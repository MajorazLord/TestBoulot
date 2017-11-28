<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmParametre
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
        Me.TCParametre = New System.Windows.Forms.TabControl
        Me.TPSecteur = New System.Windows.Forms.TabPage
        Me.CBSecteur = New System.Windows.Forms.ComboBox
        Me.LSecteurDispo = New System.Windows.Forms.Label
        Me.LNomSecteur = New System.Windows.Forms.Label
        Me.LCurrentSecteur = New System.Windows.Forms.Label
        Me.LTitreSecteur = New System.Windows.Forms.Label
        Me.TPMachine = New System.Windows.Forms.TabPage
        Me.PMachineUnique = New System.Windows.Forms.Panel
        Me.BDelMachine = New System.Windows.Forms.Button
        Me.TBNumMachine = New System.Windows.Forms.TextBox
        Me.LScanMachine = New System.Windows.Forms.Label
        Me.CBUniMachine = New System.Windows.Forms.CheckBox
        Me.CBMultiMachine = New System.Windows.Forms.CheckBox
        Me.LTitreMachine = New System.Windows.Forms.Label
        Me.BModifier = New System.Windows.Forms.Button
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.TCParametre.SuspendLayout()
        Me.TPSecteur.SuspendLayout()
        Me.TPMachine.SuspendLayout()
        Me.PMachineUnique.SuspendLayout()
        Me.SuspendLayout()
        '
        'TCParametre
        '
        Me.TCParametre.Controls.Add(Me.TPSecteur)
        Me.TCParametre.Controls.Add(Me.TPMachine)
        Me.TCParametre.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.TCParametre.Location = New System.Drawing.Point(0, 0)
        Me.TCParametre.Name = "TCParametre"
        Me.TCParametre.SelectedIndex = 0
        Me.TCParametre.Size = New System.Drawing.Size(240, 224)
        Me.TCParametre.TabIndex = 0
        '
        'TPSecteur
        '
        Me.TPSecteur.Controls.Add(Me.CBSecteur)
        Me.TPSecteur.Controls.Add(Me.LSecteurDispo)
        Me.TPSecteur.Controls.Add(Me.LNomSecteur)
        Me.TPSecteur.Controls.Add(Me.LCurrentSecteur)
        Me.TPSecteur.Controls.Add(Me.LTitreSecteur)
        Me.TPSecteur.Location = New System.Drawing.Point(0, 0)
        Me.TPSecteur.Name = "TPSecteur"
        Me.TPSecteur.Size = New System.Drawing.Size(240, 196)
        Me.TPSecteur.Text = "Modifer secteur"
        '
        'CBSecteur
        '
        Me.CBSecteur.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.CBSecteur.Location = New System.Drawing.Point(51, 154)
        Me.CBSecteur.Name = "CBSecteur"
        Me.CBSecteur.Size = New System.Drawing.Size(141, 30)
        Me.CBSecteur.TabIndex = 8
        '
        'LSecteurDispo
        '
        Me.LSecteurDispo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LSecteurDispo.Location = New System.Drawing.Point(27, 122)
        Me.LSecteurDispo.Name = "LSecteurDispo"
        Me.LSecteurDispo.Size = New System.Drawing.Size(182, 20)
        Me.LSecteurDispo.Text = "Secteurs disponibles:"
        Me.LSecteurDispo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LNomSecteur
        '
        Me.LNomSecteur.Font = New System.Drawing.Font("Tahoma", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.LNomSecteur.Location = New System.Drawing.Point(4, 70)
        Me.LNomSecteur.Name = "LNomSecteur"
        Me.LNomSecteur.Size = New System.Drawing.Size(232, 40)
        Me.LNomSecteur.Text = "Secteur"
        Me.LNomSecteur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LCurrentSecteur
        '
        Me.LCurrentSecteur.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LCurrentSecteur.Location = New System.Drawing.Point(51, 36)
        Me.LCurrentSecteur.Name = "LCurrentSecteur"
        Me.LCurrentSecteur.Size = New System.Drawing.Size(137, 20)
        Me.LCurrentSecteur.Text = "Secteur actuel:"
        '
        'LTitreSecteur
        '
        Me.LTitreSecteur.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreSecteur.ForeColor = System.Drawing.Color.Peru
        Me.LTitreSecteur.Location = New System.Drawing.Point(0, 0)
        Me.LTitreSecteur.Name = "LTitreSecteur"
        Me.LTitreSecteur.Size = New System.Drawing.Size(240, 32)
        Me.LTitreSecteur.Text = "Modifier le secteur"
        Me.LTitreSecteur.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TPMachine
        '
        Me.TPMachine.Controls.Add(Me.PMachineUnique)
        Me.TPMachine.Controls.Add(Me.CBUniMachine)
        Me.TPMachine.Controls.Add(Me.CBMultiMachine)
        Me.TPMachine.Controls.Add(Me.LTitreMachine)
        Me.TPMachine.Location = New System.Drawing.Point(0, 0)
        Me.TPMachine.Name = "TPMachine"
        Me.TPMachine.Size = New System.Drawing.Size(232, 193)
        Me.TPMachine.Text = "Option machine"
        '
        'PMachineUnique
        '
        Me.PMachineUnique.Controls.Add(Me.BDelMachine)
        Me.PMachineUnique.Controls.Add(Me.TBNumMachine)
        Me.PMachineUnique.Controls.Add(Me.LScanMachine)
        Me.PMachineUnique.Location = New System.Drawing.Point(2, 110)
        Me.PMachineUnique.Name = "PMachineUnique"
        Me.PMachineUnique.Size = New System.Drawing.Size(237, 83)
        Me.PMachineUnique.Visible = False
        '
        'BDelMachine
        '
        Me.BDelMachine.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BDelMachine.Location = New System.Drawing.Point(192, 27)
        Me.BDelMachine.Name = "BDelMachine"
        Me.BDelMachine.Size = New System.Drawing.Size(27, 29)
        Me.BDelMachine.TabIndex = 2
        Me.BDelMachine.Text = "X"
        '
        'TBNumMachine
        '
        Me.TBNumMachine.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumMachine.Location = New System.Drawing.Point(6, 27)
        Me.TBNumMachine.Name = "TBNumMachine"
        Me.TBNumMachine.Size = New System.Drawing.Size(180, 29)
        Me.TBNumMachine.TabIndex = 1
        '
        'LScanMachine
        '
        Me.LScanMachine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LScanMachine.Location = New System.Drawing.Point(3, 4)
        Me.LScanMachine.Name = "LScanMachine"
        Me.LScanMachine.Size = New System.Drawing.Size(231, 20)
        Me.LScanMachine.Text = "Scan N° Machine (ou table):"
        '
        'CBUniMachine
        '
        Me.CBUniMachine.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.CBUniMachine.Location = New System.Drawing.Point(19, 78)
        Me.CBUniMachine.Name = "CBUniMachine"
        Me.CBUniMachine.Size = New System.Drawing.Size(201, 26)
        Me.CBUniMachine.TabIndex = 7
        Me.CBUniMachine.Text = "Machine unique"
        '
        'CBMultiMachine
        '
        Me.CBMultiMachine.Checked = True
        Me.CBMultiMachine.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBMultiMachine.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.CBMultiMachine.Location = New System.Drawing.Point(19, 46)
        Me.CBMultiMachine.Name = "CBMultiMachine"
        Me.CBMultiMachine.Size = New System.Drawing.Size(201, 26)
        Me.CBMultiMachine.TabIndex = 6
        Me.CBMultiMachine.Text = "Plusieurs machines"
        '
        'LTitreMachine
        '
        Me.LTitreMachine.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreMachine.ForeColor = System.Drawing.Color.Peru
        Me.LTitreMachine.Location = New System.Drawing.Point(0, 0)
        Me.LTitreMachine.Name = "LTitreMachine"
        Me.LTitreMachine.Size = New System.Drawing.Size(240, 32)
        Me.LTitreMachine.Text = "Option machine"
        Me.LTitreMachine.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'BModifier
        '
        Me.BModifier.BackColor = System.Drawing.Color.Lime
        Me.BModifier.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.BModifier.Location = New System.Drawing.Point(75, 228)
        Me.BModifier.Name = "BModifier"
        Me.BModifier.Size = New System.Drawing.Size(162, 66)
        Me.BModifier.TabIndex = 2
        Me.BModifier.Text = "Modifier"
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmParametre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.TCParametre)
        Me.Controls.Add(Me.BModifier)
        Me.Controls.Add(Me.PBRetour)
        Me.Name = "frmParametre"
        Me.Text = "Paramètre"
        Me.TCParametre.ResumeLayout(False)
        Me.TPSecteur.ResumeLayout(False)
        Me.TPMachine.ResumeLayout(False)
        Me.PMachineUnique.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TCParametre As System.Windows.Forms.TabControl
    Friend WithEvents TPSecteur As System.Windows.Forms.TabPage
    Friend WithEvents TPMachine As System.Windows.Forms.TabPage
    Friend WithEvents LTitreSecteur As System.Windows.Forms.Label
    Friend WithEvents LTitreMachine As System.Windows.Forms.Label
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents BModifier As System.Windows.Forms.Button
    Friend WithEvents LCurrentSecteur As System.Windows.Forms.Label
    Friend WithEvents LNomSecteur As System.Windows.Forms.Label
    Friend WithEvents LSecteurDispo As System.Windows.Forms.Label
    Friend WithEvents CBSecteur As System.Windows.Forms.ComboBox
    Friend WithEvents CBMultiMachine As System.Windows.Forms.CheckBox
    Friend WithEvents CBUniMachine As System.Windows.Forms.CheckBox
    Friend WithEvents PMachineUnique As System.Windows.Forms.Panel
    Friend WithEvents LScanMachine As System.Windows.Forms.Label
    Friend WithEvents BDelMachine As System.Windows.Forms.Button
    Friend WithEvents TBNumMachine As System.Windows.Forms.TextBox
End Class
