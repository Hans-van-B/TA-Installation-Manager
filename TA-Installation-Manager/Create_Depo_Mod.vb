Imports System.Windows.Forms.VisualStyles

Module Create_Depo_Mod
    Public LocDepoCreateProcFileName As String = BinLib & "\Create_Local_Depo_Share.bat"
    Public LocDepoDeleteProcFileName As String = BinLib & "\Undo_Local_Depo_Share.bat"

    Dim RegKey As String = "HKEY_CURRENT_USER\Software\TA\TA-Installation-Manager"
    Sub Create_Local_Depo_Share()
        xtrace_subs("Create_Local_Depo_Share")
        Form1.SetStatus("Create local depo share procedure")

        Dim DriveLetters() As String = {"I", "T", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U", "V", "W", "X", "Y", "Z"}
        Dim DriveLetter As String = "I:"
        Dim TryDl As String

        For Each TryDl In DriveLetters
            If Not My.Computer.FileSystem.DirectoryExists(TryDl & ":\.") Then
                DriveLetter = TryDl & ":"
                Exit For
            End If
        Next

        Dim ShareDir As String = Form1.TextBoxNewDepo.Text
        Dim ProcContent As String = "@If not '%DEBUG%'=='TRUE' echo Off
TITLE Create Local Depo Share

set SHARE_DIR=" & ShareDir & "
set SHARENAME=Depo
set DEPODRV=" & DriveLetter & "

:CREATESHARE
if exist \\%COMPUTERNAME%\%SHARENAME% goto MAPDRIVE
"
        If Form1.CheckBoxLocalGroups.Checked Then
            ProcContent = ProcContent & "
if not exist '%SHARE_DIR%' md '%SHARE_DIR%'
if not exist '%SHARE_DIR%\TA_InstLib' (
    md '%SHARE_DIR%\TA_InstLib\04\Inst\bat'
    md '%SHARE_DIR%\TA_InstLib\04\Inst\data'
    md '%SHARE_DIR%\TA_InstLib\04\Inst\exe'
    )

NET LOCALGROUP TA_DEPO_Admin /ADD /COMMENT:'Provides Admin access to the TA Inst Depo'
NET LOCALGROUP TA_DEPO_Install /ADD /COMMENT:'Provides Read access to the TA Inst Depo for users that need to install software'

NET LOCALGROUP TA_DEPO_Admin Administrators /ADD
NET LOCALGROUP TA_DEPO_Admin %USERNAME% /ADD
NET LOCALGROUP TA_DEPO_Install %USERNAME% /ADD

NET SHARE %SHARENAME%='%SHARE_DIR%' /GRANT:TA_DEPO_Admin,FULL /GRANT:TA_DEPO_Install,READ /REMARK:'Technical Application Installation Share'
"
        Else
            ProcContent = ProcContent & "
NET SHARE %SHARENAME%='%SHARE_DIR%' /GRANT:Administrators,FULL /REMARK:'Technical Application Installation Share'
"
        End If

        ProcContent = ProcContent & "
:MAPDRIVE
NET USE %DEPODRV% \\%COMPUTERNAME%\%SHARENAME% /PERSISTENT:YES

echo Finished
timeout /t 4
"
        ProcContent = ProcContent.Replace("'", """")

        If Not My.Computer.FileSystem.DirectoryExists(BinLib) Then
            My.Computer.FileSystem.CreateDirectory(BinLib)
        End If
        If WriteTxtToFile(LocDepoCreateProcFileName, ProcContent, False, 0, "", "", True, False) Then
            xtrace_i("Execute: ")
            StartElevated(LocDepoCreateProcFileName)
        End If

        '---- Mount for the current user (not elevated) --------------------------

        Dim MyProc As String = BinLib & "\Check_CU_Share.bat"
        ProcContent = "@If not '%DEBUG%'=='TRUE' echo Off
TITLE Check current user drive mount

set SHARENAME=Depo
set DEPODRV=" & DriveLetter & "

:MAPDRIVE
IF NOT EXIST %DEPODRV% NET USE %DEPODRV% \\%COMPUTERNAME%\%SHARENAME% /PERSISTENT:YES

echo Finished
timeout /t 4

        "
        If WriteTxtToFile(MyProc, ProcContent, False, 0, "", "", True, False) Then
            xtrace_i("Execute: ")
            StartNormal(MyProc)
        End If

        '---- Undo ---------------------------------------------------------------
        Form1.SetStatus("Create undo procedure")
        ProcContent = "@If not '%DEBUG%'=='TRUE' echo Off
TITLE Undo Local Depo Share and settings

set SHARE_DIR=" & Form1.TextBoxNewDepo.Text & "
set SHARENAME=Depo
set DEPODRV=" & DriveLetter & "

NET USE %DEPODRV% /D
NET SHARE %SHARENAME% /D

NET LOCALGROUP TA_DEPO_Admin /DELETE
NET LOCALGROUP TA_DEPO_Install /DELETE

if not exist '%SHARE_DIR%' goto END

set /p RSP=Also delete %SHARE_DIR% [y/N] ? ^>
if /i '%RSP%'=='Y' rd /s /q '%SHARE_DIR%'

:END
echo Finished
timeout /t 4
        "
        ProcContent = ProcContent.Replace("'", """")

        WriteTxtToFile(LocDepoDeleteProcFileName, ProcContent, False, 0, "", "", True, False)

        My.Computer.Registry.SetValue(RegKey, "LocalDepoLocation", Form1.TextBoxNewDepo.Text)
        TAISLocDepo = DriveLetter

        LocalDepoTabReset()
        MsgBox("You new Local Depo has been created.
You can access it via " & ShareDir & " directly,
but You may not yet have access to the new shared drive " & DriveLetter & ",
untill you have logged off and on again!", vbExclamation, "You may not yet have access to " & DriveLetter & "!")

        xtrace_sube("Create_Local_Depo_Share")
    End Sub

    Sub Delete_Local_Depo_Share()
        xtrace_subs("Delete_Local_Depo_Share")

        xtrace_i("Execute: ")
        StartElevated(LocDepoDeleteProcFileName)

        LocalDepoTabReset()

        xtrace_sube("Delete_Local_Depo_Share")
    End Sub

    Sub LocalDepoTabReset()
        Form1.SetStatus("Finished")
        Form1.GroupBoxCreateDepo.Visible = False

        Form1.TabControl1.SelectTab(0)
        Form1.TabPageCreateShare.Text = "-"

    End Sub
End Module
