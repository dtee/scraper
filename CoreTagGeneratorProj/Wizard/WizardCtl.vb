Public Class WizardCtl
   Public Property ContorlName() As String
      Get
         Return Me.Label1.Text
      End Get
      Set(ByVal value As String)
         Me.Label1.Text = value
      End Set
   End Property

   Private _Dt As DataTable
   Public ReadOnly Property DT() As DataTable
      Get
         Return _Dt
      End Get
   End Property

   Private _DirName As String
   Public Property DirName() As String
      Get
         Return _DirName
      End Get
      Set(ByVal value As String)
         _DirName = value

         If value IsNot Nothing Then
            _Dt = New DataTable

            _Dt.ReadXmlSchema(_DirName & "\data1.xml.schme")
            _Dt.ReadXml(_DirName & "\data1.xml")

            Me.RichTextBox1.Text = System.IO.File.ReadAllText(_DirName & "\data1.html")

            Me.DataGridView1.DataSource = _Dt

         Else
            _Dt = Nothing
         End If
      End Set
   End Property

   Private _TagTree As TagTree
   Public Property TagTree() As TagTree
      Get
         Return _TagTree
      End Get
      Set(ByVal value As TagTree)
         Me._TagTree = value
         If value IsNot Nothing Then Me.TagTreeView1.TagTree = _TagTree
      End Set
   End Property

   Public ReadOnly Property Content() As String
      Get
         Return Me.RichTextBox1.Text
      End Get
   End Property

   Private Sub WizardCtl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Private Sub TagTreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TagTreeView1.AfterSelect
      Me.TagNodeInfoControl1.TagTreeNode = Me.TagTreeView1.SelectedNode
   End Sub
End Class
