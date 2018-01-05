Public Class frmOptions

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        recuperationProduit()
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Public Sub BReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReset.Click
        Dim iNB As Integer
        iNB = MsgBox("Etes-vous sûr de vouloir redémarrer la douchette ? Cela peut réparer les problèmes de connexion WiFi.", vbYesNo + vbQuestion, "Eteindre?")
        If iNB = REPONSE_OK Then
            resetLeds()
            effectuerSoftReset()
        End If
    End Sub

    Private Sub BUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUpload.Click
        If Not isMainDirectoryEmpty() Then
            Dim iNB As Integer
            iNB = MsgBox("Souhaitez-vous remonter en base de données les dossiers restants ?", vbYesNo + vbQuestion, "Continuer?")
            If iNB = REPONSE_OK Then
                Dim FU As New frmUpload
                frmUpload.ShowDialog()
            End If
        Else
            MsgBox("Aucun dossier à remonter en base de données.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BParametre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BParametre.Click
        Dim param As New frmParametre
        param.ShowDialog()
    End Sub
End Class