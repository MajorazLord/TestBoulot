<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCreerOF
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
        Me.TBOF = New System.Windows.Forms.TextBox
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.btajouter = New System.Windows.Forms.Button
        Me.BDelOF = New System.Windows.Forms.Button
        Me.LblOF = New System.Windows.Forms.Label
        Me.LblTitre = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TBOF
        '
        Me.TBOF.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.TBOF.Location = New System.Drawing.Point(7, 110)
        Me.TBOF.Name = "TBOF"
        Me.TBOF.Size = New System.Drawing.Size(188, 32)
        Me.TBOF.TabIndex = 0
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'btajouter
        '
        Me.btajouter.BackColor = System.Drawing.Color.Lime
        Me.btajouter.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.btajouter.Location = New System.Drawing.Point(75, 228)
        Me.btajouter.Name = "btajouter"
        Me.btajouter.Size = New System.Drawing.Size(162, 66)
        Me.btajouter.TabIndex = 7
        Me.btajouter.Text = "Ajouter"
        '
        'BDelOF
        '
        Me.BDelOF.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelOF.Location = New System.Drawing.Point(202, 110)
        Me.BDelOF.Name = "BDelOF"
        Me.BDelOF.Size = New System.Drawing.Size(36, 32)
        Me.BDelOF.TabIndex = 8
        Me.BDelOF.Text = "X"
        '
        'LblOF
        '
        Me.LblOF.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LblOF.Location = New System.Drawing.Point(7, 63)
        Me.LblOF.Name = "LblOF"
        Me.LblOF.Size = New System.Drawing.Size(231, 44)
        Me.LblOF.Text = "Scan partie détachable ou saisie du numéro d'OF:"
        '
        'LblTitre
        '
        Me.LblTitre.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitre.ForeColor = System.Drawing.Color.LimeGreen
        Me.LblTitre.Location = New System.Drawing.Point(5, 4)
        Me.LblTitre.Name = "LblTitre"
        Me.LblTitre.Size = New System.Drawing.Size(230, 28)
        Me.LblTitre.Text = "Ajout d'un OF"
        Me.LblTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmCreerOF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LblTitre)
        Me.Controls.Add(Me.LblOF)
        Me.Controls.Add(Me.BDelOF)
        Me.Controls.Add(Me.btajouter)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.TBOF)
        Me.Name = "frmCreerOF"
        Me.Text = "Creation OF"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TBOF As System.Windows.Forms.TextBox
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents btajouter As System.Windows.Forms.Button
    Friend WithEvents BDelOF As System.Windows.Forms.Button
    Friend WithEvents LblOF As System.Windows.Forms.Label
    Friend WithEvents LblTitre As System.Windows.Forms.Label
End Class
