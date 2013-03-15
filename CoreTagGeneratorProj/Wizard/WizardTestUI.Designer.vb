<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WizardTestUI
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
      Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
      Me.GenerateButton = New System.Windows.Forms.Button
      Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
      Me.TabControl1 = New System.Windows.Forms.TabControl
      Me.TestCasesabPage = New System.Windows.Forms.TabPage
      Me.ComboBox1 = New System.Windows.Forms.ComboBox
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.WizardCtl1 = New CoreTagGeneratorProj.WizardCtl
      Me.CrawledDataControl1 = New SharedUI.CrawledDataControl
      Me.ComboBox2 = New System.Windows.Forms.ComboBox
      Me.CreateTestCaseTabPage = New System.Windows.Forms.TabPage
      Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
      Me.RichTextBox1 = New System.Windows.Forms.RichTextBox
      Me.SampleDataGridView = New System.Windows.Forms.DataGridView
      Me.FieldsDataGridView = New System.Windows.Forms.DataGridView
      Me.FieldName = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MaxChars = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IsSaveData = New System.Windows.Forms.DataGridViewCheckBoxColumn
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.UpdateTableButton = New System.Windows.Forms.Button
      Me.NewTestCaseButton = New System.Windows.Forms.Button
      Me.Label1 = New System.Windows.Forms.Label
      Me.TestCaseNameTextBox = New System.Windows.Forms.TextBox
      Me.SaveTestCaseButton = New System.Windows.Forms.Button
      Me.Button1 = New System.Windows.Forms.Button
      Me.GenerateEndTagButton = New System.Windows.Forms.Button
      Me.SaveProjectButton = New System.Windows.Forms.Button
      Me.ScrapeButton = New System.Windows.Forms.Button
      Me.Panel2 = New System.Windows.Forms.Panel
      Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
      Me.SplitContainer3.Panel1.SuspendLayout()
      Me.SplitContainer3.Panel2.SuspendLayout()
      Me.SplitContainer3.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TestCasesabPage.SuspendLayout()
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      Me.CreateTestCaseTabPage.SuspendLayout()
      Me.SplitContainer2.Panel1.SuspendLayout()
      Me.SplitContainer2.Panel2.SuspendLayout()
      Me.SplitContainer2.SuspendLayout()
      CType(Me.SampleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.FieldsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'GenerateButton
      '
      Me.GenerateButton.Enabled = False
      Me.GenerateButton.Location = New System.Drawing.Point(12, 3)
      Me.GenerateButton.Name = "GenerateButton"
      Me.GenerateButton.Size = New System.Drawing.Size(75, 23)
      Me.GenerateButton.TabIndex = 1
      Me.GenerateButton.Text = "Generate"
      Me.GenerateButton.UseVisualStyleBackColor = True
      '
      'SplitContainer3
      '
      Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
      Me.SplitContainer3.Name = "SplitContainer3"
      Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer3.Panel1
      '
      Me.SplitContainer3.Panel1.Controls.Add(Me.TabControl1)
      '
      'SplitContainer3.Panel2
      '
      Me.SplitContainer3.Panel2.Controls.Add(Me.Button1)
      Me.SplitContainer3.Panel2.Controls.Add(Me.GenerateEndTagButton)
      Me.SplitContainer3.Panel2.Controls.Add(Me.SaveProjectButton)
      Me.SplitContainer3.Panel2.Controls.Add(Me.ScrapeButton)
      Me.SplitContainer3.Panel2.Controls.Add(Me.GenerateButton)
      Me.SplitContainer3.Size = New System.Drawing.Size(978, 532)
      Me.SplitContainer3.SplitterDistance = 495
      Me.SplitContainer3.TabIndex = 6
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TestCasesabPage)
      Me.TabControl1.Controls.Add(Me.CreateTestCaseTabPage)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 0)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(978, 495)
      Me.TabControl1.TabIndex = 1
      '
      'TestCasesabPage
      '
      Me.TestCasesabPage.Controls.Add(Me.ComboBox1)
      Me.TestCasesabPage.Controls.Add(Me.SplitContainer1)
      Me.TestCasesabPage.Location = New System.Drawing.Point(4, 22)
      Me.TestCasesabPage.Name = "TestCasesabPage"
      Me.TestCasesabPage.Padding = New System.Windows.Forms.Padding(3)
      Me.TestCasesabPage.Size = New System.Drawing.Size(970, 469)
      Me.TestCasesabPage.TabIndex = 0
      Me.TestCasesabPage.Text = "Test Cases"
      Me.TestCasesabPage.UseVisualStyleBackColor = True
      '
      'ComboBox1
      '
      Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Top
      Me.ComboBox1.FormattingEnabled = True
      Me.ComboBox1.Location = New System.Drawing.Point(3, 3)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(964, 21)
      Me.ComboBox1.TabIndex = 0
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
      Me.SplitContainer1.Name = "SplitContainer1"
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.WizardCtl1)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.CrawledDataControl1)
      Me.SplitContainer1.Panel2.Controls.Add(Me.ComboBox2)
      Me.SplitContainer1.Size = New System.Drawing.Size(964, 463)
      Me.SplitContainer1.SplitterDistance = 468
      Me.SplitContainer1.TabIndex = 1
      '
      'WizardCtl1
      '
      Me.WizardCtl1.ContorlName = "Label1"
      Me.WizardCtl1.DirName = Nothing
      Me.WizardCtl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.WizardCtl1.Location = New System.Drawing.Point(0, 0)
      Me.WizardCtl1.Name = "WizardCtl1"
      Me.WizardCtl1.Size = New System.Drawing.Size(468, 463)
      Me.WizardCtl1.TabIndex = 0
      Me.WizardCtl1.TagTree = Nothing
      '
      'CrawledDataControl1
      '
      Me.CrawledDataControl1.DataSet = Nothing
      Me.CrawledDataControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.CrawledDataControl1.Location = New System.Drawing.Point(0, 21)
      Me.CrawledDataControl1.Name = "CrawledDataControl1"
      Me.CrawledDataControl1.Size = New System.Drawing.Size(492, 442)
      Me.CrawledDataControl1.TabIndex = 12
      '
      'ComboBox2
      '
      Me.ComboBox2.Dock = System.Windows.Forms.DockStyle.Top
      Me.ComboBox2.FormattingEnabled = True
      Me.ComboBox2.Location = New System.Drawing.Point(0, 0)
      Me.ComboBox2.Name = "ComboBox2"
      Me.ComboBox2.Size = New System.Drawing.Size(492, 21)
      Me.ComboBox2.TabIndex = 11
      '
      'CreateTestCaseTabPage
      '
      Me.CreateTestCaseTabPage.Controls.Add(Me.SplitContainer2)
      Me.CreateTestCaseTabPage.Location = New System.Drawing.Point(4, 22)
      Me.CreateTestCaseTabPage.Name = "CreateTestCaseTabPage"
      Me.CreateTestCaseTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me.CreateTestCaseTabPage.Size = New System.Drawing.Size(970, 469)
      Me.CreateTestCaseTabPage.TabIndex = 1
      Me.CreateTestCaseTabPage.Text = "Create Test Case"
      Me.CreateTestCaseTabPage.UseVisualStyleBackColor = True
      '
      'SplitContainer2
      '
      Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
      Me.SplitContainer2.Name = "SplitContainer2"
      '
      'SplitContainer2.Panel1
      '
      Me.SplitContainer2.Panel1.Controls.Add(Me.RichTextBox1)
      '
      'SplitContainer2.Panel2
      '
      Me.SplitContainer2.Panel2.Controls.Add(Me.SampleDataGridView)
      Me.SplitContainer2.Panel2.Controls.Add(Me.FieldsDataGridView)
      Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
      Me.SplitContainer2.Size = New System.Drawing.Size(964, 463)
      Me.SplitContainer2.SplitterDistance = 475
      Me.SplitContainer2.TabIndex = 5
      '
      'RichTextBox1
      '
      Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
      Me.RichTextBox1.Name = "RichTextBox1"
      Me.RichTextBox1.Size = New System.Drawing.Size(475, 463)
      Me.RichTextBox1.TabIndex = 1
      Me.RichTextBox1.Text = ""
      '
      'SampleDataGridView
      '
      Me.SampleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.SampleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.SampleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SampleDataGridView.Location = New System.Drawing.Point(0, 179)
      Me.SampleDataGridView.Name = "SampleDataGridView"
      Me.SampleDataGridView.Size = New System.Drawing.Size(485, 284)
      Me.SampleDataGridView.TabIndex = 7
      '
      'FieldsDataGridView
      '
      DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue
      Me.FieldsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
      Me.FieldsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.FieldsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.FieldsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FieldName, Me.MaxChars, Me.IsSaveData})
      Me.FieldsDataGridView.Dock = System.Windows.Forms.DockStyle.Top
      Me.FieldsDataGridView.Location = New System.Drawing.Point(0, 51)
      Me.FieldsDataGridView.Name = "FieldsDataGridView"
      Me.FieldsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.FieldsDataGridView.Size = New System.Drawing.Size(485, 128)
      Me.FieldsDataGridView.TabIndex = 5
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
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.UpdateTableButton)
      Me.Panel1.Controls.Add(Me.NewTestCaseButton)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.TestCaseNameTextBox)
      Me.Panel1.Controls.Add(Me.SaveTestCaseButton)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(485, 51)
      Me.Panel1.TabIndex = 6
      '
      'UpdateTableButton
      '
      Me.UpdateTableButton.Location = New System.Drawing.Point(234, 14)
      Me.UpdateTableButton.Name = "UpdateTableButton"
      Me.UpdateTableButton.Size = New System.Drawing.Size(75, 23)
      Me.UpdateTableButton.TabIndex = 4
      Me.UpdateTableButton.Text = "Update Table"
      Me.UpdateTableButton.UseVisualStyleBackColor = True
      '
      'NewTestCaseButton
      '
      Me.NewTestCaseButton.Location = New System.Drawing.Point(396, 14)
      Me.NewTestCaseButton.Name = "NewTestCaseButton"
      Me.NewTestCaseButton.Size = New System.Drawing.Size(75, 23)
      Me.NewTestCaseButton.TabIndex = 3
      Me.NewTestCaseButton.Text = "New"
      Me.NewTestCaseButton.UseVisualStyleBackColor = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(8, 17)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(62, 13)
      Me.Label1.TabIndex = 2
      Me.Label1.Text = "Test Name:"
      '
      'TestCaseNameTextBox
      '
      Me.TestCaseNameTextBox.Location = New System.Drawing.Point(76, 14)
      Me.TestCaseNameTextBox.Name = "TestCaseNameTextBox"
      Me.TestCaseNameTextBox.Size = New System.Drawing.Size(152, 20)
      Me.TestCaseNameTextBox.TabIndex = 1
      '
      'SaveTestCaseButton
      '
      Me.SaveTestCaseButton.Location = New System.Drawing.Point(315, 14)
      Me.SaveTestCaseButton.Name = "SaveTestCaseButton"
      Me.SaveTestCaseButton.Size = New System.Drawing.Size(75, 23)
      Me.SaveTestCaseButton.TabIndex = 0
      Me.SaveTestCaseButton.Text = "Save"
      Me.SaveTestCaseButton.UseVisualStyleBackColor = True
      '
      'Button1
      '
      Me.Button1.Location = New System.Drawing.Point(891, 3)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(75, 23)
      Me.Button1.TabIndex = 5
      Me.Button1.Text = "Test"
      Me.Button1.UseVisualStyleBackColor = True
      '
      'GenerateEndTagButton
      '
      Me.GenerateEndTagButton.Location = New System.Drawing.Point(479, 3)
      Me.GenerateEndTagButton.Name = "GenerateEndTagButton"
      Me.GenerateEndTagButton.Size = New System.Drawing.Size(183, 23)
      Me.GenerateEndTagButton.TabIndex = 4
      Me.GenerateEndTagButton.Text = "Generate End Tag"
      Me.GenerateEndTagButton.UseVisualStyleBackColor = True
      '
      'SaveProjectButton
      '
      Me.SaveProjectButton.Location = New System.Drawing.Point(174, 3)
      Me.SaveProjectButton.Name = "SaveProjectButton"
      Me.SaveProjectButton.Size = New System.Drawing.Size(111, 23)
      Me.SaveProjectButton.TabIndex = 3
      Me.SaveProjectButton.Text = "Save Project"
      Me.SaveProjectButton.UseVisualStyleBackColor = True
      '
      'ScrapeButton
      '
      Me.ScrapeButton.Location = New System.Drawing.Point(93, 3)
      Me.ScrapeButton.Name = "ScrapeButton"
      Me.ScrapeButton.Size = New System.Drawing.Size(75, 23)
      Me.ScrapeButton.TabIndex = 2
      Me.ScrapeButton.Text = "Scrape"
      Me.ScrapeButton.UseVisualStyleBackColor = True
      '
      'Panel2
      '
      Me.Panel2.Controls.Add(Me.SplitContainer3)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Panel2.Location = New System.Drawing.Point(0, 0)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(978, 532)
      Me.Panel2.TabIndex = 3
      '
      'SaveFileDialog1
      '
      Me.SaveFileDialog1.DefaultExt = "sprj"
      Me.SaveFileDialog1.Filter = "Scraper Project File (*.sprj)|*.sprj|Xml File (*.xml)|*.xml|All Files (*.*)|*.*"
      '
      'WizardTestUI
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(978, 532)
      Me.Controls.Add(Me.Panel2)
      Me.Name = "WizardTestUI"
      Me.Text = "textCompareTest"
      Me.SplitContainer3.Panel1.ResumeLayout(False)
      Me.SplitContainer3.Panel2.ResumeLayout(False)
      Me.SplitContainer3.ResumeLayout(False)
      Me.TabControl1.ResumeLayout(False)
      Me.TestCasesabPage.ResumeLayout(False)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      Me.CreateTestCaseTabPage.ResumeLayout(False)
      Me.SplitContainer2.Panel1.ResumeLayout(False)
      Me.SplitContainer2.Panel2.ResumeLayout(False)
      Me.SplitContainer2.ResumeLayout(False)
      CType(Me.SampleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.FieldsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub
   Friend WithEvents GenerateButton As System.Windows.Forms.Button
   Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents ScrapeButton As System.Windows.Forms.Button
   Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
   Friend WithEvents SaveProjectButton As System.Windows.Forms.Button
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TestCasesabPage As System.Windows.Forms.TabPage
   Friend WithEvents CreateTestCaseTabPage As System.Windows.Forms.TabPage
   Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
   Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
   Friend WithEvents FieldsDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents FieldName As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents MaxChars As System.Windows.Forms.DataGridViewTextBoxColumn
   Friend WithEvents IsSaveData As System.Windows.Forms.DataGridViewCheckBoxColumn
   Friend WithEvents GenerateEndTagButton As System.Windows.Forms.Button
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents SaveTestCaseButton As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents TestCaseNameTextBox As System.Windows.Forms.TextBox
   Friend WithEvents NewTestCaseButton As System.Windows.Forms.Button
   Friend WithEvents SampleDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents UpdateTableButton As System.Windows.Forms.Button
   Friend WithEvents WizardCtl1 As CoreTagGeneratorProj.WizardCtl
   Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
   Friend WithEvents CrawledDataControl1 As SharedUI.CrawledDataControl
   Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
