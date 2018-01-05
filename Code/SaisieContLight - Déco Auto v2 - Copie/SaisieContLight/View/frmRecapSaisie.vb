Imports System.Windows.Forms.ListViewItem
Imports System.Data

Public Class frmRecapSaisie
    Private values As New ArrayList
    Private currentOF As String
    Private currentMachine As String

    Private Sub frmRecapSaisie1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim nbRow As Integer

        If choix Then
            PBRetour.Image = New Bitmap(My.Resources.Ok)
        Else
            PBRetour.Image = New Bitmap(My.Resources.Fleche_retour)
        End If

        nbRow = myUser.getDTSaisie().Rows.Count
        'values.Capacity = nbRow

        If nbRow = 0 Then
            LVSaisie.Visible = False
            LAucuneProd.Visible = True
        Else
            LVSaisie.Visible = True
            LAucuneProd.Visible = False

            For Index As Integer = 1 To nbRow
                Dim rows As DataRow = myUser.getDTSaisie.Rows.Item(Index - 1)
                Dim row(5) As String
                row(0) = rows.Item(0)
                row(1) = rows.Item(1)
                row(2) = rows.Item(2)
                row(3) = rows.Item(3)

                If Not IsDBNull(rows.Item(4)) Then
                    row(4) = rows.Item(4)
                End If

                'If IsDBNull(rows.Item(4)) Then
                '   getDetailEtiquetteNumProduit(row(1).Split("/")(0), row(4))
                'Else
                '    row(4) = rows.Item(4)
                'End If

                LVSaisie.Items.Add(New ListViewItem("Production " & Index))

                values.Add(row)
            Next
        End If
    End Sub

    Private Sub PBRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBRetour.Click
        Me.Close()
    End Sub

    Private Sub LLRebut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLRebut.Click
        LVRebArret.Clear()
        LVRebArret.Visible = True
        LVRebArret.Items.Add(New ListViewItem("REBUTS (C./Q./N°OF)"))

        For Each row As DataRow In myUser.getDTSaisieRebut.Rows
            If row(2) = currentOF And row(3) = currentMachine Then
                LVRebArret.Items.Add(New ListViewItem(row(0).ToString & "/" & row(1).ToString & "/" & row(2).ToString))
            End If
        Next
    End Sub

    Private Sub LLArret_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LLArret.Click
        LVRebArret.Clear()
        LVRebArret.Visible = True
        LVRebArret.Items.Add(New ListViewItem("ARRETS (C./H./Mach.)"))

        For Each row As DataRow In myUser.getDTSaisieArret.Rows
            If row(2) = currentMachine Then
                LVRebArret.Items.Add(New ListViewItem(row(0).ToString & "/" & row(1).ToString & "/" & row(2).ToString))
            End If
        Next
    End Sub

    Private Sub LVSaisie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LVSaisie.SelectedIndexChanged
        Dim currentItem = LVSaisie.FocusedItem()
        Dim value(5) As String
        Try
            LNomProd.Text = ""
            value = values.Item(LVSaisie.Items.IndexOf(currentItem))
            PDetail.Visible = True
            LVRebArret.Visible = False
            LQuantite.Text = value(0)
            LOF.Text = value(1).Split("/")(0)
            currentOF = value(1).Split("/")(0)
            LMachine.Text = value(2)
            currentMachine = value(2)
            LTpsProd.Text = value(3) & " h"
            getABVNomProd(value(4), LNomProd.Text, currentOF)
            LProduit.Text = value(4)
            initRebutsArrets(value)
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Permet d'initialiser les labels Rebuts et Arrets
    ''' </summary>
    ''' <param name="value"></param>
    ''' <remarks></remarks>
    Private Sub initRebutsArrets(ByVal value() As String)
        If myUser.isArrets(value(2), value(1)) Then
            LLArret.Enabled = True
        Else
            LLArret.Enabled = False
        End If

        If myUser.isRebuts(value(1).Split("/")(0)) Then
            LLRebut.Enabled = True
        Else
            LLRebut.Enabled = False
        End If
    End Sub

End Class