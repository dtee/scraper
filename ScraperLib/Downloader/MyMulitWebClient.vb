Imports System.Net
Imports System.ComponentModel
Imports System.Threading
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.IO.Compression

Public Class MyMultiWebClient
   Public Delegate Sub MyDownloadProgressChangedEventHandler( _
       ByVal sender As Object, _
       ByVal e As MyMultiWebClient.MyDownloadProgressChangedEventArgs)

   Public Delegate Sub MyDownloadStringCompletedEventHandler( _
       ByVal sender As Object, _
       ByVal e As MyMultiWebClient.MyDownloadStringCompletedEventArgs)

   Public Delegate Sub MyThreadFinishedEventHandler( _
       ByVal sender As Object, _
       ByVal e As MyMultiWebClient.MyThreadFinishedEventArgs)

   Private OnDownloadProgressChanged As SendOrPostCallback
   Public Event DownloadProgressChanged As MyMultiWebClient.MyDownloadProgressChangedEventHandler
   Private Sub DoDownloadProgressChanged(ByVal e As Object)
      RaiseEvent DownloadProgressChanged(Me, e)
   End Sub

   Private OnDownloadStringCompleted As SendOrPostCallback
   Public Event DownloadStringCompleted As MyMultiWebClient.MyDownloadStringCompletedEventHandler
   Public Sub DoDownloadStringCompleted(ByVal e As Object)
      RaiseEvent DownloadStringCompleted(Me, e)
   End Sub

   Private OnThreadFinished As SendOrPostCallback
   Public Event ThreadFinished As MyMultiWebClient.MyThreadFinishedEventHandler
   Public Sub DoThreadFinished(ByVal e As Object)
      RaiseEvent ThreadFinished(Me, e)
   End Sub

   Public Class MyWebDownLoadInfo
      Public Uri As Uri
      Public Proxy As WebProxy
      Public referer As String
      Public AsyncOp As AsyncOperation
      Public UserState As Object

      Public Elapsed As TimeSpan
      Public Result As String
      Public IsCancled As Boolean
      Public Exception As Exception

      Public WebResponse As HttpWebResponse

      Public Sub New(ByVal Uri As Uri, ByVal Refereer As String, ByVal Proxy As WebProxy, ByVal UserState As Object, ByVal AsyncOp As AsyncOperation)
         Me.Uri = Uri
         Me.referer = referer
         Me.Proxy = Proxy
         Me.UserState = UserState
         Me.AsyncOp = AsyncOp

         Elapsed = New TimeSpan(0)
         Result = ""
         IsCancled = False
         Exception = Nothing
      End Sub
   End Class

   Public ReadOnly Property CurrentTotalThreads() As Integer
      Get
         Return Me.userStateToLifetime.Count
      End Get
   End Property

   Private userStateToLifetime As New Dictionary(Of Object, MyWebDownLoadInfo)
   Public Sub DownloadStringAsync(ByVal Uri As Uri, ByVal Referer As String, ByVal Proxy As WebProxy, ByVal UserState As Object)
      ' Create an AsyncOperation for taskId.
      Dim asyncOp As AsyncOperation = AsyncOperationManager.CreateOperation(UserState)
      Dim w As New MyWebDownLoadInfo(Uri, Referer, Proxy, UserState, asyncOp)

      ' Multiple threads will access the task dictionary,
      ' so it must be locked to serialize access.
      SyncLock userStateToLifetime
         If userStateToLifetime.ContainsKey(UserState) Then
            Throw New ArgumentException( _
                "Userstate parameter must be unique", _
                "taskId")
         End If

         userStateToLifetime.Add(UserState, w)
      End SyncLock

      Dim workerDelegate As New WorkerEventHandler(AddressOf Me.DownloadStringThread)
      workerDelegate.BeginInvoke(w, Nothing, Nothing)
   End Sub

   Public Sub CancelAsync(ByVal UserState As Object)
      SyncLock userStateToLifetime
         If userStateToLifetime.ContainsKey(UserState) Then
            Dim w As MyWebDownLoadInfo = userStateToLifetime(UserState)
            w.IsCancled = True

            ' Remove it form our thread op list!
            userStateToLifetime.Remove(w.UserState)

            Dim threadFinishedE As New MyThreadFinishedEventArgs(w.Exception, w.IsCancled, w.UserState)
            w.AsyncOp.Post(Me.OnThreadFinished, threadFinishedE)

            w.AsyncOp.OperationCompleted()         ' End this operation
         End If
      End SyncLock
   End Sub

   Public Sub CancelAllAsync()
      SyncLock userStateToLifetime
         For Each obj As Object In userStateToLifetime.Keys
            Dim w As MyWebDownLoadInfo = userStateToLifetime(obj)
            w.IsCancled = True

            Dim threadFinishedE As New MyThreadFinishedEventArgs(w.Exception, w.IsCancled, w.UserState)
            w.AsyncOp.Post(Me.OnThreadFinished, threadFinishedE)

            w.AsyncOp.OperationCompleted()         ' End this operation
         Next

         userStateToLifetime.Clear()
      End SyncLock
   End Sub

   Private Delegate Sub WorkerEventHandler(ByVal w As MyWebDownLoadInfo)

