Imports System.Windows.Forms

Public Class TreeNodeColorEdit

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   Private Sub TreeNodeColorEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Me.TreeView1.Nodes.Add(TagNodeColor.SampleNodes)
   End Sub
End Class
