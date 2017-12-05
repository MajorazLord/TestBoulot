Public Class RebutManager
    Private dicoRebuts As Dictionary(Of String, List(Of String))

    Public Sub New()
        dicoRebuts = New Dictionary(Of String, List(Of String))()
    End Sub


    ''' <summary>
    ''' Permet d'ajouter une machine dans le dictionnaire par rapport a une of
    ''' </summary>
    ''' <param name="noof"></param>
    ''' <param name="machine"></param>
    ''' <remarks></remarks>
    Public Sub addMachine(ByVal noof As String, ByVal machine As String)
        Dim isFind As Boolean = False

        If dicoRebuts.Keys.Contains(noof) Then
            If dicoRebuts.Item(noof).Contains(machine) Then
                Exit Sub
            End If
            dicoRebuts.Item(noof).Add(machine)
        Else
            Dim list As New List(Of String)
            list.Add(machine)
            dicoRebuts.Add(noof, list)
        End If
    End Sub


    ''' <summary>
    ''' Permet de récuperer la liste des machines d'une of
    ''' </summary>
    ''' <param name="Noof"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListOfValue(ByVal Noof As String) As List(Of String)
        If Not Noof Is Nothing Then
            If dicoRebuts.Keys.Contains(Noof) Then
                Return dicoRebuts.Item(Noof)
            End If
        End If
        Return Nothing
    End Function
End Class
