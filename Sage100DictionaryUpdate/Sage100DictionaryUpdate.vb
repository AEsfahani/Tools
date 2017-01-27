Imports ProvideX.ScriptClass
'Imports Outlook = Microsoft.Office.Interop.Outlook
Public Class Sage100DictionaryUpdate

    Inherits System.Windows.Forms.Form
    Public retVAL As Integer
    Public InitPath As String
    Public PvxScript As ProvideX.Script
    Public myPVXObject As ProvideX.PvxDispatch
    Public oUI As ProvideX.PvxDispatch
    Public Embed As ProvideX.PvxDispatch
    Public mySecur As ProvideX.PvxDispatch
    Dim LastClickTick As Integer = 0
    Public Howmany As Integer
    Public Maybe As String = ""
    Public er As Integer = 0
    Public Done As Integer = 0



 



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim path As String = ""

        'path = TextBox1.Text







        'If Len(path) = 0 Then
        'MsgBox("Sorry the program could not retrieve the path to your MAS90 folder " & "Please enter it manually")
        ' er = 1
        'GoTo endd2
        'End If

        ' Try
        'Dim SOTAMAS90Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\ODBC\ODBC.INI\SOTAMAS90")
        '  Dim InitPath2 = SOTAMAS90Key.GetValue("Directory")
        'TextBox1.Text = InitPath2 + "\Home"
        ' Catch ex As Exception
        'MsgBox("Sorry the program could not retrieve the path to your MAS90 folder" & "Please enter it manually")
        'er = 1
        'GoTo endd2
        ' End Try

        ' If Howmany = 1 Then
        'If Maybe = "" Then



        'Try
        'Dim SOTAMAS90Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\ODBC\ODBC.INI\SOTAMAS90")
        ' Dim InitPath = SOTAMAS90Key.GetValue("Directory") & "\Home"


        ' Catch ex As Exception
        ' MsgBox("There is something wrong setting the SY_session object" & vbCrLf & " Please send an email to ali.esfahani@sage.com with steps to duplicate " & ex.Message)
        'er = 1
        ' GoTo endd2
        ' End Try
        ' End If
        ' If Maybe = "Y" Then
        'Try
        'InitPath = TextBox1.Text
        ' PvxScript = New ProvideX.Script
        ' PvxScript.Init(InitPath)
        ' myPVXObject = PvxScript.NewObject("SY_Session")
        'Catch ex As Exception
        'MsgBox("There is something wrong setting the SY_session object" & vbCrLf & " Please send an email to ali.esfahani@sage.com with steps to duplicate " & ex.Message)
        ' er = 1
        ' GoTo endd2
        ' End Try
        ' End If
        '  End If



        Try
            If System.Environment.TickCount - LastClickTick < 1000 Then
                Exit Sub
            Else

                'Clear the List
                Me.Result.Items.Clear()

                'Declearing variables
                Dim User, Password, Company, Mo As String



                ' Variable defenition 
                User = TextBox2.Text
                Password = TextBox3.Text
                Company = TextBox4.Text
                Company = UCase(Company)

                If Company = "" Then
                    MsgBox("Please Enter a Valid Company code")
                    er = 1
                    GoTo Endd
                End If
                If Len(Password) = 0 Then
                    Password = ""
                End If

                If CheckedListBox1.CheckedItems.Count = 0 Then
                    MsgBox("Please select at least one module to be updated")
                    er = 1
                    GoTo Endd

                End If
                retVAL = myPVXObject.nSetUser(User, Password)


                If retVAL = 0 Then
                    MsgBox("Unable to use this user ID and password because " & myPVXObject.sLastErrorMsg)
                    er = 1

                    GoTo Endd
                End If
                retVAL = myPVXObject.nSetCompany(Company, 1)
                If retVAL = 0 Then
                    MsgBox("Unable to set company " & Company & " Because " & myPVXObject.sLastErrorMsg & vbCrLf & "Try check marking the Allow External Access in Company maintenance preferences tab")
                    er = 1
                    GoTo Endd

                End If

                retVAL = myPVXObject.nSetModule("SYS")
                If retVAL = 0 Then
                    MsgBox("Unable to set module SYS" & myPVXObject.sLastErrorMsg)
                    er = 1
                    GoTo Endd
                End If

                Try
                    mySecur = PvxScript.NewObject("SY_Security", myPVXObject, 0)
                Catch ex As Exception
                    MsgBox("Sorry was not able to set the security object for this user because ", ex.Message)
                    er = 1
                    GoTo Endd
                End Try

                retVAL = myPVXObject.nSetProgram(myPVXObject.nLookupTask("SY_company_ui"))

                If retVAL <> 0 Then
                    Embed = PvxScript.NewObject("SY_activation_bus", myPVXObject)
                Else
                    MsgBox("Sorry Unable to Set the Activation BUS object because " & myPVXObject.sLastErrorMsg)
                    er = 1
                    GoTo Endd
                End If
                Result.Items.Add("The Path to MAS90 folder that we are using for this update is " & TextBox1.Text)
                Result.Refresh()
                For Each itemChecked In CheckedListBox1.CheckedItems
                    Mo = itemChecked
                    Mo = Mo.Substring(0, 1) + "/" + Mo.Substring(1, 1)

                    Result.Items.Add("Running Dictionary Update(Embedded I/O) for module " & itemChecked & " ...")
                    Done = 1
                    Result.Refresh()
                    retVAL = Embed.nActivate(Mo, Company)
                    If retVAL <> 0 Then
                        Result.Items.Add("Success. ")
                        Done = 1
                    Else
                        Result.Items.Add("Failed, and last error message is " & Embed.sLastErrorMsg)
                        Result.Refresh()
                        MsgBox("Dictionary Update for Company " & Company & " and Module " & Mo & " has failed and the last error is:" & vbCrLf & Embed.sLastErrorMsg & vbCrLf & vbCrLf & " Update process will stop now.")
                        er = 1
                        GoTo Endd

                    End If



                Next
            End If
