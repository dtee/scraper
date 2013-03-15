Option Explicit On
Imports system.Text.RegularExpressions
Imports ScraperLib
Imports SharedUI

Public Class Main
   Private WithEvents _ResultDatasetUI As ResultDSUI             ' Crawled Dataset
   Private WithEvents _NodeFieldDTUI As NodeFieldDTUI

   Private _CrawlProjectManager As CrawlProjectManager            ' Crawl Project Manager
   Private _SqlConnection As New SqlClient.SqlConnection(ScraperApp.My.Settings.ScraperDBConnectionString)

   Private Shared _Log As New Log(GetType(Main), True)

   Private installSQL As String

#Region "New, and close (Init items and clear them on exit)"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      _NodeFieldDTUI = New NodeFieldDTUI()
      _NodeFieldDTUI.Owner = Me
      _NodeFieldDTUI.Text = "View Node Data"

      _ResultDatasetUI = New ResultDSUI()                    ' We sould remove this.
      _ResultDatasetUI.Text = "Sample Scraped Data"
      _ResultDatasetUI.Owner = Me

      AddHandler ProxyManagerControl1.progress, AddressOf Me.handleProgress
      AddHandler UrlManagerControl1.Progress, AddressOf Me.handleProgress

      Me.ProjectLocToolStripStatusLabel.Text = "Ready"
      Me._CrawlProjectManager = New CrawlProjectManager(Me._SqlConnection)

      Me.doNew()              ' Create new empty project (file based.)

      installSQL = ScraperLib.DataManagement.SqlExpress.getInstallProjectSQL
      Me.InstallSQLRichTextBox.Text = installSQL
   End Sub

   Private Sub Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      _NodeFieldDTUI.IsExit = True
      _ResultDatasetUI.IsExit = True
      e.Cancel = False
   End Sub
#End Region

   Private _CrawlProject As CrawlProject

   Public Property CrawlProject() As CrawlProject
      Get
         Return Me._CrawlProject
      End Get
      Set(ByVal value As CrawlProject)

         If value IsNot Nothing Then
            If Me._CrawlProject IsNot Nothing Then
               RemoveHandler _CrawlProject.Crawler.CrawlFinished, AddressOf onCrawlFinished
            End If

            Me._CrawlProject = value
            AddHandler _CrawlProject.Crawler.CrawlFinished, AddressOf onCrawlFinished
            'Me.Crawler1.Crawler = Me._CrawlProject.Crawler

            ' This doesn't work... Project may not have a Adaptor
            If Me._CrawlProject.ScraperDataAdaptor Is Nothing Then
               Me.ProjectLocToolStripStatusLabel.Text = "Project not save."
            Else
               Me.ProjectLocToolStripStatusLabel.Text = Me._CrawlProject.ScraperDataAdaptor.ProjectLocation
            End If

            Me.UrlManagerControl1.CrawlProject = Me._CrawlProject
            Me.LinkMappingControl1.CrawlProject = Me._CrawlProject

            ' UI stuffs
            Me.CrawledDataControl1.DataSet = Me._CrawlProject.ScrapedDS
            Me.CrawlProjectInfoControl1.CrawlProject = Me._CrawlProject
            Me.DataTypeControl1.DataTypeManager = Me._CrawlProject.DataTypeManager
            Me.ProxyManagerControl1.CrawlProject = Me._CrawlProject
            Me.CronControl1.CronManger = Me._CrawlProject.CronManger

            ' Set title
            Me.SelectView(ProjectView.CrawlView, False)
            Me.Text = "Crawl Project: " & Me._CrawlProject.CrawlProjectRow.Name

            ' TODO: Remove this line
         End If
      End Set
   End Property

