Imports KulturkatalogenArrangemang
Public Class arrangemangHandler

    Private _arrObj As New kk_aj_arr_MainController

    Public Function getArrangemang(cmd As String, arrstatus As String, usrid As String, val As String) As jsonMainAnnonsFormat
        'exempel på cmd= byStatus,bySearch

        Dim tmpArrinfo As New arrangemangcontainerInfo
        Dim cmdtyp As New commandTypeInfo

        cmdtyp.CmdTyp = cmd
        cmdtyp.ArrStatusTyp = arrstatus
        cmdtyp.CmdtypUserid = usrid

        tmpArrinfo = _arrObj.getArrangemang(cmdtyp)

        Return convertToArrangemangInfoApi(tmpArrinfo)

    End Function


    Private Function convertToArrangemangInfoApi(arrinfo As arrangemangcontainerInfo) As jsonMainAnnonsFormat

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
                tmpitm.ansokningkonstform = itm.Konstform
                tmpitm.ansokninglast = itm.LookedAt
                tmpitm.ansokningpublicerad = itm.Publicerad
                tmpitm.ansokningstatus = itm.ArrangemangStatus
                tmpitm.ansokningsubtitle = itm.UnderRubrik
                tmpitm.ansokningtitle = itm.Rubrik
                tmpitm.ansokningtyp = itm.Arrangemangtyp
                tmpitm.ansokningutovare = itm.Utovare
                retansoklista.ansokningar.Add(tmpitm)
            Next
            retMainObj.ansokningarlista = retansoklista

        Catch ex As Exception

            retMainObj.status = "Error in convert to json arrangemang"
        End Try

        Return retMainObj
    End Function
End Class
