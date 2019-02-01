Imports System.IO
Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports kulturkatalogenUtovare
'------------------------------------------------------------------------------------------------------
'exempel call GET:
'lista alla: -------------------------------------------------------------------------------------------
'localhost:60485/Api_v3/utovare/list/user/2/val/1/devkey/alf?type=json
'detalj: ----------------------------------------------------------------------------------------------
'localhost:60485/Api_v3/utovare/detail/user/2/val/1/devkey/alf?type=json
'------------------------------------------------------------------------------------------------------
'formsearch: ------------------------------------------------------------------------------------------
'localhost:60485/Api_v3/utovare/searchForm/user/test@test.se/val/52330/devkey/alf?type=json
'------------------------------------------------------------------------------------------------------


<EnableCors("*", "*", "*")>
Public Class utovareController
    Inherits ApiController

    Private _utovarobj As New utovareHandler
    Public Function GetValues() As funkarInfo
        Dim testar As funkarInfo = New funkarInfo
        testar.namn = "Andreas build2"
        testar.devkey = "inga värden"

        Return testar
    End Function
    Public Function GetValues(cmd As String, usr As String, val As String, devkey As String) As jsonUtovareReturnFormatInfo

        Dim returnobject As New jsonUtovareReturnFormatInfo

        If devkeytester(devkey) Then
            returnobject.kk_aj_admin = _utovarobj.getutovare(cmd, usr, val)
        End If

        Return returnobject

    End Function

    Public Function GetValues(cmd As String, uid As String, arrstatus As String, val As String, devkey As String) As jsonrootInfo
        Dim ret As New jsonrootInfo


        Return ret
    End Function

    Public Function PostValue(cmd As String, usr As String, devkey As String) As jsonUtovareReturnFormatInfo
        Dim returnobject As New jsonUtovareReturnFormatInfo
        Dim reqobj = HttpContext.Current
        Dim utovareobj As New utovareDetailInfo

        If devkeytester(devkey) Then

            utovareobj.UtovarID = reqobj.Request("UtovarID")
            utovareobj.Organisation = reqobj.Request("Organisation")
            utovareobj.Fornamn = reqobj.Request("Fornamn")
            utovareobj.Efternamn = reqobj.Request("Efternamn")
            utovareobj.Telefon = reqobj.Request("Telefon")
            utovareobj.Adress = reqobj.Request("Adress")
            utovareobj.Postnr = reqobj.Request("Postnr")
            utovareobj.Ort = reqobj.Request("Ort")
            utovareobj.Epost = reqobj.Request("Epost")
            utovareobj.Kommun = reqobj.Request("Kommun")
            utovareobj.Weburl = reqobj.Request("Weburl")
            utovareobj.Beskrivning = reqobj.Request("Beskrivning")

            If HttpContext.Current.Request.Files.AllKeys.Any() Then
                ' Get the uploaded image from the Files collection
                Dim httpPostedFile = HttpContext.Current.Request.Files("Bild")

                If httpPostedFile IsNot Nothing Then
                    ' Validate the uploaded image(optional)
                    ' Get the complete file path 
                    ' den andra urlen som skall ändras är här: uploadmediaController.vb
                    'Dim fileSavePath = Path.Combine("D:\wwwroot\dnndev_v902.me\Portals\0\kulturkatalogUtovareImages\", httpPostedFile.FileName)
                    'Dim webserverImgUrl = "/Portals/0/kulturkatalogUtovareImages/" & httpPostedFile.FileName

                    Dim fileSavePath = Path.Combine("D:\websites\kulturkatalogenvast\kulturkatalogendnn\Portals\0\kulturkatalogenArrImages\", httpPostedFile.FileName)
                    Dim webserverImgUrl = "/Portals/0/kulturkatalogUtovareImages/" & httpPostedFile.FileName

                    utovareobj.Bild = webserverImgUrl
                    ' Save the uploaded file to "UploadedFiles" folder
                    Try
                        httpPostedFile.SaveAs(fileSavePath)
                        utovareobj.Bild = webserverImgUrl
                    Catch ex As Exception
                        utovareobj.Bild = ""
                    End Try

                End If
            End If

            returnobject.kk_aj_admin = _utovarobj.crudutovare(cmd, usr, utovareobj)

        End If

        Return returnobject
    End Function

    Public Function DeleteValue(arrid As String, userid As String, devkey As String) As jsonrootInfo
        Dim ret As New jsonrootInfo


        Return ret

    End Function

    Private Function devkeytester(devkey As String) As Boolean
        If devkey = "alf" Then
            Return True
        Else
            Return False
        End If
    End Function



End Class


