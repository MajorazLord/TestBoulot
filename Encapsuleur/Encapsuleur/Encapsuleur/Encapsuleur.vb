Imports Datalogic.API

Public Class Encapsuleur
    Private WithEvents res As Process
    Dim eventHandled As Boolean
    Dim cheminApp As String

    Private WithEvents dcdEvent As DecodeEvent
    Private hDcd As DecodeHandle

    Private Sub myProcess_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        loadFullDecodeur(hDcd, Me, dcdEvent)
        res = Process.Start(cheminApp, "")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cheminApp = "\Program Files\saisiecontlight\SaisieContLight.exe"
    End Sub

    Private Sub Encapsuleur_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        dcdEvent.Dispose()
    End Sub
End Class
