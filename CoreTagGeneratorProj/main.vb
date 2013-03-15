Public Class main

   Public Shared Sub main()
      Dim dt As New DataTable
      dt.Columns.Add("ID", GetType(Integer))

      dt.Columns.Add("identifier1", GetType(String))
      dt.Columns.Add("identifier2", GetType(String))

      dt.Columns.Add("checksum1")
      dt.Columns.Add("checksum2")
      dt.Columns.Add("checksum3")

      dt.Constraints.Add("ID", dt.Columns(0), True)

      Dim ids() As DataColumn = New DataColumn() {dt.Columns(1), dt.Columns(2)}

      Dim uniqueCon As New UniqueConstraint("identifier", ids, False)

      dt.Constraints.Add("identifier", dt.Columns(0), False)
      dt.Constraints.Add(uniqueCon)
   End Sub
End Class
