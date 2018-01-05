<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmAddMachine
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
        Me.LTitreOF = New System.Windows.Forms.Label
        Me.LOF = New System.Windows.Forms.Label
        Me.LTitreMach = New System.Windows.Forms.Label
        Me.TBNumMach = New System.Windows.Forms.TextBox
        Me.BDelNumMach = New System.Windows.Forms.Button
        Me.BAddMach = New System.Windows.Forms.Button
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LTitre.Location = New System.Drawing.Point(0, 13)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 32)
        Me.LTitre.Text = "Ajout d'une machine"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LTitreOF
        '
        Me.LTitreOF.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreOF.Location = New System.Drawing.Point(15, 62)
        Me.LTitreOF.Name = "LTitreOF"
        Me.LTitreOF.Size = New System.Drawing.Size(118, 20)
        Me.LTitreOF.Text = "Numéro d'OF:"
        '
        'LOF
        '
        Me.LOF.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.LOF.Location = New System.Drawing.Point(139, 62)
        Me.LOF.Name = "LOF"
        Me.LOF.Size = New System.Drawing.Size(72, 20)
        Me.LOF.Text = "Num OF"
        '
        'LTitreMach
        '
        Me.LTitreMach.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreMach.Location = New System.Drawing.Point(3, 107)
        Me.LTitreMach.Name = "LTitreMach"
        Me.LTitreMach.Size = New System.Drawing.Size(234, 20)
        Me.LTitreMach.Text = "Scan N° Machine (ou table): "
        '
        'TBNumMach
        '
        Me.TBNumMach.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumMach.Location = New System.Drawing.Point(3, 139)
        Me.TBNumMach.Name = "TBNumMach"
        Me.TBNumMach.Size = New System.Drawing.Size(175, 31)
        Me.TBNumMach.TabIndex = 4
        '
        'BDelNumMach
        '
        Me.BDelNumMach.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelNumMach.Location = New System.Drawing.Point(184, 139)
        Me.BDelNumMach.Name = "BDelNumMach"
        Me.BDelNumMach.Size = New System.Drawing.Size(36, 31)
        Me.BDelNumMach.TabIndex = 5
        Me.BDelNumMach.Text = "X"
        '
        'BAddMach
        '
        Me.BAddMach.BackColor = System.Drawing.Color.Lime
        Me.BAddMach.Font = New System.Drawing.Font("Segoe Condensed", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BAddMach.Location = New System.Drawing.Point(77, 225)
        Me.BAddMach.Name = "BAddMach"
        Me.BAddMach.Size = New System.Drawing.Size(163, 66)
        Me.BAddMach.TabIndex = 6
        Me.BAddMach.Text = "Ajouter"
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(2, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmAddMachine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.BAddMach)
        Me.Controls.Add(Me.BDelNumMach)
        Me.Controls.Add(Me.TBNumMach)
        Me.Controls.Add(Me.LTitreMach)
        Me.Controls.Add(Me.LOF)
        Me.Controls.Add(Me.LTitreOF)
        Me.Controls.Add(Me.LTitre)
        Me.Name = "frmAddMachine"
        Me.Text = "Ajout d'une machine"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents LTitreOF As System.Windows.Forms.Label
    Friend WithEvents LOF As System.Windows.Forms.Label
    Friend WithEvents LTitreMach As System.Windows.Forms.Label
    Friend WithEvents TBNumMach As System.Windows.Forms.TextBox
    Friend WithEvents BDelNumMach As System.Windows.Forms.Button
    Friend WithEvents BAddMach As System.Windows.Forms.Button
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
End Class
