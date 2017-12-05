Imports System.Data

Public Class frmRecapContenantsNT

    Private Sub frmRecapContenantsNT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        'Liaison de la dataGrid avec la dataTable'
        DGContenant.DataSource = myUser.getDTQteFinPoste
        DGContenant.TableStyles.Clear()

        'Permet d'avoir des colonnes dont la taille est redéfinie, sinon c'est impossible de changer la taille des colonnes'
        Dim tableStyle As New DataGridTableStyle

        'Redimensionnement des colonnes'
        If isScreenVGA() Then
            initSizeColumnVGA(tableStyle)
        Else
            initSizeColumn(tableStyle)
        End If

        DGContenant.TableStyles.Add(tableStyle)

        'On enleve la selection de base de la première case'
        DGContenant.CurrentCell = Nothing

    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        'le try est présent pour empecher l'exception (out of bond, james bond) de remonter concernant le isSelected, cependant cela est necessaire pour ne pas supprimer des lignes qui ne sont pas selectionnées'
        Try
            If myUser.getDTQteFinPoste.Rows.Count <> 0 Then
                If DGContenant.CurrentRowIndex = DGContenant.CurrentCell.RowNumber And DGContenant.IsSelected(DGContenant.CurrentRowIndex) Then
                    Dim iNB As Integer
                    iNB = MsgBox("Voulez-vous supprimer cette ligne ?", vbYesNo + vbQuestion, "Suppression")
                    If iNB = REPONSE_OK Then
                        myUser.removeTempsProduction(DGContenant.Item(DGContenant.CurrentRowIndex, 4), DGContenant.Item(DGContenant.CurrentRowIndex, 0))

                        If myQteProd.getQuantiteProd(DGContenant.Item(DGContenant.CurrentRowIndex, 0), DGContenant.Item(DGContenant.CurrentRowIndex, 1), DGContenant.Item(DGContenant.CurrentRowIndex, 4)) = 0 Then
                            myUser.removeSaisie(DGContenant.Item(DGContenant.CurrentRowIndex, 0), DGContenant.Item(DGContenant.CurrentRowIndex, 1), DGContenant.Item(DGContenant.CurrentRowIndex, 4))
                        Else
                            myUser.updateSaisie(DGContenant.Item(DGContenant.CurrentRowIndex, 0), DGContenant.Item(DGContenant.CurrentRowIndex, 1), DGContenant.Item(DGContenant.CurrentRowIndex, 4))
                        End If

                        myQteProd.removeQteFinPosteActuel(DGContenant.Item(DGContenant.CurrentRowIndex, 0), DGContenant.Item(DGContenant.CurrentRowIndex, 1), DGContenant.Item(DGContenant.CurrentRowIndex, 4))

                        myUser.getDTQteFinPoste.Rows(DGContenant.CurrentRowIndex).Delete()
                        myUser.miseAJourDeclaration()
                        myUser.miseAJourTempsProduction()
                    End If
                Else
                    MsgBox("Aucune ligne séléctionnée.", MsgBoxStyle.Exclamation, "Impossible")
                    Exit Sub
                End If
            Else
                MsgBox("Aucune ligne dans le tableau.", MsgBoxStyle.Exclamation, "Impossible")
                Exit Sub
            End If
        Catch
        End Try
    End Sub

    Private Sub DGContenant_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGContenant.CurrentCellChanged
        If DGContenant.CurrentCell.RowNumber = DGContenant.CurrentRowIndex Then
            DGContenant.Select(DGContenant.CurrentRowIndex)
        End If
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecrans "classiques" (skorpio x3, falcon x3)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTQteFinPoste.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName
            'Si il s'agit de la colonne num etiquette'
            If item.ColumnName.Equals("Machine") Then
                col.Width = 85
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Noof") Then
                col.Width = 80
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("Noop") Then
                col.Width = 80
                col.HeaderText = "N° OP"
            ElseIf item.ColumnName.Equals("Quantite") Then
                col.Width = 100
                col.HeaderText = "Quantité"
            ElseIf item.ColumnName.Equals("NoProd") Then
                col.Width = 100
                col.HeaderText = "N° Produit"
            Else
                col.Width = 0
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGContenant.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25
            vBar.Height = DGContenant.Height - 25
        Next

        For Each hBar As HScrollBar In DGContenant.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25
        Next
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecrans VGA (falcon x3+)
    ''' </summary>
    ''' <param name="tablestyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumnVGA(ByRef tablestyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTQteFinPoste.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName
            'Si il s'agit de la colonne num etiquette'
            If item.ColumnName.Equals("Machine") Then
                col.Width = 85 * 2
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Noof") Then
                col.Width = 80 * 2
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("Noop") Then
                col.Width = 80 * 2
                col.HeaderText = "N° OP"
            ElseIf item.ColumnName.Equals("Quantite") Then
                col.Width = 100 * 2
                col.HeaderText = "Quantité"
            ElseIf item.ColumnName.Equals("NoProd") Then
                col.Width = 100 * 2
                col.HeaderText = "N° Produit"
            Else
                col.Width = 0
            End If
            tablestyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGContenant.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25 * 2
            vBar.Height = DGContenant.Height - (25 * 2)
        Next

        For Each hBar As HScrollBar In DGContenant.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25 * 2
        Next
    End Sub
End Class