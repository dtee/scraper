
Partial Class _Default
    Inherits System.Web.UI.Page

   Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
      If FileUpload1.HasFile Then
         Dim ds As New Data.DataSet
         Dim sb As New System.Text.StringBuilder

         Try
            ds.ReadXml(FileUpload1.PostedFile.InputStream)

            ' Load using the crawl Project

            ' Look for error row in data table and print them out
            For Each dt As Data.DataTable In ds.Tables
               If dt.HasErrors Then
                  ' Select each row in data table
                  For Each row As Data.DataRow In dt.GetErrors
                     sb.AppendLine(row.RowState)
                  Next
               End If
            Next

            ' Validate using validator
            Me.CustomValidator1.IsValid = False
            Me.CustomValidator1.Text = "Total Datatables: " & ds.Tables.Count
         Catch ex As Exception
            Me.CustomValidator1.IsValid = False
            Me.CustomValidator1.Text = "File uploaded is not a valid project file."
         End Try
      Else
         Me.CustomValidator1.IsValid = False
         Me.CustomValidator1.Text = "Select a file to upload."
      End If
   End Sub

   Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate

   End Sub

   Public Function EditCrawlProjectLink(ByVal projID As Integer) As String
      Return "EditCrawlProject.aspx?CrawlProjectID=" & projID
   End Function

   Public Function CrawlProjectInfoLink(ByVal projID As Integer) As String
      Return "CrawlProjectInfo.aspx?CrawlProjectID=" & projID
   End Function

   Public Function CrawlProjectUrl(ByVal projID As Integer) As String
      Return "url.aspx?CrawlProjectID=" & projID
   End Function

   ' Load the project list
   Protected Sub GridView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.DataBound
      
   End Sub

   Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

   End Sub

   Protected Sub onSelectChange(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim dList As DropDownList = CType(sender, DropDownList)
      Console.WriteLine(dList.Text & " " & dList.SelectedValue)
   End Sub

   Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      If Not Page.IsPostBack Then
         DataBind()
      End If
   End Sub

   Public Overrides Sub DataBind()
      Dim projMgr As New ScraperLib.CrawlProjectManager(App.SqlConnection)
      projMgr.LoadProjects()

      Me.GridView1.AutoGenerateColumns = True
      Me.GridView1.DataSource = projMgr.CrawlProjectHollows
      Me.GridView1.DataBind()
      'setUpGrid(Me.GridView1, projMgr)
      'Me.initGrid()
   End Sub

   Class Projects
      Dim _name As String
      Property ProjectName() As String
         Get
            Return Me._name
         End Get
         Set(ByVal value As String)
            Me._name = value
         End Set
      End Property

      Private _list As New System.Collections.Generic.List(Of MyItems)
      Public ReadOnly Property Items() As System.Collections.Generic.List(Of MyItems)
         Get
            Return _list
         End Get
      End Property

      Public Sub New(ByVal name As String, ByVal total As Integer)
         Me._name = name
         For i As Integer = 0 To total
            Me._list.Add(New MyItems(i))
         Next
      End Sub
   End Class

   Private Sub initGrid()
      Dim projectList As New Collections.Generic.List(Of Projects)

      For i As Integer = 0 To 15
         projectList.Add(New Projects("Project " & i, i))
      Next

      Dim boundCol As New BoundField()
      boundCol.DataField = "ProjectName"
      boundCol.HeaderText = "Crawl Project"

      Dim tempCol As New TemplateField
      tempCol.HeaderText = "Data Tables"
      tempCol.ItemTemplate = New GridViewTemplate(DataControlRowType.DataRow, "Author Name")

      Me.GridView1.Columns.Add(boundCol)
      Me.GridView1.Columns.Add(tempCol)

      Me.GridView1.DataSource = projectList
      Me.GridView1.DataBind()
   End Sub

   Private Sub setUpGrid(ByVal gv As GridView, ByVal projMgr As ScraperLib.CrawlProjectManager)
      Dim projDT As ScraperLib.ScraperDB.CrawlProjectDataTable = projMgr.ProjectDT
      Dim boundCol As New BoundField()
      boundCol.DataField = projDT.NameColumn.ColumnName
      boundCol.HeaderText = "Crawl Project"

      Dim linkCol As New HyperLinkField
      linkCol.DataTextField = projDT.NameColumn.ColumnName
      linkCol.DataNavigateUrlFields = New String() {projDT.NameColumn.ColumnName}
      linkCol.DataNavigateUrlFormatString = "crawl_project_details.asp?{0}"

      Dim tempCol As New TemplateField
      tempCol.HeaderText = "Data Tables"
      tempCol.ItemTemplate = New GridViewTemplate(DataControlRowType.DataRow, "Author Name")

      For Each hollowProj As ScraperLib.CrawlProjectHollow In projMgr.CrawlProjectHollows

      Next

      gv.Columns.Add(boundCol)
      gv.Columns.Add(linkCol)
      gv.Columns.Add(tempCol)

      gv.DataSource = projDT
      gv.DataBind()
   End Sub
End Class

