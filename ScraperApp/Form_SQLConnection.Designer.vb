<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SQLConnectionDialog
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
      Me.UserNameTextBox = New System.Windows.Forms.TextBox
      Me.PasswordTextBox = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.DataSourceTextBox = New System.Windows.Forms.TextBox
      Me.Label4 = New System.Windows.Forms.Label
      Me.ConnTypeComboBox = New System.Windows.Forms.ComboBox
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.OKButton = New System.Windows.Forms.Button
      Me.Cancel_Button = New System.Windows.Forms.Button
      Me.ConnectButton = New System.Windows.Forms.Button
      Me.Label5 = New System.Windows.Forms.Label
      Me.DatabaseTextBox = New System.Windows.Forms.TextBox
      Me.GroupBox1.SuspendLayout()
      Me.SuspendLayout()
      '
      'UserNameTextBox
      '
      Me.UserNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.UserNameTextBox.Location = New System.Drawing.Point(81, 13)
      Me.UserNameTextBox.Name = "UserNameTextBox"
      Me.UserNameTextBox.Size = New System.Drawing.Size(359, 20)
      Me.UserNameTextBox.TabIndex = 0
      '
      'PasswordTextBox
      '
      Me.PasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.PasswordTextBox.Location = New System.Drawing.Point(81, 39)
      Me.PasswordTextBox.Name = "PasswordTextBox"
      Me.PasswordTextBox.Size = New System.Drawing.Size(359, 20)
      Me.PasswordTextBox.TabIndex = 1
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(3, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(58, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Username:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(6, 42)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(53, 13)
      Me.Label2.TabIndex = 3
      Me.Label2.Text = "Password"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(12, 9)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(72, 13)
      Me.Label3.TabIndex = 4
      Me.Label3.Text = "Server Name:"
      '
      'DataSourceTextBox
      '
      Me.DataSourceTextBox.Location = New System.Drawing.Point(94, 6)
      Me.DataSourceTextBox.Name = "DataSourceTextBox"
      Me.DataSourceTextBox.Size = New System.Drawing.Size(364, 20)
      Me.DataSourceTextBox.TabIndex = 5
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(12, 34)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(75, 13)
      Me.Label4.TabIndex = 6
      Me.Label4.Text = "Authentication"
      '
      'ConnTypeComboBox
      '
      Me.ConnTypeComboBox.FormattingEnabled = True
      Me.ConnTypeComboBox.Items.AddRange(New Object() {"Windows", "SQL Server"})
      Me.ConnTypeComboBox.Location = New System.Drawing.Point(94, 31)
      Me.ConnTypeComboBox.Name = "ConnTypeComboBox"
      Me.ConnTypeComboBox.Size = New System.Drawing.Size(154, 21)
      Me.ConnTypeComboBox.TabIndex = 7
      Me.ConnTypeComboBox.Text = "Windows"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Controls.Add(Me.PasswordTextBox)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Controls.Add(Me.UserNameTextBox)
      Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(446, 67)
      Me.GroupBox1.TabIndex = 8
      Me.GroupBox1.TabStop = False
      '
      'OKButton
      '
      Me.OKButton.Location = New System.Drawing.Point(302, 131)
      Me.OKButton.Name = "OKButton"
      Me.OKButton.Size = New System.Drawing.Size(75, 23)
      Me.OKButton.TabIndex = 9
      Me.OKButton.Text = "OK"
      Me.OKButton.UseVisualStyleBackColor = True
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Location = New System.Drawing.Point(383, 131)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
      Me.Cancel_Button.TabIndex = 10
      Me.Cancel_Button.Text = "Cancel"
      Me.Cancel_Button.UseVisualStyleBackColor = True
      '
      'ConnectButton
      '
      Me.ConnectButton.Location = New System.Drawing.Point(12, 131)
      Me.ConnectButton.Name = "ConnectButton"
      Me.ConnectButton.Size = New System.Drawing.Size(75, 23)
      Me.ConnectButton.TabIndex = 11
      Me.ConnectButton.Text = "Connect"
      Me.ConnectButton.UseVisualStyleBackColor = True
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(255, 34)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(57, 13)
      Me.Label5.TabIndex = 12
      Me.Label5.Text = "Data Base"
      '
      'DatabaseTextBox
      '
      Me.DatabaseTextBox.Location = New System.Drawing.Point(318, 31)
      Me.DatabaseTextBox.Name = "DatabaseTextBox"
      Me.DatabaseTextBox.Size = New System.Drawing.Size(140, 20)
      Me.DatabaseTextBox.TabIndex = 13
      '
      'SQLConnectionDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(470, 160)
      Me.Controls.Add(Me.DatabaseTextBox)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.ConnectButton)
      Me.Controls.Add(Me.Cancel_Button)
      Me.Controls.Add(Me.OKButton)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.ConnTypeComboBox)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.DataSourceTextBox)
      Me.Controls.Add(Me.Label3)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SQLConnectionDialog"
      Me.Text = "Connection"
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents DataSourceTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents ConnTypeComboBox As System.Windows.Forms.ComboBox
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents OKButton As System.Windows.Forms.Button
   Friend WithEvents Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents ConnectButton As System.Windows.Forms.Button
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents DatabaseTextBox As System.Windows.Forms.TextBox
End Class
