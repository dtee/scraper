<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrawlProjectListUI
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
      Me.DeleteButton = New System.Windows.Forms.Button
      Me.OpenButton = New System.Windows.Forms.Button
      Me.ConnectionButton = New System.Windows.Forms.Button
      Me.ProjectsDataGridView = New System.Windows.Forms.DataGridView
      Me.projectName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.Cancel_Button = New System.Windows.Forms.Button
      CType(Me.ProjectsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'DeleteButton
      '
      Me.DeleteButton.Location = New System.Drawing.Point(93, 290)
      Me.DeleteButton.Name = "DeleteButton"
      Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
      Me.DeleteButton.TabIndex = 6
      Me.DeleteButton.Text = "Delete"
      Me.DeleteButton.UseVisualStyleBackColor = True
      '
      'OpenButton
      '
      Me.OpenButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.OpenButton.Location = New System.Drawing.Point(398, 290)
      Me.OpenButton.Name = "OpenButton"
      Me.OpenButton.Size = New System.Drawing.Size(75, 23)
      Me.OpenButton.TabIndex = 5
      Me.OpenButton.Text = "Open"
      Me.OpenButton.UseVisualStyleBackColor = True
      '
      'ConnectionButton
      '
      Me.ConnectionButton.Location = New System.Drawing.Point(12, 290)
      Me.ConnectionButton.Name = "ConnectionButton"
      Me.ConnectionButton.Size = New System.Drawing.Size(75, 23)
      Me.ConnectionButton.TabIndex = 4
      Me.ConnectionButton.Text = "Connection"
      Me.ConnectionButton.UseVisualStyleBackColor = True
      '
      'ProjectsDataGridView
      '
      Me.ProjectsDataGridView.AllowUserToAddRows = False
      Me.ProjectsDataGridView.AllowUserToDeleteRows = False
      Me.ProjectsDataGridView.AllowUserToResizeColumns = False
      Me.ProjectsDataGridView.AllowUserToResizeRows = False
      Me.ProjectsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.ProjectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.ProjectsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.projectName})
      Me.ProjectsDataGridView.Location = New System.Drawing.Point(12, 12)
      Me.ProjectsDataGridView.MultiSelect = False
      Me.ProjectsDataGridView.Name = "ProjectsDataGridView"
      Me.ProjectsDataGridView.ReadOnly = True
      Me.ProjectsDataGridView.RowHeadersVisible = False
      Me.ProjectsDataGridView.RowHeadersWidth = 10
      Me.ProjectsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
      Me.ProjectsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.ProjectsDataGridView.Size = New System.Drawing.Size(461, 272)
      Me.ProjectsDataGridView.TabIndex = 7
      '
      'projectName
      '
      Me.projectName.HeaderText = "Project Name"
      Me.projectName.Name = "projectName"
      Me.projectName.ReadOnly = True
      '
      'Cancel_Button
      '
      Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Cancel_Button.Location = New System.Drawing.Point(317, 290)
      Me.Cancel_Button.Name = "Cancel_Button"
      Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
      Me.Cancel_Button.TabIndex = 8
      Me.Cancel_Button.Text = "Cancel"
      Me.Cancel_Button.UseVisualStyleBackColor = True
      '
      'CrawlProjectListUI
      '
      Me.AcceptButton = Me.OpenButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me.Cancel_Button
      Me.ClientSize = New System.Drawing.Size(485, 325)
      Me.Controls.Add(Me.Cancel_Button)
      Me.Controls.Add(Me.ProjectsDataGridView)
      Me.Controls.Add(Me.DeleteButton)
      Me.Controls.Add(Me.OpenButton)
      Me.Controls.Add(Me.ConnectionButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CrawlProjectListUI"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      Me.Text = "Crawl Projects"
      CType(Me.ProjectsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents DeleteButton As System.Windows.Forms.Button
   Friend WithEvents OpenButton As System.Windows.Forms.Button
   Friend WithEvents ConnectionButton As System.Windows.Forms.Button
   Friend WithEvents ProjectsDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents Cancel_Button As System.Windows.Forms.Button
   Friend WithEvents projectName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
