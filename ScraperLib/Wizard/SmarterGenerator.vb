Imports System.Text.RegularExpressions

Public Class SmarterGenerator
   Private _Content As String
   Private _List As String
   Private _DataMap As Dictionary(Of Integer, String)
   Private _HtmlElement As Dictionary(Of Integer, String)
   Private _RootNode As TagNode

   Public Sub New(ByVal text As String, ByVal dt As DataTable, ByVal RootNode As TagNode)
      Me._Content = text
      Me._RootNode = RootNode

      For Each row As DataRow In dt.Rows
         ' Regex find
         For i As Integer = 0 To dt.Columns.Count - 1
            Dim mc As MatchCollection = Regex.Matches(Me._Content, Regex.Escape(row(i)))
            For Each m As Match In mc
               Me._DataMap.Add(m.Index, m.Value)
            Next
         Next
      Next

   End Sub
End Class
