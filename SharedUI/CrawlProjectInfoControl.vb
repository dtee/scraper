Imports ScraperLib

Public Class CrawlProjectInfoControl
   Private _CrawlProject As CrawlProject
   Private _Elapsed As New TimeSpan()

   Private Sub onStatusChange()
      Dim acrawler As Crawler = Me._CrawlProject.Crawler
      Me.lblStatus.Text = acrawler.aCrawlStatus.ToString
   End Sub

   Public Property CrawlProject() As CrawlProject
      Get
         Return Me._CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         If value IsNot Nothing Then

            If _CrawlProject IsNot Nothing Then
               RemoveHandler _CrawlProject.Crawler.ScrapeFinished, AddressOf onScrapeFinish
               RemoveHandler _CrawlProject.Crawler.CrawlStatusChange, AddressOf onStatusChange
            End If

            Me._CrawlProject = value
            AddHandler _CrawlProject.Crawler.ScrapeFinished, AddressOf onScrapeFinish
            AddHandler _CrawlProject.Crawler.CrawlStatusChange, AddressOf onStatusChange

            ' Bind controls:
            Me.ProjectNameTextBox.DataBindings.Clear()         ' Bind to a new new
            Me.ProjectNameTextBox.DataBindings.Add("Text", Me._CrawlProject.CrawlProjectRow, _
                  Me._CrawlProject.Dataset.CrawlProject.NameColumn.ColumnName)
            Me.ProjectNameTextBox.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged


            Me.UserAgentTextBox.DataBindings.Clear()         ' Bind to a new new
            Me.UserAgentTextBox.DataBindings.Add("Text", Me._CrawlProject.CrawlProjectRow, _
                  Me._CrawlProject.Dataset.CrawlProject.WebAgentNameColumn.ColumnName)
            Me.UserAgentTextBox.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged

            Me.ThreadsNumericUpDown.DataBindings.Clear()
            Me.ThreadsNumericUpDown.DataBindings.Add("Value", Me._CrawlProject.CrawlProjectRow, "Threads")
            Me.ThreadsNumericUpDown.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged

            'If Me._CrawlProject.CrawlProjectRow.DownloadDelay Mod 10 <> 0 Then
            'Me._CrawlProject.CrawlProjectRow.DownloadDelay = 0
            Me.DownloadDelayNumericUpDown.DataBindings.Clear()
            Me.DownloadDelayNumericUpDown.DataBindings.Add("Value", Me._CrawlProject.CrawlProjectRow, "DownloadDelay")
            Me.DownloadDelayNumericUpDown.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged

            Me.ConnectionsNumericUpDown.DataBindings.Clear()
            Me.ConnectionsNumericUpDown.DataBindings.Add("Value", Me._CrawlProject.CrawlProjectRow, "ConnectionPerIP")
            Me.ConnectionsNumericUpDown.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged

            Me.UrlAssignTimeoutNumericUpDown.DataBindings.Clear()
            Me.UrlAssignTimeoutNumericUpDown.DataBindings.Add("Value", Me._CrawlProject.CrawlProjectRow, _
                     Me._CrawlProject.Dataset.CrawlProject.AssignTimeOutMinuteColumn.ColumnName)
            Me.UrlAssignTimeoutNumericUpDown.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged

            Me.MaxUrlNumericUpDown.DataBindings.Clear()
            Me.MaxUrlNumericUpDown.DataBindings.Add("Value", Me._CrawlProject.CrawlProjectRow, _
                     Me._CrawlProject.Dataset.CrawlProject.MaxUrlColumn.ColumnName)
            Me.MaxUrlNumericUpDown.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged

            Me.WebTimeoutNumericUpDown.DataBindings.Clear()
            Me.WebTimeoutNumericUpDown.DataBindings.Add("Value", Me._CrawlProject.CrawlProjectRow, _
                     Me._CrawlProject.Dataset.CrawlProject.WebTimeoutColumn.ColumnName)
            Me.WebTimeoutNumericUpDown.DataBindings.DefaultDataSourceUpdateMode = Windows.Forms.DataSourceUpdateMode.OnPropertyChanged

            Me.IsSaveContentCheckBox.DataBindings.Clear()
            Me.IsSaveContentCheckBox.DataBindings.Add("Checked", Me._CrawlProject.CrawlProjectRow, "IsSaveContent")

            onScrapeFinish(Nothing)       ' Really bad way...

            Me.CrawlerControl1.Crawler = Me._CrawlProject.Crawler
         End If
      End Set
   End Property

   Private Sub onScrapeFinish(ByVal crawlInfo As Crawler.CrawlInfo)
      ' Update the information
      Dim acrawler As Crawler = Me._CrawlProject.Crawler

      Me.AverageSpeed = acrawler.AverageSpeed
      Me.TotalUrl = Me._CrawlProject.UrlManager.TotalUrl
      Me.TotalLeft = Me._CrawlProject.UrlManager.TotalToScrape
      Me.TotalFinished = Me._CrawlProject.UrlManager.TotalScraped
      Me.TotalDownloadedSize = acrawler.TotalBytesDownloaded

      ' Change the status
      Me.lblStatus.Text = acrawler.aCrawlStatus.ToString
   End Sub

   ''' <summary>
   ''' Return total time Elasped since timer.Start is called.
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Public ReadOnly Property Elasped() As TimeSpan
      Get
         Return _Elapsed
      End Get
   End Property

