
Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports kulturkatalogenUtovare
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

    Public Function PostValue(cmd As String, usr As String, devkey As String, <FromBody> utovareobj As utovareDetailInfo) As jsonUtovareReturnFormatInfo
        Dim returnobject As New jsonUtovareReturnFormatInfo

        If devkeytester(devkey) Then
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


