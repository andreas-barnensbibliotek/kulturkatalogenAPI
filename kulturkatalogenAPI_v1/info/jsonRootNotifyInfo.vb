Public Class jsonRootNotifyInfo
    Public Sub New()
        _kk_aj_admin = New apiNotifieringarInfo
    End Sub
    Private _kk_aj_admin As apiNotifieringarInfo
    Public Property kk_aj_admin() As apiNotifieringarInfo
        Get
            Return _kk_aj_admin
        End Get
        Set(ByVal value As apiNotifieringarInfo)
            _kk_aj_admin = value
        End Set
    End Property
End Class
