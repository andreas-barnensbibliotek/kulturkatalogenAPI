Public Class jsonuserInfo
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
    Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
End Class
