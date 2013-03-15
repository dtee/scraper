Namespace LCS
   ''' <summary>
   ''' Contains matched informations: The starting index, ending index and the text matched
   ''' </summary>
   ''' <remarks></remarks>
   Public Class LCSMatchInfo
      ''' <summary>
      ''' The Start Index where the LCS is found
      ''' </summary>
      ''' <remarks></remarks>
      Public Start As Integer

      ''' <summary>
      ''' The End Index where the LCS is found
      ''' </summary>
      ''' <remarks></remarks>
      Public [Stop] As Integer

      ''' <summary>
      ''' The string for the LCS
      ''' </summary>
      ''' <remarks></remarks>
      Public Text As String
   End Class
End Namespace