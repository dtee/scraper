<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
      Me.Button1 = New System.Windows.Forms.Button
      Me.WebBrowser1 = New System.Windows.Forms.WebBrowser
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.BackToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ForwardToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.UrlToolStripTextBox = New System.Windows.Forms.ToolStripTextBox
      Me.GoToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.SpyPostDataToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.TabControl1 = New System.Windows.Forms.TabControl
      Me.TabPage1 = New System.Windows.Forms.TabPage
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.TabPage2 = New System.Windows.Forms.TabPage
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.ToolStrip1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(3, 3)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 0
      Me.Button1.Text = "Test Cookie"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'WebBrowser1
      '
      Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.WebBrowser1.Location = New System.Drawing.Point(0, 25)
      Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
      Me.WebBrowser1.Name = "WebBrowser1"
      Me.WebBrowser1.Size = New System.Drawing.Size(724, 133)
      Me.WebBrowser1.TabIndex = 2
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 31)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.WebBrowser1)
      Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
      Me.SplitContainer1.Size = New System.Drawing.Size(724, 317)
      Me.SplitContainer1.SplitterDistance = 158
      Me.SplitContainer1.TabIndex = 4
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackToolStripButton, Me.ForwardToolStripButton, Me.ToolStripSeparator1, Me.UrlToolStripTextBox, Me.GoToolStripButton, Me.ToolStripSeparator2, Me.SpyPostDataToolStripButton})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(724, 25)
      Me.ToolStrip1.TabIndex = 3
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'BackToolStripButton
      '
      Me.BackToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.BackToolStripButton.Enabled = False
      Me.BackToolStripButton.Image = CType(resources.GetObject("BackToolStripButton.Image"), System.Drawing.Image)
      Me.BackToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.BackToolStripButton.Name = "BackToolStripButton"
      Me.BackToolStripButton.Size = New System.Drawing.Size(33, 22)
      Me.BackToolStripButton.Text = "Back"
      '
      'ForwardToolStripButton
      '
      Me.ForwardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ForwardToolStripButton.Enabled = False
      Me.ForwardToolStripButton.Image = CType(resources.GetObject("ForwardToolStripButton.Image"), System.Drawing.Image)
      Me.ForwardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ForwardToolStripButton.Name = "ForwardToolStripButton"
      Me.ForwardToolStripButton.Size = New System.Drawing.Size(51, 22)
      Me.ForwardToolStripButton.Text = "Forward"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'UrlToolStripTextBox
      '
      Me.UrlToolStripTextBox.Name = "UrlToolStripTextBox"
      Me.UrlToolStripTextBox.Size = New System.Drawing.Size(350, 25)
      Me.UrlToolStripTextBox.Text = "http://www.hongfire.com"
      '
      'GoToolStripButton
      '
      Me.GoToolStripButton.Image = CType(resources.GetObject("GoToolStripButton.Image"), System.Drawing.Image)
      Me.GoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.GoToolStripButton.Name = "GoToolStripButton"
      Me.GoToolStripButton.Size = New System.Drawing.Size(40, 22)
      Me.GoToolStripButton.Text = "Go"
      Me.GoToolStripButton.ToolTipText = "Go"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'SpyPostDataToolStripButton
      '
      Me.SpyPostDataToolStripButton.Checked = True
      Me.SpyPostDataToolStripButton.CheckOnClick = True
      Me.SpyPostDataToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked
      Me.SpyPostDataToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.SpyPostDataToolStripButton.Image = CType(resources.GetObject("SpyPostDataToolStripButton.Image"), System.Drawing.Image)
      Me.SpyPostDataToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SpyPostDataToolStripButton.Name = "SpyPostDataToolStripButton"
      Me.SpyPostDataToolStripButton.Size = New System.Drawing.Size(76, 22)
      Me.SpyPostDataToolStripButton.Text = "Spy PostData"
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 0)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(724, 155)
      Me.TabControl1.TabIndex = 2
      '
      'TabPage1
      '
      Me.TabPage1.Controls.Add(Me.DataGridView1)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(716, 129)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "TabPage1"
      Me.TabPage1.UseVisualStyleBackColor = True
      '
      'DataGridView1
      '
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.Size = New System.Drawing.Size(710, 123)
      Me.DataGridView1.TabIndex = 1
      '
      'TabPage2
      '
      Me.TabPage2.Controls.Add(Me.RichTextBox1)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage2.Size = New System.Drawing.Size(716, 129)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "TabPage2"
      Me.TabPage2.UseVisualStyleBackColor = True
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox1.Location = New System.Drawing.Point(3, 3)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(710, 123)
      Me.RichTextBox1.TabIndex = 0
      Me.RichTextBox1.Text = "vb_login_md5password:7f99bef877271bf7dd4aee74c0629e32" & Global.Microsoft.VisualBasic.ChrW(10) & "s:" & Global.Microsoft.VisualBasic.ChrW(10) & "do:login" & Global.Microsoft.VisualBasic.ChrW(10) & "vb_login_userna" & _
          "me:dkgamer" & Global.Microsoft.VisualBasic.ChrW(10) & "vb_login_password:" & Global.Microsoft.VisualBasic.ChrW(10) & "cookieuser:1"
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.Button1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(724, 31)
      Me.Panel1.TabIndex = 5
      '
      'Form2
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(724, 348)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.Panel1)
      Me.Name = "Form2"
      Me.Text = "Form2"
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.PerformLayout()
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents UrlToolStripTextBox As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents GoToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents BackToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ForwardToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SpyPostDataToolStripButton As System.Windows.Forms.ToolStripButton
End Class
