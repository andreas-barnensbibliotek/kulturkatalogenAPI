Public Class userdataInfo
    Private _userid As String
    Public Property userid() As String
        Get
            Return _userid
        End Get
        Set(ByVal value As String)
            _userid = value
        End Set
    End Property
    Private _username As String
    Public Property username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property

    Private _userfornamn As String
    Public Property userfornamn() As String
        Get
            Return _userfornamn
        End Get
        Set(ByVal value As String)
            _userfornamn = value
        End Set
    End Property

    Private _userefternamn As String
    Public Property userefternamn() As String
        Get
            Return _userefternamn
        End Get
        Set(ByVal value As String)
            _userefternamn = value
        End Set
    End Property
    Private _useravatar As String
    Public Property useravatar() As String
        Get
            Return _useravatar
        End Get
        Set(ByVal value As String)
            _useravatar = value
        End Set
    End Property

    Private _userepost As String
    Public Property userepost() As String
        Get
            Return _userepost
        End Get
        Set(ByVal value As String)
            _userepost = value
        End Set
    End Property

    Private _usertel As String
    Public Property usertel() As String
        Get
            Return _usertel
        End Get
        Set(ByVal value As String)
            _usertel = value
        End Set
    End Property

    Private _userinfoheader As String
    Public Property userinfoheader() As String
        Get
            Return _userinfoheader
        End Get
        Set(ByVal value As String)
            _userinfoheader = value
        End Set
    End Property

    Private _userinfotext As String
    Public Property userinfotext() As String
        Get
            Return _userinfotext
        End Get
        Set(ByVal value As String)
            _userinfotext = value
        End Set
    End Property

    Private _userrolls As IList(Of apiuserrollistInfo)
    Public Property userrolls() As IList(Of apiuserrollistInfo)
        Get
            Return _userrolls
        End Get
        Set(ByVal value As IList(Of apiuserrollistInfo))
            _userrolls = value
        End Set
    End Property
End Class
