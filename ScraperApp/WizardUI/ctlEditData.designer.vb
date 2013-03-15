<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlEditData
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'DataGridView1
      '
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.Size = New System.Drawing.Size(459, 242)
      Me.DataGridView1.TabIndex = 7
      '
      'ctlEditData
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.DataGridView1)
      Me.Name = "ctlEditData"
      Me.Size = New System.Drawing.Size(459, 242)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView

End Class
