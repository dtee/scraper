<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataTypeControl
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
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.DataTypeListBox = New System.Windows.Forms.ListBox
      Me.DataTypeContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.DataTypeCodeRichTextBox = New System.Windows.Forms.TextBox
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.TestButton = New System.Windows.Forms.Button
      Me.Label1 = New System.Windows.Forms.Label
      Me.DataTypeNameTextBox = New System.Windows.Forms.TextBox
      Me.CompileButton = New System.Windows.Forms.Button
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.DataTypeContextMenuStrip.SuspendLayout()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.DataTypeListBox)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.DataTypeCodeRichTextBox)
      Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
      Me.SplitContainer1.Size = New System.Drawing.Size(729, 463)
      Me.SplitContainer1.SplitterDistance = 188
      Me.SplitContainer1.TabIndex = 1
      '
      'DataTypeListBox
      '
      Me.DataTypeListBox.ContextMenuStrip = Me.DataTypeContextMenuStrip
      Me.DataTypeListBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataTypeListBox.FormattingEnabled = True
      Me.DataTypeListBox.Location = New System.Drawing.Point(0, 0)
      Me.DataTypeListBox.Name = "DataTypeListBox"
      Me.DataTypeListBox.Size = New System.Drawing.Size(188, 459)
      Me.DataTypeListBox.TabIndex = 1
      '
      'DataTypeContextMenuStrip
      '
      Me.DataTypeContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.DeleteToolStripMenuItem})
      Me.DataTypeContextMenuStrip.Name = "DataTypeContextMenuStrip"
      Me.DataTypeContextMenuStrip.Size = New System.Drawing.Size(106, 48)
      '
      'NewToolStripMenuItem
      '
      Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
      Me.NewToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
      Me.NewToolStripMenuItem.Text = "New"
      '
      'DeleteToolStripMenuItem
      '
      Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
      Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
      Me.DeleteToolStripMenuItem.Text = "Delete"
      '
      'DataTypeCodeRichTextBox
      '
      Me.DataTypeCodeRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataTypeCodeRichTextBox.Location = New System.Drawing.Point(0, 32)
      Me.DataTypeCodeRichTextBox.Multiline = True
      Me.DataTypeCodeRichTextBox.Name = "DataTypeCodeRichTextBox"
      Me.DataTypeCodeRichTextBox.Size = New System.Drawing.Size(537, 431)
      Me.DataTypeCodeRichTextBox.TabIndex = 1
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.TestButton)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.DataTypeNameTextBox)
      Me.Panel1.Controls.Add(Me.CompileButton)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(537, 32)
      Me.Panel1.TabIndex = 0
      '
      'TestButton
      '
      Me.TestButton.Location = New System.Drawing.Point(333, 3)
      Me.TestButton.Name = "TestButton"
      Me.TestButton.Size = New System.Drawing.Size(75, 23)
      Me.TestButton.TabIndex = 3
      Me.TestButton.Text = "Test"
      Me.TestButton.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(3, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(35, 13)
      Me.Label1.TabIndex = 1
      Me.Label1.Text = "Name"
      '
      'DataTypeNameTextBox
      '
      Me.DataTypeNameTextBox.Location = New System.Drawing.Point(44, 5)
      Me.DataTypeNameTextBox.Name = "DataTypeNameTextBox"
      Me.DataTypeNameTextBox.Size = New System.Drawing.Size(202, 20)
      Me.DataTypeNameTextBox.TabIndex = 0
      '
      'CompileButton
      '
      Me.CompileButton.Location = New System.Drawing.Point(252, 3)
      Me.CompileButton.Name = "CompileButton"
      Me.CompileButton.Size = New System.Drawing.Size(75, 23)
      Me.CompileButton.TabIndex = 2
      Me.CompileButton.Text = "Compile"
      Me.CompileButton.UseVisualStyleBackColor = True
      '
      'DataTypeControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.SplitContainer1)
      Me.Name = "DataTypeControl"
      Me.Size = New System.Drawing.Size(729, 463)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.Panel2.PerformLayout()
      Me.SplitContainer1.ResumeLayout(False)
      Me.DataTypeContextMenuStrip.ResumeLayout(False)
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents DataTypeListBox As System.Windows.Forms.ListBox
   Friend WithEvents CompileButton As System.Windows.Forms.Button
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents DataTypeNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents DataTypeContextMenuStrip As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TestButton As System.Windows.Forms.Button
   Friend WithEvents DataTypeCodeRichTextBox As System.Windows.Forms.TextBox

End Class
