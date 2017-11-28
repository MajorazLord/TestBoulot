Imports Datalogic.API

Public Class frmContenantBloque

    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    Private Sub frmContenantBloque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        PBListe.Image = New Bitmap(My.Resources.recapitulatif)

        loadFullDecodeur(hDcd, Me, dcdEvent)
    End Sub

    'Fonction appelée lors du scan d'un code barre, afin d'associé le codebarre au bon TF'
    Private Sub dcdEvent_Scanned(ByVal sender As System.Object, ByVal e As DecodeEventArgs) Handles dcdEvent.Scanned
        Dim cID As CodeId = CodeId.NoData
        Dim dcdData As String = ""
        Dim bBadRead As Boolean = False

        Try
            dcdData = hDcd.ReadString(e.RequestID, cID)
        Catch ex As Exception
            MessageBox.Show("Problème lors de la lecture.")
            bBadRead = True
        End Try

        If Not bBadRead Then
            For Each ctrl As Control In Me.Controls
                'Est-ce celui sur lequel on est'
                If ctrl.Focused Then
                    If ctrl.Name = "TBNoetiq" Then
                        If isNoEtiqOK(dcdData) Then
                            affichePointVert()
                            TBNoetiq.Text = dcdData
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If

    End Sub

    Private Sub DelNoetiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelNoetiq.Click
        TBNoetiq.Text = ""
        TBNoetiq.Focus()
    End Sub

    Private Sub PBListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBListe.Click
        frmRecapContenantsBloque.ShowDialog()
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        dcdEvent.Dispose()
        Me.Close()
    End Sub

    Private Sub TBNoetiq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNoetiq.KeyPress
        e.Handled = True
    End Sub

    Private Sub BAjouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAjouter.Click
        If TBNoetiq.Text = "" Then
            MsgBox("Veuillez scanner la partie détachable de l'étiquette du contenant plein.", MsgBoxStyle.Information, "Erreur")
            TBNoetiq.Focus()
            Exit Sub
        End If

        'Verifier que la partie detachable est unique dans la table de stockage
        If myUser.isNoetiqInLocalContenantBloque(TBNoetiq.Text) Then
            MsgBox("Ce contenant a déjà été déclaré comme bloqué !", MsgBoxStyle.Exclamation, "Declaration impossible")
            Exit Sub
        End If

        Dim iNB As Integer
        iNB = MsgBox("Etes-vous sûr de vouloir déclarer ce contenant comme bloqué ?", vbYesNo + vbQuestion, "Quitter?")
        If iNB = REPONSE_OK Then
            Dim ligne() = TBNoetiq.Text.Split("/")
            Dim noProd = ""
            If isConnectionOK() Then
                getDetailEtiquetteNumProduit(ligne(0), noProd)
            End If

            myUser.addContenantBloque(TBNoetiq.Text)
            myUser.miseAJourDeclaration()

            affichageValide(Me)

            TBNoetiq.Text = ""
            TBNoetiq.Focus()
        End If
    End Sub
End Class