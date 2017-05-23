Imports KulturkatalogenArrangemang

'anrop cmd: byt status(ny,godkänd,nekad, arkiverad):"arrstat", läst post: "lookedat", publicerad: "pub"
Public Class addAndDelArrangemangHandler
    Private _logobj As New LogHandlerModel
    Private _Arrobj As New kk_aj_arr_MainController
    Private _converttoJson As New convertArrtoJsonMainAnnonsFormat

    Enum statusevent
        Ny = 1
        Borttagen = 10
        Andrad = 5
    End Enum

    Public Function addArrangemang(cmd As String, arrobj As arrangemangInfo) As jsonMainAnnonsFormat
        Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand
        Dim jsn As New jsonrootInfo

        retobj.Ansokningstyp = "Add"
        tmpobj.Status = "Fel vid skapa nytt arrangemang"

        If Not String.IsNullOrEmpty(cmd) Then
            cmdtyp.CmdTyp = cmd
            tmpobj = _Arrobj.addArrangemang(cmdtyp, arrobj)
        End If


        _logobj.logger(tmpobj.Arrangemanglist(0).Arrid, 1, tmpobj.Status, 0, statusevent.Ny)

        Return _converttoJson.convertToArrangemangInfoApi(tmpobj)

    End Function

    Public Function delArrangemang(cmd As String, arrid As String, userid As String) As jsonMainAnnonsFormat
        Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand
        Dim jsn As New jsonrootInfo

        tmpobj.Status = "Fel när arrangemanget skulle tas bort"

        If String.IsNullOrEmpty(userid) Then
            tmpobj.Status = "Du har inte behörighet att ta bort arrangemang!"
        Else
            cmdtyp.CmdTyp = "Delete"
            cmdtyp.Arrid = CInt(arrid)
            tmpobj = _Arrobj.DelArrangemang(cmdtyp)
        End If

        _logobj.logger(arrid, 1, tmpobj.Status, userid, statusevent.Borttagen)

        Return _converttoJson.convertToArrangemangInfoApi(tmpobj)

    End Function


End Class
