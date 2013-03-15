Option Explicit On
Option Strict On

Imports System.Text
Imports System.Text.RegularExpressions
Imports ScraperLib.LCS
Imports System.Threading

Public Class CoreTagGenerator

#Region "Shared"
   Public Shared StartTagSize As Integer = 8
   Public Shared EndTagSize As Integer = 5

   Public Shared ParentTagLength As Integer = 20

   Public Shared StartBound As String = "<"
   Public Shared EndBound As String = ">"

   ''' <summary>
   ''' Max Same (Tag) Generation before moving on to find a better tag.
   ''' </summary>
   ''' <remarks></remarks>
   Public Shared ParentBoundMax As Integer = 1
   Public Shared TempBoundMax As Integer = 1

   ''' <summary>
   ''' Return the preferred Tag Pattern
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared ReadOnly Property PeferredTagPattern() As String
      Get
         Return CoreTagGenerator.StartBound & "[\w\W\s]*?" & CoreTagGenerator.EndBound
      End Get
   End Property
#End Region

   Private SampleDataDT As DataTable
   Private Text As String

   'Public TagGenInfo As New TagGenInfo
   ' Used at various place to determine at the index of last tag's origion
   Private _Index As Integer
   Private _DataLength As Integer        ' The index where last data row is found + last data length

   Public EndTempNodes As New LinkedList(Of TagNode)           ' Nodes at the end

   Private RootNode As TagNode               ' The root tag to begin the generation.
   Private _DataNode As TagNode               ' A node that will be the datatable. (use this to find the last bound)
   Private _LastFieldNode As TagNode

   Public ReadOnly Property LastFieldNode() As TagNode
      Get
         Return Me._LastFieldNode
      End Get
   End Property

   ''' <summary>
   ''' Create new using the following param. 
   ''' </summary>
   ''' <param name="text"></param>
   ''' <param name="dt"></param>
   ''' <remarks></remarks>
   Public Sub New(ByVal text As String, ByVal dt As DataTable, ByVal RootNode As TagNode)
      Me.Text = text
      Me.SampleDataDT = dt

      Me.RootNode = RootNode
   End Sub

   Public ReadOnly Property DataNode() As TagNode
      Get
         Return Me._DataNode
      End Get
   End Property

   ''' <summary>
   ''' Check the data user entered to see if it valid or not
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function IsValid() As Boolean
      Dim pattern() As String = generateFowardRegex(Me.SampleDataDT)
      Dim temptxt As String = Text
      IsValid = True

      Dim lastIndex As Integer = 0
      For i As Integer = 0 To pattern.GetUpperBound(0)
         Dim pat As String = Regex.Escape(Me.SampleDataDT.Rows(i)(0).ToString)

         ' Set row to error if can't be found
         Dim fwrMatch As Match = Regex.Match(temptxt, pat, RegexOptions.IgnorePatternWhitespace)
         If fwrMatch.Success Then
            temptxt = temptxt.Substring(fwrMatch.Groups(fwrMatch.Groups.Count - 1).Index)
         Else
            ' Look for every single row and set error.
            Me.SampleDataDT.Rows(i).RowError = "One of more of the data in the row could not be found in the sample text."
            IsValid = False
         End If
      Next
   End Function

   ''' <summary>
   ''' Where the first tag is found relative to the given text
   ''' </summary>
   ''' <value>Index of the first tag found relative to the given text</value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property Index() As Integer
      Get
         Return _Index
      End Get
   End Property

   ''' <summary>
   ''' Takes 2-d TagArray and converts into 1-d of LCS array of tagArray.columns length
   ''' 2-d tag array may contain any row whose string is empty/nothing.
   ''' </summary>
   ''' <param name="tagArray">2-d string array</param>
   ''' <returns>1-d LCSString Array</returns>
   ''' <remarks></remarks>
   Private Function FindLCS(ByVal tagArray(,) As String) As LCSString()
      Dim matchList() As LCSString     ' Total columns in the pattern
      ReDim matchList(tagArray.GetUpperBound(1))

      ' For each columns in the array, find LCS
      For j As Integer = 0 To tagArray.GetUpperBound(1)
         Dim temp As New LCS.LCSFinder

         If (tagArray.GetUpperBound(0) = 0) Then
            ' One data sample
            matchList(j) = Me.LCSCompare(tagArray(0, j), tagArray(0, j))
         Else
            ' Multiple Data
            For i As Integer = 1 To tagArray.GetUpperBound(0)
               'Console.WriteLine("Compare {0} : {1}", tagArray(i - 1, j), tagArray(i, j))
               temp.GetLCS(tagArray(i - 1, j), tagArray(i, j))

               If temp IsNot Nothing Then
                  If matchList(j) Is Nothing Then
                     matchList(j) = temp.xLCSString
                  Else
                     If (temp.xLCSString.Text.Length > matchList(j).Text.Length) Then
                        matchList(j) = temp.xLCSString
                     End If
                  End If
               End If
            Next
         End If
      Next

      Return matchList
   End Function

   ''' <summary>
   ''' Find the LCS of two string, return nothing if both string are nothing
   ''' </summary>
   ''' <param name="str1"></param>
   ''' <param name="str2"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function LCSCompare(ByVal str1 As String, ByVal str2 As String) As LCSString
      Dim t As New LCS.LCSFinder

      If str1 Is Nothing And str2 Is Nothing Then
         Return Nothing
      ElseIf str1 Is Nothing Then
         t.GetLCS(str2, str2)
      ElseIf str2 Is Nothing Then
         t.GetLCS(str1, str1)
      Else
         'Console.WriteLine("Compare {0} : {1}", str1, str2)
         t.GetLCS(str1, str2)
      End If

      Return t.xLCSString
   End Function

   ''' <summary>
   ''' Find the tags for given data row, the result of the fuction is 2-d array of string. (row.count rows by dt.fields + 1 column)
   ''' Example: User entered 2 rows, with 3 fields => (Generate 2x4 2-d string array)
   ''' </summary>
   ''' <returns>2-d array from given table</returns>
   ''' <remarks>Some row may contain nothing for string when the given row can not be found on the given text. Also, the end of 
   ''' first data row and the start of the second row (n, and n + 1) row's string is split/divided into two equal parts. First
   ''' half serve as end tag for first row (n) and second half serve as start tag for second row (n+1)!</remarks>
   Private Function FindTags() As String(,)
      ' generate regular expression
      Dim tagList(,) As String

      Dim pattern() As String = generateFowardRegex(Me.SampleDataDT)


      ReDim tagList(pattern.GetUpperBound(0), Me.SampleDataDT.Columns.Count)

      Dim temptxt As String = Text

      Dim revPattern() As String = generateReverseRegex(Me.SampleDataDT)
      For i As Integer = 0 To pattern.GetUpperBound(0)
         Dim fwrMatch As Match = Regex.Match(temptxt, pattern(i))

         ' Set row to error if can't be found
         If fwrMatch.Success Then
            Dim temp As String = fwrMatch.Value
            Dim m As Match = Regex.Match(temp, revPattern(i), RegexOptions.IgnorePatternWhitespace)

            ' We are using last group fro fwrMatch to get the right index of text position
            Dim lastGroup As Group = m.Groups(m.Groups.Count - 1)

            If (Me.Index = -1) Then
               Me._Index = m.Groups(0).Index + fwrMatch.Groups(0).Index
            End If

            ' Split the end, one for firstnode's end, and the rest for the second node's beginning
            ' Last group is changed to the revRegex Match here
            Dim splitEndSize As Integer = CInt(lastGroup.Value.Length - CoreTagGenerator.StartTagSize)

            For j As Integer = 1 To m.Groups.Count - 2
               tagList(i, j - 1) = m.Groups(j.ToString).ToString
            Next
            ' Last group gets the half of what it found.
            If (splitEndSize < CoreTagGenerator.StartTagSize) Then
               splitEndSize = CInt(lastGroup.Value.Length / 2)
            End If

            temptxt = temptxt.Substring(fwrMatch.Index + lastGroup.Index + splitEndSize)
            tagList(i, m.Groups.Count - 2) = lastGroup.Value.Substring(0, splitEndSize)

            If i <= pattern.GetUpperBound(0) Then
               Me._DataLength = Me._DataLength + fwrMatch.Value.Length
            End If
         End If
      Next

      Return tagList
   End Function

