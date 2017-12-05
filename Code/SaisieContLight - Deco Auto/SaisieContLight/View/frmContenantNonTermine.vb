Imports Datalogic.API

Public Class frmContenantNonTermine

    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle
    Private upd As New UploadManager

    Private Sub frmContenantNonFini_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRecapitulatif.Image = New Bitmap(My.Resources.recapitulatif)

        If finSaisie Then
            PBRetour.Image = New Bitmap(My.Resources.Ok)
        Else
            PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        End If

        loadFullDecodeur(hDcd, Me, dcdEvent)

        If bMono Then
            TBMachine.Text = monoMachine
            TBNumEtiq.Focus()
        Else
            TBMachine.Text = ""
            TBMachine.Focus()
        End If

    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Dim iNB As Integer
        If finSaisie Then
            iNB = MsgBox("Avez-vous finis de déclarer tous vos contenants non terminés?", vbYesNo + vbQuestion, "Fin de saisie")
            If iNB = REPONSE_OK Then
                dcdEvent.Dispose()
                Me.Close()
            Else
                Exit Sub
            End If
        Else
            dcdEvent.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub PBRecapitulatif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRecapitulatif.Click
        frmRecapContenantsNT.ShowDialog()
    End Sub

#Region "Bouton supprimer"
    Private Sub BDelMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMachine.Click
        TBMachine.Text = ""
        TBMachine.Focus()
    End Sub

    Private Sub BDelNumEtiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelNumEtiq.Click
        TBNumEtiq.Text = ""
        TBNumEtiq.Focus()
    End Sub

    Private Sub BDelQuantite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelQuantite.Click
        TBQuantite.Text = ""
        TBQuantite.Focus()
    End Sub


