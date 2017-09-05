Imports kulturkatalogenUtovare
Public Class utovareHandler

    Private _utovareobj As New utovareMainController

    Public Function getutovareautocompletelist(searchstr As String) As utovaredataInfo

        Dim retobj As New utovaredataInfo
        Try
            retobj.Utovarelist = _utovareobj.getutovarebyautocomplete(searchstr)
            retobj.antalutovare = retobj.Utovarelist.Count
            retobj.Status = "autocomplete levererar för denna sökning: " & searchstr
        Catch ex As Exception
            retobj.Status = "Något blev fel vid autocomplete!"
        End Try
        Return retobj
    End Function

    Public Function getutovare(cmd As String, usr As String, val As String) As utovaredataInfo
        Dim retobj As New utovaredataInfo

        Try
            Select Case cmd
                Case "list"
                    retobj.Utovarelist = _utovareobj.getutovareAll()
                    retobj.antalutovare = retobj.Utovarelist.Count
                    retobj.cmdresponse = "list"
                    retobj.Status = "Lista av alla utövare"

                Case "detail"
                    Dim id As Integer = CInt(val)
                    Dim tmplist As New List(Of utovareDetailInfo)
                    tmplist.Add(_utovareobj.getutovareDetail(id))

                    retobj.Utovarelist = tmplist
                    retobj.antalutovare = retobj.Utovarelist.Count
                    retobj.cmdresponse = "detail"
                    retobj.Status = "Utövaredetalj av utövare id:" & val

                Case "searchForm"
                    retobj.Utovarelist = _utovareobj.getutovarebyFormSearch(usr, val)
                    retobj.antalutovare = retobj.Utovarelist.Count
                    retobj.cmdresponse = "FormSearchdetail"
                    retobj.Status = "Utövaredetalj av utövare id:" & val
            End Select

        Catch ex As Exception
            retobj.cmdresponse = "error" & cmd
            retobj.Status = "Något blev fel vid hämtning av utövare. cmd= " & cmd
        End Try

        Return retobj
    End Function

    Public Function crudutovare(cmd As String, userid As String, utovarinfo As utovareDetailInfo) As utovaredataInfo
        Dim retobj As New utovaredataInfo
        Dim tmplist As New List(Of utovareDetailInfo)

        Try
            Select Case cmd
                Case "addutovare"
                    Dim tmputovare As New utovareDetailInfo
                    tmputovare = _utovareobj.addutovare(utovarinfo)
                    If tmputovare.UtovarID = 0 Then
                        retobj.cmdresponse = "exists"
                        retobj.Status = "User Exists"
                    Else
                        retobj.cmdresponse = "added"
                        retobj.Status = "Utövaredetalj av nyutövare id:" & tmputovare.UtovarID
                    End If
                    tmplist.Add(tmputovare)

                Case "editutovare"
                    tmplist.Add(_utovareobj.Editutovare(utovarinfo))
                    retobj.cmdresponse = "edited"
                    retobj.Status = "Utövaredetalj av ändradutövare med id:" & tmplist(0).UtovarID

                Case "delutovare"
                    Dim userobj As New userHandler
                    If userobj.chkUserRoll(userid, 6) Then 'roll 6 = KulturkatalogenSuperUser
                        If _utovareobj.delutovare(utovarinfo.UtovarID) Then
                            retobj.cmdresponse = "deleted"
                            retobj.Status = "Deleted, Utövaredetalj id:" & utovarinfo.UtovarID & " är bort tagen!"
                        Else
                            retobj.cmdresponse = "error"
                            retobj.Status = "Error, Något blev fel när utövaredetalj med id:" & utovarinfo.UtovarID & " skulle tas bort!"
                        End If
                    Else
                        retobj.cmdresponse = "notauthorised"
                        retobj.Status = "Error 10, DU har inte behörighet att tabort utövare!"

                    End If

                    tmplist.Add(New utovareDetailInfo)
            End Select

            retobj.Utovarelist = tmplist
            retobj.antalutovare = retobj.Utovarelist.Count


        Catch ex As Exception
            retobj.Status = "Något blev fel vid hantering av utövare. cmd= " & cmd
        End Try

        Return retobj

    End Function

End Class
