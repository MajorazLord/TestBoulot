Imports Datalogic.API
Imports System.Data

Public Class Départ
    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    'Changer le visuel pour qu'il y ait le poids de saisie pour chaque scan de départ

    Private Sub Départ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Liaison de la dataGrid avec la dataTable'
        DGDépart.DataSource = myUser.getDTDépart

        'Permet d'avoir des colonnes dont la taille est redéfinie, sinon c'est impossible de changer la taille des colonnes'
        Dim tableStyle As New DataGridTableStyle

        'Redimensionnement des colonnes'
        If isScreenVGA() Then
            initSizeColumnVGA(tableStyle)
        Else
            initSizeColumn(tableStyle)
        End If
        DGDépart.TableStyles.Add(tableStyle)

        'On enleve la selection de base de la première case'
        DGDépart.CurrentCell = Nothing
    End Sub

    Private Sub BTerm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTerm.Click
        Me.Close()
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
                If (dcdData.StartsWith("AE") And dcdData.Length < 10 And dcdData.Length > 5 And IsNumeric(dcdData.Substring(2))) Or (dcdData.Length < 3 And IsNumeric(dcdData)) Then
                    '
                ElseIf dcdData.StartsWith(PdCFourG) Then
                    '
                Else
                    affichePointVert()
                    myUser.DTDépart.Rows.Add(dcdData)
                    'TODO
                    'Ecrire auto en BDD
                    Exit For
                End If
            Next
        Else
            Exit Sub
        End If
    End Sub

    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTArrivee.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("NoEtiq") Then
                col.Width = 130
                col.HeaderText = item.ColumnName
            End If

            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGDépart.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25
            vBar.Height = DGDépart.Height - 25
        Next

        For Each hBar As HScrollBar In DGDépart.Controls.OfType(Of HScrollBar)()
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
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGDépart.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25 * 2
            vBar.Height = DGDépart.Height - (25 * 2)
        Next

        For Each hBar As HScrollBar In DGDépart.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25 * 2
        Next
    End Sub

    Private Sub Départ_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        dcdEvent.Dispose()
    End Sub

    Private Sub Départ_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        loadFullDecodeur(hDcd, Me, dcdEvent)
    End Sub

    Private Sub BtnSuppr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSuppr.Click
        If myUser.getDTDépart.Rows.Count <> 0 Then
            If DGDépart.CurrentRowIndex = DGDépart.CurrentCell.RowNumber And DGDépart.IsSelected(DGDépart.CurrentRowIndex) Then
                Dim iNB = MsgBox("Voulez-vous supprimer cette ligne ?", vbYesNo + vbQuestion, "Suppression")
                If iNB = MsgBoxResult.Yes Then
                    Dim row As DataRow
                    row = myUser.getDTDépart.Rows(DGDépart.CurrentRowIndex)
                    myUser.DTDépart.Rows.Remove(row)
                End If
            End If
        End If
    End Sub

    Private Sub DGDépart_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGDépart.CurrentCellChanged
        If DGDépart.CurrentCell.RowNumber = DGDépart.CurrentRowIndex Then
            DGDépart.Select(DGDépart.CurrentRowIndex)
        End If
    End Sub
End Class