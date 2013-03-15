Imports System.Xml

''' <summary>
''' This class takes an XML file and generate
''' the Scraper Project to Scrape information from the XML file
''' </summary>
''' <remarks></remarks>
Public Class XMLTagGenerator
   Private Shared _log As New Log(GetType(UrlManager), True)
   Private _CrawlProject As CrawlProject

   Public Sub New(ByVal crawlProj As CrawlProject)
      Me._CrawlProject = crawlProj
   End Sub

   Public Sub printXML(ByVal xmlFile As String)
      Try
         Dim dom As New System.Xml.XmlDocument
         _log.Debug(IO.File.Exists(xmlFile))

         dom.Load(xmlFile)
         printRecursive(dom.LastChild, "")
      Catch ex As Exception
         _log.Debug(ex.Message)
         _log.Debug(ex.StackTrace)
         Throw ex
      End Try
   End Sub

   Public Sub printRecursive(ByVal rootnode As XmlNode, ByVal space As String)
      Console.WriteLine(space & rootnode.Name)
      space = "   " & space

      For Each ele As XmlAttribute In rootnode.Attributes
         Console.WriteLine(space & ele.Name & "-" & ele.Value)
      Next

      For Each node As Xml.XmlNode In rootnode.ChildNodes
         If node.NodeType = XmlNodeType.Element Then
            printRecursive(node, space)
         ElseIf node.NodeType = XmlNodeType.Attribute Then
         End If
      Next
   End Sub

   Public Sub getProject(ByVal xmlFile As String)
      Dim dom As New System.Xml.XmlDocument
      Dim proj As Project = Me._CrawlProject.ProjectManager.newProject()

      proj.ProjectRow.Name = "XML Prase Project"

      Try
         dom.Load(xmlFile)
         Dim rootNode As TagNode = proj.TagTree.RootNode
         rootNode.Row.TagName = dom.Name

         Me.parseXML(rootNode, dom)

      Catch ex As Exception
         _log.Debug(ex.Message)
         _log.Debug(ex.StackTrace)
         Throw ex
      End Try
   End Sub

   ''' <summary>
   ''' Parse the XML File, creating the tag as it goes
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub parseXML(ByVal tagNode As TagNode, ByVal xmlNode As Xml.XmlNode)

      For Each node As Xml.XmlNode In xmlNode.ChildNodes
         Dim newNode As TagNode = tagNode.NewNode()
         newNode.Row.TagName = node.Name
         newNode.Row.StartTag = node.Name
      Next

      For Each ele As XmlAttribute In xmlNode.Attributes

      Next
   End Sub
End Class
