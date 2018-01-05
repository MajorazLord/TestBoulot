Imports System.Data

Public Class RecapArrivee

    Private Sub RecapArrivee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        'Liaison de la dataGrid avec la dataTable'
        DGIO.DataSource = myUser.getDTArrivee

        'Permet d'avoir des colonnes dont la taille est redéfinie, sinon c'est impossible de changer la taille des colonnes'
        Dim tableStyle As New DataGridTableStyle

        'Redimensionnement des colonnes'
        If isScreenVGA() Then
            initSizeColumnVGA(tableStyle)
        Else
            initSizeColumn(tableStyle)
        End If
        DGIO.TableStyles.Add(tableStyle)

        'On enleve la selection de base de la première case'
        DGIO.CurrentCell = Nothing
    End Sub

    Private Sub DGIO_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGIO.CurrentCellChanged
        If DGIO.CurrentCell.RowNumber = DGIO.CurrentRowIndex Then
            DGIO.Select(DGIO.CurrentRowIndex)
        End If
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        If myUser.getDTArrivee.Rows.Count <> 0 Then
            If DGIO.CurrentRowIndex = DGIO.CurrentCell.RowNumber And DGIO.IsSelected(DGIO.CurrentRowIndex) Then
                Dim iNB = MsgBox("Voulez-vous supprimer cette ligne ?", vbYesNo + vbQuestion, "Suppression")
                If iNB = MsgBoxResult.Yes Then
                    'On se trouve ici si tout va bien'
                    Dim row As DataRow
                    row = myUser.getDTArrivee.Rows(DGIO.CurrentRowIndex)

                    myUser.DTArrivee.Rows.Remove(row)
                End If
            End If
        End If
    End Sub

    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTArrivee().Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("NoEtiq") Then
                col.Width = 130
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Quantité") Then
                col.Width = 80
                col.HeaderText = item.ColumnName
            End If

            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGIO.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25
            vBar.Height = DGIO.Height - 25
        Next

        For Each hBar As HScrollBar In DGIO.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25
        Next
    End Sub

    Private Sub initSizeColumnVGA(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTArrivee.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("NoEtiq") Then
                col.Width = 130 * 2
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Quantité") Then
                col.Width = 80 * 2
                col.HeaderText = item.ColumnName
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGIO.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25 * 2
            vBar.Height = DGIO.Height - (25 * 2)
        Next

        For Each hBar As HScrollBar In DGIO.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25 * 2
        Next
    End Sub

End Class