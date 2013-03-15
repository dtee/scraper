Imports System.Net
Imports System.ComponentModel

Namespace NetworkClient
   Public Class NetWorkClientDownloadInfo
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
End Namespace