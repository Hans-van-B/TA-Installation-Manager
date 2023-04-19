Imports System.Net
Imports System.Reflection

Module InstallationWizardStart
    Public WizardName As String
    Public WizardExists As Boolean

    Public ContentInit As String = ""
    Public ContentTestIfExist As String = ""
    Public ContentAIExtr As String = ""  ' Application Installation Extract
    Public ContentInstCmd As String = "" ' Installation Command
    Public DepoSubDir As String
    Public ContentReadme As String = ""
    Public ContentAutoStart As String = ""
    Public ContentMsiDeinstall As String = ""
    Public Downloads(10) As String
    'Public DownloadFileNames(10) As String
    Public DownLoadIndex As Integer
    Public WizIniFile As String
    Public GetFileData As New Stack
    Public WizardInitialized As Boolean = False

    Sub InstallationWizard()
        xtrace_subs("InstallationWizard")

        If Disable_Wizard Then
            xtrace_i("Wizard Disabled")
        ElseIf WizardInitialized Then
            xtrace_i("Don't initialize again")
        Else
            InitWizard()
        End If
        AddReadme()

        xtrace_sube("InstallationWizard")
    End Sub

    Sub AddReadme()

    End Sub

    '---- Init Wizard (Read Defaults) --------------------------------------------------
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
    Sub InitWizard()
        xtrace_subs("InitWizard (Read defaults)")

        If WizIniFile Is Nothing Then
            If Not AssignWizIniFile() Then GoTo QUIT
        End If

        '---- Initialize
        WizardName = "W_" & Form1.ComboBoxInstName.Text
        xtrace_i("Wizard Name = " & WizardName)
        WizardExists = False

        '---- Start Wizard Init
        xtrace_i("Reset content")
        DepoSubDir = ""
        ContentInit = ""
        ContentAIExtr = ""
        ContentInstCmd = ""
        ContentReadme = ""
        DownLoadIndex = -1
        ContentMsiDeinstall = ""

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

                    If Group.ToUpper = Form1.ComboBoxInstName.Text.ToUpper Then
                        Form1.WriteInfoWarning("Found matching wizard group name " & Group & " without preceeding 'W_'")
                    ElseIf Left(Group, 2).ToUpper <> "W_" Then
                        Form1.WriteInfoWarning("Found wizard group name " & Group & " without preceeding 'W_'")
                    End If

                    Continue While
                End If

                '---- Read Defaults
                P1 = InStr(Line, "=")
                DName = Left(Line, P1 - 1)
                DVal = Mid(Line, P1 + 1)
                xtrace("Default " & DName & "=" & DVal)

                If (Group.ToUpper = WizardName.ToUpper) And (Not Disable_Wizard) Then
                    If Not WizardExists Then
                        xtrace_i("Group Matches")   ' Only log once
                        Form1.SetStatus("Wizard found")
                    End If
                    WizardExists = True

                    If DName = "DownloadURL" Then
                        DownLoadIndex += 1
                        xtrace_i("Add " & DownLoadIndex.ToString & ";" & DVal)
                        Downloads(DownLoadIndex) = DVal
                    End If

                    SharedDefaults(DName, DVal)

                    BatWDefaults(DName, DVal)

                    If DName = "DepoSubDir" Then
                        DepoSubDir = DVal
                        xtrace_i("Set DepoSubDir = " & DepoSubDir)
                    End If

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

                    If DName = "AutoStart" Then
                        ContentAutoStart = DVal
                    End If

                    If DName = "MsiDeinstall" Then
                        ContentMsiDeinstall = "MsiExec.exe /X" & DVal & " /q"
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
        WizardInitialized = True

        xtrace_i("Wizard found = " & WizardExists.ToString)
        xtrace("GetFileData Length = " & GetFileData.Count.ToString)

QUIT:
        xtrace_sube("InitWizard")
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
        If DData.Length < 2 Then
            MsgBox("Warning: Line " & DLine & vbCrLf & "Missing target field", MsgBoxStyle.Critical, "Missing target field")
            GoTo QUIT
        End If
        URL = DData(0)
        Target = DData(1)

        P1 = InStrRev(URL, "/")
        xtrace_i("P1 = " & P1.ToString)
        Name = Mid(URL, P1 + 1)

        xtrace_i("DownloadData = " & URL & " -> " & Target & " (" & Name & ")")
        DownloadData = {URL, Target, Name}
QUIT:
        xtrace_sube("DownloadData")
    End Function



End Module
