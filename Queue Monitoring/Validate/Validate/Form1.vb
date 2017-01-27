Imports Outlook = Microsoft.Office.Interop.Outlook
'Imports System.IO


Public Class Form1

    Private Declare Function GetValidModules Lib "masrkc.dll" (ByVal validationkey As String, ByVal productkey As String, ByVal tmplist As String, ByVal i As Integer) As Integer
    'Private Declare Function IsValidKey Lib "C:\masrkc.dll" (ByVal validationkey As String, ByVal productkey As String) As Integer
    'Private Declare Function GetExpirationDate Lib "masrkc.dll" (ByVal validationkey As String, ByVal productkey As String, ByVal tmpdate As String, ByVal j As Integer) As Integer


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        'clean the list box first.
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        'ListView1.Items.Clear()

        TextBox5.Text = ""
        TextBox8.Text = ""
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox1.BackColor = Color.Empty
        CheckBox2.BackColor = Color.Empty
        CheckBox3.BackColor = Color.Empty
        CheckBox4.BackColor = Color.Empty
        CheckBox5.BackColor = Color.Empty


        'Varialble Declare
        Dim Serial, CustomerNo, Userkey, Validation, Product, tmpkey, numuser As String
        Dim i As Integer
        Dim asciiChar As Char
        asciiChar = Chr(0)
        Dim tmplist As New String(" "c, 512)
        Dim Productkey() As String
        Dim PKresult As String
        Dim Moduleresult() As String
        Dim Moduledef(44, 2) As String
        Dim x As Integer
        Dim userfromkey As Integer
        Dim modulelist As String
        Dim SQL1 As Integer
        Dim SQLMOD As Integer
        SQL1 = 0
        SQLMOD = 0
        'Dim j As Integer
        'Dim tmpdate As New String(" "c, 20)
        Dim M90, M200, M200SQL, EES90, EES200 As Integer
        M90 = 0
        M200 = 0
        M200SQL = 0
        EES90 = 0
        EES200 = 0
        Dim user As Integer
        'Dim iTM As ListViewItem

        'Grab the input
        modulelist = ""
        Moduledef(0, 0) = "AL"
        Moduledef(0, 1) = "ACT LINK"
        Moduledef(1, 0) = "AP"
        Moduledef(1, 1) = "ACCOUNTS PAYABLE"
        Moduledef(2, 0) = "AR"
        Moduledef(2, 1) = "ACCOUNTS RECEIVBLE"
        Moduledef(3, 0) = "BC"
        Moduledef(3, 1) = "BAR CODE"
        Moduledef(4, 0) = "BM"
        Moduledef(4, 1) = "BILL OF MATERIALS"
        Moduledef(5, 0) = "BR"
        Moduledef(5, 1) = "BANK RECONCILIATION"
        Moduledef(6, 0) = "CC"
        Moduledef(6, 1) = "CREDIT CARD PROCESSING"
        Moduledef(7, 0) = "CM"
        Moduledef(7, 1) = "CUSTOM OFFICE"
        Moduledef(8, 0) = "CS"
        Moduledef(8, 1) = "CLIENTS SERVER"
        Moduledef(9, 0) = "CW"
        Moduledef(9, 1) = "CLIENTS WRITEUP"
        Moduledef(10, 0) = "DM"
        Moduledef(10, 1) = "DATA MIGRATOR"
        Moduledef(11, 0) = "FL"
        Moduledef(11, 1) = "FIXED ASSETS"
        Moduledef(12, 0) = "EE"
        Moduledef(12, 1) = "EXTENDED ENTERPRISE SUITE"
        Moduledef(13, 0) = "ES"
        Moduledef(13, 1) = "BUSINESS INSIGHTS"
        Moduledef(14, 0) = "CI"
        Moduledef(14, 1) = "COMMON INFORMATION"
        Moduledef(15, 0) = "GL"
        Moduledef(15, 1) = "GENERAL LEDGER"
        Moduledef(16, 0) = "IM"
        Moduledef(16, 1) = "INVENTORY MANAGEMENT"
        Moduledef(17, 0) = "IT"
        Moduledef(17, 1) = "E-BUSINESS MANAGER"
        Moduledef(18, 0) = "IT0"
        Moduledef(18, 1) = ".INQUIRY"
        Moduledef(19, 0) = "IT1"
        Moduledef(19, 1) = ".ORDER"
        Moduledef(20, 0) = "IT2"
        Moduledef(20, 1) = ".STORE"
        Moduledef(21, 0) = "JC"
        Moduledef(21, 1) = "JOB COST"
        Moduledef(22, 0) = "LM"
        Moduledef(22, 1) = "LIBRARY MASTER"
        Moduledef(23, 0) = "MD"
        Moduledef(23, 1) = "DEVELOPMENT STUDIO"
        Moduledef(24, 0) = "MP"
        Moduledef(24, 1) = "MATERIAL REQUIRMENTS PLANNING"
        Moduledef(25, 0) = "MR"
        Moduledef(25, 1) = "ELECTRONIC REPORTING FOR W2 AND 1099"
        Moduledef(26, 0) = "PL"
        Moduledef(26, 1) = "PAPERLESS OFFICE"
        Moduledef(27, 0) = "PO"
        Moduledef(27, 1) = "PURCHASE ORDER"
        Moduledef(28, 0) = "OI"
        Moduledef(28, 1) = "OBJECT INTERFACE"
        Moduledef(29, 0) = "PR"
        Moduledef(29, 1) = "PAYROLL"
        Moduledef(30, 0) = "PRT"
        Moduledef(30, 1) = "TAX TABLES"
        Moduledef(31, 0) = "RA"
        Moduledef(31, 1) = "RETURN MERCHANDISE AUTHORIZATION"
        Moduledef(32, 0) = "RM"
        Moduledef(32, 1) = "REPORT MASTER"
        Moduledef(33, 0) = "SD"
        Moduledef(33, 1) = "DIRECT DEPOSIT"
        Moduledef(34, 0) = "SO"
        Moduledef(34, 1) = "SALES ORDER"
        Moduledef(35, 0) = "SQL"
        Moduledef(35, 1) = "SQL"
        Moduledef(36, 0) = "ST"
        Moduledef(36, 1) = "STARSHIP"
        Moduledef(37, 0) = "TC"
        Moduledef(37, 1) = "TIME CARD"
        Moduledef(38, 0) = "VI"
        Moduledef(38, 1) = "VISUAL INTEGRATOR"
        Moduledef(39, 0) = "WO"
        Moduledef(39, 1) = "WORK ORDER"
        Moduledef(40, 0) = "CU"
        Moduledef(40, 1) = "CUSTOMER RELATIONSHIP MANAGEMENT"
        Moduledef(41, 0) = "C2"
        Moduledef(41, 1) = "CREDIT CARD PROCESSING"
        Moduledef(42, 0) = "WS"
        Moduledef(42, 1) = "WEB SERVICES"
        Moduledef(43, 0) = "NFR"
        Moduledef(43, 1) = "NOT FOR RESALE"
        Moduledef(44, 0) = "PF"
        Moduledef(44, 1) = "Visual Process Flows"
        ' Make sure to change the for statment if you change this and the defitnition



        Serial = TextBox1.Text
        CustomerNo = TextBox2.Text
        Userkey = TextBox3.Text
        Product = TextBox4.Text
        Validation = Serial + "/" + CustomerNo + "/" + Userkey
        Validation = UCase(Validation)
        Product = UCase(Product)
        tmpkey = Userkey.Substring(16, 2)
        'MsgBox(tmpkey)
        userfromkey = Convert.ToInt32(tmpkey, 16)
        'MsgBox(userfromkey)
        'userfromkey = Val("&" & tmpkey & "&")
        'CInt(tmpkey)
        'MsgBox(userfromkey)
        If Len(Serial) = 0 Then
            MsgBox("Please enter a serial number")

        End If
        If Len(CustomerNo) = 0 Then
            MsgBox("Please enter a Customer number")
        End If
        If Len(Userkey) <> 20 Then
            MsgBox("Please enter a 20 digit Userkey")
            GoTo Endd
        End If
        If InStr(Product, "-") = 0 Then
            MsgBox("Please enter the product key in the format of XXXXX-XXXXX-XXXXX-XXXXX-XXXXX")
            GoTo Endd
        End If
        If Len(Product) <> 29 Then
            MsgBox("Please enter the product key in the format of XXXXX-XXXXX-XXXXX-XXXXX-XXXXX")
            GoTo Endd
        End If
        Try
            Productkey = Split(Product, "-")
        Catch ex As Exception
            MsgBox(" Sorry there is somthing wrong with the product key " + e.ToString)
            GoTo Endd
        End Try


        'Validation = "0090084/559636/F07B476C3A2650C0ABCD"
        'Product = "5DE3QAPUUG98KDW4VW2XVEUEV"

        PKresult = Productkey(0) + Productkey(1) + Productkey(2) + Productkey(3) + Productkey(4) + vbNullString
        'MsgBox(PKresult)
        Validation = Validation + vbNullString
        tmplist = tmplist + vbNullString
    
        i = GetValidModules(Validation, PKresult, tmplist, 512)
        ' j = GetValidModules(Validation, PKresult, tmpdate, 20)
        'MsgBox(tmpdate)
        If i = 0 Then
            MsgBox("One or more registration fields are invalid or the Key is bad." + vbCrLf + "Try old customer number(from Vantive)." + vbCrLf + " Double check your entries and if it's still same problem contact Sales advisors at ext 340808.")
            GoTo Endd
        End If
        Moduleresult = Split(tmplist, "|")
        Array.Sort(Moduleresult)
        For Each Str As String In Moduleresult
            For x = 0 To 44
                If InStr(Str, "U:") > 0 Then
                    ListBox3.Items.Add(Str.Substring(2, 5))
                    numuser = Str.Substring(2, 5)

                    'MsgBox(ListBox3.Items(0))
                    If Val(Str.Substring(2, 5)) <> userfromkey Then
                        MsgBox("Warning , User Licenses from User Key is different than the user license from Product key." + vbCrLf + "This may cause a No valid activation error." + vbCrLf + "If this is related to a Customer/Partner key contact Sales Adviosrs at Ext 340808." + vbCrLf + "If you are testing Sage Internal Key ignore this message.")
                    End If
                    GoTo Forend
                End If
                If InStr(Str, ":") > 0 Then
                    GoTo Forend
                End If
                If Str = Moduledef(x, 0) Then
                    If Len(modulelist) = 0 Then
                        modulelist = Moduledef(x, 0)

                    Else
                        modulelist = modulelist + "," + Moduledef(x, 0)
                    End If
                    ListBox1.Items.Add(Moduledef(x, 0))
                    ListBox2.Items.Add(Moduledef(x, 1))
                    'ListView1.Items.Add(Moduledef(x,0)
                    ' ListView listitem = New ListViewItem(New String(Moduledef(x, 0), Moduledef(x, 1))))
                    'iTM = ListView1.Items.Add(Moduledef(x, 0))
                    'iTM.SubItems(1).Text = Moduledef(x, 1)
                    'ListView1.Subitem.add(1)

                    GoTo Forend
                End If
            Next
            ListBox1.Items.Add(Str)
            ListBox2.Items.Add(Str)
            'ListView1.Items.Add(Str, Str)
            If Len(modulelist) = 0 Then
                modulelist = Str

            Else
                modulelist = modulelist + "," + Str
            End If
            'numuser = ListBox3.Items(0)
