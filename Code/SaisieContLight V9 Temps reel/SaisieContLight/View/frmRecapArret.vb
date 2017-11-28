Imports System.Data

Public Class frmRecapArret

    Private Sub frmRecapArret_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)


        'Liaison de la dataGrid avec la dataTable'
        DGArret.DataSource = myUser.getDTArrets
        DGArret.TableStyles.Clear()

        'Permet d'avoir des colonnes dont la taille est redéfinie, sinon c'est impossible de changer la taille des colonnes'
        Dim tableStyle As New DataGridTableStyle

        'Redimensionnement des colonnes'
        If isScreenVGA() Then
            initSizeColumnVGA(tableStyle)
        Else
            initSizeColumn(tableStyle)
        End If

        DGArret.TableStyles.Add(tableStyle)
       
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        'le try est présent pour empecher l'exception (out of bond, james bond) de remonter concernant le isSelected, cependant cela est necessaire pour ne pas supprimer des lignes qui ne sont pas selectionnées'
        Try
            If myUser.getDTArrets.Rows.Count <> 0 Then
                If DGArret.CurrentRowIndex = DGArret.CurrentCell.RowNumber And DGArret.IsSelected(DGArret.CurrentRowIndex) Then
                    Dim iNB As Integer
                    iNB = MsgBox("Voulez-vous supprimer cette ligne ?", vbYesNo + vbQuestion, "Suppression")
                    If iNB = REPONSE_OK Then
                        If DGArret.VisibleColumnCount = 3 Then
                            myUser.removeSaisieArrets(DGArret.Item(DGArret.CurrentRowIndex, 1), DGArret.Item(DGArret.CurrentRowIndex, 2), DGArret.Item(DGArret.CurrentRowIndex, 0), "")
                        Else
                            myUser.removeSaisieArrets(DGArret.Item(DGArret.CurrentRowIndex, 2), DGArret.Item(DGArret.CurrentRowIndex, 3), DGArret.Item(DGArret.CurrentRowIndex, 0), DGArret.Item(DGArret.CurrentRowIndex, 1))
                        End If

                        myUser.getDTArrets.Rows(DGArret.CurrentRowIndex).Delete()
                        myUser.miseAJourDeclaration()
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

    Private Sub DGArret_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGArret.CurrentCellChanged
        If DGArret.CurrentCell.RowNumber = DGArret.CurrentRowIndex Then
            DGArret.Select(DGArret.CurrentRowIndex)
        End If
    End Sub


    ''' <summary>
    ''' Fonction utiliser pour les ecrans "classiques" (skorpio x3, falcon x3)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTArrets.Columns
            'Si il s'agit de la colonne N°Machine'
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("N°Machine") Then
                col.Width = 105
                col.HeaderText = "N° Machine"
                tableStyle.GridColumnStyles.Add(col)
            ElseIf item.ColumnName.Equals("Code") Then
                col.Width = 55
                col.HeaderText = item.ColumnName
                tableStyle.GridColumnStyles.Add(col)
            ElseIf item.ColumnName.Equals("Durée") Then
                col.Width = 75
                col.HeaderText = item.ColumnName
                tableStyle.GridColumnStyles.Add(col)
            End If
        Next

        For Each vBar As VScrollBar In DGArret.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25
            vBar.Height = DGArret.Height - 25
        Next

        For Each hBar As HScrollBar In DGArret.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25
        Next
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecran VGA (falcon x3 +)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumnVGA(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTArrets.Columns
            'Si il s'agit de la colonne N°Machine'
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("N°Machine") Then
                col.Width = 105 * 2
                col.HeaderText = "N° Machine"
                tableStyle.GridColumnStyles.Add(col)
            ElseIf item.ColumnName.Equals("Code") Then
                col.Width = 55 * 2
                col.HeaderText = item.ColumnName
                tableStyle.GridColumnStyles.Add(col)
            ElseIf item.ColumnName.Equals("Durée") Then
                col.Width = 75 * 2
                col.HeaderText = item.ColumnName
                tableStyle.GridColumnStyles.Add(col)
            End If
        Next

        For Each vBar As VScrollBar In DGArret.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25 * 2
            vBar.Height = DGArret.Height - (25 * 2)
        Next

        For Each hBar As HScrollBar In DGArret.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25 * 2
        Next
    End Sub
End Class