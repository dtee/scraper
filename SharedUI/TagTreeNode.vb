Imports ScraperLib
Imports System.Drawing

Public Class TagTreeNode
   Inherits Windows.Forms.TreeNode
   Public Shared ErrorForeColor As Color = Color.Red
   Public Shared ErrorBackColor As Color = Color.Yellow

   Private _Row As ScraperDB.TagLibraryRow
   Private _TagNode As TagNode
   Private _TagTreeView As TagTreeView

   Public MatchListIndex As New List(Of Integer)
   Public Sub New(ByVal t As TagNode, ByVal tv As TagTreeView)
      Me._Row = t.Row
      Me._TagTreeView = tv
      Me._TagNode = t
      MyBase.Text = Me._Row.TagName
   End Sub

   Public ReadOnly Property TagNode() As TagNode
      Get
         Return _TagNode
      End Get
   End Property

   Public ReadOnly Property Row() As ScraperDB.TagLibraryRow
      Get
         Return _Row
      End Get
   End Property

   ''' <summary>
   ''' Calculate image index based on the information proved by _Row
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub CalculteImageIndex()
      If Me._TagNode.IsParent Then
         If Me._Row.isSaveData AndAlso Me._Row.IsDataTable Then
            MyBase.ImageIndex = TagImageIndex.ParentChildSave
         ElseIf Me._Row.isSaveData AndAlso Not Me._Row.IsDataTable Then
            MyBase.ImageIndex = TagImageIndex.ParentChild
         ElseIf Not Me._Row.isSaveData AndAlso Me._Row.IsDataTable Then
            MyBase.ImageIndex = TagImageIndex.ParentSave
         Else
            MyBase.ImageIndex = TagImageIndex.Parent
         End If
      Else
         ' Child Tag
         If Me._Row.isSaveData Then
            MyBase.ImageIndex = TagImageIndex.ChildSave
         Else
            MyBase.ImageIndex = TagImageIndex.Child
         End If
      End If

      MyBase.SelectedImageIndex = ImageIndex

      ' If i am saving then update parent node!
      ' Ideally, this should not update parent, but happens to check on draw.
      If Me.Parent IsNot Nothing Then
         Me.Parent.CalculteImageIndex()
      End If
   End Sub

   Public Overloads Sub Refresh()
      MyBase.Text = Me._Row.TagName
      Me.CalculteImageIndex()

      ' Node order can also change

      ' Check for Error         If Not mValid Then
      If Not Me._TagNode.IsValid Then
         MyBase.ForeColor = ErrorForeColor
         MyBase.BackColor = ErrorBackColor
      Else
         MyBase.ForeColor = Color.Black
         MyBase.BackColor = Color.White

         'If Me.ForeColor <> ErrorForeColor Then
         '   MyBase.ForeColor = NormalForeColor
         'End If

         'If Me.BackColor <> ErrorBackColor Then
         '   MyBase.BackColor = NormalBackColor
         'End If
      End If

      If Me.Parent IsNot Nothing Then Me.Parent.Refresh()
   End Sub

   ''' <summary>
   ''' Remove the Node and Delete the _Row
   ''' </summary>
   ''' <remarks></remarks>
   Public Shadows Sub Remove()
      Dim pnode As TagTreeNode = Me.Parent
      ' Remove _Row
      MyBase.Remove()
      _TagNode.Delete()

      If pnode IsNot Nothing Then pnode.CalculteImageIndex()
   End Sub

   ''' <summary>
   ''' Set Parent Node. (this remove current node from it's current parent and add to the new parent.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Overloads Property Parent() As TagTreeNode
      Get
         Return MyBase.Parent
      End Get
      Set(ByVal value As TagTreeNode)
         Dim p As TagTreeNode = MyBase.Parent

         If p IsNot Nothing And value IsNot Nothing Then
            p.Nodes.Remove(Me)      ' Remove to parent
            value.Nodes.Add(Me)     ' Add to a new parent

            'Me.Row.TagLibraryRowParent = value.Row
            Me.TagNode.ParentTagNode = value.TagNode        ' Set tagNode to a new parent node

            ' We need to refresh the old parent's information somehow
            p.TagNode.refresh()
            p.Refresh()

            value.TagNode.refresh()
            value.Refresh()

         End If
      End Set
   End Property

   ''' <summary>
   ''' Move current node up or down.
   ''' </summary>
   ''' <param name="Direction"></param>
   ''' <remarks></remarks>
   Public Sub MoveNode(ByVal Direction As TagTreeView.NodeMovement)
      Me._TagTreeView.MoveNode(Me, Direction)
   End Sub

   Private NormalForeColor As Color
   Private NormalBackColor As Color

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
