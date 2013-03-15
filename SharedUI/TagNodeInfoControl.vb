Option Explicit On
Option Strict On

Imports ScraperLib
Imports System.Drawing

Public Class TagNodeInfoControl
   Private _CurrentNode As TagTreeNode
   ''' <summary>
   ''' Tag Node: Setting this will 
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property TagTreeNode() As TagTreeNode
      Get
         Return _CurrentNode
      End Get
      Set(ByVal value As TagTreeNode)
         _CurrentNode = value
         If (value IsNot Nothing) Then
            Me.Enabled = True
            populateData()

            If value.TagNode.Row.TagLibraryRowParent Is Nothing Then
               'Me.Enabled = False
               'Me.SaveTagToolStripButton.Enabled = False
               'Me.OptionalToolStripButton.Enabled = False
            Else
               Me.Enabled = True
               Me.SaveTagToolStripButton.Enabled = True
               Me.OptionalToolStripButton.Enabled = True
            End If
         Else
            Me.Enabled = False
            Exit Property
         End If
      End Set
   End Property

   ''' <summary>
   ''' Populate the data.
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub populateData()
      ' Tag Property
      Me.txtName.Text = "" & _CurrentNode.Row.TagName
      Me.txtTagStart.Text = "" & _CurrentNode.Row.StartTag
      Me.txtTagEnd.Text = "" & _CurrentNode.Row.EndTag

      Me.AppendEndStripButton.Checked = _CurrentNode.Row.IsAppendEndTag
      Me.AppendStartStripButton.Checked = _CurrentNode.Row.IsAppendStartTag

      Me.StartRegexStripButton.Checked = _CurrentNode.Row.IsStartTagRegex
      Me.EndRegexToolStripButton.Checked = _CurrentNode.Row.IsEndTagRegex

      ' Options
      Me.txtMaxChars.Text = "" & _CurrentNode.Row.MaxChars
      Me.OptionalToolStripButton.Checked = _CurrentNode.Row.IsOptional
      Me.SingleRegexToolStripButton.Checked = Me._CurrentNode.Row.IsSingleRegex
      Me.RevSearchToolStripButton.Checked = _CurrentNode.Row.IsReverseSearch
      Me.URLToolStripButton.Checked = _CurrentNode.Row.IsURL

      Me.SaveTagToolStripButton.Checked = Me._CurrentNode.Row.isSaveData

      ' Dynamic code

   End Sub

   Private _DataTypeManager As DataTypeManager
   Public Property DataTypeManager() As DataTypeManager
      Get
         Return Me._DataTypeManager
      End Get
      Set(ByVal value As DataTypeManager)
         Me._DataTypeManager = value

         Dim cb As System.Windows.Forms.ComboBox = Me.DataTypeToolStripComboBox.ComboBox
         cb.DataSource = Me._DataTypeManager.DataTypeList

         cb.DisplayMember = "DataTypeName"
      End Set
   End Property

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

      Me._CurrentNode.Row.TagName = Me.txtName.Text
      handleTagNodeRefresh()
   End Sub

   Private Sub txtMaxChars_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMaxChars.TextChanged
      If Me._CurrentNode Is Nothing Then
         Exit Sub
      End If

      Try
         Dim max As Integer = CInt(Me.txtMaxChars.Text)

         If (max > Int16.MaxValue) Then
            Me.txtMaxChars.Text = CStr(Int16.MaxValue)
            max = Int16.MaxValue
         End If

         txtMaxChars.Text = "" & max
         Me._CurrentNode.Row.MaxChars = max
         Me.ErrorProvider1.SetError(Me.txtMaxChars, "")
      Catch ex As Exception
         ' This could never happen...
         Me.ErrorProvider1.SetError(Me.txtMaxChars, "Max Char must be a number.")
      End Try
   End Sub

   Private Sub handleTagNodeRefresh()
      Me._CurrentNode.Refresh()

      If Me._CurrentNode.Row.RowError <> "" Then
         Me.ErrorProvider1.SetError(Me.txtName, Me._CurrentNode.Row.RowError)
      Else
         Me.ErrorProvider1.SetError(Me.txtName, "")
      End If
   End Sub

   Public Overloads Sub Refresh()
      MyBase.Refresh()
      Me.handleTagNodeRefresh()
   End Sub

   Private Sub txtTagStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTagStart.TextChanged
      Me._CurrentNode.Row.StartTag = Me.txtTagStart.Text
   End Sub

   Private Sub txtTagEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTagEnd.TextChanged
      Me._CurrentNode.Row.EndTag = Me.txtTagEnd.Text
   End Sub

   Private Sub SaveTagToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveTagToolStripButton.Click
      Me._CurrentNode.TagNode.IsSaveData = Me.SaveTagToolStripButton.Checked
      handleTagNodeRefresh()
   End Sub

   Private Sub OptionalToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionalToolStripButton.Click
      Me._CurrentNode.Row.IsOptional = Me.OptionalToolStripButton.Checked
   End Sub

   Private Sub URLToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles URLToolStripButton.Click
      Me._CurrentNode.Row.IsURL = Me.URLToolStripButton.Checked
   End Sub

   Private Sub AppendStartStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendStartStripButton.Click
      Me._CurrentNode.Row.IsAppendStartTag = Me.AppendStartStripButton.Checked
   End Sub

   Private Sub StartRegexStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartRegexStripButton.Click
      Me._CurrentNode.Row.IsStartTagRegex = Me.StartRegexStripButton.Checked
   End Sub

   Private Sub AppendEndStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AppendEndStripButton.Click
      Me._CurrentNode.Row.IsAppendEndTag = AppendEndStripButton.Checked
   End Sub

   Private Sub EndRegexToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndRegexToolStripButton.Click
      Me._CurrentNode.Row.IsEndTagRegex = EndRegexToolStripButton.Checked
   End Sub

   Private Sub SingleRegexToolStripButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SingleRegexToolStripButton.CheckedChanged
      Me._CurrentNode.Row.IsSingleRegex = SingleRegexToolStripButton.Checked

      If (Me._CurrentNode.Row.IsSingleRegex) Then
         Me.lblStart.Text = "Regex "
         Me.txtTagStart.Height = 70

         Me.lblStop.Visible = False
         Me.txtTagEnd.Visible = False

         Me.AppendStartStripButton.Enabled = False
         Me.StartRegexStripButton.Enabled = False

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
      End If
   End Sub

   Private Sub RevSearchToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RevSearchToolStripButton.Click
      Me._CurrentNode.Row.isReverseSearch = Me.RevSearchToolStripButton.Checked
   End Sub
#End Region

   Private Sub DataTypeToolStripComboBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataTypeToolStripComboBox.Click

   End Sub
End Class
