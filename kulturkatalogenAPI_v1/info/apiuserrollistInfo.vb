Public Class apiuserrollistInfo
    Public Sub New()
        _userrollid = ""
        _userrollname = ""
    End Sub

    Private _userrollid As String
    Public Property userrollid() As String
        Get
            Return _userrollid
        End Get
        Set(ByVal value As String)
            _userrollid = value
        End Set
    End Property

    Private _userrollname As String
    Public Property userrollname() As String
        Get
            Return _userrollname
        End Get
        Set(ByVal value As String)
            _userrollname = value
        End Set
    End Property
End Class
