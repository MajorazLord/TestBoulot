

Public Class frmChangeParam

    Private Sub frmChangeParam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LOperateur.Text = "Opérateur: " & myUser.getPointage
        LPoste.Text = "Poste: " & posteActuel

        TimerDeco.Interval = 0
        TimerDeco.Enabled = False

        'Timer de 15min
        TimerSecu.Interval = 900000
        TimerSecu.Enabled = False

        If horaireStandard = True Then
            RbOui.Checked = True
        Else
            RbNon.Checked = True
        End If
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


    Public Sub RbOui_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbOui.CheckedChanged
        If RbOui.Checked = True Then
            horaireStandard = True
            LbActiv.Visible = True
            LbDesac.Visible = False
            'fin auto
            LancerTimerDeco()
        End If
        If RbNon.Checked = True Then
            horaireStandard = False
            LbActiv.Visible = False
            LbDesac.Visible = True
            'raz fin auto
            ArretTimerDeco()
        End If
    End Sub

    Private Sub frmChangeParam_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        'If decoAutoFermeture = "Close" Then
        'Me.Close()
        'End If
    End Sub
    
End Class