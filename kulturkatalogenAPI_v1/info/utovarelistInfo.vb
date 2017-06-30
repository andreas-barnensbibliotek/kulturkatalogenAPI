Public Class utovarelistInfo

    Public Sub New()
        _selected = "nej"
    End Sub
    Private _utovareid As String
    Public Property utovarid() As String
        Get
            Return _utovareid
        End Get
        Set(ByVal value As String)
            _utovareid = value
        End Set
    End Property

    Private _utovare As String
    Public Property utovare() As String
        Get
            Return _utovare
        End Get
        Set(ByVal value As String)
            _utovare = value
        End Set
    End Property
    Private _selected As String
    Public Property selected() As String
        Get
            Return _selected
        End Get
        Set(ByVal value As String)
            _selected = value
        End Set
    End Property
End Class