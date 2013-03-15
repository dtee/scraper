Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO

Public Class s
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
      cgen = New CoreTagGenerator(Me.WizardCtl1.RichTextBox1.Text, Me.WizardCtl1.DT, Me._Project.TagTree.RootNode)
      Try
         cgen.Generate()
         Me.scraper.Scrape(Me.WizardCtl1.RichTextBox1.Text, "http://localhost", Me._Project.TagTree)

         Me.DataSet = _Project.ScrapedDS
      Catch ex As Exception
         MsgBox(ex.Message)
      End Try

   End Sub

   Private Sub ScrapeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScrapeButton.Click
      Try
         Me.scraper.Scrape(Me.WizardCtl1.RichTextBox1.Text, "http://localhost", Me._Project.TagTree)
         Me.DataSet = _Project.ScrapedDS
      Catch ex As Exception
         MsgBox("Scrape Timed Out")
      End Try
   End Sub

   Dim ds As DataSet
   Public Property [DataSet]() As DataSet
      Get
         Return ds
      End Get
      Set(ByVal value As DataSet)
         ds = value
         Me.ComboBox2.Items.Clear()
         Me.DataGridView1.DataMember = ""
         Me.DataGridView1.DataSource = ds

         If (value IsNot Nothing) Then
            For Each tbl As DataTable In ds.Tables
               Me.ComboBox2.Items.Add(tbl.TableName)
            Next

            For Each r As DataRelation In ds.Relations
               Me.ComboBox2.Items.Add(r.ParentTable.TableName & "." & r.RelationName)
            Next

            If Me.ComboBox2.Items.Count > 0 Then
               Me.ComboBox2.SelectedIndex = 0
               Me.DataGridView1.DataMember = Me.ComboBox2.SelectedItem
            End If
         End If

         Me.DataGridView1.Columns(0).Visible = False
         Me.DataGridView1.Columns(1).Visible = False
         Me.DataGridView1.Columns(2).Visible = False
      End Set
   End Property

   Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
      Me.DataGridView1.DataMember = Me.ComboBox2.SelectedItem

      'no adding of new rows thru dataview...
      Dim cm As CurrencyManager = CType(Me.BindingContext(DataGridView1.DataSource, DataGridView1.DataMember), CurrencyManager)
      CType(cm.List, DataView).AllowNew = False
   End Sub

   Private Sub SaveProjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveProjectButton.Click
      MsgBox("not implemented")
   End Sub

   Private Sub GenerateEndTagButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateEndTagButton.Click
      doGenerateEndTag()
   End Sub

   Private Sub doGenerateEndTag()
      If Me.DataGridView1.SelectedRows.Count = 0 Then
         MsgBox("You must select one row as the last row.")
         Exit Sub
      End If

      Dim rowIndex As Integer = 0

      Dim tagnode As TagNode = cgen.LastFieldNode
      Dim fDT As ScraperLib.ScraperTempDS.FieldDTDataTable = Me.cgen.LastFieldNode.FieldDT

      For Each r As Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
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

         Me.scraper.Scrape(Me.WizardCtl1.RichTextBox1.Text, "http://localhost", Me._Project.TagTree)
         Me.DataSet = _Project.ScrapedDS
      Catch ex As Exception
         MsgBox(ex.Message)
      End Try
   End Sub

   Private _CrawlProject As CrawlProject
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      wDS = New WizardDS
      Me.newFieldDT = wDS.FieldDT

      Me.FieldName.DataPropertyName = newFieldDT.FieldNameColumn.ColumnName
      Me.IsSaveData.DataPropertyName = newFieldDT.IsSaveDataColumn.ColumnName
      Me.MaxChars.DataPropertyName = newFieldDT.MaxCharsColumn.ColumnName

      DataGridView2.AutoGenerateColumns = False
      Me.DataGridView2.DataSource = Me.newFieldDT
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
   Dim wDS As WizardDS
   Private newFieldDT As WizardDS.FieldDTDataTable
   Private Sub SaveTestCaseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTestCaseButton.Click
      ' Create a directory
      Me.newFieldDT.TableName = Me.TestCaseNameTextBox.Text
      Dim newdir As String = Me.dirName & "\" & Me.newFieldDT.TableName
      Directory.CreateDirectory(newdir)

      ' Save the xml file\
      wDS.WriteXml(newdir & "\data1.xml")
      Me.RichTextBox1.SaveFile(newdir & "\data1.html")

      Me.doLoadTestCases()
   End Sub

   Private Sub NewTestCaseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewTestCaseButton.Click
      doNew()
   End Sub

   Private Sub doNew()
      newFieldDT.Clear()
      newFieldDT.TableName = "Test Case 1"

      Me.TestCaseNameTextBox.Text = "Test Case 1"
      Me.RichTextBox1.Text = ""
   End Sub

   Private Sub UpdateTableButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateTableButton.Click

   End Sub
#End Region

End Class
