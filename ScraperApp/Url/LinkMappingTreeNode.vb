Imports SharedUI

Public Class LinkMappingTreeNode
   Inherits TreeNode

   Private _CrawlProject As CrawlProject

   Public Sub New()
      MyBase.Text = "Project Link Map"
   End Sub

   Public Property CrawlProject() As CrawlProject
      Get
         Return _CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         _CrawlProject = value
         Me.refresh()
      End Set
   End Property

   Public Sub refresh()
      MyBase.ImageIndex = LinkImageList.CrawlProject
      MyBase.SelectedImageIndex = MyBase.ImageIndex
      For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
         Me.Nodes.Add(New ProjectTreeNode(proj, Me._CrawlProject))
      Next
   End Sub
End Class

''' <summary>
''' Image id for the Image list
''' </summary>
''' <remarks></remarks>
Enum LinkImageList
   CrawlProject = 0
   Project = 1
   DataTableLink = 2
   FieldLink = 3
   PartialData = 4
   NewData = 5
End Enum

Public Class ProjectTreeNode
   Inherits TreeNode

   Private _Project As Project
   Private _CrawlProject As CrawlProject

   Public Sub New(ByVal Proj As Project, ByVal crawlProject As CrawlProject)
      'MyBase.New(Proj.ProjectRow.Name)
      Me._Project = Proj
      Me._CrawlProject = crawlproject
      refresh()
   End Sub

   Public Overloads Sub refresh()
      MyBase.Text = Me._Project.ProjectRow.Name
      MyBase.ImageIndex = LinkImageList.Project
      MyBase.SelectedImageIndex = MyBase.ImageIndex

      ' Load the tag nodes
      Me.Nodes.Clear()
      For Each urlnode As TagNode In Me._Project.TagTree.UrlTagNodes
         Dim urlTreeNode As UrlTreeNode = New UrlTreeNode(urlnode, Me._CrawlProject)
         Me.Nodes.Add(urlTreeNode)
      Next
   End Sub

   Public Overloads Property Text() As String
      Get
         Return MyBase.Text
      End Get
      Set(ByVal value As String)
         MyBase.Text = value
      End Set
   End Property
End Class

Public Class UrlTreeNode
   Inherits TreeNode

   Private _CrawlProject As CrawlProject
   Private _TagNode As TagNode

   Public ReadOnly Property TagNode() As TagNode
      Get
         Return _TagNode
      End Get
   End Property

   Public Sub New(ByVal urlNode As TagNode, ByVal crawlProject As CrawlProject)
      Me._TagNode = urlNode
      Me._CrawlProject = crawlProject

      refresh()
   End Sub

   Public Overloads Sub refresh()
      MyBase.Text = getParentTable(Me._TagNode) & Me._TagNode.Row.TagName        ' Make a precise name
      MyBase.ImageIndex = LinkImageList.FieldLink
      MyBase.SelectedImageIndex = MyBase.ImageIndex

      If MyBase.Text.Contains(".") Then
         MyBase.ImageIndex = LinkImageList.DataTableLink
         MyBase.SelectedImageIndex = MyBase.ImageIndex
      End If

      MyBase.Nodes.Clear()
      For Each _LinkMap As LinkMap In _CrawlProject.LinkMapManager.getLinkMaps(Me._TagNode)
         Dim linkProjectNode As New LinkProjectTreeNode(_LinkMap)
         linkProjectNode.Tag = _LinkMap
         MyBase.Nodes.Add(linkProjectNode)
      Next
   End Sub

   Public Function getParentTable(ByVal node As TagNode) As String
      Dim tableName As String = ""
      Dim parentNode As TagNode = node.ParentTagNode

      While parentNode IsNot Nothing
         If (parentNode.IsDataTable) Then
            tableName = parentNode.TagName & "." & tableName
         End If
         parentNode = parentNode.ParentTagNode
      End While

      Return tableName
   End Function

   Public Sub AddProject(ByVal proj As Project)
      Dim _LinkMap As LinkMap = Me._CrawlProject.LinkMapManager.NewLinkMap(proj, Me._TagNode)
      Dim linkProjectNode As New LinkProjectTreeNode(_LinkMap)
      linkProjectNode.Tag = _LinkMap.Project

      MyBase.Nodes.Add(linkProjectNode)
   End Sub

   Public Sub removeLink(ByVal linkMap As LinkMap)
      Me._CrawlProject.LinkMapManager.removeLinkMap(linkMap)
   End Sub
End Class

Public Class LinkProjectTreeNode
   Inherits TreeNode

   Private _LinkMap As LinkMap

   Public Sub New(ByVal _LinkMap As LinkMap)
      Me._LinkMap = _LinkMap
      refresh()
   End Sub

   ''' <summary>
   ''' Chagne the link map type - also change the image
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property IsPartialData() As Boolean
      Get
         Return _LinkMap.IsPartialData
      End Get
      Set(ByVal value As Boolean)
         _LinkMap.IsPartialData  = value
         refresh()
      End Set
   End Property

   Private Sub refresh()
      MyBase.Text = Me._LinkMap.Project.ProjectName

      MyBase.ImageIndex = LinkImageList.PartialData
      MyBase.SelectedImageIndex = MyBase.ImageIndex

      If (Not Me._LinkMap.IsPartialData) Then
         MyBase.ImageIndex = LinkImageList.NewData
         MyBase.SelectedImageIndex = MyBase.ImageIndex
      End If
   End Sub
End Class