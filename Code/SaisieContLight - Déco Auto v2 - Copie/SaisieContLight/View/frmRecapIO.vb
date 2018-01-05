Imports System.Data

Public Class frmRecapIO

    Private Sub frmRecapIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        'Liaison de la dataGrid avec la dataTable'
        DGIO.DataSource = myUser.getDTIORECAP

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

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub BDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelete.Click
        Dim delIO As SqlCommand = New SqlCommand("", New SqlConnection(connS3SQL))
        Dim delDefaultOutput As SqlCommand = New SqlCommand("", New SqlConnection(connS3SQL))

        Try
            If myUser.getDTIORECAP.Rows.Count <> 0 Then
                If DGIO.CurrentRowIndex = DGIO.CurrentCell.RowNumber And DGIO.IsSelected(DGIO.CurrentRowIndex) Then
                    Dim iNB As Integer
                    iNB = MsgBox("Voulez-vous supprimer cette ligne ?", vbYesNo + vbQuestion, "Suppression")
                    If iNB = REPONSE_OK Then
                        'On se trouve ici si tout va bien'
                        If isConnectionOK() Then
                            'Recuperation de la ligne correspondante entre la vue et la DTIORECAP'
                            Dim row As DataRow
                            row = myUser.getDTIORECAP.Rows(DGIO.CurrentRowIndex)

                            delIO = New SqlCommand("Delete from IO where IOCODESAISIE = " & codeSaisieActu & " and IOTYPE = '" & row(0) & "' and IONUMETIQ = '" & row(3) & "'", New SqlConnection(connS3SQL))
                            delIO.CommandTimeout = 2
                            delIO.Connection.Open()
                            delIO.ExecuteNonQuery()
                            delIO.Connection.Close()
                            'Si on vient de supprimer une entree, verification si il n'y a pas une sortie par defaut correspondante'
                            If row(0).Equals(Entree) Then
                                delDefaultOutput = New SqlCommand("Delete from IO where IOCODESAISIE = " & codeSaisieActu & " and IONUMMACH = '???' and IONUMETIQ = '" & row(3) & "'", New SqlConnection(connS3SQL))
                                delDefaultOutput.CommandTimeout = 2
                                delDefaultOutput.Connection.Open()
                                delDefaultOutput.ExecuteNonQuery()
                                delDefaultOutput.Connection.Close()
                            End If
                            Dim noop As String = ""
                            If row(3).ToString.Split("/").Length = 3 Then
                                noop = row(3).ToString.Split("/")(1)
                            Else
                                getDetailEtiquetteGOPAL(row(3), "", "", noop)
                            End If


                            If mode = Sortie Then

                                If isFour(numMachine) Then
                                    myUser.removeSaisieRebuts("92", row(2), row(5))
                                    myUser.removeRebut(row(2), row(5))
                                    myUser.miseAJourDeclaration()
                                End If

                                myUser.removeTempsProduction(row(5), row(2))
                                myUser.miseAJourTempsProduction()

                                myQteProd.removeQte(row(2), noop, row(4), row(5))
                                myUser.miseAJourQteFinPoste()

                                If myQteProd.getQuantiteProd(row(2), noop, row(5)) = 0 Then
                                    myUser.removeSaisie(row(2), noop, row(5))
                                Else
                                    myUser.updateSaisie(row(2), noop, row(5))
                                End If

                            End If
                            myUser.removeIO(row(3), row(0))
                            myUser.miseAJourSaisie()

                        Else
                            MsgBox("Suppression impossible car l'appareil n'est pas connecté au Wifi, ni à un socle", MsgBoxStyle.Information, "Suppression impossible")
                        End If
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
            delIO.Connection.Close()
            delDefaultOutput.Connection.Close()
        End Try
    End Sub

    Private Sub DGIO_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGIO.CurrentCellChanged
        If DGIO.CurrentCell.RowNumber = DGIO.CurrentRowIndex Then
            DGIO.Select(DGIO.CurrentRowIndex)
        End If
    End Sub

    ''' <summary>
    ''' Fonction utiliser pour les ecrans "classiques" (skorpio x3, falcon x3)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumn(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTIORECAP.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("Type") Then
                col.Width = 54
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Machine") Then
                col.Width = 85
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Lot") Then
                col.Width = 150
                col.HeaderText = "N° Lot"
            ElseIf item.ColumnName.Equals("Noof") Then
                col.Width = 70
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("NumEtiq") Then
                col.Width = 128
                col.HeaderText = "N° Etiq"
            ElseIf item.ColumnName.Equals("QuantCont") Then
                col.Width = 90
                col.HeaderText = "Quantité"
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

    ''' <summary>
    ''' Fonction utiliser pour les ecrans VGA (falcon x3+)
    ''' </summary>
    ''' <param name="tableStyle"></param>
    ''' <remarks></remarks>
    Private Sub initSizeColumnVGA(ByRef tableStyle As DataGridTableStyle)
        For Each item As DataColumn In myUser.getDTIORECAP.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName

            If item.ColumnName.Equals("Type") Then
                col.Width = 54 * 2
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Machine") Then
                col.Width = 85 * 2
                col.HeaderText = item.ColumnName
            ElseIf item.ColumnName.Equals("Lot") Then
                col.Width = 150 * 2
                col.HeaderText = "N° Lot"
            ElseIf item.ColumnName.Equals("Noof") Then
                col.Width = 70 * 2
                col.HeaderText = "N° OF"
            ElseIf item.ColumnName.Equals("NumEtiq") Then
                col.Width = 128 * 2
                col.HeaderText = "N° Etiq"
            ElseIf item.ColumnName.Equals("QuantCont") Then
                col.Width = 90 * 2
                col.HeaderText = "Quantité"
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