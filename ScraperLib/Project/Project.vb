Public Class Project
   Private Shared _Log As New Log(GetType(Project), False)

   Public ReadOnly Property ProjectRow() As ScraperDB.ProjectRow
      Get
         Return _ProjRow
      End Get
   End Property

   Public ReadOnly Property ProjectID() As Integer
      Get
         Return Me._ProjRow.ProjectID
      End Get
   End Property

   Public ReadOnly Property Dataset() As ScraperDB
      Get
         Return _Dataset
      End Get
   End Property

   Public ReadOnly Property ProjectName() As String
      Get
         Return Me._ProjRow.Name
      End Get
   End Property

   Private _CrawlProject As CrawlProject
   Private _ProjRow As ScraperDB.ProjectRow
   Private _TagTree As TagTree
   Private _SaveDataDS As DataSet
   Private _Dataset As ScraperDB

   Public Sub New(ByVal CrawlProject As CrawlProject, ByVal row As ScraperDB.ProjectRow)
      Me._CrawlProject = CrawlProject
      Me._ProjRow = row
      Me._Dataset = CrawlProject.Dataset

      Me._TagTree = New TagTree(Me)       ' Create a new Tag Tree.
   End Sub

   Public ReadOnly Property TagTree() As TagTree
      Get
         Return _TagTree
      End Get
   End Property

   Public ReadOnly Property ScrapedDS() As DataSet
      Get
         Return Me._TagTree.ScrapedDS
      End Get
   End Property

   Public Sub Remove()
      Dim ProjectList As List(Of Project) = Me._CrawlProject.ProjectManager.ProjectList
      _Log.Debug("Removed Successfully: " & ProjectList.Remove(Me))
      Me.ProjectRow.Delete()
   End Sub
End Class
