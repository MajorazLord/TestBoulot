<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmUpload
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
        Me.LblTitre = New System.Windows.Forms.Label
        Me.BAfter = New System.Windows.Forms.Button
        Me.PBWIFI = New System.Windows.Forms.PictureBox
        Me.LblWifi = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LblTitre
        '
        Me.LblTitre.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitre.ForeColor = System.Drawing.Color.Orange
        Me.LblTitre.Location = New System.Drawing.Point(14, 4)
        Me.LblTitre.Name = "LblTitre"
        Me.LblTitre.Size = New System.Drawing.Size(214, 54)
        Me.LblTitre.Text = "Envoi des données via..."
        Me.LblTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BAfter
        '
        Me.BAfter.BackColor = System.Drawing.Color.Red
        Me.BAfter.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BAfter.Location = New System.Drawing.Point(3, 251)
        Me.BAfter.Name = "BAfter"
        Me.BAfter.Size = New System.Drawing.Size(234, 43)
        Me.BAfter.TabIndex = 1
        Me.BAfter.Text = "Plus tard..."
        '
        'PBWIFI
        '
        Me.PBWIFI.Location = New System.Drawing.Point(63, 84)
        Me.PBWIFI.Name = "PBWIFI"
        Me.PBWIFI.Size = New System.Drawing.Size(113, 107)
        Me.PBWIFI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LblWifi
        '
        Me.LblWifi.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LblWifi.Location = New System.Drawing.Point(88, 194)
        Me.LblWifi.Name = "LblWifi"
        Me.LblWifi.Size = New System.Drawing.Size(60, 20)
        Me.LblWifi.Text = "WIFI"
        Me.LblWifi.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmUpload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LblWifi)
        Me.Controls.Add(Me.PBWIFI)
        Me.Controls.Add(Me.BAfter)
        Me.Controls.Add(Me.LblTitre)
        Me.KeyPreview = True
        Me.Name = "frmUpload"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblTitre As System.Windows.Forms.Label
    Friend WithEvents BAfter As System.Windows.Forms.Button
    Friend WithEvents PBWIFI As System.Windows.Forms.PictureBox
    Friend WithEvents LblWifi As System.Windows.Forms.Label
End Class
