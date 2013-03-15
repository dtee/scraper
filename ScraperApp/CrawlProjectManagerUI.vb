Public Class CrawlProjectManagerUI

   ''' <summary>
   ''' Try to connect to the given connection, and load database
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub CheckConnection()

   End Sub

   Private Sub ConnectionToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' 1. Show connection box
   End Sub

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me.DataGridView1.AutoGenerateColumns = False
      Me.DataGridView1.DataSource = Me._DT

      Me.ProjectName.DataPropertyName = "Name"
      Me.DateAdded.DataPropertyName = "DateAdded"
      Me.DateRun.DataPropertyName = "DateRun"
   End Sub

   Private _Conn As SqlClient.SqlConnection
   Private _DT As New ScraperDB.ProjectDataTable

   Private _CrawlProjectManger As CrawlProjectManager
   Public Property Connection() As SqlClient.SqlConnection
      Get
         Return _Conn
      End Get
      Set(ByVal value As SqlClient.SqlConnection)
         Me._Conn = value
         Me._CrawlProjectManger = New CrawlProjectManager(Me._Conn)

         If value IsNot Nothing Then
            ' Load Database tables
            DoRefresh()
         End If
      End Set
   End Property

   Public Sub DoRefresh()
      Me._CrawlProjectManger.LoadProjects()
   End Sub

   Private _ProjectID As Integer
   Public ReadOnly Property ProjectID() As Integer
      Get
         Return _ProjectID
      End Get
   End Property

   Private Sub SelectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectButton.Click
      If Me.DataGridView1.SelectedRows.Count = 0 Then
         MsgBox("You must select a project.")
      End If

      For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

         If rv IsNot Nothing Then
            Dim row As ScraperDB.ProjectRow = rv.Row
            Me._ProjectID = row.ProjectID
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         End If
      Next
   End Sub

   Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub ProjectManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   ''' <summary>
   ''' Create Server Tables, it's a bad idea. doesn't belong here!
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub CreateTableButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTableButton.Click
      'Me.Connection.Open()
      'For Each r As System.Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
      '   Dim rv As DataRowView = TryCast(r.DataBoundItem, System.Data.DataRowView)

      '   If rv IsNot Nothing Then
      '      Dim row As ScraperDB.ProjectRow = rv.Row
      '      Dim sda As New SQLDatabaseScraperAdapter(Me.Connection)
      '      sda.ProjectID = row.ProjectID
      '      sda.LoadProject()

      '      sda.CreateServerTables(True)
      '   End If
      'Next
      'Me.Connection.Close()
   End Sub
End Class