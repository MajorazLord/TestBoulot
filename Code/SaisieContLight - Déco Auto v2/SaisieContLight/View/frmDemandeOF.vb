Public Class frmDemandeOF

    Private Sub frmDemandeOF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TBOF.Focus()
    End Sub

    Private Sub BAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAnnuler.Click
        numeroOF = Nothing
        Me.Close()
    End Sub

    Private Sub BOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BOK.Click
        If TBOF.Text = "" Or TBOF.Text.Length > 10 Then
            MsgBox("Numero d'OF invalide !", MsgBoxStyle.Exclamation, "OF invalide")
            TBOF.Text = ""
            TBOF.Focus()
            Exit Sub
        End If
        Try
            numeroOF = Convert.ToInt32(TBOF.Text).ToString

        Catch ex As Exception
            numeroOF = Nothing
            MsgBox("Numero d'OF invalide !", MsgBoxStyle.Exclamation, "OF invalide")
            TBOF.Text = ""
            TBOF.Focus()
            Exit Sub
        End Try

        Me.Close()
    End Sub

    Private Sub TBOF_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBOF.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub BDelOF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelOF.Click
        TBOF.Text = ""
        TBOF.Focus()
    End Sub

   
End Class