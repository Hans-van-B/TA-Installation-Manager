Module Create_Installation_Type_Bat

    Dim BatFileHeader As String = "@echo ---- Start %~n0 ----------------------------" & vbCrLf & ":: Created by " & AppName & " V" & AppVer & vbCrLf
    Dim BatFileFooter As String = "@echo ---- End %~n0 ------------------------------" & vbCrLf
    Sub Add_Installation_Components_Bat()
        xtrace_subs("Add_Installation_Components_Bat")

        Dim CheckDir, SD As String
        For Each SD In {"Inst\bat\util"}
            CheckDir = DepoPath & "\" & SD
            xtrace_i("Check : " & CheckDir)
            If Not My.Computer.FileSystem.DirectoryExists(CheckDir) Then
                CreateDirectory(CheckDir, 0, "", "Please check your directory access rights", True, True)
            End If
        Next


        Dim CreateFile As String = "\bat\Install.bat"
        xtrace_i("Create " & CreateFile)
        Dim StartFile As String =
            ":: Created by : " & AppName & " V" & AppVer & vbCrLf &
            ":: Date       : " & DateTime.Now.ToString("yyyy-MM-dd") & vbCrLf &
            "echo on" & vbCrLf &
            "title " & InstName & " Installation" & vbCrLf &
            "echo Starting the " & InstName & " installation >%ICL%" & vbCrLf &
            "echo  * INSTROOT = %INSTROOT% >>%ICL%" & vbCrLf &
            vbCrLf &
            "call ""%instroot%\bat\init""" & vbCrLf &
            "call ""%instroot%\bat\05_" & InstName & ".bat""" & vbCrLf &
            vbCrLf &
            "if exist ""%instroot%\bat\09_After_Install.bat"" call ""%instroot%\bat\09_After_Install""" & vbCrLf &
            vbCrLf &
            "echo Installation finished! >>%ICL%" & vbCrLf &
            "call ""%util%\exit""" & vbCrLf

        WriteTxtToFile(InstRoot & CreateFile, StartFile, False, 0, "", "", True, True)


        CreateFile = "\bat\util\exit.bat"
        xtrace_i("Create " & CreateFile)
        StartFile = BatFileHeader &
            "echo  Done. >con" & vbCrLf &
            "wait 10 >con" & vbCrLf &
            BatFileFooter

        WriteTxtToFile(InstRoot & CreateFile, StartFile, False, 0, "", "", True, True)

        AddInstFile(True, "Inst\Exe\wait.exe")

        xtrace_sube("Add_Installation_Components_Bat")
    End Sub
End Module
