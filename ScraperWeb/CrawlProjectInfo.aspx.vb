
Partial Class CrawlProjectInfo
    Inherits System.Web.UI.Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If Not Page.IsPostBack Then
         Dim projID As Integer = Request.QueryString("CrawlProjectID")

         Dim projSQL As String = "SELECT [Name], [ProjectID] FROM [Project] WHERE ([CrawlProjectID] = @CrawlProjectID)"
         Dim dataSql As String = "SELECT DISTINCT TagLibrary.TagName as Name FROM CrawlProject INNER" & _
                           " JOIN Project ON CrawlProject.CrawlProjectID = Project.CrawlProjectID INNER JOIN TagLibrary ON " & _
                           "Project.ProjectID = TagLibrary.ProjectID WHERE (CrawlProject.CrawlProjectID = @CrawlProjectID) " & _
                           " AND (TagLibrary.IsDataTable = 1)"


         Dim sqlDS As New SqlDataSource()
         sqlDS.ConnectionString = App.connStr
         sqlDS.SelectCommand = projSQL
         sqlDS.SelectParameters.Add("CrawlProjectID", TypeCode.Int32, projID)

         GridView1.DataSource = sqlDS
         GridView1.DataBind()

         sqlDS = New SqlDataSource()
         sqlDS.ConnectionString = App.connStr
         sqlDS.SelectCommand = dataSql
         sqlDS.SelectParameters.Add("CrawlProjectID", TypeCode.Int32, projID)

         GridView2.DataSource = sqlDS
         GridView2.DataBind()
      End If
   End Sub

   Public Function DataTableEval(ByVal name As String) As String
      Dim projID As Integer = Request.QueryString("CrawlProjectID")
      Return String.Format("ScrapedData.aspx?CrawlProjectID={0}&TableName={1}", projID, name)
   End Function

   Public Function EvalProjectUrlPage(ByVal id As Integer) As String
      Return String.Format("url.aspx?ProjectID={0}", id)
   End Function
End Class
