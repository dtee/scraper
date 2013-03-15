Public Class CrawlClient
   Private _CrawlProjects As New List(Of CrawlProject)
   Private _SqlConnection As SqlClient.SqlConnection

   Public Property SqlConnection() As SqlClient.SqlConnection
      Get
         Return Me._SqlConnection
      End Get
      Set(ByVal value As SqlClient.SqlConnection)
         Me._SqlConnection = value
      End Set
   End Property

   Private Sub LoadProjects()
      ' Load the list of projects
      Dim _CrawlDT As ScraperDB.CrawlProjectDataTable = New ScraperDB.CrawlProjectDataTable
      Dim sql As String = String.Format("SELECT * FROM [{0}]", _CrawlDT.TableName)

      Dim da As New SqlClient.SqlDataAdapter(sql, Me._SqlConnection)
      ' Dim com As New SqlClient.SqlConnectionStringBuilder(da)

      da.Fill(_CrawlDT)

      ' Load each project - if exits, reload the project's schedule and other important fields
   End Sub

   Dim totalMinute As Byte = 0
   Private Sub start()
      ' Run each project
      For Each proj As CrawlProject In Me._CrawlProjects
         ' Check the crawl schedule
         For Each cron As Cron In proj.CronManger.CronList
            ' Start if the start time is less than now
            If cron.getNextStartTime(Now.AddMinutes(-cron.Duration)) <= Now Then
               proj.Crawler.StartCrawl()
            Else
               proj.Crawler.StopCrawl()
            End If
         Next
      Next

      totalMinute += 0
      If (totalMinute = 30) Then
         totalMinute = 0
         ' Load the projects
         Me.LoadProjects()
      End If

      System.Threading.Thread.Sleep(60000)         ' Sleep for 1 minute
   End Sub

   Private Sub [stop]()

   End Sub
End Class
