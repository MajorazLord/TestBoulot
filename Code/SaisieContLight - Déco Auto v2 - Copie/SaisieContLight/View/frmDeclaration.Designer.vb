<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDeclaration
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
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.BRebuts = New System.Windows.Forms.Button
        Me.BContenantNT = New System.Windows.Forms.Button
        Me.LbIdOperateur = New System.Windows.Forms.Label
        Me.BContenantBloque = New System.Windows.Forms.Button
        Me.BTempsProduction = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PBRetour.Tag = ""
        '
        'BRebuts
        '
        Me.BRebuts.BackColor = System.Drawing.Color.Red
        Me.BRebuts.Font = New System.Drawing.Font("Segoe Condensed", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BRebuts.Location = New System.Drawing.Point(3, 31)
        Me.BRebuts.Name = "BRebuts"
        Me.BRebuts.Size = New System.Drawing.Size(234, 40)
        Me.BRebuts.TabIndex = 1
        Me.BRebuts.Text = "Pièces écartées"
        '
        'BContenantNT
        '
        Me.BContenantNT.BackColor = System.Drawing.Color.DodgerBlue
        Me.BContenantNT.Font = New System.Drawing.Font("Segoe Condensed", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BContenantNT.Location = New System.Drawing.Point(3, 77)
        Me.BContenantNT.Name = "BContenantNT"
        Me.BContenantNT.Size = New System.Drawing.Size(234, 40)
        Me.BContenantNT.TabIndex = 3
        Me.BContenantNT.Text = "Quantité Fin de Poste"
        '
        'LbIdOperateur
        '
        Me.LbIdOperateur.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LbIdOperateur.Location = New System.Drawing.Point(3, 0)
        Me.LbIdOperateur.Name = "LbIdOperateur"
        Me.LbIdOperateur.Size = New System.Drawing.Size(234, 28)
        Me.LbIdOperateur.Text = "Id Opérateur"
        Me.LbIdOperateur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BContenantBloque
        '
        Me.BContenantBloque.BackColor = System.Drawing.Color.Orange
        Me.BContenantBloque.Font = New System.Drawing.Font("Segoe Condensed", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BContenantBloque.Location = New System.Drawing.Point(3, 169)
        Me.BContenantBloque.Name = "BContenantBloque"
        Me.BContenantBloque.Size = New System.Drawing.Size(234, 40)
        Me.BContenantBloque.TabIndex = 2
        Me.BContenantBloque.Text = "Contenants bloqués"
        Me.BContenantBloque.Visible = False
        '
        'BTempsProduction
        '
        Me.BTempsProduction.BackColor = System.Drawing.Color.Chocolate
        Me.BTempsProduction.Font = New System.Drawing.Font("Segoe Condensed", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BTempsProduction.Location = New System.Drawing.Point(3, 123)
        Me.BTempsProduction.Name = "BTempsProduction"
        Me.BTempsProduction.Size = New System.Drawing.Size(234, 40)
        Me.BTempsProduction.TabIndex = 5
        Me.BTempsProduction.Text = "Temps de production"
        '
        'frmDeclaration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BTempsProduction)
        Me.Controls.Add(Me.BContenantBloque)
        Me.Controls.Add(Me.LbIdOperateur)
        Me.Controls.Add(Me.BContenantNT)
        Me.Controls.Add(Me.BRebuts)
        Me.Controls.Add(Me.PBRetour)
        Me.Name = "frmDeclaration"
        Me.Text = "Declarations"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents BRebuts As System.Windows.Forms.Button
    Friend WithEvents BContenantNT As System.Windows.Forms.Button
    Friend WithEvents LbIdOperateur As System.Windows.Forms.Label
    Friend WithEvents BContenantBloque As System.Windows.Forms.Button
    Friend WithEvents BTempsProduction As System.Windows.Forms.Button
End Class