#End Region

    Private Sub BValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BValider.Click
        If TBMachine.Text = "" Then
            MsgBox("La machine doit être renseignée.", MsgBoxStyle.Exclamation, "Machine manquante")
            TBMachine.Focus()
            Exit Sub
        Else
            If Not (TBMachine.Text.StartsWith("AE") And TBMachine.Text.Length < 10 And TBMachine.Text.Length > 5 And IsNumeric(TBMachine.Text.Substring(2))) Then
                MsgBox("Le numéro de machine est invalide", MsgBoxStyle.Exclamation, "Machine invalide")
                TBMachine.Text = ""
                TBMachine.Focus()
                Exit Sub
            End If
        End If

        If TBNumEtiq.Text = "" Then
            MsgBox("La partie détachable doit être renseignée.", MsgBoxStyle.Exclamation, "Partie détachable manquante")
            TBNumEtiq.Text = ""
            TBNumEtiq.Focus()
            Exit Sub
        Else
            If Not isNoEtiqOK(TBNumEtiq.Text) Then
                MsgBox("La partie détachable est invalide.", MsgBoxStyle.Exclamation, "Info invalide")
                TBNumEtiq.Focus()
                Exit Sub
            End If
        End If

        If Not getNomSecteur.Equals(UsinageA) Then
            If getNomSecteur.Equals(UsinageG) Then
                If TBMachine.Text.StartsWith("AE2001") Or TBMachine.Text.StartsWith("AE0058") Or TBMachine.Text.StartsWith("AE0057.04") Then
                    If TBQuantite.Text = "" Then
                        MsgBox("La quantité doit être renseignée.", MsgBoxStyle.Exclamation, "Quantité manquante")
                        TBQuantite.Focus()
                        Exit Sub
                    ElseIf Not IsNumeric(TBQuantite.Text) Then
                        MsgBox("Quantité invalide", MsgBoxStyle.Exclamation, "Quantité invalide")
                        TBQuantite.Text = ""
                        TBQuantite.Focus()
                        Exit Sub
                    End If
                End If
            Else
                If TBQuantite.Text = "" Then
                    MsgBox("La quantité doit être renseignée.", MsgBoxStyle.Exclamation, "Quantité manquante")
                    TBQuantite.Focus()
                    Exit Sub
                ElseIf Not IsNumeric(TBQuantite.Text) Then
                    MsgBox("Quantité invalide", MsgBoxStyle.Exclamation, "Quantité invalide")
                    TBQuantite.Text = ""
                    TBQuantite.Focus()
                    Exit Sub
                End If
            End If
        End If

        If myUser.isLocalOutputAlreadyDoneForUser(TBNumEtiq.Text) Then
            MsgBox("Ce contenant a déjà était déclaré en sortie", MsgBoxStyle.Exclamation, "Déclaration impossible")
            Exit Sub
        End If
        If upd.isIOFullPresentInDB(TBNumEtiq.Text, Sortie) Then
            MsgBox("Ce contenant a déjà était déclaré en sortie", MsgBoxStyle.Exclamation, "Déclaration impossible")
            Exit Sub
        End If

        Dim values() As String
        Dim noof As String = ""
        Dim noop As String = ""
        Dim noProd As String = ""
        values = TBNumEtiq.Text.Split("/")
        If values.Length = 3 Then
            noof = values(0)
            noop = values(1)
        Else
            If TBNumEtiq.Text.StartsWith("G") Or TBNumEtiq.Text.StartsWith("A") Then
                If isConnectionOK() Then
                    getDetailEtiquetteGOPAL(TBNumEtiq.Text, "", noof, noop)
                Else
                    Dim frmD As New frmDemandeOF
                    frmD.ShowDialog()

                    If numeroOF = Nothing Then
                        Exit Sub
                    End If
                    noof = numeroOF
                    noop = ""
                End If
            End If
        End If

        If isConnectionOK() Then
            getDetailEtiquetteNumProduit(noof, noProd)
        End If

        If Not getNomSecteur.Equals(UsinageG) Then
            If Not myUser.addQteFinPoste(noof, noop, noProd, Convert.ToInt32(TBQuantite.Text), TBMachine.Text, TBNumEtiq.Text) Then
                Exit Sub
            End If
        Else
            If TBMachine.Text.StartsWith("AE2001") Or TBMachine.Text.StartsWith("AE0058") Or TBMachine.Text.StartsWith("AE0057.04") Then
                If Not myUser.addQteFinPoste(noof, noop, noProd, Convert.ToInt32(TBQuantite.Text), TBMachine.Text, TBNumEtiq.Text) Then
                    Exit Sub
                End If
            Else
                If Not myUser.addQteFinPoste(noof, noop, noProd, 0, TBMachine.Text, TBNumEtiq.Text) Then
                    Exit Sub
                End If
            End If
        End If

        myQteProd.addQteFinPosteActuel(noof, noop, Convert.ToInt32(TBQuantite.Text), TBMachine.Text, TBNumEtiq.Text)

        myUser.miseAJourDeclaration()
        myUser.addSaisie(TBQuantite.Text, noof, noop, TBMachine.Text, True, noProd)

        If Secteur.Equals(CodeUsinageG) Then
            If TBMachine.Text.StartsWith("AE2001") Or TBMachine.Text.StartsWith("AE0058") Or TBMachine.Text.StartsWith("AE0057.04") Then
                myUser.addTempsProduction(TBMachine.Text, noof, noop, noProd, 0, 1)
            Else
                myUser.addTempsProduction(TBMachine.Text, noof, noop, noProd, TPS_TRAVAIL, 0)
                myUser.addTempsProductionRECAP(1, TBMachine.Text, noof, noop, noProd, TPS_TRAVAIL)
                myUser.addSaisieProd(noof, noop, TBMachine.Text, TPS_TRAVAIL)
            End If
        Else
            If Secteur.Equals(CodeInstallG) Or Secteur.Equals(CodeInstall) Then
                myUser.addTempsProduction(TBMachine.Text, noof, noop, noProd, TPS_TRAVAIL, 0)
                myUser.addTempsProductionRECAP(1, TBMachine.Text, noof, noop, noProd, TPS_TRAVAIL)
                myUser.addSaisieProd(noof, noop, TBMachine.Text, TPS_TRAVAIL)
                'myUser.addTempsProduction(TBMachine.Text, noof, noop, noProd, 0, 1)
            Else
                If Secteur.Equals(CodeUsinageA) Then
                    myUser.addTempsProduction(TBMachine.Text, noof, noop, noProd, TPS_TRAVAIL, 0)
                    myUser.addTempsProductionRECAP(1, TBMachine.Text, noof, noop, noProd, TPS_TRAVAIL)
                    myUser.addSaisieProd(noof, noop, TBMachine.Text, TPS_TRAVAIL)
                Else
                    myUser.addTempsProduction(TBMachine.Text, noof, noop, noProd, 0, 1)
                End If
            End If
        End If

        myUser.miseAJourTempsProduction()

        affichageValide(Me)

        TBNumEtiq.Text = ""
        TBQuantite.Text = ""
        If bMono Then
            TBNumEtiq.Focus()
        Else
            TBMachine.Text = ""
            TBMachine.Focus()
        End If
    End Sub

    Private Sub TBMachine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBMachine.KeyPress
        e.Handled = True
        If Asc(e.KeyChar) = Keys.Enter Then
            BValider_Click(Me, e)
        End If
    End Sub

    Private Sub TBNumEtiq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumEtiq.KeyPress
        'e.Handled = True
    End Sub

    ''' <summary>
    ''' Fonction appelée lors d'un scan d'un code barre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dcdEvent_Scanned(ByVal sender As System.Object, ByVal e As DecodeEventArgs) Handles dcdEvent.Scanned
        Dim cID As CodeId = CodeId.NoData
        Dim dcdData As String = ""
        Dim bBadRead As Boolean = False

        Try
            dcdData = hDcd.ReadString(e.RequestID, cID)
        Catch ex As Exception
            MessageBox.Show("Problème lors de la lecture")
            bBadRead = True
        End Try

        If Not bBadRead Then
            For Each ctrl As Control In Me.Controls
                If ctrl.Focused Then
                    If ctrl.Name = "TBMachine" Then
                        If (dcdData.StartsWith("AE") And dcdData.Length < 10 And dcdData.Length > 5 And IsNumeric(dcdData.Substring(2))) Or (dcdData.Length < 3 And IsNumeric(dcdData)) Then
                            affichePointVert()
                            TBMachine.Text = dcdData
                            TBNumEtiq.Focus()
                        End If
                    ElseIf ctrl.Name = "TBNumEtiq" Then
                        If isNoEtiqOK(dcdData) Then
                            affichePointVert()
                            TBNumEtiq.Text = dcdData
                            TBQuantite.Focus()
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub

    Private Sub TBQuantite_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBQuantite.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            BValider_Click(Me, e)
        Else
            e.Handled = True
        End If
    End Sub
End Class