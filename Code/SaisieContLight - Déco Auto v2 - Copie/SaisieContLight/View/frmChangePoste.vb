Public Class frmChangePoste

    Private Sub frmChangePoste_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LPoste.Text = posteActuel
        initialisationPoste()
        CBPoste.SelectedItem = posteActuel
    End Sub

    Private Sub initialisationPoste()
        CBPoste.Items.Add(Matin)
        CBPoste.Items.Add(Journee)
        CBPoste.Items.Add(Soir)
        CBPoste.Items.Add(Nuit)
        CBPoste.Items.Add(Week1)
        CBPoste.Items.Add(Week2)
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BModifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModifier.Click
        If CBPoste.SelectedItem = posteActuel Then
            MsgBox("Il s'agit déjà du poste actuel.", MsgBoxStyle.Information, "Impossible")
            CBPoste.Focus()
            Exit Sub
        End If

        posteActuel = CBPoste.SelectedItem
        LPoste.Text = posteActuel
        myUser.miseAJourSaisie()
        If Not codeSaisieActu = 0 Then
            If isConnectionOK() Then
                Dim req As New SqlCommand("update session_saisie set seposte = '" & posteActuel & "' where secodesaisie = " & codeSaisieActu, New SqlConnection(connS3SQL))
                Try
                    req.Connection.Open()
                    req.ExecuteNonQuery()
                    req.Connection.Close()
                Catch ex As Exception
                    req.Connection.Close()
                End Try
            Else
                MsgBox("Changement de poste impossible sans connexion", MsgBoxStyle.Information, "Impossible")
                Exit Sub
            End If
        End If
    End Sub

End Class