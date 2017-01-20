Imports System.IO
Public Class Form1
    Public s_cancell As Boolean
    Public filetext As String
    ' Set Defualt value for Combobox that shows the version
    Public Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox2.Text = "4.50.3.0"
        ComboBox1.Text = "4.50.3.0"
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Clearing the List

        Me.Missing.Items.Clear()
        Me.Log.Items.Clear()

        'Declearing variables
        Dim Path, Source, Company, pathi, ver As String
        Dim r As String
        s_cancell = False

        ' Variable defenition 
        Path = TextBox1.Text
        Company = TextBox2.Text
        ver = ComboBox1.Text
        'checking to make sure the input is right. 
        If Path = "" Then
            MsgBox("Please enter a Valid Path to MAS90 folder")
            GoTo Endd1
        End If
        If Company = "" Then
            MsgBox("Please enter a Valid 3 Digit Company Code")
            GoTo Endd1
        End If
        If Len(Company) <> 3 Then
            MsgBox("Please enter a Valid 3 Digit Company Code")
            GoTo Endd1
        End If
        If UCase(Path.Substring(Path.Length - 5, 5)) <> "MAS90" Then
            MsgBox("Please enter a Valid Path to MAS90 folder")
            GoTo Endd1
        End If

        'Checking for Company Data
        If CheckedListBox1.CheckedItems.Count = 0 Then
            MsgBox("Please select at least one module to be compared")
            GoTo Endd1

        End If
        For Each itemChecked In CheckedListBox1.CheckedItems
            Application.DoEvents()
            If s_cancell Then Exit For
            r = System.AppDomain.CurrentDomain.BaseDirectory()
            Source = r + "\" + ver + "\Companydata\" + itemChecked.ToString() + ".txt"
            pathi = Path + "\MAS_" + Company + "\" + itemChecked.ToString() + Company
            Call Comparecompanydata(Source, pathi, Company)
        Next

        If Missing.Items.Count = 0 Then
            Missing.Items.Add("Congratulation nothing is missing")
        End If
        If s_cancell Then
            Missing.Items.Add("Search has been stopped")
        End If
Endd1:
    End Sub
    Private Sub Comparecompanydata(ByVal Source As String, ByVal Path As String, ByVal Company As String)
        Dim Filename, file As String
        Dim pathe As String = ""
        Dim Filereader As System.IO.StreamReader
        Try
            Filereader = My.Computer.FileSystem.OpenTextFileReader(Source)
        Catch ex As Exception
            MsgBox("There is a problem with Source please email ali.esfahani@sage.com with steps to duplicate and this screen shot" + ex.Message)
            Exit Sub
        End Try

        Log.Items.Add("Checking for " + Source.Substring(Source.Length - 6, 2) + Company + " files")
        Do While Filereader.Peek() <> -1

            Filename = Filereader.ReadLine()
            If InStr(Filename, "XXX") <> 0 Then
                Filename = Replace(Filename, "XXX", Company)
            End If
            Filename = UCase(Filename)
            Try


                For Each foundFile As String In My.Computer.FileSystem.GetFiles(Path, FileIO.SearchOption.SearchTopLevelOnly, "*.*")

                    file = System.IO.Path.GetFileName(foundFile)
                    If Filename = UCase(file) Then

                        GoTo Line2
                    End If
                Next

                Missing.Items.Add(Filename)


            Catch ex As System.IO.DirectoryNotFoundException
                If pathe <> Path Then
                    Missing.Items.Add("Folder " + Path.Substring(Path.Length - 5) + " Does not exist")
                    pathe = Path
                End If
            Catch ex As Exception
                Missing.Items.Add("Sorry there was a problem checking for " + Filename + " " + ex.Message)
            End Try