Forend:
            If TextBox7.Text <> "" Then
                TextBox8.Text = "Customer Number: " & CustomerNo & vbCrLf & "Customer Name: " & TextBox7.Text & vbCrLf & "Serial Number: " & Serial & vbCrLf & "Unlocking Key / User Key: " & Userkey & vbCrLf & "Product Key: " & Product & vbCrLf & "Validation Results: " & modulelist & vbCrLf & "Number of Users: " & numuser
            Else
                TextBox8.Text = "Customer Number: " & CustomerNo & vbCrLf & "Serial Number: " & Serial & vbCrLf & "Unlocking Key / User Key: " & Userkey & vbCrLf & "Product Key: " & Product & vbCrLf & "Validation Results: " & modulelist & vbCrLf & "Number of Users: " & numuser

            End If
            
        Next
        'MsgBox(tmplist)
        'MsgBox(i)
        'ListBox1.Items.Add(tmplist)
        For Each Str As String In Moduleresult
            If Str = "GL" Then
                M90 = M90 + 1
                M200 = M200 + 1
                M200SQL = M200SQL + 1
                EES90 = EES90 + 1
                EES200 = EES200 + 1

            End If
            If Str = "CS" Then
                M200 = M200 + 1
                M200SQL = M200SQL + 1
                EES200 = EES200 + 1

            End If
            If Str = "SQL" Then
                M200SQL = M200SQL + 1

            End If
            If Str = "EE" Then
                EES90 = EES90 + 1
                EES200 = EES200 + 1

            End If
        Next

