Imports System.Data
Imports Datalogic.API

Public Class frmRebuts

    Public NoEtiq As String

    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    Private Sub frmRebutsTout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fenetreAide = fenetreRebut

        PBAddOF.Image = New Bitmap(My.Resources.Icone_Add)
        PBAddCode.Image = New Bitmap(My.Resources.Icone_Add)
        PBAddMachine.Image = New Bitmap(My.Resources.Icone_Add)
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        PBRecap.Image = New Bitmap(My.Resources.recapitulatif)

        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            initRebutTR()
            loadFullDecodeur(hDcd, Me, dcdEvent)
        Else
            PNumOF.Visible = True
            PScan.Visible = False
            PNumOF.BringToFront()

            If Not getNomSecteur.Equals(Controle) Then
                Me.Text = "Rebuts"
                LTitre.Text = "Rebuts"
                LPEcartees.Text = "Nb rebuts:"
            Else
                Me.Text = "Pièces écartées"
                LTitre.Text = "Pièces écartées"
                LPEcartees.Text = "P. écartées:"
            End If

            CBOF.DataSource = myUser.getListOf

            If myUser.getListOf.Count = 0 Then
                CBOF.Enabled = False
            End If
        End If

        If Not TBNumEtiq.Text.Length = 0 Then
            If TBNumEtiq.Text.StartsWith("G") Or TBNumEtiq.Text.StartsWith("A") Then
                Dim noof = ""
                getDetailEtiquetteGOPAL(TBNumEtiq.Text, "", noof, "")
                CBMachine.DataSource = myRebut.getListOfValue(noof)
            Else
                CBMachine.DataSource = myRebut.getListOfValue(TBNumEtiq.Text.Split("/")(0))
            End If
        Else
            CBMachine.DataSource = myRebut.getListOfValue(CBOF.SelectedValue)
        End If

        If bMono Then
            If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
                PBAddMachine.Visible = True
            Else
                PBAddMachine.Visible = False
            End If
        Else
            PBAddMachine.Visible = True
        End If

        If bMono Or CBMachine.Items.Count = 1 Or CBMachine.Items.Count = 0 Then
            CBMachine.Enabled = False
        Else
            CBMachine.Enabled = True
        End If
    End Sub

    ''' <summary>
    ''' Permet d'initialiser la fenetre lorsque c'est du temps réel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initRebutTR()
        PNumOF.Visible = False
        PScan.Visible = True
        PScan.Location = PNumOF.Location
        PScan.BringToFront()

        If NoEtiq IsNot Nothing Then
            TBNumEtiq.Text = NoEtiq
        Else
            TBNumEtiq.Focus()
        End If
    End Sub

    Private Sub PBAddOF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAddOF.Click
        Dim frOF As New frmCreerOF

        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            dcdEvent.Dispose()
        End If

        frOF.ShowDialog()

        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            loadFullDecodeur(hDcd, Me, dcdEvent)
        End If

        CBOF.DataSource = Nothing
        CBOF.DataSource = myUser.getListOf

        If ajoutNumeroOF = Nothing Then
            Exit Sub
        Else
            CBOF.SelectedItem = ajoutNumeroOF
        End If
        
        CBOF.Enabled = True

        If bMono Then
            CBMachine.DataSource = Nothing
            myRebut.addMachine(ajoutNumeroOF, monoMachine)
            CBMachine.DataSource = myRebut.getListOfValue(ajoutNumeroOF)
        End If
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        CBOF.Dispose()
        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            dcdEvent.Dispose()
            TBNumEtiq.Dispose()
            BDelScan.Dispose()
        End If
        Me.Close()
    End Sub

    Private Sub PBRecap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRecap.Click
        frmRecapRebuts.ShowDialog()
    End Sub

    Private Sub PBAddCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAddCode.Click
        frmR = Me
        frmHelp.ShowDialog()

        If (Not TBCode.Text = "") And TBEcartees.Text = "" Then
            TBEcartees.Focus()
        ElseIf (Not TBCode2.Text = "") And TBEcartees2.Text = "" Then
            TBEcartees2.Focus()
        End If
    End Sub

    Private Sub BValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BValider.Click
        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            validerRebutTR()
        Else
            validerRebut()
        End If
    End Sub

    Private Sub BDelScan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelScan.Click
        TBNumEtiq.Text = ""
        TBNumEtiq.Focus()
    End Sub

    Private Function isVerificationCode(ByVal elementCode As TextBox, ByVal elementRebut As TextBox) As Boolean
        Dim foundRow() As DataRow
        foundRow = DTcodeDEF.Select("Code = '" & elementCode.Text & "'")
        If foundRow.Count = 0 Then
            MsgBox("Le code rebut doit être présent dans la grille des codes", MsgBoxStyle.Exclamation, "Code invalide")
            elementCode.Text = ""
            elementRebut.Text = ""
            elementCode.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Permet d'ajouter les lignes effectuées dans la DT des rebuts
    ''' </summary>
    ''' <param name="elementCode"></param>
    ''' <param name="elementRebut"></param>
    ''' <remarks></remarks>
    Private Sub ajoutLigneEffectueesRebuts(ByVal elementCode As TextBox, ByVal elementRebut As TextBox)
        Dim row() As DataRow
        row = myUser.getDTRebuts.Select("N°OF = '" & CBOF.SelectedValue & "' and Code='" & elementCode.Text & "' and Machine ='" & CBMachine.SelectedValue & "'")

        Try
            If row.Count <> 0 Then
                row(0).Item(2) = row(0).Item(2) + Convert.ToInt32(elementRebut.Text)
            Else
                myUser.addPiecesEcrt(CBOF.SelectedValue, elementCode.Text, elementRebut.Text, CBMachine.SelectedValue)
            End If

            Dim noProd = ""
            If isConnectionOK() Then
                getDetailEtiquetteNumProduit(CBOF.SelectedValue, noProd)
            End If

            myUser.addSaisieRebuts(elementCode.Text, elementRebut.Text, CBOF.SelectedValue, CBMachine.SelectedValue)
            myUser.miseAJourDeclaration()
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Permet d'ajouter les lignes effectuées dans la DT des rebutsTR
    ''' </summary>
    ''' <param name="elementCode"></param>
    ''' <param name="elementRebut"></param>
    ''' <remarks></remarks>
    Private Sub ajoutLigneEffectueesRebutsTR(ByVal elementCode As TextBox, ByVal elementRebut As TextBox)
        Try
            myUser.addPiecesEcrtTR(TBNumEtiq.Text, elementCode.Text, Convert.ToInt32(elementRebut.Text), CBMachine.SelectedValue)
        Catch
        End Try

        Try
            myUser.addPiecesEcrtTRRECAP(TBNumEtiq.Text, elementCode.Text, Convert.ToInt32(elementRebut.Text), CBMachine.SelectedValue)
        Catch
        End Try

        Dim ligne() = TBNumEtiq.Text.Split("/")
        Dim noProd = ""
        Dim Noof As String = ""
        If isConnectionOK() Then
            If TBNumEtiq.Text.StartsWith("G") Or TBNumEtiq.Text.StartsWith("A") Then
                getDetailEtiquetteGOPAL(TBNumEtiq.Text, "", Noof, "")
                getDetailEtiquetteNumProduit(Convert.ToInt32(Noof), noProd)

            Else
                getDetailEtiquetteNumProduit(ligne(0), noProd)
            End If
        End If

        If Not Noof.Length = 0 Then
            myUser.addSaisieRebuts(elementCode.Text, elementRebut.Text, Noof, CBMachine.SelectedValue)
        Else
            myUser.addSaisieRebuts(elementCode.Text, elementRebut.Text, ligne(0), CBMachine.SelectedValue)
        End If

        myUser.miseAJourDeclaration()
    End Sub

    ''' <summary>
    ''' Valide les lignes des Rebuts
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub validerRebut()
        If CBOF.SelectedValue Is Nothing Then
            MsgBox("Veuillez sélectionner un numéro d'OF", MsgBoxStyle.Exclamation, "OF manquant")
            Exit Sub
        End If

        If CBMachine.Items.Count = 0 Then
            MsgBox("Veuillez ajouter une machine.", MsgBoxStyle.Exclamation, "Machine manquante")
            Exit Sub
        End If

        If Not isVerificationChamps() Then
            Exit Sub
        End If

        For Each ctrl As Control In Me.Controls
            If ctrl.Name = "TBCode" Then
                ajoutLigneEffectueesRebuts(TBCode, TBEcartees)
            ElseIf ctrl.Name = "TBCode2" Then
                If Not TBCode2.Text = "" Then
                    ajoutLigneEffectueesRebuts(TBCode2, TBEcartees2)
                End If
            End If
        Next

        reinitChampsFenetre(False)
    End Sub

    ''' <summary>
    ''' Valide les lignes des RebutsTR
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub validerRebutTR()
        Dim upldM As New UploadManager
        Dim FC As New frmChargement

        If TBNumEtiq.Text = "" Then
            MsgBox("Veuillez scanner la partie détachable.", MsgBoxStyle.Exclamation, "Partie détachable manquante")
            TBNumEtiq.Focus()
            Exit Sub
        Else
            If Not isNoEtiqOK(TBNumEtiq.Text) Then
                MsgBox("La partie détachable est invalide.", MsgBoxStyle.Exclamation, " Partie détachable invalide")
                TBNumEtiq.Text = ""
                TBNumEtiq.Focus()
                Exit Sub
            End If
        End If

        If CBMachine.Items.Count = 0 Then
            MsgBox("Veuillez ajouter une machine.", MsgBoxStyle.Exclamation, "Machine manquante")
            Exit Sub
        End If

        If Not isVerificationChamps() Then
            Exit Sub
        End If

        FC.Show()
        FC.Refresh()

        For Each ctrl As Control In Me.Controls
            If ctrl.Name = "TBCode" Then
                ajoutLigneEffectueesRebutsTR(TBCode, TBEcartees)
            ElseIf ctrl.Name = "TBCode2" Then
                If Not TBCode2.Text = "" Then
                    ajoutLigneEffectueesRebutsTR(TBCode2, TBEcartees2)
                End If
            End If
        Next

        If isConnectionOK() Then
            If codeSaisieActu = Nothing Then
                Try
                    codeSaisieActu = upldM.insertSessionSaisie(Secteur, posteActuel)
                Catch ex As Exception
                    codeSaisieActu = Nothing
                End Try
            End If

            If Not codeSaisieActu = Nothing Then
                Try
                    upldM.insertAllRebuts()
                Catch ex As Exception
                    Debug.WriteLine(ex)
                    'TODO 

                End Try
            End If
        End If

        FC.Close()
        FC.Dispose()

        reinitChampsFenetre(True)
    End Sub

