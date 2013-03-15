''' <summary>
''' Maps Project to the "url" type tag ID
''' - Given a Tag, return the related projects
''' </summary>
''' <remarks></remarks>
Public Class LinkMappingManager
   Private _CrawlProject As CrawlProject
   Private _LinkMapDT As ScraperDB.LinkMappingDataTable

   Public Sub New(ByVal crawlProject As CrawlProject)
      Me._CrawlProject = crawlProject
      Me._LinkMapDT = Me._CrawlProject.Dataset.LinkMapping
   End Sub

   ''' <summary>
   ''' Return the root projects in the crawl project
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getRootProjects() As List(Of Project)
      Dim rootProjList As New List(Of Project)
      Dim projectListView As New DataView(Me._CrawlProject.Dataset.LinkMapping)

      For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
         projectListView.RowFilter = "projectID = " & proj.ProjectID
         If (projectListView.Count = 0) Then       ' No one is pointing to this project
            rootProjList.Add(proj)
         End If
      Next

      Return rootProjList
   End Function

   Private _LinkMapList As New List(Of LinkMap)

   ''' <summary>
   ''' Get non selected projects
   ''' </summary>
   ''' <param name="tagNode"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getOtherProjects(ByVal tagNode As TagNode) As List(Of Project)
      Dim projList As New List(Of Project)
      For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
         projList.Add(proj)
      Next

      ' Return list of projects
      For Each linkmap As LinkMap In Me.getLinkMaps(tagNode)
         projList.Remove(linkmap.Project)
      Next

      Return projList
   End Function


   ''' <summary>
   ''' Init the project link map.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub LoadLinkMappingList()
      _LinkMapList.Clear()
      '_LinkMapDT.Rows.Clear()

      For Each linkRow As ScraperDB.LinkMappingRow In Me._LinkMapDT.Rows
         Dim proj As Project = Me._CrawlProject.ProjectManager.getProject(linkRow.ProjectRow)

         Dim urlTagNode As TagNode = findTagNode(linkRow.TagLibraryRow)
         If (urlTagNode IsNot Nothing) Then
            Dim temp As New LinkMap(linkRow, proj, urlTagNode)
            Me._LinkMapList.Add(temp)
         End If
      Next
   End Sub

   Public Function findTagNode(ByVal tagRow As ScraperDB.TagLibraryRow) As TagNode
      For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
         For Each urlNode As TagNode In proj.TagTree.UrlTagNodes
            If (urlNode.Row Is tagRow) Then
               Return urlNode
            End If
         Next
      Next

      Return Nothing
   End Function

   Public Sub removeLinkMap(ByVal linkMap As LinkMap)
      linkMap.remove()
   End Sub

   Public Function getLinkMap(ByVal row As ScraperDB.LinkMappingRow)
      For Each tempLinkMap As LinkMap In Me._LinkMapList
         If (tempLinkMap.LinkMapRow Is row) Then
            Return tempLinkMap
         End If
      Next

      Return Nothing
   End Function

   Public Function getLinkMaps(ByVal proj As Project) As List(Of LinkMap)
      Dim projLinkMap As New List(Of LinkMap)
      For Each tempLinkMap As LinkMap In Me._LinkMapList
         If (tempLinkMap.Project Is proj) Then
            projLinkMap.Add(tempLinkMap)
         End If
      Next

      Return projLinkMap
   End Function

   Public Function getLinkMaps(ByVal urlTagNode As TagNode) As List(Of LinkMap)
      Dim tagLinkMap As New List(Of LinkMap)
      For Each tempLinkMap As LinkMap In Me._LinkMapList
         If (tempLinkMap.UrlTagNode Is urlTagNode) Then
            tagLinkMap.Add(tempLinkMap)
         End If
      Next

      Return tagLinkMap
   End Function

   Public Function NewLinkMap(ByVal proj As Project, ByVal urlTagNode As TagNode) As LinkMap
      Dim linkRow As ScraperDB.LinkMappingRow = addLinkMap(urlTagNode, proj)
      Dim temp As New LinkMap(linkRow, proj, urlTagNode)
      Me._LinkMapList.Add(temp)

      Return temp
   End Function

   Private Function addLinkMap(ByVal tagnode As TagNode, ByVal proj As Project) As ScraperDB.LinkMappingRow
      ' if the row like this exists, then don't let the user add it
      For Each row As ScraperDB.LinkMappingRow In proj.ProjectRow.GetLinkMappingRows
         If row.TagLibraryRow Is tagnode.Row And row.ProjectRow Is proj.ProjectRow Then
            Throw New Exception("Link already exists in the Crawl Project.")
         End If
      Next

      Dim linkRow As ScraperDB.LinkMappingRow = Me._LinkMapDT.NewLinkMappingRow
      linkRow.TagLibraryRow = tagnode.Row
      linkRow.ProjectRow = proj.ProjectRow
      _LinkMapDT.AddLinkMappingRow(linkRow)

      Return linkRow
   End Function


   Public ReadOnly Property LinkMappingDT() As ScraperDB.LinkMappingDataTable
      Get
         Return Me._CrawlProject.Dataset.LinkMapping
      End Get
   End Property

   ''' <summary>
   ''' Make sure link mapping is valid
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsValid() As Boolean
      Get
         Return True
      End Get
   End Property
End Class
