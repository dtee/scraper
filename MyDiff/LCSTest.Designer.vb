<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LCSTest
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
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.ClearButton = New System.Windows.Forms.Button
      Me.CompareButton = New System.Windows.Forms.Button
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
      Me.RichTextBox2 = New System.Windows.Forms.RichTextBox
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
      Me.Button1 = New System.Windows.Forms.Button
      Me.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.Button1)
      Me.Panel1.Controls.Add(Me.ClearButton)
      Me.Panel1.Controls.Add(Me.CompareButton)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(642, 30)
      Me.Panel1.TabIndex = 0
      '
      'ClearButton
      '
      Me.ClearButton.Location = New System.Drawing.Point(93, 4)
      Me.ClearButton.Name = "ClearButton"
      Me.ClearButton.Size = New System.Drawing.Size(75, 23)
      Me.ClearButton.TabIndex = 1
      Me.ClearButton.Text = "Clear"
      Me.ClearButton.UseVisualStyleBackColor = True
      '
      'CompareButton
      '
      Me.CompareButton.Location = New System.Drawing.Point(12, 3)
      Me.CompareButton.Name = "CompareButton"
      Me.CompareButton.Size = New System.Drawing.Size(75, 23)
      Me.CompareButton.TabIndex = 0
      Me.CompareButton.Text = "Compare"
      Me.CompareButton.UseVisualStyleBackColor = True
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 30)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.RichTextBox1)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox2)
      Me.SplitContainer1.Size = New System.Drawing.Size(642, 332)
      Me.SplitContainer1.SplitterDistance = 317
      Me.SplitContainer1.TabIndex = 1
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(317, 332)
      Me.RichTextBox1.TabIndex = 0
      Me.RichTextBox1.Text = ""
      '
      'RichTextBox2
      '
      Me.RichTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox2.Location = New System.Drawing.Point(0, 0)
      Me.RichTextBox2.Name = "RichTextBox2"
      Me.RichTextBox2.Size = New System.Drawing.Size(321, 332)
      Me.RichTextBox2.TabIndex = 0
      Me.RichTextBox2.Text = ""
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 362)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(642, 22)
      Me.StatusStrip1.TabIndex = 1
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(38, 17)
      Me.ToolStripStatusLabel1.Text = "Ready"
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(284, 4)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 2
      Me.Button1.Text = "Compare"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'LCSTest
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(642, 384)
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Name = "LCSTest"
      Me.Text = "Simple Diff"
      Me.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents CompareButton As System.Windows.Forms.Button
   Friend WithEvents ClearButton As System.Windows.Forms.Button
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
