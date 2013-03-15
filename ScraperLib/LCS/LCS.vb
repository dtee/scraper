Imports System
Imports System.Diagnostics
Imports System.Collections.Generic

Namespace LCS
   ''' <summary>
   ''' Summary description for LCSFinder.
   ''' </summary>
   Public Class LCSFinder
      Public Shared Singleton As LCSFinder = New LCSFinder
      Private xList As List(Of LCSMatchInfo)
      Private yList As List(Of LCSMatchInfo)
      Private x As String, y As String
      Public xLCSString As LCSString, yLCSString As LCSString

      Public Sub New()
         MyBase.New()
      End Sub

      Public Function GetLCS(ByVal s As String, ByVal t As String) As String
         If s Is Nothing Or t Is Nothing Then
            Return ""
         End If

         x = s
         y = t

         xLCSString = New LCSString
         xLCSString.Text = x

         yLCSString = New LCSString
         yLCSString.Text = y

         Dim str As String = FindLCS(x.ToCharArray, y.ToCharArray)

         yLCSString.MatchedText = str
         xLCSString.MatchedText = str

         For Each g As LCSMatchInfo In xList
            xLCSString.LCSMatchList.AddFirst(g)
         Next

         For Each g As LCSMatchInfo In yList
            yLCSString.LCSMatchList.AddFirst(g)
         Next
         Return str
      End Function

      Private Function ConsecutiveMeasure(ByVal k As Integer) As Integer
         Return k * k
      End Function

      Private Function FindLCS(ByVal list1() As Char, ByVal list2() As Char) As String
         Dim m As Integer = list1.Length
         Dim n As Integer = list2.Length
         Dim lcs As Integer(,), w As Integer(,)
         ReDim lcs(m + 1, n + 1)
         ReDim w(m + 1, n + 1)

         Dim backTracer As BackTracking(,)
         ReDim backTracer(m + 1, n + 1)

         Dim j As Integer = 0, i As Integer = 0

         For i = 0 To m
            lcs(i, 0) = 0
            backTracer(i, 0) = BackTracking.UP
         Next

         For j = 0 To n
            lcs(0, j) = 0
            backTracer(0, j) = BackTracking.LEFT
         Next

         For i = 1 To m
            For j = 1 To n
               If list1((i - 1)).Equals(list2((j - 1))) Then
                  Dim k As Integer = w((i - 1), (j - 1))
                  'lcs(i,j) = lcs(i-1,j-1) + 1;
                  lcs(i, j) = (lcs((i - 1), (j - 1)) + (ConsecutiveMeasure((k + 1)) - ConsecutiveMeasure(k)))
                  backTracer(i, j) = BackTracking.UP_AND_LEFT
                  w(i, j) = (k + 1)
               Else
                  lcs(i, j) = lcs((i - 1), (j - 1))
                  backTracer(i, j) = BackTracking.NEITHER
               End If
               If (lcs((i - 1), j) >= lcs(i, j)) Then
                  lcs(i, j) = lcs((i - 1), j)
                  backTracer(i, j) = BackTracking.UP
                  w(i, j) = 0
               End If
               If (lcs(i, (j - 1)) >= lcs(i, j)) Then
                  lcs(i, j) = lcs(i, (j - 1))
                  backTracer(i, j) = BackTracking.LEFT
                  w(i, j) = 0
               End If
            Next
         Next

         Dim subseq As String = ""
         Dim p As Integer = lcs(i, j)
         'trace the backtracking matrix.
         Dim IsGroup As Boolean = False
         Dim xGroup As LCSMatchInfo = New LCSMatchInfo
         Dim yGroup As LCSMatchInfo = New LCSMatchInfo

         xList = New List(Of LCSMatchInfo)
         yList = New List(Of LCSMatchInfo)

         i = m
         j = n
         While ((i > 0) OrElse (j > 0))
            If (backTracer(i, j) = BackTracking.UP_AND_LEFT) Then
               i = (i - 1)
               j = (j - 1)
               subseq = (list1(i) + subseq)
               If Not IsGroup Then
                  xGroup = New LCSMatchInfo
                  xGroup.stop = i
                  yGroup = New LCSMatchInfo
                  yGroup.stop = j
                  yList.Add(yGroup)
                  xList.Add(xGroup)
                  'Console.WriteLine("")
                  IsGroup = True
               End If
               'Console.WriteLine(i & " " & list1(i) & " " & j)
            ElseIf (backTracer(i, j) = BackTracking.UP) Then
               i = (i - 1)
               If (IsGroup = True) Then
                  yGroup.start = j
                  xGroup.start = i
                  yGroup.text = y.Substring(yGroup.start, ((yGroup.stop - yGroup.start) + 1))
                  xGroup.text = x.Substring(xGroup.start, ((xGroup.stop - xGroup.start) + 1))
                  IsGroup = False
               End If
            ElseIf (backTracer(i, j) = BackTracking.LEFT) Then
               If (IsGroup = True) Then
                  yGroup.start = j
                  xGroup.start = i
                  yGroup.Text = y.Substring(yGroup.Start, ((yGroup.Stop - yGroup.Start) + 1))
                  xGroup.Text = x.Substring(xGroup.Start, ((xGroup.Stop - xGroup.Start) + 1))
                  IsGroup = False
               End If
               j = (j - 1)
            End If
         End While

         If (IsGroup = True) Then
            yGroup.Start = 0
            xGroup.Start = 0
            yGroup.Text = y.Substring(yGroup.Start, ((yGroup.Stop - yGroup.Start) + 1))
            xGroup.Text = x.Substring(xGroup.Start, ((xGroup.Stop - xGroup.Start) + 1))
            IsGroup = False
         End If

         findMaxiumSequence()
         'printList()
         Return subseq
      End Function

      ''' <summary>
      ''' After you run this function, the list should be changed
      ''' </summary>
      ''' <remarks></remarks>
      Private Sub findMaxiumSequence()
         Dim isFound As Boolean = False
         For i As Integer = 0 To Me.yList.Count - 2
            Dim groupLen As Integer = Me.yList.Count - 1 - i
            'Console.Write("Group: " & ControlChars.Tab)

            For j As Integer = 0 To i
               Dim str As String = "", tempGroup As String = ""
               For k As Integer = j To Math.Min(j + groupLen, yList.Count - 1)
                  str = "(" & yList(k).Text & ")" & str
                  tempGroup = yList(k).Text & tempGroup
               Next

               If (j > i) Then Exit For

               ' Look in the text for pattern.
               Dim tempy As String = y.Substring(yList(j).Start)
               Dim tempx As String = x.Substring(xList(j).Start)

               If (tempy.Contains(tempGroup) And tempx.Contains(tempGroup)) Then
                  For k As Integer = j To Math.Min(j + groupLen - 1, yList.Count - 2)
                     xList.RemoveAt(k)
                     yList.RemoveAt(k)
                  Next

                  xList(j).Start = x.IndexOf(tempGroup)
                  yList(j).Start = y.IndexOf(tempGroup)

                  xList(j).Stop = xList(j).Start + tempGroup.Length - 1
                  yList(j).Stop = yList(j).Start + tempGroup.Length - 1

                  xList(j).Text = tempGroup
                  yList(j).Text = tempGroup

                  'j += (groupLen + 1) ' don't have to do...list got smaller.
                  i = Me.yList.Count - 1
                  isFound = True
               End If
               'Console.Write("[" & str & "]" & ControlChars.Tab)
            Next

            'Console.WriteLine()
            If isFound Then Exit For
         Next
      End Sub

      'Private Sub printList()
      '   Console.Write("XGroup: ")
      '   For Each g As LCSMatchInfo In Me.xList
      '      Console.Write("(" & g.text & ")")
      '   Next
      '   Console.WriteLine()

      '   Console.Write("YGroup: ")
      '   For Each g As LCSMatchInfo In Me.yList
      '      Console.Write("(" & g.text & ")")
      '   Next
      '   Console.WriteLine()
      'End Sub

      Private Enum BackTracking
         NEITHER
         UP
         LEFT
         UP_AND_LEFT
      End Enum

      Public Shared Sub main(ByVal arg As String())
         Dim str As String() = New String() { _
                              "AA BB CC DD EE", "AA BB DD CC EE", _
                              "BB AA BB CC DD", "CC AA BB DD EE", _
                              "BB AA BB BB CC"}

         Console.WriteLine("LCS: " & LCS.LCSFinder.Singleton.GetLCS(str(0), str(1)))
         Console.WriteLine("LCS: " & LCS.LCSFinder.Singleton.GetLCS(str(0), str(2)))
         Console.WriteLine("LCS: " & LCS.LCSFinder.Singleton.GetLCS(str(0), str(3)))
         Console.WriteLine("LCS: " & LCS.LCSFinder.Singleton.GetLCS(str(0), str(4)))

         str = New String() { _
                              "AA", _
                              "AA BB CC AA", "A BA AA BB A", _
                              "AB BB BA CA AA"}
         Console.WriteLine("LCS: " & LCS.LCSFinder.Singleton.GetLCS(str(0), str(1)))
         Console.WriteLine("LCS: " & LCS.LCSFinder.Singleton.GetLCS(str(0), str(2)))
         Console.WriteLine("LCS: " & LCS.LCSFinder.Singleton.GetLCS(str(0), str(3)))
      End Sub
   End Class
End Namespace