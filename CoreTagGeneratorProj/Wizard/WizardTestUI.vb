Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO

Public Class WizardTestUI
   Dim _Project As Project
   Dim dirName As String = "C:\Scraper\Test Cases\TagLibraryGenerator"
   Dim scraper As New Scraper()

   Private Sub textCompareTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
      If Me.ComboBox1.SelectedItem IsNot Nothing Then
         ' Load files
         Me.WizardCtl1.DirName = Me.ComboBox1.SelectedItem

         Me.GenerateButton.Enabled = True

         'CreateProjects()
      End If
   End Sub

   Dim cgen As CoreTagGenerator
   Private Sub GenerateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateButton.Click
      Me._Project.TagTree.RootNode.TagNodeList.Clear()
      cgen = New CoreTagGenerator(Me.WizardCtl1.RichTextBox1.Text, Me.WizardCtl1.DT, Me._Project.TagTree.RootNode)
      Try

         If Not cgen.IsValid Then
            MsgBox("Invalid sample data")
            Me.WizardCtl1.DataGridView1.Refresh()
            Exit Sub
         End If
         cgen.Generate()
         Me.WizardCtl1.TagTree = Me._Project.TagTree
         Me._Project.TagTree.RebuildDataTable()
         Me.scraper.Scrape(Me.WizardCtl1.RichTextBox1.Text, "http://localhost", Me._Project.TagTree)

         ' Me.DataSet = _Project.ScrapedDS
         Me.CrawledDataControl1.DataSet = Me._Project.ScrapedDS
         'Me.CrawledDataControl1.DataSet = Me._Project.Dataset
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox(ex.Message)
      End Try

   End Sub

   Private Sub ScrapeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScrapeButton.Click
      Try
         Me._Project.TagTree.RebuildDataTable()
         Me.scraper.Scrape(Me.WizardCtl1.RichTextBox1.Text, "http://localhost", Me._Project.TagTree)
         Me.CrawledDataControl1.DataSet = Me._Project.ScrapedDS
      Catch ex As Exception
         MsgBox("Scrape Timed Out")
      End Try
   End Sub

   Private Sub SaveProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectButton.Click
      doSaveAsFile()
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
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error")
         End Try
      End If
   End Sub

   Private Sub GenerateEndTagButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateEndTagButton.Click
      doGenerateEndTag()
   End Sub

   Private Sub doGenerateEndTag()
      If Me.CrawledDataControl1.ParentDataGridView.SelectedRows.Count = 0 Then
         MsgBox("You must select one row as the last row.")
         Exit Sub
      End If

      Dim rowIndex As Integer = 0

      Dim tagnode As TagNode = cgen.LastFieldNode
      Dim fDT As ScraperLib.ScraperTempDS.FieldDTDataTable = Me.cgen.LastFieldNode.FieldDT

      For Each r As Windows.Forms.DataGridViewRow In Me.CrawledDataControl1.ParentDataGridView.SelectedRows
         Dim rv As System.Data.DataRowView = r.DataBoundItem

         For i As Integer = 0 To fDT.Count - 1
            Dim row As DataRow = Me._Project.ScrapedDS.Tables(0).Rows(i)

            If (row Is rv.Row) Then
               doGenerateEndTag(i)
               Exit For
            End If
         Next
         Exit For
      Next
   End Sub

   Private Sub doGenerateEndTag(ByVal index As Integer)
      Dim fDT As ScraperLib.ScraperTempDS.FieldDTDataTable = Me.cgen.LastFieldNode.FieldDT
      Dim dDT As ScraperLib.ScraperTempDS.FieldDTDataTable = Me.cgen.DataNode.FieldDT

      Dim selectedRow As ScraperLib.ScraperTempDS.FieldDTRow = fDT.Rows(index)
      Dim prevRow As ScraperLib.ScraperTempDS.FieldDTRow = Nothing
      Dim nextRow As ScraperLib.ScraperTempDS.FieldDTRow = Nothing

      Dim badText As String = ""
      Dim goodText As String = ""
      Dim badTextStart As String = ""

      Dim context As String = Me.WizardCtl1.Content

      If (index = fDT.Count - 1) Then
         'Throw New Exception("Don't need to generate the last tag.")
         goodText = context.Substring(selectedRow.EndTagIndex)
      Else
         prevRow = fDT(index - 1)
         nextRow = fDT(index + 1)
         goodText = context.Substring(selectedRow.EndTagIndex, nextRow.StartTagIndex - selectedRow.EndTagIndex)
      End If

      badText = context.Substring(prevRow.EndTagIndex, selectedRow.StartTagIndex - prevRow.EndTagIndex)

      Dim dataRow As ScraperLib.ScraperTempDS.FieldDTRow = dDT.Rows(0)
      Dim firstRow As ScraperLib.ScraperTempDS.FieldDTRow = fDT.Rows(0)
      badTextStart = context.Substring(dataRow.StartTagIndex, firstRow.StartTagIndex - dataRow.StartTagIndex)

      Try
         ' Generate the end tag -> Then Scrape
         Console.WriteLine("============== After End Tag Generated ============")
         Me.cgen.GenerateEndTag(Me.RichTextBox1.Text, goodText, badText, badTextStart)

         Me._Project.TagTree.RebuildDataTable()
         Me.scraper.Scrape(Me.WizardCtl1.RichTextBox1.Text, "http://localhost", Me._Project.TagTree)

         Me.CrawledDataControl1.DataSet = Me._Project.ScrapedDS
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox(ex.Message)
      End Try
   End Sub

   Private _CrawlProject As CrawlProject
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me._DataScheme = New WizardDS.FieldDTDataTable

      Me.FieldName.DataPropertyName = _DataScheme.FieldNameColumn.ColumnName
      Me.IsSaveData.DataPropertyName = _DataScheme.IsSaveDataColumn.ColumnName
      Me.MaxChars.DataPropertyName = _DataScheme.MaxCharsColumn.ColumnName

      FieldsDataGridView.AutoGenerateColumns = False
      Me.FieldsDataGridView.DataSource = Me._DataScheme
      Me.doNew()

      _CrawlProject = New CrawlProject("Wizard Test")
      Me._Project = Me._CrawlProject.ProjectManager.ProjectList(0)
      Me.doLoadTestCases()
   End Sub

   Private Sub doLoadTestCases()
      Dim dir As New System.IO.DirectoryInfo(dirName)

      Me.ComboBox1.Items.Clear()
      For Each d As System.IO.DirectoryInfo In dir.GetDirectories
         Me.ComboBox1.Items.Add(d.FullName)
      Next
   End Sub

