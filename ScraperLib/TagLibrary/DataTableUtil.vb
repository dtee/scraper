Public Class DataTableUtil
   ''' <summary>
   ''' Data DT stuffs.
   ''' </summary>
   ''' <remarks></remarks>
   Public Enum DataDTCol
      ID = 0
      PID = 1
      Data = 2
      StartIndex = 3
      StopIndex = 4
      TagStartIndex = 5
      TagStartLength = 6
      TagEndIndex = 7
      TagEndLength = 8
   End Enum

#Region "Shared Functions"
   Public Shared ID As String = "SYS_ID"           ' SYS_ID Field Name
   'Public Shared PID As String = "SYS_PID"         ' Parent Field Name
   Public Shared URL As String = "SYS_URL"         ' URL Data 
   Public Shared CHECKSUM As String = "SYS_CHECKSUM"     ' Identifier
   Public Shared URLIDFK As String = "UrlID_FK"

   'Public Shared URL_DATASET_TABLENAME = "SYS_Url_Dataset"

   Public Shared Function URL_DATASET_TABLENAME(ByVal projID As Integer) As String
      If projID >= 0 Then
         Return "SYS_Url_Dataset" & "_" & projID
      Else
         Return "SYS_Url_Dataset"
      End If
   End Function

   Public Shared Function URL_DATACount_TABLENAME(ByVal projID As Integer) As String
      If projID >= 0 Then
         Return "SYS_Url_Datacount" & "_" & projID
      Else
         Return "SYS_Url_Datacount"
      End If
   End Function

   Public Shared POSTFIX As String = "ID_FK"

   ''' <summary>
   ''' Is the data table a system generated table? ex: SYS_ tables
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function IsGeneratedTable(ByVal dt As DataTable) As Boolean
      Return dt.TableName.Contains("SYS_")
   End Function

   ''' <summary>
   ''' Create a data table that keeps tracks of number of data per url
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function CreateUrlDataCountTable(ByVal ds As ScraperDB, ByVal projID As Integer) As DataTable
      Dim urlDataset As New DataTable(URL_DATACount_TABLENAME(projID))

      urlDataset.Columns.Add("UrlDatasetID", GetType(Int32))
      urlDataset.Columns(0).AutoIncrement = True
      urlDataset.Columns(0).Unique = True
      urlDataset.Columns(0).AutoIncrementStep = -1
      urlDataset.Columns(0).AutoIncrementSeed = -1

      urlDataset.PrimaryKey = New DataColumn() {urlDataset.Columns(0)}
      ds.Tables.Add(urlDataset)

      Dim fkColName As String = ds.Url.TableName + POSTFIX

      Dim projectUrlCol As New DataColumn(fkColName, GetType(Int32))
      urlDataset.Columns.Add(projectUrlCol)

      Dim relationName As String = ds.Url.TableName & "_" & urlDataset.TableName

      ' Add relation
      Dim newRelation As New DataRelation(relationName, ds.Url.UrlIDColumn, projectUrlCol, True)
      ds.Relations.Add(newRelation)

      newRelation.ChildKeyConstraint.UpdateRule = Rule.Cascade
      newRelation.ChildKeyConstraint.DeleteRule = Rule.Cascade

      For Each tbl As DataTable In ds.Tables
         If DataTableUtil.IsGeneratedTable(tbl) And Not tbl.TableName.Contains("SYS_Url_Dataset") Then
            DataTableUtil.AddRelation(tbl, urlDataset)
         End If
      Next

      Return urlDataset
   End Function

   ''' <summary>
   ''' Create Url Relational Table
   ''' </summary>
   ''' <param name="ds"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function CreateUrlRelationalTable(ByVal ds As ScraperDB, ByVal projID As Integer) As DataTable
      Dim urlDataset As New DataTable(URL_DATASET_TABLENAME(projID))

      urlDataset.Columns.Add("UrlDatasetID", GetType(Int32))
      urlDataset.Columns(0).AutoIncrement = True
      urlDataset.Columns(0).Unique = True
      urlDataset.Columns(0).AutoIncrementStep = -1
      urlDataset.Columns(0).AutoIncrementSeed = -1

      urlDataset.PrimaryKey = New DataColumn() {urlDataset.Columns(0)}
      ds.Tables.Add(urlDataset)

      Dim fkColName As String = ds.Url.TableName + POSTFIX

      Dim projectUrlCol As New DataColumn(fkColName, GetType(Int32))
      urlDataset.Columns.Add(projectUrlCol)

      Dim relationName As String = ds.Url.TableName & "_" & urlDataset.TableName

      ' Add relation
      Dim newRelation As New DataRelation(relationName, ds.Url.UrlIDColumn, projectUrlCol, True)
      ds.Relations.Add(newRelation)

      newRelation.ChildKeyConstraint.UpdateRule = Rule.Cascade
      newRelation.ChildKeyConstraint.DeleteRule = Rule.Cascade

      For Each tbl As DataTable In ds.Tables
         If DataTableUtil.IsGeneratedTable(tbl) And Not tbl.TableName.Contains("SYS_Url_Dataset") Then
            DataTableUtil.AddRelation(tbl, urlDataset)
         End If
      Next

      Return urlDataset
   End Function

   ''' <summary>
   ''' Add Relation betweeen the parent and the child
   ''' </summary>
   ''' <param name="parentTable"></param>
   ''' <param name="childTable"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function AddRelation(ByVal parentTable As DataTable, ByVal childTable As DataTable) As Boolean
      Dim fkColName As String = parentTable.TableName + POSTFIX

      If childTable.Columns.Contains(fkColName) Then
         Return False
      Else
         Dim relationName As String = parentTable.TableName & "_" & childTable.TableName
         Dim col As New DataColumn(fkColName, GetType(Int32))

         col.AllowDBNull = True
         childTable.Columns.Add(col)

         ' Add relation
         Dim newRelation As New DataRelation(relationName, parentTable.Columns(DataTableUtil.ID), col, True)
         parentTable.DataSet.Relations.Add(newRelation)

         newRelation.ChildKeyConstraint.UpdateRule = Rule.Cascade
         newRelation.ChildKeyConstraint.DeleteRule = Rule.Cascade
         Return True
      End If
   End Function

   ''' <summary>
   ''' Create Data table.
   ''' </summary>
   ''' <param name="aTagNode"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function CreateDataTable(ByVal aTagNode As TagNode) As DataTable
      Dim dt As New DataTable("SYS_" & aTagNode.Row.TagName)

      Dim cols As DataColumnCollection = dt.Columns
      ' Add the identity field.
      Dim column As DataColumn = New DataColumn

      column.DataType = System.Type.GetType("System.Int32")
      column.ColumnName = DataTableUtil.ID
      column.AutoIncrement = True
      column.AutoIncrementSeed = -1
      column.AutoIncrementStep = -1
      cols.Add(column)

      'cols.Add(New DataColumn(Scraper.PROJECT, GetType(String)))
      'cols.Add(New DataColumn(DataTableUtil.UrlID, GetType(String)))
      'cols.Add(New DataColumn(DataTableUtil.CreateDate, GetType(String)))
      cols.Add(New DataColumn(DataTableUtil.URL, GetType(String)))
      cols.Add(New DataColumn(DataTableUtil.URLIDFK, GetType(System.Int32)))

      'cols.Add(New DataColumn(DataTableUtil.PID, System.Type.GetType("System.Int32")))
      cols.Add(New DataColumn(DataTableUtil.CHECKSUM, GetType(String)))     ' same as url, except use choose this.

      cols(DataTableUtil.CHECKSUM).MaxLength = 32

      For Each node As TagNode In aTagNode.TagNodeList
         If node.Row.isSaveData Then
            Dim col As New DataColumn(node.Row.TagName, System.Type.GetType("System.String"))
            cols.Add(col) '.MaxLength = node.MaxChars
         End If
      Next

      dt.PrimaryKey = New DataColumn() {column}

      Return dt
   End Function
#End Region
End Class