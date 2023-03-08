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
        Me.ComboBoxDevDepo = New System.Windows.Forms.ComboBox()
        Me.SplitContainer2V = New System.Windows.Forms.SplitContainer()
        Me.CheckBoxTADeinstall = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTASelect = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTASetup = New System.Windows.Forms.CheckBox()
        Me.ButtonBat = New System.Windows.Forms.Button()
        Me.ButtonPS = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TextBoxInfo = New System.Windows.Forms.TextBox()
        Me.TimerInit = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxInstName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxInstVer = New System.Windows.Forms.ComboBox()
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
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
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
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
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
        Me.SplitContainerBase.Panel1.Controls.Add(Me.ButtonStartCreate)
        '
        'SplitContainerBase.Panel2
        '
        Me.SplitContainerBase.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainerBase.Panel2.Controls.Add(Me.SplitContainer1H)
        Me.SplitContainerBase.Panel2.Controls.Add(Me.TextBoxInfo)
        Me.SplitContainerBase.Size = New System.Drawing.Size(873, 519)
        Me.SplitContainerBase.SplitterDistance = 196
        Me.SplitContainerBase.TabIndex = 3
        '
        'ButtonStartCreate
        '
        Me.ButtonStartCreate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonStartCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStartCreate.Location = New System.Drawing.Point(18, 93)
        Me.ButtonStartCreate.Name = "ButtonStartCreate"
        Me.ButtonStartCreate.Size = New System.Drawing.Size(157, 34)
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
        Me.SplitContainer1H.Size = New System.Drawing.Size(673, 519)
        Me.SplitContainer1H.SplitterDistance = 165
        Me.SplitContainer1H.TabIndex = 2
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
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxTADeinstall)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxTASelect)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.CheckBoxTASetup)
        Me.SplitContainer2V.Panel1.Controls.Add(Me.ButtonBat)
        '
        'SplitContainer2V.Panel2
        '
        Me.SplitContainer2V.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer2V.Panel2.Controls.Add(Me.ButtonPS)
        Me.SplitContainer2V.Size = New System.Drawing.Size(673, 328)
        Me.SplitContainer2V.SplitterDistance = 284
        Me.SplitContainer2V.TabIndex = 2
        '
        'CheckBoxTADeinstall
        '
        Me.CheckBoxTADeinstall.AutoSize = True
        Me.CheckBoxTADeinstall.Location = New System.Drawing.Point(16, 94)
        Me.CheckBoxTADeinstall.Name = "CheckBoxTADeinstall"
        Me.CheckBoxTADeinstall.Size = New System.Drawing.Size(103, 17)
        Me.CheckBoxTADeinstall.TabIndex = 3
        Me.CheckBoxTADeinstall.Text = "TA-Deinstall.exe"
        Me.CheckBoxTADeinstall.UseVisualStyleBackColor = True
        '
        'CheckBoxTASelect
        '
        Me.CheckBoxTASelect.AutoSize = True
        Me.CheckBoxTASelect.Location = New System.Drawing.Point(16, 70)
        Me.CheckBoxTASelect.Name = "CheckBoxTASelect"
        Me.CheckBoxTASelect.Size = New System.Drawing.Size(93, 17)
        Me.CheckBoxTASelect.TabIndex = 2
        Me.CheckBoxTASelect.Text = "TA-Select.exe"
        Me.CheckBoxTASelect.UseVisualStyleBackColor = True
        '
        'CheckBoxTASetup
        '
        Me.CheckBoxTASetup.AutoSize = True
        Me.CheckBoxTASetup.Checked = True
        Me.CheckBoxTASetup.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTASetup.Enabled = False
        Me.CheckBoxTASetup.Location = New System.Drawing.Point(16, 46)
        Me.CheckBoxTASetup.Name = "CheckBoxTASetup"
        Me.CheckBoxTASetup.Size = New System.Drawing.Size(91, 17)
        Me.CheckBoxTASetup.TabIndex = 1
        Me.CheckBoxTASetup.Text = "TA-Setup.exe"
        Me.CheckBoxTASetup.UseVisualStyleBackColor = True
        '
        'ButtonBat
        '
        Me.ButtonBat.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonBat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBat.Location = New System.Drawing.Point(0, 0)
        Me.ButtonBat.Name = "ButtonBat"
        Me.ButtonBat.Size = New System.Drawing.Size(284, 40)
        Me.ButtonBat.TabIndex = 0
        Me.ButtonBat.Text = "Windows Batch"
        Me.ButtonBat.UseVisualStyleBackColor = True
        '
        'ButtonPS
        '
        Me.ButtonPS.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPS.Location = New System.Drawing.Point(0, 0)
        Me.ButtonPS.Name = "ButtonPS"
        Me.ButtonPS.Size = New System.Drawing.Size(385, 40)
        Me.ButtonPS.TabIndex = 0
        Me.ButtonPS.Text = "Power Shell"
        Me.ButtonPS.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 328)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(673, 22)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Dev Depo"
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
        'ComboBoxInstName
        '
        Me.ComboBoxInstName.FormattingEnabled = True
        Me.ComboBoxInstName.Items.AddRange(New Object() {"NX12", "NX1926", "Creo4", "Creo8", "Notepad_pp", "WinSysinternals", "VirtualDesktopManager"})
        Me.ComboBoxInstName.Location = New System.Drawing.Point(84, 31)
        Me.ComboBoxInstName.Name = "ComboBoxInstName"
        Me.ComboBoxInstName.Size = New System.Drawing.Size(200, 21)
        Me.ComboBoxInstName.TabIndex = 3
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
    Friend WithEvents CheckBoxTADeinstall As CheckBox
    Friend WithEvents CheckBoxTASelect As CheckBox
    Friend WithEvents CheckBoxTASetup As CheckBox
    Friend WithEvents ButtonBat As Button
    Friend WithEvents ButtonPS As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TimerInit As Timer
    Friend WithEvents ComboBoxDevDepo As ComboBox
    Friend WithEvents ComboBoxInstVer As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBoxInstName As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
End Class
