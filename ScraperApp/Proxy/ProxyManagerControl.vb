Imports System.Text.RegularExpressions

Public Class ProxyManagerControl
   Public Event progress(ByVal status As String)

   Private Shared _log As New Log(GetType(ProxyManagerControl), True)

   Private _content As String = "Google"
   Private _Uri As Uri = New Uri("http://www.google.com")

   Private _ProxyManager As ProxyManager
   Private _CrawlProject As CrawlProject
   Private _ProxyStatusDT As ScraperDB.ProxyStatusDataTable
   Private _ProxyChecker As ProxyChecker

   Private dv As DataView
   Public Property ProxyManager() As ProxyManager
      Get
         Return _ProxyManager
      End Get
      Set(ByVal value As ProxyManager)
         Me._ProxyManager = value

         If value IsNot Nothing Then
            Me.dv = New DataView(Me._ProxyManager.ProxyDT)
            Me.DataGridView1.DataSource = dv
            proxyStatusCombobox.DataSource = Me.ProxyManager.ProxyStatusDT

            Me._ProxyChecker = New ProxyChecker(Me._ProxyManager)
         End If
      End Set
   End Property

   Public Property CrawlProject() As CrawlProject
      Get
         Return Me._CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         Me._CrawlProject = value
         If _CrawlProject IsNot Nothing Then
            Me.ProxyManager = Me._CrawlProject.ProxyManager

            raiseProxyChangeEvent()
         End If
      End Set
   End Property

   Private OpenFileDia As OpenFileDialog

   Public Sub New()
      Me._ProxyStatusDT = New ScraperDB.ProxyStatusDataTable

      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      InitCustomColumns()
      InitFilterAndChange()

      ' Add any initialization after the InitializeComponent() call.
      OpenFileDia = New OpenFileDialog
      OpenFileDia.DefaultExt = "*.txt"
      OpenFileDia.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*"
      OpenFileDia.CheckFileExists = True
      OpenFileDia.CheckPathExists = True
   End Sub

   Public Sub New(ByVal ProxyManager As ProxyManager)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      InitCustomColumns()
      InitFilterAndChange()

      ' Add any initialization after the InitializeComponent() call.
      OpenFileDia = New OpenFileDialog
      OpenFileDia.DefaultExt = "*.txt"
      OpenFileDia.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*"
      OpenFileDia.CheckFileExists = True
      OpenFileDia.CheckPathExists = True

      Me.ProxyManager = ProxyManager
   End Sub

   Private Sub InitFilterAndChange()
      Dim t As New ToolStripMenuItem("All")
      Me.FilterContextMenuStrip.Items.Add(t)

      For Each r As ScraperDB.ProxyStatusRow In Me._ProxyStatusDT.Rows
         t = New ToolStripMenuItem(r.StatusName)
         t.Tag = r.ProxyStatusID
         Me.FilterContextMenuStrip.Items.Add(t)

         t = New ToolStripMenuItem(r.StatusName)
         t.Tag = r.ProxyStatusID
         Me.ChangeContextMenuStrip.Items.Add(t)
      Next
   End Sub

   Private proxyStatusCombobox As DataGridViewComboBoxColumn
   Private Sub InitCustomColumns()
      Dim dt As New ScraperDB.ProxyDataTable
      ' Add buttons for proxy context menu
      Me.DataGridView1.AutoGenerateColumns = False
      For Each col As DataColumn In dt.Columns
         If (col Is dt.ProxyIDColumn) Then Continue For

         Dim t As New ToolStripMenuItem(col.ColumnName)
         t.CheckOnClick = True

         Me.ColumnsContextMenuStrip.Items.Add(t)

         If col Is dt.ProxyStatusIDColumn Then
            Dim c As New DataGridViewComboBoxColumn
            c.HeaderText = "Status"

            c.DataSource = _ProxyStatusDT
            c.DisplayMember = _ProxyStatusDT.StatusNameColumn.ColumnName
            c.ValueMember = _ProxyStatusDT.ProxyStatusIDColumn.ColumnName
            c.DataPropertyName = col.ColumnName
            c.SortMode = DataGridViewColumnSortMode.Automatic

            c.FillWeight = 2.0!
            c.MinimumWidth = 75
            t.Tag = c
            c.Visible = True
            proxyStatusCombobox = c
            Me.DataGridView1.Columns.Add(c)
            t.Enabled = False
            t.CheckState = CheckState.Checked
            t.Visible = False
         Else
            Dim c As New System.Windows.Forms.DataGridViewTextBoxColumn()
            c.HeaderText = col.ColumnName
            c.DataPropertyName = col.ColumnName
            t.Tag = c

            If col Is dt.ProxyLinkColumn Then
               c.FillWeight = 60.0!
               c.Visible = True
               t.Enabled = False
               t.CheckState = CheckState.Checked
               Me.DataGridView1.Columns.Insert(0, c)
               t.Visible = False
            Else
               c.Visible = False
               c.FillWeight = 20.0!
               Me.DataGridView1.Columns.Add(c)
            End If
         End If
      Next
   End Sub

