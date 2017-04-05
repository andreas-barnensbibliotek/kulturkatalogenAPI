Public Class jsonLogReturnInfo
    Private _logcount As Integer
    Public Property Logcount() As Integer
        Get
            Return _logcount
        End Get
        Set(ByVal value As Integer)
            _logcount = value
        End Set
    End Property

    Private _logitemlist As List(Of logItemInfo)
    Public Property Logitemlist() As List(Of logItemInfo)
        Get
            Return _logitemlist
        End Get
        Set(ByVal value As List(Of logItemInfo))
            _logitemlist = value
        End Set
    End Property

    Private _logstatus As String
    Public Property Logstatus() As String
        Get
            Return _logstatus
        End Get
        Set(ByVal value As String)
            _logstatus = value
        End Set
    End Property
End Class
