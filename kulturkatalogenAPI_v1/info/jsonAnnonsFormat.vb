Public Class jsonAnnonsFormat

    Private _ansokningid As Integer
    Private _ansokningdate As String
    Private _ansokningtitle As String
    Private _ansokningsubtitle As String
    Private _ansokningpublicerad As String
    Private _ansokninglast As String
    Private _ansokningstatus As String
    Private _ansokningtyp As String
    Private _ansokningkonstform As String
    Private _ansokningutovare As String

    Public Sub New()
        _ansokningid = 0
        _ansokningdate = ""
        _ansokningtitle = ""
        _ansokningsubtitle = ""
        _ansokningpublicerad = "Nej"
        _ansokninglast = "Nej"
        _ansokningstatus = ""
        _ansokningtyp = ""
        _ansokningkonstform = ""
        _ansokningutovare = ""
        _ansokningurl = ""
        _ansokningbilaga = ""

    End Sub
    Public Property ansokningid() As Integer
        Get
            Return _ansokningid
        End Get
        Set(ByVal value As Integer)
            _ansokningid = value
        End Set
    End Property

    Public Property ansokningdate() As String
        Get
            Return _ansokningdate
        End Get
        Set(ByVal value As String)
            _ansokningdate = value
        End Set
    End Property
    Public Property ansokningtitle() As String
        Get
            Return _ansokningtitle
        End Get
        Set(ByVal value As String)
            _ansokningtitle = value
        End Set
    End Property

    Public Property ansokningsubtitle() As String
        Get
            Return _ansokningsubtitle
        End Get
        Set(ByVal value As String)
            _ansokningsubtitle = value
        End Set
    End Property

    Public Property ansokningutovare() As String
        Get
            Return _ansokningutovare
        End Get
        Set(ByVal value As String)
            _ansokningutovare = value
        End Set
    End Property

    Private _ansokningurl As String
    Public Property ansokningurl() As String
        Get
            Return _ansokningurl
        End Get
        Set(ByVal value As String)
            _ansokningurl = value
        End Set
    End Property

    Private _ansokningbilaga As String
    Public Property ansokningbilaga() As String
        Get
            Return _ansokningbilaga
        End Get
        Set(ByVal value As String)
            _ansokningbilaga = value
        End Set
    End Property
    Public Property ansokningpublicerad() As String
        Get
            Return _ansokningpublicerad
        End Get
        Set(ByVal value As String)
            _ansokningpublicerad = value
        End Set
    End Property

    Public Property ansokninglast() As String
        Get
            Return _ansokninglast
        End Get
        Set(ByVal value As String)
            _ansokninglast = value
        End Set
    End Property

    Public Property ansokningstatus() As String
        Get
            Return _ansokningstatus
        End Get
        Set(ByVal value As String)
            _ansokningstatus = value
        End Set
    End Property

    Public Property ansokningtyp() As String
        Get
            Return _ansokningtyp
        End Get
        Set(ByVal value As String)
            _ansokningtyp = value
        End Set
    End Property

    Public Property ansokningkonstform() As String
        Get
            Return _ansokningkonstform
        End Get
        Set(ByVal value As String)
            _ansokningkonstform = value
        End Set
    End Property


End Class
