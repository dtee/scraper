<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataFieldUI
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
      Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
      Me.OK_Button = New System.Windows.Forms.Button
      Me.Cancel_Button = New System.Windows.Forms.Button
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MaxChars = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IsSaveData = New System.Windows.Forms.DataGridViewCheckBoxColumn
      Me.Label1 = New System.Windows.Forms.Label
      Me.TextBox1 = New System.Windows.Forms.TextBox
      Me.TableLayoutPanel1.SuspendLayout()
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'TableLayoutPanel1
      '
      Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TableLayoutPanel1.ColumnCount = 2
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
      Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
      Me.TableLayoutPanel1.Location = New System.Drawing.Point(320, 260)
      Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
      Me.TableLayoutPanel1.RowCount = 1
      Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
      Me.TableLayoutPanel1.TabIndex = 0
      '
      'OK_Button
      '
      Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.OK_Button.Location = New System.Drawing.Point(3, 3)
      Me.OK_Button.Name = "OK_Button"
      Me.OK_Button.Size = New System.Drawing.Size(67, 23)
      Me.OK_Button.TabIndex = 0
      Me.OK_Button.Text = "OK"
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
      Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
      Me.Cancel_Button.TabIndex = 1
      Me.Cancel_Button.Text = "Cancel"
      '
      'DataGridView1
      '
      DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue
      Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
      Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FieldName, Me.MaxChars, Me.IsSaveData})
      Me.DataGridView1.Location = New System.Drawing.Point(12, 32)
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.RowHeadersVisible = False
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(451, 222)
      Me.DataGridView1.TabIndex = 5
      '
      'FieldName
      '
      Me.FieldName.FillWeight = 75.0!
      Me.FieldName.HeaderText = "Field Name"
      Me.FieldName.Name = "FieldName"
      '
      'MaxChars
      '
      Me.MaxChars.FillWeight = 24.0!
      Me.MaxChars.HeaderText = "Max Chars"
      Me.MaxChars.MaxInputLength = 5
      Me.MaxChars.Name = "MaxChars"
      Me.MaxChars.ToolTipText = "Max Chars"
      '
      'IsSaveData
      '
      Me.IsSaveData.DataPropertyName = "IsSaveData"
      Me.IsSaveData.FillWeight = 1.0!
      Me.IsSaveData.HeaderText = ""
      Me.IsSaveData.MinimumWidth = 30
      Me.IsSaveData.Name = "IsSaveData"
      Me.IsSaveData.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.IsSaveData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      Me.IsSaveData.ToolTipText = "Is Save"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(12, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(71, 13)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Table Name: "
      '
      'TextBox1
      '
      Me.TextBox1.Location = New System.Drawing.Point(89, 6)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(177, 20)
      Me.TextBox1.TabIndex = 7
      '
      'DataFieldUI
      '
      Me.AcceptButton = Me.OK_Button
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(478, 301)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.TableLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "DataFieldUI"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Edit Data Field"
      Me.TableLayoutPanel1.ResumeLayout(False)
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents FieldName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MaxChars As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IsSaveData As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class
