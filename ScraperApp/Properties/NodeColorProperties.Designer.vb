<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NodeColorProperties
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
      Me.TreeView1 = New System.Windows.Forms.TreeView
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.SuspendLayout()
      '
      'TreeView1
      '
      Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TreeView1.Location = New System.Drawing.Point(0, 0)
      Me.TreeView1.Name = "TreeView1"
      Me.TreeView1.Size = New System.Drawing.Size(164, 382)
      Me.TreeView1.TabIndex = 0
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.TreeView1)
      Me.SplitContainer1.Size = New System.Drawing.Size(432, 382)
      Me.SplitContainer1.SplitterDistance = 164
      Me.SplitContainer1.TabIndex = 1
      '
      'NodeColorProperties
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.SplitContainer1)
      Me.Name = "NodeColorProperties"
      Me.Size = New System.Drawing.Size(432, 382)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog

End Class
