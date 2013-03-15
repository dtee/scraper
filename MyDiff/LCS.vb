Public Class LCS
   Dim x As String
   Dim y As String

   Dim c As Integer(,)
   Private Sub calculateLCS()
      ReDim c(x.Length, y.Length)

      For i As Integer = 1 To x.Length
         For j As Integer = 1 To y.Length
            If (x(i - 1) = y(j - 1)) Then
               c(i, j) = c(i - 1, j - 1) + 1
            Else
               c(i, j) = Math.Max(c(i, j - 1), c(i - 1, j))
            End If

         Next
      Next
   End Sub

   Private Function BackTrack(i as Integer, j as Integer ) As String
      If i = 0 Or j = 0 Then
         Return "[]"
      ElseIf x(i - 1) = y(j - 1) Then
         ' Match found
         Return BackTrack(i - 1, j - 1) & x(i - 1)
      Else
         If (c(i, j - 1) > c(i - 1, j)) Then
            Return BackTrack(i, j - 1)
         Else
            Return BackTrack(i - 1, j)
         End If
      End If
   End Function

   Public Sub compare(ByVal str As String, ByVal str2 As String)
      x = str
      y = str2
      If (x.Length > 4096) Then Me.x = x.Substring(0, 4096)
      If (y.Length > 4096) Then Me.y = y.Substring(0, 4096)
      Me.calculateLCS()
      Console.WriteLine(Me.BackTrack(x.Length, y.Length))
   End Sub

   Public Shared Singleton As New LCS
End Class
