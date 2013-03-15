''' <summary>
''' Contains hollow crawl project, this class 
''' only contains basic information about project
''' 
''' However, it has the abality to load the full scale
''' Crawl project from database
''' </summary>
''' <remarks></remarks>
Public Class CrawlProjectHollow
   Private _projectID As Integer
   Private _projectsDT As New ScraperLib.ScraperDB.ProjectDataTable
   Private Shared _log As New Log(GetType(UrlManager), False)
   Private _SQLConnection As SqlClient.SqlConnection

   Private _row As ScraperDB.CrawlProjectRow
   Public Sub New(ByVal row As ScraperDB.CrawlProjectRow, ByVal sqlconn As SqlClient.SqlConnection)
      Me._row = row
      Me._SQLConnection = sqlconn
      loadDetails()
   End Sub

   Public ReadOnly Property CrawlProjectRow() As ScraperDB.CrawlProjectRow
      Get
         Return Me._row
      End Get
   End Property

   ''' <summary>
   ''' Project Name
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ProjectName() As String
      Get
         Return Me._row.Name
      End Get
      Set(ByVal value As String)
         Me._row.Name = value
      End Set
   End Property

   ''' <summary>
   ''' Project ID
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ProjectID() As Integer
      Get
         Return Me._row.CrawlProjectID
      End Get
      Set(ByVal value As Integer)
         Me._projectID = value
      End Set
   End Property

   Public ReadOnly Property CreatedDate() As Date
      Get
         Return Me._row.CreatedDate
      End Get
   End Property

   Public ReadOnly Property DateRun() As Date
      Get
         Return Me.CrawlProjectRow.DateRun
      End Get
   End Property

   Public ReadOnly Property TotalUrl() As Integer
      Get
         Return Me._row.TotalUrl
      End Get
   End Property

   Public ReadOnly Property TotalUrlLeft() As Integer
      Get
         Return Me._row.TotalUrlLeft
      End Get
   End Property

   ''' <summary>
   ''' R
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property getProjectDetails() As ScraperDB.ProjectDataTable
      Get
         Return Me._projectsDT
      End Get
   End Property

   Public Sub loadDetails()
      Try
         Dim crawlDT As New ScraperDB.CrawlProjectDataTable
         Dim sql As String = "SELECT * FROM " & Me._projectsDT.TableName
         sql &= " WHERE " & crawlDT.CrawlProjectIDColumn.ColumnName & " = " & Me._row.CrawlProjectID
         Dim da As New SqlClient.SqlDataAdapter(sql, Me._SQLConnection)

         CrawlProjectHollow._log.Debug("Loading more Crawl Project Details.")
         da.Fill(Me._projectsDT)
      Catch ex As Exception
         Console.WriteLine("Error opening project from database.")
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)

         Throw ex
      End Try
   End Sub
End Class
