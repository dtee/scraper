Imports System.Data.OleDb

Public Class TestPublic
   Inherits ScraperDataAdapter

   Private conn As OleDbConnection

   Private ProjectAdaptor As OleDbDataAdapter
   Private UrlAdaptor As OleDbDataAdapter
   Private ProxyAdaptor As OleDbDataAdapter
   Private TagLibraryAdaptor As OleDbDataAdapter
   Private UrlLogAdaptor As OleDbDataAdapter

#Region "Readonly Datatable"
   Public prefix As String = ""
   Private ReadOnly Property UrlTableName() As String
      Get
         Return prefix & "Url"
      End Get
   End Property

   Private ReadOnly Property ProxyTableName() As String
      Get
         Return prefix & "Proxy"
      End Get
   End Property

   Private ReadOnly Property ProjectTableName() As String
      Get
         Return prefix & "Project"
      End Get
   End Property

   Private ReadOnly Property UrlLogTableName() As String
      Get
         Return prefix & "UrlLog"
      End Get
   End Property

   Private ReadOnly Property TagLibraryTableName() As String
      Get
         Return prefix & "TagLibrary"
      End Get
   End Property
#End Region

   Public Sub New()
      Dim strSQL As String
      Dim cb As OleDbCommandBuilder

      ' Project
      strSQL = "SELECT * FROM " & Me.ProjectTableName

      ProjectAdaptor.MissingMappingAction = MissingMappingAction.Error
      ProjectAdaptor.SelectCommand = New OleDbCommand(strSQL, conn)
      cb = New OleDbCommandBuilder(ProjectAdaptor)

      ProjectAdaptor.UpdateCommand = cb.GetUpdateCommand
      ProjectAdaptor.InsertCommand = cb.GetInsertCommand
      ProjectAdaptor.DeleteCommand = cb.GetDeleteCommand

      ' Url
      strSQL = "SELECT * FROM " & Me.UrlTableName

      UrlAdaptor.MissingMappingAction = MissingMappingAction.Error
      UrlAdaptor.SelectCommand = New OleDbCommand(strSQL, conn)
      cb = New OleDbCommandBuilder(UrlAdaptor)

      UrlAdaptor.UpdateCommand = cb.GetUpdateCommand
      UrlAdaptor.InsertCommand = cb.GetInsertCommand
      UrlAdaptor.DeleteCommand = cb.GetDeleteCommand

      ' Proxy
      strSQL = "SELECT * FROM " & Me.ProxyTableName

      ProxyAdaptor.MissingMappingAction = MissingMappingAction.Error
      ProxyAdaptor.SelectCommand = New OleDbCommand(strSQL, conn)
      cb = New OleDbCommandBuilder(ProxyAdaptor)

      ProxyAdaptor.UpdateCommand = cb.GetUpdateCommand
      ProxyAdaptor.InsertCommand = cb.GetInsertCommand
      ProxyAdaptor.DeleteCommand = cb.GetDeleteCommand

      ' TagLibrary
      strSQL = "SELECT * FROM " & Me.TagLibraryTableName

      TagLibraryAdaptor.MissingMappingAction = MissingMappingAction.Error
      TagLibraryAdaptor.SelectCommand = New OleDbCommand(strSQL, conn)
      cb = New OleDbCommandBuilder(TagLibraryAdaptor)

      TagLibraryAdaptor.UpdateCommand = cb.GetUpdateCommand
      TagLibraryAdaptor.InsertCommand = cb.GetInsertCommand
      TagLibraryAdaptor.DeleteCommand = cb.GetDeleteCommand

      ' UrlLog - Remove UrlID
      strSQL = "SELECT * FROM " & Me.UrlLogTableName

      UrlLogAdaptor.MissingMappingAction = MissingMappingAction.Error
      UrlLogAdaptor.SelectCommand = New OleDbCommand(strSQL, conn)
      cb = New OleDbCommandBuilder(UrlLogAdaptor)

      UrlLogAdaptor.UpdateCommand = cb.GetUpdateCommand
      UrlLogAdaptor.InsertCommand = cb.GetInsertCommand
      UrlLogAdaptor.DeleteCommand = cb.GetDeleteCommand
   End Sub

   Public Overrides Sub LoadAllUrl()
      UrlLogAdaptor.Fill(Me.Project.DataSet.Url)
   End Sub

   Public Overrides Sub LoadData()
      Dim da As New OleDbDataAdapter

      For Each tbl As DataTable In MyBase.DataDS.Tables
         Dim strSQL As String = "SELECT * FROM " & tbl.TableName

         da.MissingMappingAction = MissingMappingAction.Passthrough
         da.SelectCommand = New OleDbCommand(strSQL, conn)
         Dim cb As OleDbCommandBuilder = New OleDbCommandBuilder(da)

         da.UpdateCommand = cb.GetUpdateCommand
         da.InsertCommand = cb.GetInsertCommand
         da.DeleteCommand = cb.GetDeleteCommand

         Dim d As MyScraperDBTableAdapters.ProjectTableAdapter
         d.GetProject()

         da.Update(MyBase.DataDS)
      Next
   End Sub

   Public Overrides Sub LoadProject()

   End Sub

   Public Overrides Sub LoadUrl()

   End Sub

   Public Overrides ReadOnly Property ProjectLocation() As Object
      Get
         Return ""
      End Get
   End Property

   Public Overrides Sub SaveData()

   End Sub

   Public Overrides Sub SaveProject()

   End Sub

   Public Overrides Sub SaveUrl()

   End Sub
End Class
