﻿Imports KulturkatalogenArrangemang
Public Class convertArrtoJsonMainAnnonsFormat
#Region "arrcontainer to jsonmainAnnonsformat"
    Public Function convertToArrangemangInfoApi(arrinfo As arrangemangcontainerInfo) As jsonMainAnnonsFormat

        Dim retMainObj As New jsonMainAnnonsFormat
        Dim retansoklista As New jsonAnnonsListFormat

        Try
            retMainObj.Ansokningstyp = arrinfo.ArrStatus
            retMainObj.Ansokningarlistacount = arrinfo.ArrangemanglistCount
            retMainObj.Ansokningarlistacurrentpage = arrinfo.ArrangemangCurrentPage
            retMainObj.Ansokningarlistatotalpages = arrinfo.ArrangemangTotalPages
            retMainObj.approvedansokningarcount = arrinfo.ApprovedarrangemangCount
            retMainObj.deniedansokningarcount = arrinfo.DeniedarrangemangCount
            retMainObj.nyaansokningarcount = arrinfo.NyaArrangemangCount
            retMainObj.status = arrinfo.Status

            'lägg till alla annonser/arrangemang
            retansoklista.ansokningarcount = arrinfo.ArrangemanglistCount
            For Each itm In arrinfo.Arrangemanglist
                Dim tmpitm As New jsonAnnonsFormat
                tmpitm.ansokningdate = itm.Datum
                tmpitm.ansokningid = itm.Arrid
                tmpitm.ansokningkonstformid = itm.Konstformid
                tmpitm.ansokningkonstform = itm.Konstform
                tmpitm.ansokninglast = itm.LookedAt
                tmpitm.ansokningpublicerad = itm.Publicerad
                tmpitm.ansokningstatus = itm.ArrangemangStatus
                tmpitm.ansokningcontentid = itm.ContentID
                tmpitm.ansokningsubtitle = itm.UnderRubrik
                tmpitm.ansokningtitle = itm.Rubrik
                tmpitm.ansokningContent = itm.Innehall
                tmpitm.ansokningtypid = itm.Arrangemangtypid
                tmpitm.ansokningtyp = itm.Arrangemangtyp
                tmpitm.ansokningutovare = itm.Utovare
                tmpitm.ansokningUtovarid = itm.Utovarid
                tmpitm.ansokningMedialist = itm.MediaList
                tmpitm.ansokningFaktalist = itm.Faktalist
                tmpitm.ansokningMediaImage = itm.MainImage
                tmpitm.ansokningKonstform2 = itm.Konstform2
                tmpitm.ansokningKonstform3 = itm.Konstform3
                tmpitm.ansokningKontaktEfternamn = itm.KontaktEfternamn
                tmpitm.ansokningKontaktEpost = itm.KontaktEpost
                tmpitm.ansokningKontaktfornamn = itm.Kontaktfornamn
                tmpitm.ansokningKontaktTelefon = itm.KontaktTelefon
                'tmpitm.ansokningMovieClip = itm.MediaClip
                tmpitm.ansokningUsername = itm.Username
                tmpitm.ansokningUtovardata = itm.UtovareData
                tmpitm.ansokningFilterfakta = itm.Filterfakta
                tmpitm.ansokningAgespan = itm.Startyear & "- " & itm.Stoppyear
                retansoklista.ansokningar.Add(tmpitm)
            Next
            retMainObj.ansokningarlista = retansoklista

        Catch ex As Exception

            retMainObj.status = "Error in convert to json arrangemang"
        End Try

        Return retMainObj
    End Function
#End Region
End Class