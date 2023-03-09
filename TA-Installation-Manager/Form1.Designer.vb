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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainerBase = New System.Windows.Forms.SplitContainer()
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
        Me.CheckBoxLogToServer = New System.Windows.Forms.CheckBox()
        Me.CheckBoxStopUpdates = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageWinBat = New System.Windows.Forms.TabPage()
        Me.CheckBoxBatSeparateApp = New System.Windows.Forms.CheckBox()
        Me.CheckBoxBatSeparateInit = New System.Windows.Forms.CheckBox()
        Me.TabPagePS = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBoxInfo = New System.Windows.Forms.TextBox()
        Me.TimerInit = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonShowResult = New System.Windows.Forms.Button()
        Me.CheckBoxBatSeparatePost = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainerBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerBase.Panel1.SuspendLayout()
        Me.SplitContainerBase.Panel2.SuspendLayout()
        Me.SplitContainerBase.SuspendLayout()
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
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
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
        Me.ShowSettingsToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ShowSettingsToolStripMenuItem.Text = "Show settings"
        '
        'ShowLogToolStripMenuItem
        '
        Me.ShowLogToolStripMenuItem.Name = "ShowLogToolStripMenuItem"
        Me.ShowLogToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
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
        'ButtonStartCreate
        '
        Me.ButtonStartCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStartCreate.Location = New System.Drawing.Point(10, 74)
        Me.ButtonStartCreate.Name = "ButtonStartCreate"
        Me.ButtonStartCreate.Size = New System.Drawing.Size(161, 34)
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
        Me.SplitContainer1H.SplitterDistance = 102
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
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxLogToServer)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxStopUpdates)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.Label4)
        '
        'SplitContainer2V.Panel2
        '
        Me.SplitContainer2V.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2V.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer2V.Size = New System.Drawing.Size(674, 391)
        Me.SplitContainer2V.SplitterDistance = 129
        Me.SplitContainer2V.TabIndex = 2
        '
        'CheckBoxLogToServer
        '
        Me.CheckBoxLogToServer.AutoSize = True
        Me.CheckBoxLogToServer.Location = New System.Drawing.Point(4, 57)
        Me.CheckBoxLogToServer.Name = "CheckBoxLogToServer"
        Me.CheckBoxLogToServer.Size = New System.Drawing.Size(121, 17)
        Me.CheckBoxLogToServer.TabIndex = 2
        Me.CheckBoxLogToServer.Text = "Copy Log To Server"
        Me.CheckBoxLogToServer.UseVisualStyleBackColor = True
        '
        'CheckBoxStopUpdates
        '
        Me.CheckBoxStopUpdates.AutoSize = True
        Me.CheckBoxStopUpdates.Location = New System.Drawing.Point(4, 33)
        Me.CheckBoxStopUpdates.Name = "CheckBoxStopUpdates"
        Me.CheckBoxStopUpdates.Size = New System.Drawing.Size(91, 17)
        Me.CheckBoxStopUpdates.TabIndex = 1
        Me.CheckBoxStopUpdates.Text = "Stop Updates"
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
        Me.TabControl1.Size = New System.Drawing.Size(541, 391)
        Me.TabControl1.TabIndex = 0
        '
        'TabPageWinBat
        '
        Me.TabPageWinBat.Controls.Add(Me.CheckBoxBatSeparatePost)
        Me.TabPageWinBat.Controls.Add(Me.CheckBoxBatSeparateApp)
        Me.TabPageWinBat.Controls.Add(Me.CheckBoxBatSeparateInit)
        Me.TabPageWinBat.Location = New System.Drawing.Point(4, 24)
        Me.TabPageWinBat.Name = "TabPageWinBat"
        Me.TabPageWinBat.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPageWinBat.Size = New System.Drawing.Size(533, 363)
        Me.TabPageWinBat.TabIndex = 0
        Me.TabPageWinBat.Text = "Windows Batch"
        Me.TabPageWinBat.UseVisualStyleBackColor = True
        '
        'CheckBoxBatSeparateApp
        '
        Me.CheckBoxBatSeparateApp.AutoSize = True
        Me.CheckBoxBatSeparateApp.Location = New System.Drawing.Point(6, 35)
        Me.CheckBoxBatSeparateApp.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.CheckBoxBatSeparateApp.Name = "CheckBoxBatSeparateApp"
        Me.CheckBoxBatSeparateApp.Size = New System.Drawing.Size(181, 19)
        Me.CheckBoxBatSeparateApp.TabIndex = 1
        Me.CheckBoxBatSeparateApp.Text = "Separate Application Ins File"
        Me.CheckBoxBatSeparateApp.UseVisualStyleBackColor = True
        '
        'CheckBoxBatSeparateInit
        '
        Me.CheckBoxBatSeparateInit.AutoSize = True
        Me.CheckBoxBatSeparateInit.Location = New System.Drawing.Point(6, 11)
        Me.CheckBoxBatSeparateInit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
        Me.TabPagePS.Padding = New System.Windows.Forms.Padding(3, 3, 3, 3)
        Me.TabPagePS.Size = New System.Drawing.Size(532, 367)
        Me.TabPagePS.TabIndex = 1
        Me.TabPagePS.Text = "Power Shell"
        Me.TabPagePS.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 391)
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
        'ButtonShowResult
        '
        Me.ButtonShowResult.Enabled = False
        Me.ButtonShowResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonShowResult.Location = New System.Drawing.Point(9, 124)
        Me.ButtonShowResult.Name = "ButtonShowResult"
        Me.ButtonShowResult.Size = New System.Drawing.Size(161, 35)
        Me.ButtonShowResult.TabIndex = 1
        Me.ButtonShowResult.Text = "Show result"
        Me.ButtonShowResult.UseVisualStyleBackColor = True
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 543)
        Me.Controls.Add(Me.SplitContainerBase)
        Me.Controls.Add(Me.MenuStrip1)
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
End Class
