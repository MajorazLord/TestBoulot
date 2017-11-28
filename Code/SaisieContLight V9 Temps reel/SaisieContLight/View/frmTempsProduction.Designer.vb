<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmTempsProduction
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
        Me.BValider = New System.Windows.Forms.Button
        Me.LVTempsProd = New System.Windows.Forms.ListView
        Me.LProduction = New System.Windows.Forms.Label
        Me.PDetail = New System.Windows.Forms.Panel
        Me.BArretProd = New System.Windows.Forms.Button
        Me.BDelTpsProd = New System.Windows.Forms.Button
        Me.LTempsProdAc = New System.Windows.Forms.Label
        Me.LProduit = New System.Windows.Forms.Label
        Me.LIProduit = New System.Windows.Forms.Label
        Me.LOF = New System.Windows.Forms.Label
        Me.LMachine = New System.Windows.Forms.Label
        Me.PBAdd = New System.Windows.Forms.PictureBox
        Me.LIOF = New System.Windows.Forms.Label
        Me.TBTempsProd = New System.Windows.Forms.TextBox
        Me.LTempsProd = New System.Windows.Forms.Label
        Me.LIMachine = New System.Windows.Forms.Label
        Me.LProdActuel = New System.Windows.Forms.Label
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.PBRecap = New System.Windows.Forms.PictureBox
        Me.LAucuneProd = New System.Windows.Forms.Label
        Me.LProdAuj = New System.Windows.Forms.Label
        Me.BArretMachine = New System.Windows.Forms.Button
        Me.PDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'BValider
        '
        Me.BValider.BackColor = System.Drawing.Color.Lime
        Me.BValider.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.BValider.Location = New System.Drawing.Point(138, 225)
        Me.BValider.Name = "BValider"
        Me.BValider.Size = New System.Drawing.Size(99, 66)
        Me.BValider.TabIndex = 1
        Me.BValider.Text = "Valider"
        '
        'LVTempsProd
        '
        Me.LVTempsProd.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.LVTempsProd.Location = New System.Drawing.Point(0, 41)
        Me.LVTempsProd.Name = "LVTempsProd"
        Me.LVTempsProd.Size = New System.Drawing.Size(100, 134)
        Me.LVTempsProd.TabIndex = 1
        Me.LVTempsProd.View = System.Windows.Forms.View.List
        '
        'LProduction
        '
        Me.LProduction.Font = New System.Drawing.Font("Tahoma", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LProduction.Location = New System.Drawing.Point(6, 10)
        Me.LProduction.Name = "LProduction"
        Me.LProduction.Size = New System.Drawing.Size(129, 19)
        Me.LProduction.Text = "N° Production"
        Me.LProduction.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PDetail
        '
        Me.PDetail.Controls.Add(Me.BArretProd)
        Me.PDetail.Controls.Add(Me.BDelTpsProd)
        Me.PDetail.Controls.Add(Me.LTempsProdAc)
        Me.PDetail.Controls.Add(Me.LProduit)
        Me.PDetail.Controls.Add(Me.LIProduit)
        Me.PDetail.Controls.Add(Me.LOF)
        Me.PDetail.Controls.Add(Me.LMachine)
        Me.PDetail.Controls.Add(Me.PBAdd)
        Me.PDetail.Controls.Add(Me.LIOF)
        Me.PDetail.Controls.Add(Me.TBTempsProd)
        Me.PDetail.Controls.Add(Me.LTempsProd)
        Me.PDetail.Controls.Add(Me.LIMachine)
        Me.PDetail.Controls.Add(Me.LProduction)
        Me.PDetail.Controls.Add(Me.LProdActuel)
        Me.PDetail.Location = New System.Drawing.Point(101, 0)
        Me.PDetail.Name = "PDetail"
        Me.PDetail.Size = New System.Drawing.Size(139, 222)
        Me.PDetail.Visible = False
        '
        'BArretProd
        '
        Me.BArretProd.BackColor = System.Drawing.Color.MediumOrchid
        Me.BArretProd.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.BArretProd.Location = New System.Drawing.Point(6, 184)
        Me.BArretProd.Name = "BArretProd"
        Me.BArretProd.Size = New System.Drawing.Size(127, 35)
        Me.BArretProd.TabIndex = 17
        Me.BArretProd.Text = "Arrêt production"
        '
        'BDelTpsProd
        '
        Me.BDelTpsProd.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelTpsProd.Location = New System.Drawing.Point(65, 146)
        Me.BDelTpsProd.Name = "BDelTpsProd"
        Me.BDelTpsProd.Size = New System.Drawing.Size(23, 29)
        Me.BDelTpsProd.TabIndex = 3
        Me.BDelTpsProd.Text = "X"
        '
        'LTempsProdAc
        '
        Me.LTempsProdAc.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LTempsProdAc.Location = New System.Drawing.Point(103, 101)
        Me.LTempsProdAc.Name = "LTempsProdAc"
        Me.LTempsProdAc.Size = New System.Drawing.Size(33, 19)
        Me.LTempsProdAc.Text = "H."
        Me.LTempsProdAc.Visible = False
        '
        'LProduit
        '
        Me.LProduit.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LProduit.Location = New System.Drawing.Point(72, 80)
        Me.LProduit.Name = "LProduit"
        Me.LProduit.Size = New System.Drawing.Size(63, 19)
        Me.LProduit.Text = "Produit"
        '
        'LIProduit
        '
        Me.LIProduit.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LIProduit.Location = New System.Drawing.Point(2, 79)
        Me.LIProduit.Name = "LIProduit"
        Me.LIProduit.Size = New System.Drawing.Size(83, 20)
        Me.LIProduit.Text = "N° Produit:"
        '
        'LOF
        '
        Me.LOF.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LOF.Location = New System.Drawing.Point(54, 58)
        Me.LOF.Name = "LOF"
        Me.LOF.Size = New System.Drawing.Size(76, 18)
        Me.LOF.Text = "OF"
        '
        'LMachine
        '
        Me.LMachine.Font = New System.Drawing.Font("Tahoma", 8.5!, System.Drawing.FontStyle.Italic)
        Me.LMachine.Location = New System.Drawing.Point(62, 35)
        Me.LMachine.Name = "LMachine"
        Me.LMachine.Size = New System.Drawing.Size(68, 18)
        Me.LMachine.Text = "Machine"
        '
        'PBAdd
        '
        Me.PBAdd.Location = New System.Drawing.Point(94, 135)
        Me.PBAdd.Name = "PBAdd"
        Me.PBAdd.Size = New System.Drawing.Size(40, 40)
        Me.PBAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LIOF
        '
        Me.LIOF.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LIOF.Location = New System.Drawing.Point(3, 56)
        Me.LIOF.Name = "LIOF"
        Me.LIOF.Size = New System.Drawing.Size(53, 20)
        Me.LIOF.Text = "OF/OP:"
        '
        'TBTempsProd
        '
        Me.TBTempsProd.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBTempsProd.Location = New System.Drawing.Point(3, 146)
        Me.TBTempsProd.Multiline = True
        Me.TBTempsProd.Name = "TBTempsProd"
        Me.TBTempsProd.Size = New System.Drawing.Size(56, 29)
        Me.TBTempsProd.TabIndex = 2
        '
        'LTempsProd
        '
        Me.LTempsProd.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LTempsProd.Location = New System.Drawing.Point(3, 121)
        Me.LTempsProd.Name = "LTempsProd"
        Me.LTempsProd.Size = New System.Drawing.Size(101, 20)
        Me.LTempsProd.Text = "Temps prod:"
        '
        'LIMachine
        '
        Me.LIMachine.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LIMachine.Location = New System.Drawing.Point(3, 33)
        Me.LIMachine.Name = "LIMachine"
        Me.LIMachine.Size = New System.Drawing.Size(61, 20)
        Me.LIMachine.Text = "Machine:"
        '
        'LProdActuel
        '
        Me.LProdActuel.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LProdActuel.Location = New System.Drawing.Point(3, 100)
        Me.LProdActuel.Name = "LProdActuel"
        Me.LProdActuel.Size = New System.Drawing.Size(111, 20)
        Me.LProdActuel.Text = "Tps Prod actuel:"
        Me.LProdActuel.Visible = False
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(3, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PBRecap
        '
        Me.PBRecap.Location = New System.Drawing.Point(78, 225)
        Me.PBRecap.Name = "PBRecap"
        Me.PBRecap.Size = New System.Drawing.Size(54, 66)
        Me.PBRecap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LAucuneProd
        '
        Me.LAucuneProd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LAucuneProd.Location = New System.Drawing.Point(70, 92)
        Me.LAucuneProd.Name = "LAucuneProd"
        Me.LAucuneProd.Size = New System.Drawing.Size(100, 45)
        Me.LAucuneProd.Text = "Aucune production"
        Me.LAucuneProd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.LAucuneProd.Visible = False
        '
        'LProdAuj
        '
        Me.LProdAuj.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LProdAuj.Location = New System.Drawing.Point(0, 6)
        Me.LProdAuj.Name = "LProdAuj"
        Me.LProdAuj.Size = New System.Drawing.Size(100, 30)
        Me.LProdAuj.Text = "Productions actuelles:"
        Me.LProdAuj.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BArretMachine
        '
        Me.BArretMachine.BackColor = System.Drawing.Color.MediumOrchid
        Me.BArretMachine.Location = New System.Drawing.Point(1, 184)
        Me.BArretMachine.Name = "BArretMachine"
        Me.BArretMachine.Size = New System.Drawing.Size(98, 35)
        Me.BArretMachine.TabIndex = 29
        Me.BArretMachine.Text = "Arrêt machine"
        '
        'frmTempsProduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BArretMachine)
        Me.Controls.Add(Me.PDetail)
        Me.Controls.Add(Me.LProdAuj)
        Me.Controls.Add(Me.PBRecap)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.BValider)
        Me.Controls.Add(Me.LVTempsProd)
        Me.Controls.Add(Me.LAucuneProd)
        Me.Name = "frmTempsProduction"
        Me.Text = "Tps de production"
        Me.PDetail.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BValider As System.Windows.Forms.Button
    Friend WithEvents LVTempsProd As System.Windows.Forms.ListView
    Friend WithEvents LProduction As System.Windows.Forms.Label
    Friend WithEvents PDetail As System.Windows.Forms.Panel
    Friend WithEvents LTempsProd As System.Windows.Forms.Label
    Friend WithEvents LIMachine As System.Windows.Forms.Label
    Friend WithEvents TBTempsProd As System.Windows.Forms.TextBox
    Friend WithEvents LIOF As System.Windows.Forms.Label
    Friend WithEvents LIProduit As System.Windows.Forms.Label
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents PBRecap As System.Windows.Forms.PictureBox
    Friend WithEvents LAucuneProd As System.Windows.Forms.Label
    Friend WithEvents PBAdd As System.Windows.Forms.PictureBox
    Friend WithEvents LProduit As System.Windows.Forms.Label
    Friend WithEvents LOF As System.Windows.Forms.Label
    Friend WithEvents LMachine As System.Windows.Forms.Label
    Friend WithEvents LProdAuj As System.Windows.Forms.Label
    Friend WithEvents LTempsProdAc As System.Windows.Forms.Label
    Friend WithEvents LProdActuel As System.Windows.Forms.Label
    Friend WithEvents BDelTpsProd As System.Windows.Forms.Button
    Friend WithEvents BArretProd As System.Windows.Forms.Button
    Friend WithEvents BArretMachine As System.Windows.Forms.Button
End Class
