Imports System.Data

Public Class UploadManager

    'NOTES'
    'test borne WiFi aux expeditions: ping 10.163.20.3'
    'test borne WiFi service inform.: ping 10.163.20.4'

    'Attributs permettant de manipuler les dossiers presents sur la douchette, afin de les remonter en bdd
    Private pathToSaisie As String
    Private pathToDeclarations As String
    Private pathToTempsProduction As String

    Private dateCreation As Date
    Private codeAInserer As Integer
    Private posteSession As String
    Private secteurSession As String

    Private iDUtilisateur As String
    Private iDAideUtilisateur As String
    Private iDAideUtilisateur2 As String

    Private codeTmp As String

    Private qteProdTmp As QuantiteProdManager

    ''' <summary>
    ''' Upload les données des dossiers restants sur la douchette, puis supprime le dossier. Renvoie une exception si jamais Erreur !
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub uploadAllDirectories()
       
        'Tant qu'il y a des dossiers a envoyer'
        While isMainDirectoryEmpty() = False

            For Each dossierPointage In IO.Directory.GetDirectories(CheminSaisieProd)
                For index As Integer = 0 To IO.Directory.GetDirectories(dossierPointage).Count - 1
                    qteProdTmp = New QuantiteProdManager
                    pathDirectory = IO.Directory.GetDirectories(dossierPointage)(index)

                    If IO.Directory.GetDirectories(CheminSaisieProd).Count > 1 Then
                        If Not myUser Is Nothing Then
                            horsligne = Not myUser.getPathFile = pathDirectory
                        Else
                            horsligne = True
                        End If
                    End If
                    
                    Debug.WriteLine("Hors ligne :" & horsligne)

                    If horsligne Then
                        Debug.WriteLine(pathDirectory)
                        uploadQte(pathDirectory)
                    End If

                    'Check si l'integrité du dossier est OK, cad si les dossiers sont correctement nommés, presents...'
                    miseAJourDirectory(dossierPointage)

                Next
                IO.Directory.Delete(dossierPointage, True)
            Next
        End While

    End Sub

    Public Sub uploadQte(ByVal cheminFile As String)
        Dim pathToQte = cheminFile & "\QteFinPoste.xls"
        Dim x As New IO.StreamReader(pathToQte)
        Dim ligne() As String
        ligne = x.ReadLine().Split(";")

        codeTmp = ligne(1)

        x.ReadLine()

        While x.Peek <> -1
            ligne = x.ReadLine.Split(";")
            If ligne(1) = "" Then
                getDetailEtiquetteGOPAL(ligne(4), "", ligne(0), ligne(1))
            End If

            qteProdTmp.addProd(ligne(0), ligne(1), ligne(3), ligne(2), ligne(4))
        End While

        x.Close()
    End Sub

    Public Sub miseAJourDirectory(ByVal dossierPointage As String)
        Dim suppressionDossierOK As Boolean
        suppressionDossierOK = False

        If isSessionIntegrityOK() Then
            pathToSaisie = pathDirectory & "\Saisie.xls"
            pathToDeclarations = pathDirectory & "\Declaration.xls"

            recupInfos(pathToSaisie)

            Try
                codeAInserer = recupCodeSaisie()
            Catch ex As Exception
                MsgBox("La connexion ne fonctionne pas, veuillez relancer le gestionnaire pour appareils Windows Mobile.", MsgBoxStyle.Exclamation, "En attente")
                Throw ex
            End Try

            Try
                If codeAInserer = 0 Then

                    codeAInserer = getNewNumFiche()

                    codeSaisieActu = codeAInserer

                    If secteurSession.Contains(CodeControle) Then
                        secteurSession = CodeControle
                    End If

                    'Insertion de la nouvelle session en BDD'
                    Dim reqSessionSaisie As New SqlCommand("Insert into SESSION_SAISIE (SECODESAISIE, SESECTEUR, SEPOSTE, SEDATECREATION, SEDATEUPLOAD, SEUPLOADOK) values (" & codeAInserer & ",'" & secteurSession & "','" & posteSession & "','" & dateCreation & "', '" & Date.Now & "',0)", New SqlConnection(connS3SQL))
                    reqSessionSaisie.CommandTimeout = 2
                    Try
                        reqSessionSaisie.Connection.Open()
                        reqSessionSaisie.ExecuteNonQuery()
                        reqSessionSaisie.Connection.Close()
                    Catch ex As Exception
                        reqSessionSaisie.Connection.Close()
                        Throw ex
                    End Try

                Else
                    'Suppression des données sur le serveur avec ce numero puis réupload correctement'
                    suppressionDonnees()
                End If

            Catch
                MsgBox("La connexion ne fonctionne pas, veuillez relancer le gestionnaire pour appareils Windows Mobile.", vbOK + MsgBoxStyle.Exclamation, "En attente")
                Throw New Exception
            End Try

            'On remonte les données de saisies et de prod'
            Try
                'Insertion de la nouvelle session dans la table session_saisie, et upload de tout le reste'
                uploadData(dossierPointage)
            Catch ex As Exception
                MsgBox("Problème en cours d'execution. Recommencez maintenant ou plus tard.", vbOK + MsgBoxStyle.Exclamation, "En attente")
                Throw New Exception
            End Try

            'Modification de l'etat de l'upload à OK, sinon l'execution ne va pas jusqu'ici'
            Dim updateFinish As New SqlCommand("update SESSION_SAISIE set SEUPLOADOK = 1, SEDATEUPLOAD = '" & Date.Now & "' where SECODESAISIE = " & codeAInserer & "", New SqlConnection(connS3SQL))
            updateFinish.CommandTimeout = 2
            updateFinish.Connection.Open()
            updateFinish.ExecuteNonQuery()
            updateFinish.Connection.Close()

            If Not suppressionDossierOK Then
                insertAllTempsProduction(dossierPointage)
            End If

        Else 'En cas d'erreur d'intégrité d'un des dossiers/fichiers'
            Throw New Exception
        End If
    End Sub

    ''' <summary>
    ''' Recupere l'id de l'operateur et celui de l'aide. Recupere aussi son poste
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Private Sub recupInfos(ByVal path As String)

        Dim nomDossier As String = pathDirectory.Split("\")(4)
        Dim x As System.IO.StreamReader
        Dim ligne() As String

        Try
            x = New System.IO.StreamReader(path, System.Text.Encoding.Default)
        Catch ex As Exception
            MsgBox(path & ": Fichier introuvable !", MsgBoxStyle.Exclamation)
            Throw ex
        End Try

        ligne = x.ReadLine.Split(";")    ' Lit la ligne du numID        
        ligne = x.ReadLine.Split(";")    ' Lit la ligne du numIDAide
        ligne = x.ReadLine.Split(";")    ' Lit la ligne du numIDAideBis
        ligne = x.ReadLine.Split(";")

        posteSession = ligne(1)

        x.Close()

        'Recuperation de la date de création du dossier dans la variable globale'
        secteurSession = nomDossier.Split("_")(0)
        dateCreation = DateTime.ParseExact(nomDossier.Split("_")(1), "yyyyMMdd-HHmmss", Nothing)
        Debug.WriteLine(dateCreation)


    End Sub

    ''' <summary>
    ''' Renvoie le numéro de fiche, ou 0 si rien
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function recupCodeSaisie(Optional ByVal dateC As Date = Nothing) As Integer
        If Not dateC = Nothing Then
            dateCreation = dateC
        End If

        Dim request As New SqlCommand("select SECODESAISIE from SESSION_SAISIE where SEPOSTE = '" & posteSession & "' AND SEDATECREATION = '" & dateCreation & "' AND SEUPLOADOK = 0", New SqlConnection(connS3SQL))
        request.CommandTimeout = 2
        Try
            request.Connection.Open()

            Dim lecture = request.ExecuteReader
            Dim result As Integer

            If lecture.Read Then
                result = lecture.GetInt32(0)
            Else
                result = 0
            End If

            request.Connection.Close()
            Return result
        Catch ex As Exception
            request.Connection.Close()
            Throw ex
        End Try

    End Function

    ''' <summary>
    ''' Fonction renvoyant le dernier numéro d'ID disponible dans la bdd
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getNewNumFiche() As Integer
        Dim req As New SqlCommand("select max(SECODESAISIE) from SESSION_SAISIE", New SqlConnection(connS3SQL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim lecture = req.ExecuteReader
            If lecture.Read() Then
                Return lecture.GetInt32(0) + 1
            Else
                Return 1
            End If

        Catch ex As Exception
            req.Connection.Close()
            Throw ex
        End Try
    End Function

    'Fonction appelée seulement si un upload s'est mal déroulé, permet de supprimer en bdd l'existant et de tenter de reupload'
    ''' <summary>
    ''' Supprime les données en bdd correspondant au numéro de fiche en cours, afin de réuploader sans problème
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub suppressionDonnees()

        Dim reqDel1 As New SqlCommand("Delete from TEMPS_NP1 where TNPCODESAISIE = '" & codeAInserer & "'", New SqlConnection(connS3SQL))
        Dim reqDel3 As New SqlCommand("Delete from MEMBRE where MCODESAISIE = '" & codeAInserer & "'", New SqlConnection(connS3SQL))
        reqDel1.CommandTimeout = 2
        reqDel3.CommandTimeout = 2

        Try
            reqDel1.Connection.Open()
            reqDel1.ExecuteNonQuery()
            reqDel1.Connection.Close()

            reqDel3.Connection.Open()
            reqDel3.ExecuteNonQuery()
            reqDel3.Connection.Close()


        Catch
            reqDel1.Connection.Close()
            reqDel3.Connection.Close()
        End Try

    End Sub

    ''' <summary>
    ''' Fonction qui permet d'appeller les 2 fonctions d'upload des données présents dans les fichiers
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub uploadData(ByVal dossier As String)

        uploadDataSaisie()
        uploadDataDeclaration()

        pathDirectory = IO.Directory.GetDirectories(dossier)(0)

        pathToTempsProduction = pathDirectory & "\TempsProduction.xls"

    End Sub

    ''' <summary>
    ''' Fonction remontant en BDD les données du fichiers de saisie
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub uploadDataSaisie()
        Dim ligne() As String
        Dim x As System.IO.StreamReader
        x = New System.IO.StreamReader(pathToSaisie)

        'Recupération du numéro de pointage de l'utilisateur et de son aide associé'
        ligne = x.ReadLine.Split(";")
        iDUtilisateur = ligne(1)

        ligne = x.ReadLine.Split(";")
        iDAideUtilisateur = ligne(1)

        ligne = x.ReadLine.Split(";")
        iDAideUtilisateur2 = ligne(1)

        Dim reqMembre As New SqlCommand("Insert into MEMBRE (MCODESAISIE, MNUMPOINTAGE, MNUMAIDE, MNUMAIDEBIS) values (" & codeAInserer & ",'" & iDUtilisateur & "','" & iDAideUtilisateur & "','" & iDAideUtilisateur2 & "')", New SqlConnection(connS3SQL))
        reqMembre.CommandTimeout = 2

        Try
            reqMembre.Connection.Open()
            reqMembre.ExecuteNonQuery()
            reqMembre.Connection.Close()
        Catch ex As Exception
            reqMembre.Connection.Close()
        End Try

        'Parcours le fichier jusqu'à trouver la ligne des saisies'
        While x.Peek <> -1

            ligne = x.ReadLine.Split(";")

            If ligne(0).Equals("TypeMouvement") Then
                Dim quantiteRealisee As Integer = 0
                Dim abv As String = ""
                Dim noProd As String = ""
                Dim reqIO As SqlClient.SqlCommand
                Dim isBlocked As Integer
                Dim noLot As String = ""
                Dim noop As String = ""
                Dim online As Boolean

                'Insere toutes les lignes de saisies'
                While x.Peek <> -1
                    '0 -> false'
                    isBlocked = 0
                    ligne = x.ReadLine.Split(";")
                    'Récupération de l'abv et noprod au cas où pas récupéré avant..'
                    online = ligne(13)

                    If Not online Then

                        If ligne(2).Equals("") Then
                            If ligne(1).Equals("") Then
                                Dim separateValue() As String = ligne(5).Split("/")
                                '  Dim noop As String = ""
                                Dim noEtiq As String
                                Dim noof As String = ""

                                If ligne(5).Split("/").Length = 3 Then
                                    noop = separateValue(1)
                                    noEtiq = separateValue(2)
                                Else
                                    If ligne(5).StartsWith("G") Or ligne(5).StartsWith("A") Then
                                        getDetailEtiquetteGOPAL(ligne(5), noLot, noof, noop)
                                        getDetailsEtiquette(noLot, noProd)
                                    Else
                                        noop = separateValue(0)
                                        noEtiq = separateValue(1)
                                        getDetailsEtiquette(ligne(4), noop, noEtiq, noLot, noProd)
                                    End If
                                    getABVNomProd(noProd, abv, noof)
                                End If

                            Else
                                getDetailsEtiquette(ligne(1), noProd)
                                getABVNomProd(noProd, abv, ligne(4))
                            End If
                        Else
                            abv = ligne(3)
                            noProd = ligne(2)
                        End If
                        Try
                            'Si quantite realisee est vide, recupération'
                            If ligne(0).Equals(Sortie) And ligne(6).Equals("") Then
                                '    quantiteRealisee = getQuantiteDejaPresente(ligne(5))
                                '    quantiteRealisee = Convert.ToInt32(ligne(7)) - quantiteRealisee
                            ElseIf ligne(0).Equals(Sortie) And Not ligne(6).Equals("") Then
                                'Si c'est une sortie avec la quantiteRealisee déjà calculé, on la récupère directement du fichier'
                                quantiteRealisee = Convert.ToInt32(ligne(6))
                            End If
                        Catch ex As Exception
                            'En cas d'erreur avec la conversion'
                            Throw New Exception
                        End Try

                        'Dans le cas d'une entrée, on verifie qu'il y ait bien une sortie. Si oui OK, sinon, on crée une sortie par defaut, qui sera ensuite mise a jour'
                        'Dans le cas d'une sortie, verifier si l'id du contenant n'est pas déjà déclaré en sortie. si deja déclaré, mise a jour de la ligne'

                        '       Dim noopTmp As String = ""
                        Dim noofTmp As String = ""
                        If Not ligne(5).Split("/").Length = 3 Then
                            getDetailEtiquetteGOPAL(ligne(5), "", noofTmp, noop)
                        Else
                            noop = ligne(5).Split("/")(1)
                        End If


                        'Si il s'agit d'une entrée'
                        If ligne(0).Equals(Entree) Then
                            'Check si sortie présente'
                            If Not isOutputPresentForInput(ligne(5)) Then
                                If ligne(1) = "" Then
                                    reqIO = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values(" & codeAInserer & ", NULL, 'Sortie', '???','" & noLot & "','" & ligne(4) & "','" & ligne(5) & "','" & noProd & "','" & abv & "',NULL,NULL,NULL," & isBlocked & ", '', '', '', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                                Else
                                    reqIO = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values(" & codeAInserer & ", NULL, 'Sortie', '???','" & ligne(1) & "','" & ligne(4) & "','" & ligne(5) & "','" & noProd & "','" & abv & "',NULL,NULL,NULL," & isBlocked & ", '', '', '', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                                End If
                                reqIO.CommandTimeout = 2

                                'non présente, on en crée une par defaut'
                                Try
                                    reqIO.Connection.Open()
                                Catch ex As Exception
                                    reqIO.Connection.Close()
                                    Throw New Exception
                                End Try

                                reqIO.ExecuteNonQuery()
                                reqIO.Connection.Close()
                            End If

                            If ligne(1).Equals("") Then
                                reqIO = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values (" & codeAInserer & ",'" & iDUtilisateur & "','" & ligne(0) & "','" & ligne(8) & "','" & noLot & "','" & ligne(4) & "','" & ligne(5) & "','" & noProd & "','" & abv & "',NULL,NULL,'" & ligne(9) & "'," & isBlocked & ", '', '', '', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                            Else
                                reqIO = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values (" & codeAInserer & ",'" & iDUtilisateur & "','" & ligne(0) & "','" & ligne(8) & "','" & ligne(1) & "','" & ligne(4) & "','" & ligne(5) & "','" & noProd & "','" & abv & "',NULL,NULL,'" & ligne(9) & "'," & isBlocked & ", '', '', '', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                            End If

                            reqIO.CommandTimeout = 2
                            Try
                                reqIO.Connection.Open()
                            Catch ex As Exception 'Pb de connexion'
                                reqIO.Connection.Close()
                                Throw New Exception
                            End Try

                            Try
                                reqIO.ExecuteNonQuery()
                            Catch ex As Exception 'id container déjà présent'
                                'On ignore, passe à la suite'
                            End Try
                        Else 'Alors d'une sortie'
                            If ligne(1).Equals("") Then
                                reqIO = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values (" & codeAInserer & ",'" & iDUtilisateur & "','" & ligne(0) & "','" & ligne(8) & "','" & noLot & "','" & ligne(4) & "','" & ligne(5) & "','" & noProd & "','" & abv & "','" & quantiteRealisee & "','" & ligne(7) & "','" & ligne(9) & "'," & isBlocked & ",'" & ligne(10) & "','" & ligne(11) & "','" & ligne(12) & "', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                            Else
                                reqIO = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values (" & codeAInserer & ",'" & iDUtilisateur & "','" & ligne(0) & "','" & ligne(8) & "','" & ligne(1) & "','" & ligne(4) & "','" & ligne(5) & "','" & noProd & "','" & abv & "','" & quantiteRealisee & "','" & ligne(7) & "','" & ligne(9) & "'," & isBlocked & ",'" & ligne(10) & "','" & ligne(11) & "','" & ligne(12) & "', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                            End If

                            reqIO.CommandTimeout = 2

                            Try
                                reqIO.Connection.Open()
                            Catch ex As Exception 'Pb de connexion'
                                reqIO.Connection.Close()
                                Throw New Exception
                            End Try

                            Try
                                reqIO.ExecuteNonQuery()
                            Catch ex As Exception 'id container déjà présent
                                Debug.WriteLine(ex.StackTrace)

                                If Not isIOFullPresentInDB(ligne(5), Sortie) Then
                                    'Modification de la ligne: numero de pointage, quantite...'
                                    updateOutputInDB(codeAInserer, iDUtilisateur, ligne(8), ligne(5), quantiteRealisee, ligne(7), ligne(9), ligne(10), ligne(11), ligne(12))
                                End If
                            End Try
                        End If

                        reqIO.Connection.Close()

                    End If

                    qteProdTmp.addEtiq((ligne(4) & "/" & noop & "/" & ligne(8)), ligne(5))

                End While
                Exit While 'Quitte l'insertion de la saisie'
            End If
        End While

        x.Close()
    End Sub

    ''' <summary>
    ''' Fonction remontant en BDD les données du fichier des déclarations
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub uploadDataDeclaration()

        'Insertion des données de déclaration dans la base de données'
        Dim ligne() As String
        Dim res() As String
        Dim x As System.IO.StreamReader
        x = New System.IO.StreamReader(pathToDeclarations)

        While x.Peek <> -1

            ligne = x.ReadLine().Split(";")
            'Si la ligne contient numMachine, il y donc des données de temps d'arret'
            If ligne(0).Equals("NumMachine") Then
                Dim numLigne As Integer = 1

                'Boucle afin de récupérer toutes les données des temps d'arrêt'
                While x.Peek <> -1
                    ligne = x.ReadLine().Split(";")
                    'Quitte la boucle de lecture des temps d'arrêt'
                    If ligne(0).Equals("Quantité Fin de Poste") Then
                        Exit While
                    End If

                    Dim reqTpsArret As SqlCommand
                    If ligne(3) = "NULL" Then
                        reqTpsArret = New SqlCommand("INSERT INTO TEMPS_NP1 (TNPCODESAISIE, TNPNUMPOINTAGE, TNPNUMLIGNE, TNPNUMMACH, TNPCODEARRET, TNPNBHEURE, TNPNUMOF, TNPNUMOP) VALUES(" & codeAInserer & "," & iDUtilisateur & "," & numLigne & ", '" & ligne(0) & "','" & ligne(1) & "'," & ligne(2) & ", NULL,NULL)", New SqlConnection(connS3SQL))
                    Else
                        reqTpsArret = New SqlCommand("INSERT INTO TEMPS_NP1 (TNPCODESAISIE, TNPNUMPOINTAGE, TNPNUMLIGNE, TNPNUMMACH, TNPCODEARRET, TNPNBHEURE, TNPNUMOF, TNPNUMOP) VALUES(" & codeAInserer & "," & iDUtilisateur & "," & numLigne & ", '" & ligne(0) & "','" & ligne(1) & "'," & ligne(2) & ", '" & ligne(3) & "', '" & ligne(4) & "')", New SqlConnection(connS3SQL))
                    End If
                    reqTpsArret.CommandTimeout = 2

                    Try
                        reqTpsArret.Connection.Open()
                        reqTpsArret.ExecuteNonQuery()
                        reqTpsArret.Connection.Close()
                    Catch ex As Exception
                        reqTpsArret.Connection.Close()
                    End Try

                    numLigne += 1
                End While
            End If

            'En-tête obligatoire si des contenants non terminés sont présents'
            If ligne(0).Equals("ID") Or ligne(0).Equals("Noof") Then
                'Si la ligne contient quantite, associé avec noetiq, il s'agit donc des contenants non terminés, et il y a donc des données'
                If ligne(1).Equals("Noop") Then
                    If ligne(2).Equals("NoProd") Then
                        'Boucle afin de récupérer toutes les données des contenants non finis'
                        While x.Peek <> -1
                            ligne = x.ReadLine().Split(";")
                            'Quitte la boucle de lecture des temps d'arrêt'
                            If ligne(0).Equals("Rebuts / retouches") Then
                                Exit While
                            End If

                            If horsligne Then
                                If ligne(1) = "" Then
                                    getDetailEtiquetteGOPAL(ligne(5), "", ligne(0), ligne(1))
                                End If
                                qteProdTmp.addQteFinPosteActuel(ligne(0), ligne(1), ligne(3), ligne(4), ligne(5))
                            End If

                        End While
                    End If
                    'Si la ligne contient code, associé à ID, il s'agit donc de la déclaration de rebuts et retouches'
                ElseIf ligne(1).Equals("Code") Then

                    Dim reqREB_RET As SqlCommand

                    If secteurSession.Equals(CodeControleCU) Then 'Si c'etait une session avec du temps reel ou non, il y aura peut-etre des mises a jour de lignes à faire'

                        While x.Peek <> -1
                            reqREB_RET = New SqlCommand("Select RRCODESAISIE from REB_RET where RRCODESAISIE = " & codeAInserer & " and RRNUMPOINTAGE = " & iDUtilisateur & " and RRID = '" & ligne(0) & "' and RRCODEDEF = '" & ligne(1) & "' and RRNUMMACH = '" & ligne(3) & "'", New SqlConnection(connS3SQL))

                            reqREB_RET.CommandTimeout = 2
                            res = x.ReadLine().Split(";")
                            Try
                                reqREB_RET.Connection.Open()

                                Dim data = reqREB_RET.ExecuteReader()

                                If data.Read Then 'Il y a deja une ligne pour cette utilisateur, on va la mettre à jour'
                                    Debug.WriteLine("Data :" & data.Item(4))
                                    Debug.WriteLine("Row :" & ligne(2))
                                    Dim update As New SqlCommand("Update REB_RET set RRNBPIECESECART = " & data.Item(4) + Convert.ToInt32(ligne(2)) & " where RRCODESAISIE = " & codeAInserer & " and RRNUMPOINTAGE = " & iDUtilisateur & " and RRID = '" & res(0) & "' and RRCODEDEF = '" & res(1) & "' and RRNUMMACH = '" & res(3) & "'", New SqlConnection(connS3SQL))

                                    update.CommandTimeout = 2
                                    Try
                                        update.Connection.Open()
                                        update.ExecuteNonQuery()
                                        update.Connection.Close()
                                    Catch ex As Exception
                                        update.Connection.Close()
                                    End Try

                                Else 'Aucune ligne trouvée, on insert simplement'

                                    Dim lecture As Boolean = False

                                    Debug.WriteLine("!!!!!!  " & codeAInserer)

                                    Dim reqSelect As New SqlCommand("select 1 from reb_ret where rrcodesaisie = " & codeAInserer & " and rrid = '" & res(0) & "' and rrcodedef = '" & res(1) & "' and rrnummach = '" & res(3) & "'", New SqlConnection(connS3SQL))
                                    Try
                                        reqSelect.Connection.Open()
                                        If reqSelect.ExecuteReader.Read() Then
                                            lecture = True
                                        End If
                                        reqSelect.Connection.Close()
                                    Catch ex As Exception
                                        MsgBox(ex.ToString)
                                        reqSelect.Connection.Close()
                                    End Try

                                    If Not lecture Then
                                        Dim insert As New SqlCommand("Insert into REB_RET (RRCODESAISIE, RRNUMPOINTAGE, RRID, RRCODEDEF, RRNBPIECESECART, RRNUMMACH) values (" & codeAInserer & ", " & iDUtilisateur & ", '" & res(0) & "', '" & res(1) & "', " & res(2) & ", '" & res(3) & "')", New SqlConnection(connS3SQL))
                                        insert.CommandTimeout = 2
                                        Try
                                            insert.Connection.Open()
                                            insert.ExecuteNonQuery()
                                            insert.Connection.Close()
                                        Catch ex As Exception
                                            MsgBox(ex.ToString)
                                            insert.Connection.Close()
                                        End Try
                                    End If
                                End If
                                reqREB_RET.Connection.Close()
                            Catch ex As Exception
                                reqREB_RET.Connection.Close()
                            End Try
                        End While
                    Else
                        'Boucle afin de récupérer toutes les données des rebuts'
                        While x.Peek <> -1

                            ligne = x.ReadLine().Split(";")

                            reqREB_RET = New SqlCommand("INSERT INTO REB_RET (RRCODESAISIE, RRNUMPOINTAGE, RRID, RRCODEDEF, RRNBPIECESECART, RRNUMMACH) VALUES(" & codeAInserer & ",'" & iDUtilisateur & "','" & ligne(0) & "','" & ligne(1) & "'," & ligne(2) & ",'" & ligne(3) & "')", New SqlConnection(connS3SQL))
                            reqREB_RET.CommandTimeout = 2
                            Try
                                reqREB_RET.Connection.Open()
                            Catch ex As Exception
                                reqREB_RET.Connection.Close()
                                Throw New Exception
                            End Try

                            Try
                                reqREB_RET.ExecuteNonQuery()
                            Catch ex As Exception
                                'Ligne deja présente, evite de crash si il y a eu coupure de connexion et evite les doublons'
                            End Try

                            reqREB_RET.Connection.Close()

                        End While
                    End If
                End If
            End If
        End While

        Debug.WriteLine("upload data declaration code saisie : " & codeSaisieActu)

        If horsligne Then
            For Each key In qteProdTmp.getListAllProd
                If key.Split("/")(1) = "" Then
                    getDetailEtiquetteGOPAL(qteProdTmp.getItemFromDicoEtiq(key)(0), "", "", key.Split("/")(1))
                End If
                qteProdTmp.getFinPostePrec(key.Split("/")(0), key.Split("/")(1), key.Split("/")(2))
            Next

            If Not codeTmp = 0 Then
                codeSaisieActu = codeTmp
            End If

            If codeSaisieActu = 0 Then
                If Not codeTmp = 0 Then
                    codeSaisieActu = codeTmp
                End If
            End If

            qteProdTmp.miseAJourFinPoste()
        End If

        x.Close()

    End Sub

    ''' <summary>
    ''' Fonction qui permet de récupérer les temps de production d'un utilisateur
    ''' </summary>
    ''' <param name="rows"></param>
    ''' <param name="dossier"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function uploadDataTempsProd(ByRef rows As ArrayList, Optional ByVal dossier As String = "") As Integer
        Dim ligne() As String
        Dim nbRow As Integer = 0

        If dossier = "" Then
            dossier = CheminSaisieProd & myUser.getPointage
        End If

        pathDirectory = IO.Directory.GetDirectories(dossier)(0)

        If isSessionIntegrityOK() Then
            pathToTempsProduction = pathDirectory & "\TempsProduction.xls"
            Dim x As System.IO.StreamReader
            x = New System.IO.StreamReader(pathToTempsProduction)

            ligne = x.ReadLine.Split(";")
            iDUtilisateur = ligne(1)

            While x.Peek <> -1

                ligne = x.ReadLine.Split(";")

                If ligne(0) = "Machine" Then
                    While x.Peek <> -1
                        Dim row(6) As String
                        ligne = x.ReadLine.Split(";")
                        row(0) = ligne(0)
                        row(1) = ligne(1)
                        row(2) = ligne(2)
                        row(3) = ligne(3)
                        row(4) = ligne(4)
                        row(5) = ligne(5)
                        rows.Add(row)
                        nbRow += 1
                    End While
                End If
            End While

            x.Close()
        End If

        Return nbRow
    End Function

    ''' <summary>
    ''' Permet de créer la ligne correspondant à la session en temps reel grace au WiFi, et va permettre d'insérer les IO grâce au numero que cela retourne
    ''' </summary>
    ''' <param name="sectActu"></param>
    ''' <param name="posteActu"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function insertSessionSaisie(ByVal sectActu As String, ByVal posteActu As String) As Integer
        Dim codeInsert = getNewNumFiche()

        If sectActu.Contains(CodeControle) Then
            sectActu = CodeControle
        End If

        Dim nomDossier = myUser.getPathFile.Split("\")(4)
        Dim dateToInsert = Date.ParseExact(nomDossier.Split("_")(1), "yyyyMMdd-HHmmss", Nothing)

        'Insertion de la nouvelle session en BDD'
        Dim reqSessionSaisie As New SqlCommand("Insert into SESSION_SAISIE (SECODESAISIE, SESECTEUR, SEPOSTE, SEDATECREATION, SEDATEUPLOAD, SEUPLOADOK) values (" & codeInsert & ",'" & sectActu & "','" & posteActu & "','" & dateToInsert & "','" & Date.Now & "',0)", New SqlConnection(connS3SQL))
        reqSessionSaisie.CommandTimeout = 2

        Try
            reqSessionSaisie.Connection.Open()
        Catch ex As Exception
            reqSessionSaisie.Connection.Close()
            Return Nothing
        End Try

        reqSessionSaisie.ExecuteNonQuery()
        reqSessionSaisie.Connection.Close()

        Return codeInsert
    End Function

    ''' <summary>
    ''' Fonction appelée a chaque fois que l'utilisateur effectue une entrée/sortie, afin de rentrer directement en bdd la saisie (Temps reel)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub insertAllIO()
        Dim reqIOToDB As SqlCommand
        Dim abv As String = ""
        Dim noProd As String = ""
        Dim isBlocked As Integer
        Dim machine As String = ""
        Dim noof As String = ""
        Dim noEtiq As String = ""

        For Each row As DataRow In myUser.getDTIO.Rows
            '0 -> false'
            isBlocked = 0

            'Verifier si l'abv et le noprod ont bien été récupéré'
            If row(2).ToString.Equals("") Then
                getDetailsEtiquette(row(1), noProd)
                getABVNomProd(noProd, abv, row(4))
                row(2) = noProd
                row(3) = abv
            End If

            Dim noop As String = ""

            If Not row(5).ToString.Split("/").Length = 3 Then
                getDetailEtiquetteGOPAL(row(5).ToString, "", noof, noop)
            Else
                noop = row(5).ToString.Split("/")(1)
            End If

            'Si il s'agit d'une entrée'
            If row(0).Equals("Entree") Then
                'Check si sortie présente'
                If Not isOutputPresentForInput(row(5).ToString) Then
                    'non présente, on en crée une par defaut'

                    reqIOToDB = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values(" & codeSaisieActu & ", NULL, 'Sortie', '???','" & row(1).ToString & "','" & row(4).ToString & "','" & row(5).ToString & "','" & row(2).ToString & "','" & row(3).ToString & "',NULL,NULL,NULL," & isBlocked & ", '', '', '', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                    reqIOToDB.CommandTimeout = 2

                    Try
                        reqIOToDB.Connection.Open()

                        reqIOToDB.ExecuteNonQuery()
                        reqIOToDB.Connection.Close()
                    Catch ex As Exception
                        reqIOToDB.Connection.Close()
                        Throw New Exception
                    End Try

                End If

                reqIOToDB = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values (" & codeSaisieActu & ",'" & myUser.getPointage & "','" & row(0) & "','" & row(8) & "','" & row(1) & "','" & row(4) & "','" & row(5) & "','" & row(2) & "','" & row(3) & "',NULL,NULL,'" & row(9) & "'," & isBlocked & ", '', '', '', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                reqIOToDB.CommandTimeout = 2

                Try
                    reqIOToDB.Connection.Open()
                    reqIOToDB.ExecuteNonQuery()
                    reqIOToDB.Connection.Close()
                Catch ex As Exception
                    reqIOToDB.Connection.Close()
                    Throw New Exception
                End Try

                'row.Delete() 'Soit suppression du doublon de la DT sans l'insérer en BD, soit l'insertion s'est bien déroulée et suppression de la ligne
            Else 'Alors d'une sortie'
                Try
                    'Si quantite realisee est vide, recupération'
                    If row(6).Equals("") Then
                        'row(6) = getQuantiteDejaPresente(row(5).ToString)
                        row(6) = Convert.ToInt32(row(7).ToString) ' - row(6)
                        myUser.miseAJourSaisie()
                    End If
                Catch ex As Exception
                    'En cas d'erreur avec la conversion'
                    Throw New Exception
                End Try

                reqIOToDB = New SqlCommand("Insert into IO (IOCODESAISIE, IONUMPOINTAGE, IOTYPE, IONUMMACH, IONUMLOT, IONUMOF, IONUMETIQ, IONOPROD, IOABVNOMPROD, IOQUANTITEREALISE, IOQUANTITETOTALE, IODATESCAN, IOBLOCKED, IONUMCHARGE, IONUMMATRICE, IONUMVAGUE, IONUMOP, IOPDCSUIVANT) values (" & codeSaisieActu & ",'" & myUser.getPointage & "','" & row(0) & "','" & row(8) & "','" & row(1) & "','" & row(4) & "','" & row(5) & "','" & row(2) & "','" & row(3) & "','" & row(6) & "','" & row(7) & "','" & row(9) & "'," & isBlocked & ", '" & row(10) & "', '" & row(11) & "', '" & row(12) & "', '" & noop & "', NULL)", New SqlConnection(connS3SQL))
                reqIOToDB.CommandTimeout = 2

                Try
                    reqIOToDB.Connection.Open()
                    reqIOToDB.ExecuteNonQuery()
                    reqIOToDB.Connection.Close()
                Catch ex As Exception 'bug connexion'
                    reqIOToDB.Connection.Close()
                    If Not isIOFullPresentInDB(row(5), "Sortie") Then
                        'Modification de la ligne: numero de pointage, quantite...'
                        updateOutputInDB(codeSaisieActu, myUser.getPointage, row(8).ToString, row(5).ToString, row(6).ToString, row(7).ToString, row(9).ToString, row(10).ToString, row(11).ToString, row(12).ToString)
                    End If
                End Try

                'row.Delete()

                noof = row(4)
                noEtiq = row(5)
                machine = row(8)
            End If

            reqIOToDB.Connection.Close()
        Next

        myUser.updateIO(noof, machine, noEtiq)
        ' myUser.getDTIO.Clear()
        myUser.miseAJourSaisie()
    End Sub

    ''' <summary>
    ''' Fonction permettant de remonter le contenu de la DT des rebuts en base de donnés
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub insertAllRebuts()

        Dim reqRRToDB As SqlCommand

        For Each row As DataRow In myUser.getDTRebutsTR.Rows

            reqRRToDB = New SqlCommand("Select * from REB_RET where RRCODESAISIE = " & codeSaisieActu & " and RRNUMPOINTAGE = " & myUser.getPointage & " and RRID = '" & row.Item(0) & "' and RRCODEDEF = '" & row.Item(1) & "' and RRNUMMACH= '" & row.Item(3) & "'", New SqlConnection(connS3SQL))
            reqRRToDB.CommandTimeout = 2


            reqRRToDB.Connection.Open()

            Dim data = reqRRToDB.ExecuteReader()

            If data.Read Then 'Il y a deja une ligne pour cette utilisateur, on va la mettre à jour data.Item(4) + '
                If (row.Item(2).ToString = data.Item(4).ToString) Then

                Else
                    Debug.WriteLine("Update : ")
                    Debug.WriteLine("Row : " & row.Item(2))
                    Debug.WriteLine("Data : " & data.Item(4))
                    Dim update As New SqlCommand("Update REB_RET set RRNBPIECESECART = " & row.Item(2) & " where RRCODESAISIE = " & codeSaisieActu & " and RRNUMPOINTAGE = " & myUser.getPointage & " and RRID = '" & row.Item(0) & "' and RRCODEDEF = '" & row.Item(1) & "' and RRNUMMACH = '" & row.Item(3) & "'", New SqlConnection(connS3SQL))
                    update.CommandTimeout = 2

                    update.Connection.Open()
                    update.ExecuteNonQuery()
                    update.Connection.Close()
                End If

            Else 'Aucune ligne trouvée, on insert simplement'
                Debug.WriteLine("Insert : ")
                Debug.WriteLine("Row : " & row.Item(2))

                Dim insert As New SqlCommand("Insert into REB_RET (RRCODESAISIE, RRNUMPOINTAGE, RRID, RRCODEDEF, RRNBPIECESECART, RRNUMMACH) values (" & codeSaisieActu & ", " & myUser.getPointage & ", '" & row.Item(0) & "', '" & row.Item(1) & "', " & row.Item(2) & ",'" & row.Item(3) & "')", New SqlConnection(connS3SQL))
                insert.CommandTimeout = 2

                insert.Connection.Open()
                insert.ExecuteNonQuery()
                insert.Connection.Close()
            End If

                reqRRToDB.Connection.Close()
        Next

        '      myUser.getDTRebutsTR.Clear()
        myUser.miseAJourDeclaration()

    End Sub

    ''' <summary>
    ''' Fonction qui insère tous les temps de production d'un utilisateur
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub insertAllTempsProduction(ByVal dossier As String)
        Dim ligne() As String
        Dim rows As New ArrayList
        Dim nbRow As Integer
        Dim x As System.IO.StreamReader
        x = New System.IO.StreamReader(pathToTempsProduction)

        ligne = x.ReadLine.Split(";")
        Dim pointageUser = ligne(1)
        x.Close()
        nbRow = uploadDataTempsProd(rows, dossier)

        Dim reqCode As New SqlCommand("SELECT MAX(MCODESAISIE) FROM MEMBRE WHERE MNUMPOINTAGE = '" & pointageUser & "'", New SqlConnection(connS3SQL))
        reqCode.CommandTimeout = 2

        Try
            reqCode.Connection.Open()
            Dim result = reqCode.ExecuteReader()
            If result.Read Then
                codeAInserer = result(0)
            End If
            reqCode.Connection.Close()
        Catch ex As Exception
            reqCode.Connection.Close()
        End Try

        For index As Integer = 1 To nbRow
            Dim row(6) As String
            Dim req As SqlCommand
            row = rows(index - 1)

            ' entre dans le if si il y a eu un arret brutal du programme par defaut on met le nombre d'heure de travail dans la journée
            If row(4) = 0 Then
                row(4) = 8
            End If

            If row(3) = "" Then
                Dim noProd As String
                noProd = ""
                getDetailEtiquetteNumProduit(row(1), noProd)

                req = New SqlCommand("INSERT INTO HEURE_PRODUCTION (HPCODESAISIE, HPNUMPOINTAGE, HPNUMOF, HPNUMOP, HPMACHINE, HPNUMPROD, HPNBHEURE, HPRECUPOK) values(" & codeAInserer & "," & pointageUser & ",'" & row(1) & "','" & row(2) & "','" & row(0) & "','" & noProd & "'," & row(4) & ", " & row(5) & ")", New SqlConnection(connS3SQL))
            Else    '                                                                                                   numero of       numero op        numero machine    numero prod     nb d'heure
                req = New SqlCommand("INSERT INTO HEURE_PRODUCTION (HPCODESAISIE, HPNUMPOINTAGE, HPNUMOF, HPNUMOP, HPMACHINE, HPNUMPROD, HPNBHEURE, HPRECUPOK) values(" & codeAInserer & "," & pointageUser & ",'" & row(1) & "','" & row(2) & "','" & row(0) & "','" & row(3) & "'," & row(4) & ", " & row(5) & ")", New SqlConnection(connS3SQL))

            End If
            req.CommandTimeout = 2
            Try
                req.Connection.Open()
                req.ExecuteNonQuery()
                req.Connection.Close()
            Catch ex As Exception
                req.Connection.Close()
            End Try
        Next
    End Sub

    ''' <summary>
    ''' Fonction qui permet de vérifier si le secteur est présent dans le fichier init
    ''' </summary>
    ''' <param name="secteurDossier"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValidateSecteur(ByVal secteurDossier As String) As Boolean
        Return (secteurDossier.Equals(CodeDebitage) Or secteurDossier.Equals(CodeInstall) Or secteurDossier.Equals(CodePresse300) Or secteurDossier.Equals(CodePresse390) Or secteurDossier.Equals(CodeUsinageA) Or secteurDossier.Equals(CodeUsinageM) Or secteurDossier.Equals(CodeControleCU) Or secteurDossier.Equals(CodeControleCV) Or secteurDossier.Equals(CodePresse500) Or secteurDossier.Equals(CodeControleG) Or secteurDossier.Equals(CodeInstallG) Or secteurDossier.Equals(CodePresseG) Or secteurDossier.Equals(CodeUsinageG))
    End Function

    ''' <summary>
    ''' Fonction verifiant que les sous-dossiers et le contenu des fichiers sont correctement labellés
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isSessionIntegrityOK() As Boolean
        Dim nomDossier As String = pathDirectory.Split("\")(4)
        Dim secteurDossier As String
        Dim dateDossier As Date

        'On verifie l'integrité des dossiers/fichiers contenu dans la variable pathDirectory'
        'Format du nom du dossier et secteur existant'
        Try
            secteurDossier = nomDossier.Split("_")(0)
            dateDossier = DateTime.ParseExact(nomDossier.Split("_")(1), "yyyyMMdd-HHmmss", Nothing)

            If Not isValidateSecteur(secteurDossier) Then
                MsgBox("Le nom du secteur n'est pas présent dans le nom du dossier: " & pathDirectory & " !", MsgBoxStyle.Critical, "Erreur")
                Return False
            End If
        Catch 'Si un problème survient ici, c'est qu'il y a un problème avec le dossier'
            MsgBox("Problème de lecture du dossier " & pathDirectory & " ! Le nom n'est pas formaté correctement (Secteur_yyyyMMdd-HHmmss).", MsgBoxStyle.Critical, "Erreur")
            Return False
        End Try

        Return True
    End Function

    ''' <summary>
    ''' Fonction qui va permettre de mettre à jour une sortie qui est déjà présente en BDD, mise par defaut car sortie inexistante lors du scan de l'entrée'
    ''' </summary>
    ''' <param name="numEtiq">La partie détachable de l'étiquette de sortie</param>
    ''' <remarks></remarks>
    Private Sub updateOutputInDB(ByVal code As Integer, ByVal idUser As String, ByVal numMach As String, ByVal numEtiq As String, ByVal quantReal As String, ByVal quantTotale As String, ByVal dateScan As String, ByVal numCharge As String, ByVal numMatrice As String, ByVal numVague As String)
        'Met à jour les données de la sortie créée par défaut'
        Dim reqOutputUpdate As New SqlCommand("Update IO set IOCODESAISIE = " & code & ", IONUMPOINTAGE = " & idUser & ", IONUMMACH = '" & numMach & "', IOQUANTITEREALISE = " & quantReal & ", IOQUANTITETOTALE = " & quantTotale & ", IODATESCAN = '" & dateScan & "', IONUMCHARGE = '" & numCharge & "', IONUMMATRICE = '" & numMatrice & "', IONUMVAGUE = '" & numVague & "' where IOTYPE = 'Sortie' and IONUMETIQ = '" & numEtiq & "'", New SqlConnection(connS3SQL))
        reqOutputUpdate.CommandTimeout = 2
        Try
            reqOutputUpdate.Connection.Open()
            reqOutputUpdate.ExecuteNonQuery()
            reqOutputUpdate.Connection.Close()
        Catch ex As Exception
            reqOutputUpdate.Connection.Close()
        End Try
    End Sub

    ''' <summary>
    ''' Fonction qui verifie qu'une sortie est présente pour un container en entrée
    ''' </summary>
    ''' <param name="numEtiquette">La partie détachable de l'étiquette d'entrée</param>
    ''' <returns>Renvoie true si le numero d'étiquette est présent en sortie</returns>
    ''' <remarks></remarks>
    Private Function isOutputPresentForInput(ByVal numEtiquette As String) As Boolean
        'Verifie la présence de la sortie pour l'id du container en entrée'
        Dim reqIOOutput As New SqlCommand("Select IOCODESAISIE from IO where IOTYPE = 'Sortie' and IONUMETIQ = '" & numEtiquette & "'", New SqlConnection(connS3SQL))
        reqIOOutput.CommandTimeout = 2

        Try
            reqIOOutput.Connection.Open()
            Dim result = reqIOOutput.ExecuteReader
            If result.Read Then
                reqIOOutput.Connection.Close()
                Return True
            Else
                reqIOOutput.Connection.Close()
                Return False
            End If

        Catch ex As Exception
            reqIOOutput.Connection.Close()
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Fonction qui verifie si un numero d'etiquette est présent en BDD dans la table IO
    ''' </summary>
    ''' <param name="numEtiquette"></param>
    ''' <param name="typeIO"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isIOFullPresentInDB(ByVal numEtiquette As String, ByVal typeIO As String) As Boolean
        'Verifie la présence de la sortie pour l'id du container en entrée'
        Dim reqIOOutput As New SqlCommand("Select IOCODESAISIE from IO where IOTYPE = '" & typeIO & "' and IONUMETIQ = '" & numEtiquette & "' and IONUMPOINTAGE IS NOT NULL", New SqlConnection(connS3SQL))
        reqIOOutput.CommandTimeout = 2
        Try
            reqIOOutput.Connection.Open()
            Dim result = reqIOOutput.ExecuteReader
            If result.Read Then
                reqIOOutput.Connection.Close()
                Return True
            Else
                reqIOOutput.Connection.Close()
                Return False
            End If

        Catch ex As Exception
            reqIOOutput.Connection.Close()
            Return False
        End Try
    End Function

#Region "BLOCAGE DES IO"

    ''' <summary>
    ''' Fonction qui permet de passer les IO pour un numéro d'étiquette comme bloqué
    ''' </summary>
    ''' <param name="numEtiq"></param>
    ''' <remarks></remarks>
    Private Sub updateIOToBlocked(ByVal numEtiq As String)

        'Met à jour les données de la sortie créée par défaut'
        Dim reqIOBlocked As New SqlCommand("Update IO set IOBLOCKED = 1 where IONUMETIQ = '" & numEtiq & "'", New SqlConnection(connS3SQL))
        reqIOBlocked.CommandTimeout = 2

        Try
            reqIOBlocked.Connection.Open()
        Catch ex As Exception
            reqIOBlocked.Connection.Close()
            Throw New Exception
        End Try

        reqIOBlocked.ExecuteNonQuery()
        reqIOBlocked.Connection.Close()

    End Sub

    ''' <summary>
    ''' Fonction permettant de verifier en bdd si un contenant est bloqué
    ''' </summary>
    ''' <param name="numEtiquette"></param>
    ''' <returns>0 is false, 1 is true</returns>
    ''' <remarks></remarks>
    Public Function isNoetiqBlocked(ByVal numEtiquette As String) As Integer

        Dim reqCTBloque As New SqlCommand("select * from CONTENANT_BLOQUE where CBNOETIQ = '" & numEtiquette & "'", New SqlConnection(connS3SQL))
        reqCTBloque.CommandTimeout = 2

        Try
            reqCTBloque.Connection.Open()
        Catch ex As Exception
            reqCTBloque.Connection.Close()
            Throw New Exception
        End Try

        Dim data = reqCTBloque.ExecuteReader

        If data.Read Then
            reqCTBloque.Connection.Close()
            Return 1
        Else
            reqCTBloque.Connection.Close()
            Return 0
        End If

    End Function

    ''' <summary>
    ''' Fonction permettant de remonter directement en bdd le contenue de la table DTContenantBloque'
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub insertAllCTBlocked()

        Dim reqDTBloque As SqlCommand
        Dim CTWasNotBlocked As Boolean = True

        For Each row As DataRow In myUser.getDTContenantBloque.Rows

            reqDTBloque = New SqlCommand("Insert into CONTENANT_BLOQUE values('" & row(1) & "')", New SqlConnection(connS3SQL))
            reqDTBloque.CommandTimeout = 2
            Try
                reqDTBloque.Connection.Open()
            Catch ex As Exception 'Connexion non fonctionnelle'
                reqDTBloque.Connection.Close()
                Throw New Exception
            End Try

            Try
                reqDTBloque.ExecuteNonQuery()
            Catch ex As Exception
                'Container déjà bloqué'
                CTWasNotBlocked = False
            End Try

            If CTWasNotBlocked Then
                Try
                    updateIOToBlocked(row(0))
                Catch ex As Exception
                    reqDTBloque.Connection.Close()
                    Throw New Exception
                End Try
            End If

            reqDTBloque.Connection.Close()
            row.Delete()
            CTWasNotBlocked = True

        Next

    End Sub

#End Region

End Class
