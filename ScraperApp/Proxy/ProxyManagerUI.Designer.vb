<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProxyManagerUI
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProxyManagerUI))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.StatusToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
      Me.ProgressToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
      Me.ProxyListInfoToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.AddProxyToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.RemoveProxyToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ResetAllToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.ImportFileToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.CheckAllToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.StopCheckToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
      Me.RemoveErrorToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
      Me.TimeoutToolStripTextBox = New System.Windows.Forms.ToolStripTextBox
      Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
      Me.ThreadsToolStripTextBox = New System.Windows.Forms.ToolStripTextBox
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.ProxyContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ChangeStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ChangeContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ColumnsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ColumnsContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.FilterContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.AddProxyPanel = New System.Windows.Forms.Panel
      Me.PortTextBox = New System.Windows.Forms.TextBox
      Me.Label1 = New System.Windows.Forms.Label
      Me.ProxyTextBox = New System.Windows.Forms.TextBox
      Me.AddButton = New System.Windows.Forms.Button
      Me.StatusStrip1.SuspendLayout()
      Me.ToolStrip1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ProxyContextMenuStrip.SuspendLayout()
      Me.AddProxyPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusToolStripStatusLabel, Me.ProgressToolStripProgressBar, Me.ProxyListInfoToolStripStatusLabel})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 364)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(760, 22)
      Me.StatusStrip1.TabIndex = 0
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'StatusToolStripStatusLabel
      '
      Me.StatusToolStripStatusLabel.Name = "StatusToolStripStatusLabel"
      Me.StatusToolStripStatusLabel.Size = New System.Drawing.Size(38, 17)
      Me.StatusToolStripStatusLabel.Text = "Ready"
      '
      'ProgressToolStripProgressBar
      '
      Me.ProgressToolStripProgressBar.Name = "ProgressToolStripProgressBar"
      Me.ProgressToolStripProgressBar.Size = New System.Drawing.Size(100, 16)
      '
      'ProxyListInfoToolStripStatusLabel
      '
      Me.ProxyListInfoToolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.ProxyListInfoToolStripStatusLabel.Name = "ProxyListInfoToolStripStatusLabel"
      Me.ProxyListInfoToolStripStatusLabel.Size = New System.Drawing.Size(605, 17)
      Me.ProxyListInfoToolStripStatusLabel.Spring = True
      Me.ProxyListInfoToolStripStatusLabel.Text = "20/10/200 (Work/Error/Total)"
      Me.ProxyListInfoToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddProxyToolStripButton, Me.RemoveProxyToolStripButton, Me.ResetAllToolStripButton, Me.ToolStripSeparator1, Me.ImportFileToolStripButton, Me.ToolStripSeparator2, Me.CheckAllToolStripButton, Me.StopCheckToolStripButton, Me.ToolStripSeparator6, Me.RemoveErrorToolStripButton, Me.ToolStripSeparator3, Me.SaveToolStripButton, Me.ToolStripSeparator5, Me.ToolStripLabel1, Me.TimeoutToolStripTextBox, Me.ToolStripLabel2, Me.ThreadsToolStripTextBox})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(760, 25)
      Me.ToolStrip1.TabIndex = 1
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'AddProxyToolStripButton
      '
      Me.AddProxyToolStripButton.CheckOnClick = True
      Me.AddProxyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.AddProxyToolStripButton.Image = CType(resources.GetObject("AddProxyToolStripButton.Image"), System.Drawing.Image)
      Me.AddProxyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AddProxyToolStripButton.Name = "AddProxyToolStripButton"
      Me.AddProxyToolStripButton.Size = New System.Drawing.Size(74, 22)
      Me.AddProxyToolStripButton.Text = "Add Proxy(s)"
      '
      'RemoveProxyToolStripButton
      '
      Me.RemoveProxyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.RemoveProxyToolStripButton.Image = CType(resources.GetObject("RemoveProxyToolStripButton.Image"), System.Drawing.Image)
      Me.RemoveProxyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RemoveProxyToolStripButton.Name = "RemoveProxyToolStripButton"
      Me.RemoveProxyToolStripButton.Size = New System.Drawing.Size(50, 22)
      Me.RemoveProxyToolStripButton.Text = "Remove"
      Me.RemoveProxyToolStripButton.ToolTipText = "Remove Selected Proxy"
      '
      'ResetAllToolStripButton
      '
      Me.ResetAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ResetAllToolStripButton.Image = CType(resources.GetObject("ResetAllToolStripButton.Image"), System.Drawing.Image)
      Me.ResetAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ResetAllToolStripButton.Name = "ResetAllToolStripButton"
      Me.ResetAllToolStripButton.Size = New System.Drawing.Size(53, 22)
      Me.ResetAllToolStripButton.Text = "Reset All"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'ImportFileToolStripButton
      '
      Me.ImportFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ImportFileToolStripButton.Image = CType(resources.GetObject("ImportFileToolStripButton.Image"), System.Drawing.Image)
      Me.ImportFileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ImportFileToolStripButton.Name = "ImportFileToolStripButton"
      Me.ImportFileToolStripButton.Size = New System.Drawing.Size(62, 22)
      Me.ImportFileToolStripButton.Text = "Import File"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'CheckAllToolStripButton
      '
      Me.CheckAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.CheckAllToolStripButton.Image = CType(resources.GetObject("CheckAllToolStripButton.Image"), System.Drawing.Image)
      Me.CheckAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.CheckAllToolStripButton.Name = "CheckAllToolStripButton"
      Me.CheckAllToolStripButton.Size = New System.Drawing.Size(54, 22)
      Me.CheckAllToolStripButton.Text = "Check All"
      '
      'StopCheckToolStripButton
      '
      Me.StopCheckToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.StopCheckToolStripButton.Image = CType(resources.GetObject("StopCheckToolStripButton.Image"), System.Drawing.Image)
      Me.StopCheckToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.StopCheckToolStripButton.Name = "StopCheckToolStripButton"
      Me.StopCheckToolStripButton.Size = New System.Drawing.Size(47, 22)
      Me.StopCheckToolStripButton.Text = "Stop All"
      Me.StopCheckToolStripButton.ToolTipText = "Stop Checking All"
      '
      'ToolStripSeparator6
      '
      Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
      Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
      '
      'RemoveErrorToolStripButton
      '
      Me.RemoveErrorToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.RemoveErrorToolStripButton.Image = CType(resources.GetObject("RemoveErrorToolStripButton.Image"), System.Drawing.Image)
      Me.RemoveErrorToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RemoveErrorToolStripButton.Name = "RemoveErrorToolStripButton"
      Me.RemoveErrorToolStripButton.Size = New System.Drawing.Size(108, 22)
      Me.RemoveErrorToolStripButton.Text = "Remove Error Proxy"
      Me.RemoveErrorToolStripButton.ToolTipText = "Remove Error Proxy"
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      '
      'SaveToolStripButton
      '
      Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
      Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SaveToolStripButton.Name = "SaveToolStripButton"
      Me.SaveToolStripButton.Size = New System.Drawing.Size(35, 22)
      Me.SaveToolStripButton.Text = "Save"
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripLabel1
      '
      Me.ToolStripLabel1.Name = "ToolStripLabel1"
      Me.ToolStripLabel1.Size = New System.Drawing.Size(94, 22)
      Me.ToolStripLabel1.Text = "Timeout (second):"
      '
      'TimeoutToolStripTextBox
      '
      Me.TimeoutToolStripTextBox.MaxLength = 5
      Me.TimeoutToolStripTextBox.Name = "TimeoutToolStripTextBox"
      Me.TimeoutToolStripTextBox.Size = New System.Drawing.Size(40, 25)
      Me.TimeoutToolStripTextBox.Text = "30"
      '
      'ToolStripLabel2
      '
      Me.ToolStripLabel2.Name = "ToolStripLabel2"
      Me.ToolStripLabel2.Size = New System.Drawing.Size(46, 22)
      Me.ToolStripLabel2.Text = "Threads"
      '
      'ThreadsToolStripTextBox
      '
      Me.ThreadsToolStripTextBox.MaxLength = 3
      Me.ThreadsToolStripTextBox.Name = "ThreadsToolStripTextBox"
      Me.ThreadsToolStripTextBox.Size = New System.Drawing.Size(35, 25)
      Me.ThreadsToolStripTextBox.Text = "5"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.ContextMenuStrip = Me.ProxyContextMenuStrip
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 58)
      Me.DataGridView1.Name = "DataGridView1"
      DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(760, 306)
      Me.DataGridView1.TabIndex = 2
      '
      'ProxyContextMenuStrip
      '
      Me.ProxyContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem, Me.ChangeStatusToolStripMenuItem, Me.ColumnsToolStripMenuItem, Me.ToolStripSeparator4, Me.FilterToolStripMenuItem})
      Me.ProxyContextMenuStrip.Name = "ProxyContextMenuStrip"
      Me.ProxyContextMenuStrip.Size = New System.Drawing.Size(146, 98)
      '
      'DeleteToolStripMenuItem
      '
      Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
      Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.DeleteToolStripMenuItem.Text = "Delete"
      '
      'ChangeStatusToolStripMenuItem
      '
      Me.ChangeStatusToolStripMenuItem.DropDown = Me.ChangeContextMenuStrip
      Me.ChangeStatusToolStripMenuItem.Name = "ChangeStatusToolStripMenuItem"
      Me.ChangeStatusToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.ChangeStatusToolStripMenuItem.Text = "Change Status"
      '
      'ChangeContextMenuStrip
      '
      Me.ChangeContextMenuStrip.Name = "ChangeContextMenuStrip"
      Me.ChangeContextMenuStrip.OwnerItem = Me.ChangeStatusToolStripMenuItem
      Me.ChangeContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'ColumnsToolStripMenuItem
      '
      Me.ColumnsToolStripMenuItem.DropDown = Me.ColumnsContextMenuStrip
      Me.ColumnsToolStripMenuItem.Name = "ColumnsToolStripMenuItem"
      Me.ColumnsToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.ColumnsToolStripMenuItem.Text = "Columns"
      '
      'ColumnsContextMenuStrip
      '
      Me.ColumnsContextMenuStrip.Name = "ColumnsContextMenuStrip"
      Me.ColumnsContextMenuStrip.OwnerItem = Me.ColumnsToolStripMenuItem
      Me.ColumnsContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(142, 6)
      '
      'FilterToolStripMenuItem
      '
      Me.FilterToolStripMenuItem.DropDown = Me.FilterContextMenuStrip
      Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
      Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
      Me.FilterToolStripMenuItem.Text = "Filter"
      '
      'FilterContextMenuStrip
      '
      Me.FilterContextMenuStrip.Name = "FilterContextMenuStrip"
      Me.FilterContextMenuStrip.OwnerItem = Me.FilterToolStripMenuItem
      Me.FilterContextMenuStrip.Size = New System.Drawing.Size(61, 4)
      '
      'AddProxyPanel
      '
      Me.AddProxyPanel.Controls.Add(Me.PortTextBox)
      Me.AddProxyPanel.Controls.Add(Me.Label1)
      Me.AddProxyPanel.Controls.Add(Me.ProxyTextBox)
      Me.AddProxyPanel.Controls.Add(Me.AddButton)
      Me.AddProxyPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.AddProxyPanel.Location = New System.Drawing.Point(0, 25)
      Me.AddProxyPanel.Name = "AddProxyPanel"
      Me.AddProxyPanel.Size = New System.Drawing.Size(760, 33)
      Me.AddProxyPanel.TabIndex = 5
      '
      'PortTextBox
      '
      Me.PortTextBox.Location = New System.Drawing.Point(408, 5)
      Me.PortTextBox.Name = "PortTextBox"
      Me.PortTextBox.Size = New System.Drawing.Size(56, 20)
      Me.PortTextBox.TabIndex = 3
      Me.PortTextBox.Text = "80"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(33, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Proxy"
      '
      'ProxyTextBox
      '
      Me.ProxyTextBox.Location = New System.Drawing.Point(51, 4)
      Me.ProxyTextBox.Name = "ProxyTextBox"
      Me.ProxyTextBox.Size = New System.Drawing.Size(351, 20)
      Me.ProxyTextBox.TabIndex = 1
      '
      'AddButton
      '
      Me.AddButton.Location = New System.Drawing.Point(470, 3)
      Me.AddButton.Name = "AddButton"
      Me.AddButton.Size = New System.Drawing.Size(75, 23)
      Me.AddButton.TabIndex = 0
      Me.AddButton.Text = "Add"
      Me.AddButton.UseVisualStyleBackColor = True
      '
      'ProxyManagerUI
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(760, 386)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.AddProxyPanel)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Name = "ProxyManagerUI"
      Me.Text = "Proxy Management"
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ProxyContextMenuStrip.ResumeLayout(False)
      Me.AddProxyPanel.ResumeLayout(False)
      Me.AddProxyPanel.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents AddProxyToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents RemoveProxyToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ImportFileToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents CheckAllToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents StopCheckToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ProxyContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ChangeStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ColumnsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents StatusToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ProgressToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
   Friend WithEvents AddProxyPanel As System.Windows.Forms.Panel
   Friend WithEvents AddButton As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents ProxyTextBox As System.Windows.Forms.TextBox
   Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ProxyListInfoToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents PortTextBox As System.Windows.Forms.TextBox
   Friend WithEvents ColumnsContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents FilterContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ChangeContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents ResetAllToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents FilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents TimeoutToolStripTextBox As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ThreadsToolStripTextBox As System.Windows.Forms.ToolStripTextBox
   Friend WithEvents RemoveErrorToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
End Class
