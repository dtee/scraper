Option Explicit On
Option Strict On

Public Class TagNodeAdvView
   Private _CurrentNode As TagNode
   ''' <summary>
   ''' Tag Node: Setting this will 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TagNode() As TagNode
      Get
         Return _CurrentNode
      End Get
      Set(ByVal value As TagNode)
         If Me._CurrentNode Is value Then
            Exit Property
         End If

         _CurrentNode = value
         If (value IsNot Nothing) Then
            populateData()
            Me.Enabled = True
         Else
            Me.Enabled = False
         End If

         If value.IsRootTagNode Then
            Me.Enabled = False
            Me.SaveTagToolStripButton.Enabled = False
            Me.OptionalToolStripButton.Enabled = False
         Else
            Me.Enabled = True
            Me.SaveTagToolStripButton.Enabled = True
            Me.OptionalToolStripButton.Enabled = True
         End If
      End Set
   End Property

   ''' <summary>
   ''' Populate the data.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub populateData()
      ' Tag Property
      Me.txtName.Text = "" & _CurrentNode.TagName
      Me.txtTagStart.Text = "" & _CurrentNode.StartTag
      Me.txtTagEnd.Text = "" & _CurrentNode.EndTag

      Me.AppendEndStripButton.Checked = _CurrentNode.IsAppendEndTag
      Me.AppendStartStripButton.Checked = _CurrentNode.IsAppendStartTag

      Me.StartRegexStripButton.Checked = _CurrentNode.IsStartTagRegex
      Me.EndRegexToolStripButton.Checked = _CurrentNode.IsEndTagRegex

      ' Options
      Me.txtMaxChars.Text = "" & _CurrentNode.MaxChars
      Me.OptionalToolStripButton.Checked = _CurrentNode.IsOptional
      Me.SingleRegexToolStripButton.Checked = Me._CurrentNode.IsSingleRegex
      Me.RevSearchToolStripButton.Checked = _CurrentNode.IsReverseSearch
      Me.URLToolStripButton.Checked = _CurrentNode.IsURL

      Me.SaveTagToolStripButton.Checked = _CurrentNode.IsSaveData
      Me.SharedTagToolStripButton.Checked = _CurrentNode.IsSharedTag

      ' Dynamic code
      'Me.chkIsTrim.Checked = _CurrentNode.IsTrim
      'Me.txtDynamicCode.Text = _CurrentNode.DynamicCode
   End Sub

