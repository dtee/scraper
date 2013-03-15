Imports System.Text.RegularExpressions

''' <summary>
''' Generate URL
''' </summary>
''' <remarks></remarks>
Public Class URLGenerator
   Private patternList As New LinkedList(Of URLGeneratorPattern)

   Private Shared mSingleton As New URLGenerator
   Public Shared ReadOnly Property Singleton() As URLGenerator
      Get
         Return mSingleton
      End Get
   End Property

#Region "Properties"
   Dim _UrlList As UrlManager
   Public Property UrlList() As UrlManager
      Get
         Return _UrlList
      End Get
      Set(ByVal value As UrlManager)
         _UrlList = value
      End Set
   End Property

   Private mURL As String
   Public Property URL() As String
      Get
         Return mURL
      End Get
      Set(ByVal value As String)
         If value IsNot Nothing Then
            Dim ErrorMsg As String
            Dim tempURL As String = Regex.Replace(value, URLGenerator.WrapperPattern, "")

            If Not Uri.IsWellFormedUriString(tempURL, UriKind.Absolute) Then
               ' Add http to url and test again
               tempURL = "http://" & tempURL
            End If

            If Not Uri.IsWellFormedUriString(tempURL, UriKind.Absolute) Then
               ' Add http to url and test again
               ErrorMsg = "Invalid Url Format. It must be in accordance with RFC 2396 and RFC 2732."
               Throw New Exception(ErrorMsg)
            Else
               Dim u As New Uri(tempURL)
               If u.Scheme <> Uri.UriSchemeHttp Then
                  ErrorMsg = "Invalid Url Protocal, it must start with http://."
                  Throw New Exception(ErrorMsg)
               End If
            End If

            If (Not Regex.IsMatch(value, "http://")) Then
               value = "http://" & value
            End If

            Me.mURL = value
            QueuePattern()
         End If
         mURL = value
      End Set
   End Property

   Private mPostData As String
   Public Property PostData() As String
      Get
         Return mPostData
      End Get
      Set(ByVal value As String)
         mPostData = value
      End Set
   End Property

   Private mReferer As String
   Public Property Referer() As String
      Get
         Return mReferer
      End Get
      Set(ByVal value As String)
         mReferer = value
      End Set
   End Property

   Private mProjectID As Integer
   Public Property ProjectID() As Integer
      Get
         Return mProjectID
      End Get
      Set(ByVal value As Integer)
         mProjectID = value
      End Set
   End Property
