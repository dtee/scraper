''' <summary>
''' Crawls sites, calls scaper, downloader, refiner, etc.
''' </summary>
''' <remarks></remarks>
Public Class Crawler
   Public Event CrawlFinished()           ' The crawling finished
   Public Event ScrapeUpdate(ByVal crawlInfo As CrawlInfo)              ' One Crawl Finished
   Public Event ScrapeFinished(ByVal crawlInfo As CrawlInfo)
   Public Event CrawlStatusChange()

   Public AverageSpeed As Integer = 0
   Public TotalBytesDownloaded As Integer = 0
   Public MaxRetry As Integer = 3

   Private _CrawlProject As CrawlProject
   Private _TotalCrawledPages As Integer = 0
   Private WithEvents mMyWebclient As New NetworkClient.MultiWebClient

   Private Shared _Log As New Log(GetType(Crawler), False)            '  Create a new log
   Private _CrawlHelper As CrawlHelper

   Private startDate As Date           ' Date when the crawl started
   Private stopDate As Date            ' Date when crawl is stopped
   Public IsSaveOnExit As Boolean = True


   Public Sub New(ByVal crawlProject As CrawlProject)
      Me._CrawlProject = crawlProject
      Me._CrawlHelper = New CrawlHelper(Me._CrawlProject)


      setWebSetting()
   End Sub

   ''' <summary>
   ''' Set the crawler the web Settting, Timeout, Useragent and sleep seconds
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub setWebSetting()
      Me.mMyWebclient.TimeOut = Me._CrawlProject.CrawlProjectRow.WebTimeout * 1000
      Me.mMyWebclient.UserAgent = Me._CrawlProject.CrawlProjectRow.WebAgentName
      Me.mMyWebclient.SleepSeconds = Me._CrawlProject.CrawlProjectRow.DownloadDelay
      Me._maxurl = Me._CrawlProject.CrawlProjectRow.MaxUrl
   End Sub

   ''' <summary>
   ''' Start crawling
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub StartCrawl()
      Me.NewStartAll()
      Me._CrawlStatus = CrawlStatus.Crawling
      setWebSetting()
   End Sub

   ''' <summary>
   ''' Stop the crawling, by signaling to stop all the downloads.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub StopCrawl()
      ' Cancel the web downloading, which will trigger crawler to stop crawling.
      Me.mMyWebclient.CancelAllAsync()
   End Sub

   Private _CrawlStatus As CrawlStatus
   Public ReadOnly Property aCrawlStatus() As CrawlStatus
      Get
         Return _CrawlStatus
      End Get
   End Property

   Private _maxurl As Integer = 10
   Private ReadOnly Property MaxUrl() As Integer
      Get
         Return Me._maxurl
      End Get
   End Property

