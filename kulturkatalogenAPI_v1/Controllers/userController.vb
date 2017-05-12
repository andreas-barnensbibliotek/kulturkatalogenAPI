Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors

'------------------------------------------------------------------------------------------------------
' apianrop exempel för att få användaruppgifter:
' commando måste skickas med: usrinfo
' userid måste skickas med: id = userid
' localhost:60485/Api_v2/user/usrinfo/id/2/devkey/alf?type=json&callback=testar
' kulturkatalog.kivdev.se:8080/Api_v2/user/usrinfo/id/2/devkey/alf?type=json&callback=testar
'------------------------------------------------------------------------------------------------------
<EnableCors("*", "*", "*")>
Public Class userController
    Inherits ApiController

    Public Function GetValues(cmd As String, id As String, devkey As String) As jsonuserbaseInfo
        Dim ret As New jsonuserbaseInfo
        Dim usrobj As New userHandler

        If devkeytester(devkey) Then
            ret.kk_aj_admin = usrobj.getuserdata(cmd, id)
        Else
            ret.kk_aj_admin.status = "Fel behörighet!"
        End If

        Return ret ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
    End Function

    Private Function devkeytester(devkey As String) As Boolean
        If devkey = "alf" Then
            Return True
        Else
            Return False
        End If
    End Function



End Class

