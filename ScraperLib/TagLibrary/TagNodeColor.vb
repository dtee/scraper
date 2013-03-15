Public Class TagNodeColor
   Public Shared LevelColor As Color() = {Color.LightBlue, Color.LightYellow, Color.Yellow, Color.LimeGreen, Color.LightGray}

   Public Shared Function GetLevelColor(ByVal level As Integer) As Color
      level = level Mod 5

      Return LevelColor(level)
   End Function

   Public Shared OrderColor As Color() = {Color.Black, Color.Blue, Color.Red, Color.Brown, Color.Green}
   Public Shared Function GetOrderColor(ByVal order As Integer) As Color
      order = order Mod 5
      Return OrderColor(order)
   End Function

   Public Shared Function SampleNodes() As TreeNode
      Dim RootNode As TreeNode = New TreeNode()
      RootNode.Text = String.Format("Node {0} - {1}", RootNode.Level, RootNode.Index)
      RootNode.BackColor = GetLevelColor(RootNode.Level)
      RootNode.ForeColor = GetOrderColor(RootNode.Index)

      For i As Integer = 0 To 7
         Dim t As New TreeNode
         RootNode.Nodes.Add(t)

         t.Text = String.Format("Node {0} - {1}", t.Level, t.Index)
         t.BackColor = GetLevelColor(t.Level)
         t.ForeColor = GetOrderColor(t.Index)
      Next

      Dim pNode As TreeNode = RootNode.FirstNode
      For i As Integer = 0 To 6
         Dim t As New TreeNode
         pNode.Nodes.Add(t)

         t.Text = String.Format("Node {0} - {1}", t.Level, t.Index)
         t.BackColor = GetLevelColor(t.Level)
         t.ForeColor = GetOrderColor(t.Index)

         pNode = t
      Next

      Return RootNode
   End Function
End Class
