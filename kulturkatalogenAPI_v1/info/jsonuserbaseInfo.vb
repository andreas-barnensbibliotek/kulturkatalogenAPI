Public Class jsonuserbaseInfo
    Private _kk_aj_admin As jsonuserInfo
    Public Property kk_aj_admin() As jsonuserInfo
        Get
            Return _kk_aj_admin
        End Get
        Set(ByVal value As jsonuserInfo)
            _kk_aj_admin = value
        End Set
    End Property

End Class
