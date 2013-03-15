Imports System.Data.OleDb
Imports System.Configuration

Public Class SQLDatabaseScraperAdapter
   Inherits ScraperDataAdapter

   Public MaxURL As Integer = -1

   Public _ProjectID As Integer         ' Set up the project ID for scraper to load from
   Public Property ProjectID() As Integer
      Get
         If Me.Project IsNot Nothing Then
            _ProjectID = Me.Project.ProjectID
         End If
         Return _ProjectID
      End Get
      Set(ByVal value As Integer)
         Me._ProjectID = value
      End Set
   End Property

   Private ProjectDataAdapter As MyScraperDBTableAdapters.ProjectTableAdapter
   Private UrlDataAdapter As MyScraperDBTableAdapters.UrlTableAdapter
   Private TagLibraryDataAdapter As MyScraperDBTableAdapters.TagLibraryTableAdapter

   Public Sub New(ByVal conn As SqlClient.SqlConnection)
      Me._SqlConnection = conn

      ProjectDataAdapter = New MyScraperDBTableAdapters.ProjectTableAdapter
      UrlDataAdapter = New MyScraperDBTableAdapters.UrlTableAdapter
      TagLibraryDataAdapter = New MyScraperDBTableAdapters.TagLibraryTableAdapter

      TagLibraryDataAdapter.Connection = conn
      UrlDataAdapter.Connection = conn
      ProjectDataAdapter.Connection = conn

      ProjectDataAdapter.ClearBeforeFill = True
      UrlDataAdapter.ClearBeforeFill = True
      TagLibraryDataAdapter.ClearBeforeFill = True
   End Sub

   Private _SqlConnection As System.Data.SqlClient.SqlConnection
   ''' <summary>
   ''' A new connection to a differnt sql server. We should use oledb for generic DB
   ''' connection.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property SqlConnection() As System.Data.SqlClient.SqlConnection
      Get
         Return Me._SqlConnection
      End Get
      Set(ByVal value As System.Data.SqlClient.SqlConnection)
         _SqlConnection = value

         Me.ProjectDataAdapter.Connection = value
         Me.UrlDataAdapter.Connection = value
         Me.TagLibraryDataAdapter.Connection = value
      End Set
   End Property

   Public Overrides Sub LoadAllUrl()
      Me.UrlDataAdapter.Fill(Me.ProjectDS.Url, Me.Project.ProjectID)
   End Sub

#Region "Project Load/Update"
   Public Overrides Sub LoadProject()
      Try
         Project = Nothing
         ProjectDS = New ScraperDB

         ' Load Tag library first
         Me.ProjectDS.EnforceConstraints = False
         ' Load Project, Url and TagTree Information
         Me.ProjectDataAdapter.Fill(Me.ProjectDS.Project, Me.ProjectID)

         ' Turn off constraints becuase there's no order in how tag rows are loaded.
         Me.TagLibraryDataAdapter.Fill(Me.ProjectDS.TagLibrary, Me.ProjectID)
         Me.ProjectDS.EnforceConstraints = True

         Me.UrlDataAdapter.Fill(Me.ProjectDS.Url, Me.ProjectID)

         Me.Project = New Project(ProjectDS, ProjectDS.Project.Rows(0))
      Catch ex As Exception
         MyBase.Exception = ex
         MyBase.ErrorMessage = ex.Message
      End Try
   End Sub

   ''' <summary>
   ''' Save the current project as a new project. This assumes the project name is unique in db
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub SaveProject()
      Try
         Me.ProjectDS = Me.Project.DataSet
         'Me.ProjectDataAdapter.Update(Me.ProjectDS.Project.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
         Me.ProjectDataAdapter.Update(Me.ProjectDS.Project.Select(Nothing, Nothing, DataViewRowState.Added))

         ' Update URL
         For Each r As ScraperDB.TagLibraryRow In Me.ProjectDS.TagLibrary.Rows
            Console.WriteLine("Old ID: {0} - {1}", r.ProjectID, r.RowState)
         Next

         Me.UrlDataAdapter.Update(Me.ProjectDS.Url)
         UpdateTagLib(Me.Project.TagTreeView.RootNode)
      Catch ex As Exception
         Console.WriteLine("Error" & ex.Message)
      End Try
   End Sub

   ''' <summary>
   ''' Recursive TagLibrary update, this is needed because there's no way for update() to know which
   ''' row is parent and child, thus, the update() usually update incorrectly!
   ''' </summary>
   ''' <param name="node"></param>
   ''' <remarks></remarks>
   Public Sub UpdateTagLib(ByVal node As TagNode)
      Dim r As ScraperDB.TagLibraryRow = node.Row

      'node.Row.SetAdded()
      Me.TagLibraryDataAdapter.Update(node.Row)

      For Each n As TagNode In node.Nodes
         UpdateTagLib(n)
      Next
   End Sub

   ''' <summary>
   ''' Load URL
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub LoadUrl()
      ' We don't have a function for loadUrl currently
      If MaxURL < 0 Then
         Me.UrlDataAdapter.Fill(Me.ProjectDS.Url, Me.Project.ProjectID)
      Else
         Me.UrlDataAdapter.Fill(Me.ProjectDS.Url, Me.Project.ProjectID)
      End If
   End Sub

   ''' <summary>
   ''' Save URL
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub SaveUrl()
      Me.UrlDataAdapter.Update(Me.ProjectDS.Url)
   End Sub
#End Region

#Region "Scraped Data to be saved"
   Public Overrides Sub SaveData()
   End Sub

   Public Overrides Sub LoadData()
      ' Data adaptor is differnt, this should problaby be somewhere else
   End Sub

   ''' <summary>
   ''' Create Data table on the server: This is needed for UpdateData or 
   ''' installing project on the web server.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub CreateDataTable()

   End Sub

   ''' <summary>
   ''' Get data table information that ScrapedDT can use
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub CheckDataTable()
   End Sub

   Public Function createTable(ByVal dt As DataTable) As Boolean
      Try
         Dim strSQL As String = Me.CreateMSSQLTable(dt)

         Dim cmd As SqlClient.SqlCommand = Me._SqlConnection.CreateCommand
         cmd.CommandText = strSQL
         cmd.CommandType = CommandType.Text

         cmd.ExecuteNonQuery()

         Return True
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Return False
      End Try
   End Function

   Private Function CreateMSSQLTable(ByVal dt As DataTable) As String
      Dim sqlString As String = "Create Table " & dt.TableName & " ("
      Dim index As Integer = 0
      Dim dataType As String, nullType As String

      For Each col As DataColumn In dt.Columns
         dataType = col.DataType.Name

         If (index > 0) Then
            sqlString += ", "
         End If
         index += 1
         sqlString &= ControlChars.NewLine & ControlChars.Tab & ControlChars.Tab

         Select Case dataType
            Case "TimeSpan"
               dataType = "DateTime"
            Case "Boolean"
               dataType = "Bit"
            Case "String"
               dataType = "text"
            Case Else
               If (System.Text.RegularExpressions.Regex.IsMatch(dataType, "Int")) Then
                  dataType = "int"
               End If
         End Select


         nullType = "NOT NULL"
         If (col.AllowDBNull) Then
            nullType = "NULL"
         End If

         If col.Unique Then
            sqlString &= "[" & col.ColumnName & "] " & dataType
            sqlString &= String.Format(" IDENTITY({0},{1}) PRIMARY KEY", col.AutoIncrementSeed, col.AutoIncrementStep)
         Else
            sqlString &= "[" & col.ColumnName & "] " & dataType & " " & nullType
         End If
      Next

      sqlString &= ControlChars.NewLine & ")"

      Return sqlString
   End Function

   Public Function dropTable(ByVal dt As DataTable) As Boolean
      Try
         Dim strSQL As String = "DROP TABLE " & dt.TableName

         Dim cmd As SqlClient.SqlCommand = Me.SqlConnection.CreateCommand
         cmd.CommandText = strSQL
         cmd.CommandType = CommandType.Text

         cmd.ExecuteNonQuery()

         Return True
      Catch ex As Exception
         Return False
      End Try
   End Function

#End Region

   Public Overrides ReadOnly Property ProjectLocation() As Object
      Get

         Return Me.SqlConnection.ConnectionString & " (ProjectID: " & Me.Project.ProjectID & ")"
      End Get
   End Property
End Class