#Region "Project Contorl: New, Open, Save, Save As, Scrape"
   Private Sub MainToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MainToolStrip.ItemClicked
      If e.ClickedItem Is Me.NewToolStripButton Then        ' New Project
         Me.doNew()
      ElseIf e.ClickedItem Is Me.OpenToolStripButton Then       ' Open File
         Me.doOpenFile()
      ElseIf e.ClickedItem Is Me.SaveToolStripButton Then       ' Save File
         Me.doSaveFile()
      ElseIf e.ClickedItem Is Me.SaveAsToolStripButton Then     ' Save As File
         Me.doSaveAsFile()
      ElseIf e.ClickedItem Is Me.OpenDBToolStripButton Then             ' Open DB
         doOpenCrawlProjectList()
      ElseIf e.ClickedItem Is Me.SaveProjectDBToolStripButton Then      ' Save as DB
         Me.doSaveDB()
      ElseIf e.ClickedItem Is Me.LoadUrlToolStripButton Then           ' Open Project List
         If Me._CrawlProject.ScraperDataAdaptor IsNot Nothing AndAlso _
            TypeOf (Me._CrawlProject.ScraperDataAdaptor) Is SQLDatabaseScraperAdapter Then
            Dim sqlSDA As SQLDatabaseScraperAdapter = Me._CrawlProject.ScraperDataAdaptor

            sqlSDA.LoadUrl()
         Else
            MsgBox("Must be a database project to load url from database.")
         End If

         ' TODO: Use the CrawlProject Manger to upload
      ElseIf e.ClickedItem Is Me.SaveDataToolStripButton Then            ' Import Project to DB
         If Me._CrawlProject.ScraperDataAdaptor IsNot Nothing AndAlso _
            TypeOf (Me._CrawlProject.ScraperDataAdaptor) Is SQLDatabaseScraperAdapter Then
            Dim sqlSDA As SQLDatabaseScraperAdapter = Me._CrawlProject.ScraperDataAdaptor

            sqlSDA.SaveData()
         Else
            MsgBox("Must be a database project to save data to database.")
         End If
      ElseIf e.ClickedItem Is Nothing Then
      ElseIf e.ClickedItem Is Nothing Then
      End If
   End Sub

   ''' <summary>
   ''' Open the Crawl project list
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doOpenCrawlProjectList()
      'Me.CrawledDataView.Show()
      Dim pjList As New CrawlProjectListUI(Me._CrawlProjectManager)

      If pjList.ShowDialog = Windows.Forms.DialogResult.OK Then
         Try
            Me.CrawlProject = pjList.CrawlProject
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)

            'Me.CrawledDataControl1.DataSet = sqlDA.CrawlProject.Dataset
            MsgBox(ex.Message)         ' Error
         End Try
      End If
   End Sub

   Private Sub doNew()
      Try
         Me.CrawlProject = New CrawlProject("Untitled Crawl Project")
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
      End Try

      If My.Application.CommandLineArgs.Count > 0 Then
         Me.OpenProjectFile(My.Application.CommandLineArgs(0))
      End If
   End Sub

   ''' <summary>
   ''' Open File
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doOpenFile()
      If Me.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
         OpenProjectFile(OpenFileDialog1.FileName)
      End If
   End Sub

   ''' <summary>
   ''' Open file on start up
   ''' </summary>
   ''' <param name="fileName"></param>
   ''' <remarks></remarks>
   Public Sub OpenProjectFile(ByVal fileName As String)
      If IO.File.Exists(fileName) Then
         Dim floader As New FileScraperDataAdapter()
         floader.ProjectFileName = fileName

         Try
            floader.LoadProject()
            Me.CrawlProject = floader.CrawlProject       ' Change the current crawl project
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Opening File")
         End Try
      End If
   End Sub

   ''' <summary>
   ''' Save File
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doSaveFile()
      If Me._CrawlProject.ScraperDataAdaptor Is Nothing Then
         doSaveAsFile()
      Else
         Try
            Me._CrawlProject.ScraperDataAdaptor.SaveProject()
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
         End Try
      End If
   End Sub

   ''' <summary>
   ''' Save As File
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doSaveAsFile()
      If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
         ' By default: Save as File.
         Dim floader As New FileScraperDataAdapter()
         floader.ProjectFileName = SaveFileDialog1.FileName
         floader.CrawlProject = Me._CrawlProject

         Try
            floader.SaveProject()
            Me._CrawlProject.ScraperDataAdaptor = floader

            ' Update Location
            Me.CrawlProject = Me._CrawlProject
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
         End Try
      End If
   End Sub

   Private Sub doSaveDB()
      Try
         Me._CrawlProjectManager.uploadProject(Me._CrawlProject)
         MsgBox("Project successfully saved.")
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox("Error saving project: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
      End Try
   End Sub

   ''' <summary>
   ''' 
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub doImportProject()
      ' Import a project to database.
   End Sub
#End Region


   ' Do link mapping
   Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Doesn't do anything.
   End Sub


   Private Sub ConnectionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectionToolStripMenuItem.Click
      Dim conDiag As New SQLConnectionDialog
      conDiag.Conn = Me._SqlConnection

      If conDiag.ShowDialog() = Windows.Forms.DialogResult.OK Then
         Me._SqlConnection = conDiag.Conn
      End If
   End Sub

#Region "Tab Pages/Group"
   Private Sub EditTagsTabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabGroupTabControl.SelectedIndexChanged
      If Me.TabGroupTabControl.SelectedTab Is Me.GeneralTabPage Then
         'Me.UpdateProjectInfo()
      ElseIf Me.TabGroupTabControl.SelectedTab Is Me.UrlListTabPage Then
         Me.StatusToolStripStatusLabel.Text = "Total Url: " & Me._CrawlProject.UrlManager.TotalUrl
      ElseIf Me.TabGroupTabControl.SelectedTab Is Me.SQLlTabPage Then
         Me.StatusToolStripStatusLabel.Text = "Ready"
      ElseIf Me.TabGroupTabControl.SelectedTab Is Me.CrawledDataTabPage Then
         Me.StatusToolStripStatusLabel.Text = "Total Data: " & Me.CrawledDataControl1.TotalData
      Else
         ' Generated tag library, check the tag
         If Me.TabGroupTabControl.SelectedTab IsNot Nothing AndAlso Me.TabGroupTabControl.SelectedTab.Tag IsNot Nothing Then
            Dim proj As Project = Me.TabGroupTabControl.SelectedTab.Tag
            Dim tagLibControl As TagLibraryControl = TabGroupTabControl.SelectedTab.Controls(0)

            Me.handleProgress("Ready")
            Me.handleNodeDataView(tagLibControl.IsOpenNodeDataView, tagLibControl.SelectedNode)

            If tagLibControl.DataSet IsNot Nothing AndAlso tagLibControl.DataSet.Tables.Count > 0 Then
               Me.handleResultView(tagLibControl.IsOpenResultDataView, tagLibControl.DataSet)
            Else
               Me.handleResultView(tagLibControl.IsOpenResultDataView, Nothing)
            End If
         End If
      End If
   End Sub

   Private Sub DoValidate()
      Dim isValid As Boolean = False
      Try
         isValid = Me._CrawlProject.DataMapper.IsValid
      Catch ex As Exception
         Me.StatusToolStripStatusLabel.Text = "Schema View: Data Mapping: " & ex.Message
      End Try

      If Not Me._CrawlProject.LinkMapManager.IsValid Then
         Me.StatusToolStripStatusLabel.Text = "Schema View: Invalid Link Mapping"
      End If

      For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
         If Not proj.TagTree.IsValid Then
            Me.StatusToolStripStatusLabel.Text = "Project " & proj.ProjectName & " does not have a valid TagTree"
         End If
      Next
   End Sub

   Enum ProjectView
      ProjectEditView         ' Changes apply to database sheme
      CrawlView               ' Changes do not apply to database schme change
   End Enum

   Private Sub SelectView(ByVal View As ProjectView, ByVal IsRebuild As Boolean)
      ' Clear all check
      Me.CrawlViewToolStripMenuItem.Checked = False
      Me.EditViewToolStripMenuItem.Checked = False
      Me.TabGroupTabControl.TabPages.Clear()

      _ResultDatasetUI.Visible = False
      _NodeFieldDTUI.Visible = False

      If View = ProjectView.CrawlView Then
         ' Check the last checked Menu - We need to regenerate tables if any of the tags lib is changed.
         If IsRebuild Then Me._CrawlProject.RebuildScrapeDS() ' Rebuild the Scraper DS

         Me.CrawledDataControl1.DataSet = Me._CrawlProject.Dataset         ' ScrapedDS = Dataset

         DoValidate()

         Me.CrawlViewToolStripMenuItem.Checked = True
            Me.ProjectsToolStrip.Visible = False
            Me.ScraperToolStrip.Visible = True

         Me.CrawlViewToolStripMenuItem.Checked = True
         Me.TabGroupTabControl.TabPages.Add(Me.GeneralTabPage)          ' General
         Me.TabGroupTabControl.TabPages.Add(Me.SQLlTabPage)            ' Crawl           - Crawling
         Me.TabGroupTabControl.TabPages.Add(Me.CrawledDataTabPage)         ' Crawl Data

         Me.TabGroupTabControl.TabPages.Add(Me.LinkMapTabPage)          ' Link Mapping    (Always Valid)
         Me.TabGroupTabControl.TabPages.Add(Me.UrlListTabPage)          ' Url List        (Always Valid)
         Me.TabGroupTabControl.TabPages.Add(Me.ScheduleTabPage)            ' Table Mapping   (In valid if user change Tree or bad connection)
         Me.TabGroupTabControl.TabPages.Add(Me.ProxyListTabPage)        ' Edit Proxy List
         Me.TabGroupTabControl.TabPages.Add(Me.DataTypesTabPage)
      End If

      If View = ProjectView.ProjectEditView Then
         Me.ProjectsToolStrip.Visible = True
         Me.ScraperToolStrip.Visible = False

         'Me.TabGroupTabControl.TabPages.Add(Me.GeneralTabPage)          ' General
         For Each proj As Project In Me._CrawlProject.ProjectManager.ProjectList
            Me.EditViewToolStripMenuItem.Checked = True
            Me.ProjectsToolStrip.Visible = True

            addTabPage(proj)
         Next
      End If
   End Sub

   ''' <summary>
   ''' Add a project tab page (tag library edit control)
   ''' </summary>
   ''' <param name="proj"></param>
   ''' <remarks></remarks>
   Private Sub addTabPage(ByVal proj As Project)
      ' Create a new tag
      Dim tabPage As New TabPage
      tabPage.Text = proj.ProjectRow.Name
      tabPage.Tag = proj                     ' Add a tag

      Dim tagLibControl As New TagLibraryControl
      tagLibControl.Project = proj
      tagLibControl.Dock = DockStyle.Fill

      ' Add listener
      AddHandler tagLibControl.Progress, AddressOf Me.handleProgress
      AddHandler tagLibControl.NodeDataView, AddressOf Me.handleNodeDataView
      AddHandler tagLibControl.ResultView, AddressOf Me.handleResultView

      tabPage.Controls.Add(tagLibControl)

      Me.TabGroupTabControl.TabPages.Add(tabPage)
   End Sub

   Private Sub ViewsContextMenuStrip_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ViewsContextMenuStrip.ItemClicked
      If e.ClickedItem Is Me.CrawlViewToolStripMenuItem Then
         If Me.CrawlViewToolStripMenuItem.Checked Then
            SelectView(ProjectView.CrawlView, False)
         Else
            ' TODO: Do testing here to seee if the tree changed, tables generated changed.
            SelectView(ProjectView.CrawlView, True)
         End If
      ElseIf e.ClickedItem Is Me.EditViewToolStripMenuItem Then
         SelectView(ProjectView.ProjectEditView, False)
      End If
   End Sub

   Private Sub ProjectsToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ProjectsToolStrip.ItemClicked
      If e.ClickedItem Is Me.EditProjectInfoToolStripButton Then
         Dim proj As Project = Me.TabGroupTabControl.SelectedTab.Tag
         Dim projectInfo As New ProjectInfoUI(proj)
         If projectInfo.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' Change the tab text (project name changed)
            Me.TabGroupTabControl.SelectedTab.Text = proj.ProjectName
         End If
      ElseIf e.ClickedItem Is Me.NewProjectToolStripButton Then
         Dim proj As Project = Me._CrawlProject.ProjectManager.newProject
         Me.addTabPage(proj)
      ElseIf e.ClickedItem Is Me.RemoveProjectToolStripButton Then
         Dim proj As Project = CType(Me.TabGroupTabControl.SelectedTab.Tag, Project)

         If Me.TabGroupTabControl.TabPages.Count = 1 Then
            MsgBox("There must be at last one project with in a crawl project.")
         Else
            If MsgBox("Are you sure sure you want to remove the project?", MsgBoxStyle.YesNo, "Remove Project") = MsgBoxResult.Yes Then
               Me._CrawlProject.ProjectManager.removeProject(proj)

               Dim tagLibControl As TagLibraryControl = Me.TabGroupTabControl.SelectedTab.Controls(0)

               ' Remove the event listeners
               RemoveHandler tagLibControl.Progress, AddressOf Me.handleProgress
               RemoveHandler tagLibControl.NodeDataView, AddressOf Me.handleNodeDataView
               RemoveHandler tagLibControl.ResultView, AddressOf Me.handleResultView

               Me.TabGroupTabControl.TabPages.Remove(Me.TabGroupTabControl.SelectedTab)
            End If
         End If
      End If
   End Sub
