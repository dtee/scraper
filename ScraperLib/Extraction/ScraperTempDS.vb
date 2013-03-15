

Partial Public Class ScraperTempDS
   Partial Class FieldDTDataTable

      Private Sub FieldDTDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
         If (e.Column.ColumnName = Me.CheckSUMColumn.ColumnName) Then
            'Add user code here
         End If

      End Sub

   End Class

End Class