Endd:

        TextBox5.Text = modulelist
        If M200 = 2 Then
            If EES200 <> 3 Then
                If M200SQL = 3 Then
                    CheckBox4.Checked = True
                    CheckBox4.BackColor = Color.GreenYellow
                    numuser = numuser.Trim()
                    TextBox8.Text = "Valid Sage 100 Premium key" & vbCrLf & TextBox8.Text
                    user = Convert.ToInt32(numuser) - 2
                    ListBox4.Items.Add(user)
                    GoTo akhar
                End If
                CheckBox2.Checked = True
                CheckBox2.BackColor = Color.GreenYellow
                TextBox8.Text = "Valid Sage 100 Advanced key" & vbCrLf & TextBox8.Text
                numuser = numuser.Trim()
                user = Convert.ToInt32(numuser) - 2
                ListBox4.Items.Add(user)
                GoTo akhar
            ElseIf EES200 = 3 Then
                CheckBox5.Checked = True
                CheckBox5.BackColor = Color.GreenYellow
                CheckBox2.Checked = True
                CheckBox2.BackColor = Color.GreenYellow
                TextBox8.Text = "Valid Sage 100 Advanced key" & vbCrLf & "Valid EES200 key" & vbCrLf & TextBox8.Text
                numuser = numuser.Trim()
                user = Convert.ToInt32(numuser) - 2
                ListBox4.Items.Add(user)
                GoTo akhar
            End If

        End If
        If EES90 = 2 Then
            CheckBox3.Checked = True
            CheckBox3.BackColor = Color.GreenYellow
            CheckBox1.Checked = True
            CheckBox1.BackColor = Color.GreenYellow
            TextBox8.Text = "Valid Sage 100 Standard key" & vbCrLf & "Valid EES90 key" & vbCrLf & TextBox8.Text
            numuser = numuser.Trim()
            user = Convert.ToInt32(numuser) - 1
            ListBox4.Items.Add(user)
            GoTo akhar

        ElseIf M90 = 1 Then
            CheckBox1.Checked = True
            CheckBox1.BackColor = Color.GreenYellow
            TextBox8.Text = "Valid Sage 100 Standard key" & vbCrLf & TextBox8.Text
            numuser = numuser.Trim()
            user = Convert.ToInt32(numuser) - 1
            ListBox4.Items.Add(user)
            GoTo akhar
        End If
        If CheckBox4.Checked = True Then
            SQL1 = SQL1 + ListBox1.FindString("PR")
            MsgBox(ListBox1.FindString("PR"))
            SQL1 = SQL1 + ListBox1.FindString("WO")
            SQL1 = SQL1 + ListBox1.FindString("JC")
            SQL1 = SQL1 + ListBox1.FindString("FL")

            SQL1 = SQL1 + ListBox1.FindString("IT")
            SQL1 = SQL1 + ListBox1.FindString("IT0")
            SQL1 = SQL1 + ListBox1.FindString("IT1")
            SQL1 = SQL1 + ListBox1.FindString("IT2")
            SQL1 = SQL1 + ListBox1.FindString("MR")
            SQL1 = SQL1 + ListBox1.FindString("PT")
            SQL1 = SQL1 + ListBox1.FindString("TC")
        End If
        If SQL1 <> 0 Then
            MsgBox("Warning : This is a Sage 100 Premium key." + vbCrLf + "But one or more Legacy modules are part of the key." + vbCrLf + " This can cause an error during Sage 2013 Installation please contact Sales advisors at ext 340808.")
            GoTo akhar

        End If

