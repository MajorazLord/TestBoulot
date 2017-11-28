Imports System.Data

Public Class frmRecapRebuts
    Private isRebutTR As Boolean

    Private Sub frmRecapRebutsTous_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        If Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleG) Then
            '        BDelLigne.Visible = False
            DGRebut.DataSource = myUser.getDTRebutsTRRECAP
            initColumn(myUser.getDTRebutsTR)
            isRebutTR = True
        Else
            BDelLigne.Visible = True
            DGRebut.DataSource = myUser.getDTRebuts
            initColumn(myUser.getDTRebuts)
            isRebutTR = False
        End If

        DGRebut.CurrentCell = Nothing
    End Sub

    ''' <summary>
    ''' Permet d'initialiser les colonnes de la DataGrid
    ''' </summary>
    ''' <param name="DTReb"></param>
    ''' <remarks></remarks>
    Private Sub initColumn(ByVal DTReb As DataTable)
        DGRebut.TableStyles.Clear()

        Dim tableStyle As New DataGridTableStyle

        If isScreenVGA() Then
            initSizeColumnVGA(tableStyle, DTReb)
        Else
            initSizeColumn(tableStyle, DTReb)
        End If
        
        DGRebut.TableStyles.Add(tableStyle)
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub DGRebut_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGRebut.CurrentCellChanged
        If DGRebut.CurrentCell.RowNumber = DGRebut.CurrentRowIndex Then
            DGRebut.Select(DGRebut.CurrentRowIndex)
        End If
    End Sub

    Private Sub BDelLigne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelLigne.Click
        Try
            If isRebutTR Then
                If myUser.getDTRebutsTR.Rows.Count <> 0 Then
                    If DGRebut.CurrentCell.RowNumber = DGRebut.CurrentRowIndex And DGRebut.IsSelected(DGRebut.CurrentRowIndex) Then
                        Dim iNB As Integer
                        iNB = MsgBox("Voulez-vous supprimer cette ligne?", vbYesNo + vbQuestion, "Suppression")
                        If iNB = REPONSE_OK Then

                            Debug.WriteLine("suppression rebut TR code saisie: " & codeSaisieActu)

                            Dim row As DataRow
                            row = myUser.getDTRebutsTRRECAP.Rows(DGRebut.CurrentRowIndex)

                            Dim req As New SqlCommand("delete from reb_ret where rrcodesaisie = " & codeSaisieActu & " and rrid = '" & row(0) & "' and rrcodedef = '" & row(1) & "' and rrnummach = '" & row(3) & "'", New SqlConnection(connS3SQL))
                            Try
                                req.Connection.Open()
                                req.ExecuteNonQuery()
                                req.Connection.Close()
                            Catch ex As Exception
                                req.Connection.Close()
                            End Try

                            myUser.removeSaisieRebuts(DGRebut.Item(DGRebut.CurrentRowIndex, 1), DGRebut.Item(DGRebut.CurrentRowIndex, 0), DGRebut.Item(DGRebut.CurrentRowIndex, 3))
                            myUser.getDTRebutsTR.Rows(DGRebut.CurrentRowIndex).Delete()
                            myUser.getDTRebutsTRRECAP.Rows(DGRebut.CurrentRowIndex).Delete()

                            myUser.miseAJourDeclaration()
                        Else
                            MsgBox("Aucune ligne sélectionnée.", MsgBoxStyle.Exclamation, "Impossible")
                        End If
                    End If
                Else
                    MsgBox("Aucune ligne dans le tableau", MsgBoxStyle.Exclamation, "Impossible")
                    Exit Sub
                End If
            Else
                If myUser.getDTRebuts.Rows.Count <> 0 Then
                    If DGRebut.CurrentCell.RowNumber = DGRebut.CurrentRowIndex And DGRebut.IsSelected(DGRebut.CurrentRowIndex) Then
                        Dim iNB As Integer
                        iNB = MsgBox("Voulez-vous supprimer cette ligne?", vbYesNo + vbQuestion, "Suppression")
                        If iNB = REPONSE_OK Then
                            myUser.removeSaisieRebuts(DGRebut.Item(DGRebut.CurrentRowIndex, 1), DGRebut.Item(DGRebut.CurrentRowIndex, 0), DGRebut.Item(DGRebut.CurrentRowIndex, 3))
                            myUser.getDTRebuts.Rows(DGRebut.CurrentRowIndex).Delete()
                            myUser.miseAJourDeclaration()
                        End If
                    Else
                        MsgBox("Aucune ligne sélectionnée.", MsgBoxStyle.Exclamation, "Impossible")
                        Exit Sub
                    End If
                Else
                    MsgBox("Aucune ligne dans le tableau", MsgBoxStyle.Exclamation, "Impossible")
                    Exit Sub
                End If
            End If

        Catch
        End Try
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecrans "classiques" (skorpio x3, falcon x3)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <param name="DTReb"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle, ByVal DTReb As DataTable)
        For Each item As DataColumn In DTReb.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("NumEtiq") Then
                col.Width = 120
                col.HeaderText = "N° Etiquette"
            ElseIf item.ColumnName.Equals("N°OF") Then
                col.Width = 70
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("Code") Then
                col.Width = 55
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("PiecesEcartées") Then
                col.Width = 110
                col.HeaderText = "P. Ecartées"
            ElseIf item.ColumnName.Equals("Machine") Then
                col.Width = 80
                col.HeaderText = item.ColumnName
            End If

            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGRebut.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25
            vBar.Height = DGRebut.Height - 25
        Next

        For Each hBar As HScrollBar In DGRebut.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25
        Next
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecrans VGA (falcon x3 +)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <param name="DTReb"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumnVGA(ByRef tableStyle As DataGridTableStyle, ByVal DTReb As DataTable)
        For Each item As DataColumn In DTReb.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("NumEtiq") Then
                col.Width = 120 * 2
                col.HeaderText = "N° Etiquette"
            ElseIf item.ColumnName.Equals("N°OF") Then
                col.Width = 70 * 2
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("Code") Then
                col.Width = 55 * 2
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("PiecesEcartées") Then
                col.Width = 110 * 2
                col.HeaderText = "P. Ecartées"
            ElseIf item.ColumnName.Equals("Machine") Then
                col.Width = 80 * 2
                col.HeaderText = item.ColumnName
            End If

            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGRebut.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25 * 2
            vBar.Height = DGRebut.Height - (25 * 2)
        Next

        For Each hBar As HScrollBar In DGRebut.Controls.OfType(Of HScrollBar)()
            hBar.Height = 25 * 2
        Next
    End Sub
End Class