Endd:
        Finally
            LastClickTick = System.Environment.TickCount
        End Try
endd2:
        If er = 0 Then
            Result.Items.Add("Dictionary update for requested modules is done. Thank you ")
        End If
        Howmany = Howmany + 1

    End Sub



   
    Public Sub Sage100DictionaryUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Howmany = 1
        Try

            Dim SOTAMAS90Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\ODBC\ODBC.INI\SOTAMAS90")
            Dim InitPath2 = SOTAMAS90Key.GetValue("Directory")
            TextBox1.Text = InitPath2 + "\Home"
            InitPath2 = TextBox1.Text

            PvxScript = New ProvideX.Script
            PvxScript.Init(InitPath2)
            myPVXObject = PvxScript.NewObject("SY_Session")

        Catch ex As Exception
            MsgBox("Sorry the program could not retrieve the path to your MAS90\Home folder " & "Please close the program and first log in MAS90 or 200 and then launch this application." & vbCrLf & "Note: At the moment this application does not work with MAS200 SQL")
            Maybe = "Y"

        End Try





    End Sub

    Private Sub Sage100DictionaryUpdate_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If er <> 1 Then
            If Done = 1 Then
                myPVXObject.ncleanup()
                myPVXObject.DropObject()
                PvxScript = Nothing
                myPVXObject = Nothing
            End If
          
        End If
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        For I = 0 To CheckedListBox1.Items.Count - 1
            CheckedListBox1.SetItemChecked(I, True)
        Next
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        For I = 0 To CheckedListBox1.Items.Count - 1

            CheckedListBox1.SetItemChecked(I, False)

        Next
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        For I = 0 To CheckedListBox1.Items.Count - 1

            CheckedListBox1.SetItemChecked(I, False)

        Next
        Me.Result.Items.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        myPVXObject.ncleanup()
        myPVXObject.DropObject()
        PvxScript = Nothing
        myPVXObject = Nothing
        Me.Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        For I = 0 To CheckedListBox1.Items.Count - 1

            CheckedListBox1.SetItemChecked(I, False)

        Next
        Me.Result.Items.Clear()
    End Sub

    Private Sub AboutSage100DictionaryUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutSage100DictionaryUpdateToolStripMenuItem.Click
        Dim oForm As AboutBox1

        oForm = New AboutBox1()
        oForm.Show()
        oForm = Nothing
    End Sub

    'Private Sub ReportIssueOrAskForEnhancmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Dim objOutlook As Outlook.Application
    '  Dim objOutlookMsg As Outlook.MailItem
    '  Dim objOutlookRecip As Outlook.Recipient


    '   Try
    ' Create the Outlook session.
    '    objOutlook = CreateObject("Outlook.Application")

    ' Create the message.
    '      objOutlookMsg = objOutlook.CreateItem(0)
    '    With objOutlookMsg
    ' Add the To recipient(s) to the message.
    '    objOutlookRecip = .Recipients.Add("ali.esfahani@sage.com")

    ' Set the Subject, Body, and Importance of the message.
    '     .Subject = "Enhancement request / Bug Report / Question "
    '.Body = "This is the body of the message." & vbCrLf & vbCrLf

    ' Resolve each Recipient's name.
    '  For Each objOutlookRecip In .Recipients
    '      objOutlookRecip.Resolve()
    '  Next

    ' Should we display the message before sending?
    '     .Display()
    '    .Save()
    '.Send()

    '     End With
    '  Catch ex As Exception
    '     MsgBox("Sorry something went wrong connecting to Microsoft Outlook" + vbCrLf + "Instead please email to ali.esfahani@sage.com with your request")
    '    GoTo enddd
    'End Try


    'enddd:
    'End Sub

    Private Sub HowToUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HowToUserToolStripMenuItem.Click
        Dim r As String
        r = System.AppDomain.CurrentDomain.BaseDirectory()

        System.Diagnostics.Process.Start(r + "\help.htm")
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim fbd As New FolderBrowserDialog
        fbd.RootFolder = Environment.SpecialFolder.MyComputer
        If fbd.ShowDialog = DialogResult.OK Then
            TextBox1.Text = fbd.SelectedPath
        End If

    End Sub


End Class