#End Region

   Private _TotalCount As Integer
   ''' <summary>
   ''' Total Counts of urls to be generated.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalCount() As Integer
      Get
         Return _TotalCount
      End Get
   End Property

   Private _BadRowCount As Integer
   Public ReadOnly Property BadRowCount() As Integer
      Get
         Return _BadRowCount
      End Get
   End Property

   Public Shared WrapperPattern As String = "\$([a-zA-Z]|[\d]+)-([a-zA-Z]|[\d]+)\$"

   Private Sub ResetGlobal()
      Me._BadRowCount = 0
      Me._TotalCount = 1
      Me.patternList.Clear()
   End Sub

   ''' <summary>
   ''' Build a list of pattern to generate the url from.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub QueuePattern()
      ResetGlobal()
      Dim index As Integer = 0
      Dim pa As URLGeneratorPattern = Nothing
      Dim ErrorMsg As String = ""

      Dim mc As MatchCollection = Regex.Matches(mURL, URLGenerator.WrapperPattern)

      For Each m As Match In mc
         pa = New URLGeneratorPattern
         Dim sStart As String = m.Groups(1).Value
         Dim sStop As String = m.Groups(2).Value

         ' make sure genstart and gen stop is right
         If (Char.IsNumber(sStart(0)) And Char.IsNumber(sStart(0))) Then
            ' Convert to number
            pa.isNumber = True
            Try
               pa.numStart = Integer.Parse(sStart)
               pa.numStop = Integer.Parse(sStop)

               For i As Integer = 0 To sStart.Length - 1
                  pa.NumberMask &= "0"
               Next
            Catch ex As Exception
               ErrorMsg = "Error, could not convert the number: " & m.Value
            End Try
         ElseIf (Char.IsLetter(sStart(0)) And Char.IsLetter(sStart(0))) Then
            pa.isNumber = False
            pa.numStart = Asc(sStart(0))
            pa.numStop = Asc(sStop(0))
         Else
            ' Report Error
            ErrorMsg = "Error, format is incorrect, could not convert letter: " & m.Value
         End If

         pa.startingURL = mURL.Substring(index, m.Index - index)
         index = m.Index + m.Length

         Me._TotalCount *= (pa.numStop - pa.numStart + 1)

         If m Is mc.Item(mc.Count - 1) Then
            pa.endingURL = mURL.Substring(index, mURL.Length - index)
         End If

         Me.patternList.AddLast(pa)
      Next

      If ErrorMsg <> "" Then Throw New Exception(ErrorMsg)
   End Sub

   Private _projList As List(Of Project)
   ''' <summary>
   ''' Generate URL, Assming Pattern list have been set.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub GenerateURL(ByVal projList As List(Of Project))
      If Me._UrlList Is Nothing Then
         Return
      End If

      If Me.URL Is Nothing Then
         Return
      End If

      _projList = projList
      DoGenerateUrl()
   End Sub

   Private Sub DoGenerateUrl()
      Dim pa As URLGeneratorPattern = Nothing

      If Me.patternList.Count > 0 Then
         pa = Me.patternList.First.Value
         Me.patternList.RemoveFirst()

         ' Generate the pattern
         generateURLRec("", pa)
      Else
         DoAdd(mURL, _projList)
      End If
   End Sub

   Private Sub DoAdd(ByVal url As String, ByVal projList As List(Of Project))
      Try
         Dim row As ScraperDB.UrlRow = Me.UrlList.addUrl(url, "", projList)
         row.UrlReferer = mReferer
         row.PostData = mPostData
      Catch ex As DataException
         _BadRowCount += 1
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         _BadRowCount += 1
      End Try
   End Sub

   Private Sub generateURLRec(ByRef murl As String, ByRef pa As URLGeneratorPattern)
      Dim nextPattern As URLGeneratorPattern = Nothing
      If (Me.patternList.Count > 0) Then
         nextPattern = Me.patternList.First.Value
         Me.patternList.RemoveFirst()
      End If

      ' Generate
      Dim newURL As String = ""

      ' Reason why this is laid out this way: Speed, less comparison per loop
      If (nextPattern Is Nothing) Then
         ' No more pattern to go throught, finished
         If (pa.isNumber) Then
            For i As Integer = pa.numStart To pa.numStop
               newURL = murl & pa.startingURL & i.ToString(pa.NumberMask) & pa.endingURL
               DoAdd(newURL, _projList)
            Next
         Else
            For i As Integer = pa.numStart To pa.numStop
               newURL = murl & pa.startingURL & Chr(i) & pa.endingURL
               DoAdd(newURL, _projList)
            Next
         End If
      Else
         ' Do recursion call, there's more pattern to go through
         If (pa.isNumber) Then
            For i As Integer = pa.numStart To pa.numStop
               newURL = murl & pa.startingURL & i.ToString(pa.NumberMask) & pa.endingURL
            Next
         Else
            For i As Integer = pa.numStart To pa.numStop
               newURL = murl & pa.startingURL & Chr(i) & pa.endingURL
               generateURLRec(newURL, nextPattern)
            Next
         End If
      End If
   End Sub

   Private Class URLGeneratorPattern
      Public isNumber As Boolean

      Public numStart As Integer
      Public numStop As Integer

      Public startingURL As String
      Public endingURL As String

      Public NumberMask As String
   End Class
End Class