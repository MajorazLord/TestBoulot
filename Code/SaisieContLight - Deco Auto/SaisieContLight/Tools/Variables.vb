Imports System.Data

Module Variables

    Public myRebut As RebutManager
    Public myQteProd As QuantiteProdManager

    Public horsligne As Boolean = True

    Public dateCreationSession As Date

    Public numPointage As Integer

    Public currentOFRebuts As String
    Public ajoutMachine As String

    Public Const HEIGHT_SCREEN_VGA As Integer = 640
    Public Const WIDTH_SCREEN_VGA As Integer = 480

    Public currentScreenHeight As Integer
    Public currentScreenWidth As Integer

    'Temps de travail d'une journée 
    Public TPS_TRAVAIL As Double

    Public Const REPONSE_OK As Integer = 6

    'Correspond au code qui va permettre de potentiellement insérer en temps réel les IO/Rebuts en BDD'
    Public codeSaisieActu As Integer

#Region "Chaine de connexion aux différentes bases de données"
    Public Const connS3SQL As String = "SERVER=10.163.14.203;UID=sa;PWD=Passw0rd;DATABASE=SAISIE_CONT;Connection Timeout=2;"
    Public Const connGOPAL As String = "SERVER=10.163.14.203;UID=sa;PWD=Passw0rd;DATABASE=GOPAL;Connection Timeout=2;"
    Public Const connT3BPW As String = "SERVER=10.163.14.1;UID=sa;PWD=Passw0rd;DATABASE=BPW_Datamarts;Connection Timeout=2;"
#End Region
    
    Public DTcodeNP As DataTable
    Public DTcodeDEF As DataTable

    'Variable permettant de savoir si la fenetre de saisie des totaux de production sera la derniere de la session ou juste une ouverture normale'
    'FLAG'
    Public finSaisie As Boolean

    Public choix As Boolean

    'References a la fenetre de saisi des arrets machines et aux rebuts, utilisées pour recupérer le code '
    Public frmAP As frmArretProd
    Public frmAM As frmArretMachine

    Public frmR As frmRebuts
    Public frID As frmID

    'Correspond au mode entrée/sortie du scan à effectuer'
    Public mode As String
    Public Const Sortie As String = "Sortie"
    Public Const Entree As String = "Entree"

    'Variable utilisée lorsqu'il n'y a pas d'OF dans la partie détachable, pour faire correspondre la fenetre de demande d'OF avec la fenetre des mouvements'
    Public numeroOF As String

    'Variable permettant de stocker le numero de machine choisit, afin de le réutiliser'
    Public numMachine As String

    Public monoMachine As String
    Public bMono As Boolean = False
    Public Const Multi As String = "MultiMachine"
    Public Const Mono As String = "MonoMachine"

    'Sauvegarde Correspondant au chemin absolu du fichier en cours de remplissage, ainsi que le dossier en cours'
    Public pathDirectory As String

    Public ajoutNumeroOF As String

    Public fenetreAide As String
    Public Const fenetreRebut As String = "Rebut"
    Public Const fenetreArretMachine As String = "ArretMach"
    Public Const fenetreArretProd As String = "ArretProd"

    Public currentProd As String
    Public currentMachine As String

    Public myUser As User

    Public dicoProduit As Dictionary(Of String, String)

#Region "Initialisation des différents secteurs"
    'Conserve le secteur lié à la douchette, présent dans le fichier parametre'
    Public Secteur As String

#Region "Code Secteur Montluçon"

    Public Const Debitage As String = "Debitage"
    Public Const CodeDebitage As String = "A100"

    Public Const Install As String = "Install"
    Public Const CodeInstall As String = "A200"

    Public Const Presse As String = "Presse"
    Public Const CodePresse300 As String = "A300"
    Public Const CodePresse390 As String = "A390"
    Public Const CodePresse500 As String = "A500"

    Public Const Controle As String = "Contrôle"
    Public Const CodeControleCU As String = "A492CU"
    Public Const CodeControleCV As String = "A492CV"
    Public Const CodeControle As String = "A492"

    Public Const Usinage As String = "Usinage"
    Public Const CodeUsinage As String = "A450"

    Public Const UsinageA As String = "Usinage Auto"
    Public Const CodeUsinageA As String = "A400AUTO"

    Public Const UsinageM As String = "Usinage Manuel"
    Public Const CodeUsinageM As String = "A400MANUEL"


    Public listFour As New List(Of String)
    Public Const PdCFourG As String = "AGCIEFFE"

#End Region

#Region "Code Secteur Guéret"
    Public Const InstallG As String = "Install Guéret"
    Public Const CodeInstallG As String = "A2200"

    Public Const UsinageG As String = "Usinage Guéret"
    Public Const CodeUsinageG As String = "A2400"

    Public Const PresseG As String = "Presse Guéret"
    Public Const CodePresseG As String = "A2500"

    Public Const ControleG As String = "Contrôle Guéret"
    Public Const CodeControleG As String = "A2492"
#End Region
#End Region

#Region "Initialisation des chemins d'accès"
    Public Const CheminSaisieProd As String = "\My Documents\SaisieProd\"
    Public Const CheminSecteurInit As String = "\Program Files\SaisieContLight\Secteur.ini"
    Public Const CheminMachineInit As String = "\Program Files\SaisieContLight\Machine.ini"
    Public Const CheminProduitInit As String = "Program Files\SaisieContLight\Produit.ini"
#End Region

#Region "Initialisation des postes"
    Public Const Matin As String = "MAT"
    Public Const Journee As String = "JOU"
    Public Const Soir As String = "SOI"
    Public Const Nuit As String = "NUI"
    Public Const Week1 As String = "WE1"
    Public Const Week2 As String = "WE2"

    'Poste de la session actuelle'
    Public posteActuel As String
#End Region

End Module
