<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
      Me.ImportToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.RemoveToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.StartProjectToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.StopToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.CreateDataTableToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.ToolStrip1.SuspendLayout()
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(694, 364)
      Me.DataGridView1.TabIndex = 0
      '
      'ToolStrip1
      '
      Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportToolStripButton, Me.RemoveToolStripButton, Me.ToolStripSeparator1, Me.StartProjectToolStripButton, Me.StopToolStripButton, Me.ToolStripSeparator2, Me.CreateDataTableToolStripButton})
      Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
      Me.ToolStrip1.Name = "ToolStrip1"
      Me.ToolStrip1.Size = New System.Drawing.Size(694, 25)
      Me.ToolStrip1.TabIndex = 1
      Me.ToolStrip1.Text = "ToolStrip1"
      '
      'ImportToolStripButton
      '
      Me.ImportToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ImportToolStripButton.Image = CType(resources.GetObject("ImportToolStripButton.Image"), System.Drawing.Image)
      Me.ImportToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ImportToolStripButton.Name = "ImportToolStripButton"
      Me.ImportToolStripButton.Size = New System.Drawing.Size(43, 22)
      Me.ImportToolStripButton.Text = "Import"
      Me.ImportToolStripButton.ToolTipText = "Import New Project"
      '
      'RemoveToolStripButton
      '
      Me.RemoveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.RemoveToolStripButton.Image = CType(resources.GetObject("RemoveToolStripButton.Image"), System.Drawing.Image)
      Me.RemoveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.RemoveToolStripButton.Name = "RemoveToolStripButton"
      Me.RemoveToolStripButton.Size = New System.Drawing.Size(50, 22)
      Me.RemoveToolStripButton.Text = "Remove"
      Me.RemoveToolStripButton.ToolTipText = "Remove Selected Project"
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'StartProjectToolStripButton
      '
      Me.StartProjectToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.StartProjectToolStripButton.Image = CType(resources.GetObject("StartProjectToolStripButton.Image"), System.Drawing.Image)
      Me.StartProjectToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.StartProjectToolStripButton.Name = "StartProjectToolStripButton"
      Me.StartProjectToolStripButton.Size = New System.Drawing.Size(35, 22)
      Me.StartProjectToolStripButton.Text = "Start"
      Me.StartProjectToolStripButton.ToolTipText = "Start Project"
      '
      'StopToolStripButton
      '
      Me.StopToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.StopToolStripButton.Image = CType(resources.GetObject("StopToolStripButton.Image"), System.Drawing.Image)
      Me.StopToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.StopToolStripButton.Name = "StopToolStripButton"
      Me.StopToolStripButton.Size = New System.Drawing.Size(33, 22)
      Me.StopToolStripButton.Text = "Stop"
      Me.StopToolStripButton.ToolTipText = "Stop Selected Project"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'CreateDataTableToolStripButton
      '
      Me.CreateDataTableToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.CreateDataTableToolStripButton.Image = CType(resources.GetObject("CreateDataTableToolStripButton.Image"), System.Drawing.Image)
      Me.CreateDataTableToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.CreateDataTableToolStripButton.Name = "CreateDataTableToolStripButton"
      Me.CreateDataTableToolStripButton.Size = New System.Drawing.Size(60, 22)
      Me.CreateDataTableToolStripButton.Text = "Create DS"
      Me.CreateDataTableToolStripButton.ToolTipText = "Create Data Tables"
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 389)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(694, 22)
      Me.StatusStrip1.TabIndex = 2
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'ToolStripStatusLabel1
      '
      Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
      Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(111, 17)
      Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
      '
      'Timer1
      '
      '
      'Form1
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(694, 411)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.Controls.Add(Me.ToolStrip1)
      Me.Name = "Form1"
      Me.Text = "Form1"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ToolStrip1.ResumeLayout(False)
      Me.ToolStrip1.PerformLayout()
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents ImportToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents RemoveToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents StartProjectToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents StopToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents CreateDataTableToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
