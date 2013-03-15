Imports System.Windows.Forms

Public Class ProjectInfoEditForm
   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Me.Save()
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
   End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
   End Sub

   Private _ProjectRow As ScraperDB.ProjectRow
   Public Property ProjectRow() As ScraperDB.ProjectRow
      Get
         Return _ProjectRow
      End Get
      Set(ByVal value As ScraperDB.ProjectRow)
         _ProjectRow = value

         If (value IsNot Nothing) Then
            Me.ProjectNameTextBox.Text = _ProjectRow.Name
         End If
      End Set
   End Property

   Public Sub Save()
      Dim t As New TimeSpan(Me.IntervalDay.Value, Me.IntervalHour.Value, Me.IntervalMinute.Value)
      Me._ProjectRow.Name = Me.ProjectNameTextBox.Text

   End Sub

   Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaskPasswordCheckBox.CheckedChanged
      If Me.MaskPasswordCheckBox.Checked Then
         Me.PasswordTextBox.PasswordChar = "*"
      Else
         Me.PasswordTextBox.PasswordChar = ""
      End If
   End Sub
End Class
