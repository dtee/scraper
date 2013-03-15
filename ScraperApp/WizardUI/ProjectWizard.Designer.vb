<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectWizard
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
      Me.CtlWizard1 = New ScraperApp.ctlWizard
      Me.SuspendLayout()
      '
      'CtlWizard1
      '
      Me.CtlWizard1.CurrentIndex = 0
      Me.CtlWizard1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.CtlWizard1.FinishIndex = -1
      Me.CtlWizard1.Location = New System.Drawing.Point(0, 0)
      Me.CtlWizard1.Name = "CtlWizard1"
      Me.CtlWizard1.Size = New System.Drawing.Size(605, 357)
      Me.CtlWizard1.TabIndex = 0
      '
      'ProjectWizard
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(605, 357)
      Me.Controls.Add(Me.CtlWizard1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "ProjectWizard"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "ProjectWizard"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents CtlWizard1 As ScraperApp.ctlWizard
End Class
