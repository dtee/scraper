Imports ScraperLib

Public Class DataMapperControl
   Private _DataMapper As DataMappingManager
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.

   End Sub

   Public Property DataMapper() As DataMappingManager
      Get
         Return Me._DataMapper
      End Get
      Set(ByVal value As DataMappingManager)
         Me._DataMapper = value

         If value IsNot Nothing Then
            Me.MapDatasets()
         Else
            Me.DataMappingTableGridView.DataSource = Nothing
            Me.DataMappingFieldGridView.DataSource = Nothing
         End If
      End Set
   End Property

   Private Sub MapDatasets()
      Me.DataMappingTableTableName.DataPropertyName = Me._DataMapper.TableMaps.TableNameColumn.ColumnName
      Me.DataMappingTableTagName.DataPropertyName = Me._DataMapper.TableMaps.TagNameColumn.ColumnName

      Me.DataMappingTableGridView.AutoGenerateColumns = False
      Me.DataMappingTableGridView.DataSource = Me._DataMapper.TableMaps.DataSet
      Me.DataMappingTableGridView.DataMember = Me._DataMapper.TableMaps.TableName

      Me.DataMappingFieldName.DataPropertyName = Me._DataMapper.FieldMaps.FieldNameColumn.ColumnName
      Me.DataMappingFieldID.DataPropertyName = Me._DataMapper.FieldMaps.IsIdentityColumn.ColumnName
      Me.DataMappingFieldTagName.DataPropertyName = Me._DataMapper.FieldMaps.TagNameColumn.ColumnName
      Me.DataMappingFieldChecksum.DataPropertyName = Me._DataMapper.FieldMaps.IsCheckFieldColumn.ColumnName

      ' Add relation
      Me.DataMappingFieldGridView.AutoGenerateColumns = False
      Me.DataMappingFieldGridView.DataSource = Me._DataMapper.FieldMaps.DataSet        ' Select data set

      ' Add relation
      Me.DataMappingFieldGridView.DataMember = Me._DataMapper.TableMaps.TableName & "." & _
                  Me._DataMapper.TableMaps.ChildRelations(0).RelationName
   End Sub


   Private Sub DataMappingToolStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles DataMappingToolStrip.ItemClicked
      If e.ClickedItem Is Me.GenerateAllToolStripButton Then
         Me._DataMapper.AutoGenerate()
      ElseIf e.ClickedItem Is Me.GenerateToolStripButton Then
      End If
   End Sub
End Class
