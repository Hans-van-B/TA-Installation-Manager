Module Create_Installation_Type_Bat
    '==== Frequently ysed strings
    Dim BatFileHeader As String = "@echo ---- Start %~n0 ----------------------------" & vbCrLf & ":: Created by " & AppName & " V" & AppVer
    Dim BatFileFooter As String = vbCrLf & ":END" & vbCrLf & "@echo ---- End %~n0 ------------------------------"
    Dim BatTimeStamp As String = "@echo Timestamp: %DATE% / %TIME%"

    '==== Short notation of write to batch file
    Dim OutFile As String
    Dim InstallStartFile As String = "\bat\Install.bat"

    Sub WTI(Content As String)
        WriteTxtToFile(InstRoot & InstallStartFile, Content & vbCrLf, False, 0, "", "", True, True)
    End Sub

    Sub WTO(Content As String)
        WriteTxtToFile(InstRoot & OutFile, Content & vbCrLf, False, 0, "", "", True, True)
    End Sub
    '---- Create echo line with title
    Function CreateELine(Msg As String)
        Msg = "@echo ---- " & Msg & " "
        Msg.PadRight(60, "-")
        CreateELine = Msg
    End Function

    Function WriteMsg(Msg As String)
        Msg = "%WRITE% "" * " & Msg & """"
        WriteMsg = Msg
    End Function

    '==== Add Installation Components Bat ==========================================
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
        xtrace_i("Create " & InstallStartFile)
        WTI(":: Created by : " & AppName & " V" & AppVer)
        WTI(":: Date       : " & DateTime.Now.ToString("yyyy-MM-dd"))
        WTI("echo on")
        WTI("title " & InstName & " Installation")
        WTI("echo Starting the " & InstName & " installation >%ICL%")
        WTI("echo  * INSTROOT = %INSTROOT% >>%ICL%")
        WTI("")

        '---- Create bat\init.bat
        Add_Installation_Init()

        '---- Create Application Install bat
        Add_Installation_Application()

        '---- Create post installation file or section
        Add_Post_Installation()

        ' It is not possible to integrate this file, keep it separate
        '---- Create util\exit.bat
        Add_Util_Exit()

        '---- Add DeInstallation
        If (Form1.CheckBoxTADeinstall.Checked) Or (Form1.CheckBoxTASelect.Checked) Then
            Add_DeinstallationBat()
        End If

        '---- Add exe files
        AddInstFile(True, "Inst\Exe\wait.exe")

        xtrace_sube("Add_Installation_Components_Bat")
    End Sub

    '==== Write Init ====================================================================
    Sub Add_Installation_Init()
        xtrace_subs("Add_Installation_Init")

        OutFile = "\bat\01_init.bat"

        Dim SeparateFile As Boolean = Form1.CheckBoxBatSeparateInit.Checked

        If SeparateFile Then
            ' Write call in the start file
            WTI("call ""%instroot%" & OutFile & """")

            ' Write the file header
            xtrace_i("Create " & OutFile)
            WTO(BatFileHeader)
            WTO(BatTimeStamp)
        Else
            OutFile = InstallStartFile

            ' Remove the separate file if it exists
            DeleteFile(InstRoot & OutFile, 0, "", "", True, False)

            ' Write the section header
            WTI("")
            WTI(CreateELine("Start Init"))
            WTI("")
            WTI(BatTimeStamp)
        End If

        ' Set init body txt
        WTO(WriteMsg("Initializing"))
        WTO(":: Add initialization conten here")

        ' Add footer and write
        If SeparateFile Then
            WTO(BatFileFooter)
        Else
            WTI(CreateELine("End Init"))
            WTI("")
        End If

        xtrace_sube("Add_Installation_Init")
    End Sub

    '==== Write Application Installation ================================================
    Sub Add_Installation_Application()
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
            OutFile = InstallAppFile
        Else
            ' Remove the separate file if it exists
            DeleteFile(InstRoot & InstallAppFile, 0, "", "", True, False)

            ' Write the section header
            AppFileTxt = vbCrLf & "@echo ---- Start Application Install -----------------------" & vbCrLf & BatTimeStamp
            WriteTxtToFile(InstRoot & InstallStartFile, AppFileTxt, True, 0, "", "", True, True)
            OutFile = InstallStartFile
        End If

        ' Set Application Install body txt
        AppFileTxt = "
