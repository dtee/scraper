<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CrawledDataControl
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CrawledDataControl))
      Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
      Me.ParentDataGridView = New System.Windows.Forms.DataGridView
      Me.ChildDataGridView = New System.Windows.Forms.DataGridView
      Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
      Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
      Me.DataSetToolStrip = New System.Windows.Forms.ToolStrip
      Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
      Me.TableListToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
      Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel
      Me.ChildTableToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
      Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
      Me.ViewChildTableToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ViewSYSFieldsToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.FilterParentToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
      Me.SaveDatasetToolStripButton = New System.Windows.Forms.ToolStripButton
      Me.SplitContainer1.Panel1.SuspendLayout()
      Me.SplitContainer1.Panel2.SuspendLayout()
      Me.SplitContainer1.SuspendLayout()
      CType(Me.ParentDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ChildDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.DataSetToolStrip.SuspendLayout()
      Me.SuspendLayout()
      '
      'SplitContainer1
      '
      Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.SplitContainer1.Location = New System.Drawing.Point(0, 25)
      Me.SplitContainer1.Name = "SplitContainer1"
      Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
      '
      'SplitContainer1.Panel1
      '
      Me.SplitContainer1.Panel1.Controls.Add(Me.ParentDataGridView)
      '
      'SplitContainer1.Panel2
      '
      Me.SplitContainer1.Panel2.Controls.Add(Me.ChildDataGridView)
      Me.SplitContainer1.Size = New System.Drawing.Size(723, 426)
      Me.SplitContainer1.SplitterDistance = 213
      Me.SplitContainer1.TabIndex = 13
      '
      'ParentDataGridView
      '
      Me.ParentDataGridView.AllowUserToAddRows = False
      Me.ParentDataGridView.AllowUserToDeleteRows = False
      Me.ParentDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.ParentDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
      Me.ParentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.ParentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ParentDataGridView.Location = New System.Drawing.Point(0, 0)
      Me.ParentDataGridView.Name = "ParentDataGridView"
      Me.ParentDataGridView.Size = New System.Drawing.Size(723, 213)
      Me.ParentDataGridView.TabIndex = 8
      '
      'ChildDataGridView
      '
      Me.ChildDataGridView.AllowUserToAddRows = False
      Me.ChildDataGridView.AllowUserToDeleteRows = False
      Me.ChildDataGridView.AllowUserToResizeRows = False
      Me.ChildDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
      Me.ChildDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.ChildDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.ChildDataGridView.Location = New System.Drawing.Point(0, 0)
      Me.ChildDataGridView.Name = "ChildDataGridView"
      Me.ChildDataGridView.Size = New System.Drawing.Size(723, 209)
      Me.ChildDataGridView.TabIndex = 0
      '
      'ToolStripLabel1
      '
      Me.ToolStripLabel1.Name = "ToolStripLabel1"
      Me.ToolStripLabel1.Size = New System.Drawing.Size(65, 22)
      Me.ToolStripLabel1.Text = "Select Table"
      '
      'ToolStripSeparator2
      '
      Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
      Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripSeparator1
      '
      Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
      Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
      '
      'DataSetToolStrip
      '
      Me.DataSetToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
      Me.DataSetToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.TableListToolStripComboBox, Me.ToolStripSeparator3, Me.ToolStripLabel3, Me.ChildTableToolStripComboBox, Me.ToolStripSeparator5, Me.ViewChildTableToolStripButton, Me.ViewSYSFieldsToolStripButton, Me.FilterParentToolStripButton, Me.ToolStripSeparator4, Me.SaveDatasetToolStripButton})
      Me.DataSetToolStrip.Location = New System.Drawing.Point(0, 0)
      Me.DataSetToolStrip.Name = "DataSetToolStrip"
      Me.DataSetToolStrip.Size = New System.Drawing.Size(723, 25)
      Me.DataSetToolStrip.TabIndex = 14
      Me.DataSetToolStrip.Text = "CrawledDataToolStrip"
      '
      'ToolStripLabel2
      '
      Me.ToolStripLabel2.Name = "ToolStripLabel2"
      Me.ToolStripLabel2.Size = New System.Drawing.Size(65, 22)
      Me.ToolStripLabel2.Text = "Select Table"
      '
      'TableListToolStripComboBox
      '
      Me.TableListToolStripComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
      Me.TableListToolStripComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
      Me.TableListToolStripComboBox.Name = "TableListToolStripComboBox"
      Me.TableListToolStripComboBox.Size = New System.Drawing.Size(121, 25)
      '
      'ToolStripSeparator3
      '
      Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
      Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      '
      'ToolStripLabel3
      '
      Me.ToolStripLabel3.Name = "ToolStripLabel3"
      Me.ToolStripLabel3.Size = New System.Drawing.Size(34, 22)
      Me.ToolStripLabel3.Text = "Child:"
      '
      'ChildTableToolStripComboBox
      '
      Me.ChildTableToolStripComboBox.Name = "ChildTableToolStripComboBox"
      Me.ChildTableToolStripComboBox.Size = New System.Drawing.Size(121, 25)
      '
      'ToolStripSeparator5
      '
      Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
      Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
      '
      'ViewChildTableToolStripButton
      '
      Me.ViewChildTableToolStripButton.CheckOnClick = True
      Me.ViewChildTableToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ViewChildTableToolStripButton.Image = CType(resources.GetObject("ViewChildTableToolStripButton.Image"), System.Drawing.Image)
      Me.ViewChildTableToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ViewChildTableToolStripButton.Name = "ViewChildTableToolStripButton"
      Me.ViewChildTableToolStripButton.Size = New System.Drawing.Size(88, 22)
      Me.ViewChildTableToolStripButton.Text = "View Child Table"
      '
      'ViewSYSFieldsToolStripButton
      '
      Me.ViewSYSFieldsToolStripButton.CheckOnClick = True
      Me.ViewSYSFieldsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.ViewSYSFieldsToolStripButton.Image = CType(resources.GetObject("ViewSYSFieldsToolStripButton.Image"), System.Drawing.Image)
      Me.ViewSYSFieldsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.ViewSYSFieldsToolStripButton.Name = "ViewSYSFieldsToolStripButton"
      Me.ViewSYSFieldsToolStripButton.Size = New System.Drawing.Size(84, 22)
      Me.ViewSYSFieldsToolStripButton.Text = "View SYS Fields"
      '
      'FilterParentToolStripButton
      '
      Me.FilterParentToolStripButton.CheckOnClick = True
      Me.FilterParentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.FilterParentToolStripButton.Image = CType(resources.GetObject("FilterParentToolStripButton.Image"), System.Drawing.Image)
      Me.FilterParentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.FilterParentToolStripButton.Name = "FilterParentToolStripButton"
      Me.FilterParentToolStripButton.Size = New System.Drawing.Size(70, 22)
      Me.FilterParentToolStripButton.Text = "Filter Parent"
      Me.FilterParentToolStripButton.Visible = False
      '
      'ToolStripSeparator4
      '
      Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
      Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
      '
      'SaveDatasetToolStripButton
      '
      Me.SaveDatasetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
      Me.SaveDatasetToolStripButton.Image = CType(resources.GetObject("SaveDatasetToolStripButton.Image"), System.Drawing.Image)
      Me.SaveDatasetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
      Me.SaveDatasetToolStripButton.Name = "SaveDatasetToolStripButton"
      Me.SaveDatasetToolStripButton.Size = New System.Drawing.Size(76, 22)
      Me.SaveDatasetToolStripButton.Text = "Save Dataset"
      '
      'CrawledDataControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.SplitContainer1)
      Me.Controls.Add(Me.DataSetToolStrip)
      Me.Name = "CrawledDataControl"
      Me.Size = New System.Drawing.Size(723, 451)
      Me.SplitContainer1.Panel1.ResumeLayout(False)
      Me.SplitContainer1.Panel2.ResumeLayout(False)
      Me.SplitContainer1.ResumeLayout(False)
      CType(Me.ParentDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ChildDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.DataSetToolStrip.ResumeLayout(False)
      Me.DataSetToolStrip.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
   Friend WithEvents ChildDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents DataSetToolStrip As System.Windows.Forms.ToolStrip
   Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents TableListToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents ViewChildTableToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Friend WithEvents SaveDatasetToolStripButton As System.Windows.Forms.ToolStripButton
   Public WithEvents ParentDataGridView As System.Windows.Forms.DataGridView
   Friend WithEvents ViewSYSFieldsToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents FilterParentToolStripButton As System.Windows.Forms.ToolStripButton
   Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
   Friend WithEvents ChildTableToolStripComboBox As System.Windows.Forms.ToolStripComboBox
   Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator

End Class
