Public Class DataMappingManager
   Private _CrawlProject As CrawlProject
   Public Sub New(ByVal crawlProject As CrawlProject)
      Me._CrawlProject = crawlProject
   End Sub
   ''' <summary>
   ''' Return true if Data mapping is Valid
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsValid() As Boolean
      Get
         ' Build map Tables
         IsValid = True

         For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
            For Each node As TagNode In proj.TagTree.DataTagNodes
               IsValid = IsValid
            Next
         Next

         Return IsValid
      End Get
   End Property

   ''' <summary>
   ''' Get Identity columns used for updating data.
   ''' </summary>
   ''' <param name="DT">Data table</param>
   ''' <param name="isUpdate">ID column for update? or to check to see if data exists.</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getIdentityColumns(ByVal DT As DataTable, ByVal isUpdate As Boolean) As List(Of DataColumn)
      Dim colList As New List(Of DataColumn)
      If DataTableUtil.IsGeneratedTable(DT) Then
         ' Look for identity fields in the tag librarys, data table does not carry the information.
         If (DT.Columns.Contains(DataTableUtil.CHECKSUM)) Then
            colList.Add(DT.Columns(DataTableUtil.CHECKSUM))          ' Checksum is one of the identifiers.
         Else
            colList.Add(DT.Columns(DataTableUtil.URLIDFK))           ' UrlID is the update key
         End If
      Else
         ' Url Link and post data must be unique
         If isUpdate Then
            colList.Add(DT.PrimaryKey(0))          ' primary key is the unique constraint
            'ElseIf DT Is Me._CrawlProject.Dataset.Url Then
            '   Dim urlTable As ScraperDB.UrlDataTable = DT
            '   colList.Add(urlTable.CrawlProjectID_FKColumn)          ' Unique based on crawl project
            '   colList.Add(urlTable.UrlLinkColumn)
            '   'colList.Add(urlTable.PostDataColumn)                     ' Post data and url link is the identifier for ul
         ElseIf DT Is Me._CrawlProject.Dataset.Project_Url Then
            Dim projUrlTable As ScraperDB.Project_UrlDataTable = DT
            colList.Add(projUrlTable.UrlIDColumn)
            colList.Add(projUrlTable.ProjectIDColumn)                ' Post data and url link is the identifier for ul
            'ElseIf DT Is Me._CrawlProject.Dataset.CrawlProject Then
            '   Dim projTable As ScraperDB.CrawlProjectDataTable = DT
            '   colList.Add(projTable.NameColumn)                     ' These two must be unique
            '   colList.Add(projTable.CrawlProjectIDColumn)           ' These two must be unique.
         ElseIf DT Is Me._CrawlProject.Dataset.Proxy Then
            Dim proxyTable As ScraperDB.ProxyDataTable = DT
            colList.Add(proxyTable.ProxyLinkColumn)                     ' These two must be unique
            colList.Add(proxyTable.ProxyPortColumn)                     ' These two must be unique.
         ElseIf DT Is Me._CrawlProject.Dataset.DataType Then
            Dim dataTable As ScraperDB.DataTypeDataTable = Me._CrawlProject.Dataset.DataType
            colList.Add(dataTable.DataTypeNameColumn)                     ' These two must be unique
         Else
            colList.Add(DT.PrimaryKey(0))          ' primary key is the unique constraint
         End If
      End If

         Return colList
   End Function

   '''' <summary>
   '''' Return table mapping collection
   '''' </summary>
   '''' <returns></returns>
   '''' <remarks></remarks>
   'Public Function getTableMaps() As System.Data.Common.DataTableMappingCollection
   '   Dim tMaps As New System.Data.Common.DataTableMappingCollection
   '   Dim ds As DataSet = Me._CrawlProject.ScrapedDS

   '   For Each r As ScraperDB.DataMappingTablesRow In Me._TableMaps.Rows
   '      Dim tableMapping As System.Data.Common.DataTableMapping = New System.Data.Common.DataTableMapping
   '      tableMapping.SourceTable = r.TagLibraryRow.TagName
   '      tableMapping.DataSetTable = r.TableName
   '      For Each fRow As ScraperDB.DataMappingFieldsRow In r.GetChildRows(Me._FieldMaps.ParentRelations(0))
   '         tableMapping.ColumnMappings.Add(fRow.TagLibraryRow.TagName, fRow.FieldName)
   '      Next

   '      tMaps.Add(tableMapping)
   '   Next

   '   Return tMaps
   'End Function

   Private Function isValidTableName(ByVal name As String) As Boolean
      For Each c As Char In name
         If Not (Char.IsLetterOrDigit(c) Or c = "_") Then
            Return False
         End If
      Next
      Return True
   End Function

   Private Function isValidFieldName(ByVal name As String) As Boolean
      Return isValidTableName(name)
   End Function


#Region "Datatable update order"
   Private dtLevel As New Dictionary(Of DataTable, Integer)
   Public Function getDataTablesUpdateOrder(ByVal isWholeProject As Boolean) As List(Of DataTable)
      dtLevel.Clear()
      Dim tableList As New List(Of DataTable)

      Dim ds As ScraperDB = Me._CrawlProject.Dataset

      ' Add all the root data tables
      For Each tbl As Data.DataTable In Me._CrawlProject.Dataset.Tables
         If (Not isWholeProject) Then
            If DataTableUtil.IsGeneratedTable(tbl) Then ' Just generated tables
               ' Self referencing parent table
               If tbl.ParentRelations.Count = 1 AndAlso tbl.ParentRelations(0).ParentTable Is tbl Then
                  recursiveFindLevel(tbl, 0)
               End If

               If tbl.ParentRelations.Count = 0 Then
                  recursiveFindLevel(tbl, 0)
               End If
            End If

            If tbl Is Me._CrawlProject.Dataset.Url Then        ' Partail, the url needs to be updated
               recursiveFindLevel(tbl, 0)
               ' TODO: Need to add schedule history here.
            End If
         Else
            If tbl.ParentRelations.Count = 0 Then        ' Save the whole project.
               recursiveFindLevel(tbl, 0)
            End If
         End If
      Next

      Dim maxLevel As Integer = 0
      For Each dt As DataTable In dtLevel.Keys
         If dtLevel(dt) > maxLevel Then
            maxLevel = dtLevel(dt)
         End If
      Next

      For i As Integer = 0 To maxLevel
         For Each dt As DataTable In dtLevel.Keys
            If dtLevel(dt) = i Then
               tableList.Add(dt)
            End If
         Next
      Next

      Return tableList
   End Function

   Private Sub recursiveFindLevel(ByVal dt As DataTable, ByVal level As Integer)
      dtLevel.Add(dt, level)

      For Each rel As Data.DataRelation In dt.ChildRelations
         If rel.ChildTable Is rel.ParentTable Then
            If (dtLevel(dt) <= level) Then
               dtLevel(dt) = level + 1
            End If
            Continue For
         End If

         If Not dtLevel.ContainsKey(rel.ChildTable) Then
            recursiveFindLevel(rel.ChildTable, level + 1)
         Else
            If (dtLevel(rel.ChildTable) <= level) Then
               dtLevel(rel.ChildTable) = level + 1
            End If
         End If
      Next
   End Sub
#End Region
End Class
