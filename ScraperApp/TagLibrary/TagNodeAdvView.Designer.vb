<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagNodeAdvView
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TagNodeAdvView))
      Me.txtTagStart = New System.Windows.Forms.TextBox
      Me.lblStart = New System.Windows.Forms.Label
      Me.txtTagEnd = New System.Windows.Forms.TextBox
      Me.lblStop = New System.Windows.Forms.Label
      Me.lblName = New System.Windows.Forms.Label
      Me.txtName = New System.Windows.Forms.TextBox
      Me.txtMaxChars = New System.Windows.Forms.TextBox
      Me.lblMaxChars = New System.Windows.Forms.Label
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
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
      Me.SharedTagToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.ToolStrip1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'txtTagStart
      '
      Me.txtTagStart.Location = New System.Drawing.Point(49, 28)
      Me.txtTagStart.MaxLength = 255
      Me.txtTagStart.Multiline = True
      Me.txtTagStart.Name = "txtTagStart"
      Me.txtTagStart.Size = New System.Drawing.Size(472, 32)
      Me.txtTagStart.TabIndex = 34
      '
      'lblStart
      '
      Me.lblStart.Location = New System.Drawing.Point(0, 31)
      Me.lblStart.Name = "lblStart"
      Me.lblStart.Size = New System.Drawing.Size(46, 17)
      Me.lblStart.TabIndex = 35
      Me.lblStart.Text = "Start"
      Me.lblStart.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'txtTagEnd
      '
      Me.txtTagEnd.Location = New System.Drawing.Point(49, 66)
      Me.txtTagEnd.MaxLength = 255
      Me.txtTagEnd.Multiline = True
      Me.txtTagEnd.Name = "txtTagEnd"
      Me.txtTagEnd.Size = New System.Drawing.Size(472, 32)
      Me.txtTagEnd.TabIndex = 36
      '
      'lblStop
      '
      Me.lblStop.Location = New System.Drawing.Point(0, 69)
      Me.lblStop.Name = "lblStop"
      Me.lblStop.Size = New System.Drawing.Size(46, 16)
      Me.lblStop.TabIndex = 37
      Me.lblStop.Text = "Stop"
      Me.lblStop.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'lblName
      '
      Me.lblName.Location = New System.Drawing.Point(0, 6)
      Me.lblName.Name = "lblName"
      Me.lblName.Size = New System.Drawing.Size(46, 16)
      Me.lblName.TabIndex = 50
      Me.lblName.Text = "Name"
      Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'txtName
      '
      Me.txtName.Location = New System.Drawing.Point(49, 3)
      Me.txtName.MaxLength = 25
      Me.txtName.Name = "txtName"
      Me.txtName.Size = New System.Drawing.Size(118, 20)
      Me.txtName.TabIndex = 49
      '
      'txtMaxChars
      '
      Me.txtMaxChars.Location = New System.Drawing.Point(211, 3)
      Me.txtMaxChars.Name = "txtMaxChars"
      Me.txtMaxChars.Size = New System.Drawing.Size(56, 20)
      Me.txtMaxChars.TabIndex = 51
      Me.txtMaxChars.Text = "255"
      '
      'lblMaxChars
      '
      Me.lblMaxChars.ImageAlign = System.Drawing.ContentAlignment.TopRight
      Me.lblMaxChars.Location = New System.Drawing.Point(173, 6)
      Me.lblMaxChars.Name = "lblMaxChars"
      Me.lblMaxChars.Size = New System.Drawing.Size(32, 16)
      Me.lblMaxChars.TabIndex = 52
      Me.lblMaxChars.Text = "Max"
      Me.lblMaxChars.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
      Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveTagToolStripButton, Me.OptionalToolStripButton, Me.RevSearchToolStripButton, Me.URLToolStripButton, Me.ToolStripSeparator1, Me.AppendStartStripButton, Me.StartRegexStripButton, Me.ToolStripSeparator3, Me.AppendEndStripButton, Me.EndRegexToolStripButton, Me.ToolStripSeparator2, Me.SingleRegexToolStripButton, Me.SharedTagToolStripButton})
      Me.ToolStrip1.Location = New System.Drawing.Point(270, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(282, 25)
      Me.ToolStrip1.TabIndex = 53
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'SaveTagToolStripButton
      '
      Me.SaveTagToolStripButton.CheckOnClick = True
      Me.SaveTagToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.SaveTagToolStripButton.Image = Global.ScraperApp.My.Resources.Resources.SaveTag
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
      Me.OptionalToolStripButton.Image = Global.ScraperApp.My.Resources.Resources._Optional
      Me.OptionalToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.OptionalToolStripButton.Name = "OptionalToolStripButton"
      Me.OptionalToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.OptionalToolStripButton.Text = "Optional"
      '
      'RevSearchToolStripButton
      '
      Me.RevSearchToolStripButton.CheckOnClick = True
      Me.RevSearchToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.RevSearchToolStripButton.Image = Global.ScraperApp.My.Resources.Resources.Reverse
      Me.RevSearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RevSearchToolStripButton.Name = "RevSearchToolStripButton"
      Me.RevSearchToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.RevSearchToolStripButton.Text = "Search Behind"
      '
      'URLToolStripButton
      '
      Me.URLToolStripButton.CheckOnClick = True
      Me.URLToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.URLToolStripButton.Image = Global.ScraperApp.My.Resources.Resources.Url
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
      Me.AppendStartStripButton.Image = Global.ScraperApp.My.Resources.Resources.AppendStart
      Me.AppendStartStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AppendStartStripButton.Name = "AppendStartStripButton"
      Me.AppendStartStripButton.Size = New System.Drawing.Size(23, 22)
      Me.AppendStartStripButton.Text = "Append Start Tag"
      '
      'StartRegexStripButton
      '
      Me.StartRegexStripButton.CheckOnClick = True
      Me.StartRegexStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.StartRegexStripButton.Image = Global.ScraperApp.My.Resources.Resources.RegexStart
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
      Me.AppendEndStripButton.Image = Global.ScraperApp.My.Resources.Resources.AppendEnd
      Me.AppendEndStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AppendEndStripButton.Name = "AppendEndStripButton"
      Me.AppendEndStripButton.Size = New System.Drawing.Size(23, 22)
      Me.AppendEndStripButton.Text = "ToolStripButton5"
      '
      'EndRegexToolStripButton
      '
      Me.EndRegexToolStripButton.CheckOnClick = True
      Me.EndRegexToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.EndRegexToolStripButton.Image = Global.ScraperApp.My.Resources.Resources.RegexEnd
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
      Me.SingleRegexToolStripButton.Image = Global.ScraperApp.My.Resources.Resources.Regex
      Me.SingleRegexToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SingleRegexToolStripButton.Name = "SingleRegexToolStripButton"
      Me.SingleRegexToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.SingleRegexToolStripButton.Text = "Single Regular Expression"
      '
      'SharedTagToolStripButton
      '
      Me.SharedTagToolStripButton.CheckOnClick = True
      Me.SharedTagToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me.SharedTagToolStripButton.Image = Global.ScraperApp.My.Resources.Resources.SharedTag
      Me.SharedTagToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SharedTagToolStripButton.Name = "SharedTagToolStripButton"
      Me.SharedTagToolStripButton.Size = New System.Drawing.Size(23, 22)
      Me.SharedTagToolStripButton.Text = "Shared Tag"
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
      'TagNodeAdvView
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.txtMaxChars)
      Me.Controls.Add(Me.lblMaxChars)
      Me.Controls.Add(Me.lblName)
      Me.Controls.Add(Me.txtName)
      Me.Controls.Add(Me.txtTagEnd)
      Me.Controls.Add(Me.lblStop)
      Me.Controls.Add(Me.txtTagStart)
      Me.Controls.Add(Me.lblStart)
      Me.Name = "TagNodeAdvView"
      Me.Size = New System.Drawing.Size(531, 104)
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
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
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
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
   Friend WithEvents SharedTagToolStripButton As System.Windows.Forms.ToolStripButton

End Class
