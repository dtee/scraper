Public Class CrawlHelper
   Private Shared _log As New Log(GetType(CrawlHelper), False)

   Private _CrawlProject As CrawlProject
   Public Sub New(ByVal crawlproject As CrawlProject)
      Me._CrawlProject = crawlproject
   End Sub

#Region "Scrape + Data/Url Relational Stuffs"
   ''' <summary>
   ''' Do Scrape
   ''' </summary>
   ''' <param name="urlRow"></param>
   ''' <param name="content"></param>
   ''' <remarks></remarks>
   Public Sub doScrape(ByVal urlRow As ScraperDB.UrlRow, ByVal content As String)
      ' Do Scrape
      For Each urlMap As UrlManager.UrlMap In Me._CrawlProject.UrlManager.getUrlMaps(urlRow)
         Try
            ' Scrape the downloaded context
            Me._CrawlProject.Scraper.Scrape(content, urlRow, urlMap.Project.TagTree)

            ' Scrape saved data: depends on the mapping rule

            ' Do further data refining

            ' Copy the data row relational information
            If Not urlMap.LinkMap Is Nothing Then
               UpdateReferences(urlMap.LinkMap, urlRow)
            End If

            ' Insert url to scraped to the url list.
            For Each node As TagNode In urlMap.Project.TagTree.UrlTagNodes
               If node.Row.GetLinkMappingRows.Length > 0 Then
                  InsertUrl(node, urlRow)
               End If
            Next

            urlMap.UrlProjectRow.IsScraped = True
            urlMap.UrlProjectRow.LastScraped = Now       ' Set the last scraped date
         Catch ex As Exception
            _log.Error(ex.Message)
            _log.Error(ex.StackTrace)
            urlMap.UrlProjectRow.IsScraped = False          ' Could be any problem, url not linking, etc.
         End Try
      Next
   End Sub

   ''' <summary>
   ''' Copy referenes to data tables
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub UpdateReferences(ByVal linkMap As LinkMap, ByVal urlRow As ScraperDB.UrlRow)
      Dim proj As Project = linkMap.Project

      Dim datasetDT As DataTable = Me._CrawlProject.Dataset.Tables(DataTableUtil.URL_DATASET_TABLENAME(Me._CrawlProject.CrawlProjectRow.CrawlProjectID))
      Dim dv As New DataView(datasetDT)
      dv.RowFilter = Me._CrawlProject.Dataset.Url.TableName & DataTableUtil.POSTFIX & " = " & urlRow.UrlID

      Dim dsRow As DataRow
      If dv.Count > 0 Then
         dsRow = dv(0).Row
      Else
         Return      ' No relations exists
      End If

      For Each node As TagNode In proj.TagTree.DataTagNodes
         If (node.ParentDataTableTagNode Is Nothing) Then         ' If the table in the project is a root table then

            If node.DataDT.Rows.Count = 0 Then
               _log.Warn("No data scraped in the project")
            Else
               ' Get Url ID and find the column
               If linkMap.IsPartialData Then
                  copyFieldRelation(node, dsRow)
               Else
                  _log.Info("Copying data references.")
                  CopyTableRelations(node, dsRow)
               End If
            End If
         End If
      Next
   End Sub

   ''' <summary>
   ''' this function requires a mapping information data table which contains identifier and other information
   ''' </summary>
   ''' <param name="row"></param>
   ''' <remarks></remarks>
   Public Shared Sub GenerateChecksum(ByVal row As DataRow)
      Dim m As New System.Security.Cryptography.MD5CryptoServiceProvider()

      Dim values As New System.Text.StringBuilder()
      For Each col As DataColumn In row.Table.Columns
         If col.ColumnName.Contains("SYS_") Then
         Else
            values.Append(row(col))
         End If
      Next

      Dim hash() As Byte = m.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(values.ToString))
      Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder(CInt((hash.Length * 2) _
                      + (hash.Length / 8)))

      For i As Integer = 0 To hash.Length - 1
         sb.Append(BitConverter.ToString(hash, i, 1))
      Next

      row(DataTableUtil.CHECKSUM) = sb.ToString       ' Set the checksum
   End Sub

   ''' <summary>
   ''' Copy field data relation.
   ''' </summary>
   ''' <param name="dataTagNode"></param>
   ''' <param name="dsRow"></param>
   ''' <remarks></remarks>
   Private Sub copyFieldRelation(ByVal dataTagNode As TagNode, ByVal dsRow As DataRow)
      ' Get the first row in data table
      Dim colName As String = dataTagNode.DataDT.TableName & DataTableUtil.POSTFIX     ' Copy the relations
      Dim partialDV As New DataView(dataTagNode.DataDT)

      Dim childNode As TagNode = dataTagNode.TagNodeList(0)

      partialDV.RowFilter = DataTableUtil.ID & " = " & dsRow(colName)

      _log.Debug(partialDV.RowFilter)

      'Some partial data row exists
      If partialDV.Count > 0 Then

         Dim firstChildRow As ScraperTempDS.FieldDTRow = childNode.FieldDT.Rows(0)

         Dim dv As New DataView(dataTagNode.DataDT)
         dv.RowFilter = DataTableUtil.ID & " = " & firstChildRow.PID

         Dim targetRow As DataRow = partialDV.Item(0).Row               ' Row to copy to
         Dim sourceRow As DataRow = dv.Item(0).Row                      ' Row to copy from

         ' Copy this row
         For Each fieldNode As TagNode In dataTagNode.TagNodeList
            If fieldNode.IsSaveData Then
               _log.Debug("Copying: " & fieldNode.TagName)
               targetRow(fieldNode.TagName) = sourceRow(fieldNode.TagName)
            End If
         Next

         ' Recalculate targetRow's checksum
         GenerateChecksum(targetRow)
      Else
         _log.Warn("No data row found in Partial datatable. (Expected one)")
      End If

      If childNode.FieldDT.Rows.Count > 1 Then
         _log.Warn("Partial datatable contains more than one data (Expected one)")
      End If

      For Each fieldRow As ScraperTempDS.FieldDTRow In childNode.FieldDT.Rows
         Dim dv As New DataView(dataTagNode.DataDT)
         dv.RowFilter = DataTableUtil.ID & " = " & fieldRow.PID

         If dv.Count = 0 Then
            Console.WriteLine("Data row doesn't exists")
         Else
            Dim row As DataRow = dv(0).Row

            ' Delete the rows
            row.Delete()
         End If
      Next
   End Sub

   ''' <summary>
   ''' Copy Dataset relation to parent root node
   ''' </summary>
   ''' <param name="dataTagNode"></param>
   ''' <param name="dsRow"></param>
   ''' <remarks></remarks>
   Private Sub CopyTableRelations(ByVal dataTagNode As TagNode, ByVal dsRow As DataRow)
      Dim childNode As TagNode = dataTagNode.TagNodeList(0)

      For Each fieldRow As ScraperTempDS.FieldDTRow In childNode.FieldDT.Rows
         Dim dv As New DataView(dataTagNode.DataDT)
         dv.RowFilter = DataTableUtil.ID & " = " & fieldRow.PID

         If dv.Count = 0 Then
            Console.WriteLine("Data row doesn't exists")
         Else
            Dim row As DataRow = dv(0).Row

            For Each rel As Data.DataRelation In dataTagNode.DataDT.ParentRelations
               Dim colName As String = rel.ParentTable.TableName & DataTableUtil.POSTFIX     ' Copy the relations
               row(colName) = dsRow(colName)
            Next

            GenerateChecksum(row)         ' Calculate checksum
         End If
      Next
   End Sub

   ''' <summary>
   ''' Insert Url
   ''' </summary>
   ''' <param name="urlNode"></param>
   ''' <param name="urlRow"></param>
   ''' <remarks></remarks>
   Private Sub InsertUrl(ByVal urlNode As TagNode, ByVal urlRow As ScraperDB.UrlRow)
      Dim datasetDT As DataTable = Me._CrawlProject.Dataset.Tables(DataTableUtil.URL_DATASET_TABLENAME(Me._CrawlProject.CrawlProjectRow.CrawlProjectID))

      Dim linkMapList As List(Of LinkMap) = Me._CrawlProject.LinkMapManager.getLinkMaps(urlNode)

      For Each row As ScraperTempDS.FieldDTRow In urlNode.FieldDT.Rows
         ' Insert a new url to the url list.
         Dim tempURLRow As ScraperDB.UrlRow = Me._CrawlProject.UrlManager.addUrl(row.Data, "", linkMapList)
         tempURLRow.UrlReferer = urlRow.UrlLink             ' TODO: Keep track of referers in a differnt data table.

         If tempURLRow Is Nothing Then
            ' Hit the same page, we need to do some data references - keep track of url tree
            tempURLRow = Me._CrawlProject.UrlManager.findUrl(row.Data, "")
            Me._CrawlProject.UrlManager.addHistory(urlRow, tempURLRow)
         Else
            ' Add to history
            Me._CrawlProject.UrlManager.addHistory(urlRow, tempURLRow)

            ' Add a new row to datasetDT
            Dim dv As New DataView(datasetDT)
            Dim urlID As String = Me._CrawlProject.Dataset.Url.TableName & DataTableUtil.POSTFIX
            dv.RowFilter = urlID & " = " & tempURLRow.UrlID

            Dim dsRow As DataRow
            If dv.Count > 0 Then
               dsRow = dv(0).Row
            Else
               dsRow = datasetDT.NewRow               ' Look for 
               dsRow(urlID) = tempURLRow.UrlID
               datasetDT.Rows.Add(dsRow)
            End If

            ' Copy the relation to the data table that the url come from.
            If urlNode.ParentDataTableTagNode IsNot Nothing Then
               ' Copy the sys parent ID (SYS ID)

               Dim colName As String = urlNode.ParentDataTableTagNode.DataDT.TableName & DataTableUtil.POSTFIX
               dsRow(colName) = row.PID
            End If
         End If
      Next
   End Sub
#End Region

End Class
