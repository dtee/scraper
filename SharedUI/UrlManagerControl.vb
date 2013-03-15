Imports ScraperLib
Imports System.Windows.Forms

Public Class UrlManagerControl
   Private _StatuCol As DataGridViewComboBoxColumn

   Public Event Progress(ByVal text As String)

   Private Sub AddUrlToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUrlToolStripButton.Click
      Me.ShowAddPanel = Me.AddUrlToolStripButton.Checked
   End Sub

   'Private Sub UrlListView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
   '   Dim u As New URLList
   '   Me.UrlList = u
   'End Sub
   Public Sub New()
      InitializeComponent()

      ' Load Create tools bars for url columns
      Dim dt As New ScraperDB.UrlDataTable
      Dim statusDT As New ScraperDB.UrlStatusDataTable

      Me.DataGridView1.AutoGenerateColumns = False

      _StatuCol = New DataGridViewComboBoxColumn
      _StatuCol.HeaderText = "Status"
      _StatuCol.DisplayMember = statusDT.NameColumn.ColumnName
      _StatuCol.ValueMember = statusDT.UrlStatusIDColumn.ColumnName
      _StatuCol.DataPropertyName = dt.UrlStatusIDColumn.ColumnName

      _StatuCol.FillWeight = 2.0!
      _StatuCol.MinimumWidth = 75
      _StatuCol.Visible = True

      For Each col As DataColumn In dt.Columns

         If col Is dt.UrlIDColumn Then Continue For

         Dim t As New ToolStripMenuItem(col.ColumnName)
         t.CheckOnClick = True
         t.CheckState = CheckState.Unchecked

         Me.ViewColumnToolStripDropDownButton.DropDownItems.Add(t)
         Me.ShowFieldMenuStrip.Items.Add(t)

         If col Is dt.UrlStatusIDColumn Then
            t.Tag = _StatuCol
            'Me.DataGridView1.Columns.Add(c)
            t.Enabled = False
            t.CheckState = CheckState.Checked
         Else
            Dim c As New System.Windows.Forms.DataGridViewTextBoxColumn()
            c.HeaderText = col.ColumnName
            c.DataPropertyName = col.ColumnName
            t.Tag = c

            If col Is dt.UrlLinkColumn Then
               c.FillWeight = 60.0!
               c.Visible = True
               t.Enabled = False
               t.CheckState = CheckState.Checked
               Me.DataGridView1.Columns.Insert(0, c)
            Else
               c.Visible = False
               c.FillWeight = 20.0!
               Me.DataGridView1.Columns.Add(c)
            End If
         End If

         If (col Is dt.UrlStatusIDColumn) Then     ' dont' add thse two
         ElseIf (col Is dt.UrlLinkColumn) Then
         Else
            Me.ShowFieldMenuStrip.Items.Add(t)
         End If
      Next

      ' Move Status to last
      Me.DataGridView1.Columns.Insert(DataGridView1.ColumnCount, _StatuCol)
   End Sub

