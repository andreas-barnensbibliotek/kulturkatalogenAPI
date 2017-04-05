Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors

<EnableCors("*", "*", "*")>
Public Class LogController
    Inherits ApiController

    Private _loghandlerobj As New LogHandlerModel
    ' GET api/<controller>/devkey/key
    Public Function GetValues() As funkarInfo
        Dim testar As funkarInfo = New funkarInfo
        testar.namn = "Andreas build2"
        testar.devkey = "inga värden"

        Return testar ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
    End Function
    Public Function GetValues(cmd As String, id As Integer, devkey As String) As jsonMainLogReturnInfo


        Dim returnobject As New jsonMainLogReturnInfo
        Dim logobj As New jsonLogReturnInfo

        If devkeytester(devkey) Then

            logobj = _loghandlerobj.getloggs(cmd, id)
            'Return logobj.getlog(cmd)
        End If

        returnobject.kk_aj_admin = logobj

        Return returnobject ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
    End Function

    ' POST Api_v2/{controller}/add/devkey/{devkey} (create/add)
    Public Function PostValue(devkey As String, <FromBody> Logobj As Object) As String


        Dim infoobj As New crudLogInfo
        infoobj.logUserid = Logobj.logUserid
        infoobj.logtypid = Logobj.logtypid
        infoobj.Arrid = Logobj.Arrid
        infoobj.Statustypid = Logobj.Statustypid
        infoobj.Beskrivning = Logobj.Beskrivning

        If (_loghandlerobj.addlog(Logobj)) Then
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