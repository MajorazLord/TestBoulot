Imports System.Data

Public Class frmChoix

    Private WithEvents TimerWifi As New Timer

    ''' <summary>
    ''' Fonction appelée au lancement de la fenetre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmChoix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LbIdOperateur.Text = "Opérateur: " & myUser.getPointage() & vbCrLf & "Poste: " & posteActuel

        TimerWifi.Interval = 0
        TimerWifi.Enabled = True


        PBAddUser.Image = New Bitmap(My.Resources.Icone_Add)

        If getNomSecteur.Equals(UsinageA) Then
            BDeclaration.Text = "Quantité Fin de Poste"
        Else
            BDeclaration.Text = "Déclaration"
        End If

    End Sub

    ''' <summary>
    ''' Fonction permettant de mettre a jour l'état de la conenction WIFI toute les 30 minutes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimerWifi_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerWifi.Tick
        If isConnectionOK() Then
            PBox.Image = New Bitmap(My.Resources.Check)
            Debug.WriteLine("OK")
            TimerWifi.Interval = 1000 * GetSecondsToNextHour()
        Else
            PBox.Image = New Bitmap(My.Resources.NoCheck)
            Debug.WriteLine("NOK")
            TimerWifi.Interval = 60000

        End If

    End Sub

    Private Sub BFinPoste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BFinPoste.Click
        Dim FChrgmnt As New frmChargement
        Dim iNB As Integer

        choix = True
        iNB = MsgBox("Etes - vous sûr de vouloir arrêter la saisie pour cet utilisateur ?", vbYesNo + vbQuestion, "Fin de saisie")
        If iNB = REPONSE_OK Then

            finSaisie = False

            Dim machines(0) As String
            Dim bDoublon As Boolean = False
            Dim bRecup As Boolean

            recupMachines(machines, bDoublon, bRecup)

            ' Permet de mettre a jour les temps de production 
            If myUser.getDTTempsProduction.Rows.Count <> myUser.getDTTempsProductionRECAP.Rows.Count Then
                If myUser.getDTTempsProduction.Copy.Rows.Count = 1 Then
                    Dim row As DataRow = myUser.getDTTempsProduction.Copy.Rows.Item(0)
                    myUser.getDTTempsProduction.Clear()
                    myUser.addTempsProduction(row(0), row(1), row(2), row(3), TPS_TRAVAIL, 1)

                    myUser.addSaisieProd(row(1), row(2), row(0), TPS_TRAVAIL)
                    myUser.miseAJourTempsProduction()
                Else
                    If Not bDoublon Then
                        Dim rows = myUser.getDTTempsProduction.Copy.Rows
                        For Each row As DataRow In rows
                            myUser.removeTempsProduction(row(0), row(1))
                            myUser.addTempsProduction(row(0), row(1), row(2), row(3), TPS_TRAVAIL, 1)
                            myUser.addSaisieProd(row(1), row(2), row(0), TPS_TRAVAIL)
                        Next
                        myUser.miseAJourTempsProduction()
                    Else
                        If bRecup Then
                            Dim reponse As Integer
                            reponse = MsgBox("Certaines de vos productions n'ont pas été saisies.", vbOK + MsgBoxStyle.Exclamation, "Productions manquantes")
                            If reponse = 1 Then
                                Dim frmTempsProd As New frmTempsProduction()
                                frmTempsProd.ShowDialog()
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            Else
                'Si la Data Table TempsProd est égal a 1 alors on remplace les anciennes valeurs par celle de la data table Recap
                If myUser.getDTTempsProduction.Copy.Rows.Count = 1 Then
                    myUser.getDTTempsProduction.Clear()
                    Dim rows As DataRow = myUser.getDTTempsProductionRECAP.Rows.Item(0)
                    If rows(5) = 0 Then
                        myUser.addTempsProduction(rows(1), rows(2), rows(3), rows(4), TPS_TRAVAIL, 1)
                        myUser.addSaisieProd(rows(2), rows(3), rows(1), TPS_TRAVAIL)
                    Else
                        myUser.addTempsProduction(rows(1), rows(2), rows(3), rows(4), rows(5), 1)
                        myUser.addSaisieProd(rows(2), rows(3), rows(1), rows(5))
                    End If

                    myUser.miseAJourTempsProduction()
                Else
                    If Not bDoublon Then
                        Dim rows = myUser.getDTTempsProduction.Copy.Clone
                        myUser.getDTTempsProduction.Clear()
                        For index As Integer = 1 To rows.Rows.Count
                            Dim rowRecap As DataRow = myUser.getDTTempsProductionRECAP.Rows.Item(index - 1)
                            myUser.addTempsProduction(rowRecap(1), rowRecap(2), rowRecap(3), rowRecap(4), rowRecap(5), 1)
                            myUser.addSaisieProd(rowRecap(2), rowRecap(3), rowRecap(1), rowRecap(5))
                        Next
                        myUser.miseAJourTempsProduction()
                    End If
                End If
            End If
            'Declaration que l'utilisateur actuel vient de finir sa saisie'
            myUser.inputIsOver()

            'Verification si, pour tous les utilisateurs, tout est vide'
            If myUser.isDTEmpty Then
                MsgBox("Rien n'a été saisie pendant cette session, suppression du dossier.", MsgBoxStyle.Information, "Suppression en cours")
                suppressionCodeSaisie()

                Try
                    If IO.Directory.GetDirectories(CheminSaisieProd & myUser.getPointage).Count = 1 Then
                        IO.Directory.Delete(CheminSaisieProd & myUser.getPointage, True)
                    Else
                        IO.Directory.Delete(myUser.getPathFile, True)
                    End If
                Catch ex As Exception
                End Try

            Else 'Dans ce cas, Upload de toutes les données'

                FChrgmnt.Show()
                FChrgmnt.Refresh()
                If Not isConnectionOK() Then
                    FChrgmnt.Close()
                    FChrgmnt.Dispose()
                    Dim FU As New frmUpload
                    FU.ShowDialog()
                Else

                    Try 'Essaye de remonter en base de données le contenu de tous les dossiers'

                        horsligne = False
                        Dim utilUpload As New UploadManager

                        Dim test = IO.Directory.GetDirectories(CheminSaisieProd).Count > 1

                        utilUpload.uploadAllDirectories()

                        If Not test Then
                            For Each key In myQteProd.getListAllProd
                                If key.Split("/")(1) = "" Then
                                    getDetailEtiquetteGOPAL(myQteProd.getItemFromDicoEtiq(key)(0), "", "", key.Split("/")(1))
                                End If

                                myQteProd.getFinPostePrec(key.Split("/")(0), key.Split("/")(1), key.Split("/")(2))
                            Next

                            myQteProd.miseAJourFinPoste()

                        End If

                        horsligne = True
                    Catch ex As Exception
                        FChrgmnt.Close()
                        FChrgmnt.Dispose()
                        Dim FU As New frmUpload
                        FU.ShowDialog()
                    End Try
                End If
            End If

            saveProduitInFile()

            FChrgmnt.Close()
            FChrgmnt.Dispose()

            'On remet le bon listener sur la douchette pour la fenetre d'identification, qui reste la même depuis le début (même reference)'
            frID.resetTextBox()

            myUser = Nothing

            Me.Close()
        End If
    End Sub

    Private Sub BEntree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BEntree.Click
        mode = Entree
        Dim FM As New frmEntree
        FM.ShowDialog()
    End Sub

    Private Sub BSortie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSortie.Click
        mode = Sortie
        Dim FM As New frmMouvements
        FM.ShowDialog()
    End Sub

    Private Sub BDeclaration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDeclaration.Click
        mode = Nothing
        If getNomSecteur.Equals(UsinageA) Then
            Dim qteFinPoste As New frmContenantNonTermine
            qteFinPoste.ShowDialog()
        Else
            frmDeclaration.ShowDialog()
        End If
    End Sub

    Private Sub BTempsProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmTP As New frmTempsProduction
        choix = False
        frmTP.ShowDialog()
    End Sub

    Private Sub BRecapSaisie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BRecapSaisie.Click
        Dim frmRS As New frmRecapSaisie
        choix = False
        frmRS.ShowDialog()
    End Sub

    ' Permet de supprimer la session si toutes les saisies sont supprimées
    Private Sub suppressionCodeSaisie()
        If isConnectionOK() Then
            Dim req As New SqlCommand("DELETE FROM SESSION_SAISIE WHERE SECODESAISIE = " & codeSaisieActu, New SqlConnection(connS3SQL))
            req.CommandTimeout = 2

            Try
                req.Connection.Open()
                req.ExecuteNonQuery()
                req.Connection.Close()
            Catch ex As Exception
                req.Connection.Close()
            End Try
        End If
    End Sub

    Private Sub PBAddUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBAddUser.Click
        'Dim frmUser As New frmAddUser
        'frmUser.ShowDialog()
        Debug.WriteLine(codeSaisieActu)
        Dim frmModif As New frmChangeParam
        frmModif.ShowDialog()
        LbIdOperateur.Text = "Opérateur: " & myUser.getPointage() & vbCrLf & "Poste: " & posteActuel
    End Sub
End Class