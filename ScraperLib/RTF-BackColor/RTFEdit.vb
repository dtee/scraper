Imports System.Text

Public Class RTFEdit
   Private header As String
   Private textSection As String

   Private colorTable As New ArrayList
   Private toDoTable As New ArrayList

   Private textTag() As RTFTag

   Private _text As String
   Public Property Text() As String
      Get
         Return _text
      End Get
      Set(ByVal value As String)
         _text = value
         If value IsNot Nothing AndAlso value.Length > 0 Then
            ReDim textTag(_text.Length - 1)

            For i As Integer = 0 To textTag.Length - 1
               textTag(i) = New RTFTag
            Next
         End If
      End Set
   End Property

   ''' <summary>
   ''' Return the RTF text equalvialnce... 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks>
   ''' Does not work, have Error with newline?</remarks>
   Public ReadOnly Property RTFText() As String
      Get
         If Me.Text = "" Or Me.Text Is Nothing Then
            Return ""
         End If

         Dim str As New StringBuilder

         Dim lastTag As RTFTag = Nothing
         Dim tag As String = generateHeader(textTag(0))

         str.Append(Me.generateColorTable())


         lastTag = textTag(0)
         str.Append(generateHeader(textTag(0)))
         str.Append(_text(0))
         For i As Integer = 1 To _text.Length - 1
            ' Generate header and append
            If (Not textTag(i).Equals(lastTag)) Then
               If (Not lastTag Is Nothing) Then
                  ' Close it
                  str.Append("}")
               End If

               lastTag = textTag(i)
               str.Append(generateHeader(textTag(i)))
            End If

            '            \bullet   	 149  	 0xA5
            '\endash 	150 	0xD1
            '\emdash 	151 	0xD0
            '\lquote 	145 	0xD4
            '\rquote 	146 	0xD5
            '\ldblquote 	147 	0xD2
            '\rdblquote 	148 	0xD3

            ' Append the text
            Select Case _text(i)
               Case ControlChars.CrLf
                  str.AppendLine("\par")
               Case ControlChars.Lf
                  str.AppendLine("\par")
               Case ControlChars.Cr
                  str.AppendLine("\par")
               Case ControlChars.Tab
                  str.Append("\tab")
               Case Chr(149)
                  str.Append("\bullet")
               Case Chr(150)
                  str.Append("\endash")
               Case Chr(151)
                  str.Append("\emdash")
               Case Chr(145)
                  str.Append("\lquote")
               Case Chr(146)
                  str.Append("\rquote")
               Case Chr(147)
                  str.Append("\ldblquote")
               Case Chr(148)
                  str.Append("\rdblquote")
               Case Else
                  str.Append(_text(i))
            End Select

            If (i = _text.Length - 1) Then
               str.Append("}")
            End If
         Next
         str.Append("}")

         ' End RTF
         Return str.ToString
      End Get
   End Property

   ''' <summary>
   ''' Generate the rtf headers
   ''' </summary>
   ''' <param name="tag"></param>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Private Function generateHeader(ByVal tag As RTFTag) As String
      Dim str As String = "{" & String.Format("\cf{1}\highlight{0}", tag.backColorIndex, tag.colorIndex)
      ' Bold or not
      If tag.isBold Then str &= "\b"

      str &= " "
      Return str
   End Function


   Private Function generateColorTable() As String
      Dim str As New StringBuilder
      str.Append("{\rtf1\ansi\ansicpg1252\deff0\deflang1033")
      str.Append("{\colortbl;")

      For Each c As Color In Me.colorTable
         str.Append(String.Format("\red{0}\green{1}\blue{2};", c.R, c.G, c.B))
      Next

      str.Append("}")
      Return str.ToString
   End Function

   ''' <summary>
   ''' Change color.
   ''' </summary>
   ''' <param name="iStart"></param>
   ''' <param name="iStop"></param>
   ''' <param name="color"></param>
   ''' <remarks></remarks>
   Public Sub changeColor(ByVal iStart As Integer, ByVal iStop As Integer, ByVal color As Color)
      If (iStart >= Me._text.Length Or iStart < 0) Then
         Return
      End If

      If (iStop < iStart) Then
         Return
      End If

      If (iStop >= Me._text.Length) Then
         iStop = Me._text.Length - 1
      End If

      Dim cIndex As Integer = getColorIndex(color)
      For i As Integer = iStart To iStop
         textTag(i).colorIndex = cIndex
      Next
   End Sub

   ''' <summary>
   ''' Color the background of the text. 
   ''' </summary>
   ''' <param name="iStart"></param>
   ''' <param name="iStop"></param>
   ''' <param name="color"></param>
   ''' <remarks>
   ''' This function works but is not using the most efficent method... 
   ''' </remarks>
   Public Sub changeBackground(ByVal iStart As Integer, ByVal iStop As Integer, ByVal color As Color)
      If (iStart >= Me._text.Length Or iStart < 0) Then
         Return
      End If

      If (iStop < iStart) Then
         Return
      End If

      If (iStop >= Me._text.Length) Then
         iStop = Me._text.Length - 1
      End If

      Dim cIndex As Integer = getColorIndex(color)
      For i As Integer = iStart To iStop
         textTag(i).backColorIndex = cIndex
      Next
   End Sub

   ''' <summary>
   ''' Change boldness of the selected text
   ''' </summary>
   ''' <param name="iStart"></param>
   ''' <param name="iStop"></param>
   ''' <param name="isBold"></param>
   ''' <remarks></remarks>
   Public Sub changeBold(ByVal iStart As Integer, ByVal iStop As Integer, ByVal isBold As Boolean)
      If (iStart >= Me._text.Length Or iStart < 0) Then
         Return
      End If

      If (iStop < iStart) Then
         Return
      End If

      If (iStop >= Me._text.Length) Then
         iStop = Me._text.Length - 1
      End If

      For i As Integer = iStart To iStop
         textTag(i).isBold = isBold
      Next
   End Sub

   Private Function getColorIndex(ByVal c As Color) As Integer
      Dim index As Integer = 0

      For Each co As Color In colorTable
         index += 1
         If (co.Equals(c)) Then
            Return index
         End If
      Next

      Return colorTable.Add(c) + 1
   End Function

   Private Class RTFTag
      Public colorIndex As Integer
      Public backColorIndex As Integer
      Public isBold As Boolean = False

      Public Overloads Function Equals(ByVal target As RTFTag) As Boolean
         If target Is Nothing Then
            Exit Function
         End If

         If target.colorIndex <> Me.colorIndex Then
            Return False
         End If

         If target.backColorIndex <> Me.backColorIndex Then
            Return False
         End If

         If target.isBold <> Me.isBold Then
            Return False
         End If
         Return True
      End Function

   End Class
End Class
