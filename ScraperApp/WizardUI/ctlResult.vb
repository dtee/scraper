Public Class ctlResult
   Public Overrides Property Text() As String
      Get
         Return Me.RichTextBox1.Text
      End Get
      Set(ByVal value As String)
         Me.RichTextBox1.Text = value
      End Set
   End Property

End Class