akhar:
        If CheckBox4.Checked = True Then
            SQLMOD = ListBox1.FindString("PR")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("PR")
            End If
            SQLMOD = ListBox1.FindString("WO")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("WO")
            End If
            SQLMOD = ListBox1.FindString("JC")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("JC")
            End If
            SQLMOD = ListBox1.FindString("FL")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("FL")
            End If
            SQLMOD = ListBox1.FindString("IT")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("IT")
            End If

            SQLMOD = ListBox1.FindString("IT0")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("IT0")
            End If
            SQLMOD = ListBox1.FindString("IT1")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("IT1")
            End If
            SQLMOD = ListBox1.FindString("IT2")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("IT2")
            End If
            SQLMOD = ListBox1.FindString("MR")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("MR")
            End If
            SQLMOD = ListBox1.FindString("PT")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("PT")
            End If
            SQLMOD = ListBox1.FindString("TC")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("TC")
            End If
            SQLMOD = ListBox1.FindString("MP")
            If SQLMOD <> -1 Then
                SQL1 = SQL1 + ListBox1.FindString("MP")
            End If

        End If
        If SQL1 <> 0 Then
            MsgBox("Warning : This is a Sage 100 Premium key." + vbCrLf + "But one or more Legacy modules of (FL,IT,IT0,IT1,IT2,JC,MP,MR,PR,PT,TC,WO) are part of the key." + vbCrLf + "This can cause an error during Sage 100 2013 Installation Please contact Sales advisors at ext 340808.")


        End If
    End Sub



    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ' ListView1.Items.Clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox1.BackColor = Color.Empty
        CheckBox2.BackColor = Color.Empty
        CheckBox3.BackColor = Color.Empty
        CheckBox4.BackColor = Color.Empty
        CheckBox5.BackColor = Color.Empty



    End Sub


  
    Private Sub AboutSage100KeyValidationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutSage100KeyValidationToolStripMenuItem.Click
        Dim oForm As AboutBox1

        oForm = New AboutBox1()
        oForm.Show()
        oForm = Nothing
    End Sub

    Private Sub HowToUseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HowToUseToolStripMenuItem.Click
        Dim r As String
        r = System.AppDomain.CurrentDomain.BaseDirectory()

        System.Diagnostics.Process.Start(r + "\help.chm")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ' ListView1.Items.Clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox1.BackColor = Color.Empty
        CheckBox2.BackColor = Color.Empty
        CheckBox3.BackColor = Color.Empty
        CheckBox4.BackColor = Color.Empty
        CheckBox5.BackColor = Color.Empty

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Len(TextBox5.Text) = 0 Then
            MsgBox("Sorry you have not validated anything yet to be coppied to Clipboard")
            GoTo A
        End If
        Try
            Clipboard.SetDataObject(TextBox5.Text)
            MsgBox("Validation results have been copied to clipboard")
        Catch ex As Exception
            MsgBox("Sorry something went wrong accessing your computer clipboard" & vbCrLf & "Please send an email to ali.esfahani@sage.com with steps to duplicate and " & ex.Message)
        End Try

