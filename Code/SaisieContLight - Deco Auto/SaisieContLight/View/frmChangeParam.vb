Public Class frmChangeParam

    Private Sub frmChangeParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LOperateur.Text = "Opérateur: " & myUser.getPointage
        LPoste.Text = "Poste: " & posteActuel
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddUser.Click
        Dim frmUser As New frmAddUser
        frmUser.ShowDialog()
    End Sub

    Private Sub BModifPoste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModifPoste.Click
        Dim frmPoste As New frmChangePoste
        frmPoste.ShowDialog()
        LPoste.Text = "Poste: " & posteActuel
    End Sub


    Private Sub BReset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BReset2.Click
        Dim frmOptions As New frmOptions
        frmOptions.BReset_Click(sender, e)
    End Sub
End Class