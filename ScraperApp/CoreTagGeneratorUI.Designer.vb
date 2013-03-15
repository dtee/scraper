<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CoreTagGeneratorUI
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CoreTagGeneratorUI))
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.Button1 = New System.Windows.Forms.Button
      Me.SampleDataGridView = New System.Windows.Forms.DataGridView
      Me.HtmlRichTextBox = New System.Windows.Forms.RichTextBox
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.GeneratorToolStrip = New System.Windows.Forms.ToolStrip
      Me.UrlToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.DownloadToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator25 = New System.Windows.Forms.ToolStripSeparator
      Me.ChangeFieldsToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.CheckDataToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.GenerateToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.EndingBoundToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator26 = New System.Windows.Forms.ToolStripSeparator
      Me.ViewHtmlToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      CType(Me.SampleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GeneratorToolStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
      Me.SplitContainer1.Panel1.Controls.Add(Me.SampleDataGridView)
      Me.SplitContainer1.Panel1MinSize = 150
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.HtmlRichTextBox)
      Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
      Me.SplitContainer1.Size = New System.Drawing.Size(790, 425)
      Me.SplitContainer1.SplitterDistance = 193
      Me.SplitContainer1.TabIndex = 2
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(680, 131)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 1
      Me.Button1.Text = "Button1"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'SampleDataGridView
      '
      Me.SampleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.SampleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.SampleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SampleDataGridView.Location = New System.Drawing.Point(0, 0)
      Me.SampleDataGridView.Name = "SampleDataGridView"
      Me.SampleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.SampleDataGridView.Size = New System.Drawing.Size(790, 193)
      Me.SampleDataGridView.TabIndex = 0
      '
      'HtmlRichTextBox
      '
      Me.HtmlRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.HtmlRichTextBox.Location = New System.Drawing.Point(0, 0)
      Me.HtmlRichTextBox.Name = "HtmlRichTextBox"
      Me.HtmlRichTextBox.Size = New System.Drawing.Size(790, 228)
      Me.HtmlRichTextBox.TabIndex = 0
      Me.HtmlRichTextBox.Text = ""
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(790, 228)
      Me.DataGridView1.TabIndex = 0
      '
      'GeneratorToolStrip
      '
      Me.GeneratorToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UrlToolStripComboBox, Me.DownloadToolStripButton, Me.ToolStripSeparator25, Me.ChangeFieldsToolStripButton, Me.CheckDataToolStripButton, Me.GenerateToolStripButton, Me.EndingBoundToolStripButton, Me.ToolStripSeparator26, Me.ViewHtmlToolStripButton})
      Me.GeneratorToolStrip.Location = New System.Drawing.Point(0, 0)
      Me.GeneratorToolStrip.Name = "GeneratorToolStrip"
      Me.GeneratorToolStrip.Size = New System.Drawing.Size(790, 25)
      Me.GeneratorToolStrip.TabIndex = 1
      Me.GeneratorToolStrip.Text = "ToolStrip1"
      '
      'UrlToolStripComboBox
      '
      Me.UrlToolStripComboBox.Name = "UrlToolStripComboBox"
      Me.UrlToolStripComboBox.Size = New System.Drawing.Size(350, 25)
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
      'ToolStripSeparator25
      '
      Me.ToolStripSeparator25.Name = "ToolStripSeparator25"
      Me.ToolStripSeparator25.Size = New System.Drawing.Size(6, 25)
      '
      'ChangeFieldsToolStripButton
      '
      Me.ChangeFieldsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ChangeFieldsToolStripButton.Image = CType(resources.GetObject("ChangeFieldsToolStripButton.Image"), System.Drawing.Image)
      Me.ChangeFieldsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ChangeFieldsToolStripButton.Name = "ChangeFieldsToolStripButton"
      Me.ChangeFieldsToolStripButton.Size = New System.Drawing.Size(78, 22)
      Me.ChangeFieldsToolStripButton.Text = "Change Fields"
      '
      'CheckDataToolStripButton
      '
      Me.CheckDataToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.CheckDataToolStripButton.Image = CType(resources.GetObject("CheckDataToolStripButton.Image"), System.Drawing.Image)
      Me.CheckDataToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.CheckDataToolStripButton.Name = "CheckDataToolStripButton"
      Me.CheckDataToolStripButton.Size = New System.Drawing.Size(66, 22)
      Me.CheckDataToolStripButton.Text = "Check Data"
      Me.CheckDataToolStripButton.ToolTipText = "Check Data"
      '
      'GenerateToolStripButton
      '
      Me.GenerateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.GenerateToolStripButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
      Me.GenerateToolStripButton.Image = CType(resources.GetObject("GenerateToolStripButton.Image"), System.Drawing.Image)
      Me.GenerateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.GenerateToolStripButton.Name = "GenerateToolStripButton"
      Me.GenerateToolStripButton.Size = New System.Drawing.Size(64, 22)
      Me.GenerateToolStripButton.Text = "Generate"
      '
      'EndingBoundToolStripButton
      '
      Me.EndingBoundToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.EndingBoundToolStripButton.Image = CType(resources.GetObject("EndingBoundToolStripButton.Image"), System.Drawing.Image)
      Me.EndingBoundToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.EndingBoundToolStripButton.Name = "EndingBoundToolStripButton"
      Me.EndingBoundToolStripButton.Size = New System.Drawing.Size(60, 22)
      Me.EndingBoundToolStripButton.Text = "Fix Ending"
      '
      'ToolStripSeparator26
      '
      Me.ToolStripSeparator26.Name = "ToolStripSeparator26"
      Me.ToolStripSeparator26.Size = New System.Drawing.Size(6, 25)
      '
      'ViewHtmlToolStripButton
      '
      Me.ViewHtmlToolStripButton.Checked = True
      Me.ViewHtmlToolStripButton.CheckOnClick = True
      Me.ViewHtmlToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me.ViewHtmlToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ViewHtmlToolStripButton.Image = CType(resources.GetObject("ViewHtmlToolStripButton.Image"), System.Drawing.Image)
      Me.ViewHtmlToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ViewHtmlToolStripButton.Name = "ViewHtmlToolStripButton"
      Me.ViewHtmlToolStripButton.Size = New System.Drawing.Size(57, 22)
      Me.ViewHtmlToolStripButton.Text = "View Html"
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "Child.gif")
      Me.ImageList1.Images.SetKeyName(1, "ChildSave.gif")
      Me.ImageList1.Images.SetKeyName(2, "Parent.gif")
      Me.ImageList1.Images.SetKeyName(3, "ParentSave.gif")
      Me.ImageList1.Images.SetKeyName(4, "ParentChild.gif")
      Me.ImageList1.Images.SetKeyName(5, "ParentChildSave.gif")
      '
      'TagGeneratorUI
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(790, 450)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.GeneratorToolStrip)
      Me.Name = "TagGeneratorUI"
      Me.Text = "TagGeneratorUI"
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      CType(Me.SampleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GeneratorToolStrip.ResumeLayout(False)
      Me.GeneratorToolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents HtmlRichTextBox As System.Windows.Forms.RichTextBox
   Friend WithEvents SampleDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents GeneratorToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents UrlToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents DownloadToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator25 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ChangeFieldsToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents GenerateToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator26 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ViewHtmlToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents CheckDataToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents EndingBoundToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
