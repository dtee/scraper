Public Class EditCronUI
   Private _Cron As Cron

   Public Sub New(ByVal cron As Cron)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      _Cron = cron
      ' Add any initialization after the InitializeComponent() call.
      init()
   End Sub

   Public Sub init()
      Me.NameTextBox.Text = _Cron.CronName

      Me.MinuteTextBox.Text = _Cron.Minute
      Me.HourTextBox.Text = _Cron.Hour
      Me.DayOfWeekTextBox.Text = _Cron.DayOfWeek
      Me.DayTextBox.Text = Me._Cron.DateOfMonth
      Me.MonthTextBox.Text = Me._Cron.Month

      Me.DurationTextBox.Text = Me._Cron.Duration
   End Sub

   Private Sub DayOfWeekTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayOfWeekTextBox.TextChanged
      Try
         Me._Cron.DayOfWeek = Me.DayOfWeekTextBox.Text
         Me.ErrorProvider1.SetError(Me.DayOfWeekTextBox, "")
         setNextDate()
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.DayOfWeekTextBox, ex.Message)
      End Try
   End Sub

   Private Sub DurationTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DurationTextBox.KeyPress
      'Restirct user to key numeric values, decimal point and control keys
      If Char.IsDigit(e.KeyChar) Then
         e.Handled = False
      Else
         e.Handled = True
      End If
   End Sub

   Private Sub DurationTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DurationTextBox.TextChanged
      Try
         Me._Cron.Duration = Me.DurationTextBox.Text
         Me.ErrorProvider1.SetError(Me.DurationTextBox, "")
         setNextDate()
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.DurationTextBox, ex.Message)
      End Try
   End Sub

   Private Sub MinuteTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinuteTextBox.TextChanged
      Try
         Me._Cron.Minute = Me.MinuteTextBox.Text
         Me.ErrorProvider1.SetError(Me.MinuteTextBox, "")
         setNextDate()
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.MinuteTextBox, ex.Message)
      End Try
   End Sub

   Private Sub HourTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HourTextBox.TextChanged
      Try
         Me._Cron.Hour = Me.HourTextBox.Text
         Me.ErrorProvider1.SetError(Me.HourTextBox, "")
         setNextDate()
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.HourTextBox, ex.Message)
      End Try
   End Sub

   Private Sub DayTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayTextBox.TextChanged
      Try
         Me._Cron.DateOfMonth = Me.DayTextBox.Text
         Me.ErrorProvider1.SetError(Me.DayTextBox, "")
         setNextDate()
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.DayTextBox, ex.Message)
      End Try
   End Sub

   Private Sub MonthTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthTextBox.TextChanged
      Try
         Me._Cron.Month = Me.MonthTextBox.Text
         Me.ErrorProvider1.SetError(Me.MonthTextBox, "")
         setNextDate()
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.MonthTextBox, ex.Message)
      End Try
   End Sub

   Private Sub Test_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Test_Button.Click
      setNextDate()
   End Sub

   Private Sub setNextDate()
      Dim sb As New System.Text.StringBuilder

      Try
         Dim nextDate As Date = Me._Cron.NextStartTime
         sb.AppendLine(nextDate.ToShortDateString & " " & nextDate.ToLongTimeString)

         For i As Integer = 0 To 10
            nextDate = Me._Cron.getNextStartTime(nextDate)
            sb.AppendLine(nextDate.ToShortDateString & " " & nextDate.ToLongTimeString)
         Next

         Me.TextBox1.Text = sb.ToString
      Catch ex As Exception
         Me.TextBox1.Text = ex.Message
      End Try
   End Sub

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
   End Sub

   Private Sub EditCronUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub
End Class