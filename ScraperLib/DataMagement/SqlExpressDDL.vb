Public Class SQLDDL                                   ' All the sql probalby shares the same ddl?
   Public SqlConnection As SqlClient.SqlConnection
   Public trans As SqlClient.SqlTransaction           ' Tranactin for the functions

   Private Shared _Log As New Log(GetType(SQLDDL), False)

   Private Shared _sqlddl As New SQLDDL
   Public Shared ReadOnly Property Singleton() As SQLDDL
      Get
         Return _sqlddl
      End Get
   End Property


   ''' <summary>
   ''' Create a database table from dataTable
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <remarks></remarks>
   Public Function CreateTable(ByVal dt As DataTable) As Boolean
      Try
         Dim strSQL As String = SQLDDL.getCreateTableSQL(dt)

         Dim cmd As SqlClient.SqlCommand = Me.SqlConnection.CreateCommand
         cmd.Transaction = trans
         cmd.CommandText = strSQL
         cmd.CommandType = CommandType.Text
         cmd.ExecuteNonQuery()

         Return True
      Catch ex As Exception
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
         Return False
      End Try
   End Function

   ''' <summary>
   ''' Function to create database table, we probalby need to add more datatypes to this.
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getCreateTableSQL(ByVal dt As DataTable) As String
      Dim tablename As String = dt.TableName
      Dim sqlStr As New System.Text.StringBuilder
      sqlStr.AppendLine(String.Format("Create Table {0}", tablename))
      sqlStr.AppendLine("(")

      Dim pkCol As DataColumn = dt.PrimaryKey(0)
      For i As Integer = 0 To dt.Columns.Count - 1
         Dim col As DataColumn = dt.Columns(i)

         Dim isNullString As String = "not null"
         If col.AllowDBNull Then
            isNullString = "null"
         End If

         If col.DataType Is GetType(Integer) Then
            If col Is pkCol Then
               sqlStr.Append(String.Format("[{0}] {1} IDENTITY(0,1) PRIMARY KEY", col.ColumnName, "int"))
            Else
               sqlStr.Append(String.Format("[{0}] {1} {2}", col.ColumnName, "int", isNullString))
            End If
         End If

         If col.DataType Is GetType(String) Then
            If col.MaxLength = -1 Then
               sqlStr.Append(String.Format("[{0}] {1} {2}", col.ColumnName, "text", isNullString))
            Else
               sqlStr.Append(String.Format("[{0}] varchar({1}) {2}", col.ColumnName, col.MaxLength, isNullString))
            End If
         End If

         If col.DataType Is GetType(Date) Then
            ' timestamp stores DateAandTime
            sqlStr.Append(String.Format("    [{0}]		{1}		{2}", col.ColumnName, "datetime", isNullString))
         End If

         If col.DataType Is GetType(Boolean) Then
            sqlStr.Append(String.Format("    [{0}]		{1}		{2}", col.ColumnName, "bit", isNullString))
         End If

         If i = dt.Columns.Count - 1 Then
            sqlStr.AppendLine()
         Else
            sqlStr.AppendLine(",")
         End If
      Next
      sqlStr.AppendLine(");")

      _Log.Info("SQL Generated: " & sqlStr.ToString)
      Return sqlStr.ToString
   End Function

   ''' <summary>
   ''' Return sql string for dropping sql data table.
   ''' </summary>
   ''' <param name="dt"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Shared Function getDropTableSql(ByVal dt As DataTable) As String
      Dim sqlStr As New System.Text.StringBuilder
      sqlStr.AppendLine(String.Format("if exists (select 1 from sysobjects where  id = object_id('{0}') and type = 'U')", dt.TableName))
      sqlStr.AppendLine(String.Format("drop table {0}", dt.TableName))
      sqlStr.AppendLine(";")

      Return sqlStr.ToString
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
   ''' Add a field to existing table
   ''' </summary>
   ''' <param name="TableName"></param>
   ''' <param name="FieldName"></param>
   ''' <remarks></remarks>
   Public Sub addField(ByVal TableName As String, ByVal FieldName As String)
      Try
         Dim strSQL As String = "DROP TABLE " & TableName

         Dim cmd As SqlClient.SqlCommand = Me.SqlConnection.CreateCommand

         cmd.CommandText = strSQL
         cmd.CommandType = CommandType.Text
         cmd.Transaction = trans

         cmd.ExecuteNonQuery()
      Catch ex As Exception
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
      End Try
   End Sub

   ''' <summary>
   ''' Drop a database table
   ''' </summary>
   ''' <param name="tableName"></param>
   ''' <remarks></remarks>
   Public Function DropTable(ByVal TableName As String) As Boolean
      Try
         Dim strSQL As String = "DROP TABLE " & TableName

         Dim cmd As SqlClient.SqlCommand = Me.SqlConnection.CreateCommand
         cmd.CommandText = strSQL
         cmd.CommandType = CommandType.Text
         cmd.Transaction = trans

         cmd.ExecuteNonQuery()

         Return True
      Catch ex As Exception
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
         Return False
      End Try
   End Function

   ''' <summary>
   ''' Get a list of fields in a table
   ''' </summary>
   ''' <param name="tableName"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Function getFields(ByVal tableName As String) As List(Of String)
      Dim fieldList As New List(Of String)
      Dim sql As String = String.Format("select column_name from information_schema.columns where table_name = '{0}';", tableName)
      Dim dt As New DataTable()

      Try
         Dim da As New SqlClient.SqlDataAdapter(sql, Me.SqlConnection)
         Dim cmmBuilder As New SqlClient.SqlCommandBuilder(da)

         da.SelectCommand.Transaction = Me.trans
         dt = da.FillSchema(dt, SchemaType.Mapped)
         da.Fill(dt)

         For Each row As DataRow In dt.Rows
            fieldList.Add(row(0))
         Next

         Return fieldList
      Catch ex As Exception
         _Log.Error(ex.Message)
         _Log.Error(ex.StackTrace)
         Return Nothing
      End Try
   End Function

   Public Function IsFieldExists(ByVal tableName As String, ByVal fieldName As String)
      Dim strSQL As String = String.Format("select count(column_name) from information_schema.columns" & _
                            " where table_name = '{0}' AND column_name = '{1}';", tableName, fieldName)
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
End Class
