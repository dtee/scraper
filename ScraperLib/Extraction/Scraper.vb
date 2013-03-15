Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Scraper
   Private _TagTree As TagTree
   Private _Text As String
   Private _WebUrl As String        ' Change this to Url
   Private autoEvent As New AutoResetEvent(False)
   Private _ScrapeTime As TimeSpan
   Private _UrlRow As ScraperDB.UrlRow

   Public ReadOnly Property ScrapeTime() As TimeSpan
      Get
         Return _ScrapeTime
      End Get
   End Property

   Public Sub Scrape(ByVal context As String, ByVal urlRow As ScraperDB.UrlRow, ByVal TagTree As TagTree)
      _UrlRow = urlRow
      Scrape(context, Me._UrlRow.UrlLink, TagTree)
   End Sub

   Public Sub Scrape(ByVal context As String, ByVal url As String, ByVal TagTree As TagTree)
      Me._WebUrl = url
      Me._Text = context
      Me._TagTree = TagTree

      Me._TagTree.ClearData()

      Dim rootNode As TagNode = Me._TagTree.RootNode

      If Me._Text = "" Or Me._Text Is Nothing Then
         Exit Sub
      End If

      ' PID does not matter for root node anyway, could be anything.
      rootNode.NewFieldData(Me._Text, 0, Me._Text.Length - 1)

      Dim starttime As Integer = System.Environment.TickCount
      autoEvent.Reset()
      Dim t As New System.Threading.Thread(AddressOf DoScrape)
      t.Start()

      If Not (autoEvent.WaitOne(Me.ScrapeTimeout, True)) Then
         t.Abort()
         Dim err As String = String.Format("Scrape Timedout at {0} seconds.", (Me.ScrapeTimeout / 1000).ToString("0"))
         Throw New Exception(err)
      End If

      'DoScrape()

      ' Time how long it takes to scrape
      Me._ScrapeTime = New TimeSpan((System.Environment.TickCount - starttime) * 10000)
      _UrlRow = Nothing
   End Sub

   Public ScrapeTimeout As Integer = 10000
   Private Sub DoScrape()
      Try
         ' Recursive Scrape Algorithm - This can easily be converted to a loop.
         Scrape(Me._TagTree.RootNode)
      Catch ex As ThreadAbortException
         Console.WriteLine("Thread aborted")
      Finally
         ' Raise an event
         autoEvent.Set()
      End Try
   End Sub

   ''' <summary>
   ''' Scrape given aNode - Performs Breath First Recursion search.
   ''' </summary>
   ''' <param name="aScraperNode"></param>
   ''' <remarks></remarks>
   Private Sub Scrape(ByVal aScraperNode As TagNode)
      If Not aScraperNode.IsParent Then
         Exit Sub
      End If

      ' LOOP THOUGHT EACH MAIN DATA - (Data list in the current row)
      For Each row As ScraperTempDS.FieldDTRow In aScraperNode.FieldDT.Rows
         Dim mainStr As String = row.Data   ' Can be changed to row(2)

         ' LOOP THOUGHT EACH REGEX!
         Dim RegexStr As String = aScraperNode.ScraperRegexCapture
         'Console.WriteLine("Regex str: " & RegexStr)

         If (RegexStr Is Nothing Or mainStr Is Nothing) Then
            Exit For
         End If

         'scrape the data	
         Dim Matches As MatchCollection = Regex.Matches(mainStr, RegexStr, RegexOptions.Multiline)

         'loop through all matches filling out the table as you go	
         Dim i As Integer = 0
         For Each match As System.Text.RegularExpressions.Match In Matches
            ' Do reverse search on the match - BAD IDEA... but why?!!!!!!
            'Dim m As Match = Regex.Match(match.Value, RegexStr, RegexOptions.Multiline And RegexOptions.RightToLeft)
            SaveScrapedData(aScraperNode, match, row)

            If i > 2000 Then
               Exit For
            End If
         Next
      Next

      'EVERY tag under ROOT is now scraped, SCRAPE BELOW THOSE TAGS
      For Each node As TagNode In aScraperNode.TagNodeList
         Scrape(node)
      Next
   End Sub

   ''' <summary>
   ''' Takes aNode, match result (contains Group which references to children nodes of the given node), 
   ''' and the ParentID of the previous generated data row, for data referencing.
   ''' </summary>
   ''' <param name="aScraperNode">Node where match is pereformed</param>
   ''' <param name="match">Result match of Matches</param>
   ''' <param name="PRow">Datarow's ID</param>
   ''' <remarks></remarks>
   Private Sub SaveScrapedData(ByVal aScraperNode As TagNode, ByVal match As Match, ByVal PRow As ScraperTempDS.FieldDTRow)
      Dim row As DataRow = Nothing

      ' A new data row.
      If aScraperNode.DataDT IsNot Nothing Then
         row = aScraperNode.DataDT.NewRow
         aScraperNode.DataDT.Rows.Add(row)         ' This will generate rowID
      End If

      For Each node As TagNode In aScraperNode.TagNodeList
         Dim body As Group = match.Groups(node.ScrapeTagID)                   ' Data Group
         Dim startTag As Group = match.Groups(node.ScrapeTagID & "s")         ' Start Group
         Dim endTag As Group = match.Groups(node.ScrapeTagID & "e")           ' End Group

         Dim data As String
         Dim startIndex, dataIndex, endIndex, endLength As Integer

         ' For Text Coloring - Store the location of the place found Matched
         startIndex = PRow.DataTagIndex + startTag.Index
         If startIndex = 0 Then
            startIndex = match.Index
         End If

         ' ReverseSearch
         If (node.Row.isReverseSearch) Then
            data = startTag.Value & body.Value & endTag.Value
            Dim m As Match = Regex.Match(data, node.ScraperReverseRegexCapture, RegexOptions.RightToLeft)

            If m.Success Then
               body = m.Groups(node.ScrapeTagID)
               startTag = m.Groups(node.ScrapeTagID & "s")
               endTag = m.Groups(node.ScrapeTagID & "e")
               startIndex = startTag.Index + startIndex
            End If
         End If

         dataIndex = startIndex + startTag.Length
         endIndex = dataIndex + body.Length
         endLength = endTag.Length

         data = body.Value
         If node.Row.IsAppendStartTag Then
            data = startTag.Value & data
            dataIndex = startIndex
         End If

         If node.Row.IsAppendEndTag Then
            data = data & endTag.Value
         End If

         If (node.Row.IsURL) Then
            data = getAbsoluteURL(data, Me._WebUrl)
         End If

         ' Dynamic code edit: TBD

         ' Save other Data into the table
         'Dim pid As Integer = PRow.PID
         Dim fieldRow As ScraperTempDS.FieldDTRow

         If aScraperNode.Row.IsDataTable AndAlso row IsNot Nothing Then
            fieldRow = node.NewFieldData(data, dataIndex, endIndex)                ' Set parent ID
            If row(DataTableUtil.ID) IsNot Nothing Then fieldRow.PID = row(DataTableUtil.ID)

            If aScraperNode.ParentDataTableTagNode IsNot Nothing Then
               Dim colName As String = aScraperNode.ParentDataTableTagNode.DataDT.TableName & DataTableUtil.POSTFIX
               row(colName) = PRow.PID  ' May need to try catch error ->

               fieldRow.PID = row(colName)
            End If
         Else
            fieldRow = node.NewFieldNoLinkData(data, dataIndex, endIndex)         ' Do not use Auto Generated ID
         End If

         fieldRow.StartTagIndex = startIndex
         fieldRow.EndTagLength = endLength

         ' If this node is saving data, then row must not be nothing!
         If node.Row.isSaveData Then
            ' Fix the data using a datarefiner
            If Me._CrawlProject IsNot Nothing And node.Row.DataTypeRow IsNot Nothing Then
               Dim dRefiner As DataRefinerAsm.DataRefiner = Me._CrawlProject.DataTypeManager.getDataType(node.Row.DataTypeRow).DataObject
               row(node.Row.TagName) = dRefiner.Refine(data)
            Else
               row(node.Row.TagName) = data
            End If

            ' Generate checksum
            CrawlHelper.GenerateChecksum(row)
         End If
      Next

      If row IsNot Nothing Then
         row(DataTableUtil.URL) = Me._WebUrl

         ' Add Url RowID
         If Me._UrlRow IsNot Nothing Then
            row(DataTableUtil.URLIDFK) = Me._UrlRow.UrlID
         End If
      End If
   End Sub

   Public _CrawlProject As CrawlProject

   ''' <summary>
   ''' Return Absolute url given relative.
   ''' </summary>
   ''' <param name="relUrl">Relative Url - Not Assumed valid Uri (will call escape)</param>
   ''' <param name="mainUrl">Base Absolute URL - assumed valid Uri</param>
   ''' <returns>Valid Absolute Url (On Error, return relative)</returns>
   ''' <remarks></remarks>
   Public Shared Function getAbsoluteURL(ByVal relUrl As String, ByVal mainUrl As String) As String
      Try

         Dim baseUri As Uri = New Uri(mainUrl)
         Dim absoluteUri As Uri = New Uri(baseUri, Uri.EscapeUriString(relUrl))
         'absoluteUri = New Uri(absoluteUri, Uri.EscapeDataString(absoluteUri.AbsolutePath))

         Return absoluteUri.ToString()
      Catch ex As Exception
         Return relUrl
      End Try
   End Function

   ''' <summary>
   ''' Standardize new line characters in the given content.
   ''' </summary>
   ''' <param name="content"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function StandardizeNewLine(ByVal content As String) As String
      If content Is Nothing Then
         Return ""
      End If

      content = System.Text.RegularExpressions.Regex.Replace(content, ControlChars.CrLf, ControlChars.Lf)
      content = System.Text.RegularExpressions.Regex.Replace(content, ControlChars.Cr, ControlChars.Lf)

      Return content
   End Function
End Class
