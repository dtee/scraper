<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListBoxTest
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
      Me.TabControl1 = New System.Windows.Forms.TabControl
      Me.TabPage1 = New System.Windows.Forms.TabPage
      Me.TabPage2 = New System.Windows.Forms.TabPage
      Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.TestButtonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me.TabControl1.SuspendLayout()
      Me.ContextMenuStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TabControl1
      '
      Me.TabControl1.ContextMenuStrip = Me.ContextMenuStrip1
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 0)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(446, 366)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage1.Size = New System.Drawing.Size(438, 340)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "TabPage1"
      Me.TabPage1.UseVisualStyleBackColor = True
      '
      'TabPage2
      '
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage2.Size = New System.Drawing.Size(192, 74)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "TabPage2"
      Me.TabPage2.UseVisualStyleBackColor = True
      '
      'ContextMenuStrip1
      '
      Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TestButtonToolStripMenuItem})
      Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
      Me.ContextMenuStrip1.Size = New System.Drawing.Size(131, 26)
      '
      'TestButtonToolStripMenuItem
      '
      Me.TestButtonToolStripMenuItem.Name = "TestButtonToolStripMenuItem"
      Me.TestButtonToolStripMenuItem.Size = New System.Drawing.Size(130, 22)
      Me.TestButtonToolStripMenuItem.Text = "Test Button"
      '
      'ListBoxTest
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(446, 366)
      Me.Controls.Add(Me.TabControl1)
      Me.Name = "ListBoxTest"
      Me.Text = "ListBoxTest"
      Me.TabControl1.ResumeLayout(False)
      Me.ContextMenuStrip1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
   Friend WithEvents TestButtonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
End Class
