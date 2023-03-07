' StdMod: C:\Cloud1\VB.Net-Dev\Lib\StdMod\Log.vb
' Dependencies on other modules has largely been removed

Module Log
    Public ErrorCount As Integer = 0
    Public WarningCount As Integer = 0
    Public Debug As Boolean = False
    Public Verbose As Boolean = False
    Public LogFile As String = Temp & "\" & AppName & ".log"
    Public HintList() As String = {"Check if there are no other instances of " & AppName & " running. If you are unsure the please restart your computer and restart the installation.",
                                   "Unknown error, try to restart your computer and restart the installation.",
                                   "Check if another instance of the installation is running."}
    Public WarnIfLogfileInUse As Boolean = False
    Public StartSeq As String = ""

    Dim SubLevel As Integer = 0                        ' Count the call depth
    Public CTrace As Integer = 1                       ' Console Trace Level
    Public LTrace As Integer = 2                       ' Log File Trace Level
    Public G_TL_Sub As Integer = 2  ' Trace level for Subroutines
    Dim LogStatus As Integer = 0
    Dim LogFileMode As Integer = 0   ' 0=None, 1=Once, 2=Fresh (differs if called multiple times)
    Dim LogFileName As String
    Dim LogFileAppendix As String

    '=============================================================================================
    Sub Read_Trace_Command_Line_Arg()
        xtrace_subs("Read_Trace_Command_Line_Arg")

        If Environment.GetEnvironmentVariable("DEBUG") = "TRUE" Then
            Debug = True
            dtrace_i("Set by environment Debug = True")
            Verbose = True
        End If

        Dim SwName As String = ""
        Dim SwString As String = ""
        Dim P1 As Integer
        Dim Name As String
        Dim ValS As String


        For Each argument As String In My.Application.CommandLineArgs
            xtrace_i("Argument=" & argument)

            '---- Double-dash arguments
            If Left(argument, 2) = "--" Then
                SwName = Mid(argument, 3)
                dtrace_i("DDA:" & SwName)

                '---- Double-dash Assignment
                P1 = InStr(SwName, "=")
                If P1 > 0 Then
                    Name = Left(SwName, P1 - 1)
                    ValS = Mid(SwName, P1 + 1)
                    dtrace_i("Name = " & Name)

                    If Name = "lfm" Then
                        LogFileMode = Val(ValS)
                        xtrace_i("LogFileMode = " & LogFileMode.ToString)
                    End If

                    If Name = "seq" Then
                        StartSeq = ValS
                        xtrace_i("StartSeq = " & StartSeq)
                    End If

                    Continue For
                End If
				
				'---- Double-dash, No Assignment
				
				Continue For
            End If

            '---- Single-dash arguments
            If Left(argument, 1) = "-" Then
                ' Switch String = remaining switches
                SwString = Mid(argument, 2)

                ' for each switch in the string
                While Len(SwString) > 0
                    SwName = Left(SwString, 1)
                    SwString = Mid(SwString, 2)
                    dtrace_i("SDA:" & SwName & "," & SwString)

                    If SwName = "v" Then
                        xtrace_i("Set verbose = True")
                        Verbose = True
                    End If

                    If SwName = "d" Then
                        xtrace_i("Set Debug = True")
                        Debug = True
                        Verbose = True
                    End If
                End While

                Continue For
            End If
        Next

        xtrace_sube("Read_Trace_Command_Line_Arg End")
    End Sub

    '===============================================================================

    Sub InitTemp()
        xtrace_subs("InitTemp")

        Temp = Temp & "\TAIS"
        xtrace_i("Temp = " & Temp)
        If Not My.Computer.FileSystem.DirectoryExists(Temp) Then
            My.Computer.FileSystem.CreateDirectory(Temp)
        End If

        xtrace_sube("InitTemp")
    End Sub

    '===============================================================================

    '---- Set log file appendix as datestamp ---------------------
    Function SetLogFileAppendix() As String
        xtrace_subs("SetLogFileAppendix")

        Dim t As String = DateTime.Now.TimeOfDay.ToString
        t = t.Replace(":", "")
        t = t.Replace(".", "")
        LogFileAppendix = "_" & t
        xtrace_i("SetLogFileAppendix = " & LogFileAppendix)
        SetLogFileAppendix = LogFileAppendix

        xtrace_sube("SetLogFileAppendix")
    End Function

    '---- Set log file name
    Function SetLogFileName() As String
        xtrace_subs("SetLogFileName")

        ' Read command-line argument, set the switches
        Read_Trace_Command_Line_Arg()

        ' Set the log file name
        Select Case LogFileMode
            Case 0

                If StartSeq = "" Then
                    LogFileAppendix = ""
                Else
                    LogFileAppendix = "_" & StartSeq
                End If
            Case 1
                If LogFileAppendix Is Nothing Then SetLogFileAppendix()
            Case 2
                SetLogFileAppendix()
            Case Else
                xtrace_warn("Invalid LogFileMode")
                LogFileAppendix = ""
        End Select
        xtrace_i("LogFileAppendix = " & LogFileAppendix)

        LogFileName = AppName & LogFileAppendix     ' Without extension can also be used for other file formats
        xtrace_i("LogFileName = " & LogFileName)
        SetLogFileName = LogFileName

        xtrace_sube("SetLogFileName")
    End Function

    Sub xtrace_init()
        xtrace_subs("xtrace_init")

        xtrace_i("Standard Log Module / V-0.03 / 2023-03-03")
		xtrace_i("TimeStamp            = " & DateTime.Now)
        InitTemp()
        LogFile = Temp & "\" & SetLogFileName() & ".log"
        xtrace_i("LogFile = " & LogFile)

        ' Show the command-line string at the top of the log file
        ' If the log file is in use then switch to using the timestamp appendix
        While Not ModFileSystem.WriteTxtToFile(LogFile, Environment.CommandLine & vbCrLf, False, 1001, "Failed to initialize the log file", HintList(0), WarnIfLogfileInUse, False)
            SetLogFileAppendix()
            LogFileName = AppName & LogFileAppendix
            LogFile = Temp & "\" & LogFileName & ".log"
            xtrace_i("Retry with = " & LogFile)
            WarnIfLogfileInUse = True
        End While
        xtrace_i("LogFile Ready")
        LogStatus = 1
		' Write at the top, before the log cashe'
		xtrace_header()
		
        FlushLogCashe()

        xtrace_sube("xtrace_init")
    End Sub

    Sub xtrace_header()
		Dim Msg As String
		Msg = AppName & " V" & AppVer & vbCrLf &
		      "Timestamp = " & DateTime.Now & vbCrLf &
			  "AppRoot   = " & AppRoot & vbCrLf &
			  "Temp      = " & Temp & vbCrLf &
			  "Log level to con     = " & CTrace.ToString & vbCrLf &
			  "Log level to logfile = " & LTrace.ToString & vbCrLf 
		ModFileSystem.WriteTxtToFile(LogFile, Msg, True, 1002, "Failed to initialize the log file", HintList(0), WarnIfLogfileInUse, False)
        LogStatus = 2
    End Sub

    '==== xtrace ==========================================================================
    Sub xtrace_root(Msg As String, TV As Integer)
        Dim Nr As Int16
        Dim Tab As String = ""

        ' If subroutines are Not logged then tabbing is also disabeled
        If LTrace >= G_TL_Sub Then
            ' If exiting main or sublevel maint error,
            ' this if makes it more clear
            If SubLevel >= 0 Then Tab = "|"

            For Nr = 1 To SubLevel
                Tab = Tab + "  |"
            Next
        End If

        If TV <= CTrace Then
            Console.Write(Msg & vbCrLf)
        End If

        If TV <= LTrace Then
            If LogStatus < 1 Then
                WriteLogCache(Tab & Msg)
            Else
                ModFileSystem.WriteTxtToFile(LogFile, Tab & Msg & vbCrLf, True, 1002, "Failed to write to the log file", HintList(0), True, False)
            End If
        End If
    End Sub

    Sub xtrace(Msg As String)
        xtrace_root(" " & Msg, 2)
    End Sub

    Sub xtrace(Msg As String, TV As Integer)
        xtrace_root(" " & Msg, TV)
    End Sub

    '---- xtrace_i ----
    Sub xtrace_i(Msg As String)
        xtrace(" * " & Msg)
    End Sub

    Sub xtrace_i(Msg As String, TV As Integer)
        xtrace(" * " & Msg, TV)
    End Sub

    '--- xtrace TimeStamp ----
    Sub xtrace_TimeStamp()
        xtrace_i("Timestamp = " & DateTime.Now)
    End Sub

    '--- xtrace Sub ----
    Sub xtrace_subs(Msg As String)  ' Default trace level
        xtrace_root("->" & Msg & " (" & (SubLevel + 1).ToString & ")", G_TL_Sub)
        SubLevel = SubLevel + 1
    End Sub
    Sub xtrace_subs(Msg As String, TV As Integer)   ' Specific trace level
        xtrace_root("->" & Msg & " (" & (SubLevel + 1).ToString & ")", TV)
        SubLevel = SubLevel + 1
    End Sub

    Sub xtrace_sube(Msg As String)
        SubLevel = SubLevel - 1
        xtrace_root("<-" & Msg & " (" & (SubLevel + 1).ToString & ")", G_TL_Sub)
    End Sub
    Sub xtrace_sube(Msg As String, TV As Integer)
        SubLevel = SubLevel - 1
        xtrace_root("<-" & Msg & " (" & (SubLevel + 1).ToString & ")", TV)
    End Sub

    '==== Write Error =======================================================
    '---- xtrace_err
    Sub xtrace_err(Msg As String)
        ErrorCount = ErrorCount + 1
        xtrace("ERROR: " & Msg, 1)
        ExitProgram = True
        wait(3)
    End Sub
    Sub WriteErr(Msg As String)
        xtrace_err(Msg)
    End Sub
    Sub xtrace_err(Msg() As String)
        ErrorCount = ErrorCount + 1
        Dim LNr As Integer = 0
        For Each Line As String In Msg
            LNr += 1
            If LNr = 1 Then
                xtrace("ERROR: " & Line, 1)
            Else
                xtrace("         " & Line, 1)
            End If
        Next
        ExitProgram = True
        wait(3)
    End Sub

    '---- xtrace_err with hint and dialog ----
    Sub xtrace_Err(ErrNr As Integer,
                   ErrMsg As String,
                   Details() As String,
                   Hint() As String,
                   ShowDialog As Boolean,
                   OSError As String)
        Dim LNr As Integer
        ErrorCount = ErrorCount + 1

        xtrace("ERROR  : " & ErrNr.ToString, 1)
        xtrace("         " & ErrMsg, 1)

        If (Len(Details(0)) > 0) Then
            LNr = 0
            For Each Line As String In Details
                LNr += 1
                If LNr = 1 Then
                    xtrace("Details: " & Line, 1)
                Else
                    xtrace("         " & Line, 1)
                End If
            Next
        End If

        If Len(Hint(0)) > 0 Then
            LNr = 0
            For Each Line As String In Hint
                LNr += 1
                If LNr = 1 Then
                    xtrace("Hint   : " & Line, 1)
                Else
                    xtrace("         " & Line, 1)
                End If
            Next
        End If

        If (Len(OSError) > 0) Then
            xtrace("OSError : " & OSError, 1)
        End If

        ' Create the message Box
        If ShowDialog Then
            Dim DMsg As String = ErrMsg & vbCrLf

            If (Len(Details(0)) > 0) Then
                DMsg = DMsg & vbCrLf
                LNr = 0
                For Each Line As String In Details
                    LNr += 1
                    If LNr = 1 Then
                        DMsg = DMsg & "Details: " & Line & vbCrLf
                    Else
                        DMsg = DMsg & "              " & Line & vbCrLf
                    End If
                Next
            End If

            If Len(Hint(0)) > 0 Then
                DMsg = DMsg & vbCrLf
                LNr = 0
                For Each Line As String In Hint
                    LNr += 1
                    If LNr = 1 Then
                        DMsg = DMsg & "Hint   : " & Line & vbCrLf
                    Else
                        DMsg = DMsg & "            " & Line & vbCrLf
                    End If
                Next
            End If

            MsgBox(DMsg,
                   MsgBoxStyle.Critical,
                   "Error:")
        End If

        ExitProgram = True
        wait(3)
    End Sub


    '---- XTrace Warn
    Sub xtrace_warn(Msg As String)
        WarningCount = WarningCount + 1
        xtrace("Warning: " & Msg, 1)
        wait(1)
    End Sub

    ' Replaces xtrace_warn2 because specifying the trace value is more clear and consistent
    Sub xtrace_warn(Msg() As String, TV As Integer)
        Dim LNr As Integer = 0
        For Each Line As String In Msg
            LNr += 1
            If LNr = 1 Then
                xtrace("Warning: " & Line, 1)
            Else
                xtrace("         " & Line, 1)
            End If
        Next
        wait(1)
    End Sub

    ' Default trace value = 1
    Sub xtrace_warn(Msg() As String)
        xtrace_warn(Msg, 1)
    End Sub

    'Move to Form1
    'Public Sub WriteInfo(Msg)
    '    Form1.TextBoxInfo.AppendText(Msg & vbCrLf)
    '    xtrace(Msg)
    'End Sub

    '=================================================================

    Dim LogCache As New List(Of String)

    Sub WriteLogCache(Msg)
        LogCache.Add(Msg)
        If Debug Then Console.WriteLine(Msg)    ' Show in the console what is not yet written to the log file
    End Sub

    Sub FlushLogCashe()
        Dim Msg As String
        ModFileSystem.WriteTxtToFile(LogFile, "=== Log Cache ===" & vbCrLf, True, 1010, "Failed to write to the log file", HintList(2), True, False)
        For Each Msg In LogCache
            ModFileSystem.WriteTxtToFile(LogFile, Msg & vbCrLf, True, 1011, "Failed to write to the log file", HintList(2), True, False)
        Next
        ModFileSystem.WriteTxtToFile(LogFile, "=== End Cache ===" & vbCrLf, True, 1010, "Failed to write to the log file", HintList(2), True, False)
    End Sub

    '=================================================================
    ' Debug early trace to console

    Sub dtrace(Msg As String)
        If Debug Then Console.WriteLine(" " & Msg)

    End Sub

    Sub dtrace_i(Msg As String)
        If Debug Then Console.WriteLine("  - " & Msg)
    End Sub

End Module
