Imports kulturkatalogenUtovare
Public Class utovaredataInfo

    Private _antalutovare As String
    Public Property antalutovare() As String
        Get
            Return _antalutovare
        End Get
        Set(ByVal value As String)
            _antalutovare = value
        End Set
    End Property

    Private _utovarelist As List(Of utovareDetailInfo)
    Public Property Utovarelist() As List(Of utovareDetailInfo)
        Get
            Return _utovarelist
        End Get
        Set(ByVal value As List(Of utovareDetailInfo))
            _utovarelist = value
        End Set
    End Property
    Private _cmdresponse As String
    Public Property cmdresponse() As String
        Get
            Return _cmdresponse
        End Get
        Set(ByVal value As String)
            _cmdresponse = value
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
