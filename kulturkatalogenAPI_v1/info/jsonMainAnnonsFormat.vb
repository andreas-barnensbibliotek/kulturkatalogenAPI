﻿Imports KulturkatalogenArrangemang
Public Class jsonMainAnnonsFormat

    Public Sub New()
        _ansokningarlista = New jsonAnnonsListFormat
        _ansokningarlistacount = 0
        _ansokningarlistacurrentpage = 0
        _ansokningarlistatotalpages = 0
        _ansokningstyp = 0
        _approvedansokningarcount = 0
        _deniedansokningarcount = 0
        _nyaansokningarcount = 0
        _status = ""

    End Sub

    Private _ansokningstyp As String
    Public Property Ansokningstyp() As String
        Get
            Return _ansokningstyp
        End Get
        Set(ByVal value As String)
            _ansokningstyp = value
        End Set
    End Property

    Private _ansokningarlista As jsonAnnonsListFormat
    Public Property ansokningarlista() As jsonAnnonsListFormat
        Get
            Return _ansokningarlista
        End Get
        Set(ByVal value As jsonAnnonsListFormat)
            _ansokningarlista = value
        End Set
    End Property

    Private _ansokningarlistacount As Integer
    Public Property Ansokningarlistacount() As Integer
        Get
            Return _ansokningarlistacount
        End Get
        Set(ByVal value As Integer)
            _ansokningarlistacount = value
        End Set
    End Property

    Private _ansokningarlistacurrentpage As Integer
    Public Property Ansokningarlistacurrentpage() As Integer
        Get
            Return _ansokningarlistacurrentpage
        End Get
        Set(ByVal value As Integer)
            _ansokningarlistacurrentpage = value
        End Set
    End Property

    Private _ansokningarlistatotalpages As Integer
    Public Property Ansokningarlistatotalpages() As Integer
        Get
            Return _ansokningarlistatotalpages
        End Get
        Set(ByVal value As Integer)
            _ansokningarlistatotalpages = value
        End Set
    End Property
    Private _nyaansokningarcount As Integer
    Public Property nyaansokningarcount() As Integer
        Get
            Return _nyaansokningarcount
        End Get
        Set(ByVal value As Integer)
            _nyaansokningarcount = value
        End Set
    End Property
    Private _approvedansokningarcount As Integer
    Public Property approvedansokningarcount() As Integer
        Get
            Return _approvedansokningarcount
        End Get
        Set(ByVal value As Integer)
            _approvedansokningarcount = value
        End Set
    End Property
    Private _deniedansokningarcount As Integer
    Public Property deniedansokningarcount() As Integer
        Get
            Return _deniedansokningarcount
        End Get
        Set(ByVal value As Integer)
            _deniedansokningarcount = value
        End Set
    End Property

    Private _status As String
    Public Property status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
End Class
