<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectInfoEditForm
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
      Me.ConnectionsNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.ThreadsNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.DownloadDelayNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.ProjectNameTextBox = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
      Me.IntervalDay = New System.Windows.Forms.NumericUpDown
      Me.IntervalHour = New System.Windows.Forms.NumericUpDown
      Me.IntervalMinute = New System.Windows.Forms.NumericUpDown
      Me.Label6 = New System.Windows.Forms.Label
      Me.IsSaveContentCheckBox = New System.Windows.Forms.CheckBox
      Me.UserNameTextBox = New System.Windows.Forms.TextBox
      Me.Label5 = New System.Windows.Forms.Label
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.MaskPasswordCheckBox = New System.Windows.Forms.CheckBox
      Me.Label7 = New System.Windows.Forms.Label
      Me.PasswordTextBox = New System.Windows.Forms.TextBox
      Me.Button1 = New System.Windows.Forms.Button
      Me.TextBox4 = New System.Windows.Forms.TextBox
      Me.Label9 = New System.Windows.Forms.Label
      Me.TextBox3 = New System.Windows.Forms.TextBox
      Me.Label8 = New System.Windows.Forms.Label
      Me.GroupBox2 = New System.Windows.Forms.GroupBox
      Me.LogInButton = New System.Windows.Forms.Button
      Me.OK_Button = New System.Windows.Forms.Button
      Me.Cancel_Button = New System.Windows.Forms.Button
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
      Me.Adv_Botton = New System.Windows.Forms.Button
      CType(Me.ConnectionsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ThreadsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DownloadDelayNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.FlowLayoutPanel1.SuspendLayout()
      CType(Me.IntervalDay, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.IntervalHour, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.IntervalMinute, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'ConnectionsNumericUpDown
      '
      Me.ConnectionsNumericUpDown.Location = New System.Drawing.Point(385, 38)
      Me.ConnectionsNumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
      Me.ConnectionsNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.ConnectionsNumericUpDown.Name = "ConnectionsNumericUpDown"
      Me.ConnectionsNumericUpDown.Size = New System.Drawing.Size(81, 20)
      Me.ConnectionsNumericUpDown.TabIndex = 27
      Me.ConnectionsNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'ThreadsNumericUpDown
      '
      Me.ThreadsNumericUpDown.Location = New System.Drawing.Point(68, 38)
      Me.ThreadsNumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
      Me.ThreadsNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.ThreadsNumericUpDown.Name = "ThreadsNumericUpDown"
      Me.ThreadsNumericUpDown.Size = New System.Drawing.Size(54, 20)
      Me.ThreadsNumericUpDown.TabIndex = 26
      Me.ThreadsNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'DownloadDelayNumericUpDown
      '
      Me.DownloadDelayNumericUpDown.Increment = New Decimal(New Integer() {10, 0, 0, 0})
      Me.DownloadDelayNumericUpDown.Location = New System.Drawing.Point(219, 38)
      Me.DownloadDelayNumericUpDown.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
      Me.DownloadDelayNumericUpDown.Name = "DownloadDelayNumericUpDown"
      Me.DownloadDelayNumericUpDown.Size = New System.Drawing.Size(64, 20)
      Me.DownloadDelayNumericUpDown.TabIndex = 25
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(179, 40)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(34, 13)
      Me.Label4.TabIndex = 24
      Me.Label4.Text = "Delay"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(313, 40)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(66, 13)
      Me.Label3.TabIndex = 23
      Me.Label3.Text = "Connections"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(16, 40)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(46, 13)
      Me.Label2.TabIndex = 22
      Me.Label2.Text = "Threads"
      '
      'ProjectNameTextBox
      '
      Me.ProjectNameTextBox.Location = New System.Drawing.Point(68, 12)
      Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
      Me.ProjectNameTextBox.Size = New System.Drawing.Size(399, 20)
      Me.ProjectNameTextBox.TabIndex = 21
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(16, 15)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(35, 13)
      Me.Label1.TabIndex = 20
      Me.Label1.Text = "Name"
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Controls.Add(Me.IntervalDay)
      Me.FlowLayoutPanel1.Controls.Add(Me.IntervalHour)
      Me.FlowLayoutPanel1.Controls.Add(Me.IntervalMinute)
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(68, 65)
      Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(215, 27)
      Me.FlowLayoutPanel1.TabIndex = 30
      '
      'IntervalDay
      '
      Me.IntervalDay.Location = New System.Drawing.Point(3, 3)
      Me.IntervalDay.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
      Me.IntervalDay.Name = "IntervalDay"
      Me.IntervalDay.Size = New System.Drawing.Size(49, 20)
      Me.IntervalDay.TabIndex = 0
      '
      'IntervalHour
      '
      Me.IntervalHour.Location = New System.Drawing.Point(58, 3)
      Me.IntervalHour.Maximum = New Decimal(New Integer() {23, 0, 0, 0})
      Me.IntervalHour.Name = "IntervalHour"
      Me.IntervalHour.Size = New System.Drawing.Size(49, 20)
      Me.IntervalHour.TabIndex = 1
      '
      'IntervalMinute
      '
      Me.IntervalMinute.Location = New System.Drawing.Point(113, 3)
      Me.IntervalMinute.Maximum = New Decimal(New Integer() {59, 0, 0, 0})
      Me.IntervalMinute.Name = "IntervalMinute"
      Me.IntervalMinute.Size = New System.Drawing.Size(49, 20)
      Me.IntervalMinute.TabIndex = 2
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(16, 70)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(42, 13)
      Me.Label6.TabIndex = 31
      Me.Label6.Text = "Interval"
      Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'IsSaveContentCheckBox
      '
      Me.IsSaveContentCheckBox.AutoSize = True
      Me.IsSaveContentCheckBox.Location = New System.Drawing.Point(321, 65)
      Me.IsSaveContentCheckBox.Name = "IsSaveContentCheckBox"
      Me.IsSaveContentCheckBox.Size = New System.Drawing.Size(91, 17)
      Me.IsSaveContentCheckBox.TabIndex = 32
      Me.IsSaveContentCheckBox.Text = "Save Content"
      Me.IsSaveContentCheckBox.UseVisualStyleBackColor = True
      '
      'UserNameTextBox
      '
      Me.UserNameTextBox.Location = New System.Drawing.Point(72, 19)
      Me.UserNameTextBox.Name = "UserNameTextBox"
      Me.UserNameTextBox.Size = New System.Drawing.Size(139, 20)
      Me.UserNameTextBox.TabIndex = 33
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(11, 22)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(55, 13)
      Me.Label5.TabIndex = 34
      Me.Label5.Text = "Username"
      Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.MaskPasswordCheckBox)
      Me.GroupBox1.Controls.Add(Me.Label7)
      Me.GroupBox1.Controls.Add(Me.PasswordTextBox)
      Me.GroupBox1.Controls.Add(Me.Label5)
      Me.GroupBox1.Controls.Add(Me.UserNameTextBox)
      Me.GroupBox1.Location = New System.Drawing.Point(19, 103)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(448, 73)
      Me.GroupBox1.TabIndex = 35
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Authentication - Server"
      '
      'MaskPasswordCheckBox
      '
      Me.MaskPasswordCheckBox.AutoSize = True
      Me.MaskPasswordCheckBox.Location = New System.Drawing.Point(326, 22)
      Me.MaskPasswordCheckBox.Name = "MaskPasswordCheckBox"
      Me.MaskPasswordCheckBox.Size = New System.Drawing.Size(101, 17)
      Me.MaskPasswordCheckBox.TabIndex = 42
      Me.MaskPasswordCheckBox.Text = "Mask Password"
      Me.MaskPasswordCheckBox.UseVisualStyleBackColor = True
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(11, 48)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(53, 13)
      Me.Label7.TabIndex = 36
      Me.Label7.Text = "Password"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'PasswordTextBox
      '
      Me.PasswordTextBox.Location = New System.Drawing.Point(72, 45)
      Me.PasswordTextBox.Name = "PasswordTextBox"
      Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
      Me.PasswordTextBox.Size = New System.Drawing.Size(139, 20)
      Me.PasswordTextBox.TabIndex = 35
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(67, 71)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(91, 23)
      Me.Button1.TabIndex = 41
      Me.Button1.Text = "Edit Post Data"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'TextBox4
      '
      Me.TextBox4.Location = New System.Drawing.Point(67, 45)
      Me.TextBox4.Name = "TextBox4"
      Me.TextBox4.Size = New System.Drawing.Size(369, 20)
      Me.TextBox4.TabIndex = 40
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Location = New System.Drawing.Point(6, 48)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(54, 13)
      Me.Label9.TabIndex = 39
      Me.Label9.Text = "Post Data"
      '
      'TextBox3
      '
      Me.TextBox3.Location = New System.Drawing.Point(67, 19)
      Me.TextBox3.Name = "TextBox3"
      Me.TextBox3.Size = New System.Drawing.Size(369, 20)
      Me.TextBox3.TabIndex = 38
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(6, 22)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(20, 13)
      Me.Label8.TabIndex = 37
      Me.Label8.Text = "Url"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.LogInButton)
      Me.GroupBox2.Controls.Add(Me.TextBox3)
      Me.GroupBox2.Controls.Add(Me.Button1)
      Me.GroupBox2.Controls.Add(Me.Label8)
      Me.GroupBox2.Controls.Add(Me.TextBox4)
      Me.GroupBox2.Controls.Add(Me.Label9)
      Me.GroupBox2.Location = New System.Drawing.Point(19, 182)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(448, 100)
      Me.GroupBox2.TabIndex = 36
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Authentication - Web"
      '
      'LogInButton
      '
      Me.LogInButton.Location = New System.Drawing.Point(345, 71)
      Me.LogInButton.Name = "LogInButton"
      Me.LogInButton.Size = New System.Drawing.Size(91, 23)
      Me.LogInButton.TabIndex = 42
      Me.LogInButton.Text = "Log In Helper"
      Me.LogInButton.UseVisualStyleBackColor = True
      '
      'OK_Button
      '
      Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.OK_Button.Location = New System.Drawing.Point(76, 3)
      Me.OK_Button.Name = "OK_Button"
      Me.OK_Button.Size = New System.Drawing.Size(67, 23)
      Me.OK_Button.TabIndex = 0
      Me.OK_Button.Text = "OK"
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Cancel_Button.Location = New System.Drawing.Point(149, 3)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
      Me.Cancel_Button.TabIndex = 1
      Me.Cancel_Button.Text = "Cancel"
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TableLayoutPanel1.ColumnCount = 3
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.Controls.Add(Me.Adv_Botton, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 2, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 1, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(248, 290)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(220, 29)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'Adv_Botton
      '
      Me.Adv_Botton.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Adv_Botton.Location = New System.Drawing.Point(3, 3)
      Me.Adv_Botton.Name = "Adv_Botton"
      Me.Adv_Botton.Size = New System.Drawing.Size(67, 23)
      Me.Adv_Botton.TabIndex = 2
      Me.Adv_Botton.Text = "Advanced"
      '
      'ProjectInfoEditForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(480, 331)
      Me.Controls.Add(Me.GroupBox2)
      Me.Controls.Add(Me.GroupBox1)
      Me.Controls.Add(Me.IsSaveContentCheckBox)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.FlowLayoutPanel1)
      Me.Controls.Add(Me.ConnectionsNumericUpDown)
      Me.Controls.Add(Me.ThreadsNumericUpDown)
      Me.Controls.Add(Me.DownloadDelayNumericUpDown)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.ProjectNameTextBox)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ProjectInfoEditForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Edit Project Informaiton"
      CType(Me.ConnectionsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ThreadsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DownloadDelayNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me.FlowLayoutPanel1.ResumeLayout(False)
      CType(Me.IntervalDay, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.IntervalHour, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.IntervalMinute, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ConnectionsNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents ThreadsNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents DownloadDelayNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents ProjectNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
   Friend WithEvents IntervalDay As System.Windows.Forms.NumericUpDown
   Friend WithEvents IntervalHour As System.Windows.Forms.NumericUpDown
   Friend WithEvents IntervalMinute As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents IsSaveContentCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents UserNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents MaskPasswordCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Friend WithEvents LogInButton As System.Windows.Forms.Button
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents Adv_Botton As System.Windows.Forms.Button

End Class
