﻿Public Class arrfaktainfo

    Private _faktaid As String
    Private _faktatypid As String
    Private _faktarubrik As String
    Private _faktavalue As String
    Public Sub New()
        _faktaid = "0"
        _faktatypid = "0"
        _faktarubrik = ""
        _faktavalue = ""
    End Sub
    Public Property Faktaid() As String
        Get
            Return _faktaid
        End Get
        Set(ByVal value As String)
            _faktaid = value
        End Set
    End Property
    Public Property FaktaTypID() As String
        Get
            Return _faktatypid
        End Get
        Set(ByVal value As String)
            _faktatypid = value
        End Set
    End Property
    Public Property Faktarubrik() As String
        Get
            Return _faktarubrik
        End Get
        Set(ByVal value As String)
            _faktarubrik = value
        End Set
    End Property

    Public Property FaktaValue() As String
        Get
            Return _faktavalue
        End Get
        Set(ByVal value As String)
            _faktavalue = value
        End Set
    End Property


End Class