Line2:
        Loop

        Log.Items.Add("Done")

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub



    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Me.Missing.Items.Clear()
        Me.Log.Items.Clear()
        Me.Missing2.Items.Clear()
        Me.Log2.Items.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        Dim i As Integer
        For i = 0 To (CheckedListBox1.Items.Count - 1)
            CheckedListBox1.SetItemChecked(i, False)
        Next
        For i = 0 To (CheckedListBox2.Items.Count - 1)
            CheckedListBox2.SetItemChecked(i, False)
        Next

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Clearing the List

        Me.Missing2.Items.Clear()
        Me.Log2.Items.Clear()

        'Declearing variables
        Dim Source, ver As String '
        Dim Path As String = ""
        Dim r As String
        Dim i As Integer = 0
        Dim l As Integer = 0
        s_cancell = False


        ' Variable defenition 

        Path = TextBox3.Text
        ver = ComboBox2.Text
        If Path = "" Then
            MsgBox("Please enter a Valid Path to MAS90 folder")
            GoTo Endd
        End If
        l = Path.Length
        If l > 5 Then
            If UCase(Path.Substring(Path.Length - 5, 5)) <> "MAS90" Then
                MsgBox("Please enter a Valid Path to MAS90 folder that ends with \MAS90")
                GoTo Endd
            End If
        End If
        If l < 5 Then
            MsgBox("Please enter a Valid Path to MAS90 folder")
            GoTo Endd
        End If
        If CheckedListBox2.CheckedItems.Count = 0 Then
            MsgBox("Please select at least one Program folder to be compared")
            GoTo Endd

        End If


        'Checking for Program files Data
        For Each itemChecked In CheckedListBox2.CheckedItems
            Application.DoEvents()
            If s_cancell Then Exit For

            If CheckedListBox2.GetItemCheckState(CheckedListBox2.Items.IndexOf(itemChecked)).ToString() <> "Indeterminate" Then
                If ver = "4.40.0.9" Then
                    If CheckedListBox2.Items.IndexOf(itemChecked) <> 9 Then
                        If CheckedListBox2.Items.IndexOf(itemChecked) <> 21 Then
                            If CheckedListBox2.Items.IndexOf(itemChecked) <> 12 Then
                                r = System.AppDomain.CurrentDomain.BaseDirectory()

                                Source = r + "\" + ver + "\Programs\" + itemChecked.ToString() + ".txt"
                                Call Compareprograms(Source, Path, itemChecked.ToString())

                            End If
                        End If
                    End If
                End If


                If ver = "4.30.0.23" Then

                    If CheckedListBox2.Items.IndexOf(itemChecked) <> 21 Then
                        If CheckedListBox2.Items.IndexOf(itemChecked) <> 12 Then
                            r = System.AppDomain.CurrentDomain.BaseDirectory()
                            Source = r + "\" + ver + "\Programs\" + itemChecked.ToString() + ".txt"
                            Call Compareprograms(Source, Path, itemChecked.ToString())
                        End If
                    End If
                End If


                If ver = "4.50.3.0" Then

                    If CheckedListBox2.Items.IndexOf(itemChecked) <> 11 Then
                        If CheckedListBox2.Items.IndexOf(itemChecked) <> 12 Then
                            r = System.AppDomain.CurrentDomain.BaseDirectory()
                            Source = r + "\" + ver + "\Programs\" + itemChecked.ToString() + ".txt"
                            Call Compareprograms(Source, Path, itemChecked.ToString())
                        End If
                    End If
                End If
            End If

            If CheckedListBox2.Items.IndexOf(itemChecked) = 12 Then
                r = System.AppDomain.CurrentDomain.BaseDirectory()
                Source = r + "\" + ver + "\Programs\" + "files.txt"
                Call Compareprograms(Source, Path, itemChecked.ToString())
            End If

        Next
        If Missing2.Items.Count = 0 And Path <> "" Then
            Missing2.Items.Add("Congratulation nothing is missing")
        End If
        If s_cancell Then
            Missing2.Items.Add("Search has been stoped")
        Else
            Missing2.Items.Add("Search has finished")
        End If