#Region "Regex Generation"
   ''' <summary>
   ''' Generate regular expression for Forward data matching
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function generateFowardRegex(ByVal dt As DataTable) As String()
      Dim pattern(SampleDataDT.Rows.Count - 1) As String

      For rowIndex As Integer = 0 To Me.SampleDataDT.Rows.Count - 1
         Dim row As DataRow = dt.Rows(rowIndex)

         If (rowIndex = 0) Then
            pattern(rowIndex) = "(?<1>[\w\W\s]{0," & StartTagSize & "})"
         Else
            pattern(rowIndex) = "(?<1>[\w\W\s]*?)"
         End If

         For j As Integer = 0 To dt.Columns.Count - 1
            Dim escapedPattern As String = Regex.Escape(row(j).ToString)

            If j = dt.Columns.Count - 1 And rowIndex = dt.Rows.Count - 1 Then
               ' The very last pattern
               pattern(rowIndex) &= escapedPattern & "(?<" & j + 2 & ">[\w\W\s]{0," & StartTagSize & "})"
            ElseIf j = dt.Columns.Count - 1 And rowIndex < dt.Rows.Count - 1 Then
               pattern(rowIndex) &= escapedPattern & "(?<" & j + 2 & ">[\w\W\s]*?)"

               ' Add the first data from next row.
               row = dt.Rows(rowIndex + 1)
               pattern(rowIndex) &= Regex.Escape(row(0).ToString)
            Else
               pattern(rowIndex) &= escapedPattern & "(?<" & j + 2 & ">[\w\W\s]*?)"
            End If
         Next
      Next
      Return pattern
   End Function

   ''' <summary>
   ''' Generate the regular expression for backward data matching. (To get the tightest match possible)
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function generateReverseRegex(ByVal dt As DataTable) As String()
      Dim pattern(Me.SampleDataDT.Rows.Count - 1) As String
      Dim StartIndex As Integer = 0

      For rowIndex As Integer = StartIndex To Me.SampleDataDT.Rows.Count - 1
         Dim row As DataRow = dt.Rows(rowIndex)

         If (rowIndex = StartIndex) Then
            pattern(rowIndex) = "(?<1>[\w\W\s]{0," & StartTagSize & "})"
         Else
            pattern(rowIndex) = "(?<1>[\w\W\s]*)"
         End If

         For j As Integer = 0 To dt.Columns.Count - 1
            Dim escapedPattern As String = Regex.Escape(row(j).ToString)

            If j = dt.Columns.Count - 1 And rowIndex = dt.Rows.Count - 1 Then
               ' The very last pattern
               pattern(rowIndex) &= escapedPattern & "(?<" & j + 2 & ">[\w\W\s]{0," & StartTagSize & "})"
            ElseIf j = dt.Columns.Count - 1 And rowIndex < dt.Rows.Count - 1 Then
               pattern(rowIndex) &= escapedPattern & "(?<" & j + 2 & ">[\w\W\s]*?)"

               ' Add the first data from next row.
               row = dt.Rows(rowIndex + 1)
               pattern(rowIndex) &= Regex.Escape(row(0).ToString)
            Else
               pattern(rowIndex) &= escapedPattern & "(?<" & j + 2 & ">[\w\W\s]*?)"

            End If

            'Console.WriteLine("Col: {0}", dt.Columns(j).ColumnName)
         Next
      Next
      Return pattern
   End Function

