Public Class testarinfo
    Private _testnamn As String
    Public Property testnamn() As String
        Get
            Return _testnamn
        End Get
        Set(ByVal value As String)
            _testnamn = value
        End Set
    End Property

    Private _testort As String
    Public Property testort() As String
        Get
            Return _testort
        End Get
        Set(ByVal value As String)
            _testort = value
        End Set
    End Property


    Private _lista As List(Of testarrlist)
    Public Property lista() As List(Of testarrlist)
        Get
            Return _lista
        End Get
        Set(ByVal value As List(Of testarrlist))
            _lista = value
        End Set
    End Property
End Class
