Module Create_Installation_Type_All
    Public DepoPath As String
    Public InstRoot As String
    Public InstName As String
    Sub Create_Installation_Base()
        xtrace_subs("Create_Installation_Base")

        InstName = Form1.ComboBoxInstName.Text
        DepoPath = TAISDevDepo & "\" & InstName & "\" & Form1.ComboBoxInstVer.Text
        xtrace_i("DepoPath = " & DepoPath)
        If Not My.Computer.FileSystem.DirectoryExists(DepoPath) Then
            CreateDirectory(DepoPath, 0, "", "Please check your directory access rights", True, True)
        End If

        InstRoot = DepoPath & "\Inst"
        xtrace_i("InstRoot = " & InstRoot)
        If Not My.Computer.FileSystem.DirectoryExists(InstRoot) Then
            CreateDirectory(InstRoot, 0, "", "Please check your directory access rights", True, True)
        End If

        Check_InstSubDirs(InstRoot, "   ")

        Dim CheckDir, SD As String
        For Each SD In {"Inst\Doc", "Source", "Source\W64", "Prepare", "Prepare\Doc", "Prepare\Doc\Err", "Prepare\Doc\ChangeReq"}
            CheckDir = DepoPath & "\" & SD
            xtrace_i("Check : " & CheckDir)
            If Not My.Computer.FileSystem.DirectoryExists(CheckDir) Then
                CreateDirectory(CheckDir, 0, "", "Please check your directory access rights", True, True)
            End If
        Next

        AddInstFile(Form1.CheckBoxTASetup.Checked, "Inst\TA-Setup.exe")
        AddInstFile(Form1.CheckBoxTASelect.Checked, "Inst\TA-Select.exe")
        AddInstFile(Form1.CheckBoxTADeinstall.Checked, "Inst\TA-Deinstall.exe")

        Form1.ButtonShowResult.Enabled = True

        xtrace_sube("Create_Installation_Base")
    End Sub

    Sub Finalize_Installation()
        xtrace_subs("Finalize_Installation")

        xtrace_sube("Finalize_Installation")
    End Sub

    Sub AddInstFile(CheckBox As Boolean, SubPath As String)
        If CheckBox Then
            Dim Source As String = TA_TemplateV & "\" & SubPath
            Dim Target As String = DepoPath & "\" & SubPath
            xtrace_i("Add: " & Target)
            CopyFile(Source, Target, 0, "", "", True, True)

        End If
    End Sub
End Module
