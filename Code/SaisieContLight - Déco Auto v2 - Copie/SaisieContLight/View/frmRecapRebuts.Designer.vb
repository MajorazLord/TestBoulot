<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRecapRebuts
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
        Me.DGRebut = New System.Windows.Forms.DataGrid
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.BDelLigne = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.Goldenrod
        Me.LTitre.Location = New System.Drawing.Point(0, 0)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 27)
        Me.LTitre.Text = "Récap pièces écartées"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DGRebut
        '
        Me.DGRebut.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGRebut.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.DGRebut.Location = New System.Drawing.Point(0, 30)
        Me.DGRebut.Name = "DGRebut"
        Me.DGRebut.RowHeadersVisible = False
        Me.DGRebut.Size = New System.Drawing.Size(240, 192)
        Me.DGRebut.TabIndex = 1
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BDelLigne
        '
        Me.BDelLigne.BackColor = System.Drawing.Color.Red
        Me.BDelLigne.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne.Location = New System.Drawing.Point(75, 228)
        Me.BDelLigne.Name = "BDelLigne"
        Me.BDelLigne.Size = New System.Drawing.Size(162, 66)
        Me.BDelLigne.TabIndex = 3
        Me.BDelLigne.Text = "Supprimer la ligne"
        '
        'frmRecapRebuts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BDelLigne)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.DGRebut)
        Me.Controls.Add(Me.LTitre)
        Me.Name = "frmRecapRebuts"
        Me.Text = "Récap P. écartées"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents DGRebut As System.Windows.Forms.DataGrid
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents BDelLigne As System.Windows.Forms.Button
End Class
