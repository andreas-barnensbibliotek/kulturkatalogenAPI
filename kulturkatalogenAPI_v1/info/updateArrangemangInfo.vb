Public Class updateArrangemangInfo
    Private _userid As Integer
    Private _logtypid As Integer
    Private _arrid As Integer
    Private _logstatusid As Integer
    Private _logbeskrivning As String
    Private _cmdtyp As String
    Private _updVal As String

    Public Sub New()
        _userid = "0"
        _arrid = "0"
        _logtypid = "0"
        _logstatusid = "0"
        _logbeskrivning = ""
        _cmdtyp = ""
        _updVal = ""

    End Sub

    Public Property Userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property

    Public Property Logtypid() As Integer
        Get
            Return _logtypid
        End Get
        Set(ByVal value As Integer)
            _logtypid = value
        End Set
    End Property

    Public Property Arrid() As Integer
        Get
            Return _arrid
        End Get
        Set(ByVal value As Integer)
            _arrid = value
        End Set
    End Property

    Public Property Logstatusid() As Integer
        Get
            Return _logstatusid
        End Get
        Set(ByVal value As Integer)
            _logstatusid = value
        End Set
    End Property

    Public Property Logbeskrivning() As String
        Get
            Return _logbeskrivning
        End Get
        Set(ByVal value As String)
            _logbeskrivning = value
        End Set
    End Property

    Public Property CmdTyp() As String
        Get
            Return _cmdtyp
        End Get
        Set(ByVal value As String)
            _cmdtyp = value
        End Set
    End Property

    Public Property UpdValue() As String
        Get
            Return _updVal
        End Get
        Set(ByVal value As String)
            _updVal = value
        End Set
    End Property

End Class
