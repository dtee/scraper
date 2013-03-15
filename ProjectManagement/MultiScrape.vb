Public Class MultiScrape

#Region "New WebClient"
   Private WithEvents mMyWebclient As New MyMultiWebClient
   Private DownloadList As New List(Of RowAndView)

   Private ProjectList As ProjectList

   Private Sub OnProjectValueChanged() Handles ProjectInfoControl1.ProjectValueChanged
      Me.mMyWebclient.SleepSeconds = Me.Project.ProjectRow.DownloadDelay
   End Sub

   Public Sub OnAllUrlScraped()
      ' One of two thign can happen: All urls finsihed or it's cancled due to error
      Try
         ' If all finished
         If Me.DownloadList.Count = 0 And Me.Project.URLList.TotalToScrape = 0 Then
            If TypeOf (Me.Project.ScraperDataAdaptor) Is SQLDatabaseScraperAdapter Then
               Dim sda As SQLDatabaseScraperAdapter = Me.Project.ScraperDataAdaptor
               sda.SaveUrl()
               sda.SaveData()

               ' Start it all up agian! - how do i know when it's stopped?
               If Me.Project.URLList.TotalToScrape > 0 Then
                  Me.NewStartAll()
               Else
                  Me.ScrapeAllToolStripButton.Enabled = True
                  Me.DownloadAllToolStripButton.Enabled = True
               End If
            End If
         Else
            Me.ScrapeAllToolStripButton.Enabled = True
            Me.DownloadAllToolStripButton.Enabled = True
         End If
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
      End Try
   End Sub

   Private Sub NewStartAll()
      Me.ScrapedDataView.DataSet = Me.Project.SaveDataDS

      Dim TotalThreads As Integer = Me.ProjectInfoControl1.TotalThreads
      If TotalThreads > Me.Project.URLList.TotalToScrape Then
         TotalThreads = Me.Project.URLList.TotalToScrape
      End If

      If TotalThreads = 0 And DownloadList.Count = 0 Then
         Me.OnAllUrlScraped()
      End If

      If TotalThreads = DownloadList.Count Then    ' Lets not put any more sleep delays
         Me.myWebClient.SleepSeconds = 0
      Else
         Me.myWebClient.SleepSeconds = Me.Project.ProjectRow.DownloadDelay
      End If

      For i As Integer = DownloadList.Count To TotalThreads - 1
         Dim urlRow As ScraperDB.UrlRow = Me.Project.URLList.NextURL

         If urlRow IsNot Nothing Then
            Dim rv As New RowAndView()
            rv.Row = urlRow
            rv.UrlLog = Project.NewUrlLog(urlRow.UrlID)

            Me.ListView1.Items.Add(rv.lViewItem)
            mMyWebclient.DownloadStringAsync(New Uri(urlRow.Url), urlRow.UrlReferer, Nothing, rv)
            DownloadList.Add(rv)
         End If
      Next
   End Sub

   Public Sub DownloadProgressChanged(ByVal sender As Object, ByVal e As MyMultiWebClient.MyDownloadProgressChangedEventArgs) Handles mMyWebclient.DownloadProgressChanged
      Dim rv As RowAndView = e.UserState

      rv.lViewItem.Size = "?"
      rv.lViewItem.Download = e.BytesReceived
      rv.lViewItem.Percent = "?"
      rv.lViewItem.Status = e.Status.ToString

      Select Case e.Status
         ' Assign New
         Case MyMultiWebClient.MyDownloadProgressChangedEventArgs.ProgressStatus.Sleeping
            rv.lViewItem.Status &= " " & e.SleepCount    ' Bytes received becomes sleep delay
      End Select
   End Sub

   Public Sub ThreadFinished(ByVal sender As Object, ByVal e As MyMultiWebClient.MyThreadFinishedEventArgs) Handles mMyWebclient.ThreadFinished
      Dim rv As RowAndView = e.UserState

      Me.DownloadList.Remove(rv)

      ' Not Scraped, must be cancled.
      If Not rv.IsScraped Then
         If e.Cancelled Then
            rv.UrlLog.Message = "Scrape Cancled"
         ElseIf e.ErrorStatus = MyMultiWebClient.DownloadError.NoConnection Then
            rv.UrlLog.Message = "No Internet connection"
         ElseIf e.Error IsNot Nothing Then
            rv.UrlLog.Message = "Download Error: " & e.Error.Message
         End If
      End If

      Console.WriteLine("In Main: Thread Finished")
      If e.Cancelled Or e.ErrorStatus = MyMultiWebClient.DownloadError.NoConnection Then

         If Me.DownloadList.Count = 0 Then       ' Finished all
            Me.OnAllUrlScraped()
         End If
      Else
         NewStartAll()        ' Start all up again
      End If
   End Sub

   Public Sub DownloadStringCompleted(ByVal sender As Object, ByVal e As MyMultiWebClient.MyDownloadStringCompletedEventArgs) Handles mMyWebclient.DownloadStringCompleted
      Dim rv As RowAndView = e.UserState
      rv.lViewItem.Status = "Scraping"
      rv.IsScraped = True

      If e.Error IsNot Nothing Then
         rv.UrlLog.DateModified = URLList.GetNow
         rv.Row.LastScraped = URLList.GetNow
         rv.Row.LastModified = URLList.GetNow
         Exit Sub
      End If

      If Me.Project.ProjectRow.IsSaveContent Then
         rv.Row.Content = e.Result
      Else
         rv.Row.Content = ""
      End If

      rv.Row.LastModified = URLList.GetNow           ' Everything must be in utf time.
      rv.Row.LastScraped = URLList.GetNow
      Me.ProjectInfoControl1.TotalLeft = Me.Project.URLList.TotalToScrape
      Me.ProjectInfoControl1.TotalUrl = Me.Project.URLList.TotalUrl

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
      Catch ex As Exception
         rv.UrlLog.Message = "Scraped Error: " & ex.Message

         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
      End Try
   End Sub

   Private Sub NewStopAll()
      While DownloadList.Count > 0
         Dim rv As RowAndView = DownloadList.Item(0)
         Me.mMyWebclient.CancelAsync(rv)
         Me.DownloadList.Remove(rv)
      End While
   End Sub

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
            lViewItem.Percent = 0
            lViewItem.Status = "Starting..."
         End Set
      End Property

      Public UrlLog As ScraperDB.UrlLogRow
      Public IsScraped As Boolean = False
      Public lViewItem As New DownloadListViewItem
   End Class
#End Region

End Class
