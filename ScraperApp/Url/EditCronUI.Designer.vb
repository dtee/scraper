<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditCronUI
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
      Me.components = New System.ComponentModel.Container
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
      Me.NameTextBox = New System.Windows.Forms.TextBox
      Me.Label6 = New System.Windows.Forms.Label
      Me.Label5 = New System.Windows.Forms.Label
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.Label8 = New System.Windows.Forms.Label
      Me.MinuteTextBox = New System.Windows.Forms.TextBox
      Me.Label7 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.HourTextBox = New System.Windows.Forms.TextBox
      Me.DayTextBox = New System.Windows.Forms.TextBox
      Me.DayOfWeekTextBox = New System.Windows.Forms.TextBox
      Me.MonthTextBox = New System.Windows.Forms.TextBox
      Me.DurationTextBox = New System.Windows.Forms.TextBox
      Me.Cancel_Button = New System.Windows.Forms.Button
      Me.OK_Button = New System.Windows.Forms.Button
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.Test_Button = New System.Windows.Forms.Button
      Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.TableLayoutPanel1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TableLayoutPanel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.NameTextBox, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 4)
      Me.TableLayoutPanel1.Controls.Add(Me.MinuteTextBox, 1, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 6)
      Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 5)
      Me.TableLayoutPanel1.Controls.Add(Me.HourTextBox, 1, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.DayTextBox, 1, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.DayOfWeekTextBox, 1, 5)
      Me.TableLayoutPanel1.Controls.Add(Me.MonthTextBox, 1, 4)
      Me.TableLayoutPanel1.Controls.Add(Me.DurationTextBox, 1, 6)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 7
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(229, 181)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'NameTextBox
      '
      Me.NameTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorProvider1.SetIconAlignment(Me.NameTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
      Me.NameTextBox.Location = New System.Drawing.Point(123, 3)
      Me.NameTextBox.Name = "NameTextBox"
      Me.NameTextBox.Size = New System.Drawing.Size(103, 20)
      Me.NameTextBox.TabIndex = 20
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(3, 0)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(60, 13)
      Me.Label6.TabIndex = 19
      Me.Label6.Text = "Cron Name"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(3, 26)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(69, 13)
      Me.Label5.TabIndex = 5
      Me.Label5.Text = "Minute (0-59)"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(3, 52)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(60, 13)
      Me.Label4.TabIndex = 4
      Me.Label4.Text = "Hour (0-59)"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(3, 78)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(56, 13)
      Me.Label3.TabIndex = 3
      Me.Label3.Text = "Day (1-31)"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Location = New System.Drawing.Point(3, 104)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(67, 13)
      Me.Label8.TabIndex = 21
      Me.Label8.Text = "Month (1-12)"
      '
      'MinuteTextBox
      '
      Me.MinuteTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorProvider1.SetIconAlignment(Me.MinuteTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
      Me.MinuteTextBox.Location = New System.Drawing.Point(123, 29)
      Me.MinuteTextBox.Name = "MinuteTextBox"
      Me.MinuteTextBox.Size = New System.Drawing.Size(103, 20)
      Me.MinuteTextBox.TabIndex = 10
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(3, 156)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(93, 13)
      Me.Label7.TabIndex = 14
      Me.Label7.Text = "Duration (Minutes)"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(3, 130)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(96, 13)
      Me.Label2.TabIndex = 2
      Me.Label2.Text = "Day Of Week (0-6)"
      '
      'HourTextBox
      '
      Me.HourTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorProvider1.SetIconAlignment(Me.HourTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
      Me.HourTextBox.Location = New System.Drawing.Point(123, 55)
      Me.HourTextBox.Name = "HourTextBox"
      Me.HourTextBox.Size = New System.Drawing.Size(103, 20)
      Me.HourTextBox.TabIndex = 9
      '
      'DayTextBox
      '
      Me.DayTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorProvider1.SetIconAlignment(Me.DayTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
      Me.DayTextBox.Location = New System.Drawing.Point(123, 81)
      Me.DayTextBox.Name = "DayTextBox"
      Me.DayTextBox.Size = New System.Drawing.Size(103, 20)
      Me.DayTextBox.TabIndex = 8
      '
      'DayOfWeekTextBox
      '
      Me.DayOfWeekTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorProvider1.SetIconAlignment(Me.DayOfWeekTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
      Me.DayOfWeekTextBox.Location = New System.Drawing.Point(123, 133)
      Me.DayOfWeekTextBox.Name = "DayOfWeekTextBox"
      Me.DayOfWeekTextBox.Size = New System.Drawing.Size(103, 20)
      Me.DayOfWeekTextBox.TabIndex = 7
      '
      'MonthTextBox
      '
      Me.MonthTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorProvider1.SetIconAlignment(Me.MonthTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
      Me.MonthTextBox.Location = New System.Drawing.Point(123, 107)
      Me.MonthTextBox.Name = "MonthTextBox"
      Me.MonthTextBox.Size = New System.Drawing.Size(103, 20)
      Me.MonthTextBox.TabIndex = 22
      '
      'DurationTextBox
      '
      Me.DurationTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ErrorProvider1.SetIconAlignment(Me.DurationTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
      Me.DurationTextBox.Location = New System.Drawing.Point(123, 159)
      Me.DurationTextBox.Name = "DurationTextBox"
      Me.DurationTextBox.Size = New System.Drawing.Size(103, 20)
      Me.DurationTextBox.TabIndex = 15
      '
      'Cancel_Button
      '
      Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Cancel_Button.Location = New System.Drawing.Point(342, 202)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
      Me.Cancel_Button.TabIndex = 1
      Me.Cancel_Button.Text = "Cancel"
      Me.Cancel_Button.UseVisualStyleBackColor = True
      '
      'OK_Button
      '
      Me.OK_Button.Location = New System.Drawing.Point(261, 202)
      Me.OK_Button.Name = "OK_Button"
      Me.OK_Button.Size = New System.Drawing.Size(75, 23)
      Me.OK_Button.TabIndex = 2
      Me.OK_Button.Text = "OK"
      Me.OK_Button.UseVisualStyleBackColor = True
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'Test_Button
      '
      Me.Test_Button.Location = New System.Drawing.Point(12, 202)
      Me.Test_Button.Name = "Test_Button"
      Me.Test_Button.Size = New System.Drawing.Size(75, 23)
      Me.Test_Button.TabIndex = 3
      Me.Test_Button.Text = "Test"
      Me.Test_Button.UseVisualStyleBackColor = True
      '
      'TableLayoutPanel2
      '
      Me.TableLayoutPanel2.ColumnCount = 2
      Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.03922!))
      Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.96078!))
      Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel1, 0, 0)
      Me.TableLayoutPanel2.Controls.Add(Me.TextBox1, 1, 0)
      Me.TableLayoutPanel2.Location = New System.Drawing.Point(12, 9)
      Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
      Me.TableLayoutPanel2.RowCount = 1
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel2.Size = New System.Drawing.Size(405, 187)
      Me.TableLayoutPanel2.TabIndex = 4
      '
      'TextBox1
      '
      Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TextBox1.Location = New System.Drawing.Point(238, 3)
      Me.TextBox1.Multiline = True
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(164, 181)
      Me.TextBox1.TabIndex = 1
      '
      'EditCronUI
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(426, 231)
      Me.Controls.Add(Me.TableLayoutPanel2)
      Me.Controls.Add(Me.Test_Button)
      Me.Controls.Add(Me.OK_Button)
      Me.Controls.Add(Me.Cancel_Button)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EditCronUI"
      Me.ShowInTaskbar = False
      Me.Text = "Edit Cron"
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TableLayoutPanel2.ResumeLayout(False)
      Me.TableLayoutPanel2.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents DurationTextBox As System.Windows.Forms.TextBox
   Friend WithEvents MinuteTextBox As System.Windows.Forms.TextBox
   Friend WithEvents HourTextBox As System.Windows.Forms.TextBox
   Friend WithEvents DayTextBox As System.Windows.Forms.TextBox
   Friend WithEvents DayOfWeekTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents MonthTextBox As System.Windows.Forms.TextBox
   Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents Test_Button As System.Windows.Forms.Button
   Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
