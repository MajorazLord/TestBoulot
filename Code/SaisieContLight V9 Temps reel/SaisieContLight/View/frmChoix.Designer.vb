<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmChoix
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
        Me.BFinPoste = New System.Windows.Forms.Button
        Me.BEntree = New System.Windows.Forms.Button
        Me.BSortie = New System.Windows.Forms.Button
        Me.BDeclaration = New System.Windows.Forms.Button
        Me.LbIdOperateur = New System.Windows.Forms.Label
        Me.BRecapSaisie = New System.Windows.Forms.Button
        Me.PBAddUser = New System.Windows.Forms.PictureBox
        Me.LWifi = New System.Windows.Forms.Label
        Me.PBox = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'BFinPoste
        '
        Me.BFinPoste.BackColor = System.Drawing.Color.Black
        Me.BFinPoste.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BFinPoste.ForeColor = System.Drawing.Color.White
        Me.BFinPoste.Location = New System.Drawing.Point(3, 251)
        Me.BFinPoste.Name = "BFinPoste"
        Me.BFinPoste.Size = New System.Drawing.Size(234, 43)
        Me.BFinPoste.TabIndex = 5
        Me.BFinPoste.Text = "Fin de poste"
        '
        'BEntree
        '
        Me.BEntree.BackColor = System.Drawing.Color.Yellow
        Me.BEntree.Font = New System.Drawing.Font("Segoe Condensed", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BEntree.Location = New System.Drawing.Point(3, 140)
        Me.BEntree.Name = "BEntree"
        Me.BEntree.Size = New System.Drawing.Size(234, 45)
        Me.BEntree.TabIndex = 3
        Me.BEntree.Text = "Entrée"
        '
        'BSortie
        '
        Me.BSortie.BackColor = System.Drawing.Color.LimeGreen
        Me.BSortie.Font = New System.Drawing.Font("Segoe Condensed", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BSortie.Location = New System.Drawing.Point(3, 89)
        Me.BSortie.Name = "BSortie"
        Me.BSortie.Size = New System.Drawing.Size(234, 45)
        Me.BSortie.TabIndex = 2
        Me.BSortie.Text = "Sortie"
        '
        'BDeclaration
        '
        Me.BDeclaration.BackColor = System.Drawing.Color.DodgerBlue
        Me.BDeclaration.Font = New System.Drawing.Font("Segoe Condensed", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BDeclaration.Location = New System.Drawing.Point(3, 37)
        Me.BDeclaration.Name = "BDeclaration"
        Me.BDeclaration.Size = New System.Drawing.Size(234, 45)
        Me.BDeclaration.TabIndex = 1
        Me.BDeclaration.Text = "Déclarations"
        '
        'LbIdOperateur
        '
        Me.LbIdOperateur.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LbIdOperateur.Location = New System.Drawing.Point(73, 1)
        Me.LbIdOperateur.Name = "LbIdOperateur"
        Me.LbIdOperateur.Size = New System.Drawing.Size(135, 34)
        Me.LbIdOperateur.Text = "Opérateur: pointage"
        Me.LbIdOperateur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BRecapSaisie
        '
        Me.BRecapSaisie.BackColor = System.Drawing.Color.Chocolate
        Me.BRecapSaisie.Font = New System.Drawing.Font("Segoe Condensed", 20.0!, System.Drawing.FontStyle.Bold)
        Me.BRecapSaisie.Location = New System.Drawing.Point(3, 191)
        Me.BRecapSaisie.Name = "BRecapSaisie"
        Me.BRecapSaisie.Size = New System.Drawing.Size(234, 45)
        Me.BRecapSaisie.TabIndex = 6
        Me.BRecapSaisie.Text = "Récap Saisie"
        '
        'PBAddUser
        '
        Me.PBAddUser.Location = New System.Drawing.Point(204, 1)
        Me.PBAddUser.Name = "PBAddUser"
        Me.PBAddUser.Size = New System.Drawing.Size(33, 33)
        Me.PBAddUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LWifi
        '
        Me.LWifi.Location = New System.Drawing.Point(4, 4)
        Me.LWifi.Name = "LWifi"
        Me.LWifi.Size = New System.Drawing.Size(76, 30)
        Me.LWifi.Text = "WIFI : "
        '
        'PBox
        '
        Me.PBox.BackColor = System.Drawing.Color.Transparent
        Me.PBox.Location = New System.Drawing.Point(45, 4)
        Me.PBox.Name = "PBox"
        Me.PBox.Size = New System.Drawing.Size(22, 18)
        Me.PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmChoix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.PBox)
        Me.Controls.Add(Me.LWifi)
        Me.Controls.Add(Me.PBAddUser)
        Me.Controls.Add(Me.BRecapSaisie)
        Me.Controls.Add(Me.BDeclaration)
        Me.Controls.Add(Me.BSortie)
        Me.Controls.Add(Me.BEntree)
        Me.Controls.Add(Me.BFinPoste)
        Me.Controls.Add(Me.LbIdOperateur)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "frmChoix"
        Me.Text = "Choix saisie"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BFinPoste As System.Windows.Forms.Button
    Friend WithEvents BEntree As System.Windows.Forms.Button
    Friend WithEvents BSortie As System.Windows.Forms.Button
    Friend WithEvents BDeclaration As System.Windows.Forms.Button
    Friend WithEvents LbIdOperateur As System.Windows.Forms.Label
    Friend WithEvents BRecapSaisie As System.Windows.Forms.Button
    Friend WithEvents PBAddUser As System.Windows.Forms.PictureBox
    Friend WithEvents LWifi As System.Windows.Forms.Label
    Friend WithEvents PBox As System.Windows.Forms.PictureBox
End Class
