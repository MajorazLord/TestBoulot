<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRecapContenantsNT
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
        Me.BDelete = New System.Windows.Forms.Button
        Me.DGContenant = New System.Windows.Forms.DataGrid
        Me.LblTitre = New System.Windows.Forms.Label
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'BDelete
        '
        Me.BDelete.BackColor = System.Drawing.Color.Red
        Me.BDelete.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BDelete.Location = New System.Drawing.Point(75, 228)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(162, 66)
        Me.BDelete.TabIndex = 8
        Me.BDelete.Text = "Supprimer la ligne"
        '
        'DGContenant
        '
        Me.DGContenant.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGContenant.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.DGContenant.Location = New System.Drawing.Point(0, 55)
        Me.DGContenant.Name = "DGContenant"
        Me.DGContenant.PreferredRowHeight = 25
        Me.DGContenant.RowHeadersVisible = False
        Me.DGContenant.Size = New System.Drawing.Size(240, 167)
        Me.DGContenant.TabIndex = 7
        '
        'LblTitre
        '
        Me.LblTitre.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitre.ForeColor = System.Drawing.Color.Blue
        Me.LblTitre.Location = New System.Drawing.Point(0, 0)
        Me.LblTitre.Name = "LblTitre"
        Me.LblTitre.Size = New System.Drawing.Size(240, 52)
        Me.LblTitre.Text = "Récap Quantité Fin de Poste"
        Me.LblTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmRecapContenantsNT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BDelete)
        Me.Controls.Add(Me.DGContenant)
        Me.Controls.Add(Me.LblTitre)
        Me.Controls.Add(Me.PBRetour)
        Me.Name = "frmRecapContenantsNT"
        Me.Text = "Récap contenants NT"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BDelete As System.Windows.Forms.Button
    Friend WithEvents DGContenant As System.Windows.Forms.DataGrid
    Friend WithEvents LblTitre As System.Windows.Forms.Label
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
End Class
