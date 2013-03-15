Public Class ctlEditColumn
   Private _FieldDT As WizardDS.FieldDTDataTable
   Public Sub New(ByVal FieldDT As WizardDS.FieldDTDataTable)
      InitializeComponent()
      _FieldDT = FieldDT

      Me.DataGridView1.AutoGenerateColumns = False
      Me.DataGridView1.DataSource = _FieldDT

      Me.FieldName.DataPropertyName = "FieldName"
      Me.MaxChars.DataPropertyName = "MaxChars"
      Me.IsSaveData.DataPropertyName = "IsSaveData"
   End Sub

   Public Property TableName() As String
      Get
         Return Me.txtTableName.Text
      End Get
      Set(ByVal value As String)
         Me.txtTableName.Text = value
      End Set
   End Property

   Private Sub txtTableName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTableName.KeyPress
      'Restirct user to key numeric values, decimal point and control keys
      If Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
         e.Handled = True
      End If
   End Sub

   Private Sub RemoveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripMenuItem.Click
      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As WizardDS.FieldDTRow = rv.Row
            row.Delete()
         End If
      Next
   End Sub

   Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

   End Sub

   Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
      MsgBox(e.Exception.Message, MsgBoxStyle.OkOnly, "Error")
      e.Cancel = True
   End Sub
End Class
