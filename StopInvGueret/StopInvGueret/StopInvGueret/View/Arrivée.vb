Imports Datalogic.API

Public Class Arrivée
    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    Private Sub Arrivée_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub

    ''' <summary>
    ''' Fonction appelée lors du scan d'un code barre, afin d'associé le codebarre au bon TF
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
            For Each ctrl As Control In Me.Controls()
                'Est-ce celui sur lequel on est'
                If ctrl.Focused Then
                    If ctrl.Name = "TbScan" Then
                        If (dcdData.StartsWith("AE") And dcdData.Length < 10 And dcdData.Length > 5 And IsNumeric(dcdData.Substring(2))) Or (dcdData.Length < 3 And IsNumeric(dcdData)) Then
                            'affichePointVert()
                            'TbScan.Text = dcdData
                            'TbQtité.Focus()
                        ElseIf dcdData.StartsWith(PdCFourG) Then
                            'affichePointVert()
                            'TbScan.Text = dcdData
                            'TbQtité.Focus()
                        Else
                            affichePointVert()
                            TbScan.Text = dcdData
                            TbQtité.Focus()
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub

    Private Sub BtnRecap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRecap.Click
        Dim frmRecapArrivee As New RecapArrivee
        frmRecapArrivee.ShowDialog()
    End Sub

    Private Sub BtnCont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCont.Click
        If TbScan.Text.CompareTo("") & TbQtité.Text.CompareTo("") Then
            myUser.DTArrivee.Rows.Add(TbScan.Text, TbQtité.Text)
            TbScan.Text = ""
            TbQtité.Text = ""
            'TODO
            'Ecrire direct en BDD
        End If
    End Sub

    Private Sub Arrivee_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCont.GotFocus, MyBase.GotFocus
        loadFullDecodeur(hDcd, Me, dcdEvent)
    End Sub

    Private Sub Arrivee_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCont.LostFocus, MyBase.Deactivate
        dcdEvent.Dispose()
    End Sub

    Private Sub BTerm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTerm.Click
        If TbScan.Text.CompareTo("") & TbQtité.Text.CompareTo("") & myUser.DTArrivee.Rows.Count = 0 Then
            MsgBox("Rien n'a été saisie ! Annulation de la saisie.", MsgBoxStyle.OkOnly, "Attention Saisie")
            Me.Close()
        ElseIf TbScan.Text.CompareTo("") & TbQtité.Text.CompareTo("") & myUser.DTArrivee.Rows.Count <> 0 Then
            myUser.DTArrivee.Clear()
            Me.Close()
        Else
            myUser.DTArrivee.Rows.Add(TbScan.Text, TbQtité.Text)
            TbScan.Text = ""
            TbQtité.Text = ""
            'TODO
            'Ecrire direct en BDD
            myUser.DTArrivee.Clear()
            Me.Close()
        End If
    End Sub

    Private Sub BtnDelDétach_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelDétach.Click
        TbScan.Text = ""
    End Sub

    Private Sub BtnDelQtité_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelQtité.Click
        TbQtité.Text = ""
    End Sub
End Class