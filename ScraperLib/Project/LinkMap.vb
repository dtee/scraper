Public Class LinkMap
   Private _project As Project
   Private _urlTagNode As TagNode
   Private _Row As ScraperDB.LinkMappingRow
   Private _crawlProject As CrawlProject

   Public Sub New(ByVal row As ScraperDB.LinkMappingRow, ByVal proj As Project, ByVal urlTagNode As TagNode)
      Me._Row = row
      Me._project = proj
      Me._urlTagNode = urlTagNode
   End Sub

   Public ReadOnly Property Project() As Project
      Get
         Return Me._project
      End Get
   End Property

   Public ReadOnly Property LinkMapRow() As ScraperDB.LinkMappingRow
      Get
         Return Me._Row
      End Get
   End Property

   Public ReadOnly Property UrlTagNode() As TagNode
      Get
         Return Me._urlTagNode
      End Get
   End Property

   Public Property IsPartialData() As Boolean
      Get
         Return Me._Row.IsPartialData
      End Get
      Set(ByVal value As Boolean)
         Me._Row.IsPartialData = value
      End Set
   End Property

   Public Sub remove()
      Me._Row.Delete()
   End Sub
End Class
