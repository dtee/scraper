Public Class ResultDSUI
   Public Event Event_Closing()

   Private ds As DataSet
   Public Property [DataSet]() As DataSet
      Get
         Return ds
      End Get
      Set(ByVal value As DataSet)
         Me.CrawledDataControl1.DataSet = value
      End Set
   End Property

   Private _IsExit As Boolean
   Public Property IsExit() As Boolean
      Get
         Return _IsExit
      End Get
      Set(ByVal value As Boolean)
         _IsExit = value
         Me.Close()
      End Set
   End Property

   Private Sub ShowDS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      If Me._IsExit = False Then
         Me.Visible = False
         e.Cancel = True
         RaiseEvent Event_Closing()
      End If
   End Sub

   Private Sub handleProgress(ByVal text As String) Handles CrawledDataControl1.Progress
      Me.TotalRowToolStripStatusLabel.Text = text
   End Sub
End Class
