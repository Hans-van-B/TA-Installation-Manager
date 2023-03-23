Imports System.Net
Imports System.Reflection

Module InstallationWizzardStart
    Public WizzardName As String
    Public WizzardExists As Boolean

    Public ContentInit As String = ""
    Public ContentTestIfExist As String = ""
    Public ContentAIExtr As String = ""  ' Application Installation Extract
    Public ContentInstCmd As String = "" ' Installation Command
    Public ContentReadme As String = ""
    Public Downloads(10) As String
    'Public DownloadFileNames(10) As String
    Public DownLoadIndex As Integer
    Public WizIniFile As String
    Public GetFileData As New Stack
    Public WizzardInitialized As Boolean = False

    Sub InstallationWizzard()
        xtrace_subs("InstallationWizzard")

        If WizzardInitialized Then
            xtrace_i("Don't initialize again")
        Else
            InitWizzard()
        End If
        AddReadme()

        xtrace_sube("InstallationWizzard")
    End Sub

    Sub AddReadme()

    End Sub

    '---- Init Wizzard (Read Defaults) --------------------------------------------------
    ' Allows the file to be read from elsewhere
    ' The GetFile Data is now pushed on a stack GetFileData so it can be accessed more quickly
    Function AssignWizIniFile() As Boolean
        xtrace_subs("AssignWizIniFile")

        Dim Result As Boolean
        Dim WIniFile1 As String = AppRoot & "\" & AppName & "_W.ini"
        Dim WIniFile2 As String = AppRoot & "\Data\" & AppName & "_W.ini"

        If My.Computer.FileSystem.FileExists(WIniFile1) Then
            WizIniFile = WIniFile1
            Result = True
        ElseIf My.Computer.FileSystem.FileExists(WIniFile2) Then
            WizIniFile = WIniFile2
            Result = True
        Else
            Form1.WriteInfo("Failed to read:")
            Form1.WriteInfo("   " & WIniFile1)
            Form1.WriteInfo("Or " & WIniFile2)
            WizIniFile = ""
            Result = False
        End If
        AssignWizIniFile = Result
        xtrace_sube("AssignWizIniFile")
    End Function
    Sub InitWizzard()
        xtrace_subs("InitWizzard (Read defaults)")

        If WizIniFile Is Nothing Then
            If Not AssignWizIniFile() Then GoTo QUIT
        End If

        '---- Initialize
        WizzardName = "W_" & Form1.ComboBoxInstName.Text
        xtrace_i("Wizzard Name = " & WizzardName)
        WizzardExists = False

        '---- Start Wizzard Init
        xtrace_i("Reset content")
        ContentInit = ""
        ContentAIExtr = ""
        ContentInstCmd = ""
        ContentReadme = ""
        DownLoadIndex = -1

        '---- Start
        Dim ReadFile
        Form1.WriteInfo("Read Defaults " & WizIniFile)
        ReadFile = My.Computer.FileSystem.OpenTextFileReader(WizIniFile)

        Dim Line As String
        Dim Group As String = ""
        Dim P1, P2 As Integer
        Dim DName, DVal As String
        GetFileData.Clear()

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

                If Group.ToUpper = WizzardName.ToUpper Then
                    If Not WizzardExists Then
                        xtrace_i("Group Matches")   ' Only log once
                        Form1.SetStatus("Wizard found")
                    End If
                    WizzardExists = True

                    If DName = "DownloadURL" Then
                        DownLoadIndex += 1
                        xtrace_i("Add " & DownLoadIndex.ToString & ";" & DVal)
                        Downloads(DownLoadIndex) = DVal
                    End If

                    SharedDefaults(DName, DVal)
                    BatWDefaults(DName, DVal)

                    If DName = "ContentInitLine" Then
                        xtrace_i("Add Init Line: " & DVal)
                        ContentInit = ContentInit & DVal & vbCrLf
                    End If

                    If DName = "TestIfExist" Then
                        xtrace_i("Set TestIfExist = " & DVal)
                        ContentTestIfExist = DVal
                    End If

                    If DName = "Readme" Then
                        Dim RLine As String
                        If Left(DVal, 4) = "URL;" Then
                            Dim Nr As Integer = Val(Mid(DVal, 5))
                            Dim RData() As String = DownloadData(Downloads(Nr))
                            RLine = "Source: " & RData(0)
                        Else
                            RLine = DVal
                        End If
                        xtrace_i("Add Readme Line: " & RLine)
                        ContentReadme = ContentReadme & RLine & vbCrLf
                    End If

                    If DName = "InstCmd" Then
                        xtrace_i("Add Installation Command: " & DVal)
                        ContentInstCmd = DVal
                    End If


                End If

                If Group = "GETFILE" Then
                    xtrace_i("Push")
                    GetFileData.Push(Line)
                End If

            Catch ex As Exception

            End Try
        End While
        ReadFile.Dispose()
        WizzardInitialized = True
        xtrace("GetFileData Length = " & GetFileData.Count.ToString)

QUIT:
        xtrace_sube("InitWizzard")
    End Sub

    '==== General Purpose routines ======================================================

    Function DownloadData(DLine As String) As String()
        xtrace_subs("DownloadData")

        Dim DData() As String
        Dim URL As String
        Dim Target As String
        Dim Name As String
        Dim P1 As Integer

        DData = DLine.Split(";")
        URL = DData(0)
        Target = DData(1)

        P1 = InStrRev(URL, "/")
        xtrace_i("P1 = " & P1.ToString)
        Name = Mid(URL, P1 + 1)

        xtrace_i("DownloadData = " & URL & " -> " & Target & " (" & Name & ")")
        DownloadData = {URL, Target, Name}

        xtrace_sube("DownloadData")
    End Function



End Module
