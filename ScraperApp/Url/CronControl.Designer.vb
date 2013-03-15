<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CronControl
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CronControl))
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.ScheduleToolStrip = New System.Windows.Forms.ToolStrip
      Me.AddToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.EditToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.RemoveToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.MinuteCol = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.HourCol = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DayCol = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MonthTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DayOfWeekCol = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DurationCol = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ScheduleToolStrip.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ScheduleToolStrip
      '
      Me.ScheduleToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripButton, Me.EditToolStripButton, Me.RemoveToolStripButton})
      Me.ScheduleToolStrip.Location = New System.Drawing.Point(0, 0)
      Me.ScheduleToolStrip.Name = "ScheduleToolStrip"
      Me.ScheduleToolStrip.Size = New System.Drawing.Size(674, 25)
      Me.ScheduleToolStrip.TabIndex = 1
      Me.ScheduleToolStrip.Text = "ToolStrip1"
      '
      'AddToolStripButton
      '
      Me.AddToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.AddToolStripButton.Image = CType(resources.GetObject("AddToolStripButton.Image"), System.Drawing.Image)
      Me.AddToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.AddToolStripButton.Name = "AddToolStripButton"
      Me.AddToolStripButton.Size = New System.Drawing.Size(30, 22)
      Me.AddToolStripButton.Text = "Add"
      '
      'EditToolStripButton
      '
      Me.EditToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.EditToolStripButton.Image = CType(resources.GetObject("EditToolStripButton.Image"), System.Drawing.Image)
      Me.EditToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.EditToolStripButton.Name = "EditToolStripButton"
      Me.EditToolStripButton.Size = New System.Drawing.Size(29, 22)
      Me.EditToolStripButton.Text = "Edit"
      '
      'RemoveToolStripButton
      '
      Me.RemoveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.RemoveToolStripButton.Image = CType(resources.GetObject("RemoveToolStripButton.Image"), System.Drawing.Image)
      Me.RemoveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RemoveToolStripButton.Name = "RemoveToolStripButton"
      Me.RemoveToolStripButton.Size = New System.Drawing.Size(50, 22)
      Me.RemoveToolStripButton.Text = "Remove"
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      Me.DataGridView1.AllowUserToResizeRows = False
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MinuteCol, Me.HourCol, Me.DayCol, Me.MonthTextBoxColumn, Me.DayOfWeekCol, Me.DurationCol})
      DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
      DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
      DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
      DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
      DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
      Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
      Me.DataGridView1.RowHeadersVisible = False
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(674, 282)
      Me.DataGridView1.TabIndex = 2
      '
      'MinuteCol
      '
      Me.MinuteCol.HeaderText = "Minute"
      Me.MinuteCol.Name = "MinuteCol"
      Me.MinuteCol.ReadOnly = True
      '
      'HourCol
      '
      Me.HourCol.HeaderText = "Hour"
      Me.HourCol.Name = "HourCol"
      Me.HourCol.ReadOnly = True
      '
      'DayCol
      '
      Me.DayCol.HeaderText = "Day"
      Me.DayCol.Name = "DayCol"
      Me.DayCol.ReadOnly = True
      '
      'MonthTextBoxColumn
      '
      Me.MonthTextBoxColumn.HeaderText = "Month"
      Me.MonthTextBoxColumn.Name = "MonthTextBoxColumn"
      Me.MonthTextBoxColumn.ReadOnly = True
      '
      'DayOfWeekCol
      '
      Me.DayOfWeekCol.HeaderText = "Day Of Week"
      Me.DayOfWeekCol.Name = "DayOfWeekCol"
      Me.DayOfWeekCol.ReadOnly = True
      '
      'DurationCol
      '
      Me.DurationCol.HeaderText = "Duration"
      Me.DurationCol.Name = "DurationCol"
      Me.DurationCol.ReadOnly = True
      '
      'CronControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.ScheduleToolStrip)
      Me.Name = "CronControl"
      Me.Size = New System.Drawing.Size(674, 307)
      Me.ScheduleToolStrip.ResumeLayout(False)
      Me.ScheduleToolStrip.PerformLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents ScheduleToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents AddToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents EditToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents RemoveToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents MinuteCol As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents HourCol As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DayCol As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MonthTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DayOfWeekCol As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DurationCol As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
