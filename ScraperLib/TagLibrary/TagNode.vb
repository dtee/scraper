Imports System.Text.RegularExpressions

Public Class TagNode

#Region "Regular Tag Node"
   Private _TagNodeList As New TagNodeList
   Private _ParentTagNode As TagNode
   Private _Row As ScraperDB.TagLibraryRow

   Public ReadOnly Property TagNodeList() As TagNodeList
      Get
         Return _TagNodeList
      End Get
   End Property

   Public ReadOnly Property Row() As ScraperDB.TagLibraryRow
      Get
         Return _Row
      End Get
   End Property

   Public ReadOnly Property TagName() As String
      Get
         Return Me._Row.TagName
      End Get
   End Property

   Public ReadOnly Property ScrapeTagID() As String
      Get
         Return "g" & Math.Abs(Me._Row.TagID)
      End Get
   End Property

   ''' <summary>
   ''' Used by link mapper
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ProjectTagName() As String
      Get
         Return Me._Row.ProjectRow.Name & "." & Me._Row.TagName
      End Get
   End Property

   Public Sub New(ByVal row As ScraperDB.TagLibraryRow, ByVal parentNode As TagNode)
      Me._Row = row
      Me.ParentTagNode = parentNode
   End Sub

   Public ReadOnly Property FirstNode() As TagNode
      Get
         If Me._TagNodeList.Count = 0 Then Return Nothing
         Return Me._TagNodeList(0)
      End Get
   End Property

   Public ReadOnly Property LastNode() As TagNode
      Get
         If Me._TagNodeList.Count = 0 Then Return Nothing
         Return Me._TagNodeList(Me._TagNodeList.Count - 1)
      End Get
   End Property

   Public ReadOnly Property Index() As Integer
      Get
         If Me.ParentTagNode Is Nothing Then
            Return 0
         Else
            Return Me.ParentTagNode.TagNodeList.IndexOf(Me)
         End If
      End Get
   End Property

   Public Sub MoveNode(ByVal index As Integer)
      If Me.ParentTagNode IsNot Nothing Then
         Me.ParentTagNode.TagNodeList.Move(Me, index)
      End If
   End Sub

   ''' <summary>
   ''' Create a new node under this current node.
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function NewNode() As TagNode
      Dim dt As ScraperDB.TagLibraryDataTable = Me._Row.Table
      Dim newRow As ScraperDB.TagLibraryRow = dt.NewRow()

      newRow.TagLibraryRowParent = Me._Row
      newRow.TagName = "Node" & Me.TagNodeList.Count
      newRow.ProjectRow = Me._Row.ProjectRow

      NewNode = New TagNode(newRow, Me)

      dt.AddTagLibraryRow(newRow)

      Return NewNode
   End Function


   ''' <summary>
   ''' Root will not be removed. Remove self from the parent, then delete self
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub Delete()
      If Me._ParentTagNode IsNot Nothing Then
         Me._ParentTagNode.TagNodeList.Remove(Me)
         _Row.Delete()
      End If
   End Sub

   ''' <summary>
   ''' Set or get parent node
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ParentTagNode() As TagNode
      Get
         Return Me._ParentTagNode
      End Get
      Set(ByVal value As TagNode)
         If value Is Nothing Then Exit Property

         If Me._ParentTagNode IsNot Nothing Then
            ' Remove self from parent
            Me._ParentTagNode.TagNodeList.Remove(Me)
         End If

         Me._ParentTagNode = value           ' Change the current parent
         Me._Row.TagLibraryRowParent = Me._ParentTagNode.Row      ' Change parent row.
         Me._ParentTagNode.TagNodeList.add(Me)                    ' Add to the new parent's list
      End Set
   End Property

   ''' <summary>
   ''' Is Valid node.
   ''' 1.) Tag Name is Valid
   ''' 2.) Child "Save" Nodes does not contains duplicate Nodes
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsValid() As Boolean
      Get
         Dim msg As String = ""
         IsValid = True

         Me._Row.RowError = ""
         If Me._Row.TagName.Length = 0 Then
            msg &= "Tag name must not contain at least one letter."
            Me._Row.RowError = "Tag name must not contain at least one letter."
            IsValid = False
         End If

         ' Check Name
         For Each c As Char In Me.Row.TagName
            If Not (Char.IsLetterOrDigit(c) Or c = "_") Then
               msg &= "Tag name must contain only letter or digits or _."
               Me._Row.RowError = "Tag name must contain only letter or digits or _."
               IsValid = False
            End If
         Next

         ' Check for same name node.
         If Me.ParentTagNode IsNot Nothing Then
            Dim dv As New DataView(Me._Row.Table)
            dv.RowFilter = "TagName = '" & Me._Row.TagName & "' AND ISSAVEDATA = TRUE AND Parent_TagID = " & Me._Row.Parent_TagID

            If dv.Count > 1 Then
               msg &= Me._Row.TagName & " is a duplicate field Node."
               Me._Row.RowError = "Field Node must be unique."

               IsValid = False
            End If
         End If

         Return IsValid
      End Get
   End Property

   Public ReadOnly Property IsParent() As Boolean
      Get
         Return Me.TagNodeList.Count > 0
      End Get
   End Property

   Public ReadOnly Property IsDataTable() As Boolean
      Get
         If Me.IsParent Then
            For Each t As TagNode In Me.TagNodeList
               If t.Row.isSaveData Then
                  Return True
               End If
            Next
         End If

         Return False
      End Get
   End Property

   Public Property IsSaveData() As Boolean
      Get
         Return Me._Row.isSaveData
      End Get
      Set(ByVal value As Boolean)
         Me._Row.isSaveData = value
         Me._ParentTagNode.Row.IsDataTable = False

         ' Change parent's data table
         For Each n As TagNode In Me._ParentTagNode.TagNodeList
            If n.IsSaveData Then
               Me._ParentTagNode.Row.IsDataTable = True
            End If
         Next
      End Set
   End Property

   Public Overloads Function toString() As String
      Return Me._Row.ProjectRow.Name & "." & Me._Row.TagName
   End Function
