Public Class apinotifyItemInfo

    Public Sub New()
        _noteid = 0
        _title = ""
        _url = ""
        _date = ""
        _extranote = ""
    End Sub

    Private _noteid As Integer
    Public Property NoteID() As Integer
        Get
            Return _noteid
        End Get
        Set(ByVal value As Integer)
            _noteid = value
        End Set
    End Property

    Private _title As String
    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal value As String)
            _title = value
        End Set
    End Property
    Private _url As String
    Public Property Url() As String
        Get
            Return _url
        End Get
        Set(ByVal value As String)
            _url = value
        End Set
    End Property
    Private _extranote As String
    Public Property ExtraNote() As String
        Get
            Return _extranote
        End Get
        Set(ByVal value As String)
            _extranote = value
        End Set
    End Property
    Private _date As String
    Public Property Datum() As String
        Get
            Return _date
        End Get
        Set(ByVal value As String)
            _date = value
        End Set
    End Property
End Class