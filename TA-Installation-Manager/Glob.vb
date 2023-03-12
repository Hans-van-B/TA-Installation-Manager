Module Glob
    ' Template Windows Forms
    Public AppName As String = "TA-Installation-Manager"
    Public AppVer As String = "0.01.06"

    Public AppRoot As String = Application.StartupPath
    Public CD As String = My.Computer.FileSystem.CurrentDirectory

    ' Log File
    Public Temp As String = Environment.GetEnvironmentVariable("TEMP")
    Public G_TL_FR As Integer = 2   ' Trace level File Reads
    Public ExitProgram As Boolean = False
    Public StartSeq As String = ""

    ' Defaults
    Public IniFile1 As String = AppRoot & "\" & AppName & ".ini"
    Public IniFile2 As String = AppRoot & "\Data\" & AppName & ".ini"
    Public ScriptTypeSelect As String = ""
    Public CopySourceToLocal As Boolean = True
    Public BatSeparateInit As String = "False"
    Public BatSeparateApp As String = "False"
    Public BatSeparatePost As String = "False"
    Public IniDevDepo As String = "<Undefined>"
    Public ReDownload As Boolean = False

    Public StopUpdates As String = "False"
    Public CopyLogToServer As String = "False"

    Public EndDelay As Integer = 2
    Public EndPause As Boolean = False
    Public ShowGui As Boolean = False


End Module
