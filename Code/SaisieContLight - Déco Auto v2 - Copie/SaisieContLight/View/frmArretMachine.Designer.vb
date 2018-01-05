<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmArretMachine
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
        Me.LMachine = New System.Windows.Forms.Label
        Me.TBMachine = New System.Windows.Forms.TextBox
        Me.BDelMachine = New System.Windows.Forms.Button
        Me.LCode = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.PBRecapitulatif = New System.Windows.Forms.PictureBox
        Me.BValider = New System.Windows.Forms.Button
        Me.TBCode = New System.Windows.Forms.TextBox
        Me.TBCode2 = New System.Windows.Forms.TextBox
        Me.TBCode3 = New System.Windows.Forms.TextBox
        Me.TBHeure = New System.Windows.Forms.TextBox
        Me.TBHeure2 = New System.Windows.Forms.TextBox
        Me.TBHeure3 = New System.Windows.Forms.TextBox
        Me.BDelLigne = New System.Windows.Forms.Button
        Me.BDelLigne2 = New System.Windows.Forms.Button
        Me.BDelLigne3 = New System.Windows.Forms.Button
        Me.PBAddCode = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.DarkOrchid
        Me.LTitre.Location = New System.Drawing.Point(0, 3)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 31)
        Me.LTitre.Text = "Arrêt Machine"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LMachine
        '
        Me.LMachine.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold)
        Me.LMachine.Location = New System.Drawing.Point(9, 36)
        Me.LMachine.Name = "LMachine"
        Me.LMachine.Size = New System.Drawing.Size(202, 20)
        Me.LMachine.Text = "Scan N° Machine:"
        '
        'TBMachine
        '
        Me.TBMachine.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular)
        Me.TBMachine.Location = New System.Drawing.Point(9, 59)
        Me.TBMachine.Multiline = True
        Me.TBMachine.Name = "TBMachine"
        Me.TBMachine.Size = New System.Drawing.Size(177, 30)
        Me.TBMachine.TabIndex = 1
        '
        'BDelMachine
        '
        Me.BDelMachine.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelMachine.Location = New System.Drawing.Point(192, 59)
        Me.BDelMachine.Name = "BDelMachine"
        Me.BDelMachine.Size = New System.Drawing.Size(32, 30)
        Me.BDelMachine.TabIndex = 2
        Me.BDelMachine.Text = "X"
        '
        'LCode
        '
        Me.LCode.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LCode.Location = New System.Drawing.Point(5, 94)
        Me.LCode.Name = "LCode"
        Me.LCode.Size = New System.Drawing.Size(56, 20)
        Me.LCode.Text = "Code:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(67, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.Text = "NB Heures:"
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PBRecapitulatif
        '
        Me.PBRecapitulatif.Location = New System.Drawing.Point(75, 228)
        Me.PBRecapitulatif.Name = "PBRecapitulatif"
        Me.PBRecapitulatif.Size = New System.Drawing.Size(54, 66)
        Me.PBRecapitulatif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BValider
        '
        Me.BValider.BackColor = System.Drawing.Color.Lime
        Me.BValider.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BValider.Location = New System.Drawing.Point(135, 228)
        Me.BValider.Name = "BValider"
        Me.BValider.Size = New System.Drawing.Size(102, 66)
        Me.BValider.TabIndex = 12
        Me.BValider.Text = "Valider"
        '
        'TBCode
        '
        Me.TBCode.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode.Location = New System.Drawing.Point(5, 117)
        Me.TBCode.Multiline = True
        Me.TBCode.Name = "TBCode"
        Me.TBCode.Size = New System.Drawing.Size(51, 29)
        Me.TBCode.TabIndex = 3
        '
        'TBCode2
        '
        Me.TBCode2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode2.Location = New System.Drawing.Point(5, 152)
        Me.TBCode2.Multiline = True
        Me.TBCode2.Name = "TBCode2"
        Me.TBCode2.Size = New System.Drawing.Size(51, 29)
        Me.TBCode2.TabIndex = 6
        '
        'TBCode3
        '
        Me.TBCode3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode3.Location = New System.Drawing.Point(5, 187)
        Me.TBCode3.Multiline = True
        Me.TBCode3.Name = "TBCode3"
        Me.TBCode3.Size = New System.Drawing.Size(51, 29)
        Me.TBCode3.TabIndex = 9
        '
        'TBHeure
        '
        Me.TBHeure.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBHeure.Location = New System.Drawing.Point(67, 117)
        Me.TBHeure.Multiline = True
        Me.TBHeure.Name = "TBHeure"
        Me.TBHeure.Size = New System.Drawing.Size(64, 29)
        Me.TBHeure.TabIndex = 4
        '
        'TBHeure2
        '
        Me.TBHeure2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBHeure2.Location = New System.Drawing.Point(67, 152)
        Me.TBHeure2.Multiline = True
        Me.TBHeure2.Name = "TBHeure2"
        Me.TBHeure2.Size = New System.Drawing.Size(64, 29)
        Me.TBHeure2.TabIndex = 7
        '
        'TBHeure3
        '
        Me.TBHeure3.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBHeure3.Location = New System.Drawing.Point(67, 187)
        Me.TBHeure3.Multiline = True
        Me.TBHeure3.Name = "TBHeure3"
        Me.TBHeure3.Size = New System.Drawing.Size(64, 29)
        Me.TBHeure3.TabIndex = 10
        '
        'BDelLigne
        '
        Me.BDelLigne.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne.Location = New System.Drawing.Point(137, 117)
        Me.BDelLigne.Name = "BDelLigne"
        Me.BDelLigne.Size = New System.Drawing.Size(27, 29)
        Me.BDelLigne.TabIndex = 5
        Me.BDelLigne.Text = "X"
        '
        'BDelLigne2
        '
        Me.BDelLigne2.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne2.Location = New System.Drawing.Point(137, 152)
        Me.BDelLigne2.Name = "BDelLigne2"
        Me.BDelLigne2.Size = New System.Drawing.Size(27, 29)
        Me.BDelLigne2.TabIndex = 8
        Me.BDelLigne2.Text = "X"
        '
        'BDelLigne3
        '
        Me.BDelLigne3.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne3.Location = New System.Drawing.Point(137, 187)
        Me.BDelLigne3.Name = "BDelLigne3"
        Me.BDelLigne3.Size = New System.Drawing.Size(27, 29)
        Me.BDelLigne3.TabIndex = 11
        Me.BDelLigne3.Text = "X"
        '
        'PBAddCode
        '
        Me.PBAddCode.Location = New System.Drawing.Point(170, 133)
        Me.PBAddCode.Name = "PBAddCode"
        Me.PBAddCode.Size = New System.Drawing.Size(65, 65)
        Me.PBAddCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmArretMachine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.PBAddCode)
        Me.Controls.Add(Me.BDelLigne3)
        Me.Controls.Add(Me.BDelLigne2)
        Me.Controls.Add(Me.BDelLigne)
        Me.Controls.Add(Me.TBHeure3)
        Me.Controls.Add(Me.TBHeure2)
        Me.Controls.Add(Me.TBHeure)
        Me.Controls.Add(Me.TBCode3)
        Me.Controls.Add(Me.TBCode2)
        Me.Controls.Add(Me.TBCode)
        Me.Controls.Add(Me.BValider)
        Me.Controls.Add(Me.PBRecapitulatif)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LCode)
        Me.Controls.Add(Me.BDelMachine)
        Me.Controls.Add(Me.TBMachine)
        Me.Controls.Add(Me.LMachine)
        Me.Controls.Add(Me.LTitre)
        Me.Name = "frmArretMachine"
        Me.Text = "Arrêt Machine"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents LMachine As System.Windows.Forms.Label
    Friend WithEvents TBMachine As System.Windows.Forms.TextBox
    Friend WithEvents BDelMachine As System.Windows.Forms.Button
    Friend WithEvents LCode As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents PBRecapitulatif As System.Windows.Forms.PictureBox
    Friend WithEvents BValider As System.Windows.Forms.Button
    Friend WithEvents TBCode As System.Windows.Forms.TextBox
    Friend WithEvents TBCode2 As System.Windows.Forms.TextBox
    Friend WithEvents TBCode3 As System.Windows.Forms.TextBox
    Friend WithEvents TBHeure As System.Windows.Forms.TextBox
    Friend WithEvents TBHeure2 As System.Windows.Forms.TextBox
    Friend WithEvents TBHeure3 As System.Windows.Forms.TextBox
    Friend WithEvents BDelLigne As System.Windows.Forms.Button
    Friend WithEvents BDelLigne2 As System.Windows.Forms.Button
    Friend WithEvents BDelLigne3 As System.Windows.Forms.Button
    Friend WithEvents PBAddCode As System.Windows.Forms.PictureBox
End Class