#Region "LostFocus des TBCode"

    Private Sub TBCode_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCode.LostFocus
        verificationChampsCode(TBCode)
    End Sub

    Private Sub TBCode2_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBCode2.LostFocus
        verificationChampsCode(TBCode2)
    End Sub

    Private Sub verificationChampsCode(ByVal elementCode As TextBox)
        If elementCode.Text <> "" Then
            elementCode.Text = elementCode.Text.Trim()

            If IsNumeric(elementCode.Text) Then
                elementCode.Text = Convert.ToInt32(elementCode.Text)

                Dim numero As Integer
                numero = elementCode.Text

                If numero > 0 And numero < 10 Then
                    elementCode.Text = "0" & numero
                End If
            Else
                elementCode.Text = elementCode.Text.ToUpper
            End If

        End If
    End Sub

#End Region

#Region "KeyPress des TBEcartees"

    Private Sub TBEcartees_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBEcartees.KeyPress
        verificationChampsEtiq(e)
    End Sub

    Private Sub TBEcartees2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBEcartees2.KeyPress
        verificationChampsEtiq(e)
    End Sub

    Private Sub verificationChampsEtiq(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

    Private Sub TBNumEtiq_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumEtiq.KeyPress
        e.Handled = True
    End Sub

#Region "Boutton supprimer ligne"
    Private Sub BDelLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelLigne.Click
        TBCode.Text = ""
        TBEcartees.Text = ""
        TBCode.Focus()
    End Sub

    Private Sub BDelLigne2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelLigne2.Click
        TBCode2.Text = ""
        TBEcartees2.Text = ""
        TBCode2.Focus()
    End Sub

#End Region

    ''' <summary>
    ''' Fonction appelé si la fenetre est en mode temps réel
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dcdEvent_Scanned(ByVal sender As System.Object, ByVal e As DecodeEventArgs) Handles dcdEvent.Scanned
        Dim codeID As CodeId = codeID.NoData
        Dim dcdData As String = ""
        Dim bBadRead As Boolean = False

        Try
            dcdData = hDcd.ReadString(e.RequestID, codeID)
        Catch ex As Exception
            MessageBox.Show("Problème lors de la lecture.")
            bBadRead = True
        End Try

        If Not bBadRead Then
            For Each ctrl As Control In Me.PScan.Controls
                If ctrl.Focused Then
                    If ctrl.Name = "TBNumEtiq" Then
                        If isNoEtiqOK(dcdData) Then
                            affichePointVert()
                            TBNumEtiq.Text = dcdData
                            TBCode.Focus()
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub

    Private Function isVerificationChamps() As Boolean
        If TBCode.Text = "" Then
            MsgBox("Veuillez saisir un code de rebut.", MsgBoxStyle.Exclamation, "Code manquant")
            TBCode.Focus()
            Return False
        Else
            For Each ctrl As Control In Me.Controls
                If ctrl.Name = "TBCode" Then
                    If Not isVerificationCode(TBCode, TBEcartees) Then
                        Return False
                    End If
                ElseIf ctrl.Name = "TBCode2" Then
                    If Not TBCode2.Text = "" Then
                        If Not isVerificationCode(TBCode2, TBEcartees2) Then
                            Return False
                        End If
                    End If
                End If
            Next
        End If

        If TBEcartees.Text = "" Then
            MsgBox("Veuillez saisir une quantité de rebuts.", MsgBoxStyle.Exclamation, "Quantité manquante")
            TBEcartees.Focus()
            Return False
        ElseIf (Not TBCode2.Text = "") And TBEcartees2.Text = "" Then
            MsgBox("Veuillez saisir une quantité de rebuts.", MsgBoxStyle.Exclamation, "Quantité manquante")
            TBEcartees2.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub reinitChampsFenetre(ByVal bTR As Boolean)
        affichageValide(Me)
        TBCode.Text = ""
        TBCode2.Text = ""
        TBEcartees.Text = ""
        TBEcartees2.Text = ""
        If bTR Then
            TBNumEtiq.Focus()
        Else
            TBCode.Focus()
        End If
    End Sub

    Private Sub CBOF_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBOF.SelectedValueChanged
        CBMachine.DataSource = Nothing
        CBMachine.DataSource = myRebut.getListOfValue(CBOF.SelectedValue)

        If bMono Or CBMachine.Items.Count = 1 Or CBMachine.Items.Count = 0 Then
            CBMachine.Enabled = False
        Else
            CBMachine.Enabled = True
        End If
    End Sub

    Private Sub PBAddMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAddMachine.Click
        Dim addMach As New frmAddMachine
        If CBOF.SelectedValue = Nothing And TBNumEtiq.Text = "" Then
            MsgBox("Ajout d'une machine impossible sans numéro d'OF", MsgBoxStyle.Exclamation, "Ajout impossible de machine")
            Exit Sub
        End If

        If CBOF.SelectedValue = Nothing Then
            If TBNumEtiq.Text.Split("/").Count = 3 Then
                currentOFRebuts = TBNumEtiq.Text.Split("/")(0)
            Else
                Dim Noof As String = ""
                getDetailEtiquetteGOPAL(TBNumEtiq.Text, "", Noof, "")
                currentOFRebuts = Noof
            End If
        Else
            currentOFRebuts = CBOF.SelectedValue
        End If

        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            dcdEvent.Dispose()
        End If

        addMach.ShowDialog()

        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            loadFullDecodeur(hDcd, Me, dcdEvent)
        End If

        If Not ajoutMachine Is Nothing Then
            myRebut.addMachine(currentOFRebuts, ajoutMachine)
            CBMachine.DataSource = Nothing

            CBMachine.DataSource = myRebut.getListOfValue(currentOFRebuts)

            If bMono Or CBMachine.Items.Count = 1 Or CBMachine.Items.Count = 0 Then
                CBMachine.Enabled = False
            Else
                CBMachine.Enabled = True
            End If
        End If

    End Sub

End Class