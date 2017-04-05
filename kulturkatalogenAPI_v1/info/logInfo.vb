Imports System.Runtime.Serialization
Imports System.ServiceModel


Public Class logInfoapi


    Private _logtyp As Integer
    Private _datum As Date
    Private _arrid As Integer
    Private _status As String
    Private _arrangemang As List(Of arrangemangInfo)

    Public Sub New()
        _logid = 0
        _logtyp = 0
        _datum = Date.Now
        _arrid = 0
        _status = ""
        _arrangemang = New List(Of arrangemangInfo)
    End Sub


    Private _logid As Integer

    <DataMember(Name:="testarlogid")>
    Public Property logid() As Integer
        Get
            Return _logid
        End Get
        Set(ByVal value As Integer)
            _logid = value
        End Set
    End Property

    <DataMember(Name:="logtyp")>
    Public Property logtyp() As Integer
        Get
            Return _logtyp
        End Get
        Set(ByVal value As Integer)
            _logtyp = value
        End Set
    End Property

    <DataMember(Name:="datum")>
    Public Property Datum() As Date
        Get
            Return _datum
        End Get
        Set(ByVal value As Date)
            _datum = value
        End Set
    End Property

    <DataMember(Name:="arrid")>
    Public Property Arrid() As Integer
        Get
            Return _arrid
        End Get
        Set(ByVal value As Integer)
            _arrid = value
        End Set
    End Property

    <DataMember(Name:="status")>
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property


End Class