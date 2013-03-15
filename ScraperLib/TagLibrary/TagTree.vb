''' <summary>
''' TagTree provide a way to edit tag library on a little higher level than database. 
''' - Also acts as a container of tempory data for a Scrape Session.
''' </summary>
''' <remarks></remarks>
Public Class TagTree

#Region "Normal - Tag Releated"
   Private _Project As Project
   Private _TagLibDT As ScraperDB.TagLibraryDataTable
   Private _RootNode As TagNode

   ''' <summary>
   ''' Create a new TagTree
   ''' </summary>
   ''' <param name="Proj"></param>
   ''' <remarks></remarks>
   Public Sub New(ByVal proj As Project)
      Me._UrlTagNodes = New List(Of TagNode)
      Me._Project = proj
      Me._TagLibDT = _Project.Dataset.TagLibrary

      ' Load the root node
      Dim dv As New DataView(Me._TagLibDT)
      dv.RowFilter = Me._TagLibDT.Parent_TagIDColumn.ColumnName & " is null AND " _
                     & "ProjectID = " & Me._Project.ProjectRow.ProjectID

      ' Create a root node
      If dv.Count = 0 Then
         Dim r As ScraperDB.TagLibraryRow = Me._TagLibDT.NewRow
         r.TagName = "Root"
         r.ProjectRow = Me._Project.ProjectRow
         Me._TagLibDT.AddTagLibraryRow(r)
      End If

      Me._RootNode = New TagNode(dv.Item(0).Row, Nothing)
      RecursiveLoadTags(Me._RootNode)
   End Sub

   ''' <summary>
   ''' Recursive Load Tags
   ''' </summary>
   ''' <param name="parentTag"></param>
   ''' <remarks></remarks>
   Private Sub RecursiveLoadTags(ByVal parentTag As TagNode)
      ' Add child node - how does the order work?
      Dim dv As New DataView(Me._TagLibDT)
      dv.RowFilter = "Parent_TagID = " & parentTag.Row.TagID
      dv.Sort = "OrderNumber"

      For i As Integer = 0 To dv.Count - 1
         Dim childRow As ScraperDB.TagLibraryRow = dv.Item(i).Row
         Dim t As New TagNode(childRow, parentTag)

         RecursiveLoadTags(t)
      Next
   End Sub

   ''' <summary>
   ''' Get the root node
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property RootNode() As TagNode
      Get
         Return Me._RootNode
      End Get
   End Property

   ''' <summary>
   ''' Valid
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsValid() As Boolean
      Get
         Return RecursiveIsValid(Me._RootNode)
      End Get
   End Property

   ''' <summary>
   ''' Determine each node in the tree to see if they are valid
   ''' </summary>
   ''' <param name="node"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function RecursiveIsValid(ByVal node As TagNode) As Boolean
      Dim isValid As Boolean = node.IsValid

      For Each n As TagNode In node.TagNodeList
         Return RecursiveIsValid(n) And isValid
      Next

      Return True
   End Function

#End Region

#Region "Scrape/Data Releated"
   Private _ScrapedDS As DataSet                               ' Have a global dataset.
   Private _DataTagNodes As New LinkedList(Of TagNode)
   Private _UrlTagNodes As List(Of TagNode)

   Public ReadOnly Property ScrapedDS() As DataSet
      Get
         Return _ScrapedDS
      End Get
   End Property


   ''' <summary>
   ''' Rebuild the Data Table, Field Tables: For when the tree may get changed.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub RebuildDataTable(Optional ByVal isCrawlProjectWide As Boolean = False)
      ' Recursive rebuild tables
      If isCrawlProjectWide Then
         Me._ScrapedDS = Me.RootNode.Row.Table.DataSet         ' Remove the table then rebuild it
      Else
         Me._ScrapedDS = New DataSet(Me._Project.ProjectRow.Name)
      End If

      Me._UrlTagNodes.Clear()             ' clear the url tag node list
      Me._DataTagNodes.Clear()

      RecursiveRebuildTables(Me._RootNode, Nothing)
   End Sub

   ''' <summary>
   ''' Rebuild the tables
   ''' </summary>
   ''' <param name="parentNode"></param>
   ''' <param name="pDTNode"></param>
   ''' <remarks></remarks>
   Private Sub RecursiveRebuildTables(ByVal parentNode As TagNode, ByVal pDTNode As TagNode)
      parentNode.RebuildTable(Me._ScrapedDS)

      If parentNode.IsDataTable Then
         'parentNode.ParentDataTableTagNode = Nothing
         'If pDTNode IsNot Nothing Then parentNode.ParentDataTableTagNode = pDTNode ' Set the right parent data table node

         Me._DataTagNodes.AddFirst(parentNode)            'This is a data table node

         If Not _ScrapedDS.Tables.Contains(parentNode.DataDT.TableName) Then
            ' Add it to the Scraper DB ( Wow BIG Dataset - need better solution?)
            _ScrapedDS.Tables.Add(parentNode.DataDT)

            ' If i am a scraped DS, then 
            If Me._ScrapedDS Is Me._TagLibDT.DataSet Then
               ' Change the name of the datatable, add SYS
               parentNode.DataDT.TableName = parentNode.DataDT.TableName

               ' Add relationship, each data references urlID
               Dim col As DataColumn = parentNode.DataDT.Columns(DataTableUtil.URLIDFK)
               Dim urldt As ScraperDB.UrlDataTable = CType(Me._ScrapedDS, ScraperDB).Url

               Dim newRelation As New DataRelation(urldt.TableName & "_" & parentNode.DataDT.TableName, urldt.UrlIDColumn, col, True)
               _ScrapedDS.Relations.Add(newRelation)

               newRelation.ChildKeyConstraint.UpdateRule = Rule.Cascade
               newRelation.ChildKeyConstraint.DeleteRule = Rule.Cascade
            End If
         End If

         'Me._ScrapedDS.Merge(parentNode.DataDT)
         Dim dt As DataTable = parentNode.DataDT

         If pDTNode IsNot Nothing Then
            Dim parentDT As DataTable = _ScrapedDS.Tables(pDTNode.DataDT.TableName)
            Dim childDT As DataTable = _ScrapedDS.Tables(parentNode.DataDT.TableName)
            DataTableUtil.AddRelation(parentDT, childDT)       ' Add relation
         End If

         pDTNode = parentNode
      End If

      ' Url Tag
      If parentNode.Row.IsURL Then
         Me._UrlTagNodes.Add(parentNode)

         ' Special Url, for data table mapping across differnt pages/projects
         'If parentNode.Row.GetLinkMappingRows.Length > 0 Then
         '   parentNode.IsSaveData = True           ' Force url to be saved.
         'End If
      End If

      For Each node As TagNode In parentNode.TagNodeList
         RecursiveRebuildTables(node, pDTNode)
      Next
   End Sub

   ''' <summary>
   ''' Clear data in the TagNode
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub ClearData()
      RecursiveClearData(Me._RootNode)
   End Sub

   Private Sub RecursiveClearData(ByVal node As TagNode)
      node.ClearData()

      For Each n As TagNode In node.TagNodeList
         RecursiveClearData(n)
      Next
   End Sub

   Public ReadOnly Property UrlTagNodes() As List(Of TagNode)
      Get
         Return _UrlTagNodes
      End Get
   End Property

   Public ReadOnly Property DataTagNodes() As LinkedList(Of TagNode)
      Get
         Return _DataTagNodes
      End Get
   End Property
#End Region
End Class

