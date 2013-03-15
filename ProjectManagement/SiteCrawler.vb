Imports ScraperLib

Public Class SiteCrawler
   Private conn As New SqlClient.SqlConnection(My.Settings.ScraperDBConnectionString)
   Private _CurrentProject As Project

   Public Property CurrentProject() As Project
      Get
         Return _CurrentProject
      End Get
      Set(ByVal value As Project)
         Me._CurrentProject = value

         ' Load project information
         Me.LoadProjetUI(Me.CurrentProject)
      End Set
   End Property

#Region "New, Open, Save"
   Private Sub OpenToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripButton.Click
      Dim pjm As New ProjectManagerUI(Me.conn)

      If pjm.ShowDialog() = Windows.Forms.DialogResult.OK Then
         Dim da As New ScraperLib.SQLDatabaseScraperAdapter(Me.conn)
         da.ProjectID = pjm.ProjectID
         da.LoadProject()
         Me.CurrentProject = da.Project
      End If
   End Sub

   Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click

   End Sub

   Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click

   End Sub

   ''' <summary>
   ''' Import Project from given file
   ''' </summary>
   ''' <param name="fileName"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function ImportProject(ByVal fileName As String) As Project
      Dim da As New ScraperLib.FileScraperDataAdapter
      da.ProjectFileName = fileName
      da.LoadProject()


      Dim proj As Project = da.Project
      proj.ScraperDataAdaptor = da

      Try
         proj.ScraperDataAdaptor.LoadProject()        ' Load the project
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox("Error: " & ex.Message)
      End Try

      Return proj
   End Function
#End Region