A:
    End Sub

    Private Sub ReportIssuesOrAskForAnEnhancmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportIssuesOrAskForAnEnhancmentToolStripMenuItem.Click
        Dim objOutlook As Outlook.Application
        Dim objOutlookMsg As Outlook.MailItem
        Dim objOutlookRecip As Outlook.Recipient


        Try
            ' Create the Outlook session.
            objOutlook = CreateObject("Outlook.Application")

            ' Create the message.
            objOutlookMsg = objOutlook.CreateItem(0)
            With objOutlookMsg
                ' Add the To recipient(s) to the message.
                objOutlookRecip = .Recipients.Add("ali.esfahani@sage.com")

                ' Set the Subject, Body, and Importance of the message.
                .Subject = "Enhancement request / Bug Report / Question "
                '.Body = "This is the body of the message." & vbCrLf & vbCrLf

                ' Resolve each Recipient's name.
                For Each objOutlookRecip In .Recipients
                    objOutlookRecip.Resolve()
                Next

                ' Should we display the message before sending?
                .Display()
                .Save()
                '.Send()

            End With
        Catch ex As Exception
            MsgBox("Sorry something went wrong connecting to Microsoft Outlook" + vbCrLf + "Instead please email to ali.esfahani@sage.com with your request")
            GoTo enddd
        End Try
        