#End Region

#Region "Tag library control"
   Private Sub handleNodeDataViewClose() Handles _NodeFieldDTUI.Event_Closing
      If Me.TabGroupTabControl.SelectedTab IsNot Nothing AndAlso Me.TabGroupTabControl.SelectedTab.Tag IsNot Nothing Then
         Dim proj As Project = Me.TabGroupTabControl.SelectedTab.Tag
         Dim tagLibControl As TagLibraryControl = TabGroupTabControl.SelectedTab.Controls(0)

         tagLibControl.IsOpenNodeDataView = False
      End If
   End Sub

   Private Sub handleResultViewClose() Handles _ResultDatasetUI.Event_Closing
      If Me.TabGroupTabControl.SelectedTab IsNot Nothing AndAlso Me.TabGroupTabControl.SelectedTab.Tag IsNot Nothing Then
         Dim proj As Project = Me.TabGroupTabControl.SelectedTab.Tag
         Dim tagLibControl As TagLibraryControl = TabGroupTabControl.SelectedTab.Controls(0)

         tagLibControl.IsOpenResultDataView = False
      End If
   End Sub

   Private Sub handleNodeFieldDTRowChanged(ByVal row As ScraperTempDS.FieldDTRow) Handles _NodeFieldDTUI.RowIndexChanged
      '
      If Me.TabGroupTabControl.SelectedTab IsNot Nothing AndAlso Me.TabGroupTabControl.SelectedTab.Tag IsNot Nothing Then
         Dim proj As Project = Me.TabGroupTabControl.SelectedTab.Tag
         Dim tagLibControl As TagLibraryControl = TabGroupTabControl.SelectedTab.Controls(0)

         tagLibControl.ScrollText(row)
      End If
   End Sub

   Private Sub handleNodeDataView(ByVal isOpen As System.Boolean, ByVal node As ScraperLib.TagNode)
      Me._NodeFieldDTUI.Visible = isOpen
      Me._NodeFieldDTUI.TagNode = node
   End Sub

   Private Sub handleProgress(ByVal text As String)
      Me.StatusToolStripStatusLabel.Text = text
   End Sub

   Private Sub handleResultView(ByVal isOpen As System.Boolean, ByVal ds As System.Data.DataSet)
      Me._ResultDatasetUI.Visible = isOpen
      Me._ResultDatasetUI.DataSet = ds
   End Sub

   Private Sub TagLibraryControl1_NodeDataView(ByVal isOpen As System.Boolean, ByVal node As ScraperLib.TagNode)
      handleNodeDataView(isOpen, node)
   End Sub

   Private Sub TagLibraryControl1_Progress(ByVal text As System.String)
      handleProgress(text)
   End Sub

   Private Sub TagLibraryControl1_ResultView(ByVal isOpen As System.Boolean, ByVal ds As System.Data.DataSet)
      handleResultView(isOpen, ds)
   End Sub

#End Region


#Region "Cralwer stufffs"
   Private Sub onCrawlFinished()
      CrawllToolStripButton.Enabled = True
   End Sub

   Private Sub StopAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopCrawlAllToolStripButton.Click
      Me._CrawlProject.Crawler.StopCrawl()
   End Sub

   Private Sub DownloadAllToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrawllToolStripButton.Click
      CrawllToolStripButton.Enabled = False
      Me._CrawlProject.Crawler.StartCrawl()
   End Sub
#End Region

    Private Sub ViewToolStripDropDownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripDropDownButton.Click

    End Sub

    Private Sub EditViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditViewToolStripMenuItem.Click

    End Sub

   Private Sub SaveDataToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataToolStripButton.Click

   End Sub

   Private Sub SaveProjectDBToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectDBToolStripButton.Click

   End Sub
End Class