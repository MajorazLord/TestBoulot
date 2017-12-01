Public Class DeuxSite
    Private _lesSecteurs As ArrayList
    Public Property LesSecteurs() As ArrayList
        Get
            Return _lesSecteurs
        End Get
        Set(ByVal value As ArrayList)
            _lesSecteurs = value
        End Set
    End Property

    Sub New(ByVal lesSect As ArrayList)
        LesSecteurs = lesSect
    End Sub
End Class
