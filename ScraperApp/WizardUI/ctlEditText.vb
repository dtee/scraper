Public Class ctlEditText

   Public Overrides Property Text() As String
      Get
         Return Me.RichTextBox1.Text
      End Get
      Set(ByVal value As String)
         Me.RichTextBox1.Text = value
      End Set
   End Property

   Private _FieldDT As DataTable
   ''' <summary>
   ''' Expects the same database format that ScraperNode 's field dt
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FieldDT() As DataTable
      Get
         Return _FieldDT
      End Get
      Set(ByVal value As DataTable)
         Me._FieldDT = value

         ' Fill up the combo box with the field data
         If Me._FieldDT IsNot Nothing Then
            Me.ComboBox1.DataSource = Me._FieldDT
            Me.ComboBox1.DisplayMember = "Data"

            If Me.ComboBox1.Items.Count > 0 Then
               Me.ComboBox1.SelectedIndex = 0
               Me.Text = Me.ComboBox1.SelectedText
            Else
               Me.Panel1.Visible = False
            End If
         Else
            Me.Panel1.Visible = False
         End If
      End Set
   End Property

   Public Sub New(ByVal FieldDT As DataTable)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me.FieldDT = FieldDT
   End Sub

   Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
      Me.Text = ComboBox1.Text
   End Sub
End Class
