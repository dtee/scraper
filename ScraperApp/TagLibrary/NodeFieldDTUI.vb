Public Class NodeFieldDTUI
   Public Event RowIndexChanged(ByVal newIndex As ScraperTempDS.FieldDTRow)
   Public Event Event_Closing()

   Private _TagNode As TagNode
   Public Property TagNode() As TagNode
      Get
         Return _TagNode
      End Get
      Set(ByVal value As TagNode)
         Me._TagNode = value

         If Me._TagNode IsNot Nothing Then
            Me.FieldDT = value.FieldDT
         End If
      End Set
   End Property

   Private _FieldDT As ScraperTempDS.FieldDTDataTable
   Private Property FieldDT() As ScraperTempDS.FieldDTDataTable
      Get
         Return _FieldDT
      End Get
      Set(ByVal value As ScraperTempDS.FieldDTDataTable)
         _FieldDT = value

         ViewAllToolStripMenuItem.Checked = False
         ViewAllToolStripMenuItem_CheckedChanged(Nothing, Nothing)

         'no adding of new rows thru dataview...
         If value Is Nothing Then Exit Property
         Dim cm As CurrencyManager = CType(Me.BindingContext(DataGridView1.DataSource, DataGridView1.DataMember), CurrencyManager)
      End Set
   End Property

   Public Sub New()
      InitializeComponent()
   End Sub

   Private _IsExit As Boolean
   Public Property IsExit() As Boolean
      Get
         Return _IsExit
      End Get
      Set(ByVal value As Boolean)
         _IsExit = value
         Me.Close()
      End Set
   End Property

   Private Sub ScrapedFieldDTView_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      If Me._IsExit = False Then
         Me.Visible = False
         e.Cancel = True
         RaiseEvent Event_Closing()
      End If
   End Sub

   Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
      For Each r As Windows.Forms.DataGridViewRow In Me.DataGridView1.SelectedRows
         Dim row As System.Data.DataRowView = r.DataBoundItem

         If Me.AutoScrollToolStripMenuItem.Checked Then
            RaiseEvent RowIndexChanged(row.Row)
         End If
         Exit Sub
      Next
   End Sub

   Private Sub ViewAllToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewAllToolStripMenuItem.CheckedChanged
      Me.DataGridView1.Columns.Clear()
      Me.DataGridView1.Columns.Add(Me.Data)
      Me.DataGridView1.DataSource = _FieldDT
      Me.Data.DataPropertyName = "Data"
      Me.DataGridView1.AutoGenerateColumns = ViewAllToolStripMenuItem.Checked
   End Sub
End Class