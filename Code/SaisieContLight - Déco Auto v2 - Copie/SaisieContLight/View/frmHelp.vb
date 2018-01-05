Imports System.Data

Public Class frmHelp

    Private Sub frmHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)

        If fenetreAide = fenetreArretMachine Then
            ' Code non production  CODES_NP.txt
            DGHelp.DataSource = DTcodeNP
            initColumn(DTcodeNP, 470)
        ElseIf fenetreAide = fenetreArretProd Then
            ' Code non production CODES_NP.txt
            DGHelp.DataSource = DTcodeNP
            initColumn(DTcodeNP, 470)
        Else
            ' Code rebut CODES_DEF.txt
            DGHelp.DataSource = DTcodeDEF
            initColumn(DTcodeDEF, 240)
        End If

        DGHelp.CurrentCell = Nothing
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        If fenetreAide = fenetreArretMachine Then
            frmAM = Nothing
        ElseIf fenetreAide = fenetreArretProd Then
            frmAP = Nothing
        Else
            frmR = Nothing
        End If

        Me.Close()
    End Sub

    Private Sub BChoisir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BChoisir.Click
        Try
            If DGHelp.CurrentRowIndex = DGHelp.CurrentCell.RowNumber And DGHelp.IsSelected(DGHelp.CurrentRowIndex) Then
                If fenetreAide = fenetreArretMachine Then
                    recupCodeArretMachine()
                ElseIf fenetreAide = fenetreArretProd Then
                    recupCodeArretProd()
                Else
                    recupCodeRebut()
                End If
                PBRetour_Click(Me, e)
            Else
                MsgBox("Veuillez sélectionner un code.", MsgBoxStyle.Exclamation, "Erreur")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGHelp_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGHelp.CurrentCellChanged
        If DGHelp.CurrentCell.RowNumber = DGHelp.CurrentRowIndex Then
            DGHelp.Select(DGHelp.CurrentRowIndex)
        End If
    End Sub

    ''' <summary>
    ''' Permet d'initialiser les colonnes de la DataGrid
    ''' </summary>
    ''' <param name="DTcode"></param>
    ''' <param name="tailleDescription"></param>
    ''' <remarks></remarks>
    Private Sub initColumn(ByVal DTcode As DataTable, ByVal tailleDescription As Integer)
        DGHelp.TableStyles.Clear()

        Dim tableStyle As New DataGridTableStyle

        If isScreenVGA() Then
            initColumnVGA(tableStyle, DTcode, tailleDescription)
        Else
            initColumnClassic(tableStyle, DTcode, tailleDescription)
        End If

        DGHelp.TableStyles.Add(tableStyle)
    End Sub

    Public Sub initColumnClassic(ByRef tableStyle As DataGridTableStyle, ByVal DTCode As DataTable, ByVal tailleDescription As Integer)
        For Each item As DataColumn In DTCode.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName
            If item.ColumnName.Equals("Code") Then
                col.Width = 45
                col.HeaderText = item.ColumnName
            Else
                col.Width = tailleDescription
                col.HeaderText = item.ColumnName
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGHelp.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25
            vBar.Height = DGHelp.Height - 25
        Next

        For Each hBar As HScrollBar In DGHelp.Controls.OfType(Of HScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            hBar.Height = 25
            hBar.Width = DGHelp.Width - 25
        Next
    End Sub

    Public Sub initColumnVGA(ByRef tableStyle As DataGridTableStyle, ByVal DTCode As DataTable, ByVal tailleDescription As Integer)
        For Each item As DataColumn In DTcode.Columns
            Dim col As New DataGridTextBoxColumn
            col.MappingName = item.ColumnName
            If item.ColumnName.Equals("Code") Then
                col.Width = 45 * 2
                col.HeaderText = item.ColumnName
            Else
                col.Width = tailleDescription * 2
                col.HeaderText = item.ColumnName
            End If
            tableStyle.GridColumnStyles.Add(col)
        Next

        For Each vBar As VScrollBar In DGHelp.Controls.OfType(Of VScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            vBar.Width = 25 * 2
            vBar.Height = DGHelp.Height - (25 * 2)
        Next

        For Each hBar As HScrollBar In DGHelp.Controls.OfType(Of HScrollBar)()
            ' Evite le chevauchement des scrollBars verticale et horizontale
            hBar.Height = 25 * 2
            hBar.Width = DGHelp.Width - (25 * 2)
        Next
    End Sub

    ''' <summary>
    ''' Permet de mettre le code dans la fenetre frmRebut
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub recupCodeArretMachine()
        If frmAM.TBCode.Text = "" Then
            frmAM.TBCode.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        ElseIf frmAM.TBCode2.Text = "" Then
            frmAM.TBCode2.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        ElseIf frmAM.TBCode3.Text = "" Then
            frmAM.TBCode3.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        End If
    End Sub

    ''' <summary>
    ''' Permet de mettre les codes dans la fenetre frmArretMachine/frmArretProd
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub recupCodeArretProd()
        If frmAP.TBCode.Text = "" Then
            frmAP.TBCode.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        ElseIf frmAP.TBCode2.Text = "" Then
            frmAP.TBCode2.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        ElseIf frmAP.TBCode3.Text = "" Then
            frmAP.TBCode3.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        End If
    End Sub

    ''' <summary>
    ''' Permet de mettre le code dans la fenetre frmRebut
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub recupCodeRebut()
        If frmR.TBCode.Text = "" Then
            frmR.TBCode.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        ElseIf frmR.TBCode2.Text = "" Then
            frmR.TBCode2.Text = DGHelp.Item(DGHelp.CurrentRowIndex, 0)
        End If
    End Sub

End Class