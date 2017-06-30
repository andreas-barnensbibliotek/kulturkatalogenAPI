Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Cors

<EnableCors("*", "*", "*")>
Public Class uploadmediaController
    Inherits ApiController

    '  api/<controller>/devkey/key

    Public Function PostValue(devkey As String) As HttpResponseMessage
        Dim response As HttpResponseMessage
        'Måste skicka med arrangemangid annars går den inte att spara.. måste kunna härleda vart bilden/filen hör
        Dim arrid As String = HttpContext.Current.Request("arrid") ' skickas med i postrequesten.. javascript: var data = new FormData();  Data.append("arrid", $('#arrid').val());

        If Not String.IsNullOrEmpty(arrid) Then
            If HttpContext.Current.Request.Files.AllKeys.Any() Then
                ' Get the uploaded image from the Files collection
                Dim httpPostedFile = HttpContext.Current.Request.Files("UploadedImage")

                If httpPostedFile IsNot Nothing Then
                    ' Validate the uploaded image(optional)
                    Dim uploadedfileSrc As String = "D:\slask\" & Path.GetFileName(httpPostedFile.FileName)

                    ' Get the complete file path
                    'Dim fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadedFiles"), httpPostedFile.FileName)
                    Dim fileSavePath = Path.Combine("D:\slask", uploadedfileSrc)

                    ' Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath)
                End If
            End If
            response = New HttpResponseMessage(HttpStatusCode.Created)
        Else
            response = New HttpResponseMessage(HttpStatusCode.BadRequest)
        End If

        Return response
    End Function

End Class
