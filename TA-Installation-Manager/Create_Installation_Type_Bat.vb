Module Create_Installation_Type_Bat

    Dim BatFileHeader As String = "@echo ---- Start %~n0 ----------------------------" & vbCrLf & ":: Created by " & AppName & " V" & AppVer & vbCrLf
    Dim BatFileFooter As String = vbCrLf & ":END" & vbCrLf & "@echo ---- End %~n0 ------------------------------" & vbCrLf
    Dim BatTimeStamp As String = "@echo Timestamp: %DATE% / %TIME%" & vbCrLf
    Sub Add_Installation_Components_Bat()
        xtrace_subs("Add_Installation_Components_Bat")

        '---- Create directories for InstType .bat

        Dim CheckDir, SD As String
        For Each SD In {"Inst\bat\util"}
            CheckDir = DepoPath & "\" & SD
            xtrace_i("Check : " & CheckDir)
            If Not My.Computer.FileSystem.DirectoryExists(CheckDir) Then
                CreateDirectory(CheckDir, 0, "", "Please check your directory access rights", True, True)
            End If
        Next

        '---- Create bat\Install.bat

        Dim InstallStartFile As String = "\bat\Install.bat"

        xtrace_i("Create " & InstallStartFile)
        Dim StartFileTxt As String =
            ":: Created by : " & AppName & " V" & AppVer & vbCrLf &
            ":: Date       : " & DateTime.Now.ToString("yyyy-MM-dd") & vbCrLf &
            "echo on" & vbCrLf &
            "title " & InstName & " Installation" & vbCrLf &
            "echo Starting the " & InstName & " installation >%ICL%" & vbCrLf &
            "echo  * INSTROOT = %INSTROOT% >>%ICL%" & vbCrLf &
            vbCrLf
        WriteTxtToFile(InstRoot & InstallStartFile, StartFileTxt, False, 0, "", "", True, True)

        '---- Create bat\init.bat
        Add_Installation_Init(InstallStartFile)

        '---- Create Application Install bat
        Add_Installation_Application(InstallStartFile)

        '---- Create post installation file or section
        'vbCrLf &
        '    "if exist ""%instroot%\bat\09_After_Install.bat"" call ""%instroot%\bat\09_After_Install""" & vbCrLf &

        StartFileTxt = vbCrLf &
            "echo Installation finished! >>%ICL%" & vbCrLf &
            "call ""%util%\exit""" & vbCrLf
        WriteTxtToFile(InstRoot & InstallStartFile, StartFileTxt, True, 0, "", "", True, True)



        ' It is not possible to integrate this file, keep it separate
        '---- Create util\exit.bat

        Dim Createfile, StartFile
        Createfile = "\bat\util\exit.bat"
        xtrace_i("Create " & CreateFile)
        StartFile = BatFileHeader &
            vbCrLf &
            "%WRITE% "" * Finalizing""" & vbCrLf &
            vbCrLf

        If Form1.CheckBoxStopUpdates.Checked Then
            StartFile = StartFile & "call ""%InstLibBat%\stop_updates"" FINISH" & vbCrLf
        End If

        If Form1.CheckBoxLogToServer.Checked Then
            StartFile = StartFile & "call ""%InstLibBat%\log-to-server""" & vbCrLf
        End If

        StartFile = StartFile &
            vbCrLf &
            "echo  Done. >con" & vbCrLf &
            "wait 10 >con" & vbCrLf &
            BatFileFooter &
            "exit 0" & vbCrLf

        WriteTxtToFile(InstRoot & CreateFile, StartFile, False, 0, "", "", True, True)

        AddInstFile(True, "Inst\Exe\wait.exe")

        xtrace_sube("Add_Installation_Components_Bat")
    End Sub

    '==== Write Init =============================================================
    Sub Add_Installation_Init(InstallStartFile As String)
        xtrace_subs("Add_Installation_Init")
        Dim StartFileTxt As String

        Dim InitFileTxt As String
        Dim InstallInitFile As String = "\bat\init.bat"

        Dim SeparateFile As Boolean = Form1.CheckBoxBatSeparateInit.Checked

        If SeparateFile Then
            ' Write call in the start file
            StartFileTxt = "call ""%instroot%" & InstallInitFile & """" & vbCrLf
            WriteTxtToFile(InstRoot & InstallStartFile, StartFileTxt, True, 0, "", "", True, True)

            ' Write the file header
            xtrace_i("Create " & InstallInitFile)
            InitFileTxt = BatFileHeader & BatTimeStamp
            WriteTxtToFile(InstRoot & InstallInitFile, InitFileTxt, False, 0, "", "", True, True)
        Else
            ' Remove the separate file if it exists
            DeleteFile(InstRoot & InstallInitFile, 0, "", "", True, False)

            ' Write the section header
            InitFileTxt = vbCrLf & "@echo ---- Start Init -----------------------" & vbCrLf
            WriteTxtToFile(InstRoot & InstallStartFile, InitFileTxt, True, 0, "", "", True, True)
        End If

        ' Set init body txt
        InitFileTxt = "%WRITE% "" * Initializing""" & vbCrLf

        ' Add footer and write
        If SeparateFile Then
            InitFileTxt = InitFileTxt &
            BatFileFooter

            WriteTxtToFile(InstRoot & InstallInitFile, InitFileTxt, True, 0, "", "", True, True)
        Else
            InitFileTxt = InitFileTxt &
                "@echo ---- End Init --------------------" & vbCrLf & vbCrLf

            WriteTxtToFile(InstRoot & InstallStartFile, InitFileTxt, True, 0, "", "", True, True)
        End If

        xtrace_sube("Add_Installation_Init")
    End Sub

    '==== Write Application Installation ========================================
    Sub Add_Installation_Application(InstallStartFile As String)
        xtrace_subs("Add_Installation_Application")
        Dim StartFileTxt As String

        Dim AppFileTxt As String
        Dim InstallAppFile As String = "\bat\05_" & InstName & ".bat"

        Dim SeparateFile As Boolean = Form1.CheckBoxBatSeparateApp.Checked

        If SeparateFile Then
            ' Write call in the start file
            StartFileTxt = "call ""%instroot%" & InstallAppFile & """" & vbCrLf
            WriteTxtToFile(InstRoot & InstallStartFile, StartFileTxt, True, 0, "", "", True, True)

            ' Write the file header
            xtrace_i("Create " & InstallAppFile)
            AppFileTxt = BatFileHeader &
                BatTimeStamp
            WriteTxtToFile(InstRoot & InstallAppFile, AppFileTxt, False, 0, "", "", True, True)
        Else
            ' Remove the separate file if it exists
            DeleteFile(InstRoot & InstallAppFile, 0, "", "", True, False)

            ' Write the section header
            AppFileTxt = vbCrLf & "@echo ---- Start Application Install -----------------------" & vbCrLf
            WriteTxtToFile(InstRoot & InstallStartFile, AppFileTxt, True, 0, "", "", True, True)
        End If

        ' Set Application Install body txt
        AppFileTxt = ":: Install Body" & vbCrLf

        ' Add footer and write
        If SeparateFile Then
            AppFileTxt = AppFileTxt &
            BatFileFooter

            WriteTxtToFile(InstRoot & InstallAppFile, AppFileTxt, True, 0, "", "", True, True)
        Else
            AppFileTxt = AppFileTxt &
                "@echo ---- End Application Install --------------------" & vbCrLf & vbCrLf

            WriteTxtToFile(InstRoot & InstallStartFile, AppFileTxt, True, 0, "", "", True, True)
        End If

        xtrace_sube("Add_Installation_Application")
    End Sub

End Module