#End Region

   ''' <summary>
   ''' Reset all the global variuables
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub ResetGlobals()
      Me._Index = -1
      Me.EndTempNodes.Clear()
   End Sub

   Public Timeout As Integer = 100000

   Private autoEvent As New AutoResetEvent(False)
   Public Sub Generate()
      Dim starttime As Integer = System.Environment.TickCount
      autoEvent.Reset()

      Run()
      'Dim t As New System.Threading.Thread(AddressOf Run)
      't.Start()

      'If Not Me.IsValid Then
      '   Throw New Exception("All the given data must be found on text.")
      'End If

      'If Not (autoEvent.WaitOne(Me.Timeout, True)) Then
      '   t.Abort()
      '   Dim err As String = String.Format("Timeout at {0} seconds.", (Me.Timeout / 1000).ToString("0"))
      '   Throw New Exception(err)
      'End If


      ' Time how long it takes to generate
      Dim genTime As New TimeSpan((System.Environment.TickCount - starttime) * 10000)
      Console.WriteLine("Total Time to Generate: ", genTime)
   End Sub

   ''' <summary>
   ''' Called after Generate, this function expects a "Last data row"
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub GenerateEndTag(ByVal text As String, ByVal goodStr As String, ByVal badStr As String, ByVal badStr2 As String)
      Dim badTags As LinkedList(Of String) = Me.BuildTagTable(badStr, False)
      Dim goodTags As LinkedList(Of String) = Me.BuildTagTable(goodStr, False)

      For Each badTag As String In badTags
         If goodTags.Contains(badTag) Then goodTags.Remove(badTag)
      Next

      badTags = Me.BuildTagTable(badStr2, False)
      For Each badTag As String In badTags
         If goodTags.Contains(badTag) Then goodTags.Remove(badTag)
      Next

      If goodTags.Count = 0 Then
         Throw New Exception("Unable to find a good.")
      End If

      ' Want the tighest bound, so, pick the last good tag
      For Each goodTag As String In goodTags
         Me.DataNode.Row.EndTag = goodTag

         Dim m As MatchCollection = Regex.Matches(goodStr, Regex.Escape(goodTag))
         If m.Count = 1 Then
            Me.DataNode.Row.EndTag = goodTag
            Exit For
         End If
      Next
   End Sub

   ''' <summary>
   ''' 1.) get the tag array.
   ''' 2.) Convert tag into 1d array of LCS (array.lenght = tagArray.columns)
   ''' 3.) Use the LCS list and generate the (possible) temp tags lurking in between.
   ''' </summary>
   ''' <remarks>
   ''' This function assume that IsValid is called and all the data in the sample datatable can be found 
   ''' in the given text
   ''' </remarks>
   Private Sub Run()
      ResetGlobals()

      ' 1.) Get the tag array
      Dim tagArray(,) As String = Me.FindTags()

      ' 2.) Convert tag array into 1-d array of LCS
      Dim matchList() As LCSString = Me.FindLCS(tagArray)

      ' Search thought the list, if any lcs string is "", then can't generate
      For j As Integer = 0 To matchList.GetUpperBound(0)
         ' Each tag must have some start!
         If (matchList(j).LCSMatchList.Count = 0) Then
            Throw New Exception("Some data have no determinable bound between them.")
         End If
      Next

      ' Set up the table name
      'Me.RootNode.TagName = "RootNode" & Me.RootNode.Index

      ' =====================================================================================
      ' Every match list have at least one LCS
      ' Search thought the match list for anything with mutiple lcs ( last two doesn't matter)
      For j As Integer = 1 To matchList.GetUpperBound(0)
         BuildTag(matchList(j - 1), matchList(j), j - 1, (j = matchList.GetUpperBound(0)))
      Next

      ' Index is not accurate: doesn't start from true startag index - probably fine
      Dim body As String = Me.Text.Substring(0, Me._Index)

      If Me.SampleDataDT.Rows.Count >= 2 Then
         Me._Index = FindEndTempNodePlacement(body)
      End If
      Dim FirstFieldNode As TagNode = Me.RootNode.FirstNode

      ' 4.) Generate parent tags
      body = Me.Text.Substring(0, Me._Index)

      ' LCS Match list pattern was used in the previous version of TagGenerator
      ' It is being kept here incase we want to implement multi page TagGenerator... (will
      '  probably use useless for multi page also... guess i am just lazy to change)
      Dim LCSMatchList As LinkedList(Of LCSMatchInfo)
      LCSMatchList = New LinkedList(Of LCSMatchInfo)

      Dim LcsInfo As New LCSMatchInfo
      LcsInfo.text = body
      LcsInfo.Start = 0
      LcsInfo.Stop = body.Length - 1

      LCSMatchList.AddFirst(LcsInfo)

      ' Generate Parent Nodes
      GenerateParents(LCSMatchList, Me.RootNode)

      Me._DataNode = FirstFieldNode.ParentTagNode                        'Now we have the right datanode
      Me._DataNode.Row.TagName = Me.SampleDataDT.TableName

      autoEvent.Set()         ' Signal finished
   End Sub

#Region "Inner Core Generation"
   ''' <summary>
   ''' Find the correct placement for the temp nodes at the end and place them at the right place!
   ''' </summary>
   ''' <param name="body">text(0-FirstNode.StartTag.Index)</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function FindEndTempNodePlacement(ByVal body As String) As Integer
      Dim nList As LinkedList(Of TagNode) = Me.EndTempNodes

      ' 1.) Generate Regex given the temp EndTagNodes
      Dim temp, pTemp As System.Collections.Generic.LinkedListNode(Of TagNode)
      Dim tNode As TagNode

      Dim NonEndNodePattern As String = ""
      For Each node As TagNode In Me.RootNode.TagNodeList
         NonEndNodePattern &= String.Format("{0}{1}{2}{3}", Regex.Escape(node.Row.StartTag), _
            "[\w\W\s]*?", Regex.Escape(node.Row.EndTag), "[\w\W\s]*?")
      Next

      temp = nList.First
      While temp IsNot Nothing
         Dim pattern As String = ""

         ' Look for middle pattern
         pTemp = temp
         While pTemp IsNot Nothing
            tNode = pTemp.Value
            pattern &= String.Format("{0}{1}{2}{3}", Regex.Escape(tNode.Row.StartTag), _
               "[\w\W\s]*?", Regex.Escape(tNode.Row.EndTag), "[\w\W\s]*?")

            pTemp = pTemp.Next
         End While

         Dim regexMatch As Match = Regex.Match(body, pattern, RegexOptions.RightToLeft)

         If (regexMatch.Success) Then
            ' Look for data in the body text
            Dim DataBody As String = Me.Text.Substring(regexMatch.Index, Me._DataLength + regexMatch.Length)

            Dim DataPattern() As String = Me.generateFowardRegex(Me.SampleDataDT)
            Dim isDataFound As Boolean = True
            Dim mc As MatchCollection = Regex.Matches(DataBody, pattern)

            'For Each m As Match In mc
            '   Console.WriteLine(m.Value)
            'Next

            ' The newly moved tag is able to scrape the orginal data!
            If mc.Count = Me.SampleDataDT.Rows.Count Then
               ' ..... tbd
            End If

            pTemp = temp
            While pTemp IsNot Nothing
               tNode = pTemp.Value
               tNode.MoveNode(0)
               pTemp = pTemp.Next
            End While

            Return regexMatch.Index
            Exit Function
         End If

         temp = temp.Next
      End While

      Return body.Length - 1
   End Function

   ''' <summary>
   ''' Build Tag using the data given. This function call createTemptags which fill in the
   ''' missing tags in the middle.
   ''' </summary>
   ''' <param name="firstTag">First LCS String</param>
   ''' <param name="secondTag">LCS String followed by the first.</param>
   ''' <remarks></remarks>
   Private Sub BuildTag(ByVal firstTag As LCSString, ByVal secondTag As LCSString, ByVal index As Integer, ByVal isLast As Boolean)
      Dim tagStart As String = firstTag.Text
      If firstTag.LCSMatchList.Count > 0 Then
         tagStart = firstTag.LCSMatchList.Last.Value.Text
      End If

      Dim endInfo As LCSMatchInfo = secondTag.LCSMatchList.First.Value

      ' In case of only one char between two bound, first one to have no end tag
      Dim EndTagLength As Integer = CoreTagGenerator.EndTagSize
      If (endInfo.Text.Length < EndTagLength) Then
         If isLast Then
            EndTagLength = CInt(Math.Ceiling(endInfo.Text.Length / 2))
         Else
            EndTagLength = CInt(Math.Floor(endInfo.Text.Length / 2))
         End If
      End If

      Dim tagEnd As String = endInfo.Text.Substring(0, EndTagLength)
      endInfo.Text = endInfo.Text.Substring(EndTagLength)
      endInfo.Start += CoreTagGenerator.EndTagSize

      Dim mList As LinkedList(Of LCSMatchInfo) = secondTag.LCSMatchList

      ' Build Table Node

      Dim t As TagNode = Me.RootNode.NewNode
      t.Row.TagName = Me.SampleDataDT.Columns(index).ColumnName
      t.Row.StartTag = Me.CleanTag(tagStart, True)
      t.Row.EndTag = Me.CleanTag(tagEnd, False)
      t.IsSaveData = True

      If isLast Then Me._LastFieldNode = t

      ' Add to endTaglist if index = dt.column.count
      ' Last tags have special meaning, some could go infront of the firstnode or behind.
      t.Row.isReverseSearch = CreateTempTags(mList, tagStart, (index = Me.SampleDataDT.Columns.Count - 1))
      t.Row.isReverseSearch = True            ' No harm in making it true all the time, is there?
   End Sub

   ''' <summary>
   ''' Create Temp Tag, (Non saving tags between the two saving tags.) This function 
   ''' should work very similar to creating parent nodes - we are not moving temp nodes  as parent!
   ''' </summary>
   ''' <param name="mList">LCS match list between first tag and and second</param>
   ''' <param name="startTag">SStart tag's string</param>
   ''' <param name="isLast">Temp node created is the last tem node which require tag lib to fix position.</param>
   ''' <returns>True - If save tag before the generated tag node should be Reverse Search. </returns>
   ''' <remarks></remarks>
   Private Function CreateTempTags(ByVal mList As LinkedList(Of LCSMatchInfo), ByVal startTag As String, ByVal isLast As Boolean) As Boolean
      Dim totalCount As Integer = 0
      Dim t As TagNode = Nothing

      ' Improvements: Divide up lastmatch's first node into two part or 3
      Dim temp As System.Collections.Generic.LinkedListNode(Of LCSMatchInfo) = mList.First
      Dim tagList As New List(Of String)

      ' mList is Size 0, no tags to create - this should never happen...
      If temp Is Nothing Then
         Return True
      End If

      ' For each LCS mach info, chop them into useable tag list 
      ' Ex: |(aTag) (starttag) (aTag) (starttag) | (aTag) | (startTag) (aTag)|
      While temp IsNot Nothing
         Dim m As LCSMatchInfo = temp.Value
         Dim str As String = m.Text
         Dim regexMatches As MatchCollection = Regex.Matches(str, Regex.Escape(startTag))

         ' Add First
         Dim lastIndex As Integer = 0
         For Each regexMatch As Match In regexMatches
            ' Lets get a new start Tag
            tagList.Add(str.Substring(lastIndex, regexMatch.Index - lastIndex))
            tagList.Add(startTag)
            lastIndex = regexMatch.Index + regexMatch.Length
         Next

         If (lastIndex < str.Length - 1) Then
            tagList.Add(str.Substring(lastIndex, str.Length - lastIndex))
         End If

         temp = temp.Next
      End While

      'mList.Clear()
      ' Add taglist item to lcslist

      ' Tag list contains a list of tags to be used.
      For Each tagStr As String In tagList
         Dim l As New LCSMatchInfo
         l.Text = tagStr
         mList.AddLast(l)
         If (tagStr = startTag) Then
            If (t Is Nothing) Then
               ' Add this one tag
               t = Me.RootNode.NewNode
               t.Row.TagName = "TempTag" & t.Row.OrderNumber
               t.Row.StartTag = Me.CleanTag(startTag, True)
               t.IsSaveData = False
            Else
               ' Last str is also tag str! lets leave it alone
            End If
         Else
            If (t IsNot Nothing) Then
               t.Row.EndTag = Me.CleanTag(t.Row.EndTag, False)
               If t.Row.EndTag.Length > CoreTagGenerator.EndTagSize Then
                  t.Row.EndTag = tagStr.Substring(0, CoreTagGenerator.EndTagSize)
               End If
               t.Row.EndTag = Me.CleanTag(t.Row.EndTag, False)
               If isLast Then          ' On last add to the last list
                  Me.EndTempNodes.AddLast(t)
               End If

               t = Nothing
            End If
         End If
      Next

      ' Case of where start tag is present in second to the last
      If (t IsNot Nothing) Then
         ' Remove t, we can never find end tag for it. - the Data node must do reverse search.
         t.Delete()
         Return True
      Else
         Return False
      End If
   End Function

#End Region

   ''' <summary>
   ''' Take a possible tag tree and clean it up: Make sure the start and end tag with the bound text if possible.
   ''' </summary>
   ''' <param name="OldTag"></param>
   ''' <param name="isStart"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function CleanTag(ByVal OldTag As String, ByVal isStart As Boolean) As String
      Dim m As Match
      Dim pattern As String = "[\w\W\s]*"

      If isStart Then
         pattern = Regex.Escape(CoreTagGenerator.StartBound) & pattern
         m = Regex.Match(OldTag, pattern)
      Else
         pattern &= Regex.Escape(CoreTagGenerator.EndBound)
         m = Regex.Match(OldTag, pattern, RegexOptions.RightToLeft)
      End If

      If m.Success Then
         Return m.Value
      End If

      Return OldTag
   End Function

