<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlWizard
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
      Me.btnFinish = New System.Windows.Forms.Button
      Me.btnNext = New System.Windows.Forms.Button
      Me.btnBack = New System.Windows.Forms.Button
      Me.btnCancel = New System.Windows.Forms.Button
      Me.mainPanel = New System.Windows.Forms.Panel
      Me.navPanel = New System.Windows.Forms.Panel
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      Me.Panel2 = New System.Windows.Forms.Panel
      Me.lblTitle = New System.Windows.Forms.Label
      Me.lblDescription = New System.Windows.Forms.Label
      Me.PictureBox2 = New System.Windows.Forms.PictureBox
      Me.mainPanel.SuspendLayout()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel2.SuspendLayout()
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'btnFinish
      '
      Me.btnFinish.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnFinish.BackColor = System.Drawing.SystemColors.Control
      Me.btnFinish.Enabled = False
      Me.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnFinish.Location = New System.Drawing.Point(521, 334)
      Me.btnFinish.Name = "btnFinish"
      Me.btnFinish.Size = New System.Drawing.Size(75, 23)
      Me.btnFinish.TabIndex = 4
      Me.btnFinish.Text = "Finish"
      Me.btnFinish.UseVisualStyleBackColor = False
      '
      'btnNext
      '
      Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnNext.BackColor = System.Drawing.SystemColors.Control
      Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnNext.Location = New System.Drawing.Point(422, 334)
      Me.btnNext.Name = "btnNext"
      Me.btnNext.Size = New System.Drawing.Size(75, 23)
      Me.btnNext.TabIndex = 5
      Me.btnNext.Text = "Next >>"
      Me.btnNext.UseVisualStyleBackColor = False
      '
      'btnBack
      '
      Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnBack.BackColor = System.Drawing.SystemColors.Control
      Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnBack.Location = New System.Drawing.Point(341, 334)
      Me.btnBack.Name = "btnBack"
      Me.btnBack.Size = New System.Drawing.Size(75, 23)
      Me.btnBack.TabIndex = 6
      Me.btnBack.Text = "<< Back"
      Me.btnBack.UseVisualStyleBackColor = False
      '
      'btnCancel
      '
      Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
      Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCancel.Location = New System.Drawing.Point(15, 334)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.Size = New System.Drawing.Size(75, 23)
      Me.btnCancel.TabIndex = 7
      Me.btnCancel.Text = "Cancel"
      Me.btnCancel.UseVisualStyleBackColor = False
      '
      'mainPanel
      '
      Me.mainPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.mainPanel.Controls.Add(Me.navPanel)
      Me.mainPanel.Controls.Add(Me.PictureBox1)
      Me.mainPanel.Controls.Add(Me.Panel2)
      Me.mainPanel.Location = New System.Drawing.Point(0, 3)
      Me.mainPanel.Name = "mainPanel"
      Me.mainPanel.Size = New System.Drawing.Size(618, 326)
      Me.mainPanel.TabIndex = 8
      '
      'navPanel
      '
      Me.navPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.navPanel.Location = New System.Drawing.Point(108, 79)
      Me.navPanel.Name = "navPanel"
      Me.navPanel.Padding = New System.Windows.Forms.Padding(10)
      Me.navPanel.Size = New System.Drawing.Size(508, 245)
      Me.navPanel.TabIndex = 11
      '
      'PictureBox1
      '
      Me.PictureBox1.BackColor = System.Drawing.SystemColors.Desktop
      Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
      Me.PictureBox1.Location = New System.Drawing.Point(0, 79)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(108, 245)
      Me.PictureBox1.TabIndex = 9
      Me.PictureBox1.TabStop = False
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
      Me.Panel2.Controls.Add(Me.lblTitle)
      Me.Panel2.Controls.Add(Me.lblDescription)
      Me.Panel2.Controls.Add(Me.PictureBox2)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel2.Location = New System.Drawing.Point(0, 0)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(616, 79)
      Me.Panel2.TabIndex = 10
      '
      'lblTitle
      '
      Me.lblTitle.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTitle.Location = New System.Drawing.Point(8, 16)
      Me.lblTitle.Name = "lblTitle"
      Me.lblTitle.Size = New System.Drawing.Size(336, 40)
      Me.lblTitle.TabIndex = 2
      Me.lblTitle.Text = "Title"
      '
      'lblDescription
      '
      Me.lblDescription.Location = New System.Drawing.Point(16, 56)
      Me.lblDescription.Name = "lblDescription"
      Me.lblDescription.Size = New System.Drawing.Size(328, 16)
      Me.lblDescription.TabIndex = 1
      Me.lblDescription.Text = "Description"
      '
      'PictureBox2
      '
      Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.PictureBox2.Location = New System.Drawing.Point(502, 16)
      Me.PictureBox2.Name = "PictureBox2"
      Me.PictureBox2.Size = New System.Drawing.Size(48, 48)
      Me.PictureBox2.TabIndex = 0
      Me.PictureBox2.TabStop = False
      '
      'ctlWizard
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.mainPanel)
      Me.Controls.Add(Me.btnCancel)
      Me.Controls.Add(Me.btnFinish)
      Me.Controls.Add(Me.btnNext)
      Me.Controls.Add(Me.btnBack)
      Me.Name = "ctlWizard"
      Me.Size = New System.Drawing.Size(618, 365)
      Me.mainPanel.ResumeLayout(False)
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel2.ResumeLayout(False)
      CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents btnFinish As System.Windows.Forms.Button
   Friend WithEvents btnNext As System.Windows.Forms.Button
   Friend WithEvents btnBack As System.Windows.Forms.Button
   Friend WithEvents btnCancel As System.Windows.Forms.Button
   Friend WithEvents mainPanel As System.Windows.Forms.Panel
   Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents lblTitle As System.Windows.Forms.Label
   Friend WithEvents lblDescription As System.Windows.Forms.Label
   Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
   Friend WithEvents navPanel As System.Windows.Forms.Panel

End Class
