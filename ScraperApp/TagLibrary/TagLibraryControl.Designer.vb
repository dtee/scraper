<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagLibraryControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TagLibraryControl))
      Me.EditProjectPanel = New System.Windows.Forms.SplitContainer
      Me.TagTreeView1 = New SharedUI.TagTreeView
      Me.TagTreeImageList = New System.Windows.Forms.ImageList(Me.components)
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
      Me.TextEditContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.CopyTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.GenerateParentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.TagNodeInfoControl1 = New SharedUI.TagNodeInfoControl
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.TagTreeViewContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.NewNodeUnderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.NewNodeBelowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.MoveUpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.MoveDownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
      Me.WizardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.EditorToolStrip = New System.Windows.Forms.ToolStrip
      Me.UrlToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.DownloadToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator16 = New System.Windows.Forms.ToolStripSeparator
      Me.ScrapeToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.DataNodeWindowToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ResultDataViewToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ColorSelectedToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.SearchToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.EditProjectPanel.Panel1.SuspendLayout()
      Me.EditProjectPanel.Panel2.SuspendLayout()
      Me.EditProjectPanel.SuspendLayout()
      Me.TextEditContextMenuStrip.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TagTreeViewContextMenuStrip.SuspendLayout()
      Me.EditorToolStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      'EditProjectPanel
      '
      Me.EditProjectPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.EditProjectPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.EditProjectPanel.Location = New System.Drawing.Point(0, 25)
      Me.EditProjectPanel.Name = "EditProjectPanel"
      '
      'EditProjectPanel.Panel1
      '
      Me.EditProjectPanel.Panel1.Controls.Add(Me.TagTreeView1)
      '
      'EditProjectPanel.Panel2
      '
      Me.EditProjectPanel.Panel2.Controls.Add(Me.RichTextBox1)
      Me.EditProjectPanel.Panel2.Controls.Add(Me.TagNodeInfoControl1)
      Me.EditProjectPanel.Panel2.Controls.Add(Me.DataGridView1)
      Me.EditProjectPanel.Size = New System.Drawing.Size(812, 511)
      Me.EditProjectPanel.SplitterDistance = 194
      Me.EditProjectPanel.TabIndex = 8
      '
      'TagTreeView1
      '
      Me.TagTreeView1.AllowDrop = True
      Me.TagTreeView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TagTreeView1.HideSelection = False
      Me.TagTreeView1.ImageKey = "Child.gif"
      Me.TagTreeView1.ImageList = Me.TagTreeImageList
      Me.TagTreeView1.ItemHeight = 16
      Me.TagTreeView1.Location = New System.Drawing.Point(0, 0)
      Me.TagTreeView1.Name = "TagTreeView1"
      Me.TagTreeView1.SelectedImageIndex = 0
      Me.TagTreeView1.SelectedNode = Nothing
      Me.TagTreeView1.Size = New System.Drawing.Size(192, 509)
      Me.TagTreeView1.TabIndex = 3
      Me.TagTreeView1.TagTree = Nothing
      Me.TagTreeView1.TempSelectedNode = Nothing
      '
      'TagTreeImageList
      '
      Me.TagTreeImageList.ImageStream = CType(resources.GetObject("TagTreeImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.TagTreeImageList.TransparentColor = System.Drawing.Color.Transparent
      Me.TagTreeImageList.Images.SetKeyName(0, "Child.gif")
      Me.TagTreeImageList.Images.SetKeyName(1, "ChildSave.gif")
      Me.TagTreeImageList.Images.SetKeyName(2, "Parent.gif")
      Me.TagTreeImageList.Images.SetKeyName(3, "ParentSave.gif")
      Me.TagTreeImageList.Images.SetKeyName(4, "ParentChild.gif")
      Me.TagTreeImageList.Images.SetKeyName(5, "ParentChildSave.gif")
      '
      'RichTextBox1
      '
      Me.RichTextBox1.ContextMenuStrip = Me.TextEditContextMenuStrip
      Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox1.HideSelection = False
      Me.RichTextBox1.Location = New System.Drawing.Point(0, 104)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(612, 405)
      Me.RichTextBox1.TabIndex = 12
      Me.RichTextBox1.Text = ""
      '
      'TextEditContextMenuStrip
      '
      Me.TextEditContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyTagsToolStripMenuItem, Me.GenerateParentsToolStripMenuItem})
      Me.TextEditContextMenuStrip.Name = "TextEditContextMenuStrip"
      Me.TextEditContextMenuStrip.Size = New System.Drawing.Size(160, 48)
      '
      'CopyTagsToolStripMenuItem
      '
      Me.CopyTagsToolStripMenuItem.Name = "CopyTagsToolStripMenuItem"
      Me.CopyTagsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
      Me.CopyTagsToolStripMenuItem.Text = "Copy Tags"
      '
      'GenerateParentsToolStripMenuItem
      '
      Me.GenerateParentsToolStripMenuItem.Name = "GenerateParentsToolStripMenuItem"
      Me.GenerateParentsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
      Me.GenerateParentsToolStripMenuItem.Text = "Generate Parents"
      '
      'TagNodeInfoControl1
      '
      Me.TagNodeInfoControl1.Dock = System.Windows.Forms.DockStyle.Top
      Me.TagNodeInfoControl1.Location = New System.Drawing.Point(0, 0)
      Me.TagNodeInfoControl1.Name = "TagNodeInfoControl1"
      Me.TagNodeInfoControl1.Size = New System.Drawing.Size(612, 104)
      Me.TagNodeInfoControl1.TabIndex = 7
      Me.TagNodeInfoControl1.TagTreeNode = Nothing
      '
      'DataGridView1
      '
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.Size = New System.Drawing.Size(612, 509)
      Me.DataGridView1.TabIndex = 13
      '
      'TagTreeViewContextMenuStrip
      '
      Me.TagTreeViewContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewNodeUnderToolStripMenuItem, Me.NewNodeBelowToolStripMenuItem, Me.ToolStripSeparator1, Me.MoveUpToolStripMenuItem, Me.MoveDownToolStripMenuItem, Me.ToolStripSeparator2, Me.DeleteToolStripMenuItem, Me.ToolStripSeparator13, Me.WizardToolStripMenuItem})
      Me.TagTreeViewContextMenuStrip.Name = "ContextMenuStrip1"
      Me.TagTreeViewContextMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
      Me.TagTreeViewContextMenuStrip.Size = New System.Drawing.Size(148, 154)
      '
      'NewNodeUnderToolStripMenuItem
      '
      Me.NewNodeUnderToolStripMenuItem.Name = "NewNodeUnderToolStripMenuItem"
      Me.NewNodeUnderToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
      Me.NewNodeUnderToolStripMenuItem.Text = "New (Under)"
      '
      'NewNodeBelowToolStripMenuItem
      '
      Me.NewNodeBelowToolStripMenuItem.Name = "NewNodeBelowToolStripMenuItem"
      Me.NewNodeBelowToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
      Me.NewNodeBelowToolStripMenuItem.Text = "New (Below)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
      '
      'MoveUpToolStripMenuItem
      '
      Me.MoveUpToolStripMenuItem.Name = "MoveUpToolStripMenuItem"
      Me.MoveUpToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
      Me.MoveUpToolStripMenuItem.Text = "Move Up"
      '
      'MoveDownToolStripMenuItem
      '
      Me.MoveDownToolStripMenuItem.Name = "MoveDownToolStripMenuItem"
      Me.MoveDownToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
      Me.MoveDownToolStripMenuItem.Text = "Move Down"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(144, 6)
      '
      'DeleteToolStripMenuItem
      '
      Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
      Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
      Me.DeleteToolStripMenuItem.Text = "Delete"
      '
      'ToolStripSeparator13
      '
      Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
      Me.ToolStripSeparator13.Size = New System.Drawing.Size(144, 6)
      '
      'WizardToolStripMenuItem
      '
      Me.WizardToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.WizardToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight
      Me.WizardToolStripMenuItem.Name = "WizardToolStripMenuItem"
      Me.WizardToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
      Me.WizardToolStripMenuItem.Text = "Tag Wizard"
      '
      'EditorToolStrip
      '
      Me.EditorToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.EditorToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UrlToolStripComboBox, Me.DownloadToolStripButton, Me.ToolStripSeparator16, Me.ScrapeToolStripButton, Me.ToolStripSeparator3, Me.DataNodeWindowToolStripButton, Me.ResultDataViewToolStripButton, Me.ColorSelectedToolStripButton, Me.ToolStripSeparator5, Me.SearchToolStripButton})
      Me.EditorToolStrip.Location = New System.Drawing.Point(0, 0)
      Me.EditorToolStrip.Name = "EditorToolStrip"
      Me.EditorToolStrip.Size = New System.Drawing.Size(812, 25)
      Me.EditorToolStrip.TabIndex = 10
      Me.EditorToolStrip.Text = "ToolStrip2"
      '
      'UrlToolStripComboBox
      '
      Me.UrlToolStripComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.UrlToolStripComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.UrlToolStripComboBox.Name = "UrlToolStripComboBox"
      Me.UrlToolStripComboBox.Size = New System.Drawing.Size(380, 25)
      Me.UrlToolStripComboBox.ToolTipText = "Sample Url"
      '
      'DownloadToolStripButton
      '
      Me.DownloadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.DownloadToolStripButton.Image = CType(resources.GetObject("DownloadToolStripButton.Image"), System.Drawing.Image)
      Me.DownloadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.DownloadToolStripButton.Name = "DownloadToolStripButton"
      Me.DownloadToolStripButton.Size = New System.Drawing.Size(58, 22)
      Me.DownloadToolStripButton.Text = "Download"
      '
      'ToolStripSeparator16
      '
      Me.ToolStripSeparator16.Name = "ToolStripSeparator16"
      Me.ToolStripSeparator16.Size = New System.Drawing.Size(6, 25)
      '
      'ScrapeToolStripButton
      '
      Me.ScrapeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ScrapeToolStripButton.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ScrapeToolStripButton.ForeColor = System.Drawing.SystemColors.Highlight
      Me.ScrapeToolStripButton.Image = CType(resources.GetObject("ScrapeToolStripButton.Image"), System.Drawing.Image)
      Me.ScrapeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ScrapeToolStripButton.Name = "ScrapeToolStripButton"
      Me.ScrapeToolStripButton.Size = New System.Drawing.Size(57, 22)
      Me.ScrapeToolStripButton.Text = "Scrape"
      Me.ScrapeToolStripButton.ToolTipText = "Scrape Sample Data"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      '
      'DataNodeWindowToolStripButton
      '
      Me.DataNodeWindowToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.DataNodeWindowToolStripButton.Enabled = False
      Me.DataNodeWindowToolStripButton.Image = CType(resources.GetObject("DataNodeWindowToolStripButton.Image"), System.Drawing.Image)
      Me.DataNodeWindowToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.DataNodeWindowToolStripButton.Name = "DataNodeWindowToolStripButton"
      Me.DataNodeWindowToolStripButton.Size = New System.Drawing.Size(62, 22)
      Me.DataNodeWindowToolStripButton.Text = "Node Data"
      Me.DataNodeWindowToolStripButton.ToolTipText = "View Node Data"
      '
      'ResultDataViewToolStripButton
      '
      Me.ResultDataViewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ResultDataViewToolStripButton.Enabled = False
      Me.ResultDataViewToolStripButton.Image = CType(resources.GetObject("ResultDataViewToolStripButton.Image"), System.Drawing.Image)
      Me.ResultDataViewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ResultDataViewToolStripButton.Name = "ResultDataViewToolStripButton"
      Me.ResultDataViewToolStripButton.Size = New System.Drawing.Size(41, 22)
      Me.ResultDataViewToolStripButton.Text = "Result"
      '
      'ColorSelectedToolStripButton
      '
      Me.ColorSelectedToolStripButton.CheckOnClick = True
      Me.ColorSelectedToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ColorSelectedToolStripButton.Enabled = False
      Me.ColorSelectedToolStripButton.Image = CType(resources.GetObject("ColorSelectedToolStripButton.Image"), System.Drawing.Image)
      Me.ColorSelectedToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ColorSelectedToolStripButton.Name = "ColorSelectedToolStripButton"
      Me.ColorSelectedToolStripButton.Size = New System.Drawing.Size(80, 22)
      Me.ColorSelectedToolStripButton.Text = "Highlight Node"
      Me.ColorSelectedToolStripButton.ToolTipText = "Highlight Node/All"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
      '
      'SearchToolStripButton
      '
      Me.SearchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.SearchToolStripButton.Image = CType(resources.GetObject("SearchToolStripButton.Image"), System.Drawing.Image)
      Me.SearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SearchToolStripButton.Name = "SearchToolStripButton"
      Me.SearchToolStripButton.Size = New System.Drawing.Size(44, 22)
      Me.SearchToolStripButton.Text = "Search"
      Me.SearchToolStripButton.ToolTipText = "Search Selected Node"
      '
      'TagLibraryControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.EditProjectPanel)
      Me.Controls.Add(Me.EditorToolStrip)
      Me.Name = "TagLibraryControl"
      Me.Size = New System.Drawing.Size(812, 536)
      Me.EditProjectPanel.Panel1.ResumeLayout(False)
      Me.EditProjectPanel.Panel2.ResumeLayout(False)
      Me.EditProjectPanel.ResumeLayout(False)
      Me.TextEditContextMenuStrip.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TagTreeViewContextMenuStrip.ResumeLayout(False)
      Me.EditorToolStrip.ResumeLayout(False)
      Me.EditorToolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents EditProjectPanel As System.Windows.Forms.SplitContainer
   Friend WithEvents TagTreeView1 As SharedUI.TagTreeView
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents TagNodeInfoControl1 As SharedUI.TagNodeInfoControl
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents EditorToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents UrlToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents DownloadToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator16 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ScrapeToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ResultDataViewToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents DataNodeWindowToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ColorSelectedToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SearchToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents TagTreeViewContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents NewNodeUnderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents NewNodeBelowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents MoveUpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents MoveDownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents WizardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TextEditContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents CopyTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents GenerateParentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TagTreeImageList As System.Windows.Forms.ImageList

End Class
