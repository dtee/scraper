
Namespace NetworkClient
   Public Class DownloadProgressChangedEventArgs
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
End Namespace

