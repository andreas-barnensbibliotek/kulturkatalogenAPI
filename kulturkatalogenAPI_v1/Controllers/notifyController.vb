Imports System.Net
Imports System.Web.Http
    Imports System.Web.Http.Cors
'------------------------------------------------------------------------------------------------------
' apianrop exempel för att få Notifieringar loggar:
' notify har ett command anrop: get
' userid måste skickas med: id = userid
' localhost:60485/Api_v2/notify/get/id/2/devkey/alf?type=json&callback=testar
' kulturkatalog.kivdev.se:8080/Api_v2/notify/get/id/2/devkey/alf?type=json&callback=testar
'------------------------------------------------------------------------------------------------------
<EnableCors("*", "*", "*")>
Public Class notifyController
    Inherits ApiController

    Public Function GetValues() As funkarInfo
        Dim testar As funkarInfo = New funkarInfo
        testar.namn = "Andreas build2"
        testar.devkey = "inga värden"

        Return testar
    End Function

    '"Api_v2/{controller}/{cmd}/id/{id}/devkey/{devkey}",
    Public Function GetValues(cmd As String, id As String, devkey As String) As jsonRootNotifyInfo

        Dim returnobject As New apiNotifieringarInfo
        Dim notobj As New notifyHandler

        Dim ret As New jsonRootNotifyInfo
        If devkeytester(devkey) Then
            returnobject = notobj.getnotifieringar(id)
            ret.kk_aj_admin = returnobject
        Else
            ret.kk_aj_admin.Status = "Fel behörighet!"
        End If

        Return ret
    End Function

    Private Function devkeytester(devkey As String) As Boolean
        Dim ret As Boolean = False

        If devkey = "alf" Then
            ret = True
        End If
        Return ret

    End Function



End Class

