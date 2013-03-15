Public Class LinkMappingControl
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Private _CrawlProject As CrawlProject
   Private _LinkMappingManager As LinkMappingManager

   Public Property CrawlProject() As CrawlProject
      Get
         Return Me._CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         Me._CrawlProject = value

         If Me._CrawlProject IsNot Nothing Then
            Me.ProjectLinkTreeView.Nodes.Clear()
            Dim linkNode As New LinkMappingTreeNode()
            linkNode.CrawlProject = Me._CrawlProject
            Me.ProjectLinkTreeView.Nodes.Add(linkNode)
            linkNode.ExpandAll()

            '' Data table stuffs
            Me.DatasetTreeView.Nodes.Clear()
            Dim dsNode As New DatasetTreeNode()
            dsNode.CrawlProject = Me._CrawlProject
            Me.DatasetTreeView.Nodes.Add(dsNode)
            dsNode.ExpandAll()

            ' Load the Taglist
            Me._LinkMappingManager = Me._CrawlProject.LinkMapManager

            InitDataTypeButtons()
         End If
      End Set
   End Property

   ''' <summary>
   ''' Load data types into the context menu
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub InitDataTypeButtons()

      ' Load the data type list
      Me.DataTypeContextMenuStrip.Items.Clear()

      For Each dataType As DataType In Me._CrawlProject.DataTypeManager.DataTypeList
         Dim button As New ToolStripMenuItem(dataType.DataTypeName)
         button.Tag = dataType
         button.CheckOnClick = True
         Me.DataTypeContextMenuStrip.Items.Add(button)
      Next
   End Sub



   ''' <summary>
   ''' Reset the crawl project, it will reload everything.
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub RefreshToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripButton.Click
      Me.CrawlProject = Me._CrawlProject
   End Sub

   Private Sub LinkMappingContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles LinkMappingContextMenuStrip.ItemClicked
      If e.ClickedItem Is Me.RefreshToolStripButton Then
         Me.ProjectLinkTreeView.Refresh()
      ElseIf e.ClickedItem Is Me.RemoveToolStripMenuItem Then
         Dim urlTreeNode As UrlTreeNode = Me.ProjectLinkTreeView.SelectedNode.Parent
         urlTreeNode.removeLink(Me.ProjectLinkTreeView.SelectedNode.Tag)
         Me.ProjectLinkTreeView.SelectedNode.Remove()
      End If
   End Sub

   Private Sub LinkMappingContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles LinkMappingContextMenuStrip.Opening
      ' Find the exact location.
      Me.AddToolStripMenuItem.Visible = False
      Me.RemoveToolStripMenuItem.Visible = False
      Me.PartialDataToolStripMenuItem.Visible = False

      If Me.ProjectLinkTreeView.SelectedNode IsNot Nothing Then
         If TypeOf (Me.ProjectLinkTreeView.SelectedNode) Is ProjectTreeNode Then

         ElseIf TypeOf (Me.ProjectLinkTreeView.SelectedNode) Is UrlTreeNode Then
            Me.AddToolStripMenuItem.Visible = True

            Dim urlTreeNode As UrlTreeNode = Me.ProjectLinkTreeView.SelectedNode

            ' Add Project to the list
            Me.ProjectsContextMenuStrip.Items.Clear()
            For Each proj As Project In _CrawlProject.LinkMapManager.getOtherProjects(urlTreeNode.TagNode)
               Dim button As New ToolStripMenuItem(proj.ProjectName)
               button.Tag = proj
               Me.ProjectsContextMenuStrip.Items.Add(button)
            Next
         ElseIf TypeOf (Me.ProjectLinkTreeView.SelectedNode) Is LinkProjectTreeNode Then
            If ProjectLinkTreeView.TopNode IsNot ProjectLinkTreeView.SelectedNode Then
               Me.RemoveToolStripMenuItem.Visible = True
               Me.PartialDataToolStripMenuItem.Visible = True

               Dim m As LinkProjectTreeNode = Me.ProjectLinkTreeView.SelectedNode
               Me.PartialDataToolStripMenuItem.Checked = m.IsPartialData
            End If
         End If
      End If
   End Sub

   Private Sub DatasetContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles DatasetContextMenuStrip.ItemClicked
      If e.ClickedItem Is Me.IdentifierToolStripMenuItem Then
         If TypeOf (Me.DatasetTreeView.SelectedNode) Is FieldTreeNode Then
            Dim fieldNode As FieldTreeNode = Me.DatasetTreeView.SelectedNode
            ' Show the content menu
            fieldNode.isIdentifier = Not Me.IdentifierToolStripMenuItem.Checked

            ' Show the datatype context menu
         Else

         End If
      End If
   End Sub

   Private Sub DatasetContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DatasetContextMenuStrip.Opening
      Me.DataTypeToolStripMenuItem.Visible = False

      If TypeOf (Me.DatasetTreeView.SelectedNode) Is FieldTreeNode Then
         Dim fieldNode As FieldTreeNode = Me.DatasetTreeView.SelectedNode
         ' Show the content menu
         Me.IdentifierToolStripMenuItem.Checked = fieldNode.isIdentifier
         Me.DataTypeToolStripMenuItem.Visible = True
      Else
         e.Cancel = True
      End If
   End Sub

#Region "Context menu: add projects"
   Private Sub ProjectsContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ProjectsContextMenuStrip.ItemClicked
      Dim urlTreeNode As UrlTreeNode = Me.ProjectLinkTreeView.SelectedNode
      urlTreeNode.AddProject(e.ClickedItem.Tag)
   End Sub

   Private Sub ProjectsContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ProjectsContextMenuStrip.Opening
      ' Add projects
   End Sub
#End Region

   Private Sub PartialDataToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PartialDataToolStripMenuItem.CheckedChanged
      Dim m As LinkProjectTreeNode = Me.ProjectLinkTreeView.SelectedNode
      m.IsPartialData = PartialDataToolStripMenuItem.Checked
   End Sub

   Private Sub DataTypeContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles DataTypeContextMenuStrip.ItemClicked
      If TypeOf (Me.DatasetTreeView.SelectedNode) Is FieldTreeNode Then
         ' See if the user selected or not
         Dim but As ToolStripMenuItem = e.ClickedItem

         Dim selectedFieldTreeNode As FieldTreeNode = Me.DatasetTreeView.SelectedNode

         Dim datatype As DataType = but.Tag
         For Each node As TagNode In selectedFieldTreeNode.TagNodeList
            node.DataType = datatype
            'node.Row.DataTypeRow = datatype.Row
         Next
      End If
   End Sub

   Private Sub DataTypeContextMenuStrip_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DataTypeContextMenuStrip.Opening
      ' Check the selected tagnode's data type
      If TypeOf (Me.DatasetTreeView.SelectedNode) Is FieldTreeNode Then
         Dim selectedFieldTreeNode As FieldTreeNode = Me.DatasetTreeView.SelectedNode

         Dim datatype As DataType = Me._CrawlProject.DataTypeManager.getDataType( _
               selectedFieldTreeNode.TagNode.Row.DataTypeRow)

         datatype = selectedFieldTreeNode.TagNode.DataType

         ' Select the data type
         For Each button As ToolStripMenuItem In Me.DataTypeContextMenuStrip.Items
            If button.Tag Is datatype Then
               button.Checked = True
            Else
               button.Checked = False
            End If
         Next
      End If
   End Sub
End Class
