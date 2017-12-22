Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Cors

<EnableCors("*", "*", "*")>
Public Class uploadmediaController
    Inherits ApiController

    '  api/<controller>/devkey/key
    'local
    'Private _saveurl As String = "D:\wwwroot\dnndev_v902.me\Portals\0\kulturkatalogenArrImages\"
    'server
    Private _saveurl As String = "D:\websites\kulturkatalogendnn\Portals\0\kulturkatalogenArrImages\"
    Public Function PostValue(devkey As String) As HttpResponseMessage
        Dim returnobject As New jsonMainAnnonsFormat
        Dim infoobj As New EditArrangemangDetailInfo
        Dim tmparrobj As New addAndDelArrangemangHandler
        Dim response As HttpResponseMessage
        Dim cmd As String = ""
        Dim userid As String = ""
        If devkeytester(devkey) Then
            cmd = HttpContext.Current.Request("cmd")

            Select Case cmd
                Case "uploadimg"
                    infoobj.arrid = HttpContext.Current.Request("arrid")
                    tempuploadimage("publik", infoobj.arrid)
                    response = New HttpResponseMessage(HttpStatusCode.OK)
                Case "tmpimg"
                    tempuploadimage("tmp", 0)
                    response = New HttpResponseMessage(HttpStatusCode.OK)
                Case Else
                    '-------------start
                    userid = HttpContext.Current.Request("userid")
                    infoobj.arrid = HttpContext.Current.Request("arrid")
                    infoobj.contentid = HttpContext.Current.Request("contentid")
                    infoobj.innehall = HttpContext.Current.Request("innehall").ToString()
                    infoobj.rubrik = HttpContext.Current.Request("rubrik")
                    infoobj.underrubrik = HttpContext.Current.Request("underrubrik")
                    infoobj.konstformid = HttpContext.Current.Request("konstformid")
                    infoobj.arrangemangtypid = HttpContext.Current.Request("arrangemangtypid")
                    infoobj.utovareid = HttpContext.Current.Request("utovareid")
                    infoobj.publicerad = HttpContext.Current.Request("publicerad")
                    infoobj.MediaUrl = HttpContext.Current.Request("mediaimgageUrl")
                    infoobj.MediaSize = HttpContext.Current.Request("arrsize")
                    infoobj.MediaFoto = HttpContext.Current.Request("arrfoto")
                    infoobj.MediaAlt = HttpContext.Current.Request("arralt")
                    infoobj.Kontaktfornamn = HttpContext.Current.Request("Kontaktfornamn")
                    infoobj.KontaktEfternamn = HttpContext.Current.Request("KontaktEfternamn")
                    infoobj.KontaktTelefon = HttpContext.Current.Request("KontaktTelefon")
                    infoobj.KontaktEpost = HttpContext.Current.Request("KontaktEpost")

                    'Måste skicka med arrangemangid annars går den inte att spara.. måste kunna härleda vart bilden/filen hör
                    If Not String.IsNullOrEmpty(infoobj.arrid) Then
                        If HttpContext.Current.Request.Files.AllKeys.Any() Then
                            ' skickas med i postrequesten.. javascript: var data = new FormData();  Data.append("arrid", $('#arrid').val());

                            'Dim saveurl As String = "D:\wwwroot\dnndev_v902.me\Portals\0\kulturkatalogenArrImages\"
                            Dim saveurl As String = _saveurl
                            Dim weburl As String = "/Portals/0/kulturkatalogenArrImages/"
                            ' Get the uploaded image from the Files collection
                            Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")

                            If httpPostedFile IsNot Nothing Then
                                ' Validate the uploaded image(optional)
                                'Dim uploadedfileSrc As String = saveurl & Path.GetFileName(httpPostedFile.FileName)
                                Dim uploadedfileSrc As String = saveurl & infoobj.arrid & "_" & httpPostedFile.FileName
                                infoobj.MediaUrl = httpPostedFile.FileName
                                'infoobj.MediaUrl = weburl & infoobj.arrid & "_" & httpPostedFile.FileName
                                ' Get the complete file path
                                'Dim fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName)
                                'Dim fileSavePath = Path.Combine(saveurl, uploadedfileSrc)

                                ' Save the uploaded file to "UploadedFiles" folder
                                httpPostedFile.SaveAs(uploadedfileSrc)
                                'returnobject = tmparrobj.EditArrangemang(cmd, Val, arrobj)

                            End If
                        End If
                        returnobject = tmparrobj.EditArrangemang(cmd, userid, infoobj)

                    End If

                    Dim ret As New jsonrootInfo
                    ret.kk_aj_admin = returnobject


                    response = New HttpResponseMessage(HttpStatusCode.Created)
                    '-------------stopp
            End Select

        Else
            response = New HttpResponseMessage(HttpStatusCode.BadRequest)
        End If

        Return response



    End Function
    Private Function devkeytester(devkey As String) As Boolean
        If devkey = "alf" Then
            Return True
        Else
            Return False
        End If
    End Function


    Private Function tempuploadimage(val As String, arrid As String) As String
        Dim tempurl As String = ""

        If HttpContext.Current.Request.Files.AllKeys.Any() Then
            ' skickas med i postrequesten.. javascript: var data = new FormData();  Data.append("arrid", $('#arrid').val());
            Dim saveurl As String = _saveurl
            'Dim saveurl As String = "D:\websites\kulturkatalogendnn\Portals\0\kulturkatalogenArrImages\"
            Dim weburl As String = "/Portals/0/kulturkatalogenArrImages/"
            ' Get the uploaded image from the Files collection

            If val = "tmp" Then
                saveurl &= "tmp\"
                weburl &= "tmp/"
            End If

            Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")

            If httpPostedFile IsNot Nothing Then
                Dim uploadedfileSrc As String = ""
                ' Validate the uploaded image(optional)
                'Dim uploadedfileSrc As String = saveurl & Path.GetFileName(httpPostedFile.FileName)
                If val = "tmp" Then
                    uploadedfileSrc = saveurl & "_" & httpPostedFile.FileName
                Else
                    uploadedfileSrc = saveurl & arrid & "_" & httpPostedFile.FileName
                End If


                tempurl = weburl & "_" & httpPostedFile.FileName
                    ' Get the complete file path
                    'Dim fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName)
                    'Dim fileSavePath = Path.Combine(saveurl, uploadedfileSrc)

                    ' Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(uploadedfileSrc)
                    'returnobject = tmparrobj.EditArrangemang(cmd, Val, arrobj)

                End If
            End If

        Return tempurl

    End Function

End Class
