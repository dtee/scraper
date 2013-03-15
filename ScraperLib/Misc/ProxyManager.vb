''' <summary>
''' This project requries all the proxy to be checked before engaging in scraping using proxy
''' </summary>
''' <remarks></remarks>
Public Class ProxyManager
   Private checkDV As DataView
   Private dv As DataView
   Private _ProxyDT As ScraperDB.ProxyDataTable
   Private _CrawlProject As CrawlProject

   ''' <summary>
   ''' Check proxy given a url and the content to check
   ''' </summary>
   ''' <param name="url"></param>
   ''' <param name="checkContent"></param>
   ''' <remarks></remarks>s
   Public Sub CheckProxies(ByVal url As String, ByVal checkContent As String)

   End Sub

   Public Property ProxyDT() As ScraperDB.ProxyDataTable
      Get
         Return _ProxyDT
      End Get
      Set(ByVal value As ScraperDB.ProxyDataTable)
         _ProxyDT = value
         Me._ProxyStatusDT = Me._CrawlProject.Dataset.ProxyStatus

         If value IsNot Nothing Then
            Me.dv = New DataView(Me._ProxyDT)
            Me.dv.RowFilter = "ProxyStatusID = " & ProxyManager.ProxyStatus.Ready

            Me.checkDV = New DataView(Me._ProxyDT)
            Me.checkDV.RowFilter = "ProxyStatusID = " & ProxyManager.ProxyStatus.Unknown
         End If
      End Set
   End Property

   Public Sub New(ByVal ProxyDT As ScraperDB.ProxyDataTable)
      Me.ProxyDT = ProxyDT
   End Sub

   Private Sub initProxyDT()
      If _ProxyStatusDT.Count = 0 Then
         Dim r As ScraperDB.ProxyStatusRow

         r = _ProxyStatusDT.NewProxyStatusRow
         r.ProxyStatusID = 0
         r.StatusName = "Ready"
         r.StatusDescription = ""
         _ProxyStatusDT.Rows.Add(r)

         r = _ProxyStatusDT.NewProxyStatusRow
         r.ProxyStatusID = 1
         r.StatusName = "Checking"
         r.StatusDescription = ""
         _ProxyStatusDT.Rows.Add(r)
         r = _ProxyStatusDT.NewProxyStatusRow

         r.ProxyStatusID = 2
         r.StatusName = "Unknown"
         r.StatusDescription = ""
         _ProxyStatusDT.Rows.Add(r)

         r = _ProxyStatusDT.NewProxyStatusRow
         r.ProxyStatusID = 3
         r.StatusName = "Error"
         r.StatusDescription = ""
         _ProxyStatusDT.Rows.Add(r)
      End If
   End Sub

   Public Sub New(ByVal CrawlProject As CrawlProject)
      Me._CrawlProject = CrawlProject
      Me.ProxyDT = Me._CrawlProject.Dataset.Proxy
      Me._ProxyStatusDT = Me._CrawlProject.Dataset.ProxyStatus
      initProxyDT()

      If Me._ProxyDT.Rows.Count = 0 Then
         ' Add default proxy

         Dim row As ScraperDB.ProxyRow = Me.AddProxy("localhost", 80)
         row.ProxyStatusID = ProxyStatus.Ready        ' Set local proxy to ready
      End If
   End Sub

   ''' <summary>
   ''' Total Proxly in the DT
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property TotalProxy() As Integer
      Get
         Return Me._ProxyDT.Rows.Count
      End Get
   End Property

   ''' <summary>
   ''' Remove all the non working proxy from the proxy list
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub RemoveErrorProxy()
      Dim ErrDV As New DataView(Me.ProxyDT)
      ErrDV.RowFilter = "ProxyStatusID = " & ProxyManager.ProxyStatus.Error

      While ErrDV.Count > 0
         ErrDV.Item(0).Row.Delete()
      End While
   End Sub

   ''' <summary>
   ''' Add a new proxy
   ''' </summary>
   ''' <param name="Proxy"></param>
   ''' <param name="port"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function AddProxy(ByVal Proxy As String, ByVal port As Integer) As ScraperDB.ProxyRow
      Try
         Dim r As ScraperDB.ProxyRow = Me._ProxyDT.NewProxyRow

         r.ProxyLink = Proxy
         r.ProxyPort = port
         r.ProxyStatusID = ProxyManager.ProxyStatus.Unknown

         Me._ProxyDT.AddProxyRow(r)
         Return r
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         Return Nothing
      End Try
   End Function

   ''' <summary>
   ''' Return the next proxy need checking
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ProxyToCheck() As ScraperDB.ProxyRow
      Get
         If checkDV.Count > 0 Then
            ProxyToCheck = checkDV.Item(0).Row
            ProxyToCheck.ProxyStatusID = ProxyManager.ProxyStatus.Checking
            Return ProxyToCheck
         End If
         Return Nothing
      End Get
   End Property

   ''' <summary>
   ''' Total Proxy left to check
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ProxyToCheckCount() As Integer
      Get
         Return checkDV.Count
      End Get
   End Property

   ''' <summary>
   ''' Return nothing if non of the proxies are checked.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ProxyToUse() As ScraperDB.ProjectRow
      Get
         If dv.Count > 0 Then
            Return dv.Item(0).Row
         End If
         Return Nothing
      End Get
   End Property

   ''' <summary>
   ''' Total proxy ready to use
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property ProxyToUseCount() As Integer
      Get
         Return dv.Count
      End Get
   End Property

   Public Sub ResetAllProxyStatus()
      For Each r As ScraperDB.ProxyRow In Me._ProxyDT.Rows
         r.ProxyStatusID = ProxyManager.ProxyStatus.Unknown
      Next
   End Sub

   Public Enum ProxyStatus
      Ready = 0               ' Proxy ready to be used
      Checking = 1            ' Proxy currently checking
      Unknown = 2             ' Newly added/unknown proxy
      [Error] = 3             ' Error proxy, not anonymous, no response, etc.
   End Enum

   Public _ProxyStatusDT As ScraperDB.ProxyStatusDataTable
   Public ReadOnly Property ProxyStatusDT() As ScraperDB.ProxyStatusDataTable
      Get
         Return _ProxyStatusDT
      End Get
   End Property
End Class
