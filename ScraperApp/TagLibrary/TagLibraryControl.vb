Imports SharedUI
Imports System.Text.RegularExpressions

Public Class TagLibraryControl

   Public Event ResultView(ByVal isOpen As Boolean, ByVal ds As DataSet)            ' Trigger container to open the result window
   Public Event NodeDataView(ByVal isOpen As Boolean, ByVal node As TagNode)          ' Trigger container to open the DataView window
   Public Event Progress(ByVal text As String)         ' text for the status lable, and % of the progress.

   Private _selectedProject As Project
   Private _RtfEdit As RTFEdit
   Private _Scraper As Scraper
   Private WithEvents _myWebClient As NetworkClient.MultiWebClient

   Private SearchPattern As String = ""         ' Keep track of the search information.
   Private SearchMatch As Match = Nothing

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

      _RtfEdit = New RTFEdit
      _Scraper = New Scraper()
      _myWebClient = New NetworkClient.MultiWebClient

      _myWebClient.SleepSeconds = 0
      _myWebClient.TimeOut = 15000
   End Sub

   Public Property Project() As Project
      Get
         Return Me._selectedProject
      End Get
      Set(ByVal value As Project)
         Me._selectedProject = value

         If Me._selectedProject IsNot Nothing Then
            Me.TagTreeView1.TagTree = Me._selectedProject.TagTree

            ' Bind sample url stuffs
            bindUrlComboBox()

            Me.UrlToolStripComboBox.SelectedItem = Me._selectedProject.ProjectRow

            ' Triger tree change, which will disable some buttons and hide windows.
            OnTreeChange()
         End If
      End Set
   End Property

   Private Sub bindUrlComboBox()
      Dim cb As ComboBox = Me.UrlToolStripComboBox.Control

      cb.DataSource = Me._selectedProject.ProjectRow.GetProject_SampleRows
      cb.DisplayMember = Me._selectedProject.Dataset.Project_Sample.SampleUrlColumn.ColumnName
   End Sub

#Region "Public property"
   Public ReadOnly Property DataSet() As DataSet
      Get
         Return Me._selectedProject.ScrapedDS
      End Get
   End Property

   Public ReadOnly Property SelectedNode() As TagNode
      Get
         Return Me.TagTreeView1.SelectedNode.TagNode
      End Get
   End Property

   Private _IsOpenNodeDataView As Boolean = False
   Public Property IsOpenNodeDataView() As Boolean
      Get
         Return Me._IsOpenNodeDataView
      End Get
      Set(ByVal value As Boolean)
         Me._IsOpenNodeDataView = value
         RaiseEvent NodeDataView(Me.IsOpenNodeDataView, Me.TagTreeView1.SelectedNode.TagNode)
      End Set
   End Property

   Private _IsOpenResultDataView As Boolean = False
   Public Property IsOpenResultDataView() As Boolean
      Get
         Return Me._IsOpenResultDataView
      End Get
      Set(ByVal value As Boolean)
         Me._IsOpenResultDataView = value
         RaiseEvent ResultView(Me._IsOpenResultDataView, Me.DataSet)
      End Set
   End Property
#End Region

