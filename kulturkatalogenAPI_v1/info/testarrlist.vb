Public Class testarrlist
    Private _val As String
    Public Property val() As String
        Get
            Return _val
        End Get
        Set(ByVal value As String)
            _val = value
        End Set
    End Property
End Class
