﻿
Imports KulturkatalogenArrangemang
Imports KulturkatalogenMail
Imports kulturkatalogenUser

Public Class mailnewarrangemangHandler
    'Public Function newarrangemangMail(arrmaildata As KulturkatalogenArrangemang.arrangemangInfo) As String
    '    Dim userobj As New kk_aj_katalogenUsers
    '    Dim userlist As New List(Of katalogenUserInfo)
    '    Dim mailobj As New katalogenMailController
    '    Dim mailtolist As String = ""

    '    If arrmaildata.debug = "9999" Then 'debug nummer
    '        mailtolist = "theonealf@gmail.com"
    '    Else
    '        userlist = userobj.getUsersbykonstform(arrmaildata.Konstform)

    '        Dim antal As Integer = userlist.Count
    '        Dim i As Integer = 1
    '        For Each x In userlist
    '            mailtolist = x.userepost
    '            If antal > i Then
    '                mailtolist &= "; "
    '            End If

    '            i += 1
    '        Next
    '    End If

    '    Return mailobj.arraangemangmail(convertinfoclasser(arrmaildata), mailtolist)

    'End Function

    Public Sub sendmail(mailtyp As String, arrid As Integer, logtext As String)
        Dim logobj As New LogHandlerModel
        Dim logbes As String = "AutoMail to: " & arrid & " status: "
        logbes &= SendMailHandler(mailtyp, arrid, logtext)

        logobj.logger(arrid, 2, logbes, 1, 9) 'logobj.logger(arrid, Logtyp.Systemevent, logbeskrivning, hostuser, statusevent.handelse)

    End Sub
    Private Function SendMailHandler(mailtyp As String, arrid As Integer, motivering As String) As String
        Dim mailhandler As New katalogenMailController
        Dim arrangemang As New KulturkatalogenArrangemang.arrangemangInfo
        Dim kostformobj As New kk_aj_katalogenUsers
        arrangemang = getmailBasecontent(arrid)
        Dim konstformuser As List(Of katalogenUserInfo) = kostformobj.getUsersbykonstform(arrangemang.Konstformid)

        Dim mailobj As New mailInfo
        Dim ret As String = ""
        Dim konsformusruserepost As String = ""
        'If konstformuser.Count > 0 Then
        '    If konstformuser.Count > 1 Then

        For Each epostadr In konstformuser
            If epostadr Is konstformuser.Last Then
                konsformusruserepost &= epostadr.userepost
            Else
                konsformusruserepost &= epostadr.userepost & ","
            End If

        Next
        'Else
        '    konsformusruserepost = konstformuser(0).userepost
        'End If

        ' konsformusruserepost = konstformuser(0).userepost
        'End If

        If String.IsNullOrEmpty(arrangemang.KontaktEpost) Or String.IsNullOrEmpty(konsformusruserepost) Then
            ret = "Fel Ingen kontaktEpostadress eller KonstformansvarigEpost finns registrerad" & " konsulent: userid " & mailobj.KulturkatalogenUserid
        Else
            With mailobj
                .Utovarid = arrangemang.Utovarid
                .utovaremailtoadress = arrangemang.KontaktEpost
                .Konstformid = arrangemang.Konstformid
                .MailTemplateId = mailtyp
                .MailArrdata = convertinfoclasser(arrangemang)
                .Motivering = motivering
                .KulturkatalogenUserid = konstformuser(0).Userid
                .KulturkatalogenAvsEpost = konsformusruserepost 'konstformuser(0).userepost
                .KulturkatalogenAvsNamn = konstformuser(0).userfornamn & " " & konstformuser(0).userefternamn

            End With
            ret = mailhandler.sendArrangemangsMail(mailobj) & " konsulent: " & mailobj.KulturkatalogenAvsEpost & "(" & mailobj.KulturkatalogenUserid & ")"
        End If

        Return ret

    End Function

    Private Function getmailBasecontent(arrid As Integer) As KulturkatalogenArrangemang.arrangemangInfo
        Dim tmparrobj As New KulturkatalogenArrangemang.arrangemangcontainerInfo
        Dim _arrObj As New kk_aj_arr_MainController

        Dim cmdtyp As New commandTypeInfo
        cmdtyp.ArrID = arrid
        cmdtyp.CmdTyp = "details"

        tmparrobj = _arrObj.getArrangemang(cmdtyp)

        Return tmparrobj.Arrangemanglist(0)


    End Function

    Private Function convertinfoclasser(arrmaildata As KulturkatalogenArrangemang.arrangemangInfo) As KulturkatalogenMail.arrangemangInfo
        Dim nymail As New KulturkatalogenMail.arrangemangInfo
        nymail.ArrangemangStatus = arrmaildata.ArrangemangStatus
        nymail.Arrangemangtyp = arrmaildata.Arrangemangtyp
        nymail.Arrgruppid = arrmaildata.Arrgruppid
        nymail.Arrid = arrmaildata.Arrid
        nymail.ContentID = arrmaildata.ContentID
        nymail.Datum = arrmaildata.Datum

        For Each itm In arrmaildata.Faktalist
            Dim nyfakta As New KulturkatalogenMail.faktainfo
            nyfakta.Faktaid = itm.Faktaid
            nyfakta.Faktarubrik = itm.Faktarubrik
            nyfakta.FaktaTypID = itm.FaktaTypID
            nyfakta.FaktaValue = itm.FaktaValue
            nymail.Faktalist.Add(nyfakta)
        Next

        nymail.Innehall = arrmaildata.Innehall
        nymail.Konstform = arrmaildata.Konstform
        nymail.LookedAt = arrmaildata.LookedAt
        nymail.MainImage.MediaAlt = arrmaildata.MainImage.MediaAlt
        nymail.MainImage.mediaBeskrivning = arrmaildata.MainImage.mediaBeskrivning
        nymail.MainImage.MediaFilename = arrmaildata.MainImage.MediaFilename
        nymail.MainImage.MediaFoto = arrmaildata.MainImage.MediaFoto
        nymail.MainImage.MediaID = arrmaildata.MainImage.MediaID
        nymail.MainImage.mediaLink = arrmaildata.MainImage.mediaLink
        nymail.MainImage.MediaSize = arrmaildata.MainImage.MediaSize
        nymail.MainImage.mediaTitle = arrmaildata.MainImage.mediaTitle
        nymail.MainImage.MediaTyp = arrmaildata.MainImage.MediaTyp
        nymail.MainImage.MediaUrl = arrmaildata.MainImage.MediaUrl
        nymail.MainImage.MediaVald = arrmaildata.MainImage.MediaVald
        nymail.MainImage.sortering = arrmaildata.MainImage.sortering

        nymail.MediaClip.MediaAlt = arrmaildata.MediaClip.MediaAlt
        nymail.MediaClip.mediaBeskrivning = arrmaildata.MediaClip.mediaBeskrivning
        nymail.MediaClip.MediaFilename = arrmaildata.MediaClip.MediaFilename
        nymail.MediaClip.MediaFoto = arrmaildata.MediaClip.MediaFoto
        nymail.MediaClip.MediaID = arrmaildata.MediaClip.MediaID
        nymail.MediaClip.mediaLink = arrmaildata.MediaClip.mediaLink
        nymail.MediaClip.MediaSize = arrmaildata.MediaClip.MediaSize
        nymail.MediaClip.mediaTitle = arrmaildata.MediaClip.mediaTitle
        nymail.MediaClip.MediaTyp = arrmaildata.MediaClip.MediaTyp
        nymail.MediaClip.MediaUrl = arrmaildata.MediaClip.MediaUrl
        nymail.MediaClip.MediaVald = arrmaildata.MediaClip.MediaVald
        nymail.MediaClip.sortering = arrmaildata.MediaClip.sortering


        For Each itm In arrmaildata.MediaList
            Dim nymedia As New KulturkatalogenMail.mediaInfo
            nymedia.MediaAlt = itm.MediaAlt
            nymedia.mediaBeskrivning = itm.mediaBeskrivning
            nymedia.MediaFilename = itm.MediaFilename
            nymedia.MediaFoto = itm.MediaFoto
            nymedia.MediaID = itm.MediaID
            nymedia.mediaLink = itm.mediaLink
            nymedia.MediaSize = itm.MediaSize
            nymedia.mediaTitle = itm.mediaTitle
            nymedia.MediaTyp = itm.MediaTyp
            nymedia.MediaUrl = itm.MediaUrl
            nymedia.MediaVald = itm.MediaVald
            nymedia.sortering = itm.sortering
            nymail.MediaList.Add(nymedia)
        Next


        nymail.Publicerad = arrmaildata.Publicerad
        nymail.Rubrik = arrmaildata.Rubrik
        nymail.UnderRubrik = arrmaildata.UnderRubrik
        nymail.Username = arrmaildata.Username
        nymail.Utovare = arrmaildata.Utovare
        nymail.UtovareData.Adress = arrmaildata.UtovareData.Adress
        nymail.UtovareData.Efternamn = arrmaildata.UtovareData.Efternamn
        nymail.UtovareData.Epost = arrmaildata.UtovareData.Epost
        nymail.UtovareData.Fornamn = arrmaildata.UtovareData.Fornamn
        nymail.UtovareData.Kommun = arrmaildata.UtovareData.Kommun
        nymail.UtovareData.Organisation = arrmaildata.UtovareData.Organisation
        nymail.UtovareData.Ort = arrmaildata.UtovareData.Ort
        nymail.UtovareData.Postnr = arrmaildata.UtovareData.Postnr
        nymail.UtovareData.Telefon = arrmaildata.UtovareData.Telefon
        nymail.UtovareData.UtovarID = arrmaildata.UtovareData.UtovarID
        nymail.UtovareData.Weburl = arrmaildata.UtovareData.Weburl

        nymail.Utovarid = arrmaildata.Utovarid

        Return nymail
    End Function



End Class
