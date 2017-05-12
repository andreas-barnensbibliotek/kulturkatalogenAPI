Imports kulturkatalogenUser
Public Class userHandler
    Public Function getuserdata(cmd As String, userid As Integer) As jsonuserInfo
        Dim retobj As New jsonuserInfo

        Try
            retobj.status = "Fel kommando!"
            Select Case cmd
                Case "usrinfo"
                    retobj.userinfo = getuserdata(userid)
                    retobj.status = "userinfo is collected!"
            End Select

        Catch ex As Exception
            retobj.status = "Fel vid hämtning av userinfo"
        End Try

        Return retobj
    End Function

    Private Function getuserdata(userid As Integer) As userdataInfo

        Dim usrobj As New userdataInfo
        Dim obj As New kk_aj_katalogenUsers

        Dim katobj As katalogenUserInfo = obj.getUserdata(userid)

        usrobj.useravatar = katobj.useravatar
        usrobj.userefternamn = katobj.userefternamn
        usrobj.userepost = katobj.userepost
        usrobj.userfornamn = katobj.userfornamn
        usrobj.userid = katobj.Userid
        usrobj.userinfoheader = katobj.userinfoheader
        usrobj.userinfotext = katobj.userinfotext 'Regex.Replace(System.Net.WebUtility.HtmlDecode(katobj.userinfotext), "<.*?>", "") 'rensa html från strängen
        usrobj.username = katobj.Username
        usrobj.usertel = katobj.usertel

        Dim rolllist As New List(Of apiuserrollistInfo)
        For Each itm In katobj.userrollList
            Dim rollobj As New apiuserrollistInfo
            rollobj.userrollid = itm.userrollid
            rollobj.userrollname = itm.userrollname
            rolllist.Add(rollobj)
        Next
        usrobj.userrolls = rolllist

        Return usrobj

    End Function

End Class
