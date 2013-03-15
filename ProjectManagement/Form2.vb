Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Form2

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      Dim encoding As ASCIIEncoding = New ASCIIEncoding
      Dim postData As String = Me.getPostData(Me.postDatadt)

      Dim data() As Byte = encoding.GetBytes(postData)
      Dim myRequest As HttpWebRequest = CType(WebRequest.Create("http://www.hongfire.com/forum/login.php"), HttpWebRequest)
      myRequest.Method = "POST"
      myRequest.AllowAutoRedirect = True
      myRequest.MaximumAutomaticRedirections = 5
      myRequest.ContentType = "application/x-www-form-urlencoded"
      myRequest.ContentLength = data.Length
      myRequest.CookieContainer = New CookieContainer()
      myRequest.UserAgent = ""
      myRequest.CookieContainer.Add(New Cookie("hongfiresessionhash", "83c0e9b30253cb65c719e95ced7e4f50", "/", ".hongfire.com"))
      myRequest.CookieContainer.Add(New Cookie("hongfirelastvisit", "1147905947", "/", ".hongfire.com"))
      myRequest.CookieContainer.Add(New Cookie("hongfirelastactivity", "0", "/", ".hongfire.com"))
      myRequest.CookieContainer.Add(New Cookie("hongfireuserid", "93565", "/", ".hongfire.com"))
      myRequest.CookieContainer.Add(New Cookie("hongfirepassword", "2abbc920f110d52e28be4b1aef8e2184", "/", ".hongfire.com"))

      Dim newStream As Stream = myRequest.GetRequestStream

      ' Send the data.
      newStream.Write(data, 0, data.Length)
      newStream.Close()

      Dim re As HttpWebResponse = myRequest.GetResponse
      Console.WriteLine("totalcookie" & re.Cookies.Count)
      For Each c As Cookie In re.Cookies
         Console.Write(c.Domain & " ")
         Console.Write(c.Path & " ")
         Console.WriteLine(c.ToString)
      Next

      Dim i As New IO.StreamReader(re.GetResponseStream)
      Dim html As String = i.ReadToEnd
      Me.RichTextBox1.Text = html

      ' Request it again... this time we should see a differnt page

   End Sub

   ' Find form element within form
   Private Sub findFormElements()
      Dim regex As String = "<form"
   End Sub

   Private Sub onDocClink(ByVal sender As Object, ByVal e As System.Windows.Forms.HtmlElementEventArgs)
      Me.RichTextBox1.Text = e.ToElement.OuterHtml
   End Sub

   Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
      'Console.WriteLine(Me.WebBrowser1.Document.Cookie)

      Dim d As HtmlDocument = WebBrowser1.Document
      Me.BackToolStripButton.Enabled = Me.WebBrowser1.CanGoBack
      Me.ForwardToolStripButton.Enabled = Me.WebBrowser1.CanGoForward

      If d Is Nothing Then Exit Sub
      If Not Me.SpyPostDataToolStripButton.Checked Then Exit Sub

      For i As Integer = 0 To d.Forms.Count - 1
         Console.WriteLine("Before: " & d.Forms(i).GetAttribute("Action"))
         d.Forms(i).SetAttribute("Action", "http://localhost/ScraperWeb/post.aspx")
         Console.WriteLine("After: " & d.Forms(i).GetAttribute("Action"))
      Next
   End Sub

   Dim postDatadt As New UrlPostData.PostDataDTDataTable
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Me.CreatePostDataRows(Me.RichTextBox1.Text)
      Me.DataGridView1.DataSource = Me.postDatadt
   End Sub

   Public Sub CreatePostDataRows(ByVal str As String)
      Dim pattern As String = "^(.*?):(.*?)$"

      Dim ma As MatchCollection = Regex.Matches(str, pattern, RegexOptions.Multiline)
      For Each m As Match In ma
         Dim r As UrlPostData.PostDataDTRow = Me.postDatadt.NewPostDataDTRow
         r.Name = m.Groups(1).Value
         r.Value = m.Groups(2).Value
         r.EncodedValue = Uri.EscapeDataString(r.Value)
         Me.postDatadt.AddPostDataDTRow(r)
      Next
   End Sub

   Public Function getPostData(ByVal PostDataDT As UrlPostData.PostDataDTDataTable) As String
      Dim s As New StringBuilder
      For Each r As UrlPostData.PostDataDTRow In PostDataDT.Rows
         s.Append(Uri.EscapeDataString(r.Name))
         s.Append("=")
         s.Append(Uri.EscapeDataString(r.Value))
         s.Append("&")
      Next
      Return s.ToString
   End Function

   Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.postDatadt.Clear()
      Me.CreatePostDataRows(Me.RichTextBox1.Text)
   End Sub

   Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoToolStripButton.Click
      Dim url As New Uri(Me.UrlToolStripTextBox.Text)
      Me.WebBrowser1.Navigate(url)
   End Sub

   Private Sub BackToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackToolStripButton.Click
      If Me.WebBrowser1.CanGoBack Then Me.WebBrowser1.GoBack()
   End Sub

   Private Sub ForwardToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForwardToolStripButton.Click
      If Me.WebBrowser1.CanGoForward Then Me.WebBrowser1.GoForward()
   End Sub

   Private Sub SpyPostDataToolStripButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpyPostDataToolStripButton.CheckedChanged
      Me.WebBrowser1.Refresh()
   End Sub

   Private Sub WebBrowser1_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated

   End Sub
End Class