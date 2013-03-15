Imports System
Imports System.Diagnostics
Imports System.Collections.Generic

Namespace LCS
   ''' <summary>
   ''' Summary description for LCSFinder.
   ''' </summary>
   Public Class LCSFinder
      Public Shared Singleton As LCSFinder = New LCSFinder
      Private xList As List(Of LCSGroup)
      Private yList As List(Of LCSGroup)
      Dim x As String, y As String

      Public Sub New()
         MyBase.New()
      End Sub

      Public Function GetLCS(ByVal s As String, ByVal t As String) As String
         x = s
         y = t
         Dim str As String = FindLCS(x.ToCharArray, y.ToCharArray)
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
         Dim xGroup As LCSGroup = New LCSGroup
         Dim yGroup As LCSGroup = New LCSGroup

         xList = New List(Of LCSGroup)
         yList = New List(Of LCSGroup)

         i = m
         j = n
         While ((i > 0) OrElse (j > 0))
            If (backTracer(i, j) = BackTracking.UP_AND_LEFT) Then
               i = (i - 1)
               j = (j - 1)
               subseq = (list1(i) + subseq)
               If Not IsGroup Then
                  xGroup = New LCSGroup
                  xGroup.stop = i
                  yGroup = New LCSGroup
                  yGroup.stop = j
                  yList.Add(yGroup)
                  xList.Add(xGroup)
                  Console.WriteLine("")
                  IsGroup = True
               End If
               'Console.WriteLine(i & " " & list1(i) & " " & j)
            ElseIf (backTracer(i, j) = BackTracking.UP) Then
               i = (i - 1)
               If (IsGroup = True) Then
                  yGroup.start = j
                  xGroup.start = i
                  yGroup.str = y.Substring(yGroup.start, ((yGroup.stop - yGroup.start) + 1))
                  xGroup.str = x.Substring(xGroup.start, ((xGroup.stop - xGroup.start) + 1))
                  IsGroup = False
               End If
            ElseIf (backTracer(i, j) = BackTracking.LEFT) Then
               If (IsGroup = True) Then
                  yGroup.start = j
                  xGroup.start = i
                  yGroup.str = y.Substring(yGroup.start, ((yGroup.stop - yGroup.start) + 1))
                  xGroup.str = x.Substring(xGroup.start, ((xGroup.stop - xGroup.start) + 1))
                  IsGroup = False
               End If
               j = (j - 1)
            End If
         End While

         If (IsGroup = True) Then
            yGroup.start = 0
            xGroup.start = 0
            yGroup.str = y.Substring(yGroup.start, ((yGroup.stop - yGroup.start) + 1))
            xGroup.str = x.Substring(xGroup.start, ((xGroup.stop - xGroup.start) + 1))
            IsGroup = False
         End If

         findMaxiumSequence()
         printList()
         Return subseq
      End Function

      ''' <summary>
      ''' After you run this function, the list should be changed
      ''' </summary>
      ''' <remarks></remarks>
      Private Sub findMaxiumSequence()
         Dim num As String = ""
         For i As Integer = 0 To Me.yList.Count - 1
            num &= i
         Next

         Dim isFound As Boolean = False
         For i As Integer = 0 To Me.yList.Count - 2
            Dim groupLen As Integer = Me.yList.Count - 1 - i
            Console.Write("Group: " & ControlChars.Tab)

            For j As Integer = 0 To i
               'Console.Write(num.Substring(j, groupLen) & ControlChars.Tab)
               Dim str As String = "", tempGroup As String = ""
               For k As Integer = j To j + groupLen
                  Dim index As Integer = Integer.Parse(num(k))
                  str = "(" & yList(k).str & ")" & str
                  tempGroup = yList(k).str & tempGroup
               Next

               ' Look in the text for pattern.
               If (y.Contains(tempGroup) And x.Contains(tempGroup)) Then
                  For k As Integer = j To j + groupLen - 1
                     xList.RemoveAt(k)
                     yList.RemoveAt(k)
                  Next

                  xList(j).start = x.IndexOf(tempGroup)
                  yList(j).start = y.IndexOf(tempGroup)

                  xList(j).stop = xList(j).start + tempGroup.Length - 1
                  yList(j).stop = yList(j).start + tempGroup.Length - 1

                  xList(j).str = tempGroup
                  yList(j).str = tempGroup

                  'j += (groupLen + 1) ' don't have to do...list got smaller.
                  isFound = True
               End If
               Console.Write("[" & str & "]" & ControlChars.Tab)
            Next

            Console.WriteLine()
            If isFound Then Exit For
         Next
      End Sub

      Private Sub printList()
         Console.Write("XGroup: ")
         For Each g As LCSGroup In Me.xList
            Console.Write("(" & g.str & ")")
         Next
         Console.WriteLine()

         Console.Write("YGroup: ")
         For Each g As LCSGroup In Me.yList
            Console.Write("(" & g.str & ")")
         Next
         Console.WriteLine()
      End Sub

      Public Enum BackTracking
         NEITHER
         UP
         LEFT
         UP_AND_LEFT
      End Enum

      Class LCSGroup
         Public start As Integer
         Public [stop] As Integer
         Public str As String
      End Class

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