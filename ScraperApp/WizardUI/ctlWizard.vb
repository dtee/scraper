Imports System.Text

Public Class ctlWizard

#Region "Events"
   Public Event ValidateInput(ByVal cnt As Windows.Forms.Control)
   Public Event FinishNavigation()
   Public Event CancelNavigation()
#End Region

   Public ErrorMessage As New StringBuilder
   Private isADD As Boolean = False

#Region "Property"
   Private mPanelList As New ArrayList

   ''' <summary>
   ''' Clear the panel list
   ''' </summary>
   ''' <remarks></remarks>
   Public Sub ClearPanels()
      Me.mPanelList.Clear()
   End Sub

   ''' <summary>
   ''' Addwizard panel
   ''' </summary>
   ''' <param name="cnt"></param>
   ''' <remarks></remarks>
   Public Sub AddControl(ByVal cnt As Windows.Forms.Control, ByVal title As String, ByVal description As String)
      Dim info As New ControlInfo(title, description)

      cnt.Tag = info
      Me.mPanelList.Add(cnt)

      ' Refresh the display - mainly buttons
      isADD = True            ' Disable event raising.
      Me.CurrentIndex = Me.CurrentIndex

      isADD = False
   End Sub

   ''' <summary>
   ''' Remove wizard panel
   ''' </summary>
   ''' <param name="cnt"></param>
   ''' <remarks></remarks>
   Public Sub RemoveControl(ByVal cnt As Windows.Forms.Control)
      Try
         Me.mPanelList.Remove(cnt)

         ' Refresh the display - mainly buttons
         Me.CurrentIndex = Me.CurrentIndex
      Catch ex As Exception
         ' do nothing
         Console.WriteLine(ex.StackTrace)
      End Try
   End Sub

   Private mCurrentIndex As Integer
   ''' <summary>
   ''' Zero based wizard panel index. Changing this index will cause it to change the current wizard
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property CurrentIndex() As Integer
      Get
         Return mCurrentIndex
      End Get
      Set(ByVal value As Integer)
         ' is the new index valid?
         If (mCurrentIndex >= Me.mPanelList.Count) Then
            Return
         End If

         ' Signal to validate the inputs (do not validate if you are going back!
         If Me.navPanel.Controls.Count > 0 And Not isADD And (value > mCurrentIndex) Then
            RaiseEvent ValidateInput(Me.navPanel.Controls(0))
         End If

         If ErrorMessage.Length > 0 Then
            MessageBox.Show(ErrorMessage.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorMessage = New StringBuilder
            return
         End If

         mCurrentIndex = value

         ' Index is valid, change the control
         Dim info As ControlInfo = CType(CType(mPanelList(mCurrentIndex), Control).Tag, ControlInfo)
         Dim pan As Windows.Forms.Control = CType(mPanelList(mCurrentIndex), Control)

         pan.Dock = DockStyle.Fill
         Me.lblDescription.Text = info.Description
         Me.lblTitle.Text = info.Title

         ' Clear the current wizard panel
         Me.navPanel.Controls.Clear()

         ' Set the new panel
         Me.navPanel.Controls.Add(pan)

         Me.btnBack.Enabled = True
         Me.btnNext.Enabled = True

         ' Change the button Status
         If (mCurrentIndex = 0) Then
            Me.btnBack.Enabled = False
         End If

         If (Me.mCurrentIndex = Me.mPanelList.Count - 1) Then
            Me.btnNext.Enabled = False
         End If

         If (Me.mCurrentIndex = mFinishIndex) Then
            Me.btnFinish.Enabled = True
         Else
            Me.btnFinish.Enabled = False
         End If
      End Set
   End Property

   Private mFinishIndex As Integer
   ''' <summary>
   ''' Finish index indicate when the wizard is okay to be finished.
   ''' </summary>
   ''' <value></value>
   ''' <returns></returns>
   ''' <remarks></remarks>
   Public Property FinishIndex() As Integer
      Get
         Return mFinishIndex
      End Get
      Set(ByVal value As Integer)
         ' Invalid value, don't set it
         If (value < 0 Or value >= Me.mPanelList.Count - 1) Then
            mFinishIndex = Me.mPanelList.Count - 1
         Else
            mFinishIndex = value
         End If
      End Set
   End Property
#End Region

#Region "Button Clicks"
   Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
      Me.CurrentIndex -= 1
   End Sub

   Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
      Me.CurrentIndex += 1
   End Sub

   Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
      RaiseEvent FinishNavigation()
   End Sub

   Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
      RaiseEvent CancelNavigation()
   End Sub
#End Region

   Private Class ControlInfo
      Public Title As String
      Public Description As String

      Public Sub New(ByVal title As String, ByVal description As String)
         Me.Title = title
         Me.Description = description
      End Sub
   End Class

   Private Sub ctlWizard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub
End Class

