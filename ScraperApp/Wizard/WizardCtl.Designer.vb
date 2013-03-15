<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WizardCtl
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
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.Label1 = New System.Windows.Forms.Label
      Me.TagTreeView1 = New SharedUI.TagTreeView
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.TagTreeView1)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.RichTextBox1)
      Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
      Me.SplitContainer1.Size = New System.Drawing.Size(593, 470)
      Me.SplitContainer1.SplitterDistance = 238
      Me.SplitContainer1.TabIndex = 0
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox1.Location = New System.Drawing.Point(0, 191)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(351, 279)
      Me.RichTextBox1.TabIndex = 0
      Me.RichTextBox1.Text = ""
      '
      'DataGridView1
      '
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.Size = New System.Drawing.Size(351, 191)
      Me.DataGridView1.TabIndex = 2
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(0, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(83, 25)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Label1"
      '
      'TagTreeView1
      '
      Me.TagTreeView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TagTreeView1.Location = New System.Drawing.Point(0, 0)
      Me.TagTreeView1.Name = "TagTreeView1"
      Me.TagTreeView1.SelectedNode = Nothing
      Me.TagTreeView1.Size = New System.Drawing.Size(238, 470)
      Me.TagTreeView1.TabIndex = 0
      Me.TagTreeView1.TagTree = Nothing
      Me.TagTreeView1.TempSelectedNode = Nothing
      '
      'WizardCtl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.Label1)
      Me.Name = "WizardCtl"
      Me.Size = New System.Drawing.Size(593, 495)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents TagTreeView1 As SharedUI.TagTreeView

End Class
