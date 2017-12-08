Imports KulturkatalogenArrangemang

'anrop cmd: byt status(ny,godkänd,nekad, arkiverad):"arrstat", läst post: "lookedat", publicerad: "pub"
Public Class updateArrangemang
    Private _logobj As New LogHandlerModel
    Private _mailobj As New mailnewarrangemangHandler
    Enum statusevent
        Ny = 1
        Borttagen = 10
        handelse = 9 'event
        Andrad = 5
    End Enum
    Enum Logtyp
        Arrangemangevent = 1
        Systemevent = 2
        Searchevent = 3
    End Enum
    Public Function updateArrangemangParametrar(cmd As String, arrid As Integer, usrid As Integer, val As String) As jsonMainAnnonsFormat
        Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand

        retobj.Ansokningstyp = "Update"
        tmpobj.Status = "Fel vid anrop av uppdateringen"

        If Not String.IsNullOrEmpty(cmd) Then
            If Not String.IsNullOrEmpty(val) Then
                cmdtyp.CmdTyp = cmd
                cmdtyp.Arrid = arrid
                cmdtyp.arrUserid = usrid
                cmdtyp.UpdValue = val

                Dim updatecmdobj As New kk_aj_arr_MainController
                tmpobj = updatecmdobj.updateArrPropeties(cmdtyp)

            End If
        End If

        retobj.status = tmpobj.Status
        _logobj.logger(arrid, Logtyp.Arrangemangevent, tmpobj.Status, usrid, statusevent.Andrad)

        Return retobj

    End Function

    Public Function updateArrangemangParametrar(arrobj As updateArrangemangInfo) As jsonMainAnnonsFormat
        Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand

        retobj.Ansokningstyp = "Update"
        tmpobj.Status = "Fel vid anrop av uppdateringen"

        If Not String.IsNullOrEmpty(arrobj.Logbeskrivning) Then
            If arrobj.Userid > 0 Then
                If arrobj.Arrid > 0 Then
                    cmdtyp.CmdTyp = arrobj.CmdTyp
                    cmdtyp.Arrid = arrobj.Arrid
                    cmdtyp.arrUserid = arrobj.Userid
                    cmdtyp.UpdValue = arrobj.UpdValue
                End If


                Dim updatecmdobj As New kk_aj_arr_MainController
                tmpobj = updatecmdobj.updateArrPropeties(cmdtyp)

            End If
        End If

        retobj.status = tmpobj.Status
        _logobj.logger(arrobj.Arrid, arrobj.Logtypid, arrobj.Logbeskrivning, arrobj.Userid, arrobj.Logstatusid)

        If retobj.status.IndexOf("Fel") = -1 Then
            _mailobj.sendmail(arrobj.UpdValue, arrobj.Arrid, arrobj.Logbeskrivning)
        End If

        Return retobj

    End Function

End Class
