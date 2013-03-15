Imports Microsoft.VisualBasic
Imports System.Data
Public Class App

   Public Shared connStr As String = "Data Source=DAVID-PC\sqlexpress;Initial Catalog=ScraperDB;Integrated Security=True"
   Public Shared SqlConnection As New SqlClient.SqlConnection(App.connStr)
End Class


Public Class MyItems
   Private _index As Integer
   Public ReadOnly Property Index() As Integer
      Get
         Return _index
      End Get
   End Property

   Private _value As String
   Public ReadOnly Property Value() As String
      Get
         Return _value
      End Get
   End Property

   Public Sub New(ByVal i As Integer)
      Me._index = i
      Me._value = "Item " & i
   End Sub
End Class