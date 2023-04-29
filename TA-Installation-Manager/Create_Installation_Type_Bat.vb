Imports System.Security.Policy
Imports System.IO

Module Create_Installation_Type_Bat
    '==== Frequently used strings
    Dim BatRemStr As String
    Dim BatFileHeader As String
    Dim BatFileFooter As String
    Dim BatTimeStamp As String
    Dim InstBat As String
    Dim InstData As String
    Dim CRLTL As Integer = 2   ' Create Rem Line Trace Level

    '==== Short notation of write to batch file
    Dim OutFile As String
    Dim InstallStartFile As String = "\bat\Install.bat"

    Sub WTI(Content As String)  ' Default append
        xtrace_subs("WTI", CRLTL)
        WT(Content, True, "I")
        xtrace_sube("WTI", CRLTL)
    End Sub
    Sub WTI(Content As String, Append As Boolean)
        xtrace_subs("WTI", CRLTL)
        WT(Content, Append, "I")
        xtrace_sube("WTI", CRLTL)
    End Sub

    Sub WTO(Content As String)  ' Default append
        xtrace_subs("WTO", CRLTL)
        WT(Content, True, "O")
        xtrace_sube("WTO", CRLTL)
    End Sub
    Sub WTO(Content As String, Append As Boolean)
        xtrace_subs("WTO", CRLTL)
        WT(Content, Append, "O")
        xtrace_sube("WTO", CRLTL)
    End Sub
    Sub WT(Content As String, Append As Boolean, OID As String)
        xtrace_subs("WT", CRLTL)

        Dim Output As String
        If OID = "I" Then
            Output = InstallStartFile
        ElseIf OID = "O" Then
            Output = OutFile
        Else
            Output = OutFile
        End If

        If Content Is Nothing Then
            Content = ":: "
            xtrace_i("Warning: WT" & OID & " Content is nothing")
        End If

        'Content = Content.Replace("'", """")
        WriteTxtToFile(InstRoot & Output, Content & vbCrLf, Append, 0, "", "", True, True)

        xtrace_sube("WT", CRLTL)
    End Sub

    '---- Create echo line with title
    Function CreRemLine(Msg As String)
        xtrace_subs("CreRemLine", CRLTL)
        xtrace_i("Input: " & Msg, CRLTL)
        If BatRemStr Is Nothing Then SetBatRemString()

        Msg = BatRemStr & "---- " & Msg & " --------------------------------------------------"
        Msg = Left(Msg, 60)
        CreRemLine = Msg

        xtrace_i("Return: " & Msg, CRLTL)
        xtrace_sube("CreRemLine", CRLTL)
    End Function

    ' Both lines produce the same result
    ' WTO(WriteMsg("Initializing"))
    ' WTO("%WRITE% ' * Initializing'")
    Function WriteMsg(Msg As String)
        Msg = "%WRITE% "" * " & Msg & """"
        WriteMsg = Msg
    End Function

    '---- Create line proc start ---------------------------------------------------
    Function CreRemLineProcStart(Msg As String)
        xtrace_subs("CreRemLineProcStart", CRLTL)

        Msg = System.IO.Path.GetFileName(Msg)
        Msg = CreRemLine("Start: " & Msg)
        CreRemLineProcStart = Msg

        xtrace_i("Return: " & Msg, CRLTL)
        xtrace_sube("CreRemLineProcStart", CRLTL)
    End Function

    '---- Create line proc end ---------------------------------------------------
    Function CreRemLineProcEnd(Msg As String)
        xtrace_subs("CreRemLineProcEnd", CRLTL)

        Msg = System.IO.Path.GetFileName(Msg)
        Msg = CreRemLine("End: " & Msg)
        CreRemLineProcEnd = Msg

        xtrace_i("Return: " & Msg, CRLTL)
        xtrace_sube("CreRemLineProcEnd", CRLTL)
    End Function

    '---- Set the bat remark string ------------------------------------------------

    Sub SetBatRemString()
        xtrace_subs("SetBatRemString", CRLTL)

        If RemType = "REM" Then BatRemStr = "REM "
        If RemType = "::" Then BatRemStr = "::"
        If RemType = "echo" Then BatRemStr = "@echo "
        If RemType = "#" Then BatRemStr = "# "
        xtrace_i("BatRemStr     = " & BatRemStr, CRLTL)

        BatFileHeader =
            BatRemStr & "---- Start %~n0 ------------------------------------------" & vbCrLf &
            BatRemStr & "Created by " & AppName & " V" & AppVer
        BatFileFooter =
            vbCrLf &
            ":END" & vbCrLf &
            BatRemStr & "---- End %~n0 --------------------------------------------"
        BatTimeStamp =
            BatRemStr & "Timestamp: %DATE% / %TIME%"

        xtrace_i("BatFileHeader = " & BatFileHeader, CRLTL)
        xtrace_i("BatFileFooter = " & BatFileFooter, CRLTL)
        xtrace_i("BatTimeStamp  = " & BatTimeStamp, CRLTL)

        xtrace_sube("SetBatRemString", CRLTL)
    End Sub

    '==== Add Installation Components Bat ==========================================
    Sub Add_Installation_Components_Bat()
        xtrace_line()
        xtrace_subs("Add_Installation_Components_Bat")

        InstBat = InstRoot & "\bat"
        InstData = InstRoot & "\data"

        InstBackup()

        Form1.SetStatus("Create Installation (Bat)")
        '---- Create directories for InstType .bat

        Dim CheckDir, SD As String
        For Each SD In {"Inst\bat\util"}
            CheckDir = DepoPath & "\" & SD
            xtrace_i("Check : " & CheckDir)
            If Not My.Computer.FileSystem.DirectoryExists(CheckDir) Then
                CreateDirectory(CheckDir, 0, "", "Please check your directory access rights", True, True)
            End If
        Next

        SetBatRemString()
        AddInstFile((RemType = "#"), "#.exe", "Inst\exe")

        '---- Create bat\Install.bat
        xtrace_i("Create " & InstallStartFile)
        WTI(":: Created by : " & AppName & " V" & AppVer, False)
        WTI(":: Date       : " & DateTime.Now.ToString("yyyy-MM-dd"))
        WTI("echo on")
        WTI("title " & InstName & " Installation")
        WTI("echo Starting the " & InstName & " installation >%ICL%")
        WTI("echo  * INSTROOT = %INSTROOT% >>%ICL%")
        WTI("")
        If Form1.ListEnvironmentToolStripMenuItem.Checked Then
            xtrace_i("Add list environment")
            WTI("set >%INSTTMP%\env1.txt")
        Else
            xtrace_i("List environment is off")
        End If

        '---- Create bat\init.bat
        Add_Installation_Init()

        '---- Create Site/Group config
        If Form1.CheckBoxDeptConfigs.Checked Then
            Add_DeptConfig()
        Else
            xtrace_i("No Dept config")
        End If

        '---- Create Application Install bat
        Add_Installation_Application()

        '---- Create post installation file or section
        Add_Post_Installation()

        ' It is not possible to integrate this file, keep it separate
        '---- Create util\exit.bat
        Add_Util_Exit()

        '---- Add Readme
        Add_Readme()

        '---- Add DeInstallation
        If (Form1.CheckBoxTADeinstall.Checked) Or (Form1.CheckBoxTASelect.Checked) Then
            xtrace_i("TADeinstall Checked = " & Form1.CheckBoxTADeinstall.Checked.ToString)
            xtrace_i("CheckBoxTASelect Checked = " & Form1.CheckBoxTASelect.Checked.ToString)
            Add_DeinstallationBat()
        Else
            Dim CheckFile As String = InstRoot & "\bat\09_After_Install.bat"
            xtrace_i("Check: " & CheckFile)
            If My.Computer.FileSystem.FileExists(CheckFile) Then
                My.Computer.FileSystem.DeleteFile(CheckFile)
            End If
        End If

        '---- Add exe files
        AddInstFile(True, "wait.exe", "Inst\Exe")
        AddInstFile(Form1.RadioButtonRemHash.Checked, "#.exe", "Inst\Exe")  ' 2023-04-18


        xtrace_sube("Add_Installation_Components_Bat")
    End Sub

    '==== Write Init ====================================================================
    Sub Add_Installation_Init()
        xtrace_subs("Add_Installation_Init")

        OutFile = "\bat\01_init.bat"

        Dim SeparateFile As Boolean = Form1.CheckBoxBatSeparateInit.Checked
        xtrace_i("Separate file = " & SeparateFile.ToString)

        If SeparateFile Then
            xtrace_i("Write call in the start file")
            WTI("call ""%instroot%" & OutFile & """")

            ' Write the file header
            xtrace_i("Create " & OutFile)
            WTO(BatFileHeader, False)
            WTO(BatTimeStamp)
        Else
            ' Remove the separate file if it exists
            DeleteFile(InstRoot & OutFile, 0, "", "", True, False)

            xtrace_i("Write the section header")
            WTI("")
            WTI(CreRemLine("Start Init"))
            WTI("")
            WTI(BatTimeStamp)

            OutFile = InstallStartFile
        End If

        ' Set init body txt
        WTO("%WRITE% ' * Initializing'")
        WTO("")

        If Form1.CheckBoxDeptConfigs.Checked Then
            xtrace_i("Add site init")
            WTO(CreRemLine("Default TA_SITE?"))
            ' todo
            WTO("set ALLOW_DEFAULT_SITE=TRUE")
            WTO("")
            WTO("if %ALLOW_DEFAULT_SITE%==FALSE if '%TA_SITE%'=='' call '%InstLibBat%\Err_Fatal_Msg' No_Site")
            WTO("if %ALLOW_DEFAULT_SITE%==TRUE if '%TA_SITE%'=='' set TA_SITE=" & Form1.TextBoxDept.Lines(0))
            WTO("")
            WTO(CreRemLine("Set TA_SITE"))
            WTO("echo  * TA_SITE = %TA_SITE% >>%ICL%")
            WTO("set site_conf=%instroot%\bat\%TA_SITE%")
            WTO("set site_data=%instroot%\data\%TA_SITE%")
            WTO("@if not exist '%site_conf%\site_init.bat' %WRITE% 'ERROR: site_init does not exist' & call '%util%\exit'")
            WTO("call '%site_conf%\site_init'")
            WTO("")
        End If

        WTO(CreRemLine("Processor Architecture"))
        WTO("set PA=%PROCESSOR_ARCHITECTURE%
if %PA%==x86   set WPBIT=32
if %PA%==AMD64 set WPBIT=64
@if '%WPBIT%'=='' %WRITE% 'Error: Failed to detect the Processor Architecture' & call '%util%\exit'

set instexe_pa=%instroot%\exe\W%WPBIT%
set SOURCE_PA=%SOURCEPATH%\W%WPBIT%

:: set path=%instexe_pa%;%InstLibExe%;%path%
")
        If Form1.CheckBoxSetWinLocations.Checked Then
            WTO("call '%InstLibBat%\set_win_locations'")
            WTO("")
        End If

        If (ContentInit = "") Or (ContentInit Is Nothing) Then
            WTO(":: Add additional initialization content here")
        Else
            WTO(ContentInit)    ' Optional Wizard Content
        End If

        If Form1.CheckBoxStopUpdates.Checked Then
            WTO("call '%InstLibBat%\stop_updates' START")
        End If


        ' Add footer and write
        If SeparateFile Then
            WTO(BatFileFooter)
        Else
            WTI(CreRemLine("End Init"))
            WTI("")
        End If

        xtrace_sube("Add_Installation_Init")
    End Sub

    '==== Write Dept Config =============================================================

    Sub Add_DeptConfig()
        xtrace_subs("Add_DeptConfig")

        Dim Dept As String
        Dim Content As String
        ' Write call in install
        WTI("call ""%site_conf%\site_init.bat""")

        ' Create Dept-Dirs
        For Each Dept In Form1.TextBoxDept.Lines
            If Dept.Length < 2 Then Continue For

            xtrace_i("Dept : " & Dept)
            CreateDirectory(InstBat & "\" & Dept, 0, "", "Please check your directory access rights", True, True)
            CreateDirectory(InstData & "\" & Dept, 0, "", "Please check your directory access rights", True, True)

            ' Create Dept-Scripts
            Content = BatFileHeader & vbCrLf &
                "echo  * " & Dept & " site init >>%ICL%" & vbCrLf &
                vbCrLf &
                BatFileFooter & vbCrLf
            WriteTxtToFile(InstBat & "\" & Dept & "\site_init.bat", Content, False, 0, "", "", True, True)

            If Form1.CheckBoxBatSeparatePost.Checked Then
                Content = BatFileHeader & vbCrLf &
                    "echo  * " & Dept & " site post inst >>%ICL%" & vbCrLf &
                    vbCrLf &
                    BatFileFooter & vbCrLf
                WriteTxtToFile(InstBat & "\" & Dept & "\site_post_inst.bat", Content, False, 0, "", "", True, True)
            End If
        Next
        ' Create Select Config

        xtrace_sube("Add_DeptConfig")
    End Sub

    '==== Write Application Installation ================================================
    Sub Add_Installation_Application()
        xtrace_subs("Add_Installation_Application")

        OutFile = "\bat\05_" & InstName & ".bat"

        Dim SeparateFile As Boolean = Form1.CheckBoxBatSeparateApp.Checked
        xtrace_i("Separate file = " & SeparateFile.ToString)

        If SeparateFile Then
            ' Write call in the start file
            WTI("call ""%instroot%" & OutFile & """")

            ' Write the file header
            xtrace_i("Create " & OutFile)
            WTO(BatFileHeader, False)
            WTO(BatTimeStamp)
        Else
            ' Remove the separate file if it exists
            DeleteFile(InstRoot & OutFile, 0, "", "", True, False)

            ' Write the section header
            WTI("")
            WTI(CreRemLine("Start Application Install"))
            WTI(BatTimeStamp)

            OutFile = InstallStartFile
        End If

        xtrace_i("Write Application Install body")
        WTO(WriteMsg("Start %appname% Installation"))
        WTO("")
        WTO(CreRemLine("Check if the installation exists"))
        WTO("")
        If ContentTestIfExist <> "" Then
            Dim Test As String
            For Each Test In ContentTestIfExist.Split(";")
                WTO("if exist """ & Test & """ goto :EXISTS")
            Next
            WTO("")
        End If

        WTO(CreRemLine("Verify"))
        WTO("")

        '---- Copy Source files #1
        If Form1.CheckBoxCopySource.Checked = True Then
            xtrace_i("Add copy source files")
            WTO("")
            WTO(CreRemLine("Copy source files"))
            WTO("")
            WTO("%WRITE% ' * Preparing...'")
            WTO("set ARCHIVES=%INSTTMP%\Archives")
            WTO("If Not exist %ARCHIVES% md %ARCHIVES%")
            WTO(":: /Z = Restartable Mode")
            WTO(":: /J = Unbuffered for large files")
            WTO(":: /R = Retry")
            WTO(":: /W = Wait time in Sec.")
            WTO("robocopy '%SOURCEPATH%' '%ARCHIVES%' /mir /Z /J /R:3 /W:10 /FFT  /LOG+:'%INSTTMP%\CopyArchives.Log'")
            WTO("set RESULTC=%ERRORLEVEL%")
            WTO("")
        End If

        '---- Extract
        Dim AddExtr As Boolean = ((ContentAIExtr <> "") Or Form1.CheckBoxExtract.Checked)

        If AddExtr Then
            WTO(CreRemLine("Extract Installation Archive"))
            WTO("")
            WTO("SET INST=%InstTmp%\Inst")
            WTO("If Not exist %INST% md %INST%")

        End If

        If (ContentAIExtr <> "") Then
            WTO(ContentAIExtr)      ' Extract command supplied by wizard
        ElseIf Form1.CheckBoxExtract.Checked Then
            WTO(":: ToDo")
            WTO(":: '%InstLibExe%\unzip' -od '%InstTarget%' 'ArchDir\ArchName'")
            WTO(":: '%InstLibExe%\W64\7z.exe' x %ARCHIVES%\Archive.zip -o'%Inst%' -aoa")
        End If

        If AddExtr Then
            WTO("SET RESULTE=%ERRORLEVEL%")
            WTO("")
            WTO("if /i not '%TA_INST_KEEP_ARCHIVES%'=='TRUE' rd /s/q '%ARCHIVES%'")
            WTO("")

            WTO(CreRemLine("Start the App installation."))
            WTO("")
        End If

        If Form1.ListEnvironmentToolStripMenuItem.Checked Then WTI("set >%INSTTMP%\env2.txt")
        '--- Start Debug Console
        If Form1.AddDebugPromptToolStripMenuItem.Checked Then
            WTO("Start ""Debug Prompt"" cmd")
        End If

        If ContentInstCmd = "" Then
            WTO(":: Add the installation command here")
        Else
            WTO(ContentInstCmd)
        End If
        WTO("SET RESULTI=%ERRORLEVEL%")
        WTO("")
        WTO(CreRemLine("App Settings"))
        WTO(":APPSET")
        WTO("")
        WTO("goto INSTDONE")
        WTO("")
        WTO(CreRemLine("Messages"))
        WTO("")
        WTO(":EXISTS")
        WTO("   %WRITE% ' * %appname% Already exists'")
        WTO("   goto APPSET")
        WTO("")
        WTO(CreRemLine("End Inst"))
        WTO(":INSTDONE")
        WTO(BatTimeStamp)
        WTO("")

        ' Add footer
        If SeparateFile Then
            WTO(BatFileFooter)
        Else
            WTO(CreRemLine("End Application Install"))
        End If

        xtrace_sube("Add_Installation_Application")
    End Sub

    '==== Write Post Installation file or section =======================================

    Sub Add_Post_Installation()
        xtrace_subs("Add_Post_Installation")

        OutFile = "\bat\09_After_Install.bat"

        Dim SeparateFile As Boolean = Form1.CheckBoxBatSeparatePost.Checked
        xtrace_i("Separate file = " & SeparateFile.ToString)

        If SeparateFile Then
            ' Write call in the start file
            WTI("call '%instroot%" & OutFile & "'")

            ' Write the file header
            xtrace_i("Create " & OutFile)
            WTO(BatFileHeader, False)
            WTO(BatTimeStamp)
        Else
            ' Remove the separate file if it exists
            DeleteFile(InstRoot & OutFile, 0, "", "", True, False)

            ' Write the section header
            WTI("")
            WTI(CreRemLine("Start Post Installation"))
            WTI(BatTimeStamp)
            WTI("")

            OutFile = InstallStartFile
        End If

        ' Set Application Install body txt
        WTO(":: Add Post Installation Content Here")
        WTO("")

        If ContentAutoStart <> "" Then
            WTO(":: Auto start " & AppName)
            Dim RegKeyAutoStart As String = "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run"
            Dim Line As String = "reg add " & RegKeyAutoStart & " /v %AppName% /d '%InstTarget%\" & ContentAutoStart & "' /f"
            WTO(Line)
            WTO("")
        End If

        If Form1.CheckBoxDeptConfigs.Checked Then
            WTO("call ""%site_conf%\site_post_inst.bat""")
            WTO("")
        End If

        ' Add footer and write
        If SeparateFile Then
            WTO(BatFileFooter)
        Else
            WTI(CreRemLine("End Post Installation"))
            WTI("")
        End If

        xtrace_sube("Add_Post_Installation")
    End Sub

    '==== Write Util\Exit ===============================================================

    Sub Add_Util_Exit()
        xtrace_subs("Add_Util_Exit")

        ' Write call in the start file
        WTI("")
        WTI(BatTimeStamp)
        WTI("echo Installation finished! >>%ICL%")
        WTI("call '%util%\exit'")

        OutFile = "\bat\util\exit.bat"
        xtrace_i("Create " & OutFile)
        WTO(BatFileHeader, False)
        WTO("")
        WTO("%WRITE% ' * Finalizing'")
        WTO("")

        If Form1.CheckBoxStopUpdates.Checked Then
            WTO("call '%InstLibBat%\stop_updates' FINISH")
        End If

        If Form1.CheckBoxLogToServer.Checked Then
            WTO("call '%InstLibBat%\log-to-server'")
        End If

        WTO("")
        WTO("echo  Done. >con")
        WTO("wait 10 >con")
        WTO("%WRITE% ' Done.'")
        WTO("wait 10 > con")
        WTO(BatFileFooter)
        WTO("exit 0")

        xtrace_sube("Add_Util_Exit")
    End Sub

    '==== Add Readme

    Sub Add_Readme()
        xtrace_subs("Add_Readme")
        If (ContentReadme <> "") Then
            ContentReadme = ContentReadme.Replace(";", vbCrLf)
            OutFile = "\..\Readme.txt"
            WTO(ContentReadme, False)
        End If
        xtrace_sube("Add_Readme")
    End Sub



    '==== Add Deinstallation Bat ====

    Sub Add_DeinstallationBat()
        xtrace_subs("Add_DeinstallationBat")

        Dim DeinstallationFile, DeinstallationFileTxt
        DeinstallationFile = "\bat\DeInstall.bat"
        xtrace_i("Create " & DeinstallationFile)

        If ContentMsiDeinstall = "" Then ContentMsiDeinstall = "# MsiExec.exe /X{XX} /q"

        DeinstallationFileTxt = BatFileHeader & vbCrLf &
            BatTimeStamp & "
if '%ICL%'==''     set ICL=%TEMP%\Remove_%AppName%.log
if '%INSTTMP%'=='' set INSTTMP=C:\Temp
title %InstTitle%
echo on

%WRITE% ' * Init'

rem Seek installation directory
set APPL_BASE_DIR=xxx

if exist '%ProgramFiles%\XX'  SET APPL_BASE_DIR=%ProgramFiles%\XX

%WRITE% ' * %AppName% Root Dir = %APPL_BASE_DIR%'

@echo ---- Start the de-installation ----------------------
:START
%WRITE% ' * Start de-installation'
 " &
 ContentMsiDeinstall & vbCrLf &
"

echo  * De-installation finished >>%ICL%

@echo ---- Cleanup ----------------------------------------
%WRITE% ' * Post de-installation cleanup'

:: allow quitting accidental startup
%instexe%\wait 6


@echo ---- Files -----------------
echo  * Removing files >>%ICL%

if not '%APPL_BASE_DIR%'=='xxx' rd /s/q '%APPL_BASE_DIR%'
rd /s/q 'C:\Temp\Inst_%AppName%_logs'

@echo ---- User profiles ---------
:UPROF
echo  * Cleanup Userprofiles >>%ICL%

FOR /F %%D IN (^'dir /B /A:D C:\Users^') DO CALL :UPROF_DEL %%D
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

reg delete 'HKLM\SOFTWARE\XX' /f

@echo ---- firewall --------------

goto DONE

rem ---- Errors ---------------------------------------------------------------

:ERR1
   %WRITE% 'Error: %AppName% installation not found'
   goto DONE

rem ---- Exit -----------------------------------------------------------------

:DONE
   echo Done

" & BatFileFooter

        WriteTxtToFile(InstRoot & DeinstallationFile, DeinstallationFileTxt, False, 0, "", "", True, True)

        xtrace_sube("Add_DeinstallationBat")
    End Sub


End Module