#Region "Crawl"
   Private Sub saveData(ByVal isLoadUrl As Boolean)
      Try
         ' Crawl Finished, Save data and load new url from database.
         Dim sda As SQLDatabaseScraperAdapter = Me._CrawlProject.ScraperDataAdaptor

         Me._CrawlStatus = CrawlStatus.SavingData
         _Log.Debug("Saving Data")
         sda.SaveData()       ' Save data to database

         Me.setWebSetting()

         _Log.Debug("Loading Urls")
         If isLoadUrl Then sda.LoadUrl() ' Load new URL
      Catch ex As Exception
         ' Unable to save data exception! - sql server is down?
         _Log.Error("Save to database failed")
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
      End Try
   End Sub

   Private Sub NewStartAll()
      ' check for max list in the list view, if it over max, then clear it

      ' This need a change - a cralwer 
      If (Me._CrawlProject.UrlManager.TotalScraped + Me._CrawlProject.UrlManager.TotalAssigned >= Me.MaxUrl Or _
         Me.mMyWebclient.CurrentTotalThreads = 0) And _
         TypeOf (Me._CrawlProject.ScraperDataAdaptor) Is SQLDatabaseScraperAdapter Then

         ' If all the assigned url is finished, and project is saveable
         If Me._CrawlProject.UrlManager.TotalAssigned = 0 And Me._CrawlProject.UrlManager.IsSaveable Then
            ' If sql type of crawling, then we want to save data when there's no URL left
            saveData(True)
         Else
            ' If all the partials are assigned, dun't assign any more.
            Dim urlDT As ScraperDB.UrlDataTable = Me._CrawlProject.Dataset.Url
            Dim partialDV As New DataView(urlDT)

            ' Make sure there are no partial url in progress
            partialDV.RowFilter = urlDT.IsPartialDataColumn.ColumnName & " = True AND " & _
              urlDT.UrlStatusIDColumn.ColumnName & " = " & UrlManager.UrlStatus.Ready

            If partialDV.Count = 0 Then
               Exit Sub
            End If
         End If
      End If

      Me._CrawlStatus = CrawlStatus.Crawling
      For i As Integer = Me.mMyWebclient.CurrentTotalThreads To Me._CrawlProject.CrawlProjectRow.Threads - 1
         ' Get the next Url to crawl
         Dim urlRow As ScraperDB.UrlRow = Me._CrawlProject.UrlManager.NextURL

         If urlRow IsNot Nothing Then  ' Start a new download
            _Log.Debug("Crawling: " & urlRow.UrlID)
            _Log.Debug("Crawling: " & urlRow.UrlLink)

            ' Skip, make room for partial urls to download + scrape
            If Me._CrawlProject.UrlManager.PartialUrlCount > Me.MaxUrl And urlRow.IsPartialData = False Then
               urlRow.UrlStatusID = UrlManager.UrlStatus.Ready
               Continue For
            End If

            Try
               Dim uri As New Uri(urlRow.UrlLink)
               mMyWebclient.DownloadStringAsync(New Uri(urlRow.UrlLink), urlRow.UrlReferer, Nothing, New CrawlInfo(urlRow))
            Catch ex As UriFormatException
               urlRow.UrlStatusID = UrlManager.UrlStatus.Error
               urlRow.ErrorMessage = ex.Message
            Catch ex As Exception
               urlRow.UrlStatusID = UrlManager.UrlStatus.Error
               urlRow.ErrorMessage = ex.Message
            End Try
         Else
            Me._CrawlStatus = CrawlStatus.Ready
            RaiseEvent CrawlFinished()
         End If
      Next
   End Sub

   Private Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As NetworkClient.DownloadProgressChangedEventArgs) Handles mMyWebclient.DownloadProgressChanged
      Dim tempCrawlInfo As CrawlInfo = e.UserState

      tempCrawlInfo.CurrentDownloadedBytes = e.BytesReceived
      tempCrawlInfo.StatusText = e.Status.ToString

      Me.TotalBytesDownloaded = Me.mMyWebclient.TotalBytesReceived
      Me.AverageSpeed = Me.mMyWebclient.AverageSpeed

      Select Case e.Status
         ' Assign New
         Case NetworkClient.DownloadProgressChangedEventArgs.ProgressStatus.Sleeping
            tempCrawlInfo.StatusText &= " " & e.SleepCount    ' Bytes received becomes sleep delay
      End Select

      RaiseEvent ScrapeUpdate(tempCrawlInfo)
   End Sub

   ''' <summary>
   ''' Web client's thread finished - this happens regardless of failing or success (the event arg contains those information)
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub ThreadFinished(ByVal sender As Object, ByVal e As NetworkClient.ThreadFinishedEventArgs) Handles mMyWebclient.ThreadFinished
      Dim tempCrawlInfo As CrawlInfo = e.UserState

      If e.Cancelled Then
         If tempCrawlInfo.ScrapeStatus <> ScrapeStatus.Scraped Then
            tempCrawlInfo.ScrapeStatus = ScrapeStatus.Cancelled
         End If

         If Me.mMyWebclient.CurrentTotalThreads = 0 Then
            Me._CrawlStatus = CrawlStatus.Ready
         End If
      Else
         ' Not Scraped, must be cancled.
         If e.ErrorStatus = NetworkClient.DownloadError.Recoverable Then
            ' Download this again, dun't call newstart all
            tempCrawlInfo.TotalRetry += 1
            tempCrawlInfo.TotalRetry = tempCrawlInfo.TotalRetry

            If tempCrawlInfo.TotalRetry < MaxRetry Then
               ' Redownload the website
               Me.mMyWebclient.DownloadStringAsync(New Uri(tempCrawlInfo.UrlRow.UrlLink), tempCrawlInfo.UrlRow.UrlReferer, Nothing, tempCrawlInfo)
            End If
         End If
      End If

      RaiseEvent ScrapeFinished(tempCrawlInfo)

      If Not e.Cancelled And Not e.ErrorStatus = NetworkClient.DownloadError.NoConnection Then
         NewStartAll()              ' Start all up again
      Else
         If Me.IsSaveOnExit Then
            Me.saveData(False)         ' Don't load the url
         End If

         RaiseEvent CrawlStatusChange()
         RaiseEvent CrawlFinished()
      End If
   End Sub

   ''' <summary>
   ''' Download web site successful, we can scrape the downloaded content
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub DownloadStringCompleted(ByVal sender As Object, ByVal e As NetworkClient.DownloadStringCompletedEventArgs) Handles mMyWebclient.DownloadStringCompleted
      Dim tempCrawlInfo As CrawlInfo = e.UserState

      Select Case e.ErrorStatus
         Case NetworkClient.DownloadError.NoConnection
            tempCrawlInfo.ScrapeStatus = ScrapeStatus.NoConnection

            Me._CrawlStatus = CrawlStatus.NoConnection
         Case NetworkClient.DownloadError.Recoverable       ' Time outs
            tempCrawlInfo.ScrapeStatus = ScrapeStatus.DownloadErrorRetry
         Case NetworkClient.DownloadError.NonRecoverable
            tempCrawlInfo.ScrapeStatus = ScrapeStatus.DownloadError
         Case NetworkClient.DownloadError.NoError
            tempCrawlInfo.ScrapeStatus = ScrapeStatus.Scraping

            If Me._CrawlProject.CrawlProjectRow.IsSaveContent Then
               tempCrawlInfo.UrlRow.Content = e.Result        ' Save content
            End If

            If Me._CrawlProject.UrlManager.PartialUrlCount > Me.MaxUrl And tempCrawlInfo.UrlRow.IsPartialData = False Then
               tempCrawlInfo.UrlRow.UrlStatusID = UrlManager.UrlStatus.Ready
               Exit Sub
            End If

            ' Do Scrape here
            Try
               ' User CrawlHelper to scrape
               Me._CrawlHelper.doScrape(tempCrawlInfo.UrlRow, e.Result)       ' Scraped the downloaded content
               tempCrawlInfo.ScrapeStatus = ScrapeStatus.Scraped

               ' Everything must be in utf time.
               tempCrawlInfo.UrlRow.LastModified = e.WebResponse.LastModified         ' Set the last modified date
               tempCrawlInfo.UrlRow.LastScraped = UrlManager.GetNow
            Catch ex As Exception
               tempCrawlInfo.ScrapeStatus = ScrapeStatus.ScrapeError
            End Try
      End Select

      RaiseEvent ScrapeUpdate(tempCrawlInfo)         ' Update the crawl information
   End Sub
