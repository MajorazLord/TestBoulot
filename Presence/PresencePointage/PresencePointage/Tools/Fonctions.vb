Imports System.Data.SqlClient

Module Fonctions
    Public Function getSecteurs() As ArrayList
        Dim maList As New ArrayList
        Dim req As New SqlCommand("SELECT * from SECTEURS", New SqlConnection(connS3SQL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim lecture = req.ExecuteReader
            While lecture.Read()
                maList.Add(New Secteur(lecture.Item(0), lecture.Item(1), lecture.Item(2)))
            End While
            'Debug.WriteLine(maList.Count)
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try
        Return maList
    End Function

    Public Function getPdcsInOneSecteur(ByVal sect As Secteur) As ArrayList
        Dim maList As New ArrayList
        Dim req As New SqlCommand("select * from POSTE_CHARGE WHERE SECTEUR = '" & sect.Code & "'", New SqlConnection(connS3SQL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim lecture = req.ExecuteReader
            While lecture.Read()
                maList.Add(New Poste(lecture.Item(0), lecture.Item(1), lecture.Item(2)))
            End While
            'Debug.WriteLine(maList.Count)
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try
        Return maList
    End Function

    Public Function getMachineInOnePoste(ByVal _poste As Poste) As ArrayList
        Dim maList As New ArrayList
        Dim req As New SqlCommand("select * from MACHINES WHERE POSTE_CHARGE = '" & _poste.Code & "'", New SqlConnection(connS3SQL))
        req.CommandTimeout = 2
        Try
            req.Connection.Open()
            Dim lecture = req.ExecuteReader
            While lecture.Read()
                maList.Add(New Machine(lecture.Item(0), lecture.Item(1), lecture.Item(2)))
            End While
            'Debug.WriteLine(maList.Count)
            req.Connection.Close()
        Catch ex As Exception
            req.Connection.Close()
        End Try
        Return maList
    End Function

    Public Function initTotal() As DeuxSite
        Dim site As New DeuxSite(getSecteurs())
        For Each sect As Secteur In site.LesSecteurs
            sect.LesPdcs = getPdcsInOneSecteur(sect)
            For Each pdc As Poste In sect.LesPdcs
                pdc.LesMachines = getMachineInOnePoste(pdc)
            Next
        Next
        Return site
    End Function
End Module
