<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectListUI
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
      Me.NewButton = New System.Windows.Forms.Button
      Me.OpenButton = New System.Windows.Forms.Button
      Me.DeleteButton = New System.Windows.Forms.Button
      Me.ProjectListCheckedListBox = New System.Windows.Forms.CheckedListBox
      Me.SuspendLayout()
      '
      'NewButton
      '
      Me.NewButton.Location = New System.Drawing.Point(12, 238)
      Me.NewButton.Name = "NewButton"
      Me.NewButton.Size = New System.Drawing.Size(75, 23)
      Me.NewButton.TabIndex = 0
      Me.NewButton.Text = "New"
      Me.NewButton.UseVisualStyleBackColor = True
      '
      'OpenButton
      '
      Me.OpenButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.OpenButton.Location = New System.Drawing.Point(249, 238)
      Me.OpenButton.Name = "OpenButton"
      Me.OpenButton.Size = New System.Drawing.Size(75, 23)
      Me.OpenButton.TabIndex = 1
      Me.OpenButton.Text = "Open"
      Me.OpenButton.UseVisualStyleBackColor = True
      '
      'DeleteButton
      '
      Me.DeleteButton.Location = New System.Drawing.Point(93, 238)
      Me.DeleteButton.Name = "DeleteButton"
      Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
      Me.DeleteButton.TabIndex = 3
      Me.DeleteButton.Text = "Delete"
      Me.DeleteButton.UseVisualStyleBackColor = True
      '
      'ProjectListCheckedListBox
      '
      Me.ProjectListCheckedListBox.FormattingEnabled = True
      Me.ProjectListCheckedListBox.Location = New System.Drawing.Point(12, 12)
      Me.ProjectListCheckedListBox.Name = "ProjectListCheckedListBox"
      Me.ProjectListCheckedListBox.Size = New System.Drawing.Size(312, 214)
      Me.ProjectListCheckedListBox.TabIndex = 4
      '
      'ProjectListUI
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(336, 273)
      Me.Controls.Add(Me.ProjectListCheckedListBox)
      Me.Controls.Add(Me.DeleteButton)
      Me.Controls.Add(Me.OpenButton)
      Me.Controls.Add(Me.NewButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "ProjectListUI"
      Me.Text = "Project List"
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents NewButton As System.Windows.Forms.Button
   Friend WithEvents OpenButton As System.Windows.Forms.Button
   Friend WithEvents DeleteButton As System.Windows.Forms.Button
   Friend WithEvents ProjectListCheckedListBox As System.Windows.Forms.CheckedListBox
End Class
