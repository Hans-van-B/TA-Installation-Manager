Module Create_Installation_Type_All
    Public DepoPath As String
    Sub Create_Installation_Base()
        xtrace_subs("Create_Installation_Base")

        DepoPath = TAISDevDepo & "\" & Form1.ComboBoxInstName.Text & "\" & Form1.ComboBoxInstVer.Text
        xtrace_i("DepoPath = " & DepoPath)
        If Not My.Computer.FileSystem.DirectoryExists(DepoPath) Then
            CreateDirectory(DepoPath, 0, "", "Please check your directory access rights", True, True)
        End If

        DepoRoot = DepoPath & "\Inst"
        xtrace_i("DepoRoot = " & DepoRoot)
        If Not My.Computer.FileSystem.DirectoryExists(DepoRoot) Then
            CreateDirectory(DepoRoot, 0, "", "Please check your directory access rights", True, True)
        End If

        Check_InstSubDirs(DepoRoot, "   ")

        AddInstFile(Form1.CheckBoxTASetup.Checked, "Inst\TA-Setup.exe")

        xtrace_sube("Create_Installation_Base")
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
