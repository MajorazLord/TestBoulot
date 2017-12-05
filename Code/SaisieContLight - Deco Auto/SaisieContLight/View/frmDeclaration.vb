Public Class frmDeclaration

    Private Sub frmDeclaration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resetLeds()

        LbIdOperateur.Text = "Opérateur actuel: n° " & myUser.getPointage

        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        If Not (getNomSecteur.Equals(Controle) Or getNomSecteur.Equals(ControleG)) Then
            BRebuts.Text = "Rebuts"
        Else
            BRebuts.Text = "Pièces écartées"
        End If
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BRebuts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRebuts.Click
        Dim frR As New frmRebuts
        frR.ShowDialog()

    End Sub

    Private Sub BContenantNT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BContenantNT.Click
        Dim fcnf As New frmContenantNonTermine
        fcnf.ShowDialog()

    End Sub

    Private Sub BTempsProduction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTempsProduction.Click
        Dim tpsProd As New frmTempsProduction
        choix = False
        tpsProd.ShowDialog()
    End Sub


#Region "Contenant bloqué"
    'Fenetre contenant bloque pour le moment indisponible
    Private Sub BContenantBloque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BContenantBloque.Click
        Dim FCB As New frmContenantBloque
        FCB.ShowDialog()
    End Sub
#End Region

End Class