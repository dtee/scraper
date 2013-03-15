<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrawlProjectInfoControl
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
      Me.gpProgress = New System.Windows.Forms.GroupBox
      Me.ProjectProgressBar = New System.Windows.Forms.ProgressBar
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
      Me.gpTransfer = New System.Windows.Forms.GroupBox
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
      Me.lblTotalUrl = New System.Windows.Forms.Label
      Me.lblTotalLeft = New System.Windows.Forms.Label
      Me.lblTotalFinished = New System.Windows.Forms.Label
      Me.Label8 = New System.Windows.Forms.Label
      Me.Label9 = New System.Windows.Forms.Label
      Me.Label13 = New System.Windows.Forms.Label
      Me.Label25 = New System.Windows.Forms.Label
      Me.Label15 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.lblTimeElasped = New System.Windows.Forms.Label
      Me.lblTotalDownloadedSize = New System.Windows.Forms.Label
      Me.lblStatus = New System.Windows.Forms.Label
      Me.Label10 = New System.Windows.Forms.Label
      Me.lblAverageSpeed = New System.Windows.Forms.Label
      Me.SettingGroupBox = New System.Windows.Forms.GroupBox
      Me.Label7 = New System.Windows.Forms.Label
      Me.WebTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.Label11 = New System.Windows.Forms.Label
      Me.Label5 = New System.Windows.Forms.Label
      Me.UserAgentTextBox = New System.Windows.Forms.TextBox
      Me.MaxUrlNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.Label6 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.UrlAssignTimeoutNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.Label4 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.IsSaveContentCheckBox = New System.Windows.Forms.CheckBox
      Me.ConnectionsNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.ThreadsNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.DownloadDelayNumericUpDown = New System.Windows.Forms.NumericUpDown
      Me.Label19 = New System.Windows.Forms.Label
      Me.Label20 = New System.Windows.Forms.Label
      Me.Label21 = New System.Windows.Forms.Label
      Me.ProjectNameTextBox = New System.Windows.Forms.TextBox
      Me.Label22 = New System.Windows.Forms.Label
      Me.CrawlerControl1 = New SharedUI.CrawlerControl
      Me.gpProgress.SuspendLayout()
      Me.TableLayoutPanel2.SuspendLayout()
      Me.gpTransfer.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.SettingGroupBox.SuspendLayout()
      CType(Me.WebTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.MaxUrlNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.UrlAssignTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ConnectionsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ThreadsNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DownloadDelayNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'gpProgress
      '
      Me.gpProgress.Controls.Add(Me.ProjectProgressBar)
      Me.gpProgress.Dock = System.Windows.Forms.DockStyle.Fill
      Me.gpProgress.Location = New System.Drawing.Point(3, 3)
      Me.gpProgress.Name = "gpProgress"
      Me.gpProgress.Size = New System.Drawing.Size(762, 56)
      Me.gpProgress.TabIndex = 7
      Me.gpProgress.TabStop = False
      Me.gpProgress.Text = "Progress:"
      '
      'ProjectProgressBar
      '
      Me.ProjectProgressBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ProjectProgressBar.Location = New System.Drawing.Point(16, 16)
      Me.ProjectProgressBar.Maximum = 10
      Me.ProjectProgressBar.Name = "ProjectProgressBar"
      Me.ProjectProgressBar.Size = New System.Drawing.Size(732, 32)
      Me.ProjectProgressBar.TabIndex = 1
      Me.ProjectProgressBar.Value = 8
      '
      'Timer1
      '
      '
      'TableLayoutPanel2
      '
      Me.TableLayoutPanel2.ColumnCount = 1
      Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel2.Controls.Add(Me.gpTransfer, 0, 1)
      Me.TableLayoutPanel2.Controls.Add(Me.gpProgress, 0, 0)
      Me.TableLayoutPanel2.Controls.Add(Me.CrawlerControl1, 0, 3)
      Me.TableLayoutPanel2.Controls.Add(Me.SettingGroupBox, 0, 2)
      Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
      Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
      Me.TableLayoutPanel2.RowCount = 4
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 89.0!))
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.TableLayoutPanel2.Size = New System.Drawing.Size(768, 366)
      Me.TableLayoutPanel2.TabIndex = 14
      '
      'gpTransfer
      '
      Me.gpTransfer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.gpTransfer.Controls.Add(Me.TableLayoutPanel1)
      Me.gpTransfer.Location = New System.Drawing.Point(3, 65)
      Me.gpTransfer.Name = "gpTransfer"
      Me.gpTransfer.Size = New System.Drawing.Size(762, 83)
      Me.gpTransfer.TabIndex = 8
      Me.gpTransfer.TabStop = False
      Me.gpTransfer.Text = "Transfer"
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
      Me.TableLayoutPanel1.ColumnCount = 4
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.lblTotalUrl, 3, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.lblTotalLeft, 3, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.lblTotalFinished, 3, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.Label13, 2, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.Label25, 0, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.Label3, 2, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.lblTimeElasped, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.lblTotalDownloadedSize, 1, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.lblStatus, 1, 3)
      Me.TableLayoutPanel1.Controls.Add(Me.Label10, 2, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.lblAverageSpeed, 1, 1)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 4
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(756, 64)
      Me.TableLayoutPanel1.TabIndex = 22
      '
      'lblTotalUrl
      '
      Me.lblTotalUrl.AutoSize = True
      Me.lblTotalUrl.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblTotalUrl.Location = New System.Drawing.Point(461, 0)
      Me.lblTotalUrl.Name = "lblTotalUrl"
      Me.lblTotalUrl.Size = New System.Drawing.Size(292, 16)
      Me.lblTotalUrl.TabIndex = 9
      Me.lblTotalUrl.Text = "20,000"
      Me.lblTotalUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTotalLeft
      '
      Me.lblTotalLeft.AutoSize = True
      Me.lblTotalLeft.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblTotalLeft.Location = New System.Drawing.Point(461, 16)
      Me.lblTotalLeft.Name = "lblTotalLeft"
      Me.lblTotalLeft.Size = New System.Drawing.Size(292, 16)
      Me.lblTotalLeft.TabIndex = 13
      Me.lblTotalLeft.Text = "10"
      Me.lblTotalLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTotalFinished
      '
      Me.lblTotalFinished.AutoSize = True
      Me.lblTotalFinished.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblTotalFinished.Location = New System.Drawing.Point(461, 32)
      Me.lblTotalFinished.Name = "lblTotalFinished"
      Me.lblTotalFinished.Size = New System.Drawing.Size(292, 16)
      Me.lblTotalFinished.TabIndex = 15
      Me.lblTotalFinished.Text = "10"
      Me.lblTotalFinished.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label8.Location = New System.Drawing.Point(3, 0)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(84, 16)
      Me.Label8.TabIndex = 0
      Me.Label8.Text = "Time Elapsed"
      Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label9.Location = New System.Drawing.Point(3, 16)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(84, 16)
      Me.Label9.TabIndex = 1
      Me.Label9.Text = "Average Speed"
      Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label13.Location = New System.Drawing.Point(390, 32)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(65, 16)
      Me.Label13.TabIndex = 14
      Me.Label13.Text = "Total Finished"
      Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label25.Location = New System.Drawing.Point(3, 32)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(84, 16)
      Me.Label25.TabIndex = 10
      Me.Label25.Text = "Downloaded"
      Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label15.Location = New System.Drawing.Point(3, 48)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(84, 16)
      Me.Label15.TabIndex = 5
      Me.Label15.Text = "Status"
      Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label3.Location = New System.Drawing.Point(390, 16)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(65, 16)
      Me.Label3.TabIndex = 12
      Me.Label3.Text = "Total Left"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTimeElasped
      '
      Me.lblTimeElasped.AutoSize = True
      Me.lblTimeElasped.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblTimeElasped.Location = New System.Drawing.Point(93, 0)
      Me.lblTimeElasped.Name = "lblTimeElasped"
      Me.lblTimeElasped.Size = New System.Drawing.Size(291, 16)
      Me.lblTimeElasped.TabIndex = 6
      Me.lblTimeElasped.Text = "00:00:00"
      Me.lblTimeElasped.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblTotalDownloadedSize
      '
      Me.lblTotalDownloadedSize.AutoSize = True
      Me.lblTotalDownloadedSize.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblTotalDownloadedSize.Location = New System.Drawing.Point(93, 32)
      Me.lblTotalDownloadedSize.Name = "lblTotalDownloadedSize"
      Me.lblTotalDownloadedSize.Size = New System.Drawing.Size(291, 16)
      Me.lblTotalDownloadedSize.TabIndex = 11
      Me.lblTotalDownloadedSize.Text = "20.89 MB"
      Me.lblTotalDownloadedSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblStatus.Location = New System.Drawing.Point(93, 48)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(291, 16)
      Me.lblStatus.TabIndex = 8
      Me.lblStatus.Text = "Connected"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label10.Location = New System.Drawing.Point(390, 0)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(65, 16)
      Me.Label10.TabIndex = 2
      Me.Label10.Text = "Total Url"
      Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblAverageSpeed
      '
      Me.lblAverageSpeed.AutoSize = True
      Me.lblAverageSpeed.Dock = System.Windows.Forms.DockStyle.Fill
      Me.lblAverageSpeed.Location = New System.Drawing.Point(93, 16)
      Me.lblAverageSpeed.Name = "lblAverageSpeed"
      Me.lblAverageSpeed.Size = New System.Drawing.Size(291, 16)
      Me.lblAverageSpeed.TabIndex = 7
      Me.lblAverageSpeed.Text = "150 MB/s"
      Me.lblAverageSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'SettingGroupBox
      '
      Me.SettingGroupBox.Controls.Add(Me.Label7)
      Me.SettingGroupBox.Controls.Add(Me.WebTimeoutNumericUpDown)
      Me.SettingGroupBox.Controls.Add(Me.Label11)
      Me.SettingGroupBox.Controls.Add(Me.Label5)
      Me.SettingGroupBox.Controls.Add(Me.UserAgentTextBox)
      Me.SettingGroupBox.Controls.Add(Me.MaxUrlNumericUpDown)
      Me.SettingGroupBox.Controls.Add(Me.Label6)
      Me.SettingGroupBox.Controls.Add(Me.Label2)
      Me.SettingGroupBox.Controls.Add(Me.UrlAssignTimeoutNumericUpDown)
      Me.SettingGroupBox.Controls.Add(Me.Label4)
      Me.SettingGroupBox.Controls.Add(Me.Label1)
      Me.SettingGroupBox.Controls.Add(Me.IsSaveContentCheckBox)
      Me.SettingGroupBox.Controls.Add(Me.ConnectionsNumericUpDown)
      Me.SettingGroupBox.Controls.Add(Me.ThreadsNumericUpDown)
      Me.SettingGroupBox.Controls.Add(Me.DownloadDelayNumericUpDown)
      Me.SettingGroupBox.Controls.Add(Me.Label19)
      Me.SettingGroupBox.Controls.Add(Me.Label20)
      Me.SettingGroupBox.Controls.Add(Me.Label21)
      Me.SettingGroupBox.Controls.Add(Me.ProjectNameTextBox)
      Me.SettingGroupBox.Controls.Add(Me.Label22)
      Me.SettingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SettingGroupBox.Location = New System.Drawing.Point(3, 154)
      Me.SettingGroupBox.Name = "SettingGroupBox"
      Me.SettingGroupBox.Size = New System.Drawing.Size(762, 91)
      Me.SettingGroupBox.TabIndex = 12
      Me.SettingGroupBox.TabStop = False
      Me.SettingGroupBox.Text = "Settings"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Location = New System.Drawing.Point(248, 69)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(49, 13)
      Me.Label7.TabIndex = 54
      Me.Label7.Text = "Seconds"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'WebTimeoutNumericUpDown
      '
      Me.WebTimeoutNumericUpDown.Increment = New Decimal(New Integer() {10, 0, 0, 0})
      Me.WebTimeoutNumericUpDown.Location = New System.Drawing.Point(178, 67)
      Me.WebTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
      Me.WebTimeoutNumericUpDown.Name = "WebTimeoutNumericUpDown"
      Me.WebTimeoutNumericUpDown.Size = New System.Drawing.Size(64, 20)
      Me.WebTimeoutNumericUpDown.TabIndex = 53
      Me.WebTimeoutNumericUpDown.ThousandsSeparator = True
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.Location = New System.Drawing.Point(127, 69)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(45, 13)
      Me.Label11.TabIndex = 52
      Me.Label11.Text = "Timeout"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Location = New System.Drawing.Point(323, 44)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(35, 13)
      Me.Label5.TabIndex = 51
      Me.Label5.Text = "Agent"
      '
      'UserAgentTextBox
      '
      Me.UserAgentTextBox.Location = New System.Drawing.Point(364, 44)
      Me.UserAgentTextBox.Multiline = True
      Me.UserAgentTextBox.Name = "UserAgentTextBox"
      Me.UserAgentTextBox.Size = New System.Drawing.Size(392, 43)
      Me.UserAgentTextBox.TabIndex = 50
      '
      'MaxUrlNumericUpDown
      '
      Me.MaxUrlNumericUpDown.Increment = New Decimal(New Integer() {10, 0, 0, 0})
      Me.MaxUrlNumericUpDown.Location = New System.Drawing.Point(364, 19)
      Me.MaxUrlNumericUpDown.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
      Me.MaxUrlNumericUpDown.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.MaxUrlNumericUpDown.Name = "MaxUrlNumericUpDown"
      Me.MaxUrlNumericUpDown.Size = New System.Drawing.Size(63, 20)
      Me.MaxUrlNumericUpDown.TabIndex = 49
      Me.MaxUrlNumericUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.Location = New System.Drawing.Point(312, 21)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(47, 13)
      Me.Label6.TabIndex = 48
      Me.Label6.Text = "Url Load"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(598, 21)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(44, 13)
      Me.Label2.TabIndex = 47
      Me.Label2.Text = "Minutes"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'UrlAssignTimeoutNumericUpDown
      '
      Me.UrlAssignTimeoutNumericUpDown.Enabled = False
      Me.UrlAssignTimeoutNumericUpDown.Increment = New Decimal(New Integer() {10, 0, 0, 0})
      Me.UrlAssignTimeoutNumericUpDown.Location = New System.Drawing.Point(528, 19)
      Me.UrlAssignTimeoutNumericUpDown.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
      Me.UrlAssignTimeoutNumericUpDown.Name = "UrlAssignTimeoutNumericUpDown"
      Me.UrlAssignTimeoutNumericUpDown.ReadOnly = True
      Me.UrlAssignTimeoutNumericUpDown.Size = New System.Drawing.Size(64, 20)
      Me.UrlAssignTimeoutNumericUpDown.TabIndex = 46
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(443, 21)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(79, 13)
      Me.Label4.TabIndex = 45
      Me.Label4.Text = "Assign Timeout"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(248, 44)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(49, 13)
      Me.Label1.TabIndex = 44
      Me.Label1.Text = "Seconds"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'IsSaveContentCheckBox
      '
      Me.IsSaveContentCheckBox.AutoSize = True
      Me.IsSaveContentCheckBox.Location = New System.Drawing.Point(657, 20)
      Me.IsSaveContentCheckBox.Name = "IsSaveContentCheckBox"
      Me.IsSaveContentCheckBox.Size = New System.Drawing.Size(91, 17)
      Me.IsSaveContentCheckBox.TabIndex = 43
      Me.IsSaveContentCheckBox.Text = "Save Content"
      Me.IsSaveContentCheckBox.UseVisualStyleBackColor = True
      '
      'ConnectionsNumericUpDown
      '
      Me.ConnectionsNumericUpDown.Location = New System.Drawing.Point(58, 67)
      Me.ConnectionsNumericUpDown.Maximum = New Decimal(New Integer() {6, 0, 0, 0})
      Me.ConnectionsNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.ConnectionsNumericUpDown.Name = "ConnectionsNumericUpDown"
      Me.ConnectionsNumericUpDown.Size = New System.Drawing.Size(63, 20)
      Me.ConnectionsNumericUpDown.TabIndex = 40
      Me.ConnectionsNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'ThreadsNumericUpDown
      '
      Me.ThreadsNumericUpDown.Location = New System.Drawing.Point(58, 42)
      Me.ThreadsNumericUpDown.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me.ThreadsNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.ThreadsNumericUpDown.Name = "ThreadsNumericUpDown"
      Me.ThreadsNumericUpDown.Size = New System.Drawing.Size(63, 20)
      Me.ThreadsNumericUpDown.TabIndex = 39
      Me.ThreadsNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'DownloadDelayNumericUpDown
      '
      Me.DownloadDelayNumericUpDown.Increment = New Decimal(New Integer() {10, 0, 0, 0})
      Me.DownloadDelayNumericUpDown.Location = New System.Drawing.Point(178, 42)
      Me.DownloadDelayNumericUpDown.Maximum = New Decimal(New Integer() {120, 0, 0, 0})
      Me.DownloadDelayNumericUpDown.Name = "DownloadDelayNumericUpDown"
      Me.DownloadDelayNumericUpDown.Size = New System.Drawing.Size(64, 20)
      Me.DownloadDelayNumericUpDown.TabIndex = 38
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.Location = New System.Drawing.Point(127, 44)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(34, 13)
      Me.Label19.TabIndex = 37
      Me.Label19.Text = "Delay"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.Location = New System.Drawing.Point(6, 69)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(32, 13)
      Me.Label20.TabIndex = 36
      Me.Label20.Text = "Conn"
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.Location = New System.Drawing.Point(6, 44)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(46, 13)
      Me.Label21.TabIndex = 35
      Me.Label21.Text = "Threads"
      '
      'ProjectNameTextBox
      '
      Me.ProjectNameTextBox.Location = New System.Drawing.Point(58, 18)
      Me.ProjectNameTextBox.Name = "ProjectNameTextBox"
      Me.ProjectNameTextBox.Size = New System.Drawing.Size(239, 20)
      Me.ProjectNameTextBox.TabIndex = 34
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Location = New System.Drawing.Point(6, 19)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(35, 13)
      Me.Label22.TabIndex = 33
      Me.Label22.Text = "Name"
      '
      'CrawlerControl1
      '
      Me.CrawlerControl1.Crawler = Nothing
      Me.CrawlerControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.CrawlerControl1.Location = New System.Drawing.Point(3, 251)
      Me.CrawlerControl1.Name = "CrawlerControl1"
      Me.CrawlerControl1.Size = New System.Drawing.Size(762, 112)
      Me.CrawlerControl1.TabIndex = 48
      '
      'CrawlProjectInfoControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.TableLayoutPanel2)
      Me.Name = "CrawlProjectInfoControl"
      Me.Size = New System.Drawing.Size(768, 366)
      Me.gpProgress.ResumeLayout(False)
      Me.TableLayoutPanel2.ResumeLayout(False)
      Me.gpTransfer.ResumeLayout(False)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      Me.SettingGroupBox.ResumeLayout(False)
      Me.SettingGroupBox.PerformLayout()
      CType(Me.WebTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.MaxUrlNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.UrlAssignTimeoutNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ConnectionsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ThreadsNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DownloadDelayNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents gpProgress As System.Windows.Forms.GroupBox
   Friend WithEvents ProjectProgressBar As System.Windows.Forms.ProgressBar
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents gpTransfer As System.Windows.Forms.GroupBox
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents lblTotalUrl As System.Windows.Forms.Label
   Friend WithEvents lblTotalLeft As System.Windows.Forms.Label
   Friend WithEvents lblTotalFinished As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lblTimeElasped As System.Windows.Forms.Label
   Friend WithEvents lblTotalDownloadedSize As System.Windows.Forms.Label
   Friend WithEvents lblStatus As System.Windows.Forms.Label
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents lblAverageSpeed As System.Windows.Forms.Label
   Friend WithEvents CrawlerControl1 As SharedUI.CrawlerControl
   Friend WithEvents SettingGroupBox As System.Windows.Forms.GroupBox
   Friend WithEvents MaxUrlNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents UrlAssignTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents IsSaveContentCheckBox As System.Windows.Forms.CheckBox
   Friend WithEvents ConnectionsNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents ThreadsNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents DownloadDelayNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents ProjectNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents UserAgentTextBox As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents WebTimeoutNumericUpDown As System.Windows.Forms.NumericUpDown
   Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