#Region "Properties"
   Public WriteOnly Property TotalDownloadedSize() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalDownloadedSize.Text = Me.CalculateSize(value)
      End Set
   End Property

   ''' <summary>
   ''' Average speed TotalDownloadedSize over Elapsed
   ''' </summary>
   ''' <value>Bytest per secod - in bytes</value>
   ''' <remarks></remarks>
   Public WriteOnly Property AverageSpeed() As Integer
      Set(ByVal value As Integer)
         Me.lblAverageSpeed.Text = Me.CalculateSize(value) & "/s"
      End Set
   End Property

   ''' <summary>
   ''' Change Byte to text in b/kb/mb/gb
   ''' </summary>
   ''' <param name="bytes"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function CalculateSize(ByVal bytes As Double) As String
      Dim strSize As String = String.Format("{0} B", bytes.ToString("N"))

      If (bytes > 1024) Then
         bytes /= 1024
         strSize = String.Format("{0} KB", bytes.ToString("N"))
      End If

      If (bytes > 1024) Then
         bytes /= 1024
         strSize = String.Format("{0} MB", bytes.ToString("N"))
      End If

      If (bytes > 1024) Then
         bytes /= 1024
         strSize = String.Format("{0} GB", bytes.ToString("N"))
      End If

      Return strSize
   End Function

   ''' <summary>
   ''' Total Urls left to scrape
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Public WriteOnly Property TotalLeft() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalLeft.Text = value
         Me.TotalFinished = Me.ProjectProgressBar.Maximum - value
      End Set
   End Property

   ''' <summary>
   ''' Total Finished is TotalUrl - TotalLeft
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Private WriteOnly Property TotalFinished() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalFinished.Text = value
         If (value <= Me.ProjectProgressBar.Maximum) Then
            Me.ProjectProgressBar.Value = value
         End If
      End Set
   End Property

   ''' <summary>
   ''' Total Url
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Public WriteOnly Property TotalUrl() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalUrl.Text = value.ToString
         Me.ProjectProgressBar.Maximum = value
      End Set
   End Property
#End Region

   ''' <summary>
   ''' Update Time Elapsed
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Me._Elapsed.Add(New TimeSpan(Timer1.Interval))
      Me._Elapsed = New TimeSpan(10000 * (System.Environment.TickCount - starttime))

      Me.lblTimeElasped.Text = String.Format("{0}:{1}:{2}", Me._Elapsed.Hours, Me._Elapsed.Minutes, Me._Elapsed.Seconds)
   End Sub

   Private starttime As Integer
   ''' <summary>
   ''' Start the timer, have the option of restarting it.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub StartTimer()
      starttime = System.Environment.TickCount
      Me.Timer1.Start()
   End Sub

   Public Sub StopTimer()
      Me.Timer1.Stop()
   End Sub

   Private Sub IsSaveContentCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsSaveContentCheckBox.CheckedChanged

   End Sub

   Private Sub DownloadDelayNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadDelayNumericUpDown.ValueChanged
      calculateCheckoutExpire()
   End Sub

   Private Sub WebTimeoutNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebTimeoutNumericUpDown.ValueChanged
      calculateCheckoutExpire()
   End Sub

   Private Sub MaxUrlNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaxUrlNumericUpDown.ValueChanged
      calculateCheckoutExpire()
   End Sub

   Private Sub calculateCheckoutExpire()
      If Me._CrawlProject IsNot Nothing Then
         Dim projRow As ScraperDB.CrawlProjectRow = Me._CrawlProject.CrawlProjectRow
         Dim newTimeout As Integer = Math.Ceiling(MaxUrlNumericUpDown.Value * (WebTimeoutNumericUpDown.Value + DownloadDelayNumericUpDown.Value) / 60)
         newTimeout = newTimeout / Me.ThreadsNumericUpDown.Value

         If Short.MaxValue > newTimeout Then
            Me.UrlAssignTimeoutNumericUpDown.Value = newTimeout
            projRow.AssignTimeOutMinute = newTimeout
         End If
      End If
   End Sub

   Private Sub ThreadsNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThreadsNumericUpDown.ValueChanged
      calculateCheckoutExpire()
   End Sub
End Class
