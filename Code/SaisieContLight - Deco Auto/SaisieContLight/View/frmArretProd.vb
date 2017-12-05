Imports System.Data

Public Class frmArretProd

    Private Sub frmArretProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fenetreAide = fenetreArretProd

        LProd.Text = currentProd
        LMachine.Text = currentMachine

        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        PBRecap.Image = New Bitmap(My.Resources.recapitulatif)
        PBAddCode.Image = New Bitmap(My.Resources.Icone_Add)
    End Sub

    Private Sub BValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BValider.Click
        If TBCode.Text = "" Then
            MsgBox("Veuillez indiquer un code d'arrêt", MsgBoxStyle.Exclamation, "Code manquant")
            TBCode.Focus()
            Exit Sub
        Else
            For Each ctrl As Control In Me.Controls
                If ctrl.Name = "TBCode" Then
                    If Not isVerificationCode(TBCode) Then
                        Exit Sub
                    End If
                ElseIf ctrl.Name = "TBCode2" Then
                    If Not TBCode2.Text = "" Then
                        If Not isVerificationCode(TBCode2) Then
                            Exit Sub
                        End If
                    End If
                ElseIf ctrl.Name = "TBCode3" Then
                    If Not TBCode3.Text = "" Then
                        If Not isVerificationCode(TBCode3) Then
                            Exit Sub
                        End If
                    End If
                End If
            Next
        End If

        If TBHeure.Text = "" Then
            MsgBox("Veuillez indiquer un nombre d'heure.", MsgBoxStyle.Exclamation, "Heure manquante")
            TBHeure.Focus()
            Exit Sub
        ElseIf (Not TBCode2.Text = "") And TBHeure2.Text = "" Then
            MsgBox("Veuillez indiquer un nombre d'heure.", MsgBoxStyle.Exclamation, "Heure manquante")
            TBHeure2.Focus()
            Exit Sub
        ElseIf (Not TBCode3.Text = "") And TBHeure3.Text = "" Then
            MsgBox("Veuillez indiquer un nombre d'heure.", MsgBoxStyle.Exclamation, "Heure manquante")
            TBHeure3.Focus()
            Exit Sub
        Else
            Try
                If Convert.ToDouble(TBHeure.Text) > TPS_TRAVAIL Then
                    MsgBox("Nombre d'heure incorrect. Doit être inférieur à " & TPS_TRAVAIL & ". ex: 30 min = 0.5", MsgBoxStyle.Exclamation, "Nombre invalide")
                    TBHeure.Text = ""
                    TBHeure.Focus()
                    Exit Sub
                ElseIf Convert.ToDouble(TBHeure2.Text) > TPS_TRAVAIL Then
                    MsgBox("Nombre d'heure incorrect. Doit être inférieur à " & TPS_TRAVAIL & ". ex: 30min = 0.5", MsgBoxStyle.Exclamation, "Nombre invalide")
                    TBHeure2.Text = ""
                    TBHeure2.Focus()
                    Exit Sub
                ElseIf Convert.ToDouble(TBHeure3.Text) > TPS_TRAVAIL Then
                    MsgBox("Nombre d'heure incorrect. Doit être inférieur à " & TPS_TRAVAIL & ". ex: 30min = 0.5", MsgBoxStyle.Exclamation, "Nombre invalide")
                    TBHeure3.Text = ""
                    TBHeure3.Focus()
                    Exit Sub
                End If
            Catch
            End Try
        End If

        For Each ctrl As Control In Me.Controls
            If ctrl.Name = "TBCode" Then
                ajoutLigneEffectuee(TBCode.Text, TBHeure.Text)
            ElseIf ctrl.Name = "TBCode2" Then
                If Not TBCode2.Text = "" Then
                    ajoutLigneEffectuee(TBCode2.Text, TBHeure2.Text)
                End If
            ElseIf ctrl.Name = "TBCode3" Then
                If Not TBCode3.Text = "" Then
                    ajoutLigneEffectuee(TBCode3.Text, TBHeure3.Text)
                End If
            End If
        Next

        affichageValide(Me)

        TBCode.Text = ""
        TBCode2.Text = ""
        TBCode3.Text = ""

        TBHeure.Text = ""
        TBHeure2.Text = ""
        TBHeure3.Text = ""

        TBCode.Focus()
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub PBRecap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRecap.Click
        frmRecapArretProd.ShowDialog()
    End Sub

    Private Sub TBCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBCode.KeyPress
        verificationChampsCode(e)
    End Sub

    Private Sub TBCode2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBCode2.KeyPress
        verificationChampsCode(e)
    End Sub

    Private Sub TBCode3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBCode3.KeyPress
        verificationChampsCode(e)
    End Sub

    Private Sub TBHeure_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBHeure.KeyPress
        verificationChampsHeure(e)
    End Sub

    Private Sub TBHeure2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBHeure2.KeyPress
        verificationChampsHeure(e)
    End Sub

    Private Sub TBHeure3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBHeure3.KeyPress
        verificationChampsHeure(e)
    End Sub

    Private Sub PBAddCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAddCode.Click
        Dim aide As New frmHelp
        frmAP = Me
        aide.ShowDialog()

        If (Not TBCode.Text = "") And TBHeure.Text = "" Then
            TBHeure.Focus()
        ElseIf (Not TBCode2.Text = "") And TBHeure2.Text = "" Then
            TBHeure2.Focus()
        ElseIf (Not TBCode3.Text = "") And TBHeure3.Text = "" Then
            TBHeure3.Focus()
        End If
    End Sub

    Private Sub BDelLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelLigne.Click
        TBCode.Text = ""
        TBHeure.Text = ""
        TBCode.Focus()
    End Sub

    Private Sub BDelLigne2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelLigne2.Click
        TBCode2.Text = ""
        TBHeure2.Text = ""
        TBCode2.Focus()
    End Sub

    Private Sub BDelLigne3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelLigne3.Click
        TBCode3.Text = ""
        TBHeure3.Text = ""
        TBCode3.Focus()
    End Sub

    ''' <summary>
    ''' Permet de vérifier si le code saisie est un nombre
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub verificationChampsCode(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Permet de vérifier si les heures sont des nombres (décimaux)
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub verificationChampsHeure(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Permet de vérifier si le code est présent dans la liste CODE_NP.txt
    ''' </summary>
    ''' <param name="elementCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isVerificationCode(ByVal elementCode As TextBox)
        Dim foundRow() As DataRow
        foundRow = DTcodeNP.Select("Code = '" & elementCode.Text & "'")
        If foundRow.Count = 0 Then
            MsgBox("Le code n'est pas valide.", MsgBoxStyle.Exclamation, "Code invalide")
            elementCode.Text = ""
            elementCode.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub ajoutLigneEffectuee(ByVal elementCode As String, ByVal elementHeure As String)

        myUser.addArret(LMachine.Text, LProd.Text, elementCode, elementHeure)

        myUser.addSaisieArrets(elementCode, elementHeure, LMachine.Text, LProd.Text)
        myUser.miseAJourDeclaration()
    End Sub
End Class