
Partial Class ScrapedData
   Inherits System.Web.UI.Page
   Private dataColSql As String = "SELECT DISTINCT TagLibrary.TagName AS FieldName FROM TagLibrary INNER JOIN TagLibrary AS ParentTagLib " & _
"ON TagLibrary.Parent_TagID = ParentTagLib.TagID WHERE (ParentTagLib.TagName = @TagName) " & _
"AND (ParentTagLib.isSaveData = 0)"

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If Not Page.IsPostBack Then
         bindData()
      End If
   End Sub

   Private Sub bindData()
      Try

         Dim sqlDS As New SqlDataSource()
         sqlDS.ConnectionString = App.connStr
         sqlDS.SelectCommand = "Select * from " & Me.getTableName

         ' Find Columns to show for the table

         GridView1.DataSource = sqlDS
         GridView1.ToolTip = "View Data"

         If Request.QueryString("UrlID") IsNot Nothing Then
            Dim urlID As Integer = Request.QueryString("UrlID")
            sqlDS.SelectCommand &= " WHERE (UrlID_FK = @UrlID)"

            sqlDS.SelectParameters.Add("UrlID", TypeCode.Int32, Request.QueryString("UrlID"))
         End If

         GridView1.DataBind()

         'For i As Integer = 0 To 3
         '   CType(GridView1, GridViewEx2).BoundColumns(i).Visible = False
         'Next
      Catch ex As Exception
         Me.CustomValidator1.IsValid = False
         Me.CustomValidator1.Text = ex.Message
      End Try
   End Sub

   Private Function getTableName() As String
      If Request.QueryString("TableName") Is Nothing AndAlso Request.QueryString("CrawlProjectID") Is Nothing Then
         Throw New Exception("Requires data table name and CrawlProjectID")
      End If

      Dim dtName As String = Request.QueryString("TableName")
      Dim projID As Integer = Request.QueryString("CrawlProjectID")
      Return String.Format("{0}_{1}_{2}", "SYS", dtName, projID)
   End Function

   Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

   End Sub

   Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
      GridView1.PageIndex = e.NewPageIndex
      bindData()
   End Sub

   Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
      'Me.GridView1 = New GridViewEx2()
   End Sub
End Class

Public Class GridViewEx2
   Inherits GridView

   Private _boundColumns As DataControlFieldCollection = New DataControlFieldCollection

   Public ReadOnly Property BoundColumns() As DataControlFieldCollection
      Get
         Return _boundColumns
      End Get
   End Property

   Protected Shadows Function CreateColumns(ByVal dataSource As PagedDataSource, ByVal useDataSource As Boolean) As ICollection
      Return MyBase.CreateColumns(dataSource, useDataSource)

      'Dim generatedColumns As ICollection = MyBase.CreateColumns(dataSource, useDataSource)
      '_boundColumns.Clear()

      'For Each column As DataControlField In generatedColumns
      '   _boundColumns.Add(CType(column, DataControlField))
      'Next
      'Return _boundColumns
   End Function
End Class