Namespace LCS
   ''' <summary>
   ''' Contain LCS Match and text information.
   ''' </summary>
   ''' <remarks></remarks>
   Public Class LCSString
      Public Sub New()
         LCSMatchList = New LinkedList(Of LCSMatchInfo)
      End Sub

      Public Text As String
      Public MatchedText As String
      Public LCSMatchList As Collections.Generic.LinkedList(Of LCSMatchInfo)
   End Class
End Namespace