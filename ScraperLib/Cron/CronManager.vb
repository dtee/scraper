Public Class CronManager
   Private _CrawlProject As CrawlProject
   Private _CronDT As ScraperDB.CronDataTable
   Private _CronList As New List(Of Cron)

   Public ReadOnly Property CrawlProject() As CrawlProject
      Get
         Return Me._CrawlProject
      End Get
   End Property

   Public Sub New(ByVal CrawlProject As CrawlProject)
      Me._CrawlProject = CrawlProject
      _CronDT = Me._CrawlProject.Dataset.Cron

      For Each row As ScraperDB.CronRow In Me._CronDT.Rows
         Me._CronList.Add(New Cron(row))
      Next
   End Sub

   Public Function NewCron() As Cron
      Dim newRow As ScraperDB.CronRow = Me._CronDT.NewRow
      newRow.CrawlProjectID_FK = Me._CrawlProject.CrawlProjectRow.CrawlProjectID
      Me._CronDT.AddCronRow(newRow)

      Dim cron As New Cron(newRow)
      Me._CronList.Add(cron)
      Return Cron
   End Function

   Public Sub Remove(ByVal cron As Cron)
      Me._CronList.Remove(cron)
      cron.CronRow.Delete()
   End Sub

   Public ReadOnly Property CronList() As List(Of Cron)
      Get
         Return Me._CronList
      End Get
   End Property

   Public Function getCron(ByVal cronRow As ScraperDB.CronRow)
      For Each cron As Cron In Me.CronList
         If cronRow Is cron.CronRow Then
            Return cron
         End If
      Next

      Return Nothing
   End Function
End Class
