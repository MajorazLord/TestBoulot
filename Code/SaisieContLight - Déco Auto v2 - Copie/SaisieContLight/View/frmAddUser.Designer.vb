<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmAddUser
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
        Me.btvalid = New System.Windows.Forms.Button
        Me.TBNumIDAide2 = New System.Windows.Forms.TextBox
        Me.BDelNumIDAide = New System.Windows.Forms.Button
        Me.TBNumIDAide = New System.Windows.Forms.TextBox
        Me.LNumIDAide = New System.Windows.Forms.Label
        Me.LNumID = New System.Windows.Forms.Label
        Me.BDelNumAide2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.LNumPointage = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'btvalid
        '
        Me.btvalid.BackColor = System.Drawing.Color.Lime
        Me.btvalid.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btvalid.Location = New System.Drawing.Point(75, 225)
        Me.btvalid.Name = "btvalid"
        Me.btvalid.Size = New System.Drawing.Size(162, 66)
        Me.btvalid.TabIndex = 5
        Me.btvalid.Text = "Ajouter"
        '
        'TBNumIDAide2
        '
        Me.TBNumIDAide2.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumIDAide2.Location = New System.Drawing.Point(13, 175)
        Me.TBNumIDAide2.MaxLength = 10
        Me.TBNumIDAide2.Multiline = True
        Me.TBNumIDAide2.Name = "TBNumIDAide2"
        Me.TBNumIDAide2.Size = New System.Drawing.Size(168, 33)
        Me.TBNumIDAide2.TabIndex = 3
        '
        'BDelNumIDAide
        '
        Me.BDelNumIDAide.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelNumIDAide.Location = New System.Drawing.Point(187, 102)
        Me.BDelNumIDAide.Name = "BDelNumIDAide"
        Me.BDelNumIDAide.Size = New System.Drawing.Size(39, 33)
        Me.BDelNumIDAide.TabIndex = 2
        Me.BDelNumIDAide.Text = "X"
        '
        'TBNumIDAide
        '
        Me.TBNumIDAide.Font = New System.Drawing.Font("Tahoma", 15.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumIDAide.Location = New System.Drawing.Point(13, 102)
        Me.TBNumIDAide.Multiline = True
        Me.TBNumIDAide.Name = "TBNumIDAide"
        Me.TBNumIDAide.Size = New System.Drawing.Size(168, 33)
        Me.TBNumIDAide.TabIndex = 1
        '
        'LNumIDAide
        '
        Me.LNumIDAide.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LNumIDAide.Location = New System.Drawing.Point(13, 75)
        Me.LNumIDAide.Name = "LNumIDAide"
        Me.LNumIDAide.Size = New System.Drawing.Size(168, 24)
        Me.LNumIDAide.Text = "Pointage aide:"
        '
        'LNumID
        '
        Me.LNumID.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LNumID.Location = New System.Drawing.Point(13, 12)
        Me.LNumID.Name = "LNumID"
        Me.LNumID.Size = New System.Drawing.Size(219, 28)
        Me.LNumID.Text = "Opérateur actuel :"
        Me.LNumID.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BDelNumAide2
        '
        Me.BDelNumAide2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelNumAide2.Location = New System.Drawing.Point(187, 175)
        Me.BDelNumAide2.Name = "BDelNumAide2"
        Me.BDelNumAide2.Size = New System.Drawing.Size(39, 33)
        Me.BDelNumAide2.TabIndex = 4
        Me.BDelNumAide2.Text = "X"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.Label1.Location = New System.Drawing.Point(13, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 24)
        Me.Label1.Text = "Pointage aide bis:"
        '
        'LNumPointage
        '
        Me.LNumPointage.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LNumPointage.Location = New System.Drawing.Point(64, 40)
        Me.LNumPointage.Name = "LNumPointage"
        Me.LNumPointage.Size = New System.Drawing.Size(111, 35)
        Me.LNumPointage.Text = "pointage"
        Me.LNumPointage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LNumPointage)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BDelNumAide2)
        Me.Controls.Add(Me.TBNumIDAide2)
        Me.Controls.Add(Me.BDelNumIDAide)
        Me.Controls.Add(Me.TBNumIDAide)
        Me.Controls.Add(Me.LNumIDAide)
        Me.Controls.Add(Me.LNumID)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.btvalid)
        Me.Name = "frmAddUser"
        Me.Text = "Ajout utilisateur"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents btvalid As System.Windows.Forms.Button
    Friend WithEvents TBNumIDAide2 As System.Windows.Forms.TextBox
    Friend WithEvents BDelNumIDAide As System.Windows.Forms.Button
    Friend WithEvents TBNumIDAide As System.Windows.Forms.TextBox
    Friend WithEvents LNumIDAide As System.Windows.Forms.Label
    Friend WithEvents LNumID As System.Windows.Forms.Label
    Friend WithEvents BDelNumAide2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LNumPointage As System.Windows.Forms.Label
End Class