#Region "Highlight Node Control and functions"
   ''' <summary>
   ''' Handles tree node changed
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub OnTreeChange() Handles TagTreeView1.TreeChanged
      Me.ColorSelectedToolStripButton.Checked = False
      Me.ColorSelectedToolStripButton.Enabled = False          ' Disable the buttons

      Me.IsOpenNodeDataView = False
      Me.IsOpenResultDataView = False         
   End Sub

   ''' <summary>
   ''' Scroll to the first data node in the text box.
   ''' </summary>
   ''' <remarks>
   ''' Only scroll if there's a selected node and node data window is opened.
   ''' </remarks>
   Private Sub ScrollText()
      If Me.TagTreeView1.SelectedNode IsNot Nothing AndAlso Me.DataNodeWindowToolStripButton.Checked Then
         Dim dt As DataTable = Me.TagTreeView1.SelectedNode.TagNode.FieldDT

         If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Me.RichTextBox1.Select()
            Dim iStart As Integer = dt.Rows(0)(3)
            Dim iStop As Integer = dt.Rows(0)(4)
            Me.RichTextBox1.SelectionStart = dt.Rows(0)(3)
            Me.RichTextBox1.SelectionLength = dt.Rows(0)(4) - dt.Rows(0)(3)
         End If
      End If
   End Sub

   ''' <summary>
   ''' Scroll text to a given FieldDT row, this is evoked by node data window. 
   ''' </summary>
   ''' <param name="row"></param>
   ''' <remarks></remarks>
   Public Sub ScrollText(ByVal row As ScraperTempDS.FieldDTRow)
      'Dim aNode As TagTreeNode = Me.TagTreeView1.SelectedNode
      'Dim index As Integer = row.DataTagIndex
      'Dim length As Integer = row.EndTagIndex - 1

      'Dim cb As Color = TagNodeColor.GetLevelColor(aNode.Level)
      'Dim cf As Color = TagNodeColor.GetOrderColor(aNode.Index)

      'aNode.MatchListIndex.Add(index)
      'Me._RtfEdit.changeBackground(index, length, cb)
      'Me._RtfEdit.changeColor(index, length, cf)

      'aNode.ForeColor = TagNodeColor.GetOrderColor(aNode.Index)
      'aNode.BackColor = TagNodeColor.GetLevelColor(aNode.Level)

      '' Color start and end tag
      'Me._RtfEdit.changeBackground(row.StartTagIndex, row.DataTagIndex - 1, cf)
      'Me._RtfEdit.changeColor(row.StartTagIndex, row.DataTagIndex - 1, cb)

      'Me._RtfEdit.changeBackground(row.EndTagIndex, row.EndTagIndex + row.EndTagLength, cf)
      'Me._RtfEdit.changeColor(row.EndTagIndex, row.EndTagIndex + row.EndTagLength, cb)

      If Me.TagTreeView1.SelectedNode IsNot Nothing Then
         'Dim row As ScraperTempDS.FieldDTRow = DataNodeWindow.FieldDT.Rows(rowIndex)
         Dim iStart As Integer = row.StartTagIndex
         Dim iStop As Integer = row.EndTagIndex + row.EndTagLength

         'Me.RichTextBox1.Focus()
         Me.RichTextBox1.Select()
         Me.RichTextBox1.SelectionStart = iStart
         Me.RichTextBox1.SelectionLength = iStop - iStart
      End If

      If Me.ColorSelectedToolStripButton.Checked = False Then
         'clear all hightlight and highlight only the section
         Me.RichTextBox1.SelectionBackColor = Color.Yellow
      End If
   End Sub

   ''' <summary>
   ''' Reset the color of the nodes to the orginal node
   ''' </summary>
   ''' <param name="aNode"></param>
   ''' <remarks></remarks>
   Private Sub ColorNodeColor(ByVal aNode As TagTreeNode)
      aNode.ForeColor = Me.TagTreeView1.ForeColor
      aNode.BackColor = Me.TagTreeView1.BackColor

      For Each n As TagTreeNode In aNode.Nodes
         ColorNodeColor(n)
      Next
   End Sub

   ''' <summary>
   ''' Color node and the given sample text
   ''' </summary>
   ''' <param name="aNode"></param>
   ''' <remarks></remarks>
   Private Sub ColorText(ByVal aNode As TagTreeNode)
      aNode.MatchListIndex.Clear()

      If aNode.Level = 5 Then
         aNode.MatchListIndex.Clear()
      End If

      For Each row As ScraperTempDS.FieldDTRow In aNode.TagNode.FieldDT.Rows
         Dim index As Integer = row.DataTagIndex
         Dim length As Integer = row.EndTagIndex - 1

         Dim cb As Color = TagNodeColor.GetLevelColor(aNode.Level)
         Dim cf As Color = TagNodeColor.GetOrderColor(aNode.Index)

         aNode.MatchListIndex.Add(index)
         Me._RtfEdit.changeBackground(index, length, cb)
         Me._RtfEdit.changeColor(index, length, cf)

         aNode.ForeColor = TagNodeColor.GetOrderColor(aNode.Index)
         aNode.BackColor = TagNodeColor.GetLevelColor(aNode.Level)

         ' Color start and end tag
         Me._RtfEdit.changeBackground(row.StartTagIndex, row.DataTagIndex - 1, cf)
         Me._RtfEdit.changeColor(row.StartTagIndex, row.DataTagIndex - 1, cb)

         Me._RtfEdit.changeBackground(row.EndTagIndex, row.EndTagIndex + row.EndTagLength, cf)
         Me._RtfEdit.changeColor(row.EndTagIndex, row.EndTagIndex + row.EndTagLength, cb)
      Next

      For Each n As TagTreeNode In aNode.Nodes
         ColorText(n)
      Next
   End Sub
#End Region

#Region "Tag Library Edit"
   Private Sub EditorToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles EditorToolStrip.ItemClicked
      If e.ClickedItem Is SearchToolStripButton Then
         doSearchText()
      ElseIf e.ClickedItem Is Me.DownloadToolStripButton Then
         doDownload()
      ElseIf e.ClickedItem Is ScrapeToolStripButton Then
         Me.doScrape()
      ElseIf e.ClickedItem Is ColorSelectedToolStripButton Then
         ' Do nothing, let the event listener handle
      ElseIf e.ClickedItem Is Me.DataNodeWindowToolStripButton Then
         Me.IsOpenNodeDataView = True
      ElseIf e.ClickedItem Is Me.ResultDataViewToolStripButton Then
         Me.IsOpenResultDataView = True
      End If
   End Sub

   Private Sub ColorSelectedToolStripButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColorSelectedToolStripButton.CheckedChanged
      doColor()
   End Sub

   ''' <summary>
   ''' handle text color based on scraped data
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doColor()
      If ColorSelectedToolStripButton.Checked Then
         _RtfEdit.Text = Me.RichTextBox1.Text
         ColorText(Me.TagTreeView1.RootNode)
         Me.RichTextBox1.Rtf = Me._RtfEdit.RTFText
      Else
         _RtfEdit.Text = Me.RichTextBox1.Text
         Me.RichTextBox1.Rtf = Me._RtfEdit.RTFText
         ColorNodeColor(Me.TagTreeView1.RootNode)
      End If
   End Sub

   ''' <summary>
   ''' Perform Data Scrape
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doScrape()
      ' Check Nodes
      If Me.TagTreeView1.RootNode.Nodes.Count = 0 Then
         MsgBox("Root must have at least one child node.")
         Exit Sub
      End If

      If Not Me._selectedProject.TagTree.IsValid Then
         MsgBox("The tag library is not valid. (check red text w/ yellow highlight nodes).")
         Exit Sub
      End If

      Try
         ' Rebuild everything - this is why we don't need to clear data.
         Me._selectedProject.TagTree.RebuildDataTable()
         Me._Scraper.Scrape(Me.RichTextBox1.Text, Me.UrlToolStripComboBox.Text, Me._selectedProject.TagTree)
         Me.ColorSelectedToolStripButton.Enabled = True

         Console.WriteLine("Scrape Finished.")
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox(ex.Message)
      End Try

      ' Auto Color Nodes
      Me.ColorSelectedToolStripButton.Enabled = True
      Me.ColorSelectedToolStripButton.Checked = True

      ' Auto view the cralwed Data Window
      Me.DataNodeWindowToolStripButton.Enabled = True

      If Me._selectedProject.ScrapedDS.Tables.Count > 0 Then
         Me.ResultDataViewToolStripButton.Enabled = True
         Me.IsOpenResultDataView = True
      Else
         Me.IsOpenNodeDataView = True
      End If
   End Sub

   ''' <summary>
   ''' Download is clicked.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doDownload()
      ' See if the selected url is part of the url list
      Dim url As String = Nothing

      If Me.UrlToolStripComboBox.SelectedItem Is Nothing Then
         url = Me.UrlToolStripComboBox.Text

         If Not Uri.IsWellFormedUriString(Me.UrlToolStripComboBox.Text, UriKind.Absolute) Then
            ' Add http to url and test again
            url = "http://" & url
         End If

         If Not Uri.IsWellFormedUriString(url, UriKind.Absolute) Then
            ' Add http to url and test again
            MsgBox("Invalid Url Format. It must be in accordance with RFC 2396 and RFC 2732.")
            Return
         Else
            Dim u As New Uri(url)
            If u.Scheme <> Uri.UriSchemeHttp Then
               MsgBox("Url must be of http portocal. (http://)")
               Return
            End If
         End If

         Me.UrlToolStripComboBox.Text = url        ' A good url
         If Me._selectedProject.ProjectRow.GetProject_SampleRows.Length > 5 Then
            ' change one of the rows.
            Dim sampleRow As ScraperDB.Project_SampleRow = Me._selectedProject.ProjectRow.GetProject_SampleRows(0)
            sampleRow.SampleText = ""
            sampleRow.SampleUrl = url

            Me.bindUrlComboBox()
            Me.UrlToolStripComboBox.SelectedItem = sampleRow
         Else
            ' Add a new sample url
            Dim sampleRow As ScraperDB.Project_SampleRow = Me._selectedProject.Dataset.Project_Sample.NewProject_SampleRow
            sampleRow.SampleText = ""
            sampleRow.SampleUrl = url
            sampleRow.ProjectRow = Me._selectedProject.ProjectRow
            Me._selectedProject.Dataset.Project_Sample.AddProject_SampleRow(sampleRow)

            ' Change the selected item
            Me.bindUrlComboBox()
            Me.UrlToolStripComboBox.SelectedItem = sampleRow
         End If

      Else
         Dim row As ScraperDB.Project_SampleRow = Me.UrlToolStripComboBox.SelectedItem
         url = row.SampleUrl
      End If

      If url Is Nothing Then
         Exit Sub
      End If

      'Download url
      If url <> "" Then
         Dim aURI As Uri = New Uri(url)
         Me._myWebClient.DownloadStringAsync(aURI, "", Nothing, aURI)
         Me.DownloadToolStripButton.Enabled = False
      End If
   End Sub

   ''' <summary>
   ''' Simulate a search on the pattern.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doSearchText()
      Dim tagNode As TagTreeNode = Me.TagTreeView1.SelectedNode

      If (tagNode IsNot Nothing) Then
         Dim startPattern As String = tagNode.Row.StartTag
         If Not tagNode.Row.IsStartTagRegex Then
            startPattern = Regex.Escape(startPattern)

            ' replace white spaces
            Dim evl As New MatchEvaluator(AddressOf replaceWhiteSpaceEvel)
            Regex.Replace(startPattern, "\w", evl)
         End If

         Dim endPattern As String = tagNode.Row.EndTag
         If Not tagNode.Row.IsEndTagRegex Then
            endPattern = Regex.Escape(endPattern)
         End If

         Dim pattern As String = startPattern & "[\w\W\s]*?" & endPattern

         Dim txt As String = Me.RichTextBox1.Text
         If pattern = SearchPattern Then
            SearchMatch = SearchMatch.NextMatch()
         Else
            SearchMatch = Regex.Match(txt, pattern)
         End If

         Me.SearchPattern = pattern

         If SearchMatch.Success Then
            Me.RichTextBox1.Select()
            Me.RichTextBox1.SelectionStart = SearchMatch.Index
            Me.RichTextBox1.SelectionLength = SearchMatch.Length
         Else
            Dim m As Match = Regex.Match(txt, SearchPattern, RegexOptions.IgnorePatternWhitespace)

            If m.Success Then
               If MsgBox("Pattern not found on page. Go back to beginning?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                  SearchPattern = ""
                  doSearchText()       ' Recursive call
               End If
            Else
               MsgBox("Pattern not found on page.")
            End If
         End If
      End If
   End Sub

   Private Function replaceWhiteSpaceEvel(ByVal m As Match) As String
      Return "\w+"
   End Function
#End Region

#Region "Scraper-Editor Toolbar - Download - url combo box"
   Private Sub UrlToolStripComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UrlToolStripComboBox.KeyDown
      If e.KeyCode = Keys.Enter Then
         ' Simulate crawl
         If (Me.DownloadToolStripButton.Enabled) Then
            Me.doDownload()
         Else
            ' We can't start a new download. do nothing
         End If
         e.Handled = False          ' We dont' want to include enter...
      Else
         e.Handled = True
      End If
   End Sub

   ''' <summary>
   ''' Selected URL changed, change the sample context also
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub UrlToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UrlToolStripComboBox.SelectedIndexChanged
      Dim rv As ScraperDB.Project_SampleRow = Me.UrlToolStripComboBox.SelectedItem

      If rv IsNot Nothing Then
         Me.RichTextBox1.Text = rv.SampleText
         'Me.RichTextBox1.Rtf = Me._RtfEdit.RTFText
         Me.OnTreeChange()
      End If
   End Sub

   ''' <summary>
   ''' Progress changed
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub onDownloadProgressChanged(ByVal sender As Object, ByVal e As NetworkClient.DownloadProgressChangedEventArgs) Handles _myWebClient.DownloadProgressChanged
      RaiseEvent Progress(e.Status.ToString & ": " & e.BytesReceived)
   End Sub

   ''' <summary>
   ''' Download completed
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub myWebClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As NetworkClient.DownloadStringCompletedEventArgs) Handles _myWebClient.DownloadStringCompleted
      '_RtfEdit.Text = e.Result
      Me.RichTextBox1.Text = e.Result

      If Me.UrlToolStripComboBox.SelectedItem IsNot Nothing Then
         Dim rv As ScraperDB.Project_SampleRow = Me.UrlToolStripComboBox.SelectedItem
         rv.SampleText = e.Result
         rv.SampleText = e.Result
      End If
   End Sub

   ''' <summary>
   ''' Thread Finished
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub myWebClient_ThreadComplete(ByVal sender As Object, ByVal e As NetworkClient.ThreadFinishedEventArgs) Handles _myWebClient.ThreadFinished
      If e.ErrorStatus <> NetworkClient.DownloadError.NoError Then
         Me.RichTextBox1.Text = "Download Error: " & e.Error.Message
      End If

      RaiseEvent Progress("Ready")
      Me.DownloadToolStripButton.Enabled = True
   End Sub
#End Region

#Region "Tagtree contextmenu - drag stuffs"
   ''' <summary>
   ''' On TagTreeview, use can press Control + Up or Down to move nodes. Delete to delete the node
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub TagTreeView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TagTreeView1.KeyUp
      Dim node As TagTreeNode = Me.TagTreeView1.SelectedNode
      Dim pNode As TagTreeNode = node.Parent

      If e.Control Then
         If e.KeyCode = Keys.Up Then
            If node.Index > 0 Then
               Me.TagTreeView1.MoveNode(Me.TagTreeView1.SelectedNode, TagTreeView.NodeMovement.Up)
            End If
         ElseIf e.KeyCode = Keys.Down Then
            If pNode IsNot Nothing And node.Index < pNode.Nodes.Count - 1 Then
               Me.TagTreeView1.MoveNode(Me.TagTreeView1.SelectedNode, TagTreeView.NodeMovement.Down)
            End If
         End If
      End If

      If e.KeyCode = Keys.Delete Then
         If node IsNot Me.TagTreeView1.RootNode Then
            doDeleteNode()
         End If
      End If
   End Sub

   ''' <summary>
   ''' On TagTreeview, use right click, then show context menu and select the node. (A hack made to look like file explorer)
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub TagTreeView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TagTreeView1.MouseUp
      If e.Button = Windows.Forms.MouseButtons.Right Then
         Me.TagTreeView1.TempSelectedNode = Me.TagTreeView1.GetNodeAt(New Point(e.X, e.Y))
         Dim rightClickedNode As TagTreeNode = Me.TagTreeView1.TempSelectedNode

         If rightClickedNode IsNot Nothing Then
            Me.TagTreeViewContextMenuStrip.Show(Me.TagTreeView1, e.Location)
         End If
      End If
   End Sub

   Private Sub doDeleteNode()
      Dim node As TagTreeNode = Me.TagTreeView1.TempSelectedNode
      If MsgBox("Are you sure you want to delete the selected node (and it's childen)?", MsgBoxStyle.YesNo, "Delete Nodes") = MsgBoxResult.Yes Then
         Me.TagTreeView1.DeleteNode(node)
      End If
   End Sub

   ''' <summary>
   ''' TagTree's ContextMenu click
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub TagTreeViewContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TagTreeViewContextMenuStrip.ItemClicked
      Dim node As TagTreeNode = Me.TagTreeView1.TempSelectedNode

      If e.ClickedItem Is Me.MoveDownToolStripMenuItem Then
         Me.TagTreeView1.MoveNode(node, TagTreeView.NodeMovement.Down)
      ElseIf e.ClickedItem Is Me.MoveUpToolStripMenuItem Then
         Me.TagTreeView1.MoveNode(node, TagTreeView.NodeMovement.Up)
      ElseIf e.ClickedItem Is Me.DeleteToolStripMenuItem Then
         doDeleteNode()
      ElseIf e.ClickedItem Is Me.NewNodeBelowToolStripMenuItem Then
         ' Create New Node...
         Dim t As TagTreeNode = Me.TagTreeView1.CreateNode("TempNode", node, True)
      ElseIf e.ClickedItem Is Me.NewNodeUnderToolStripMenuItem Then
         ' Create New Node...
         Dim t As TagTreeNode = Me.TagTreeView1.CreateNode("TempNode", node)
      ElseIf e.ClickedItem Is Me.WizardToolStripMenuItem Then
         MsgBox("To be implemented")
      End If
   End Sub

   ''' <summary>
   ''' TagTree's ContextMenu Show
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub TagTreeViewContextMenuStrip_Opening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TagTreeViewContextMenuStrip.Opening
      Dim node As TagTreeNode = Me.TagTreeView1.TempSelectedNode

      Me.NewNodeUnderToolStripMenuItem.Enabled = True
      Me.NewNodeBelowToolStripMenuItem.Enabled = False
      Me.MoveDownToolStripMenuItem.Enabled = False
      Me.MoveUpToolStripMenuItem.Enabled = False
      Me.DeleteToolStripMenuItem.Enabled = False
      Me.WizardToolStripMenuItem.Enabled = False

      If node IsNot Nothing Then
         If node.Index > 0 Then
            Me.MoveUpToolStripMenuItem.Enabled = True
         End If

         Dim pnode As TagTreeNode = node.Parent
         If (pnode IsNot Nothing) Then
            If node.Index < pnode.Nodes.Count - 1 Then
               Me.MoveDownToolStripMenuItem.Enabled = True
            End If
         End If

         If node IsNot Me.TagTreeView1.RootNode Then
            Me.DeleteToolStripMenuItem.Enabled = True
            Me.NewNodeBelowToolStripMenuItem.Enabled = True
         End If

         If node.Nodes.Count = 0 Then
            Me.WizardToolStripMenuItem.Enabled = True
         End If
      End If

   End Sub
#End Region

#Region "Tree Control"
   Private sourceNode As TagTreeNode

   Private Sub TagTreeView1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TagTreeView1.DragDrop
      'Dim temp As TagTreeNode = e.Data.GetData(Windows.Forms.DataFormats.Serializable)
      Dim destNode As TreeNode = Nothing

      Dim pt As Point = TagTreeView1.PointToClient(New Point(e.X, e.Y))
      destNode = TagTreeView1.GetNodeAt(pt)

      If e.Effect = DragDropEffects.Move Then
         TagTreeView1.MoveNode(destNode, sourceNode)

         ' Reset the color nodes
         destNode.ExpandAll()
      End If
   End Sub

   Private Sub TagTreeView1_ItemDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles TagTreeView1.ItemDrag
      sourceNode = CType(e.Item, TagTreeNode)
      Me.TagTreeView1.DoDragDrop(e.Item, DragDropEffects.Move)
   End Sub

   Private Sub TagTreeView1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles TagTreeView1.DragOver
      Dim pt As Point
      Dim destNode As TreeNode = Nothing

      ' Check to see data being dragged is a window object type
      If (e.Data.GetDataPresent(Windows.Forms.DataFormats.Serializable)) Then
         ' Get the node
         Dim o As Object = e.Data.GetData(Windows.Forms.DataFormats.Serializable)

         ' Check to see if the node is a TagTreeNode type
         If (o.GetType Is GetType(TagTreeNode)) Then
            Dim temp As TagTreeNode = e.Data.GetData(Windows.Forms.DataFormats.Serializable)

            'Get dest Node
            pt = TagTreeView1.PointToClient(New Point(e.X, e.Y))
            destNode = TagTreeView1.GetNodeAt(pt)

            If (Me.TagTreeView1.IsDropAllowed(destNode, temp)) Then
               e.Effect = DragDropEffects.Move
               TagTreeView1.TempSelectedNode = destNode
               destNode.Expand()
            Else
               e.Effect = DragDropEffects.None
            End If
         End If
      End If
   End Sub

   Private Sub TagTreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TagTreeView1.AfterSelect
      ' Update the TagInfo
      Me.TagNodeInfoControl1.TagTreeNode = Me.TagTreeView1.SelectedNode

      ' Update Field DT
      If Me.IsOpenNodeDataView Then
         Me.IsOpenNodeDataView = True
      End If
   End Sub
#End Region

#Region "Text Edit Control"
   Private Sub TextEditContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TextEditContextMenuStrip.ItemClicked
      If e.ClickedItem Is Me.CopyTagsToolStripMenuItem Then
         doCopyTag()
      End If
   End Sub

   ''' <summary>
   ''' Copy tag into box
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doCopyTag()
      Dim aTagNode As TagTreeNode = Me.TagTreeView1.SelectedNode

      If Me.RichTextBox1.SelectedText.Length > 0 AndAlso aTagNode IsNot Nothing Then
         Dim selStart As Integer = Me.RichTextBox1.SelectionStart
         Dim selEnd As Integer = Me.RichTextBox1.SelectionStart + Me.RichTextBox1.SelectionLength

         If selStart - 10 < 0 Then
            aTagNode.Row.StartTag = Me.RichTextBox1.Text.Substring(0, selStart)
         Else
            aTagNode.Row.StartTag = Me.RichTextBox1.Text.Substring(selStart - 10, 10)
         End If


         If Me.RichTextBox1.Text.Length - selEnd - 10 < 0 Then
            aTagNode.Row.EndTag = Me.RichTextBox1.Text.Substring(selEnd, Me.RichTextBox1.Text.Length - selEnd)
         Else
            aTagNode.Row.EndTag = Me.RichTextBox1.Text.Substring(selEnd, 10)
         End If

         ' Node change, we need to refresh info
         Me.TagNodeInfoControl1.TagTreeNode = Me.TagTreeView1.SelectedNode
      End If
   End Sub

   Private Sub TextEditContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TextEditContextMenuStrip.Opening
      If Me.TagTreeView1.SelectedNode Is Me.TagTreeView1.RootNode Then
         e.Cancel = True
      End If
      If Me.RichTextBox1.SelectedText.Length = 0 Then
         e.Cancel = True
      End If
   End Sub
#End Region

   Private Sub RichTextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RichTextBox1.TextChanged

   End Sub

End Class