#Region "Create new test case"
   Private _DataScheme As WizardDS.FieldDTDataTable
   Private _DataTable As DataTable

   Private Sub SaveTestCaseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTestCaseButton.Click
      ' Create a directory
      Me._DataScheme.TableName = Me.TestCaseNameTextBox.Text
      Dim newdir As String = Me.dirName & "\" & Me._DataScheme.TableName
      Directory.CreateDirectory(newdir)
      Dim wDS As New DataSet

      ' Save the xml file\
      _DataTable.WriteXml(newdir & "\data1.xml")
      _DataTable.WriteXmlSchema(newdir & "\data1.xml.schme")

      File.WriteAllText(newdir & "\data1.html", Me.RichTextBox1.Text)

      Me.doLoadTestCases()
   End Sub

   Private Sub NewTestCaseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTestCaseButton.Click
      doNew()
      Me.FieldsDataGridView.DataSource = _DataScheme
   End Sub

   Private Sub doNew()
      _DataScheme.Clear()
      _DataScheme.TableName = "TestCase1"

      Me.TestCaseNameTextBox.Text = "TestCase1"
      Me.RichTextBox1.Text = ""
      _DataTable = New DataTable

      Me.FieldsDataGridView.DataSource = _DataScheme
   End Sub

   Private Sub UpdateTableButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateTableButton.Click
      GenerateTable()
      Me.FieldsDataGridView.DataSource = _DataScheme
   End Sub

   Private Sub GenerateTable()
      _DataTable = New DataTable
      Me._DataTable.TableName = Me._DataScheme.TableName

      ' Remove extra cols
      For i As Integer = Me._DataScheme.Rows.Count To Me._DataTable.Columns.Count - 1
         Me._DataTable.Columns.RemoveAt(i)
      Next

      ' Rename existing cols
      For i As Integer = 0 To Me._DataTable.Columns.Count - 1
         Dim r As WizardDS.FieldDTRow = Me._DataScheme.Rows(i)
         Me._DataTable.Columns(i).ColumnName = r.FieldName
      Next

      ' Add extra col
      For i As Integer = Me._DataTable.Columns.Count To Me._DataScheme.Rows.Count - 1
         Dim r As WizardDS.FieldDTRow = Me._DataScheme.Rows(i)
         _DataTable.Columns.Add(r.FieldName)
      Next

      '' Adjust the colum width -> Based on text size
      Me.SampleDataGridView.DataSource = _DataTable
      Dim maxWidth As Integer = SampleDataGridView.Width

      For i As Integer = 0 To SampleDataGridView.Columns.Count - 1
         If (_DataScheme(i).MaxChars = 0) Then
            SampleDataGridView.Columns(i).FillWeight = 100
         Else
            SampleDataGridView.Columns(i).FillWeight = _DataScheme(i).MaxChars
         End If
      Next
      Me.SampleDataGridView.DataSource = _DataTable
   End Sub
#End Region

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      ' Data set test, what happens if one dataset try to merage two dataset with differnt table, but table name
      Dim dt As New DataTable("Test")
      dt.Columns.Add("ID", GetType(Integer))
      dt.Columns.Add("Name", GetType(Integer))
      dt.Columns.Add("Test2", GetType(Integer))

      Dim dt1 As New DataTable("Test")
      dt1.Columns.Add("ID", GetType(Integer))
      dt1.Columns.Add("Name", GetType(Integer))
      dt1.Columns.Add("Test", GetType(Integer))

      Dim dt2 As New DataTable("Test1")
      dt2.Columns.Add("ID", GetType(Integer))
      dt2.Columns.Add("Name", GetType(Integer))
      dt2.Columns.Add("Test", GetType(Integer))

      Dim ds As New DataSet
      ds.Merge(dt)
      ds.Merge(dt1)
      ds.Merge(dt2)

      Me.CrawledDataControl1.DataSet = ds
   End Sub

   Private Sub CreateTestCaseTabPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTestCaseTabPage.Click

   End Sub

   Private Sub UpdateTableButton_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UpdateTableButton.MouseClick
      ' Create a data base.
   End Sub

   Private Sub NewTestCaseButton_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NewTestCaseButton.MouseClick
      ' create New
   End Sub

   Private Sub SaveTestCaseButton_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SaveTestCaseButton.MouseClick


   End Sub
End Class
