<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmArretProd
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
        Me.PBRecap = New System.Windows.Forms.PictureBox
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.BValider = New System.Windows.Forms.Button
        Me.PBAddCode = New System.Windows.Forms.PictureBox
        Me.BDelLigne2 = New System.Windows.Forms.Button
        Me.BDelLigne = New System.Windows.Forms.Button
        Me.TBHeure2 = New System.Windows.Forms.TextBox
        Me.TBHeure = New System.Windows.Forms.TextBox
        Me.TBCode2 = New System.Windows.Forms.TextBox
        Me.TBCode = New System.Windows.Forms.TextBox
        Me.LTitreNbHeure = New System.Windows.Forms.Label
        Me.LCode = New System.Windows.Forms.Label
        Me.BDelLigne3 = New System.Windows.Forms.Button
        Me.TBHeure3 = New System.Windows.Forms.TextBox
        Me.TBCode3 = New System.Windows.Forms.TextBox
        Me.LTitre = New System.Windows.Forms.Label
        Me.LTitreProd = New System.Windows.Forms.Label
        Me.LTitreMachine = New System.Windows.Forms.Label
        Me.LProd = New System.Windows.Forms.Label
        Me.LMachine = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PBRecap
        '
        Me.PBRecap.Location = New System.Drawing.Point(77, 225)
        Me.PBRecap.Name = "PBRecap"
        Me.PBRecap.Size = New System.Drawing.Size(54, 66)
        Me.PBRecap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(2, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BValider
        '
        Me.BValider.BackColor = System.Drawing.Color.Lime
        Me.BValider.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BValider.Location = New System.Drawing.Point(137, 225)
        Me.BValider.Name = "BValider"
        Me.BValider.Size = New System.Drawing.Size(99, 66)
        Me.BValider.TabIndex = 10
        Me.BValider.Text = "Valider"
        '
        'PBAddCode
        '
        Me.PBAddCode.Location = New System.Drawing.Point(169, 137)
        Me.PBAddCode.Name = "PBAddCode"
        Me.PBAddCode.Size = New System.Drawing.Size(65, 65)
        Me.PBAddCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BDelLigne2
        '
        Me.BDelLigne2.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne2.Location = New System.Drawing.Point(136, 149)
        Me.BDelLigne2.Name = "BDelLigne2"
        Me.BDelLigne2.Size = New System.Drawing.Size(27, 29)
        Me.BDelLigne2.TabIndex = 6
        Me.BDelLigne2.Text = "X"
        '
        'BDelLigne
        '
        Me.BDelLigne.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne.Location = New System.Drawing.Point(136, 114)
        Me.BDelLigne.Name = "BDelLigne"
        Me.BDelLigne.Size = New System.Drawing.Size(27, 29)
        Me.BDelLigne.TabIndex = 3
        Me.BDelLigne.Text = "X"
        '
        'TBHeure2
        '
        Me.TBHeure2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBHeure2.Location = New System.Drawing.Point(66, 149)
        Me.TBHeure2.Multiline = True
        Me.TBHeure2.Name = "TBHeure2"
        Me.TBHeure2.Size = New System.Drawing.Size(64, 29)
        Me.TBHeure2.TabIndex = 5
        '
        'TBHeure
        '
        Me.TBHeure.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBHeure.Location = New System.Drawing.Point(66, 114)
        Me.TBHeure.Multiline = True
        Me.TBHeure.Name = "TBHeure"
        Me.TBHeure.Size = New System.Drawing.Size(64, 29)
        Me.TBHeure.TabIndex = 2
        '
        'TBCode2
        '
        Me.TBCode2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode2.Location = New System.Drawing.Point(4, 149)
        Me.TBCode2.Multiline = True
        Me.TBCode2.Name = "TBCode2"
        Me.TBCode2.Size = New System.Drawing.Size(51, 29)
        Me.TBCode2.TabIndex = 4
        '
        'TBCode
        '
        Me.TBCode.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode.Location = New System.Drawing.Point(4, 114)
        Me.TBCode.Multiline = True
        Me.TBCode.Name = "TBCode"
        Me.TBCode.Size = New System.Drawing.Size(51, 29)
        Me.TBCode.TabIndex = 1
        '
        'LTitreNbHeure
        '
        Me.LTitreNbHeure.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreNbHeure.Location = New System.Drawing.Point(66, 91)
        Me.LTitreNbHeure.Name = "LTitreNbHeure"
        Me.LTitreNbHeure.Size = New System.Drawing.Size(96, 20)
        Me.LTitreNbHeure.Text = "NB Heures:"
        '
        'LCode
        '
        Me.LCode.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LCode.Location = New System.Drawing.Point(4, 91)
        Me.LCode.Name = "LCode"
        Me.LCode.Size = New System.Drawing.Size(56, 20)
        Me.LCode.Text = "Code:"
        '
        'BDelLigne3
        '
        Me.BDelLigne3.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne3.Location = New System.Drawing.Point(136, 188)
        Me.BDelLigne3.Name = "BDelLigne3"
        Me.BDelLigne3.Size = New System.Drawing.Size(27, 29)
        Me.BDelLigne3.TabIndex = 9
        Me.BDelLigne3.Text = "X"
        '
        'TBHeure3
        '
        Me.TBHeure3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBHeure3.Location = New System.Drawing.Point(66, 188)
        Me.TBHeure3.Multiline = True
        Me.TBHeure3.Name = "TBHeure3"
        Me.TBHeure3.Size = New System.Drawing.Size(64, 29)
        Me.TBHeure3.TabIndex = 8
        '
        'TBCode3
        '
        Me.TBCode3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode3.Location = New System.Drawing.Point(4, 188)
        Me.TBCode3.Multiline = True
        Me.TBCode3.Name = "TBCode3"
        Me.TBCode3.Size = New System.Drawing.Size(51, 29)
        Me.TBCode3.TabIndex = 7
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.MediumOrchid
        Me.LTitre.Location = New System.Drawing.Point(0, 4)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 30)
        Me.LTitre.Text = "Arrêt Production"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LTitreProd
        '
        Me.LTitreProd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreProd.Location = New System.Drawing.Point(4, 41)
        Me.LTitreProd.Name = "LTitreProd"
        Me.LTitreProd.Size = New System.Drawing.Size(90, 20)
        Me.LTitreProd.Text = "N° OF/OP:"
        '
        'LTitreMachine
        '
        Me.LTitreMachine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreMachine.Location = New System.Drawing.Point(4, 69)
        Me.LTitreMachine.Name = "LTitreMachine"
        Me.LTitreMachine.Size = New System.Drawing.Size(90, 20)
        Me.LTitreMachine.Text = "Machine: "
        '
        'LProd
        '
        Me.LProd.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.LProd.Location = New System.Drawing.Point(100, 41)
        Me.LProd.Name = "LProd"
        Me.LProd.Size = New System.Drawing.Size(134, 20)
        Me.LProd.Text = "prod"
        '
        'LMachine
        '
        Me.LMachine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.LMachine.Location = New System.Drawing.Point(100, 71)
        Me.LMachine.Name = "LMachine"
        Me.LMachine.Size = New System.Drawing.Size(134, 20)
        Me.LMachine.Text = "Machine"
        '
        'frmArretProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LMachine)
        Me.Controls.Add(Me.LProd)
        Me.Controls.Add(Me.LTitreMachine)
        Me.Controls.Add(Me.LTitreProd)
        Me.Controls.Add(Me.LTitre)
        Me.Controls.Add(Me.BDelLigne3)
        Me.Controls.Add(Me.TBHeure3)
        Me.Controls.Add(Me.TBCode3)
        Me.Controls.Add(Me.PBAddCode)
        Me.Controls.Add(Me.BDelLigne2)
        Me.Controls.Add(Me.BDelLigne)
        Me.Controls.Add(Me.TBHeure2)
        Me.Controls.Add(Me.TBHeure)
        Me.Controls.Add(Me.TBCode2)
        Me.Controls.Add(Me.TBCode)
        Me.Controls.Add(Me.LTitreNbHeure)
        Me.Controls.Add(Me.LCode)
        Me.Controls.Add(Me.PBRecap)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.BValider)
        Me.Name = "frmArretProd"
        Me.Text = "Arrêt Production"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PBRecap As System.Windows.Forms.PictureBox
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents BValider As System.Windows.Forms.Button
    Friend WithEvents PBAddCode As System.Windows.Forms.PictureBox
    Friend WithEvents BDelLigne2 As System.Windows.Forms.Button
    Friend WithEvents BDelLigne As System.Windows.Forms.Button
    Friend WithEvents TBHeure2 As System.Windows.Forms.TextBox
    Friend WithEvents TBHeure As System.Windows.Forms.TextBox
    Friend WithEvents TBCode2 As System.Windows.Forms.TextBox
    Friend WithEvents TBCode As System.Windows.Forms.TextBox
    Friend WithEvents LTitreNbHeure As System.Windows.Forms.Label
    Friend WithEvents LCode As System.Windows.Forms.Label
    Friend WithEvents BDelLigne3 As System.Windows.Forms.Button
    Friend WithEvents TBHeure3 As System.Windows.Forms.TextBox
    Friend WithEvents TBCode3 As System.Windows.Forms.TextBox
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents LTitreProd As System.Windows.Forms.Label
    Friend WithEvents LTitreMachine As System.Windows.Forms.Label
    Friend WithEvents LProd As System.Windows.Forms.Label
    Friend WithEvents LMachine As System.Windows.Forms.Label
End Class
