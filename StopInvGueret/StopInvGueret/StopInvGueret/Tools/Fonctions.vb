Imports Datalogic.API

Module Fonctions
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

    Public Sub affichePointVert()
        Device.EnableLED(Device.LEDs.GreenSpot, True)
        pause(1)
        Device.EnableLED(Device.LEDs.GreenSpot, False)
    End Sub

    Public Function isScreenVGA() As Boolean
        Return (currentScreenHeight = HEIGHT_SCREEN_VGA And currentScreenWidth = WIDTH_SCREEN_VGA)
    End Function

    Public Sub pause(ByVal coef As Integer)
        Threading.Thread.Sleep(300 * coef)
    End Sub

End Module