enddd:

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim Email As String
        Dim result As String
        Dim numberuser As String
        Dim serial, customerno, userkey, product As String
        Serial = TextBox1.Text
        CustomerNo = TextBox2.Text
        Userkey = TextBox3.Text
        Product = TextBox4.Text
        result = TextBox5.Text

        'MsgBox(numberuser)
        Email = TextBox6.Text
        If Len(Email) = 0 Then
            MsgBox("Sorry you have to enter an email for the Customer/Partner to be emailed to")
            GoTo engg
        End If
        If Len(result) = 0 Then
            MsgBox("Sorry first validate and then you can email them")
            GoTo engg

        End If
        numberuser = ListBox3.Items.Item(0)
        Dim objOutlook As Outlook.Application
        Dim objOutlookMsg As Outlook.MailItem
        Dim objOutlookRecip As Outlook.Recipient
        'Dim oInsp As Outlook.Inspector
        Try


            ' Create the Outlook session.
            objOutlook = CreateObject("Outlook.Application")

            ' Create the message.
            objOutlookMsg = objOutlook.CreateItem(0)

            ' objOutlook = objOutlookMsg.GetInspector

            With objOutlookMsg
                Try
                    ' Add the To recipient(s) to the message.
                    objOutlookRecip = .Recipients.Add(Email)

                    ' Set the Subject, Body, and Importance of the message.
                    .Subject = "Validated Keys for Customer Number " + customerno


                    .Body = "Hello," & vbCrLf & vbCrLf & "Below you can find your validated key information" & vbCrLf & vbCrLf & "Customer Number: " & customerno & vbCrLf & "Serial Number: " & serial & vbCrLf & "Unlocking Key / User Key: " & userkey & vbCrLf & "Product Key: " & product & vbCrLf & "Validation Results: " & result & vbCrLf & "Number of Users: " & numberuser & vbCrLf & vbCrLf & "Regards,"

                Catch ex As Exception
                    MsgBox("Sorry a problem happened accessing Outlook on your computer therefore we can't send email" + vbCrLf + "As a workaround you can copy the results to clipboard using the button to the right")
                    GoTo engg
                End Try


                ' Resolve each Recipient's name.
                For Each objOutlookRecip In .Recipients
                    objOutlookRecip.Resolve()
                Next

                ' Should we display the message before sending?
                .Display()
                .Save()
                '.Send()

            End With
        Catch ex As Exception
            MsgBox("Sorry something went wrong connecting to Microsoft Outlook" + vbCrLf + "Instead please email the results directly to your customer")
            GoTo engg
        End Try
