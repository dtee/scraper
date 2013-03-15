Public Class Crawler
   Public Event CrawlFinished()
   Public Event DataUpdate()

   Public AverageDownload As Integer = 0
   Public TotalBytesDownloaded As Integer = 0
   Public MaxRetry As Integer = 3

   Private _MaxListViewCount As Integer = 150
   Public Property MaxListViewCount() As Integer
      Get
         Return _MaxListViewCount
      End Get
      Set(ByVal value As Integer)
         _MaxListViewCount = value
      End Set
   End Property

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Private _project As Project
   Public Property Project() As Project
      Get
         Return _Project
      End Get
      Set(ByVal value As Project)
         _project = value
         Me.ListView1.Items.Clear()
      End Set
   End Property

   Public Sub StartDownload()
      _IsCrawling = True
      Me.NewStartAll()
   End Sub

   Private WithEvents mMyWebclient As New MyMultiWebClient
   Public Sub StopDownload()
      Me.mMyWebclient.CancelAllAsync()
      _IsCrawling = False
   End Sub

   Private _IsCrawling As Boolean
   Public ReadOnly Property IsCrawling() As Boolean
      Get
         Return _IsCrawling
      End Get
   End Property

#Region "Crawl"
   Private Sub NewStartAll()
      Me.mMyWebclient.SleepSeconds = Me.Project.ProjectRow.DownloadDelay

      ' check for max list in the list view, if it over max, then clear it
      Console.WriteLine("Started Downloading")
      If Me.Project.URLList.TotalToScrape = 0 And Me.mMyWebclient.CurrentTotalThreads = 0 Then
         If TypeOf (Me.Project.ScraperDataAdaptor) Is SQLDatabaseScraperAdapter Then
            Try
               Dim sda As SQLDatabaseScraperAdapter = Me.Project.ScraperDataAdaptor
               sda.SaveUrl()
               sda.SaveData()

               ' Start it all up agian! - how do i know when it's stopped?
               If Me.Project.URLList.TotalToScrape > 0 Then
                  Me.NewStartAll()
               End If
            Catch ex As Exception
               ' Unable to save data exception! - sql server is down?
               Console.WriteLine(ex.Message)
               Console.WriteLine(ex.StackTrace)
            End Try
         Else
            Me._IsCrawling = True
         End If
      End If

      For i As Integer = Me.mMyWebclient.CurrentTotalThreads To Me._project.ProjectRow.Threads - 1
         Dim urlRow As ScraperDB.UrlRow = Me.Project.URLList.NextURL

         If urlRow IsNot Nothing Then  ' Double checking
            Dim rv As New RowAndView()
            rv.Row = urlRow
            rv.UrlLog = Project.NewUrlLog(urlRow.UrlID)

            Me.ListView1.Items.Add(rv.lViewItem)
            mMyWebclient.DownloadStringAsync(New Uri(urlRow.Url), urlRow.UrlReferer, Nothing, rv)
         End If
      Next
   End Sub

   Public Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As MyMultiWebClient.MyDownloadProgressChangedEventArgs) Handles mMyWebclient.DownloadProgressChanged
      Dim rv As RowAndView = e.UserState

      rv.lViewItem.Size = "?"
      rv.lViewItem.Download = e.BytesReceived
      rv.lViewItem.Status = e.Status.ToString

      Me.TotalBytesDownloaded = Me.mMyWebclient.TotalBytesReceived
      Me.AverageDownload = Me.mMyWebclient.AverageSpeed
      RaiseEvent DataUpdate()

      Select Case e.Status
         ' Assign New
         Case MyMultiWebClient.MyDownloadProgressChangedEventArgs.ProgressStatus.Sleeping
            rv.lViewItem.Status &= " " & e.SleepCount    ' Bytes received becomes sleep delay
      End Select
   End Sub

   Public Sub ThreadFinished(ByVal sender As Object, ByVal e As MyMultiWebClient.MyThreadFinishedEventArgs) Handles mMyWebclient.ThreadFinished
      Dim rv As RowAndView = e.UserState

      ' Not Scraped, must be cancled.
      If e.ErrorStatus = MyMultiWebClient.DownloadError.Recoverable Then
         ' Download this again, dun't call newstart all
         rv.TotalRetry += 1
         rv.lViewItem.Retry = rv.TotalRetry

         If rv.TotalRetry < MaxRetry Then
            rv.UrlLog = Project.NewUrlLog(rv.Row.UrlID)  ' Start a new log.
            Me.mMyWebclient.DownloadStringAsync(New Uri(rv.Row.Url), rv.Row.UrlReferer, Nothing, rv)
            Exit Sub ' We are retrying this url.
         End If
      End If

      rv.lViewItem.Status = "Scraped"

      If e.Cancelled And Me.mMyWebclient.CurrentTotalThreads = 0 Then
         Me._IsCrawling = False
         RaiseEvent CrawlFinished()
      End If

      If Not e.Cancelled Then
         NewStartAll()        ' Start all up again
      End If
   End Sub

   Public Sub DownloadStringCompleted(ByVal sender As Object, ByVal e As MyMultiWebClient.MyDownloadStringCompletedEventArgs) Handles mMyWebclient.DownloadStringCompleted
      Dim rv As RowAndView = e.UserState

      If e.Cancelled Then
         rv.UrlLog.Message = "Scrape Cancelled"
         rv.lViewItem.Status = "Cancelled"
         rv.Row.UrlStatusID = URLList.UrlStatus.Ready
         Exit Sub
      End If

      Select Case e.ErrorStatus
         Case MyMultiWebClient.DownloadError.NoConnection
            rv.UrlLog.Message = "No Internet connection"
            rv.lViewItem.Status = "Cancelled: No Internet connection"
            rv.Row.UrlStatusID = URLList.UrlStatus.Ready
            Exit Sub
         Case MyMultiWebClient.DownloadError.Recoverable       ' Time outs
            rv.UrlLog.Message = "Recoverable Error" & e.Error.Message
            Exit Sub
         Case MyMultiWebClient.DownloadError.NonRecoverable
            rv.UrlLog.Message = "NonRecoverable Error" & e.Error.Message
            rv.Row.UrlStatusID = URLList.UrlStatus.Error
            Exit Sub
         Case MyMultiWebClient.DownloadError.NoError
            ' Do Scrape here
      End Select

      rv.lViewItem.Status = "Scraping"

      If Me.Project.ProjectRow.IsSaveContent Then
         rv.Row.Content = e.Result
      Else
         rv.Row.Content = ""
      End If

      rv.Row.LastModified = URLList.GetNow           ' Everything must be in utf time.
      rv.Row.LastScraped = URLList.GetNow
      RaiseEvent DataUpdate()

      If Me.Project.ProjectRow.ScrapeInterval = 0 Then
         rv.Row.UrlStatusID = URLList.UrlStatus.Finished     ' Set this to ready depending on interval
      Else
         rv.Row.UrlStatusID = URLList.UrlStatus.Ready
      End If

      ' No Error, lets scrape
      Try            ' Lets Scrape This!
         Me.Project.Scraper.Text = e.Result
         Me.Project.Scraper.WebUrl = rv.Row.Url
         Me.Project.Scraper.Scrape()

         rv.UrlLog.DateModified = e.WebResponse.LastModified

         ' Should probably check total data scraped, we may need to redownload this.
         Me.Project.SaveDataDS.Merge(Me.Project.Scraper.ScraperTree.ScrapedDS)
         Console.WriteLine("Scrape Time: " & Me.Project.Scraper.ScrapeTime.TotalSeconds)

         ' Lets add newly discovered url
         If Me.Project.Scraper.ScraperTree.UrlDataTable IsNot Nothing Then
            For Each row As DataRow In Me.Project.Scraper.ScraperTree.UrlDataTable.Rows
               Dim tempURLRow As ScraperDB.UrlRow = Me.Project.URLList.AddUrl(row("Data"))
               If tempURLRow IsNot Nothing Then
                  tempURLRow.UrlReferer = rv.Row.Url
               End If
            Next
         End If

         rv.UrlLog.Message = "Successfully Scraped"
         rv.lViewItem.Status = "Scraped"
      Catch ex As Exception
         rv.UrlLog.Message = "Scraped Error: " & ex.Message
      End Try
   End Sub
#End Region

   Public Class RowAndView
      Private _row As ScraperDB.UrlRow
      Public Property Row() As ScraperDB.UrlRow
         Get
            Return _row
         End Get
         Set(ByVal value As ScraperDB.UrlRow)
            _row = value
            lViewItem.UrlID = _row.UrlID
            lViewItem.Url = _row.Url
            lViewItem.Size = 0
            lViewItem.Retry = 0
            lViewItem.Status = "Starting..."
         End Set
      End Property

      Public UrlLog As ScraperDB.UrlLogRow
      Public TotalRetry As Integer = 0
      Public lViewItem As New DownloadListViewItem
   End Class

   Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

   End Sub
End Class
