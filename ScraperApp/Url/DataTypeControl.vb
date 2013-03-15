Public Class DataTypeControl

   Private _DataType As DataTypeManager
   Public Property DataTypeManager() As DataTypeManager
      Get
         Return _DataType
      End Get
      Set(ByVal value As DataTypeManager)
         _DataType = value

         Me.DataTypeListBox.DataSource = Nothing
         If _DataType IsNot Nothing Then
            Me.DataTypeListBox.DataSource = _DataType.DataTypeList
            Me.DataTypeListBox.DisplayMember = "DataTypeName"
         End If
      End Set
   End Property

   Private Sub DataTypeListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataTypeListBox.SelectedIndexChanged
      Dim selectedDataType As DataType = DataTypeListBox.SelectedItem

      If selectedDataType IsNot Nothing Then
         Me.DataTypeCodeRichTextBox.DataBindings.Clear()
         Me.DataTypeNameTextBox.DataBindings.Clear()

         Me.DataTypeCodeRichTextBox.DataBindings.Add("Text", selectedDataType, "DataTypeCode")
         Me.DataTypeNameTextBox.DataBindings.Add("Text", selectedDataType, "DataTypeName")
      End If
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompileButton.Click
      Dim selectedDataType As DataType = DataTypeListBox.SelectedItem

      If selectedDataType IsNot Nothing Then
         Try
            selectedDataType.CompileCode()

            MsgBox("Compiled successfully.")
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)

            MsgBox(ex.Message)
         End Try
      End If
   End Sub

   Private Sub TestButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestButton.Click
      Dim selectedDataType As DataType = DataTypeListBox.SelectedItem

      If selectedDataType IsNot Nothing AndAlso selectedDataType.DataObject IsNot Nothing Then
         Dim dtUI As New DataTypeTestUI(selectedDataType)
         dtUI.ShowDialog()
      Else
         MsgBox("The object is not valid.")
      End If
   End Sub
End Class
