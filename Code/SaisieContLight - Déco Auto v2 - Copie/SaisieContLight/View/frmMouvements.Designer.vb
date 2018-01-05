<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmMouvements
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
        Me.LblMach = New System.Windows.Forms.Label
        Me.btvalid = New System.Windows.Forms.Button
        Me.tbQte = New System.Windows.Forms.TextBox
        Me.lblQté = New System.Windows.Forms.Label
        Me.tbnoetiq = New System.Windows.Forms.TextBox
        Me.LblPart = New System.Windows.Forms.Label
        Me.DelNoetiq = New System.Windows.Forms.Button
        Me.DelQte = New System.Windows.Forms.Button
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.tbNumMach = New System.Windows.Forms.TextBox
        Me.DelMach = New System.Windows.Forms.Button
        Me.PBRecapitulatif = New System.Windows.Forms.PictureBox
        Me.DelMatrice = New System.Windows.Forms.Button
        Me.TBMatrice = New System.Windows.Forms.TextBox
        Me.LblMatrice = New System.Windows.Forms.Label
        Me.DelCharge = New System.Windows.Forms.Button
        Me.TBCharge = New System.Windows.Forms.TextBox
        Me.LblCharge = New System.Windows.Forms.Label
        Me.DelVague = New System.Windows.Forms.Button
        Me.TBVague = New System.Windows.Forms.TextBox
        Me.LblVague = New System.Windows.Forms.Label
        Me.PanelIO = New System.Windows.Forms.Panel
        Me.PanelIO.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblMach
        '
        Me.LblMach.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblMach.Location = New System.Drawing.Point(3, 0)
        Me.LblMach.Name = "LblMach"
        Me.LblMach.Size = New System.Drawing.Size(220, 18)
        Me.LblMach.Text = "Scan N° Machine (ou table): "
        '
        'btvalid
        '
        Me.btvalid.BackColor = System.Drawing.Color.Lime
        Me.btvalid.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btvalid.Location = New System.Drawing.Point(135, 228)
        Me.btvalid.Name = "btvalid"
        Me.btvalid.Size = New System.Drawing.Size(102, 66)
        Me.btvalid.TabIndex = 13
        Me.btvalid.Text = "Valider"
        '
        'tbQte
        '
        Me.tbQte.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.tbQte.Location = New System.Drawing.Point(3, 132)
        Me.tbQte.Name = "tbQte"
        Me.tbQte.Size = New System.Drawing.Size(175, 29)
        Me.tbQte.TabIndex = 5
        Me.tbQte.Visible = False
        '
        'lblQté
        '
        Me.lblQté.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblQté.Location = New System.Drawing.Point(3, 111)
        Me.lblQté.Name = "lblQté"
        Me.lblQté.Size = New System.Drawing.Size(213, 18)
        Me.lblQté.Text = "Saisir quantité contenant :"
        Me.lblQté.Visible = False
        '
        'tbnoetiq
        '
        Me.tbnoetiq.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.tbnoetiq.Location = New System.Drawing.Point(3, 77)
        Me.tbnoetiq.Name = "tbnoetiq"
        Me.tbnoetiq.Size = New System.Drawing.Size(175, 29)
        Me.tbnoetiq.TabIndex = 3
        '
        'LblPart
        '
        Me.LblPart.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblPart.Location = New System.Drawing.Point(3, 55)
        Me.LblPart.Name = "LblPart"
        Me.LblPart.Size = New System.Drawing.Size(199, 18)
        Me.LblPart.Text = "Scan partie détachable : "
        '
        'DelNoetiq
        '
        Me.DelNoetiq.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelNoetiq.Location = New System.Drawing.Point(184, 77)
        Me.DelNoetiq.Name = "DelNoetiq"
        Me.DelNoetiq.Size = New System.Drawing.Size(39, 29)
        Me.DelNoetiq.TabIndex = 4
        Me.DelNoetiq.Text = "X"
        '
        'DelQte
        '
        Me.DelQte.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelQte.Location = New System.Drawing.Point(184, 132)
        Me.DelQte.Name = "DelQte"
        Me.DelQte.Size = New System.Drawing.Size(39, 29)
        Me.DelQte.TabIndex = 6
        Me.DelQte.Text = "X"
        Me.DelQte.Visible = False
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'tbNumMach
        '
        Me.tbNumMach.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.tbNumMach.Location = New System.Drawing.Point(3, 21)
        Me.tbNumMach.Name = "tbNumMach"
        Me.tbNumMach.Size = New System.Drawing.Size(175, 29)
        Me.tbNumMach.TabIndex = 1
        '
        'DelMach
        '
        Me.DelMach.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelMach.Location = New System.Drawing.Point(184, 21)
        Me.DelMach.Name = "DelMach"
        Me.DelMach.Size = New System.Drawing.Size(39, 29)
        Me.DelMach.TabIndex = 2
        Me.DelMach.Text = "X"
        '
        'PBRecapitulatif
        '
        Me.PBRecapitulatif.Location = New System.Drawing.Point(75, 228)
        Me.PBRecapitulatif.Name = "PBRecapitulatif"
        Me.PBRecapitulatif.Size = New System.Drawing.Size(54, 66)
        Me.PBRecapitulatif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'DelMatrice
        '
        Me.DelMatrice.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelMatrice.Location = New System.Drawing.Point(184, 242)
        Me.DelMatrice.Name = "DelMatrice"
        Me.DelMatrice.Size = New System.Drawing.Size(39, 29)
        Me.DelMatrice.TabIndex = 10
        Me.DelMatrice.Text = "X"
        Me.DelMatrice.Visible = False
        '
        'TBMatrice
        '
        Me.TBMatrice.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBMatrice.Location = New System.Drawing.Point(4, 242)
        Me.TBMatrice.Name = "TBMatrice"
        Me.TBMatrice.Size = New System.Drawing.Size(175, 29)
        Me.TBMatrice.TabIndex = 9
        Me.TBMatrice.Visible = False
        '
        'LblMatrice
        '
        Me.LblMatrice.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblMatrice.Location = New System.Drawing.Point(4, 222)
        Me.LblMatrice.Name = "LblMatrice"
        Me.LblMatrice.Size = New System.Drawing.Size(175, 18)
        Me.LblMatrice.Text = "Numéro de matrice : "
        Me.LblMatrice.Visible = False
        '
        'DelCharge
        '
        Me.DelCharge.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelCharge.Location = New System.Drawing.Point(184, 187)
        Me.DelCharge.Name = "DelCharge"
        Me.DelCharge.Size = New System.Drawing.Size(39, 29)
        Me.DelCharge.TabIndex = 8
        Me.DelCharge.Text = "X"
        Me.DelCharge.Visible = False
        '
        'TBCharge
        '
        Me.TBCharge.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCharge.Location = New System.Drawing.Point(4, 187)
        Me.TBCharge.Name = "TBCharge"
        Me.TBCharge.Size = New System.Drawing.Size(175, 29)
        Me.TBCharge.TabIndex = 7
        Me.TBCharge.Visible = False
        '
        'LblCharge
        '
        Me.LblCharge.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblCharge.Location = New System.Drawing.Point(4, 166)
        Me.LblCharge.Name = "LblCharge"
        Me.LblCharge.Size = New System.Drawing.Size(160, 18)
        Me.LblCharge.Text = "Numéro de charge :"
        Me.LblCharge.Visible = False
        '
        'DelVague
        '
        Me.DelVague.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelVague.Location = New System.Drawing.Point(184, 297)
        Me.DelVague.Name = "DelVague"
        Me.DelVague.Size = New System.Drawing.Size(39, 29)
        Me.DelVague.TabIndex = 12
        Me.DelVague.Text = "X"
        Me.DelVague.Visible = False
        '
        'TBVague
        '
        Me.TBVague.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBVague.Location = New System.Drawing.Point(4, 297)
        Me.TBVague.Name = "TBVague"
        Me.TBVague.Size = New System.Drawing.Size(175, 29)
        Me.TBVague.TabIndex = 11
        Me.TBVague.Visible = False
        '
        'LblVague
        '
        Me.LblVague.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblVague.Location = New System.Drawing.Point(4, 276)
        Me.LblVague.Name = "LblVague"
        Me.LblVague.Size = New System.Drawing.Size(160, 18)
        Me.LblVague.Text = "Numéro de vague :"
        Me.LblVague.Visible = False
        '
        'PanelIO
        '
        Me.PanelIO.AutoScroll = True
        Me.PanelIO.Controls.Add(Me.TBMatrice)
        Me.PanelIO.Controls.Add(Me.DelVague)
        Me.PanelIO.Controls.Add(Me.TBVague)
        Me.PanelIO.Controls.Add(Me.LblVague)
        Me.PanelIO.Controls.Add(Me.LblPart)
        Me.PanelIO.Controls.Add(Me.DelCharge)
        Me.PanelIO.Controls.Add(Me.tbnoetiq)
        Me.PanelIO.Controls.Add(Me.TBCharge)
        Me.PanelIO.Controls.Add(Me.lblQté)
        Me.PanelIO.Controls.Add(Me.LblCharge)
        Me.PanelIO.Controls.Add(Me.tbQte)
        Me.PanelIO.Controls.Add(Me.DelMatrice)
        Me.PanelIO.Controls.Add(Me.LblMach)
        Me.PanelIO.Controls.Add(Me.LblMatrice)
        Me.PanelIO.Controls.Add(Me.DelNoetiq)
        Me.PanelIO.Controls.Add(Me.DelQte)
        Me.PanelIO.Controls.Add(Me.DelMach)
        Me.PanelIO.Controls.Add(Me.tbNumMach)
        Me.PanelIO.Location = New System.Drawing.Point(0, 0)
        Me.PanelIO.Name = "PanelIO"
        Me.PanelIO.Size = New System.Drawing.Size(240, 225)
        '
        'frmMouvements
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.PanelIO)
        Me.Controls.Add(Me.PBRecapitulatif)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.btvalid)
        Me.KeyPreview = True
        Me.Name = "frmMouvements"
        Me.Text = "Saisie des Contenants"
        Me.PanelIO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblMach As System.Windows.Forms.Label
    Friend WithEvents btvalid As System.Windows.Forms.Button
    Friend WithEvents tbQte As System.Windows.Forms.TextBox
    Friend WithEvents lblQté As System.Windows.Forms.Label
    Friend WithEvents tbnoetiq As System.Windows.Forms.TextBox
    Friend WithEvents LblPart As System.Windows.Forms.Label
    Friend WithEvents DelNoetiq As System.Windows.Forms.Button
    Friend WithEvents DelQte As System.Windows.Forms.Button
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents tbNumMach As System.Windows.Forms.TextBox
    Friend WithEvents DelMach As System.Windows.Forms.Button
    Friend WithEvents PBRecapitulatif As System.Windows.Forms.PictureBox
    Friend WithEvents DelMatrice As System.Windows.Forms.Button
    Friend WithEvents TBMatrice As System.Windows.Forms.TextBox
    Friend WithEvents LblMatrice As System.Windows.Forms.Label
    Friend WithEvents DelCharge As System.Windows.Forms.Button
    Friend WithEvents TBCharge As System.Windows.Forms.TextBox
    Friend WithEvents LblCharge As System.Windows.Forms.Label
    Friend WithEvents DelVague As System.Windows.Forms.Button
    Friend WithEvents TBVague As System.Windows.Forms.TextBox
    Friend WithEvents LblVague As System.Windows.Forms.Label
    Friend WithEvents PanelIO As System.Windows.Forms.Panel

End Class
