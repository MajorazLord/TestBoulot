Imports System.Data

Public Class frmRecapContenantsBloque
    Private Sub frmRecapCBL_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        'Liaison de la dataGrid avec la dataTable'
        DGContenantBloque.DataSource = myUser.getDTContenantBloqueRecap
        DGContenantBloque.TableStyles.Clear()

        'Permet d'avoir des colonnes dont la taille est redéfinie, sinon c'est impossible de changer la taille des colonnes'
        Dim tableStyle As New DataGridTableStyle

        'Redimensionnement des colonnes'
        If isScreenVGA() Then
            initSizeColumn(tableStyle)
        Else
            initSizeColumn(tableStyle)
        End If

        DGContenantBloque.TableStyles.Add(tableStyle)

        'On enleve la selection de base de la première case'
        DGContenantBloque.CurrentCell = Nothing

        'Augmentation de la taille des scroll barz'
      

    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub DGContenantBloque_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGContenantBloque.CurrentCellChanged
        If DGContenantBloque.CurrentCell.RowNumber = DGContenantBloque.CurrentRowIndex Then
            DGContenantBloque.Select(DGContenantBloque.CurrentRowIndex)
        End If
    End Sub


    ''' <summary>
    ''' Fonction utiliser pour les ecrans "classiques" (skorpio x3, falcon x3)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTContenantBloque.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            'Si il s'agit de la colonne des num etiquettes'
            If item.ColumnName.Equals("Noetiq") Then
                col.Width = 228
                col.HeaderText = item.ColumnName
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGContenantBloque.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25
            vBar.Height = DGContenantBloque.Height - 25
        Next

        For Each hBar As HScrollBar In DGContenantBloque.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25
        Next
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecrans VGA (falcon x3 +)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumnVGA(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTContenantBloque.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            'Si il s'agit de la colonne des num etiquettes'
            If item.ColumnName.Equals("Noetiq") Then
                col.Width = 228 * 2
                col.HeaderText = item.ColumnName
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGContenantBloque.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25 * 2
            vBar.Height = DGContenantBloque.Height - (25 * 2)
        Next

        For Each hBar As HScrollBar In DGContenantBloque.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25 * 2
        Next
    End Sub
End Class