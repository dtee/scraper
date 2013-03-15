Imports System.Data.OleDb
Imports System.Configuration

Public Class SQLDatabaseScraperAdapter
   Inherits ScraperDataAdapter

   Public Shared _Log As New Log(GetType(SQLDatabaseScraperAdapter), False)
   Public MaxURL As Integer = 200

   Public Sub New(ByVal conn As SqlClient.SqlConnection)
      Me._SqlConnection = conn
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
      End Set
   End Property

   Private _CrawlProjectID As Integer
   Public Property CrawlProjectID() As Integer
      Get
         Return _CrawlProjectID
      End Get
      Set(ByVal value As Integer)
         _CrawlProjectID = value
      End Set
   End Property

   Public Overrides Sub DeleteProject()
      ' Project has not been loaded, load the project
      If Me._Dataset Is Nothing Then
         Me.LoadProject()
      End If

      ' get tables names created by this project
      For Each dt As DataTable In Me._CrawlProject.DataTables

      Next

      ' drop the tables in order

      ' Delete the project row, it should cascade delete other rows
      Me._CrawlProject.CrawlProjectRow.Delete()

      Me.SaveProject()
   End Sub

   Private Sub loadProjectRelatedTable(ByVal dt As DataTable, ByVal projectID As Integer)
      Dim sql As String = "Select * from " & dt.TableName & " where projectid = " & Me.CrawlProjectID
      Dim da As New SqlClient.SqlDataAdapter(sql, Me._SqlConnection)
      Dim com As New SqlClient.SqlCommandBuilder(da)

      da.Fill(dt)
   End Sub

   ' Load top url to url table
   Private Sub loadTopURL()
      Dim da As New SqlClient.SqlDataAdapter()
      Dim c As SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand()
      c.Connection = Me._SqlConnection
      c.CommandText = "dbo.sp_GetTopURL"
      c.CommandType = System.Data.CommandType.StoredProcedure
      c.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, 10, 0, Nothing, System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
      c.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, Nothing, System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
      c.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TopNum", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 10, 0, Nothing, System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))

      da.Fill(Me.CrawlProject.Dataset.Url)
   End Sub

