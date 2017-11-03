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
        'Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand
        Dim jsn As New jsonrootInfo
        Dim mailstatus As String = ""
        'retobj.Ansokningstyp = "Add"
        tmpobj.Status = "Fel vid skapa nytt arrangemang"

        If Not String.IsNullOrEmpty(cmd) Then
            cmdtyp.CmdTyp = cmd
            tmpobj = _Arrobj.addArrangemang(cmdtyp, arrobj)
            mailstatus = sendmail(arrobj)
            tmpobj.Status &= " " & mailstatus
        End If

        'LOGGA ALLA EVENT
        _logobj.logger(tmpobj.Arrangemanglist(0).Arrid, 1, tmpobj.Status, 0, statusevent.Ny)

        Return _converttoJson.convertToArrangemangInfoApi(tmpobj)

    End Function

    Public Function delArrangemang(cmd As String, arrid As String, userid As String) As jsonMainAnnonsFormat
        ' Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand

        tmpobj.Status = "Fel när arrangemanget skulle tas bort"

        If String.IsNullOrEmpty(userid) Then
            tmpobj.Status = "Du har inte behörighet att ta bort arrangemang!"
        Else
            cmdtyp.CmdTyp = "Delete"
            cmdtyp.Arrid = CInt(arrid)
            tmpobj = _Arrobj.DelArrangemang(cmdtyp)
        End If

        'LOGGA ALLA EVENT
        _logobj.logger(arrid, 1, tmpobj.Status, userid, statusevent.Borttagen)

        Return _converttoJson.convertToArrangemangInfoApi(tmpobj)

    End Function

    Public Function EditArrangemang(cmd As String, usrid As String, arrobj As EditArrangemangDetailInfo) As jsonMainAnnonsFormat

        Dim tmpobj As New arrangemangcontainerInfo

        If String.IsNullOrEmpty(usrid) Then
            tmpobj.Status = "Du har inte behörighet att ta bort arrangemang!"
        Else
            Select Case cmd
                Case "editcontent"
                    tmpobj = EditArrangemangContent(cmd, usrid, arrobj)
                Case "editcontentImg"
                    tmpobj = EditArrangemangContent(cmd, usrid, arrobj)
                Case "editfakta"
                    tmpobj = EditArrangemangFakta(cmd, usrid, arrobj)
                Case "editmedia"
                    tmpobj = EditArrangemangMedia(cmd, arrobj)
                Case "content"
                    tmpobj = EditArrangemangFakta(cmd, usrid, arrobj)
                Case "addfakta"
                    tmpobj = addArrangemangFakta(cmd, usrid, arrobj)
                Case "addmedia"
                    tmpobj = addArrangemangMedia(cmd, arrobj)
                Case "delfakta"
                    tmpobj = DeleteArrangemangFakta(cmd, usrid, arrobj)
                Case "delmedia"
                    tmpobj = DeleteArrangemangMedia(cmd, arrobj)

            End Select
        End If

        'LOGGA ALLA EVENT
        _logobj.logger(arrobj.arrid, 1, tmpobj.Status, usrid, statusevent.Andrad)

        Return _converttoJson.convertToArrangemangInfoApi(tmpobj)
    End Function
    Private Function sendmail(arrData As arrangemangInfo) As String

        Dim obj As New mailnewarrangemangHandler
        Return obj.newarrangemangMail(arrData)

    End Function

#Region "ADD"

    Private Function addArrangemangFakta(cmd As String, usrid As String, arrobj As EditArrangemangDetailInfo) As arrangemangcontainerInfo

        Dim mainobj As New kk_aj_arr_MainController
        Dim editObj As New faktainfo

        editObj.FaktaTypID = arrobj.faktaid
        editObj.FaktaValue = arrobj.faktaval

        Return mainobj.addFaktaToArrangemang(arrobj.arrid, editObj)
    End Function

    Private Function addArrangemangMedia(cmd As String, arrobj As EditArrangemangDetailInfo) As arrangemangcontainerInfo

        Dim mainobj As New kk_aj_arr_MainController
        Dim mediaObj As New mediaInfo

        'mediaObj.MediaID = CInt(arrobj.MediaID)
        mediaObj.MediaAlt = arrobj.MediaAlt
        mediaObj.MediaFilename = arrobj.MediaFilename
        mediaObj.MediaFoto = arrobj.MediaFoto
        mediaObj.MediaSize = arrobj.MediaSize
        mediaObj.MediaUrl = arrobj.MediaUrl
        mediaObj.MediaTyp = arrobj.MediaTyp
        mediaObj.MediaVald = arrobj.MediaVald
        mediaObj.mediaTitle = arrobj.mediaTitle
        mediaObj.mediaBeskrivning = arrobj.mediaBeskrivning
        mediaObj.mediaLink = arrobj.mediaLink
        mediaObj.sortering = arrobj.sortering.ToString
        'mediaObj.mediaTitle = HttpContext.Current.Server.HtmlEncode(arrobj.mediaTitle)
        'mediaObj.mediaBeskrivning = HttpContext.Current.Server.HtmlEncode(arrobj.mediaBeskrivning)

        Return mainobj.addmediaToArrangemang(arrobj.arrid, mediaObj)
    End Function

