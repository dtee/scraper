Public Class Cron
   Private _CronRow As ScraperDB.CronRow
   Private _DT As New ScraperDB.CronDataTable

   Public ReadOnly Property CronRow() As ScraperDB.CronRow
      Get
         Return Me._CronRow
      End Get
   End Property

   Public Property CronName() As String
      Get
         Return Me._CronRow.CronName
      End Get
      Set(ByVal value As String)
         Me._CronRow.CronName = value
      End Set
   End Property

   Public Property Duration() As Integer
      Get
         Return Me._CronRow.Duration
      End Get
      Set(ByVal value As Integer)
         Me._CronRow.Duration = value
      End Set
   End Property


   Public Sub New()
      Me._CronRow = Me._DT.NewCronRow
      Me._DT.AddCronRow(Me._CronRow)

      Me._CronRow.Minute = "*"
      Me._CronRow.Hour = "*"
      Me._CronRow.DateOfMonth = "*"
      Me._CronRow.DayOfWeek = "*"
      Me._CronRow.Month = "*"
   End Sub

   Public Sub New(ByVal cronRow As ScraperDB.CronRow)
      Me._CronRow = cronRow
   End Sub

   Public Property Hour() As String
      Get
         Return Me._CronRow.Hour
      End Get
      Set(ByVal value As String)
         Dim reason As String = Me.checkString(value, 0, 23)
         If reason = "" Then
            Me._CronRow.Hour = value
         Else
            Throw New Exception(reason)
         End If
      End Set
   End Property

   Public Property Minute() As String
      Get
         Return Me._CronRow.Minute
      End Get
      Set(ByVal value As String)
         Dim reason As String = Me.checkString(value, 0, 59)
         If reason = "" Then
            Me._CronRow.Minute = value
         Else
            Throw New Exception(reason)
         End If
      End Set
   End Property

   Public Property [DateOfMonth]() As String
      Get
         Return Me._CronRow.DateOfMonth
      End Get
      Set(ByVal value As String)
         Dim reason As String = Me.checkString(value, 1, 31)
         If reason = "" Then
            Me._CronRow.DateOfMonth = value
         Else
            Throw New Exception(reason)
         End If
      End Set
   End Property

   Public Property Month() As String
      Get
         Return Me._CronRow.Month
      End Get
      Set(ByVal value As String)
         Dim reason As String = Me.checkString(value, 1, 12)
         If reason = "" Then
            Me._CronRow.Month = value
         Else
            Throw New Exception(reason)
         End If
      End Set
   End Property

   Public Property DayOfWeek() As String
      Get
         Return Me._CronRow.DayOfWeek
      End Get
      Set(ByVal value As String)
         Dim reason As String = Me.checkString(value, 0, 6)
         If reason = "" Then
            Me._CronRow.DayOfWeek = value
         Else
            Throw New Exception(reason)
         End If
      End Set
   End Property

   Public ReadOnly Property NextStartTime() As Date
      Get
         Return getNextStartTime(Now)
      End Get
   End Property

   Private Function initArray(ByVal min As Integer, ByVal max As Integer) As Integer()
      Dim arr As Integer()
      If min = 0 Then
      Else
      End If

      ReDim arr(max - min)

      Dim j As Integer = 0
      For i As Integer = min To max
         arr(j) = i
         j += 1
      Next

      Return arr
   End Function

   Private Class CronDate
      Public isValid As Boolean = True
      Public nextDate As Date

      Public Sub New(ByVal nextDate As Date, ByVal isValid As Boolean)
         Me.isValid = isValid
         Me.nextDate = nextDate
      End Sub
   End Class

   Private Function getNextCron(ByVal startTime As Date) As CronDate
      Dim minuteArray() As Integer = getNumbers(Me.Minute)
      Dim hourArray() As Integer = getNumbers(Me.Hour)
      Dim dayArray() As Integer = getNumbers(Me.DateOfMonth)
      Dim monthArray() As Integer = getNumbers(Me.Month)
      Dim ErrorCount As Integer = 0

      Dim DayOfWeekArray() As Integer = getNumbers(Me.DayOfWeek)

      If DayOfWeekArray Is Nothing Then
         DayOfWeekArray = initArray(0, 6)
      End If

      If minuteArray Is Nothing Then
         minuteArray = initArray(0, 59)
      End If

      If hourArray Is Nothing Then
         hourArray = initArray(0, 23)
      End If

      If dayArray Is Nothing Then
         dayArray = initArray(1, 31)
      End If

      If monthArray Is Nothing Then
         monthArray = initArray(1, 12)
      End If

      Dim minute As Integer = getNextNumber(startTime.Minute, minuteArray)
      Dim hour As Integer = getNextNumber(startTime.Hour - 1, hourArray)
      Dim day As Integer = getNextNumber(startTime.Day - 1, dayArray)
      Dim month As Integer = getNextNumber(startTime.Month - 1, monthArray)
      Dim year As Integer = startTime.Year

      Dim nextDate As Date

      nextDate = getTempDate(year, month, day, hour, minute).nextDate
      If (nextDate <= startTime) Then
         ' Get a new hour
         minute = minuteArray(0)
         hour = getNextNumber(hour, hourArray)
      End If

      nextDate = getTempDate(year, month, day, hour, minute).nextDate
      If (nextDate <= startTime) Then
         ' Get a new hour
         minute = minuteArray(0)
         hour = hourArray(0)

         day = getNextNumber(day, dayArray)
      End If

      nextDate = getTempDate(year, month, day, hour, minute).nextDate
      If (nextDate <= startTime) Then
         ' Get a new hour
         minute = minuteArray(0)
         hour = hourArray(0)
         day = dayArray(0)
         month = getNextNumber(month, monthArray)
      End If

      nextDate = getTempDate(year, month, day, hour, minute).nextDate
      If (nextDate <= startTime) Then
         ' Get a new hour
         minute = minuteArray(0)
         hour = hourArray(0)
         day = dayArray(0)
         month = monthArray(0)
         year += 1
      End If

      Return getTempDate(year, month, day, hour, minute)
   End Function


   Private Function getTempDate(ByVal year As Integer, ByVal month As Integer, ByVal day As Integer, _
      ByVal hour As Integer, ByVal minute As Integer) As CronDate

      Dim nextDate As Date, isValid As Boolean = True

      Try
         nextDate = New Date(year, month, day, hour, minute, 0)
         isValid = True
      Catch ex As Exception   ' Invalid Day
         month += 1        ' Move to next month

         If month > 12 Then
            month = 1
            year += 1
         End If

         nextDate = New Date(year, month, 1, 0, 0, 0)
         isValid = False
      End Try

      Return New CronDate(nextDate, isValid)
   End Function

   Private Function getNextCronDate(ByVal startTime As Date) As Date
      Dim cronDate As CronDate = getNextCron(startTime)

      Dim i As Integer = 0
      While (Not cronDate.isValid And i < Byte.MaxValue)
         cronDate = getNextCron(cronDate.nextDate)
         i += 1
      End While

      If cronDate.isValid Then
         Return cronDate.nextDate
      Else
         Throw New Exception(String.Format("Could not find the next date after {0} tries.", Byte.MaxValue))
      End If
   End Function

   Public Function getNextStartTime(ByVal startTime As Date) As Date
      Dim nextDate As Date = getNextCronDate(startTime)

      Dim DayOfWeekArray() As Integer = getNumbers(Me.DayOfWeek)

      If DayOfWeekArray Is Nothing Then
         DayOfWeekArray = initArray(0, 6)
      End If

      For i As Integer = 0 To Byte.MaxValue
         For Each d As Integer In DayOfWeekArray
            If nextDate.DayOfWeek = d Then
               Return nextDate
            End If
         Next

         nextDate.AddDays(1)
         nextDate = getNextCronDate(nextDate)
      Next

      Throw New Exception(String.Format("Could not find the next date after {0} tries.", Byte.MaxValue))
   End Function

   Private Function isAll(ByVal str As String) As Boolean
      Return str.Length = 1 AndAlso str(0) = "*"
   End Function

   Private Function getNextNumber(ByVal num As Integer, ByVal nums() As Integer) As Integer
      If nums Is Nothing Then Return num

      Array.Sort(nums)

      For Each m As Integer In nums
         If m > num Then
            Return m
         End If
      Next

      Return nums(0)
   End Function

   ''' <summary>
   ''' Assume the string is a vlid string and not isAll string. 
   ''' Assumines the string contains numbers in the following format:
   ''' "0,1,2...."
   ''' </summary>
   ''' <param name="str"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function getNumbers(ByVal str As String) As Integer()
      If isAll(str) Then
         Return Nothing
      End If

      ' Schedule in range
      Dim numbers() As String
      If str.Contains("-") Then
         numbers = str.Split("-")
         Dim startNum As Integer = Integer.Parse(numbers(0))
         Dim stopNum As Integer = Integer.Parse(numbers(1))

         Return initArray(startNum, stopNum)
      Else
         numbers = str.Split(",")
         Dim num() As Integer
         ReDim num(numbers.Length - 1)

         Dim i As Integer = 0
         For Each strNum As String In numbers
            num(i) = Integer.Parse(strNum)
            i += 1
         Next

         Return num
      End If
   End Function

   ''' <summary>
   ''' Take a string and see if it is a valid string or not:
   ''' Valid String: "0,1,2...max", or "*"
   ''' </summary>
   ''' <param name="str"></param>
   ''' <param name="max"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function checkString(ByVal str As String, ByVal min As Integer, ByVal max As Integer) As String
      Dim sb As New System.Text.StringBuilder
      If str.Length = 1 And str = "*" Then
         Return ""
      End If

      Dim numbers As String()
      If str.Contains("-") Then
         numbers = str.Split("-")
         Dim startNum As Integer
         Dim stopNum As Integer

         Try
            startNum = Integer.Parse(numbers(0))
         Catch ex As Exception
            sb.AppendLine(String.Format("{0} is not a valid number.", numbers(0)))
         End Try

         Try
            stopNum = Integer.Parse(numbers(1))
         Catch ex As Exception
            sb.AppendLine(String.Format("{0} is not a valid number.", numbers(1)))
         End Try

         If stopNum < startNum Then
            sb.AppendLine(String.Format("For range, {0} must be less than or equal to {1}.", stopNum, startNum))
         End If
      Else
         numbers = str.Split(",")
         For Each strNum As String In numbers
            Try
               Dim num As Integer = Integer.Parse(strNum)
               If num > max Then
                  sb.AppendLine(String.Format("{0} must be <= {1}.", num, max))
               End If

               If num < min Then
                  sb.AppendLine(String.Format("{0} must be >= {1}.", num, min))
               End If
            Catch ex As Exception
               sb.AppendLine(strNum & " is not a valid number.")
            End Try
         Next
      End If
      Return sb.ToString
   End Function

End Class
