''' <summary>
''' TagTreeView inherits from Windows.Forms.TreeView and provides specific functions for the program.
''' </summary>
''' <remarks></remarks>
Public Class TagTreeView
   Inherits Windows.Forms.TreeView

   ' Occurs when the tree itself changed -> node movement, new node, etc.

   Private _RootNode As TagTreeNode
   ''' <summary>
   ''' Parent Node
   ''' </summary>
   ''' <returns>Parent Node to start navigation from.</returns>
   ''' <remarks></remarks>
   Public ReadOnly Property RootNode() As TagTreeNode
      Get
         Return _RootNode
      End Get
   End Property

   ''' <summary>
   ''' Function check for validity of TagTree for valid table name and fieldNames
   ''' Table name - IsDataTable TagNode must have unique names
   ''' Field Name - IsSaveDataTable TagNodes must have unique names
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property IsValidTree() As Boolean
      Get
         Return IsValidNode(Me.RootNode)
      End Get
   End Property

   ''' <summary>
   ''' Check to see anyone is valid.
   ''' </summary>
   ''' <param name="aNode"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function IsValidNode(ByVal aNode As TagTreeNode) As Boolean
      Dim isValid As Boolean = aNode.IsValid

      For Each n As TagTreeNode In aNode.Nodes
         isValid = isValid And IsValidNode(n)
      Next

      Return isValid
   End Function

   Private _TagTree As TagTree
   ''' <summary>
   ''' TagTree
   ''' </summary>
   ''' <value>Create nodes recursively.</value>
   ''' <returns>return tagtree</returns>
   ''' <remarks>
   ''' _TagTree guarantee Rootnode to be soemthing, it will never be nothing.</remarks>
   Public Property [TagTree]() As TagTree
      Get
         Return _TagTree
      End Get
      Set(ByVal value As TagTree)
         _TagTree = value

         If value IsNot Nothing Then
            MyBase.Nodes.Clear()

            _RootNode = New TagTreeNode(_TagTree.RootNode, Me)
            RecursiveLoadTree(_RootNode)

            MyBase.Nodes.Add(_RootNode)

            Me.SelectedNode = Me._RootNode
            MyBase.ExpandAll()
         End If
      End Set
   End Property

   ''' <summary>
   ''' Load the tag tree recursively
   ''' </summary>
   ''' <param name="parentNode"></param>
   ''' <remarks></remarks>
   Public Sub RecursiveLoadTree(ByVal parentNode As TagTreeNode)
      For Each node As TagNode In parentNode.TagNode.TagNodeList
         Dim t As New TagTreeNode(node, Me)

         parentNode.Nodes.Add(t)
         RecursiveLoadTree(t)
      Next
   End Sub

   ''' <summary>
   ''' Create a node
   ''' </summary>
   ''' <param name="name">Name of new tag node</param>
   ''' <param name="anode">parent node, if the node is nothing, the creates the root node.</param>
   ''' <param name="isBelow">If true, create a node below the given not.</param>
   ''' <remarks>
   ''' Raiseevent - TreeChanged
   ''' </remarks>
   Public Function CreateNode(ByVal name As String, ByVal anode As TagTreeNode, Optional ByVal isBelow As Boolean = False) As TagTreeNode
      Dim tNode As TagTreeNode
      If isBelow Then
         Dim pnode As TagTreeNode = anode.Parent
         Dim newNode As TagNode = pnode.TagNode.NewNode

         tNode = New TagTreeNode(newNode, Me)
         pnode.Nodes.Add(tNode)

         ' Move to the position below anode.
         While (tNode.PrevNode IsNot anode)
            Me.MoveNode(tNode, NodeMovement.Up)
         End While
         pnode.Expand()
      Else
         Dim pnode As TagTreeNode = anode
         Dim newNode As TagNode = pnode.TagNode.NewNode

         tNode = New TagTreeNode(newNode, Me)
         pnode.Nodes.Add(tNode)
         pnode.Expand()
      End If

      Me.TriggerTreeChanged()
      Return tnode
   End Function

   ''' <summary>
   ''' Delete a node in the tree
   ''' </summary>
   ''' <param name="node"></param>
   ''' <remarks>
   ''' Calls node.Remove which remove the node itself, the row and all of it's child row.
   ''' Raiseevent - TreeChanged
   ''' </remarks>
   Public Sub DeleteNode(ByVal node As TagTreeNode)
      node.Remove()

      Me.TriggerTreeChanged()
   End Sub

   ''' <summary>
   ''' Move a node into another node.
   ''' </summary>
   ''' <param name="destNode"></param>
   ''' <param name="sourceNode"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function MoveNode(ByVal destNode As TagTreeNode, ByVal sourceNode As TagTreeNode) As Boolean
      ' Change the order
      If (IsDropAllowed(destNode, sourceNode)) Then
         sourceNode.Parent = destNode
      End If
      destNode.UpdateData()
      sourceNode.UpdateData()

      Me.TriggerTreeChanged()
   End Function

   ''' <summary>
   ''' Return true if the drop is allowed
   ''' </summary>
   ''' <param name="destNode">Destiation node</param>
   ''' <param name="sourceNode">Source Node</param>
   ''' <returns>True if moveable, else false.</returns>
   ''' <remarks></remarks>
   Public Function IsDropAllowed(ByVal destNode As TagTreeNode, ByVal sourceNode As TagTreeNode) As Boolean
      Dim tnCurrent As TagTreeNode = destNode

      Do Until tnCurrent Is Nothing
         If tnCurrent Is sourceNode Then
            Return False
         End If
         tnCurrent = tnCurrent.Parent
      Loop

      Return True
   End Function

   ''' <summary>
   ''' Move node with the same parent, this function is for moving node up and down.
   ''' </summary>
   ''' <param name="targetNode"></param>
   ''' <param name="op">Move node up or down</param>
   ''' <remarks>
   ''' Raiseevent - TreeChanged</remarks>
   Public Sub MoveNode(ByVal targetNode As TagTreeNode, ByVal op As NodeMovement)
      Dim pNode As TagTreeNode = targetNode.Parent
      'Dim nodeQueue As New Queue(pNode.LastNode.Index + 1)

      Dim nodeQueue As New LinkedList(Of TagTreeNode)

      Dim checknode As TagTreeNode = targetNode.PrevNode
      If op = NodeMovement.Down Then
         checknode = targetNode.NextNode
      End If

      ' Using ienumator becuase we need to move two node sometime
      Dim iemu As IEnumerator = pNode.Nodes.GetEnumerator
      While iemu.MoveNext
         If (iemu.Current Is checknode) Then
            If op = NodeMovement.Down Then
               nodeQueue.AddLast(iemu.Current)
               nodeQueue.AddLast(targetNode)
            Else
               nodeQueue.AddLast(targetNode)
               nodeQueue.AddLast(iemu.Current)
            End If
         ElseIf iemu.Current Is targetNode Then
            ' DO NOTHING - 
         Else
            nodeQueue.AddLast(iemu.Current)
         End If
      End While

      pNode.Nodes.Clear()

      For Each tNode As TagTreeNode In nodeQueue
         pNode.Nodes.Add(tNode)
         tNode.UpdateData()
      Next
      Me.SelectedNode = targetNode

      Me.TriggerTreeChanged()
   End Sub

   Public Enum NodeMovement
      Up
      Down
   End Enum

   ''' <summary>
   ''' Update each tag library row in the data base table with the correct node order number. 
   ''' </summary>
   ''' <remarks> Does recursion call on private function UpdateOrder.</remarks>
   Public Sub UpdateOrder()
      UpdateOrder(Me.RootNode)
   End Sub

   ''' <summary>
   ''' Update each tag library row in the data base table with the correct node order number. 
   ''' </summary>
   ''' <param name="node">parent node</param>
   ''' <remarks>
   ''' call node.updatedata which update the data row with the index.
   ''' </remarks>
   Private Sub UpdateOrder(ByVal node As TagTreeNode)
      For Each n As TagTreeNode In node.Nodes
         n.UpdateData()
         UpdateOrder(n)
      Next
   End Sub

   ''' <summary>
   ''' Overloads selected node, returns the current selected TagNode
   ''' </summary>
   ''' <value>Node to be selected</value>
   ''' <returns>Selected Node</returns>
   ''' <remarks></remarks>
   Public Overloads Property SelectedNode() As TagTreeNode
      Get
         Return MyBase.SelectedNode
      End Get
      Set(ByVal value As TagTreeNode)
         MyBase.SelectedNode = value
      End Set
   End Property

   Private _OldSelectedNode As TagTreeNode
   ''' <summary>
   ''' TempSelectedNode, setting this will tempori
   ''' </summary>
   ''' <value>If nothing, set the selected TagNode to previous selected TagNode</value>
   ''' <returns>Current selected TagNode</returns>
   ''' <remarks>
   ''' This function is used to simulate File explorer like selection. 
   ''' Example: The node being dragged under or right clicked will be heighlighted.
   ''' </remarks>
   Public Property TempSelectedNode() As TagTreeNode
      Get
         Return MyBase.SelectedNode
      End Get
      Set(ByVal value As TagTreeNode)

         If value Is Nothing Then
            MyBase.SelectedNode = _OldSelectedNode
         Else
            _OldSelectedNode = MyBase.SelectedNode
            MyBase.SelectedNode = value
         End If
      End Set
   End Property

   Public Event TreeChanged()
   ''' <summary>
   ''' Tree Changed is triggered - Update Scraper, which updates it's data tables
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub TriggerTreeChanged()
      Me.UpdateOrder()
      '_Scraper.TagTreeView = Me
      RaiseEvent TreeChanged()
   End Sub
End Class
