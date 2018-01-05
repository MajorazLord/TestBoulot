<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRecapContenantsBloque
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
        Me.LblRecap = New System.Windows.Forms.Label
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.DGContenantBloque = New System.Windows.Forms.DataGrid
        Me.SuspendLayout()
        '
        'LblRecap
        '
        Me.LblRecap.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblRecap.ForeColor = System.Drawing.Color.Orange
        Me.LblRecap.Location = New System.Drawing.Point(17, 1)
        Me.LblRecap.Name = "LblRecap"
        Me.LblRecap.Size = New System.Drawing.Size(208, 46)
        Me.LblRecap.Text = "Récap contenants bloqués"
        Me.LblRecap.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 227)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'DGContenantBloque
        '
        Me.DGContenantBloque.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGContenantBloque.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.DGContenantBloque.Location = New System.Drawing.Point(0, 50)
        Me.DGContenantBloque.Name = "DGContenantBloque"
        Me.DGContenantBloque.PreferredRowHeight = 25
        Me.DGContenantBloque.RowHeadersVisible = False
        Me.DGContenantBloque.Size = New System.Drawing.Size(240, 171)
        Me.DGContenantBloque.TabIndex = 5
        '
        'frmRecapContenantsBloque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LblRecap)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.DGContenantBloque)
        Me.Name = "frmRecapContenantsBloque"
        Me.Text = "Récap cont. bloqués"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblRecap As System.Windows.Forms.Label
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents DGContenantBloque As System.Windows.Forms.DataGrid
End Class
