Imports System.Windows.Forms

Public Class DataFieldUI

   Private _dt As WizardDS.FieldDTDataTable
   Public Sub New(ByVal DT As WizardDS.FieldDTDataTable)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      Me.DataGridView1.AutoGenerateColumns = False

      Me.FieldName.DataPropertyName = "FieldName"
      Me.MaxChars.DataPropertyName = "MaxChars"
      Me.IsSaveData.DataPropertyName = "IsSaveData"

      ' Add any initialization after the InitializeComponent() call.
      Me.DataGridView1.DataSource = DT
      Me._dt = DT

      Me.TextBox1.Text = DT.TableName
   End Sub

   Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
      If _dt.Rows.Count = 0 Then
         MsgBox("Must have at least one column to generate.", MsgBoxStyle.Information)
      Else
         Me._dt.TableName = Me.TextBox1.Text
         Me.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.Close()
      End If
   End Sub

   Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub DataFieldUI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub
End Class
