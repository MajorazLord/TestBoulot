Imports Datalogic.API

Public Class frmEntree
    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle
    Private currentGOPAL As String = ""
    Private listGOPAL As New List(Of String)


    Private Sub frmEntree_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resetLeds()

        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        PBRecapitulatif.Image = New Bitmap(My.Resources.recapitulatif)

        loadFullDecodeur(hDcd, Me, dcdEvent)

        If bMono Then
            tbNumMach.Text = monoMachine
            tbnoetiq.Focus()
        Else
            tbNumMach.Text = ""
            tbNumMach.Focus()
        End If
    End Sub


    ''' <summary>
    ''' Fonction appelée lors du scan d'un code barre, afin d'associé le codebarre au bon TF
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dcdEvent_Scanned(ByVal sender As System.Object, ByVal e As DecodeEventArgs) Handles dcdEvent.Scanned
        Dim cID As CodeId = CodeId.NoData
        Dim dcdData As String = ""
        Dim bBadRead As Boolean = False
        Dim noof As String = ""
        Try
            dcdData = hDcd.ReadString(e.RequestID, cID)
        Catch ex As Exception
            MessageBox.Show("Problème lors de la lecture.")
            bBadRead = True
        End Try

        If Not bBadRead Then
            For Each ctrl As Control In Me.Controls()
                'Est-ce celui sur lequel on est'
                If ctrl.Focused Then
                    If ctrl.Name = "tbNumMach" Then
                        If (dcdData.StartsWith("AE") And dcdData.Length < 10 And dcdData.Length > 5 And IsNumeric(dcdData.Substring(2))) Or (dcdData.Length < 3 And IsNumeric(dcdData)) Then
                            affichePointVert()
                            tbNumMach.Text = dcdData
                            tbnoetiq.Focus()
                        ElseIf dcdData.StartsWith(PdCFourG) Then
                            affichePointVert()
                            tbNumMach.Text = dcdData
                            tbnoetiq.Focus()
                        End If

                    ElseIf ctrl.Name = "tbnoetiq" Then
                        If isNoEtiqOK(dcdData) Then
                            affichePointVert()
                            tbnoetiq.Text = dcdData
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub

#Region "KeyPress"
    Private Sub tbNumMach_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNumMach.KeyPress
        e.Handled = True
        If Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        End If
    End Sub

    Private Sub tbnoetiq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbnoetiq.KeyPress
        'La saisie à la main est possible pour les étiquettes
        'e.Handled = True
        If Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        End If
    End Sub

#End Region

#Region "Bouton supprimer"
    Private Sub DelMach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelMach.Click
        tbNumMach.Text = ""
        tbNumMach.Focus()
    End Sub

    Private Sub DelNoetiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelNoetiq.Click
        tbnoetiq.Text = ""
        tbnoetiq.Focus()
    End Sub
