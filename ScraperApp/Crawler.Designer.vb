<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Crawler
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
      Me.UrlIDColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.UrlColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.SizeGottenColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.SizeToGoColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.PercentColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.StatusColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.ListView1 = New System.Windows.Forms.ListView
      Me.SuspendLayout()
      '
      'UrlIDColumnHeader
      '
      Me.UrlIDColumnHeader.Text = "ID"
      Me.UrlIDColumnHeader.Width = 32
      '
      'UrlColumnHeader
      '
      Me.UrlColumnHeader.Text = "URL"
      Me.UrlColumnHeader.Width = 374
      '
      'SizeGottenColumnHeader
      '
      Me.SizeGottenColumnHeader.Text = "Size"
      Me.SizeGottenColumnHeader.Width = 65
      '
      'SizeToGoColumnHeader
      '
      Me.SizeToGoColumnHeader.Text = "Download"
      Me.SizeToGoColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.SizeToGoColumnHeader.Width = 63
      '
      'PercentColumnHeader
      '
      Me.PercentColumnHeader.Text = "%"
      '
      'StatusColumnHeader
      '
      Me.StatusColumnHeader.Text = "Status"
      Me.StatusColumnHeader.Width = 132
      '
      'ListView1
      '
      Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.UrlIDColumnHeader, Me.UrlColumnHeader, Me.SizeGottenColumnHeader, Me.SizeToGoColumnHeader, Me.PercentColumnHeader, Me.StatusColumnHeader})
      Me.ListView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ListView1.FullRowSelect = True
      Me.ListView1.GridLines = True
      Me.ListView1.Location = New System.Drawing.Point(0, 0)
      Me.ListView1.Name = "ListView1"
      Me.ListView1.Size = New System.Drawing.Size(782, 389)
      Me.ListView1.TabIndex = 1
      Me.ListView1.UseCompatibleStateImageBehavior = False
      Me.ListView1.View = System.Windows.Forms.View.Details
      '
      'Crawler
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.ListView1)
      Me.Name = "Crawler"
      Me.Size = New System.Drawing.Size(782, 389)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents UrlIDColumnHeader As System.Windows.Forms.ColumnHeader
   Friend WithEvents UrlColumnHeader As System.Windows.Forms.ColumnHeader
   Friend WithEvents SizeGottenColumnHeader As System.Windows.Forms.ColumnHeader
   Friend WithEvents SizeToGoColumnHeader As System.Windows.Forms.ColumnHeader
   Friend WithEvents PercentColumnHeader As System.Windows.Forms.ColumnHeader
   Friend WithEvents StatusColumnHeader As System.Windows.Forms.ColumnHeader
   Friend WithEvents ListView1 As System.Windows.Forms.ListView

End Class
