Public Class crudloginfoapi

    Private _logUserid As String
    Private _logtypid As String
    Private _arrid As String
    Private _statustypid As String
    Private _beskrivning As String

    Public Sub New()
        _logUserid = "0"
        _arrid = "0"
        _logtypid = "0"
        _statustypid = "0"
        _beskrivning = ""
    End Sub

    Public Property LogUserid() As String
        Get
            Return _logUserid
        End Get
        Set(ByVal value As String)
            _logUserid = value
        End Set
    End Property

    Public Property Logtypid() As String
        Get
            Return _logtypid
        End Get
        Set(ByVal value As String)
            _logtypid = value
        End Set
    End Property

    Public Property Arrid() As String
        Get
            Return _arrid
        End Get
        Set(ByVal value As String)
            _arrid = value
        End Set
    End Property

    Public Property Statustypid() As String
        Get
            Return _statustypid
        End Get
        Set(ByVal value As String)
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