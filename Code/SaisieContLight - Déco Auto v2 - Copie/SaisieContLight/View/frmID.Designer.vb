<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmID
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
        Me.LNumID = New System.Windows.Forms.Label
        Me.TBNumID = New System.Windows.Forms.TextBox
        Me.BDelNumID = New System.Windows.Forms.Button
        Me.LNumIDAide = New System.Windows.Forms.Label
        Me.TBNumIDAide = New System.Windows.Forms.TextBox
        Me.BDelNumIDAide = New System.Windows.Forms.Button
        Me.PBOption = New System.Windows.Forms.PictureBox
        Me.BStart = New System.Windows.Forms.Button
        Me.LPoste = New System.Windows.Forms.Label
        Me.CBPoste = New System.Windows.Forms.ComboBox
        Me.TBNumIDAide2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.Red
        Me.LTitre.Location = New System.Drawing.Point(0, 4)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 30)
        Me.LTitre.Text = "Saisie au contenant"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LNumID
        '
        Me.LNumID.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LNumID.Location = New System.Drawing.Point(13, 40)
        Me.LNumID.Name = "LNumID"
        Me.LNumID.Size = New System.Drawing.Size(219, 28)
        Me.LNumID.Text = "Numéro de pointage:"
        '
        'TBNumID
        '
        Me.TBNumID.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumID.Location = New System.Drawing.Point(13, 70)
        Me.TBNumID.Multiline = True
        Me.TBNumID.Name = "TBNumID"
        Me.TBNumID.Size = New System.Drawing.Size(168, 35)
        Me.TBNumID.TabIndex = 1
        '
        'BDelNumID
        '
        Me.BDelNumID.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelNumID.Location = New System.Drawing.Point(187, 70)
        Me.BDelNumID.Name = "BDelNumID"
        Me.BDelNumID.Size = New System.Drawing.Size(39, 35)
        Me.BDelNumID.TabIndex = 4
        Me.BDelNumID.Text = "X"
        '
        'LNumIDAide
        '
        Me.LNumIDAide.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Italic)
        Me.LNumIDAide.Location = New System.Drawing.Point(12, 111)
        Me.LNumIDAide.Name = "LNumIDAide"
        Me.LNumIDAide.Size = New System.Drawing.Size(212, 24)
        Me.LNumIDAide.Text = "Pointage aide (optionnel): "
        '
        'TBNumIDAide
        '
        Me.TBNumIDAide.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumIDAide.Location = New System.Drawing.Point(12, 138)
        Me.TBNumIDAide.Multiline = True
        Me.TBNumIDAide.Name = "TBNumIDAide"
        Me.TBNumIDAide.Size = New System.Drawing.Size(84, 30)
        Me.TBNumIDAide.TabIndex = 2
        '
        'BDelNumIDAide
        '
        Me.BDelNumIDAide.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelNumIDAide.Location = New System.Drawing.Point(194, 138)
        Me.BDelNumIDAide.Name = "BDelNumIDAide"
        Me.BDelNumIDAide.Size = New System.Drawing.Size(39, 30)
        Me.BDelNumIDAide.TabIndex = 5
        Me.BDelNumIDAide.Text = "X"
        '
        'PBOption
        '
        Me.PBOption.Location = New System.Drawing.Point(15, 175)
        Me.PBOption.Name = "PBOption"
        Me.PBOption.Size = New System.Drawing.Size(62, 62)
        Me.PBOption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BStart
        '
        Me.BStart.BackColor = System.Drawing.Color.Lime
        Me.BStart.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BStart.Location = New System.Drawing.Point(2, 243)
        Me.BStart.Name = "BStart"
        Me.BStart.Size = New System.Drawing.Size(236, 51)
        Me.BStart.TabIndex = 6
        Me.BStart.Text = "Commencer"
        '
        'LPoste
        '
        Me.LPoste.Font = New System.Drawing.Font("Tahoma", 13.0!, System.Drawing.FontStyle.Regular)
        Me.LPoste.Location = New System.Drawing.Point(113, 179)
        Me.LPoste.Name = "LPoste"
        Me.LPoste.Size = New System.Drawing.Size(72, 20)
        Me.LPoste.Text = "Poste:"
        '
        'CBPoste
        '
        Me.CBPoste.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.CBPoste.Location = New System.Drawing.Point(115, 202)
        Me.CBPoste.Name = "CBPoste"
        Me.CBPoste.Size = New System.Drawing.Size(103, 30)
        Me.CBPoste.TabIndex = 11
        '
        'TBNumIDAide2
        '
        Me.TBNumIDAide2.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumIDAide2.Location = New System.Drawing.Point(102, 138)
        Me.TBNumIDAide2.MaxLength = 10
        Me.TBNumIDAide2.Multiline = True
        Me.TBNumIDAide2.Name = "TBNumIDAide2"
        Me.TBNumIDAide2.Size = New System.Drawing.Size(84, 30)
        Me.TBNumIDAide2.TabIndex = 3
        '
        'frmID
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.TBNumIDAide2)
        Me.Controls.Add(Me.CBPoste)
        Me.Controls.Add(Me.LPoste)
        Me.Controls.Add(Me.BStart)
        Me.Controls.Add(Me.PBOption)
        Me.Controls.Add(Me.BDelNumIDAide)
        Me.Controls.Add(Me.TBNumIDAide)
        Me.Controls.Add(Me.LNumIDAide)
        Me.Controls.Add(Me.BDelNumID)
        Me.Controls.Add(Me.TBNumID)
        Me.Controls.Add(Me.LNumID)
        Me.Controls.Add(Me.LTitre)
        Me.KeyPreview = True
        Me.Name = "frmID"
        Me.Text = "Démarrage"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents LNumID As System.Windows.Forms.Label
    Friend WithEvents TBNumID As System.Windows.Forms.TextBox
    Friend WithEvents BDelNumID As System.Windows.Forms.Button
    Friend WithEvents LNumIDAide As System.Windows.Forms.Label
    Friend WithEvents TBNumIDAide As System.Windows.Forms.TextBox
    Friend WithEvents BDelNumIDAide As System.Windows.Forms.Button
    Friend WithEvents PBOption As System.Windows.Forms.PictureBox
    Friend WithEvents BStart As System.Windows.Forms.Button
    Friend WithEvents LPoste As System.Windows.Forms.Label
    Friend WithEvents CBPoste As System.Windows.Forms.ComboBox
    Friend WithEvents TBNumIDAide2 As System.Windows.Forms.TextBox
End Class
