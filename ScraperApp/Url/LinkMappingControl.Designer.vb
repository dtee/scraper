<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LinkMappingControl
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LinkMappingControl))
      Me.UrlMappingToolStrip = New System.Windows.Forms.ToolStrip
      Me.RefreshToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ProjectLinkTreeView = New System.Windows.Forms.TreeView
      Me.LinkMappingContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ProjectsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.PartialDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.LinkImageList = New System.Windows.Forms.ImageList(Me.components)
      Me.DatasetTreeView = New System.Windows.Forms.TreeView
      Me.DatasetContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.IdentifierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.DatasetImageList = New System.Windows.Forms.ImageList(Me.components)
      Me.DataTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.DataTypeContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.UrlMappingToolStrip.SuspendLayout()
      Me.LinkMappingContextMenuStrip.SuspendLayout()
      Me.DatasetContextMenuStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      'UrlMappingToolStrip
      '
      Me.UrlMappingToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripButton})
      Me.UrlMappingToolStrip.Location = New System.Drawing.Point(0, 0)
      Me.UrlMappingToolStrip.Name = "UrlMappingToolStrip"
      Me.UrlMappingToolStrip.Size = New System.Drawing.Size(659, 25)
      Me.UrlMappingToolStrip.TabIndex = 17
      Me.UrlMappingToolStrip.Text = "ToolStrip2"
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
      'ProjectLinkTreeView
      '
      Me.ProjectLinkTreeView.ContextMenuStrip = Me.LinkMappingContextMenuStrip
      Me.ProjectLinkTreeView.Dock = System.Windows.Forms.DockStyle.Left
      Me.ProjectLinkTreeView.ImageIndex = 0
      Me.ProjectLinkTreeView.ImageList = Me.LinkImageList
      Me.ProjectLinkTreeView.Location = New System.Drawing.Point(0, 25)
      Me.ProjectLinkTreeView.Name = "ProjectLinkTreeView"
      Me.ProjectLinkTreeView.SelectedImageIndex = 0
      Me.ProjectLinkTreeView.Size = New System.Drawing.Size(194, 383)
      Me.ProjectLinkTreeView.TabIndex = 18
      '
      'LinkMappingContextMenuStrip
      '
      Me.LinkMappingContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.RemoveToolStripMenuItem, Me.AddToolStripMenuItem, Me.PartialDataToolStripMenuItem})
      Me.LinkMappingContextMenuStrip.Name = "LinkMappingContextMenuStrip"
      Me.LinkMappingContextMenuStrip.Size = New System.Drawing.Size(128, 92)
      '
      'RefreshToolStripMenuItem
      '
      Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
      Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
      Me.RefreshToolStripMenuItem.Text = "Refresh"
      '
      'RemoveToolStripMenuItem
      '
      Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
      Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
      Me.RemoveToolStripMenuItem.Text = "Remove"
      '
      'AddToolStripMenuItem
      '
      Me.AddToolStripMenuItem.DropDown = Me.ProjectsContextMenuStrip
      Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
      Me.AddToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
      Me.AddToolStripMenuItem.Text = "Add"
      '
      'ProjectsContextMenuStrip
      '
      Me.ProjectsContextMenuStrip.Name = "ProjectsContextMenuStrip"
      Me.ProjectsContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'PartialDataToolStripMenuItem
      '
      Me.PartialDataToolStripMenuItem.CheckOnClick = True
      Me.PartialDataToolStripMenuItem.Name = "PartialDataToolStripMenuItem"
      Me.PartialDataToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
      Me.PartialDataToolStripMenuItem.Text = "PartialData"
      '
      'LinkImageList
      '
      Me.LinkImageList.ImageStream = CType(resources.GetObject("LinkImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.LinkImageList.TransparentColor = System.Drawing.Color.Transparent
      Me.LinkImageList.Images.SetKeyName(0, "CrawlProject.gif")
      Me.LinkImageList.Images.SetKeyName(1, "Project.gif")
      Me.LinkImageList.Images.SetKeyName(2, "DataTableLink.gif")
      Me.LinkImageList.Images.SetKeyName(3, "FieldChildLink.gif")
      Me.LinkImageList.Images.SetKeyName(4, "Partial.gif")
      Me.LinkImageList.Images.SetKeyName(5, "NewData.gif")
      '
      'DatasetTreeView
      '
      Me.DatasetTreeView.ContextMenuStrip = Me.DatasetContextMenuStrip
      Me.DatasetTreeView.Dock = System.Windows.Forms.DockStyle.Left
      Me.DatasetTreeView.HideSelection = False
      Me.DatasetTreeView.ImageIndex = 0
      Me.DatasetTreeView.ImageList = Me.DatasetImageList
      Me.DatasetTreeView.Location = New System.Drawing.Point(194, 25)
      Me.DatasetTreeView.Name = "DatasetTreeView"
      Me.DatasetTreeView.SelectedImageIndex = 0
      Me.DatasetTreeView.Size = New System.Drawing.Size(178, 383)
      Me.DatasetTreeView.TabIndex = 19
      '
      'DatasetContextMenuStrip
      '
      Me.DatasetContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IdentifierToolStripMenuItem, Me.DataTypeToolStripMenuItem})
      Me.DatasetContextMenuStrip.Name = "DatasetContextMenuStrip"
      Me.DatasetContextMenuStrip.Size = New System.Drawing.Size(125, 48)
      '
      'IdentifierToolStripMenuItem
      '
      Me.IdentifierToolStripMenuItem.CheckOnClick = True
      Me.IdentifierToolStripMenuItem.Name = "IdentifierToolStripMenuItem"
      Me.IdentifierToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
      Me.IdentifierToolStripMenuItem.Text = "Identifier"
      '
      'DatasetImageList
      '
      Me.DatasetImageList.ImageStream = CType(resources.GetObject("DatasetImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.DatasetImageList.TransparentColor = System.Drawing.Color.Transparent
      Me.DatasetImageList.Images.SetKeyName(0, "Dataset.gif")
      Me.DatasetImageList.Images.SetKeyName(1, "DataTable.gif")
      Me.DatasetImageList.Images.SetKeyName(2, "FieldIdentity.gif")
      Me.DatasetImageList.Images.SetKeyName(3, "FieldChild.gif")
      '
      'DataTypeToolStripMenuItem
      '
      Me.DataTypeToolStripMenuItem.DropDown = Me.DataTypeContextMenuStrip
      Me.DataTypeToolStripMenuItem.Name = "DataTypeToolStripMenuItem"
      Me.DataTypeToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
      Me.DataTypeToolStripMenuItem.Text = "Data Type"
      '
      'DataTypeContextMenuStrip
      '
      Me.DataTypeContextMenuStrip.Name = "DataTypeContextMenuStrip"
      Me.DataTypeContextMenuStrip.Size = New System.Drawing.Size(153, 26)
      '
      'LinkMappingControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.DatasetTreeView)
      Me.Controls.Add(Me.ProjectLinkTreeView)
      Me.Controls.Add(Me.UrlMappingToolStrip)
      Me.Name = "LinkMappingControl"
      Me.Size = New System.Drawing.Size(659, 408)
      Me.UrlMappingToolStrip.ResumeLayout(False)
      Me.UrlMappingToolStrip.PerformLayout()
      Me.LinkMappingContextMenuStrip.ResumeLayout(False)
      Me.DatasetContextMenuStrip.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents UrlMappingToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents RefreshToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ProjectLinkTreeView As System.Windows.Forms.TreeView
   Friend WithEvents LinkMappingContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DatasetTreeView As System.Windows.Forms.TreeView
   Friend WithEvents DatasetImageList As System.Windows.Forms.ImageList
   Friend WithEvents DatasetContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents IdentifierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents LinkImageList As System.Windows.Forms.ImageList
   Friend WithEvents ProjectsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents PartialDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DataTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DataTypeContextMenuStrip As System.Windows.Forms.ContextMenuStrip

End Class
