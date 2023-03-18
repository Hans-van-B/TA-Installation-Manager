' This license mechanism is based on trust, not security.
' It shows you your license model
' It supports open-source (free) licensing
' It is intended to be simple and require little maintenance (both in finances and human effort)
' If you want to hack, find another app, this one is too easy.

Imports System.IO
Imports System.Text
Imports System.Net
Imports System.ComponentModel
Imports System.Globalization
Imports System.Security.Policy
Imports System.Net.NetworkInformation

Public Class LicC
    Public Shared DefaultLicID As String = "OpenSource"
    Public Shared LicTraceLevel As Integer = 4
    Public Shared LicID As String = LicC.DefaultLicID

    Public Shared LicFile As String = ""
    Public Shared LicString As String = "License not reachable"
    Public Shared LicValidUntill As String = "2023-06-04"

    Shared LicDomainList() As String = {
        "tainst.nl",
        "christelijke-antwoorden.nl"}
    Shared LicDirList() As String = {
        "LicFiles/" & AppName,
        "LicFiles/TAIS"}
    Shared LicFileList() As String = {}
    Shared LicFileFound As Boolean = False

    Public Shared Sub GetLic()
        xtrace_subs("LicC.GetLic", LicTraceLevel)

        ' Try Each Domain
        Dim Domain As String
        For Each Domain In LicDomainList
            If Len(Domain) < 4 Then Continue For

            Dim LicServer As String = "http://www." & Domain & "/"
            xtrace("", LicTraceLevel)
            xtrace_i("Try LicServer: " & LicServer, LicTraceLevel)

            'Try each LicDir
            Dim LicDir As String
            For Each LicDir In LicDirList
                If Len(LicDir) < 3 Then Continue For

                ' Try Each LicID
                Dim LicFileListFixed As String() = {
                    AppName & "_" & AppVer & "_" & LicID,
                    AppName & "_" & LicID,
                    LicID}
                LicFileList = LicFileList.Union(LicFileListFixed).ToArray

                For Each LicFile As String In LicFileList
                    If Len(LicFile) < 3 Then Continue For
                    Dim URL As String
                    URL = LicServer & LicDir & "/" & LicFile & ".txt"

                    If LicC.GetLicFile(URL) Then Exit For
                Next
                If LicFileFound Then Exit For
            Next
            If LicFileFound Then Exit For
        Next

        xtrace_sube("LicC.GetLic", LicTraceLevel)
    End Sub

    Shared Function GetLicFile(URL As String) As Boolean
        xtrace_i("Try " & URL, LicTraceLevel)
        Try
            Dim client As WebClient = New WebClient()
            Dim reader As StreamReader = New StreamReader(client.OpenRead(URL))
            LicFile = reader.ReadToEnd
            xtrace_i("Received: " & Left(LicFile, 30) & "...", LicTraceLevel)
        Catch ex As Exception
            xtrace("   " & ex.Message, LicTraceLevel)
            Return False
        End Try

        If Len(LicFile) < 10 Then
            xtrace("   Lic file empty", LicTraceLevel)
            Return False
        End If

        Dim LicLines() As String
        Dim LicFileType As String = "Windows"
        LicLines = LicFile.Split(vbNewLine) ' Windows file

        If LicLines.Length < 2 Then
            LicFileType = "Unix"
            LicLines = LicFile.Split(vbLf)  ' Web server may have a Unix File
        End If

        If LicLines.Length < 2 Then ' eof characted unknown
            LicFileType = "Unknown"
            xtrace("   Lic file type unknown", LicTraceLevel)
            Return False
        End If

        If Not CheckLicFileValid(LicLines) Then
            xtrace("   The license file used is invalid")
            Return False
        End If

        xtrace("   Lic file = " & LicFileType, LicTraceLevel)
        GetLicFile = True
        LicFileFound = True

        ' Read lines
        Dim P1 As Integer
        Dim CName, CVal As String

        For Each line As String In LicLines

            '---- Remark lines ----
            If Left(line, 1) = "#" Then
                xtrace_i("Skip Remark line", LicTraceLevel)
                Continue For
            End If

            '---- Read LicLines
            xtrace(" - Lic Line : " & line, LicTraceLevel)
            P1 = InStr(line, "=")

            If P1 > 0 Then
                CName = Left(line, P1 - 1)
                CVal = Mid(line, P1 + 1)
                xtrace(" - " & CName & " = " & CVal, LicTraceLevel)

                '-- InstTitle
                If CName = "LicString" Then
                    LicString = CVal
                    xtrace(" - SET LicString = " & LicString, LicTraceLevel)
                End If

                '-- LicValidUntill
                If CName = "LicValidUntill" Then
                    LicValidUntill = CVal
                    xtrace(" - SET LicValidUntill = " & LicValidUntill, LicTraceLevel)
                    xtrace_i("License valid untill " & LicValidUntill)
                End If

            End If
        Next

    End Function

    Public Shared Function CheckLicDate() As Boolean
        xtrace_subs("LicC.CheckLicDate", LicTraceLevel)

        Dim DDNow As DateTime
        Dim SDNow As String
        Dim Result As Boolean = True

        If LicValidUntill = AppVer & "_Permanent" Then
            xtrace_i("Permanent", LicTraceLevel)
            Result = True
            GoTo QUIT
        End If

        DDNow = DateTime.Now
        'SDNow = DDNow.ToString("d", CultureInfo.CreateSpecificCulture("ja-JP"))
        SDNow = DDNow.ToString("yyyy-MM-dd")

        xtrace_i("Compare: " & LicValidUntill & " > " & SDNow, LicTraceLevel)

        If LicValidUntill > SDNow Then
            Result = True
        Else
            Result = False
            xtrace_Err(1100,
                       "The license for " & LicID & "Has expired",
                       {""},
                       {"Contact you software supplier or raise an issue in GitHub"},
                       True,
                       "")
        End If

