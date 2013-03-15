''' <summary>
''' Scrape the project every x minute
''' </summary>
''' <remarks></remarks>
Public Class MultiScraper
   Public Event OnAllStart()
   Public Event OnAllFinished()
   Public Event OnDownloadComplete()
   Public Event OnProgressUpdate()        ' Update Progress

   Public ProjectDT As ScraperDB.ProjectDataTable    ' Current project list
   Private downloaderHash As Dictionary(Of Project, MyMultiWebClient)

   Public Sub New()
      Me.downloaderHash = New Dictionary(Of Project, MyMultiWebClient)
      Me.ProjectDT = New ScraperDB.ProjectDataTable
   End Sub

   Private _SQLConnection As SqlClient.SqlConnection
   Public Property SQLConnection() As SqlClient.SqlConnection
      Get
         Return _SQLConnection
      End Get
      Set(ByVal value As SqlClient.SqlConnection)
         _SQLConnection = value
      End Set
   End Property

   ''' <summary>
   ''' Loads project from the database, create new multidownloader for the project.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub LoadProjects()
      ' Load the project list
      Console.WriteLine("Loading Projects")
      If Me.SQLConnection IsNot Nothing Then
         Dim da As New SqlClient.SqlDataAdapter
         da.FillLoadOption = LoadOption.OverwriteChanges

         da.SelectCommand = New SqlClient.SqlCommand
         da.SelectCommand.CommandType = CommandType.Text
         da.SelectCommand.CommandText = "SELECT * FROM PROJECT"
         da.SelectCommand.Connection = Me.SQLConnection

         Me.ProjectDT.Clear()
         da.Fill(Me.ProjectDT)

         ' Look for removed projects
         Dim dv As New DataView(Me.ProjectDT)
         Dim removelist As New List(Of Project)
         For Each prj As Project In Me.downloaderHash.Keys
            dv.RowFilter = "ProjectID = " & prj.ProjectID

            If dv.Count = 0 Then            ' Project is removed
               removelist.Add(prj)
            End If
         Next

         ' Remove the projects that needs removiong
         For Each prj As Project In removelist
            Me.RemoveProject(prj)
         Next

         ' Look for new project and add it to project list
         For Each row As ScraperDB.ProjectRow In Me.ProjectDT
            Dim IsOld As Boolean = False
            For Each prj As Project In Me.downloaderHash.Keys
               If row.ProjectID = prj.ProjectID Then IsOld = True
            Next

            If Not IsOld Then
               ' Load the project and add add it to the multi downloader
               Dim sdbloader As New SQLDatabaseScraperAdapter(Me.SQLConnection)
               sdbloader.ProjectID = row.ProjectID

               Try
                  sdbloader.LoadProject()
                  Me.AddProject(sdbloader.Project)
               Catch ex As Exception
                  Console.WriteLine(ex.Message)
                  Console.WriteLine(ex.StackTrace)
               End Try
            End If
         Next
      End If
   End Sub

   ''' <summary>
   ''' Import new project to server, This assumes project is a vlid 
   ''' </summary>
   ''' <param name="prj">A Valid Project with valid tags, and has data tables.</param>
   ''' <remarks></remarks>
   Public Sub ImportProject(ByVal prj As Project)
      ' 4.) Import Project Into the server -> the project will have
      Dim sdbloader As New SQLDatabaseScraperAdapter(Me.SQLConnection)
      sdbloader.Project = prj
      prj.ScraperDataAdaptor = sdbloader
      Try
         sdbloader.SaveProject()       ' This saves project individually
         sdbloader.CreateServerTables(True)     ' Create server tables, drop any old tables
     
         Me.LoadProjects()

      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
      End Try
   End Sub

   ''' <summary>
   ''' Delete is more of a UI, just like import
   ''' </summary>
   ''' <param name="ProjID"></param>
   ''' <remarks></remarks>
   Public Sub DeleteProject(ByVal ProjID As Integer)
      ' Look for project in the downloader list and remove it
      SyncLock Me.downloaderHash
         Dim aprj As Project = Nothing
         For Each prj As Project In Me.downloaderHash.Keys
            If prj.ProjectID = ProjID Then
               aprj = prj
               Exit For
            End If
         Next

         If aprj IsNot Nothing Then
            Try
               Me.RemoveProject(aprj)        ' Remove from our list
               aprj.ProjectRow.Delete()      ' Delete from the dataset
               aprj.ScraperDataAdaptor.SaveProject()

               'Dim da As New ScraperDBTableAdapters.ProjectTableAdapter()
               'da.Connection = Me.SQLConnection
               'da.Update(Me.ProjectDT)            ' Update the database.
            Catch ex As Exception
               Console.WriteLine("Error removing Project: {0}", ProjID)
               Console.WriteLine(ex.Message)
               Console.WriteLine(ex.StackTrace)
            End Try
         Else
            Console.WriteLine("Error removing Project: {0} does not exists.", ProjID)
         End If
      End SyncLock
   End Sub

   Private Sub AddProject(ByVal prj As Project)
      SyncLock downloaderHash
         Dim m As New MyMultiWebClient

         AddHandler m.DownloadStringCompleted, AddressOf DownloadStringCompleted
         AddHandler m.ThreadFinished, AddressOf ThreadFinished

         m.SleepSeconds = prj.ProjectRow.DownloadDelay
         Me.downloaderHash.Add(prj, m)

         Console.WriteLine("Project {0} - {1} added to Download List.", prj.ProjectID, prj.ProjectName)
         Console.WriteLine("Total Projects in Scrape list: {0}", Me.downloaderHash.Count)
      End SyncLock
   End Sub

   Private Sub RemoveProject(ByVal prj As Project)
      SyncLock downloaderHash
         downloaderHash(prj).CancelAllAsync()
         RemoveHandler downloaderHash(prj).DownloadStringCompleted, AddressOf DownloadStringCompleted
         RemoveHandler downloaderHash(prj).ThreadFinished, AddressOf ThreadFinished
         Me.downloaderHash.Remove(prj)

         Console.WriteLine("Project {0} - {1} removed from Download List.", prj.ProjectID, prj.ProjectName)
         Console.WriteLine("Total Projects in Scrape list: {0}", Me.downloaderHash.Count)
      End SyncLock
   End Sub

