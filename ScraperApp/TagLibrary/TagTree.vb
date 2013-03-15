''' <summary>
''' TagTree provide a way to edit tag library on a little higher level than database. 
''' </summary>
''' <remarks></remarks>
Public Class TagTree
   Private dt As ScraperDB.TagLibraryDataTable
   Private projectRow As ScraperDB.ProjectRow

   Public Sub New(ByVal dt As ScraperDB.TagLibraryDataTable, ByVal projectRow As ScraperDB.ProjectRow)
      Me.dt = dt
      Me.projectRow = projectRow
   End Sub

   Public ReadOnly Property IsValid() As Boolean
      Get
         Return False
      End Get
   End Property

   Private _RootTag As ScraperDB.TagLibraryRow
   ''' <summary>
   ''' Return a Roottag to the tag library, create the Root Tag if it doesn't exists.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property RootTag() As ScraperDB.TagLibraryRow
      Get
         If _RootTag Is Nothing And dt IsNot Nothing Then
            Dim dv As New DataView(dt)
            dv.RowFilter = String.Format("ProjectID = {0} AND Parent_TagID is null", Me.projectRow.ProjectID)

            If (dv.Count = 0) Then
               'Create a new root node
               _RootTag = CreateTag("Root", Nothing)
            Else
               _RootTag = dv.Item(0).Row
            End If
         End If
         Return _RootTag
      End Get
   End Property

   ''' <summary>
   ''' Delete a Tag Row
   ''' </summary>
   ''' <param name="tag"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function DeleteTag(ByVal tag As ScraperDB.TagLibraryRow) As Boolean
      ' Dataset is set to cascade delete rows.
      tag.Delete()
   End Function

   ''' <summary>
   ''' Change a Tag row's parent
   ''' </summary>
   ''' <param name="dest"></param>
   ''' <param name="source"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function MoveTag(ByVal dest As ScraperDB.TagLibraryRow, ByVal source As ScraperDB.TagLibraryRow) As Boolean
      ' Check to see if the move is a valid move - dest is not source's parent
      Dim temp As ScraperDB.TagLibraryRow = dest
      While (temp IsNot Nothing)
         If (temp Is source) Then
            Return False
         End If

         temp = temp.TagLibraryRowParent
      End While

      source.TagLibraryRowParent = dest

      Return True
   End Function

   ''' <summary>
   ''' Create a tag row, set the defaults. 
   ''' </summary>
   ''' <param name="name">Name of a new tag row to create</param>
   ''' <param name="parentRow">Parent tag row, the tag library is a tree struture.</param>
   ''' <returns>A newly added row - does not do error checking.</returns>
   ''' <remarks></remarks>
   Public Function CreateTag(ByVal name As String, ByVal parentRow As ScraperDB.TagLibraryRow) As ScraperDB.TagLibraryRow
      Dim row As ScraperDB.TagLibraryRow = dt.NewTagLibraryRow
      row.ProjectID = projectRow.ProjectID
      row.TagName = name

      row.OrderNumber = 0

      ' Init to default
      row.StartTag = ""
      row.EndTag = ""
      row.MaxChars = 0

      row.IsOptional = False
      row.isSaveData = False

      row.IsStartTagRegex = False
      row.IsEndTagRegex = False
      row.IsAppendEndTag = False
      row.IsAppendStartTag = False

      row.isReverseSearch = False
      row.DynamicCode = ""
      row.IsSingleRegex = False
      row.IsURL = False

      row.IsSharedTag = False

      row.TagLibraryRowParent = parentRow

      Me.dt.AddTagLibraryRow(row)

      Return row
   End Function
End Class

