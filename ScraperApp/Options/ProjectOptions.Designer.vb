<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectOptions
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
      Me.Label1 = New System.Windows.Forms.Label
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label3 = New System.Windows.Forms.Label
      Me.GroupBox1 = New System.Windows.Forms.GroupBox
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.TextBox2 = New System.Windows.Forms.TextBox
      Me.CheckBox1 = New System.Windows.Forms.CheckBox
      Me.GroupBox1.SuspendLayout()
      Me.TableLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label1.Location = New System.Drawing.Point(3, 0)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(85, 26)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Project Name:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label2.Location = New System.Drawing.Point(3, 26)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 26)
      Me.Label2.TabIndex = 1
      Me.Label2.Text = "Default Url"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Label3.Location = New System.Drawing.Point(3, 52)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(85, 29)
      Me.Label3.TabIndex = 2
      Me.Label3.Text = "IsSaveData"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
      Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
      Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(403, 100)
      Me.GroupBox1.TabIndex = 3
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Project Information"
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.92192!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.07809!))
      Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
      Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.TextBox1, 1, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.TextBox2, 1, 1)
      Me.TableLayoutPanel1.Controls.Add(Me.CheckBox1, 1, 2)
      Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 3
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(397, 81)
      Me.TableLayoutPanel1.TabIndex = 4
      '
      'TextBox1
      '
      Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TextBox1.Location = New System.Drawing.Point(94, 3)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(300, 20)
      Me.TextBox1.TabIndex = 3
      '
      'TextBox2
      '
      Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TextBox2.Location = New System.Drawing.Point(94, 29)
      Me.TextBox2.Name = "TextBox2"
      Me.TextBox2.Size = New System.Drawing.Size(300, 20)
      Me.TextBox2.TabIndex = 4
      '
      'CheckBox1
      '
      Me.CheckBox1.AutoSize = True
      Me.CheckBox1.Location = New System.Drawing.Point(94, 55)
      Me.CheckBox1.Name = "CheckBox1"
      Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
      Me.CheckBox1.TabIndex = 5
      Me.CheckBox1.Text = "CheckBox1"
      Me.CheckBox1.UseVisualStyleBackColor = True
      '
      'ProjectOptions
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.GroupBox1)
      Me.Name = "ProjectOptions"
      Me.Size = New System.Drawing.Size(403, 285)
      Me.GroupBox1.ResumeLayout(False)
      Me.TableLayoutPanel1.ResumeLayout(False)
      Me.TableLayoutPanel1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
