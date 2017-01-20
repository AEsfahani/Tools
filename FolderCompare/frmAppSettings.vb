Option Explicit On
Option Strict On
Imports ProvideX.ScriptClass
Public Class frmAppSettings

    Private valMgr As New CommonRoutines.ValidationManager()
    Private cr As New CommonRoutines()
    Private fmgr As New FileMgr()
    '' Private appConfig As New Accounting.Framework.AppConfig()
    Public MAS90path As String
    

    Private Sub frmAppSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Dim SOTAMAS90Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\ODBC\ODBC.INI\SOTAMAS90")
            Dim InitPath2 = SOTAMAS90Key.GetValue("Directory")
            'Dim path As String
            MAS90path = CStr(InitPath2)

            ''InitPath2 = InitPath2 + "\Home"
            ''InitPath2 = TextBox1.Text


        Catch ex As Exception
            MsgBox("Sorry the program could not retrieve the path to your MAS90\Home folder " & "Please close the program and first log in MAS90 or 200 and then launch this application." & vbCrLf & "Note: At the moment this application does not work with MAS200 SQL")
            'Maybe = "Y"

        End Try
        Try
            PopulateDefaults()
        Catch ex As Exception
            cr.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try


    End Sub


    Private Sub txtFromEmailAddr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFromEmailAddr.Validating

        If String.IsNullOrEmpty(txtFromEmailAddr.Text) Then
            'Do nothing and allow form validation to handle
            ErrorProvider1.Clear()
            Return
        End If

        If valMgr.ValidateEmailAddress(txtFromEmailAddr.Text.ToString()) = False Then
            ErrorProvider1.SetError(txtFromEmailAddr, Constants.kInvalidEmailAddr)
            e.Cancel = True
            Return
        Else
            ErrorProvider1.Clear()
        End If

    End Sub

    Private Sub txtDfltToEmailAddr_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDfltToEmailAddr.Validating

        If String.IsNullOrEmpty(txtDfltToEmailAddr.Text) Then
            'Do nothing and allow form validation to handle
            ErrorProvider1.Clear()
            Return
        End If

        If valMgr.ValidateEmailAddress(txtDfltToEmailAddr.Text.ToString()) = False Then
            'cr.ShowMessageBox(constants.kInvalidEmailAddr, _
            '                  MessageBoxIcon.Information, _
            '                  MessageBoxButtons.OK)

            ErrorProvider1.SetError(txtDfltToEmailAddr, Constants.kInvalidEmailAddr)
            e.Cancel = True
            Return
        Else
            ErrorProvider1.Clear()
        End If

    End Sub


    Private Sub frmAppSettings_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating

        If ValidateRequiredFields() = False Then
            e.Cancel = True
            Return
        End If


    End Sub

    Private Function ValidateRequiredFields() As Boolean
        If String.IsNullOrEmpty(txtDfltToEmailAddr.Text) Then
            'Do nothing and allow form validation to handle
            ErrorProvider1.SetError(txtDfltToEmailAddr, String.Format(Constants.kRequiredFields, "Default Email Address"))
            Return False
        End If

        If String.IsNullOrEmpty(txtFromEmailAddr.Text) Then
            'Do nothing and allow form validation to handle
            ErrorProvider1.SetError(txtFromEmailAddr, String.Format(Constants.kRequiredFields, "Default Email Address"))
            Return False
        End If

        Return True
    End Function


    Private Sub miSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SaveSettings()
    End Sub

    Private Sub PopulateDefaults()
        txtDfltToEmailAddr.Text = My.Settings.DefaultToEmail
        txtFromEmailAddr.Text = My.Settings.DefaultFromEmail
        txtFirstName.Text = My.Settings.FirstName
        txtLastName.Text = My.Settings.LastName

        If Not String.IsNullOrEmpty(My.Settings.DefaultFolderToCompare) Then
            'We already have a default value
            txtDefaultFolderToCompare.Text = My.Settings.DefaultFolderToCompare
        Else
            'String is empty, so set a default value where MAS 90 is installed
            My.Settings.DefaultFolderToCompare = MAS90path
            'My.Settings.DefaultFolderToCompare = appConfig.LocalPath()
            txtDefaultFolderToCompare.Text = My.Settings.DefaultFolderToCompare
            My.Settings.Save()
        End If

    End Sub

    Private Function SaveSettings() As Boolean
        Dim blnSaveSucceeded As Boolean = False

        My.Settings.FirstName = txtFirstName.Text.Trim()
        My.Settings.LastName = txtLastName.Text.Trim()
        My.Settings.DefaultFromEmail = txtFromEmailAddr.Text.Trim()
        My.Settings.DefaultToEmail = txtDfltToEmailAddr.Text.Trim()

        If Not String.IsNullOrEmpty(txtDefaultFolderToCompare.Text.Trim()) Then
            Dim di As New System.IO.DirectoryInfo(txtDefaultFolderToCompare.Text.Trim())
            If di.Exists = True Then
                My.Settings.DefaultFolderToCompare = txtDefaultFolderToCompare.Text.Trim()
            Else
                Throw New System.IO.DirectoryNotFoundException("Folder " _
                    & di.FullName & " does not exist. This setting will be cleared")
                My.Settings.DefaultFolderToCompare = ""
            End If
        End If

        Dim strFromEmail As String = txtFromEmailAddr.Text
        Dim strToEmail As String = txtDfltToEmailAddr.Text
        Dim intValidationResponse As Integer = -1

        intValidationResponse = valMgr.ValidateEmailOkToSend(strFromEmail, strToEmail)

        Select Case intValidationResponse
            Case Constants.EmailValidation.EmailIsValid
                ' Do nothing, allow save to happen
            Case Constants.EmailValidation.InvalidFromAddress
                cr.ShowMessageBox(Constants.kFromEmailRequired, _
                                  MessageBoxIcon.Information, _
                                  MessageBoxButtons.OK)

                blnSaveSucceeded = False
                Return blnSaveSucceeded

            Case Constants.EmailValidation.InvalidToAddress
                cr.ShowMessageBox(Constants.kToEmailRequired, _
                  MessageBoxIcon.Information, _
                  MessageBoxButtons.OK)

                blnSaveSucceeded = False
                Return blnSaveSucceeded


            Case Else
                cr.ShowMessageBox(Constants.kFromToEmailRequired, _
                  MessageBoxIcon.Information, _
                  MessageBoxButtons.OK)

                blnSaveSucceeded = False
                Return blnSaveSucceeded


        End Select


        blnSaveSucceeded = True
        My.Settings.Save()
        Me.Validate()
        Return blnSaveSucceeded

    End Function


    Private Sub miSaveAndClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            If SaveSettings() = True Then
                Me.Close()
            End If

        Catch ex As Exception
            cr.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try



    End Sub

  

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try

            If SaveSettings() = True Then
                Me.Close()
            End If

        Catch ex As Exception
            cr.ShowMessageBox(ex, MessageBoxIcon.Error, MessageBoxButtons.OK)
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveSettings()
    End Sub


 
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim fd As New FolderBrowserDialog()
        Dim dr As New DialogResult()

        Try
            With fd
                .ShowNewFolderButton = False
                .ShowDialog()
                txtDefaultFolderToCompare.Text = fd.SelectedPath()
            End With
        Catch ex As Exception

        End Try
    End Sub


End Class