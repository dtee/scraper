<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Progress
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
      Me.Cancel_Button = New System.Windows.Forms.Button
      Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
      Me.Label1 = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Cancel_Button.Location = New System.Drawing.Point(270, 57)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
      Me.Cancel_Button.TabIndex = 1
      Me.Cancel_Button.Text = "Cancel"
      '
      'ProgressBar1
      '
      Me.ProgressBar1.Location = New System.Drawing.Point(12, 25)
      Me.ProgressBar1.Name = "ProgressBar1"
      Me.ProgressBar1.Size = New System.Drawing.Size(325, 26)
      Me.ProgressBar1.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(9, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(84, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Generating Url..."
      '
      'Progress
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(349, 88)
      Me.ControlBox = False
      Me.Controls.Add(Me.Cancel_Button)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.ProgressBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "Progress"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Progress"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
   Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
