Imports System.Net
Imports System.Web.Http
Imports System.Web.Http.Cors
Imports KulturkatalogenArrangemang
'------------------------------------------------------------------------------------------------------
'kulturkatalog.kivdev.se:8080/Api_v2/search/mainsearch/devkey/alf?type=json&callback=testar
'localhost:60485/Api_v2/search/mainsearch/devkey/alf?type=json&callback=testar
'Kommando:  mainsearch -för sökning i arrangörstyp, konstart, ålder
'           Reslultat visa alla. Dessa värden skall vara "0" :("arrtypid": "0", "konstartid": "0","startyear": "0",) 
'kulturkatalog.kivdev.se:8080/Api_v2/search/freesearch/devkey/alf?type=json&callback=testar
'localhost:60485/Api_v2/search/freesearch/devkey/alf?type=json&callback=testar
'Kommando:  freesearch -för fritextsökning
'           searchstr värden skall vara "textvärde" :("searchstr": "testar") 
'{
'	"arrtypid": "",
'	"cmdtyp": "",
'	"konstartid": "4",
'	"publiceradJaNej": "",
'	"searchstr": "",
'	"startyear": "",
'	"stopyear": ""	
'}

'------------------------------------------------------------------------------------------------------
<EnableCors("*", "*", "*")>
Public Class searchController
    Inherits ApiController

    Public Function GetValues() As funkarInfo
        Dim testar As funkarInfo = New funkarInfo
        testar.namn = "Search publik arragemang TEST"
        testar.devkey = "inga värden"

        Return testar
    End Function

    ' POST Api_v2/{controller}/{cmd}/devkey/{devkey} (create/add) OBS FromBody kan bara ta emot string, så mottagande class måste bara ha string propeties
    Public Function PostValue(cmd As String, devkey As String, <FromBody> searchcmd As commandTypeSearchInfo) As jsonrootInfo
        Dim returnobject As New jsonMainAnnonsFormat
        Dim arrobj As New searchHandler

        If devkeytester(devkey) Then

            Dim searchcommandobj As New commandTypeSearchInfo
            searchcommandobj.arrtypid = CInt(searchcmd.arrtypid)
            searchcommandobj.cmdtyp = cmd
            searchcommandobj.konstartid = CInt(searchcmd.konstartid)
            searchcommandobj.startyear = CInt(searchcmd.startyear)
            searchcommandobj.stopyear = searchcmd.stopyear
            searchcommandobj.searchstr = searchcmd.searchstr
            searchcommandobj.publiceradJaNej = searchcmd.publiceradJaNej

            returnobject = arrobj.searchArrangemang(cmd, searchcommandobj)

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
