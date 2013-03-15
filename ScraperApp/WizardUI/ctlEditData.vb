Public Class ctlEditData
   Private mDataDT As DataTable
   Public ReadOnly Property DataDT() As DataTable
      Get
         Return mDataDT
      End Get
   End Property

   'Private mDT As WizardDS.FieldDTDataTable
   Private _FieldTable As WizardDS.FieldDTDataTable
   Public Property FieldTable() As WizardDS.FieldDTDataTable
      Set(ByVal value As WizardDS.FieldDTDataTable)
         ' check dt
         mDataDT = New DataTable()

         For Each row As WizardDS.FieldDTRow In value.Rows
            mDataDT.Columns.Add(row.FieldName)
         Next

         Me.DataGridView1.DataSource = DataDT

         '' Adjust the colum width -> Based on text size

         Dim maxWidth As Integer = DataGridView1.Width

         For i As Integer = 0 To DataGridView1.Columns.Count - 1
            'DataGridView1.Columns(i).Width = CInt(maxWidth / DataGridView1.Columns.Count)
         Next

         _FieldTable = value
      End Set
      Get
         Return _FieldTable
      End Get
   End Property

End Class
