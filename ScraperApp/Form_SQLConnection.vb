Imports System.Text.RegularExpressions

Public Class SQLConnectionDialog
   Private _Conn As SqlClient.SqlConnection
   Public Property Conn() As SqlClient.SqlConnection
      Get
         Return _Conn
      End Get
      Set(ByVal value As SqlClient.SqlConnection)
         _Conn = value

         If value IsNot Nothing Then
            ParseConnectionString()
         End If

      End Set
   End Property

   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me.Conn = New SqlClient.SqlConnection(ScraperApp.My.Settings.ScraperDBConnectionString)
   End Sub

   Private Sub ParseConnectionString()
      ' Get Security Type
      If _Conn.ConnectionString.Contains("Integrated Security=True") Then
         Me.ConnTypeComboBox.SelectedIndex = 0
      Else
         Me.ConnTypeComboBox.SelectedIndex = 1
      End If

      ' Fill username/pasword

      ' Fill Datasource
      Dim pattern As String = "Data Source=([\w\W\s]*?);"
      Dim m As Match = Regex.Match(Me._Conn.ConnectionString, pattern)
      If m.Success Then
         Me.DataSourceTextBox.Text = m.Groups(1).Value
      End If

      ' set database
      pattern = "Initial Catalog=([\w\W\s]*?);"
      m = Regex.Match(Me._Conn.ConnectionString, pattern)
      If m.Success Then
         Me.DatabaseTextBox.Text = m.Groups(1).Value
      End If
   End Sub

   ''' <summary>
   ''' Return connection string
   ''' </summary>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function GetConnectionString() As String
      Dim str As New System.Text.StringBuilder
      str.Append("Data Source=" & Me.DataSourceTextBox.Text & ";")
      str.Append("Initial Catalog=" & Me.DatabaseTextBox.Text & ";")

      If Me.ConnTypeComboBox.SelectedIndex = 0 Then
         str.Append("Integrated Security=True;")
      Else
         str.Append("")
      End If
      Return str.ToString
   End Function

   Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
   End Sub

   Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
   End Sub

   Private Sub ConnTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnTypeComboBox.SelectedIndexChanged
      If Me.ConnTypeComboBox.SelectedIndex = 0 Then
         Me.GroupBox1.Enabled = False
      Else
         Me.GroupBox1.Enabled = True
      End If
   End Sub

   Private Sub ConnectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectButton.Click
      Dim conn As New SqlClient.SqlConnection(Me.GetConnectionString)

      Console.WriteLine(Me.GetConnectionString)
      Try
         conn.Open()
         Me.OKButton.Enabled = True
         MsgBox("Connection is successful.")
      Catch ex As Exception
         MsgBox(ex.Message)
         Me.OKButton.Enabled = False
      End Try
   End Sub
End Class