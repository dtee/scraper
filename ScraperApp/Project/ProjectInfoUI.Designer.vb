<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectInfoUI
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
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
      Me.OK_Button = New System.Windows.Forms.Button
      Me.Cancel_Button = New System.Windows.Forms.Button
      Me.ProjectContentTextBox = New System.Windows.Forms.TextBox
      Me.ProjectNameTextBox = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.TableLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(277, 122)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'OK_Button
      '
      Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.OK_Button.Location = New System.Drawing.Point(3, 3)
      Me.OK_Button.Name = "OK_Button"
      Me.OK_Button.Size = New System.Drawing.Size(67, 23)
      Me.OK_Button.TabIndex = 0
      Me.OK_Button.Text = "OK"
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
      Me.Cancel_Button.TabIndex = 1
      Me.Cancel_Button.Text = "Cancel"
      '
      'ProjectContentTextBox
      '
      Me.ProjectContentTextBox.Location = New System.Drawing.Point(68, 32)
      Me.ProjectContentTextBox.MaxLength = 50
      Me.ProjectContentTextBox.Multiline = True
      Me.ProjectContentTextBox.Name = "ProjectContentTextBox"
      Me.ProjectContentTextBox.Size = New System.Drawing.Size(352, 80)
      Me.ProjectContentTextBox.TabIndex = 1
      '
      'ProjectNameTextBox
      '
      Me.ProjectNameTextBox.Location = New System.Drawing.Point(68, 6)
      Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
      Me.ProjectNameTextBox.Size = New System.Drawing.Size(352, 20)
      Me.ProjectNameTextBox.TabIndex = 2
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 35)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(50, 13)
      Me.Label1.TabIndex = 3
      Me.Label1.Text = "Content: "
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(12, 9)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Name:"
      '
      'ProjectInfoUI
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(435, 163)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.ProjectNameTextBox)
      Me.Controls.Add(Me.ProjectContentTextBox)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ProjectInfoUI"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Project Information"
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents ProjectContentTextBox As System.Windows.Forms.TextBox
   Friend WithEvents ProjectNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
