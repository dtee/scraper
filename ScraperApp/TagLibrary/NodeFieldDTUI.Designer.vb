<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NodeFieldDTUI
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.Data = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.AutoScrollToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.FullRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.ViewAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ContextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      Me.DataGridView1.AllowUserToResizeRows = False
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Data})
      Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(523, 270)
      Me.DataGridView1.TabIndex = 0
      '
      'Data
      '
      Me.Data.HeaderText = "Data"
      Me.Data.Name = "Data"
      '
      'ContextMenuStrip1
      '
      Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutoScrollToolStripMenuItem, Me.FullRowToolStripMenuItem, Me.ViewAllToolStripMenuItem})
      Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
      Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 92)
      '
      'AutoScrollToolStripMenuItem
      '
      Me.AutoScrollToolStripMenuItem.Checked = True
      Me.AutoScrollToolStripMenuItem.CheckOnClick = True
      Me.AutoScrollToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me.AutoScrollToolStripMenuItem.Name = "AutoScrollToolStripMenuItem"
      Me.AutoScrollToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.AutoScrollToolStripMenuItem.Text = "Auto Scroll"
      '
      'FullRowToolStripMenuItem
      '
      Me.FullRowToolStripMenuItem.Name = "FullRowToolStripMenuItem"
      Me.FullRowToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.FullRowToolStripMenuItem.Text = "Resize Row"
      Me.FullRowToolStripMenuItem.Visible = False
      '
      'ViewAllToolStripMenuItem
      '
      Me.ViewAllToolStripMenuItem.Checked = True
      Me.ViewAllToolStripMenuItem.CheckOnClick = True
      Me.ViewAllToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
      Me.ViewAllToolStripMenuItem.Name = "ViewAllToolStripMenuItem"
      Me.ViewAllToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
      Me.ViewAllToolStripMenuItem.Text = "View All"
      '
      'ScrapedFieldDTView
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(523, 270)
      Me.Controls.Add(Me.DataGridView1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.Name = "ScrapedFieldDTView"
      Me.Text = "ScrapedFieldDTView"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ContextMenuStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Data As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents AutoScrollToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents FullRowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents ViewAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
