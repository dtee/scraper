<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UrlListView
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UrlListView))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.UrlListToolStrip = New System.Windows.Forms.ToolStrip
      Me.AddUrlToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.RemoveToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.ImportToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.EditPostDataToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.SelectAllToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.ViewColumnToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton
      Me.CustomContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.StatusToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
      Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ChangeStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ChangeStatusContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.AddUrlPanel = New System.Windows.Forms.Panel
      Me.txtUrl = New System.Windows.Forms.TextBox
      Me.AddButton = New System.Windows.Forms.Button
      Me.txtPost = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.txtReferer = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.UrlListToolStrip.SuspendLayout()
      Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
      Me.ToolStripContainer1.ContentPanel.SuspendLayout()
      Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
      Me.ToolStripContainer1.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ContextMenuStrip1.SuspendLayout()
      Me.AddUrlPanel.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'UrlListToolStrip
      '
      Me.UrlListToolStrip.Dock = System.Windows.Forms.DockStyle.None
      Me.UrlListToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUrlToolStripButton, Me.RemoveToolStripButton, Me.ToolStripSeparator1, Me.ImportToolStripButton, Me.ToolStripSeparator2, Me.EditPostDataToolStripButton, Me.SelectAllToolStripButton, Me.ToolStripSeparator5, Me.ViewColumnToolStripDropDownButton})
      Me.UrlListToolStrip.Location = New System.Drawing.Point(3, 0)
      Me.UrlListToolStrip.Name = "UrlListToolStrip"
      Me.UrlListToolStrip.Size = New System.Drawing.Size(407, 25)
      Me.UrlListToolStrip.TabIndex = 0
      Me.UrlListToolStrip.Text = "Menu"
      '
      'AddUrlToolStripButton
      '
      Me.AddUrlToolStripButton.CheckOnClick = True
      Me.AddUrlToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.AddUrlToolStripButton.Image = CType(resources.GetObject("AddUrlToolStripButton.Image"), System.Drawing.Image)
      Me.AddUrlToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AddUrlToolStripButton.Name = "AddUrlToolStripButton"
      Me.AddUrlToolStripButton.Size = New System.Drawing.Size(46, 22)
      Me.AddUrlToolStripButton.Text = "Add Url"
      '
      'RemoveToolStripButton
      '
      Me.RemoveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.RemoveToolStripButton.Image = CType(resources.GetObject("RemoveToolStripButton.Image"), System.Drawing.Image)
      Me.RemoveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RemoveToolStripButton.Name = "RemoveToolStripButton"
      Me.RemoveToolStripButton.Size = New System.Drawing.Size(79, 22)
      Me.RemoveToolStripButton.Text = "Remove Url(s)"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'ImportToolStripButton
      '
      Me.ImportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ImportToolStripButton.Enabled = False
      Me.ImportToolStripButton.Image = CType(resources.GetObject("ImportToolStripButton.Image"), System.Drawing.Image)
      Me.ImportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ImportToolStripButton.Name = "ImportToolStripButton"
      Me.ImportToolStripButton.Size = New System.Drawing.Size(62, 22)
      Me.ImportToolStripButton.Text = "Import File"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'EditPostDataToolStripButton
      '
      Me.EditPostDataToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.EditPostDataToolStripButton.Image = CType(resources.GetObject("EditPostDataToolStripButton.Image"), System.Drawing.Image)
      Me.EditPostDataToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.EditPostDataToolStripButton.Name = "EditPostDataToolStripButton"
      Me.EditPostDataToolStripButton.Size = New System.Drawing.Size(58, 22)
      Me.EditPostDataToolStripButton.Text = "Post Data"
      Me.EditPostDataToolStripButton.ToolTipText = "Edit Post Data"
      '
      'SelectAllToolStripButton
      '
      Me.SelectAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.SelectAllToolStripButton.Image = CType(resources.GetObject("SelectAllToolStripButton.Image"), System.Drawing.Image)
      Me.SelectAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SelectAllToolStripButton.Name = "SelectAllToolStripButton"
      Me.SelectAllToolStripButton.Size = New System.Drawing.Size(54, 22)
      Me.SelectAllToolStripButton.Text = "Select All"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
      '
      'ViewColumnToolStripDropDownButton
      '
      Me.ViewColumnToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ViewColumnToolStripDropDownButton.DropDown = Me.CustomContextMenuStrip
      Me.ViewColumnToolStripDropDownButton.Image = CType(resources.GetObject("ViewColumnToolStripDropDownButton.Image"), System.Drawing.Image)
      Me.ViewColumnToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ViewColumnToolStripDropDownButton.Name = "ViewColumnToolStripDropDownButton"
      Me.ViewColumnToolStripDropDownButton.Size = New System.Drawing.Size(80, 22)
      Me.ViewColumnToolStripDropDownButton.Text = "View Column"
      Me.ViewColumnToolStripDropDownButton.ToolTipText = "ToolStripDropDownButton"
      '
      'CustomContextMenuStrip
      '
      Me.CustomContextMenuStrip.Name = "CustomContextMenuStrip"
      Me.CustomContextMenuStrip.OwnerItem = Me.ColumnsToolStripMenuItem
      Me.CustomContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'ColumnsToolStripMenuItem
      '
      Me.ColumnsToolStripMenuItem.DropDown = Me.CustomContextMenuStrip
      Me.ColumnsToolStripMenuItem.Name = "ColumnsToolStripMenuItem"
      Me.ColumnsToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.ColumnsToolStripMenuItem.Text = "Columns"
      '
      'ToolStripContainer1
      '
      '
      'ToolStripContainer1.BottomToolStripPanel
      '
      Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.StatusStrip1)
      '
      'ToolStripContainer1.ContentPanel
      '
      Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.DataGridView1)
      Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.AddUrlPanel)
      Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(762, 353)
      Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStripContainer1.Name = "ToolStripContainer1"
      Me.ToolStripContainer1.Size = New System.Drawing.Size(762, 400)
      Me.ToolStripContainer1.TabIndex = 1
      Me.ToolStripContainer1.Text = "ToolStripContainer1"
      '
      'ToolStripContainer1.TopToolStripPanel
      '
      Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.UrlListToolStrip)
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusToolStripStatusLabel, Me.ToolStripProgressBar1})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 0)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(762, 22)
      Me.StatusStrip1.TabIndex = 0
      '
      'StatusToolStripStatusLabel
      '
      Me.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel"
      Me.StatusToolStripStatusLabel.Size = New System.Drawing.Size(38, 17)
      Me.StatusToolStripStatusLabel.Text = "Ready"
      '
      'ToolStripProgressBar1
      '
      Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
      Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
      Me.ToolStripProgressBar1.Visible = False
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToOrderColumns = True
      Me.DataGridView1.AllowUserToResizeRows = False
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 78)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.RowTemplate.Height = 20
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(762, 275)
      Me.DataGridView1.TabIndex = 1
      '
      'ContextMenuStrip1
      '
      Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.ChangeStatusToolStripMenuItem, Me.ToolStripSeparator4, Me.ColumnsToolStripMenuItem})
      Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
      Me.ContextMenuStrip1.Size = New System.Drawing.Size(146, 76)
      '
      'DeleteToolStripMenuItem
      '
      Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
      Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.DeleteToolStripMenuItem.Text = "Delete"
      '
      'ChangeStatusToolStripMenuItem
      '
      Me.ChangeStatusToolStripMenuItem.DropDown = Me.ChangeStatusContextMenuStrip
      Me.ChangeStatusToolStripMenuItem.Name = "ChangeStatusToolStripMenuItem"
      Me.ChangeStatusToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.ChangeStatusToolStripMenuItem.Text = "Change Status"
      '
      'ChangeStatusContextMenuStrip
      '
      Me.ChangeStatusContextMenuStrip.Name = "ChangeStatusContextMenuStrip"
      Me.ChangeStatusContextMenuStrip.OwnerItem = Me.ChangeStatusToolStripMenuItem
      Me.ChangeStatusContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(142, 6)
      Me.ToolStripSeparator4.Visible = False
      '
      'AddUrlPanel
      '
      Me.AddUrlPanel.Controls.Add(Me.txtUrl)
      Me.AddUrlPanel.Controls.Add(Me.AddButton)
      Me.AddUrlPanel.Controls.Add(Me.txtPost)
      Me.AddUrlPanel.Controls.Add(Me.Label3)
      Me.AddUrlPanel.Controls.Add(Me.txtReferer)
      Me.AddUrlPanel.Controls.Add(Me.Label2)
      Me.AddUrlPanel.Controls.Add(Me.Label1)
      Me.AddUrlPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.AddUrlPanel.Location = New System.Drawing.Point(0, 0)
      Me.AddUrlPanel.Name = "AddUrlPanel"
      Me.AddUrlPanel.Size = New System.Drawing.Size(762, 78)
      Me.AddUrlPanel.TabIndex = 0
      Me.AddUrlPanel.Visible = False
      '
      'txtUrl
      '
      Me.txtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtUrl.Location = New System.Drawing.Point(57, 5)
      Me.txtUrl.Multiline = True
      Me.txtUrl.Name = "txtUrl"
      Me.txtUrl.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
      Me.txtUrl.Size = New System.Drawing.Size(612, 20)
      Me.txtUrl.TabIndex = 25
      Me.txtUrl.Text = "http://www.dkr.com/$a-z$/test$1-10$.html"
      '
      'AddButton
      '
      Me.AddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.AddButton.Location = New System.Drawing.Point(675, 3)
      Me.AddButton.Name = "AddButton"
      Me.AddButton.Size = New System.Drawing.Size(75, 23)
      Me.AddButton.TabIndex = 24
      Me.AddButton.Text = "Add"
      Me.AddButton.UseVisualStyleBackColor = True
      '
      'txtPost
      '
      Me.txtPost.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPost.Location = New System.Drawing.Point(57, 27)
      Me.txtPost.Multiline = True
      Me.txtPost.Name = "txtPost"
      Me.txtPost.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
      Me.txtPost.Size = New System.Drawing.Size(612, 20)
      Me.txtPost.TabIndex = 23
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(9, 30)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(42, 20)
      Me.Label3.TabIndex = 22
      Me.Label3.Text = "Post"
      '
      'txtReferer
      '
      Me.txtReferer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtReferer.Location = New System.Drawing.Point(57, 50)
      Me.txtReferer.Name = "txtReferer"
      Me.txtReferer.Size = New System.Drawing.Size(612, 20)
      Me.txtReferer.TabIndex = 21
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(9, 50)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(42, 20)
      Me.Label2.TabIndex = 20
      Me.Label2.Text = "Referer"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(9, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(42, 20)
      Me.Label1.TabIndex = 18
      Me.Label1.Text = "Url"
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      Me.ErrorProvider1.RightToLeft = True
      '
      'UrlListView
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(762, 400)
      Me.Controls.Add(Me.ToolStripContainer1)
      Me.Name = "UrlListView"
      Me.Text = "Url List"
      Me.UrlListToolStrip.ResumeLayout(False)
      Me.UrlListToolStrip.PerformLayout()
      Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
      Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
      Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
      Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
      Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
      Me.ToolStripContainer1.ResumeLayout(False)
      Me.ToolStripContainer1.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ContextMenuStrip1.ResumeLayout(False)
      Me.AddUrlPanel.ResumeLayout(False)
      Me.AddUrlPanel.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents UrlListToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents AddUrlToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents RemoveToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ImportToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents AddUrlPanel As System.Windows.Forms.Panel
   Friend WithEvents txtPost As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtReferer As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents AddButton As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents txtUrl As System.Windows.Forms.TextBox
   Friend WithEvents SelectAllToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChangeStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents StatusToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents ColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ViewColumnToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents CustomContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ChangeStatusContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents EditPostDataToolStripButton As System.Windows.Forms.ToolStripButton
End Class
