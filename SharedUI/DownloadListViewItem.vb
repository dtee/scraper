Imports System.Windows.Forms

Public Class DownloadListViewItem
   Inherits ListViewItem
   Public Header() As String = {"ID", "Url", "Size", "Retry", "Status"}

   Public Sub New()
      Me.SubItems.AddRange(Header)
   End Sub

   Public Property UrlID() As String
      Get
         Return Me.SubItems(0).Text
      End Get
      Set(ByVal value As String)
         Me.SubItems(0).Text = value
      End Set
   End Property

   Public Property Url() As String
      Get
         Return Me.SubItems(1).Text
      End Get
      Set(ByVal value As String)
         Me.SubItems(1).Text = value
      End Set
   End Property


   Public Property Size() As String
      Get
         Return Me.SubItems(2).Text
      End Get
      Set(ByVal value As String)
         Me.SubItems(2).Text = value
      End Set
   End Property

   Public Property Retry() As String
      Get
         Return Me.SubItems(3).Text
      End Get
      Set(ByVal value As String)
         Me.SubItems(3).Text = value
      End Set
   End Property

   Public Property Status() As String
      Get
         Return Me.SubItems(4).Text
      End Get
      Set(ByVal value As String)
         Me.SubItems(4).Text = value
      End Set
   End Property
End Class