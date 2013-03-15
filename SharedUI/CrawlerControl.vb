Imports ScraperLib

Public Class CrawlerControl
   Private Shared _Log As New Log(GetType(CrawlerControl), True)

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Private _Crawler As Crawler

   Public Property Crawler() As Crawler
      Get
         Return Me._Crawler
      End Get
      Set(ByVal value As Crawler)
         If value IsNot Nothing Then
            If Me._Crawler IsNot Nothing Then
               RemoveHandler _Crawler.ScrapeFinished, AddressOf onScrapeFinished
               RemoveHandler _Crawler.ScrapeUpdate, AddressOf onScrapeUpdate
            End If

            Me._Crawler = value
            AddHandler _Crawler.ScrapeFinished, AddressOf onScrapeFinished
            AddHandler _Crawler.ScrapeUpdate, AddressOf onScrapeUpdate
         End If
      End Set
   End Property

   Public Sub ResetList()
      Me.ListView1.Items.Clear()
   End Sub

   ''' <summary>
   ''' Update the UI
   ''' </summary>
   ''' <param name="tempCrawlInfo"></param>
   ''' <remarks></remarks>
   Public Sub onScrapeUpdate(ByVal tempCrawlInfo As Crawler.CrawlInfo)
      Dim listViewItem As DownloadListViewItem = tempCrawlInfo.Tag

      If listViewItem Is Nothing Then
         ' Create a new listview
         listViewItem = New DownloadListViewItem()
         tempCrawlInfo.Tag = listViewItem

         ' Add to listview
         Me.ListView1.Items.Add(listViewItem)
      End If

      Try
         listViewItem.UrlID = tempCrawlInfo.UrlRow.UrlID
         listViewItem.Url = tempCrawlInfo.UrlRow.UrlLink
         listViewItem.Size = tempCrawlInfo.CurrentDownloadedBytes
         listViewItem.Retry = tempCrawlInfo.TotalRetry
         listViewItem.Status = tempCrawlInfo.StatusText
      Catch ex As Exception
         _Log.Error("Sync lock error: happens because data is saved before event is raised.")
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
      End Try
   End Sub

   Private Sub onScrapeFinished(ByVal tempCrawlInfo As Crawler.CrawlInfo)
      Dim listViewItem As DownloadListViewItem = tempCrawlInfo.Tag

      If listViewItem IsNot Nothing Then
         Me.ListView1.Items.Remove(listViewItem)
      End If
   End Sub
End Class
