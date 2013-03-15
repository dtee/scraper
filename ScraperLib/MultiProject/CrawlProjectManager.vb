Imports System.Data.SqlClient

''' <summary>
''' This class manages loading the projects from database.
''' 
''' Since a project could not be loaded without loading
''' all the project related files, this class will create 
''' the hollow Project
''' </summary>
''' <remarks></remarks>
Public Class CrawlProjectManager
   Private _ProjectDT As New ScraperDB.CrawlProjectDataTable
   Private Shared _log As New Log(GetType(UrlManager), False)
   Private _hollowProjectList As List(Of CrawlProjectHollow)

   Public Sub New(ByVal conn As SqlClient.SqlConnection)
      Me._SQLConnection = conn
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

   Public ReadOnly Property ProjectDT() As ScraperDB.CrawlProjectDataTable
      Get
         Return Me._ProjectDT
      End Get
   End Property

   Public Function IsConnecitonOpen(ByVal timeoutSeconds As Integer) As Boolean
      'Me._SQLConnection.ConnectionTimeout = 1000
      Try
         Me._SQLConnection.Open()
         Me._SQLConnection.Close()
         Return True
      Catch ex As Exception
         Console.WriteLine("Error opening project from database.")
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)

         Return False
      End Try
   End Function

   ''' <summary>
   ''' Return a list of crawl project hollow, which contains more information
   ''' about the crawl project
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property CrawlProjectHollows() As List(Of CrawlProjectHollow)
      Get
         If Me._hollowProjectList Is Nothing Then
            Me._hollowProjectList = New List(Of CrawlProjectHollow)

            For Each row As ScraperDB.CrawlProjectRow In Me.ProjectDT
               Me._hollowProjectList.Add(New CrawlProjectHollow(row, Me._SQLConnection))
            Next
         End If

         Return Me._hollowProjectList
      End Get
   End Property


   ''' <summary>
   ''' Loads project from the database, create new multidownloader for the project.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub LoadProjects(Optional ByVal offset As Integer = 0, Optional ByVal limit As Integer = Integer.MaxValue)
      ' Load the project list
      Console.WriteLine("Loading Projects")
      If Me.SQLConnection IsNot Nothing Then
         Dim sql As String = "Select * from " & Me.ProjectDT.TableName
         Dim da As New SqlClient.SqlDataAdapter(sql, Me._SQLConnection)

         Try
            da.Fill(Me._ProjectDT)
            Me._hollowProjectList = Nothing     ' Let it build a new list
         Catch ex As Exception
            Console.WriteLine("Error opening project from database.")
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)

            Throw ex
         End Try
      End If
   End Sub

   ''' <summary>
   ''' Load the project from the database
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function loadCrawlProject(ByVal crawlProjectID As Integer) As CrawlProject
      Dim sqlDA As New SQLDatabaseScraperAdapter(Me._SQLConnection)
      sqlDA.CrawlProjectID = crawlProjectID

      Try
         sqlDA.LoadProject()
         Return sqlDA.CrawlProject
      Catch ex As Exception
         Console.WriteLine("Error opening project from database.")
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         Throw ex
      End Try

      Return Nothing
   End Function

   ''' <summary>
   ''' Check to see if the project exists in database
   ''' 1.) Check the server database to see if the project name exists
   ''' 2.) Return true if it does, else return false
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function projectExists(ByVal prj As CrawlProject) As Boolean
      Throw New Exception("Function not yet implemented")
   End Function

   ''' <summary>
   ''' Get the crawl project ID from the server given the name
   ''' 1.) Get the project ID from database
   ''' </summary>
   ''' <param name="prj"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getProjectID(ByVal prj As CrawlProject)
      Throw New Exception("Function not yet implemented")
   End Function

   ''' <summary>
   ''' Delete the project from the database
   ''' </summary>
   ''' <param name="crawlProjectID">A valid project id that exists in database</param>
   ''' <remarks>
   ''' Throws exception if the project to delete does not exists in the database.
   ''' </remarks>
   Public Sub deleteProject(ByVal crawlProjectID As Integer)
      Dim sql As String = String.Format("DELETE FROM {0} WHERE crawlprojectid = {1}")
   End Sub

   ''' <summary>
   ''' Upload a new project to the server 
   ''' 1.) Assumes the user wants to save the project to server no matter what
   ''' 2.) If project name exists in server, then save it
   ''' </summary>
   ''' <param name="prj">A Valid Project with valid tags, and has data tables.</param>
   ''' <remarks></remarks>
   Public Sub uploadProject(ByVal prj As CrawlProject)
      Dim sdbloader As SQLDatabaseScraperAdapter

      If prj.ScraperDataAdaptor Is Nothing Then
         sdbloader = New SQLDatabaseScraperAdapter(Me._SQLConnection)
         sdbloader.CrawlProject = prj
         prj.ScraperDataAdaptor = sdbloader
      Else
         sdbloader = prj.ScraperDataAdaptor
      End If

      Try
         ' A new project being saved to database
         sdbloader.SaveProject()

         ' There can be two kind of save, if the project a new project or existing project
         If prj.CrawlProjectRow.CrawlProjectID < 0 Then
            prj.RebuildScrapeDS()         ' This function has to be called if project is saved to db.

            ' Create database tables - (FK names may not be what i want)
            sdbloader.createDataTables()

            MsgBox("Project successfully saved.")
         End If
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox("Error saving project: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
      End Try
   End Sub
End Class