#Region "Shared"
   Public TimeOut As Integer = New TimeSpan(0, 1, 0).TotalMilliseconds
   Public UserAgent As String = "Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 4.0)"
   Public BufferSize As Integer = 1024
   Public Accept As String = "text/xml,application/xml,application/xhtml+xml,text/html;q=0.9,text/plain;q=0.8,image/png,*/*;q=0.5"
   Public AcceptLanguage As String = "en-us,en;q=0.5"
   Public AcceptEncoding As String = "gzip,deflate"
   Public KeepAlive As Boolean = False
   Public SleepSeconds As Integer = 5         ' Sleep delay in Seconds
#End Region

   Public Sub New()
      Me.OnDownloadStringCompleted = New SendOrPostCallback(AddressOf DoDownloadStringCompleted)
      Me.OnDownloadProgressChanged = New SendOrPostCallback(AddressOf DoDownloadProgressChanged)
      Me.OnThreadFinished = New SendOrPostCallback(AddressOf DoThreadFinished)
   End Sub

   Private _ElapsedSeconds As Integer = 0
   ''' <summary>
   ''' Total Time Elapsed
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ElapsedSeconds() As Integer
      Get
         Return _ElapsedSeconds
      End Get
   End Property

   ''' <summary>
   ''' Total Average Speed
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property AverageSpeed() As Integer
      Get
         If _ElapsedSeconds > 0 Then
            Return _TotalBytesReceived / _ElapsedSeconds
         End If
         Return 0
      End Get
   End Property

   Private _TotalBytesReceived As Integer = 0
   Public ReadOnly Property TotalBytesReceived() As Integer
      Get
         Return _TotalBytesReceived
      End Get
   End Property

   ''' <summary>
   ''' Download url set to the class
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub DownloadStringThread(ByVal w As MyWebDownLoadInfo)
      Dim downloadedBytes As Integer = 0
      Dim Content As New System.Text.StringBuilder
      Dim Exception As Exception = Nothing
      Dim _TimeElapsed As TimeSpan = New TimeSpan(0)
      Dim DownloadStartTime As Integer
      Dim _Request As HttpWebRequest
      Dim _Response As HttpWebResponse = Nothing

      Try
         DownloadStartTime = System.Environment.TickCount
         _Request = Net.WebRequest.Create(w.Uri)

         ' Set credentials to use for this request.
         _Request.Credentials = CredentialCache.DefaultNetworkCredentials

         'ADDED PROXY
         If (w.Proxy IsNot Nothing) Then
            _Request.Proxy = w.Proxy
         End If

         With _Request
            .Referer = w.referer
            .KeepAlive = Me.KeepAlive
            .Timeout = Me.TimeOut
            .AllowAutoRedirect = True
            .UserAgent = Me.UserAgent
         End With

         With _Request.Headers
            .Add(HttpRequestHeader.AcceptEncoding, Me.AcceptEncoding)
         End With

         Dim sTime As Integer = System.Environment.TickCount

         Dim e As New MyDownloadProgressChangedEventArgs(MyDownloadProgressChangedEventArgs.ProgressStatus.Requesting, _
            _TimeElapsed, 0, w.UserState, Nothing, 0)

         w.AsyncOp.Post(Me.OnDownloadProgressChanged, e)
         _Response = _Request.GetResponse()

         ' Read reponse header for validity
         Dim StreamResponse As Stream = _Response.GetResponseStream()

         If _Response.ContentEncoding = "gzip" Then
            StreamResponse = New Compression.GZipStream(StreamResponse, CompressionMode.Decompress)
            Console.WriteLine("Downloading gzip")
         ElseIf _Response.ContentEncoding = "deflate" Then
            StreamResponse = New Compression.DeflateStream(StreamResponse, CompressionMode.Decompress)
            Console.WriteLine("Downloading deflate")
         End If

         Dim txtRead As New IO.StreamReader(StreamResponse, True)

         Dim Buffer(BufferSize) As Char
         Dim BytesRead As Integer = txtRead.Read(Buffer, 0, Buffer.Length)
         Dim TotalBytesRead As Integer = 0
         While BytesRead > 0
            ' Append Temp string into the full content
            Content.Append(Buffer, 0, BytesRead)
            BytesRead = txtRead.Read(Buffer, 0, Buffer.Length)

            TotalBytesRead += BytesRead
            Me._TotalBytesReceived += BytesRead       ' Update overall Total bytes downloaded

            _TimeElapsed = TimeSpan.FromTicks((Environment.TickCount - DownloadStartTime) * 10000)
            e = New MyDownloadProgressChangedEventArgs(MyDownloadProgressChangedEventArgs.ProgressStatus.Downloading, _
                  _TimeElapsed, _Response.ContentLength, w.UserState, Nothing, 0)

            w.AsyncOp.Post(Me.OnDownloadProgressChanged, e)
         End While
         _ElapsedSeconds += (Environment.TickCount - DownloadStartTime) / 1000
         'Console.WriteLine("Speed: {0} {1} : {2}", TotalBytesRead, _ElapsedSeconds, TotalBytesRead / _ElapsedSeconds)
         _TimeElapsed = TimeSpan.FromTicks((Environment.TickCount - DownloadStartTime) * 10000)

         txtRead.Close()
         StreamResponse.Close()
         _Response.Close()
      Catch ex As Exception
         Exception = ex
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
      End Try

      If Not w.IsCancled Then
         Try
            w.Elapsed = _TimeElapsed
            w.Result = Content.ToString
            w.Exception = Exception
            w.WebResponse = _Response

            Dim e As New MyDownloadProgressChangedEventArgs(MyDownloadProgressChangedEventArgs.ProgressStatus.Downloaded, _
               _TimeElapsed, Content.Length, w.UserState, Content.ToString, 0)
            w.AsyncOp.Post(Me.OnDownloadProgressChanged, e)

            Dim completeE As New MyDownloadStringCompletedEventArgs(w.Exception, w.IsCancled, w.WebResponse, _
               w.Elapsed, w.Result, w.UserState)
            w.AsyncOp.Post(Me.OnDownloadStringCompleted, completeE)

            ' Lets Sleep for whatever given time.
            For i As Integer = 1 To Me.SleepSeconds
               System.Threading.Thread.Sleep(1000)    ' Sleep for 1 second and update progress

               e = New MyDownloadProgressChangedEventArgs(MyDownloadProgressChangedEventArgs.ProgressStatus.Sleeping, _
                  _TimeElapsed, Content.Length, w.UserState, Nothing, i)
               w.AsyncOp.Post(Me.OnDownloadProgressChanged, e)
            Next

            'Console.WriteLine("Total Time Taken: {0}", _TimeElapsed.ToString)

            ' Remove it form our thread op list!
            SyncLock userStateToLifetime
               Dim t As Boolean = userStateToLifetime.Remove(w.UserState)
            End SyncLock

            Dim threadFinishedE As New MyThreadFinishedEventArgs(w.Exception, w.IsCancled, w.UserState)
            w.AsyncOp.Post(Me.OnThreadFinished, threadFinishedE)


            w.AsyncOp.OperationCompleted()         ' End this operation
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            'Operation is cancled.
         End Try
      End If
   End Sub

   Public Enum DownloadError
      NoError = 0                ' No Error! YAY
      Recoverable = 1            ' Suggest keep trying
      NonRecoverable = 2         ' Suggests do not keep trying
      NoConnection = 3           ' Non Connection
   End Enum

   Public Class MyDownloadProgressChangedEventArgs
      Private _UserState As Object
      Public ReadOnly Property UserState() As Object
         Get
            Return _UserState
         End Get
      End Property

      Public Sub New(ByVal Status As ProgressStatus, ByVal Elapsed As TimeSpan, ByVal TotalBytesDownloaded As Integer, _
         ByVal UserState As Object, ByVal Result As String, ByVal SleepCount As Integer)

         _Elapsed = Elapsed
         _TotalBytesDownloaded = TotalBytesDownloaded
         _Status = Status
         _UserState = UserState
         _Result = Result
         _SleepCount = SleepCount
      End Sub

      Private _Result As String
      Public ReadOnly Property Result() As String
         Get
            Return _Result
         End Get
      End Property

      Private _Status As ProgressStatus
      Public ReadOnly Property Status() As ProgressStatus
         Get
            Return _Status
         End Get
      End Property

      Private _Elapsed As TimeSpan
      Public ReadOnly Property Elapsed() As TimeSpan
         Get
            Return _Elapsed
         End Get
      End Property

      Private _TotalBytesDownloaded As Integer
      Public ReadOnly Property BytesReceived() As Integer
         Get
            Return _TotalBytesDownloaded
         End Get
      End Property

      Private _SleepCount As Integer
      Public ReadOnly Property SleepCount() As Integer
         Get
            Return _SleepCount
         End Get
      End Property

      Public Enum ProgressStatus
         Starting
         Requesting
         Downloading
         Downloaded
         Sleeping
      End Enum
   End Class

   Public Class MyThreadFinishedEventArgs
      Inherits AsyncCompletedEventArgs

      Public Sub New(ByVal e As Exception, ByVal Iscanceled As Boolean, ByVal state As Object)
         MyBase.New(e, Iscanceled, state)
      End Sub

      Public ReadOnly Property ErrorStatus() As DownloadError
         Get
            Dim status As DownloadError
            If MyBase.Error IsNot Nothing Then
               If Regex.IsMatch(MyBase.Error.Message, "408") Then         ' Time out
                  status = DownloadError.Recoverable
               ElseIf Regex.IsMatch(MyBase.Error.Message, "407") Then         ' Bad proxy
                  status = DownloadError.Recoverable
               ElseIf Regex.IsMatch(MyBase.Error.Message, "could not be resolved") Then
                  status = DownloadError.NoConnection
               Else
                  status = DownloadError.NonRecoverable
               End If
            Else
               status = DownloadError.NoError
            End If
            Return status
         End Get
      End Property
   End Class

   Public Class MyDownloadStringCompletedEventArgs
      Inherits AsyncCompletedEventArgs

      Public ReadOnly Property ErrorStatus() As DownloadError
         Get
            Dim status As DownloadError
            If MyBase.Error IsNot Nothing Then
               If Regex.IsMatch(MyBase.Error.Message, "408") Then         ' Time out
                  status = DownloadError.Recoverable
               ElseIf Regex.IsMatch(MyBase.Error.Message, "407") Then         ' Bad proxy
                  status = DownloadError.Recoverable
               ElseIf Regex.IsMatch(MyBase.Error.Message, "could not be resolved") Then
                  status = DownloadError.NoConnection
               Else
                  status = DownloadError.NonRecoverable
               End If
            Else
               status = DownloadError.NoError
            End If
            Return status
         End Get
      End Property

      Public Sub New(ByVal err As Exception, ByVal Cancelled As Boolean, ByVal WebResponse As WebResponse, ByVal Elapsed As TimeSpan, ByVal Result As String, ByVal state As Object)
         MyBase.New(err, Cancelled, state)
         Me._Elapsed = Elapsed
         Me._Result = Result
         Me._WebResponse = WebResponse
      End Sub

      Private _Result As String
      Public ReadOnly Property Result() As String
         Get
            Return _Result
         End Get
      End Property

      Private _Elapsed As TimeSpan
      Public ReadOnly Property Elapsed() As TimeSpan
         Get
            Return _Elapsed
         End Get
      End Property

      Private _WebResponse As HttpWebResponse
      Public ReadOnly Property WebResponse() As HttpWebResponse       ' Hold web response information
         Get
            Return _WebResponse
         End Get
      End Property
   End Class
End Class
