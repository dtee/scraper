
Public Class TagNode
   Inherits Windows.Forms.TreeNode
   Public Shared ErrorForeColor As Color = Color.Red
   Public Shared ErrorBackColor As Color = Color.Yellow

   Public MatchListIndex As New List(Of Integer)
   Public TagTreeView As TagTreeView

   Private _ScraperNode As ScraperNode = Nothing
   Public Property ScraperNode() As ScraperNode
      Get
         Return _ScraperNode
      End Get
      Set(ByVal value As ScraperNode)
         _ScraperNode = value
      End Set
   End Property

   Public Overloads ReadOnly Property FirstNode() As TagNode
      Get
         Return MyBase.FirstNode
      End Get
   End Property

   Public Property IsSharedTag() As Boolean
      Get
         Return _Row.IsSharedTag
      End Get
      Set(ByVal value As Boolean)
         _Row.IsSharedTag = value
      End Set
   End Property

   Friend _Row As ScraperDB.TagLibraryRow
   Public ReadOnly Property Row() As ScraperDB.TagLibraryRow
      Get
         Return _Row
      End Get
   End Property

   Public Sub New(ByVal _Row As ScraperDB.TagLibraryRow, ByVal TagTreeView As TagTreeView)
      Me.TagTreeView = TagTreeView

      Me._Row = _Row
      Text = _Row.TagName
      CalculteImageIndex()
   End Sub

   Public Overloads Property ImageIndex() As Integer
      Get
         Return MyBase.ImageIndex
      End Get
      Set(ByVal value As Integer)
         ' Do nothing
      End Set
   End Property

   ''' <summary>
   ''' Calculate image index based on the information proved by _Row
   ''' </summary>
   ''' <remarks></remarks>
   Friend Sub CalculteImageIndex()
      If Me.IsParent Then
         If Me.IsSaveData AndAlso Me.IsDataTable Then
            MyBase.ImageIndex = TagImageIndex.ParentChildSave
         ElseIf Me.IsSaveData AndAlso Not Me.IsDataTable Then
            MyBase.ImageIndex = TagImageIndex.ParentChild
         ElseIf Not Me.IsSaveData AndAlso Me.IsDataTable Then
            MyBase.ImageIndex = TagImageIndex.ParentSave
         Else
            MyBase.ImageIndex = TagImageIndex.Parent
         End If
      Else
         ' Child Tag
         If Me.IsSaveData Then
            MyBase.ImageIndex = TagImageIndex.ChildSave
         Else
            MyBase.ImageIndex = TagImageIndex.Child
         End If
      End If

      MyBase.SelectedImageIndex = ImageIndex
      'MyBase.StateImageIndex = Me.ImageIndex

      ' If i am saving then update parent node!
      ' Ideally, this should not update parent, but happens to check on draw.
      If Me.Parent IsNot Nothing Then
         Me.Parent.CalculteImageIndex()
      End If
   End Sub

   ''' <summary>
   ''' TagID is unique, thus can not be changed.
   ''' </summary>
   ''' <value></value>6
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TagID() As Integer
      Get
         Return _Row.TagID
      End Get
   End Property

   ''' <summary>
   ''' This is a parent node if there is nodes below me
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsParent() As Boolean
      Get
         Return Me.Nodes.Count > 0
      End Get
   End Property

   Public ReadOnly Property ParentID() As Integer
      Get
         If (Parent Is Nothing) Then
            Return -1
         End If
         Return Parent.TagID
      End Get
   End Property

   Public ReadOnly Property IsDataTable() As Boolean
      Get
         If Not Me.IsParent Then
            Return False
         End If

         For Each t As TagNode In Nodes
            If t.IsSaveData Then
               Return True
            End If
         Next

         Return False
      End Get
   End Property


   Public Sub UpdateData()
      _Row.OrderNumber = MyBase.Index
   End Sub

   ''' <summary>
   ''' Remove the Node and Delete the _Row
   ''' </summary>
   ''' <remarks></remarks>
   Public Shadows Sub Remove()
      Dim pnode As TagNode = Me.Parent
      ' Remove _Row
      MyBase.Remove()
      _Row.Delete()

      If pnode IsNot Nothing Then pnode.CalculteImageIndex()
   End Sub

   Public ReadOnly Property IsRootTagNode() As Boolean
      Get
         Return Me Is Me.TagTreeView.RootNode
      End Get
   End Property

   ''' <summary>
   ''' Add a new node below
   ''' </summary>
   ''' <param name="TagName">Name of the new node</param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AddNode(ByVal TagName As String) As TagNode
      Return Me.TagTreeView.CreateNode(TagName, Me)
   End Function

   ''' <summary>
   ''' Set Parent Node. (this remove current node from it's current parent and add to the new parent.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Overloads Property Parent() As TagNode
      Get
         Return MyBase.Parent
      End Get
      Set(ByVal value As TagNode)
         Dim p As TagNode = MyBase.Parent

         If p IsNot Nothing And value IsNot Nothing Then
            p.Nodes.Remove(Me)
            value.Nodes.Add(Me)

            Me.Row.TagLibraryRowParent = value.Row
            p.UpdateData()
            value.UpdateData()

            ' Possible to change to a differnt parent
            Me.TagTreeView = p.TagTreeView
         End If
         Me.CalculteImageIndex()
      End Set
   End Property

   ''' <summary>
   ''' Move current node up or down.
   ''' </summary>
   ''' <param name="Direction"></param>
   ''' <remarks></remarks>
   Public Sub MoveNode(ByVal Direction As TagTreeView.NodeMovement)
      Me.TagTreeView.MoveNode(Me, Direction)
   End Sub

#Region "Other"
   Public Overloads Property TagName() As String
      Get
         Return Text
      End Get
      Set(ByVal value As String)
         Me.Text = value
      End Set
   End Property

   Public Overloads Property Text() As String
      Get
         Return _Row.TagName
      End Get
      Set(ByVal value As String)
         MyBase.Text = value
         _Row.TagName = value

         ' Should this be called here?
         Dim isv As Boolean = Me.IsValid()
      End Set
   End Property

   Public Property StartTag() As String
      Get
         Return Scraper.StandardizeNewLine(_Row.StartTag)
      End Get
      Set(ByVal value As String)
         _Row.StartTag = value
      End Set
   End Property

   Public Property EndTag() As String
      Get
         Return Scraper.StandardizeNewLine(_Row.EndTag)
      End Get
      Set(ByVal value As String)
         _Row.EndTag = value
      End Set
   End Property

   Public Property MaxChars() As Integer
      Get
         Return _Row.MaxChars
      End Get
      Set(ByVal value As Integer)
         _Row.MaxChars = value
      End Set
   End Property

   Public Property DynamicCode() As String
      Get
         Return _Row.DynamicCode
      End Get
      Set(ByVal value As String)
         _Row.DynamicCode = value
      End Set
   End Property

   Public Property ProjectID() As Integer
      Get
         Return _Row.ProjectID
      End Get
      Set(ByVal value As Integer)
         _Row.ProjectID = value
      End Set
   End Property
#End Region

#Region "Booleans"
   Public Property IsURL() As Boolean
      Get
         Return _Row.IsURL
      End Get
      Set(ByVal value As Boolean)
         _Row.IsURL = value
      End Set
   End Property

   Public Property IsSaveData() As Boolean
      Get
         Return _Row.isSaveData
      End Get
      Set(ByVal value As Boolean)
         _Row.isSaveData = value
         CalculteImageIndex()
      End Set
   End Property

   Public Property IsReverseSearch() As Boolean
      Get
         Return _Row.isReverseSearch
      End Get
      Set(ByVal value As Boolean)
         _Row.isReverseSearch = value
      End Set
   End Property

   Public Property IsSingleRegex() As Boolean
      Get
         Return _Row.IsSingleRegex
      End Get
      Set(ByVal value As Boolean)
         _Row.IsSingleRegex = value
      End Set
   End Property

   Public Property IsOptional() As Boolean
      Get
         Return _Row.IsOptional
      End Get
      Set(ByVal value As Boolean)
         _Row.IsOptional = value
      End Set
   End Property

   Public Property IsAppendStartTag() As Boolean
      Get
         Return _Row.IsAppendStartTag
      End Get
      Set(ByVal value As Boolean)
         _Row.IsAppendStartTag = value
      End Set
   End Property

   Public Property IsAppendEndTag() As Boolean
      Get
         Return _Row.IsAppendEndTag
      End Get
      Set(ByVal value As Boolean)
         _Row.IsAppendEndTag = value
      End Set
   End Property

   Public Property IsStartTagRegex() As Boolean
      Get
         Return _Row.IsStartTagRegex
      End Get
      Set(ByVal value As Boolean)
         _Row.IsStartTagRegex = value
      End Set
   End Property

   Public Property IsEndTagRegex() As Boolean
      Get
         Return _Row.IsEndTagRegex
      End Get
      Set(ByVal value As Boolean)
         _Row.IsEndTagRegex = value
      End Set
   End Property
#End Region

   Friend _ErrorList As New List(Of String)
   Public ReadOnly Property ErrorList() As List(Of String)
      Get
         Return _ErrorList
      End Get
   End Property

   Private NormalForeColor As Color
   Private NormalBackColor As Color

   ''' <summary>
   ''' Check Validity of the fields
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsValid() As Boolean
      Get
         _ErrorList.Clear()
         Dim mValid As Boolean = True

         ' Check Fields
         ' Check StartTag and EndTag

         ' Check Data Field Names
         _IsTagNameValid = CheckTagName()
         mValid = mValid And _IsTagNameValid

         If Not mValid Then
            MyBase.ForeColor = ErrorForeColor
            MyBase.BackColor = ErrorBackColor
         Else
            Me.NormalBackColor = Me.BackColor
            Me.NormalForeColor = Me.ForeColor

            If Me.ForeColor <> ErrorForeColor Then
               Me.ForeColor = NormalForeColor
            End If

            If Me.BackColor <> ErrorBackColor Then
               Me.BackColor = NormalBackColor
            End If
         End If

         Return mValid
      End Get
   End Property

   Public _IsTagNameValid As Boolean
   ''' <summary>
   ''' Return true if IsTagNameValid is valid. 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks>
   ''' This function assumes IsValid is called in advanced. If IsValid is not yet called, 
   ''' Invalid Name maybe returned as valid
   ''' </remarks>
   Public ReadOnly Property IsTagNameValid() As Boolean
      Get
         Return _IsTagNameValid
      End Get
   End Property

   ''' <summary>
   ''' Check Tag Name to see if it valid
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Friend Function CheckTagName() As Boolean
      Dim amValid As Boolean = True
      ' Make sure field names are unique
      Dim pNode As TagNode = Me.Parent

      Dim sList As New List(Of String)
      If pNode IsNot Nothing Then
         For Each n As TagNode In pNode.Nodes
            If (sList.Contains(Me.TagName)) Then
               Me._ErrorList.Add("TagNode is not Valid")
               Return False
            End If

            If n IsNot Me Then
               sList.Add(n.TagName)
            End If
         Next
      End If

      Return True
   End Function


   Enum TagImageIndex
      Child = 0
      ChildSave = 1
      Parent = 2
      ParentSave = 3
      ParentChild = 4
      ParentChildSave = 5

      'ParentData
      ParentDataSave = 6         ' Data and being saved in some dt
      Root = 7
      Clone = 8
   End Enum
End Class
