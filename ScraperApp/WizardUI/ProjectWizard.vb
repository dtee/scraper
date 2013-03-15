Public Class ProjectWizard
   Private FieldDT As WizardDS.FieldDTDataTable
   Private DataDT As DataTable

   Private ctlEditText As ctlEditText
   Private ctlEditData As ctlEditData
   Private ctlEditColumn As ctlEditColumn
   Private rtb As ctlResult

   Private TagNode As TagNode

   Public Sub New(ByVal node As TagNode, ByVal text As String)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      FieldDT = New WizardDS.FieldDTDataTable
      rtb = New ctlResult
      ctlEditData = New ctlEditData
      ctlEditColumn = New ctlEditColumn(Me.FieldDT)

      If node.ScraperNode Is Nothing Then
         ctlEditText = New ctlEditText(Nothing)
         ctlEditText.Text = text
      Else
         ctlEditText = New ctlEditText(node.ScraperNode.FieldDT)
         If ctlEditText.Text = "" Then
            ctlEditText.Text = text
         End If
      End If

      Me.ctlEditColumn.TableName = node.TagName

      Me.CtlWizard1.AddControl(ctlEditText, "Step 1.", "Enter Sample Data")
      Me.CtlWizard1.AddControl(ctlEditColumn, "Step 2.", "Enter Datatable Information")
      Me.CtlWizard1.AddControl(ctlEditData, "Step 3.", "Enter Sample Data")
      Me.CtlWizard1.AddControl(rtb, "Results", "Tag Library Generator Result.")

      TagNode = node
   End Sub

   ''' <summary>
   ''' Nothing to do when it's finished. (User may cancel which would cause this to delete all nodes generated
   ''' </summary>
   ''' <remarks></remarks>
   Private Sub CtlWizard1_FinishNavigation() Handles CtlWizard1.FinishNavigation
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

#Region "Handle Wizard Events"
   Private Sub CtlWizard1_ValidateInput(ByVal cnt As System.Windows.Forms.Control) Handles CtlWizard1.ValidateInput
      ' 1.) User enter/pick data from the list
      If (cnt Is Me.ctlEditText) Then
         If Me.ctlEditText.Text = "" Then
            Me.CtlWizard1.ErrorMessage.AppendLine("Please enter sample text.")
         End If
      End If

      ' 1.) User enter Tables/Project Info
      If (cnt Is Me.ctlEditColumn) Then
         ' Validate the data fields, make sure its' greater than 1

         If (Me.ctlEditColumn.TableName = "") Then
            Me.CtlWizard1.ErrorMessage.AppendLine("Data Table must have a valid name.")
         Else
            Me.FieldDT.TableName = Me.ctlEditColumn.TableName
         End If

         If (Me.FieldDT.Rows.Count = 0) Then
            Me.CtlWizard1.ErrorMessage.AppendLine("Data Table must have at least one field.")
         End If

         ' Everything is ok - change the nex control box (Data File)
         If Me.CtlWizard1.ErrorMessage.Length = 0 Then
            ctlEditData.FieldTable = Me.FieldDT
         End If
      End If

      ' User enter sample url and sample Data
      If (cnt Is Me.ctlEditData) Then
         If Me.ctlEditData.DataDT.Rows.Count = 0 Then
            Me.CtlWizard1.ErrorMessage.AppendLine("Must have at least one sample data.")
            Exit Sub
         End If

         ' Try to Generate the library from the given url
         ' There will be a few error, such as list of rows that could not be found on the given Text
         If Me.CtlWizard1.ErrorMessage.Length = 0 Then
            Dim CoreGen As New CoreTagGenerator(Me.ctlEditText.Text, Me.ctlEditData.DataDT, Me.TagNode)
            Me.DataDT = ctlEditData.DataDT
            Me.ctlEditData.DataGridView1.Refresh()

            ' 1.) Check the rows to see if they can be with in the given text, if not, this is an error
            If Not CoreGen.IsValid() Then
               Me.ctlEditData.DataGridView1.Refresh()
               If MsgBox("Some of the data does not exist in the text. Continue anyway?", _
                  MsgBoxStyle.YesNo, "Notice") = MsgBoxResult.No Then
                  Exit Sub
               End If
            End If

            Try
               CoreGen.Generate()
               rtb.Text = "Successfully Generated Tags"
            Catch ex As Exception
               rtb.Text = ex.Message & ControlChars.NewLine
               rtb.Text = ex.Message
            End Try
         End If
      End If
   End Sub
#End Region

   Private Sub OnCancel() Handles CtlWizard1.CancelNavigation
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub
End Class