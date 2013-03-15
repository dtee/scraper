Public MustInherit Class ScraperDataAdapter
   Protected _Dataset As ScraperDB

   MustOverride Sub LoadProject()                      ' Throws exception
   MustOverride Sub SaveProject()                      ' Throws Exception
   MustOverride Sub DeleteProject()                    ' Deletes the project

   MustOverride Sub SaveData()                        ' Create new if it doesnn't exist

   MustOverride Sub LoadUrl()                      ' Load all the url
   MustOverride Sub SaveUrl()                      ' Save all the url

   Protected _CrawlProject As CrawlProject
   Public Property CrawlProject() As CrawlProject
      Get
         Return _CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         _CrawlProject = value
         If value IsNot Nothing Then
            Me._Dataset = value.Dataset
         End If
      End Set
   End Property

   Public MustOverride ReadOnly Property ProjectLocation()

   Public Shared MaxLocationString
   Public Shared Function FixProjectLocation(ByVal str As String) As String
      If str.Length > 300 Then
         Dim CutoffLength As Integer = (ScraperDataAdapter.MaxLocationString / 2)
         Return (str.Substring(0, CutoffLength - 5) & "..." & (str.Substring(str.Length - CutoffLength)))
      End If
      Return str
   End Function
End Class