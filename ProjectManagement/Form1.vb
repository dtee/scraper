Public Class Form1
   Private OpenFileDiag As OpenFileDialog
   Private MultiScraper As MultiScraper
   Private ProjectDA As New ScraperLib.ScraperDBTableAdapters.ProjectTableAdapter()

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      OpenFileDiag = New OpenFileDialog()
      OpenFileDiag.Filter = ""
      OpenFileDiag.CheckFileExists = True

      ' Open connection
      Me.conn.Open()

      ' Add any initialization after the InitializeComponent() call.
      MultiScraper = New MultiScraper
      Me.MultiScraper.SQLConnection = Me.conn
      Me.MultiScraper.LoadProjects()

      Me.DataGridView1.DataSource = Me.MultiScraper.ProjectDT
   End Sub

   Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

   End Sub

   Private Sub ImportToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripButton.Click
      Me.DoImport()
   End Sub

   Private Sub DoImport()
      ' 1.) Ask for project file path
      Dim prj As Project = Nothing
      Dim fileAdaptor As New FileScraperDataAdapter()

      If Me.OpenFileDiag.ShowDialog = Windows.Forms.DialogResult.OK Then
         fileAdaptor.ProjectFileName = Me.OpenFileDiag.FileName

         Try
            fileAdaptor.LoadProject()
            prj = fileAdaptor.Project
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            MsgBox("Unhandled Error: " & ex.Message)
         End Try
      End If

      ' 2.) Check Project Information
      If Not prj.TagTreeView.IsValidTree Then
         MsgBox("TreeView is not valid.")
         Exit Sub
      End If

      ' 3.) Check Saving Data table, there must be at least one!
      If prj.Scraper.ScraperTree.ScrapedDS.Tables.Count = 0 Then
         MsgBox("Project does not contain any Saving Data")
         Exit Sub
      End If

      ' All fine, lets import the project
      Me.MultiScraper.ImportProject(prj)
   End Sub

   Private conn As New SqlClient.SqlConnection(My.Settings.ScraperDBConnectionString)

   Private Sub CreateDataTableToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateDataTableToolStripButton.Click
      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As ScraperDB.ProjectRow = rv.Row
            Dim sda As New SQLDatabaseScraperAdapter(conn)
            sda.ProjectID = row.ProjectID
            sda.LoadProject()

            sda.CreateServerTables(True)
         End If
      Next
   End Sub

   Private Sub DoRemoveProjects()
      Dim digResult As Microsoft.VisualBasic.MsgBoxResult = MsgBoxResult.Yes
      If Me.DataGridView1.SelectedRows.Count > 1 Then
         digResult = MsgBox("Remove " & Me.DataGridView1.SelectedRows.Count & " Projects?", MsgBoxStyle.YesNo, "Remove Projects")
      End If

      If digResult = MsgBoxResult.No Then
         Exit Sub
      End If

      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As ScraperDB.ProjectRow = rv.Row
            Me.MultiScraper.DeleteProject(row.ProjectID)
         End If
      Next

      Try
         ' Best way to remove project is to open the project and use adaptor.remove
         ProjectDA.Update(Me.MultiScraper.ProjectDT)
      Catch ex As Exception
         Console.WriteLine(ex.Message)
      End Try
   End Sub

   Private Sub RemoveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripButton.Click
      Me.DoRemoveProjects()
   End Sub

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Me.MultiScraper.LoadProjects()  ' Load projects every 30 minute
   End Sub

   Private Sub StartProjectToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartProjectToolStripButton.Click
      Me.MultiScraper.NewStartAll()
      Me.Timer1.Interval = 30 * 1000 * 60 ' Set interval to 30 minute
      Me.Timer1.Start()
   End Sub

   Private Sub StopToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopToolStripButton.Click
      Me.MultiScraper.NewStopAll()
      Me.Timer1.Stop()
   End Sub
End Class