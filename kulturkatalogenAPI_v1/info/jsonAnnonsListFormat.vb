Public Class jsonAnnonsListFormat

    Public Sub New()
        _ansokningar = New List(Of jsonAnnonsFormat)
        _ansokningarcount = 0
    End Sub

    Private _ansokningarcount As String
    Public Property ansokningarcount() As String
        Get
            Return _ansokningarcount
        End Get
        Set(ByVal value As String)
            _ansokningarcount = value
        End Set
    End Property

    Private _ansokningar As List(Of jsonAnnonsFormat)
    Public Property ansokningar() As List(Of jsonAnnonsFormat)
        Get
            Return _ansokningar
        End Get
        Set(ByVal value As List(Of jsonAnnonsFormat))
            _ansokningar = value
        End Set
    End Property
End Class
