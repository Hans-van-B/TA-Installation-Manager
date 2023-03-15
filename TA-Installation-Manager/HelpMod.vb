Module HelpMod

    '==== GUI Help ============================================================

    Dim HelpPage As String = Temp & "\help.html"
    Dim HelpPageHtm As String = AppRoot & "\" & AppName & ".html"
    Dim HelpPagePdf As String = AppRoot & "\" & AppName & ".pdf"

    Sub ShowHelp()
        xtrace("Show Help")

        If (System.IO.File.Exists(HelpPageHtm)) Then
            HelpPage = HelpPageHtm
        ElseIf (System.IO.File.Exists(HelpPagePdf)) Then
            HelpPage = HelpPagePdf
        Else
            xtrace("Did not find " & HelpPageHtm)
            xtrace("Did not find " & HelpPagePdf)

            xtrace("Create page")
            My.Computer.FileSystem.WriteAllText(HelpPage, "<html>" & vbNewLine, False)
            WriteHelp("<head>")
            WriteHelp("")
            WriteHelp("</head>")
            WriteHelp("<H2>" & AppName & " V" & AppVer & " Help Page</H2>")
            WriteHelp("<br>")
            WriteHelp("<H3>Using Templates and Wizzards</H3>")
            WriteHelp("Some installations contain an installation wizzard that delivers and (almost) complete installation.<br>")
            WriteHelp("If you select your own application name, then the installation manager will create an installation framework (or template).<br>")
            WriteHelp("But you can also use the settings of an existing wizzard for another application: <br>")
            WriteHelp("<UL>")
            WriteHelp(" <LI>For instance, you can select the (older) NX12 application.</LI>")
            WriteHelp(" <LI>Then press [Check Settings]. This will set all the settings in the application wizzard.</LI>")
            WriteHelp(" <LI>Then enter you own application name, for instance NX1926</LI>")
            WriteHelp(" <LI>And then create the installation</LI>")
            WriteHelp("</UL>")
            WriteHelp("<br>")
            WriteHelp("<br>")
            WriteHelp("<br>")
            WriteHelp("<br>")
            WriteHelp("The " & AppName & " log can be found here: " & LogFile & "<br>")
            WriteHelp("</body>")
            WriteHelp("</html")
        End If

        Process.Start(HelpPage, "")
    End Sub

    Sub ShowHelpAbout()
        xtrace("Show Help, about")

        xtrace("Create page")
        My.Computer.FileSystem.WriteAllText(HelpPage, "<html>" & vbNewLine, False)
        WriteHelp("<head>")
        WriteHelp("")
        WriteHelp("</head>")
        WriteHelp("<H2>" & AppName & " V" & AppVer & " Help About</H2>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<br>")
        WriteHelp("<font size=""-1"">")
        WriteHelp(" The " & AppName & " log can be found here: " & LogFile & "<br>")
        WriteHelp(" Wiki : <a href=""https://github.com/Hans-van-B/" & AppName & "/wiki"">https://github.com/Hans-van-B/" & AppName & "/wiki</a> <br>")
        WriteHelp(" Dev. : <br>")
        WriteHelp(" Maint: <br>")
        WriteHelp(" GitHub: <a href=""https://github.com/Hans-van-B/" & AppName & """>https://github.com/Hans-van-B/" & AppName & "</a> <br>")
        WriteHelp(" Inst.: " & AppRoot & "<br>")
        WriteHelp(" The " & AppName & " log can be found here: " & Log.LogFile & "<br>")
        WriteHelp("</font>")
        WriteHelp("</body>")
        WriteHelp("</html")

        Process.Start(HelpPage, "")
    End Sub

    Sub WriteHelp(Line As String)
        My.Computer.FileSystem.WriteAllText(HelpPage, Line & vbNewLine, True)
    End Sub

End Module
