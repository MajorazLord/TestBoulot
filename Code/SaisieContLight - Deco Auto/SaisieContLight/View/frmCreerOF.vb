Imports Datalogic.API
Imports System.Data

Public Class frmCreerOF

    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    Private Sub frmCreerOF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        loadFullDecodeur(hDcd, Me, dcdEvent)
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

        Try
            dcdData = hDcd.ReadString(e.RequestID, cID)
        Catch ex As Exception
            MessageBox.Show("Problème lors de la lecture")
            bBadRead = True
        End Try

        If Not bBadRead Then
            For Each ctrl As Control In Me.Controls
                'Est-ce celui sur lequel on est'
                If ctrl.Focused Then
                    If ctrl.Name = "TBOF" Then
                        If isNoEtiqOK(dcdData) Then
                            If dcdData.Split("/").Length = 3 Then
                                affichePointVert()
                                TBOF.Text = dcdData.Split("/")(0)
                            Else
                                Dim noof As String = ""
                                affichePointVert()
                                getDetailEtiquetteGOPAL(dcdData, "", noof, "")
                                TBOF.Text = noof
                            End If
                        End If
                    End If
                End If
            Next
        Else
            Exit Sub
        End If

    End Sub

    Private Sub btvalid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btajouter.Click

        'Re-verification des données insérées dans la TB'
        If TBOF.Text = "" Or TBOF.Text.Length > 10 Or Not IsNumeric(TBOF.Text) Then

            MsgBox("Numero d'OF invalide", MsgBoxStyle.Exclamation, "OF invalide")
            TBOF.Text = ""
            TBOF.Focus()
            Exit Sub

        End If

        If myUser.getListOf.Contains(TBOF.Text) Then
            MsgBox("Numero d'OF déjà présent !", MsgBoxStyle.Exclamation, "OF invalide")
            TBOF.Text = ""
            TBOF.Focus()
            Exit Sub
        End If

        dcdEvent.Dispose()
        'Verification OK, ajoute l'OF'
        ajoutNumeroOF = Nothing
        ajoutNumeroOF = TBOF.Text
        myUser.addOF(TBOF.Text)
        PBRetour_Click(Me, e)

    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        dcdEvent.Dispose()
        Me.Close()
    End Sub

    Private Sub BDelOF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelOF.Click
        TBOF.Text = ""
        TBOF.Focus()
    End Sub

    Private Sub TBOF_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBOF.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
End Class