#Region "Menu/Item Click"
   Private Sub ImportFileToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportFileToolStripButton.Click
      Me.DoImportFile()
      raiseProxyChangeEvent()
   End Sub

   Private Sub AddButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddButton.Click
      Me._ProxyManager.AddProxy(Me.ProxyTextBox.Text, Me.PortTextBox.Text)
      raiseProxyChangeEvent()
   End Sub

   Private Sub AddProxyToolStripButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddProxyToolStripButton.CheckedChanged
      Me.AddProxyPanel.Visible = Me.AddProxyToolStripButton.Checked
   End Sub

   Private Sub RemoveProxyToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveProxyToolStripButton.Click
      Dim digResult As Microsoft.VisualBasic.MsgBoxResult = MsgBoxResult.Yes
      If Me.DataGridView1.SelectedRows.Count > 1 Then
         digResult = MsgBox("Remove " & Me.DataGridView1.SelectedRows.Count & " Proxys?", MsgBoxStyle.YesNo, "Remove Proxys")
      End If

      If digResult = MsgBoxResult.No Then
         Exit Sub
      End If

      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As ScraperDB.ProxyRow = rv.Row
            row.Delete()
         End If
      Next
   End Sub
#End Region

   ''' <summary>
   ''' Import another proxy xml datatable or text file.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub DoImportFile()
      If Me.OpenFileDia.ShowDialog = Windows.Forms.DialogResult.OK Then
         Dim mainStr As String = IO.File.ReadAllText(OpenFileDia.FileName)
         Dim mc As MatchCollection = Regex.Matches(mainStr, "(.*?):(\d*)")

         For Each m As Match In mc
            Console.WriteLine("{0}:{1}", m.Groups(1).Value, m.Groups(2).Value)

            Try
               Dim proxyPort As Integer = Integer.Parse(m.Groups(2).Value)
               Me._ProxyManager.AddProxy(m.Groups(1).Value, m.Groups(2).Value)
            Catch ex As Exception

            End Try
         Next
      End If
   End Sub

   ''' <summary>
   ''' Add a proxy to list
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub DoAddProxy()
      Me._ProxyManager.AddProxy(Me.ProxyTextBox.Text, Me.PortTextBox.Text)
   End Sub

   Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
      Me.raiseProxyChangeEvent()
   End Sub

   Private Sub DataGridView1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
      If _ProxyManager Is Nothing Then Exit Sub
        End Sub

   Private Sub raiseProxyChangeEvent()
      RaiseEvent progress(String.Format("Proxies: {0}/{1} (Work/Total)", Me._ProxyManager.ProxyToUseCount, Me._ProxyManager.TotalProxy))
   End Sub

   Private Sub ColumnsContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ColumnsContextMenuStrip.ItemClicked
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

   Private Sub StopCheckToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopCheckToolStripButton.Click
      Me._ProxyChecker.Abort()
   End Sub

   Private Sub FilterContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles FilterContextMenuStrip.ItemClicked
      If e.ClickedItem.Text = "All" Then
         dv.RowFilter = ""
      ElseIf e.ClickedItem.Tag = ProxyManager.ProxyStatus.Ready Then
         dv.RowFilter = _ProxyStatusDT.ProxyStatusIDColumn.ColumnName & " = " & ProxyManager.ProxyStatus.Ready
      ElseIf e.ClickedItem.Tag = ProxyManager.ProxyStatus.Error Then
         dv.RowFilter = _ProxyStatusDT.ProxyStatusIDColumn.ColumnName & " = " & ProxyManager.ProxyStatus.Error
      ElseIf e.ClickedItem.Tag = ProxyManager.ProxyStatus.Unknown Then
         dv.RowFilter = _ProxyStatusDT.ProxyStatusIDColumn.ColumnName & " = " & ProxyManager.ProxyStatus.Unknown
      ElseIf e.ClickedItem.Tag = ProxyManager.ProxyStatus.Checking Then
         dv.RowFilter = _ProxyStatusDT.ProxyStatusIDColumn.ColumnName & " = " & ProxyManager.ProxyStatus.Checking
      End If
   End Sub

   Private Sub ResetAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetAllToolStripButton.Click
      Me.ProxyManager.ResetAllProxyStatus()
   End Sub


   Private Sub CheckAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAllToolStripButton.Click
      Me._ProxyChecker.check(Me._Uri, Me._content)
      Me.CheckAllToolStripButton.Enabled = False
   End Sub

   ''' <summary>
   ''' Get and set total Threads
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TotalThreads() As Integer
      Get
         Return CInt(Me.ThreadsToolStripTextBox.Text)
      End Get
      Set(ByVal value As Integer)
         Me.ThreadsToolStripTextBox.Text = value
      End Set
   End Property


   ' Go thought listivew and remove all error proxy
   Private Sub RemoveErrorToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveErrorToolStripButton.Click
      Me.ProxyManager.RemoveErrorProxy()
   End Sub
End Class