#Region "Project Editing Information"
   ''' <summary>
   ''' Load Project Information to the UI
   ''' </summary>
   ''' <param name="proj"></param>
   ''' <remarks></remarks>
   Private Sub LoadProjetUI(ByVal proj As Project)
      'Me.ProjectNameTextBox.Text = proj.ProjectRow.Name
      'Me.ThreadsNumericUpDown.Value = proj.ProjectRow.Threads
      'Me.IsSaveContentCheckBox.Checked = proj.ProjectRow.IsSaveContent
      'Me.DownloadDelayNumericUpDown.Value = proj.ProjectRow.DownloadDelay
      'Me.lblLastRun.Text = proj.ProjectRow.DateRun

      'Dim t As New TimeSpan(0, 0, proj.ProjectRow.ScrapeInterval, 0)
      'Me.IntervalDay.Value = t.Days
      'Me.IntervalHour.Value = t.Hours
      'Me.IntervalMinute.Value = t.Minutes

      ' Me.ProjectInfoControl1.Elasped = New TimeSpan(0)

      Me.ProjectInfoControl1.TotalDownloadedSize = 0
      Me.ProjectInfoControl1.TotalUrl = Me.CurrentProject.URLList.TotalUrl
      Me.ProjectInfoControl1.TotalLeft = Me.CurrentProject.URLList.TotalToScrape
      Me.ProjectInfoControl1.AverageSpeed = 0

      Me.ProjectInfoControl1.ProjectRow = Me.CurrentProject.ProjectRow

      ' Load mapping and link information
      ' Set Data binding
      Me.MapLinkMapping()

      ' Temp: Generate
      Me.GenerateMapping()
      Me.MapDataMapping()
   End Sub

   ''' <summary>
   ''' When adding a project from file: Generate mapping if it does not come with mappings
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub GenerateMapping()
      ' Clear the old mapping.
      Me.CurrentProject.DataSet.DataMapping.Clear()
      Dim dv As New DataView(Me.CurrentProject.DataSet.TagLibrary)
      dv.RowFilter = Me.CurrentProject.DataSet.TagLibrary.isSaveDataColumn.ColumnName & " = true OR " & _
                     Me.CurrentProject.DataSet.TagLibrary.IsDataTableColumn.ColumnName & " = true"

      For i As Integer = 0 To dv.Count - 1
         Dim r As ScraperDB.TagLibraryRow = dv.Item(i).Row

         Dim row As ScraperDB.DataMappingRow = Me.CurrentProject.DataSet.DataMapping.NewDataMappingRow
         row.ProjectID = Me.CurrentProject.ProjectID
         row.TagID = r.TagID
         row.FieldName = r.TagName
         row.IsCheckField = False
         row.IsIdentity = False
         row.DataType = 0
         Me.CurrentProject.DataSet.DataMapping.AddDataMappingRow(row)
      Next

   End Sub

   Private Sub MapLinkMapping()
      ' Map Project Names
      Me.LinkMappingProjectID.DataSource = myProjectManager.ProjectDT
      Me.LinkMappingProjectID.DisplayMember = myProjectManager.ProjectDT.NameColumn.ColumnName
      Me.LinkMappingProjectID.ValueMember = myProjectManager.ProjectDT.ProjectIDColumn.ColumnName
      Me.LinkMappingProjectID.DataPropertyName = Me.CurrentProject.DataSet.LinkMapping.Pro_ProjectIDColumn.ColumnName

      ' Filter URL Tag names
      Dim dv As New DataView(Me.CurrentProject.DataSet.TagLibrary)
      dv.RowFilter = Me.CurrentProject.DataSet.TagLibrary.IsURLColumn.ColumnName & " = true"
      Me.LinkMappingTagID.DataSource = dv
      Me.LinkMappingTagID.DisplayMember = Me.CurrentProject.DataSet.TagLibrary.TagNameColumn.ColumnName
      Me.LinkMappingTagID.ValueMember = Me.CurrentProject.DataSet.TagLibrary.TagIDColumn.ColumnName
      Me.LinkMappingTagID.DataPropertyName = Me.CurrentProject.DataSet.LinkMapping.TagIDColumn.ColumnName

      Dim c As ComboBox
      ' Project
      c = Me.ProjectToolStripComboBox.Control
      c.DataSource = myProjectManager.ProjectDT
      c.DisplayMember = myProjectManager.ProjectDT.NameColumn.ColumnName
      c.ValueMember = myProjectManager.ProjectDT.ProjectIDColumn.ColumnName

      ' URL Tag
      c = Me.UrlTagToolStripComboBox.Control
      c.DataSource = dv
      c.DisplayMember = Me.CurrentProject.DataSet.TagLibrary.TagNameColumn.ColumnName
      c.ValueMember = Me.CurrentProject.DataSet.TagLibrary.TagIDColumn.ColumnName

      Me.LinkMappingDataGridView.AutoGenerateColumns = False
      Me.LinkMappingDataGridView.DataSource = Me.CurrentProject.DataSet.LinkMapping
   End Sub

   Private Sub MapDataMapping()
      Dim dv As New DataView(Me.CurrentProject.DataSet.TagLibrary)
      dv.RowFilter = Me.CurrentProject.DataSet.TagLibrary.IsDataTableColumn.ColumnName & " = true"

      Dim c As ComboBox = Me.TableGeneratedToolStripComboBox.Control
      c.DataSource = dv
      c.DisplayMember = Me.CurrentProject.DataSet.TagLibrary.TagNameColumn.ColumnName
      c.ValueMember = Me.CurrentProject.DataSet.TagLibrary.TagIDColumn.ColumnName

      Me.DataMappingTag.DataSource = Me.CurrentProject.DataSet.TagLibrary
      Me.DataMappingTag.DisplayMember = Me.CurrentProject.DataSet.TagLibrary.TagNameColumn.ColumnName
      Me.DataMappingTag.ValueMember = Me.CurrentProject.DataSet.TagLibrary.TagIDColumn.ColumnName
      Me.DataMappingTag.DataPropertyName = Me.CurrentProject.DataSet.DataMapping.TagIDColumn.ColumnName

      Me.DataMappingField.DataPropertyName = Me.CurrentProject.DataSet.DataMapping.FieldNameColumn.ColumnName
      Me.DataMappingID.DataPropertyName = Me.CurrentProject.DataSet.DataMapping.IsIdentityColumn.ColumnName
      Me.DataMappingChecksum.DataPropertyName = Me.CurrentProject.DataSet.DataMapping.IsCheckFieldColumn.ColumnName

      Me.DataMappingDataGridView.AutoGenerateColumns = False
      Me.DataMappingDataGridView.DataSource = Me.CurrentProject.DataSet.DataMapping
   End Sub

   ''' <summary>
   ''' Save Project Information from the UI to project class
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub SaveProjectUI()
      'Dim t As New TimeSpan(Me.IntervalDay.Value, Me.IntervalHour.Value, Me.IntervalMinute.Value)
      'Me.CurrentProject.ProjectRow.IsSaveContent = Me.IsSaveContentCheckBox.Checked
      'Me.CurrentProject.ProjectRow.Name = Me.ProjectNameTextBox.Text

      'Me.CurrentProject.ProjectRow.DownloadDelay = Me.DownloadDelayNumericUpDown.Value
      'Me.CurrentProject.ProjectRow.Threads = Me.ThreadsNumericUpDown.Value
      'Me.CurrentProject.ProjectRow.ScrapeInterval = t.Minutes
   End Sub
#End Region

   Private Sub SiteCrawler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Console.WriteLine("Reached here")

      ' Open connection
      Me.conn.Open()

      ' Add any initialization after the InitializeComponent() call.
      myProjectManager = New ProjectManager(Me.conn)

      ' Load all the project.
      myProjectManager.SQLConnection = Me.conn
      myProjectManager.LoadProjects()

      ' Bind the project list into the projectlistview
      Me.ProjectListViewBindData()
   End Sub

   Private Sub ProjectListViewBindData()
      For Each row As ScraperDB.ProjectRow In myProjectManager.ProjectDT
         Dim listitem As New ListViewItem()
         listitem.Text = row.Name
         listitem.Tag = row
         Me.ProjectListView.Items.Add(listitem)
      Next
   End Sub

   Private Sub ImportProjectToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportProjectToolStripButton.Click
      DoImport()
   End Sub


   Private Sub DoImport()
      ' 1.) Ask for project file path
      Dim prj As Project = Nothing
      Dim fileAdaptor As New FileScraperDataAdapter()
      Dim OpenFileDiag As New OpenFileDialog()

      If OpenFileDiag.ShowDialog = Windows.Forms.DialogResult.OK Then
         fileAdaptor.ProjectFileName = OpenFileDiag.FileName

         Try
            fileAdaptor.LoadProject()
            prj = fileAdaptor.Project

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
            myProjectManager.ImportProject(prj)
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            MsgBox("Unhandled Error: " & ex.Message)
         End Try
      End If
   End Sub

   Private myProjectManager As ProjectManager

   Private Sub AddUrlMappingToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUrlMappingToolStripButton.Click
      Dim r As ScraperDB.LinkMappingRow = Me.CurrentProject.DataSet.LinkMapping.NewRow()
      r.Pro_ProjectID = Me.CurrentProject.ProjectID
      r.ProjectID = CType(Me.ProjectToolStripComboBox.Control, ComboBox).SelectedValue
      r.TagID = CType(Me.UrlTagToolStripComboBox.Control, ComboBox).SelectedValue

      ' Run a filter check
      Dim dv As New DataView(Me.CurrentProject.DataSet.LinkMapping)
      dv.RowFilter = Me.CurrentProject.DataSet.LinkMapping.ProjectIDColumn.ColumnName & "=" & r.ProjectID & " AND " & _
                   Me.CurrentProject.DataSet.LinkMapping.TagIDColumn.ColumnName & "=" & r.TagID

      If dv.Count > 0 Then
         MsgBox("Mapping already exists.")
         Exit Sub
      End If

      Try
         ' Add Mapping
         Me.CurrentProject.DataSet.LinkMapping.AddLinkMappingRow(r)
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox("Error adding url mapping: " & ex.Message)
      End Try
   End Sub

   Private Sub RemoveUrlMappingToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveUrlMappingToolStripButton.Click
      ' check for selected items in the box

   End Sub

   Private Sub TableGeneratedToolStripComboBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableGeneratedToolStripComboBox.Click

   End Sub
End Class