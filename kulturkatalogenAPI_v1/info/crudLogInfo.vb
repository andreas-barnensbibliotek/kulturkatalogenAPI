Public Class crudLogInfo

    Private _logUserid As Integer
    Private _logtypid As Integer
    Private _arrid As Integer
    Private _statustypid As Integer
    Private _beskrivning As String

    Public Sub New()
        _logUserid = 0
        _arrid = 0
        _logtypid = 0
        _statustypid = ""
        _beskrivning = ""
    End Sub

    Public Property logUserid() As Integer
        Get
            Return _logUserid
        End Get
        Set(ByVal value As Integer)
            _logUserid = value
        End Set
    End Property

    Public Property logtypid() As Integer
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

    Public Property Statustypid() As Integer
        Get
            Return _statustypid
        End Get
        Set(ByVal value As Integer)
            _statustypid = value
        End Set
    End Property

    Public Property Beskrivning() As String
        Get
            Return _beskrivning
        End Get
        Set(ByVal value As String)
            _beskrivning = value
        End Set
    End Property

End Class