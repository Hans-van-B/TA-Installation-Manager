Imports System.IO
Imports System.Net
Imports System.Text


Module InstallationWizzardBat
    Sub AddWebContent()
        xtrace_subs("AddWebContent")
        Dim ReadFile
        Form1.WriteInfo("Read Defaults " & Inifile)
        ReadFile = My.Computer.FileSystem.OpenTextFileReader(Inifile)

        Dim Line As String
        Dim Group As String = ""
        Dim P1, P2 As Integer
        Dim DName, DVal As String
        Dim Target As String = ""

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

                If Group = "W_" & InstName Then
                    xtrace_i("Group Matches")

                    If DName = "Target" Then
                        Target = DVal
                        xtrace_i("Target = " & Target)
                    End If

                    If DName = "SourceURL" Then
                        GetUrl(DVal, Target, 0)
                    End If

                End If

            Catch ex As Exception

            End Try
        End While

        xtrace_sube("AddWebContent")
    End Sub

    Public DownloadFileNames(10) As String
    Sub GetUrl(Url As String, Target As String, Index As Integer)
        xtrace_subs("GetUrl")

        Dim wclient As WebClient = New WebClient()

        Dim P1 As Integer = InStrRev(Url, "/")
        xtrace_i("P1 = " & P1.ToString)
        Dim Name = Mid(Url, P1 + 1)
        xtrace_i("Name = " & Name)

        ' Store the name for later unpacking
        DownloadFileNames(Index) = Name

        Dim FPath = DepoPath & "\" & Target & "\" & Name

        xtrace_i(Url & " -> " & FPath)
        Try
            wclient.DownloadFile(Url, FPath)
        Catch ex As Exception
            xtrace_i(ex.Message)
        End Try

        xtrace_sube("GetUrl")
    End Sub


End Module
