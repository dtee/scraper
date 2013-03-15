<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UrlManagerControl
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UrlManagerControl))
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.ChangeStatusContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.AddUrlPanel = New System.Windows.Forms.Panel
      Me.ProjectListCheckedListBox = New System.Windows.Forms.CheckedListBox
      Me.txtUrl = New System.Windows.Forms.TextBox
      Me.AddButton = New System.Windows.Forms.Button
      Me.txtPost = New System.Windows.Forms.TextBox
      Me.Label3 = New System.Windows.Forms.Label
      Me.txtReferer = New System.Windows.Forms.TextBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
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
      Me.ShowFieldMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.FilterToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton
      Me.ColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ChangeStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.AddUrlPanel.SuspendLayout()
      Me.UrlListToolStrip.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ContextMenuStrip1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ChangeStatusContextMenuStrip
      '
      Me.ChangeStatusContextMenuStrip.Name = "ChangeStatusContextMenuStrip"
      Me.ChangeStatusContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'AddUrlPanel
      '
      Me.AddUrlPanel.Controls.Add(Me.ProjectListCheckedListBox)
      Me.AddUrlPanel.Controls.Add(Me.txtUrl)
      Me.AddUrlPanel.Controls.Add(Me.AddButton)
      Me.AddUrlPanel.Controls.Add(Me.txtPost)
      Me.AddUrlPanel.Controls.Add(Me.Label3)
      Me.AddUrlPanel.Controls.Add(Me.txtReferer)
      Me.AddUrlPanel.Controls.Add(Me.Label2)
      Me.AddUrlPanel.Controls.Add(Me.Label1)
      Me.AddUrlPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.AddUrlPanel.Location = New System.Drawing.Point(0, 25)
      Me.AddUrlPanel.Name = "AddUrlPanel"
      Me.AddUrlPanel.Size = New System.Drawing.Size(873, 78)
      Me.AddUrlPanel.TabIndex = 0
      Me.AddUrlPanel.Visible = False
      '
      'ProjectListCheckedListBox
      '
      Me.ProjectListCheckedListBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ProjectListCheckedListBox.FormattingEnabled = True
      Me.ProjectListCheckedListBox.Items.AddRange(New Object() {"Project 1", "Project 2"})
      Me.ProjectListCheckedListBox.Location = New System.Drawing.Point(643, 6)
      Me.ProjectListCheckedListBox.Name = "ProjectListCheckedListBox"
      Me.ProjectListCheckedListBox.Size = New System.Drawing.Size(137, 64)
      Me.ProjectListCheckedListBox.TabIndex = 26
      '
      'txtUrl
      '
      Me.txtUrl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtUrl.Location = New System.Drawing.Point(57, 5)
      Me.txtUrl.Multiline = True
      Me.txtUrl.Name = "txtUrl"
      Me.txtUrl.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
      Me.txtUrl.Size = New System.Drawing.Size(580, 20)
      Me.txtUrl.TabIndex = 25
      Me.txtUrl.Text = "http://www.dkr.com/$a-z$/test$1-10$.html"
      '
      'AddButton
      '
      Me.AddButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.AddButton.Location = New System.Drawing.Point(786, 3)
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
      Me.txtPost.Size = New System.Drawing.Size(580, 20)
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
      Me.txtReferer.Size = New System.Drawing.Size(580, 20)
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
      'UrlListToolStrip
      '
      Me.UrlListToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddUrlToolStripButton, Me.RemoveToolStripButton, Me.ToolStripSeparator1, Me.ImportToolStripButton, Me.ToolStripSeparator2, Me.EditPostDataToolStripButton, Me.SelectAllToolStripButton, Me.ToolStripSeparator5, Me.ViewColumnToolStripDropDownButton, Me.FilterToolStripDropDownButton})
      Me.UrlListToolStrip.Location = New System.Drawing.Point(0, 0)
      Me.UrlListToolStrip.Name = "UrlListToolStrip"
      Me.UrlListToolStrip.Size = New System.Drawing.Size(873, 25)
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
      Me.ViewColumnToolStripDropDownButton.DropDown = Me.ShowFieldMenuStrip
      Me.ViewColumnToolStripDropDownButton.Image = CType(resources.GetObject("ViewColumnToolStripDropDownButton.Image"), System.Drawing.Image)
      Me.ViewColumnToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ViewColumnToolStripDropDownButton.Name = "ViewColumnToolStripDropDownButton"
      Me.ViewColumnToolStripDropDownButton.Size = New System.Drawing.Size(80, 22)
      Me.ViewColumnToolStripDropDownButton.Text = "View Column"
      Me.ViewColumnToolStripDropDownButton.ToolTipText = "ToolStripDropDownButton"
      '
      'ShowFieldMenuStrip
      '
      Me.ShowFieldMenuStrip.Name = "CustomContextMenuStrip"
      Me.ShowFieldMenuStrip.OwnerItem = Me.ColumnsToolStripMenuItem
      Me.ShowFieldMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'FilterToolStripDropDownButton
      '
      Me.FilterToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.FilterToolStripDropDownButton.Image = CType(resources.GetObject("FilterToolStripDropDownButton.Image"), System.Drawing.Image)
      Me.FilterToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.FilterToolStripDropDownButton.Name = "FilterToolStripDropDownButton"
      Me.FilterToolStripDropDownButton.Size = New System.Drawing.Size(44, 22)
      Me.FilterToolStripDropDownButton.Text = "Filter"
      '
      'ColumnsToolStripMenuItem
      '
      Me.ColumnsToolStripMenuItem.DropDown = Me.ShowFieldMenuStrip
      Me.ColumnsToolStripMenuItem.Name = "ColumnsToolStripMenuItem"
      Me.ColumnsToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.ColumnsToolStripMenuItem.Text = "Columns"
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      Me.ErrorProvider1.RightToLeft = True
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
      Me.ChangeStatusToolStripMenuItem.Name = "ChangeStatusToolStripMenuItem"
      Me.ChangeStatusToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.ChangeStatusToolStripMenuItem.Text = "Change Status"
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(142, 6)
      Me.ToolStripSeparator4.Visible = False
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToOrderColumns = True
      Me.DataGridView1.AllowUserToResizeRows = False
      DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.ContextMenuStrip = Me.ChangeStatusContextMenuStrip
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 103)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.RowHeadersVisible = False
      Me.DataGridView1.RowTemplate.Height = 20
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(873, 421)
      Me.DataGridView1.TabIndex = 1
      '
      'UrlManagerControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.AddUrlPanel)
      Me.Controls.Add(Me.UrlListToolStrip)
      Me.Name = "UrlManagerControl"
      Me.Size = New System.Drawing.Size(873, 524)
      Me.AddUrlPanel.ResumeLayout(False)
      Me.AddUrlPanel.PerformLayout()
      Me.UrlListToolStrip.ResumeLayout(False)
      Me.UrlListToolStrip.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ContextMenuStrip1.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents AddUrlPanel As System.Windows.Forms.Panel
   Friend WithEvents txtUrl As System.Windows.Forms.TextBox
   Friend WithEvents AddButton As System.Windows.Forms.Button
   Friend WithEvents txtPost As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents txtReferer As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents UrlListToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents AddUrlToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents RemoveToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ImportToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents EditPostDataToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents SelectAllToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ViewColumnToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChangeStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ShowFieldMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ChangeStatusContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ProjectListCheckedListBox As System.Windows.Forms.CheckedListBox
   Friend WithEvents FilterToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

End Class
