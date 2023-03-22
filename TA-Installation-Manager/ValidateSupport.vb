Imports System.IO
Imports System.Text

Module ValidateSupport
    Sub CreateValidateLogs()
        xtrace_subs("CreateValidateLogs")

        Dim ValidateEnv As Boolean = True
        Dim vlogf As String
        Dim Subd, Listd, BatchFile As String
        If Environment.GetEnvironmentVariable("validatedir") = "" Then ValidateEnv = False
        vlogf = Environment.GetEnvironmentVariable("logf")
        If vlogf = "" Then ValidateEnv = False

        If ValidateEnv Then

            If Form1.ResultPathExist Then

                '---- Create a compiled list of all the batch files
                xtrace_i("Save Inst Result.")

                Dim BatchFileCollection = Left(vlogf, Len(vlogf) - 4) & "_Result.txt"
                xtrace_i("BatchFileCollection = " & BatchFileCollection)
                My.Computer.FileSystem.WriteAllText(BatchFileCollection, "Result:" & vbCrLf, False, Encoding.ASCII)
                Dim BatchFileContent As String

                For Each Subd In {"bat", "bat\util", "ps"}
                    Listd = InstRoot & "\" & Subd
                    If My.Computer.FileSystem.DirectoryExists(Listd) Then
                        xtrace_i("List: " & Listd)
                        For Each BatchFile In My.Computer.FileSystem.GetFiles(Listd)
                            xtrace("    - " & BatchFile)
                            BatchFileContent = My.Computer.FileSystem.ReadAllText(BatchFile)
                            My.Computer.FileSystem.WriteAllText(BatchFileCollection, vbCrLf &
                                                                "______________________________________________________________________" & vbCrLf &
                                                                Left("____ " & BatchFile & " __________________________________________", 70) & vbCrLf &
                                                                vbCrLf &
                                                                BatchFileContent,
                                                                True)
                        Next
                    End If
                Next

                '---- Create a file listing of Inst
                xtrace_i("Create a file listing of " & InstRoot)
                My.Computer.FileSystem.WriteAllText(BatchFileCollection, vbCrLf &
                                                    "______________________________________________________________________" & vbCrLf &
                                                    Left("____ File Listing _____________________________________________________", 70) & vbCrLf &
                                                    vbCrLf,
                                                    True)

                ListDirRecursiveStart(InstRoot)
                Dim Line As String
                For Each Line In lstResult
                    My.Computer.FileSystem.WriteAllText(BatchFileCollection, Line & vbCrLf, True)
                Next

            Else
                xtrace_i("Result path does not exist")
            End If

            '---- Copy Log File
            Try
                xtrace_i("Copy logfile")
                My.Computer.FileSystem.CopyFile(LogFile, vlogf, True)
            Catch ex As Exception
                xtrace(ex.Message)
            End Try

        Else
            xtrace_i("No Validate Environment found")
        End If

        xtrace_sube("CreateValidateLogs")
    End Sub

    Dim lstResult As New List(Of String)
    Dim listRecursion As Integer

    Sub ListDirRecursiveStart(MyDir As String)
        xtrace_subs("ListDirRecursiveStart")
        lstResult.Clear()
        listRecursion = 0
        ListDirRecursive(MyDir)
        xtrace_sube("ListDirRecursiveStart")
    End Sub
    Sub ListDirRecursive(MyDir As String)
        listRecursion += 1
        xtrace(" " & listRecursion.ToString & " " & MyDir)

        If listRecursion < 10 Then
            lstResult.AddRange(Directory.GetFiles(MyDir, "*.*"))
            Dim SubDir As String
            For Each SubDir In Directory.GetDirectories(MyDir)
                ListDirRecursive(SubDir)
            Next
        Else
            xtrace_warn("List recursion limit of 10 exceeded!")
        End If

        listRecursion -= 1
    End Sub
End Module
