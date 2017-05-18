Imports KulturkatalogenArrangemang
Public Class arrangemangHandler

    Private _arrObj As New kk_aj_arr_MainController
    Private _converttoJson As New convertArrtoJsonMainAnnonsFormat
    Public Function getArrangemang(cmd As String, arrstatus As String, usrid As String, val As String) As jsonMainAnnonsFormat
        'exempel på cmd= byStatus,bySearch

        Dim tmpArrinfo As New arrangemangcontainerInfo
        Dim cmdtyp As New commandTypeInfo

        cmdtyp.CmdTyp = cmd
        cmdtyp.ArrStatusTyp = arrstatus
        cmdtyp.CmdtypUserid = usrid
        cmdtyp.cmdValue = val
        cmdtyp.Visningsperiod = Date.Now.Year.ToString
        tmpArrinfo = _arrObj.getArrangemang(cmdtyp)

        Return _converttoJson.convertToArrangemangInfoApi(tmpArrinfo)

    End Function


End Class
