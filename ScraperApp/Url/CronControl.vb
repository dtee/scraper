Public Class CronControl
   Private _CronManager As CronManager
   Public Property CronManger() As CronManager
      Get
         Return _CronManager
      End Get
      Set(ByVal value As CronManager)
         Me._CronManager = value

         ' Bind the data

         If Me.CronManger IsNot Nothing Then
            Me.DataGridView1.DataSource = Me._CronManager.CrawlProject.Dataset.Cron
            Me.Enabled = True
         Else
            Me.Enabled = False
         End If
      End Set
   End Property


   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Me.HourCol.DataPropertyName = "Hour"
      Me.MinuteCol.DataPropertyName = "Minute"
      Me.DayCol.DataPropertyName = "DateOfMonth"
      Me.DayOfWeekCol.DataPropertyName = "DayOfWeek"
      Me.MonthTextBoxColumn.DataPropertyName = "Month"
      Me.DurationCol.DataPropertyName = "Duration"


      ' Add any initialization after the InitializeComponent() call.
      Me.DataGridView1.AutoGenerateColumns = False
   End Sub

   Private Sub AddToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripButton.Click
      Dim newCron As Cron = Me._CronManager.NewCron
      Dim cronEdit As New EditCronUI(newCron)

      If cronEdit.ShowDialog = DialogResult.Yes Then
         ' Do nothig
      End If
   End Sub

   Private Sub EditToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripButton.Click
      If Me.DataGridView1.SelectedRows.Count = 0 Then
         MsgBox("Select a cron to edit.")
         Exit Sub
      End If

      Dim cronRow As ScraperDB.CronRow = CType(Me.DataGridView1.SelectedRows(0).DataBoundItem, DataRowView).Row
      Dim cron As Cron = Me._CronManager.getCron(cronRow)
      Dim cronEdit As New EditCronUI(cron)

      If cronEdit.ShowDialog = DialogResult.Yes Then

      End If
   End Sub

   Private Sub RemoveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveToolStripButton.Click
      Dim removeList As New List(Of Cron)
      For i As Integer = 0 To Me.DataGridView1.SelectedRows.Count - 1
         Dim cronRow As ScraperDB.CronRow = CType(Me.DataGridView1.SelectedRows(0).DataBoundItem, DataRowView).Row
         Dim cron As Cron = Me._CronManager.getCron(cronRow)

         removeList.Add(cron)
      Next


      For Each cron As Cron In removeList
         Me._CronManager.Remove(cron)
      Next
   End Sub
End Class
