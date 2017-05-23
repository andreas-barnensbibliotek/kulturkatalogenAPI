﻿Imports KulturkatalogenArrangemang

'anrop cmd: byt status(ny,godkänd,nekad, arkiverad):"arrstat", läst post: "lookedat", publicerad: "pub"
Public Class updateArrangemang
    Private _logobj As New LogHandlerModel
    Enum statusevent
        Ny = 1
        Borttagen = 10
        Andrad = 5
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
        _logobj.logger(arrid, cmd, tmpobj.Status, usrid, statusevent.Andrad)

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
        _logobj.logger(arrobj.Arrid, arrobj.Logtypid, arrobj.Logbeskrivning, arrobj.Userid, statusevent.Andrad)

        Return retobj

    End Function

End Class
