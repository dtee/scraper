''' <summary>
''' Takes one project and load the project tree if there's mulitple projects
''' Projects are stored in seperate data set, so project links to each other 
''' through treeview, tree view will handle project parent/child handling
''' </summary>
''' <remarks></remarks>
Public Class ProjectTreeView
   Inherits TreeView

   Public Sub New(ByVal Proj As Project)
      MyBase.New()

      ' Recursive load the projects
      Dim t As New ProjectTreeNode(Proj)
      Me.Nodes.Add(t)
   End Sub

   Public Overloads Property TopNode() As ProjectTreeNode
      Get
         Return MyBase.TopNode
      End Get
      Set(ByVal value As ProjectTreeNode)
         MyBase.TopNode = value
      End Set
   End Property

   ''' <summary>
   ''' Any node remove must be done from the tree
   ''' </summary>
   ''' <param name="node"></param>
   ''' <remarks></remarks>
   Public Sub RemoveProject(ByVal node As ProjectTreeNode)

   End Sub
End Class

Public Class ProjectTreeNode
   Inherits TreeNode

   Public Sub New(ByVal proj As Project)
      Me.Project = proj
   End Sub

   Private _project As Project
   Public Property Project() As Project
      Get
         Return _project
      End Get
      Set(ByVal value As Project)
         _project = value
      End Set
   End Property

   Public Overloads Sub Remove()
      MyBase.Remove()
      Me.Project.ProjectRow.ProjectRowParent = Nothing
   End Sub

   Public Overloads Property Text() As String
      Get
         Return Me._project.ProjectName
      End Get
      Set(ByVal value As String)
         Me._project.ProjectName = value
      End Set
   End Property

   Public Overloads Property Parent() As ProjectTreeNode
      Get
         Return MyBase.Parent
      End Get
      Set(ByVal value As ProjectTreeNode)
         Dim p As ProjectTreeNode = MyBase.Parent

         If p IsNot Nothing And value IsNot Nothing Then
            p.Nodes.Remove(Me)
            value.Nodes.Add(Me)

            Me.Project.ProjectRow.ProjectRowParent = value.Project.ProjectRow

            ' Possible to change to a differnt parent
            p.CalculateImageIndex()
            Me.CalculateImageIndex()
         End If
      End Set
   End Property

   Public Overloads Property ImageIndex() As Integer
      Get
         Return MyBase.ImageIndex
      End Get
      Set(ByVal value As Integer)
         ' Do nothing
      End Set
   End Property

   Private Sub CalculateImageIndex()
      If Me.Nodes.Count = 0 Then
         MyBase.ImageIndex = ProjectTreeNodeImage.Leaf
      Else
         ' How do you determine if the project is saving to data base?
         ' Dataview and run query on the tab library table is one way.
         MyBase.ImageIndex = ProjectTreeNodeImage.Link
      End If
   End Sub

   Enum ProjectTreeNodeImage
      Leaf
      DataLink
      Link
   End Enum
End Class
