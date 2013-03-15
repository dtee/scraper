Imports System.IO

''' <summary>
''' Loads an XML file that contains project information. 
''' -> Problem, we expect our Dataset to have only one project row and no invalid url rows.
''' This class will load the data from given xml and remove unnecressary projectrow and url rows.
''' This step is taken to ensure we only upload one project to the database when we decide to import
''' the project into database.
''' </summary>
''' <remarks></remarks>
Public Class FileScraperDataAdapter
   Inherits ScraperDataAdapter
   Public ProjectFileName As String
   Public DataFileName As String

   Public Overrides Sub DeleteProject()
      Throw New Exception("Method is not implemented.")
   End Sub

   Public Overrides Sub LoadProject()
      Me._Dataset = New ScraperDB

      If Not System.IO.File.Exists(ProjectFileName) Then
         Throw New Exception("File Doesn't Exist")
      End If

      Try
         _Dataset.EnforceConstraints = False
         _Dataset.ReadXml(ProjectFileName)

         ' Create a Crawl Project Row
         'Dim cRow As ScraperDB.CrawlProjectRow = Me._Dataset.CrawlProject.NewCrawlProjectRow
         'cRow.Name = Me.ProjectFileName.Replace("C:\Scraper\Test Cases\Scraper\", "")
         'Me._Dataset.CrawlProject.AddCrawlProjectRow(cRow)

         'Me._Dataset.Project(0).CrawlProjectRow = cRow

         '' Set url 
         'For Each row As ScraperDB.UrlRow In Me._Dataset.Url.Rows
         '   Dim refRow As ScraperDB.ProjectUrlRow = Me._Dataset.Project_Url.NewProjectUrlRow
         '   refRow.UrlRow = row
         '   refRow.ProjectRow = Me._Dataset.Project(0)
         '   Me._Dataset.Project_Url.AddProjectUrlRow(refRow)
         'Next

         Try
            ' Create a new crawl project
            Me._CrawlProject = New CrawlProject(Me._Dataset.CrawlProject(0))
            Me._CrawlProject.ScraperDataAdaptor = Me

            ' Enable Constraints
            _Dataset.EnforceConstraints = True
         Catch e As System.Data.ConstraintException
            ' fix Errors here
            Console.WriteLine(e.Message)
            Console.WriteLine(e.StackTrace)
         End Try

      Catch ex As System.Data.ConstraintException
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         Throw New Exception("Unhandled DATA error in loading file: " & ex.Message)
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         Throw New Exception("Unhandled error in loading file: " & ex.Message)
      End Try

      ' Look for rows with errors
      For Each tbl As DataTable In Me._Dataset.Tables
         For Each row As DataRow In tbl.Rows
            If row.RowError <> "" Then
               Console.WriteLine(tbl.TableName & ": " & row.RowError)
            End If
         Next
      Next

      If _Dataset.CrawlProject.Rows.Count = 0 Then
         Throw New Exception("File does not contain any project.")
      End If
   End Sub

   ''' <summary>
   ''' Url and project is the same thing for file system.
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub LoadUrl()
      Me.LoadProject()
   End Sub

   ''' <summary>
   ''' Save Data
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub SaveData()
      ' Make sure directory exists
      Try
         Me._CrawlProject.ScrapedDS.WriteXml(Me.DataFileName)
      Catch ex As Exception
         Throw New Exception("Unhandled error in Saving file: " & ex.Message)
      End Try
   End Sub

   ''' <summary>
   ''' Save Project
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub SaveProject()
      Try
         ' Remove all the data related projects, starts with SYS_
         Me._Dataset.WriteXml(Me.ProjectFileName)
      Catch ex As Exception
         Throw New Exception("Unhandled error in saving file: " & ex.Message)
      End Try
   End Sub

   Public Overrides Sub SaveUrl()
      Me.SaveProject()
   End Sub

   Public Overrides ReadOnly Property ProjectLocation() As Object
      Get
         Return ScraperDataAdapter.FixProjectLocation(Me.ProjectFileName)
      End Get
   End Property
End Class