#Region "New WebClient"
   Private MaxRetry As Integer = 3
   Private TimerCallBack As Integer = 30     ' Try to start all up every 30 minute

   Public Sub NewStartAll()
      Console.WriteLine("Server Started")
      SyncLock downloaderHash
         For Each prj As Project In Me.downloaderHash.Keys
            NewStartAll(prj)
         Next
      End SyncLock
   End Sub

   Private Sub NewStartAll(ByVal prj As Project)
      Console.WriteLine("Project Scrape Started: {0}", prj.ProjectName)
      If (prj.URLList.TotalToScrape = 0 And Me.downloaderHash(prj).CurrentTotalThreads = 0) Or _
         prj.URLList.TotalScraped = 1 Then         ' Total Scraped = total given to scrape
         Try
            Dim sda As SQLDatabaseScraperAdapter = prj.ScraperDataAdaptor
            sda.SaveUrl()
            sda.SaveData()

            ' Start it all up agian! - how do i know when it's stopped?
            If prj.URLList.TotalToScrape > 0 Then
               Me.NewStartAll()
            End If
         Catch ex As Exception
            Console.WriteLine("Error Updating Data to Server.")
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
         End Try
      End If

      Dim TotalThreads As Integer = prj.ProjectRow.Threads
      Me.downloaderHash(prj).SleepSeconds = prj.ProjectRow.DownloadDelay

      For i As Integer = Me.downloaderHash(prj).CurrentTotalThreads To TotalThreads - 1
         Dim urlRow As ScraperDB.UrlRow = prj.URLList.NextURL

         If urlRow IsNot Nothing Then  ' Double checking
            Dim rv As New ClientInfo()
            rv.UrlRow = urlRow
            rv.UrlLog = prj.NewUrlLog(urlRow.UrlID)
            rv.Project = prj
            rv.TotalRetry = 0

            Console.WriteLine("{0} Downlading {1}", prj.ProjectName, rv.UrlRow.Url)
            Me.downloaderHash(prj).DownloadStringAsync(New Uri(urlRow.Url), urlRow.UrlReferer, Nothing, rv)
         End If
      Next
   End Sub

   Public Sub ThreadFinished(ByVal sender As Object, ByVal e As MyMultiWebClient.MyThreadFinishedEventArgs)
      Dim rv As ClientInfo = e.UserState
      Dim prj As Project = rv.Project

      ' Not Scraped, must be cancled.
      If e.ErrorStatus = MyMultiWebClient.DownloadError.Recoverable Then
         ' Download this again, dun't call newstart all
         rv.TotalRetry += 1

         If rv.TotalRetry < MaxRetry Then
            rv.UrlLog = prj.NewUrlLog(rv.UrlRow.UrlID)  ' Start a new log.
            Me.downloaderHash(prj).DownloadStringAsync(New Uri(rv.UrlRow.Url), rv.UrlRow.UrlReferer, Nothing, rv)
            Exit Sub ' We are retrying this url.
         Else
            rv.UrlRow.UrlStatusID = URLList.UrlStatus.Error ' Scrape Error
         End If
      End If

      If Not e.Cancelled And e.ErrorStatus <> MyMultiWebClient.DownloadError.NoConnection Then
         NewStartAll(prj)        ' Start all up again
      End If
   End Sub

   Public Sub DownloadStringCompleted(ByVal sender As Object, ByVal e As MyMultiWebClient.MyDownloadStringCompletedEventArgs)
      Dim rv As ClientInfo = e.UserState
      Dim prj As Project = rv.Project

      Console.WriteLine("Url Download Finished: " & rv.UrlRow.Url)
      If e.Cancelled Then
         rv.UrlLog.Message = "Scrape Cancelled"
         rv.UrlRow.UrlStatusID = URLList.UrlStatus.Ready
         Exit Sub
      End If

      Select Case e.ErrorStatus
         Case MyMultiWebClient.DownloadError.NoConnection
            rv.UrlLog.Message = "No Internet connection"
            rv.UrlRow.UrlStatusID = URLList.UrlStatus.Ready    '  No Connection
            Exit Sub
         Case MyMultiWebClient.DownloadError.Recoverable       ' Time outs
            rv.UrlLog.Message = "Recoverable Error" & e.Error.Message
            Exit Sub
         Case MyMultiWebClient.DownloadError.NonRecoverable
            rv.UrlLog.Message = "NonRecoverable Error" & e.Error.Message
            rv.UrlRow.UrlStatusID = URLList.UrlStatus.Error
            Exit Sub
         Case MyMultiWebClient.DownloadError.NoError
            ' Do Scrape here
      End Select

      rv.UrlRow.LastModified = URLList.GetNow           ' Everything must be in utf time.
      rv.UrlRow.LastScraped = URLList.GetNow

      If prj.ProjectRow.IsSaveContent Then
         rv.UrlRow.Content = e.Result
      Else
         rv.UrlRow.Content = ""
      End If

      If prj.ProjectRow.ScrapeInterval = 0 Then
         rv.UrlRow.UrlStatusID = URLList.UrlStatus.Finished     ' Set this to ready depending on interval
      Else
         rv.UrlRow.UrlStatusID = URLList.UrlStatus.Ready
      End If

      ' No Error, lets scrape
      Try            ' Lets Scrape This!
         prj.Scraper.Text = e.Result
         prj.Scraper.WebUrl = rv.UrlRow.Url
         prj.Scraper.Scrape()

         rv.UrlLog.DateModified = e.WebResponse.LastModified

         ' Should probably check total data scraped, we may need to redownload this.
         prj.SaveDataDS.Merge(prj.Scraper.ScraperTree.ScrapedDS)

         ' Lets add newly discovered url
         If prj.Scraper.ScraperTree.UrlDataTable IsNot Nothing Then
            Console.WriteLine("Project in Auto Recover Mode!")
            For Each row As DataRow In prj.Scraper.ScraperTree.UrlDataTable.Rows
               Try
                  Dim tempURLRow As ScraperDB.UrlRow = prj.URLList.AddUrl(row("Data"))
                  If tempURLRow IsNot Nothing Then
                     tempURLRow.UrlReferer = rv.UrlRow.Url
                  End If
                  Console.WriteLine("Added New Url: {0}", row("Data"))
               Catch ex As Exception
               End Try
            Next
         End If

         rv.UrlLog.Message = "Successfully Scraped"
      Catch ex As Exception
         rv.UrlLog.Message = "Scraped Error: " & ex.Message
      End Try
      Console.WriteLine("{0} Scraped... Waiting for delay of {1} seconds.", rv.UrlRow.Url, prj.ProjectRow.DownloadDelay)
   End Sub

   Public Sub NewStopAll()
      Console.WriteLine("Server Stoppped")
      For Each client As MyMultiWebClient In Me.downloaderHash.Values
         client.CancelAllAsync()
      Next
   End Sub

   Public Class ClientInfo
      Public Project As Project
      Public UrlRow As ScraperDB.UrlRow
      Public UrlLog As ScraperDB.UrlLogRow
      Public TotalRetry As Integer = 0
   End Class
#End Region
End Class