engg:
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try


            Dim Desktoppath, path, path2, regkey, Userkey, Usercount, actpvx, name, serial As String
            Dim I As Integer
            'Dim file As System.IO.FileStream
            Dim H As String

            Desktoppath = Environ$("UserProfile") & "\Desktop"
            path = Desktoppath + "\$ACTPVX.BAT"
            path2 = Desktoppath + "\$ACTPVX.BAT.OLD"
            If Dir(path2) <> "" Then
                My.Computer.FileSystem.DeleteFile(path2)
            End If

            If Dir(path) <> "" Then
                My.Computer.FileSystem.RenameFile(path, "$ACTPVX.BAT.OLD")
            End If
            If ListBox3.Items.Count = 0 Then
                MsgBox("Sorry you need to Validate a key first before creating the $ACTPVX file")
                GoTo Endd
            End If
            If TextBox7.Text = "" Then
                MsgBox("Please enter the customer Company name before creating the $ACTPVX file")
                GoTo Endd

            End If
            Usercount = ListBox3.Items.Item(0)
            I = Val(Usercount)
            H = Hex(I)
            serial = TextBox1.Text
            name = TextBox7.Text
            Userkey = TextBox3.Text
            Userkey = Userkey.Substring(0, 16)
            If Len(H) = 1 Then
                H = "0" + H
            End If
            Usercount = H
            If InStr(Usercount, " ") > 0 Then
                If Len(Usercount) > 2 Then
                    Usercount = Usercount.Substring(1, 2)
                    'MsgBox(Usercount)
                Else
                    Usercount = Usercount.Substring(1, 1)
                    Usercount = "0" + Usercount
                End If


            End If
            regkey = "P" + Userkey + Usercount
            actpvx = "PVXWACTV -e 0 -i -m 3453987879 -n " + Chr(34) + name + Chr(34) + " -o 90 -s " + serial + " -k " + regkey
            'file = System.IO.File.Create(path)
            Dim objWriter As New System.IO.StreamWriter(path, True)
            objWriter.WriteLine(actpvx)
            'My.Computer.FileSystem.WriteAllText(path, actpvx, True)
            MsgBox("$ACTPVX.BAT file got created on your desktop" + vbCrLf + "You can send that file to your client and by pasting that in to MAS90\Home folder and running the Batch file you will have a new Activate.pvx")
            objWriter.Close()
        Catch ex As Exception
            MsgBox("Sorry something went wrong creating the $actpvx on the desktop of your computer" & vbCrLf & "Please send an email to ali.esfahani@sage.com with steps to duplicate " & ex.Message)
            GoTo Endd
        End Try
Endd:
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try


            Dim Desktoppath, path, path2, regkey, Userkey, actpvx, name, serial As String
            Dim Productkey() As String
            Dim Product As String

            Desktoppath = Environ$("UserProfile") & "\Desktop"
            path = Desktoppath + "\MASREG.INI"
            path2 = Desktoppath + "\MASREG.INI.OLD"
            Product = TextBox4.Text
            Try
                Productkey = Split(Product, "-")
            Catch ex As Exception
                MsgBox(" Sorry there is somthing wrong with the product key " + e.ToString)
                GoTo Endd
            End Try
            If Dir(path2) <> "" Then
                My.Computer.FileSystem.DeleteFile(path2)
            End If

            If Dir(path) <> "" Then
                My.Computer.FileSystem.RenameFile(path, "MASREG.INI.OLD")
            End If
            If ListBox3.Items.Count = 0 Then
                MsgBox("Sorry you need to Validate a key first before creating the MASREG file")
                GoTo Endd
            End If
            If TextBox7.Text = "" Then
                MsgBox("Please enter the customer Company name before creating the MASREG file")
                GoTo Endd

            End If

            serial = TextBox1.Text
            name = TextBox7.Text
            Userkey = TextBox3.Text
            regkey = TextBox2.Text
            actpvx = "[RegInfo]" + vbCrLf + "Company=" + name + vbCrLf + "Reseller=None" + vbCrLf + "Serial=" + serial + vbCrLf + "RegId=" + regkey + vbCrLf + "UserKey=" + Userkey + vbCrLf + "PK1=" + Productkey(0) + vbCrLf + "PK2=" + Productkey(1) + vbCrLf + "PK3=" + Productkey(2) + vbCrLf + "PK4=" + Productkey(3) + vbCrLf + "PK5=" + Productkey(4) + vbCrLf
            ' actpvx = "PVXWACTV -e 0 -i -m 3453987879 -n " + Chr(34) + name + Chr(34) + " -o 90 -s " + serial + " -k " + regkey

            Dim objWriter As New System.IO.StreamWriter(path, True)
            objWriter.WriteLine(actpvx)

            MsgBox("MASREG.INI file got created on your desktop" + vbCrLf + "You can send that file to your client and by pasting that in to root of C drive and running the MAS install they can install the product without a need to enter the keys.")
            objWriter.Close()
        Catch ex As Exception
            MsgBox("Sorry something went wrong creating the $MASREG.INI on the desktop of your computer" & vbCrLf & "Please send an email to ali.esfahani@sage.com with steps to duplicate " & ex.Message)
            GoTo Endd
        End Try
