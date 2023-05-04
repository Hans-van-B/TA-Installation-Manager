Module Defaults
    Public Inifile As String = IniFile1

    Dim XX As String ' Dummy
    Dim StrNothing As String = "<Nothing>"
    Sub ReadDefaults()
        xtrace_subs("ReadDefaults")
        Dim ReadFile

        If My.Computer.FileSystem.FileExists(IniFile1) Then
            Inifile = IniFile1

        ElseIf My.Computer.FileSystem.FileExists(IniFile2) Then
            Inifile = IniFile2

        Else
            Form1.WriteInfo("Failed to read:")
            Form1.WriteInfo("   " & IniFile1)
            Form1.WriteInfo("Or " & IniFile2)
            'WriteIniFile()
            Exit Sub
        End If

        Form1.WriteInfo("Read Defaults " & Inifile)
        ReadFile = My.Computer.FileSystem.OpenTextFileReader(Inifile)

        Dim Line As String
        Dim Group As String = ""
        Dim P1, P2 As Integer
        Dim DName, DVal As String

        While Not ReadFile.EndOfStream
            Try
                Line = ReadFile.ReadLine()

                '---- Remark lines ----
                If Left(Line, 1) = "#" Then
                    Continue While
                End If

                If Len(Line) < 2 Then
                    Continue While
                End If

                '---- Read Group ----------
                P1 = InStr(Line, "[")
                P2 = InStr(Line, "]")

                If P1 = 1 And P2 > 2 Then
                    Group = Mid(Line, 2, P2 - 2)
                    xtrace("Group = " & Group)
                    Continue While
                End If

                '---- Pick Lists ----
                ' Reset group (Optional)

                If Group = "COMBOBOX01" Then
                    'Form1.COMBOBOX01.Items.Add(Line)
                End If

                '---- Read Defaults
                P1 = InStr(Line, "=")
                DName = Left(Line, P1 - 1)
                DVal = Mid(Line, P1 + 1)
                xtrace("Default " & DName & "=" & DVal)

                If DVal = StrNothing Then Continue While

                If Group = "INIT" Then
                    If DName = "LicID" Then
                        LicC.LicID = DVal
                        xtrace(" - SET LicID=" & LicC.LicID, 2)
                    End If

                    If DName = "WindowState" Then
                        If UCase(DVal) = "MIN" Then
                            xtrace("Minimize form")
                            Form1.WindowState = FormWindowState.Minimized
                        End If
                    End If

                    SharedDefaults(DName, DVal)

                    If DName = "StopUpdates" Then
                        StopUpdates = DVal
                        xtrace("Set StopUpdates = " & StopUpdates)
                    End If

                    If DName = "Redownload" Then
                        If DVal = "True" Then
                            ReDownload = True
                            xtrace_i("Set Redownload = " & ReDownload.ToString)
                        End If
                    End If

                    If DName = "TAISDevDepo" Then
                        IniDevDepo = DVal
                        xtrace("Set TAISDevDepo = " & IniDevDepo)
                    End If

                    If DName = "TAISLocDepo" Then
                        TAISLocDepo = DVal
                        xtrace("Set TAISLocDepo = " & TAISLocDepo)
                    End If

                    If DName = "SetWinLoc" Then
                        Form1.CheckBoxSetWinLocations.Checked = StringToBool(DVal)
                        xtrace("Set SetWinLoc = " & Form1.CheckBoxSetWinLocations.Checked.ToString)
                    End If

                    If DName = "Extract" Then
                        Form1.CheckBoxExtract.Checked = StringToBool(DVal)
                        xtrace("Set XX = " & XX)
                    End If

                    If DName = "XX" Then
                        XX = DVal
                        xtrace("Set XX = " & XX)
                    End If
                End If

            Catch ex As Exception

            End Try
        End While
        ReadFile.Dispose()
        xtrace_sube("ReadDefaults")
    End Sub

    ' These defaults are used both in the general defaults and also in the Wizard init
    Sub SharedDefaults(DName As String, DVal As String)
        Dim LT As Integer = SharedDefaultsTraceValue
        xtrace_subs("SharedDefaults", LT)

        If DName = "DownloadMethod" Then
            DownloadMethod = DVal
            xtrace_i("Set DownloadMethod = " & DownloadMethod)
        End If

        If DName = "ScriptTypeSelect" Then
            ScriptTypeSelect = DVal.ToUpper
            xtrace("Set ScriptTypeSelect = " & ScriptTypeSelect)
            Form1.SetGUIScryptType(Glob.ScriptTypeSelect)
        End If

        If DName = "CopySourceToLocal" Then
            If DVal = "True" Then
                CopySourceToLocal = True
                Form1.CheckBoxCopySource.Checked = True
            ElseIf DVal = False Then
                CopySourceToLocal = False
                Form1.CheckBoxCopySource.Checked = False
            End If
            xtrace_i("Set CopySourceToLocal = " & CopySourceToLocal.ToString)
        End If

        If DName = "BatSeparateInit" Then
            BatSeparateInit = DVal
            xtrace("Set BatSeparateInit = " & BatSeparateInit)
            If BatSeparateInit = "True" Then
                Form1.CheckBoxBatSeparateInit.Checked = True
            ElseIf BatSeparateInit = "False" Then
                Form1.CheckBoxBatSeparateInit.Checked = False
            End If
        End If

        If DName = "BatSeparateApp" Then
            BatSeparateApp = DVal
            xtrace("Set BatSeparateApp = " & BatSeparateApp)
            If BatSeparateApp = "True" Then
                Form1.CheckBoxBatSeparateApp.Checked = True
            ElseIf BatSeparateApp = "False" Then
                Form1.CheckBoxBatSeparateApp.Checked = False
            End If
        End If

        If DName = "BatSeparatePost" Then
            BatSeparatePost = StringToBool(DVal)
            Form1.CheckBoxBatSeparatePost.Checked = BatSeparatePost
            xtrace_i("Set BatSeparatePost = " & BatSeparatePost.ToString)
        End If

        If DName = "BatRemarkMethod" Then
            RemType = DVal
            xtrace_i("Set BatRemarkMethod = " & RemType)
            If RemType = "REM" Then Form1.RadioButtonRemRem.Checked = True Else Form1.RadioButtonRemRem.Checked = False
            If RemType = "::" Then Form1.RadioButtonRemDots.Checked = True Else Form1.RadioButtonRemDots.Checked = False
            If RemType = "echo" Then Form1.RadioButtonRemEcho.Checked = True Else Form1.RadioButtonRemEcho.Checked = False
            If RemType = "#" Then Form1.RadioButtonRemHash.Checked = True Else Form1.RadioButtonRemHash.Checked = False
        End If

        If DName = "UseTASetup" Then
            Dim UseTASetup As Boolean = StringToBool(DVal)
            Form1.CheckBoxTASetup.Checked = UseTASetup
            xtrace_i("Set UseTASetup = " & UseTASetup.ToString)
        End If

        If DName = "UseTASelect" Then
            Dim UseTASelect As Boolean = StringToBool(DVal)
            Form1.CheckBoxTASelect.Checked = UseTASelect
            xtrace_i("Set UseTASelect = " & UseTASelect.ToString)
        End If

        If DName = "UseTADeinstall" Then
            Dim UseTADeinstall As Boolean = StringToBool(DVal)
            Form1.CheckBoxTADeinstall.Checked = UseTADeinstall
            xtrace_i("Set UseTADeinstall = " & UseTADeinstall.ToString)
        End If

        If DName = "AppNameList" Then
            Dim AppNameList() As String = DVal.Split(";")
            Dim AppName As String
            For Each AppName In AppNameList
                xtrace_i("Add AppName: " & AppName)
                Form1.ComboBoxInstName.Items.Add(AppName)
            Next
        End If

        If DName = "UseDept" Then
            Dim UseDept As Boolean = StringToBool(DVal)
            Form1.CheckBoxDeptConfigs.Checked = UseDept
            xtrace_i("UseDept = " & UseDept.ToString)
        End If

        If DName = "DeptNameList" Then
            Dim DeptNameList() As String = DVal.Split(";")
            Dim DeptName As String
            Form1.TextBoxDept.ResetText()
            For Each DeptName In DeptNameList
                xtrace_i("Add DeptName: " & DeptName)
                'Form1.TextBoxDept.Lines.Append(DeptName & vbCrLf)
                Form1.TextBoxDept.Text = Form1.TextBoxDept.Text & DeptName & vbCrLf
            Next
        End If

        If DName = "CopyLogToServer" Then
            ' CopyLogToServer = DVal    Only used to read the default
            Form1.CheckBoxLogToServer.Checked = StringToBool(DVal)
            xtrace("Set CopyLogToServer = " & Form1.CheckBoxLogToServer.Checked.ToString)
        End If

        If DName = "AddDebugPrompt" Then
            Form1.AddDebugPromptToolStripMenuItem.Checked = StringToBool(DVal)
            xtrace("Set AddDebugPrompt = " & Form1.AddDebugPromptToolStripMenuItem.Checked.ToString)

        End If

        If DName = "StopUpdates" Then
            Form1.CheckBoxStopUpdates.Checked = StringToBool(DVal)
            xtrace("Set StopUpdates = " & Form1.CheckBoxStopUpdates.Checked.ToString)

        End If

        If DName = "LogToServer" Then
            Form1.CheckBoxLogToServer.Checked = StringToBool(DVal)
            xtrace("Set LogToServer = " & Form1.CheckBoxLogToServer.Checked.ToString)
        End If

        If DName = "ListEnv" Then
            Form1.ListEnvironmentToolStripMenuItem.Checked = StringToBool(DVal)
            xtrace("Set ListEnv = " & Form1.ListEnvironmentToolStripMenuItem.Checked.ToString)
        End If

        If DName = "CheckSystem" Then
            Form1.CheckBoxCheckSystem.Checked = StringToBool(DVal)
            xtrace("Set ListEnv = " & Form1.CheckBoxCheckSystem.Checked.ToString)
        End If

        If DName = "xx" Then
            XX = DVal
            xtrace("Set XX = " & XX)

        End If

        xtrace_sube("SharedDefaults", LT)
    End Sub

    Function StringToBoolean(Val As String) As Boolean
        Val = UCase(Val).Trim

        If (Val = "TRUE") _
        Or (Val = "1") _
        Or (Val = "Y") Then
            Return True
        Else
            Return False
        End If
    End Function

    '---- Create ini file -----------------------------------------------------
    ' Write each default that applies to the default file
    ' Do not write values that are intended for the wizards only (SharedDefaults)
    Sub WriteIniFile()
        xtrace_subs("WriteIniFile")
        If Glob.ScriptTypeSelect = "" Then Glob.ScriptTypeSelect = "Bat"

        StartIniFile()
        WriteIniLine("[INIT]")
        WriteIniLine("LicID", LicC.LicID)
        WriteIniLine("UseTASetup", Form1.CheckBoxTASetup.Checked)
        WriteIniLine("UseTASelect", Form1.CheckBoxTASelect.Checked)
        WriteIniLine("UseTADeinstall", Form1.CheckBoxTADeinstall.Checked)
        WriteIniLine("ScriptTypeSelect", Glob.ScriptTypeSelect)
        WriteIniLine("BatSeparateInit", Form1.CheckBoxBatSeparateInit.Checked)
        WriteIniLine("CopySourceToLocal", Form1.CheckBoxCopySource.Checked)
        WriteIniLine("Extract", Form1.CheckBoxExtract.Checked)
        WriteIniLine("CheckSystem", Form1.CheckBoxCheckSystem.Checked)
        WriteIniLine("BatSeparateApp", Form1.CheckBoxBatSeparateApp.Checked)
        WriteIniLine("BatSeparatePost", Form1.CheckBoxBatSeparatePost.Checked)
        WriteIniLine("BatRemarkMethod", RemType)
        WriteIniLine("AppNameList", Form1.ComboBoxInstName.Items)
        WriteIniLine("UseDept", Form1.CheckBoxDeptConfigs.Checked)
        WriteIniLine("")
        WriteIniLine("StopUpdates", Form1.CheckBoxStopUpdates.Checked)
        WriteIniLine("CopyLogToServer", Form1.CheckBoxLogToServer.Checked)
        WriteIniLine("ReDownload", Form1.CheckBoxReDownload.Checked)
        WriteIniLine("")
        WriteIniLine("# Only used if the environment var. is missing")
        WriteIniLine("TAISDevDepo", TAISDevDepo)

        If TAISLocDepo = "" Then TAISLocDepo = StrNothing   ' Nothing will not be read
        WriteIniLine("TAISLocDepo", TAISLocDepo)

        Dim DeptNames As String = Join(Form1.TextBoxDept.Lines, ";")
        WriteIniLine("DeptNameList=" & DeptNames)

        WriteIniLine("")

        xtrace_sube("WriteIniFile")
    End Sub

    '---- StartIniFile

    Sub StartIniFile()
        WriteTxtToFile(Inifile, "# Saved by " & AppName & " - V" & AppVer & vbCrLf & vbCrLf, False, 0, "", "", True, False)
    End Sub

    '---- Write a group, empty line or remark
    Sub WriteIniLine(Line As String)
        Dim IniTxt As String

        If Line = Nothing Then
            Line = ""
        End If

        IniTxt = Line & vbCrLf
        WriteTxtToFile(Inifile, IniTxt, True, 0, "", "", True, False)
    End Sub

    '---- Write a string value
    Sub WriteIniLine(Name As String, SVal As String)
        Dim IniTxt As String

        If SVal Is Nothing Then SVal = StrNothing

        IniTxt = Name & "=" & SVal & vbCrLf
        WriteTxtToFile(Inifile, IniTxt, True, 0, "", "", True, False)
    End Sub

    '---- Write a string list
    Sub WriteIniLine(Name As String, List() As String)
        Dim SVal As String
        Dim IniTxt As String

        If List Is Nothing Then
            SVal = StrNothing
        Else
            SVal = Join(List, ";")
        End If

        IniTxt = Name & "=" & SVal & vbCrLf
        WriteTxtToFile(Inifile, IniTxt, True, 0, "", "", True, False)
    End Sub

    '---- Write Object list
    Sub WriteIniLine(Name As String, List() As Object)
        Dim SVal As String = ""
        Dim OVal As Object
        Dim IniTxt As String

        For Each OVal In List
            If SVal = "" Then
                SVal = OVal.ToString
            Else
                SVal = SVal & ";" & OVal.ToString
            End If
        Next

        IniTxt = Name & "=" & SVal & vbCrLf
        WriteTxtToFile(Inifile, IniTxt, True, 0, "", "", True, False)
    End Sub

    Sub WriteIniLine(Name As String, List As ComboBox.ObjectCollection)
        Dim SVal As String = ""
        Dim OVal As Object
        Dim IniTxt As String

        For Each OVal In List
            If SVal = "" Then
                SVal = OVal.ToString
            Else
                SVal = SVal & ";" & OVal.ToString
            End If
        Next

        IniTxt = Name & "=" & SVal & vbCrLf
        WriteTxtToFile(Inifile, IniTxt, True, 0, "", "", True, False)
    End Sub

    '---- Write a boolean value
    ' False and nothing are the same, so you cannot test for nothing!
    Sub WriteIniLine(Name As String, BVal As Boolean)
        Dim SVal As String
        Dim IniTxt As String

        SVal = BVal.ToString

        IniTxt = Name & "=" & SVal & vbCrLf
        WriteTxtToFile(Inifile, IniTxt, True, 0, "", "", True, False)
    End Sub

    '---- Dummy supports "Template lines"
    Sub WriteIniLine()

    End Sub

    Sub ReadDefaultsFromEnv()
        xtrace_subs("ReadDefaultsFromEnv")
        If Environment.GetEnvironmentVariable("TAIS_BINLIB") <> "" Then
            Glob.BinLib = Environment.GetEnvironmentVariable("TAIS_BINLIB")
            xtrace_i("Set BinLib = " & BinLib)
        End If

        xtrace_sube("ReadDefaultsFromEnv")
    End Sub

End Module
