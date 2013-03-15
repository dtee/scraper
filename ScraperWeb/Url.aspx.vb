
Imports System.Collections.Generic

Partial Class _Default
   Inherits System.Web.UI.Page

   Private crawlProjUrl As String = "SELECT Url.UriID, Url.UrlLink, Url.LastScraped, Url.DateAdded, UrlStatus.Name FROM Url INNER JOIN UrlStatus ON Url.UrlStatusID = UrlStatus.UrlStatusID WHERE (CrawlProjectID_FK = @id)"

   Private projurl As String = "SELECT Url.UrlID, Url.UrlLink, Url.LastScraped, Url.DateAdded, " & _
            "UrlStatus.Name FROM Url INNER JOIN UrlStatus ON Url.UrlStatusID = " & _
            "UrlStatus.UrlStatusID INNER JOIN Project_Url ON Url.UrlID = Project_Url.UrlID WHERE (Project_Url.ProjectID = @id)"

   Private statusFilter = " AND (UrlStatusID = @StatusID)"
   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If Not Page.IsPostBack Then
         GridView1.AutoGenerateColumns = False
         bindData()
      End If
   End Sub

   Private Sub bindData()
      Dim projID As Integer

      Dim sqlDS As New SqlDataSource()
      sqlDS.ConnectionString = App.connStr

      If Request.QueryString("ProjectID") IsNot Nothing Then
         sqlDS.SelectCommand = projurl
         projID = Request.QueryString("ProjectID")
      ElseIf Request.QueryString("CrawlProjectID") IsNot Nothing Then
         sqlDS.SelectCommand = crawlProjUrl
         projID = Request.QueryString("CrawlProjectID")
      Else

      End If

      If sqlDS.SelectCommand IsNot Nothing Then
         sqlDS.SelectParameters.Add("id", TypeCode.Int32, projID)

         If Request.QueryString("UrlStatusID") IsNot Nothing Then
            sqlDS.SelectCommand &= statusFilter
            sqlDS.SelectParameters.Add("StatusID", TypeCode.Int32, Request.QueryString("UrlStatusID"))
         End If

         GridView1.DataSource = sqlDS
         GridView1.DataBind()

         ' Add the data table columns
      Else
         GridView1.DataSource = Nothing
         GridView1.DataBind()
      End If
   End Sub

   Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
      GridView1.PageIndex = e.NewPageIndex
      bindData()
   End Sub

   Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

   End Sub

   Private Function EvalUrlLink(ByVal id As Integer) As String
      Return String.Format("ScrapedData.aspx?UrlID={0}", id)
   End Function
End Class