%WRITE% "" * Start %appname% Installation""
            
@echo ---- Check if the installation exists ---------------

@echo ---- Verify -----------------------------------------

"
        WriteTxtToFile(InstRoot & OutFile, AppFileTxt, True, 0, "", "", True, True)

        '---- Copy Source files #1
        If Form1.CheckBoxCopySource.Checked = True Then
            xtrace_i("Add copy source files")
            AppFileTxt = "
@echo ---- Copy source files ------------------------------

set ARCHIVES=%INSTTMP%\Archives
robocopy ""%SOURCEPATH%"" ""%ARCHIVES%"" /mir /r:3 /w:10 /FFT

"
            WriteTxtToFile(InstRoot & OutFile, AppFileTxt, True, 0, "", "", True, True)
        End If

        AppFileTxt = "

@echo ---- Start the App installation. --------------------

:: Add the installation command here
@echo Result = %ERRORLEVEL%

@echo ---- App Settings -----------------------------------
:APPSET

goto DONE

::---- Messages ---------------------------------

:EXISTS
    echo  * %appname% Already exists >> %ICL%
    goto APPSET

::---- Exit -------------------------------------
:DONE

"

        ' Add footer and write
        If SeparateFile Then
            AppFileTxt = AppFileTxt &
            BatFileFooter
        Else
            AppFileTxt = AppFileTxt &
                "@echo ---- End Application Install ------------------------" & vbCrLf & vbCrLf
        End If
        WriteTxtToFile(InstRoot & OutFile, AppFileTxt, True, 0, "", "", True, True)

        xtrace_sube("Add_Installation_Application")
    End Sub

    '==== Write Post Installation file or section =======================================

    Sub Add_Post_Installation()
        xtrace_subs("Add_Post_Installation")
        Dim StartFileTxt As String

        Dim PostFileTxt As String
        Dim PostFile As String = "\bat\09_After_Install.bat"

        Dim SeparateFile As Boolean = Form1.CheckBoxBatSeparatePost.Checked
        If SeparateFile Then
            ' Write call in the start file
            StartFileTxt = "call ""%instroot%" & PostFile & """" & vbCrLf
            WriteTxtToFile(InstRoot & InstallStartFile, StartFileTxt, True, 0, "", "", True, True)

            ' Write the file header
            xtrace_i("Create " & PostFile)
            PostFileTxt = BatFileHeader &
                BatTimeStamp
            WriteTxtToFile(InstRoot & PostFile, PostFileTxt, False, 0, "", "", True, True)
        Else
            ' Remove the separate file if it exists
            DeleteFile(InstRoot & PostFile, 0, "", "", True, False)

            ' Write the section header
            PostFileTxt = vbCrLf & "@echo ---- Start Post Installation ------------------------" & vbCrLf & BatTimeStamp
            WriteTxtToFile(InstRoot & InstallStartFile, PostFileTxt, True, 0, "", "", True, True)
        End If

        ' Set Application Install body txt
        PostFileTxt = ":: Add Post Installation Content Here" & vbCrLf

        ' Add footer and write
        If SeparateFile Then
            PostFileTxt = PostFileTxt &
            BatFileFooter

            WriteTxtToFile(InstRoot & PostFile, PostFileTxt, True, 0, "", "", True, True)
        Else
            PostFileTxt = PostFileTxt &
                "@echo ---- End Post Installation --------------------" & vbCrLf & vbCrLf

            WriteTxtToFile(InstRoot & InstallStartFile, PostFileTxt, True, 0, "", "", True, True)
        End If

        xtrace_sube("Add_Post_Installation")
    End Sub

    '==== Write Util\Exit ===============================================================

    Sub Add_Util_Exit()
        xtrace_subs("Add_Util_Exit")
        Dim StartFileTxt As String

        ' Write call in the start file
        StartFileTxt = vbCrLf &
            BatTimeStamp &
            "echo Installation finished! >>%ICL%" & vbCrLf &
            "call ""%util%\exit""" & vbCrLf
        WriteTxtToFile(InstRoot & InstallStartFile, StartFileTxt, True, 0, "", "", True, True)


        Dim ExitFile, ExitFileTxt
        ExitFile = "\bat\util\exit.bat"
        xtrace_i("Create " & ExitFile)
        ExitFileTxt = BatFileHeader &
            vbCrLf &
            "%WRITE% "" * Finalizing""" & vbCrLf &
            vbCrLf

        If Form1.CheckBoxStopUpdates.Checked Then
            ExitFileTxt = ExitFileTxt & "call ""%InstLibBat%\stop_updates"" FINISH" & vbCrLf
        End If

        If Form1.CheckBoxLogToServer.Checked Then
            ExitFileTxt = ExitFileTxt & "call ""%InstLibBat%\log-to-server""" & vbCrLf
        End If

        ExitFileTxt = ExitFileTxt &
            vbCrLf &
            "echo  Done. >con" & vbCrLf &
            "wait 10 >con" & vbCrLf &
            BatFileFooter &
            "exit 0" & vbCrLf

        WriteTxtToFile(InstRoot & ExitFile, ExitFileTxt, False, 0, "", "", True, True)

        xtrace_sube("Add_Util_Exit")
    End Sub

    '==== Add Deinstallation Bat ====

    Sub Add_DeinstallationBat()
        xtrace_subs("Add_DeinstallationBat")

        Dim DeinstallationFile, DeinstallationFileTxt
        DeinstallationFile = "\bat\DeInstall.bat"
        xtrace_i("Create " & DeinstallationFile)

        DeinstallationFileTxt = BatFileHeader & BatTimeStamp & "
