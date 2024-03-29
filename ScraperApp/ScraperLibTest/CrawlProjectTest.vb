﻿'The following code was generated by Microsoft Visual Studio 2005.
'The test owner should check each test for validity.
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System
Imports System.Text
Imports System.Collections.Generic
Imports ScraperLib
Imports System.Data




'''<summary>
'''This is a test class for ScraperLib.CrawlProject and is intended
'''to contain all ScraperLib.CrawlProject Unit Tests
'''</summary>
<TestClass()> _
Public Class CrawlProjectTest

   Private Shared tran As SqlClient.SqlTransaction
   Private Shared conn As SqlClient.SqlConnection

   Private testContextInstance As TestContext

   '''<summary>
   '''Gets or sets the test context which provides
   '''information about and functionality for the current test run.
   '''</summary>
   Public Property TestContext() As TestContext
      Get
         Return testContextInstance
      End Get
      Set(ByVal value As TestContext)
         testContextInstance = Value
      End Set
   End Property

#Region "Additional test attributes"
   '
   'You can use the following additional attributes as you write your tests:
   '
   'Use ClassInitialize to run code before running the first test in the class
   '
   <ClassInitialize()> _
   Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
      conn = New Data.SqlClient.SqlConnection(My.Settings.SqlConnString)
   End Sub
   '
   'Use ClassCleanup to run code after all tests in a class have run
   '
   '<ClassCleanup()> _
   'Public Shared Sub MyClassCleanup()
   'End Sub
   '
   'Use TestInitialize to run code before running each test
   '
   <TestInitialize()> _
   Public Sub MyTestInitialize()
   End Sub

   '
   'Use TestCleanup to run code after each test has run
   '
   <TestCleanup()> _
   Public Sub MyTestCleanup()
   End Sub
#End Region

   '''<summary>
   '''A test for AddRelations()
   '''</summary>
   <TestMethod()> _
   Public Sub AddRelationsTest()
      Dim projRow As ScraperDB.CrawlProjectRow = Nothing 'TODO: Initialize to an appropriate value

      Dim target As CrawlProject = Me.loadProjectFile()

      ' Test rebulid tables
      target.RebuildScrapeDS()

      Dim projList As List(Of Project) = target.LinkMapManager.getRootProjects()
      For Each proj As Project In projList
         Console.WriteLine("Project Name: " & proj.ProjectName)
      Next

      Assert.AreEqual(1, projList.Count, "Expected Root Project is no the same.")

      ' Add relation
      target.AddRelations()

      For Each dt As Data.DataTable In target.Dataset.Tables
         Console.Write(dt.TableName & ": ")
         For Each parentRelation As Data.DataRelation In dt.ChildRelations
            Console.Write(parentRelation.ParentTable.TableName)
         Next
         Console.WriteLine()
      Next

      Console.WriteLine("Data Table Columns: ")
      For Each dt As Data.DataTable In target.Dataset.Tables
         Console.Write(dt.TableName & ": ")
         For Each col As Data.DataColumn In dt.Columns
            Console.Write(col.ColumnName & ", ")
         Next
         Console.WriteLine()
      Next

      For Each dt As Data.DataTable In target.Dataset.Tables
         If ScraperLib.DataTableUtil.IsGeneratedTable(dt) Then
            Assert.AreEqual(True, dt.Constraints.Count > 0)       ' Make sure generated tables has some relation.
         End If
      Next

      'Console.WriteLine("Dataset Relations:")
      'For Each rel As Data.DataRelation In target.Dataset.Relations
      '   Console.WriteLine(rel.ParentTable.TableName & " -> " & rel.ChildTable.TableName)
      'Next

      'Console.WriteLine("Data update order:")
      'For Each dt As Data.DataTable In target.DataMapper.getDataTablesUpdateOrder(False)
      '   Console.WriteLine(dt.TableName)
      'Next

      Dim ds As New ScraperDB
      For Each tbl As Data.DataTable In ds.Tables
         Console.WriteLine(DataManagement.SqlExpress.getLoadProjectDataSQL(tbl, 10))
      Next

      'Console.WriteLine("SQL DDL: ")
      'Console.WriteLine(DataManagement.SqlExpress.getDropCreateLSQL(target))

      ' TODO: How should this be tested?
      Console.WriteLine("============== Install SQL ======================")
      Console.WriteLine(DataManagement.SqlExpress.getInstallProjectSQL())

   End Sub

   ''' <summary>
   ''' Open file on start up
   ''' </summary>
   ''' <remarks></remarks>
   Private Function loadProjectFile() As CrawlProject
      Dim floader As New FileScraperDataAdapter()

      System.IO.File.WriteAllBytes("test.sproj", My.Resources.test)
      floader.ProjectFileName = "test.sproj"

      Try
         floader.LoadProject()
         Return floader.CrawlProject
      Catch ex As Exception
         Console.WriteLine(ex.Message)
         Console.WriteLine(ex.StackTrace)
         MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Error Opening File")

         Return Nothing
      End Try
   End Function

   '''<summary>
   '''Test save DB.
   '''</summary>
   <TestMethod()> _
   Public Sub saveDBTest()
      Dim projRow As ScraperDB.CrawlProjectRow = Nothing 'TODO: Initialize to an appropriate value

      Dim target As CrawlProject = Me.loadProjectFile()

      Dim sqlAdaptor As New ScraperLib.SQLDatabaseScraperAdapter(conn)
      sqlAdaptor.CrawlProject = target

      sqlAdaptor.SaveProject()

      Assert.AreEqual(True, target.CrawlProjectRow.CrawlProjectID >= 0, "Project data not saved to database")

      Dim newAdaptor As New ScraperLib.SQLDatabaseScraperAdapter(conn)
      newAdaptor.CrawlProjectID = target.CrawlProjectRow.CrawlProjectID
      newAdaptor.LoadProject()

      Assert.AreEqual(target.CrawlProjectRow.CrawlProjectID, newAdaptor.CrawlProject.CrawlProjectRow.CrawlProjectID, "differnt id loaded")
      Assert.AreNotEqual(target.CrawlProjectRow, newAdaptor.CrawlProject.CrawlProjectRow, "Row should be differnt.")

      ' Create database tables
      newAdaptor.createDataTables()

   End Sub
End Class