Endd:
    End Sub
    Private Sub Compareprograms(ByVal Source As String, ByVal Path As String, ByVal itemchecked As String)
        Dim Filename, Fullsource, Pathwithoutfilename, file As String
        Dim pathe As String = ""
        Dim Halfpath As String = ""
        Dim i1 As Integer = 0
        Dim Filereader As System.IO.StreamReader
        Try
            Filereader = My.Computer.FileSystem.OpenTextFileReader(Source)
        Catch ex As Exception
            MsgBox("There is a problem with Source please email ali.esfahani@sage.com with steps to duplicate and this screen shot " + ex.Message)
            Exit Sub
        End Try
        Log2.Items.Add("Checking for " + itemchecked + " Program files")
        Log2.Refresh()

        Do While Filereader.Peek() <> -1

            Fullsource = Filereader.ReadLine()
            i1 = InStrRev(Fullsource, "\")
            Filename = Fullsource.Substring(i1, Fullsource.Length - i1)
            Pathwithoutfilename = Fullsource.Substring(0, i1 - 1)
            Filename = UCase(Filename)

            Try
                Halfpath = Path + "\" + Pathwithoutfilename
                Log2.Items.Add("Checking for Existance of " + Fullsource)
                Log2.Refresh()
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(Halfpath, FileIO.SearchOption.SearchTopLevelOnly, "*.*")

                    file = System.IO.Path.GetFileName(foundFile)
                    If Filename = UCase(file) Then
                        GoTo Line3
                    End If

                Next
                Missing2.Items.Add("File " + Fullsource + " is missing.")


            Catch ex As System.IO.DirectoryNotFoundException
                If pathe <> Halfpath Then
                    Missing2.Items.Add("Folder " + Halfpath + " does not exist.")
                    pathe = Halfpath
                End If
            Catch ex As Exception
                MsgBox("Sorry a problem happend with the search please email the steps to duplicate to tools.na@sage.com")
                GoTo endd
            End Try
Line3:
        Loop
Endd:
        Log2.Items.Add("Done")
    End Sub

    

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ver As String
        ver = ComboBox2.Text

        For I = 0 To CheckedListBox2.Items.Count - 1

            CheckedListBox2.SetItemChecked(I, True)
            If ver = "4.40.0.9" Then
                If I = 9 Then
                    CheckedListBox2.SetItemCheckState(9, CheckState.Indeterminate)
                ElseIf I = 21 Then
                    CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
                End If
            End If
            If ver = "4.30.0.23" Then
           
                If I = 21 Then
                    CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
                End If
            End If
            If ver = "4.50.3.0" Then

                If I = 11 Then
                    CheckedListBox2.SetItemCheckState(11, CheckState.Indeterminate)
                End If
            End If

        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        For I = 0 To CheckedListBox1.Items.Count - 1

            CheckedListBox1.SetItemChecked(I, True)

        Next
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim ver As String
        ver = ComboBox2.Text
        For I = 0 To CheckedListBox2.Items.Count - 1

            CheckedListBox2.SetItemChecked(I, False)
            If ver = "4.40.0.9" Then
                If I = 9 Then
                    CheckedListBox2.SetItemCheckState(9, CheckState.Indeterminate)
                ElseIf I = 21 Then
                    CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
                End If
            End If
            If ver = "4.30.0.23" Then

                If I = 21 Then
                    CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
                End If
            End If
            If ver = "4.50.3.0" Then

                If I = 11 Then
                    CheckedListBox2.SetItemCheckState(11, CheckState.Indeterminate)
                End If
            End If
        Next
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        For I = 0 To CheckedListBox1.Items.Count - 1

            CheckedListBox1.SetItemChecked(I, False)

        Next
    End Sub


 

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim i As Integer
        Dim ver As String
        ver = ComboBox2.Text
        For i = 0 To 12

            CheckedListBox2.SetItemChecked(i, True)
            If ver = "4.40.0.9" Then
                If i = 9 Then
                    CheckedListBox2.SetItemCheckState(9, CheckState.Indeterminate)
                ElseIf i = 21 Then
                    CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
                End If
            End If
            If ver = "4.30.0.23" Then

                If i = 21 Then
                    CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
                End If
            End If
            If ver = "4.50.3.0" Then

                If i = 11 Then
                    CheckedListBox2.SetItemCheckState(11, CheckState.Indeterminate)
                End If
            End If
        Next
    End Sub


    


 


    
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim ver As String
        ver = ComboBox2.Text()
        If ver = "4.40.0.9" Then
            CheckedListBox2.SetItemCheckState(9, CheckState.Indeterminate)
            CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
        End If
        If ver = "4.30.0.23" Then
            CheckedListBox2.SetItemCheckState(21, CheckState.Indeterminate)
        End If
        If ver = "4.50.3.0" Then


            CheckedListBox2.SetItemCheckState(11, CheckState.Indeterminate)

        End If
    End Sub




    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim oForm As AboutBox1

        oForm = New AboutBox1()
        oForm.Show()
        oForm = Nothing
    End Sub

    Private Sub HowToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HowToToolStripMenuItem.Click
        Dim r As String
        r = System.AppDomain.CurrentDomain.BaseDirectory()

        System.Diagnostics.Process.Start(r + "\help.htm")

    End Sub


    Private Sub Log_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Log.SelectedIndexChanged

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        s_cancell = True
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        s_cancell = True
    End Sub
End Class
