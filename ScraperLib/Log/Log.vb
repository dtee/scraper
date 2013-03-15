Imports System.Diagnostics.Debugger

Public Class Log
   Private _type As Type
   Private isEnabled As Boolean = True

   Public Sub New(ByVal _type As Type, ByVal isEnabled As Boolean)
      Me._type = _type
      Me.isEnabled = isEnabled
   End Sub

   Public Sub Debug(ByVal str As String)
      printHeader("DEBUG ", str)
   End Sub

   Public Sub [Error](ByVal str As String)
      printHeader("ERROR ", str)
   End Sub

   Public Sub Warn(ByVal str As String)
      printHeader("WARN ", str)
   End Sub

   Public Sub Info(ByVal str As String)
      printHeader("INFO ", str)
   End Sub

   Private Sub printHeader(ByVal warnType As String, ByVal str As String)
      If Not isEnabled Then Exit Sub

      Console.Write(Now.ToString("hh:mm:ss,fff") & ControlChars.Tab & _type.Name & "(" & warnType & ") : ")        ' & Now.ToString
      Console.WriteLine(str)
   End Sub

End Class


