Imports System.ComponentModel
Imports System.Threading
Imports System.Net
Imports System.Text.RegularExpressions

Namespace NetworkClient
   Public Class DownloadStringCompletedEventArgs
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

   Public Enum DownloadError
      NoError = 0                ' No Error! YAY
      Recoverable = 1            ' Suggest keep trying
      NonRecoverable = 2         ' Suggests do not keep trying
      NoConnection = 3           ' Non Connection
   End Enum
End Namespace