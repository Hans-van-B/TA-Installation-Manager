Module Create_Installation_Type_All
    Public DepoPath As String
    Public InstRoot As String
    Public InstName As String
    Sub Create_Installation_Base()
        xtrace_line()
        xtrace_subs("Create_Installation_Base")

        Form1.SetStatus("Create Installation")
        InstName = Form1.ComboBoxInstName.Text
        xtrace_i("TAISDevDepo = " & TAISDevDepo)

        xtrace_i("Check DepoSubDir: " & DepoSubDir)
        If DepoSubDir = "" Then
            DepoPath = TAISDevDepo & "\" & InstName & "\" & Form1.ComboBoxInstVer.Text
        Else
            DepoPath = TAISDevDepo & "\" & DepoSubDir & "\" & InstName & "\" & Form1.ComboBoxInstVer.Text
        End If
        xtrace_i("DepoPath = " & DepoPath)
        If Not My.Computer.FileSystem.DirectoryExists(DepoPath) Then
            CreateDirectory(DepoPath, 0, "", "Please check your directory access rights", True, True)
        End If

        InstRoot = DepoPath & "\Inst"
        xtrace_i("InstRoot = " & InstRoot)
        If Not My.Computer.FileSystem.DirectoryExists(InstRoot) Then
            CreateDirectory(InstRoot, 0, "", "Please check your directory access rights", True, True)
        End If

        Check_InstSubDirs(InstRoot, "")

        Dim CheckDir, SD As String
        For Each SD In {"Inst\Doc", "Source", "Source\W64", "Prepare", "Prepare\Bookmark", "Prepare\Doc", "Prepare\Doc\Err", "Prepare\Doc\ChangeReq"}
            CheckDir = DepoPath & "\" & SD
            xtrace_i("Check : " & CheckDir)
            If Not My.Computer.FileSystem.DirectoryExists(CheckDir) Then
                CreateDirectory(CheckDir, 0, "", "Please check your directory access rights", True, True)
            End If
        Next

        AddInstFile(Form1.CheckBoxTASetup.Checked, "TA-Setup.exe", "Inst")
        AddInstFile(Form1.CheckBoxTASelect.Checked, "TA-Select.exe", "Inst")
        AddInstFile(Form1.CheckBoxTADeinstall.Checked, "TA-Deinstall.exe", "Inst")

        Form1.ButtonShowResult.Enabled = True

        xtrace_sube("Create_Installation_Base")
    End Sub

    Sub Finalize_Installation()
        xtrace_subs("Finalize_Installation")

        xtrace_sube("Finalize_Installation")
    End Sub

    Sub AddInstFile(CheckBox As Boolean, FileName As String, SubPath As String)
        xtrace_subs("AddInstFile " & FileName)

        Dim Target As String = DepoPath & "\" & SubPath
        Dim FTarget As String = Target & "\" & FileName
        xtrace_i("File Target = " & FTarget)
        xtrace_i("CheckBox = " & CheckBox.ToString)

        If CheckBox Then
            xtrace_i("Add: " & SubPath & "\" & FileName)
            GetFile(FileName, Target)
        Else
            xtrace_i("Off: " & SubPath & "\" & FileName)
            If My.Computer.FileSystem.FileExists(FTarget) Then
                xtrace_i("Remove " & FTarget)
                My.Computer.FileSystem.DeleteFile(FTarget)
            End If
        End If

        xtrace_sube("AddInstFile")
    End Sub
End Module
