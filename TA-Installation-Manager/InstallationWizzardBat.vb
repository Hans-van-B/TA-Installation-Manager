'Imports System.IO
'Imports System.Net
'Imports System.Text


Module InstallationWizzardBat
    Sub AddWebContent()
        xtrace_subs("AddWebContent")

        If Not (DownLoadIndex = -1) Then
            Dim Nr As Integer
            Dim DLine As String
            Dim DData() As String
            Dim URL As String
            Dim Target As String
            For Nr = 0 To DownLoadIndex
                DLine = Downloads(Nr)
                DData = DLine.Split(";")
                URL = DData(0)
                Target = DData(1)
                GetUrl(URL, Target, Nr)
            Next
        End If

        xtrace_sube("AddWebContent")
    End Sub



End Module
