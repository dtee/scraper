Public Class TagNodeList
   Inherits List(Of TagNode)

   Public Overloads Sub add(ByVal TagNode As TagNode)
      MyBase.Add(TagNode)

      ' Get the node index in the list
      TagNode.Row.OrderNumber = MyBase.IndexOf(TagNode)
   End Sub

   Public Overloads Sub Remove(ByVal tagnode As TagNode)
      MyBase.Remove(tagnode)

      ' Renumber all the nodes
      For Each node As TagNode In Me
         node.Row.OrderNumber = MyBase.IndexOf(node)
      Next
   End Sub

   Public Overloads Sub Clear()
      While (Me.Count > 0)
         Dim node As TagNode = Me(0)
         node.Delete()
      End While
   End Sub

   ''' <summary>
   ''' Move the mode to the right place
   ''' </summary>
   ''' <param name="node"></param>
   ''' <param name="index"></param>
   ''' <remarks></remarks>
   Public Sub Move(ByVal node As TagNode, ByVal index As Integer)
      If index > Me.Count - 1 Or index < 0 Then Throw New Exception("Invalid index to move the node.")

      If node.Index = index Then Exit Sub ' Already at the right place

      Dim startIndex As Integer = index
      Dim stopIndex As Integer = node.Index

      If node.Index > index Then    ' Move up
         For i As Integer = stopIndex To (startIndex + 1) Step -1
            Me(i) = Me(i - 1)
         Next
         Me(startIndex) = node
      Else           ' Move down
         For i As Integer = stopIndex To (startIndex - 1)
            Me(i) = Me(i + 1)
         Next
         Me(startIndex) = node
      End If

      'MyBase.Remove(node)
      'MyBase.Insert(index, node)

      ' Successful move, recalculate index
      For Each tagnode As TagNode In Me
         tagnode.Row.OrderNumber = MyBase.IndexOf(tagnode)
         Console.WriteLine("Node " & tagnode.TagName & ", " & tagnode.Row.OrderNumber)
      Next
   End Sub
End Class
