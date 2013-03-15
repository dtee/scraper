Public Class ProjectInfoControl
   Private _ProjectRow As ScraperDB.ProjectRow

   Public Property ProjectRow() As ScraperDB.ProjectRow
      Get
         Return _ProjectRow
      End Get
      Set(ByVal value As ScraperDB.ProjectRow)
         Me._ProjectRow = value

         If value IsNot Nothing Then
            Me.ThreadsNumericUpDown.Value = _ProjectRow.Threads
            Me.IsSaveContentCheckBox.Checked = _ProjectRow.IsSaveContent
            Me.DownloadDelayNumericUpDown.Value = _ProjectRow.DownloadDelay

            Dim t As New TimeSpan(0, 0, _ProjectRow.ScrapeInterval, 0)
            Me.IntervalDay.Value = t.Days
            Me.IntervalHour.Value = t.Hours
            Me.IntervalMinute.Value = t.Minutes

            Me.ConnectionsNumericUpDown.Value = _ProjectRow.ConnectionPerIP
            Me.ProjectNameTextBox.Text = _ProjectRow.Name

            Me.lblLastRun.Text = Me._ProjectRow.DateRun
         End If
      End Set
   End Property

   Private _Elapsed As New TimeSpan()

   ''' <summary>
   ''' Return total time Elasped since timer.Start is called.
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Public ReadOnly Property Elasped() As TimeSpan
      Get
         Return _Elapsed
      End Get
   End Property

   Public Property TotalThreads() As Integer
      Get
         Return Me.ThreadsNumericUpDown.Value
      End Get
      Set(ByVal value As Integer)
         If value <= Me.ThreadsNumericUpDown.Maximum Or value >= Me.ThreadsNumericUpDown.Minimum Then
            Me.ThreadsNumericUpDown.Value = value
         End If
      End Set
   End Property

#Region "Properties"
   Public WriteOnly Property TotalDownloadedSize() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalDownloadedSize.Text = Me.CalculateSize(value)
      End Set
   End Property

   ''' <summary>
   ''' Average speed TotalDownloadedSize over Elapsed
   ''' </summary>
   ''' <value>Bytest per secod - in bytes</value>
   ''' <remarks></remarks>
   Public WriteOnly Property AverageSpeed() As Integer
      Set(ByVal value As Integer)
         Me.lblAverageSpeed.Text = Me.CalculateSize(value) & "/s"
      End Set
   End Property

   ''' <summary>
   ''' Change Byte to text in b/kb/mb/gb
   ''' </summary>
   ''' <param name="bytes"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function CalculateSize(ByVal bytes As Double) As String
      Dim strSize As String = String.Format("{0} B", bytes.ToString("N"))

      If (bytes > 1024) Then
         bytes /= 1024
         strSize = String.Format("{0} KB", bytes.ToString("N"))
      End If

      If (bytes > 1024) Then
         bytes /= 1024
         strSize = String.Format("{0} MB", bytes.ToString("N"))
      End If

      If (bytes > 1024) Then
         bytes /= 1024
         strSize = String.Format("{0} GB", bytes.ToString("N"))
      End If

      Return strSize
   End Function

   ''' <summary>
   ''' Total Urls left to scrape
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Public WriteOnly Property TotalLeft() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalLeft.Text = value
         Me.TotalFinished = Me.ProjectProgressBar.Maximum - value
      End Set
   End Property

   ''' <summary>
   ''' Total Finished is TotalUrl - TotalLeft
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Private WriteOnly Property TotalFinished() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalFinished.Text = value
         If (value <= Me.ProjectProgressBar.Maximum) Then
            Me.ProjectProgressBar.Value = value
         End If
      End Set
   End Property

   ''' <summary>
   ''' Total Url
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Public WriteOnly Property TotalUrl() As Integer
      Set(ByVal value As Integer)
         Me.lblTotalUrl.Text = value.ToString
         Me.ProjectProgressBar.Maximum = value
      End Set
   End Property

   ''' <summary>
   ''' Set the connection Status
   ''' </summary>
   ''' <value></value>
   ''' <remarks></remarks>
   Public WriteOnly Property Status() As ProjectStatus
      Set(ByVal value As ProjectStatus)
         Me.lblStatus.Text = value
      End Set
   End Property
#End Region

   ''' <summary>
   ''' Update Time Elapsed
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   ''' <remarks></remarks>
   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Me._Elapsed.Add(New TimeSpan(Timer1.Interval))
      Me._Elapsed = New TimeSpan(10000 * (System.Environment.TickCount - starttime))

      Me.lblTimeElasped.Text = String.Format("{0}:{1}:{2}", Me._Elapsed.Hours, Me._Elapsed.Minutes, Me._Elapsed.Seconds)
   End Sub

   Private starttime As Integer
   ''' <summary>
   ''' Start the timer, have the option of restarting it.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub StartTimer()
      starttime = System.Environment.TickCount
      Me.Timer1.Start()
   End Sub

   Public Sub StopTimer()
      Me.Timer1.Stop()
   End Sub

   Enum ProjectStatus
      Ready
      Scraping
      NoConnection
   End Enum

   Public Event ProjectValueChanged()

   Private Sub OnValueChanged()
      ' Save data
      If Me.ProjectRow IsNot Nothing Then
         Me.Save()

         ' Calculate next date to run
         Me.lblNextRun.Text = Me._ProjectRow.DateRun.AddMinutes(Me._ProjectRow.ScrapeInterval)
      End If

      RaiseEvent ProjectValueChanged()
   End Sub

   Public Sub Save()
      Dim t As New TimeSpan(Me.IntervalDay.Value, Me.IntervalHour.Value, Me.IntervalMinute.Value, 0)

      ' Setting
      Me._ProjectRow.Name = Me.ProjectNameTextBox.Text
      Me._ProjectRow.DownloadDelay = Me.DownloadDelayNumericUpDown.Value
      Me._ProjectRow.Threads = Me.ThreadsNumericUpDown.Value
      Me._ProjectRow.ConnectionPerIP = Me.ConnectionsNumericUpDown.Value
      Me._ProjectRow.IsSaveContent = Me.IsSaveContentCheckBox.Checked

      ' Schedule
      Me._ProjectRow.ScrapeInterval = t.TotalMinutes
   End Sub

#Region "Value Changed"
   Private Sub IntervalDay_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntervalDay.ValueChanged
      Me.OnValueChanged()
   End Sub

   Private Sub IntervalHour_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntervalHour.ValueChanged
      Me.OnValueChanged()
   End Sub

   Private Sub IntervalMinute_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntervalMinute.ValueChanged
      Me.OnValueChanged()
   End Sub

   Private Sub ProjectNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectNameTextBox.TextChanged
      Me.OnValueChanged()
   End Sub

   Private Sub ThreadsNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThreadsNumericUpDown.ValueChanged
      Me.OnValueChanged()
   End Sub

   Private Sub DownloadDelayNumericUpDown_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadDelayNumericUpDown.ValueChanged
      Me.OnValueChanged()
   End Sub

   Private Sub ConnectionsNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectionsNumericUpDown.ValueChanged
      Me.OnValueChanged()
   End Sub

   Private Sub IsSaveContentCheckBox_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsSaveContentCheckBox.CheckedChanged
      Me.OnValueChanged()
   End Sub
#End Region


   Private Sub SettingGroupBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingGroupBox.Enter

   End Sub
End Class
