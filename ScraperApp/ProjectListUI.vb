Public Class ProjectListUI
   Private Sub ProjectListUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
   End Sub

   Private _ProjectManager As ProjectManager
   Private _CrawlProject As CrawlProject

   Public Property CrawlProject() As CrawlProject
      Get
         Return _CrawlProject
      End Get
      Set(ByVal value As CrawlProject)
         Me._CrawlProject = value
         Me._SelectedProjects = New List(Of Project)

         Me._ProjectManager = _CrawlProject.ProjectManager
         Me.ProjectListCheckedListBox.DataSource = Me._ProjectManager.ProjectList
         Me.ProjectListCheckedListBox.DisplayMember = "ProjectName"
      End Set
   End Property

   Private _SelectedProjects As List(Of Project)
   Public ReadOnly Property SelectedProjects() As List(Of Project)
      Get
         Return Me._SelectedProjects
      End Get
   End Property

   Private Sub OpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click
      If Me.ProjectListCheckedListBox.SelectedItems.Count = 0 Then
         MsgBox("Please select project(s) to open.")
      End If

      For Each proj As Project In Me.ProjectListCheckedListBox.SelectedItems
         Me._SelectedProjects.Add(proj)
      Next

      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
      Me._ProjectManager.newProject()

      Me.ProjectListCheckedListBox.DataSource = Nothing
      Me.ProjectListCheckedListBox.DataSource = Me._ProjectManager.ProjectList
      Me.ProjectListCheckedListBox.DisplayMember = "ProjectName"
   End Sub

   Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
      If Me.ProjectListCheckedListBox.SelectedItems.Count = 0 Then
         MsgBox("Please select project(s) to delete.")
      Else
         If MsgBox("Are you sure you to remove " & Me.ProjectListCheckedListBox.SelectedItems.Count & " projects?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each proj As Project In Me.ProjectListCheckedListBox.SelectedItems
               Me._CrawlProject.ProjectManager.removeProject(proj)
            Next

            Me.ProjectListCheckedListBox.DataSource = Nothing
            Me.ProjectListCheckedListBox.DataSource = Me._ProjectManager.ProjectList
            Me.ProjectListCheckedListBox.DisplayMember = "ProjectName"
         End If
      End If
   End Sub
End Class