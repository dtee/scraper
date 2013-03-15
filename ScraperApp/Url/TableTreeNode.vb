Public Class DatasetTreeNode
   Inherits TreeNode

   Private _CrawlProject As CrawlProject

   Public Sub New()
      MyBase.Text = "Dataset"
   End Sub

   Public Property CrawlProject() As CrawlProject
      Get
         Return Me._CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         Me._CrawlProject = value
         refresh()
      End Set
   End Property

   Public Sub refresh()
      ' We need to give it only the datatables.
      Dim dic As New Dictionary(Of String, TableTreeNode)
      For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
         ' User need to see the datatable generated. 
         For Each node As TagNode In proj.TagTree.DataTagNodes
            ' Combine nodes
            If dic.ContainsKey(node.TagName) Then
               dic(node.TagName).addDataNode(node)
            Else
               Dim tblNode As New TableTreeNode(node)
               Me.Nodes.Add(tblNode)
               dic.Add(node.TagName, tblNode)
            End If
         Next
      Next
   End Sub
End Class

Public Class TableTreeNode
   Inherits TreeNode
   Private _NodeList As List(Of TagNode)
   Private _TagNode As TagNode

   Public Sub New(ByVal node As TagNode)
      Me._TagNode = node

      _NodeList = New List(Of TagNode)
      Me.refresh()

      Me.addDataNode(node)
   End Sub

   Public Sub refresh()
      MyBase.Text = Me._TagNode.TagName
      Me.Nodes.Clear()

      MyBase.ImageIndex = DatasetImageList.DataTable
      MyBase.SelectedImageIndex = MyBase.ImageIndex
   End Sub

   ''' <summary>
   ''' Add a new field/column to the list.
   ''' </summary>
   ''' <param name="value"></param>
   ''' <remarks></remarks>
   Private Sub addFieldNode(ByVal value As TagNode)
      ' make sure the new value is being saved
      If Not value.IsSaveData Then Exit Sub

      Dim isExists As Boolean = False

      ' see if i contains the value
      For Each node As FieldTreeNode In Me.Nodes
         If node.Text = value.TagName Then
            isExists = True
            node.addFieldNode(value)
            Exit For
         End If
      Next

      If Not isExists Then
         ' Add a new node
         Me.Nodes.Add(New FieldTreeNode(value))
      End If
   End Sub

   ''' <summary>
   ''' Add a data table node
   ''' </summary>
   ''' <param name="value"></param>
   ''' <remarks></remarks>
   Public Sub addDataNode(ByVal value As TagNode)
      If value.TagName.Equals(Me._TagNode.TagName) Then
         Me._NodeList.Add(value)

         For Each node As TagNode In value.TagNodeList
            If node.Row.isSaveData Then
               Me.addFieldNode(node)
            End If
         Next
      End If
   End Sub

   Public Property TableName() As String
      Get
         Return Me._TagNode.Row.TableName
      End Get
      Set(ByVal value As String)
         For Each node As TagNode In Me._NodeList
            node.Row.TableName = value
         Next
      End Set
   End Property
End Class


''' <summary>
''' Data Field Node
''' </summary>
''' <remarks></remarks>
Public Class FieldTreeNode
   Inherits TreeNode

   Private _TagNode As TagNode
   Private _NodeList As List(Of TagNode)

   Public ReadOnly Property TagNodeList() As List(Of TagNode)
      Get
         Return Me._NodeList
      End Get
   End Property

   Public Sub New(ByVal node As TagNode)
      Me._TagNode = node

      Me._NodeList = New List(Of TagNode)
      Me._NodeList.Add(Me._TagNode)

      Me.refresh()
   End Sub

   Public ReadOnly Property TagNode() As TagNode
      Get
         Return Me._TagNode
      End Get
   End Property

   Public Sub refresh()
      MyBase.Text = Me._TagNode.TagName

      ' Identifier, then change image
      If Me._TagNode.Row.IsIdentfier Then
         MyBase.ImageIndex = DatasetImageList.KeyField
      Else
         MyBase.ImageIndex = DatasetImageList.Field
      End If

      MyBase.SelectedImageIndex = MyBase.ImageIndex
   End Sub

   Public Sub addFieldNode(ByVal node As TagNode)
      Me._NodeList.Add(node)
   End Sub

   Public Property FieldName() As String
      Get
         Return Me._TagNode.Row.FieldName
      End Get
      Set(ByVal value As String)
         For Each node As TagNode In Me._NodeList
            node.Row.FieldName = value
         Next
      End Set
   End Property

   Public Property isIdentifier() As Boolean
      Get
         Return Me._TagNode.Row.IsIdentfier
      End Get
      Set(ByVal value As Boolean)
         For Each node As TagNode In Me._NodeList
            node.Row.IsIdentfier = value
         Next

         refresh()
      End Set
   End Property
End Class

''' <summary>
''' Image id for the Image list
''' </summary>
''' <remarks></remarks>
Enum DatasetImageList
   DataSet = 0
   DataTable = 1
   KeyField = 2
   Field = 3
End Enum