Imports Datalogic.API

Module Fonctions


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
End Module
