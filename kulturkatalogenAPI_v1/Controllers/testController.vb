Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Cors

<EnableCors("*", "*", "*")>
Public Class testController
    Inherits ApiController

    ' GET api/<controller>/devkey/key
    Public Function GetValues() As List(Of utovarelistInfo)

        Dim ret As New List(Of utovarelistInfo)

        Dim testar As utovarelistInfo = New utovarelistInfo
        testar.utovarid = "1"
        testar.utovare = "nisse"
        ret.Add(testar)
        Dim testar2 As utovarelistInfo = New utovarelistInfo
        testar2.utovarid = "2"
        testar2.utovare = "Lisa"
        ret.Add(testar2)

        Dim testar3 As utovarelistInfo = New utovarelistInfo
        testar3.utovarid = "3"
        testar3.utovare = "Klara"
        testar3.selected = "ja"
        ret.Add(testar3)

        Return ret

        'Return testar ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"

    End Function
    Public Function GetValues(devkey As String) As HttpResponseMessage
        'Dim testar As funkarInfo = New funkarInfo
        'testar.namn = "Andreas ny build"
        'testar.devkey = devkey

        'Return testar ' "{'Booklist':[{'Bookid':11674,'title':'Pojken och hunden','isbn':'978-91-28-10697-9','Forfattare':[{'bookid':11674,'creatorid':5118,'namn':'Siw Widerberg','CreatorRollID':1}],'Illustrator':null,'Published':'2010','forlag':null,'Categories':[{'bookid':11674,'CategoryID':3,'catnamn':null}],'ExtraCategorier':[],'Amnen':null,'Serie':null,'Serienr':null,'Subtitle':null,'Easyread':0,'TotVotes':0,'BookReview':null,'BokomslagURL':'http://www.barnensbibliotek.com/Portals/0/bokomslag/978-91-28-10697-9.jpg','MediaUrler':null,'status':0}],'Totalbookitems':48,'requestedpage':'4','requestedpagecount':12,'Morepageleft':'ja','Totalpages':4,'Status':'ok'}"
        ' Get the uploaded image from the Files collection
        Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")

        If httpPostedFile IsNot Nothing Then
            ' Validate the uploaded image(optional)

            ' Get the complete file path
            Dim fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName)

            ' Save the uploaded file to "UploadedFiles" folder
            httpPostedFile.SaveAs(fileSavePath)
        End If

        Dim response = New HttpResponseMessage(HttpStatusCode.Created)
        Return response
    End Function



    Public Function PostValue(update As testarinfo) As HttpResponseMessage
        Dim test As testarinfo = update

        Dim response = New HttpResponseMessage(HttpStatusCode.Created)
        Return response
    End Function
    Public Function PostValue(devkey As String) As HttpResponseMessage


        Dim test As String = HttpContext.Current.Request("box")
        If HttpContext.Current.Request.Files.AllKeys.Any() Then
            ' Get the uploaded image from the Files collection
            Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")

            If httpPostedFile IsNot Nothing Then
                ' Validate the uploaded image(optional)

                ' Get the complete file path
                Dim fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName)

                ' Save the uploaded file to "UploadedFiles" folder
                httpPostedFile.SaveAs(fileSavePath)
            End If
        End If

        Dim response = New HttpResponseMessage(HttpStatusCode.Created)
        Return response
    End Function
    Public Function PostValue(t As String, devkey As String) As HttpResponseMessage

        Dim test As String = HttpContext.Current.Request("box")
        If HttpContext.Current.Request.Files.AllKeys.Any() Then
            ' Get the uploaded image from the Files collection
            Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")

            If httpPostedFile IsNot Nothing Then
                ' Validate the uploaded image(optional)

                ' Get the complete file path
                Dim fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName)

                ' Save the uploaded file to "UploadedFiles" folder
                httpPostedFile.SaveAs(fileSavePath)
            End If
        End If

        Dim response = New HttpResponseMessage(HttpStatusCode.Created)
        Return response
    End Function
End Class
