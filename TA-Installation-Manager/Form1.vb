Public Class Form1

    '---- Initialize application ----------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Log.xtrace_init()
        Log.xtrace_subs("Form1_Load")
        Log.xtrace_header()
        WriteInfo("Log file = " & LogFile)
        Log.xtrace("Initializing")
        Defaults.ReadDefaults()
        Read_Command_Line_Arg()

        LicC.GetLic()
        LicC.CheckLicDate()

        Me.Text = AppName.Replace("-", " ") & " V" & AppVer
        Me.Width = 1100

        SplitContainerBase.SplitterDistance = 200
        TimerInit.Start()

        Log.xtrace_sube("Form1_Load")
    End Sub

    Private Sub TimerInit_Tick(sender As Object, e As EventArgs) Handles TimerInit.Tick
        Log.xtrace_line()
        Log.xtrace_subs("Form1_Load2 (TimerInit)")
        TimerInit.Stop()

        WriteInfo("Bin Library = " & BinLib)

        Set_TAISDevDepo()
        ButtonCheckWizard.Left = 10
        TabControl1.SelectTab(0)

        SetGUIScryptType(Glob.ScriptTypeSelect)

        ' Shared defaults can be changed ad execution time and are therefore set after reading the default
        ' But also by a Wizard, therefore move them to the shared defaults
        ' CheckBoxCopySource.Checked: See SharedDefaults

        ' No shared defaults (Only manual selection)
        If Glob.StopUpdates = "True" Then CheckBoxStopUpdates.Checked = True
        If Glob.CopyLogToServer = "True" Then CheckBoxLogToServer.Checked = True
        If Glob.ReDownload = True Then CheckBoxReDownload.Checked = True

        If Len(AutoRun) > 2 Then
            Log.xtrace_line()
            StartAutoRun()
        End If
        SetReconnectEnable()

        Log.xtrace_sube("Form1_Load2")

        ' Inserted also in exit_program, leave it that way.
        ' It looks like no new procedures are started after Application.Exit()
        ' If CVL Then CreateValidateLogs(True)

        Log.xtrace_line()
    End Sub

    '---- Auto Run ----------------------------------------------------------------------
    ' Mainly for automatic testing and validation, to get predictable and reproducable log files
    ' This is an Undocumented development feature, so no hiding or disabeling of the user-interface is done.
    Sub StartAutoRun()
        xtrace_subs("StartAutoRun")
        GroupBoxAutoRun.Visible = True

        Dim ARData() As String = AutoRun.Split(";")
        Dim ARDCount As Integer = ARData.Length
        Dim ArStep As String
        Dim P1 As Integer
        Dim Cmd As String
        xtrace_i("ARDCount = " & ARDCount.ToString)

        For Nr As Integer = 0 To ARDCount - 1
            ArStep = ARData(Nr)
            TextBoxAutoRun.Text = ArStep
            Do_Events()

            xtrace_i("Step " & Nr.ToString & ": " & ArStep)

            If Nr = 0 Then
                ComboBoxInstName.Text = ArStep
                wait(1)
            End If

            If ArStep = "Start" Then
                ButtonStartCreate_Click(Nothing, Nothing)
            End If

            If ArStep = "Save" Then
                ToolStripSave_Click(Nothing, Nothing)
            End If

            If ArStep = "Exit" Then
                wait(2)
                Util.exit_program()
            End If

            P1 = InStr(ArStep, " ")
            If P1 > 1 Then
                Cmd = Microsoft.VisualBasic.Left(ArStep, P1 - 1)
                If Cmd.ToLower = "set" Then
                    Dim SetStr As String = Mid(ArStep, 4).Trim
                    xtrace_i("SetStr = " & SetStr)
                    P1 = InStr(SetStr, "=")
                    If P1 > 1 Then
                        Dim Name = Microsoft.VisualBasic.Left(SetStr, P1 - 1)
                        Dim Val = Mid(SetStr, P1 + 1)
                        xtrace_i("Set: " & Name & "=" & Val)

                        If Name.ToLower = "deporoot" Then ComboBoxDevDepo.Text = Val
                        If Name.ToLower = "instname" Then ComboBoxInstName.Text = Val

                        If Name.ToLower = "sepinit" Then CheckBoxBatSeparateInit.Checked = StringToBool(Val)
                        If Name.ToLower = "sepapp" Then CheckBoxBatSeparateApp.Checked = StringToBool(Val)
                        If Name.ToLower = "seppost" Then CheckBoxBatSeparatePost.Checked = StringToBool(Val)
                        If Name.ToLower = "sepdept" Then CheckBoxDeptConfigs.Checked = StringToBool(Val)

                    End If
                End If
            End If

            'End If
        Next
        GroupBoxAutoRun.Visible = False

        xtrace_sube("StartAutoRun")
    End Sub

    Sub SetGUIScryptType(Type As String)
        If Type = "BAT" Then
            TabControl1.SelectedTab = TabPageWinBat
            TabPageWinBat.BackColor = ScryptTypeSelectColor
            TabPagePS.BackColor = SystemColors.Control
        ElseIf Type = "PS" Then
            TabControl1.SelectedTab = TabPagePS
            TabPagePS.BackColor = ScryptTypeSelectColor
            TabPageWinBat.BackColor = SystemColors.Control
        End If
    End Sub

    '---- Resize
    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        SplitContainerBase.SplitterDistance = 200
    End Sub

    Public Sub WriteInfo(Msg)
        TextBoxInfo.AppendText(Msg & vbNewLine)
        Log.xtrace(Msg)
    End Sub
    Public Sub WriteInfoWarning(Msg)
        TextBoxInfo.AppendText("Warning:" & Msg & vbNewLine)
        Log.xtrace_warn(Msg)
    End Sub

    Public Shared Sub SetStatus(Msg As String)
        Form1.ToolStripStatusLabel1.Text = Msg
        Do_Events()
    End Sub

    '==== Main Menu ===========================================================

    '---- File, Save
    Private Sub ToolStripSave_Click(sender As Object, e As EventArgs) Handles ToolStripSave.Click
        Log.xtrace_subs("File, Save")
        Defaults.WriteIniFile()
        Log.xtrace_sube("File, Save")
    End Sub

    '---- Update / Create Wizard ----------------------------------------------
    Private Sub ToolStripMenuUpdateWizard_Click(sender As Object, e As EventArgs) Handles ToolStripMenuUpdateWizard.Click
        WriteWizard()
    End Sub

    '---- File, Exit
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Log.xtrace_subs("Menu, File, Exit")
        Util.exit_program()
        Log.xtrace_sube("Menu, File, Exit")
    End Sub

    '---- Show Settings -------------------------------------------------------
    Private Sub ShowSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowSettingsToolStripMenuItem.Click
        xtrace_subs("Menu, Settings, Show settings")
        If ShowSettingsToolStripMenuItem.Checked Then
            TextBoxInfo.BringToFront()
            TextBoxInfo.Visible = True
            TextBoxInfo.Dock = DockStyle.Fill
        Else
            TextBoxInfo.Visible = False
        End If
        xtrace_sube("Show settings")
    End Sub

    '---- Show Log ----
    Private Sub ShowLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowLogToolStripMenuItem.Click
        xtrace_subs("Menu, Settings, Show log file")
        Process.Start(LogFile)
        xtrace_sube("Show log file")
    End Sub

    '---- Advanced, Reset License
    Private Sub ResetLicenseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetLicenseToolStripMenuItem.Click
        xtrace_subs("Menu, Advanced, Reset License")
        LicC.LicID = LicC.DefaultLicID
        xtrace_sube("Reset License")
    End Sub

    '---- Show help ----
    Private Sub HelpToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem1.Click
        xtrace_subs("Menu, Help, Help")
        ShowHelp()
        xtrace_sube("Help")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        xtrace_subs("Menu, Help, About")
        ShowHelpAbout()
        xtrace_sube("Help, About")
    End Sub

    Private Sub SupportThisAppToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SupportThisAppToolStripMenuItem.Click
        xtrace_subs("Menu, Help, Support")
        ShowSupport()
        xtrace_sube("Help, Support")
    End Sub

    '==== Select Script-type ==========================================================
    Dim ScryptTypeSelectColor As Color = Color.AliceBlue
    Dim ButtonHighLite As Color = Color.LightYellow

    Private Sub SelectScriptTypeBat()
        xtrace_subs("SelectScriptTypeBat")
        ScriptTypeSelect = "BAT"
        TabPageWinBat.BackColor = ScryptTypeSelectColor
        TabPagePS.BackColor = SystemColors.Control
        xtrace_sube("SelectScriptTypeBat")
    End Sub

    Private Sub SelectScriptTypePS()
        xtrace_subs("SelectScriptTypePS")
        TabPagePS.BackColor = ScryptTypeSelectColor
        TabPageWinBat.BackColor = SystemColors.Control
        ScriptTypeSelect = "PS"
        xtrace_sube("SelectScriptTypePS")
    End Sub

    Private Sub SelectScriptType()
        xtrace_subs("SelectScriptType")
        If TabControl1.SelectedTab Is TabPageWinBat Then
            SelectScriptTypeBat()
        ElseIf TabControl1.SelectedTab Is TabPagePS Then
            SelectScriptTypePS()
        End If
        xtrace_sube("SelectScriptType")
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        xtrace_subs("TabControl1_Selected")
        SelectScriptType()
        xtrace_sube("TabControl1_Selected")
    End Sub

    Private Sub TabControl1_MouseClick(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseClick
        xtrace_subs("TabControl1_MouseClick")
        SelectScriptType()
        xtrace_sube("TabControl1_MouseClick")
    End Sub

    '==== Buttons =============================================================================

    Private Sub ButtonCheckWizard_Click(sender As Object, e As EventArgs) Handles ButtonCheckWizard.Click
        xtrace_subs("ButtonCheckWizard_Click")
        If ComboBoxInstName.Text = "" Then
            ShowHint("Please enter the name of the new installation")
            ComboBoxInstName.BackColor = ButtonHighLite
        Else
            WizardInitialized = False  ' Explicit call, always initialize
            InstallationWizard()
        End If
        xtrace_sube("ButtonCheckWizard_Click")
    End Sub

    '---- Create the installation
    Private Sub ButtonStartCreate_Click(sender As Object, e As EventArgs) Handles ButtonStartCreate.Click
        xtrace_subs("ButtonStartCreate_Click")

        ButtonStartCreate.Enabled = False
        ListGUISettings()

        If ComboBoxInstName.Text = "" Then
            ShowHint("Please enter the name of the new installation")
            ComboBoxInstName.BackColor = ButtonHighLite
        End If

        If ScriptTypeSelect = "BAT" Then
            SetStatus("Create TA-Installation type .bat")
            Create_Depo()
            InstallationWizard()
            Do_Events()
            Create_Installation_Base()
            Add_Installation_Components_Bat()
            Finalize_Installation()

            AddWebContent()
            wait(1)
            SetStatus("Done.")

        ElseIf ScriptTypeSelect = "PS" Then
            SetStatus("Create TA-Installation type .ps2")
            Create_Depo()
            InstallationWizard()
            Do_Events()
            Create_Installation_Base()
            Add_Installation_Components_PS()
            Finalize_Installation()

            AddWebContent()
            wait(1)
            SetStatus("Done.")

        Else
            SetStatus("First select the installation type and it's components")
            MsgBox("Please select the installation type" & vbCrLf & " and it's components", MessageBoxIcon.Information, "Hint:")
            'TabPageWinBat.BackColor = ButtonHighLite
            'TabPagePS.BackColor = ButtonHighLite
            'TabControl1.BackColor = ButtonHighLite
            'TabControl1.SelectedTab = TabPageWinBat
            SelectScriptType()
        End If

        ButtonStartCreate.Enabled = True
        CheckResultPath()

        xtrace_sube("ButtonStartCreate_Click")
    End Sub

    '---- List Settings ---------------------------------------------------
    Sub ListGUISettings()
        xtrace("ListGUISettings", 2)
        xtrace_i("Dev Depo      = " & ComboBoxDevDepo.Text)
        xtrace_i("Inst name     = " & ComboBoxInstName.Text)
        xtrace_i("Inst Version  = " & ComboBoxInstVer.Text)
        xtrace_i("TA-Setup      = " & CheckBoxTASetup.Checked.ToString)
        xtrace_i("TA-Select     = " & CheckBoxTASelect.Checked.ToString)
        xtrace_i("TA-Deinstall  = " & CheckBoxTADeinstall.Checked.ToString)
        xtrace_i("Copy to local = " & CheckBoxCopySource.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        'xtrace_i(" = " & CheckBoxTASetup.Checked.ToString)
        xtrace_i("Re-Download   = " & CheckBoxReDownload.Checked.ToString)
        xtrace_i("Saparate Init = " & CheckBoxBatSeparateInit.Checked.ToString)
        xtrace_i("Separate App  = " & CheckBoxBatSeparateApp.Checked.ToString)
        xtrace_i("Separate Post = " & CheckBoxBatSeparatePost.Checked.ToString)
    End Sub
    '---- Show the resuly
    Private Sub ButtonShowResult_Click(sender As Object, e As EventArgs) Handles ButtonShowResult.Click
        Process.Start(InstRoot)
    End Sub
    '---- Delete the result
    Private Sub ButtonDeleteResult_Click(sender As Object, e As EventArgs) Handles ButtonDeleteResult.Click
        xtrace_subs("Button Delete the result")
        Dim Rsp As MsgBoxResult
        Rsp = MsgBox("Are you sure you want to delete the" & vbCrLf & InstName & " installation?", MsgBoxStyle.OkCancel, "Delete result?")

        ' Delete version dir
        If Rsp = MsgBoxResult.Ok Then
            DeleteDirectory(MyDepoPath, 0, "Delete the installation", "", True, False)
        End If

        'Try to delete the InstName directory
        xtrace_i("Delete the " & InstName & " Dir.")
        Try
            System.IO.Directory.Delete(TAISDevDepo & "\" & InstName, False)
        Catch ex As Exception
            xtrace_i(ex.Message)
        End Try
        CheckResultPath()

        xtrace_sube("Button Delete the result")
    End Sub

    '==== TextChanged =======================================================================

    '---- Update the DevDepo Var
    Private Sub ComboBoxDevDepo_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxDevDepo.TextChanged
        Dim NewV As String = ComboBoxDevDepo.Text
        If My.Computer.FileSystem.DirectoryExists(NewV) Then
            TAISDevDepo = NewV
            ComboBoxDevDepo.ForeColor = ForeColor
        Else
            ComboBoxDevDepo.ForeColor = Color.DarkRed
        End If
        CheckResultPath()
    End Sub

    '---- Update the InstName (Reset backColor after entering data)
    Private Sub ComboBoxInstName_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxInstName.TextChanged
        InstName = ComboBoxInstName.Text
        xtrace_i("Set InstName = " & InstName)
        WizardInitialized = False
        ComboBoxInstName.BackColor = SystemColors.Control
        CheckResultPath()
    End Sub
    Private Sub ComboBoxInstName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxInstName.SelectedIndexChanged
        xtrace_subs("ComboBoxInstName_SelectedIndexChanged")
        xtrace_i("InstName = " & ComboBoxInstName.Text)
        xtrace_sube("ComboBoxInstName_SelectedIndexChanged")
    End Sub

    '---- Update Inst version
    Private Sub ComboBoxInstVer_TextUpdate(sender As Object, e As EventArgs) Handles ComboBoxInstVer.TextUpdate
        CheckResultPath()
    End Sub

    Public ResultPathExist As Boolean = False
    Dim MyDepoPath As String
    Sub CheckResultPath()
        Dim MyDepo As String
        Dim MyInstName As String
        Dim MyInstVer As String
        ResultPathExist = True

        If TAISDevDepo = "" Then
            MyDepo = "<Undefined>"
            ResultPathExist = False
        Else
            MyDepo = TAISDevDepo
        End If

        If InstName = "" Then
            MyInstName = "<Undefined>"
            ResultPathExist = False
        Else
            MyInstName = InstName
        End If

        If ComboBoxInstVer.Text = "" Then
            MyInstVer = "<Undefined>"
            ResultPathExist = False
        Else
            MyInstVer = ComboBoxInstVer.Text
        End If

        MyDepoPath = MyDepo & "\" & MyInstName & "\" & MyInstVer
        xtrace_i("Check " & MyDepoPath, 2)

        If ResultPathExist Then
            If My.Computer.FileSystem.DirectoryExists(MyDepoPath) Then
                ResultPathExist = True
            Else
                ResultPathExist = False
            End If
        End If
        InstBckInit(MyDepoPath, ResultPathExist)

        xtrace_i("Result = " & ResultPathExist.ToString)
        ButtonDeleteResult.Enabled = ResultPathExist
    End Sub

    '---- Show Hint
    Sub ShowHint(Msg As String)
        xtrace_i("Show hint: " & Msg)
        MsgBox(Msg, MessageBoxIcon.Information, "Hint:")
    End Sub

    Private Sub RadioButtonRemRem_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonRemRem.CheckedChanged, RadioButtonRemHash.CheckedChanged, RadioButtonRemEcho.CheckedChanged, RadioButtonRemDots.CheckedChanged
        xtrace_i("RadioButtonRemRem_CheckedChanged")
        If RadioButtonRemRem.Checked Then RemType = "REM"
        If RadioButtonRemDots.Checked Then RemType = "::"
        If RadioButtonRemEcho.Checked Then RemType = "echo"
        If RadioButtonRemHash.Checked Then RemType = "#"
        xtrace_i("Set RemType = " & RemType)
    End Sub

    Private Sub CheckBoxDeptConfigs_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDeptConfigs.CheckedChanged
        xtrace_subs("CheckBoxDeptConfigs_CheckedChanged")
        If CheckBoxDeptConfigs.Checked Then
            GroupBoxDeptList.Visible = True
            CheckBoxTASelect.Checked = True
            xtrace_i("DeptList = True")
        Else
            GroupBoxDeptList.Visible = False
            CheckBoxTASelect.Checked = False
            xtrace_i("DeptList = False")
        End If
        xtrace_sube("CheckBoxDeptConfigs_CheckedChanged")
    End Sub

    '---- Create Local Depo ---------------------------------------------------------------------
    Dim EnableDeleteButton As Boolean
    Private Sub CreateDepoShareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateDepoShareToolStripMenuItem.Click
        TabControl1.SelectTab(2)
        TabPageCreateShare.Text = "Create Depo"
        TextBoxNewDepo.Text = Deflt_Depo_Path
        GroupBoxCreateDepo.Visible = True

        EnableDeleteButton = False
        CheckLocDepoDir()
        CheckLocDepoShare()
        CheckLocDepoDeleteProc()
    End Sub
    Private Sub TextBoxNewDepo_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNewDepo.TextChanged
        CheckLocDepoDir()
    End Sub

    Private Sub CheckLocDepoDir()
        xtrace_subs("CheckLocDepoDir")
        If My.Computer.FileSystem.DirectoryExists(TextBoxNewDepo.Text) Then
            LabelLocDepoDirExists.Text = "Loc Depo Dir: Exists"
            EnableDeleteButton = True
        Else
            LabelLocDepoDirExists.Text = "Loc Depo Dir: Does not exist"
        End If
        xtrace_sube("CheckLocDepoDir")
    End Sub

    Private Sub CheckLocDepoShare()
        xtrace_subs("CheckLocDepoShare")
        Dim ShareLoc = "\\" & Environment.MachineName & "\Depo"
        xtrace_i("Check: " & ShareLoc)
        If My.Computer.FileSystem.DirectoryExists(ShareLoc) Then
            LabelLocDepoShareExists.Text = "Loc Depo Share: exists"
            LabelLocDepoShareExists.ForeColor = Color.Red
            ButtonCreateDepo.Enabled = False
            EnableDeleteButton = True
            xtrace_i("Depo " & ShareLoc & " exists")
        Else
            LabelLocDepoShareExists.Text = "Loc Depo Share: Does not exist"
            LabelLocDepoShareExists.ForeColor = SystemColors.ControlText
            ButtonCreateDepo.Enabled = True
            xtrace_i("Depo " & ShareLoc & " does not exist")
        End If
        xtrace_sube("CheckLocDepoShare")
    End Sub

    Private Sub CheckLocDepoDeleteProc()
        xtrace_subs("CheckLocDepoDeleteProc")
        If EnableDeleteButton Then
            If My.Computer.FileSystem.FileExists(LocDepoDeleteProcFileName) Then
                xtrace_i("Found " & LocDepoDeleteProcFileName)
                ButtonDeleteDepo.Enabled = True
            Else
                xtrace_i(LocDepoDeleteProcFileName & " does not exist")
                ButtonDeleteDepo.Enabled = False
            End If
        Else
            xtrace_i("Local Depo does not exist")
            ButtonDeleteDepo.Enabled = False
        End If
        xtrace_sube("CheckLocDepoDeleteProc")
    End Sub

    Private Sub ButtonCreateDepo_Click(sender As Object, e As EventArgs) Handles ButtonCreateDepo.Click
        Create_Local_Depo_Share()
    End Sub

    Private Sub ButtonDeleteDepo_Click(sender As Object, e As EventArgs) Handles ButtonDeleteDepo.Click
        Delete_Local_Depo_Share()
    End Sub

    Private Sub ReconnectToLocalDepoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReconnectToLocalDepoToolStripMenuItem.Click
        LocalDepoReconnect()
    End Sub

    Private Sub SetReconnectEnable()
        xtrace_subs("SetReconnectEnable")

        Dim Result As Boolean = True
        If Not My.Computer.FileSystem.FileExists(LocDepoReconnect_FileName) Then
            xtrace(" x Procedure not available")
            Result = False
        Else
            xtrace(" v The procedure exists")
        End If

        If TAISLocDepo = "" Then
            xtrace(" x Loc Depo Drive Unknown")
            Result = False
        ElseIf My.Computer.FileSystem.DirectoryExists(TAISLocDepo & "\.") Then
            xtrace(" x LocDepoDrive already exists")
            Result = False
        End If

        Dim LocalDepoUNC As String = "\\" & Environment.MachineName & "\Depo"
        If Not My.Computer.FileSystem.DirectoryExists(LocalDepoUNC) Then
            xtrace(" x The Local Depo UNC " & LocalDepoUNC & " does not exist or cannot be accessed")
            Result = False
        Else
            xtrace(" v The Local Depo UNC exists")
        End If

        ReconnectToLocalDepoToolStripMenuItem.Enabled = Result
        If Not Result Then ReconnectToLocalDepoToolStripMenuItem.ToolTipText = "If you want to know why this option is not available" & vbCrLf &
            "then search the log file for SetReconnectEnable"

        xtrace_sube("SetReconnectEnable")
    End Sub
End Class
