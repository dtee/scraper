<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrawlProjectManagerUI
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
      Me.DataGridView1 = New System.Windows.Forms.DataGridView
      Me.ProjectName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DateAdded = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.DateRun = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.Button2 = New System.Windows.Forms.Button
      Me.SelectButton = New System.Windows.Forms.Button
      Me.CreateTableButton = New System.Windows.Forms.Button
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'DataGridView1
      '
      Me.DataGridView1.AllowUserToAddRows = False
      Me.DataGridView1.AllowUserToDeleteRows = False
      Me.DataGridView1.AllowUserToResizeColumns = False
      Me.DataGridView1.AllowUserToResizeRows = False
      Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProjectName, Me.DateAdded, Me.DateRun})
      Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
      Me.DataGridView1.MultiSelect = False
      Me.DataGridView1.Name = "DataGridView1"
      Me.DataGridView1.ReadOnly = True
      Me.DataGridView1.RowHeadersVisible = False
      Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.DataGridView1.Size = New System.Drawing.Size(576, 320)
      Me.DataGridView1.TabIndex = 2
      '
      'ProjectName
      '
      Me.ProjectName.FillWeight = 60.0!
      Me.ProjectName.HeaderText = "Project Name"
      Me.ProjectName.Name = "ProjectName"
      Me.ProjectName.ReadOnly = True
      '
      'DateAdded
      '
      Me.DateAdded.FillWeight = 20.0!
      Me.DateAdded.HeaderText = "Date Add"
      Me.DateAdded.MinimumWidth = 70
      Me.DateAdded.Name = "DateAdded"
      Me.DateAdded.ReadOnly = True
      '
      'DateRun
      '
      Me.DateRun.FillWeight = 20.0!
      Me.DateRun.HeaderText = "Date Run"
      Me.DateRun.MinimumWidth = 70
      Me.DateRun.Name = "DateRun"
      Me.DateRun.ReadOnly = True
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.CreateTableButton)
      Me.Panel1.Controls.Add(Me.Button2)
      Me.Panel1.Controls.Add(Me.SelectButton)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel1.Location = New System.Drawing.Point(0, 320)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(576, 37)
      Me.Panel1.TabIndex = 3
      '
      'Button2
      '
      Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Button2.Location = New System.Drawing.Point(408, 6)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(75, 23)
      Me.Button2.TabIndex = 1
      Me.Button2.Text = "Cancel"
      Me.Button2.UseVisualStyleBackColor = True
      '
      'SelectButton
      '
      Me.SelectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.SelectButton.Location = New System.Drawing.Point(489, 6)
      Me.SelectButton.Name = "SelectButton"
      Me.SelectButton.Size = New System.Drawing.Size(75, 23)
      Me.SelectButton.TabIndex = 0
      Me.SelectButton.Text = "Select"
      Me.SelectButton.UseVisualStyleBackColor = True
      '
      'CreateTableButton
      '
      Me.CreateTableButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CreateTableButton.Location = New System.Drawing.Point(12, 6)
      Me.CreateTableButton.Name = "CreateTableButton"
      Me.CreateTableButton.Size = New System.Drawing.Size(75, 23)
      Me.CreateTableButton.TabIndex = 2
      Me.CreateTableButton.Text = "Create DS"
      Me.CreateTableButton.UseVisualStyleBackColor = True
      '
      'ProjectManager
      '
      Me.AcceptButton = Me.SelectButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Button2
      Me.ClientSize = New System.Drawing.Size(576, 357)
      Me.Controls.Add(Me.DataGridView1)
      Me.Controls.Add(Me.Panel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ProjectManager"
      Me.ShowInTaskbar = False
      Me.Text = "ProjectManager"
      CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Button2 As System.Windows.Forms.Button
   Friend WithEvents SelectButton As System.Windows.Forms.Button
   Friend WithEvents ProjectName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DateAdded As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents DateRun As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents CreateTableButton As System.Windows.Forms.Button
End Class
