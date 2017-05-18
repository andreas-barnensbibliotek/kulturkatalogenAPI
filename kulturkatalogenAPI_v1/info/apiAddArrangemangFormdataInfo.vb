Public Class apiAddArrangemangFormdataInfo
    Private _Arrangemangtyp As String
    Public Property Arrangemangtyp() As String
        Get
            Return _Arrangemangtyp
        End Get
        Set(ByVal value As String)
            _Arrangemangtyp = value
        End Set
    End Property
    Private _ArrangemangStatus As String
    Public Property NewProperty() As String
        Get
            Return _ArrangemangStatus
        End Get
        Set(ByVal value As String)
            _ArrangemangStatus = value
        End Set
    End Property
End Class
