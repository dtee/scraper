Public Class DataTypeManager
   Private _dataTypeDT As ScraperDB.DataTypeDataTable
   Public Sub New(ByVal dataTypeDT As ScraperDB.DataTypeDataTable)
      Me._dataTypeDT = dataTypeDT
      _DataTypeList = New List(Of DataType)

      For Each row As ScraperDB.DataTypeRow In Me._dataTypeDT
         Dim newType As New DataType(row)
         _DataTypeList.Add(newType)
      Next

      If Me._dataTypeDT.Rows.Count = 0 Then
         NewDataType("DefaultDataRefiner", My.Resources.DefaultDataRefiner)
         NewDataType("NaturalNumberDataRefiner", My.Resources.NaturalNumberDataRefiner)
         NewDataType("MoneyDataRefiner", My.Resources.MoneyDataRefiner)
         NewDataType("DoubleDataRefiner", My.Resources.DoubleDataRefiner)
         NewDataType("TextDataRefiner", My.Resources.TextDataRefiner)
      End If
   End Sub

   Private _DataTypeList As List(Of DataType)

   Public ReadOnly Property DataTypeList() As List(Of DataType)
      Get
         Return _DataTypeList
      End Get
   End Property

   Public Function NewDataType(ByVal name As String, ByVal code As String) As DataType
      Dim row As ScraperDB.DataTypeRow = Me._dataTypeDT.NewRow

      row.DataTypeName = name
      row.DataTypeCode = code

      Me._dataTypeDT.Rows.Add(row)

      Dim newType As New DataType(row)
      _DataTypeList.Add(newType)

      Return newType
   End Function

   ''' <summary>
   ''' Get a data type given a row
   ''' </summary>
   ''' <param name="row"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getDataType(ByVal row As ScraperDB.DataTypeRow) As DataType
      For Each datatype As DataType In Me._DataTypeList
         If row Is datatype.Row Then
            Return datatype
         End If
      Next

      Return Nothing
   End Function
End Class
