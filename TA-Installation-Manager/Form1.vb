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
        ButtonBat.Height = 40
        ButtonPS.Height = 40

        xtrace_sube("Form1_Load")
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

    '==== Button select Script-type ==========================================================
    Dim ScryptTypeSelectColor As Color = Color.AliceBlue
    Dim ScryptTypeSelect As String = ""
    Private Sub ButtonBat_Click(sender As Object, e As EventArgs) Handles ButtonBat.Click
        xtrace_subs("ButtonBat_Click")
        ButtonBat.BackColor = ScryptTypeSelectColor
        ButtonPS.BackColor = SystemColors.Control
        SplitContainer2V.Panel1.BackColor = ScryptTypeSelectColor
        SplitContainer2V.Panel2.BackColor = SystemColors.Control
        ScryptTypeSelect = "BAT"
        xtrace_sube("ButtonBat_Click")
    End Sub

    Private Sub ButtonPS_Click(sender As Object, e As EventArgs) Handles ButtonPS.Click
        xtrace_subs("ButtonPS_Click")
        ButtonPS.BackColor = ScryptTypeSelectColor
        ButtonBat.BackColor = SystemColors.Control
        SplitContainer2V.Panel2.BackColor = ScryptTypeSelectColor
        SplitContainer2V.Panel1.BackColor = SystemColors.Control
        ScryptTypeSelect = "PS"
        xtrace_sube("ButtonPS_Click")
    End Sub

    '---- Create the installation
    Private Sub ButtonStartCreate_Click(sender As Object, e As EventArgs) Handles ButtonStartCreate.Click
        xtrace_subs("ButtonStartCreate_Click")
        If ScryptTypeSelect = "BAT" Then
            ToolStripStatusLabel1.Text = "Create TA-Installation type .bat"
            Create_Installation_Base()
            Add_Installation_Components_Bat()
        ElseIf ScryptTypeSelect = "PS" Then
            ToolStripStatusLabel1.Text = "Create TA-Installation type .ps2"
            Create_Installation_Base()
            Add_Installation_Components_PS()
        Else
            ToolStripStatusLabel1.Text = "First select the installation type and it's components"
        End If

        xtrace_sube("ButtonStartCreate_Click")
    End Sub

End Class
