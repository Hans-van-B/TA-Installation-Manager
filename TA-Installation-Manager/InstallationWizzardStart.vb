Imports System.Net

Module InstallationWizzardStart
    Public WizzardName As String
    Public WizzardExists As Boolean

    Public ContentInit As String
    Public Downloads(10) As String
    Public DownLoadIndex As Integer

    Sub InstallationWizzard()
        xtrace_subs("InstallationWizzard")
        WizzardName = "W_" & Form1.ComboBoxInstName.Text
        xtrace_i("Wizzard Name = " & WizzardName)
        WizzardExists = False

        xtrace_i("Reset content")
        ContentInit = ""
        DownLoadIndex = -1

        InitWizzard()

        xtrace_sube("InstallationWizzard")
    End Sub

    '---- Init Wizzard (Read Defaults) --------------------------------------------------
    Sub InitWizzard()
        xtrace_subs("InitWizzard")

        Dim WIniFile1 As String = AppRoot & "\" & AppName & "_W.ini"
        Dim WIniFile2 As String = AppRoot & "\Data\" & AppName & "_W.ini"
        Dim WIniFile As String

        If My.Computer.FileSystem.FileExists(WIniFile1) Then
            WIniFile = WIniFile1

        ElseIf My.Computer.FileSystem.FileExists(WIniFile2) Then
            WIniFile = WIniFile2

        Else
            Form1.WriteInfo("Failed to read:")
            Form1.WriteInfo("   " & WIniFile1)
            Form1.WriteInfo("Or " & WIniFile2)
            GoTo QUIT
        End If

        Dim ReadFile
        Form1.WriteInfo("Read Defaults " & WIniFile)
        ReadFile = My.Computer.FileSystem.OpenTextFileReader(WIniFile)

        Dim Line As String
        Dim Group As String = ""
        Dim P1, P2 As Integer
        Dim DName, DVal As String

        While Not ReadFile.EndOfStream
            Try
                Line = ReadFile.ReadLine()
                If Left(Line, 1) = "#" Then Continue While
                If Len(Line) < 2 Then Continue While

                '---- Read Group ----------
                P1 = InStr(Line, "[")
                P2 = InStr(Line, "]")

                If P1 = 1 And P2 > 2 Then
                    Group = Mid(Line, 2, P2 - 2)
                    xtrace("Group = " & Group)
                    Continue While
                End If

                '---- Read Defaults
                P1 = InStr(Line, "=")
                DName = Left(Line, P1 - 1)
                DVal = Mid(Line, P1 + 1)
                xtrace("Default " & DName & "=" & DVal)

                If Group = WizzardName Then
                    If Not WizzardExists Then xtrace_i("Group Matches")
                    WizzardExists = True

                    If DName = "DownloadURL" Then
                        DownLoadIndex += 1
                        xtrace_i("Add " & DownLoadIndex.ToString & ";" & DVal)
                        Downloads(DownLoadIndex) = DVal
                    End If

                    SharedDefaults(DName, DVal)

                    If DName = "ContentInitLine" Then
                        ContentInit = ContentInit & DVal & vbCrLf
                    End If

                End If

            Catch ex As Exception

            End Try
        End While
        ReadFile.Dispose()

QUIT:
        xtrace_sube("InitWizzard")
    End Sub

    '==== General Purpose routines ======================================================

    '---- Download ----------------------------------------------------------------------
    Public DownloadFileNames(10) As String
    Sub GetUrl(Url As String, Target As String, Index As Integer)
        xtrace_subs("GetUrl")

        Dim wclient As WebClient = New WebClient()

        ' Get Name from URL
        Dim P1 As Integer = InStrRev(Url, "/")
        xtrace_i("P1 = " & P1.ToString)
        Dim Name = Mid(Url, P1 + 1)
        xtrace_i("Name = " & Name)

        ' Store the name for later unpacking
        DownloadFileNames(Index) = Name

        ' Set the target path
        Dim FPath = DepoPath & "\" & Target & "\" & Name

        Dim GetFile As Boolean
        If ReDownload Then
            xtrace_i("Redownload = True")
            GetFile = True
        ElseIf My.Computer.FileSystem.FileExists(FPath) Then
            xtrace_i("Target exists")
            GetFile = False
        Else
            xtrace_i("Target does not exist")
            GetFile = True
        End If

        If GetFile Then
            xtrace_i(Url & " -> " & FPath)
            Try
                wclient.DownloadFile(Url, FPath)
            Catch ex As Exception
                xtrace_i(ex.Message)
            End Try
        End If

        xtrace_sube("GetUrl")
    End Sub

End Module