#Region "Contorl Functions"
   Private WithEvents _UrlGen As New URLGenerator
   Private _UrlManager As UrlManager

   Private _CrawlProject As CrawlProject
   Public Property CrawlProject() As CrawlProject
      Get
         Return _CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         _CrawlProject = value

         If value IsNot Nothing Then
            Me._UrlManager = _CrawlProject.UrlManager
            Me.DataGridView1.DataSource = Me._UrlManager.UrlDT
            Me._StatuCol.DataSource = Me._UrlManager.UrlStatusDT
            _UrlGen.UrlList = Me._UrlManager

            ' Populate the project list
            Dim c As CheckedListBox = ProjectListCheckedListBox
            c.DataSource = Me._CrawlProject.ProjectManager.ProjectList
            c.DisplayMember = "ProjectName"

            doRaiseUrlChangedEvent()
         End If
      End Set
   End Property

   Public Property ShowAddPanel() As Boolean
      Get
         Return Me.AddUrlPanel.Visible
      End Get
      Set(ByVal value As Boolean)
         ' Refresh the list
         Dim c As CheckedListBox = ProjectListCheckedListBox

         If Me._CrawlProject Is Nothing Then Exit Property

         c.DataSource = Nothing
         c.DataSource = Me._CrawlProject.ProjectManager.ProjectList
         c.DisplayMember = "ProjectName"
         Me.AddUrlPanel.Visible = value
      End Set
   End Property

   Public Sub RemoveSelected()
      Dim digResult As Microsoft.VisualBasic.MsgBoxResult = MsgBoxResult.Yes
      If Me.DataGridView1.SelectedRows.Count > 1 Then
         digResult = MsgBox("Remove " & Me.DataGridView1.SelectedRows.Count & " Urls?", MsgBoxStyle.YesNo, "Remove Urls")
      End If

      If digResult = MsgBoxResult.No Then
         Exit Sub
      End If

      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As ScraperDB.UrlRow = rv.Row
            row.Delete()
         End If
      Next
   End Sub

   Public Sub SetSelectedStatus(ByVal status As UrlManager.UrlStatus)
      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As ScraperDB.UrlRow = rv.Row
            row.UrlStatusID = status
         End If
      Next
   End Sub

   Public Sub AddUrl()
      If (Me._UrlManager Is Nothing) Then
         Exit Sub
      End If

      Me._UrlGen.URL = Me.txtUrl.Text
      Me._UrlGen.PostData = Me.txtPost.Text
      Me._UrlGen.Referer = Me.txtReferer.Text

      Dim projList As New List(Of Project)
      For Each item As Project In Me.ProjectListCheckedListBox.SelectedItems
         projList.Add(item)
      Next

      If projList.Count = 0 Then
         MsgBox("Select at least one project from the project list.")
      ElseIf Me._UrlGen.TotalCount > 1 Then
         If MsgBox("Generate " & Me._UrlGen.TotalCount & " Urls?", MsgBoxStyle.YesNo, "Generate Urls") = MsgBoxResult.Yes Then
            _UrlGen.GenerateURL(projList)

            If _UrlGen.BadRowCount > 0 Then
               MsgBox(_UrlGen.BadRowCount & " Duplicate Rows Found, and are not added", MsgBoxStyle.OkOnly, "Note")
            End If
         End If
      Else
         _UrlGen.GenerateURL(projList)
      End If
   End Sub

   Private Sub doRaiseUrlChangedEvent()
      Dim str As String = String.Format("Total Url: {0}, {1}/{2} (crawled/to crawl)", Me._UrlManager.TotalUrl, Me._UrlManager.TotalScraped, Me._UrlManager.TotalToScrape)
      RaiseEvent Progress(str)
   End Sub

   Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
      Me.AddUrl()

      doRaiseUrlChangedEvent()
   End Sub

   Private Sub txtURL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUrl.TextChanged
      If Me._UrlManager Is Nothing Then
         Exit Sub
      End If

      Try
         Me._UrlGen.URL = Me.txtUrl.Text
         Me.ErrorProvider1.SetError(Me.txtUrl, "")          ' clear the error
         Me.AddButton.Enabled = True
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.txtUrl, ex.Message)
         Me.AddButton.Enabled = False
      End Try
   End Sub

   Private Sub DoSelectAll()
      Me.DataGridView1.SelectAll()
   End Sub
#End Region

   Private Sub RemoveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripButton.Click
      Me.RemoveSelected()
      doRaiseUrlChangedEvent()
   End Sub

   Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripButton.Click
      Me.DoSelectAll()
   End Sub

   Private Sub CustomContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ShowFieldMenuStrip.ItemClicked
      If TypeOf (e.ClickedItem.Tag) Is DataGridViewTextBoxColumn Then
         Dim t As ToolStripMenuItem = e.ClickedItem
         Dim c As DataGridViewColumn = t.Tag
         c.Visible = Not t.Checked
      ElseIf TypeOf (e.ClickedItem.Tag) Is DataGridViewComboBoxColumn Then
         Dim t As ToolStripMenuItem = e.ClickedItem
         Dim c As DataGridViewColumn = t.Tag
         c.Visible = Not t.Checked
      End If
   End Sub

   Private Sub ChangeStatusContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ChangeStatusContextMenuStrip.ItemClicked
      Dim id As Integer = e.ClickedItem.Tag
      Me.SetSelectedStatus(id)
   End Sub

   'Private Sub DataGridView1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
   '   Me.StatusToolStripStatusLabel.Text = "Total Url: " & Me.UrlList.URLDT.Rows.Count
   'End Sub

   'Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
   '   Me.StatusToolStripStatusLabel.Text = "Total Url: " & Me.UrlList.URLDT.Rows.Count
   'End Sub

   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

   End Sub

   Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter

      doRaiseUrlChangedEvent()
   End Sub
End Class
