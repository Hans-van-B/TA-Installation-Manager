Imports System.Text

Module UpdateWizard
    Dim WizOut As String
    Sub WriteWizard()
        xtrace_subs("WriteWizard")

        If WizIniFile Is Nothing Then AssignWizIniFile()

        Dim ReadFile
        Form1.WriteInfo("Read Wizards " & WizIniFile)
        ReadFile = My.Computer.FileSystem.OpenTextFileReader(WizIniFile)

        Dim Line As String
        Dim Group As String = ""
        Dim P1, P2 As Integer
        Dim WizIniStart As New List(Of String)
        Dim WizIniEnd As New List(Of String)
        Dim WizStatus As Integer = 0
        Dim WizardName As String = "W_" & Form1.ComboBoxInstName.Text
        xtrace_i("Wizard Name = " & WizardName)
        Dim DName, DVal As String

        Dim DepoSubDirIfExist As String = ""    ' ZZ_Non_TA (ToDo!!)
        Dim InstTarget As String = ""
        Dim ContentInitLine As String = ""
        Dim TestIfExist As String = ""
        Dim DownloadURL As String = ""
        Dim Extract As String = ""
        Dim InstCmd As String = ""
        Dim DeptNameList As String = ""
        Dim Readme As New List(Of String)
        Dim AutoStart As String = ""
        Dim MsiDeinstall As String = ""
        Dim MyCopyLogToServer As String = ""

        While Not ReadFile.EndOfStream
            Line = ReadFile.ReadLine()
            If (Line = "# Updated") _
            Or (Len(Line) < 2) Then
                xtrace(" - " & Line)
                Continue While
            End If

            '---- Read Group ----------
            P1 = InStr(Line, "[")
            P2 = InStr(Line, "]")

            If P1 = 1 And P2 > 2 Then
                Group = Mid(Line, 2, P2 - 2)
                xtrace("Group = " & Group)
                If Group = WizardName Then  ' Wizard to update
                    WizStatus = 1
                ElseIf WizStatus = 1 Then    ' Next Wizard
                    WizStatus = 2
                End If
            End If

            If WizStatus = 0 Then
                WizIniStart.Add(Line)
            ElseIf WizStatus = 1 Then
                P1 = InStr(Line, "=")
                If P1 > 1 Then
                    DName = Left(Line, P1 - 1)
                    DVal = Mid(Line, P1 + 1)
                    xtrace("Property " & DName & "=" & DVal)

                    If DName = "DepoSubDirIfExist" Then DepoSubDirIfExist = DVal
                    If DName = "InstTarget" Then InstTarget = DVal
                    If DName = "ContentInitLine" Then ContentInitLine = DVal
                    If DName = "TestIfExist" Then TestIfExist = DVal
                    If DName = "DownloadURL" Then DownloadURL = DVal
                    If DName = "Extract" Then Extract = DVal
                    If DName = "InstCmd" Then InstCmd = DVal
                    If DName = "Readme" Then Readme.Add(DVal)
                    If DName = "AutoStart" Then AutoStart = DVal
                    If DName = "MsiDeinstall" Then MsiDeinstall = DVal
                    If DName = "CopyLogToServer" Then MyCopyLogToServer = DVal
                End If

            ElseIf WizStatus = 2 Then
                WizIniEnd.Add(Line)
            End If
        End While
        ReadFile.Close

        WizOut = AppRoot & "\" & AppName & "_W.tmp"
        Form1.WriteInfo("Write Wizards " & WizOut)

        '---- Top of file ----
        My.Computer.FileSystem.WriteAllText(WizOut, "# Updated" & vbCrLf, False, Encoding.ASCII)

        xtrace_i("Write top of file (" & WizIniStart.Count.ToString & ")")
        For Each Line In WizIniStart
            WriteWiz(Line)
        Next

        '---- Write Updated Wizard ----
        xtrace_i("Compile lines")
        ' Compile Dept Name List
        For Each Line In Form1.TextBoxDept.Lines
            If DeptNameList = "" Then
                DeptNameList = Line
            Else
                DeptNameList = DeptNameList & ";" & Line
            End If
        Next

        ' Fill in the blanks
        If ContentInitLine = "" Then ContentInitLine = "::"
        If TestIfExist = "" Then TestIfExist = "%ProgramFiles%\xx\xx.xxx"

        xtrace_i("Write updated wizard")
        WriteWiz("[W_" & Form1.ComboBoxInstName.Text & "]")
        If DepoSubDirIfExist <> "" Then WriteWiz("DepoSubDirIfExist=" & DepoSubDirIfExist)
        WriteWiz("ScriptTypeSelect=" & ScriptTypeSelect)
        WriteWiz("UseTASetup=" & Form1.CheckBoxTASetup.Checked.ToString)
        WriteWiz("UseTASelect=" & Form1.CheckBoxTASelect.Checked.ToString)
        WriteWiz("UseTADeinstall=" & Form1.CheckBoxTADeinstall.Checked.ToString)
        WriteWiz("BatSeparateInit=" & Form1.CheckBoxBatSeparateInit.Checked.ToString)
        WriteWiz("BatSeparateApp=" & Form1.CheckBoxBatSeparateApp.Checked.ToString)
        WriteWiz("BatSeparatePost=" & Form1.CheckBoxBatSeparatePost.Checked.ToString)
        WriteWiz("CopySourceToLocal=" & Form1.CheckBoxCopySource.Checked.ToString)
        WriteWiz("UseDept=" & Form1.CheckBoxDeptConfigs.Checked.ToString)
        If Form1.CheckBoxDeptConfigs.Checked Then WriteWiz("DeptNameList=" & DeptNameList)
        WriteWiz("RemType=" & RemType)
        WriteWiz("InstTarget=" & InstTarget)
        WriteWiz("ContentInitLine=" & ContentInitLine)
        WriteWiz("TestIfExist=" & TestIfExist)

        If DownloadURL <> "" Then
            WriteWiz("DownloadURL=" & DownloadURL)
        Else
            WriteWiz("# DownloadURL=<URL>;Source\W64")
        End If

        If Extract <> "" Then
            WriteWiz("Extract=" & Extract)
        Else
            WriteWiz("# Extract=<InstTarget|INST>;<DownloadNr>")
        End If

        If InstCmd <> "" Then
            WriteWiz("InstCmd=" & InstCmd)
        Else
            WriteWiz("# InstCmd=msiexec /q /i '%Archives%\%AppName%_v0.0.msi' /l* %InstTmp%\%AppName%Msi.log")
        End If

        For Each Line In Readme
            WriteWiz("Readme=" & Line)
        Next

        If AutoStart <> "" Then WriteWiz("AutoStart=" & AutoStart)

        If MsiDeinstall <> "" Then WriteWiz("MsiDeinstall=" & MsiDeinstall)

        If MyCopyLogToServer <> "" Then WriteWiz("CopyLogToServer=" & MyCopyLogToServer)

        '---- End of file ----
        xtrace_i("Write to end of file (" & WizIniEnd.Count.ToString & ")")
        For Each Line In WizIniEnd
            WriteWiz(Line)
        Next

        '---- Rename to Wizard ini ----
        xtrace_i("Finalize")
        Dim BakFile As String = AppRoot & "\" & AppName & "_W.bak"
        If My.Computer.FileSystem.FileExists(BakFile) Then
            My.Computer.FileSystem.DeleteFile(BakFile)
        End If
        My.Computer.FileSystem.RenameFile(WizIniFile, AppName & "_W.bak")
        My.Computer.FileSystem.RenameFile(WizOut, AppName & "_W.ini")

        xtrace_sube("WriteWizard")
    End Sub

    Sub WriteWiz(Line As String)
        If Left(Line, 1) = "[" Then My.Computer.FileSystem.WriteAllText(WizOut, vbCrLf, True)
        My.Computer.FileSystem.WriteAllText(WizOut, Line & vbCrLf, True)
    End Sub
End Module
