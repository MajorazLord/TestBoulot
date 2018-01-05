Imports Datalogic.API

Public Class frmAddMachine
    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    Private Sub frmAddMachine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        resetLeds()

        loadFullDecodeur(hDcd, Me, dcdEvent)
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        LTitreOF.Visible = True
        LOF.Visible = True
        LOF.Text = currentOFRebuts
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        dcdEvent.Dispose()
        Me.Close()
    End Sub

    Private Sub BAddMach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAddMach.Click
        If TBNumMach.Text = "" Then
            MsgBox("Veuillez saisir un numéro de machine avant de valider", MsgBoxStyle.Exclamation, "Num machine manquant")
            TBNumMach.Focus()
            Exit Sub
        End If

        ajoutMachine = TBNumMach.Text
        dcdEvent.Dispose()
        Me.Close()
    End Sub

    Private Sub BDelNumMach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelNumMach.Click
        TBNumMach.Text = ""
        TBNumMach.Focus()
    End Sub

    Private Sub TBNumMach_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumMach.KeyPress
        e.Handled = True
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
        Dim noof As String = ""
        Try
            dcdData = hDcd.ReadString(e.RequestID, cID)
        Catch ex As Exception
            MessageBox.Show("Problème lors de la lecture.")
            bBadRead = True
        End Try

        If Not bBadRead Then
            For Each ctrl As Control In Me.Controls
                'Est-ce celui sur lequel on est'
                If ctrl.Focused Then
                    If ctrl.Name = "TBNumMach" Then
                        If (dcdData.StartsWith("AE") And dcdData.Length < 10 And dcdData.Length > 5 And IsNumeric(dcdData.Substring(2))) Or (dcdData.Length < 3 And IsNumeric(dcdData)) Then
                            affichePointVert()
                            TBNumMach.Text = dcdData
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub
End Class