Public Class apiNotifieringarInfo
    Public Sub New()

        _topmessages = New List(Of apinotifyItemInfo)
        _topmessagescount = 0
        _topnotification = New List(Of apinotifyItemInfo)
        _topnotificationcount = 0
        _toptask = New List(Of apinotifyItemInfo)
        _toptaskcount = 0
        _userinfo = New userdataInfo
        _status = ""

    End Sub


    Private _topmessagescount As String
    Public Property topmessagescount() As String
        Get
            Return _topmessagescount
        End Get
        Set(ByVal value As String)
            _topmessagescount = value
        End Set
    End Property

    Private _topmessages As List(Of apinotifyItemInfo)
    Public Property topmessages() As List(Of apinotifyItemInfo)
        Get
            Return _topmessages
        End Get
        Set(ByVal value As List(Of apinotifyItemInfo))
            _topmessages = value
        End Set
    End Property

    Private _topnotificationcount As String
    Public Property topnotificationcount() As String
        Get
            Return _topnotificationcount
        End Get
        Set(ByVal value As String)
            _topnotificationcount = value
        End Set
    End Property

    Private _topnotification As List(Of apinotifyItemInfo)
    Public Property topnotification() As List(Of apinotifyItemInfo)
        Get
            Return _topnotification
        End Get
        Set(ByVal value As List(Of apinotifyItemInfo))
            _topnotification = value
        End Set
    End Property

    Private _toptaskcount As String
    Public Property toptaskcount() As String
        Get
            Return _toptaskcount
        End Get
        Set(ByVal value As String)
            _toptaskcount = value
        End Set
    End Property

    Private _toptask As List(Of apinotifyItemInfo)
    Public Property toptask() As List(Of apinotifyItemInfo)
        Get
            Return _toptask
        End Get
        Set(ByVal value As List(Of apinotifyItemInfo))
            _toptask = value
        End Set
    End Property

    Private _userinfo As userdataInfo
    Public Property userinfo() As userdataInfo
        Get
            Return _userinfo
        End Get
        Set(ByVal value As userdataInfo)
            _userinfo = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
End Class
