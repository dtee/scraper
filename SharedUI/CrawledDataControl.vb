Public Class CrawledDataControl

   Public Event Progress(ByVal text As String)

   Public IsDebug As Boolean = True

   Private ds As DataSet
   Public Property [DataSet]() As DataSet
      Get
         Return ds
      End Get
      Set(ByVal value As DataSet)
         ds = value
         Me.TableListToolStripComboBox.Items.Clear()
         Me.ParentDataGridView.DataMember = ""
         Me.ParentDataGridView.DataSource = ds
         Me.ChildDataGridView.DataSource = Nothing

         If value Is Nothing Then
            RaiseEvent Progress("There are no datatables.")
            Me.DataSetToolStrip.Enabled = False
            Me.SplitContainer1.Panel2Collapsed = True
         Else
            Me.DataSetToolStrip.Enabled = True
         End If

         If (value IsNot Nothing AndAlso value.Tables.Count > 0) Then
            Me.ChildDataGridView.DataSource = ds
            For Each tbl As DataTable In ds.Tables
               If IsDebug Then
                  Me.TableListToolStripComboBox.Items.Add(tbl.TableName)
               Else
                  If ScraperLib.DataTableUtil.IsGeneratedTable(tbl) Then
                     If tbl.TableName.Contains("Dataset") Then
                     Else
                        Me.TableListToolStripComboBox.Items.Add(tbl.TableName)
                     End If
                  Else
                     If tbl.TableName = "Url" Then
                        Me.TableListToolStripComboBox.Items.Add(tbl.TableName)
                     End If
                  End If
               End If
            Next

            If ds.Relations.Count = 0 Then
               Me.ViewChildTableToolStripButton.Enabled = False
               Me.ViewChildTableToolStripButton.Checked = False
               Me.ChildTableToolStripComboBox.Enabled = False
               Me.SplitContainer1.Panel2Collapsed = True
            Else
               Me.ViewChildTableToolStripButton.Enabled = True
               Me.ViewChildTableToolStripButton.Checked = True
               Me.ChildTableToolStripComboBox.Enabled = True
            End If

            If Me.TableListToolStripComboBox.Items.Count > 0 Then
               Me.TableListToolStripComboBox.SelectedIndex = 0
               Me.ParentDataGridView.DataMember = Me.TableListToolStripComboBox.SelectedItem
            End If

            ViewSYSFieldsToolStripButton.Checked = False
            ViewSYSFieldsToolStripButton_Click(Nothing, Nothing)

            If value.Relations.Count = 0 Then
               Me.ViewChildTableToolStripButton.Enabled = False
            End If
         End If

      End Set
   End Property

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub TableListToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableListToolStripComboBox.SelectedIndexChanged
      Me.ParentDataGridView.DataMember = Me.TableListToolStripComboBox.SelectedItem
      Dim pTable As DataTable = Me.DataSet.Tables(Me.TableListToolStripComboBox.SelectedItem.ToString)

      RaiseEvent Progress("Total Rows: " & pTable.Rows.Count)
      Me.ChildTableToolStripComboBox.Items.Clear()

      'Dim cb As Windows.Forms.ComboBox = Me.ChildTableToolStripComboBox.Control
      'cb.DisplayMember = "TableName"

      ' If table have child table then:
      If pTable.ChildRelations.Count > 0 Then

         ' Add relation to the data table.
         For Each rel As DataRelation In pTable.ChildRelations
            If IsDebug Then
               Me.ChildTableToolStripComboBox.Items.Add(rel.RelationName)
            Else
               If rel.RelationName.Contains("SYS") Then
                  If rel.RelationName.Contains("Dataset") Then
                  Else
                     Me.ChildTableToolStripComboBox.Items.Add(rel.RelationName)
                  End If
               Else
                  If rel.RelationName = "Url" Then
                     Me.ChildTableToolStripComboBox.Items.Add(rel.RelationName)
                  End If
               End If
            End If
         Next

         If Me.ChildTableToolStripComboBox.Items.Count > 0 Then
            'Me.ChildTableToolStripComboBox.SelectedIndex = 0
            Me.ViewChildTableToolStripButton.Enabled = True
         Else
            Me.ChildTableToolStripComboBox.Text = ""
            Me.FilterParentToolStripButton.Enabled = False
            Me.SplitContainer1.Panel2Collapsed = True
            Me.ViewChildTableToolStripButton.Enabled = False
         End If
      Else
         Me.FilterParentToolStripButton.Enabled = False
         Me.SplitContainer1.Panel2Collapsed = True
         Me.ViewChildTableToolStripButton.Enabled = False
      End If
   End Sub

   Private Sub ChildTableToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChildTableToolStripComboBox.SelectedIndexChanged
      Dim relName As String = Me.ChildTableToolStripComboBox.SelectedItem
      Dim parentDTName As String = Me.TableListToolStripComboBox.SelectedItem

      Me.SplitContainer1.Panel2Collapsed = Not Me.ViewChildTableToolStripButton.Checked
      Me.FilterParentToolStripButton.Enabled = True

      For Each rl As Data.DataRelation In Me.ds.Relations
         Console.Write(rl.RelationName & ", ")
      Next
      Console.WriteLine()
      Console.WriteLine("=====================================")

      ds.AcceptChanges()
      Me.ChildDataGridView.DataSource = ds
      Me.ChildDataGridView.DataMember = parentDTName & "." & relName
   End Sub

   Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDatasetToolStripButton.Click
      Dim saveDiag As New Windows.Forms.SaveFileDialog
      saveDiag.DefaultExt = "*.xml"
      saveDiag.Filter = "Xml file (*.xml)|*.xml"
      saveDiag.AddExtension = True

      If saveDiag.ShowDialog = Windows.Forms.DialogResult.OK Then
         Try
            Me.ds.WriteXml(saveDiag.FileName)
         Catch ex As Exception
            MsgBox("Error: " & ex.Message)
         End Try
      End If
   End Sub

   Private Sub ViewChildToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewChildTableToolStripButton.Click
      Me.SplitContainer1.Panel2Collapsed = Not ViewChildTableToolStripButton.Checked
   End Sub

   Public ReadOnly Property TotalData() As Integer
      Get
         Return Me.ParentDataGridView.RowCount
      End Get
   End Property

   Private Sub ViewSYSFieldsToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewSYSFieldsToolStripButton.Click
      If Me.ChildDataGridView.ColumnCount > 4 Then
         Me.ChildDataGridView.Columns(0).Visible = ViewSYSFieldsToolStripButton.Checked
         Me.ChildDataGridView.Columns(1).Visible = ViewSYSFieldsToolStripButton.Checked
         Me.ChildDataGridView.Columns(2).Visible = ViewSYSFieldsToolStripButton.Checked
         Me.ChildDataGridView.Columns(3).Visible = ViewSYSFieldsToolStripButton.Checked
      End If

      If Me.ParentDataGridView.ColumnCount > 4 Then
         Me.ParentDataGridView.Columns(0).Visible = ViewSYSFieldsToolStripButton.Checked
         Me.ParentDataGridView.Columns(1).Visible = ViewSYSFieldsToolStripButton.Checked
         Me.ParentDataGridView.Columns(2).Visible = ViewSYSFieldsToolStripButton.Checked
         Me.ParentDataGridView.Columns(3).Visible = ViewSYSFieldsToolStripButton.Checked
      End If
   End Sub

   Private Sub DataSetToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles DataSetToolStrip.ItemClicked

   End Sub

   Private Sub FilterParentToolStripButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles FilterParentToolStripButton.CheckedChanged
      'If Me.FilterParentToolStripButton.Checked Then
      '   Dim pTable As DataTable = Me.DataSet.Tables(Me.TableListToolStripComboBox.SelectedItem.ToString)
      '   Dim dv As New DataView(pTable)
      '   dv.RowFilter = ScraperLib.DataTableUtil.PID & " is not null"
      '   Me.ParentDataGridView.DataSource = dv

      '   Me.SplitContainer1.Panel2Collapsed = Not Me.ViewChildTableToolStripButton.Checked
      '   Me.FilterParentToolStripButton.Enabled = True
      '   Me.ChildDataGridView.DataMember = pTable.TableName & "." & pTable.ChildRelations(0).RelationName
      'End If
   End Sub

   Private Sub FilterParentToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterParentToolStripButton.Click

   End Sub

   Private Sub TableListToolStripComboBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableListToolStripComboBox.Click

   End Sub

   Private Sub ChildTableToolStripComboBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChildTableToolStripComboBox.Click

   End Sub
End Class
