﻿Module CommandLineArg
    'Has Async higer priority as the defaults
    Sub Read_Command_Line_Arg()
        xtrace_subs("Read_Command_Line_Arg")

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
                xtrace_i("DDA:" & SwName)

                '---- Double-dash Assignment
                P1 = InStr(SwName, "=")
                If P1 > 0 Then
                    Name = Left(SwName, P1 - 1)
                    ValS = Mid(SwName, P1 + 1)
                    xtrace_i("Name = " & Name & ", Val = " & ValS)

                    If Name = "AutoRun" Then
                        AutoRun = ValS
                        xtrace_i("Set AutoRun = '" & AutoRun & "'")
                    End If

                    If Name = "DownloadMethod" Then
                        DownloadMethod = ValS
                        xtrace_i("Set DownloadMethod = '" & DownloadMethod & "'")
                    End If

                    If Name = "??" Then

                    End If

                    Continue For
                End If

                '---- Double-dash No Assignment
                If SwName = "help" Then
                    ShowHelp()
                    ExitProgram = True
                End If

                If SwName = "xhelp" Then
                    ShowXHelp()
                    ExitProgram = True
                End If

                If SwName = "ip" Then
                    IncreasePerformance = True
                    xtrace_i("Set IncreasePerformance = " & IncreasePerformance.ToString)
                    xtrace("   Logging hereafter is limited to trace level 1!")
                    SharedDefaultsTraceValue = 3
                    LTrace = 1
                End If

                If SwName = "cvl" Then
                    xtrace_i("Set CVL = True")
                    CVL = True
                End If

                If SwName = "rr" Then
                    RunResult = True
                    xtrace_i("Set RunResult = True")
                End If

                If SwName = "LicTraceVisible" Then
                        LicC.LicTraceLevel = 2
                        xtrace_i(" Set LicTraceLevel = " & LicC.LicTraceLevel.ToString)
                    End If

                    If SwName = "dw" Then
                        Disable_Wizard = True
                        xtrace_i("Disable Wizard = " & Disable_Wizard.ToString)
                    End If

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
                    xtrace_i("SDA:" & SwName & "," & SwString)

                    If SwName = "v" Then
                        Verbose = True
                        xtrace_i("Set verbose = " & Verbose.ToString)
                    End If

                    If SwName = "h" Then
                        ShowHelp()
                        ExitProgram = True
                    End If
                End While

                Continue For
            End If

            '---- Else (No dashes)
            P1 = InStr(argument, "=")
            If P1 > 0 Then
                Name = Left(argument, P1 - 1)
                ValS = Mid(argument, P1 + 1)
                xtrace_i("NDA:" & argument)

                If Name = "??" Then

                End If
            End If

            '---- Else (No dashes, No Assign)
            ' Wait <Ini>
            ' for compatibility with the older wait command
            If argument = "/?" Then
                ShowHelp()
                ExitProgram = True
                Continue For
            End If

        Next
        xtrace_sube("Read_Command_Line_Arg")
    End Sub

End Module
