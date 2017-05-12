Imports kulturkatalogenUser
Public Class notifyHandler
    Private _notobj As New kk_aj_katalogenUsers

    Public Function getnotifieringar(userid As Integer) As apiNotifieringarInfo
        Dim retobj As New apiNotifieringarInfo
        Dim libobj As notifieringarMainInfo = _notobj.getallaNoteifieringar(userid)

        retobj.topmessages = fyllnotigyitems(libobj.MessList)
        retobj.topmessagescount = retobj.topmessages.Count
        retobj.topnotification = fyllnotigyitems(libobj.NotifyList)
        retobj.topnotificationcount = retobj.topnotification.Count
        retobj.toptask = fyllnotigyitems(libobj.TaskList)
        retobj.toptaskcount = retobj.toptask.Count
        retobj.userinfo = fyllnotigyitems(libobj.Userinfo)
        retobj.Status = libobj.Status

        Return retobj

    End Function

    Private Function fyllnotigyitems(listtoconvert As List(Of notifieringsInfo)) As List(Of apinotifyItemInfo)
        Dim retlist As New List(Of apinotifyItemInfo)
        For Each i In listtoconvert
            Dim tmp As New apinotifyItemInfo
            tmp.Datum = i.Datum
            tmp.ExtraNote = i.ExtraNote
            tmp.NoteID = i.NoteID
            tmp.Title = i.Title
            tmp.Url = i.Url
            retlist.Add(tmp)
        Next

        Return retlist
    End Function

    Private Function fyllnotigyitems(uinf As katalogenUserInfo) As userdataInfo
        Dim retUsr As New userdataInfo

        retUsr.userid = uinf.Userid
        retUsr.useravatar = uinf.useravatar
        retUsr.userefternamn = uinf.userefternamn
        retUsr.userepost = uinf.userepost
        retUsr.userfornamn = uinf.userfornamn
        retUsr.userinfoheader = uinf.userinfoheader
        retUsr.userinfotext = uinf.userinfotext
        retUsr.username = uinf.Username
        Dim rolllist As New List(Of apiuserrollistInfo)
        For Each itm In uinf.userrollList
            Dim rollobj As New apiuserrollistInfo
            rollobj.userrollid = itm.userrollid
            rollobj.userrollname = itm.userrollname
            rolllist.Add(rollobj)
        Next
        retUsr.userrolls = rolllist
        retUsr.usertel = uinf.usertel

        Return retUsr

    End Function

End Class
