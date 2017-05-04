Imports KulturkatalogenArrangemang

'anrop cmd: byt status(ny,godkänd,nekad, arkiverad):"arrstat", läst post: "lookedat", publicerad: "pub"
Public Class updateArrangemang
    Private _logobj As New LogHandlerModel

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

        Call logger(arrid, cmd, tmpobj.Status, usrid)

        Return retobj

    End Function


    Private Sub logger(arrid As Integer, cmd As String, beskrivning As String, userid As Integer)
        Dim log As New crudLogInfo
        log.Arrid = arrid
        log.Logtypid = 1 'arrangemangevent
        log.Statustypid = 9 'Event
        log.Beskrivning = "Update command: " & cmd & " arrparam: " & beskrivning
        log.LogUserid = userid
        _logobj.addlog(log)
    End Sub
End Class
