Public Class Poste
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

    Private _codeSect As String
    Public Property CodeSect() As String
        Get
            Return _codeSect
        End Get
        Set(ByVal value As String)
            _codeSect = value
        End Set
    End Property

    Private _lesMachines As ArrayList
    Public Property LesMachines() As ArrayList
        Get
            Return _lesMachines
        End Get
        Set(ByVal value As ArrayList)
            _lesMachines = value
        End Set
    End Property

    Sub New(ByVal leCode As String, ByVal leLibelle As String, ByVal leCodeSect As String)
        Code = leCode
        Libelle = leLibelle
        CodeSect = leCodeSect
        LesMachines = New ArrayList
    End Sub
End Class
