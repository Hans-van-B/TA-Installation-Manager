<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainerBase = New System.Windows.Forms.SplitContainer()
        Me.GroupBoxAutoRun = New System.Windows.Forms.GroupBox()
        Me.TextBoxAutoRun = New System.Windows.Forms.TextBox()
        Me.ButtonCheckWizzard = New System.Windows.Forms.Button()
        Me.ButtonDeleteResult = New System.Windows.Forms.Button()
        Me.ButtonShowResult = New System.Windows.Forms.Button()
        Me.ButtonStartCreate = New System.Windows.Forms.Button()
        Me.SplitContainer1H = New System.Windows.Forms.SplitContainer()
        Me.CheckBoxTADeinstall = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTASelect = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTASetup = New System.Windows.Forms.CheckBox()
        Me.ComboBoxInstVer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxInstName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBoxDevDepo = New System.Windows.Forms.ComboBox()
        Me.SplitContainer2V = New System.Windows.Forms.SplitContainer()
        Me.CheckBoxReDownload = New System.Windows.Forms.CheckBox()
        Me.CheckBoxCopySource = New System.Windows.Forms.CheckBox()
        Me.CheckBoxLogToServer = New System.Windows.Forms.CheckBox()
        Me.CheckBoxStopUpdates = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageWinBat = New System.Windows.Forms.TabPage()
        Me.GroupBoxRem = New System.Windows.Forms.GroupBox()
        Me.RadioButtonRemHash = New System.Windows.Forms.RadioButton()
        Me.RadioButtonRemEcho = New System.Windows.Forms.RadioButton()
        Me.RadioButtonRemDots = New System.Windows.Forms.RadioButton()
        Me.RadioButtonRemRem = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CheckBoxBatSeparatePost = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBatSeparateApp = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBatSeparateInit = New System.Windows.Forms.CheckBox()
        Me.TabPagePS = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBoxInfo = New System.Windows.Forms.TextBox()
        Me.TimerInit = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainerBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerBase.Panel1.SuspendLayout()
        Me.SplitContainerBase.Panel2.SuspendLayout()
        Me.SplitContainerBase.SuspendLayout()
        Me.GroupBoxAutoRun.SuspendLayout()
        CType(Me.SplitContainer1H, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1H.Panel1.SuspendLayout()
        Me.SplitContainer1H.Panel2.SuspendLayout()
        Me.SplitContainer1H.SuspendLayout()
        CType(Me.SplitContainer2V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2V.Panel1.SuspendLayout()
        Me.SplitContainer2V.Panel2.SuspendLayout()
        Me.SplitContainer2V.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageWinBat.SuspendLayout()
        Me.GroupBoxRem.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(873, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSave, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolStripSave
        '
        Me.ToolStripSave.Name = "ToolStripSave"
        Me.ToolStripSave.Size = New System.Drawing.Size(98, 22)
        Me.ToolStripSave.Text = "Save"
        Me.ToolStripSave.ToolTipText = "Save settings"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowSettingsToolStripMenuItem, Me.ShowLogToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ShowSettingsToolStripMenuItem
        '
        Me.ShowSettingsToolStripMenuItem.CheckOnClick = True
        Me.ShowSettingsToolStripMenuItem.Name = "ShowSettingsToolStripMenuItem"
        Me.ShowSettingsToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ShowSettingsToolStripMenuItem.Text = "Show settings"
        '
        'ShowLogToolStripMenuItem
        '
        Me.ShowLogToolStripMenuItem.Name = "ShowLogToolStripMenuItem"
        Me.ShowLogToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.ShowLogToolStripMenuItem.Text = "Show &Log"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(107, 22)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SplitContainerBase
        '
        Me.SplitContainerBase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.SplitContainerBase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerBase.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainerBase.Name = "SplitContainerBase"
        '
        'SplitContainerBase.Panel1
        '
        Me.SplitContainerBase.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainerBase.Panel1.Controls.Add(Me.GroupBoxAutoRun)
        Me.SplitContainerBase.Panel1.Controls.Add(Me.ButtonCheckWizzard)
        Me.SplitContainerBase.Panel1.Controls.Add(Me.ButtonDeleteResult)
        Me.SplitContainerBase.Panel1.Controls.Add(Me.ButtonShowResult)
        Me.SplitContainerBase.Panel1.Controls.Add(Me.ButtonStartCreate)
        '
        'SplitContainerBase.Panel2
        '
        Me.SplitContainerBase.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainerBase.Panel2.Controls.Add(Me.SplitContainer1H)
        Me.SplitContainerBase.Panel2.Controls.Add(Me.TextBoxInfo)
        Me.SplitContainerBase.Size = New System.Drawing.Size(873, 519)
        Me.SplitContainerBase.SplitterDistance = 195
        Me.SplitContainerBase.TabIndex = 3
        '
        'GroupBoxAutoRun
        '
        Me.GroupBoxAutoRun.Controls.Add(Me.TextBoxAutoRun)
        Me.GroupBoxAutoRun.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBoxAutoRun.Location = New System.Drawing.Point(0, 476)
        Me.GroupBoxAutoRun.Name = "GroupBoxAutoRun"
        Me.GroupBoxAutoRun.Size = New System.Drawing.Size(195, 43)
        Me.GroupBoxAutoRun.TabIndex = 4
        Me.GroupBoxAutoRun.TabStop = False
        Me.GroupBoxAutoRun.Text = "AutoRun"
        Me.GroupBoxAutoRun.Visible = False
        '
        'TextBoxAutoRun
        '
        Me.TextBoxAutoRun.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextBoxAutoRun.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAutoRun.ForeColor = System.Drawing.Color.Crimson
        Me.TextBoxAutoRun.Location = New System.Drawing.Point(3, 17)
        Me.TextBoxAutoRun.Name = "TextBoxAutoRun"
        Me.TextBoxAutoRun.Size = New System.Drawing.Size(189, 23)
        Me.TextBoxAutoRun.TabIndex = 0
        Me.TextBoxAutoRun.Text = "XX"
        '
        'ButtonCheckWizzard
        '
        Me.ButtonCheckWizzard.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCheckWizzard.Location = New System.Drawing.Point(10, 31)
        Me.ButtonCheckWizzard.Name = "ButtonCheckWizzard"
        Me.ButtonCheckWizzard.Size = New System.Drawing.Size(163, 33)
        Me.ButtonCheckWizzard.TabIndex = 3
        Me.ButtonCheckWizzard.Text = "Check Settings"
        Me.ToolTip1.SetToolTip(Me.ButtonCheckWizzard, "Checks if there is a settings wizzard for this application")
        Me.ButtonCheckWizzard.UseVisualStyleBackColor = True
        '
        'ButtonDeleteResult
        '
        Me.ButtonDeleteResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDeleteResult.Location = New System.Drawing.Point(12, 155)
        Me.ButtonDeleteResult.Name = "ButtonDeleteResult"
        Me.ButtonDeleteResult.Size = New System.Drawing.Size(161, 36)
        Me.ButtonDeleteResult.TabIndex = 2
        Me.ButtonDeleteResult.Text = "Delete the result"
        Me.ButtonDeleteResult.UseVisualStyleBackColor = True
        '
        'ButtonShowResult
        '
        Me.ButtonShowResult.Enabled = False
        Me.ButtonShowResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonShowResult.Location = New System.Drawing.Point(12, 114)
        Me.ButtonShowResult.Name = "ButtonShowResult"
        Me.ButtonShowResult.Size = New System.Drawing.Size(161, 35)
        Me.ButtonShowResult.TabIndex = 1
        Me.ButtonShowResult.Text = "Show result"
        Me.ButtonShowResult.UseVisualStyleBackColor = True
        '
        'ButtonStartCreate
        '
        Me.ButtonStartCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStartCreate.Location = New System.Drawing.Point(10, 74)
        Me.ButtonStartCreate.Name = "ButtonStartCreate"
        Me.ButtonStartCreate.Size = New System.Drawing.Size(163, 34)
        Me.ButtonStartCreate.TabIndex = 0
        Me.ButtonStartCreate.Text = "Create installation"
        Me.ButtonStartCreate.UseVisualStyleBackColor = True
        '
        'SplitContainer1H
        '
        Me.SplitContainer1H.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.SplitContainer1H.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1H.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1H.Name = "SplitContainer1H"
        Me.SplitContainer1H.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1H.Panel1
        '
        Me.SplitContainer1H.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1H.Panel1.Controls.Add(Me.CheckBoxTADeinstall)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.CheckBoxTASelect)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.CheckBoxTASetup)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.ComboBoxInstVer)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.ComboBoxInstName)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1H.Panel1.Controls.Add(Me.ComboBoxDevDepo)
        '
        'SplitContainer1H.Panel2
        '
        Me.SplitContainer1H.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer1H.Panel2.Controls.Add(Me.SplitContainer2V)
        Me.SplitContainer1H.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer1H.Size = New System.Drawing.Size(674, 519)
        Me.SplitContainer1H.SplitterDistance = 101
        Me.SplitContainer1H.TabIndex = 2
        '
        'CheckBoxTADeinstall
        '
        Me.CheckBoxTADeinstall.AutoSize = True
        Me.CheckBoxTADeinstall.Checked = True
        Me.CheckBoxTADeinstall.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTADeinstall.Location = New System.Drawing.Point(345, 55)
        Me.CheckBoxTADeinstall.Name = "CheckBoxTADeinstall"
        Me.CheckBoxTADeinstall.Size = New System.Drawing.Size(103, 17)
        Me.CheckBoxTADeinstall.TabIndex = 8
        Me.CheckBoxTADeinstall.Text = "TA-Deinstall.exe"
        Me.CheckBoxTADeinstall.UseVisualStyleBackColor = True
        '
        'CheckBoxTASelect
        '
        Me.CheckBoxTASelect.AutoSize = True
        Me.CheckBoxTASelect.Location = New System.Drawing.Point(345, 31)
        Me.CheckBoxTASelect.Name = "CheckBoxTASelect"
        Me.CheckBoxTASelect.Size = New System.Drawing.Size(93, 17)
        Me.CheckBoxTASelect.TabIndex = 7
        Me.CheckBoxTASelect.Text = "TA-Select.exe"
        Me.CheckBoxTASelect.UseVisualStyleBackColor = True
        '
        'CheckBoxTASetup
        '
        Me.CheckBoxTASetup.AutoSize = True
        Me.CheckBoxTASetup.Checked = True
        Me.CheckBoxTASetup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTASetup.Enabled = False
        Me.CheckBoxTASetup.Location = New System.Drawing.Point(345, 7)
        Me.CheckBoxTASetup.Name = "CheckBoxTASetup"
        Me.CheckBoxTASetup.Size = New System.Drawing.Size(91, 17)
        Me.CheckBoxTASetup.TabIndex = 6
        Me.CheckBoxTASetup.Text = "TA-Setup.exe"
        Me.CheckBoxTASetup.UseVisualStyleBackColor = True
        '
        'ComboBoxInstVer
        '
        Me.ComboBoxInstVer.FormattingEnabled = True
        Me.ComboBoxInstVer.Items.AddRange(New Object() {"01", "02", "03", "04", "05"})
        Me.ComboBoxInstVer.Location = New System.Drawing.Point(84, 59)
        Me.ComboBoxInstVer.Name = "ComboBoxInstVer"
        Me.ComboBoxInstVer.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxInstVer.TabIndex = 5
        Me.ComboBoxInstVer.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Inst Version"
        '
        'ComboBoxInstName
        '
        Me.ComboBoxInstName.FormattingEnabled = True
        Me.ComboBoxInstName.Items.AddRange(New Object() {"NX12", "NX1926", "Creo4", "Creo8", "Notepad_pp", "WinSysinternals", "VirtualDesktopManager"})
        Me.ComboBoxInstName.Location = New System.Drawing.Point(84, 31)
        Me.ComboBoxInstName.Name = "ComboBoxInstName"
        Me.ComboBoxInstName.Size = New System.Drawing.Size(200, 21)
        Me.ComboBoxInstName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Inst Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dev Depo"
        '
        'ComboBoxDevDepo
        '
        Me.ComboBoxDevDepo.FormattingEnabled = True
        Me.ComboBoxDevDepo.Location = New System.Drawing.Point(84, 3)
        Me.ComboBoxDevDepo.Name = "ComboBoxDevDepo"
        Me.ComboBoxDevDepo.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxDevDepo.TabIndex = 0
        '
        'SplitContainer2V
        '
        Me.SplitContainer2V.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.SplitContainer2V.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2V.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2V.Name = "SplitContainer2V"
        '
        'SplitContainer2V.Panel1
        '
        Me.SplitContainer2V.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxReDownload)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxCopySource)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxLogToServer)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxStopUpdates)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.Label4)
        '
        'SplitContainer2V.Panel2
        '
        Me.SplitContainer2V.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2V.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer2V.Size = New System.Drawing.Size(674, 392)
        Me.SplitContainer2V.SplitterDistance = 128
        Me.SplitContainer2V.TabIndex = 2
        '
        'CheckBoxReDownload
        '
        Me.CheckBoxReDownload.AutoSize = True
        Me.CheckBoxReDownload.Location = New System.Drawing.Point(6, 129)
        Me.CheckBoxReDownload.Name = "CheckBoxReDownload"
        Me.CheckBoxReDownload.Size = New System.Drawing.Size(91, 17)
        Me.CheckBoxReDownload.TabIndex = 4
        Me.CheckBoxReDownload.Text = "Re-Download"
        Me.ToolTip1.SetToolTip(Me.CheckBoxReDownload, "Re-downloading files is only useful if files are downloaded" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and if (some) of the" &
        "m are damaged or obsolete." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This setting cannot be set by an application wizza" &
        "rd" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You need to set this explicitly.")
        Me.CheckBoxReDownload.UseVisualStyleBackColor = True
        '
        'CheckBoxCopySource
        '
        Me.CheckBoxCopySource.AutoSize = True
        Me.CheckBoxCopySource.Location = New System.Drawing.Point(6, 25)
        Me.CheckBoxCopySource.Name = "CheckBoxCopySource"
        Me.CheckBoxCopySource.Size = New System.Drawing.Size(132, 17)
        Me.CheckBoxCopySource.TabIndex = 3
        Me.CheckBoxCopySource.Text = "Copy Source To Local"
        Me.CheckBoxCopySource.UseVisualStyleBackColor = True
        '
        'CheckBoxLogToServer
        '
        Me.CheckBoxLogToServer.AutoSize = True
        Me.CheckBoxLogToServer.Location = New System.Drawing.Point(6, 105)
        Me.CheckBoxLogToServer.Name = "CheckBoxLogToServer"
        Me.CheckBoxLogToServer.Size = New System.Drawing.Size(121, 17)
        Me.CheckBoxLogToServer.TabIndex = 2
        Me.CheckBoxLogToServer.Text = "Copy Log To Server"
        Me.ToolTip1.SetToolTip(Me.CheckBoxLogToServer, "You need to have a log-share configured" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "if you want to use this." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This setting" &
        " cannot be set by an application wizzard" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You need to set this explicitly.")
        Me.CheckBoxLogToServer.UseVisualStyleBackColor = True
        '
        'CheckBoxStopUpdates
        '
        Me.CheckBoxStopUpdates.AutoSize = True
        Me.CheckBoxStopUpdates.Location = New System.Drawing.Point(6, 82)
        Me.CheckBoxStopUpdates.Name = "CheckBoxStopUpdates"
        Me.CheckBoxStopUpdates.Size = New System.Drawing.Size(91, 17)
        Me.CheckBoxStopUpdates.TabIndex = 1
        Me.CheckBoxStopUpdates.Text = "Stop Updates"
        Me.ToolTip1.SetToolTip(Me.CheckBoxStopUpdates, "Stop background installations." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Enable this for installations that are MSI Based" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This setting cannot be set by an application wizzard" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You need to set this ex" &
        "plicitly.")
        Me.CheckBoxStopUpdates.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "All Types"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageWinBat)
        Me.TabControl1.Controls.Add(Me.TabPagePS)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(542, 392)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageWinBat
        '
        Me.TabPageWinBat.Controls.Add(Me.GroupBoxRem)
        Me.TabPageWinBat.Controls.Add(Me.Label5)
        Me.TabPageWinBat.Controls.Add(Me.CheckBoxBatSeparatePost)
        Me.TabPageWinBat.Controls.Add(Me.CheckBoxBatSeparateApp)
        Me.TabPageWinBat.Controls.Add(Me.CheckBoxBatSeparateInit)
        Me.TabPageWinBat.Location = New System.Drawing.Point(4, 24)
        Me.TabPageWinBat.Name = "TabPageWinBat"
        Me.TabPageWinBat.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageWinBat.Size = New System.Drawing.Size(534, 364)
        Me.TabPageWinBat.TabIndex = 0
        Me.TabPageWinBat.Text = "Windows Batch"
        Me.TabPageWinBat.UseVisualStyleBackColor = True
        '
        'GroupBoxRem
        '
        Me.GroupBoxRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxRem.Controls.Add(Me.RadioButtonRemHash)
        Me.GroupBoxRem.Controls.Add(Me.RadioButtonRemEcho)
        Me.GroupBoxRem.Controls.Add(Me.RadioButtonRemDots)
        Me.GroupBoxRem.Controls.Add(Me.RadioButtonRemRem)
        Me.GroupBoxRem.Location = New System.Drawing.Point(380, 6)
        Me.GroupBoxRem.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRem.Name = "GroupBoxRem"
        Me.GroupBoxRem.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBoxRem.Size = New System.Drawing.Size(150, 102)
        Me.GroupBoxRem.TabIndex = 4
        Me.GroupBoxRem.TabStop = False
        Me.GroupBoxRem.Text = "Bat Remark Method"
        '
        'RadioButtonRemHash
        '
        Me.RadioButtonRemHash.AutoSize = True
        Me.RadioButtonRemHash.Location = New System.Drawing.Point(5, 80)
        Me.RadioButtonRemHash.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioButtonRemHash.Name = "RadioButtonRemHash"
        Me.RadioButtonRemHash.Size = New System.Drawing.Size(32, 19)
        Me.RadioButtonRemHash.TabIndex = 3
        Me.RadioButtonRemHash.TabStop = True
        Me.RadioButtonRemHash.Text = "#"
        Me.RadioButtonRemHash.UseVisualStyleBackColor = True
        '
        'RadioButtonRemEcho
        '
        Me.RadioButtonRemEcho.AutoSize = True
        Me.RadioButtonRemEcho.Location = New System.Drawing.Point(5, 59)
        Me.RadioButtonRemEcho.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioButtonRemEcho.Name = "RadioButtonRemEcho"
        Me.RadioButtonRemEcho.Size = New System.Drawing.Size(64, 19)
        Me.RadioButtonRemEcho.TabIndex = 2
        Me.RadioButtonRemEcho.TabStop = True
        Me.RadioButtonRemEcho.Text = "@echo"
        Me.RadioButtonRemEcho.UseVisualStyleBackColor = True
        '
        'RadioButtonRemDots
        '
        Me.RadioButtonRemDots.AutoSize = True
        Me.RadioButtonRemDots.Location = New System.Drawing.Point(5, 38)
        Me.RadioButtonRemDots.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioButtonRemDots.Name = "RadioButtonRemDots"
        Me.RadioButtonRemDots.Size = New System.Drawing.Size(31, 19)
        Me.RadioButtonRemDots.TabIndex = 1
        Me.RadioButtonRemDots.TabStop = True
        Me.RadioButtonRemDots.Text = "::"
        Me.RadioButtonRemDots.UseVisualStyleBackColor = True
        '
        'RadioButtonRemRem
        '
        Me.RadioButtonRemRem.AutoSize = True
        Me.RadioButtonRemRem.Location = New System.Drawing.Point(5, 17)
        Me.RadioButtonRemRem.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioButtonRemRem.Name = "RadioButtonRemRem"
        Me.RadioButtonRemRem.Size = New System.Drawing.Size(53, 19)
        Me.RadioButtonRemRem.TabIndex = 0
        Me.RadioButtonRemRem.TabStop = True
        Me.RadioButtonRemRem.Text = "REM"
        Me.RadioButtonRemRem.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 329)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "InstallationWizzard"
        Me.Label5.Visible = False
        '
        'CheckBoxBatSeparatePost
        '
        Me.CheckBoxBatSeparatePost.AutoSize = True
        Me.CheckBoxBatSeparatePost.Location = New System.Drawing.Point(6, 59)
        Me.CheckBoxBatSeparatePost.Name = "CheckBoxBatSeparatePost"
        Me.CheckBoxBatSeparatePost.Size = New System.Drawing.Size(165, 19)
        Me.CheckBoxBatSeparatePost.TabIndex = 2
        Me.CheckBoxBatSeparatePost.Text = "Separate Post Installation"
        Me.CheckBoxBatSeparatePost.UseVisualStyleBackColor = True
        '
        'CheckBoxBatSeparateApp
        '
        Me.CheckBoxBatSeparateApp.AutoSize = True
        Me.CheckBoxBatSeparateApp.Location = New System.Drawing.Point(6, 35)
        Me.CheckBoxBatSeparateApp.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBoxBatSeparateApp.Name = "CheckBoxBatSeparateApp"
        Me.CheckBoxBatSeparateApp.Size = New System.Drawing.Size(187, 19)
        Me.CheckBoxBatSeparateApp.TabIndex = 1
        Me.CheckBoxBatSeparateApp.Text = "Separate Application Inst. File"
        Me.CheckBoxBatSeparateApp.UseVisualStyleBackColor = True
        '
        'CheckBoxBatSeparateInit
        '
        Me.CheckBoxBatSeparateInit.AutoSize = True
        Me.CheckBoxBatSeparateInit.Location = New System.Drawing.Point(6, 11)
        Me.CheckBoxBatSeparateInit.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBoxBatSeparateInit.Name = "CheckBoxBatSeparateInit"
        Me.CheckBoxBatSeparateInit.Size = New System.Drawing.Size(95, 19)
        Me.CheckBoxBatSeparateInit.TabIndex = 0
        Me.CheckBoxBatSeparateInit.Text = "Separate Init"
        Me.CheckBoxBatSeparateInit.UseVisualStyleBackColor = True
        '
        'TabPagePS
        '
        Me.TabPagePS.Location = New System.Drawing.Point(4, 24)
        Me.TabPagePS.Name = "TabPagePS"
        Me.TabPagePS.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPagePS.Size = New System.Drawing.Size(534, 364)
        Me.TabPagePS.TabIndex = 1
        Me.TabPagePS.Text = "Power Shell"
        Me.TabPagePS.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 392)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(674, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(238, 17)
        Me.ToolStripStatusLabel1.Text = "Select the installation type and components"
        '
        'TextBoxInfo
        '
        Me.TextBoxInfo.AcceptsReturn = True
        Me.TextBoxInfo.Font = New System.Drawing.Font("Liberation Mono", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxInfo.Location = New System.Drawing.Point(228, 227)
        Me.TextBoxInfo.Multiline = True
        Me.TextBoxInfo.Name = "TextBoxInfo"
        Me.TextBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxInfo.Size = New System.Drawing.Size(123, 64)
        Me.TextBoxInfo.TabIndex = 1
        Me.TextBoxInfo.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.TextBoxInfo.Visible = False
        Me.TextBoxInfo.WordWrap = False
        '
        'TimerInit
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 543)
        Me.Controls.Add(Me.SplitContainerBase)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainerBase.Panel1.ResumeLayout(False)
        Me.SplitContainerBase.Panel2.ResumeLayout(False)
        Me.SplitContainerBase.Panel2.PerformLayout()
        CType(Me.SplitContainerBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerBase.ResumeLayout(False)
        Me.GroupBoxAutoRun.ResumeLayout(False)
        Me.GroupBoxAutoRun.PerformLayout()
        Me.SplitContainer1H.Panel1.ResumeLayout(False)
        Me.SplitContainer1H.Panel1.PerformLayout()
        Me.SplitContainer1H.Panel2.ResumeLayout(False)
        Me.SplitContainer1H.Panel2.PerformLayout()
        CType(Me.SplitContainer1H, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1H.ResumeLayout(False)
        Me.SplitContainer2V.Panel1.ResumeLayout(False)
        Me.SplitContainer2V.Panel1.PerformLayout()
        Me.SplitContainer2V.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2V.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageWinBat.ResumeLayout(False)
        Me.TabPageWinBat.PerformLayout()
        Me.GroupBoxRem.ResumeLayout(False)
        Me.GroupBoxRem.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowSettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainerBase As SplitContainer
    Friend WithEvents TextBoxInfo As TextBox
    Friend WithEvents SplitContainer1H As SplitContainer
    Friend WithEvents ButtonStartCreate As Button
    Friend WithEvents SplitContainer2V As SplitContainer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TimerInit As Timer
    Friend WithEvents ComboBoxDevDepo As ComboBox
    Friend WithEvents ComboBoxInstVer As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxInstName As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxTADeinstall As CheckBox
    Friend WithEvents CheckBoxTASelect As CheckBox
    Friend WithEvents CheckBoxTASetup As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPageWinBat As TabPage
    Friend WithEvents TabPagePS As TabPage
    Friend WithEvents CheckBoxStopUpdates As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents CheckBoxLogToServer As CheckBox
    Friend WithEvents CheckBoxBatSeparateApp As CheckBox
    Friend WithEvents CheckBoxBatSeparateInit As CheckBox
    Friend WithEvents ButtonShowResult As Button
    Friend WithEvents CheckBoxBatSeparatePost As CheckBox
    Friend WithEvents ToolStripSave As ToolStripMenuItem
    Friend WithEvents ButtonDeleteResult As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents CheckBoxCopySource As CheckBox
    Friend WithEvents CheckBoxReDownload As CheckBox
    Friend WithEvents GroupBoxRem As GroupBox
    Friend WithEvents RadioButtonRemEcho As RadioButton
    Friend WithEvents RadioButtonRemDots As RadioButton
    Friend WithEvents RadioButtonRemRem As RadioButton
    Friend WithEvents RadioButtonRemHash As RadioButton
    Friend WithEvents ButtonCheckWizzard As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents GroupBoxAutoRun As GroupBox
    Friend WithEvents TextBoxAutoRun As TextBox
End Class
