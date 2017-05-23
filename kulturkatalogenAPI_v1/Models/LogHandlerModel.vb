Imports KulturkatalogenLog
Public Class LogHandlerModel
    Private _loghandlercontroller As New kulturkatalogLogController
    Public Function getloggs(cmd As String, param As Integer) As jsonLogReturnInfo
        Dim tmploginfo As New logInfo
        Select Case cmd
            Case "byarrid"
                tmploginfo.Arrid = param

            Case "bylogtyp"
                tmploginfo.logtyp = param

            Case "bystatus"
                tmploginfo.Statustypid = param
            Case "byuser"
            Case "byutovare"
            Case "bylogid"
        End Select

        Dim test As List(Of logInfo) = _loghandlercontroller.getlogEvent(cmd, tmploginfo)

        Return converttologinfoapi(test)


    End Function

#Region "CRUD"
    Public Function addlog(crudlog As crudLogInfo) As Boolean
        Dim tmpcrudobj As New logInfo
        Dim ret As Boolean = False

        Try
            tmpcrudobj.Arrid = crudlog.Arrid
            tmpcrudobj.logtypid = crudlog.Logtypid
            tmpcrudobj.Statustypid = crudlog.Statustypid
            tmpcrudobj.Beskrivning = crudlog.Beskrivning
            tmpcrudobj.ChangebyUserid = crudlog.LogUserid

            If _loghandlercontroller.addlogEvent(tmpcrudobj) Then
                ret = True
            End If
        Catch ex As Exception
            ret = False
        End Try

        Return ret

    End Function


    Public Function logger(arrid As Integer, logtypid As Integer, beskrivning As String, userid As Integer, statustyp As Integer) As Boolean
        Dim log As New crudLogInfo
        Try
            log.Arrid = arrid
            log.Logtypid = logtypid 'arrangemangevent
            log.Statustypid = statustyp 'Event
            log.Beskrivning = beskrivning
            log.LogUserid = userid
            addlog(log)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    '
#End Region
    Private Function converttologinfoapi(listinfo As List(Of logInfo)) As jsonLogReturnInfo
        Dim retobj As New jsonLogReturnInfo
        Dim retitemlist As New List(Of logItemInfo)

        Try

            For Each x In listinfo
                Dim i As New logItemInfo

                i.logid = x.logid
                i.logtypid = x.logtypid
                i.logtyp = x.logtyp
                i.Arrid = x.Arrid
                i.Arrrubrik = x.Arrrubrik
                i.Arrutovare = x.Arrutovare
                i.Statustypid = x.Statustypid
                i.Statustyp = x.Statustyp
                i.ChangebyUserid = x.ChangebyUserid
                i.ChangebyUsernamn = x.ChangebyUsernamn
                i.Datum = x.Datum
                i.Beskrivning = x.Beskrivning

                retitemlist.Add(i)
            Next
            retobj.Logcount = retitemlist.Count
            retobj.Logitemlist = retitemlist
            retobj.Logstatus = "Response ok"

        Catch ex As Exception
            retobj.Logcount = 0
            retobj.Logitemlist = New List(Of logItemInfo)
            retobj.Logstatus = "Error in convert to json"
        End Try

        Return retobj
    End Function


End Class