#End Region

#Region "EDIT"

    Private Function EditArrangemangContent(cmd As String, usrid As String, arrobj As EditArrangemangDetailInfo) As arrangemangcontainerInfo

        Dim mainobj As New kk_aj_arr_MainController
        Dim tmpobj As New arrangemangInfo

        tmpobj.Arrid = arrobj.arrid
        tmpobj.ContentID = arrobj.contentid

        tmpobj.Konstform = arrobj.konstformid
        tmpobj.Arrangemangtyp = arrobj.arrangemangtypid
        tmpobj.Utovare = arrobj.utovareid
        tmpobj.Publicerad = arrobj.publicerad

        tmpobj.Rubrik = arrobj.rubrik
        tmpobj.UnderRubrik = arrobj.underrubrik
        tmpobj.Innehall = arrobj.innehall
        tmpobj.MainImage.MediaUrl = arrobj.MediaUrl
        tmpobj.MainImage.MediaAlt = arrobj.MediaAlt
        tmpobj.MainImage.MediaFoto = arrobj.MediaFoto
        tmpobj.MainImage.MediaSize = arrobj.MediaSize

        Return mainobj.editArrangemang(tmpobj)

    End Function
    Private Function EditArrangemangFakta(cmd As String, usrid As String, arrobj As EditArrangemangDetailInfo) As arrangemangcontainerInfo

        Dim mainobj As New kk_aj_arr_MainController
        Dim editObj As New faktainfo

        editObj.Faktaid = arrobj.faktaid
        editObj.FaktaValue = arrobj.faktaval

        Return mainobj.editFaktaByFaktaid(arrobj.arrid, editObj)
    End Function

    Private Function EditArrangemangMedia(cmd As String, arrobj As EditArrangemangDetailInfo) As arrangemangcontainerInfo

        Dim mainobj As New kk_aj_arr_MainController
        Dim mediaObj As New mediaInfo

        mediaObj.MediaID = arrobj.MediaID
        mediaObj.MediaAlt = arrobj.MediaAlt
        mediaObj.MediaFilename = arrobj.MediaFilename
        mediaObj.MediaFoto = arrobj.MediaFoto
        mediaObj.MediaSize = arrobj.MediaSize
        mediaObj.MediaUrl = arrobj.MediaUrl
        mediaObj.MediaTyp = arrobj.MediaTyp
        mediaObj.MediaVald = arrobj.MediaVald
        mediaObj.mediaTitle = arrobj.mediaTitle
        mediaObj.mediaBeskrivning = arrobj.mediaBeskrivning
        mediaObj.mediaLink = arrobj.mediaLink
        If String.IsNullOrEmpty(arrobj.sortering) Then
            mediaObj.sortering = 0
        Else
            mediaObj.sortering = arrobj.sortering
        End If

        Return mainobj.editMediaByMediaid(arrobj.arrid, mediaObj)
    End Function

#End Region

#Region "Delete"
    Private Function DeleteArrangemangFakta(cmd As String, usrid As String, arrobj As EditArrangemangDetailInfo) As arrangemangcontainerInfo

        Dim mainobj As New kk_aj_arr_MainController
        Dim editObj As New faktainfo

        editObj.Faktaid = arrobj.faktaid

        Return mainobj.deleteFaktaByFaktaid(arrobj.arrid, editObj)
    End Function

    Private Function DeleteArrangemangMedia(cmd As String, arrobj As EditArrangemangDetailInfo) As arrangemangcontainerInfo

        Dim mainobj As New kk_aj_arr_MainController
        Dim mediaObj As New mediaInfo

        mediaObj.MediaID = arrobj.MediaID

        Return mainobj.deleteMediaByMediaid(arrobj.arrid, mediaObj)
    End Function
#End Region
End Class
