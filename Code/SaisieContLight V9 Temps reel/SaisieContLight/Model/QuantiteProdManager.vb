Public Class QuantiteProdManager

    Private listAllProd As List(Of String)

    Private dicoProd As Dictionary(Of String, Integer)

    Private dicoSessionPrec As Dictionary(Of String, Integer)
    Private dicoQteFinPostePrec As Dictionary(Of String, Integer)
    Private dicoQteFinPosteActuel As Dictionary(Of String, Integer)
    Private dicoEtiq As Dictionary(Of String, List(Of String))
    Private dicoEtiqFinPosteActuel As Dictionary(Of String, String)
    Private dicoEtiqFinPostePrec As Dictionary(Of String, String)


    Public Sub New()
        dicoProd = New Dictionary(Of String, Integer)
        dicoQteFinPosteActuel = New Dictionary(Of String, Integer)
        dicoQteFinPostePrec = New Dictionary(Of String, Integer)
        dicoSessionPrec = New Dictionary(Of String, Integer)
        dicoEtiq = New Dictionary(Of String, List(Of String))
        dicoEtiqFinPosteActuel = New Dictionary(Of String, String)
        dicoEtiqFinPostePrec = New Dictionary(Of String, String)

        listAllProd = New List(Of String)
    End Sub

    Public Sub addProd(ByVal noof As String, ByVal noop As String, ByVal quantite As Integer, ByVal machine As String, ByVal noEtiq As String)
        Dim key As String = noof & "/" & noop & "/" & machine
        If dicoProd.ContainsKey(key) Then
            dicoProd.Item(key) += quantite
        Else
            dicoProd.Add(key, quantite)
        End If

        addEtiq(key, noEtiq)
        addAllProd(key)
    End Sub

    Public Sub removeQte(ByVal noof As String, ByVal noop As String, ByVal qte As Integer, ByVal machine As String)
        Dim key As String = noof & "/" & noop & "/" & machine
        For Each element In dicoProd.Keys
            If element.Split("/")(0) = noof Then
                dicoProd.Item(element) -= qte
                If dicoProd.Item(element) = 0 Then
                    dicoProd.Remove(element)
                    Exit For
                End If
                Exit For
            End If
        Next
    End Sub

    Private Sub addQteFinPostePrec(ByVal noof As String, ByVal noop As String, ByVal quantite As Integer, ByVal machine As String, ByVal noetiq As String)
        Dim key As String = noof & "/" & noop & "/" & machine
        If Not dicoQteFinPostePrec.ContainsKey(key) Then
            dicoQteFinPostePrec.Add(key, quantite)
            dicoEtiqFinPostePrec.Add(key, noetiq)
        End If
    End Sub

    Public Sub addQteFinPosteActuel(ByVal noof As String, ByVal noop As String, ByVal quantite As Integer, ByVal machine As String, ByVal noEtiq As String)
        Dim key As String = noof & "/" & noop & "/" & machine
        If Not dicoQteFinPosteActuel.ContainsKey(key) Then
            dicoQteFinPosteActuel.Add(key, quantite)
            dicoEtiqFinPosteActuel.Add(key, noetiq)
        End If

        addAllProd(key)
    End Sub

    Private Sub addSessionPrec(ByVal noof As String, ByVal noop As String, ByVal session As Integer, ByVal machine As String)
        Dim key As String = noof & "/" & noop & "/" & machine
        If Not dicoSessionPrec.ContainsKey(key) Then
            dicoSessionPrec.Add(key, session)
        End If
    End Sub

    Public Sub removeQteFinPosteActuel(ByVal noof As String, ByVal noop As String, ByVal machine As String)
        Dim key As String = noof & "/" & noop & "/" & machine
        If dicoQteFinPosteActuel.ContainsKey(key) Then
            dicoQteFinPosteActuel.Remove(key)
            dicoEtiqFinPosteActuel.Remove(key)
        End If
    End Sub

    Private Sub addAllProd(ByVal prod As String)
        If Not listAllProd.Contains(prod) Then
            listAllProd.Add(prod)
        End If
    End Sub

    Public Sub addEtiq(ByVal key As String, ByVal noEtiq As String)
        If Not dicoEtiq.ContainsKey(key) Then
            Dim list As New List(Of String)
            list.Add(noEtiq)
            dicoEtiq.Item(key) = list
        Else
            If Not dicoEtiq.Item(key).Contains(noEtiq) Then
                dicoEtiq.Item(key).Add(noEtiq)
            End If
        End If
    End Sub

    Public Function getFinPostePrec(ByVal noof As String, ByVal noop As String, ByVal machine As String) As Boolean
        Dim req As New SqlCommand("select qfquantite, qfcodesaisie, qfnoprod, qfnoetiq from quantite_fin_poste where qfcodesaisie in (select max(qfcodesaisie) from quantite_fin_poste where qfnumof= " & noof & " and qfnumop='" & noop & "' and qfmachine = '" & machine & "') and qfnumof=" & noof & " and qfnumop='" & noop & "' and qfmachine='" & machine & "' and qftraite = 0", New SqlConnection(connS3SQL))

        Dim qte As Integer = 0

        req.CommandTimeout = 2

        Try
            req.Connection.Open()
            Dim lec = req.ExecuteReader
            If lec.Read Then
                qte = lec.GetInt32(0)

                If qte >= 0 Then
                    If compareEtiq(lec.GetString(3)) Then
                        addSessionPrec(noof, noop, lec.GetInt32(1), machine)
                        addQteFinPostePrec(noof, noop, qte, machine, lec.GetString(3))
                    End If
                End If

            End If
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try
    End Function

    Public Function miseAJourFinPoste() As Boolean
        Debug.WriteLine("count dico poste actuel: " & dicoQteFinPosteActuel.Keys.Count)
        For Each key In dicoQteFinPosteActuel.Keys
            Debug.WriteLine("key poste actuel: " & key)
            insertFinPoste(key.Split("/")(0), key.Split("/")(1), key.Split("/")(2), dicoQteFinPosteActuel.Item(key))
        Next

        For Each key In dicoSessionPrec.Keys
            updateFinPoste(dicoSessionPrec.Item(key), key.Split("/")(0), key.Split("/")(1), key.Split("/")(2))
        Next
    End Function

    Private Sub insertFinPoste(ByVal noof As String, ByVal noop As String, ByVal machine As String, ByVal quantite As Integer)
        Dim key = noof & "/" & noop & "/" & machine
        Dim noProd As String = ""
        Dim qteAvant As Integer = 0
        Dim sommeSortie As Integer = 0
        Dim noEtiq As String = ""

        If dicoQteFinPostePrec.ContainsKey(key) Then
            qteAvant = dicoQteFinPostePrec.Item(key)
        End If

        If dicoProd.ContainsKey(key) Then
            sommeSortie = dicoProd.Item(key)
        End If

        If dicoEtiqFinPosteActuel.ContainsKey(key) Then
            noEtiq = dicoEtiqFinPosteActuel.Item(key)
        End If

        Dim qteToInsert = quantite - (sommeSortie - qteAvant)

        getDetailEtiquetteNumProduit(noof, noProd)

        Debug.WriteLine("quantite a inserer: " & qteToInsert)
        Debug.WriteLine("prod: " & key)

        Debug.WriteLine("insert qte fin poste 1: " & codeSaisieActu)

        Dim req As New SqlCommand("insert into quantite_fin_poste (QFCODESAISIE, QFNUMOF, QFNOPROD, QFQUANTITE, QFMACHINE, QFNUMOP, QFTRAITE, QFQUANTITESAISIE, QFNOETIQ) values(" & codeSaisieActu & ", '" & noof & "', '" & noProd & "', " & qteToInsert & ", '" & machine & "', '" & noop & "', 0," & quantite & ", '" & noEtiq & "')", New SqlConnection(connS3SQL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim test = req.ExecuteNonQuery()
            Debug.WriteLine("qte fin poste ligne affectée: " & test)
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try

    End Sub

    Private Sub updateFinPoste(ByVal session As Integer, ByVal noof As String, ByVal noop As String, ByVal machine As String)
        Dim req As New SqlCommand("update quantite_fin_poste set qftraite = 1 where qfcodesaisie= '" & session & "' and qfnumof =" & noof & " and qfnumop='" & noop & "' and qfmachine='" & machine & "'", New SqlConnection(connS3SQL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            req.ExecuteNonQuery()
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try

        Dim key = noof & "/" & noop & "/" & machine
        Dim qteAvant As Integer = 0

        If dicoQteFinPostePrec.ContainsKey(key) Then
            qteAvant = dicoQteFinPostePrec.Item(key)
        End If

        If Not qteAvant = 0 Then
            Dim noProd As String = ""
            getDetailEtiquetteNumProduit(noof, noProd)

            Dim req2 As New SqlCommand("insert into quantite_fin_poste (QFCODESAISIE, QFNUMOF, QFNOPROD, QFQUANTITE, QFMACHINE, QFNUMOP, QFTRAITE, QFQUANTITESAISIE) values(" & codeSaisieActu & ", '" & noof & "', '" & noProd & "', " & (-qteAvant) & ", '" & machine & "', '" & noop & "', 1, NULL)", New SqlConnection(connS3SQL))
            req2.CommandTimeout = 2
            Try
                req2.Connection.Open()
                req2.ExecuteNonQuery()
                req2.Connection.Close()
            Catch ex As Exception
                req2.Connection.Close()
            End Try
        End If
    End Sub

    Public Function getQuantiteProd(ByVal noof As String, ByVal noop As String, ByVal machine As String) As Integer
        Dim key = noof & "/" & noop & "/" & machine
        If dicoProd.ContainsKey(key) Then
            Return dicoProd.Item(key)
        Else
            Return 0
        End If
    End Function

    Public Function nbCountProd() As Integer
        Return dicoProd.Keys.Count
    End Function

    Public Function getDicoProd() As Dictionary(Of String, Integer)
        Return dicoProd
    End Function

    Public Function getDicoFinPosteActuel() As Dictionary(Of String, Integer)
        Return dicoQteFinPosteActuel
    End Function

    Public Function getListAllProd() As List(Of String)
        Return listAllProd
    End Function

    Public Function getItemFromDicoEtiq(ByVal key As String) As List(Of String)
        Return dicoEtiq.Item(key)
    End Function

    Private Function compareEtiq(ByVal noEtiqPrec As String)
        For Each element In dicoEtiq.Keys
            For Each etiq In dicoEtiq.Item(element)
                Debug.WriteLine("compare etiquette: " & etiq)
                If etiq = noEtiqPrec Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function

End Class