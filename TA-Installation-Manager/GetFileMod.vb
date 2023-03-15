Module GetFileMod
    Dim UseInstLibExe As Boolean
    Dim UseBinLib As Boolean
    Dim UseUrl As Boolean
    Dim GetFileURL As String
    Dim BinLib As String = AppRoot & "\BinLib"
    Sub GetFile(FileName As String, Target As String)
        xtrace_subs("GetFile " & FileName)
        If FileExists(FileName, Target) Then GoTo QUIT

        Dim DLine As String = GetFileDefaults(FileName)
        Dim GFData() As String = DLine.Split("|")
        Dim Field As String
        For Each Field In GFData
            If Field = "InstLibExe" Then
                'UseInstLibExe = True
                If FileInInstLibExe(FileName, Target) Then GoTo QUIT

            ElseIf Field = "TemplateExe" Then
                If FileInTemplateExe(FileName, Target) Then GoTo QUIT

            ElseIf Field = "BinLib" Then
                'UseBinLib = True
                If FileInBinLib(FileName, Target) Then GoTo QUIT

            ElseIf Field = "TemplateInst" Then
                If FileInTemplateInst(FileName, Target) Then GoTo QUIT

            ElseIf Field = "URL" Then
                    UseUrl = True

                ElseIf Field = "<URL>" Then
                    xtrace_i("URL not available yet")

                ElseIf InStr(Field, "/") > 0 Then
                    GetFileURL = Field
                Else
                    xtrace_warn("Unknown field " & Field)
            End If

            If UseInstLibExe Then

            End If
        Next
QUIT:
        xtrace_sube("GetFile")
    End Sub
    '----  -------------------------------------------
    Function GetFileDefaults(FileName As String) As String
        xtrace_subs("GetFileDefaults")

        Dim Line As String
        Dim P1, P2 As Integer
        Dim DName, DVal As String
        Dim Result = ""
        If Not WizzardInitialized Then InitWizzard()

        xtrace_i("Read GetFileData")
        For Each Line In GetFileData
            If Left(Line, 1) = "#" Then Continue For
            If Len(Line) < 2 Then Continue For

            P1 = InStr(Line, "=")
            DName = Left(Line, P1 - 1)
            DVal = Mid(Line, P1 + 1)
            xtrace("Default " & DName & "=" & DVal, 3)

            If DName = FileName Then
                Result = DVal
            End If
        Next

        xtrace_i("Result = '" & Result & "'")
        GetFileDefaults = Result
        xtrace_sube("GetFileDefaults")
    End Function
    '----  -------------------------------------------
    Sub GetFileElse()

    End Sub
    '----  -------------------------------------------
    Function FileExists(FileName As String, Target As String)
        Dim Exists As Boolean
        If ReDownload Then
            xtrace_i("Redownload = True")
            Exists = False
        ElseIf My.Computer.FileSystem.FileExists(Target & "\" & FileName) Then
            xtrace_i("Target exists")
            Exists = True
        Else
            xtrace_i("Target does not exist")
            Exists = False
        End If
        xtrace_i("IfFileExists=" & Exists.ToString)
        Return Exists
    End Function
    '----  -------------------------------------------
    Function FileInInstLibExe(FileName As String, Target As String) As Boolean
        Dim SLoc As String = TA_InstLib_InstExe & "\" & FileName
        Dim Result As Boolean = False
        xtrace_i("Try: " & SLoc)

        If My.Computer.FileSystem.FileExists(SLoc) Then
            Try
                xtrace_i("Copy " & SLoc & " -> " & Target & "\" & FileName)
                My.Computer.FileSystem.CopyFile(SLoc, Target & "\" & FileName)
                Result = True
                xtrace_i("Success")
            Catch ex As Exception
                xtrace(ex.Message)
            End Try
        Else
            xtrace_i("Does not exist")
        End If

        FileInInstLibExe = Result
    End Function
    '----
    Function FileInTemplateExe(FileName, Target) As Boolean
        Dim SLoc As String = TA_Template_InstExe & "\" & FileName
        Dim Result As Boolean = False
        xtrace_i("Try: " & SLoc)

        If My.Computer.FileSystem.FileExists(SLoc) Then
            Try
                My.Computer.FileSystem.CopyFile(SLoc, Target & "\" & FileName)
                Result = True
                xtrace_i("Success")
            Catch ex As Exception
                xtrace(ex.Message)
            End Try
        Else
            xtrace_i("Does not exist")
        End If

        FileInTemplateExe = Result
    End Function
    '----  -------------------------------------------
    Function FileInBinLib(FileName As String, Target As String) As Boolean
        Dim SLoc As String = BinLib & "\" & FileName
        Dim Result As Boolean = False
        xtrace_i("Try: " & SLoc)

        If Not My.Computer.FileSystem.DirectoryExists(BinLib) Then
            xtrace_i("BinLib does not exist")
        ElseIf My.Computer.FileSystem.FileExists(SLoc) Then
            Try
                My.Computer.FileSystem.CopyFile(SLoc, Target & "\" & FileName)
                Result = True
                xtrace_i("Success")
            Catch ex As Exception
                xtrace(ex.Message)
            End Try
        Else
            xtrace_i("File does not exist")
        End If

        FileInBinLib = Result
    End Function
    '----  -------------------------------------------
    Function FileInTemplateInst(FileName As String, Target As String)
        Dim SLoc As String = TA_Template_Inst & "\" & FileName
        Dim Result As Boolean = False
        xtrace_i("Try: " & SLoc)

        If My.Computer.FileSystem.FileExists(SLoc) Then
            Try
                My.Computer.FileSystem.CopyFile(SLoc, Target & "\" & FileName)
                Result = True
                xtrace_i("Success")
            Catch ex As Exception
                xtrace(ex.Message)
            End Try
        Else
            xtrace_i("File does not exist")
        End If

        FileInTemplateInst = Result
    End Function
    '----  -------------------------------------------
    Function GetFileFromTheWeb(FileName As String, Target As String) As Boolean
        xtrace_i("Try: " & GetFileURL)
    End Function

End Module
