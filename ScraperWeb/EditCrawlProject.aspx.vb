
Partial Class EditCrawlProject
   Inherits System.Web.UI.Page

   Protected Sub DetailsView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailsView1.DataBound
      'If DetailsView1.Rows.Count = 0 Then Exit Sub

      'Dim commandRowIndex As Integer = DetailsView1.Rows.Count - 1
      'Dim commandRow As DetailsViewRow = DetailsView1.Rows(commandRowIndex)
      'Dim cell As DataControlFieldCell = CType(commandRow.Controls(0), DataControlFieldCell)
      '' Loop through controls to find Cancel button
      'For Each ctl As Control In cell.Controls
      '   If TypeOf ctl Is LinkButton Then
      '      Dim btn As LinkButton = CType(ctl, LinkButton)
      '      If btn.CommandName = "Cancel" Then
      '         btn.ToolTip = "Click here to cancel"
      '         btn.CommandName = "Cancel"
      '         btn.PostBackUrl = "default.aspx"
      '         btn.OnClientClick = "if(!confirm('Do you really want to discard the changes?')){return false;}"
      '      End If
      '   End If
      'Next

   End Sub

   Protected Sub DetailsView1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles DetailsView1.Init
   
   End Sub

   Protected Sub DetailsView1_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewCommandEventArgs) Handles DetailsView1.ItemCommand
      If e.CommandName = "Cancel" Then
         Me.Response.Redirect("Default.aspx")
      End If
   End Sub

   Protected Sub DetailsView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewUpdatedEventArgs) Handles DetailsView1.ItemUpdated
      Me.Response.Redirect("Default.aspx")
   End Sub

   Protected Sub DetailsView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DetailsViewPageEventArgs) Handles DetailsView1.PageIndexChanging

   End Sub
End Class
