Public Class CrawlProject
   Private _DS As ScraperDB
   Private _CrawlProjRow As ScraperDB.CrawlProjectRow
   Private _ProjectManager As ProjectManager
   Private _UrlManager As UrlManager
   Private _LinkMapManager As LinkMappingManager
   Private _ProxyManger As ProxyManager
   Private _DataMapper As DataMappingManager
   Private _Crawler As Crawler
   Private _CronManager As CronManager

   Public ReadOnly Property DataTables() As List(Of DataTable)
      Get
         Dim list As New List(Of DataTable)
         For Each dt As DataTable In Me._DS.Tables
            If dt.TableName = "" Then
               list.Add(dt)
            End If
         Next

         Return list
      End Get
   End Property

   Public ReadOnly Property DataMapper() As DataMappingManager
      Get
         Return Me._DataMapper
      End Get
   End Property

   Public ReadOnly Property ProjectManager() As ProjectManager
      Get
         Return Me._ProjectManager
      End Get
   End Property

   Public ReadOnly Property UrlManager() As UrlManager
      Get
         Return Me._UrlManager
      End Get
   End Property

   Public ReadOnly Property Dataset() As ScraperDB
      Get
         Return _DS
      End Get
   End Property

   Public ReadOnly Property Crawler() As Crawler
      Get
         Return _Crawler
      End Get
   End Property

   ''' <summary>
   ''' 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property LinkMapManager() As LinkMappingManager
      Get
         Return _LinkMapManager
      End Get
   End Property

   ''' <summary>
   ''' Continuously collected Data.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ScrapedDS() As DataSet
      Get
         Return Me.Dataset
      End Get
   End Property

   Private _Scraper As Scraper
   Public ReadOnly Property Scraper() As Scraper
      Get
         If _Scraper Is Nothing Then
            _Scraper = New Scraper()
            _Scraper._CrawlProject = Me
         End If

         Return _Scraper
      End Get
   End Property

   ''' <summary>
   ''' Rebuild the Scraped DS - project removed, tag changed in a project, project removed, etc. 
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub RebuildScrapeDS()
      Dim rootProject As New List(Of Project)

      Dim tblList As New List(Of DataTable)

      ' removed generaeted tables
      For Each dt As DataTable In Me.Dataset.Tables
         If DataTableUtil.IsGeneratedTable(dt) Then

            Dim conRemoveList As New List(Of Data.Constraint)
            For Each con As Data.Constraint In dt.Constraints
               If con.ConstraintName = "Constraint1" Then
               Else
                  conRemoveList.Add(con)
               End If
            Next

            While dt.ParentRelations.Count > 0
               Me.Dataset.Relations.Remove(dt.ParentRelations(0))
            End While

            While dt.ChildRelations.Count > 0
               Me.Dataset.Relations.Remove(dt.ChildRelations(0))
            End While

            For Each con As Data.Constraint In conRemoveList
               dt.Constraints.Remove(con)
            Next

            tblList.Add(dt)
         End If
      Next

      ' Remove the generated tables.
      For Each dt As DataTable In tblList
         Me.Dataset.Tables.Remove(dt)
      Next

      For Each proj As Project In Me.ProjectManager.ProjectList
         proj.TagTree.RebuildDataTable(True)                   ' Rebuild project wide
      Next

      ' Link Mapping depends on the dataset generated
      Me.LinkMapManager.LoadLinkMappingList()
      AddRelations()

      Me.Dataset.AcceptChanges()
   End Sub

   ''' <summary>
   ''' Add data relation to database tables
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub AddRelations()
      ' Build the higherachy treee based on the project url linking
      For Each proj As Project In Me.LinkMapManager.getRootProjects()
         recursiveAlterDataTable(proj, Nothing)
      Next

      ' Build the url Data table
      If (Not Me.Dataset.Tables.Contains(DataTableUtil.URL_DATASET_TABLENAME(Me.CrawlProjectRow.CrawlProjectID))) Then
         DataTableUtil.CreateUrlRelationalTable(Me.Dataset, Me._CrawlProjRow.CrawlProjectID)
      End If

      'If (Not Me.Dataset.Tables.Contains(DataTableUtil.URL_DATACount_TABLENAME(Me.CrawlProjectRow.CrawlProjectID))) Then
      '   DataTableUtil.CreateUrlDataCountTable(Me.Dataset, Me._CrawlProjRow.CrawlProjectID)
      'End If
   End Sub

   ''' <summary>
   ''' Get column list of column given identity.
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function getIdentityColumns(ByVal dt As DataTable) As List(Of Data.DataColumn)
      Dim colList As New List(Of Data.DataColumn)

      For Each proj As Project In Me.ProjectManager.ProjectList
         For Each dataNode As TagNode In proj.TagTree.DataTagNodes
            For Each node As TagNode In dataNode.TagNodeList
               If node.Row.IsIdentfier Then
                  colList.Add(dt.Columns(node.TagName))
               End If
            Next

            Return colList
         Next
      Next

      Return Nothing
   End Function

   ''' <summary>
   ''' Recursively add data table to a data table list.
   ''' - Breath first pattern.
   ''' </summary>
   ''' <param name="proj"></param>
   ''' <remarks></remarks>
   Private Sub recursiveAlterDataTable(ByVal proj As Project, ByVal parentDTTagNode As TagNode)
      If parentDTTagNode IsNot Nothing Then
         Dim parentDT As DataTable = parentDTTagNode.DataDT

         For Each node As TagNode In proj.TagTree.DataTagNodes
            If (node.ParentDataTableTagNode IsNot Nothing) Then
               Continue For
            End If

            Dim childDT As DataTable = node.DataDT
            DataTableUtil.AddRelation(parentDT, childDT)       ' Add relation
         Next
      End If

      For Each urlNode As TagNode In proj.TagTree.UrlTagNodes
         Dim tempDataNode As TagNode = urlNode.ParentDataTableTagNode

         Dim linkMaps As List(Of LinkMap) = Me.LinkMapManager.getLinkMaps(urlNode)
         For Each linkMap As LinkMap In linkMaps
            If linkMap.Project Is proj Then
               ' Do not recursive call
            ElseIf tempDataNode Is Nothing Or linkMap.IsPartialData Then
               recursiveAlterDataTable(linkMap.Project, parentDTTagNode)
            Else
               recursiveAlterDataTable(linkMap.Project, tempDataNode)
            End If
         Next
      Next
   End Sub

   Public ReadOnly Property isValid()
      Get
         ' Vaidate everything

         ' Make sure the project name is valid

         Return True
      End Get
   End Property

   Public ReadOnly Property CronManger() As CronManager
      Get
         Return Me._CronManager
      End Get
   End Property

   ''' <summary>
   ''' Test each tagtree to see if they are valid
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsProjectsValid()
      Get
         Dim isValid As Boolean = True
         For Each proj As Project In Me.ProjectManager.ProjectList
            isValid = isValid And proj.TagTree.IsValid
         Next

         Return isValid
      End Get
   End Property

   ''' <summary>
   ''' New Project by name, doesn't bind to dataset
   ''' </summary>
   ''' <param name="Name"></param>
   ''' <remarks></remarks>
   Public Sub New(ByVal Name As String)
      Me._DS = New ScraperDB
      Me._CrawlProjRow = _DS.CrawlProject.NewCrawlProjectRow

      Me._CrawlProjRow.Name = Name

      Me._CrawlProjRow.ProxyCheckContent = ""
      Me._CrawlProjRow.ProxyCheckUrl = ""

      Me._CrawlProjRow.DateRun = Now
      Me._CrawlProjRow.IsSaveContent = False
      Me._CrawlProjRow.Threads = 1
      Me._CrawlProjRow.DownloadDelay = 0

      Me._CrawlProjRow.TotalUrl = 0
      Me._CrawlProjRow.TotalUrlLeft = 0
      Me._DS.CrawlProject.AddCrawlProjectRow(Me._CrawlProjRow)

      InitManagers()
   End Sub

   Private _DataTypeManager As DataTypeManager

   Public ReadOnly Property DataTypeManager() As DataTypeManager
      Get
         Return Me._DataTypeManager
      End Get
   End Property

   Private Sub InitManagers()
      ' Create a project Manager
      ' TODO: Check out builder apttern. (facade)
      Me._ProjectManager = New ProjectManager(Me)

      Me._UrlManager = New UrlManager(Me)
      Me._ProxyManger = New ProxyManager(Me)
      Me._ProjectManager = New ProjectManager(Me)
      Me._DataMapper = New DataMappingManager(Me)
      Me._LinkMapManager = New LinkMappingManager(Me)
      Me._DataTypeManager = New DataTypeManager(Me.Dataset.DataType)
      Me._CronManager = New CronManager(Me)

      ' Build the ScraeDS
      Me.RebuildScrapeDS()       ' Link mapping requires table be build first

      Me._Crawler = New Crawler(Me)
   End Sub

   ''' <summary>
   ''' Add constraints to database that coudlnt' be added with xsd
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub AddDSConstraints()
      ' Project_Url many to many constaint -> URL Manager
      Dim cols() As DataColumn = New DataColumn() {Me.Dataset.Project_Url.UrlIDColumn, Me.Dataset.Project_Url.ProjUrlIDColumn}
      Dim project_URL As New UniqueConstraint("Project_Url_ID", cols, False)

      If Not Me.Dataset.Project_Url.Constraints.Contains(project_URL.ConstraintName) Then
         Me.Dataset.Project_Url.Constraints.Add(project_URL)
      End If

      ' Link mapping many to many constaint
      cols = New DataColumn() {Me.Dataset.LinkMapping.ProjectIDColumn, Me.Dataset.LinkMapping.TagIDColumn}
      Dim LinkMapping_TagLib As New UniqueConstraint("LinkMapping_TagLibID", cols, False)

      If Not Me.Dataset.LinkMapping.Constraints.Contains(LinkMapping_TagLib.ConstraintName) Then
         Me.Dataset.LinkMapping.Constraints.Add(LinkMapping_TagLib)
      End If

      ' URL many to many constaint -> Url Manager
      cols = New DataColumn() {Me.Dataset.UrlReferences.UrlRefIDColumn, Me.Dataset.UrlReferences.UrlID_FKColumn}
      Dim UrLRef As New UniqueConstraint("Url_UrL_ID", cols, False)

      If Not Me.Dataset.LinkMapping.Constraints.Contains(UrLRef.ConstraintName) Then
         Me.Dataset.UrlReferences.Constraints.Add(UrLRef)
      End If
   End Sub


   ''' <summary>
   ''' New Crawl Project
   ''' </summary>
   ''' <param name="projRow"></param>
   ''' <remarks></remarks>
   Public Sub New(ByVal projRow As ScraperDB.CrawlProjectRow)
      Me._CrawlProjRow = projRow
      Me._DS = projRow.Table.DataSet

      InitManagers()
   End Sub

   Private _ScraperDataAdaptor As ScraperDataAdapter
   ''' <summary>
   ''' Adaptor to access the data - DAL
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property ScraperDataAdaptor() As ScraperDataAdapter
      Get
         Return _ScraperDataAdaptor
      End Get
      Set(ByVal value As ScraperDataAdapter)
         Me._ScraperDataAdaptor = value
      End Set
   End Property

   Public ReadOnly Property ProxyManager() As ProxyManager
      Get
         Return _ProxyManger
      End Get
   End Property

   Public ReadOnly Property CrawlProjectRow() As ScraperDB.CrawlProjectRow
      Get
         Return Me._CrawlProjRow
      End Get
   End Property
End Class
