Imports System.Net
Imports System.Reflection

Module InstallationWizzardStart
    Public WizzardName As String
    Public WizzardExists As Boolean

    Public ContentInit As String
    Public ContentAIExtr As String  ' Application Installation Extract
    Public Downloads(10) As String
    'Public DownloadFileNames(10) As String
    Public DownLoadIndex As Integer

    Sub InstallationWizzard()
        xtrace_subs("InstallationWizzard")
        WizzardName = "W_" & Form1.ComboBoxInstName.Text
        xtrace_i("Wizzard Name = " & WizzardName)
        WizzardExists = False

        xtrace_i("Reset content")
        ContentInit = ""
        ContentAIExtr = ""
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
                    BatWDefaults(DName, DVal)

                    If DName = "ContentInitLine" Then
                        xtrace_i("Add InitLine: " & DVal)
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

    Function DownloadData(DLine As String) As String()
        Dim DData() As String
        Dim URL As String
        Dim Target As String
        Dim Name As String
        Dim P1 As Integer

        DData = DLine.Split(";")
        URL = DData(0)
        Target = DData(1)

        P1 = InStrRev(URL, "/")
        'xtrace_i("P1 = " & P1.ToString)
        Name = Mid(URL, P1 + 1)

        xtrace_i("DownloadData = " & URL & "," & Target & "," & Name)
        DownloadData = {URL, Target, Name}
    End Function

    '---- Download ----------------------------------------------------------------------
    Sub GetUrl(DData() As String)
        xtrace_subs("GetUrl")

        Dim Url As String = DData(0)
        Dim Target As String = DData(1)
        Dim FName As String = DData(2)
        Dim wclient As WebClient = New WebClient()

        xtrace_i("FName = " & FName)

        ' Set the target path
        Dim FPath = DepoPath & "\" & Target & "\" & FName

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

    'Sub unzip(ZipFile As String, OutputD As String)
    '    Dim sc As New Shell32.Shell()
    '    Dim output As Shell32.Folder = sc.NameSpace(OutputD)
    '    Dim input As Shell32.Folder = sc.NameSpace(ZipFile)
    '    output.CopyHere(input.Items, 4)
    'End Sub

End Module
