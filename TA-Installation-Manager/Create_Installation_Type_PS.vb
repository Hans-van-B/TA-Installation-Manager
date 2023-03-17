Module Create_Installation_Type_PS
    Sub Add_Installation_Components_PS()
        xtrace_line()
        xtrace_subs("Add_Installation_Components_PS")

        Dim StartFile As String = "# Created by " & AppName & " V" & AppVer
        WriteTxtToFile(InstRoot & "\bat\Install.ps1", StartFile, False, 0, "", "", True, True)

        xtrace_warn("Not implemented yet")

        xtrace_sube("Add_Installation_Components_PS")
    End Sub
End Module
