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
            Else
                xtrace_i("Result path does not exist")
            End If

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
End Module