#Region "Parent Tag Generation"
   ''' <summary>
   ''' Assuming hash table is made
   ''' </summary>
   ''' <param name="matchList"></param>
   ''' <param name="aTagNode"></param>
   ''' <remarks></remarks>
   Private Sub GenerateParents(ByVal matchList As LinkedList(Of LCSMatchInfo), ByVal aTagNode As TagNode)
      Dim newList As New LinkedList(Of LCSMatchInfo)
      Dim startTag As String = aTagNode.FirstNode.Row.StartTag
      Dim IsMatch As Boolean = False
      Dim temp As LinkedListNode(Of LCSMatchInfo) = matchList.Last

      ' Navigate thought match list: 
      'Trim to the next Start starttag found (Searching backward from the startTag)
      While temp IsNot Nothing
         newList.AddLast(temp.Value)

         'Console.WriteLine(temp.Value.text)
         Dim regexMatch As Match = Regex.Match(temp.Value.text, Regex.Escape(startTag), RegexOptions.RightToLeft)
         If (regexMatch.Success) Then
            Dim l As New LCSMatchInfo
            l.text = temp.Value.text.Substring(0, regexMatch.Index)

            temp.Value.text = temp.Value.text.Substring(regexMatch.Index)

            ' Change the information in the match list
            matchList.RemoveLast()
            matchList.AddLast(l)
            IsMatch = True
            Exit While
         End If

         temp = temp.Previous
         matchList.RemoveLast()
      End While

      If Not IsMatch Then
         ' Start tag is not found in the text left, don't need to look for a new start tag
         Exit Sub
      End If

      Dim MinCount As Byte = Byte.MaxValue
      Dim goodTag As String = startTag          ' Start Tag is the candidate for now

      For Each mInfo As LCSMatchInfo In newList
         ' tagList - Contains a list of possible Tags to use
         Dim possibleTagList As LinkedList(Of String) = Me.BuildTagTable(mInfo.Text)

         For Each str As String In possibleTagList
            Dim count As Integer = Me.MatchCount(matchList, str)
            If count <= MinCount Then
               goodTag = str
               MinCount = CByte(count)
            End If
            If MinCount = 0 Then Exit For
         Next
         If MinCount = 0 Then Exit For
      Next

      If MinCount = Byte.MaxValue Then
         Throw New Exception("Error, Current text would cause too much temp tags")
         Exit Sub
      End If

      If MinCount < CoreTagGenerator.ParentBoundMax Then
         GeneratePNodes(MinCount + 1, aTagNode, goodTag)
      Else
         ' Create one start node and do the process again
         GeneratePNodes(1, aTagNode, goodTag)
         GenerateParents(matchList, aTagNode)
      End If
   End Sub

   ''' <summary>
   ''' Return total Count found with in the string
   ''' </summary>
   ''' <param name="matchList"></param>
   ''' <param name="str"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function MatchCount(ByVal matchList As LinkedList(Of LCSMatchInfo), ByVal str As String) As Integer
      Dim count As Integer = 0
      For Each m As LCSMatchInfo In matchList
         count += Regex.Matches(m.text, Regex.Escape(str)).Count
      Next

      Return count
   End Function

   ''' <summary>
   ''' Generate Parent Nodes
   ''' </summary>
   ''' <param name="count"></param>
   ''' <param name="node"></param>
   ''' <param name="startTag"></param>
   ''' <remarks></remarks>
   Private Sub GeneratePNodes(ByVal count As Integer, ByVal node As TagNode, ByVal startTag As String)
      ' Create Nodes for goodTag
      Dim newParentNode As TagNode = node

      For i As Integer = 0 To count - 1
         newParentNode = node.NewNode
         newParentNode.Row.TagName = "TempParentNode"
         newParentNode.Row.StartTag = startTag
      Next

      ' Move parent node's children into the leaf
      While (node.TagNodeList.Count > 1)
         Dim childNode As TagNode = node.TagNodeList(0)
         childNode.ParentTagNode = newParentNode               ' Move node under pNode
      End While
   End Sub

   ''' <summary>
   ''' Build Tag tree of given a text. (split it into string of x length)
   ''' </summary>
   ''' <param name="bodyText"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function BuildTagTable(ByVal bodyText As String, Optional ByVal isQueue As Boolean = True) As LinkedList(Of String)
      ' Narrow Tags to the xml elements
      Dim XmlMC As MatchCollection = Regex.Matches(bodyText, "<[\w\W\s]{1,180}?>")
      Dim MaxPossibleTags As Integer = 50
      Dim tList As New LinkedList(Of String)

      'Console.WriteLine("===========================")
      If XmlMC.Count > 0 Then
         ' Narrow the tags to group of words, inbetween two space.
         For Each m As Match In XmlMC
            ' Add front and back of xml
            FindWordGroups(m.Value, MaxPossibleTags, tList, isQueue)
            If tList.Count > MaxPossibleTags Then
               Exit For
            End If
         Next
      Else
         ' Weird.. no xml tags, find group of words
         FindWordGroups(bodyText, 200, tList, isQueue)
      End If


      ' No word groups, must be a small text, or big chunk of no space and no xml text
      If tList.Count = 0 Then
         For i As Integer = 0 To bodyText.Length - CoreTagGenerator.ParentTagLength - 1
            If isQueue Then
               tList.AddLast(bodyText.Substring(i, CoreTagGenerator.ParentTagLength))
            Else
               tList.AddFirst(bodyText.Substring(i, CoreTagGenerator.ParentTagLength))
            End If
            If tList.Count > MaxPossibleTags Then Exit For
         Next
      End If

      Return tList
   End Function

   Private Sub FindWordGroups(ByVal str As String, ByVal max As Integer, ByVal tlist As LinkedList(Of String), Optional ByVal isQueue As Boolean = True)
      'Dim WordMC As MatchCollection = Regex.Matches(str, "(^<[\w\W]{1,30}?(?= ))|(?<= )([\w\W]{1,30})|[\w\W\s]{1,30}?$")
      Dim WordMC As MatchCollection = Regex.Matches(str, "(^<[\w\W]{1,30}?(?= ))")

      'Console.WriteLine(str)
      'Console.WriteLine("==========")
      For Each m As Match In WordMC
         'Console.WriteLine(m.Value)
         If isQueue Then
            tlist.AddFirst(m.Value)
         Else
            tlist.AddLast(m.Value)
         End If
         If tlist.Count > max Then Exit For
      Next
   End Sub
#End Region
End Class