<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRecapSaisie
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LTitre = New System.Windows.Forms.Label
        Me.LVSaisie = New System.Windows.Forms.ListView
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.LTitreQuantite = New System.Windows.Forms.Label
        Me.LTitreOF = New System.Windows.Forms.Label
        Me.LTitreMachine = New System.Windows.Forms.Label
        Me.LTitreTpsProd = New System.Windows.Forms.Label
        Me.LLRebut = New System.Windows.Forms.LinkLabel
        Me.LLArret = New System.Windows.Forms.LinkLabel
        Me.LVRebArret = New System.Windows.Forms.ListView
        Me.LQuantite = New System.Windows.Forms.Label
        Me.LOF = New System.Windows.Forms.Label
        Me.LMachine = New System.Windows.Forms.Label
        Me.LTpsProd = New System.Windows.Forms.Label
        Me.PDetail = New System.Windows.Forms.Panel
        Me.LNomProd = New System.Windows.Forms.Label
        Me.LProduit = New System.Windows.Forms.Label
        Me.LTitreProduit = New System.Windows.Forms.Label
        Me.LAucuneProd = New System.Windows.Forms.Label
        Me.PDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.Blue
        Me.LTitre.Location = New System.Drawing.Point(0, 0)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 49)
        Me.LTitre.Text = "Récapitulatif des saisies"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LVSaisie
        '
        Me.LVSaisie.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular)
        Me.LVSaisie.Location = New System.Drawing.Point(0, 52)
        Me.LVSaisie.Name = "LVSaisie"
        Me.LVSaisie.Size = New System.Drawing.Size(100, 170)
        Me.LVSaisie.TabIndex = 1
        Me.LVSaisie.View = System.Windows.Forms.View.List
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(13, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LTitreQuantite
        '
        Me.LTitreQuantite.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LTitreQuantite.Location = New System.Drawing.Point(3, 38)
        Me.LTitreQuantite.Name = "LTitreQuantite"
        Me.LTitreQuantite.Size = New System.Drawing.Size(62, 20)
        Me.LTitreQuantite.Text = "Quantité:"
        '
        'LTitreOF
        '
        Me.LTitreOF.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LTitreOF.Location = New System.Drawing.Point(5, 61)
        Me.LTitreOF.Name = "LTitreOF"
        Me.LTitreOF.Size = New System.Drawing.Size(59, 20)
        Me.LTitreOF.Text = "N° OF:"
        '
        'LTitreMachine
        '
        Me.LTitreMachine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LTitreMachine.Location = New System.Drawing.Point(5, 84)
        Me.LTitreMachine.Name = "LTitreMachine"
        Me.LTitreMachine.Size = New System.Drawing.Size(62, 20)
        Me.LTitreMachine.Text = "Machine:"
        '
        'LTitreTpsProd
        '
        Me.LTitreTpsProd.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LTitreTpsProd.Location = New System.Drawing.Point(5, 130)
        Me.LTitreTpsProd.Name = "LTitreTpsProd"
        Me.LTitreTpsProd.Size = New System.Drawing.Size(100, 20)
        Me.LTitreTpsProd.Text = "Tps production:"
        '
        'LLRebut
        '
        Me.LLRebut.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Underline)
        Me.LLRebut.ForeColor = System.Drawing.Color.Green
        Me.LLRebut.Location = New System.Drawing.Point(3, 150)
        Me.LLRebut.Name = "LLRebut"
        Me.LLRebut.Size = New System.Drawing.Size(55, 20)
        Me.LLRebut.TabIndex = 8
        Me.LLRebut.Text = "Rebuts"
        '
        'LLArret
        '
        Me.LLArret.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Underline)
        Me.LLArret.ForeColor = System.Drawing.Color.Green
        Me.LLArret.Location = New System.Drawing.Point(89, 150)
        Me.LLArret.Name = "LLArret"
        Me.LLArret.Size = New System.Drawing.Size(47, 20)
        Me.LLArret.TabIndex = 9
        Me.LLArret.Text = "Arrets"
        '
        'LVRebArret
        '
        Me.LVRebArret.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LVRebArret.Location = New System.Drawing.Point(3, 176)
        Me.LVRebArret.Name = "LVRebArret"
        Me.LVRebArret.Size = New System.Drawing.Size(134, 63)
        Me.LVRebArret.TabIndex = 10
        Me.LVRebArret.View = System.Windows.Forms.View.List
        Me.LVRebArret.Visible = False
        '
        'LQuantite
        '
        Me.LQuantite.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LQuantite.Location = New System.Drawing.Point(65, 38)
        Me.LQuantite.Name = "LQuantite"
        Me.LQuantite.Size = New System.Drawing.Size(63, 20)
        Me.LQuantite.Text = "Quantite"
        '
        'LOF
        '
        Me.LOF.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LOF.Location = New System.Drawing.Point(65, 61)
        Me.LOF.Name = "LOF"
        Me.LOF.Size = New System.Drawing.Size(60, 20)
        Me.LOF.Text = "Num OF"
        '
        'LMachine
        '
        Me.LMachine.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LMachine.Location = New System.Drawing.Point(65, 84)
        Me.LMachine.Name = "LMachine"
        Me.LMachine.Size = New System.Drawing.Size(60, 20)
        Me.LMachine.Text = "Machine"
        '
        'LTpsProd
        '
        Me.LTpsProd.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LTpsProd.Location = New System.Drawing.Point(104, 130)
        Me.LTpsProd.Name = "LTpsProd"
        Me.LTpsProd.Size = New System.Drawing.Size(34, 20)
        Me.LTpsProd.Text = "H"
        '
        'PDetail
        '
        Me.PDetail.Controls.Add(Me.LNomProd)
        Me.PDetail.Controls.Add(Me.LProduit)
        Me.PDetail.Controls.Add(Me.LTitreProduit)
        Me.PDetail.Controls.Add(Me.LTitreQuantite)
        Me.PDetail.Controls.Add(Me.LQuantite)
        Me.PDetail.Controls.Add(Me.LTpsProd)
        Me.PDetail.Controls.Add(Me.LVRebArret)
        Me.PDetail.Controls.Add(Me.LTitreOF)
        Me.PDetail.Controls.Add(Me.LLArret)
        Me.PDetail.Controls.Add(Me.LMachine)
        Me.PDetail.Controls.Add(Me.LLRebut)
        Me.PDetail.Controls.Add(Me.LOF)
        Me.PDetail.Controls.Add(Me.LTitreMachine)
        Me.PDetail.Controls.Add(Me.LTitreTpsProd)
        Me.PDetail.Location = New System.Drawing.Point(101, 52)
        Me.PDetail.Name = "PDetail"
        Me.PDetail.Size = New System.Drawing.Size(139, 242)
        Me.PDetail.Visible = False
        '
        'LNomProd
        '
        Me.LNomProd.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LNomProd.Location = New System.Drawing.Point(3, 0)
        Me.LNomProd.Name = "LNomProd"
        Me.LNomProd.Size = New System.Drawing.Size(133, 38)
        Me.LNomProd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LProduit
        '
        Me.LProduit.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LProduit.Location = New System.Drawing.Point(65, 107)
        Me.LProduit.Name = "LProduit"
        Me.LProduit.Size = New System.Drawing.Size(71, 20)
        Me.LProduit.Text = "Produit"
        '
        'LTitreProduit
        '
        Me.LTitreProduit.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LTitreProduit.Location = New System.Drawing.Point(5, 107)
        Me.LTitreProduit.Name = "LTitreProduit"
        Me.LTitreProduit.Size = New System.Drawing.Size(53, 20)
        Me.LTitreProduit.Text = "Produit:"
        '
        'LAucuneProd
        '
        Me.LAucuneProd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LAucuneProd.Location = New System.Drawing.Point(70, 112)
        Me.LAucuneProd.Name = "LAucuneProd"
        Me.LAucuneProd.Size = New System.Drawing.Size(100, 45)
        Me.LAucuneProd.Text = "Aucune production"
        Me.LAucuneProd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LAucuneProd.Visible = False
        '
        'frmRecapSaisie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LVSaisie)
        Me.Controls.Add(Me.PDetail)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.LTitre)
        Me.Controls.Add(Me.LAucuneProd)
        Me.Name = "frmRecapSaisie"
        Me.Text = "Récap Saisie"
        Me.PDetail.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents LVSaisie As System.Windows.Forms.ListView
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents LTitreQuantite As System.Windows.Forms.Label
    Friend WithEvents LTitreOF As System.Windows.Forms.Label
    Friend WithEvents LTitreMachine As System.Windows.Forms.Label
    Friend WithEvents LTitreTpsProd As System.Windows.Forms.Label
    Friend WithEvents LLRebut As System.Windows.Forms.LinkLabel
    Friend WithEvents LLArret As System.Windows.Forms.LinkLabel
    Friend WithEvents LVRebArret As System.Windows.Forms.ListView
    Friend WithEvents LQuantite As System.Windows.Forms.Label
    Friend WithEvents LOF As System.Windows.Forms.Label
    Friend WithEvents LMachine As System.Windows.Forms.Label
    Friend WithEvents LTpsProd As System.Windows.Forms.Label
    Friend WithEvents PDetail As System.Windows.Forms.Panel
    Friend WithEvents LAucuneProd As System.Windows.Forms.Label
    Friend WithEvents LTitreProduit As System.Windows.Forms.Label
    Friend WithEvents LProduit As System.Windows.Forms.Label
    Friend WithEvents LNomProd As System.Windows.Forms.Label
End Class
