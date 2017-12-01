Public Class Affichable
    Private _libelle As String
    Public Property Libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property

    Private _check As Boolean
    Public Property Check() As Boolean
        Get
            Return _check
        End Get
        Set(ByVal value As Boolean)
            _check = value
        End Set
    End Property


End Class
