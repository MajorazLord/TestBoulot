<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmHelp
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
        Me.DGHelp = New System.Windows.Forms.DataGrid
        Me.BChoisir = New System.Windows.Forms.Button
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.Red
        Me.LTitre.Location = New System.Drawing.Point(0, 0)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 52)
        Me.LTitre.Text = "Correspondance code/désignation"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'DGHelp
        '
        Me.DGHelp.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGHelp.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular)
        Me.DGHelp.Location = New System.Drawing.Point(0, 55)
        Me.DGHelp.Name = "DGHelp"
        Me.DGHelp.RowHeadersVisible = False
        Me.DGHelp.Size = New System.Drawing.Size(240, 167)
        Me.DGHelp.TabIndex = 1
        '
        'BChoisir
        '
        Me.BChoisir.BackColor = System.Drawing.Color.Lime
        Me.BChoisir.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BChoisir.Location = New System.Drawing.Point(75, 228)
        Me.BChoisir.Name = "BChoisir"
        Me.BChoisir.Size = New System.Drawing.Size(162, 66)
        Me.BChoisir.TabIndex = 2
        Me.BChoisir.Text = "Choisir"
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.BChoisir)
        Me.Controls.Add(Me.DGHelp)
        Me.Controls.Add(Me.LTitre)
        Me.Name = "frmHelp"
        Me.Text = "Code/Désignation"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents DGHelp As System.Windows.Forms.DataGrid
    Friend WithEvents BChoisir As System.Windows.Forms.Button
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
End Class