if ""%ICL%""==""""     set ICL=%TEMP%\Remove_%AppName%.log
if ""%INSTTMP%""=="""" set INSTTMP=C:\Temp
title %InstTitle%
echo on

%WRITE% "" * Init""

rem Seek installation directory
set APPL_BASE_DIR=xxx

if exist ""%ProgramFiles%\XX""  SET APPL_BASE_DIR=%ProgramFiles%\XX

%WRITE% "" * %AppName% Root Dir = %APPL_BASE_DIR%""

@echo ---- Start the de-installation ----------------------
:START
%WRITE% "" * Start de-installation""

MsiExec.exe /X{XX} /q

echo  * De-installation finished >>%ICL%

@echo ---- Cleanup ----------------------------------------
%WRITE% "" * Post de-installation cleanup""

:: allow quitting accidental startup
%instexe%\wait 6


@echo ---- Files -----------------
echo  * Removing files >>%ICL%

if not ""%APPL_BASE_DIR%""==""xxx"" rd /s/q ""%APPL_BASE_DIR%""
rd /s/q ""C:\Temp\Inst_%AppName%_logs""

@echo ---- User profiles ---------
:UPROF
echo  * Cleanup Userprofiles >>%ICL%

FOR /F %%D IN ('dir /B /A:D C:\Users') DO CALL :UPROF_DEL %%D
goto ICONS

:UPROF_DEL
	set updir=C:\Users\%1
	echo     - %updir% >>%ICL%
	rd /s/q %updir%\XX
	goto :EOF

@echo ---- Icons -----------------
:ICONS
echo  * Removing icons >>%ICL%


@echo ---- Environment -----------
echo  * Cleanup the environment >>%ICL%

@echo ---- Registry --------------
echo  * Cleanup the registry >>%ICL%

reg delete ""HKLM\SOFTWARE\XX"" /f

@echo ---- firewall --------------

goto DONE

rem ---- Errors ---------------------------------------------------------------

:ERR1
   %WRITE% ""Error: %AppName% installation not found""
   goto DONE

rem ---- Exit -----------------------------------------------------------------

:DONE
   echo Done

" & BatFileFooter

        WriteTxtToFile(InstRoot & DeinstallationFile, DeinstallationFileTxt, False, 0, "", "", True, True)

        xtrace_sube("Add_DeinstallationBat")
    End Sub


End Module
