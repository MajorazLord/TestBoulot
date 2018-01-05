Public Class frmTempsProduction
    Private rows() As String
    Private values As New ArrayList
    Private utilUpload As New UploadManager
    Private currentItem As Integer
    Private nbRow As Integer
    Private machines() As String

    Private Sub frmHeureProduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim value(5) As String
        Dim uploadM As New UploadManager

        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        PBRecap.Image = New Bitmap(My.Resources.recapitulatif)
        PBAdd.Image = New Bitmap(My.Resources.Ok)

        Try
            nbRow = utilUpload.uploadDataTempsProd(values)
        Catch ex As Exception
        End Try

        If choix Then
            PBRetour.Visible = False
        Else
            PBRetour.Visible = True
        End If

        If nbRow = 0 Then
            LAucuneProd.Visible = True
            BValider.Enabled = False
            LVTempsProd.Visible = False
            LProdAuj.Visible = False
            If isScreenVGA() Then
                BArretMachine.Width = 234 * 2
                BArretMachine.Height = 40 * 2
            Else
                BArretMachine.Width = 234
                BArretMachine.Height = 40
            End If
            
        Else

            If isScreenVGA() Then
                BArretMachine.Width = 98 * 2
                BArretMachine.Height = 35 * 2
            Else
                BArretMachine.Width = 98
                BArretMachine.Height = 35
            End If

            LAucuneProd.Visible = False
            BValider.Enabled = True
            LVTempsProd.Visible = True
            LProdAuj.Visible = True

            Dim initRows(nbRow) As String
            rows = initRows

            If nbRow = 1 Then
                value = values(0)
                rows(0) = TPS_TRAVAIL
                LVTempsProd.Items.Add(New ListViewItem("Production 1"))
   
                myUser.addTempsProductionRECAP(1, value(0), value(1), value(2), value(3), rows(0))
                LVTempsProd.Items.Item(0).ForeColor = Color.Lime
            Else
                Array.Resize(machines, nbRow)
                Dim bDoublon As Boolean = False
                Dim bRecup As Boolean

                recupMachines(machines, bDoublon, bRecup)
                For index As Integer = 1 To nbRow
                    Dim item As ListViewItem
                    value = values(index - 1)

                    item = New ListViewItem("Production " & index)

                    If Not bDoublon Then
                        item.ForeColor = Color.Lime
                        LVTempsProd.Items.Add(item)
                        rows(index - 1) = TPS_TRAVAIL
                        myUser.addTempsProductionRECAP(index, value(0), value(1), value(2), value(3), rows(index - 1))
                    Else
                        If isDoublonMachine(machines, value(0)) Then
                            If Not value(4) = "0" Then
                                item.ForeColor = Color.Lime
                                LVTempsProd.Items.Add(item)
                                myUser.addTempsProductionRECAP(index, value(0), value(1), value(2), value(3), value(4))
                            Else
                                myUser.removeTempsProductionRECAP(value(0), value(1), value(2), value(3))
                                LVTempsProd.Items.Add(item)
                            End If
                        Else
                            item.ForeColor = Color.Lime
                            LVTempsProd.Items.Add(item)
                            rows(index - 1) = TPS_TRAVAIL
                            myUser.addTempsProductionRECAP(index, value(0), value(1), value(2), value(3), rows(index - 1))
                        End If
                    End If
                Next
        End If
        End If
    End Sub

    ''' <summary>
    ''' Fonction appelée lorsque un élément est selectionné dans la liste
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LVTempsProd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVTempsProd.SelectedIndexChanged

        Dim value(5) As String
        TBTempsProd.Text = ""
        
        Try
            value = values.Item(LVTempsProd.Items.IndexOf(LVTempsProd.FocusedItem()))
            PDetail.Visible = True
            LProduction.Text = LVTempsProd.FocusedItem().Text
            LMachine.Text = value(0)
            LOF.Text = value(1) & "/" & value(2)
            currentProd = LOF.Text
            currentMachine = LMachine.Text
            If value(3) = "" Then
                getABVNomProd(value(3), "", value(1))
            End If
            LProduit.Text = value(3)
            If Not value(4) = "0" Then
                LTempsProdAc.Visible = True
                LProdActuel.Visible = True
                LTempsProdAc.Text = Convert.ToDouble(value(4)) & " h"
            ElseIf Not rows(LVTempsProd.Items.IndexOf(LVTempsProd.FocusedItem())) = Nothing Then
                LTempsProdAc.Visible = True
                LProdActuel.Visible = True
                LTempsProdAc.Text = Convert.ToDouble(rows(LVTempsProd.Items.IndexOf(LVTempsProd.FocusedItem()))) & " h"
            Else
                LTempsProdAc.Visible = False
                LProdActuel.Visible = False
            End If

            currentItem = LVTempsProd.FocusedItem.Index
            LVTempsProd.FocusedItem.Focused = False

        Catch ex As Exception
            '' Passe 2 fois dans la méthode lors du changement d'item. 
            '' La première fois il passe dans le catch
            '' Evite de sortir de l'application lorsque il change d'item
        End Try
        TBTempsProd.Focus()
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Dim iNB As Integer

        If Not nbRow = 1 Then
            For Each element As ListViewItem In LVTempsProd.Items
                Dim value(5) As String
                Dim currentItem As Integer
                currentItem = LVTempsProd.Items.IndexOf(element)
                value = values(currentItem)
                If isDoublonMachine(machines, value(0)) Then
                    If value(4) = "0" And Not rows(currentItem) = Nothing Then
                        iNB = MsgBox("Vos modifications seront perdus si vous retournez au menu précédent. Voulez-vous continuer?", vbYesNo + vbQuestion, "annuler modification")
                        If iNB = REPONSE_OK Then
                            myUser.removeTempsProductionRECAP(value(0), value(1), value(2), value(3))
                            Exit For
                        Else
                            Exit Sub
                        End If
                    ElseIf Not value(4) = rows(currentItem) And Not rows(currentItem) = Nothing Then
                        iNB = MsgBox("Vos modifications seront perdus si vous retournez au menu précédent. Voulez-vous continuer?", vbYesNo + vbQuestion, "annuler modification")
                        If iNB = REPONSE_OK Then
                            myUser.removeTempsProductionRECAP(value(0), value(1), value(2), value(3))
                            myUser.addTempsProductionRECAP(currentItem + 1, value(0), value(1), value(2), value(3), value(4))
                            Exit For
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Next
        End If
        Me.Close()
    End Sub

    Private Sub BDelTpsProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelTpsProd.Click
        TBTempsProd.Text = ""
        TBTempsProd.Focus()
    End Sub

    Private Sub TBTempsProd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBTempsProd.KeyPress
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Delete Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Permet de valider tous les temps de production 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BValider.Click
        Dim value(6) As String
        Dim dicoMachine As New Dictionary(Of String, Double)

        For index As Integer = 1 To rows.Count - 1
            value = values(index - 1)
            If rows(index - 1) = "" And value(4) = "0" Then
                MsgBox("Il manque le temps sur la production " & index, MsgBoxStyle.Exclamation, "Temps de prod manquant")
                LVTempsProd.Items.Item(index - 1).ForeColor = Color.Red
                Exit Sub
            Else
                If Not rows(index - 1) = "" Then
                    If dicoMachine.ContainsKey(value(0)) Then
                        dicoMachine.Item(value(0)) += Convert.ToDouble(rows(index - 1))
                    Else
                        dicoMachine.Add(value(0), Convert.ToDouble(rows(index - 1)))
                    End If
                Else
                    If dicoMachine.ContainsKey(value(0)) Then
                        dicoMachine.Item(value(0)) += Convert.ToDouble(value(4))
                    Else
                        dicoMachine.Add(value(0), Convert.ToDouble(value(4)))
                    End If
                End If
            End If
        Next

        'For Each element As String In dicoMachine.Keys
        '    If Convert.ToInt32(value(5)) = 1 Then
        '        If dicoMachine.Item(element) > 12.5 Then
        '            MsgBox("Vous avez déjà validé les temps de production", MsgBoxStyle.Exclamation, "Impossible")
        '            Exit Sub
        '        End If
        '    End If
        'Next

        For index As Integer = 0 To values.Count - 1
            Dim rowLocal() As String = values.Item(index)
            myUser.removeTempsProduction(rowLocal(0), rowLocal(1))

            If Not rows(index) = "" Then
                myUser.addTempsProduction(rowLocal(0), rowLocal(1), rowLocal(2), rowLocal(3), Convert.ToDouble(rows(index)), 1)
                myUser.addSaisieProd(rowLocal(1), rowLocal(2), rowLocal(0), rows(index))
            Else
                myUser.addTempsProduction(rowLocal(0), rowLocal(1), rowLocal(2), rowLocal(3), rowLocal(4), 1)
                myUser.addSaisieProd(rowLocal(1), rowLocal(2), rowLocal(0), rowLocal(4))
            End If

            myUser.miseAJourTempsProduction()
        Next

        affichageValide(Me)
        Me.Close()
    End Sub

    ''' <summary>
    ''' Permet d'ajouter le nombre d'heure a une production
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PBAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAdd.Click
        Dim iNB As Integer
        Dim value(6) As String

        If Not TBTempsProd.Text = "" Then
            TBTempsProd.Text = Convert.ToDouble(TBTempsProd.Text)
        Else
            MsgBox("Veuillez saisir un temps de production avant de valider", MsgBoxStyle.Information, "Temps de prod invalide")
            TBTempsProd.Focus()
            Exit Sub
        End If

        If TBTempsProd.Text = 0 Then
            MsgBox("Le temps de production doit être supérieur à 0", MsgBoxStyle.Exclamation, "Temps de prod invalide")
            Exit Sub
        End If

        value = values(currentItem)
        If TBTempsProd.Text = "" Then
            MsgBox("Veuillez saisir un temps pour cette production", MsgBoxStyle.Information, "Temps de prod manquant")
            TBTempsProd.Focus()
            Exit Sub
        ElseIf Convert.ToDouble(TBTempsProd.Text) > 12.5 Then
            If Convert.ToInt32(value(5)) = 1 Then
                MsgBox("Le temps de production ne doit pas être supérieur à 12h30.", MsgBoxStyle.Exclamation, "Temps de prod trop grand")
                TBTempsProd.Text = ""
                TBTempsProd.Focus()
                Exit Sub
            End If
        ElseIf Not value(4) = "0" Then
            iNB = (MsgBox("Etes-vous sûr de vouloir changer le temps de cette production? (" & value(4) & "h actuellement)", vbYesNo + vbQuestion, "Modif temps de prod"))
            If iNB = REPONSE_OK Then
                initDTTempsProdRecap(value)
                Exit Sub
            Else
                TBTempsProd.Text = ""
                Exit Sub
            End If
        ElseIf Not rows(currentItem) = "" Then
            iNB = (MsgBox("Etes-vous sûr de vouloir changer le temps de cette production? (" & rows(currentItem) & "h actuellement)", vbYesNo + vbQuestion, "Modif temps de prod"))
            If iNB = REPONSE_OK Then
                initDTTempsProdRecap(value)
                Exit Sub
            Else
                TBTempsProd.Text = ""
                Exit Sub
            End If
        Else
            If currentItem >= 0 Then
                initDTTempsProdRecap(value)
                LTempsProdAc.Visible = True
                LProdActuel.Visible = True
                LVTempsProd.Items.Item(currentItem).ForeColor = Color.Lime
            End If
        End If
    End Sub

    ''' <summary>
    ''' Fonction qui permet d'ajouter les valeurs dans la DT tempsProductionRECAP
    ''' </summary>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Private Sub initDTTempsProdRecap(ByVal value() As String)
        rows(currentItem) = TBTempsProd.Text
        myUser.removeTempsProductionRECAP(value(0), value(1), value(2), value(3))
        myUser.addTempsProductionRECAP(currentItem + 1, value(0), value(1), value(2), value(3), rows(currentItem))
        LTempsProdAc.Text = Convert.ToDouble(TBTempsProd.Text) & " h"
        affichageValide(Me)
        TBTempsProd.Text = ""
    End Sub

    Private Sub PBRecap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRecap.Click
        Dim frmRecap As New frmRecapTempsProduction
        frmRecap.ShowDialog()
    End Sub

    Private Sub BArret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BArretProd.Click
        Dim arretProd As New frmArretProd
        arretProd.ShowDialog()
    End Sub

    Private Sub BArretMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BArretMachine.Click
        Dim arretMachine As New frmArretMachine
        arretMachine.ShowDialog()
    End Sub
End Class