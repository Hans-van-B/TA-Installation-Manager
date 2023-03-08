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

    Public Shared ScriptTypeSelect As String = ""

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
            Add_Installation_Components_Bat()
            Finalize_Installation()
        ElseIf ScriptTypeSelect = "PS" Then
            ToolStripStatusLabel1.Text = "Create TA-Installation type .ps2"
            Create_Depo()
            Create_Installation_Base()
            Add_Installation_Components_PS()
            Finalize_Installation()
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

        xtrace_sube("ButtonStartCreate_Click")
    End Sub

    '---- Reset backColor after entering data
    Private Sub ComboBoxInstName_TextChanged(sender As Object, e As EventArgs) Handles ComboBoxInstName.TextChanged
        ComboBoxInstName.BackColor = SystemColors.Control
    End Sub

    '---- Show Hint
    Sub ShowHint(Msg As String)
        xtrace_i("Show hint: " & Msg)
        MsgBox(Msg, MessageBoxIcon.Information, "Hint:")
    End Sub

End Class
