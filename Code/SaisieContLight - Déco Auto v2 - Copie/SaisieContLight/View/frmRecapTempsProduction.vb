Imports System.Data
Public Class frmRecapTempsProduction

    Private Sub frmRecapTempsProduction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        DGTempsProd.DataSource = myUser.getDTTempsProductionRECAP
        DGTempsProd.TableStyles.Clear()

        Dim tableStyle As New DataGridTableStyle

        If isScreenVGA() Then
            initSizeColumnVGA(tableStyle)
        Else
            initSizeColumn(tableStyle)
        End If

        DGTempsProd.TableStyles.Add(tableStyle)

       

    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub DGTempsProd_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGTempsProd.CurrentCellChanged

        If DGTempsProd.CurrentCell.RowNumber = DGTempsProd.CurrentRowIndex Then
            DGTempsProd.Select(DGTempsProd.CurrentRowIndex)
        End If
    End Sub


    ''' <summary>
    ''' Fonction utiliser pour les ecrans "classiques" (skorpio x3, falcon x3)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTTempsProductionRECAP.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName
            If item.ColumnName.Equals("Production") Then
                col.Width = 100
                col.HeaderText = "Production"
            ElseIf item.ColumnName.Equals("Machine") Then
                col.Width = 90
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Noof") Then
                col.Width = 70
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("Noop") Then
                col.Width = 70
                col.HeaderText = "N° OP"
            ElseIf item.ColumnName.Equals("NumProduit") Then
                col.Width = 100
                col.HeaderText = "N° Produit"
            Else
                col.Width = 100
                col.HeaderText = "Nb Heures"
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vbar As VScrollBar In DGTempsProd.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vbar.Width = 25
            vbar.Height = DGTempsProd.Height - 25
        Next

        For Each hbar As HScrollBar In DGTempsProd.Controls.OfType(Of HScrollBar)()
            hbar.Height = 25
        Next
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecrans VGA (falcon x3 +)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumnVGA(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTTempsProductionRECAP.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName
            If item.ColumnName.Equals("Production") Then
                col.Width = 100 * 2
                col.HeaderText = "Production"
            ElseIf item.ColumnName.Equals("Machine") Then
                col.Width = 90 * 2
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Noof") Then
                col.Width = 70 * 2
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("Noop") Then
                col.Width = 70 * 2
                col.HeaderText = "N° OP"
            ElseIf item.ColumnName.Equals("NumProduit") Then
                col.Width = 100 * 2
                col.HeaderText = "N° Produit"
            Else
                col.Width = 100 * 2
                col.HeaderText = "Nb Heures"
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vbar As VScrollBar In DGTempsProd.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vbar.Width = 25 * 2
            vbar.Height = DGTempsProd.Height - (25 * 2)
        Next

        For Each hbar As HScrollBar In DGTempsProd.Controls.OfType(Of HScrollBar)()
            hbar.Height = 25 * 2
        Next
    End Sub
End Class