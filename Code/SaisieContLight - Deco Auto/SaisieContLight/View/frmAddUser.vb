Public Class frmAddUser

    Private Sub AddUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        LNumPointage.Text = myUser.getPointage
        TBNumIDAide.Text = myUser.getAide
        TBNumIDAide2.Text = myUser.getAide2
    End Sub

    Private Sub btvalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btvalid.Click
        If TBNumIDAide.Text = "" Then
            MsgBox("Veuillez saisir un numéro de pointage d'aide avant de valider", MsgBoxStyle.Exclamation, "ID manquant")
            TBNumIDAide.Focus()
            Exit Sub
        End If

        If Not isValidateIDAide() Then
            Exit Sub
        End If
        If Not isValidateIDAide2() Then
            Exit Sub
        End If

        If TBNumIDAide2.Text = TBNumIDAide.Text Then
            MsgBox("Votre numéro de pointage d'aide secondaire ne doit pas être le même que le numéro de pointage d'aide", MsgBoxStyle.Exclamation, "ID aide invalide")
            TBNumIDAide2.Text = ""
            TBNumIDAide2.Focus()
            Exit Sub
        End If

        If Not TBNumIDAide.Text = "" Then
            myUser.addPointageAide(TBNumIDAide.Text)
        End If
        If Not TBNumIDAide2.Text = "" Then
            myUser.addPointageAide2(TBNumIDAide2.Text)
        End If
        Dim FC As New frmChargement
        FC.Show()
        FC.Refresh()

        myUser.miseAJourSaisie()

        FC.Close()
        FC.Dispose()

        affichageValide(Me)
        Me.Close()
    End Sub

    Private Function isValidateIDAide() As Boolean
        If TBNumIDAide.Text <> "" Then
            If Not (Len(TBNumIDAide.Text) > 0 And Len(TBNumIDAide.Text) < 5 And IsNumeric(TBNumIDAide.Text)) Then
                MsgBox("Votre numéro de pointage d'aide est incorrect", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide.Text = ""
                TBNumIDAide.Focus()
                Return False
            ElseIf myUser.getPointage = TBNumIDAide.Text Then
                MsgBox("Votre numéro de pointage d'aide ne doit pas être le même que le numéro de pointage", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide.Text = ""
                TBNumIDAide.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Function isValidateIDAide2() As Boolean
        If TBNumIDAide2.Text <> "" Then
            If Not (Len(TBNumIDAide2.Text) > 0 And Len(TBNumIDAide2.Text) < 5 And IsNumeric(TBNumIDAide2.Text)) Then
                MsgBox("Votre numéro de pointage d'aide secondaire est incorrect", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide2.Text = ""
                TBNumIDAide2.Focus()
                Return False
            ElseIf myUser.getPointage = TBNumIDAide2.Text Then
                MsgBox("Votre numéro de pointage d'aide secondaire ne doit pas être le même que le numéro de pointage", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide2.Text = ""
                TBNumIDAide2.Focus()
                Return False
            ElseIf TBNumIDAide.Text = TBNumIDAide2.Text Then
                MsgBox("Votre numéro de pointage d'aide secondaire ne doit pas être le même que le numéro de pointage d'aide", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide2.Text = ""
                TBNumIDAide2.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BDelNumIDAide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelNumIDAide.Click
        TBNumIDAide.Text = ""
        TBNumIDAide.Focus()
    End Sub

    Private Sub TBNumIDAide_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumIDAide.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TBNumIDAide2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumIDAide2.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub BDelNumAide2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelNumAide2.Click
        TBNumIDAide2.Text = ""
        TBNumIDAide2.Focus()
    End Sub
End Class