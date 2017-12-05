Imports Datalogic.API
Imports Microsoft.Win32
Imports System.Data

Public Class frmMouvements

    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle
    Private currentGOPAL As String = ""
    Private dicoNumCharge As New Dictionary(Of String, List(Of String))
    Private listNumCharge As New List(Of String)
    Private listGOPAL As New List(Of String)

    Private Sub frmMouvements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resetLeds()

        'Donne le mode de saisie au titre de la fenetre'
        Me.Text = mode

        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        PBRecapitulatif.Image = New Bitmap(My.Resources.recapitulatif)

        setVisibility()

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
    ''' Fonction appelée lors du scan d'un code barre, afin d'associé le codebarre au bon TF'
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
            For Each ctrl As Control In Me.PanelIO.Controls
                'Est-ce celui sur lequel on est'
                If ctrl.Focused Then
                    If ctrl.Name = "tbNumMach" Then
                        If (dcdData.StartsWith("AE") And dcdData.Length < 10 And dcdData.Length > 5 And IsNumeric(dcdData.Substring(2))) Or (dcdData.Length < 3 And IsNumeric(dcdData)) Then
                            affichePointVert()
                            tbNumMach.Text = dcdData
                            tbnoetiq.Focus()
                        End If
                    ElseIf ctrl.Name = "tbnoetiq" Then
                        If isNoEtiqOK(dcdData) Then
                            affichePointVert()
                            tbnoetiq.Text = dcdData
                            If mode = Sortie Then
                                tbQte.Focus()
                            End If
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub

#Region "Button click"
    'Click sur le bouton valider'
    Private Sub btvalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvalid.Click
        validationChampsEtiquette()
    End Sub

    'Supprime le texte présent dans le TF noetiq'
    Private Sub DelNoetiq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelNoetiq.Click
        tbnoetiq.Text = ""
        tbnoetiq.Focus()
    End Sub

    'Supprime le texte présent dans le TF qté'
    Private Sub DelQte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelQte.Click
        tbQte.Text = ""
        tbQte.Focus()
    End Sub

    'Supprime le texte présent dans le TF NumMachine'
    Private Sub DelMach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelMach.Click
        tbNumMach.Text = ""
        tbNumMach.Focus()
    End Sub

    Private Sub DelMatrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelMatrice.Click
        TBMatrice.Text = ""
        TBMatrice.Focus()
    End Sub

    Private Sub DelCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelCharge.Click
        TBCharge.Text = ""
        TBCharge.Focus()
    End Sub

    Private Sub DelVague_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelVague.Click
        TBVague.Text = ""
        TBVague.Focus()
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        dcdEvent.Dispose()
        Me.Close()
    End Sub

    Private Sub PBListe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRecapitulatif.Click
        frmRecapIO.ShowDialog()
    End Sub
#End Region

#Region "keyPress"
    'On accepte seulement les chiffres pour la quantité'
    Private Sub tbQté_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbQte.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub tbnoetiq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbnoetiq.KeyPress
        'e.Handled = True
        If Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        End If
    End Sub

    'Empeche l'utilisateur de saisir le numéro de machine'
    Private Sub tbNumMach_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbNumMach.KeyPress
        e.Handled = True
        If Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        End If
    End Sub

    Private Sub TBVague_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBVague.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TBMatrice_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBMatrice.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub TBCharge_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBCharge.KeyPress
        If Asc(e.KeyChar) = Keys.Space Then
            e.Handled = True
        ElseIf Asc(e.KeyChar) = Keys.Enter Then
            btvalid_Click(Me, e)
        Else
            e.Handled = False
        End If
    End Sub

#End Region


    ''' <summary>
    '''  Permet d'afficher les différents TextBox suivant le secteur utilisé
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub setVisibility()
        If mode.Equals("Sortie") Then
            lblQté.Visible = True
            tbQte.Visible = True
            DelQte.Visible = True

            If getNomSecteur.Equals(Install) Or getNomSecteur.Equals(InstallG) Then
                LblCharge.Visible = True
                TBCharge.Visible = True
                DelCharge.Visible = True

            ElseIf getNomSecteur.Equals(Presse) Or getNomSecteur.Equals(UsinageA) Or getNomSecteur.Equals(UsinageM) Or getNomSecteur.Equals(UsinageG) Or getNomSecteur.Equals(PresseG) Then
                LblMatrice.Visible = True
                LblMatrice.Location = LblCharge.Location

                TBMatrice.Visible = True
                TBMatrice.Location = TBCharge.Location

                DelMatrice.Visible = True
                DelMatrice.Location = DelCharge.Location
            ElseIf getNomSecteur.Equals(Controle) Or getNomSecteur.Equals(ControleG) Then
                LblCharge.Visible = True
                TBCharge.Visible = True
                DelCharge.Visible = True

                LblVague.Visible = True
                LblVague.Location = LblMatrice.Location

                TBVague.Visible = True
                TBVague.Location = TBMatrice.Location

                DelVague.Visible = True
                DelVague.Location = DelMatrice.Location
            End If
        End If
    End Sub

    Private Sub reinitChamp()
        If (Not bMono) And (Not (tbNumMach.Text = "AE0153" Or tbNumMach.Text = "AE0155")) Then
            tbNumMach.Text = ""
        End If
        tbnoetiq.Text = ""
        tbQte.Text = ""
        TBMatrice.Text = ""
        TBCharge.Text = ""
        TBVague.Text = ""

        Me.AutoScrollPosition = New Point(0, 0)
    End Sub

    ''' <summary>
    ''' Fonction de validation des informations contenue dans les champs de données. Si correct, insertion dans le fichier
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub validationChampsEtiquette()
        Dim abv As String = ""
        Dim noProd As String = ""
        Dim noLot As String = ""
        Dim updlMng As New UploadManager

        If tbNumMach.Text = "" Then
            MsgBox("La machine doit être renseignée.", MsgBoxStyle.Exclamation, "Info manquante")
            tbNumMach.Focus()
            Exit Sub
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

        If tbQte.Text = "" And mode.Equals(Sortie) Then
            MsgBox("La quantité doit être renseignée.", MsgBoxStyle.Exclamation, "Info manquante")
            tbQte.Focus()
            Exit Sub
        End If

        If tbQte.Text > 100000 Then
            MsgBox("La quantité doit être inférieur à 100000.", MsgBoxStyle.Exclamation, "Quantité invalide")
            tbQte.Text = ""
            tbQte.Focus()
            Exit Sub
        End If

        '----VERIFICATION EN CAS D'ENTREE/SORTIE, SI DEJA DECLARE LOCALEMENT CAR DOUBLETTE INTERDITE----'
        If myUser.isLocalOutputAlreadyDoneForUser(tbnoetiq.Text) Then
            MsgBox("Attention, vous avez déjà déclaré ce contenant en entrée/sortie !", MsgBoxStyle.Exclamation, "Sortie impossible")
            tbnoetiq.Text = ""
            tbnoetiq.Focus()
            Exit Sub
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
                        For Each element As String In listGOPAL
                            If element = NoEtiq.Substring(0, 10) Then
                                bNewGOPAL = False
                                Exit For
                            Else
                                bNewGOPAL = True
                            End If
                        Next
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
                NooP = ""
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
        numMachine = tbNumMach.Text

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

                If bNewGOPAL Then
                    currentGOPAL = NoEtiq.Substring(0, 10)
                    listGOPAL.Add(currentGOPAL)
                End If
            End If
        End If

        'On ajoute la saisie dans les DTs'
        myUser.addIO(mode, noLot, noProd, abv, Noof, NoEtiq, tbQte.Text, tbQte.Text, numMachine, TBCharge.Text, TBMatrice.Text, TBVague.Text, 0)
        myUser.miseAJourSaisie()

        If mode = Sortie Then
            myUser.addSaisie(tbQte.Text, Noof, NooP, tbNumMach.Text, False, noProd)
        End If

        If mode.Equals(Sortie) Then
            ' Déclare un temps de production uniquement si le mode est "sortie"
            If Secteur.Equals(CodeUsinageG) Then
                If tbNumMach.Text.StartsWith("AE2001") Or tbNumMach.Text.StartsWith("AE0058") Or tbNumMach.Text.StartsWith("AE0057.04") Then
                    myUser.addTempsProduction(tbNumMach.Text, Noof, NooP, noProd, 0, 1)
                Else
                    myUser.addTempsProduction(tbNumMach.Text, Noof, NooP, noProd, TPS_TRAVAIL, 0)
                    myUser.addTempsProductionRECAP(1, tbNumMach.Text, Noof, NooP, noProd, TPS_TRAVAIL)
                    myUser.addSaisieProd(Noof, NooP, tbNumMach.Text, TPS_TRAVAIL)
                End If
            Else
                If Secteur.Equals(CodeInstallG) Or Secteur.Equals(CodeInstall) Then
                    myUser.addTempsProduction(tbNumMach.Text, Noof, NooP, noProd, TPS_TRAVAIL, 0)
                    myUser.addTempsProductionRECAP(1, tbNumMach.Text, Noof, NooP, noProd, TPS_TRAVAIL)
                    myUser.addSaisieProd(Noof, NooP, tbNumMach.Text, TPS_TRAVAIL)

                    If isFour(tbNumMach.Text) Then
                        Dim keyChargeOF = Noof & "/" & TBCharge.Text

                        If Not listNumCharge.Contains(keyChargeOF) Then
                            listNumCharge.Add(keyChargeOF)
                            myUser.addSaisieRebuts("92", "1", Noof, tbNumMach.Text)
                            myUser.addPiecesEcrt(Noof, "92", 1, tbNumMach.Text)
                            myUser.miseAJourDeclaration()
                        End If
                    End If

                Else
                    If Secteur.Equals(CodeUsinageA) Then
                        myUser.addTempsProduction(tbNumMach.Text, Noof, NooP, noProd, TPS_TRAVAIL, 0)
                        myUser.addTempsProductionRECAP(1, tbNumMach.Text, Noof, NooP, noProd, TPS_TRAVAIL)
                        myUser.addSaisieProd(Noof, NooP, tbNumMach.Text, TPS_TRAVAIL)
                    Else
                        myUser.addTempsProduction(tbNumMach.Text, Noof, NooP, noProd, 0, 1)
                    End If

                End If
            End If
            myUser.miseAJourTempsProduction()
        End If

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

        Debug.WriteLine(codeSaisieActu)

        'Verification si le numero d'of est contenu dans la liste des OF'
        If Not myUser.getListOf.Contains(Noof) Then
            myUser.addOF(Noof)
        End If

        Debug.WriteLine("Noop: " & NooP)

        myQteProd.addProd(Noof, NooP, Convert.ToInt32(tbQte.Text), tbNumMach.Text, tbnoetiq.Text)
        myUser.miseAJourQteFinPoste()

        FC.Close()
        FC.Dispose()

        affichageValide(Me)

        'S'il s'agit du secteur controle unitaire, on affiche le menu des rebuts en cas de sortie de contenant'
        If mode.Equals(Sortie) Then
            myRebut.addMachine(Noof, tbNumMach.Text)
            If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
                Dim frmReb As New frmRebuts
                frmReb.NoEtiq = tbnoetiq.Text
                frmReb.TBCode.Focus()
                dcdEvent.Dispose()
                frmReb.ShowDialog()
                loadFullDecodeur(hDcd, Me, dcdEvent)
            End If
        End If

        'reinit des TB'
        reinitChamp()
        If bMono Or (tbNumMach.Text = "AE0153") Or (tbNumMach.Text = "AE0155") Then
            tbnoetiq.Focus()
        Else
            tbNumMach.Focus()
        End If
        Refresh()
    End Sub
End Class
