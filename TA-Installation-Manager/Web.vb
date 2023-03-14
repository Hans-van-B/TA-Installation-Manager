Imports System.Net

Module Web
    Sub GetUrl2(Url As String, FPath As String)
        xtrace_subs("GetUrl2")

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
            Try
                xtrace_i("DownloadData = " & Url & " -> " & FPath)
                Dim wclient As WebClient = New WebClient()
                wclient.DownloadFile(Url, FPath)
            Catch ex As Exception
                xtrace("   " & ex.Message)
            End Try
        End If

        xtrace_sube("GetUrl2")
    End Sub

    Sub GetUrl3(Url As String, FPath As String)
        xtrace_subs("GetUrl3")

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
            Try
                Dim Cmd As String
                'md = "curl -v --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
                'md = "curl -v --user ""anonymous:"" --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
                'md = "curl -v --get --user ""anonymous:"" --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
                Cmd = "curl -v --get --ssl --user ""anonymous:"" --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
                xtrace_i("Cmd = " & Cmd)

                Dim Proc As New Process()
                Dim ProcStartInfo As New ProcessStartInfo("cmd.exe", "/c " & Cmd)
                Proc.StartInfo = ProcStartInfo
                Proc.Start()
                Proc.WaitForExit()
            Catch ex As Exception
                xtrace("   " & ex.Message)
            End Try
        End If

        xtrace_sube("GetUrl3")
    End Sub

    Sub GetUrl4(Url As String, FPath As String)
        xtrace_subs("GetUrl4")
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
            Try
                xtrace_i("DownloadData = " & Url & " -> " & FPath)
                My.Computer.Network.DownloadFile(Url, FPath)
            Catch ex As Exception
                xtrace("   " & ex.Message)
            End Try
        End If
        xtrace_sube("GetUrl4")
    End Sub

End Module
