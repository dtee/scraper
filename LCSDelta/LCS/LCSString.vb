''' <summary>
''' Contain LCS Match and text information.
''' </summary>
''' <remarks></remarks>
Public Class LCSString
   Public Text As String
   Public MatchedText As String
   Public LCSMatchList As Collections.Generic.LinkedList(Of LCSMatchInfo)
   Public LCSNotMatchList As Collections.Generic.LinkedList(Of LCSMatchInfo)
End Class