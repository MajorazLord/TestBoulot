Imports Microsoft.Win32
Imports Datalogic.API
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Module Fonctions

#Region "Fonctions sur les fenetres"

    ''' <summary>
    ''' Affiche une image de validation au milieu de l'ecran pendant quelques secondes
    ''' </summary>
    ''' <param name="ecran"></param>
    ''' <remarks></remarks>
    Public Sub affichageValide(ByRef ecran As Form)
        Dim pbValid As New PictureBox
        pbValid.Parent = ecran
        pbValid.Image = New Bitmap(My.Resources.Validation)
        pbValid.SizeMode = PictureBoxSizeMode.StretchImage
        pbValid.BringToFront()
        If isScreenVGA() Then
            pbValid.Location = New Point(33 * 2, 51 * 2)
            pbValid.Size = New Size(166 * 2, 151 * 2)
        Else
            pbValid.Location = New Point(33, 51)
            pbValid.Size = New Size(166, 151)
        End If
        pbValid.Visible = True
        pbValid.Refresh()

        pause(1)

        pbValid.Visible = False
        pbValid.Refresh()

        pbValid.Parent = Nothing

    End Sub

    ''' <summary>
    ''' Fonction qui renvoi le poste en fonction de l'heure
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPoste() As String
        Dim minute As Integer = Date.Now.Minute
        Dim Heure As Integer = Date.Now.Hour
        Dim jour As Integer = Date.Now.DayOfWeek

        'WEEK-END'
        If jour = 5 Then 'vendredi
            If Heure > 4 And Heure <= 12 Then
                Return Matin
            ElseIf Heure > 12 And Heure < 19 Then
                Return Soir
            ElseIf Heure = 19 And minute >= 30 Then
                Return Nuit
            ElseIf Heure > 19 Then
                Return Nuit
            ElseIf Heure < 5 Then
                Return Nuit
            Else : Return Soir
            End If
        ElseIf jour = 6 Then 'samedi
            If Heure <= 1 Then
                Return Nuit
            ElseIf Heure >= 2 And Heure <= 13 Then
                Return Week1
            Else
                Return Week2
            End If
        ElseIf jour = 0 Then 'Dimanche 
            If Heure <= 1 Then
                Return Week2
            ElseIf Heure >= 2 And Heure < 18 Then
                Return Week1
            ElseIf Heure = 18 And minute < 30 Then
                Return Week1
            Else
                Return Week2
            End If
        ElseIf jour = 1 And Heure < 6 Then ' Lundi
            Return Week2
        ElseIf jour = 1 And Heure = 6 And minute < 30 Then
            Return Week2
        Else 'horaires classiques'
            If Heure > 12 And Heure <= 20 Then
                Return Soir
            ElseIf Heure > 4 And Heure <= 12 Then
                Return Matin
            Else
                Return Nuit
            End If
        End If
    End Function

    ''' <summary>
    ''' Vérifie si l'écran est un écran VGA
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isScreenVGA() As Boolean
        Return (currentScreenHeight = HEIGHT_SCREEN_VGA And currentScreenWidth = WIDTH_SCREEN_VGA)
    End Function

#End Region

#Region "Outils pour la gestion des DataTables"

    ''' <summary>
    ''' Fonction qui initialise les colonnes de chaque DataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub initialisationDT()

        'Pas a réinitialiser, puisque ces tables permet seulement de contenir les différents codes d'arrêt des machines'
        DTcodeNP = New DataTable
        DTcodeNP.Columns.Add("Code", GetType(String))
        DTcodeNP.Columns.Add("Intitule", GetType(String))

        DTcodeDEF = New DataTable
        DTcodeDEF.Columns.Add("Code", GetType(String))
        DTcodeDEF.Columns.Add("Intitule", GetType(String))

        recuperationCodeDEF()
        recuperationCodeNP()

        'recuperationCodeNP1()

    End Sub

#End Region

#Region "Outils pour le scan de données"

    ''' <summary>
    ''' Fonction qui renvoie vrai si la chaine contient autre choses que des min/maj,chiffres, et espaces
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function containsSpecialChars(ByVal data As String) As Boolean
        Dim sRegex As String = "^[a-zA-Z0-9 ]*$"
        Dim regexItem = New Regex(sRegex)
        If regexItem.IsMatch(data) Then
            Return False
        Else
            Return True
        End If
    End Function

    ''' <summary>
    ''' Fonction permettant de charger le décodeur en fonction d'un ecran
    ''' </summary>
    ''' <param name="hDcd"></param>
    ''' <param name="ecran"></param>
    ''' <param name="dcdEvent"></param>
    ''' <remarks></remarks>
    Public Sub loadFullDecodeur(ByRef hDcd As DecodeHandle, ByRef ecran As Form, ByRef dcdEvent As DecodeEvent)
        Try
            'DecodeHandle correspond à l'identification du decodeur de code barre'
            hDcd = New DecodeHandle(DecodeDeviceCap.Exists Or DecodeDeviceCap.Barcode)
        Catch ex As DecodeException
            MessageBox.Show("Impossible de charger le décodeur de code barre.", "Chargement")
            ecran.Close()
        End Try

        'Determine le type de requete envoyé par le scanner'
        Dim reqType As DecodeRequest = CType(1, DecodeRequest) Or DecodeRequest.PostRecurring

        'Necessite aussi <l'ecran> afin de lier l'evenement de lecture d'un code barre à une fenetre'
        dcdEvent = New DecodeEvent(hDcd, reqType, ecran)
    End Sub

    Public Sub getDetailsEtiquette(ByVal noof As Integer, ByVal noop As String, ByVal numEtiq As Integer, ByRef nolot As String, ByRef noProd As String, Optional ByRef isDataOk As Boolean = False)
        Dim req As New SqlCommand("SELECT NOLOT, NOPROD FROM DEMANDE WHERE NOLOT IN (SELECT DISTINCT NOLOT FROM GOPAL.dbo.DETAIL_ETIQ WHERE NOOF=" & noof & " AND NOOP='" & noop & "' AND NO_ETIQ=" & numEtiq & ")", New SqlConnection(connGOPAL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim lec = req.ExecuteReader
            If lec.Read Then
                nolot = lec.GetString(0)
                noProd = lec.GetString(1)
                isDataOk = True
            Else
                isDataOk = False
            End If
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try
    End Sub

    Public Sub getDetailsEtiquette(ByVal nolot As String, ByRef noProd As String, Optional ByRef isDataOk As Boolean = False)
        Dim req As New SqlCommand("select NOPROD from DEMANDE where NOLOT='" & nolot & "'", New SqlConnection(connGOPAL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim lec = req.ExecuteReader
            If lec.Read Then
                noProd = lec.GetString(0)
                isDataOk = True
            Else
                isDataOk = False
            End If
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Permet de recupérer le numéro et le nom du produit selon l'OF
    ''' </summary>
    ''' <param name="noProd"></param>
    ''' <param name="abvProd"></param>
    ''' <param name="noof"></param>
    ''' <remarks></remarks>
    Public Sub getABVNomProd(ByRef noProd As String, ByRef abvProd As String, ByVal noof As String)
        Dim key = noof & "/" & noProd
        For Each element In dicoProduit.Keys
            If element.Split("/")(0) = noof Then
                noProd = element.Split("/")(1)
                abvProd = dicoProduit.Item(element)
                Exit Sub
            End If
        Next
        Dim req As New SqlCommand("SELECT Name FROM DT_Articles where [Item number]= '" & noProd & "'", New SqlConnection(connT3BPW))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim lec = req.ExecuteReader
            If lec.Read Then
                abvProd = lec.GetString(0)
                addProduitInDico(noProd, abvProd, noof)
            End If
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try

    End Sub

    ''' <summary>
    ''' Permet de récupérer le n° de lot si on a une etiquette GOPAL
    ''' </summary>
    ''' <param name="NoGopal"></param>
    ''' <param name="NoLot"></param>
    ''' <remarks></remarks>
    Public Sub getDetailEtiquetteGOPAL(ByVal nogopal As String, ByRef nolot As String, ByRef noof As String, ByRef noop As String)
        Dim req As New SqlClient.SqlCommand("select distinct nolot, noof, noop from detail_etiq where no_gopal = '" & nogopal & "'", New SqlClient.SqlConnection(connGOPAL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim result = req.ExecuteReader
            If result.Read Then
                nolot = result(0)
                noof = result(1)
                noop = result(2)
            Else
                nolot = ""
                noof = ""
                noop = ""
            End If
        Catch ex As Exception
            nolot = ""
            noof = ""
            noop = ""
            req.Connection.Close()
        End Try
        req.Connection.Close()
    End Sub

    ''' <summary>
    ''' Permet de récupérer le n° de produit grace au n° OF
    ''' </summary>
    ''' <param name="Noof"></param>
    ''' <param name="NumProd"></param>
    ''' <remarks></remarks>
    Public Sub getDetailEtiquetteNumProduit(ByVal Noof As Integer, ByRef NumProd As String)
        For Each element In dicoProduit.Keys
            If element.Split("/")(0) = Noof Then
                NumProd = element.Split("/")(1)
                Exit Sub
            End If
        Next

        Dim req As New SqlClient.SqlCommand("SELECT DISTINCT D.NOPROD FROM DEMANDE AS D INNER JOIN DETAIL_ETIQ AS DET ON D.NOLOT = DET.NOLOT WHERE (DET.NOOF = '" & Noof & "') ", New SqlClient.SqlConnection(connGOPAL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim result = req.ExecuteReader
            If result.Read Then
                NumProd = result(0)
            Else
                NumProd = ""
            End If
        Catch ex As Exception
            NumProd = ""
            req.Connection.Close()
        End Try
        req.Connection.Close()
    End Sub

    ''' <summary>
    ''' Permet de voir si le numéro d'of est présent en base de données
    ''' </summary>
    ''' <param name="noof"></param>
    ''' <remarks></remarks>
    Public Function isNumOF(ByVal noof As String) As Boolean
        Dim req As New SqlClient.SqlCommand("SELECT DISTINCT NOOF FROM DETAIL_ETIQ WHERE NOOF= '" & noof & "'", New SqlClient.SqlConnection(connGOPAL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim result = req.ExecuteReader
            If result.Read Then
                req.Connection.Close()
                Return True
            Else
                req.Connection.Close()
                Return False
            End If
        Catch ex As Exception
            req.Connection.Close()
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Temporisation de ~ 0.5 seconde avec un coefficient
    ''' </summary>
    ''' <param name="coef">0.5 * coef</param>
    ''' <remarks></remarks>
    Public Sub pause(ByVal coef As Integer)
        Threading.Thread.Sleep(300 * coef)
    End Sub

    ''' <summary>
    ''' Permet d'avoir le nombre de seconde avant la prochaine heure
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSecondsToNextHour() As Integer

        Dim currentMinute As Integer = Date.Now.Minute
        Dim currentSecond As Integer = Date.Now.Second
        Dim secondsPastLastHour As Integer = currentMinute * 60 + currentSecond

        If currentMinute < 30 Then
            Return 1800 - secondsPastLastHour
        Else
            Return (3600 - secondsPastLastHour)
        End If


    End Function

    ''' <summary>
    ''' Fonction de vérification du numéro de la partie détachable, qui peut contenir ou non le numéro d'OF
    ''' </summary>
    ''' <param name="data"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isNoEtiqOK(ByVal data As String) As Boolean

        Dim rgx As New Regex("[0-9]+(\-)?[0-9]+")

        If data.StartsWith("G") Then
            If Len(data) > 11 And Len(data) < 14 Then
                Return IsNumeric(Mid(data, 4, Len(data) - 3))
            Else
                Return False
            End If
        ElseIf data.StartsWith("A") Then
            If Len(data) >= 11 And Len(data) < 16 Then
                Return IsNumeric(Mid(data, 2, Len(data) - 1))
            Else
                Return False
            End If
        ElseIf data.Split("/").Length = 3 Then
            Dim separateValue = data.Split("/")
            If IsNumeric(separateValue(0)) And IsNumeric(separateValue(2)) Then
                return rgx.IsMatch(separateValue(1)) 
            Else
                Return False
            End If
        End If
        Return False
    End Function

    ''' <summary>
    ''' Fonction qui permet d'afficher le point vert si réussite du scan
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub affichePointVert()
        'Boucle pour faire apparaitre le point vert'
        Device.EnableLED(Device.LEDs.GreenSpot, True)
        pause(1)
        Device.EnableLED(Device.LEDs.GreenSpot, False)
    End Sub
#End Region

#Region "Outils sur les dossiers/fichiers"

    ''' <summary>
    ''' Fonction permettant de créer le dossier dans lequel on doit créer les fichiers de saisies
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub createDirectory()

        'Recupération de la date de création, qui sera utilisé lors de l'upload en bdd'
        pathDirectory = CheminSaisieProd & Secteur & "_" & Format(Now, "yyyyMMdd-HHmmss")
        System.IO.Directory.CreateDirectory(pathDirectory)

    End Sub

    ''' <summary>
    ''' Vérifie si c'est un secteur valide
    ''' </summary>
    ''' <param name="secteur"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValideSecteur(ByVal secteur As String) As Boolean
        Return (secteur.Equals(CodeDebitage) Or secteur.Equals(CodeInstall) Or secteur.Equals(CodePresse300) Or secteur.Equals(CodePresse390) Or secteur.Equals(CodePresse500) Or secteur.Equals(CodeUsinageA) Or secteur.Equals(CodeUsinageM) Or secteur.Equals(CodeUsinage) Or secteur.Equals(CodeControleCU) Or secteur.Equals(CodeControleCV) Or secteur.Equals(CodeControleG) Or secteur.Equals(CodeInstallG) Or secteur.Equals(CodeUsinageG) Or secteur.Equals(CodePresseG))
    End Function

    ''' <summary>
    ''' Verifie le code (numero de HALL) présent dans le fichier parametre
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub recuperationSecteur()
        If Not IO.File.Exists(CheminSecteurInit) Then
            'Fichier Secteur.ini introuvable'
            Dim w As New System.IO.StreamWriter(CheminSecteurInit, IO.FileMode.CreateNew, System.Text.Encoding.UTF8)
            w.WriteLine(CodeInstall)
            w.Close()
        End If

        Dim x As New System.IO.StreamReader(CheminSecteurInit)

        'recuperation de la ligne'
        Dim type As String = x.ReadLine

        If isValideSecteur(type) Then
            Secteur = type
        Else
            MsgBox("Numéro de secteur présent dans le fichier Secteur.ini incorrect.", MsgBoxStyle.Exclamation, "Fatal error")
            Throw New ConstraintException
        End If

        x.Close()
    End Sub

    ''' <summary>
    ''' Convertie le numero de secteur avec son nom
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNomSecteur() As String
        If Secteur.Equals(CodeDebitage) Then
            Return Debitage
        ElseIf Secteur.Equals(CodeInstall) Then
            Return Install
        ElseIf Secteur.Equals(CodePresse300) Or Secteur.Equals(CodePresse390) Or Secteur.Equals(CodePresse500) Then
            Return Presse
        ElseIf Secteur.Equals(CodeUsinage) Then
            Return Usinage
        ElseIf Secteur.Equals(CodeUsinageA) Then
            Return UsinageA
        ElseIf Secteur.Equals(CodeUsinageM) Then
            Return UsinageM
        ElseIf Secteur.Equals(CodeControleCU) Or Secteur.Equals(CodeControleCV) Then
            Return Controle
        ElseIf Secteur.Equals(CodeControleG) Then
            Return ControleG
        ElseIf Secteur.Equals(CodeInstallG) Then
            Return InstallG
        ElseIf Secteur.Equals(CodeUsinageG) Then
            Return UsinageG
        ElseIf Secteur.Equals(CodePresseG) Then
            Return PresseG
        Else : Return Nothing
        End If
    End Function

    ''' <summary>
    ''' Modification du numero de secteur présent dans le fichier Secteur.ini
    ''' </summary>
    ''' <param name="numSecteur"></param>
    ''' <remarks></remarks>
    Public Sub modificationFichierSecteur(ByVal numSecteur As String)
        Dim x = New System.IO.StreamWriter(CheminSecteurInit, False)
        x.Write(numSecteur)
        x.Close()
    End Sub

    Public Sub recuperationProduit()
        If Not IO.File.Exists(CheminProduitInit) Then
            Dim file As New IO.StreamWriter(CheminProduitInit, IO.FileMode.CreateNew, System.Text.Encoding.UTF8)
            file.Close()
        End If
        dicoProduit = New Dictionary(Of String, String)

        Dim myFile As New IO.StreamReader(CheminProduitInit)
        Dim ligne() As String
        While myFile.Peek <> -1
            ligne = myFile.ReadLine.Split(";")

            If Not dicoProduit.Keys.Contains(ligne(0)) Then
                dicoProduit.Add(ligne(0), ligne(1))
            End If
        End While

        myFile.Close()
    End Sub

    Public Sub addProduitInDico(ByVal noProd As String, ByVal nomProd As String, ByVal noof As String)
        Dim key = noof & "/" & noProd
        If Not dicoProduit.Keys.Contains(key) Then
            dicoProduit.Add(key, nomProd)
        End If
    End Sub

    Public Sub saveProduitInFile()
        Dim file As New IO.StreamWriter(CheminProduitInit, False, System.Text.Encoding.UTF8)
        For Each element In dicoProduit.Keys
            file.WriteLine(element & ";" & dicoProduit.Item(element))
        Next
        file.Close()
    End Sub

    Public Sub recuperationMachine()
        If Not IO.File.Exists(CheminMachineInit) Then
            Dim w As New System.IO.StreamWriter(CheminMachineInit, IO.FileMode.CreateNew, System.Text.Encoding.UTF8)
            w.WriteLine(Multi)
            w.Close()
        End If

        Dim x As New System.IO.StreamReader(CheminMachineInit)
        Dim type As String

        While x.Peek <> -1
            type = x.ReadLine
            If type.Equals(Multi) Then
                bMono = False
            ElseIf type.Equals(Mono) Then
                bMono = True
                While x.Peek <> -1
                    type = x.ReadLine
                    monoMachine = type
                End While
            End If
        End While
        x.Close()
    End Sub

    Public Sub modificationFichierMachine(ByVal bMono As Boolean, Optional ByVal numMachine As String = "")
        Dim x = New System.IO.StreamWriter(CheminMachineInit, False)
        If bMono Then
            x.WriteLine(Mono)
            x.WriteLine(numMachine)
        Else
            x.Write(Multi)
        End If
        x.Close()
    End Sub

    ''' <summary>
    ''' Fichier permettant d'associer un code de non production à une désignation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub recuperationCodeNP()
        Try
            Dim lignes() As String = My.Resources.CODES_NP.Split("|")
            Dim data() As String

            For Each ligne As String In lignes
                data = ligne.Split(";")

                'Suppression du retour chariot de chaque debut de ligne, juste après le |'
                data(0) = data(0).Replace(vbCr, "").Replace(vbLf, "")
                DTcodeNP.Rows.Add(data(0), data(1))
            Next
        Catch
            MsgBox("Erreur de chargement du fichier CODES_NP.txt !", MsgBoxStyle.Critical, "Erreur")
            Throw New Exception
        End Try
    End Sub

    ''' <summary>
    ''' Fichier permettant d'associer un code defaut à une désignation
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub recuperationCodeDEF()
        Try
            Dim lignes() As String = My.Resources.CODES_DEF.Split("|")
            Dim data() As String

            For Each ligne As String In lignes
                data = ligne.Split(";")

                'Suppression du retour chariot de chaque debut de ligne, juste après le |'
                data(0) = data(0).Replace(vbCr, "").Replace(vbLf, "")
                DTcodeDEF.Rows.Add(data(0), data(1))
            Next
        Catch
            MsgBox("Erreur de chargement du fichier CODES_DEF.txt !", MsgBoxStyle.Critical, "Erreur")
            Throw New Exception
        End Try

    End Sub

    ''' <summary>
    ''' Fichier permettant d'associer un code de non production à une désignation (nouveau code)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub recuperationCodeNP1()
        Try
            Dim lignes() As String = My.Resources.CODES_NP1.Split("|")
            Dim data() As String

            For Each ligne As String In lignes
                data = ligne.Split(";")

                data(0) = data(0).Replace(vbCr, "").Replace(vbLf, "")
                DTcodeNP.Rows.Add(data(0), data(1))
            Next
        Catch ex As Exception
            MsgBox("Erreur de chargement du fichier CODES_NP1.txt!", MsgBoxStyle.Critical, "Erreur")
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Permet de savoir si le dossier des saisies est vide ou non, utilisé pour savoir s'il reste des trucs a upload
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isMainDirectoryEmpty() As Boolean
        Try
            If IO.Directory.GetDirectories(CheminSaisieProd).Length = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'Si c'est la première fois que l'on lance l'application, ce fichier n'existe pas'
            Return True
        End Try
    End Function

#End Region

#Region "Fonction pour le temps de production"
    Public Sub recupMachines(ByRef machines() As String, ByRef bDoublon As Boolean, ByRef bRecup As Boolean)
        Dim values As New ArrayList
        Dim nbRow As Integer
        Dim upldM As New UploadManager

        nbRow = upldM.uploadDataTempsProd(values)
        Array.Resize(machines, nbRow)

        Dim value(6) As String

        For index As Integer = 1 To nbRow
            value = values(index - 1)
            bRecup = Convert.ToBoolean(Convert.ToInt32(value(5)))
            If Array.IndexOf(machines, value(0)) = -1 Then
                machines.SetValue(value(0), index - 1)
            Else
                machines.SetValue(value(0), index - 1)
                bDoublon = True
            End If
        Next
    End Sub

    Public Function isDoublonMachine(ByVal machines() As String, ByVal machine As String) As Boolean
        Dim firstIndex As Integer = Array.IndexOf(machines, machine)
        Dim lastIndex As Integer = Array.LastIndexOf(machines, machine)
        If firstIndex = lastIndex Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region

#Region "Outils concernant la douchette (Charge/Connexion reseau ou wifi)"

    ''' <summary>
    ''' Fonction qui essaye de se connecter à la BDD en utilisant la connexion dispo (cable ou wifi)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isConnectionOK() As Boolean
        If isDeviceOnSocle() Or Microsoft.WindowsMobile.Status.SystemState.ConnectionsNetworkCount <> 0 Then
            Dim testConnexion As New SqlCommand("", New SqlConnection(connS3SQL))
            testConnexion.CommandTimeout = 2
            Try
                testConnexion.Connection.Open()
                testConnexion.Connection.Close()
                Return True
            Catch 'Provient de test.connection.open'
                testConnexion.Connection.Close()
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Public Class SYSTEM_POWER_STATUS_EX2
        Public ACLineStatus As Byte
        Public BatteryFlag As Byte
        Public BatteryLifePercent As Byte
        Public Reserved1 As Byte
        Public BatteryLifeTime As System.UInt32
        Public BatteryFullLifeTime As System.UInt32
        Public Reserved2 As Byte
        Public BackupBatteryFlag As Byte
        Public BackupBatteryLifePercent As Byte
        Public Reserved3 As Byte
        Public BackupBatteryLifeTime As System.UInt32
        Public BackupBatteryFullLifeTime As System.UInt32
        Public BatteryVoltage As System.UInt32
        Public BatteryCurrent As System.UInt32
        Public BatteryAverageCurrent As System.UInt32
        Public BatteryAverageInterval As System.UInt32
        Public BatterymAHourConsumed As System.UInt32
        Public BatteryTemperature As System.UInt32
        Public BackupBatteryVoltage As System.UInt32
        Public BatteryChemistry As Byte
    End Class 'SYSTEM_POWER_STATUS_EX2

    <DllImport("coredll")> _
    Public Function GetSystemPowerStatusEx2(ByVal _
      lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX2, _
      ByVal dwLen As System.UInt32, ByVal fUpdate As Boolean) _
      As System.UInt32
    End Function

    ''' <summary>
    ''' Renvoie vrai ou faux suivant si l'appareil est sur le socle ou non
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isDeviceOnSocle() As Boolean
        Return Datalogic.API.Device.GetIsInCradle()
    End Function

    ''' <summary>
    ''' Enleve le capslock ou tout autre touches provoquant une led jaune ou bleu
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub resetLeds()
        Datalogic.API.Device.KeybdSetKeyInputState(0)
    End Sub

#End Region

#Region "Reset de la douchette"

    ''' <summary>
    ''' Fonction permettant de soft reset la douchette
    ''' </summary>
    ''' <param name="dwIoControlCode"></param>
    ''' <param name="lpInBuf"></param>
    ''' <param name="nInBufSize"></param>
    ''' <param name="lpOutBuf"></param>
    ''' <param name="nOutBufSize"></param>
    ''' <param name="lpBytesReturned"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Declare Function KernelIoControl Lib "coredll.dll" (ByVal dwIoControlCode As Integer, ByVal lpInBuf As IntPtr, ByVal nInBufSize As Integer, ByVal lpOutBuf As IntPtr, ByVal nOutBufSize As Integer, ByVal lpBytesReturned As IntPtr) As Boolean
    Public Sub effectuerSoftReset()
        Datalogic.API.Device.Reset(Device.BootType.Warm)
    End Sub

#End Region


    Public Sub RecupHeureFinPoste()
        Dim reqSelect As New SqlCommand("select HEURE_FIN, DUREE  from MACHINES_CALENDRIER where DATE = '" & Date.Now.ToString("yyyy-MM-dd") & "' AND EQUIPE = '" & posteActuel & "'", New SqlConnection(connS3SQL))
        reqSelect.CommandTimeout = 2
        Try
            reqSelect.Connection.Open()
            Dim lec = reqSelect.ExecuteReader
            If lec.Read Then
                heureFin = lec.Item(0)
                dureePoste = lec.Item(1)
            Else
                heureFin = "42"
            End If
        Catch ex As Exception
            reqSelect.Connection.Close()
        End Try
    End Sub

    Public Sub LancerTimerDeco()
        RecupHeureFinPoste()
        If heureFin = "42" Then
            TimerSecu.Enabled = True
            TimerDeco.Enabled = False
            Exit Sub
        End If
        TimerDeco.Interval = CalculerTempsAvantDeco()
        TimerDeco.Enabled = True
        TimerSecu.Enabled = False
    End Sub

    Public Sub ArretTimerDeco()
        heureFin = "42"
        TimerDeco.Enabled = False
        TimerSecu.Enabled = False
    End Sub

    Public WithEvents TimerSecu As New Timer
    Public WithEvents TimerDeco As New Timer

    Private Sub TimerDeco_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDeco.Tick
        decoAutoON = True
        frmChoix.BFinPoste_Click(sender, e)
    End Sub

    Private Sub TimerSecu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerSecu.Tick
        'Relance le check de l'heure de fin 
        RecupHeureFinPoste()
        If heureFin <> "42" Then
            TimerSecu.Enabled = False
            LancerTimerDeco()
        End If
    End Sub

    Public Function CalculerTempsAvantDeco() As Double
        Dim heureATravailler = heureFin
        Dim heure As String = "0"
        Dim minute As String = "0"
        Dim seconde As String = "0"

        Dim heureFormater, heureNow As New DateTime

        If heureATravailler.Contains(".") Then
            Dim res = heureATravailler.Split(".")
            heure = res(0)
            If res(1).Length = 1 Then
                minute = CInt(res(1)) * 6
            ElseIf res(1).Length = 2 Then
                minute = CInt(res(1)) * 0.6
            End If
        Else
            heure = heureATravailler
        End If
        heureFormater = New DateTime(1, 1, 1, heure, minute, seconde)
        heureNow = New DateTime(1, 1, 1, Date.Now.Hour, Date.Now.Minute, Date.Now.Second)

        Dim diff = DateDiff(DateInterval.Second, heureNow, heureFormater) * 1000

        If heureFormater.Hour < heureNow.Hour Then
            diff = diff + 86400
        End If

        '15 min après l'heure
        Return diff + 900000

    End Function


    Public Sub fabEncours(ByVal noof As String, ByVal noop As String, ByVal noProd As String, ByVal abv As String, ByVal machine As String)
        Dim reqSelect As New SqlCommand("select machine from fab_encours where machine = '" & machine & "'", New SqlConnection(connS3SQL))
        reqSelect.CommandTimeout = 2
        Try
            reqSelect.Connection.Open()
            Dim lec = reqSelect.ExecuteReader
            If lec.Read Then
                Dim req As New SqlCommand("update fab_encours set noof ='" & noof & "', noopprec='" & noop & "', numpointage= " & numPointage & ", noprod='" & noProd & "', abvnoprod='" & abv & "' ,noop='', designop='', cadenceth='' where machine = '" & machine & "'", New SqlConnection(connS3SQL))
                req.CommandTimeout = 2
                Try
                    req.Connection.Open()
                    req.ExecuteNonQuery()
                    req.Connection.Close()
                Catch ex As Exception
                    req.Connection.Close()
                End Try
            Else
                Dim req As New SqlCommand("insert into fab_encours (machine, abvnoprod, noprod, noof, noopprec, numpointage) values('" & machine & "', '" & abv & "', '" & noProd & "', '" & noof & "', '" & noop & "', " & numPointage & ") ", New SqlConnection(connS3SQL))
                req.CommandTimeout = 2
                Try
                    req.Connection.Open()
                    req.ExecuteNonQuery()
                    req.Connection.Close()
                Catch ex As Exception
                    req.Connection.Close()
                End Try
            End If
        Catch ex As Exception
            reqSelect.Connection.Close()
        End Try

    End Sub

    Public Sub initListFour()
        listFour.Add("AE0211")
        listFour.Add("AE0212")
        listFour.Add("AE0213")
        listFour.Add("AE0214")
        listFour.Add("AE0229")
        listFour.Add("AE0232")
        listFour.Add("AE0233")
        listFour.Add("AE0234")
        listFour.Add("AE0235")
        listFour.Add("AE0236")
        listFour.Add("AE0237")
        listFour.Add("AE0238")
        listFour.Add("AE0239")
        listFour.Add("AE0250")
        listFour.Add("AE0251")
        listFour.Add("AE0252")
        listFour.Add("AE0253")
        listFour.Add("AE0254")
        listFour.Add("AE0255")
        listFour.Add("AE0256")
    End Sub

    Public Function isFour(ByVal numMach As String) As Boolean
        Return listFour.Contains(numMach)
    End Function
End Module
