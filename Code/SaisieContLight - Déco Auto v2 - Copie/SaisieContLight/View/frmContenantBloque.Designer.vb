<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmContenantBloque
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
        Me.LbTitre = New System.Windows.Forms.Label
        Me.BAjouter = New System.Windows.Forms.Button
        Me.PBListe = New System.Windows.Forms.PictureBox
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.DelNoetiq = New System.Windows.Forms.Button
        Me.TBNoetiq = New System.Windows.Forms.TextBox
        Me.LbPart = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LbTitre
        '
        Me.LbTitre.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LbTitre.ForeColor = System.Drawing.Color.Orange
        Me.LbTitre.Location = New System.Drawing.Point(0, 19)
        Me.LbTitre.Name = "LbTitre"
        Me.LbTitre.Size = New System.Drawing.Size(240, 28)
        Me.LbTitre.Text = "Contenants bloqués"
        Me.LbTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BAjouter
        '
        Me.BAjouter.BackColor = System.Drawing.Color.Lime
        Me.BAjouter.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.BAjouter.Location = New System.Drawing.Point(135, 228)
        Me.BAjouter.Name = "BAjouter"
        Me.BAjouter.Size = New System.Drawing.Size(102, 66)
        Me.BAjouter.TabIndex = 3
        Me.BAjouter.Text = "Valider"
        '
        'PBListe
        '
        Me.PBListe.Location = New System.Drawing.Point(75, 228)
        Me.PBListe.Name = "PBListe"
        Me.PBListe.Size = New System.Drawing.Size(54, 66)
        Me.PBListe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'DelNoetiq
        '
        Me.DelNoetiq.Font = New System.Drawing.Font("Tahoma", 22.0!, System.Drawing.FontStyle.Bold)
        Me.DelNoetiq.Location = New System.Drawing.Point(199, 110)
        Me.DelNoetiq.Name = "DelNoetiq"
        Me.DelNoetiq.Size = New System.Drawing.Size(39, 32)
        Me.DelNoetiq.TabIndex = 2
        Me.DelNoetiq.Text = "X"
        '
        'TBNoetiq
        '
        Me.TBNoetiq.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.TBNoetiq.Location = New System.Drawing.Point(3, 110)
        Me.TBNoetiq.Name = "TBNoetiq"
        Me.TBNoetiq.Size = New System.Drawing.Size(188, 32)
        Me.TBNoetiq.TabIndex = 1
        '
        'LbPart
        '
        Me.LbPart.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LbPart.Location = New System.Drawing.Point(3, 64)
        Me.LbPart.Name = "LbPart"
        Me.LbPart.Size = New System.Drawing.Size(237, 43)
        Me.LbPart.Text = "Scan partie détachable de l'étiquette du contenant plein:"
        '
        'frmContenantBloque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.DelNoetiq)
        Me.Controls.Add(Me.TBNoetiq)
        Me.Controls.Add(Me.LbPart)
        Me.Controls.Add(Me.BAjouter)
        Me.Controls.Add(Me.PBListe)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.LbTitre)
        Me.Name = "frmContenantBloque"
        Me.Text = "Contenant bloqué"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LbTitre As System.Windows.Forms.Label
    Friend WithEvents BAjouter As System.Windows.Forms.Button
    Friend WithEvents PBListe As System.Windows.Forms.PictureBox
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents DelNoetiq As System.Windows.Forms.Button
    Friend WithEvents TBNoetiq As System.Windows.Forms.TextBox
    Friend WithEvents LbPart As System.Windows.Forms.Label
End Class
