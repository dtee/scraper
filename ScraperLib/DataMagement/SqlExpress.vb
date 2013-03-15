Namespace DataManagement
   ''' <summary>
   ''' Handle data update to database for Sql express server
   ''' - Identifiers, data duplicates, checksum and other useful stuffs
   ''' </summary>
   ''' <remarks></remarks>
   Public Class SqlExpress
      Private Shared _Log As New Log(GetType(SqlExpress), False)
      Public Shared IDENTIFIER As String = "identifier"
      Public Shared CHECKSUM As String = "checksum1"

      Public SqlConnection As SqlClient.SqlConnection
      Public trans As SqlClient.SqlTransaction           ' Tranactin for the functions

      ''' <summary>
      ''' Get sql code for installing project related tables.
      ''' </summary>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Shared Function getInstallProjectSQL() As String
         Dim crawlProject As New CrawlProject("Temp")

         Dim sqlDrop As New System.Text.StringBuilder
         Dim dropString As String = ""
         Dim sqlCreate As New System.Text.StringBuilder

         Dim sqlDropIndex As New System.Text.StringBuilder
         Dim sqlCreateIndex As New System.Text.StringBuilder

         Dim sqlCreateConstaint As New System.Text.StringBuilder

         ' we problaby need want to drop the tables in order
         For Each tbl As DataTable In crawlProject.DataMapper.getDataTablesUpdateOrder(True)
            dropString = SQLDDL.getDropTableSql(tbl) & dropString
            sqlCreate.AppendLine(SQLDDL.getCreateTableSQL(tbl))

            sqlDropIndex.AppendLine(SqlExpress.getIndexDropSql(tbl))
            sqlCreateIndex.AppendLine(SqlExpress.getIndexTableSQL(tbl))

            sqlCreateConstaint.AppendLine(SqlExpress.getTableFK(tbl))
         Next

         sqlDrop.AppendLine(dropString)
         sqlDrop.AppendLine(sqlDropIndex.ToString)
         sqlDrop.AppendLine(sqlCreate.ToString)
         sqlDrop.AppendLine(sqlCreateIndex.ToString)
         sqlDrop.AppendLine(sqlCreateConstaint.ToString)

         sqlDrop.AppendLine("insert into URLStatus values ('Ready', 'Ready to download');")
         sqlDrop.AppendLine("insert into URLStatus values ('Assigned', 'Assigned to download');")
         sqlDrop.AppendLine("insert into URLStatus values ('Error', 'Url Error, invalid or ');")
         sqlDrop.AppendLine("insert into URLStatus values ('Finished', 'Finish downloading. Will not be trying to scrape this again.');")

         sqlDrop.AppendLine("insert into ProxyStatus values ('Ready', 'Ready to used used for the project.');")
         sqlDrop.AppendLine("insert into ProxyStatus values ('Checking', 'Proxy is currently being checked.');")
         sqlDrop.AppendLine("insert into ProxyStatus values ('Unknown', 'Unknown proxy status.');")
         sqlDrop.AppendLine("insert into ProxyStatus values ('Error', 'Error, Bad proxy.');")

         Return sqlDrop.ToString
      End Function

      ''' <summary>
      ''' Return the DDL SQL for creating the project data tables
      ''' </summary>
      ''' <param name="crawlProject"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Shared Function getDropCreateLSQL(ByVal crawlProject As CrawlProject) As String
         Dim ds As ScraperDB = crawlProject.Dataset
         Dim sqlDrop As New System.Text.StringBuilder
         Dim sqlCreate As New System.Text.StringBuilder
         Dim dropString As String = ""

         Dim sqlDropIndex As New System.Text.StringBuilder
         Dim sqlCreateIndex As New System.Text.StringBuilder

         Dim sqlCreateConstaint As New System.Text.StringBuilder

         ' we problaby need want to drop the tables in order

         For Each dt As DataTable In ds.Tables
            Console.WriteLine(dt.TableName & ": " & dt.ParentRelations.Count)
         Next

         Dim tblList As List(Of DataTable) = crawlProject.DataMapper.getDataTablesUpdateOrder(False)
         For Each tbl As DataTable In tblList
            If DataTableUtil.IsGeneratedTable(tbl) Then
               dropString = SQLDDL.getDropTableSql(tbl) & dropString    ' Drop in the right order.
               sqlCreate.AppendLine(SQLDDL.getCreateTableSQL(tbl))

               sqlDropIndex.AppendLine(SqlExpress.getIndexDropSql(tbl))
               sqlCreateIndex.AppendLine(SqlExpress.getIndexTableSQL(tbl))

               sqlCreateConstaint.AppendLine(SqlExpress.getTableFK(tbl))
            End If
         Next

         sqlDrop.AppendLine(dropString)
         sqlDrop.AppendLine(sqlDropIndex.ToString)
         sqlDrop.AppendLine(sqlCreate.ToString)
         sqlDrop.AppendLine(sqlCreateIndex.ToString)

         'sqlDrop.AppendLine(SqlExpress.getDSRelationFK(ds))
         sqlDrop.AppendLine(sqlCreateConstaint.ToString)

         _Log.Debug(sqlDrop.ToString)
         Return sqlDrop.ToString
      End Function

      ' Index fk and PK keys based on relations.
      Public Shared Function getIndexTableSQL(ByVal dt As DataTable)
         Dim sql As New System.Text.StringBuilder()

         For Each rel As DataRelation In dt.ParentRelations
            Dim parentDT As DataTable = rel.ParentTable
            Dim col As DataColumn = rel.ChildColumns(0)
            Dim indexName As String = String.Format("Index_{0}_{1}", parentDT.TableName, col.ColumnName)

            sql.AppendLine(String.Format("create index {0} on {1} ({2})", indexName, dt.TableName, col.ColumnName))
            sql.AppendLine(String.Format(";"))
         Next

         Return sql.ToString
      End Function

      Public Shared Function getIndexDropSql(ByVal dt As DataTable)
         Dim sql As New System.Text.StringBuilder()

         For Each rel As DataRelation In dt.ParentRelations
            Dim parentDT As DataTable = rel.ParentTable
            Dim col As DataColumn = rel.ChildColumns(0)
            Dim indexName As String = String.Format("Index_{0}_{1}", parentDT.TableName, col.ColumnName)

            sql.AppendLine(String.Format("if exists (select 1 from  sysindexes where id = object_id('{0}') and name = '{1}')", dt.TableName, indexName))
            sql.AppendLine(String.Format("   drop index {0}.{1}", dt.TableName, indexName))
            sql.AppendLine(String.Format(";"))
         Next

         Return sql.ToString
      End Function

      Private Shared Function getDSRelationFK(ByVal ds As DataSet)
         Dim sql As New System.Text.StringBuilder()

         For Each rel As DataRelation In ds.Relations
            Dim childCol As DataColumn = rel.ChildColumns(0)
            Dim parentCol As DataColumn = rel.ParentColumns(0)

            sql.AppendLine(String.Format("alter table {0}", rel.ChildTable))
            sql.AppendLine(String.Format("    add constraint {0} foreign key ({1})", rel.RelationName, childCol.ColumnName))
            sql.AppendLine(String.Format("       references {0} ({1})", rel.ParentTable.TableName, parentCol.ColumnName))
            sql.AppendLine(String.Format("       on delete cascade"))
            sql.AppendLine(String.Format(";"))
         Next

         Return sql.ToString
      End Function

      ''' <summary>
      ''' Get fk constraints
      ''' </summary>
      ''' <param name="dt"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Shared Function getTableFK(ByVal dt As DataTable)
         Dim sql As New System.Text.StringBuilder()

         For Each rel As DataRelation In dt.ParentRelations
            Dim childCol As DataColumn = rel.ChildColumns(0)
            Dim parentCol As DataColumn = rel.ParentColumns(0)

            sql.AppendLine(String.Format("alter table {0}", dt.TableName))
            sql.AppendLine(String.Format("    add constraint {0} foreign key ({1})", rel.RelationName, childCol.ColumnName))
            sql.AppendLine(String.Format("       references {0} ({1})", rel.ParentTable.TableName, parentCol.ColumnName))

            If rel Is dt.ParentRelations(0) And rel.ParentTable IsNot rel.ChildTable Then
               sql.AppendLine(String.Format("       on delete cascade"))
            End If

            sql.AppendLine(String.Format(";"))
         Next

         Return sql.ToString
      End Function


      ''' <summary>
      ''' Does the database table exists
      ''' </summary>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function IsTableExists(ByVal tableName As String) As Boolean
         Dim strSQL As String = String.Format("select count(table_name) from information_schema.tables where table_name = '{0}';", tableName)

         Try
            Dim cmd As SqlClient.SqlCommand = Me.SqlConnection.CreateCommand
            cmd.Transaction = trans
            cmd.CommandText = strSQL
            cmd.CommandType = CommandType.Text

            Dim i As Integer = cmd.ExecuteScalar()
            Return (i > 0)
         Catch ex As Exception
            _Log.Error(ex.Message)
            _Log.Error(ex.StackTrace)
            Return False
         End Try
      End Function

      ''' <summary>
      ''' Save Data - Url, and generated data tables.
      ''' </summary>
      ''' <remarks></remarks>
      Public Sub saveData(ByVal crawlProject As CrawlProject)        ' Save a crawl project's data
         ' Save or update data.
         For Each tbl As DataTable In crawlProject.DataMapper.getDataTablesUpdateOrder(False)
            ' check fields
            Dim idCols As List(Of DataColumn) = crawlProject.DataMapper.getIdentityColumns(tbl, False)
            tbl.AcceptChanges()

            ' Set save or not save depending on isCreate
            For Each row As DataRow In tbl.Rows
               If Me.isNewDataRow(row, idCols) Then
                  row.SetAdded()          ' Set row state for update.
               Else
                  row.SetModified()
               End If
            Next

            ' Update fields
            idCols = crawlProject.DataMapper.getIdentityColumns(tbl, True)

            ' Call update data.
            Me.updateData(tbl, idCols)
         Next
      End Sub

      ''' <summary>
      ''' Generate a sql for loading project related data information
      ''' </summary>
      ''' <param name="dt"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Shared Function getLoadProjectDataSQL(ByVal dt As DataTable, ByVal crawlProjID As Integer) As String
         Dim ds As ScraperDB = dt.DataSet
         Dim where As New System.Text.StringBuilder()
         Dim tables As New System.Text.StringBuilder()
         Dim sql As New System.Text.StringBuilder()

         Dim parentDT As DataTable = dt
         tables.Append("[" & parentDT.TableName & "]")

         If parentDT Is ds.CrawlProject Then
            where.Append("([CrawlProject].CrawlProjectID = ")
            where.AppendLine(crawlProjID & ")")
         End If

         While parentDT.ParentRelations.Count > 0
            Dim rel As DataRelation = Nothing

            For Each fkRel As Data.DataRelation In parentDT.ParentRelations
               If (fkRel.ParentTable Is ds.Project) Then
                  rel = fkRel
                  Exit For
               ElseIf (parentDT Is ds.Project_Url And fkRel.ParentTable Is ds.Url) Then
                  rel = fkRel
                  Exit For
               ElseIf (fkRel.ParentTable Is ds.CrawlProject) Then
                  rel = fkRel
                  Exit For
               End If
            Next

            If rel Is Nothing Then
               Exit While
            End If

            Dim parentCol As DataColumn = rel.ParentColumns(0)
            Dim childCol As DataColumn = rel.ChildColumns(0)

            where.Append(ControlChars.Tab)
            where.Append(String.Format("([{0}].{1} = ", rel.ParentTable.TableName, parentCol.ColumnName))
            where.AppendLine(String.Format("[{0}].{1})", rel.ChildTable.TableName, childCol.ColumnName))

            parentDT = rel.ParentTable
            If parentDT.ParentRelations.Count > 0 Then
               where.Append(" AND ")
            Else
               If parentDT Is ds.CrawlProject Then
                  where.Append(" AND ")
                  where.Append("([CrawlProject].CrawlProjectID = ")
                  where.AppendLine(crawlProjID & ")")
               End If
            End If

            tables.Append(",[" & parentDT.TableName & "]")
         End While

         If where.ToString <> "" Then
            sql.AppendLine(String.Format("SELECT [{0}].* from {1}", dt.TableName, tables.ToString))
            sql.AppendLine(String.Format("{0}WHERE {1};", ControlChars.Tab, where.ToString))
         Else
            sql.AppendLine(String.Format("SELECT [{0}].* from {1};", dt.TableName, tables.ToString))
         End If

         _Log.Debug(sql.ToString)
         Return sql.ToString
      End Function

      ''' <summary>
      ''' Get the row ID in the database
      ''' </summary>
      ''' <param name="row"></param>
      ''' <param name="idCols"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function getRowID(ByVal row As DataRow, ByVal idCols As List(Of DataColumn)) As Integer
         ' Run sql function and test the result
         Dim dt As DataTable = row.Table
         Dim sql As New System.Text.StringBuilder()

         Dim pkCol As DataColumn = dt.PrimaryKey(0)

         Dim selectSql = String.Format("SELECT [{0}].{1} FROM [{0}] WHERE ", dt.TableName, pkCol.ColumnName)

         ' Check the identifier table
         Dim whereSQL As New System.Text.StringBuilder()
         Dim isFirst = True

         For Each idCol As DataColumn In idCols
            If Not isFirst Then
               whereSQL.Append(" AND ")
            End If

            isFirst = False

            If idCol.DataType Is GetType(String) And idCol.MaxLength = -1 Then
               whereSQL.AppendLine(String.Format("([{0}] LIKE @{0})", idCol.ColumnName))
            Else
               whereSQL.AppendLine(String.Format("([{0}] = @{0})", idCol.ColumnName))
            End If
         Next

         sql.Append(selectSql)
         sql.Append(whereSQL)
         sql.AppendLine(";")

         _Log.Debug("getRowID: " & sql.ToString)

         Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(sql.ToString, Me.SqlConnection)
         cmd.Transaction = Me.trans
         cmd.CommandType = System.Data.CommandType.Text

         For Each col As DataColumn In idCols
            Dim sqlParm As SqlClient.SqlParameter = getSqlParameter(col)
            sqlParm.Value = row(col)
            cmd.Parameters.Add(sqlParm)
         Next

         Dim pkID As Integer = cmd.ExecuteScalar

         Return pkID
      End Function

      ''' <summary>
      ''' See if the row in the data table is old or new
      ''' TODO: Implement caching of identity and checksum.
      ''' </summary>
      ''' <param name="row"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function isNewDataRow(ByVal row As DataRow, ByVal idCols As List(Of DataColumn)) As Boolean
         ' Run sql function and test the result
         Dim dt As DataTable = row.Table
         Dim sql As New System.Text.StringBuilder()

         Dim selectSql = String.Format("SELECT count(*) FROM [{0}] WHERE ", dt.TableName)

         ' Check the identifier table
         Dim whereSQL As New System.Text.StringBuilder()
         Dim isFirst = True

         For Each idCol As DataColumn In idCols
            If Not isFirst Then
               whereSQL.Append(" AND ")
            End If

            isFirst = False

            If idCol.DataType Is GetType(String) And idCol.MaxLength = -1 Then
               whereSQL.AppendLine(String.Format("([{0}] LIKE @{0})", idCol.ColumnName))
            Else
               whereSQL.AppendLine(String.Format("([{0}] = @{0})", idCol.ColumnName))
            End If
         Next

         sql.Append(selectSql)
         sql.Append(whereSQL)
         sql.AppendLine(";")

         '_Log.Debug("IsNewDataRow: " & sql.ToString)

         Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(sql.ToString, Me.SqlConnection)
         cmd.Transaction = Me.trans
         cmd.CommandType = System.Data.CommandType.Text

         For Each col As DataColumn In idCols
            Dim sqlParm As SqlClient.SqlParameter = getSqlParameter(col)
            sqlParm.Value = row(col)
            cmd.Parameters.Add(sqlParm)
         Next

         Return cmd.ExecuteScalar = 0
      End Function

      ''' <summary>
      ''' See if the row is changed or not
      ''' TODO: Implement caching of identity and checksum.
      ''' </summary>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function isChangedDataRow(ByVal row As DataRow) As Boolean
         Return Me.executeCountQuery(Me.getIsChangedDataSQL(row)) = 0
      End Function

      ''' <summary>
      ''' Run execute scalar on the sql.
      ''' </summary>
      ''' <param name="sql"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Private Function executeCountQuery(ByVal sql As String) As Int32
         Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(sql, Me.SqlConnection)
         cmd.Transaction = Me.trans
         cmd.CommandType = System.Data.CommandType.Text

         Return cmd.ExecuteScalar
      End Function

      ''' <summary>
      ''' Return sql to test newData
      ''' </summary>
      ''' <param name="row"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function getIsNewDataSQL(ByVal row As DataRow, ByVal idCols As List(Of DataColumn)) As String
         ' Run sql function and test the result
         Dim dt As DataTable = row.Table
         Dim sql As New System.Text.StringBuilder()

         Dim selectSql = String.Format("SELECT count(*) FROM [{0}] WHERE ", dt.TableName)

         ' Check the identifier table
         Dim whereSQL As New System.Text.StringBuilder()
         Dim isFirst = True

         For Each idCol As DataColumn In idCols
            If Not isFirst Then
               whereSQL.Append(" AND ")
            End If

            isFirst = False

            whereSQL.AppendLine(getSQLWhere(idCol, row))
         Next

         sql.Append(selectSql)
         sql.Append(whereSQL)
         sql.AppendLine(";")

         _Log.Debug("SQL isNewRow query: " & sql.ToString)

         Return sql.ToString
      End Function

      ''' <summary>
      ''' If row is nothing it it will return the paramized where statement
      ''' </summary>
      ''' <param name="idCol"></param>
      ''' <param name="row"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Shared Function getSQLWhere(ByVal idCol As DataColumn, ByVal row As DataRow) As String

         Dim whereSQL As New System.Text.StringBuilder()
         Dim parm As String = ""

         If row Is Nothing Then
            parm = "@" & idCol.ColumnName
         Else
            ' Check for row text
            parm = row(idCol).ToString

            If idCol.DataType Is GetType(String) Then
               If idCol.MaxLength = -1 Then
                  parm = String.Format("('{0}')", row(idCol).ToString)
               Else
                  parm = String.Format("('{0}')", row(idCol).ToString)
               End If
            ElseIf idCol.DataType Is GetType(Date) Then
               parm = String.Format("('#{0}#')", row(idCol).ToString)
            ElseIf idCol.DataType Is GetType(Integer) Then
               parm = String.Format("({0})", row(idCol).ToString)
            End If
         End If


         If idCol.DataType Is GetType(String) AndAlso idCol.MaxLength = -1 Then
            whereSQL.Append(String.Format("({0} LIKE {1})", idCol.ColumnName, parm))
         Else
            whereSQL.Append(String.Format("({0} = {1})", idCol.ColumnName, parm))
         End If

         Return whereSQL.ToString
      End Function

      ''' <summary>
      ''' Return sql to test changed Data
      ''' </summary>
      ''' <param name="row"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function getIsChangedDataSQL(ByVal row As DataRow) As String
         ' Run sql function and test the result
         Dim dt As DataTable = row.Table
         Dim sql As New System.Text.StringBuilder()

         Dim selectSql = String.Format("SELECT count(*) FROM [{0}] WHERE ", dt.TableName)

         ' Check the identifier table
         Dim uniqueConstraint As Data.UniqueConstraint = dt.Constraints(SqlExpress.IDENTIFIER)
         Dim whereSQL As New System.Text.StringBuilder()
         Dim isFirst = True


         For Each idCol As DataColumn In uniqueConstraint.Columns
            If Not isFirst Then
               whereSQL.Append(" AND ")
            End If

            isFirst = False
            whereSQL.Append(String.Format("({0} LIKE '{1}')", idCol.ColumnName, row(idCol).ToString))
         Next

         sql.Append(selectSql)
         sql.Append(whereSQL)
         sql.Append(" AND ")
         sql.Append(String.Format("({0} LIKE '{1}')", CHECKSUM, row(CHECKSUM).ToString))
         sql.AppendLine(";")

         _Log.Debug("SQL isChanged query: " & sql.ToString)

         Return sql.ToString
      End Function

      Public Sub updateData(ByVal dt As DataTable, ByVal idColList As List(Of DataColumn), ByVal updateColList As List(Of DataColumn))


         ' Update the database with list of identifiers
         Dim da As New SqlClient.SqlDataAdapter("SELECT * FROM " & dt.TableName, Me.SqlConnection)
         Dim cmdBuilder As New SqlClient.SqlCommandBuilder(da)

         da.UpdateCommand = New SqlClient.SqlCommand(Me.getUpdateSQL(dt, idColList, updateColList), Me.SqlConnection)
         da.UpdateCommand.Transaction = Me.trans
         da.UpdateCommand.CommandType = System.Data.CommandType.Text
         generateParam(da.UpdateCommand.Parameters, dt)

         da.InsertCommand = New SqlClient.SqlCommand(Me.getInsertSQL(dt, idColList, updateColList), Me.SqlConnection)
         da.InsertCommand.Transaction = Me.trans
         da.InsertCommand.CommandType = System.Data.CommandType.Text
         generateParam(da.InsertCommand.Parameters, dt)

         da.ContinueUpdateOnError = True
         Dim childColName As String = ""
         For Each rel As DataRelation In dt.ParentRelations
            If rel.ParentTable Is rel.ChildTable Then
               childColName = rel.ChildColumns(0).ColumnName
               Exit For
            End If
         Next

         Dim dtSQL As String = Nothing
         If (DataTableUtil.IsGeneratedTable(dt) AndAlso dt.Columns.Contains(DataTableUtil.ID)) Then
            dtSQL = DataTableUtil.ID & " < 0"         ' Save only the new rows
         End If

         ' Nested data update
         If childColName <> "" Then
            Dim pkCol As DataColumn = dt.PrimaryKey(0)

            Dim expr As String = childColName & " is null"

            If dtSQL IsNot Nothing Then expr &= " AND " & dtSQL ' Special case
            Dim rows() As DataRow = dt.Select(expr, Nothing)
            While rows.Length > 0
               da.Update(rows)
               expr = childColName & " >= 0 AND " & pkCol.ColumnName & " < 0"
               If dtSQL IsNot Nothing Then expr &= " AND " & dtSQL
               rows = dt.Select(expr, Nothing)
            End While
         Else
            Dim rows() As DataRow = dt.Select(dtSQL, Nothing)
            da.Update(rows)
         End If

      End Sub

      ''' <summary>
      ''' Update data in the datatable to the database
      ''' </summary>
      ''' <param name="dt"></param>
      ''' <remarks></remarks>
      Public Sub updateData(ByVal dt As DataTable, ByVal idColList As List(Of DataColumn))
         Dim updateCols As New List(Of DataColumn)
         For Each col As DataColumn In dt.Columns
            updateCols.Add(col)
         Next
         Me.updateData(dt, idColList, updateCols)
      End Sub

      ''' <summary>
      ''' Generate parms to add
      ''' </summary>
      ''' <param name="params"></param>
      ''' <param name="dt"></param>
      ''' <remarks></remarks>
      Private Sub generateParam(ByVal params As SqlClient.SqlParameterCollection, ByVal dt As DataTable)
         For Each col As DataColumn In dt.Columns
            params.Add(getSqlParameter(col))
         Next
      End Sub

      Private Function getSqlParameter(ByVal col As DataColumn) As SqlClient.SqlParameter
         If col.DataType Is GetType(String) Then
            If col.MaxLength = -1 Then
               Return (New SqlClient.SqlParameter("@" & col.ColumnName, _
                  SqlDbType.Text, 0, System.Data.ParameterDirection.Input, 0, 0, col.ColumnName, _
                  System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
            Else
               Return (New SqlClient.SqlParameter("@" & col.ColumnName, _
                  SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, 0, 0, col.ColumnName, _
                  System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
            End If
         ElseIf col.DataType Is GetType(DateTime) Then
            Return (New SqlClient.SqlParameter("@" & col.ColumnName, _
               SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, col.ColumnName, _
               System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
         Else
            Return (New SqlClient.SqlParameter("@" & col.ColumnName, _
               SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, col.ColumnName, _
               System.Data.DataRowVersion.Current, False, Nothing, "", "", ""))
         End If
      End Function

      ''' <summary>
      ''' Generate update sql for updating the data in the datatable
      ''' </summary>
      ''' <param name="dt"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function getUpdateSQL(ByVal dt As DataTable, ByVal idColList As List(Of DataColumn), _
         ByVal updateColList As List(Of DataColumn)) As String

         Dim sql As New System.Text.StringBuilder
         sql.Append(String.Format("UPDATE [{0}] SET ", dt.TableName))

         Dim colNameList As New List(Of String)
         Dim identifierList As New List(Of String)

         Dim paramList As New List(Of System.Data.SqlClient.SqlParameter)

         For Each col As DataColumn In updateColList
            Dim isIgnoreCol As Boolean = False
            For Each idCol As DataColumn In idColList
               If (idCol Is col) Then isIgnoreCol = True
            Next

            For Each idCol As DataColumn In dt.PrimaryKey
               If (idCol Is col) Then isIgnoreCol = True
            Next
            If isIgnoreCol Then Continue For



            colNameList.Add(String.Format("[{0}] = @{0}", col.ColumnName))
         Next

         Dim isFirst As Boolean = True
         For Each colName As String In colNameList
            If Not isFirst Then
               sql.Append(", ")
            End If
            isFirst = False
            sql.Append(colName)
         Next

         sql.Append(" WHERE ")

         ' Check the identifier table
         Dim whereSQL As New System.Text.StringBuilder()
         isFirst = True
         For Each idCol As DataColumn In idColList
            If Not isFirst Then
               whereSQL.Append(" AND ")
            End If

            isFirst = False
            whereSQL.Append(getSQLWhere(idCol, Nothing))
         Next

         sql.Append(whereSQL)
         sql.Append(";")
         sql.AppendLine()
         sql.Append("SELECT ")         ' Select * works also - but do we need all the data?, we only really just the id.
         For i As Integer = 0 To dt.Columns.Count - 1
            Dim col As DataColumn = dt.Columns(i)
            If i = dt.Columns.Count - 1 Then
               sql.Append(String.Format("[{0}]", col.ColumnName))
            Else
               sql.Append(String.Format("[{0}], ", col.ColumnName))
            End If
         Next

         ' LOADING SCOPE_IDENTITY TO UPDATE THE DATA ROW ID.
         sql.Append(" FROM [" & dt.TableName & "] WHERE (")

         sql.Append(whereSQL)

         sql.Append(");")
         _Log.Debug(sql.ToString)

         Return sql.ToString
      End Function

      Public Function getInsertSQL(ByVal dt As DataTable, ByVal colList As List(Of DataColumn), _
         ByVal updateColList As List(Of DataColumn)) As String

         Dim sql As New System.Text.StringBuilder
         sql.Append(String.Format("INSERT INTO [{0}] ", dt.TableName))

         sql.Append("(")
         Dim colNameList As New List(Of String)
         For Each col As DataColumn In updateColList
            If col.Unique Then Continue For
            colNameList.Add(String.Format("[{0}]", col.ColumnName))
         Next

         Dim isFirst As Boolean = True
         For Each colName As String In colNameList
            If Not isFirst Then
               sql.Append(", ")
            End If
            isFirst = False
            sql.Append(colName)
         Next

         sql.Append(") VALUES (")

         ' This throws a bug.
         colNameList.Clear()
         For i As Integer = 0 To dt.Columns.Count - 1
            Dim col As DataColumn = dt.Columns(i)
            If col.Unique Then Continue For

            colNameList.Add(String.Format("@{0}", col.ColumnName))
         Next

         isFirst = True
         For Each colName As String In colNameList
            If Not isFirst Then
               sql.Append(", ")
            End If
            isFirst = False
            sql.Append(colName)
         Next

         sql.Append(");")
         sql.AppendLine()
         sql.Append("SELECT ")         ' Select * works also - but do we need all the data?, we only really just the id.
         For i As Integer = 0 To dt.Columns.Count - 1
            Dim col As DataColumn = dt.Columns(i)
            If i = dt.Columns.Count - 1 Then
               sql.Append(String.Format("[{0}]", col.ColumnName))
            Else
               sql.Append(String.Format("[{0}], ", col.ColumnName))
            End If
         Next

         ' LOADING SCOPE_IDENTITY TO UPDATE THE DATA ROW ID.
         sql.Append(" from [" & dt.TableName & "] Where (")

         For i As Integer = 0 To dt.Columns.Count - 1
            Dim col As DataColumn = dt.Columns(i)

            If Not col.Unique Then Continue For
            If i = dt.Columns.Count - 1 Then
               sql.Append(String.Format("{0}  = SCOPE_IDENTITY() ", col.ColumnName))
            Else
               sql.Append(String.Format("{0}  = SCOPE_IDENTITY() ", col.ColumnName))
            End If
         Next
         sql.Append(");")

         _Log.Debug(sql.ToString)
         Return sql.ToString
      End Function

      ''' <summary>
      ''' Get total rows in a database table
      ''' </summary>
      ''' <param name="tableName"></param>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Function getRowCount(ByVal tableName As String)
         Try
            Dim strSQL As String = "select count(*) as count from " & tableName

            Dim cmd As SqlClient.SqlCommand = Me.SqlConnection.CreateCommand
            cmd.CommandText = strSQL
            cmd.CommandType = CommandType.Text
            cmd.Transaction = trans

            Return cmd.ExecuteScalar()
         Catch ex As Exception
            _Log.Error(ex.Message)
            _Log.Error(ex.StackTrace)
            Return 0
         End Try
      End Function
   End Class
End Namespace