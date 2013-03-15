Imports System.Text.RegularExpressions
Imports LCSDelta

Public Class LCSTest
   Private MatchColor As Color = Color.LightBlue
   Private NoMatchColor As Color = Color.LightYellow
   Dim lcsDelta1 As New LCSDelta.LCSDelta

   Private Sub CompareButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompareButton.Click
      lcsDelta1.FindMatch(Me.RichTextBox1.Text, Me.RichTextBox2.Text)

      ' Color the results
      Dim x As LCSString = lcsDelta1.xLCSString
      Dim y As LCSString = lcsDelta1.yLCSString

      For Each mInfo As LCSMatchInfo In x.LCSMatchList
         Me.RichTextBox1.SelectionStart = mInfo.iStart
         Me.RichTextBox1.SelectionLength = mInfo.iStop - mInfo.iStart + 1

         Me.RichTextBox1.SelectionBackColor = Me.MatchColor
         'rtfEdit.changeBackground(mInfo.iStart, mInfo.iStop, Me.MatchColor)
      Next

      'Console.WriteLine(y.Text)
      'rtfEdit.Text = y.Text
      For Each mInfo As LCSMatchInfo In y.LCSMatchList
         Me.RichTextBox2.SelectionStart = mInfo.iStart
         Me.RichTextBox2.SelectionLength = mInfo.iStop - mInfo.iStart + 1

         Me.RichTextBox2.SelectionBackColor = Me.MatchColor
         'rtfEdit.changeBackground(mInfo.iStart, mInfo.iStop, Me.MatchColor)
      Next
      'RichTextBox2.Rtf = rtfEdit.RTFText
   End Sub

   Private Sub ClearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearButton.Click

      Dim myHT As New Hashtable()
      myHT.Add("First", 1)
      myHT.Add("Second", 2)
      myHT.Add("Third", 3)

      myHT("Third") += 1

      ' Displays the properties and values of the Hashtable.
      Console.WriteLine("myHT")
      Console.WriteLine("  Count:    {0}", myHT.Count)
      Console.WriteLine("  Keys and Values: {0}", myHT("Third"))

      Dim body As String = "aaaaaaaaa"
      Dim toFind As String = "aaa"
      Dim m As MatchCollection = Regex.Matches(body, Regex.Escape(toFind))

      Console.WriteLine(m.Count)

      For Each ma As Match In m
         Console.WriteLine(ma.Value)
      Next
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
   End Sub
End Class