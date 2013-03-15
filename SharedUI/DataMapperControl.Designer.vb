<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataMapperControl
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataMapperControl))
      Me.DataMappingFieldGridView = New System.Windows.Forms.DataGridView
      Me.DataMappingFieldTagName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DataMappingFieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DataMappingFieldID = New System.Windows.Forms.DataGridViewCheckBoxColumn
      Me.DataMappingFieldChecksum = New System.Windows.Forms.DataGridViewCheckBoxColumn
      Me.DataMappingTableGridView = New System.Windows.Forms.DataGridView
      Me.DataMappingTableTagName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DataMappingTableTableName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.DataMappingToolStrip = New System.Windows.Forms.ToolStrip
      Me.GenerateAllToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.GenerateToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      CType(Me.DataMappingFieldGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.DataMappingTableGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.DataMappingToolStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      'DataMappingFieldGridView
      '
      Me.DataMappingFieldGridView.AllowUserToAddRows = False
      Me.DataMappingFieldGridView.AllowUserToDeleteRows = False
      Me.DataMappingFieldGridView.AllowUserToResizeRows = False
      Me.DataMappingFieldGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataMappingFieldGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataMappingFieldGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataMappingFieldTagName, Me.DataMappingFieldName, Me.DataMappingFieldID, Me.DataMappingFieldChecksum})
      Me.DataMappingFieldGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataMappingFieldGridView.Location = New System.Drawing.Point(0, 0)
      Me.DataMappingFieldGridView.Name = "DataMappingFieldGridView"
      Me.DataMappingFieldGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataMappingFieldGridView.Size = New System.Drawing.Size(580, 175)
      Me.DataMappingFieldGridView.TabIndex = 8
      '
      'DataMappingFieldTagName
      '
      Me.DataMappingFieldTagName.HeaderText = "Tag Name"
      Me.DataMappingFieldTagName.Name = "DataMappingFieldTagName"
      Me.DataMappingFieldTagName.ReadOnly = True
      '
      'DataMappingFieldName
      '
      Me.DataMappingFieldName.HeaderText = "Field Name"
      Me.DataMappingFieldName.Name = "DataMappingFieldName"
      '
      'DataMappingFieldID
      '
      Me.DataMappingFieldID.FillWeight = 20.0!
      Me.DataMappingFieldID.HeaderText = "ID"
      Me.DataMappingFieldID.Name = "DataMappingFieldID"
      '
      'DataMappingFieldChecksum
      '
      Me.DataMappingFieldChecksum.FillWeight = 20.0!
      Me.DataMappingFieldChecksum.HeaderText = "CS"
      Me.DataMappingFieldChecksum.Name = "DataMappingFieldChecksum"
      '
      'DataMappingTableGridView
      '
      Me.DataMappingTableGridView.AllowUserToAddRows = False
      Me.DataMappingTableGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataMappingTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataMappingTableGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataMappingTableTagName, Me.DataMappingTableTableName})
      Me.DataMappingTableGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataMappingTableGridView.Location = New System.Drawing.Point(0, 0)
      Me.DataMappingTableGridView.Name = "DataMappingTableGridView"
      Me.DataMappingTableGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataMappingTableGridView.Size = New System.Drawing.Size(580, 156)
      Me.DataMappingTableGridView.TabIndex = 10
      '
      'DataMappingTableTagName
      '
      Me.DataMappingTableTagName.HeaderText = "Tag Name"
      Me.DataMappingTableTagName.Name = "DataMappingTableTagName"
      Me.DataMappingTableTagName.ReadOnly = True
      '
      'DataMappingTableTableName
      '
      Me.DataMappingTableTableName.HeaderText = "Table Name"
      Me.DataMappingTableTableName.Name = "DataMappingTableTableName"
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.DataMappingTableGridView)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.DataMappingFieldGridView)
      Me.SplitContainer1.Size = New System.Drawing.Size(580, 335)
      Me.SplitContainer1.SplitterDistance = 156
      Me.SplitContainer1.TabIndex = 11
      '
      'DataMappingToolStrip
      '
      Me.DataMappingToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerateToolStripButton, Me.ToolStripSeparator1, Me.GenerateAllToolStripButton})
      Me.DataMappingToolStrip.Location = New System.Drawing.Point(0, 0)
      Me.DataMappingToolStrip.Name = "DataMappingToolStrip"
      Me.DataMappingToolStrip.Size = New System.Drawing.Size(580, 25)
      Me.DataMappingToolStrip.TabIndex = 12
      Me.DataMappingToolStrip.Text = "ToolStrip2"
      '
      'GenerateAllToolStripButton
      '
      Me.GenerateAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.GenerateAllToolStripButton.Image = CType(resources.GetObject("GenerateAllToolStripButton.Image"), System.Drawing.Image)
      Me.GenerateAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.GenerateAllToolStripButton.Name = "GenerateAllToolStripButton"
      Me.GenerateAllToolStripButton.Size = New System.Drawing.Size(113, 22)
      Me.GenerateAllToolStripButton.Text = "Generate All Mapping"
      '
      'GenerateToolStripButton
      '
      Me.GenerateToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.GenerateToolStripButton.Image = CType(resources.GetObject("GenerateToolStripButton.Image"), System.Drawing.Image)
      Me.GenerateToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.GenerateToolStripButton.Name = "GenerateToolStripButton"
      Me.GenerateToolStripButton.Size = New System.Drawing.Size(100, 22)
      Me.GenerateToolStripButton.Text = "Generate Selected"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'DataMapperControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.DataMappingToolStrip)
      Me.Name = "DataMapperControl"
      Me.Size = New System.Drawing.Size(580, 360)
      CType(Me.DataMappingFieldGridView, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.DataMappingTableGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.DataMappingToolStrip.ResumeLayout(False)
      Me.DataMappingToolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataMappingFieldGridView As System.Windows.Forms.DataGridView
   Friend WithEvents DataMappingTableGridView As System.Windows.Forms.DataGridView
   Friend WithEvents DataMappingTableTagName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataMappingTableTableName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents DataMappingFieldTagName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataMappingFieldName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DataMappingFieldID As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents DataMappingFieldChecksum As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents DataMappingToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents GenerateToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents GenerateAllToolStripButton As System.Windows.Forms.ToolStripButton

End Class
