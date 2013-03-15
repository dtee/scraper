Public Class CrawledDataControl

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

         If (value IsNot Nothing AndAlso value.Tables.Count > 0) Then
            Me.ChildDataGridView.DataSource = ds
            For Each tbl As DataTable In ds.Tables
               Me.TableListToolStripComboBox.Items.Add(tbl.TableName)
            Next

            If ds.Relations.Count = 0 Then
               Me.ViewChildTableToolStripButton.Enabled = False
               Me.ViewChildTableToolStripButton.Checked = False
               Me.SplitContainer1.Panel2Collapsed = True
            Else
               Me.ViewChildTableToolStripButton.Enabled = True
               Me.ViewChildTableToolStripButton.Checked = True
            End If

            If Me.TableListToolStripComboBox.Items.Count > 0 Then
               Me.TableListToolStripComboBox.SelectedIndex = 0
               Me.ParentDataGridView.DataMember = Me.TableListToolStripComboBox.SelectedItem
            End If

            Me.ParentDataGridView.Columns(0).Visible = False
            Me.ParentDataGridView.Columns(1).Visible = False

            If Me.ChildDataGridView.ColumnCount > 2 Then
               Me.ChildDataGridView.Columns(0).Visible = False
               Me.ChildDataGridView.Columns(1).Visible = False
            End If

            If value.Tables.Count = 1 Then
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

      ' If table have child table then:
      If pTable.ChildRelations.Count > 0 Then
         Me.SplitContainer1.Panel2Collapsed = Not Me.ViewChildTableToolStripButton.Checked
         Me.ChildDataGridView.DataMember = pTable.TableName & "." & pTable.ChildRelations(0).RelationName
      Else
         Me.SplitContainer1.Panel2Collapsed = True
      End If
   End Sub

   Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDatasetToolStripButton.Click
      Dim saveDiag As New SaveFileDialog
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
End Class
