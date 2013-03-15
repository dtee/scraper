Imports System.Windows.Forms

Public Class DataTypeTestUI

   Private _dataType As DataType
   Public Sub New(ByVal _dataType As DataType)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me._dataType = _dataType
   End Sub

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      If Me._dataType.DataObject IsNot Nothing Then
         Me.ResultRichTextBox.Text = _dataType.DataObject.Refine(Me.SampleDataRichTextBox.Text)
      End If
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

End Class
