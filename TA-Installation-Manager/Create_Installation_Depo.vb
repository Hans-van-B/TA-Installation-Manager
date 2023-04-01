Imports System.Security.Policy

Module Create_Installation_Depo
    Public TAISDevDepo As String
    Public DepoRoot As String

    Public TA_InstLib As String
    Public TA_InstLib_Version = "04"
    Public TA_InstLibV As String
    Public TA_InstLib_Inst As String
    Public TA_InstLib_InstExe As String

    Public TA_Template As String
    Public TA_Template_Version As String = "06"
    Public TA_TemplateV As String
    Public TA_Template_Inst As String
    Public TA_Template_InstExe As String

    Sub Create_Depo()
        xtrace_subs("Create_Depo")

        Form1.SetStatus("Check / Create Depo")
        '---- Depo Root
        TAISDevDepo = Form1.ComboBoxDevDepo.Text
        DepoRoot = TAISDevDepo
        xtrace_i("TAISDevDepo      = " & TAISDevDepo)
        ' ToDo If Not exist
        If Not My.Computer.FileSystem.DirectoryExists(TAISDevDepo) Then

        End If

        '---- TA_InstLib
        TA_InstLib = TAISDevDepo & "\TA_InstLib"
        xtrace_i("TA_InstLib       = " & TA_InstLib)
        ' ToDo If Not exist
        If Not My.Computer.FileSystem.DirectoryExists(TA_InstLib) Then
            MD(TA_InstLib)
        End If

        '---- TA_InstLibV
        TA_InstLibV = TA_InstLib & "\" & TA_InstLib_Version
        xtrace_i("TA_InstLibV      = " & TA_InstLibV)
        If Not My.Computer.FileSystem.DirectoryExists(TA_InstLibV) Then
            CreateDirectory(TA_InstLibV, 0, "Failed to create the version directory in TA_InstLib", "Please check your directory access rights", True, True)
        End If

        '---- TA_InstLib_Inst
        TA_InstLib_Inst = TA_InstLibV & "\Inst"
        TA_InstLib_InstExe = TA_InstLib_Inst & "\exe"
        xtrace_i("TA_InstLib_Inst  = " & TA_InstLib_Inst)
        If Not My.Computer.FileSystem.DirectoryExists(TA_InstLib_Inst) Then
            MD(TA_InstLib_Inst)
        End If
        Check_InstSubDirs(TA_InstLib_Inst, "           ")

        '---- TA_Instlib_Files
        'GetUrl2("", TA_InstLib_Inst & "")

        '---- TA_Template
        TA_Template = TAISDevDepo & "\TA_Template"
        xtrace_i("TA_Template      = " & TA_Template)
        If Not My.Computer.FileSystem.DirectoryExists(TA_Template) Then
            MD(TA_Template)
        End If


        '---- TA_TemplateV
        TA_TemplateV = TA_Template & "\" & TA_Template_Version
        xtrace_i("TA_TemplateV     = " & TA_TemplateV)
        If Not My.Computer.FileSystem.DirectoryExists(TA_TemplateV) Then
            MD(TA_TemplateV)
        End If

        '---- TA_Template_Inst
        TA_Template_Inst = TA_TemplateV & "\Inst"
        TA_Template_InstExe = TA_Template_Inst & "\exe"
        xtrace_i("TA_Template_Inst = " & TA_Template_Inst)
        If Not My.Computer.FileSystem.DirectoryExists(TA_Template_Inst) Then
            MD(TA_Template_Inst)
        End If
        Check_InstSubDirs(TA_Template_Inst, "           ")

        '---- TA_InstLib files
        xtrace_i("Add files for InstLib")
        'GetFile("XElevate.exe", TA_InstLib_InstExe)

        '---- TA_Template Files
        xtrace_i("Add files for Template")
        GetFile("TA-Setup.exe", TA_Template_Inst)
        GetFile("TA-Select.exe", TA_Template_Inst)
        GetFile("TA-Deinstall.exe", TA_Template_Inst)

        xtrace_sube("Create_Depo")
    End Sub


    Sub Set_TAISDevDepo()
        xtrace_subs("Set_TAISDevDepo")
        If Environment.GetEnvironmentVariable("TAIS_DEV_DEPO") <> "" Then
            TAISDevDepo = Environment.GetEnvironmentVariable("TAIS_DEV_DEPO")
        ElseIf Environment.GetEnvironmentVariable("TA_DEV_DEPO") <> "" Then
            TAISDevDepo = Environment.GetEnvironmentVariable("TA_DEV_DEPO")
        Else
            TAISDevDepo = IniDevDepo
        End If
        Form1.ComboBoxDevDepo.Text = TAISDevDepo
        Form1.ComboBoxDevDepo.Items.Add(TAISDevDepo)
        Form1.ComboBoxDevDepo.Items.Add(TAISDevDepo & "Test")
        If (My.Computer.FileSystem.DirectoryExists(Deflt_Depo_Path)) _
        And TAISDevDepo <> Deflt_Depo_Path Then
            Form1.ComboBoxDevDepo.Items.Add(Deflt_Depo_Path)
        End If
        xtrace_i("TAISDevDepo = " & TAISDevDepo)
        xtrace_sube("Set_TAISDevDepo")
    End Sub

    Sub Check_InstSubDirs(InstRoot As String, T As String)
        Dim SD, CheckDir As String

        For Each SD In {"bat", "data", "exe", "exe\W64"}
            CheckDir = InstRoot & "\" & SD
            xtrace_i("Check " & T & ": " & CheckDir)
            If Not My.Computer.FileSystem.DirectoryExists(CheckDir) Then
                CreateDirectory(CheckDir, 0, "", "Please check your directory access rights", True, True)
            End If
        Next

        ' Script Type .bat
        If Glob.ScriptTypeSelect = "BAT" Then
            For Each SD In {"pl"}
                CheckDir = InstRoot & "\" & SD
                xtrace_i("Check " & T & ": " & CheckDir)
                If Not My.Computer.FileSystem.DirectoryExists(CheckDir) Then
                    CreateDirectory(CheckDir, 0, "", "Please check your directory access rights", True, True)
                End If
            Next
        End If
    End Sub

End Module
