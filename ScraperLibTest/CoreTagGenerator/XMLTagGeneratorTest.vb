Imports System
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ScraperLib

<TestClass()> Public Class XMLTagGeneratorTest

#Region "Additional test attributes"
   '
   ' You can use the following additional attributes as you write your tests:
   '
   ' Use ClassInitialize to run code before running the first test in the class
   ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
   ' End Sub
   '
   ' Use ClassCleanup to run code after all tests in a class have run
   ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
   ' End Sub
   '
   ' Use TestInitialize to run code before running each test
   <TestInitialize()> Public Sub MyTestInitialize()
      _XMLTagGenerator = New XMLTagGenerator(Nothing)
   End Sub
   '
   ' Use TestCleanup to run code after each test has run
   ' <TestCleanup()> Public Sub MyTestCleanup()
   ' End Sub
   '
#End Region
   Private _XMLTagGenerator As XMLTagGenerator

   <TestMethod()> Public Sub TestPrint()
      ' TODO: Add test logic here
      Me._XMLTagGenerator.printXML("CoreTagGenerator\XMLFile1.xml")
   End Sub

End Class
