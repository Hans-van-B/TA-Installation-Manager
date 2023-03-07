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

        xtrace_sube("Form1_Load")
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

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
