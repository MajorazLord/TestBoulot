﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.8000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("SaisieContLight.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        Friend ReadOnly Property Check() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Check", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to C1;EJECTE VISION|
        '''C2;EJECTE VISION|
        '''01;Longueur / hauteur|
        '''02;Diametre interieur / Alesage|
        '''03;Poids|
        '''04;Angle|
        '''05;Cannelure|
        '''06;Filetage|
        '''07;Faux-rond / concentricite|
        '''08;Battement|
        '''09;Parallelisme|
        '''10;Perpendicularite|
        '''11;Symetrie|
        '''12;Circularite|
        '''13;Etat de surface|
        '''14;Pieces ejectees vision|
        '''15;Cote sur bille (PIGNON)|
        '''16;Diametre exterieur|
        '''17;Pieces ejectees controle auto|
        '''30;Chocs|
        '''31;Empreinte|
        '''32;Grippage / rayure|
        '''33;Trou|
        '''34;Deformation|
        '''35;Piece sale / Depot|
        '''36;Oxydatio [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property CODES_DEF() As String
            Get
                Return ResourceManager.GetString("CODES_DEF", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 1;PANNE|
        '''2;CHANGEMENT DE SERIE|
        '''3;REGLAGES MACHINES|
        '''4;OUTILLAGE|
        '''5;NETTOYAGE/PREVENTIF/ESSAIS|
        '''6;ANNEXES (TER, CHAUFFEUSE, CONVOYEURS, ROBOTS, MACHINE A LAVER,...)|
        '''7;ABSENCE DE PERSONNEL PREVU|
        '''8;ABSENCE DE PERSONNEL SUBIT|
        '''9;ATTENTE PIECE|
        '''10;PROBLEME QUALITE|
        '''11;MANQUE CHARGE.
        '''</summary>
        Friend ReadOnly Property CODES_NP() As String
            Get
                Return ResourceManager.GetString("CODES_NP", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 53;Changement de série|
        '''54;Réglages machine|
        '''55;Réglages annexes|
        '''56;Changement outil|
        '''57;Panne|
        '''58;Absence personnel|
        '''59;Attente validation|
        '''60;Attente outillage|
        '''61;Attente pièce|
        '''65;Arrêt volontaire|
        '''66;Préventif niveau 1|
        '''67;Préventif niveau 2,3|
        '''68;Essais.
        '''</summary>
        Friend ReadOnly Property CODES_NP1() As String
            Get
                Return ResourceManager.GetString("CODES_NP1", resourceCulture)
            End Get
        End Property
        
        Friend ReadOnly Property Fleche_retour() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Fleche_retour", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Icone_Add() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Icone_Add", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property NoCheck() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("NoCheck", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Ok() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Ok", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Options() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Options", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property recapitulatif() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("recapitulatif", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Socle() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Socle", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Validation() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Validation", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Wifi() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Wifi", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
