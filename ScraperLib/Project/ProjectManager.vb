''' <summary>
''' Loads projects from database, allow import, delete, open
''' </summary>
''' <remarks></remarks>
Public Class ProjectManager
   Private _Log As New Log(GetType(ProjectManager), True)

   Private _ProjectDT As ScraperDB.ProjectDataTable
   Private _CrawlProject As CrawlProject
   Private _ProjectList As List(Of Project)

   Public Sub New(ByVal CrawlProject As CrawlProject)
      Me._CrawlProject = CrawlProject
      Me._ProjectDT = _CrawlProject.Dataset.Project
      Me._ProjectList = New List(Of Project)

      ' Must contain more than one project
      If Me._ProjectDT.Count = 0 Then
         newProject()
      Else
         _ProjectList = New List(Of Project)
         ' Add all the project to hash map for easy retrival of project
         For Each row As ScraperDB.ProjectRow In Me._ProjectDT.Rows
            Me._ProjectList.Add(New Project(_CrawlProject, row))
         Next
      End If
   End Sub

   'Public Function getProject(ByVal row As ScraperDB.ProjectRow) As Project
   '   Dim proj As Project = Nothing
   '   Me._ProjectMap.TryGetValue(row, proj)
   '   Return proj
   'End Function

   Public Function newProject() As Project
      Dim row As ScraperDB.ProjectRow = Me._ProjectDT.NewProjectRow
      row.Name = "Untitled Project " & Me.ProjectList.Count
      row.CrawlProjectRow = Me._CrawlProject.CrawlProjectRow
      Me._ProjectDT.AddProjectRow(row)

      Dim proj As Project = New Project(_CrawlProject, row)
      Me._ProjectList.Add(proj)
      Return proj
   End Function

   Public Sub removeProject(ByVal project As Project)
      _Log.Debug("Remove Project: " & Me.ProjectList.Remove(project))
      project.ProjectRow.Delete()
   End Sub

   Public ReadOnly Property ProjectList() As List(Of Project)
      Get
         Return Me._ProjectList
      End Get
   End Property

   Public Function getProject(ByVal projRow As ScraperDB.ProjectRow) As Project
      For Each proj As Project In Me.ProjectList
         If proj.ProjectRow Is projRow Then
            Return proj
         End If
      Next

      Return Nothing
   End Function
End Class
