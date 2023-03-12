Module Defaults
    Public Inifile As String = IniFile1

    Dim XX As String ' Dummy
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

                If Group = "INIT" Then

                    If DName = "WindowState" Then
                        If UCase(DVal) = "MIN" Then
                            xtrace("Minimize form")
                            Form1.WindowState = FormWindowState.Minimized
                        End If
                    End If

                    If DName = "ScriptTypeSelect" Then
                        ScriptTypeSelect = DVal
                        xtrace("Set ScriptTypeSelect = " & ScriptTypeSelect)
                    End If

                    SharedDefaults(DName, DVal)

                    If DName = "StopUpdates" Then
                        StopUpdates = DVal
                        xtrace("Set StopUpdates = " & StopUpdates)
                    End If

                    If DName = "CopyLogToServer" Then
                        CopyLogToServer = DVal
                        xtrace("Set CopyLogToServer = " & CopyLogToServer)
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

    ' These defaults are used both in the general defaults and also in the wizzard init
    Sub SharedDefaults(DName As String, DVal As String)
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
        End If

        If DName = "BatSeparateApp" Then
            BatSeparateApp = DVal
            xtrace("Set BatSeparateApp = " & BatSeparateApp)
        End If

        If DName = "BatSeparatePost" Then
            BatSeparatePost = DVal
            xtrace("Set BatSeparatePost = " & BatSeparatePost)
        End If

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
    Sub WriteIniFile()
        xtrace_subs("WriteIniFile")

        Dim IniTxt As String = "[INIT]" & vbCrLf &
            "ScriptTypeSelect=" & Glob.ScriptTypeSelect & vbCrLf &
            "BatSeparateInit=" & Form1.CheckBoxBatSeparateInit.Checked.ToString & vbCrLf &
            "CopySourceToLocal=" & Form1.CheckBoxCopySource.Checked.ToString & vbCrLf &
            "BatSeparateApp=" & Form1.CheckBoxBatSeparateApp.Checked.ToString & vbCrLf &
            "BatSeparatePost=" & Form1.CheckBoxBatSeparatePost.Checked.ToString & vbCrLf &
            "" & vbCrLf &
            "StopUpdates=" & Form1.CheckBoxStopUpdates.Checked.ToString & vbCrLf &
            "CopyLogToServer=" & Form1.CheckBoxLogToServer.Checked.ToString & vbCrLf &
            "ReDownload=" & Form1.CheckBoxReDownload.Checked.ToString & vbCrLf &
            "" & vbCrLf &
            "# Only used if the environment var. is missing" & vbCrLf &
            "TAISDevDepo=" & TAISDevDepo & vbCrLf &
            "" & vbCrLf &
            ""
        WriteTxtToFile(Inifile, IniTxt, False, 0, "", "", True, False)

        xtrace_sube("WriteIniFile")
    End Sub
End Module
