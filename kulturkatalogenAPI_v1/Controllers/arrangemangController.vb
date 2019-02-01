Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports KulturkatalogenArrangemang
'------------------------------------------------------------------------------------------------------
' apianrop exempel för att få ett arrangemangs loggar:
' arrangemang har 2 anrop: bystatus, bysearch
' userid måste skickas med: uid = userid
' arrangemangtyp måste anges(ny,godkänd, nekad, arkiv) typ= arrtypid
' vid sök måster val = sökord
' localhost:60485/Api_v2/arrangemang/bystatus/uid/2/typ/4/devkey/alf?type=json&callback=testar
' Search anrop: (söker efter sökordet: "test")
' localhost:60485/Api_v2/arrangemang/bysearch/uid/2/typ/1/val/test/devkey/alf?type=json&callback=anrop
' kulturkatalog.kivdev.se:8080/Api_v2/arrangemang/bysearch/uid/2/typ/1/val/test/devkey/alf?type=json&callback=testar
' Hämta arrangemang Detaljdata för ett arrangemang:
' search anrop: command= details, userid= uid, typ = arrid,
'/Api_v2/arrangemang/{command}/uid/{uid}/typ/{arrid}/devkey/alf?type=json&callback=testar
'localhost:60485/Api_v2/arrangemang/details/uid/3/typ/3/devkey/alf?type=json&callback=testar
'hämta latest arrangemang
' localhost:60485/Api_v2/arrangemang/bylatest/uid/2/typ/0/val/top10/devkey/alf?type=json&callback=testar
'Vid sökning via utövarid: uid=Userid6 , val= utövarid
'localhost:60485/Api_v2/arrangemang/byutovare/uid/1/typ/1/val/211/devkey/alf?type=json&callback=testar
'------------------------------------------------------------------------------------------------------
<EnableCors("*", "*", "*")>
Public Class ArrangemangController
    Inherits ApiController

    Public Function GetValues() As funkarInfo
        Dim testar As funkarInfo = New funkarInfo
        testar.namn = "Andreas build2"
        testar.devkey = "inga värden"

        Return testar
    End Function
    Public Function GetValues(cmd As String, uid As String, arrstatus As String, devkey As String) As jsonrootInfo

        Dim returnobject As New jsonMainAnnonsFormat
        Dim arrobj As New arrangemangHandler

        If devkeytester(devkey) Then
            returnobject = arrobj.getArrangemang(cmd, arrstatus, uid, "")

        End If
        Dim ret As New jsonrootInfo
        ret.kk_aj_admin = returnobject

        Return ret ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
    End Function

    Public Function GetValues(cmd As String, uid As String, arrstatus As String, val As String, devkey As String) As jsonrootInfo
        Dim returnobject As New jsonMainAnnonsFormat
        Dim arrobj As New arrangemangHandler

        If devkeytester(devkey) Then
            returnobject = arrobj.getArrangemang(cmd, arrstatus, uid, val)

        End If

        Dim ret As New jsonrootInfo
        ret.kk_aj_admin = returnobject

        Return ret ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
    End Function



    ' POST Api_v2/{controller}/{cmd}/devkey/{devkey} (create/add) OBS FromBody kan bara ta emot string, så mottagande class måste bara ha string propeties
    Public Function PostValue(devkey As String, <FromBody> Logobj As arrangemangInfo) As jsonrootInfo
        Dim returnobject As New jsonMainAnnonsFormat
        Dim infoobj As New KulturkatalogenArrangemang.arrangemangInfo
        Dim arrobj As New addAndDelArrangemangHandler
        Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")
        If devkeytester(devkey) Then

            returnobject = arrobj.addArrangemang("add", Logobj)

        End If

        Dim ret As New jsonrootInfo
        ret.kk_aj_admin = returnobject
        Return ret
        'exempel på cmd= byStatus,bySearch

    End Function


    ' DELETE "Api_v2/{controller}/{userid}/del/{arrid}/devkey/{devkey}", (create/add) OBS FromBody kan bara ta emot string, så mottagande class måste bara ha string propeties
    Public Function DeleteValue(arrid As String, userid As String, devkey As String) As jsonrootInfo
        Dim returnobject As New jsonMainAnnonsFormat
        Dim infoobj As New KulturkatalogenArrangemang.arrangemangInfo
        Dim arrobj As New addAndDelArrangemangHandler

        If devkeytester(devkey) Then
            returnobject = arrobj.delArrangemang("del", arrid, userid)

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