#Region "Project Load/Update"
   ''' <summary>
   ''' Load Crawler Project
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub LoadProject()
      Try
         Dim sql As String = ""
         Me._Dataset = New ScraperDB
         _Dataset.EnforceConstraints = False

         ' Save project data only
         For Each tbl As DataTable In Me._Dataset.Tables
            If tbl Is Me._Dataset.Project_Url Or tbl Is Me._Dataset.Url Or tbl Is Me._Dataset.UrlReferences Then
               ' Do nothing, lets load it when it's trying to load the url
            Else
               sql = DataManagement.SqlExpress.getLoadProjectDataSQL(tbl, Me._CrawlProjectID)
               Dim da As New SqlClient.SqlDataAdapter(sql, Me._SqlConnection)

               da.Fill(tbl)
            End If
         Next

         Me._Dataset.AcceptChanges()

         ' Crawl Project
         Me._CrawlProject = New CrawlProject(Me._Dataset.CrawlProject(0))        ' Project loaded
         Me._CrawlProjectID = Me._CrawlProject.CrawlProjectRow.CrawlProjectID
         _Dataset.EnforceConstraints = True                    ' No errors

         Me.LoadUrl()                                          ' Load Urls
         Me._CrawlProject.ScraperDataAdaptor = Me              ' Set project's adaptor to this.
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         Throw New Exception("Unhandled error in loading project from database: " & ex.Message)
      End Try
   End Sub

   Public IsOverRideProject As Boolean = True

   ''' <summary>
   ''' Create database table for current project (this will also drop existing tables)
   ''' TODO: add project ID behind the table names/Mapping
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub createDataTables()

      Dim sql As String = DataManagement.SqlExpress.getDropCreateLSQL(Me._CrawlProject)
      ' TODO: Load the server time each time this function is called?
      Dim cmd As SqlClient.SqlCommand = Me._SqlConnection.CreateCommand
      cmd.CommandText = sql
      cmd.CommandType = CommandType.Text

      Me._SqlConnection.Open()
      cmd.ExecuteNonQuery()
      Me._SqlConnection.Close()
   End Sub

   ''' <summary>
   ''' Save the current project as a new project. This assumes the project name is unique in db
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub SaveProject()
      If Me.CrawlProject Is Nothing Then Exit Sub

      Dim ProjectDS As ScraperDB = Me.CrawlProject.Dataset
      Me._SqlConnection.Open()

      Dim target As DataManagement.SqlExpress = New DataManagement.SqlExpress
      target.SqlConnection = Me.SqlConnection
      target.trans = Me._SqlConnection.BeginTransaction
      Try
         For Each tbl As DataTable In Me._Dataset.Tables
            ' Check each row for errors
            If tbl.HasErrors Then
               Throw New Exception("Update Failed: " & tbl.TableName & ": Some rows contains error.")
            End If
         Next

         For Each tbl As DataTable In Me._CrawlProject.DataMapper.getDataTablesUpdateOrder(True)
            If (Not DataTableUtil.IsGeneratedTable(tbl)) Then
               If tbl Is Me._Dataset.UrlStatus Then            ' Don't update the status table
               ElseIf tbl Is Me._Dataset.ProxyStatus Then         ' Don't update the status table.
               Else
                  Dim idColList As List(Of DataColumn)
                  idColList = Me._CrawlProject.DataMapper.getIdentityColumns(tbl, False)

                  tbl.AcceptChanges()
                  Dim pkCol As DataColumn = tbl.PrimaryKey(0)

                  ' Do this for all the table, including the url tables.
                  For Each row As DataRow In tbl.Rows
                     'Dim pkID As Integer = target.getRowID(row, idColList)

                     If row(pkCol) >= 0 Then
                        row.SetModified()
                     Else
                        If target.isNewDataRow(row, idColList) Then
                           row.SetAdded()
                        Else
                           row.SetModified()

                           ' Need to fetch the id somehow..
                        End If
                     End If
                  Next

                  idColList = Me._CrawlProject.DataMapper.getIdentityColumns(tbl, False)
                  target.updateData(tbl, idColList)

                  ' Check each row for errors0..0

                  If tbl.HasErrors Then
                     _Log.Debug("Update Table Error: " & tbl.TableName)
                     For Each row As DataRow In tbl.GetErrors
                        _Log.Debug("Row error: " & row.RowError)
                     Next
                     Throw New Exception("Update Failed: " & tbl.TableName & ": Some rows contains error.")
                  End If
               End If
            End If
         Next

         'Commit the transition not that we know all went fine
         Me._CrawlProjectID = Me._CrawlProject.CrawlProjectRow.CrawlProjectID
         target.trans.Commit()
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)

         ' Roll back transaction
         target.trans.Rollback()
         Throw New Exception("Error saving project to database: " & ex.Message)
      Finally
         Me._SqlConnection.Close()
      End Try
   End Sub

   Public _DBServerTime As Date               ' Server Time
   ''' <summary>
   ''' Server Time, this is used to calculate row
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public ReadOnly Property DBServerTime() As Date
      Get
         ' TODO: Load the server time each time this function is called?
         Dim cmd As SqlClient.SqlCommand = Me.SqlConnection.CreateCommand
         cmd.CommandText = "select GETUTCDATE();"
         cmd.CommandType = CommandType.Text

         Me._DBServerTime = cmd.ExecuteScalar()       ' Get the server time.

         Return Me._DBServerTime
      End Get
   End Property

   ''' <summary>
   ''' Load URL - Load top X urls from server (This include both Project_URL and URL tables
   ''' TODO: Need a better way to load the url
   ''' We can't clear url until the data is saved
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub LoadUrl()
      ' Init tables for quick use
      Dim urlDT As ScraperDB.UrlDataTable = Me._Dataset.Url
      Dim projectUrlDt As DataTable = Me._Dataset.Project_Url

      ' Clear the data table before loading
      projectUrlDt.Clear()                ' TODO: does clear accept changes?
      Me._Dataset.UrlReferences.Clear()
      urlDT.Clear()

      ' Sql Express for help w/ updating process
      Dim target As DataManagement.SqlExpress = New DataManagement.SqlExpress
      target.SqlConnection = Me._SqlConnection
      Me._SqlConnection.Open()
      target.trans = Me.SqlConnection.BeginTransaction
      target.trans = target.trans

      Try
         ' Load all the url sql.
         Dim urlSqlString As String = DataManagement.SqlExpress.getLoadProjectDataSQL(urlDT, Me._CrawlProjectID)
         urlSqlString = urlSqlString.Replace("SELECT ", "SELECT TOP " & Me._CrawlProject.CrawlProjectRow.MaxUrl & " ")

         Dim statusFilterSQL As String = String.Format(" AND ([{0}].{1}", urlDT.TableName, urlDT.UrlStatusIDColumn.ColumnName)
         statusFilterSQL = statusFilterSQL & " = " & ScraperLib.UrlManager.UrlStatus.Ready & ";"
         urlSqlString = urlSqlString.Replace(";", statusFilterSQL)

         Dim lastAssignTimeOut As String = " OR ([Url].UrlStatusID = 1 AND dateadd(mi, {0}, lastassigned) < '{1}'));"
         lastAssignTimeOut = String.Format(lastAssignTimeOut, Me._CrawlProject.CrawlProjectRow.AssignTimeOutMinute, Now)
         urlSqlString = urlSqlString.Replace(";", lastAssignTimeOut)

         Dim sortString As String = String.Format(" ORDER BY [{0}].{1} DESC;", urlDT.TableName, urlDT.UrlIDColumn.ColumnName)
         urlSqlString = urlSqlString.Replace(";", sortString)

         Dim projUrlSqlString As String = ""
         Dim modifiedUrlSql As String = urlSqlString.Replace(";", "")
         modifiedUrlSql = modifiedUrlSql.Replace("*", urlDT.UrlIDColumn.ColumnName)
         modifiedUrlSql = String.Format(" AND [{0}].{1} IN (", projectUrlDt.TableName, urlDT.UrlIDColumn.ColumnName) & modifiedUrlSql & ")"

         Dim whereSql As String = String.Format(" AND ([{0}].{1} IN ({2}))", urlDT.TableName, urlDT.UrlIDColumn.ColumnName, urlSqlString)

         projUrlSqlString = DataManagement.SqlExpress.getLoadProjectDataSQL(projectUrlDt, Me._CrawlProjectID)
         projUrlSqlString = projUrlSqlString.Replace(";", modifiedUrlSql)

         _Log.Debug("Url SQ: " & urlSqlString)
         _Log.Debug("Project_Url SQ: " & projUrlSqlString)

         Dim urlDa As New SqlClient.SqlDataAdapter(urlSqlString, Me._SqlConnection)
         urlDa.SelectCommand.Transaction = target.trans

         Dim projUrlDa As New SqlClient.SqlDataAdapter(projUrlSqlString, Me._SqlConnection)
         projUrlDa.SelectCommand.Transaction = target.trans

         urlDa.Fill(urlDT)                      ' Load the url dt
         projUrlDa.Fill(projectUrlDt)           ' Load Project_Url dt

         For Each row As ScraperDB.UrlRow In urlDT.Rows
            row.LastAssigned = Now        ' Set the last assigned date
            row.UrlStatusID = ScraperLib.UrlManager.UrlStatus.Assigned        ' Set assigned
         Next

         ' Before update: url_Dataset table, if it exists
         Dim datasetDT As DataTable = Me._Dataset.Tables(DataTableUtil.URL_DATASET_TABLENAME(Me._CrawlProjectID))

         If datasetDT IsNot Nothing AndAlso target.IsTableExists(datasetDT.TableName) Then
            Me._Dataset.EnforceConstraints = False

            ' How do i load the data per url easily?
            Dim sqlString As String = String.Format("SELECT [{0}].* FROM {0} WHERE ", datasetDT.TableName)
            modifiedUrlSql = urlSqlString.Replace(";", "")
            modifiedUrlSql = modifiedUrlSql.Replace("*", urlDT.UrlIDColumn.ColumnName)
            sqlString &= String.Format("[{0}].{1} IN ({2});", datasetDT.TableName, DataTableUtil.URLIDFK, modifiedUrlSql)

            _Log.Debug("Url_Dataset: " & sqlString)

            Dim datasetDA As New SqlClient.SqlDataAdapter(sqlString, Me._SqlConnection)
            datasetDA.SelectCommand.Transaction = target.trans
            datasetDA.Fill(datasetDT)

            Me._CrawlProject.CrawlProjectRow.IsDateRunNull()

            ' We need to create fake ids for the constraint to work
            For Each row As DataRow In datasetDT.Rows
               For Each col As DataColumn In datasetDT.Columns
                  If col.ColumnName.Contains("SYS_") AndAlso Not row.IsNull(col) Then
                     Dim tableName As String = col.ColumnName.Replace(DataTableUtil.POSTFIX, "")
                     Dim parentDT As DataTable = Me._Dataset.Tables(tableName)

                     Dim newRow As DataRow = parentDT.NewRow
                     newRow(DataTableUtil.ID) = row(col)

                     ' If the data table is partial, then we need to load the row from database.
                     parentDT.Rows.Add(newRow)
                  End If
               Next
            Next
            Me._Dataset.EnforceConstraints = True
         End If

         ' We are now loaded with the newest data
         target.updateData(urlDT, Me._CrawlProject.DataMapper.getIdentityColumns(urlDT, True))

         ' Change the last assigned date to be used internally
         For Each row As ScraperDB.UrlRow In urlDT.Rows
            row.SetLastAssignedNull()                                      ' Set the last assigned date
            row.UrlStatusID = ScraperLib.UrlManager.UrlStatus.Ready        ' Set assigned
         Next

         ' Create the data linked by the Project_Dataset
         urlDT.AcceptChanges()
         projectUrlDt.AcceptChanges()

         target.trans.Commit()
      Catch ex As Exception
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
         target.trans.Rollback()    ' Save the changes

         Throw New Exception("Error loading Url(s) from database: " & ex.Message)
      Finally
         Me.SqlConnection.Close()
      End Try
   End Sub

   ''' <summary>
   ''' Save URL -> Saves url to database, along with the data
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub SaveUrl()
      Me.SaveData()              ' 
      LoadUrl()                  ' Load url with new url
   End Sub
#End Region

#Region "Scraped Data to be saved"

   ''' <summary>
   ''' Save data to database
   ''' </summary>
   ''' <remarks></remarks>
   Public Overrides Sub SaveData()
      Me._SqlConnection.Open()

      Dim target As DataManagement.SqlExpress = New DataManagement.SqlExpress
      target.SqlConnection = Me.SqlConnection
      target.trans = Me._SqlConnection.BeginTransaction

      Try
         Dim updateTableList As New LinkedList(Of DataTable)

         Dim tblOrderList As List(Of DataTable) = Me.CrawlProject.DataMapper.getDataTablesUpdateOrder(False)

         ' Look for data tables to save to database
         For Each tbl As DataTable In tblOrderList
            tbl.AcceptChanges()

            Dim idColList As List(Of DataColumn)

            idColList = Me.CrawlProject.DataMapper.getIdentityColumns(tbl, False)
            For Each row As DataRow In tbl.Rows
               If target.isNewDataRow(row, idColList) Then
                  row.SetAdded()
               Else
                  row.SetModified()
               End If
            Next
            _Log.Debug("Saving " & tbl.TableName & " datatable to database.")

            ' Update the data table
            idColList = Me.CrawlProject.DataMapper.getIdentityColumns(tbl, True)
            target.updateData(tbl, idColList)

            tbl.AcceptChanges()

            _Log.Debug("Saved " & tbl.TableName & " datatable to database.")

         Next

         ' We can clear all the tables now that they are all saved - This includes url tables
         ' We need to walk backward and clear in the correct order.
         Me._Dataset.EnforceConstraints = False
         For i As Integer = tblOrderList.Count - 1 To 0 Step -1
            tblOrderList(i).Clear()
         Next
         Me._Dataset.EnforceConstraints = True
         target.trans.Commit()    ' Save the changes
      Catch ex As Exception
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
         target.trans.Rollback()    ' Save the changes

         Throw New Exception("Error data to database: " & ex.Message)
      Finally
         Me.SqlConnection.Close()
      End Try
   End Sub
#End Region

   Public Overrides ReadOnly Property ProjectLocation() As Object
      Get
         Return Me.SqlConnection.ConnectionString & " (ProjectID: " & Me.CrawlProjectID & ")"
      End Get
   End Property
End Class