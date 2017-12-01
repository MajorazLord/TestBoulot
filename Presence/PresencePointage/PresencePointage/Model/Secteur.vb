Public Class Secteur
    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set(ByVal value As String)
            _code = value
        End Set
    End Property

    Private _libelle As String
    Public Property Libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property

    Private _lespdcs As ArrayList
    Public Property LesPdcs() As ArrayList
        Get
            Return _lespdcs
        End Get
        Set(ByVal value As ArrayList)
            _lespdcs = value
        End Set
    End Property


    Private _site As String
    Public Property Site() As String
        Get
            Return _site
        End Get
        Set(ByVal value As String)
            _site = value
        End Set
    End Property

    Sub New(ByVal leCode As String, ByVal leLibelle As String, ByVal leSite As String)
        Code = leCode
        Libelle = leLibelle
        Site = leSite
        LesPdcs = New ArrayList
    End Sub

    Public Overrides Function ToString() As String
        Return Code & " - " & Libelle
    End Function

End Class
