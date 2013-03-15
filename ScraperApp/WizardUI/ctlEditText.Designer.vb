<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlEditText
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
      Me.ComboBox1 = New System.Windows.Forms.ComboBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ComboBox1
      '
      Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ComboBox1.FormattingEnabled = True
      Me.ComboBox1.Location = New System.Drawing.Point(73, 3)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(447, 21)
      Me.ComboBox1.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(4, 7)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(63, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Select Data"
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox1.Location = New System.Drawing.Point(0, 27)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(523, 296)
      Me.RichTextBox1.TabIndex = 2
      Me.RichTextBox1.Text = ""
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.ComboBox1)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(523, 27)
      Me.Panel1.TabIndex = 3
      '
      'ctlEditText
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.RichTextBox1)
      Me.Controls.Add(Me.Panel1)
      Me.Name = "ctlEditText"
      Me.Size = New System.Drawing.Size(523, 323)
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents Panel1 As System.Windows.Forms.Panel

End Class
