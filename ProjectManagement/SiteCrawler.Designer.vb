<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SiteCrawler
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SiteCrawler))
      Me.ProjectManagerContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.AddProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.RemoveProjectToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
      Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.ProjectListView = New System.Windows.Forms.ListView
      Me.TabControl1 = New System.Windows.Forms.TabControl
      Me.GeneralTabPage = New System.Windows.Forms.TabPage
      Me.ProjectInfoControl1 = New SharedUI.ProjectInfoControl
      Me.DataMappingTabPage = New System.Windows.Forms.TabPage
      Me.DataMappingDataGridView = New System.Windows.Forms.DataGridView
      Me.DataMappingTag = New System.Windows.Forms.DataGridViewComboBoxColumn
      Me.DataMappingField = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DataMappingID = New System.Windows.Forms.DataGridViewCheckBoxColumn
      Me.DataMappingChecksum = New System.Windows.Forms.DataGridViewCheckBoxColumn
      Me.DataMappingToolStrip = New System.Windows.Forms.ToolStrip
      Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
      Me.TableGeneratedToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.LinkMappingTabPage = New System.Windows.Forms.TabPage
      Me.LinkMappingDataGridView = New System.Windows.Forms.DataGridView
      Me.LinkMappingTagID = New System.Windows.Forms.DataGridViewComboBoxColumn
      Me.LinkMappingProjectID = New System.Windows.Forms.DataGridViewComboBoxColumn
      Me.UrlMappingToolStrip = New System.Windows.Forms.ToolStrip
      Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
      Me.ProjectToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
      Me.UrlTagToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.AddUrlMappingToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.RemoveUrlMappingToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.Label11 = New System.Windows.Forms.Label
      Me.Label10 = New System.Windows.Forms.Label
      Me.CrawlTabPage = New System.Windows.Forms.TabPage
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
      Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
      Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
      Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.PrintPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.UndoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.RedoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.CutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.SelectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.CustomizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
      Me.LoadUrlDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.IndexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.OpenToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
      Me.ImportProjectToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.RefreshToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.CheckProjectToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.toolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
      Me.StartToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.StopToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
      Me.HelpToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ProjectManagerContextMenuStrip.SuspendLayout()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.GeneralTabPage.SuspendLayout()
      Me.DataMappingTabPage.SuspendLayout()
      CType(Me.DataMappingDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.DataMappingToolStrip.SuspendLayout()
      Me.LinkMappingTabPage.SuspendLayout()
      CType(Me.LinkMappingDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.UrlMappingToolStrip.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.MenuStrip1.SuspendLayout()
      Me.ToolStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ProjectManagerContextMenuStrip
      '
      Me.ProjectManagerContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddProjectToolStripMenuItem, Me.RemoveProjectToolStripMenuItem, Me.ToolStripSeparator10, Me.FilterToolStripMenuItem, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
      Me.ProjectManagerContextMenuStrip.Name = "ProjectManagerContextMenuStrip"
      Me.ProjectManagerContextMenuStrip.Size = New System.Drawing.Size(156, 120)
      '
      'AddProjectToolStripMenuItem
      '
      Me.AddProjectToolStripMenuItem.Name = "AddProjectToolStripMenuItem"
      Me.AddProjectToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me.AddProjectToolStripMenuItem.Text = "Import"
      Me.AddProjectToolStripMenuItem.ToolTipText = "Add Project"
      '
      'RemoveProjectToolStripMenuItem
      '
      Me.RemoveProjectToolStripMenuItem.Name = "RemoveProjectToolStripMenuItem"
      Me.RemoveProjectToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me.RemoveProjectToolStripMenuItem.Text = "Remove"
      Me.RemoveProjectToolStripMenuItem.ToolTipText = "Remove Project"
      '
      'ToolStripSeparator10
      '
      Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
      Me.ToolStripSeparator10.Size = New System.Drawing.Size(152, 6)
      '
      'FilterToolStripMenuItem
      '
      Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
      Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me.FilterToolStripMenuItem.Text = "Invalid Projects"
      '
      'ToolStripMenuItem1
      '
      Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
      Me.ToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
      Me.ToolStripMenuItem1.Text = "Running Projects"
      '
      'ToolStripMenuItem2
      '
      Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
      Me.ToolStripMenuItem2.Size = New System.Drawing.Size(155, 22)
      Me.ToolStripMenuItem2.Text = "All Projects"
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.ProjectListView)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
      Me.SplitContainer1.Size = New System.Drawing.Size(1153, 491)
      Me.SplitContainer1.SplitterDistance = 298
      Me.SplitContainer1.TabIndex = 1
      '
      'ProjectListView
      '
      Me.ProjectListView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ProjectListView.Location = New System.Drawing.Point(0, 0)
      Me.ProjectListView.Name = "ProjectListView"
      Me.ProjectListView.Size = New System.Drawing.Size(298, 491)
      Me.ProjectListView.TabIndex = 0
      Me.ProjectListView.UseCompatibleStateImageBehavior = False
      Me.ProjectListView.View = System.Windows.Forms.View.List
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.GeneralTabPage)
      Me.TabControl1.Controls.Add(Me.DataMappingTabPage)
      Me.TabControl1.Controls.Add(Me.LinkMappingTabPage)
      Me.TabControl1.Controls.Add(Me.CrawlTabPage)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 0)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(851, 491)
      Me.TabControl1.TabIndex = 6
      '
      'GeneralTabPage
      '
      Me.GeneralTabPage.Controls.Add(Me.ProjectInfoControl1)
      Me.GeneralTabPage.Location = New System.Drawing.Point(4, 22)
      Me.GeneralTabPage.Name = "GeneralTabPage"
      Me.GeneralTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me.GeneralTabPage.Size = New System.Drawing.Size(843, 465)
      Me.GeneralTabPage.TabIndex = 0
      Me.GeneralTabPage.Text = "General"
      Me.GeneralTabPage.UseVisualStyleBackColor = True
      '
      'ProjectInfoControl1
      '
      Me.ProjectInfoControl1.Location = New System.Drawing.Point(0, 0)
      Me.ProjectInfoControl1.Name = "ProjectInfoControl1"
      Me.ProjectInfoControl1.ProjectRow = Nothing
      Me.ProjectInfoControl1.Size = New System.Drawing.Size(804, 187)
      Me.ProjectInfoControl1.TabIndex = 0
      Me.ProjectInfoControl1.TotalThreads = 1
      '
      'DataMappingTabPage
      '
      Me.DataMappingTabPage.Controls.Add(Me.DataMappingDataGridView)
      Me.DataMappingTabPage.Controls.Add(Me.DataMappingToolStrip)
      Me.DataMappingTabPage.Location = New System.Drawing.Point(4, 22)
      Me.DataMappingTabPage.Name = "DataMappingTabPage"
      Me.DataMappingTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me.DataMappingTabPage.Size = New System.Drawing.Size(843, 465)
      Me.DataMappingTabPage.TabIndex = 1
      Me.DataMappingTabPage.Text = "Data Mapping"
      Me.DataMappingTabPage.UseVisualStyleBackColor = True
      '
      'DataMappingDataGridView
      '
      Me.DataMappingDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataMappingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataMappingDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataMappingTag, Me.DataMappingField, Me.DataMappingID, Me.DataMappingChecksum})
      Me.DataMappingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataMappingDataGridView.Location = New System.Drawing.Point(3, 28)
      Me.DataMappingDataGridView.Name = "DataMappingDataGridView"
      Me.DataMappingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataMappingDataGridView.Size = New System.Drawing.Size(837, 434)
      Me.DataMappingDataGridView.TabIndex = 5
      '
      'DataMappingTag
      '
      Me.DataMappingTag.HeaderText = "Tag"
      Me.DataMappingTag.Name = "DataMappingTag"
      Me.DataMappingTag.ReadOnly = True
      '
      'DataMappingField
      '
      Me.DataMappingField.HeaderText = "Field Name"
      Me.DataMappingField.Name = "DataMappingField"
      '
      'DataMappingID
      '
      Me.DataMappingID.FillWeight = 20.0!
      Me.DataMappingID.HeaderText = "ID"
      Me.DataMappingID.Name = "DataMappingID"
      '
      'DataMappingChecksum
      '
      Me.DataMappingChecksum.FillWeight = 20.0!
      Me.DataMappingChecksum.HeaderText = "CS"
      Me.DataMappingChecksum.Name = "DataMappingChecksum"
      '
      'DataMappingToolStrip
      '
      Me.DataMappingToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.TableGeneratedToolStripComboBox})
      Me.DataMappingToolStrip.Location = New System.Drawing.Point(3, 3)
      Me.DataMappingToolStrip.Name = "DataMappingToolStrip"
      Me.DataMappingToolStrip.Size = New System.Drawing.Size(837, 25)
      Me.DataMappingToolStrip.TabIndex = 6
      Me.DataMappingToolStrip.Text = "ToolStrip2"
      '
      'ToolStripLabel3
      '
      Me.ToolStripLabel3.Name = "ToolStripLabel3"
      Me.ToolStripLabel3.Size = New System.Drawing.Size(91, 22)
      Me.ToolStripLabel3.Text = "Table Generated:"
      '
      'TableGeneratedToolStripComboBox
      '
      Me.TableGeneratedToolStripComboBox.Name = "TableGeneratedToolStripComboBox"
      Me.TableGeneratedToolStripComboBox.Size = New System.Drawing.Size(121, 25)
      '
      'LinkMappingTabPage
      '
      Me.LinkMappingTabPage.Controls.Add(Me.LinkMappingDataGridView)
      Me.LinkMappingTabPage.Controls.Add(Me.UrlMappingToolStrip)
      Me.LinkMappingTabPage.Controls.Add(Me.Label11)
      Me.LinkMappingTabPage.Controls.Add(Me.Label10)
      Me.LinkMappingTabPage.Location = New System.Drawing.Point(4, 22)
      Me.LinkMappingTabPage.Name = "LinkMappingTabPage"
      Me.LinkMappingTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me.LinkMappingTabPage.Size = New System.Drawing.Size(843, 465)
      Me.LinkMappingTabPage.TabIndex = 3
      Me.LinkMappingTabPage.Text = "Link Mapping"
      Me.LinkMappingTabPage.UseVisualStyleBackColor = True
      '
      'LinkMappingDataGridView
      '
      Me.LinkMappingDataGridView.AllowUserToAddRows = False
      Me.LinkMappingDataGridView.AllowUserToResizeRows = False
      Me.LinkMappingDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.LinkMappingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.LinkMappingDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LinkMappingTagID, Me.LinkMappingProjectID})
      Me.LinkMappingDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.LinkMappingDataGridView.Location = New System.Drawing.Point(3, 28)
      Me.LinkMappingDataGridView.Name = "LinkMappingDataGridView"
      Me.LinkMappingDataGridView.ReadOnly = True
      Me.LinkMappingDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.LinkMappingDataGridView.Size = New System.Drawing.Size(837, 434)
      Me.LinkMappingDataGridView.TabIndex = 6
      '
      'LinkMappingTagID
      '
      Me.LinkMappingTagID.HeaderText = "Tag"
      Me.LinkMappingTagID.Name = "LinkMappingTagID"
      Me.LinkMappingTagID.ReadOnly = True
      Me.LinkMappingTagID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      '
      'LinkMappingProjectID
      '
      Me.LinkMappingProjectID.HeaderText = "Project"
      Me.LinkMappingProjectID.Name = "LinkMappingProjectID"
      Me.LinkMappingProjectID.ReadOnly = True
      Me.LinkMappingProjectID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      '
      'UrlMappingToolStrip
      '
      Me.UrlMappingToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ProjectToolStripComboBox, Me.ToolStripLabel2, Me.UrlTagToolStripComboBox, Me.AddUrlMappingToolStripButton, Me.RemoveUrlMappingToolStripButton})
      Me.UrlMappingToolStrip.Location = New System.Drawing.Point(3, 3)
      Me.UrlMappingToolStrip.Name = "UrlMappingToolStrip"
      Me.UrlMappingToolStrip.Size = New System.Drawing.Size(837, 25)
      Me.UrlMappingToolStrip.TabIndex = 13
      Me.UrlMappingToolStrip.Text = "ToolStrip2"
      '
      'ToolStripLabel1
      '
      Me.ToolStripLabel1.Name = "ToolStripLabel1"
      Me.ToolStripLabel1.Size = New System.Drawing.Size(45, 22)
      Me.ToolStripLabel1.Text = "Project:"
      '
      'ProjectToolStripComboBox
      '
      Me.ProjectToolStripComboBox.Name = "ProjectToolStripComboBox"
      Me.ProjectToolStripComboBox.Size = New System.Drawing.Size(121, 25)
      '
      'ToolStripLabel2
      '
      Me.ToolStripLabel2.Name = "ToolStripLabel2"
      Me.ToolStripLabel2.Size = New System.Drawing.Size(29, 22)
      Me.ToolStripLabel2.Text = "Tag:"
      '
      'UrlTagToolStripComboBox
      '
      Me.UrlTagToolStripComboBox.Name = "UrlTagToolStripComboBox"
      Me.UrlTagToolStripComboBox.Size = New System.Drawing.Size(121, 25)
      '
      'AddUrlMappingToolStripButton
      '
      Me.AddUrlMappingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.AddUrlMappingToolStripButton.Image = CType(resources.GetObject("AddUrlMappingToolStripButton.Image"), System.Drawing.Image)
      Me.AddUrlMappingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AddUrlMappingToolStripButton.Name = "AddUrlMappingToolStripButton"
      Me.AddUrlMappingToolStripButton.Size = New System.Drawing.Size(30, 22)
      Me.AddUrlMappingToolStripButton.Text = "Add"
      '
      'RemoveUrlMappingToolStripButton
      '
      Me.RemoveUrlMappingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.RemoveUrlMappingToolStripButton.Image = CType(resources.GetObject("RemoveUrlMappingToolStripButton.Image"), System.Drawing.Image)
      Me.RemoveUrlMappingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RemoveUrlMappingToolStripButton.Name = "RemoveUrlMappingToolStripButton"
      Me.RemoveUrlMappingToolStripButton.Size = New System.Drawing.Size(50, 22)
      Me.RemoveUrlMappingToolStripButton.Text = "Remove"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(138, 16)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(40, 13)
      Me.Label11.TabIndex = 10
      Me.Label11.Text = "Project"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(8, 16)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(51, 13)
      Me.Label10.TabIndex = 9
      Me.Label10.Text = "URL Tag"
      '
      'CrawlTabPage
      '
      Me.CrawlTabPage.Location = New System.Drawing.Point(4, 22)
      Me.CrawlTabPage.Name = "CrawlTabPage"
      Me.CrawlTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me.CrawlTabPage.Size = New System.Drawing.Size(843, 465)
      Me.CrawlTabPage.TabIndex = 4
      Me.CrawlTabPage.Text = "Crawl"
      Me.CrawlTabPage.UseVisualStyleBackColor = True
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(1153, 22)
      Me.StatusStrip1.TabIndex = 5
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
      Me.ToolStripStatusLabel1.Text = "Ready"
      '
      'MenuStrip1
      '
      Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
      Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
      Me.MenuStrip1.Name = "MenuStrip1"
      Me.MenuStrip1.Size = New System.Drawing.Size(1153, 24)
      Me.MenuStrip1.TabIndex = 6
      Me.MenuStrip1.Text = "MenuStrip1"
      '
      'FileToolStripMenuItem
      '
      Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.toolStripSeparator, Me.SaveToolStripMenuItem, Me.SaveAsToolStripMenuItem, Me.toolStripSeparator1, Me.PrintToolStripMenuItem, Me.PrintPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.ExitToolStripMenuItem})
      Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
      Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
      Me.FileToolStripMenuItem.Text = "&File"
      '
      'NewToolStripMenuItem
      '
      Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
      Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
      Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
      Me.NewToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.NewToolStripMenuItem.Text = "&New"
      '
      'OpenToolStripMenuItem
      '
      Me.OpenToolStripMenuItem.Image = CType(resources.GetObject("OpenToolStripMenuItem.Image"), System.Drawing.Image)
      Me.OpenToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
      Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
      Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.OpenToolStripMenuItem.Text = "&Open"
      '
      'toolStripSeparator
      '
      Me.toolStripSeparator.Name = "toolStripSeparator"
      Me.toolStripSeparator.Size = New System.Drawing.Size(137, 6)
      '
      'SaveToolStripMenuItem
      '
      Me.SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), System.Drawing.Image)
      Me.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
      Me.SaveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
      Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.SaveToolStripMenuItem.Text = "&Save"
      '
      'SaveAsToolStripMenuItem
      '
      Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
      Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.SaveAsToolStripMenuItem.Text = "Save &As"
      '
      'toolStripSeparator1
      '
      Me.toolStripSeparator1.Name = "toolStripSeparator1"
      Me.toolStripSeparator1.Size = New System.Drawing.Size(137, 6)
      '
      'PrintToolStripMenuItem
      '
      Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
      Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
      Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
      Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.PrintToolStripMenuItem.Text = "&Print"
      '
      'PrintPreviewToolStripMenuItem
      '
      Me.PrintPreviewToolStripMenuItem.Image = CType(resources.GetObject("PrintPreviewToolStripMenuItem.Image"), System.Drawing.Image)
      Me.PrintPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.PrintPreviewToolStripMenuItem.Name = "PrintPreviewToolStripMenuItem"
      Me.PrintPreviewToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.PrintPreviewToolStripMenuItem.Text = "Print Pre&view"
      '
      'toolStripSeparator2
      '
      Me.toolStripSeparator2.Name = "toolStripSeparator2"
      Me.toolStripSeparator2.Size = New System.Drawing.Size(137, 6)
      '
      'ExitToolStripMenuItem
      '
      Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
      Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
      Me.ExitToolStripMenuItem.Text = "E&xit"
      '
      'EditToolStripMenuItem
      '
      Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoToolStripMenuItem, Me.RedoToolStripMenuItem, Me.toolStripSeparator3, Me.CutToolStripMenuItem, Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.toolStripSeparator4, Me.SelectAllToolStripMenuItem})
      Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
      Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me.EditToolStripMenuItem.Text = "&Edit"
      '
      'UndoToolStripMenuItem
      '
      Me.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem"
      Me.UndoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
      Me.UndoToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.UndoToolStripMenuItem.Text = "&Undo"
      '
      'RedoToolStripMenuItem
      '
      Me.RedoToolStripMenuItem.Name = "RedoToolStripMenuItem"
      Me.RedoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
      Me.RedoToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.RedoToolStripMenuItem.Text = "&Redo"
      '
      'toolStripSeparator3
      '
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(136, 6)
      '
      'CutToolStripMenuItem
      '
      Me.CutToolStripMenuItem.Image = CType(resources.GetObject("CutToolStripMenuItem.Image"), System.Drawing.Image)
      Me.CutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.CutToolStripMenuItem.Name = "CutToolStripMenuItem"
      Me.CutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
      Me.CutToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.CutToolStripMenuItem.Text = "Cu&t"
      '
      'CopyToolStripMenuItem
      '
      Me.CopyToolStripMenuItem.Image = CType(resources.GetObject("CopyToolStripMenuItem.Image"), System.Drawing.Image)
      Me.CopyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
      Me.CopyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
      Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.CopyToolStripMenuItem.Text = "&Copy"
      '
      'PasteToolStripMenuItem
      '
      Me.PasteToolStripMenuItem.Image = CType(resources.GetObject("PasteToolStripMenuItem.Image"), System.Drawing.Image)
      Me.PasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
      Me.PasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
      Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.PasteToolStripMenuItem.Text = "&Paste"
      '
      'toolStripSeparator4
      '
      Me.toolStripSeparator4.Name = "toolStripSeparator4"
      Me.toolStripSeparator4.Size = New System.Drawing.Size(136, 6)
      '
      'SelectAllToolStripMenuItem
      '
      Me.SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
      Me.SelectAllToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.SelectAllToolStripMenuItem.Text = "Select &All"
      '
      'ToolsToolStripMenuItem
      '
      Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CustomizeToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.ToolStripSeparator8, Me.LoadUrlDataToolStripMenuItem})
      Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
      Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me.ToolsToolStripMenuItem.Text = "&Tools"
      '
      'CustomizeToolStripMenuItem
      '
      Me.CustomizeToolStripMenuItem.Name = "CustomizeToolStripMenuItem"
      Me.CustomizeToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.CustomizeToolStripMenuItem.Text = "&Customize"
      '
      'OptionsToolStripMenuItem
      '
      Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
      Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.OptionsToolStripMenuItem.Text = "&Options"
      '
      'ToolStripSeparator8
      '
      Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
      Me.ToolStripSeparator8.Size = New System.Drawing.Size(136, 6)
      '
      'LoadUrlDataToolStripMenuItem
      '
      Me.LoadUrlDataToolStripMenuItem.Name = "LoadUrlDataToolStripMenuItem"
      Me.LoadUrlDataToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
      Me.LoadUrlDataToolStripMenuItem.Text = "Load Url Data"
      '
      'HelpToolStripMenuItem
      '
      Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.IndexToolStripMenuItem, Me.SearchToolStripMenuItem, Me.toolStripSeparator5, Me.AboutToolStripMenuItem})
      Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
      Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
      Me.HelpToolStripMenuItem.Text = "&Help"
      '
      'ContentsToolStripMenuItem
      '
      Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
      Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
      Me.ContentsToolStripMenuItem.Text = "&Contents"
      '
      'IndexToolStripMenuItem
      '
      Me.IndexToolStripMenuItem.Name = "IndexToolStripMenuItem"
      Me.IndexToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
      Me.IndexToolStripMenuItem.Text = "&Index"
      '
      'SearchToolStripMenuItem
      '
      Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
      Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
      Me.SearchToolStripMenuItem.Text = "&Search"
      '
      'toolStripSeparator5
      '
      Me.toolStripSeparator5.Name = "toolStripSeparator5"
      Me.toolStripSeparator5.Size = New System.Drawing.Size(115, 6)
      '
      'AboutToolStripMenuItem
      '
      Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
      Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
      Me.AboutToolStripMenuItem.Text = "&About..."
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.OpenToolStripButton, Me.SaveToolStripButton, Me.toolStripSeparator6, Me.ImportProjectToolStripButton, Me.RefreshToolStripButton, Me.CheckProjectToolStripButton, Me.toolStripSeparator7, Me.StartToolStripButton, Me.StopToolStripButton, Me.ToolStripSeparator9, Me.HelpToolStripButton})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(1153, 25)
      Me.ToolStrip1.TabIndex = 5
      Me.ToolStrip1.Text = "MainToolStrip"
      '
      'NewToolStripButton
      '
      Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
      Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.NewToolStripButton.Name = "NewToolStripButton"
      Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.NewToolStripButton.Text = "&New"
      '
      'OpenToolStripButton
      '
      Me.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.OpenToolStripButton.Image = CType(resources.GetObject("OpenToolStripButton.Image"), System.Drawing.Image)
      Me.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.OpenToolStripButton.Name = "OpenToolStripButton"
      Me.OpenToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.OpenToolStripButton.Text = "&Open"
      '
      'SaveToolStripButton
      '
      Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
      Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SaveToolStripButton.Name = "SaveToolStripButton"
      Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.SaveToolStripButton.Text = "&Save"
      '
      'toolStripSeparator6
      '
      Me.toolStripSeparator6.Name = "toolStripSeparator6"
      Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
      '
      'ImportProjectToolStripButton
      '
      Me.ImportProjectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ImportProjectToolStripButton.Image = CType(resources.GetObject("ImportProjectToolStripButton.Image"), System.Drawing.Image)
      Me.ImportProjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ImportProjectToolStripButton.Name = "ImportProjectToolStripButton"
      Me.ImportProjectToolStripButton.Size = New System.Drawing.Size(80, 22)
      Me.ImportProjectToolStripButton.Text = "Import Project"
      '
      'RefreshToolStripButton
      '
      Me.RefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.RefreshToolStripButton.Image = CType(resources.GetObject("RefreshToolStripButton.Image"), System.Drawing.Image)
      Me.RefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RefreshToolStripButton.Name = "RefreshToolStripButton"
      Me.RefreshToolStripButton.Size = New System.Drawing.Size(49, 22)
      Me.RefreshToolStripButton.Text = "Refresh"
      '
      'CheckProjectToolStripButton
      '
      Me.CheckProjectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.CheckProjectToolStripButton.Image = CType(resources.GetObject("CheckProjectToolStripButton.Image"), System.Drawing.Image)
      Me.CheckProjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.CheckProjectToolStripButton.Name = "CheckProjectToolStripButton"
      Me.CheckProjectToolStripButton.Size = New System.Drawing.Size(77, 22)
      Me.CheckProjectToolStripButton.Text = "Check Project"
      '
      'toolStripSeparator7
      '
      Me.toolStripSeparator7.Name = "toolStripSeparator7"
      Me.toolStripSeparator7.Size = New System.Drawing.Size(6, 25)
      '
      'StartToolStripButton
      '
      Me.StartToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.StartToolStripButton.Image = CType(resources.GetObject("StartToolStripButton.Image"), System.Drawing.Image)
      Me.StartToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.StartToolStripButton.Name = "StartToolStripButton"
      Me.StartToolStripButton.Size = New System.Drawing.Size(35, 22)
      Me.StartToolStripButton.Text = "Start"
      Me.StartToolStripButton.ToolTipText = "Stop"
      '
      'StopToolStripButton
      '
      Me.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.StopToolStripButton.Image = CType(resources.GetObject("StopToolStripButton.Image"), System.Drawing.Image)
      Me.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.StopToolStripButton.Name = "StopToolStripButton"
      Me.StopToolStripButton.Size = New System.Drawing.Size(33, 22)
      Me.StopToolStripButton.Text = "Stop"
      Me.StopToolStripButton.ToolTipText = "Start"
      '
      'ToolStripSeparator9
      '
      Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
      Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
      '
      'HelpToolStripButton
      '
      Me.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.HelpToolStripButton.Image = CType(resources.GetObject("HelpToolStripButton.Image"), System.Drawing.Image)
      Me.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.HelpToolStripButton.Name = "HelpToolStripButton"
      Me.HelpToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.HelpToolStripButton.Text = "He&lp"
      '
      'SiteCrawler
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(1153, 562)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.MenuStrip1)
      Me.MainMenuStrip = Me.MenuStrip1
      Me.Name = "SiteCrawler"
      Me.Text = "SiteCrawler"
      Me.ProjectManagerContextMenuStrip.ResumeLayout(False)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.TabControl1.ResumeLayout(False)
      Me.GeneralTabPage.ResumeLayout(False)
      Me.DataMappingTabPage.ResumeLayout(False)
      Me.DataMappingTabPage.PerformLayout()
      CType(Me.DataMappingDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.DataMappingToolStrip.ResumeLayout(False)
      Me.DataMappingToolStrip.PerformLayout()
      Me.LinkMappingTabPage.ResumeLayout(False)
      Me.LinkMappingTabPage.PerformLayout()
      CType(Me.LinkMappingDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.UrlMappingToolStrip.ResumeLayout(False)
      Me.UrlMappingToolStrip.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.MenuStrip1.ResumeLayout(False)
      Me.MenuStrip1.PerformLayout()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
   Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents PrintPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents UndoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents RedoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents CutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SelectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents CustomizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents IndexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents OpenToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents toolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents HelpToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents LoadUrlDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents GeneralTabPage As System.Windows.Forms.TabPage
   Friend WithEvents DataMappingTabPage As System.Windows.Forms.TabPage
   Friend WithEvents DataMappingDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents CheckProjectToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ProjectManagerContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents AddProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents RemoveProjectToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents LinkMappingTabPage As System.Windows.Forms.TabPage
   Friend WithEvents LinkMappingDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents ImportProjectToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents UrlMappingToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ProjectToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents UrlTagToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents AddUrlMappingToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents RemoveUrlMappingToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents LinkMappingTagID As System.Windows.Forms.DataGridViewComboBoxColumn
   Friend WithEvents LinkMappingProjectID As System.Windows.Forms.DataGridViewComboBoxColumn
   Friend WithEvents DataMappingToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents TableGeneratedToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents StopToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents StartToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents CrawlTabPage As System.Windows.Forms.TabPage
   Friend WithEvents ProjectListView As System.Windows.Forms.ListView
   Friend WithEvents RefreshToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DataMappingTag As System.Windows.Forms.DataGridViewComboBoxColumn
   Friend WithEvents DataMappingField As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataMappingID As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents DataMappingChecksum As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents ProjectInfoControl1 As SharedUI.ProjectInfoControl
End Class
