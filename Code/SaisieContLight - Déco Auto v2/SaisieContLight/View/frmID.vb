Imports Datalogic.API

Public Class frmID

    Private isFocusedNum As Boolean = False
    Private isFocusedNum2 As Boolean = False

    Private WithEvents TimerPoste As New Timer

    ''' <summary>
    ''' Fonction qui est appelée au lancement de la fenetre
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmIDDepart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TimerPoste.Interval = 0
        TimerPoste.Enabled = True

        resetLeds()
        PBOption.Image = New Bitmap(My.Resources.Options)
        initialisationPoste()

        initListFour()

        Try
            'Récupère le secteur mis en dur dans la douchette (fichier secteur.ini)
            recuperationSecteur()
            recuperationMachine()
            initialisationDT()
        Catch
            Me.Close()
            Application.Exit()
        End Try

        TBNumIDAide2.Enabled = False

        CBPoste.SelectedItem = getPoste()

        currentScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height
        currentScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width

    End Sub

    ''' <summary>
    ''' Permet de mettre a jour le poste toutes les 30 minutes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TimerPoste_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerPoste.Tick
        TimerPoste.Interval = 1000 * GetSecondsToNextHour()
        CBPoste.SelectedItem = getPoste()
    End Sub

    ''' <summary>
    ''' Permet de créer les items dans la comboBox CBPoste
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub initialisationPoste()
        CBPoste.Items.Add(Matin)
        CBPoste.Items.Add(Journee)
        CBPoste.Items.Add(Soir)
        CBPoste.Items.Add(Nuit)
        CBPoste.Items.Add(Week1)
        CBPoste.Items.Add(Week2)
    End Sub

    Private Sub frmIDDepart_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        resetLeds()
        codeSaisieActu = Nothing
        Me.Text = getNomSecteur() & " - ID"
    End Sub

    Private Sub BDelNumID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelNumID.Click
        TBNumID.Text = ""
        TBNumID.Focus()
    End Sub

    Private Sub BDelNumIDAide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BDelNumIDAide.Click

        If isFocusedNum Or TBNumIDAide2.Text.Length = 0 Then
            TBNumIDAide.Text = TBNumIDAide2.Text
            If TBNumIDAide2.Text.Length = 0 Then
                TBNumIDAide.Focus()
            Else
                TBNumIDAide2.Focus()
            End If
            TBNumIDAide2.Text = ""
        End If

        If isFocusedNum2 Then
            TBNumIDAide2.Text = ""
            TBNumIDAide2.Focus()
        End If
    End Sub

    Private Sub PBOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBOption.Click
        Dim frmOpt As New frmOptions
        frmOpt.ShowDialog()
    End Sub

