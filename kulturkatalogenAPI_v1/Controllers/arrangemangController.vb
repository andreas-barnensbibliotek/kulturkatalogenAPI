﻿Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
'------------------------------------------------------------------------------------------------------
' apianrop exempel för att få ett arrangemangs loggar:
' localhost:60485/Api_v2/log/byarrid/id/1/devkey/alf?type=json&callback=testar
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

    Public Function GetValues(cmd As String, uid As String, arrstatus As String, val As String, devkey As String) As jsonMainAnnonsFormat

        Dim returnobject As New jsonMainAnnonsFormat
        Dim arrobj As New arrangemangHandler

        If devkeytester(devkey) Then
            returnobject = arrobj.getArrangemang(cmd, arrstatus, uid, val)

        End If

        Return returnobject ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
    End Function

    ' POST Api_v2/{controller}/add/devkey/{devkey} (create/add) OBS FromBody kan bara ta emot string, så mottagande class måste bara ha string propeties
    Public Function PostValue(devkey As String, <FromBody> Logobj As crudloginfoapi) As String

        Dim infoobj As New crudLogInfo
        infoobj.LogUserid = CInt(Logobj.LogUserid)
        infoobj.Logtypid = CInt(Logobj.Logtypid)
        infoobj.Arrid = CInt(Logobj.Arrid)
        infoobj.Statustypid = CInt(Logobj.Statustypid)
        infoobj.Beskrivning = Logobj.Beskrivning

        If (1 = 1) Then
            Return "{sucess:true}"
        Else
            Return "{sucess:false}"
        End If

    End Function

    Private Function devkeytester(devkey As String) As Boolean
        If devkey = "alf" Then
            Return True
        Else
            Return False
        End If
    End Function



End Class