QUIT:
        xtrace_i("Result = " & Result.ToString, LicTraceLevel)
        CheckLicDate = Result

        xtrace_sube("LicC.CheckLicDate", LicTraceLevel)
    End Function

    '---- Validate the lic file --------------------------------
    Shared Function CheckLicFileValid(LicLines() As String) As Boolean
        xtrace_subs("LicC.CheckLicFileValid", LicTraceLevel)

        Dim LicFile As String = ""
        Dim Line As String
        Dim Checksum1 As String = ""
        Dim Checksum2 As String
        Dim Result As Boolean

        For Each Line In LicLines
            If Left(Line, 6) = "LICCS=" Then
                Checksum1 = Mid(Line, 7)
                xtrace_i("Checksum1 = " & Checksum1, LicTraceLevel)
                Continue For
            End If

            ' If the licence file contains "FQDomainName=" Then the current
            ' Fully qualified domain name is added
            ' Do not use these values within the open source license!
            If Line = "FQDN=" Then
                If LicC.LicID = LicC.DefaultLicID Then
                    xtrace_warn("Do not use this Lic Line for " & LicC.DefaultLicID)
                Else
                    Dim FQDNS As String = IPGlobalProperties.GetIPGlobalProperties().DomainName
                    If FQDNS = "" Then
                        Line = Line & GetDomainNameString(LicTraceLevel)

                        If NetworkNotAvailable Then
                            CheckLicFileValid = True
                            xtrace_i("No network!", LicTraceLevel)
                            GoTo QUIT
                        End If
                    Else
                        Line = Line & FQDNS
                    End If

                End If
            End If

            If Line = "Domain=" Then
                If LicC.LicID = LicC.DefaultLicID Then
                    xtrace_warn("Do not use this Lic Line for " & LicC.DefaultLicID)
                Else
                    Line = Line & Environment.UserDomainName
                End If
            End If

            xtrace(" | " & Line, LicTraceLevel)
            LicFile = LicFile & "|" & Line
        Next

        Checksum2 = GenerateMd5Hash(LicFile)
        xtrace_i("Checksum2 = " & Checksum2, LicTraceLevel)

        Result = (Checksum1 = Checksum2)
        xtrace_i("Result = " & Result.ToString, LicTraceLevel)
        CheckLicFileValid = Result

QUIT:
        xtrace_sube("LicC.CheckLicFileValid", LicTraceLevel)
    End Function

    '---- Checksum -----------------------------------------------------
    Shared Function GenerateMd5Hash(Input As String) As String
        Dim SSC = New System.Security.Cryptography.MD5CryptoServiceProvider()
        Dim computeHash = System.Text.Encoding.UTF8.GetBytes(Input)
        computeHash = SSC.ComputeHash(computeHash)

        Dim stringBuilder = New System.Text.StringBuilder()
        Dim B As Byte
        For Each B In computeHash
            stringBuilder.Append(B.ToString("x2"))
        Next
        Return stringBuilder.ToString()
    End Function

End Class
