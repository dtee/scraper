Public Class ProxyChecker
   Private _ProxyManager As ProxyManager
   Public Sub New(ByVal proxyManager As ProxyManager)
      Me._ProxyManager = proxyManager
   End Sub

   Public Event OneCheckCompleted()
   Public Event AllCheckCompleted()

   ''' <summary>
   ''' Abort the proxy checking thread.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub Abort()
      ' Set the abort signal 
      Me._IsAbort = True
   End Sub

   Private TotalThreads As Integer = 10
   Private _Url As Uri               ' Url to download
   Private _content As String          ' Content that should exists in the content downloaded by url
   Private _IsAbort = False

   ''' <summary>
   ''' Check the proxy list given a url and the content
   ''' </summary>
   ''' <param name="url"></param>
   ''' <param name="content"></param>
   ''' <remarks></remarks>
   Public Sub check(ByVal url As Uri, ByVal content As String)
      Me._IsAbort = True

      NewStartAll()        ' Start up the proxy checking function
   End Sub


#Region "New WebClient - Proxy Checking"
   ' Currently proxies being checked by the thread.
   Private ProxyCheckingList As New List(Of ScraperDB.ProxyRow)

   ''' <summary>
   ''' Web client to download proxy by proxy
   ''' </summary>
   ''' <remarks></remarks>
   Private WithEvents mMyWebclient As New NetworkClient.MultiWebClient

   ''' <summary>
   ''' Check all the proxies
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub NewStartAll()
      ' Stop all if it running
      Dim TotalThreads As Integer = Me.TotalThreads
      If TotalThreads > Me._ProxyManager.ProxyToCheckCount Then
         TotalThreads = Me._ProxyManager.ProxyToCheckCount
      End If

      If TotalThreads = 0 And Me.ProxyCheckingList.Count = 0 Then
         ' Finish checking all proxy, edit
         Exit Sub
      End If

      For i As Integer = Me.ProxyCheckingList.Count To TotalThreads - 1
         Dim proxyRow As ScraperDB.ProxyRow = Me._ProxyManager.ProxyToCheck

         ' If aborted, dun't start any more checking
         If proxyRow IsNot Nothing And Not Me._IsAbort Then
            Dim p As New Net.WebProxy(proxyRow.ProxyLink, proxyRow.ProxyPort)
            mMyWebclient.DownloadStringAsync(Me._Url, "", p, proxyRow)
            Me.ProxyCheckingList.Add(proxyRow)
         End If
      Next
   End Sub

   Public Sub ThreadFinished(ByVal sender As Object, ByVal e As NetworkClient.ThreadFinishedEventArgs) Handles mMyWebclient.ThreadFinished
      Dim proxyRow As ScraperDB.ProxyRow = e.UserState

      ' User manually cancled the thread download
      If e.Cancelled Then        ' Do nothing, and do not start up a new download
         ' This only happens when i am removed, so lets not remove again
         proxyRow.ProxyStatusID = ProxyManager.ProxyStatus.Unknown
         Me._IsAbort = True
      Else
         Select Case e.ErrorStatus
            Case NetworkClient.DownloadError.NoConnection
               proxyRow.ProxyStatusID = ProxyManager.ProxyStatus.Unknown
               Me._IsAbort = True         ' Connection error, abort the thread
            Case NetworkClient.DownloadError.NonRecoverable
               proxyRow.ProxyStatusID = ProxyManager.ProxyStatus.Error
            Case NetworkClient.DownloadError.Recoverable
               proxyRow.ProxyStatusID = ProxyManager.ProxyStatus.Error
         End Select
      End If

      ' Assign new proxy to test
      Me.ProxyCheckingList.Remove(proxyRow)
      If Me._IsAbort Then
         If Me.ProxyCheckingList.Count = 0 Then       ' Finished all
            ' Finished Checking all proxies, raise event
            RaiseEvent AllCheckCompleted()
         End If
      Else
         NewStartAll()        ' Start all up again
      End If
   End Sub

   Public Sub DownloadStringCompleted(ByVal sender As Object, ByVal e As NetworkClient.DownloadStringCompletedEventArgs) Handles mMyWebclient.DownloadStringCompleted
      Dim proxyRow As ScraperDB.ProxyRow = e.UserState

      ' Check the download string
      If e.Result.Contains(Me._content) Then
         proxyRow.ProxyStatusID = ProxyManager.ProxyStatus.Ready
      Else
         ' Error proxy 
         proxyRow.ProxyStatusID = ProxyManager.ProxyStatus.Error
      End If

      ' Update proxy information - Average speed stuffs.
      Dim averageSpeed As Integer = e.Result.Length / e.Elapsed.TotalSeconds
      If proxyRow.AverageSpeed > 0 Then
         proxyRow.AverageSpeed = (proxyRow.AverageSpeed + averageSpeed) / 2
      Else
         proxyRow.AverageSpeed = averageSpeed
      End If

      proxyRow.TotalAnonymous += 1
   End Sub

   ''' <summary>
   ''' Stop all downloads
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub NewStopAll()
      While ProxyCheckingList.Count > 0
         Dim row As ScraperDB.ProxyRow = ProxyCheckingList.Item(0)
         Me.mMyWebclient.CancelAsync(row)
         ProxyCheckingList.Remove(row)
      End While
   End Sub
#End Region
End Class
