Imports System.Net.NetworkInformation
Module NetworkInformation
    Public NetworkNotAvailable As Boolean = False
    Public ShowDomainName As Boolean = False

    Function GetDomainNameString(LT As Integer) As String
        xtrace_subs("GetDomainNameString", LT)

        Dim Nics() As NetworkInterface
        Dim Nic As NetworkInterface
        Nics = NetworkInterface.GetAllNetworkInterfaces
        Dim NicCnt = Nics.Length
        Dim Result As String = ""

        If NicCnt > 0 Then
            xtrace("Nr of NIC interfaces .......... : " & NicCnt.ToString, LT)
            Dim NicNr As Integer = 0

            For Each Nic In Nics
                NicNr += 1
                Dim NicProp As IPInterfaceProperties
                NicProp = Nic.GetIPProperties
                xtrace(" ", LT)
                Dim NicName As String = Nic.Name
                xtrace(NicName & "  (" & NicNr.ToString & ")", LT)

                Dim NicStatus As String = Nic.OperationalStatus.ToString()
                xtrace("  Operational status .................. : " & Nic.OperationalStatus.ToString(), LT)
                If NicStatus = "Down" Then Continue For

                If (Nic.NetworkInterfaceType = NetworkInterfaceType.Loopback) Then Continue For

                Dim DNSName = NicProp.DnsSuffix
                xtrace("  Connection specific DNS suffix ...... : " & DNSName, LT)
                Result = DNSName & "." & Environment.MachineName
                xtrace("  Assigned DNS Name ................... : " & Result, LT)
            Next
        Else
            If ShowDomainName Then
                xtrace("Warning: No NIC's found!", 1)
            Else
                xtrace("Warning: No NIC's found!", LT)

                Result = "None." & Environment.MachineName
                NetworkNotAvailable = True
            End If
        End If

        If ShowDomainName Then
            xtrace("Domain name = " & Result)
            ExitProgram = True
        End If
        GetDomainNameString = Result
        xtrace_sube("GetDomainNameString", LT)
    End Function

End Module
