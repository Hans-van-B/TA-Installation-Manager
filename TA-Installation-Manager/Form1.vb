Public Class Form1

    '---- Initialize application ----------------------------------------------
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xtrace_init()
        xtrace_subs("Form1_Load")
        xtrace_header()
        WriteInfo("Log file = " & LogFile)
        xtrace("Initializing")
        ReadDefaults()
        Read_Command_Line_Arg()
        Me.Text = AppName.Replace("-", " ") & " V" & AppVer

        SplitContainerBase.SplitterDistance = 200
        TimerInit.Start()

        xtrace_sube("Form1_Load")
    End Sub

    Private Sub TimerInit_Tick(sender As Object, e As EventArgs) Handles TimerInit.Tick
        xtrace_subs("Form1_Load2 (TimerInit)")
        TimerInit.Stop()

        Set_TAISDevDepo()

        If Glob.ScriptTypeSelect = "BAT" Then
            TabPageWinBat.BackColor = ScryptTypeSelectColor
            TabPagePS.BackColor = SystemColors.Control
        End If

        ' Shared defaults can be changed ad execution time and are therefore set after reading the default
        ' CheckBoxCopySource.Checked: See SharedDefaults
        If Glob.BatSeparateInit = "True" Then CheckBoxBatSeparateInit.Checked = True
        If Glob.BatSeparateApp = "True" Then CheckBoxBatSeparateApp.Checked = True
        If Glob.BatSeparatePost = "True" Then CheckBoxBatSeparatePost.Checked = True
        If Glob.StopUpdates = "True" Then CheckBoxStopUpdates.Checked = True
        If Glob.CopyLogToServer = "True" Then CheckBoxLogToServer.Checked = True
        If Glob.ReDownload = True Then CheckBoxReDownload.Checked = True

        xtrace_sube("Form1_Load2")
    End Sub

    '---- Rezize
    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        SplitContainerBase.SplitterDistance = 200
    End Sub

    Public Sub WriteInfo(Msg)
        TextBoxInfo.AppendText(Msg & vbNewLine)
        xtrace(Msg)
    End Sub

    '==== Main Menu ===========================================================

    '---- File, Save
    Private Sub ToolStripSave_Click(sender As Object, e As EventArgs) Handles ToolStripSave.Click
        xtrace_subs("File, Save")
        WriteIniFile()
        xtrace_sube("File, Save")
    End Sub

    '---- File, Exit
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        xtrace_subs("Menu, File, Exit")
        exit_program()
        xtrace_sube("Menu, File, Exit")
    End Sub

    '---- Show Settings -------------------------------------------------------
    Private Sub ShowSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowSettingsToolStripMenuItem.Click
        xtrace_subs("Menu, Settings, Show settings")
        If ShowSettingsToolStripMenuItem.Checked Then
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
    '---- Create the installation
    Private Sub ButtonStartCreate_Click(sender As Object, e As EventArgs) Handles ButtonStartCreate.Click
        xtrace_subs("ButtonStartCreate_Click")

        ButtonStartCreate.Enabled = False

        If ComboBoxInstName.Text = "" Then
            ShowHint("Please enter the name of the new installation")
            ComboBoxInstName.BackColor = ButtonHighLite
        End If

        If ScriptTypeSelect = "BAT" Then
            ToolStripStatusLabel1.Text = "Create TA-Installation type .bat"
            Create_Depo()
            Create_Installation_Base()
            InstallationWizzard()
            Add_Installation_Components_Bat()
            Finalize_Installation()

            AddWebContent()
            wait(1)
            ToolStripStatusLabel1.Text = "Done."

        ElseIf ScriptTypeSelect = "PS" Then
            ToolStripStatusLabel1.Text = "Create TA-Installation type .ps2"
            Create_Depo()
            Create_Installation_Base()
            InstallationWizzard()
            Add_Installation_Components_PS()
            Finalize_Installation()

            AddWebContent()
            wait(1)
            ToolStripStatusLabel1.Text = "Done."

        Else
            ToolStripStatusLabel1.Text = "First select the installation type and it's components"
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
        ComboBoxInstName.BackColor = SystemColors.Control
        CheckResultPath()
    End Sub

    '---- Update Inst version
    Private Sub ComboBoxInstVer_TextUpdate(sender As Object, e As EventArgs) Handles ComboBoxInstVer.TextUpdate
        CheckResultPath()
    End Sub

    Dim ResultPathExist As Boolean = False
    Dim MyDepoPath As String
    Sub CheckResultPath()
        MyDepoPath = TAISDevDepo & "\" & InstName & "\" & ComboBoxInstVer.Text
        xtrace_i("Check " & MyDepoPath, 2)

        If My.Computer.FileSystem.DirectoryExists(MyDepoPath) Then
            ResultPathExist = True
        Else
            ResultPathExist = False
        End If
        ButtonDeleteResult.Enabled = ResultPathExist
    End Sub

    '---- Show Hint
    Sub ShowHint(Msg As String)
        xtrace_i("Show hint: " & Msg)
        MsgBox(Msg, MessageBoxIcon.Information, "Hint:")
    End Sub

End Class
