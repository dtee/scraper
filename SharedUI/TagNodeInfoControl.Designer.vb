Imports System.Drawing

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagNodeInfoControl
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TagNodeInfoControl))
      Me.txtTagStart = New System.Windows.Forms.TextBox
      Me.lblStart = New System.Windows.Forms.Label
      Me.txtTagEnd = New System.Windows.Forms.TextBox
      Me.lblStop = New System.Windows.Forms.Label
      Me.lblName = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.txtMaxChars = New System.Windows.Forms.TextBox
      Me.lblMaxChars = New System.Windows.Forms.Label
      Me.TagInfoToolStrip = New System.Windows.Forms.ToolStrip
      Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
      Me.DataTypeToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.SaveTagToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.OptionalToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.RevSearchToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.URLToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.AppendStartStripButton = New System.Windows.Forms.ToolStripButton
      Me.StartRegexStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.AppendEndStripButton = New System.Windows.Forms.ToolStripButton
      Me.EndRegexToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.SingleRegexToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.TagInfoToolStrip.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtTagStart
      '
      Me.txtTagStart.Location = New System.Drawing.Point(56, 28)
      Me.txtTagStart.MaxLength = 255
      Me.txtTagStart.Multiline = True
      Me.txtTagStart.Name = "txtTagStart"
      Me.txtTagStart.Size = New System.Drawing.Size(438, 32)
      Me.txtTagStart.TabIndex = 34
      '
      'lblStart
      '
      Me.lblStart.Location = New System.Drawing.Point(4, 28)
      Me.lblStart.Name = "lblStart"
      Me.lblStart.Size = New System.Drawing.Size(46, 17)
      Me.lblStart.TabIndex = 35
      Me.lblStart.Text = "Start"
      Me.lblStart.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'txtTagEnd
      '
      Me.txtTagEnd.Location = New System.Drawing.Point(56, 66)
      Me.txtTagEnd.MaxLength = 255
      Me.txtTagEnd.Multiline = True
      Me.txtTagEnd.Name = "txtTagEnd"
      Me.txtTagEnd.Size = New System.Drawing.Size(438, 32)
      Me.txtTagEnd.TabIndex = 36
      '
      'lblStop
      '
      Me.lblStop.Location = New System.Drawing.Point(4, 66)
      Me.lblStop.Name = "lblStop"
      Me.lblStop.Size = New System.Drawing.Size(46, 16)
      Me.lblStop.TabIndex = 37
      Me.lblStop.Text = "Stop"
      Me.lblStop.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'lblName
      '
      Me.lblName.Location = New System.Drawing.Point(4, 8)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(46, 16)
      Me.lblName.TabIndex = 50
      Me.lblName.Text = "Name"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'txtName
      '
      Me.txtName.Location = New System.Drawing.Point(56, 5)
      Me.txtName.MaxLength = 25
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(108, 20)
      Me.txtName.TabIndex = 49
      '
      'txtMaxChars
      '
      Me.txtMaxChars.Location = New System.Drawing.Point(207, 5)
      Me.txtMaxChars.Name = "txtMaxChars"
      Me.txtMaxChars.Size = New System.Drawing.Size(56, 20)
      Me.txtMaxChars.TabIndex = 51
      Me.txtMaxChars.Text = "255"
      '
      'lblMaxChars
      '
      Me.lblMaxChars.ImageAlign = System.Drawing.ContentAlignment.TopRight
      Me.lblMaxChars.Location = New System.Drawing.Point(169, 8)
      Me.lblMaxChars.Name = "lblMaxChars"
      Me.lblMaxChars.Size = New System.Drawing.Size(32, 16)
      Me.lblMaxChars.TabIndex = 52
      Me.lblMaxChars.Text = "Max"
      Me.lblMaxChars.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'TagInfoToolStrip
      '
      Me.TagInfoToolStrip.Dock = System.Windows.Forms.DockStyle.None
      Me.TagInfoToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.TagInfoToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.DataTypeToolStripComboBox, Me.ToolStripSeparator4, Me.SaveTagToolStripButton, Me.OptionalToolStripButton, Me.RevSearchToolStripButton, Me.URLToolStripButton, Me.ToolStripSeparator1, Me.AppendStartStripButton, Me.StartRegexStripButton, Me.ToolStripSeparator3, Me.AppendEndStripButton, Me.EndRegexToolStripButton, Me.ToolStripSeparator2, Me.SingleRegexToolStripButton})
      Me.TagInfoToolStrip.Location = New System.Drawing.Point(266, 0)
      Me.TagInfoToolStrip.Name = "TagInfoToolStrip"
      Me.TagInfoToolStrip.Size = New System.Drawing.Size(228, 25)
      Me.TagInfoToolStrip.TabIndex = 53
      Me.TagInfoToolStrip.Text = "ToolStrip1"
      '
      'ToolStripLabel1
      '
      Me.ToolStripLabel1.Name = "ToolStripLabel1"
      Me.ToolStripLabel1.Size = New System.Drawing.Size(61, 22)
      Me.ToolStripLabel1.Text = "Data Type:"
      Me.ToolStripLabel1.Visible = False
      '
      'DataTypeToolStripComboBox
      '
      Me.DataTypeToolStripComboBox.Name = "DataTypeToolStripComboBox"
      Me.DataTypeToolStripComboBox.Size = New System.Drawing.Size(121, 25)
      Me.DataTypeToolStripComboBox.Visible = False
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
      Me.ToolStripSeparator4.Visible = False
      '
      'SaveTagToolStripButton
      '
      Me.SaveTagToolStripButton.CheckOnClick = True
      Me.SaveTagToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.SaveTagToolStripButton.Image = Global.SharedUI.My.Resources.Resources.SaveTag
      Me.SaveTagToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SaveTagToolStripButton.Name = "SaveTagToolStripButton"
      Me.SaveTagToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.SaveTagToolStripButton.Text = "Save Data"
      Me.SaveTagToolStripButton.ToolTipText = "Save Data"
      '
      'OptionalToolStripButton
      '
      Me.OptionalToolStripButton.CheckOnClick = True
      Me.OptionalToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.OptionalToolStripButton.Image = Global.SharedUI.My.Resources.Resources._Optional
      Me.OptionalToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.OptionalToolStripButton.Name = "OptionalToolStripButton"
      Me.OptionalToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.OptionalToolStripButton.Text = "Optional"
      '
      'RevSearchToolStripButton
      '
      Me.RevSearchToolStripButton.CheckOnClick = True
      Me.RevSearchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.RevSearchToolStripButton.Image = Global.SharedUI.My.Resources.Resources.Reverse
      Me.RevSearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RevSearchToolStripButton.Name = "RevSearchToolStripButton"
      Me.RevSearchToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.RevSearchToolStripButton.Text = "Search Behind"
      '
      'URLToolStripButton
      '
      Me.URLToolStripButton.CheckOnClick = True
      Me.URLToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.URLToolStripButton.Image = Global.SharedUI.My.Resources.Resources.Url
      Me.URLToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.URLToolStripButton.Name = "URLToolStripButton"
      Me.URLToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.URLToolStripButton.Text = "ToolStripButton1"
      Me.URLToolStripButton.ToolTipText = "URL"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'AppendStartStripButton
      '
      Me.AppendStartStripButton.CheckOnClick = True
      Me.AppendStartStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.AppendStartStripButton.Image = Global.SharedUI.My.Resources.Resources.AppendStart
      Me.AppendStartStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AppendStartStripButton.Name = "AppendStartStripButton"
      Me.AppendStartStripButton.Size = New System.Drawing.Size(23, 22)
      Me.AppendStartStripButton.Text = "Append Start Tag"
      '
      'StartRegexStripButton
      '
      Me.StartRegexStripButton.CheckOnClick = True
      Me.StartRegexStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.StartRegexStripButton.Image = Global.SharedUI.My.Resources.Resources.RegexStart
      Me.StartRegexStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.StartRegexStripButton.Name = "StartRegexStripButton"
      Me.StartRegexStripButton.Size = New System.Drawing.Size(23, 22)
      Me.StartRegexStripButton.Text = " Regular Expression Start Tag"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      '
      'AppendEndStripButton
      '
      Me.AppendEndStripButton.CheckOnClick = True
      Me.AppendEndStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.AppendEndStripButton.Image = Global.SharedUI.My.Resources.Resources.AppendEnd
      Me.AppendEndStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AppendEndStripButton.Name = "AppendEndStripButton"
      Me.AppendEndStripButton.Size = New System.Drawing.Size(23, 22)
      Me.AppendEndStripButton.Text = "ToolStripButton5"
      '
      'EndRegexToolStripButton
      '
      Me.EndRegexToolStripButton.CheckOnClick = True
      Me.EndRegexToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.EndRegexToolStripButton.Image = Global.SharedUI.My.Resources.Resources.RegexEnd
      Me.EndRegexToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.EndRegexToolStripButton.Name = "EndRegexToolStripButton"
      Me.EndRegexToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.EndRegexToolStripButton.Text = " Regular Expression End Tag"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'SingleRegexToolStripButton
      '
      Me.SingleRegexToolStripButton.CheckOnClick = True
      Me.SingleRegexToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.SingleRegexToolStripButton.Image = Global.SharedUI.My.Resources.Resources.Regex
      Me.SingleRegexToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SingleRegexToolStripButton.Name = "SingleRegexToolStripButton"
      Me.SingleRegexToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.SingleRegexToolStripButton.Text = "Single Regular Expression"
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "AppendEnd.png")
      Me.ImageList1.Images.SetKeyName(1, "AppendStart.png")
      Me.ImageList1.Images.SetKeyName(2, "Optional.png")
      Me.ImageList1.Images.SetKeyName(3, "Regex.png")
      Me.ImageList1.Images.SetKeyName(4, "RegexEnd.png")
      Me.ImageList1.Images.SetKeyName(5, "RegexStart.png")
      Me.ImageList1.Images.SetKeyName(6, "Reverse.png")
      Me.ImageList1.Images.SetKeyName(7, "SaveTag.png")
      Me.ImageList1.Images.SetKeyName(8, "Url.png")
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'TagNodeInfoControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.TagInfoToolStrip)
      Me.Controls.Add(Me.txtMaxChars)
      Me.Controls.Add(Me.lblMaxChars)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.txtTagEnd)
      Me.Controls.Add(Me.lblStop)
      Me.Controls.Add(Me.txtTagStart)
      Me.Controls.Add(Me.lblStart)
      Me.Name = "TagNodeInfoControl"
      Me.Size = New System.Drawing.Size(503, 105)
      Me.TagInfoToolStrip.ResumeLayout(False)
      Me.TagInfoToolStrip.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents txtTagStart As System.Windows.Forms.TextBox
   Friend WithEvents lblStart As System.Windows.Forms.Label
   Friend WithEvents txtTagEnd As System.Windows.Forms.TextBox
   Friend WithEvents lblStop As System.Windows.Forms.Label
   Friend WithEvents lblName As System.Windows.Forms.Label
   Friend WithEvents txtName As System.Windows.Forms.TextBox
   Friend WithEvents txtMaxChars As System.Windows.Forms.TextBox
   Friend WithEvents lblMaxChars As System.Windows.Forms.Label
   Friend WithEvents TagInfoToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents URLToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents SingleRegexToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents RevSearchToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents OptionalToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AppendStartStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents StartRegexStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents AppendEndStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents EndRegexToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SaveTagToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents DataTypeToolStripComboBox As System.Windows.Forms.ToolStripComboBox

End Class
