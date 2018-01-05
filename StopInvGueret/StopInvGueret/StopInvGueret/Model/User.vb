Imports System.Data

Public Class User

    Public DTArrivee As DataTable
    Public DTDépart As DataTable

    Public Sub New()
        initDT()
    End Sub

    Private Sub initDT()
        DTArrivee = New DataTable
        DTArrivee.Columns.Add("NoEtiq", GetType(String))
        DTArrivee.Columns.Add("Quantité", GetType(String))

        DTDépart = New DataTable
        DTDépart.Columns.Add("NoEtiq", GetType(String))
    End Sub

    Public Function getDTArrivee() As DataTable
        Return DTArrivee
    End Function

    Public Function getDTDépart() As DataTable
        Return DTDépart
    End Function

End Class