#Region "KeyPress Champs ID"

    Private Sub TBNumID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumID.KeyPress
        verifChampID(e)
    End Sub

    Private Sub TBNumIDAide_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumIDAide.KeyPress
        verifChampID(e)
    End Sub

    Private Sub TBNumIDAide2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TBNumIDAide2.KeyPress
        verifChampID(e)
    End Sub

    Private Sub verifChampID(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(e.KeyChar) Or Asc(e.KeyChar) = Keys.Back Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

#End Region

    ''' <summary>
    ''' Permet de commencer la session d'un utilisateur
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub BStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BStart.Click

        ' Empeche de démarrer une sesion si la date n'est pas la bonne
        If Date.Now.Year < 2017 Then
            MsgBox("Attention la date de l'appareil n'est pas correct", MsgBoxStyle.Exclamation, "Date incorrect")
            Shell("\Windows\clock.exe", AppWinStyle.NormalFocus)
            Exit Sub
        End If

        If Not isValiditeID() Then
            Exit Sub
        End If
        If Not isValidateIDAide() Then
            Exit Sub
        End If
        If Not isValidateIDAide2() Then
            Exit Sub
        End If

        numMachine = Nothing
        posteActuel = Nothing
        frID = Me

        myRebut = New RebutManager()
        myQteProd = New QuantiteProdManager()
        recuperationProduit()

        posteActuel = CBPoste.SelectedItem.ToString

        If posteActuel = Week1 Or posteActuel = Week2 Then
            TPS_TRAVAIL = 12
        Else
            If Date.Now.DayOfWeek = 1 And posteActuel = Matin Then
                TPS_TRAVAIL = 6.5
            ElseIf Date.Now.DayOfWeek = 5 And posteActuel = Soir Then
                TPS_TRAVAIL = 6.5
            ElseIf Date.Now.DayOfWeek = 5 And posteActuel = Nuit Then
                TPS_TRAVAIL = 6.5
            Else
                TPS_TRAVAIL = 8
            End If
        End If

        myUser = New User(TBNumID.Text, TBNumIDAide.Text, TBNumIDAide2.Text)

        If myUser.getDirectoryFromUser() Then
            If MsgBox("Souhaitez-vous reprendre la dernière session en cours?", vbYesNo + vbQuestion, "Continuer session") = MsgBoxResult.Yes Then

                myUser.uploadData()
            Else
                horsligne = True
                saveDataInDatabase()
                myUser.createDirectory()
            End If

        Else
            horsligne = True
            saveDataInDatabase()
            myUser.createDirectory()
        End If

        resetLeds()
        frmChoix.ShowDialog()
        TBNumID.Focus()
    End Sub

    Private Sub saveDataInDatabase()
        If Not isMainDirectoryEmpty() Then
            Dim frmCharg As New frmChargement
            frmCharg.Show()
            frmCharg.Refresh()

            If isConnectionOK() Then
                Dim upldMngr As New UploadManager
                Try
                    upldMngr.uploadAllDirectories()
                Catch ex As Exception
                    Debug.WriteLine(ex.StackTrace)
                End Try
            End If
            frmCharg.Close()
            frmCharg.Dispose()
        End If
    End Sub

    ''' <summary>
    ''' Permet de verifier la validité du numéro de pointage
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValiditeID() As Boolean
        If TBNumID.Text = "" Then
            MsgBox("Vous devez renseigner ou scanner un numéro de pointage", MsgBoxStyle.Exclamation, "ID manquant")
            TBNumID.Focus()
            Return False
        End If

        If Not (Len(TBNumID.Text) > 0 And Len(TBNumID.Text) < 5 And IsNumeric(TBNumID.Text)) Then
            MsgBox("Votre numéro de pointage est incorrect", MsgBoxStyle.Exclamation, "ID invalide")
            TBNumID.Text = ""
            TBNumID.Focus()
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Permet de verifier la validité du numéro de pointage aide 1
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValidateIDAide() As Boolean
        If TBNumIDAide.Text <> "" Then
            If Not (Len(TBNumIDAide.Text) > 0 And Len(TBNumIDAide.Text) < 5 And IsNumeric(TBNumIDAide.Text)) Then
                MsgBox("Votre numéro de pointage d'aide est incorrect", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide.Text = ""
                TBNumIDAide.Focus()
                Return False
            ElseIf TBNumID.Text = TBNumIDAide.Text Then
                MsgBox("Votre numéro de pointage d'aide ne doit pas être le même que le numéro de pointage", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide.Text = ""
                TBNumIDAide.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    ''' <summary>
    ''' Permet de verifier la validité du numéro de pointage aide 2
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValidateIDAide2() As Boolean
        If TBNumIDAide2.Text <> "" Then
            If Not (Len(TBNumIDAide2.Text) > 0 And Len(TBNumIDAide2.Text) < 5 And IsNumeric(TBNumIDAide2.Text)) Then
                MsgBox("Votre numéro de pointage d'aide secondaire est incorrect", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide2.Text = ""
                TBNumIDAide2.Focus()
                Return False
            ElseIf TBNumID.Text = TBNumIDAide2.Text Then
                MsgBox("Votre numéro de pointage d'aide secondaire ne doit pas être le même que le numéro de pointage", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide2.Text = ""
                TBNumIDAide2.Focus()
                Return False
            ElseIf TBNumIDAide.Text = TBNumIDAide2.Text Then
                MsgBox("Votre numéro de pointage d'aide secondaire ne doit pas être le même que le numéro de pointage d'aide", MsgBoxStyle.Exclamation, "ID aide invalide")
                TBNumIDAide2.Text = ""
                TBNumIDAide2.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub frmID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = System.Windows.Forms.Keys.F1) Then
            Me.Close()
        End If
    End Sub

    Private Sub TBNumIDAide_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNumIDAide.TextChanged
        TBNumIDAide2.Enabled = True
    End Sub

    Private Sub TBNumIDAide_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNumIDAide.GotFocus
        isFocusedNum = True
        isFocusedNum2 = False
    End Sub

    Private Sub TBNumIDAide2_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBNumIDAide2.GotFocus
        isFocusedNum = False
        isFocusedNum2 = True
    End Sub

    Public Sub resetTextBox()
        CBPoste.SelectedItem = getPoste()
        TimerPoste.Interval = 0
        TimerPoste.Enabled = True
        TBNumID.Text = ""
        TBNumIDAide.Text = ""
        TBNumIDAide2.Text = ""
        TBNumID.Focus()
    End Sub
End Class