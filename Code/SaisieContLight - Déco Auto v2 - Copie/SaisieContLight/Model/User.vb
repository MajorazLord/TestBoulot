Imports System.IO
Imports System.Data

Public Class User

    Private numPointage As String
    Private numAide As String
    Private numAide2 As String
    Private pathFile As String

    Private hasFinished As Boolean

    Private pathFileDeclaration As String
    Private pathFileSaisie As String
    Private pathFileTempsProd As String
    Private pathFileQteFinPoste As String

    Private DTRebuts As DataTable
    Private DTRebutsTR As DataTable 'Rebuts en Temps reel'
    Private DTRebutsTRRECAP As DataTable
    Private DTArrets As DataTable
    Private DTIO As DataTable
    Private DTIORECAP As DataTable
    Private DTContenantBloque As DataTable
    Private DTContenantBloqueRECAP As DataTable
    Private DTTempsProduction As DataTable
    Private DTTempsProductionRECAP As DataTable
    Private DTSaisie As DataTable
    Private DTSaisieRebuts As DataTable
    Private DTSaisieArrets As DataTable
    Private DTQteFinPoste As DataTable

    Private listOF As New List(Of String)


    Public Sub New(ByVal pointage As String, ByVal aide As String, ByVal aide2 As String)
        numPointage = pointage
        numAide = aide
        numAide2 = aide2

        hasFinished = False

        initDT()
    End Sub

    Private Sub initDT()
        DTRebuts = New DataTable
        DTRebuts.Columns.Add("N°OF", GetType(String))
        DTRebuts.Columns.Add("Code", GetType(String))
        DTRebuts.Columns.Add("PiecesEcartées", GetType(Integer))
        DTRebuts.Columns.Add("Machine", GetType(String))

        DTRebutsTR = New DataTable
        DTRebutsTR.Columns.Add("NumEtiq", GetType(String))
        DTRebutsTR.Columns.Add("Code", GetType(String))
        DTRebutsTR.Columns.Add("PiecesEcartées", GetType(Integer))
        DTRebutsTR.Columns.Add("Machine", GetType(String))

        DTRebutsTRRECAP = New DataTable
        DTRebutsTRRECAP.Columns.Add("NumEtiq", GetType(String))
        DTRebutsTRRECAP.Columns.Add("Code", GetType(String))
        DTRebutsTRRECAP.Columns.Add("PiecesEcartées", GetType(Integer))
        DTRebutsTRRECAP.Columns.Add("Machine", GetType(String))

        DTArrets = New DataTable
        DTArrets.Columns.Add("N°Machine", GetType(String))
        DTArrets.Columns.Add("Production", GetType(String))
        DTArrets.Columns.Add("Code", GetType(String))
        DTArrets.Columns.Add("Durée", GetType(Double))

        DTContenantBloque = New DataTable
        DTContenantBloque.Columns.Add("Noetiq", GetType(String))

        DTContenantBloqueRECAP = New DataTable
        DTContenantBloqueRECAP.Columns.Add("Noetiq", GetType(String))

        DTIO = New DataTable
        DTIO.Columns.Add("Type", GetType(String))
        DTIO.Columns.Add("Lot", GetType(String))
        DTIO.Columns.Add("NoProd", GetType(String))
        DTIO.Columns.Add("Abv", GetType(String))
        DTIO.Columns.Add("Noof", GetType(String))
        DTIO.Columns.Add("NumEtiq", GetType(String))
        DTIO.Columns.Add("QuantEffect", GetType(String))
        DTIO.Columns.Add("QuantCont", GetType(String))
        DTIO.Columns.Add("Machine", GetType(String))
        DTIO.Columns.Add("dateScan", GetType(Date))
        DTIO.Columns.Add("NumCharge", GetType(String))
        DTIO.Columns.Add("NumMatrice", GetType(String))
        DTIO.Columns.Add("NumVague", GetType(String))
        DTIO.Columns.Add("Online", GetType(Boolean))

        DTIORECAP = New DataTable
        DTIORECAP.Columns.Add("Type", GetType(String))
        DTIORECAP.Columns.Add("Lot", GetType(String))
        DTIORECAP.Columns.Add("Noof", GetType(String))
        DTIORECAP.Columns.Add("NumEtiq", GetType(String))
        DTIORECAP.Columns.Add("QuantCont", GetType(String))
        DTIORECAP.Columns.Add("Machine", GetType(String))

        DTTempsProduction = New DataTable
        DTTempsProduction.Columns.Add("Machine", GetType(String))
        DTTempsProduction.Columns.Add("Noof", GetType(String))
        DTTempsProduction.Columns.Add("Noop", GetType(String))
        DTTempsProduction.Columns.Add("NumProduit", GetType(String))
        DTTempsProduction.Columns.Add("NbHeure", GetType(Double))
        DTTempsProduction.Columns.Add("RecupOK", GetType(Integer))

        DTTempsProductionRECAP = New DataTable
        DTTempsProductionRECAP.Columns.Add("Production", GetType(Integer))
        DTTempsProductionRECAP.Columns.Add("Machine", GetType(String))
        DTTempsProductionRECAP.Columns.Add("Noof", GetType(String))
        DTTempsProductionRECAP.Columns.Add("Noop", GetType(String))
        DTTempsProductionRECAP.Columns.Add("NumProduit", GetType(String))
        DTTempsProductionRECAP.Columns.Add("NbHeure", GetType(Double))

        DTSaisie = New DataTable
        DTSaisie.Columns.Add("Quantite", GetType(String))
        DTSaisie.Columns.Add("Noof", GetType(String))
        DTSaisie.Columns.Add("Machine", GetType(String))
        DTSaisie.Columns.Add("TempsProd", GetType(String))
        DTSaisie.Columns.Add("Produit", GetType(String))

        DTSaisieArrets = New DataTable
        DTSaisieArrets.Columns.Add("Code", GetType(String))
        DTSaisieArrets.Columns.Add("Heure", GetType(String))
        DTSaisieArrets.Columns.Add("Machine", GetType(String))
        DTSaisieArrets.Columns.Add("Production", GetType(String))

        DTSaisieRebuts = New DataTable
        DTSaisieRebuts.Columns.Add("Code", GetType(String))
        DTSaisieRebuts.Columns.Add("Quantite", GetType(String))
        DTSaisieRebuts.Columns.Add("NooF", GetType(String))
        DTSaisieRebuts.Columns.Add("Machine", GetType(String))

        DTQteFinPoste = New DataTable
        DTQteFinPoste.Columns.Add("Noof", GetType(String))
        DTQteFinPoste.Columns.Add("Noop", GetType(String))
        DTQteFinPoste.Columns.Add("NoProd", GetType(String))
        DTQteFinPoste.Columns.Add("Quantite", GetType(Integer))
        DTQteFinPoste.Columns.Add("Machine", GetType(String))
        DTQteFinPoste.Columns.Add("NoEtiq", GetType(String))
    End Sub

    Public Sub createDirectory(Optional ByVal pathSave As String = "")

        If pathSave = "" Then
            pathFile = CheminSaisieProd & numPointage & "\" & Secteur & "_" & Format(Now, "yyyyMMdd-HHmmss")
        Else
            pathFile = pathSave
        End If

        dateCreationSession = DateTime.ParseExact(pathFile.Split("\")(4).Split("_")(1), "yyyyMMdd-HHmmss", Nothing)

        Directory.CreateDirectory(pathFile)
        createFiles()
    End Sub

    Public Function getDirectoryFromUser() As Boolean
        Return Directory.Exists(CheminSaisieProd & numPointage)
    End Function

    Private Sub createFiles()
        createFileDeclaration()
        createFileSaisie()
        createFileTempsProd()
        createFileQteFinPoste()
    End Sub

    Private Sub createFileDeclaration()
        pathFileDeclaration = pathFile & "\Declaration.xls"

        If Not File.Exists(pathFileDeclaration) Then
            File.Create(pathFileDeclaration).Close()
            miseAJourDeclaration()
        End If
    End Sub

    Private Sub createFileSaisie()
        pathFileSaisie = pathFile & "\Saisie.xls"

        If Not File.Exists(pathFileSaisie) Then
            File.Create(pathFileSaisie).Close()
            miseAJourSaisie()
        End If
    End Sub

    Private Sub createFileTempsProd()
        pathFileTempsProd = pathFile & "\TempsProduction.xls"

        If Not File.Exists(pathFileTempsProd) Then
            File.Create(pathFileTempsProd).Close()
            miseAJourTempsProduction()
        End If
    End Sub

    Private Sub createFileQteFinPoste()
        pathFileQteFinPoste = pathFile & "\QteFinPoste.xls"

        If Not File.Exists(pathFileQteFinPoste) Then
            File.Create(pathFileQteFinPoste).Close()
            miseAJourQteFinPoste()
        End If
    End Sub

    Public Sub addPointageAide(ByVal pointageAide As String)
        numAide = pointageAide
    End Sub

    Public Sub addPointageAide2(ByVal pointageAide2 As String)
        numAide2 = pointageAide2
    End Sub

    Public Function getPointage() As String
        Return numPointage
    End Function

    Public Function getAide() As String
        Return numAide
    End Function

    Public Function getAide2() As String
        Return numAide2
    End Function

    Public Function getDTRebuts() As DataTable
        Return Me.DTRebuts
    End Function

    Public Function getDTRebutsTR() As DataTable
        Return Me.DTRebutsTR
    End Function

    Public Function getDTRebutsTRRECAP() As DataTable
        Return Me.DTRebutsTRRECAP
    End Function

    Public Function getDTArrets() As DataTable
        Return Me.DTArrets
    End Function

    Public Function getDTContenantBloque() As DataTable
        Return Me.DTContenantBloque
    End Function

    Public Function getDTContenantBloqueRecap() As DataTable
        Return Me.DTContenantBloqueRECAP
    End Function

    Public Function getDTIO() As DataTable
        Return Me.DTIO
    End Function

    Public Function getDTIORECAP() As DataTable
        Return Me.DTIORECAP
    End Function

    Public Function getDTTempsProduction() As DataTable
        Return Me.DTTempsProduction
    End Function

    Public Function getDTTempsProductionRECAP() As DataTable
        Return Me.DTTempsProductionRECAP
    End Function

    Public Function getDTSaisie() As DataTable
        Return Me.DTSaisie
    End Function

    Public Function getDTSaisieRebut() As DataTable
        Return Me.DTSaisieRebuts
    End Function

    Public Function getDTSaisieArret() As DataTable
        Return Me.DTSaisieArrets
    End Function

    Public Function getDTQteFinPoste() As DataTable
        Return DTQteFinPoste
    End Function

    Public Function getListOf() As List(Of String)
        Return listOF
    End Function

    ''' <summary>
    ''' Fonction qui rajoute une ligne d'arret à la DT des arrets de l'utilisateur
    ''' </summary>
    ''' <param name="numMach"></param>
    ''' <param name="code"></param>
    ''' <param name="time"></param>
    ''' <remarks></remarks>
    Public Sub addArret(ByVal numMach As String, ByVal prod As String, ByVal code As String, ByVal time As Double)
        Dim rows() As DataRow
        rows = DTArrets.Select("N°Machine = '" & numMach & "' and Production= '" & prod & "' and Code= '" & code & "'")

        If rows.Count <> 0 Then
            For Each row In rows
                Dim heure As Double = row.Item(2)
                row.Delete()
                DTArrets.Rows.Add(numMach, prod, code, time + heure)
            Next
        Else
            DTArrets.Rows.Add(numMach, prod, code, time)
        End If
    End Sub

    ''' <summary>
    ''' Fonction qui rajoute une ligne de pieces écartées à la DT correspondante de l'utilisateur
    ''' </summary>
    ''' <param name="numOF"></param>
    ''' <param name="code"></param>
    ''' <param name="nbPiecesEcrt"></param>
    ''' <remarks></remarks>
    Public Sub addPiecesEcrt(ByVal numOF As String, ByVal code As String, ByVal nbPiecesEcrt As Integer, ByVal numMachine As String)
        DTRebuts.Rows.Add(numOF, code, nbPiecesEcrt, numMachine)
    End Sub

    ''' <summary>
    ''' Attention le code est à 92 par défaut
    ''' </summary>
    ''' <param name="noof"></param>
    ''' <param name="machine"></param>
    ''' <remarks></remarks>
    Public Sub removeRebut(ByVal noof As String, ByVal machine As String)
        Dim row() As DataRow

        row = getDTRebuts.Select("N°OF = '" & noof & "' and Code='92' and Machine= '" & machine & "'")
        For Each element In row
            element.Delete()
        Next
    End Sub

    ''' <summary>
    ''' Fonction qui rajoute une ligne de pieces écartées à la DT temps reel correspondante de l'utilisateur
    ''' </summary>
    ''' <param name="numEtiq"></param>
    ''' <param name="code"></param>
    ''' <param name="nbPiecesEcrt"></param>
    ''' <remarks></remarks>
    Public Sub addPiecesEcrtTR(ByVal numEtiq As String, ByVal code As String, ByVal nbPiecesEcrt As Integer, ByVal numMachine As String)

        Dim row() As DataRow
        row = DTRebutsTR.Select("NumEtiq='" & numEtiq & "' And Code= '" & code & "' And Machine= '" & numMachine & "'")

        'Le duo OF/Code est déjà présent, on ajoute la quantité de rebuts à l'OF pour le même code'
        If row.Count <> 0 Then
            row(0).Item(2) += Convert.ToInt32(nbPiecesEcrt)
        Else
            DTRebutsTR.Rows.Add(numEtiq, code, nbPiecesEcrt, numMachine)
        End If

    End Sub

    ''' <summary>
    ''' Fonction qui rajoute une ligne de pieces écartées à la DT RECAP des rebuts temprs réel
    ''' </summary>
    ''' <param name="numEtiq"></param>
    ''' <param name="code"></param>
    ''' <param name="nbPiecesEcrt"></param>
    ''' <remarks></remarks>
    Public Sub addPiecesEcrtTRRECAP(ByVal numEtiq As String, ByVal code As String, ByVal nbPiecesEcrt As Integer, ByVal numMachine As String)

        Dim row() As DataRow
        row = DTRebutsTRRECAP.Select("NumEtiq='" & numEtiq & "' And Code= '" & code & "' and Machine= '" & numMachine & "'")

        'Le duo OF/Code est déjà présent, on ajoute la quantité de rebuts à l'OF pour le même code'
        If row.Count <> 0 Then
            row(0).Item(2) += nbPiecesEcrt
        Else
            DTRebutsTRRECAP.Rows.Add(numEtiq, code, nbPiecesEcrt, numMachine)
        End If

    End Sub

    ''' <summary>
    ''' Fonction qui ajoute une ligne de contenant bloqué dans la DT correspondante de l'utilisateur
    ''' </summary>
    ''' <param name="noEtiq"></param>
    ''' <remarks></remarks>
    Public Sub addContenantBloque(ByVal noEtiq As String)
        DTContenantBloque.Rows.Add(noEtiq)
        DTContenantBloqueRECAP.Rows.Add(noEtiq)
    End Sub

    ''' <summary>
    ''' Fonction qui rajoute une ligne d'IO à la DT des IOs de l'utilisateur
    ''' </summary>
    ''' <param name="type"></param>
    ''' <param name="numLot"></param>
    ''' <param name="NoProd"></param>
    ''' <param name="Abv"></param>
    ''' <param name="Noof"></param>
    ''' <param name="numEtiq"></param>
    ''' <param name="quantEffect"></param>
    ''' <param name="quantCont"></param>
    ''' <param name="machine"></param>
    ''' <remarks></remarks>
    Public Sub addIO(ByVal type As String, ByVal numLot As String, ByVal NoProd As String, ByVal Abv As String, ByVal Noof As String, ByVal numEtiq As String, ByVal quantEffect As String, ByVal quantCont As String, ByVal machine As String, ByVal numCharge As String, ByVal numMatrice As String, ByVal numVague As String, ByVal online As Boolean, Optional ByVal dateScan As String = "")
        'Ajoute dans la DT des entrée/sorties ainsi que celle des Recaps associés les données saisie par l'utilisateur'
        Dim myDate As Date

        If dateScan = "" Then
            myDate = Date.Now
        Else
            myDate = Date.Parse(dateScan)
        End If
        DTIO.Rows.Add(type, numLot, NoProd, Abv, Noof, numEtiq, quantEffect, quantCont, machine, myDate, numCharge, numMatrice, numVague, online)
        DTIORECAP.Rows.Add(type, numLot, Noof, numEtiq, quantCont, machine)
    End Sub

    ''' <summary>
    ''' Fonction qui supprime une entree/sortie suvant les paramètres passés
    ''' </summary>
    ''' <param name="noEtiq"></param>
    ''' <param name="typeIO"></param>
    ''' <remarks></remarks>
    Public Sub removeIO(ByVal noEtiq As String, ByVal typeIO As String)
        Dim rows() As DataRow

        rows = DTIO.Select("NumEtiq = '" & noEtiq & "' and Type = '" & typeIO & "'")

        For Each row As DataRow In rows
            row.Delete()
        Next

        rows = DTIORECAP.Select("NumEtiq = '" & noEtiq & "' and Type = '" & typeIO & "'")

        For Each row As DataRow In rows
            row.Delete()
        Next

    End Sub

    Public Sub updateIO(ByVal noof As String, ByVal machine As String, ByVal noEtiq As String)
        Dim rows() = DTIO.Select("Noof= '" & noof & "' and numEtiq= '" & noEtiq & "' and machine ='" & machine & "'")
        If rows.Count = 1 Then
            Dim type = rows(0)(0)
            Dim noLot = rows(0)(1)
            Dim noProd = rows(0)(2)
            Dim abv = rows(0)(3)
            Dim qte = rows(0)(6)
            Dim myDate = rows(0)(9)
            Dim numCharge = rows(0)(10)
            Dim numMatrice = rows(0)(11)
            Dim numVague = rows(0)(12)

            rows(0).Delete()
            DTIO.Rows.Add(type, noLot, noProd, abv, noof, noEtiq, qte, qte, machine, myDate, numCharge, numMatrice, numVague, 1)
        End If
    End Sub


    ''' <summary>
    ''' Fonction qui rajoute une ligne de temps de production à la DT des temps de prod de l'utilisateur
    ''' </summary>
    ''' <param name="Machine"></param>
    ''' <param name="Noof"></param>
    ''' <param name="Noop"></param>
    ''' <param name="NoProd"></param>
    ''' <remarks></remarks>
    Public Sub addTempsProduction(ByVal Machine As String, ByVal Noof As String, ByVal Noop As String, ByVal NoProd As String, ByVal TpsProd As Double, ByVal recupOK As Integer)
        Dim rows() As DataRow
        rows = DTTempsProduction.Select("Machine='" & Machine & "' and noof = '" & Noof & "' and noop= '" & Noop & "'")
        If rows.Count = 0 Then
            DTTempsProduction.Rows.Add(Machine, Noof, Noop, NoProd, TpsProd, recupOK)
        End If
    End Sub

    Public Sub updateTempsProduction(ByVal Machine As String, ByVal Noof As String, ByVal Noop As String, ByVal NoProd As String, ByVal TpsProd As Double)
        Dim rows() As DataRow
        rows = DTTempsProduction.Select("Machine='" & Machine & "' and noof='" & Noof & "' and noop = '" & Noop & " ' and numProduit='" & NoProd & "'")
        If rows.Count = 1 Then
            For Each row As DataRow In rows
                removeTempsProduction(row.Item(0), row.Item(1))
            Next
        End If
    End Sub

    ''' <summary>
    ''' Fonction qui rajoute une ligne de temps de production dans la table récapitulative correspondante
    ''' </summary>
    ''' <param name="Machine"></param>
    ''' <param name="Noof"></param>
    ''' <param name="Noop"></param>
    ''' <param name="NoProd"></param>
    ''' <param name="TpsProd"></param>
    ''' <remarks></remarks>
    Public Sub addTempsProductionRECAP(ByVal Production As String, ByVal Machine As String, ByVal Noof As String, ByVal Noop As String, ByVal NoProd As String, ByVal TpsProd As Double)
        Dim rows() As DataRow
        rows = DTTempsProductionRECAP.Select("Machine = '" & Machine & "' and noof = '" & Noof & "' and noop = '" & Noop & " ' and numProduit='" & NoProd & "'")
        If rows.Count = 0 Then
            DTTempsProductionRECAP.Rows.Add(Production, Machine, Noof, Noop, NoProd, TpsProd)
            rows = DTTempsProductionRECAP.Copy.Select("", "Production ASC")
            For Each row As DataRow In rows
                removeTempsProductionRECAP(row.Item(1), row.Item(2), row.Item(3), row.Item(4))
                DTTempsProductionRECAP.Rows.Add(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5))
            Next
        End If
    End Sub

    ''' <summary>
    ''' Fonction qui supprimee les temps de production dans la DT des temps de production
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub removeTempsProduction(ByVal Machine As String, ByVal Noof As String)
        Dim rows() As DataRow
        rows = DTTempsProduction.Select("Machine= '" & Machine & "' and Noof= '" & Noof & "'")
        For Each row As DataRow In rows
            row.Delete()
        Next
    End Sub

    ''' <summary>
    ''' Fonction qui supprime un temps de production dans la DT temps de production RECAP suivant les paramètres passés
    ''' </summary>
    ''' <param name="Machine"></param>
    ''' <param name="Noof"></param>
    ''' <param name="Noop"></param>
    ''' <param name="NoProd"></param>
    ''' <remarks></remarks>
    Public Sub removeTempsProductionRECAP(ByVal Machine As String, ByVal Noof As String, ByVal Noop As String, ByVal NoProd As String)
        Dim rows() As DataRow
        rows = DTTempsProductionRECAP.Select("Machine = '" & Machine & "' and Noof= '" & Noof & "' and Noop = '" & Noop & "' and NumProduit = '" & NoProd & "'")
        For Each row As DataRow In rows
            row.Delete()
        Next
    End Sub

    ''' <summary>
    ''' Fonction qui rajoute un numero d'OF à la liste des OF de l'utilisateur
    ''' </summary>
    ''' <param name="numOF"></param>
    ''' <remarks></remarks>
    Public Sub addOF(ByVal numOF As String)
        listOF.Add(numOF)
    End Sub

    ''' <summary>
    ''' Permet d'ajouter une production à la DT Saisie
    ''' </summary>
    ''' <param name="quantite"></param>
    ''' <param name="noof"></param>
    ''' <param name="machine"></param>
    ''' <remarks></remarks>
    Public Sub addSaisie(ByVal quantite As String, ByVal noof As String, ByVal noop As String, ByVal machine As String, ByVal isFinPoste As Boolean, ByVal produit As String, Optional ByVal tpsProd As String = "")
        Dim prod As String
        If noop = "" Then
            prod = noof
        Else
            prod = noof & "/" & noop
        End If

        Dim rows() As DataRow
        rows = DTSaisie.Select("Noof like '" & noof & "%' and Machine='" & machine & "'")
        If rows.Length = 0 Then
            If Not tpsProd = "" Then
                DTSaisie.Rows.Add(quantite, prod, machine, tpsProd, produit)
            Else
                DTSaisie.Rows.Add(quantite, prod, machine, 0, produit)
            End If

        Else
            Dim tmpsProd = rows(0).Item(3)
            Dim quantTmp As Integer = 0
            Dim quantBis As Integer = 0

            If Not rows(0).Item(0) = "" Then
                quantTmp = Convert.ToInt32(rows(0).Item(0))
            End If

            If Not quantite = "" Then
                quantBis = Convert.ToInt32(quantite)
            Else
                quantBis = quantTmp
            End If

            removeSaisie(noof, noop, machine)
            If isFinPoste Then
                DTSaisie.Rows.Add(quantBis, prod, machine, tmpsProd, produit)
            Else
                DTSaisie.Rows.Add(quantBis + quantTmp, prod, machine, tmpsProd, produit)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Permet d'ajouter le temps de production à une production déjà présente
    ''' </summary>
    ''' <param name="noof"></param>
    ''' <param name="machine"></param>
    ''' <param name="tpsProd"></param>
    ''' <remarks></remarks>
    Public Sub addSaisieProd(ByVal noof As String, ByVal noop As String, ByVal machine As String, ByVal tpsProd As String)
        Dim prod As String

        If noop = "" Then
            prod = noof
        Else
            prod = noof & "/" & noop
        End If

        Dim rows() As DataRow

        rows = DTSaisie.Select("Noof like '" & noof & "%' and Machine='" & machine & "'")
        If rows.Length <> 0 Then
            Dim quantite As String
            quantite = rows(0).Item(0)
            removeSaisie(noof, noop, machine)
            DTSaisie.Rows.Add(quantite, prod, machine, tpsProd)
        End If
    End Sub

    ''' <summary>
    ''' Permet de supprimer une production grâce au élément passé en paramètre
    ''' </summary>
    ''' <param name="noof"></param>
    ''' <param name="machine"></param>
    ''' <remarks></remarks>
    Public Sub removeSaisie(ByVal noof As String, ByVal noop As String, ByVal machine As String)

        Dim rows() As DataRow
        rows = DTSaisie.Select("Noof Like '" & noof & "%' and Machine='" & machine & "'")

        For Each row As DataRow In rows
            row.Delete()
        Next
    End Sub

    Public Sub updateSaisie(ByVal noof As String, ByVal noop As String, ByVal machine As String)
        ' 3 et 4
        Dim prod As String = noof & "/" & noop
        Dim rows() As DataRow
        Dim produit As String = ""
        Dim tpsProd As String = ""
        Dim qte As Integer = myQteProd.getQuantiteProd(noof, noop, machine)

        rows = DTSaisie.Select("Noof='" & prod & "' and Machine='" & machine & "'")
        For Each row As DataRow In rows
            If Not IsDBNull(row(4)) Then
                produit = row(4)
            End If
            tpsProd = row(3)
            row.Delete()
        Next
        addSaisie(qte, noof, noop, machine, False, produit, tpsProd)

    End Sub

    ''' <summary>
    ''' Permet d'ajouter une saisie de Rebuts
    ''' </summary>
    ''' <param name="code"></param>
    ''' <param name="quantite"></param>
    ''' <param name="noof"></param>
    ''' <remarks></remarks>
    Public Sub addSaisieRebuts(ByVal code As String, ByVal quantite As String, ByVal noof As String, ByVal machine As String)
        Dim rows() As DataRow
        rows = DTSaisieRebuts.Select("Code = '" & code & "' and Noof='" & noof & "' and Machine='" & machine & "'")
        If rows.Length = 0 Then
            DTSaisieRebuts.Rows.Add(code, quantite, noof, machine)
        Else
            Dim quantTmp = Convert.ToInt32(rows(0).Item(1))
            removeSaisieRebuts(code, noof, machine)
            DTSaisieRebuts.Rows.Add(code, Convert.ToInt32(quantite) + quantTmp, noof, machine)

        End If
    End Sub

    ''' <summary>
    ''' Permet de supprimer une saisie de Rebuts
    ''' </summary>
    ''' <param name="code"></param>
    ''' <param name="noof"></param>
    ''' <remarks></remarks>
    Public Sub removeSaisieRebuts(ByVal code As String, ByVal noof As String, ByVal machine As String)
        Dim rows() As DataRow
        rows = DTSaisieRebuts.Select("Code = '" & code & "' and Noof='" & noof & "' and Machine='" & machine & "'")
        For Each row As DataRow In rows
            row.Delete()
        Next
    End Sub

    ''' <summary>
    ''' Permet de savoir si un Rebut est présent selon un OF
    ''' </summary>
    ''' <param name="noof"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isRebuts(ByVal noof As String) As Boolean
        Dim rows() As DataRow
        rows = DTSaisieRebuts.Select("Noof = '" & noof & "'")
        Return Not rows.Length = 0

    End Function

    ''' <summary>
    ''' Permet d'ajouter une saisie d'Arrêt
    ''' </summary>
    ''' <param name="code"></param>
    ''' <param name="heure"></param>
    ''' <param name="machine"></param>
    ''' <remarks></remarks>
    Public Sub addSaisieArrets(ByVal code As String, ByVal heure As String, ByVal machine As String, ByVal prod As String)
        Dim rows() As DataRow
        rows = DTSaisieArrets.Select("Code = '" & code & "' and Heure='" & heure & "' and Machine='" & machine & "' and Production='" & prod & "'")
        If rows.Length = 0 Then
            DTSaisieArrets.Rows.Add(code, heure, machine, prod)
        End If
    End Sub

    ''' <summary>
    ''' Permet de supprimer une saisie d'Arrêt
    ''' </summary>
    ''' <param name="code"></param>
    ''' <param name="heure"></param>
    ''' <param name="machine"></param>
    ''' <remarks></remarks>
    Public Sub removeSaisieArrets(ByVal code As String, ByVal heure As String, ByVal machine As String, ByVal prod As String)
        Dim rows() As DataRow
        rows = DTSaisieArrets.Select("Code = '" & code & "' and Heure='" & heure & "' and Machine='" & machine & "'and Production='" & prod & "'")
        For Each row As DataRow In rows
            row.Delete()
        Next
    End Sub

    ''' <summary>
    ''' Permet de savoir si un Arrêt est présent selon une Machine
    ''' </summary>
    ''' <param name="machine"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isArrets(ByVal machine As String, ByVal prod As String) As Boolean
        Dim rows() As DataRow
        rows = DTSaisieArrets.Select("Machine='" & machine & "' and Production='" & prod & "'")
        If rows.Length = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function addQteFinPoste(ByVal noof As String, ByVal noop As String, ByVal noProd As String, ByVal qte As Integer, ByVal machine As String, ByVal noEtiq As String) As Boolean
        Dim rows() = DTQteFinPoste.Select("Noof = '" & noof & "' and Noop='" & noop & "' and machine= '" & machine & "' and NoEtiq='" & noEtiq & "'")
        If Not rows.Count = 0 Then
            MsgBox("Attention cette production est déjà saisie", MsgBoxStyle.Exclamation, "Ajout impossible")
            Return False
        End If

        DTQteFinPoste.Rows.Add(noof, noop, noProd, qte, machine, noEtiq)

        Return True
    End Function

    ''' <summary>
    ''' Verifie si il n'y a aucune ligne dans la DTContenantNT, DTArret, DTRebuts et DTIORECAP et DTTempsProduction, ce qui signifie que l'utilisateur n'a rien saisit
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isDTEmpty() As Boolean
        Return (Me.DTIORECAP.Rows.Count = 0 And Me.DTRebuts.Rows.Count = 0 And Me.DTRebutsTRRECAP.Rows.Count = 0 And Me.DTArrets.Rows.Count = 0 And Me.DTContenantBloque.Rows.Count = 0 And Me.DTTempsProduction.Rows.Count = 0)
    End Function

    ''' <summary>
    ''' Fonction renvoyant le boolean "hasFinished" de l'utilisateur
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isInputOver() As Boolean
        Return hasFinished
    End Function


    Public Function isNoetiqInLocalContenantBloque(ByVal Noetiq As String) As Boolean
        Dim data() As DataRow
        data = DTContenantBloqueRECAP.Select("Noetiq = '" & Noetiq & "'")
        Return data.Count <> 0
    End Function

    ''' <summary>
    ''' Fonction qui vérifie si une sortie a déjà été faite localement par un utilisateur, avant de déclarer la sortie
    ''' </summary>
    ''' <param name="Noetiq"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isLocalOutputAlreadyDoneForUser(ByVal Noetiq As String) As Boolean
        Dim data() As DataRow
        data = DTIORECAP.Select("NumEtiq = '" & Noetiq & "'")
        Return data.Count <> 0
    End Function

    ''' <summary>
    ''' Fonction permettant de mettre à TRUE le boolean "hasFinished" de l'utilisateur
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub inputIsOver()
        hasFinished = True
    End Sub

    Public Sub miseAJourDeclaration()
        Dim sLigne As String
        Dim x As New System.IO.StreamWriter(pathFileDeclaration, False, System.Text.Encoding.UTF8)

        sLigne = "Temps d'arrêt"
        x.WriteLine(sLigne)

        If DTArrets.Rows.Count <> 0 Then
            sLigne = "NumMachine;CodeNP;TpsNP;OF;OP"
            x.WriteLine(sLigne)

            For Each row As DataRow In DTArrets.Rows
                If row.Item(1).ToString = "" Then
                    sLigne = row.Item(0) & ";" & row.Item(2) & ";" & row.Item(3) & ";NULL;NULL"
                Else
                    sLigne = row.Item(0) & ";" & row.Item(2) & ";" & row.Item(3) & ";" & row.Item(1).ToString.Split("/")(0) & ";" & row.Item(1).ToString.Split("/")(1)
                End If

                x.WriteLine(sLigne)
            Next
        End If

        'Contenants non terminés'
        sLigne = "Quantité Fin de Poste"
        x.WriteLine(sLigne)

        If DTQteFinPoste.Rows.Count <> 0 Then
            sLigne = "Noof;Noop;NoProd;Quantite;NumMachine;NoEtiq"
            x.WriteLine(sLigne)

            For Each row As DataRow In DTQteFinPoste.Rows
                sLigne = row.Item(0) & ";" & row.Item(1) & ";" & row.Item(2) & ";" & row.Item(3) & ";" & row.Item(4) & ";" & row.Item(5)
                x.WriteLine(sLigne)
            Next
        End If

        'Rebuts'
        sLigne = "Rebuts / retouches"
        x.WriteLine(sLigne)

        'Si ce n'est pas le controle unitaire, alors ce n'est pas du temps reel'
        If Not Secteur.Equals(CodeControleCU) Then
            If DTRebuts.Rows.Count <> 0 Then
                sLigne = "ID;Code;NbPiecesEcartees;Num Machine"
                x.WriteLine(sLigne)

                For Each row As DataRow In DTRebuts.Rows
                    sLigne = row.Item(0) & ";" & row.Item(1) & ";" & row.Item(2) & ";" & row.Item(3)
                    x.WriteLine(sLigne)
                Next
            End If
        Else 'On est en temps réel au niveau des rebuts'
            If DTRebutsTR.Rows.Count <> 0 Then

                sLigne = "ID;Code;NbPiecesEcartees;Num Machine"
                x.WriteLine(sLigne)

                For Each row As DataRow In DTRebutsTR.Rows
                    sLigne = row.Item(0) & ";" & row.Item(1) & ";" & row.Item(2) & ";" & row.Item(3)
                    x.WriteLine(sLigne)
                Next
            End If
        End If

        x.Close()
    End Sub

    Public Sub miseAJourSaisie()
        Dim sLigne As String
        Dim x As New System.IO.StreamWriter(pathFileSaisie, False, System.Text.Encoding.UTF8)

        sLigne = "Pointage;" & numPointage
        x.WriteLine(sLigne)

        sLigne = "Pointage aide;" & numAide
        x.WriteLine(sLigne)

        sLigne = "Pointage aide Bis;" & numAide2
        x.WriteLine(sLigne)

        sLigne = "Poste;" & posteActuel
        x.WriteLine(sLigne)

        sLigne = "TypeMouvement;N°Lot;NoProd;AbvNomProd;N°OF;N°Etiq;Quantité réalisée;Quantité totale;Machine;DateScan;NumCharge;NumMatrice;NumVague;Online"
        x.WriteLine(sLigne)

        If DTIO.Rows.Count <> 0 Then
            For Each row As DataRow In DTIO.Rows
                sLigne = row.Item(0) & ";" & row.Item(1) & ";" & row.Item(2) & ";" & row.Item(3) & ";" & row.Item(4) & ";" & row.Item(5) & ";" & row.Item(6) & ";" & row.Item(7) & ";" & row.Item(8) & ";" & row.Item(9) & ";" & row.Item(10) & ";" & row.Item(11) & ";" & row.Item(12) & ";" & row.Item(13)
                x.WriteLine(sLigne)
            Next
        End If

        x.Close()
    End Sub

    Public Sub miseAJourTempsProduction()
        Dim sLigne As String
        Dim x As New System.IO.StreamWriter(pathFileTempsProd, False, System.Text.Encoding.UTF8)

        sLigne = "Pointage;" & numPointage
        x.WriteLine(sLigne)

        sLigne = "Machine;N°OF;N°OP;Num Produit;Nb Heure;Recup"
        x.WriteLine(sLigne)

        If DTTempsProduction.Rows.Count <> 0 Then
            For Each row As DataRow In DTTempsProduction.Rows
                sLigne = row.Item(0) & ";" & row.Item(1) & ";" & row.Item(2) & ";" & row.Item(3) & ";" & row.Item(4) & ";" & row.Item(5)
                x.WriteLine(sLigne)
            Next
        End If

        x.Close()
    End Sub

    Public Sub miseAJourQteFinPoste()
        Dim sLigne As String
        Dim x As New System.IO.StreamWriter(pathFileQteFinPoste, False, System.Text.Encoding.UTF8)

        sLigne = "CodeSession;" & codeSaisieActu
        x.WriteLine(sLigne)

        sLigne = "N°OF;N°OP;Machine;Quantité;NoEtiq"
        x.WriteLine(sLigne)

        If Not myQteProd Is Nothing Then
            For Each key In myQteProd.getDicoProd.Keys
                sLigne = key.Split("/")(0) & ";" & key.Split("/")(1) & ";" & key.Split("/")(2) & ";" & myQteProd.getDicoProd.Item(key) & ";" & myQteProd.getItemFromDicoEtiq(key)(0)
                x.WriteLine(sLigne)
            Next
        End If

        x.Close()
    End Sub

    Public Sub uploadData()
        initDT()
        createDirectory(Directory.GetDirectories(CheminSaisieProd & numPointage)(0))

        uploadDataSaisie()
        uploadDataDeclaration()
        uploadDataTempsProd()
        uploadDataQteFinPoste()
    End Sub

    Private Sub uploadDataDeclaration()

        Dim ligne() As String
        Dim x As New System.IO.StreamReader(pathFileDeclaration)

        While x.Peek <> -1
            ligne = x.ReadLine.Split(";")
            Debug.WriteLine(ligne(0))
            If ligne(0).Equals("NumMachine") Then
                While x.Peek <> -1
                    ligne = x.ReadLine.Split(";")
                    If ligne(0).Equals("Quantité Fin de Poste") Then
                        Exit While
                    End If
                    'ajout temps d'arret
                    If ligne(3) = "NULL" Then
                        addArret(ligne(0), "", ligne(1), ligne(2))
                        addSaisieArrets(ligne(1), ligne(2), ligne(0), "")
                    Else
                        addArret(ligne(0), ligne(3) & "/" & ligne(4), ligne(1), ligne(2))
                        addSaisieArrets(ligne(1), ligne(2), ligne(0), ligne(3) & "/" & ligne(4))
                    End If

                End While
            End If

            If ligne(0).Equals("ID") Or ligne(0).Equals("Noof") Then
                If ligne(1).Equals("Noop") Then
                    If ligne(2).Equals("NoProd") Then
                        'Boucle afin de récupérer toutes les données des contenants non finis'
                        While x.Peek <> -1
                            ligne = x.ReadLine().Split(";")
                            'Quitte la boucle de lecture des temps d'arrêt'
                            If ligne(0).Equals("Rebuts / retouches") Then
                                Exit While
                            End If
                            'ajout quantite fin poste
                            addQteFinPoste(ligne(0), ligne(1), ligne(2), ligne(3), ligne(4), ligne(5))
                            myQteProd.addQteFinPosteActuel(ligne(0), ligne(1), ligne(3), ligne(4), ligne(5))
                            myUser.addSaisie(ligne(3), ligne(0), ligne(1), ligne(4), True, ligne(2))
                        End While
                    End If
                ElseIf ligne(1).Equals("Code") Then
                    If Secteur.Equals(CodeControleCU) Then 'Si c'etait une session avec du temps reel ou non, il y aura peut-etre des mises a jour de lignes à faire'

                        While x.Peek <> -1
                            ligne = x.ReadLine.Split(";")
                            'ajout rebut tr
                            addPiecesEcrtTR(ligne(0), ligne(1), ligne(2), ligne(3))
                            addPiecesEcrtTRRECAP(ligne(0), ligne(1), ligne(2), ligne(3))
                            If ligne(0).Split("/").Length = 3 Then
                                addSaisieRebuts(ligne(1), ligne(2), ligne(0).Split("/")(0), ligne(3))
                            Else
                                Dim noof As String = ""
                                getDetailEtiquetteGOPAL(ligne(0), "", noof, "")
                                addSaisieRebuts(ligne(1), ligne(2), noof, ligne(3))
                            End If
                        End While
                    Else
                        While x.Peek <> -1
                            ligne = x.ReadLine().Split(";")
                            ' ajout rebut
                            addPiecesEcrt(ligne(0), ligne(1), ligne(2), ligne(3))
                            addSaisieRebuts(ligne(1), ligne(2), ligne(0), ligne(3))
                        End While
                    End If
                End If
            End If
        End While

        x.Close()

    End Sub

    Private Sub uploadDataSaisie()
        Dim ligne() As String
        Dim x As New System.IO.StreamReader(pathFileSaisie)

        x.ReadLine()   ' pointage
        x.ReadLine()  ' pointage aide
        x.ReadLine()   ' pointage aide 2
        x.ReadLine()   ' poste

        While x.Peek <> -1
            ligne = x.ReadLine.Split(";")
            If ligne(0).Equals("TypeMouvement") Then
                While x.Peek <> -1
                    Dim noop As String = ""
                    ligne = x.ReadLine.Split(";")
                    addIO(ligne(0), ligne(1), ligne(2), ligne(3), ligne(4), ligne(5), ligne(6), ligne(7), ligne(8), ligne(10), ligne(11), ligne(12), ligne(13), ligne(9))
                    Dim noEtiq() = ligne(5).Split("/")
                    If noEtiq.Length = 3 Then
                        addSaisie(ligne(7), ligne(4), noEtiq(1), ligne(8), False, ligne(2))
                    Else
                        getDetailEtiquetteGOPAL(ligne(5), "", "", noop)
                        addSaisie(ligne(7), ligne(4), noop, ligne(8), False, ligne(2))
                    End If

                    If Not listOF.Contains(ligne(4)) Then
                        addOF(ligne(4))
                    End If
                    myRebut.addMachine(ligne(4), ligne(8))

                    myQteProd.addEtiq(ligne(4) & "/" & noop & "/" & ligne(8), ligne(5))
                End While
            End If
        End While
        x.Close()
    End Sub

    Private Sub uploadDataTempsProd()
        Dim ligne() As String
        Dim x As New System.IO.StreamReader(pathFileTempsProd)

        x.ReadLine()

        While x.Peek <> -1
            ligne = x.ReadLine.Split(";")
            If ligne(0).Equals("Machine") Then

                While x.Peek <> -1
                    ligne = x.ReadLine.Split(";")
                    addTempsProduction(ligne(0), ligne(1), ligne(2), ligne(3), ligne(4), ligne(5))
                    addSaisieProd(ligne(1), ligne(2), ligne(0), ligne(4))
                End While

            End If
        End While

        x.Close()
    End Sub

    Private Sub uploadDataQteFinPoste()
        Dim ligne() As String
        Dim x As New System.IO.StreamReader(pathFileQteFinPoste)

        ligne = x.ReadLine().Split(";")
        codeSaisieActu = ligne(1)

        ligne = x.ReadLine.Split(";")

        While x.Peek <> -1
            ligne = x.ReadLine.Split(";")
            myQteProd.addProd(ligne(0), ligne(1), ligne(3), ligne(2), ligne(4))
        End While

        x.Close()
    End Sub

    Public Function getPathFile() As String
        Return pathFile
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
