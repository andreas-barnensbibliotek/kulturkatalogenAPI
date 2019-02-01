Imports KulturkatalogenArrangemang

'anrop cmd: byt status(ny,godkänd,nekad, arkiverad):"arrstat", läst post: "lookedat", publicerad: "pub"
Public Class updateArrangemang
    Private _logobj As New LogHandlerModel
    Private _mailobj As New mailnewarrangemangHandler
    Enum statusevent
        Ny = 1
        Borttagen = 10
        handelse = 9 'event
        Andrad = 5
        arkiverad = 8
    End Enum
    Enum Logtyp
        Arrangemangevent = 1
        Systemevent = 2
        Searchevent = 3
    End Enum
    Public Function updateArrangemangParametrar(cmd As String, arrid As Integer, usrid As Integer, val As String) As jsonMainAnnonsFormat
        Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand

        retobj.Ansokningstyp = "Update"
        tmpobj.Status = "Fel vid anrop av uppdateringen"

        If Not String.IsNullOrEmpty(cmd) Then
            If Not String.IsNullOrEmpty(val) Then
                cmdtyp.CmdTyp = cmd
                cmdtyp.Arrid = arrid
                cmdtyp.arrUserid = usrid
                cmdtyp.UpdValue = val

                Dim updatecmdobj As New kk_aj_arr_MainController
                tmpobj = updatecmdobj.updateArrPropeties(cmdtyp)

            End If
        End If

        retobj.status = tmpobj.Status
        Select Case val
            Case 4
                If tmpobj.Status.IndexOf("Fel") = -1 Then
                    _logobj.logger(arrid, Logtyp.Arrangemangevent, "ARKIVERAD " & tmpobj.Status, usrid, statusevent.arkiverad)
                Else
                    _logobj.logger(arrid, Logtyp.Arrangemangevent, "Fel vid arkivering!", usrid, statusevent.handelse)
                End If
            Case Else
                _logobj.logger(arrid, Logtyp.Arrangemangevent, tmpobj.Status, usrid, statusevent.Andrad)

        End Select

        Return retobj

    End Function

    Public Function updateArrangemangParametrar(arrobj As updateArrangemangInfo) As jsonMainAnnonsFormat
        Dim retobj As New jsonMainAnnonsFormat
        Dim tmpobj As New arrangemangcontainerInfo
        Dim cmdtyp As New updatearrcommand

        retobj.Ansokningstyp = "Update"
        tmpobj.Status = "Fel vid anrop av uppdateringen"

        If Not String.IsNullOrEmpty(arrobj.Logbeskrivning) Then
            If Not arrobj.Logstatusid = 2 Then

                If arrobj.Userid > 0 Then
                    If arrobj.Arrid > 0 Then
                        cmdtyp.CmdTyp = arrobj.CmdTyp
                        cmdtyp.Arrid = arrobj.Arrid
                        cmdtyp.arrUserid = arrobj.Userid
                        cmdtyp.UpdValue = arrobj.UpdValue
                    End If

                    Dim updatecmdobj As New kk_aj_arr_MainController
                    tmpobj = updatecmdobj.updateArrPropeties(cmdtyp)

                End If

                retobj.status = tmpobj.Status

                If retobj.status.IndexOf("Fel") = -1 Then

                    If arrobj.Logstatusid = 3 Or arrobj.Logstatusid = 4 Then ' 3 godkänd eller 4 nekad 
                        _mailobj.sendmail(arrobj.UpdValue, arrobj.Arrid, arrobj.Logbeskrivning)
                    Else
                        retobj.status = "Arrangemanget är tillagt som under bearbetning i arrangemangsloggen"
                    End If
                End If

            Else 'Om logtypid = 2 då är det en kommentar och skall inte ändra något bara logga
                retobj.status = "En kommentar/granska är tillagd till arrangemangsloggen"

            End If

        End If

        _logobj.logger(arrobj.Arrid, arrobj.Logtypid, arrobj.Logbeskrivning, arrobj.Userid, arrobj.Logstatusid)

        Return retobj

    End Function

End Class
