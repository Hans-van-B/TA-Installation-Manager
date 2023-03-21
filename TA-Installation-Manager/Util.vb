﻿Module Util
    '---- Wait ----------------------------------------------------------------
    Public Sub wait(ByVal interval As Integer)
        xtrace_i("Wait " & interval.ToString)
        If IncreasePerformance Then
            interval = interval * 100
        Else
            interval = interval * 1000
        End If

        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    '---- Exit Program --------------------------------------------------------
    Sub exit_program()
        xtrace_subs("exit_program")

        If (ErrorCount > 0) Or (WarningCount > 0) Then
            xtrace("Found " & ErrorCount.ToString & " Errors", 2)
            xtrace("Found " & WarningCount.ToString & " Warnings", 2)
        Else
            xtrace("Exit Ok", 1)
        End If
        Dim RunTimeSpan As TimeSpan = DateTime.Now - AppStartTime
        xtrace("Elapsed time = " & RunTimeSpan.ToString, 1)

        xtrace("")
        xtrace("================")
        xtrace("  Exit Program  ")
        xtrace("================")

        ExitProgram = True
        xtrace_TimeStamp()

        If CVL Then CreateValidateLogs()

        Application.Exit()
        xtrace_sube("exit_program")
    End Sub

    Sub Do_Events()
        Application.DoEvents()
    End Sub

    Function StringToBool(Val As String) As Boolean
        Dim Result As Boolean
        Dim Valid As Boolean = False
        Dim Test As Integer
        Val = Val.ToUpper

        Test = Array.IndexOf({"TRUE", "YES", "1"}, Val)
        If Test >= 0 Then
            Result = True
            Valid = True
        End If

        Test = Array.IndexOf({"FALSE", "NO", "0", "-1"}, Val)
        If Test >= 0 Then
            Result = False
            Valid = True
        End If

        If Not Valid Then
            xtrace_warn("The boolean value given in invalid: " & Val)
            Result = False
        End If

        xtrace_i("StringToBool returns " & Result.ToString)
        StringToBool = Result
    End Function
End Module
