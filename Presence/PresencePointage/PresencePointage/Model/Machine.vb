Public Class Machine
    Private _nomachine As String
    Public Property NoMachine() As String
        Get
            Return _nomachine
        End Get
        Set(ByVal value As String)
            _nomachine = value
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

    Private _codePdc As String
    Public Property CodePdc() As String
        Get
            Return _codePdc
        End Get
        Set(ByVal value As String)
            _codePdc = value
        End Set
    End Property

    Sub New(ByVal leNum As String, ByVal leLibelle As String, ByVal leCodePdc As String)
        NoMachine = leNum
        Libelle = leLibelle
        CodePdc = leCodePdc
    End Sub
End Class