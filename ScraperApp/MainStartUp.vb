Public Class MainStartUp
   Public Shared Sub main()
      Try
         Dim mainfrm As New Main()
         If My.Application.CommandLineArgs.Count > 0 Then
            MsgBox(My.Application.CommandLineArgs(0))
            mainfrm.OpenProjectFile(My.Application.CommandLineArgs(0))
         End If

         mainfrm.ShowDialog()
      Catch ex As Exception
         MsgBox("Unknown Error, exiting project. Log is saved into log.txt in project directory.")
         Dim ErrorFile As String = "Error.log"
         Dim f As New IO.FileInfo(ErrorFile)

         Dim w As IO.StreamWriter = (f.AppendText)
         w.WriteLine("Error on " & Now)
         w.WriteLine(ex.Message)
         w.WriteLine(ex.StackTrace)
         w.WriteLine("=======================================================")
         w.WriteLine()
      End Try
   End Sub
End Class
