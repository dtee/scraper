Public Class UrlListControl
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
      Me.DataGridView1.AutoGenerateColumns = False

      Dim StatuCol As DataGridViewComboBoxColumn = Nothing

      For Each col As DataColumn In dt.Columns
         If col Is dt.ProjectIDColumn Then
            Continue For
         End If

         Dim t As New ToolStripMenuItem(col.ColumnName)
         t.CheckOnClick = True
         t.CheckState = CheckState.Unchecked

         Me.ViewColumnToolStripDropDownButton.DropDownItems.Add(t)
         Me.CustomContextMenuStrip.Items.Add(t)

         If col Is dt.UrlStatusIDColumn Then
            Dim c As New DataGridViewComboBoxColumn
            StatuCol = c
            c.HeaderText = "Status"
            c.DataSource = ScraperLib.URLList.UrlStatusDT
            c.DisplayMember = ScraperLib.URLList.UrlStatusDT.NameColumn.ColumnName
            c.ValueMember = ScraperLib.URLList.UrlStatusDT.UrlStatusIDColumn.ColumnName
            c.DataPropertyName = col.ColumnName

            c.FillWeight = 2.0!
            c.MinimumWidth = 75
            t.Tag = c
            c.Visible = True
            'Me.DataGridView1.Columns.Add(c)
            t.Enabled = False
            t.CheckState = CheckState.Checked
         Else
            Dim c As New System.Windows.Forms.DataGridViewTextBoxColumn()
            c.HeaderText = col.ColumnName
            c.DataPropertyName = col.ColumnName
            t.Tag = c

            If col Is dt.UrlColumn Then
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

         ' Add Data colums (Except for Status and name, they are special)
      Next

      ' Move Status to last
      Me.DataGridView1.Columns.Insert(DataGridView1.ColumnCount, StatuCol)

      For Each row As ScraperDB.UrlStatusRow In ScraperLib.URLList.UrlStatusDT.Rows
         Dim t As New ToolStripMenuItem(row.Name)
         t.Tag = row.UrlStatusID
         Me.ChangeStatusContextMenuStrip.Items.Add(t)
      Next
   End Sub

#Region "Contorl Functions"
   Private WithEvents _UrlGen As New URLGenerator
   Private _UrlList As URLList

   Public Property UrlList() As URLList
      Get
         Return _UrlList
      End Get
      Set(ByVal value As URLList)
         Me.DataGridView1.AutoGenerateColumns = False

         If value IsNot Nothing Then
            Me._UrlList = value
            Me.DataGridView1.DataSource = Me._UrlList.URLDT
            _UrlGen.UrlList = Me._UrlList
            'Me.StatusToolStripStatusLabel.Text = "Total Url: " & Me.UrlList.URLDT.Rows.Count
         End If
      End Set
   End Property

   Public Property ShowAddPanel() As Boolean
      Get
         Return Me.AddUrlPanel.Visible
      End Get
      Set(ByVal value As Boolean)
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

   Public Sub SetSelectedStatus(ByVal status As URLList.UrlStatus)
      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As ScraperDB.UrlRow = rv.Row
            row.UrlStatusID = status
         End If
      Next
   End Sub

   Public Sub AddUrl()
      If (Me._UrlList Is Nothing) Then
         Exit Sub
      End If

      Me._UrlGen.URL = Me.txtUrl.Text
      Me._UrlGen.PostData = Me.txtPost.Text
      Me._UrlGen.Referer = Me.txtReferer.Text

      If Me._UrlGen.TotalCount > 1 Then
         If MsgBox("Generate " & Me._UrlGen.TotalCount & " Urls?", MsgBoxStyle.YesNo, "Generate Urls") = MsgBoxResult.Yes Then
            _UrlGen.GenerateURL()

            If _UrlGen.BadRowCount > 0 Then
               MsgBox(_UrlGen.BadRowCount & " Duplicate Rows Found, and are not added", MsgBoxStyle.OkOnly, "Note")
            End If
         End If
      Else
         _UrlGen.GenerateURL()
      End If
   End Sub

   Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
      Me.AddUrl()
   End Sub

   Private Sub txtURL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUrl.TextChanged
      If Me._UrlList Is Nothing Then
         Exit Sub
      End If

      Me._UrlGen.URL = Me.txtUrl.Text
      Me.ErrorProvider1.SetError(Me.txtUrl, Me._UrlGen.ErrorMsg)

      If Me._UrlGen.ErrorMsg <> "" Then
         Me.AddButton.Enabled = False
      Else
         Me.AddButton.Enabled = True
      End If
   End Sub

   Private Sub DoSelectAll()
      Me.DataGridView1.SelectAll()
   End Sub
#End Region

   Private Sub RemoveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripButton.Click
      Me.RemoveSelected()
   End Sub

   Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripButton.Click
      Me.DoSelectAll()
   End Sub

   Private Sub CustomContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles CustomContextMenuStrip.ItemClicked
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
End Class
