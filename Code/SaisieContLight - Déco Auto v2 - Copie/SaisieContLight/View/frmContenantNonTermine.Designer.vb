<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmContenantNonTermine
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
        Me.LNumEtiq = New System.Windows.Forms.Label
        Me.TBNumEtiq = New System.Windows.Forms.TextBox
        Me.BDelNumEtiq = New System.Windows.Forms.Button
        Me.LQuantite = New System.Windows.Forms.Label
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.PBRecapitulatif = New System.Windows.Forms.PictureBox
        Me.BValider = New System.Windows.Forms.Button
        Me.TBQuantite = New System.Windows.Forms.TextBox
        Me.BDelQuantite = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.Blue
        Me.LTitre.Location = New System.Drawing.Point(0, 6)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 21)
        Me.LTitre.Text = "Quantité Fin de Poste"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LMachine
        '
        Me.LMachine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LMachine.Location = New System.Drawing.Point(7, 33)
        Me.LMachine.Name = "LMachine"
        Me.LMachine.Size = New System.Drawing.Size(224, 23)
        Me.LMachine.Text = "Scan N° Machine (ou table):"
        '
        'TBMachine
        '
        Me.TBMachine.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.TBMachine.Location = New System.Drawing.Point(7, 59)
        Me.TBMachine.Multiline = True
        Me.TBMachine.Name = "TBMachine"
        Me.TBMachine.Size = New System.Drawing.Size(179, 32)
        Me.TBMachine.TabIndex = 1
        '
        'BDelMachine
        '
        Me.BDelMachine.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BDelMachine.Location = New System.Drawing.Point(192, 59)
        Me.BDelMachine.Name = "BDelMachine"
        Me.BDelMachine.Size = New System.Drawing.Size(39, 32)
        Me.BDelMachine.TabIndex = 2
        Me.BDelMachine.Text = "X"
        '
        'LNumEtiq
        '
        Me.LNumEtiq.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LNumEtiq.Location = New System.Drawing.Point(7, 99)
        Me.LNumEtiq.Name = "LNumEtiq"
        Me.LNumEtiq.Size = New System.Drawing.Size(224, 20)
        Me.LNumEtiq.Text = "Scan Partie Détachable:"
        '
        'TBNumEtiq
        '
        Me.TBNumEtiq.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumEtiq.Location = New System.Drawing.Point(7, 122)
        Me.TBNumEtiq.Multiline = True
        Me.TBNumEtiq.Name = "TBNumEtiq"
        Me.TBNumEtiq.Size = New System.Drawing.Size(179, 32)
        Me.TBNumEtiq.TabIndex = 3
        '
        'BDelNumEtiq
        '
        Me.BDelNumEtiq.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BDelNumEtiq.Location = New System.Drawing.Point(192, 122)
        Me.BDelNumEtiq.Name = "BDelNumEtiq"
        Me.BDelNumEtiq.Size = New System.Drawing.Size(39, 32)
        Me.BDelNumEtiq.TabIndex = 4
        Me.BDelNumEtiq.Text = "X"
        '
        'LQuantite
        '
        Me.LQuantite.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LQuantite.Location = New System.Drawing.Point(7, 162)
        Me.LQuantite.Name = "LQuantite"
        Me.LQuantite.Size = New System.Drawing.Size(224, 20)
        Me.LQuantite.Text = "Saisir Quantité Fin de Poste:"
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
        Me.BValider.TabIndex = 7
        Me.BValider.Text = "Valider"
        '
        'TBQuantite
        '
        Me.TBQuantite.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.TBQuantite.Location = New System.Drawing.Point(7, 185)
        Me.TBQuantite.Multiline = True
        Me.TBQuantite.Name = "TBQuantite"
        Me.TBQuantite.Size = New System.Drawing.Size(179, 32)
        Me.TBQuantite.TabIndex = 5
        '
        'BDelQuantite
        '
        Me.BDelQuantite.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BDelQuantite.Location = New System.Drawing.Point(192, 185)
        Me.BDelQuantite.Name = "BDelQuantite"
        Me.BDelQuantite.Size = New System.Drawing.Size(39, 32)
        Me.BDelQuantite.TabIndex = 6
        Me.BDelQuantite.Text = "X"
        '
        'frmContenantNonTermine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BDelQuantite)
        Me.Controls.Add(Me.TBQuantite)
        Me.Controls.Add(Me.BValider)
        Me.Controls.Add(Me.PBRecapitulatif)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.LQuantite)
        Me.Controls.Add(Me.BDelNumEtiq)
        Me.Controls.Add(Me.TBNumEtiq)
        Me.Controls.Add(Me.LNumEtiq)
        Me.Controls.Add(Me.BDelMachine)
        Me.Controls.Add(Me.TBMachine)
        Me.Controls.Add(Me.LMachine)
        Me.Controls.Add(Me.LTitre)
        Me.Name = "frmContenantNonTermine"
        Me.Text = "Quantité Fin Poste"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents LMachine As System.Windows.Forms.Label
    Friend WithEvents TBMachine As System.Windows.Forms.TextBox
    Friend WithEvents BDelMachine As System.Windows.Forms.Button
    Friend WithEvents LNumEtiq As System.Windows.Forms.Label
    Friend WithEvents TBNumEtiq As System.Windows.Forms.TextBox
    Friend WithEvents BDelNumEtiq As System.Windows.Forms.Button
    Friend WithEvents LQuantite As System.Windows.Forms.Label
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents PBRecapitulatif As System.Windows.Forms.PictureBox
    Friend WithEvents BValider As System.Windows.Forms.Button
    Friend WithEvents TBQuantite As System.Windows.Forms.TextBox
    Friend WithEvents BDelQuantite As System.Windows.Forms.Button
End Class