#Region "VALIDATE FIELDS - Key press Maxchar and name"
   ' ONLY NUMBERS ARE ALLOWED
   Private Sub txtMaxChars_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxChars.KeyPress
      'Restirct user to key numeric values, decimal point and control keys
      If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) _
            And Not e.KeyChar = "." Then
         e.Handled = True
      Else
         ' allow only one decimal point in textbox
         If e.KeyChar = "." And Me.txtMaxChars.Text.IndexOf(".") <> -1 Then
            e.Handled = True
         End If
      End If
   End Sub

   'DO NOT ALLOW USER TO ADD SPACE in Name field
   Private Sub txtName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtName.KeyPress
      'Restirct user to key numeric values, decimal point and control keys
      If Char.IsSymbol(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
         e.Handled = True
      End If
   End Sub
#End Region

#Region "Item Value Changed"
   Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
      If Me._CurrentNode Is Nothing Then
         Exit Sub
      End If

      Me._CurrentNode.Text = Me.txtName.Text

      If Me.txtName.Text = "" Then
         Me.ErrorProvider1.SetError(Me.txtName, "Invalid Name, must contains at least one char.")
      ElseIf Not Me._CurrentNode.IsTagNameValid Then
         Me.ErrorProvider1.SetError(Me.txtName, "Invalid Name, tree will contain duplicate names.")
      Else
         Me.ErrorProvider1.SetError(Me.txtName, "")
      End If
   End Sub

   Private Sub txtMaxChars_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaxChars.TextChanged
      If Me._CurrentNode Is Nothing Then
         Exit Sub
      End If

      If Me.txtMaxChars.Text = "" Then
         Me.txtMaxChars.Text = "0"
      End If

      Try
         Dim max As Integer = CInt(Me.txtMaxChars.Text)

         If (max > Int16.MaxValue) Then
            Me.txtMaxChars.Text = CStr(Int16.MaxValue)
            max = Int16.MaxValue
         End If

         Me._CurrentNode.MaxChars = max
         Me.ErrorProvider1.SetError(Me.txtMaxChars, "")
      Catch ex As Exception
         Me.ErrorProvider1.SetError(Me.txtMaxChars, "Max Char must be a number.")
      End Try
   End Sub

   Private Sub txtTagStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTagStart.TextChanged
      Me._CurrentNode.StartTag = Me.txtTagStart.Text
   End Sub

   Private Sub txtTagEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTagEnd.TextChanged
      Me._CurrentNode.EndTag = Me.txtTagEnd.Text
   End Sub

   Private Sub SaveTagToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTagToolStripButton.Click
      Me._CurrentNode.IsSaveData = Me.SaveTagToolStripButton.Checked
   End Sub

   Private Sub OptionalToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionalToolStripButton.Click
      Me._CurrentNode.IsOptional = Me.OptionalToolStripButton.Checked
   End Sub

   Private Sub URLToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles URLToolStripButton.Click
      Me._CurrentNode.IsURL = Me.URLToolStripButton.Checked
   End Sub

   Private Sub AppendStartStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendStartStripButton.Click
      Me._CurrentNode.IsAppendStartTag = Me.AppendStartStripButton.Checked
   End Sub

   Private Sub StartRegexStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartRegexStripButton.Click
      Me._CurrentNode.IsStartTagRegex = Me.StartRegexStripButton.Checked
   End Sub

   Private Sub AppendEndStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendEndStripButton.Click
      Me._CurrentNode.IsAppendEndTag = AppendEndStripButton.Checked
   End Sub

   Private Sub EndRegexToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndRegexToolStripButton.Click
      Me._CurrentNode.IsEndTagRegex = EndRegexToolStripButton.Checked
   End Sub

   Private Sub SingleRegexToolStripButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SingleRegexToolStripButton.CheckedChanged
      Me._CurrentNode.IsSingleRegex = SingleRegexToolStripButton.Checked

      If (Me._CurrentNode.IsSingleRegex) Then
         Me.lblStart.Text = "Regex "
         Me.txtTagStart.Height = 70

         Me.lblStop.Visible = False
         Me.txtTagEnd.Visible = False

         Me.AppendStartStripButton.Enabled = False
         Me.StartRegexStripButton.Enabled = False

         Me.AppendEndStripButton.Enabled = False
         Me.EndRegexToolStripButton.Enabled = False
         Me.SharedTagToolStripButton.Enabled = False
      Else
         Me.lblStart.Text = "Start"
         Me.txtTagStart.Height = 32

         Me.lblStop.Visible = True
         Me.txtTagEnd.Visible = True

         Me.AppendStartStripButton.Enabled = True
         Me.AppendEndStripButton.Enabled = True
         Me.StartRegexStripButton.Enabled = True
         Me.EndRegexToolStripButton.Enabled = True
         Me.SharedTagToolStripButton.Enabled = True
      End If
   End Sub

   Private Sub RevSearchToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevSearchToolStripButton.Click
      Me._CurrentNode.IsReverseSearch = Me.RevSearchToolStripButton.Checked
   End Sub
#End Region

   Private Sub SharedTagToolStripButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SharedTagToolStripButton.CheckedChanged
      Me._CurrentNode.IsSharedTag = SharedTagToolStripButton.Checked
      If (Me._CurrentNode.IsSharedTag) Then
         Me.txtTagStart.Height = 70

         Me.lblStop.Visible = False
         Me.txtTagEnd.Visible = False

         'Me.AppendStartStripButton.Enabled = False
         'Me.StartRegexStripButton.Enabled = False

         Me.SingleRegexToolStripButton.Enabled = False
         Me.AppendEndStripButton.Enabled = False
         Me.EndRegexToolStripButton.Enabled = False
      Else
         Me.lblStart.Text = "Start"
         Me.txtTagStart.Height = 32

         Me.lblStop.Visible = True
         Me.txtTagEnd.Visible = True

         Me.AppendStartStripButton.Enabled = True
         Me.AppendEndStripButton.Enabled = True
         Me.StartRegexStripButton.Enabled = True
         Me.EndRegexToolStripButton.Enabled = True
         Me.SingleRegexToolStripButton.Enabled = True
      End If
   End Sub

   Private Sub SharedTagToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SharedTagToolStripButton.Click

   End Sub
End Class
