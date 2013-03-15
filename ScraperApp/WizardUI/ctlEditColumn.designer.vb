<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlEditColumn
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtTableName = New System.Windows.Forms.TextBox
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MaxChars = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IsSaveData = New System.Windows.Forms.DataGridViewCheckBoxColumn
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ContextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(-2, 25)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(64, 13)
      Me.Label2.TabIndex = 7
      Me.Label2.Text = "Table Fields"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(-3, 3)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(65, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Table Name"
      '
      'txtTableName
      '
      Me.txtTableName.Location = New System.Drawing.Point(68, 0)
      Me.txtTableName.Name = "txtTableName"
      Me.txtTableName.ReadOnly = True
      Me.txtTableName.Size = New System.Drawing.Size(391, 20)
      Me.txtTableName.TabIndex = 5
      Me.txtTableName.Text = "Data"
      '
      'DataGridView1
      '
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FieldName, Me.MaxChars, Me.IsSaveData})
      Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
      Me.DataGridView1.Location = New System.Drawing.Point(0, 41)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(510, 209)
      Me.DataGridView1.TabIndex = 4
      '
      'FieldName
      '
      Me.FieldName.FillWeight = 75.0!
      Me.FieldName.HeaderText = "Field Name"
      Me.FieldName.Name = "FieldName"
      '
      'MaxChars
      '
      Me.MaxChars.FillWeight = 24.0!
      Me.MaxChars.HeaderText = "Max Chars"
      Me.MaxChars.MaxInputLength = 5
      Me.MaxChars.Name = "MaxChars"
      Me.MaxChars.ToolTipText = "Max Chars"
      '
      'IsSaveData
      '
      Me.IsSaveData.DataPropertyName = "IsSaveData"
      Me.IsSaveData.FillWeight = 1.0!
      Me.IsSaveData.HeaderText = ""
      Me.IsSaveData.MinimumWidth = 30
      Me.IsSaveData.Name = "IsSaveData"
      Me.IsSaveData.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.IsSaveData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.IsSaveData.ToolTipText = "Is Save"
      '
      'ContextMenuStrip1
      '
      Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem})
      Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
      Me.ContextMenuStrip1.Size = New System.Drawing.Size(125, 26)
      '
      'RemoveToolStripMenuItem
      '
      Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
      Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
      Me.RemoveToolStripMenuItem.Text = "Remove"
      '
      'ctlEditColumn
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtTableName)
      Me.Controls.Add(Me.DataGridView1)
      Me.Name = "ctlEditColumn"
      Me.Size = New System.Drawing.Size(510, 250)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ContextMenuStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents txtTableName As System.Windows.Forms.TextBox
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents FieldName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MaxChars As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IsSaveData As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents RemoveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