Endd:
    End Sub

 
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim clip As String
        'Dim Email As String
        Dim result As String
        Dim numberuser, customername As String
        Dim serial, customerno, userkey, product As String
        serial = TextBox1.Text
        customerno = TextBox2.Text
        userkey = TextBox3.Text
        customername = TextBox7.Text
        product = TextBox4.Text
        result = TextBox5.Text
        clip = ""
        If Len(result) = 0 Then
            MsgBox("Sorry first validate and then you can copy them")
            GoTo A
        End If
        numberuser = ListBox3.Items.Item(0)
        If Len(TextBox5.Text) = 0 Then
            MsgBox("Sorry you have not validated anything yet to be coppied to Clipboard")
            GoTo A
        End If
        Try
            If CheckBox4.Checked = True Then
                clip = "Valid Sage 100 Premium key" & vbCrLf & "Customer Number: " & customerno & vbCrLf & "Serial Number: " & serial & vbCrLf & "Unlocking Key / User Key: " & userkey & vbCrLf & "Product Key: " & product & vbCrLf & "Validation Results: " & result & vbCrLf & "Number of Users: " & numberuser

            End If
            If CheckBox2.Checked = True And CheckBox5.Checked = True Then
                clip = "Valid Sage 100 Advanced key" & vbCrLf & "Valid EES200 key" & vbCrLf & "Customer Number: " & customerno & vbCrLf & "Serial Number: " & serial & vbCrLf & "Unlocking Key / User Key: " & userkey & vbCrLf & "Product Key: " & product & vbCrLf & "Validation Results: " & result & vbCrLf & "Number of Users: " & numberuser

            End If
            If CheckBox2.Checked = True And CheckBox5.Checked = False Then
                clip = "Valid Sage 100 Advanced key" & vbCrLf & "Customer Number: " & customerno & vbCrLf & "Serial Number: " & serial & vbCrLf & "Unlocking Key / User Key: " & userkey & vbCrLf & "Product Key: " & product & vbCrLf & "Validation Results: " & result & vbCrLf & "Number of Users: " & numberuser
            End If
            If CheckBox1.Checked = True And CheckBox3.Checked = True Then
                clip = "Valid Sage 100 Standard key" & vbCrLf & "Valid EES90 key" & vbCrLf & "Customer Number: " & customerno & vbCrLf & "Serial Number: " & serial & vbCrLf & "Unlocking Key / User Key: " & userkey & vbCrLf & "Product Key: " & product & vbCrLf & "Validation Results: " & result & vbCrLf & "Number of Users: " & numberuser

            End If
            If CheckBox1.Checked = True And CheckBox3.Checked = False Then
                clip = "Valid Sage 100 Standard key" & vbCrLf & "Customer Number: " & customerno & vbCrLf & "Serial Number: " & serial & vbCrLf & "Unlocking Key / User Key: " & userkey & vbCrLf & "Product Key: " & product & vbCrLf & "Validation Results: " & result & vbCrLf & "Number of Users: " & numberuser
            End If
            If clip = "" Then
                clip = "Customer Number: " & customerno & vbCrLf & "Serial Number: " & serial & vbCrLf & "Unlocking Key / User Key: " & userkey & vbCrLf & "Product Key: " & product & vbCrLf & "Validation Results: " & result & vbCrLf & "Number of Users: " & numberuser

            End If
            If customername <> "" Then
                clip = "Customer Name: " & customername & vbCrLf & clip
            End If
                   Clipboard.SetDataObject(clip)
            MsgBox("Keys and Validation results have been copied to clipboard")
        Catch ex As Exception
            MsgBox("Sorry something went wrong accessing your computer clipboard" & vbCrLf & "Please send an email to ali.esfahani@sage.com with steps to duplicate and " & ex.Message)
        End Try
A:
    End Sub


    Private Sub ChangeLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeLogToolStripMenuItem.Click
        Dim oForm As Change_log

        oForm = New Change_log()
        oForm.Show()
        oForm = Nothing
    End Sub

End Class
