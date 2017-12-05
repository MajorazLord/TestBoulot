<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmOptions
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
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.BReset = New System.Windows.Forms.Button
        Me.BUpload = New System.Windows.Forms.Button
        Me.LTitre = New System.Windows.Forms.Label
        Me.BParametre = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BReset
        '
        Me.BReset.BackColor = System.Drawing.Color.Red
        Me.BReset.Font = New System.Drawing.Font("Segoe Condensed", 15.0!, System.Drawing.FontStyle.Bold)
        Me.BReset.Location = New System.Drawing.Point(3, 50)
        Me.BReset.Name = "BReset"
        Me.BReset.Size = New System.Drawing.Size(234, 48)
        Me.BReset.TabIndex = 1
        Me.BReset.Text = "Redémarrer douchette"
        '
        'BUpload
        '
        Me.BUpload.BackColor = System.Drawing.Color.Chartreuse
        Me.BUpload.Font = New System.Drawing.Font("Segoe Condensed", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BUpload.Location = New System.Drawing.Point(3, 105)
        Me.BUpload.Name = "BUpload"
        Me.BUpload.Size = New System.Drawing.Size(234, 48)
        Me.BUpload.TabIndex = 2
        Me.BUpload.Text = "Remonter données"
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.DodgerBlue
        Me.LTitre.Location = New System.Drawing.Point(0, 8)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(237, 37)
        Me.LTitre.Text = "Options"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BParametre
        '
        Me.BParametre.BackColor = System.Drawing.Color.Chartreuse
        Me.BParametre.Font = New System.Drawing.Font("Segoe Condensed", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BParametre.Location = New System.Drawing.Point(3, 160)
        Me.BParametre.Name = "BParametre"
        Me.BParametre.Size = New System.Drawing.Size(234, 48)
        Me.BParametre.TabIndex = 5
        Me.BParametre.Text = "Paramètres"
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BParametre)
        Me.Controls.Add(Me.LTitre)
        Me.Controls.Add(Me.BUpload)
        Me.Controls.Add(Me.BReset)
        Me.Controls.Add(Me.PBRetour)
        Me.KeyPreview = True
        Me.Name = "frmOptions"
        Me.Text = "Options"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents BReset As System.Windows.Forms.Button
    Friend WithEvents BUpload As System.Windows.Forms.Button
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents BParametre As System.Windows.Forms.Button
End Class
