<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmChangeParam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangeParam))
        Me.LOperateur = New System.Windows.Forms.Label
        Me.LPoste = New System.Windows.Forms.Label
        Me.BAddUser = New System.Windows.Forms.Button
        Me.BModifPoste = New System.Windows.Forms.Button
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.LTitreOption = New System.Windows.Forms.Label
        Me.BReset2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.RbOui = New System.Windows.Forms.RadioButton
        Me.RbNon = New System.Windows.Forms.RadioButton
        Me.LbActiv = New System.Windows.Forms.Label
        Me.LbDesac = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'LOperateur
        '
        Me.LOperateur.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LOperateur.Location = New System.Drawing.Point(3, 26)
        Me.LOperateur.Name = "LOperateur"
        Me.LOperateur.Size = New System.Drawing.Size(237, 23)
        Me.LOperateur.Text = "Opérateur: "
        Me.LOperateur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LPoste
        '
        Me.LPoste.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LPoste.Location = New System.Drawing.Point(3, 49)
        Me.LPoste.Name = "LPoste"
        Me.LPoste.Size = New System.Drawing.Size(237, 20)
        Me.LPoste.Text = "Poste: "
        Me.LPoste.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BAddUser
        '
        Me.BAddUser.BackColor = System.Drawing.Color.DodgerBlue
        Me.BAddUser.Font = New System.Drawing.Font("Segoe Condensed", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BAddUser.Location = New System.Drawing.Point(3, 75)
        Me.BAddUser.Name = "BAddUser"
        Me.BAddUser.Size = New System.Drawing.Size(234, 30)
        Me.BAddUser.TabIndex = 4
        Me.BAddUser.Text = "Ajout utilisateur"
        '
        'BModifPoste
        '
        Me.BModifPoste.BackColor = System.Drawing.Color.Chocolate
        Me.BModifPoste.Font = New System.Drawing.Font("Segoe Condensed", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BModifPoste.Location = New System.Drawing.Point(3, 111)
        Me.BModifPoste.Name = "BModifPoste"
        Me.BModifPoste.Size = New System.Drawing.Size(234, 32)
        Me.BModifPoste.TabIndex = 5
        Me.BModifPoste.Text = "Changement de poste"
        '
        'PBRetour
        '
        Me.PBRetour.Image = CType(resources.GetObject("PBRetour.Image"), System.Drawing.Image)
        Me.PBRetour.Location = New System.Drawing.Point(0, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LTitreOption
        '
        Me.LTitreOption.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreOption.ForeColor = System.Drawing.Color.Blue
        Me.LTitreOption.Location = New System.Drawing.Point(0, 3)
        Me.LTitreOption.Name = "LTitreOption"
        Me.LTitreOption.Size = New System.Drawing.Size(240, 29)
        Me.LTitreOption.Text = "Paramètres Utilisateur"
        Me.LTitreOption.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BReset2
        '
        Me.BReset2.BackColor = System.Drawing.Color.Red
        Me.BReset2.Font = New System.Drawing.Font("Segoe Condensed", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BReset2.Location = New System.Drawing.Point(3, 147)
        Me.BReset2.Name = "BReset2"
        Me.BReset2.Size = New System.Drawing.Size(234, 30)
        Me.BReset2.TabIndex = 5
        Me.BReset2.Text = "Redemarrer douchette"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 42)
        Me.Label1.Text = "Horaire Standard :"
        '
        'RbOui
        '
        Me.RbOui.Location = New System.Drawing.Point(100, 188)
        Me.RbOui.Name = "RbOui"
        Me.RbOui.Size = New System.Drawing.Size(52, 20)
        Me.RbOui.TabIndex = 6
        Me.RbOui.Text = "OUI"
        '
        'RbNon
        '
        Me.RbNon.Location = New System.Drawing.Point(158, 188)
        Me.RbNon.Name = "RbNon"
        Me.RbNon.Size = New System.Drawing.Size(52, 20)
        Me.RbNon.TabIndex = 7
        Me.RbNon.Text = "NON"
        '
        'LbActiv
        '
        Me.LbActiv.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LbActiv.ForeColor = System.Drawing.Color.Green
        Me.LbActiv.Location = New System.Drawing.Point(109, 211)
        Me.LbActiv.Name = "LbActiv"
        Me.LbActiv.Size = New System.Drawing.Size(88, 49)
        Me.LbActiv.Text = "Fin de poste automatique activée"
        '
        'LbDesac
        '
        Me.LbDesac.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.LbDesac.ForeColor = System.Drawing.Color.Red
        Me.LbDesac.Location = New System.Drawing.Point(109, 211)
        Me.LbDesac.Name = "LbDesac"
        Me.LbDesac.Size = New System.Drawing.Size(88, 49)
        Me.LbDesac.Text = "Fin de poste automatique desactivée"
        '
        'frmChangeParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.LbDesac)
        Me.Controls.Add(Me.LbActiv)
        Me.Controls.Add(Me.RbNon)
        Me.Controls.Add(Me.RbOui)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LPoste)
        Me.Controls.Add(Me.LOperateur)
        Me.Controls.Add(Me.LTitreOption)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.BReset2)
        Me.Controls.Add(Me.BModifPoste)
        Me.Controls.Add(Me.BAddUser)
        Me.Name = "frmChangeParam"
        Me.Text = " "
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LOperateur As System.Windows.Forms.Label
    Friend WithEvents LPoste As System.Windows.Forms.Label
    Friend WithEvents BAddUser As System.Windows.Forms.Button
    Friend WithEvents BModifPoste As System.Windows.Forms.Button
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents LTitreOption As System.Windows.Forms.Label
    Friend WithEvents BReset2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RbOui As System.Windows.Forms.RadioButton
    Friend WithEvents RbNon As System.Windows.Forms.RadioButton
    Friend WithEvents LbActiv As System.Windows.Forms.Label
    Friend WithEvents LbDesac As System.Windows.Forms.Label
End Class
