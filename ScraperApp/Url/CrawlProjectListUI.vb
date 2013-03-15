Public Class CrawlProjectListUI

   Private Sub CrawlProjectListUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Private _CrawlProjectManager As CrawlProjectManager
   Private _CrawlProject As CrawlProject = Nothing

   Public ReadOnly Property CrawlProject()
      Get
         Return _CrawlProject
      End Get
   End Property

   Public Sub New(ByVal aCrawlProjectManager As CrawlProjectManager)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Open all the freaking objects, no paging whatsoever.
      Me._CrawlProjectManager = aCrawlProjectManager
      Me._CrawlProjectManager.LoadProjects()

      Me.ProjectsDataGridView.AutoGenerateColumns = False
      Me.ProjectsDataGridView.DataSource = Me._CrawlProjectManager.ProjectDT
      Me.projectName.DataPropertyName = Me._CrawlProjectManager.ProjectDT.NameColumn.ColumnName
   End Sub


   Private Sub OpenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenButton.Click
      If Me.ProjectsDataGridView.SelectedRows.Count > 0 Then
         Dim dRowView As DataRowView = Me.ProjectsDataGridView.SelectedRows(0).DataBoundItem
         Dim row As ScraperDB.CrawlProjectRow = dRowView.Row
         Dim projectID As Integer = row.CrawlProjectID

         Try
            Me._CrawlProject = Me._CrawlProjectManager.loadCrawlProject(row.CrawlProjectID)
            Me.DialogResult = Windows.Forms.DialogResult.OK
         Catch ex As Exception
            MsgBox("Error loading project: " & ex.Message)
         End Try

         Me.Close()
      Else
         MsgBox("Please select a project to open.")
      End If
   End Sub

   Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click

      If Me.ProjectsDataGridView.SelectedRows.Count > 0 Then
         Dim dRowView As DataRowView = Me.ProjectsDataGridView.SelectedRows(0).DataBoundItem
         Dim row As ScraperDB.CrawlProjectRow = dRowView.Row
         Dim projectID As Integer = row.CrawlProjectID

         If MsgBox("Delete Project and all it's datatables?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Try
               Me._CrawlProjectManager.deleteProject(projectID)
            Catch ex As Exception
               MsgBox("Error Deleting Project: " & ex.Message)
            End Try
         End If
      Else
         MsgBox("Please select a project to delete.")
      End If

   End Sub
End Class