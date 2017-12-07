Imports KulturkatalogenArrangemang

Public Class jsonAnnonsFormat

    Private _ansokningid As Integer
    Private _ansokningdate As String
    Private _ansokningcontentid As String
    Private _ansokningtitle As String
    Private _ansokningsubtitle As String
    Private _ansokningpublicerad As String
    Private _ansokninglast As String
    Private _ansokningstatus As String
    Private _ansokningtypid As String
    Private _ansokningkonstformid As String
    Private _ansokningtyp As String
    Private _ansokningkonstform As String
    Private _ansokningutovare As String
    Private _utovareid As Integer
    Private _konstform2 As String
    Private _konstform3 As String
    Private _kontatkid As String
    Private _kontaktFornamn As String
    Private _kontaktEfternamn As String
    Private _kontakttelefon As String
    Private _kontaktEpost As String

    Public Sub New()
        _ansokningid = 0
        _ansokningdate = ""
        _ansokningcontentid = ""
        _ansokningtitle = ""
        _ansokningsubtitle = ""
        _ansokningpublicerad = "Nej"
        _ansokninglast = "Nej"
        _ansokningstatus = ""
        _ansokningtypid = 0
        _ansokningkonstformid = 0
        _ansokningtyp = ""
        _ansokningkonstform = ""
        _ansokningutovare = ""
        _ansokningurl = ""
        _ansokningbilaga = ""
        _ansokningmediaimage = New mediaInfo
        _ansokusername = ""
        '_ansokningmovieclip = New mediaInfo
        _utovareid = 0
        _utovardata = New utovareInfo
        _konstform2 = "0"
        _konstform3 = "0"
        _kontatkid = ""
        _kontaktFornamn = ""
        _kontaktEfternamn = ""
        _kontakttelefon = ""
        _kontaktEpost = ""
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

    Public Property ansokningcontentid() As String
        Get
            Return _ansokningcontentid
        End Get
        Set(ByVal value As String)
            _ansokningcontentid = value
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

    Private _innehall As String
    Public Property ansokningContent() As String
        Get
            Return _innehall
        End Get
        Set(ByVal value As String)
            _innehall = value
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

    Public Property ansokningtypid() As String
        Get
            Return _ansokningtypid
        End Get
        Set(ByVal value As String)
            _ansokningtypid = value
        End Set
    End Property

    Public Property ansokningkonstformid() As String
        Get
            Return _ansokningkonstformid
        End Get
        Set(ByVal value As String)
            _ansokningkonstformid = value
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

    Private _faktalist As List(Of faktainfo)
    Public Property ansokningFaktalist() As List(Of faktainfo)
        Get
            Return _faktalist
        End Get
        Set(ByVal value As List(Of faktainfo))
            _faktalist = value
        End Set
    End Property


    Private _medialist As List(Of mediaInfo)
    Public Property ansokningMedialist() As List(Of mediaInfo)
        Get
            Return _medialist
        End Get
        Set(ByVal value As List(Of mediaInfo))
            _medialist = value
        End Set
    End Property



    Private _ansokusername As String
    Public Property ansokningUsername() As String
        Get
            Return _ansokusername
        End Get
        Set(ByVal value As String)
            _ansokusername = value
        End Set
    End Property
    Private _ansokningmediaimage As mediaInfo
    Public Property ansokningMediaImage() As mediaInfo
        Get
            Return _ansokningmediaimage
        End Get
        Set(ByVal value As mediaInfo)
            _ansokningmediaimage = value
        End Set
    End Property

    'Private _ansokningmovieclip As mediaInfo
    'Public Property ansokningMovieClip() As mediaInfo
    '    Get
    '        Return _ansokningmovieclip
    '    End Get
    '    Set(ByVal value As mediaInfo)
    '        _ansokningmovieclip = value
    '    End Set
    'End Property


    Public Property ansokningUtovarid() As Integer
        Get
            Return _utovareid
        End Get
        Set(ByVal value As Integer)
            _utovareid = value
        End Set
    End Property

    Private _utovardata As utovareInfo
    Public Property ansokningUtovardata() As utovareInfo
        Get
            Return _utovardata
        End Get
        Set(ByVal value As utovareInfo)
            _utovardata = value
        End Set
    End Property

    Private _agesspan As String
    Public Property ansokningAgespan() As String
        Get
            Return _agesspan
        End Get
        Set(ByVal value As String)
            _agesspan = value
        End Set
    End Property

    Private _filterfakta As filterfaktaInfo
    Public Property ansokningFilterfakta() As filterfaktaInfo
        Get
            Return _filterfakta
        End Get
        Set(ByVal value As filterfaktaInfo)
            _filterfakta = value
        End Set
    End Property
    Public Property ansokningKonstform2() As String
        Get
            Return _konstform2
        End Get
        Set(ByVal value As String)
            _konstform2 = value
        End Set
    End Property

    Public Property ansokningKonstform3() As String
        Get
            Return _konstform3
        End Get
        Set(ByVal value As String)
            _konstform3 = value
        End Set
    End Property
    Public Property ansokningKontaktId() As String
        Get
            Return _kontatkid
        End Get
        Set(ByVal value As String)
            _kontatkid = value
        End Set
    End Property

    Public Property ansokningKontaktfornamn() As String
        Get
            Return _kontaktFornamn
        End Get
        Set(ByVal value As String)
            _kontaktFornamn = value
        End Set
    End Property
    Public Property ansokningKontaktEfternamn() As String
        Get
            Return _kontaktEfternamn
        End Get
        Set(ByVal value As String)
            _kontaktEfternamn = value
        End Set
    End Property
    Public Property ansokningKontaktTelefon() As String
        Get
            Return _kontakttelefon
        End Get
        Set(ByVal value As String)
            _kontakttelefon = value
        End Set
    End Property
    Public Property ansokningKontaktEpost() As String
        Get
            Return _kontaktEpost
        End Get
        Set(ByVal value As String)
            _kontaktEpost = value
        End Set
    End Property
End Class
