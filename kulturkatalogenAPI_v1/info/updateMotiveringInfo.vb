Imports KulturkatalogenArrangemang
Public Class updateMotiveringInfo
    Private _motiveringsbeskrivning As String
    Public Property Beskrivning() As String
        Get
            Return _motiveringsbeskrivning
        End Get
        Set(ByVal value As String)
            _motiveringsbeskrivning = value
        End Set
    End Property

    Private _updateArrangemangcommand As updatearrcommand
    Public Property NewProperty() As updatearrcommand
        Get
            Return _updateArrangemangcommand
        End Get
        Set(ByVal value As updatearrcommand)
            _updateArrangemangcommand = value
        End Set
    End Property
End Class
