Imports System.Net

Module Web
    Public DownloadMethod As String = "VBWebClient"

    '---- Get Url With Data Array as input ----------------------------------------------
    Sub GetUrlD(DData() As String)
        xtrace_subs("GetUrlD")

        Dim Url As String = DData(0)
        Dim Target As String = DData(1)
        Dim FName As String = DData(2)
        xtrace_i("FName = " & FName)

        ' Set the target path
        Dim FPath = DepoPath & "\" & Target & "\" & FName
        GetURL(Url, FPath)

        xtrace_sube("GetUrlD")
    End Sub

    '---- Select the download method ----------------------------------------------------
    Sub GetURL(URL As String, FPath As String)
        xtrace_subs("GetUrl")

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
            Dim MyStartTime As Date = DateTime.Now
            Form1.SetStatus("Download " & FPath)

            xtrace_i("DownloadMethod = " & DownloadMethod)

            If DownloadMethod = "VBWebClient" Then
                GetUrl2(URL, FPath)
            ElseIf DownloadMethod.ToUpper = "CURL" Then
                GetUrlCurl(URL, FPath)
            ElseIf DownloadMethod = "VBDownloadFile" Then
                GetUrl4(URL, FPath)
            Else
                xtrace_warn("Invalid DownloadMethod")
            End If

            Dim DLTimeSpan As TimeSpan = DateTime.Now - MyStartTime
            xtrace("Download time = " & DLTimeSpan.ToString, 1)

            Form1.SetStatus("Download finished")
        End If

        xtrace_sube("GetUrl")
    End Sub

    '---- Get URL Uses the VB WebClient -------------------------------------------------
    Sub GetUrl2(Url As String, FPath As String)
        xtrace_subs("GetUrl2")

        Try
            xtrace_i("DownloadData = " & Url & " -> " & FPath)
            Dim wclient As WebClient = New WebClient()
            wclient.DownloadFile(Url, FPath)
        Catch ex As Exception
            xtrace("   " & ex.Message)
        End Try

        xtrace_sube("GetUrl2")
    End Sub

    '---- Get URL Uses VB DownloadFile
    Sub GetUrl4(Url As String, FPath As String)
        xtrace_subs("GetUrl4")

        Try
            xtrace_i("DownloadData = " & Url & " -> " & FPath)
            My.Computer.Network.DownloadFile(Url, FPath)
        Catch ex As Exception
            xtrace("   " & ex.Message)
        End Try

        xtrace_sube("GetUrl4")
    End Sub

    '---- Get URL Uses curl
    Sub GetUrlCurl(Url As String, FPath As String)
        xtrace_subs("GetUrlCurl")
        Dim CurlExe As String = "curl"
        Dim CurlExe2 As String = BinLib & "\CURL.EXE"
        Dim CurlMode As String = "win"

        If My.Computer.FileSystem.FileExists(CurlExe2) Then
            xtrace_i("CurlExe2 exists")
            CurlExe = CurlExe2
            CurlMode = "Enhanced"
        End If

        Try
            Form1.SetStatus("Downloading...")
            Dim Cmd As String
            'md = "curl -v --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
            'md = "curl -v --user ""anonymous:"" --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
            'md = "curl -v --get --user ""anonymous:"" --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
            Cmd = CurlExe & " --get --ssl --user ""anonymous:"" --output """ & FPath & """ """ & Url & """ >>" & LogFile & " 2>>&1"
            xtrace_i("Cmd = " & Cmd)

            Dim Proc As New Process()
            Dim ProcStartInfo As New ProcessStartInfo("cmd.exe", "/c " & Cmd)
            ProcStartInfo.WindowStyle = ProcessWindowStyle.Minimized
            Proc.StartInfo = ProcStartInfo
            Proc.Start()
            Proc.WaitForExit()
            Form1.SetStatus("Download Finished.")
        Catch ex As Exception
            xtrace("   " & ex.Message)
            Form1.SetStatus("Download Failed.")
        End Try

        xtrace_sube("GetUrlCurl")
    End Sub

End Module
