Imports Datalogic.API

Public Class frmParametre

    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    Private Sub frmParametre_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        initialisationSecteur()
        LNomSecteur.Text = Secteur & "--" & getNomSecteur()
        CBSecteur.SelectedItem = Secteur

        CBMultiMachine.Checked = Not bMono
        CBUniMachine.Checked = bMono
        If bMono Then
            PMachineUnique.Visible = True
            TBNumMachine.Text = monoMachine
        Else
            PMachineUnique.Visible = False
            TBNumMachine.Text = ""
        End If
        loadFullDecodeur(hDcd, Me, dcdEvent)
    End Sub

    Private Sub initialisationSecteur()
        CBSecteur.Items.Add(CodeDebitage)
        CBSecteur.Items.Add(CodeInstall)
        CBSecteur.Items.Add(CodePresse300)
        CBSecteur.Items.Add(CodePresse390)
        CBSecteur.Items.Add(CodeUsinageA)
        CBSecteur.Items.Add(CodeUsinageM)
        CBSecteur.Items.Add(CodeControleCU)
        CBSecteur.Items.Add(CodeControleCV)
        CBSecteur.Items.Add(CodePresse500)
        CBSecteur.Items.Add(CodeInstallG)
        CBSecteur.Items.Add(CodeUsinageG)
        CBSecteur.Items.Add(CodePresseG)
        CBSecteur.Items.Add(CodeControleG)
    End Sub

    ''' <summary>
    ''' Fonction appelé lors d'un scan d'un code barre
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
            For Each ctrl As Control In PMachineUnique.Controls
                If ctrl.Focused Then
                    If ctrl.Name = "TBNumMachine" Then
                        If (dcdData.StartsWith("AE") And dcdData.Length < 10 And dcdData.Length > 5 And IsNumeric(dcdData.Substring(2))) Or (dcdData.Length < 3 And IsNumeric(dcdData)) Then
                            affichePointVert()
                            TBNumMachine.Text = dcdData
                        End If
                    End If
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        dcdEvent.Dispose()
        Me.Close()
    End Sub

    Private Sub TBNumMachine_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumMachine.KeyPress
        e.Handled = True
    End Sub

    Private Sub CBUniMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBUniMachine.Click
        CBUniMachine.Checked = True
        CBMultiMachine.Checked = False
        PMachineUnique.Visible = True
        TBNumMachine.Focus()
    End Sub

    Private Sub CBMultiMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBMultiMachine.Click
        CBMultiMachine.Checked = True
        CBUniMachine.Checked = False
        PMachineUnique.Visible = False
        TBNumMachine.Text = ""
    End Sub

    Private Sub BDelMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelMachine.Click
        TBNumMachine.Text = ""
        TBNumMachine.Focus()
    End Sub

    Private Sub BModifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BModifier.Click
        If TCParametre.SelectedIndex = 0 Then
            If CBSecteur.SelectedItem = Secteur Then
                MsgBox("Il s'agit déjà du secteur actuel.", MsgBoxStyle.Information, "Impossible")
                CBSecteur.Focus()
            Else
                Secteur = CBSecteur.SelectedItem
                LNomSecteur.Text = Secteur & " -- " & getNomSecteur()

                'Modification du secteur dans le fichier Secteur.ini'
                modificationFichierSecteur(Secteur)
            End If
        ElseIf TCParametre.SelectedIndex = 1 Then
            If CBUniMachine.Checked Then
                If TBNumMachine.Text = "" Then
                    MsgBox("Scanner le numéro de machine", MsgBoxStyle.Exclamation, "Machine manquante")
                    TBNumMachine.Focus()
                    Exit Sub
                End If
                monoMachine = TBNumMachine.Text
                bMono = True
                MsgBox("Machine unique activée.", MsgBoxStyle.Information, "Machine unique")
            Else
                monoMachine = Nothing
                bMono = False
                MsgBox("Machine multiple activée", MsgBoxStyle.Information, "Machine multiple")
            End If
            modificationFichierMachine(bMono, monoMachine)
        End If

    End Sub

End Class