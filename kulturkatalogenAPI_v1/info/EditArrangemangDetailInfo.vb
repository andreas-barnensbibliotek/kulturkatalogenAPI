Public Class EditArrangemangDetailInfo

    Private _arrid As String
    Private _contentid As String
    Private _rubrik As String
    Private _underrubrik As String
    Private _konstformid As String
    Private _arrangemangtypid As String
    Private _utovareID As String
    Private _publicerad As String
    Private _innehall As String
    Private _faktaid As String
    Private _faktaval As String
    Private _mediaid As String
    Private _mediaurl As String
    Private _mediafilename As String
    Private _mediasize As String
    Private _mediaalt As String
    Private _mediaFoto As String
    Private _mediatyp As String
    Private _mediaVald As String
    Private _mediaTitle As String
    Private _mediaBeskrivning As String
    Private _mediaLink As String
    Private _sortering As String

    Public Sub New()
        _arrid = ""
        _contentid = ""
        _rubrik = ""
        _underrubrik = ""
        _innehall = ""
        _konstformid = ""
        _arrangemangtypid = ""
        _utovareID = ""
        _publicerad = ""


        _faktaid = ""
        _faktaval = ""

        _mediaid = ""
        _mediaurl = ""
        _mediafilename = ""
        _mediasize = ""
        _mediaalt = ""
        _mediaFoto = ""
        _mediatyp = ""
        _mediaVald = "nej"
        _mediaTitle = ""
        _mediaBeskrivning = ""
        _mediaLink = ""
        _sortering = ""
    End Sub

    Public Property arrid() As String
        Get
            Return _arrid
        End Get
        Set(ByVal value As String)
            _arrid = value
        End Set
    End Property

    Public Property contentid() As String
        Get
            Return _contentid
        End Get
        Set(ByVal value As String)
            _contentid = value
        End Set
    End Property

    Public Property rubrik() As String
        Get
            Return _rubrik
        End Get
        Set(ByVal value As String)
            _rubrik = value
        End Set
    End Property

    Public Property underrubrik() As String
        Get
            Return _underrubrik
        End Get
        Set(ByVal value As String)
            _underrubrik = value
        End Set
    End Property

    Public Property utovareid() As String
        Get
            Return _utovareID
        End Get
        Set(ByVal value As String)
            _utovareID = value
        End Set
    End Property

    Public Property konstformid() As String
        Get
            Return _konstformid
        End Get
        Set(ByVal value As String)
            _konstformid = value
        End Set
    End Property

    Public Property arrangemangtypid() As String
        Get
            Return _arrangemangtypid
        End Get
        Set(ByVal value As String)
            _arrangemangtypid = value
        End Set
    End Property

    Public Property publicerad() As String
        Get
            Return _publicerad
        End Get
        Set(ByVal value As String)
            _publicerad = value
        End Set
    End Property

    Public Property innehall() As String
        Get
            Return _innehall
        End Get
        Set(ByVal value As String)
            _innehall = value
        End Set
    End Property

    Public Property faktaid() As String
        Get
            Return _faktaid
        End Get
        Set(ByVal value As String)
            _faktaid = value
        End Set
    End Property

    Public Property faktaval() As String
        Get
            Return _faktaval
        End Get
        Set(ByVal value As String)
            _faktaval = value
        End Set
    End Property

    Public Property MediaID() As String
        Get
            Return _mediaid
        End Get
        Set(ByVal value As String)
            _mediaid = value
        End Set
    End Property
    Public Property MediaUrl() As String
        Get
            Return _mediaurl
        End Get
        Set(ByVal value As String)
            _mediaurl = value
        End Set
    End Property

    Public Property MediaFilename() As String
        Get
            Return _mediafilename
        End Get
        Set(ByVal value As String)
            _mediafilename = value
        End Set
    End Property

    Public Property MediaSize() As String
        Get
            Return _mediasize
        End Get
        Set(ByVal value As String)
            _mediasize = value
        End Set
    End Property

    Public Property MediaAlt() As String
        Get
            Return _mediaalt
        End Get
        Set(ByVal value As String)
            _mediaalt = value
        End Set
    End Property

    Public Property MediaFoto() As String
        Get
            Return _mediaFoto
        End Get
        Set(ByVal value As String)
            _mediaFoto = value
        End Set
    End Property

    Public Property MediaTyp() As String
        Get
            Return _mediatyp
        End Get
        Set(ByVal value As String)
            _mediatyp = value
        End Set
    End Property

    Public Property MediaVald() As String
        Get
            Return _mediaVald
        End Get
        Set(ByVal value As String)
            _mediaVald = value
        End Set
    End Property
    Public Property mediaTitle() As String
        Get
            Return _mediaTitle
        End Get
        Set(ByVal value As String)
            _mediaTitle = value
        End Set
    End Property

    Public Property mediaBeskrivning() As String
        Get
            Return _mediaBeskrivning
        End Get
        Set(ByVal value As String)
            _mediaBeskrivning = value
        End Set
    End Property

    Public Property mediaLink() As String
        Get
            Return _mediaLink
        End Get
        Set(ByVal value As String)
            _mediaLink = value
        End Set
    End Property

    Public Property sortering() As String
        Get
            Return _sortering
        End Get
        Set(ByVal value As String)
            _sortering = value
        End Set
    End Property
End Class
