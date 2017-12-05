<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmEntree
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
        Me.LTitreEntree = New System.Windows.Forms.Label
        Me.tbNumMach = New System.Windows.Forms.TextBox
        Me.LblMach = New System.Windows.Forms.Label
        Me.LblPart = New System.Windows.Forms.Label
        Me.tbnoetiq = New System.Windows.Forms.TextBox
        Me.DelMach = New System.Windows.Forms.Button
        Me.DelNoetiq = New System.Windows.Forms.Button
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.PBRecapitulatif = New System.Windows.Forms.PictureBox
        Me.btvalid = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'LTitreEntree
        '
        Me.LTitreEntree.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Bold)
        Me.LTitreEntree.ForeColor = System.Drawing.Color.LimeGreen
        Me.LTitreEntree.Location = New System.Drawing.Point(1, 3)
        Me.LTitreEntree.Name = "LTitreEntree"
        Me.LTitreEntree.Size = New System.Drawing.Size(237, 45)
        Me.LTitreEntree.Text = "Entrée"
        Me.LTitreEntree.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tbNumMach
        '
        Me.tbNumMach.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.tbNumMach.Location = New System.Drawing.Point(3, 76)
        Me.tbNumMach.Name = "tbNumMach"
        Me.tbNumMach.Size = New System.Drawing.Size(189, 29)
        Me.tbNumMach.TabIndex = 2
        '
        'LblMach
        '
        Me.LblMach.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblMach.Location = New System.Drawing.Point(3, 55)
        Me.LblMach.Name = "LblMach"
        Me.LblMach.Size = New System.Drawing.Size(220, 18)
        Me.LblMach.Text = "Scan N° Machine (ou table): "
        '
        'LblPart
        '
        Me.LblPart.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LblPart.Location = New System.Drawing.Point(3, 132)
        Me.LblPart.Name = "LblPart"
        Me.LblPart.Size = New System.Drawing.Size(199, 18)
        Me.LblPart.Text = "Scan partie détachable : "
        '
        'tbnoetiq
        '
        Me.tbnoetiq.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.tbnoetiq.Location = New System.Drawing.Point(3, 153)
        Me.tbnoetiq.Name = "tbnoetiq"
        Me.tbnoetiq.Size = New System.Drawing.Size(189, 29)
        Me.tbnoetiq.TabIndex = 7
        '
        'DelMach
        '
        Me.DelMach.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelMach.Location = New System.Drawing.Point(198, 76)
        Me.DelMach.Name = "DelMach"
        Me.DelMach.Size = New System.Drawing.Size(39, 29)
        Me.DelMach.TabIndex = 8
        Me.DelMach.Text = "X"
        '
        'DelNoetiq
        '
        Me.DelNoetiq.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.DelNoetiq.Location = New System.Drawing.Point(198, 153)
        Me.DelNoetiq.Name = "DelNoetiq"
        Me.DelNoetiq.Size = New System.Drawing.Size(39, 29)
        Me.DelNoetiq.TabIndex = 9
        Me.DelNoetiq.Text = "X"
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PBRecapitulatif
        '
        Me.PBRecapitulatif.Location = New System.Drawing.Point(75, 225)
        Me.PBRecapitulatif.Name = "PBRecapitulatif"
        Me.PBRecapitulatif.Size = New System.Drawing.Size(54, 66)
        Me.PBRecapitulatif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'btvalid
        '
        Me.btvalid.BackColor = System.Drawing.Color.Lime
        Me.btvalid.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.btvalid.Location = New System.Drawing.Point(135, 225)
        Me.btvalid.Name = "btvalid"
        Me.btvalid.Size = New System.Drawing.Size(102, 66)
        Me.btvalid.TabIndex = 14
        Me.btvalid.Text = "Valider"
        '
        'frmEntree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.btvalid)
        Me.Controls.Add(Me.PBRecapitulatif)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.DelNoetiq)
        Me.Controls.Add(Me.DelMach)
        Me.Controls.Add(Me.tbnoetiq)
        Me.Controls.Add(Me.LblPart)
        Me.Controls.Add(Me.LblMach)
        Me.Controls.Add(Me.tbNumMach)
        Me.Controls.Add(Me.LTitreEntree)
        Me.Name = "frmEntree"
        Me.Text = "Entrée"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitreEntree As System.Windows.Forms.Label
    Friend WithEvents tbNumMach As System.Windows.Forms.TextBox
    Friend WithEvents LblMach As System.Windows.Forms.Label
    Friend WithEvents LblPart As System.Windows.Forms.Label
    Friend WithEvents tbnoetiq As System.Windows.Forms.TextBox
    Friend WithEvents DelMach As System.Windows.Forms.Button
    Friend WithEvents DelNoetiq As System.Windows.Forms.Button
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents PBRecapitulatif As System.Windows.Forms.PictureBox
    Friend WithEvents btvalid As System.Windows.Forms.Button
End Class