#End Region

   Public Class CrawlInfo
      Public UrlRow As ScraperDB.UrlRow            ' Url Row
      Public Content As String                     ' Content

      Public TotalRetry As Integer = 0
      Public CurrentDownloadedBytes As Integer = 0

      Public StatusText As String
      Public Tag As Object                ' A tag something can attach

      Private _CrawlStatus As ScrapeStatus
      Public Property ScrapeStatus() As ScrapeStatus
         Get
            Return _CrawlStatus
         End Get
         Set(ByVal value As ScrapeStatus)
            Me._CrawlStatus = value

            Select Case value
               Case Crawler.ScrapeStatus.Cancelled
                  Me.UrlRow.UrlStatusID = UrlManager.UrlStatus.Ready

                  Me.StatusText = "Cancelled"
               Case Crawler.ScrapeStatus.DownloadError
                  Me.UrlRow.UrlStatusID = UrlManager.UrlStatus.Error
                  Me.UrlRow.ErrorMessage = "Unrecoverable download error: " & Me.Content

                  Me.StatusText = "Download Error"
               Case Crawler.ScrapeStatus.DownloadErrorRetry
                  ' Do nothing
               Case Crawler.ScrapeStatus.NoConnection
                  Me.UrlRow.UrlStatusID = UrlManager.UrlStatus.Ready

                  Me.StatusText = "No Internet Connection"
               Case Crawler.ScrapeStatus.Scraped
                  Me.UrlRow.UrlStatusID = UrlManager.UrlStatus.Finished

                  Me.StatusText = "Scraped"
               Case Crawler.ScrapeStatus.ScrapeError
                  Me.UrlRow.UrlStatusID = UrlManager.UrlStatus.Error
                  Me.UrlRow.ErrorMessage = "Scrape Error: Time out."

                  Me.StatusText = "Scrape Error"
            End Select
         End Set
      End Property

      Public Sub New(ByVal urlRow As ScraperDB.UrlRow)
         Me.UrlRow = urlRow
      End Sub
   End Class

   Public Enum ScrapeStatus
      DownloadError
      [DownloadErrorRetry]

      Scraping
      ScrapeError

      Scraped
      Cancelled
      NoConnection
   End Enum

   Public Enum CrawlStatus
      Ready
      [Error]
      Crawling
      NoConnection
      SavingData
   End Enum
End Class