Public Class CoreTagGeneratorUI
   Private Sub GeneratorToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles GeneratorToolStrip.ItemClicked
      If e.ClickedItem Is Me.UrlToolStripComboBox Then

      ElseIf e.ClickedItem Is Me.DownloadToolStripButton Then
         Me.DoDownload()
      ElseIf e.ClickedItem Is Me.GenerateToolStripButton Then
         Me.doGenerate()
      ElseIf e.ClickedItem Is Me.ViewHtmlToolStripButton Then
         'Me.ResultPanel.Visible = ViewHtmlToolStripButton.Checked
      ElseIf e.ClickedItem Is Me.ChangeFieldsToolStripButton Then
         Dim changeFieldDialog As New DataFieldUI(Me._DataScheme)

         ' Fields changed, generate project
         If changeFieldDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.GenerateTable()
         End If
      ElseIf e.ClickedItem Is Me.EndingBoundToolStripButton Then
         doGenerateEndTag()
      ElseIf e.ClickedItem Is Me.CheckDataToolStripButton Then
         doCheckData()
      End If
   End Sub

   Private WithEvents myWebClient As New NetworkClient.MultiWebClient       ' Web client used by front end.
   Private Sub DoDownload()
      ' See if the selected url is part of the url list
      Dim url As String = Nothing
      url = Me.UrlToolStripComboBox.Text

      If Not Uri.IsWellFormedUriString(Me.UrlToolStripComboBox.Text, UriKind.Absolute) Then
         ' Add http to url and test again
         url = "http://" & url
      End If
      Me.UrlToolStripComboBox.Text = url

      If Not Uri.IsWellFormedUriString(url, UriKind.Absolute) Then
         ' Add http to url and test again
         MsgBox("Invalid Url Format. It must be in accordance with RFC 2396 and RFC 2732.")
         Return
      Else
         Dim u As New Uri(url)
         If u.Scheme <> Uri.UriSchemeHttp Then
            MsgBox("Url must be of http portocal. (http://)")
            Return
         End If
      End If

      If url Is Nothing Then
         Return
      End If

      'Download url
      If url <> "" Then
         Dim aURI As Uri = New Uri(url)
         Me.myWebClient.DownloadStringAsync(aURI, "", Nothing, aURI)
         Me.DownloadToolStripButton.Enabled = False
      End If
   End Sub

   ''' <summary>
   ''' Progress changed
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub onDownloadProgressChanged(ByVal sender As Object, ByVal e As NetworkClient.DownloadProgressChangedEventArgs) Handles myWebClient.DownloadProgressChanged
      'Me.MyStateToolStripStatusLabel.Text = e.Status.ToString & ": " & e.BytesReceived
   End Sub

   ''' <summary>
   ''' Download completed
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub myWebClient_DownloadStringCompleted(ByVal sender As Object, ByVal e As NetworkClient.DownloadStringCompletedEventArgs) Handles myWebClient.DownloadStringCompleted
      Me.HtmlRichTextBox.Text = e.Result
      Me.DownloadToolStripButton.Enabled = True
      Me.ViewHtmlToolStripButton.Checked = True
   End Sub

   Private _DataScheme As ScraperLib.WizardDS.FieldDTDataTable
   Private _DataTable As DataTable
   Private _Project As Project
   Public ReadOnly Property Project() As Project
      Get
         Return Me._Project
      End Get
   End Property

   Public Sub New(ByVal proj As Project)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me._Project = proj
      Me._DataTable = New DataTable

      ' Init Fields
      Me._DataScheme = New WizardDS.FieldDTDataTable
      Dim r As WizardDS.FieldDTRow = Me._DataScheme.NewFieldDTRow
      r.FieldName = "Data"
      Me._DataScheme.AddFieldDTRow(r)

      Me._DataScheme.TableName = "Data"
      GenerateTable()

      Me.DataGridView1.DataSource = Me._Project.ScrapedDS
   End Sub

   Private Sub GenerateTable()
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
   End Sub

   Private Sub doCheckData()
      Dim CoreGen As New CoreTagGenerator(Me.HtmlRichTextBox.Text, Me._DataTable, Me._Project.TagTree.RootNode)

      Me.HtmlRichTextBox.Focus()
      Me.SampleDataGridView.EndEdit()

      ' 1.) Check the rows to see if they can be with in the given text, if not, this is an error
      CoreGen.IsValid()
      Me.SampleDataGridView.Refresh()
   End Sub

   Private CoreGen As CoreTagGenerator
   Private _Scraper As New Scraper()

   Private Sub doGenerate()
      doCheckData()

      Me._Project.TagTree.RootNode.TagNodeList.Clear()
      CoreGen = New CoreTagGenerator(Me.HtmlRichTextBox.Text, Me._DataTable, Me._Project.TagTree.RootNode)
      Try
         CoreGen.Generate()
         'Me.WizardCtl1.TagTree = Me._Project.TagTree
         Me._Project.TagTree.RebuildDataTable()

         _Scraper.Scrape(Me.HtmlRichTextBox.Text, "http://localhost", Me._Project.TagTree)

         ' Me.DataSet = _Project.ScrapedDS
         Me.DataGridView1.DataSource = Me._Project.ScrapedDS
         'Me.CrawledDataControl1.DataSet = Me._Project.Dataset
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox(ex.Message)
      End Try
   End Sub

   Private Sub doScrape()
      Try
         _Scraper.Scrape(Me.HtmlRichTextBox.Text, "http://localhost/", Me._Project.TagTree)

         Me.DataGridView1.DataSource = Me._Project.ScrapedDS.Tables(0)
      Catch ex As Exception
         MsgBox(ex.Message)
      End Try
   End Sub

   Private Sub ViewHtmlToolStripButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewHtmlToolStripButton.CheckedChanged
      Me.HtmlRichTextBox.Visible = ViewHtmlToolStripButton.Checked
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
   End Sub


   Private Sub doGenerateEndTag()
      If Me.DataGridView1.SelectedRows.Count = 0 Then
         MsgBox("You must select one row as the last row.")
         Exit Sub
      End If

      Dim rowIndex As Integer = 0

      Dim tagnode As TagNode = CoreGen.LastFieldNode

      Dim fDT As ScraperLib.ScraperTempDS.FieldDTDataTable = Me.CoreGen.LastFieldNode.FieldDT

      For Each r As Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim rv As System.Data.DataRowView = r.DataBoundItem

         For i As Integer = 0 To fDT.Count - 1
            Dim row As DataRow = Me.Project.ScrapedDS.Tables(0).Rows(i)

            If (row Is rv.Row) Then
               doGenerateEndTag(i)
               Exit For
            End If
         Next
         Exit For
      Next
   End Sub

   Private Sub doGenerateEndTag(ByVal index As Integer)
      Dim fDT As ScraperLib.ScraperTempDS.FieldDTDataTable = Me.CoreGen.LastFieldNode.FieldDT
      Dim dDT As ScraperLib.ScraperTempDS.FieldDTDataTable = Me.CoreGen.DataNode.FieldDT

      Dim selectedRow As ScraperLib.ScraperTempDS.FieldDTRow = fDT.Rows(index)
      Dim prevRow As ScraperLib.ScraperTempDS.FieldDTRow = Nothing
      Dim nextRow As ScraperLib.ScraperTempDS.FieldDTRow = Nothing

      Dim badText As String = ""
      Dim goodText As String = ""
      Dim badTextStart As String = ""
      Dim context As String = Me.HtmlRichTextBox.Text

      prevRow = fDT(index - 1)
      nextRow = fDT(index + 1)

      'If (index = fDT.Count - 1) Then
      '   'Throw New Exception("Don't need to generate the last tag.")
      '   goodText = context.Substring(selectedRow.EndTagIndex)
      'Else
      '   prevRow = fDT(index - 1)
      '   nextRow = fDT(index + 1)
      '   goodText = context.Substring(selectedRow.EndTagIndex + selectedRow.EndTagLength, _
      '         nextRow.StartTagIndex - selectedRow.EndTagIndex + selectedRow.EndTagLength)
      'End If

      goodText = context.Substring(selectedRow.EndTagIndex)
      badText = context.Substring(prevRow.EndTagIndex, selectedRow.StartTagIndex - prevRow.EndTagIndex)

      Dim dataRow As ScraperLib.ScraperTempDS.FieldDTRow = dDT.Rows(0)
      Dim firstRow As ScraperLib.ScraperTempDS.FieldDTRow = fDT.Rows(0)
      badTextStart = context.Substring(dataRow.StartTagIndex, firstRow.StartTagIndex - dataRow.StartTagIndex)

      Try
         ' Generate the end tag -> Then Scrape
         Console.WriteLine("============== After End Tag Generated ============")
         Me.CoreGen.GenerateEndTag(context, goodText, badText, badTextStart)

         Me.doScrape()
      Catch ex As Exception
         MsgBox(ex.Message)
      End Try
   End Sub

   Private Sub TagGeneratorUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub

   Private Sub GenerateToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerateToolStripButton.Click

   End Sub
End Class