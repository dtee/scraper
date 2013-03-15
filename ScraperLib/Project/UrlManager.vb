Public Class UrlManager
   Private Shared _log As New Log(GetType(UrlManager), False)

   Private _CrawlProj As CrawlProject
   Private _UrlDT As ScraperDB.UrlDataTable
   Private _ProjectUrlDT As ScraperDB.Project_UrlDataTable
   Private _UrlStatusDT As ScraperDB.UrlStatusDataTable

   Private _ToScrapeUrlView As DataView
   Private _ScrapedUrlView As DataView

   Public IsDeapthFirst As Boolean = True

   Public ReadOnly Property UrlDT() As ScraperDB.UrlDataTable
      Get
         Return Me._UrlDT
      End Get
   End Property

   Public Shared ReadOnly Property GetNow() As DateTime
      Get
         Return Now.ToUniversalTime
      End Get
   End Property

   Public Sub New(ByVal CrawlProj As CrawlProject)
      Me._CrawlProj = CrawlProj
      Me._UrlDT = CrawlProj.Dataset.Url
      Me._ProjectUrlDT = CrawlProj.Dataset.Project_Url
      Me._UrlStatusDT = CrawlProj.Dataset.UrlStatus

      _ToScrapeUrlView = New DataView(_UrlDT)
      _ToScrapeUrlView.RowFilter = Me._UrlDT.UrlStatusIDColumn.ColumnName & " = " & UrlStatus.Ready
      _ToScrapeUrlView.Sort = "IsPartialData ASC"

      _ScrapedUrlView = New DataView(_UrlDT)
      _ScrapedUrlView.RowFilter = Me._UrlDT.UrlStatusIDColumn.ColumnName & " = " & UrlStatus.Finished & " OR " & _
               Me._UrlDT.UrlStatusIDColumn.ColumnName & " = " & UrlStatus.Error

      If Me._UrlStatusDT.Rows.Count = 0 Then InitUrlStatusDT()
   End Sub

   Private Sub InitUrlStatusDT()
      Dim r As ScraperDB.UrlStatusRow
      r = _UrlStatusDT.NewUrlStatusRow
      r.UrlStatusID = UrlManager.UrlStatus.Assigned
      r.Name = "Assigned"
      _UrlStatusDT.AddUrlStatusRow(r)

      r = _UrlStatusDT.NewUrlStatusRow
      r.UrlStatusID = UrlManager.UrlStatus.Finished
      r.Name = "Finished"
      _UrlStatusDT.AddUrlStatusRow(r)

      r = _UrlStatusDT.NewUrlStatusRow
      r.UrlStatusID = UrlManager.UrlStatus.Error
      r.Name = "Error"
      _UrlStatusDT.AddUrlStatusRow(r)

      r = _UrlStatusDT.NewUrlStatusRow
      r.UrlStatusID = UrlManager.UrlStatus.Ready
      r.Name = "Ready"
      _UrlStatusDT.AddUrlStatusRow(r)
   End Sub

   Public ReadOnly Property UrlStatusDT() As ScraperDB.UrlStatusDataTable
      Get
         Return _UrlStatusDT
      End Get
   End Property

   Public ReadOnly Property TotalAssigned() As Integer
      Get
         Return Me.TotalUrl - Me.TotalToScrape - Me.TotalScraped
      End Get
   End Property

   Public ReadOnly Property TotalScraped() As Integer
      Get
         Return _ScrapedUrlView.Count
      End Get
   End Property

   ''' <summary>
   ''' Get the Projects related to the url
   ''' </summary>
   ''' <param name="Url"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getUrlMaps(ByVal Url As ScraperDB.UrlRow) As List(Of UrlMap)
      Dim UrlMaps As New List(Of UrlMap)

      ' Look thought the child Project row of URL row
      For Each ProjUrlRow As ScraperDB.ProjectUrlRow In Url.GetProject_UrlRows
         UrlMaps.Add(New UrlMap(ProjUrlRow, Me._CrawlProj))
      Next

      Return UrlMaps
   End Function

   ''' <summary>
   ''' Find a url given given a url and post data.
   ''' </summary>
   ''' <param name="UrlLink"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function findUrl(ByVal UrlLink As String, ByVal PostData As String) As ScraperDB.UrlRow
      Dim dv As New DataView(Me._UrlDT)
      dv.RowFilter = Me._UrlDT.UrlLinkColumn.ColumnName & " = '" & UrlLink & "' AND "
      dv.RowFilter &= Me._UrlDT.PostDataColumn.ColumnName & " = '" & PostData & "'"

      If dv.Count > 0 Then
         Return dv(0).Row
      End If

      Return Nothing
   End Function


   Public Function addUrl(ByVal url As String, ByVal postData As String, ByVal projectList As List(Of Project)) As ScraperDB.UrlRow
      If (Not Uri.IsWellFormedUriString(url, UriKind.Absolute) AndAlso projectList.Count = 0) Then
         _log.Info(url & " is not a well formed url.")
         Return Nothing
      End If

      Try
         Dim newRow As ScraperDB.UrlRow = Me._UrlDT.NewUrlRow

         newRow.UrlLink = url
         newRow.UrlStatusID = UrlStatus.Ready
         newRow.DateAdded = UrlManager.GetNow           ' All must be in UTC time
         newRow.UrlStatusID = UrlStatus.Ready           ' Set Status

         newRow.CrawlProjectRow = Me._CrawlProj.CrawlProjectRow         ' Set the belonging crawl project

         Me._UrlDT.AddUrlRow(newRow)                    ' Add the url

         ' Add relation
         For Each linkMap As Project In projectList
            Try
               ' Create a relation row
               Dim relUrlDt As ScraperDB.ProjectUrlRow = Me._ProjectUrlDT.NewProjectUrlRow
               relUrlDt.UrlRow = newRow
               relUrlDt.ProjectRow = linkMap.ProjectRow

               Me._ProjectUrlDT.AddProjectUrlRow(relUrlDt)
            Catch ex As Exception
               _log.Debug(ex.Message)
               _log.Debug(ex.StackTrace)
            End Try
         Next

         Return newRow
      Catch ex As Exception
         _log.Debug(ex.Message)
         _log.Debug(ex.StackTrace)

         Return Nothing
      End Try
   End Function

   ''' <summary>
   '''  Is the crawled data saveable - This is used for full/initial crawl
   ''' Crawl Data is saveable when all the partial url is crawled
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function IsSaveable() As Boolean
      Dim partialDV As New DataView(Me._UrlDT)

      ' Make sure there are no partial url in progress
      partialDV.RowFilter = Me._UrlDT.IsPartialDataColumn.ColumnName & " = True AND (" & _
         Me._UrlDT.UrlStatusIDColumn.ColumnName & " = " & UrlManager.UrlStatus.Ready & " OR " & _
         Me._UrlDT.UrlStatusIDColumn.ColumnName & " = " & UrlManager.UrlStatus.Assigned & ")"

      Return partialDV.Count = 0
   End Function

   ''' <summary>
   ''' Return total Partail urls that's ready to be scraped
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property PartialUrlToScrapeCount() As Integer
      Get
         Dim partialDV As New DataView(Me._UrlDT)

         ' Make sure there are no partial url in progress
         partialDV.RowFilter = Me._UrlDT.IsPartialDataColumn.ColumnName & " = True AND (" & _
            Me._UrlDT.UrlStatusIDColumn.ColumnName & " = " & UrlManager.UrlStatus.Ready 

         Return partialDV.Count
      End Get
   End Property

   ''' <summary>
   ''' Return total partial url
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property PartialUrlCount() As Integer
      Get
         Dim partialDV As New DataView(Me._UrlDT)

         ' Make sure there are no partial url in progress
         partialDV.RowFilter = Me._UrlDT.IsPartialDataColumn.ColumnName & " = True"

         Return partialDV.Count
      End Get
   End Property

   ''' <summary>
   ''' Add a url w/ projects to database. Return if the url is not added due to already exists in list
   ''' </summary>
   ''' <param name="url"></param>
   ''' <param name="linkMapList"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function addUrl(ByVal url As String, ByVal postData As String, ByVal linkMapList As List(Of LinkMap)) As ScraperDB.UrlRow
      If (Not Uri.IsWellFormedUriString(url, UriKind.Absolute) AndAlso linkMapList.Count = 0) Then
         _log.Info(url & " is not a well formed url.")
         Return Nothing
      End If

      Try
         Dim newRow As ScraperDB.UrlRow = Me._UrlDT.NewUrlRow

         newRow.UrlLink = url
         newRow.UrlStatusID = UrlStatus.Ready
         newRow.DateAdded = UrlManager.GetNow           ' All must be in UTC time
         newRow.UrlStatusID = UrlStatus.Ready           ' Set Status
         newRow.CrawlProjectRow = Me._CrawlProj.CrawlProjectRow
         Me._UrlDT.AddUrlRow(newRow)                    ' Add the url

         ' Add relation
         For Each linkMap As LinkMap In linkMapList
            Try
               ' Create a relation row
               Dim relUrlDt As ScraperDB.ProjectUrlRow = Me._ProjectUrlDT.NewProjectUrlRow
               relUrlDt.UrlRow = newRow
               relUrlDt.LinkMappingRow = linkMap.LinkMapRow
               relUrlDt.ProjectRow = linkMap.Project.ProjectRow

               If linkMap.IsPartialData Then
                  newRow.IsPartialData = True
               End If

               Me._ProjectUrlDT.AddProjectUrlRow(relUrlDt)
            Catch ex As Exception
               _log.Debug(ex.Message)
               _log.Debug(ex.StackTrace)
            End Try
         Next

         Return newRow
      Catch ex As Exception
         _log.Debug(ex.Message)
         _log.Debug(ex.StackTrace)

         Return Nothing
      End Try
   End Function

   ''' <summary>
   ''' Add url row to database
   ''' </summary>
   ''' <param name="refUrlRow"></param>
   ''' <param name="mainUrlRow"></param>
   ''' <remarks></remarks>
   Public Sub addHistory(ByVal refUrlRow As ScraperDB.UrlRow, ByVal mainUrlRow As ScraperDB.UrlRow)
      Try
         Dim refDT As ScraperDB.UrlReferencesDataTable = Me._CrawlProj.Dataset.UrlReferences
         Dim refRow As ScraperDB.UrlReferencesRow = refDT.NewRow

         refRow.UrlRowByUrl_Main = refUrlRow
         refRow.UrlRowByUrl_Referer = mainUrlRow

         refDT.Rows.Add(refRow)
      Catch ex As Exception
         _log.Debug("Unable to add history row")
         _log.Debug(ex.Message)
         _log.Debug(ex.StackTrace)
      End Try
   End Sub

   Public Sub removeURL(ByVal url As ScraperDB.UrlRow)
      url.Delete()
   End Sub

   ''' <summary>
   ''' Return the next url to be scraped. 
   ''' This modify the status column of the url row (It sets it Assigned).
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property NextURL() As ScraperDB.UrlRow
      Get
         Dim r As ScraperDB.UrlRow = Nothing

         _log.Debug("Total to scrape: " & _ToScrapeUrlView.Count)
         _log.Debug("Total Url: " & Me._UrlDT.Count)

         If _ToScrapeUrlView.Count > 0 Then
            If IsDeapthFirst Then
               r = _ToScrapeUrlView.Item(_ToScrapeUrlView.Count - 1).Row
            Else
               r = _ToScrapeUrlView.Item(0).Row
            End If
            r.UrlStatusID = UrlManager.UrlStatus.Assigned
         End If

         Return r
      End Get
   End Property


   ''' <summary>
   ''' Total URL left to scrape
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalToScrape() As Integer
      Get
         Return Me._ToScrapeUrlView.Count
      End Get
   End Property

   ''' <summary>
   ''' Return total url in the list
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalUrl() As Integer
      Get
         Return Me._UrlDT.Rows.Count
      End Get
   End Property

   Enum UrlStatus
      Ready = 0
      Assigned = 1
      [Error] = 2
      Finished = 3
   End Enum

   ''' <summary>
   ''' UrlMap class contains information about the url and project to scrape
   ''' </summary>
   ''' <remarks></remarks>
   Public Class UrlMap
      Private _UrlProjectRow As ScraperDB.ProjectUrlRow
      Private _CrawlProject As CrawlProject

      Public ReadOnly Property UrlProjectRow() As ScraperDB.ProjectUrlRow
         Get
            Return _UrlProjectRow
         End Get
      End Property

      Public ReadOnly Property LinkMap() As LinkMap
         Get
            Return Me._CrawlProject.LinkMapManager.getLinkMap(Me._UrlProjectRow.LinkMappingRow)
         End Get
      End Property

      Public ReadOnly Property Project() As Project
         Get
            Return Me._CrawlProject.ProjectManager.getProject(Me._UrlProjectRow.ProjectRow)
         End Get
      End Property

      Public ReadOnly Property UrlRow() As ScraperDB.UrlRow
         Get
            Return Me._UrlProjectRow.UrlRow
         End Get
      End Property

      Public Sub New(ByVal UrlProject As ScraperDB.ProjectUrlRow, ByVal crawlProject As CrawlProject)
         _UrlProjectRow = UrlProject
         _CrawlProject = crawlProject
      End Sub
   End Class
End Class