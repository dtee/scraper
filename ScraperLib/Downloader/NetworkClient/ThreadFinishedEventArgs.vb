Imports System.ComponentModel
Imports System.Threading
Imports System.Net
Imports System.Text.RegularExpressions

Namespace NetworkClient
   Public Class ThreadFinishedEventArgs
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
End Namespace