#End Region

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        dcdEvent.Dispose()
        Me.Close()
    End Sub

    Private Sub PBListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRecapitulatif.Click
        frmRecapIO.ShowDialog()
    End Sub

    Private Sub btvalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvalid.Click
        Dim abv As String = ""
        Dim noProd As String = ""
        Dim noLot As String = ""
        Dim updlMng As New UploadManager
        Dim machine As String = tbNumMach.Text

        If machine = PdCFourG Then
            machine = "AE0251"
        End If

        If machine = "" Then
            MsgBox("La machine doit être renseignée.", MsgBoxStyle.Exclamation, "Info manquante")
            tbNumMach.Focus()
            Exit Sub
        Else
            If Not (machine.StartsWith("AE") And machine.Length < 10 And machine.Length > 5 And IsNumeric(machine.Substring(2))) Then
                MsgBox("Le numéro de machine est invalide.", MsgBoxStyle.Exclamation, "Info invalide")
                tbNumMach.Focus()
                Exit Sub
            End If
        End If

        If tbnoetiq.Text = "" Then
            MsgBox("La partie détachable doit être renseignée.", MsgBoxStyle.Exclamation, "Info manquante")
            tbnoetiq.Focus()
            Exit Sub
        Else
            'Si il est bon ou non'

            If Not isNoEtiqOK(tbnoetiq.Text) Then
                MsgBox("La partie détachable est invalide.", MsgBoxStyle.Exclamation, "Info invalide")
                tbnoetiq.Focus()
                Exit Sub
            End If
        End If

        '----VERIFICATION EN CAS D'ENTREE/SORTIE, SI DEJA DECLARE LOCALEMENT CAR DOUBLETTE INTERDITE----'
        If myUser.isLocalOutputAlreadyDoneForUser(tbnoetiq.Text) Then
            MsgBox("Attention, vous avez déjà déclaré ce contenant en entree/sortie !", MsgBoxStyle.Exclamation, "Sortie impossible")
            Exit Sub
            'ElseIf UserManager.getInstance.isLocalInputAlreadyDoneForUsers(tbnoetiq.Text) Then
            '    MsgBox("Attention, vous avez déjà déclaré ce contenant en entrée!", MsgBoxStyle.Exclamation, "Entrée impossible")
            '    Exit Sub
        End If

        'Séparation des numéros pour la partie détachable'
        Dim NoEtiq As String = tbnoetiq.Text
        Dim SeparateValue() As String
        Dim Noof As String
        Dim NooP As String
        Dim NumEtiq As String
        Dim bGOPAL As Boolean = False

        'La partie detachable est ok, reste a savoir si il faut recuperer le numero d'OF ou non'
        'On compte le nombre de parties qu'il y a dans le numero etiquette'
        'Si il n'y a pas le numéro d'of dans la partie détachable, on le demande à l'utilisateur'

        If Not NoEtiq.Split("/").Length = 3 Then
            SeparateValue = NoEtiq.Split("/")
            If NoEtiq.StartsWith("G") Or NoEtiq.StartsWith("A") Then
                NooP = ""
                Noof = ""
                NumEtiq = -1
                bGOPAL = True
                If currentGOPAL = "" Then
                    currentGOPAL = NoEtiq.Substring(0, 10)
                    listGOPAL.Add(currentGOPAL)
                Else
                    Dim bNewGOPAL = False
                    If Not currentGOPAL = NoEtiq.Substring(0, 10) Then
                        bNewGOPAL = Not listGOPAL.Contains(NoEtiq.Substring(0, 10))

                        If bNewGOPAL Then
                            currentGOPAL = NoEtiq.Substring(0, 10)
                            listGOPAL.Add(currentGOPAL)
                        End If
                    End If
                End If
            Else
                NooP = SeparateValue(0)
                NumEtiq = SeparateValue(1)

                'Demande du numero d'OF'
                numeroOF = Nothing
                Dim frmDOF As New frmDemandeOF
                frmDOF.ShowDialog()

                'Si rien est donné, on annule'
                If numeroOF = Nothing Then
                    Exit Sub
                End If

                Noof = numeroOF

            End If
        Else 'Le numéro d'OF est présent'
            SeparateValue = NoEtiq.Split("/")
            Noof = SeparateValue(0)
            NooP = SeparateValue(1)
            NumEtiq = SeparateValue(2)

            'Verification que la valeur de l'OF scanné ne contient que des chiffres'
            If Not IsNumeric(Noof) Then
                MsgBox("Le numéro d'OF contenu dans la partie détachable ne doit contenir que des chiffres !", MsgBoxStyle.Exclamation, "Info invalide")
                tbnoetiq.Focus()
                Exit Sub
            End If
        End If

        '---------- DATA OK A PARTIR D'ICI -------------'
        'Permet d'enlever correctement l'affichage de la fenetre de demande de l'OF'
        Refresh()
        numMachine = machine

        Dim quantiteDejaPresente As String = Nothing
        Dim quantiteEffectue As String = Nothing

        'Affichage de la petite fenetre de chargement'
        Dim FC As New frmChargement
        FC.Show()
        FC.Refresh()

        If isConnectionOK() Then
            If updlMng.isIOFullPresentInDB(tbnoetiq.Text, mode) Then
                FC.Close()
                MsgBox("Attention, ce contenant a déjà été déclaré en " & mode & " !", MsgBoxStyle.Exclamation, mode & " impossible")
                FC.Close()
                FC.Dispose()
                Exit Sub
            End If


            Dim isDataOk As Boolean = False
            'Récuperation des données depuis la table demande et boucle_gopal'
            Try
                If bGOPAL Then
                    getDetailEtiquetteGOPAL(tbnoetiq.Text, noLot, Noof, NooP)
                    getDetailsEtiquette(noLot, noProd, isDataOk)
                Else
                    getDetailsEtiquette(Noof, NooP, NumEtiq, noLot, noProd, isDataOk)
                End If
                getABVNomProd(noProd, abv, Noof)
            Catch ex As Exception
            End Try

            If Not isDataOk Then
                FC.Close()
                FC.Dispose()
                Dim reponse = MsgBox("Etes-vous sûr d'avoir scanner l'étiquette " & tbnoetiq.Text, vbYesNo + vbQuestion, "Confirmation OF")
                If reponse = MsgBoxResult.No Then
                    tbnoetiq.Text = ""
                    tbnoetiq.Focus()
                    Exit Sub
                End If
            End If

        Else
            If bGOPAL Then
                Dim demandeOF As New frmDemandeOF
                Dim bNewGOPAL As Boolean = False
                demandeOF.ShowDialog()
                If numeroOF Is Nothing Then
                    FC.Close()
                    Exit Sub
                End If
                Noof = numeroOF
                NooP = ""
                noProd = ""

                bNewGOPAL = Not listGOPAL.Contains(NoEtiq.Substring(0, 10))

            End If
        End If

        'On ajoute la saisie dans les DTs'
        myUser.addIO(mode, noLot, noProd, abv, Noof, NoEtiq, quantiteEffectue, "", numMachine, "", "", "", 0)
        myUser.miseAJourSaisie()

        '  currentUser.addSaisie1(0, Noof, NooP, tbNumMach.Text, False, noProd)

        If isConnectionOK() Then
            'Check si la session a été créée en BDD, et essaye d'insérer l'entrée/sortie'
            If codeSaisieActu = Nothing Then
                Try 'Tentative de creation de la Session en base de données. Si réussi, récupération du numéro de session'
                    codeSaisieActu = updlMng.insertSessionSaisie(Secteur, posteActuel)
                Catch ex As Exception
                    codeSaisieActu = Nothing
                End Try
            End If

            'On essaye de remonter en bdd le contenu de la DT des IOs, seulement si on a réussi a créer une session en bdd au préalable'
            If Not codeSaisieActu = Nothing Then
                Try
                    updlMng.insertAllIO()
                Catch
                End Try
            End If
        End If

        'Verification si le numero d'of est contenu dans la liste des OF'
        If Not myUser.getListOf.Contains(Noof) Then
            myUser.addOF(Noof)
        End If

        myRebut.addMachine(Noof, tbNumMach.Text)

        fabEncours(Noof, NooP, noProd, abv, machine)

        FC.Close()
        FC.Dispose()

        affichageValide(Me)

        'reinit des TB'
        reinitChamp()
        If bMono Or (tbNumMach.Text = PdCFourG) Or (tbNumMach.Text = "AE0153") Or (tbNumMach.Text = "AE0155") Then
            tbnoetiq.Focus()
        Else
            tbNumMach.Focus()
        End If
        Refresh()
    End Sub

    Private Sub reinitChamp()
        If (Not bMono) And (Not tbNumMach.Text = PdCFourG) And (Not (tbNumMach.Text = "AE0153" Or tbNumMach.Text = "AE0155")) Then
            tbNumMach.Text = ""
        End If
        tbnoetiq.Text = ""
    End Sub
End Class