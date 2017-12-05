<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDemandeOF
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
        Me.LbOF = New System.Windows.Forms.Label
        Me.BOK = New System.Windows.Forms.Button
        Me.BAnnuler = New System.Windows.Forms.Button
        Me.TBOF = New System.Windows.Forms.TextBox
        Me.BDelOF = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LbOF
        '
        Me.LbOF.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LbOF.Location = New System.Drawing.Point(38, 0)
        Me.LbOF.Name = "LbOF"
        Me.LbOF.Size = New System.Drawing.Size(125, 20)
        Me.LbOF.Text = "Numéro d'OF:"
        Me.LbOF.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BOK
        '
        Me.BOK.BackColor = System.Drawing.Color.Lime
        Me.BOK.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BOK.Location = New System.Drawing.Point(114, 63)
        Me.BOK.Name = "BOK"
        Me.BOK.Size = New System.Drawing.Size(84, 39)
        Me.BOK.TabIndex = 1
        Me.BOK.Text = "Valider"
        '
        'BAnnuler
        '
        Me.BAnnuler.BackColor = System.Drawing.Color.Red
        Me.BAnnuler.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BAnnuler.Location = New System.Drawing.Point(3, 63)
        Me.BAnnuler.Name = "BAnnuler"
        Me.BAnnuler.Size = New System.Drawing.Size(84, 39)
        Me.BAnnuler.TabIndex = 2
        Me.BAnnuler.Text = "Annuler"
        '
        'TBOF
        '
        Me.TBOF.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBOF.Location = New System.Drawing.Point(22, 28)
        Me.TBOF.Name = "TBOF"
        Me.TBOF.Size = New System.Drawing.Size(114, 29)
        Me.TBOF.TabIndex = 3
        '
        'BDelOF
        '
        Me.BDelOF.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelOF.Location = New System.Drawing.Point(142, 28)
        Me.BDelOF.Name = "BDelOF"
        Me.BDelOF.Size = New System.Drawing.Size(36, 29)
        Me.BDelOF.TabIndex = 9
        Me.BDelOF.Text = "X"
        '
        'frmDemandeOF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.ClientSize = New System.Drawing.Size(205, 113)
        Me.Controls.Add(Me.BDelOF)
        Me.Controls.Add(Me.TBOF)
        Me.Controls.Add(Me.BAnnuler)
        Me.Controls.Add(Me.BOK)
        Me.Controls.Add(Me.LbOF)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(27, 90)
        Me.Name = "frmDemandeOF"
        Me.Text = "frmDemandeOF"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LbOF As System.Windows.Forms.Label
    Friend WithEvents BOK As System.Windows.Forms.Button
    Friend WithEvents BAnnuler As System.Windows.Forms.Button
    Friend WithEvents TBOF As System.Windows.Forms.TextBox
    Friend WithEvents BDelOF As System.Windows.Forms.Button
End Class