#End Region

   ' Refresh the data
   Public Sub refresh()
      ' Change parent's data table
      Me.Row.IsDataTable = False
      For Each n As TagNode In Me.TagNodeList
         If n.IsSaveData Then
            Me.Row.IsDataTable = True
         End If
      Next
   End Sub

#Region "Scraper Tag Node"
   Private _datatype As DataType
   Public Property DataType() As DataType
      Get
         Return _datatype
      End Get
      Set(ByVal value As DataType)
         Me._datatype = value

         If value Is Nothing Then
            Me.Row.DataTypeRow = Nothing
         Else
            Me.Row.DataTypeRow = Me._datatype.Row
         End If
      End Set
   End Property

   Public ReadOnly Property ParentDataTableTagNode() As TagNode
      Get
         If (Me.ParentTagNode IsNot Nothing AndAlso Me.ParentTagNode.IsDataTable) Then
            Return Me.ParentTagNode
         End If

         Return Nothing
      End Get
   End Property

   ''' <summary>
   ''' Rebuild Tables, Regex patterns.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub RebuildTable(ByVal ds As DataSet)
      _ScraperRegex = Nothing
      _ScraperReverseRegex = Nothing
      _DataDT = Nothing
      _FieldDT = Nothing
      _ScrapedDS = ds
   End Sub

   Public ReadOnly Property ParentDataDT() As DataTable
      Get
         Dim parentNode As TagNode = Me.ParentTagNode
         While (parentNode IsNot Nothing)
            If parentNode.IsDataTable Then
               Return parentNode.DataDT
            End If

            parentNode = Me.ParentTagNode.ParentTagNode
         End While

         Return Nothing
      End Get
   End Property

   Private _ScrapedDS As DataSet

   Public Sub ClearData()
      'If Me._DataDT IsNot Nothing Then _DataDT.Clear()
      If Me._FieldDT IsNot Nothing Then FieldDT.Clear()
   End Sub

   Private _ScraperRegex As String = Nothing
   Public ReadOnly Property ScraperRegexCapture() As String
      Get
         If Not Me.IsParent Then
            Return _ScraperRegex
         End If

         If _ScraperRegex IsNot Nothing Then
            'Console.WriteLine(_ScraperRegex)
            Return _ScraperRegex
         End If

         ' FOR EACH DATAROW IN DATAVIEW
         Dim regexString As String = ""

         For Each aTagNode As TagNode In Me.TagNodeList
            Dim tempRegex As String = "", minMax As String

            'Set Greedy, lazy or given length
            If aTagNode.Row.EndTag = "" Then
               minMax = "*"               ' Problem with greedy, if i have nextNode, we don't want greedy, we want lazy
            ElseIf (aTagNode.Row.MaxChars = 0) Then
               minMax = "*?"
            Else
               minMax = "{0," & aTagNode.Row.MaxChars & "}?"
            End If

            ' IF REGEX, then
            Dim tag1 As String = aTagNode.Row.StartTag
            If (aTagNode.Row.IsStartTagRegex = False AndAlso Not aTagNode.Row.IsSingleRegex) Then
               tag1 = Regex.Escape(tag1)
            End If

            ' IF REGEX, then
            Dim tag2 As String = aTagNode.Row.EndTag, body As String
            If (aTagNode.Row.IsEndTagRegex = False) Then
               tag2 = Regex.Escape(tag2)
            End If

            Dim name As String = "<" & aTagNode.ScrapeTagID & ">"

            ' SINGLE REGEX MODE
            If (aTagNode.Row.IsSingleRegex) Then
               tempRegex = String.Format("(?{0}{1})", name, tag1)
            Else
               tag1 = String.Format("(?{0}{1})", "<" & aTagNode.ScrapeTagID & "s>", tag1)
               tag2 = String.Format("(?{0}{1})", "<" & aTagNode.ScrapeTagID & "e>", tag2)
               body = String.Format("(?{0}{1}{2})", name, "[\w\W\s]", minMax)
               tempRegex = String.Format("{0}{1}{2}", tag1, body, tag2)
            End If

            If aTagNode.Row.EndTag = "" AndAlso aTagNode IsNot aTagNode.ParentTagNode.LastNode AndAlso Not aTagNode.Row.IsSingleRegex Then
               body = String.Format("(?{0}{1})", name, "[\w\W\s]*?")
               regexString += String.Format("{0}{1}", tag1, body)
            ElseIf (aTagNode.Row.IsOptional) Then            ' Add more lazy operator IF IT OPTIONAL!
               regexString += String.Format("([\w\W\s]*?{0}|[\w\W\s]*?)[\w\W\s]*?", tempRegex)
               'regexString += String.Format("(?={0})?", tempRegex)
            ElseIf (aTagNode Is aTagNode.ParentTagNode.LastNode Or aTagNode.Row.IsSingleRegex) Then
               regexString += tempRegex
            Else
               regexString += tempRegex & "[\w\W\s]*?"
            End If
         Next

         Console.WriteLine("Regex: " & regexString)
         _ScraperRegex = regexString
         Return _ScraperRegex
      End Get
   End Property

   Private _ScraperReverseRegex As String
   Public ReadOnly Property ScraperReverseRegexCapture() As String
      Get
         If _Row.isReverseSearch = False Then
            Return Nothing
         End If

         If _ScraperReverseRegex IsNot Nothing Then
            Return _ScraperReverseRegex
         End If

         Dim tag1 As String = _Row.StartTag
         If _Row.IsStartTagRegex = False Then
            tag1 = Regex.Escape(tag1)
         End If

         Dim tag2 As String = _Row.EndTag
         If _Row.IsEndTagRegex = False Then
            tag2 = Regex.Escape(tag2)
         End If

         Dim body As String
         tag1 = String.Format("(?{0}{1})", "<" & Me.ScrapeTagID & "s>", tag1)
         tag2 = String.Format("(?{0}{1})", "<" & Me.ScrapeTagID & "e>", tag2)
         body = String.Format("(?{0}{1})", "<" & Me.ScrapeTagID & ">", "[\w\W\s]*?")
         _ScraperReverseRegex = String.Format("{0}{1}{2}", tag1, body, tag2)

         Return _ScraperReverseRegex
      End Get
   End Property

   Private _DataDT As DataTable = Nothing
   ''' <summary>
   ''' Create a data table if the TagNode given is a DataTable node, else return nothing
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property DataDT() As DataTable
      Get
         If _DataDT Is Nothing AndAlso Me.IsDataTable Then
            ' Check parent tag nodes, if they have the same table, then don't create it
            ' This need to change to 

            Me._DataDT = DataTableUtil.CreateDataTable(Me)

            ' Project Data set - append ID to tablename
            If Me._ScrapedDS Is Me.Row.Table.DataSet Then
               Dim ds As ScraperDB = Me._ScrapedDS
               Dim crawlProjRow As ScraperDB.CrawlProjectRow = ds.CrawlProject.Rows(0)

               If crawlProjRow.CrawlProjectID >= 0 Then
                  Me._DataDT.TableName &= "_" & crawlProjRow.CrawlProjectID
               End If
            End If

            If Me._ScrapedDS.Tables.Contains(Me._DataDT.TableName) Then
               Dim existingDT As DataTable = Me._ScrapedDS.Tables(Me._DataDT.TableName)

               existingDT.Merge(Me._DataDT)       ' Merge the two table, maybe there's a change in scheme (added columns)
               Me._DataDT = existingDT
            Else
               'DataTableUtil.AddRelation()
               '' Add constraints to the data table
               'Dim colList As New List(Of DataColumn)

               'For Each node As TagNode In Me.TagNodeList
               '   If node.Row.IsIdentfier Then
               '      colList.Add(Me._DataDT.Columns(node.TagName))
               '   End If
               'Next

               'If (colList.Count > 0) Then
               '   ' add identity constraint to the data table.
               '   Dim constraint As New Data.UniqueConstraint("identifier", colList.ToArray, False)
               '   Me._DataDT.Constraints.Add(constraint)
               'End If
            End If
         End If

         Return _DataDT
      End Get
   End Property

   Private _FieldDT As ScraperTempDS.FieldDTDataTable = Nothing
   ''' <summary>
   ''' Build Data Field for any kind of tag node!
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property FieldDT() As ScraperTempDS.FieldDTDataTable
      Get
         If _FieldDT Is Nothing Then
            Me._FieldDT = New ScraperTempDS.FieldDTDataTable()
         End If

         Return _FieldDT
      End Get
   End Property

   Public Function NewFieldData(ByVal data As String, _
      ByVal DataTagIndex As Integer, ByVal EndTagIndex As Integer) As ScraperTempDS.FieldDTRow
      Dim r As ScraperTempDS.FieldDTRow = Me.FieldDT.NewFieldDTRow
      'r.PID = PID
      r.Data = data                ' This will always be 2, what ever the name of the field is.
      r.DataTagIndex = DataTagIndex
      r.EndTagIndex = EndTagIndex

      Me.FieldDT.Rows.Add(r)
      Return r
   End Function

   Public Function NewFieldNoLinkData(ByVal data As String, _
      ByVal DataTagIndex As Integer, ByVal EndTagIndex As Integer) As ScraperTempDS.FieldDTRow
      Dim r As ScraperTempDS.FieldDTRow = NewFieldData(data, DataTagIndex, EndTagIndex)
      Return r
   End Function
#End Region
End Class
