'Imports System.IO
'Imports System.Net
'Imports System.Text

' Read defaults that interprets towards language dependent output
Module InstallationWizzardBat

    Sub BatWDefaults(DName As String, DVal As String)
        Dim ALine As String


        If DName = "InstTarget" Then
            ALine = "set InstTarget=" & DVal
            xtrace_i("Add: " & ALine)
            ContentInit = ContentInit & ALine
        End If

        If DName = "Extract" Then
            Dim EData() As String = DVal.Split(";")
            Dim Index As Integer = Val(EData(1))
            Dim DData() As String = DownloadData(Downloads(Index))
            Dim ArchName As String = DData(2)
            xtrace_i("Add Extract " & ArchName)

            If EData(0) = "INST" Then
                ContentAIExtr = "set INST1=%INSTTMP%\INST1" & vbCrLf &
                    "if not exist '%INST1%' md '%INST1%'" & vbCrLf

                ' Add extract command
                ContentAIExtr = ContentAIExtr & "'%InstLibExe%\unzip' -od %INST1% '%ARCHIVES%\" & ArchName & "'"

            ElseIf EData(0) = "InstTarget" Then
                ContentAIExtr = "if not exist '%InstTarget%' md '%InstTarget%'" & vbCrLf

                ' Add extract command
                ContentAIExtr = ContentAIExtr & "'%InstLibExe%\unzip' -od '%InstTarget%' '%ARCHIVES%\" & ArchName & "'"
            End If

        End If

    End Sub

    Sub AddWebContent()
        xtrace_subs("AddWebContent")

        If Not (DownLoadIndex = -1) Then
            Dim Nr As Integer
            Dim DData() As String
            For Nr = 0 To DownLoadIndex
                DData = DownloadData(Downloads(Nr))

                GetUrl(DData)
            Next
        End If

        xtrace_sube("AddWebContent")
    End Sub


End Module
