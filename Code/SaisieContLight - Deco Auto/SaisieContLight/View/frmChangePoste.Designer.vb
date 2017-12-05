<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmChangePoste
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePoste))
        Me.CBPoste = New System.Windows.Forms.ComboBox
        Me.LPosteDispo = New System.Windows.Forms.Label
        Me.LPoste = New System.Windows.Forms.Label
        Me.LCurrentPoste = New System.Windows.Forms.Label
        Me.LTitrePoste = New System.Windows.Forms.Label
        Me.BModifier = New System.Windows.Forms.Button
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'CBPoste
        '
        Me.CBPoste.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.CBPoste.Location = New System.Drawing.Point(51, 158)
        Me.CBPoste.Name = "CBPoste"
        Me.CBPoste.Size = New System.Drawing.Size(141, 30)
        Me.CBPoste.TabIndex = 13
        '
        'LPosteDispo
        '
        Me.LPosteDispo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LPosteDispo.Location = New System.Drawing.Point(27, 126)
        Me.LPosteDispo.Name = "LPosteDispo"
        Me.LPosteDispo.Size = New System.Drawing.Size(182, 20)
        Me.LPosteDispo.Text = "Postes disponibles:"
        Me.LPosteDispo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LPoste
        '
        Me.LPoste.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LPoste.Location = New System.Drawing.Point(4, 74)
        Me.LPoste.Name = "LPoste"
        Me.LPoste.Size = New System.Drawing.Size(232, 40)
        Me.LPoste.Text = "Poste"
        Me.LPoste.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LCurrentPoste
        '
        Me.LCurrentPoste.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LCurrentPoste.Location = New System.Drawing.Point(4, 40)
        Me.LCurrentPoste.Name = "LCurrentPoste"
        Me.LCurrentPoste.Size = New System.Drawing.Size(232, 20)
        Me.LCurrentPoste.Text = "Poste actuel:"
        Me.LCurrentPoste.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LTitrePoste
        '
        Me.LTitrePoste.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LTitrePoste.ForeColor = System.Drawing.Color.Peru
        Me.LTitrePoste.Location = New System.Drawing.Point(0, 4)
        Me.LTitrePoste.Name = "LTitrePoste"
        Me.LTitrePoste.Size = New System.Drawing.Size(240, 32)
        Me.LTitrePoste.Text = "Modifier le poste"
        Me.LTitrePoste.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BModifier
        '
        Me.BModifier.BackColor = System.Drawing.Color.Lime
        Me.BModifier.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BModifier.Location = New System.Drawing.Point(78, 225)
        Me.BModifier.Name = "BModifier"
        Me.BModifier.Size = New System.Drawing.Size(162, 66)
        Me.BModifier.TabIndex = 19
        Me.BModifier.Text = "Modifier"
        '
        'PBRetour
        '
        Me.PBRetour.Image = CType(resources.GetObject("PBRetour.Image"), System.Drawing.Image)
        Me.PBRetour.Location = New System.Drawing.Point(3, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmChangePoste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BModifier)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.CBPoste)
        Me.Controls.Add(Me.LPosteDispo)
        Me.Controls.Add(Me.LPoste)
        Me.Controls.Add(Me.LCurrentPoste)
        Me.Controls.Add(Me.LTitrePoste)
        Me.Name = "frmChangePoste"
        Me.Text = "Changer poste"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CBPoste As System.Windows.Forms.ComboBox
    Friend WithEvents LPosteDispo As System.Windows.Forms.Label
    Friend WithEvents LPoste As System.Windows.Forms.Label
    Friend WithEvents LCurrentPoste As System.Windows.Forms.Label
    Friend WithEvents LTitrePoste As System.Windows.Forms.Label
    Friend WithEvents BModifier As System.Windows.Forms.Button
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
End Class
