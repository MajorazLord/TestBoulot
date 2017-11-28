Imports Microsoft.WindowsMobile.Status

Public Class frmUpload

    Private Sub frmUpload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PBWIFI.Image = New Bitmap(My.Resources.Wifi)
    End Sub

    Private Sub BAfter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAfter.Click

        Dim iNB As Integer
        iNB = MsgBox("Etes - vous sûr de vouloir le faire plus tard ?", vbYesNo + vbQuestion, "Plus tard ?")

        If iNB = REPONSE_OK Then
            Me.Refresh()
            Me.Close()
        End If
    End Sub

    Private Sub PBWIFI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBWIFI.Click

        'If isDeviceOnSocle() Then
        '    MsgBox("Veuillez enlever l'appareil du socle svp.", MsgBoxStyle.Exclamation, "En attente")
        '    Exit Sub
        'End If

        Dim FC As New frmChargement
        FC.Show()
        FC.Refresh()

        If Not isConnectionOK() Then
            FC.Close()
            FC.Dispose()
            MsgBox("La connexion ne fonctionne pas, veuillez vous deplacer plus près d'une borne. Si le problème persiste, veuillez redémarrer la douchette via l'accueil de l'application.", vbOK + MsgBoxStyle.Exclamation, "En attente")

            Exit Sub
        End If

        Try 'Essaye de remonter en base de données le contenu de tous les dossiers'
            Dim utilUpload As New UploadManager
            horsligne = True
            utilUpload.uploadAllDirectories()
        Catch ex As Exception
            FC.Close()
            FC.Dispose()
            Exit Sub
        End Try

        FC.Close()
        FC.Dispose()
        Me.Close()

    End Sub

    Private Sub PBSOCLE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Not isDeviceOnSocle() Then
            MsgBox("Veuillez poser l'appareil sur le socle et assurez vous que le voyant de la base est allumé.", MsgBoxStyle.Exclamation, "En attente")
            Exit Sub
        End If

        Dim FC As New frmChargement
        FC.Show()
        FC.Refresh()


        If Not isConnectionOK() Then
            'Diminution du temps d'attente car délai trop long s'active seulement si il n'y a pas de connexion '
            '40 * 0.5 = 20 sec
            pause(40)
        End If

        If Not isConnectionOK() Then
            FC.Close()
            FC.Dispose()
            MsgBox("La connexion ne fonctionne pas, veuillez relancer le gestionnaire pour appareils Windows Mobile.", vbOK + MsgBoxStyle.Exclamation, "En attente")

            Exit Sub
        End If

        Try 'Essaye de remonter en base de données le contenu de tous les dossiers'
            Dim utilUpload As New UploadManager
            utilUpload.uploadAllDirectories()
        Catch ex As Exception
            FC.Close()
            FC.Dispose()

            Exit Sub
        End Try

        FC.Close()
        FC.Dispose()
        Me.Close()

    End Sub

End Class