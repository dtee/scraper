Imports System.Reflection
Imports System.CodeDom.Compiler
Imports System.Text.RegularExpressions
Imports DataRefinerAsm

Public Class DataType
   Private _row As ScraperDB.DataTypeRow

   Public ReadOnly Property Row() As ScraperDB.DataTypeRow
      Get
         Return Me._row
      End Get
   End Property

   Public Sub New(ByVal row As ScraperDB.DataTypeRow)
      Me._row = row
      DataTypeCode = Me._row.DataTypeCode
   End Sub

   Public Property DataTypeCode() As String
      Get
         Return Me._row.DataTypeCode
      End Get
      Set(ByVal value As String)
         ' Compile the object
         Me._row.DataTypeCode = value

         Try
            CompileCode()
         Catch ex As Exception
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.StackTrace)
         End Try
      End Set
   End Property

   ''' <summary>
   ''' Compile the datatype code.
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub CompileCode()
      _dataObject = CompileCode(Row.DataTypeName, Row.DataTypeCode)
   End Sub

   Private Function compileCode(ByVal className As String, ByVal strCode As String) As DataRefiner
      Dim objCodeCompiler As ICodeCompiler = New VBCodeProvider().CreateCompiler
      Dim objCompilerParameters As New CompilerParameters()

      Dim asmUri As New Uri(System.Reflection.Assembly.GetAssembly(GetType(DataRefiner)).CodeBase())
      Dim asmPath As String = Uri.EscapeUriString(asmUri.AbsolutePath)
      asmPath = asmPath.Replace("/", "\\")
      asmPath = Uri.UnescapeDataString(asmUri.AbsolutePath)
      Console.WriteLine(asmPath)

      objCompilerParameters.ReferencedAssemblies.Add("System.dll")
      objCompilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll")
      objCompilerParameters.ReferencedAssemblies.Add(asmPath)

      objCompilerParameters.GenerateInMemory = True

      Dim objCompileResults As CompilerResults = objCodeCompiler.CompileAssemblyFromSource(objCompilerParameters, strCode)
      If objCompileResults.Errors.HasErrors Then
         Throw New Exception("Error: Line>" & objCompileResults.Errors(0).Line.ToString & ", " & objCompileResults.Errors(0).ErrorText)
         Return Nothing
      End If

      Dim objAssembly As System.Reflection.Assembly = objCompileResults.CompiledAssembly
      Dim objTheClass As Object = objAssembly.CreateInstance(className)

      Console.WriteLine("Created Data type: " & System.Reflection.Assembly.GetAssembly(objTheClass.GetType).CodeBase())
      Return objTheClass
   End Function

   Private _dataObject As DataRefiner
   Public ReadOnly Property DataObject() As DataRefiner
      Get
         Return _dataObject
      End Get
   End Property

   Public Property DataTypeName() As String
      Get
         Return Me._row.DataTypeName
      End Get
      Set(ByVal value As String)
         ' Check to see if the datatype name is a valid name
         Me._row.DataTypeName = value
      End Set
   End Property
End Class
