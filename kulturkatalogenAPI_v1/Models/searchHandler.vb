
Imports KulturkatalogenArrangemang

'anrop cmd: byt status(ny,godkänd,nekad, arkiverad):"arrstat", läst post: "lookedat", publicerad: "pub"
Public Class searchHandler

    Private _Arrobj As New kk_aj_arr_MainController
    Private _converttoJson As New convertArrtoJsonMainAnnonsFormat

    Public Function searchArrangemang(cmd As String, searchcmd As commandTypeSearchInfo) As jsonMainAnnonsFormat
        'Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim jsn As New jsonrootInfo

        tmpobj.Status = "Fel vid skapa nytt arrangemang"

        If Not String.IsNullOrEmpty(cmd) Then

            tmpobj = _Arrobj.searchArrangemang(searchcmd)

            tmpobj.Status = "Sökningen på detta: arrtyp: " & searchcmd.arrtypid & ", konstartid: " & searchcmd.konstartid & " age: " & searchcmd.startyear & "- " & searchcmd.stopyear & " searchstr: " & searchcmd.searchstr & " är gjord."
        End If

        ''LOGGA ALLA EVENT
        '_logobj.logger(tmpobj.Arrangemanglist(0).Arrid, 1, tmpobj.Status, 0, statusevent.Ny)

        Return _converttoJson.convertToArrangemangInfoApi(tmpobj)

    End Function
End Class
