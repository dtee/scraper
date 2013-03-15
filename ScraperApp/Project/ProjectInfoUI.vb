Imports System.Windows.Forms

Public Class ProjectInfoUI
   Private _Project As Project
   Public Sub New(ByVal proj As Project)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me._Project = proj

      Me.ProjectNameTextBox.Text = Me._Project.ProjectRow.Name
      Me.ProjectContentTextBox.Text = Me._Project.ProjectRow.UrlCheckContent
   End Sub

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Me._Project.ProjectRow.Name = Me.ProjectNameTextBox.Text
      Me._Project.ProjectRow.UrlCheckContent = Me.ProjectContentTextBox.Text

      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub
End Class
