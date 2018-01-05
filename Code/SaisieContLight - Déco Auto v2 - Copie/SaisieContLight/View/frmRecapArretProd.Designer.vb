<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRecapArretProd
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
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.DGArret = New System.Windows.Forms.DataGrid
        Me.LblRecap = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'BDelete
        '
        Me.BDelete.BackColor = System.Drawing.Color.Red
        Me.BDelete.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BDelete.Location = New System.Drawing.Point(76, 225)
        Me.BDelete.Name = "BDelete"
        Me.BDelete.Size = New System.Drawing.Size(162, 66)
        Me.BDelete.TabIndex = 4
        Me.BDelete.Text = "Supprimer la ligne"
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(2, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'DGArret
        '
        Me.DGArret.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGArret.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.DGArret.Location = New System.Drawing.Point(0, 53)
        Me.DGArret.Name = "DGArret"
        Me.DGArret.PreferredRowHeight = 25
        Me.DGArret.RowHeadersVisible = False
        Me.DGArret.Size = New System.Drawing.Size(240, 167)
        Me.DGArret.TabIndex = 6
        '
        'LblRecap
        '
        Me.LblRecap.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblRecap.ForeColor = System.Drawing.Color.Blue
        Me.LblRecap.Location = New System.Drawing.Point(0, 1)
        Me.LblRecap.Name = "LblRecap"
        Me.LblRecap.Size = New System.Drawing.Size(240, 50)
        Me.LblRecap.Text = "Récap temps d'arrêt production"
        Me.LblRecap.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmRecapArretProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LblRecap)
        Me.Controls.Add(Me.DGArret)
        Me.Controls.Add(Me.BDelete)
        Me.Controls.Add(Me.PBRetour)
        Me.Name = "frmRecapArretProd"
        Me.Text = "Récap arret prod"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BDelete As System.Windows.Forms.Button
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents DGArret As System.Windows.Forms.DataGrid
    Friend WithEvents LblRecap As System.Windows.Forms.Label
End Class
