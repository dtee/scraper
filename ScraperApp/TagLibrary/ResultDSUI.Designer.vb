<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultDSUI
   Inherits Form

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
      Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
      Me.TotalRowToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
      Me.CrawledDataControl1 = New SharedUI.CrawledDataControl
      Me.StatusStrip1.SuspendLayout()
      Me.SuspendLayout()
      '
      'StatusStrip1
      '
      Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalRowToolStripStatusLabel})
      Me.StatusStrip1.Location = New System.Drawing.Point(0, 229)
      Me.StatusStrip1.Name = "StatusStrip1"
      Me.StatusStrip1.Size = New System.Drawing.Size(569, 22)
      Me.StatusStrip1.TabIndex = 10
      Me.StatusStrip1.Text = "StatusStrip1"
      '
      'TotalRowToolStripStatusLabel
      '
      Me.TotalRowToolStripStatusLabel.Name = "TotalRowToolStripStatusLabel"
      Me.TotalRowToolStripStatusLabel.Size = New System.Drawing.Size(67, 17)
      Me.TotalRowToolStripStatusLabel.Text = "Total Rows: "
      '
      'CrawledDataControl1
      '
      Me.CrawledDataControl1.DataSet = Nothing
      Me.CrawledDataControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.CrawledDataControl1.Location = New System.Drawing.Point(0, 0)
      Me.CrawledDataControl1.Name = "CrawledDataControl1"
      Me.CrawledDataControl1.Size = New System.Drawing.Size(569, 229)
      Me.CrawledDataControl1.TabIndex = 11
      '
      'ResultDSUI
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(569, 251)
      Me.Controls.Add(Me.CrawledDataControl1)
      Me.Controls.Add(Me.StatusStrip1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.Name = "ResultDSUI"
      Me.ShowInTaskbar = False
      Me.Text = "ShowDS"
      Me.StatusStrip1.ResumeLayout(False)
      Me.StatusStrip1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
   Friend WithEvents TotalRowToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
   Friend WithEvents CrawledDataControl1 As SharedUI.CrawledDataControl
End Class
