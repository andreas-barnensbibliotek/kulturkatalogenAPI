Imports System.Net
Imports System.Web.Http
    Imports System.Web.Http.Cors
'------------------------------------------------------------------------------------------------------
' apianrop exempel för att uppdatera ett arrangemangs parametrar:
' arrangemang tre parametrar som kan ändras commando:   lookedat (kan bara "ja" el "nej"),
'                                                       arrstat (1=ny,2=godkänd, 3=nekad, 4=arkiv),
'                                                       pub (kan bara "ja" el "nej")
' userid måste skickas med: uid = userid
' Värdet som skall ändras till måste anges= val/{val} (ny,godkänd, nekad, arkiv) typ= arrtypid
' Api_v2/{controller}/{cmd}/id/{arrid}/uid/{userid}/val/{val}/devkey/{devkey}
' localhost:60485/Api_v2/updatearrangemang/lookedat/id/2/uid/2/val/ja/devkey/alf?type=json&callback=testar
' localhost:60485/Api_v2/updatearrangemang/arrstat/id/1/uid/2/val/2/devkey/alf?type=json&callback=testar
' localhost:60485/Api_v2/updatearrangemang/pub/id/1/uid/2/val/ja/devkey/alf?type=json&callback=testar
' kulturkatalog.kivdev.se:8080/Api_v2/updatearrangemang/lookedat/id/2/uid/2/val/ja/devkey/alf?type=json&callback=testar
'------------------------------------------------------------------------------------------------------
<EnableCors("*", "*", "*")>
Public Class updatearrangemangController
    Inherits ApiController

    Public Function GetValues() As funkarInfo
        Dim testar As funkarInfo = New funkarInfo
        testar.namn = "Andreas build2"
        testar.devkey = "inga värden"

        Return testar
    End Function

    'Api_v2/{controller}/{cmd}/id/{id}/uid/{uid}/val/{val}/devkey/{devkey}
    Public Function GetValues(cmd As String, id As String, uid As String, val As String, devkey As String) As jsonrootInfo

        Dim returnobject As New jsonMainAnnonsFormat
        Dim arrobj As New updateArrangemang

        If devkeytester(devkey) Then
            returnobject = arrobj.updateArrangemangParametrar(cmd, CInt(id), CInt(uid), val)

        End If

        Dim ret As New jsonrootInfo
        ret.kk_aj_admin = returnobject

        Return ret ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
    End Function

    Public Function PostValue(cmd As String, devkey As String, <FromBody> Logobj As apiupdateArrangemangInfo) As jsonrootInfo


        Dim arrdataoobj As New updateArrangemangInfo
        arrdataoobj.Userid = CInt(Logobj.Userid) '1
        arrdataoobj.Logtypid = 1 'arranganang
        arrdataoobj.Arrid = CInt(Logobj.Arrid) '21
        arrdataoobj.Logstatusid = CInt(Logobj.Logstatusid) '3 godkänd
        arrdataoobj.Logbeskrivning = Logobj.Logbeskrivning ' nu godkänd
        arrdataoobj.UpdValue = Logobj.UpdValue ' 2 godkänd
        arrdataoobj.CmdTyp = "arrstat"

        Dim returnobject As New jsonMainAnnonsFormat
        Dim arrobj As New updateArrangemang

        If devkeytester(devkey) Then
            returnobject = arrobj.updateArrangemangParametrar(arrdataoobj)

        End If

        Dim ret As New jsonrootInfo
        ret.kk_aj_admin = returnobject

        Return ret

    End Function

    Public Function PostValue(cmd As String, val As String, devkey As String, <FromBody> arrobj As EditArrangemangDetailInfo) As jsonrootInfo

        Dim returnobject As New jsonMainAnnonsFormat
        Dim infoobj As New EditArrangemangDetailInfo
        Dim tmparrobj As New addAndDelArrangemangHandler

        If devkeytester(devkey) Then
            returnobject = tmparrobj.EditArrangemang(cmd, val, arrobj)

        End If

        Dim ret As New jsonrootInfo
        ret.kk_aj_admin = returnobject
        Return ret
        'exempel på cmd= byStatus,bySearch


    End Function

    Private Function devkeytester(devkey As String) As Boolean
        If devkey = "alf" Then
            Return True
        Else
            Return False
        End If
    End Function



End Class


