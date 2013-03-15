''' <summary>
''' Loads projects from database, allow import, delete, open
''' </summary>
''' <remarks></remarks>
Public Class ProjectManager
   Public ProjectDT As New ScraperDB.ProjectDataTable
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

   ''' <summary>
   ''' Loads project from the database, create new multidownloader for the project.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub LoadProjects()
      ' Load the project list
      Console.WriteLine("Loading Projects")
      If Me.SQLConnection IsNot Nothing Then
         Dim da As New ScraperDBTableAdapters.ProjectTableAdapter()
         Me.ProjectDT = da.GetProjects()
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

         Me.LoadProjects()    ' Reload the projcts DT
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
      End Try
   End Sub
End Class
