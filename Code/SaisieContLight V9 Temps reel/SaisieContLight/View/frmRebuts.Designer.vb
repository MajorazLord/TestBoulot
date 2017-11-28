<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRebuts
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
        Me.LOF = New System.Windows.Forms.Label
        Me.PNumOF = New System.Windows.Forms.Panel
        Me.CBOF = New System.Windows.Forms.ComboBox
        Me.PBAddOF = New System.Windows.Forms.PictureBox
        Me.PScan = New System.Windows.Forms.Panel
        Me.BDelScan = New System.Windows.Forms.Button
        Me.TBNumEtiq = New System.Windows.Forms.TextBox
        Me.Lscan = New System.Windows.Forms.Label
        Me.LCode = New System.Windows.Forms.Label
        Me.LPEcartees = New System.Windows.Forms.Label
        Me.TBCode = New System.Windows.Forms.TextBox
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.PBRecap = New System.Windows.Forms.PictureBox
        Me.BValider = New System.Windows.Forms.Button
        Me.TBCode2 = New System.Windows.Forms.TextBox
        Me.TBEcartees = New System.Windows.Forms.TextBox
        Me.TBEcartees2 = New System.Windows.Forms.TextBox
        Me.BDelLigne = New System.Windows.Forms.Button
        Me.BDelLigne2 = New System.Windows.Forms.Button
        Me.PBAddCode = New System.Windows.Forms.PictureBox
        Me.LMachine = New System.Windows.Forms.Label
        Me.CBMachine = New System.Windows.Forms.ComboBox
        Me.PBAddMachine = New System.Windows.Forms.PictureBox
        Me.PNumOF.SuspendLayout()
        Me.PScan.SuspendLayout()
        Me.SuspendLayout()
        '
        'LTitre
        '
        Me.LTitre.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LTitre.ForeColor = System.Drawing.Color.Red
        Me.LTitre.Location = New System.Drawing.Point(0, 1)
        Me.LTitre.Name = "LTitre"
        Me.LTitre.Size = New System.Drawing.Size(240, 25)
        Me.LTitre.Text = "Pièces écartées"
        Me.LTitre.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LOF
        '
        Me.LOF.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LOF.Location = New System.Drawing.Point(4, 20)
        Me.LOF.Name = "LOF"
        Me.LOF.Size = New System.Drawing.Size(57, 33)
        Me.LOF.Text = "N° OF:"
        '
        'PNumOF
        '
        Me.PNumOF.Controls.Add(Me.CBOF)
        Me.PNumOF.Controls.Add(Me.PBAddOF)
        Me.PNumOF.Controls.Add(Me.LOF)
        Me.PNumOF.Location = New System.Drawing.Point(0, 27)
        Me.PNumOF.Name = "PNumOF"
        Me.PNumOF.Size = New System.Drawing.Size(240, 60)
        '
        'CBOF
        '
        Me.CBOF.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.CBOF.Location = New System.Drawing.Point(66, 16)
        Me.CBOF.Name = "CBOF"
        Me.CBOF.Size = New System.Drawing.Size(127, 33)
        Me.CBOF.TabIndex = 12
        '
        'PBAddOF
        '
        Me.PBAddOF.Location = New System.Drawing.Point(202, 14)
        Me.PBAddOF.Name = "PBAddOF"
        Me.PBAddOF.Size = New System.Drawing.Size(35, 35)
        Me.PBAddOF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PScan
        '
        Me.PScan.Controls.Add(Me.BDelScan)
        Me.PScan.Controls.Add(Me.TBNumEtiq)
        Me.PScan.Controls.Add(Me.Lscan)
        Me.PScan.Location = New System.Drawing.Point(211, 89)
        Me.PScan.Name = "PScan"
        Me.PScan.Size = New System.Drawing.Size(240, 60)
        '
        'BDelScan
        '
        Me.BDelScan.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelScan.Location = New System.Drawing.Point(186, 26)
        Me.BDelScan.Name = "BDelScan"
        Me.BDelScan.Size = New System.Drawing.Size(32, 32)
        Me.BDelScan.TabIndex = 2
        Me.BDelScan.Text = "X"
        '
        'TBNumEtiq
        '
        Me.TBNumEtiq.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.TBNumEtiq.Location = New System.Drawing.Point(5, 26)
        Me.TBNumEtiq.Name = "TBNumEtiq"
        Me.TBNumEtiq.Size = New System.Drawing.Size(175, 32)
        Me.TBNumEtiq.TabIndex = 1
        '
        'Lscan
        '
        Me.Lscan.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Lscan.Location = New System.Drawing.Point(3, 1)
        Me.Lscan.Name = "Lscan"
        Me.Lscan.Size = New System.Drawing.Size(228, 20)
        Me.Lscan.Text = "Scan partie détachable:"
        '
        'LCode
        '
        Me.LCode.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LCode.Location = New System.Drawing.Point(4, 132)
        Me.LCode.Name = "LCode"
        Me.LCode.Size = New System.Drawing.Size(60, 20)
        Me.LCode.Text = "Code:"
        '
        'LPEcartees
        '
        Me.LPEcartees.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LPEcartees.Location = New System.Drawing.Point(67, 132)
        Me.LPEcartees.Name = "LPEcartees"
        Me.LPEcartees.Size = New System.Drawing.Size(89, 20)
        Me.LPEcartees.Text = "P. écartées:"
        '
        'TBCode
        '
        Me.TBCode.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode.Location = New System.Drawing.Point(4, 155)
        Me.TBCode.Multiline = True
        Me.TBCode.Name = "TBCode"
        Me.TBCode.Size = New System.Drawing.Size(57, 29)
        Me.TBCode.TabIndex = 6
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(0, 228)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(69, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'PBRecap
        '
        Me.PBRecap.Location = New System.Drawing.Point(75, 228)
        Me.PBRecap.Name = "PBRecap"
        Me.PBRecap.Size = New System.Drawing.Size(54, 66)
        Me.PBRecap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'BValider
        '
        Me.BValider.BackColor = System.Drawing.Color.Lime
        Me.BValider.Font = New System.Drawing.Font("Tahoma", 20.0!, System.Drawing.FontStyle.Regular)
        Me.BValider.Location = New System.Drawing.Point(135, 228)
        Me.BValider.Name = "BValider"
        Me.BValider.Size = New System.Drawing.Size(102, 66)
        Me.BValider.TabIndex = 9
        Me.BValider.Text = "Valider"
        '
        'TBCode2
        '
        Me.TBCode2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBCode2.Location = New System.Drawing.Point(3, 191)
        Me.TBCode2.Multiline = True
        Me.TBCode2.Name = "TBCode2"
        Me.TBCode2.Size = New System.Drawing.Size(57, 29)
        Me.TBCode2.TabIndex = 10
        '
        'TBEcartees
        '
        Me.TBEcartees.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBEcartees.Location = New System.Drawing.Point(67, 155)
        Me.TBEcartees.Multiline = True
        Me.TBEcartees.Name = "TBEcartees"
        Me.TBEcartees.Size = New System.Drawing.Size(68, 29)
        Me.TBEcartees.TabIndex = 12
        '
        'TBEcartees2
        '
        Me.TBEcartees2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TBEcartees2.Location = New System.Drawing.Point(67, 191)
        Me.TBEcartees2.Multiline = True
        Me.TBEcartees2.Name = "TBEcartees2"
        Me.TBEcartees2.Size = New System.Drawing.Size(68, 29)
        Me.TBEcartees2.TabIndex = 13
        '
        'BDelLigne
        '
        Me.BDelLigne.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne.Location = New System.Drawing.Point(141, 155)
        Me.BDelLigne.Name = "BDelLigne"
        Me.BDelLigne.Size = New System.Drawing.Size(23, 29)
        Me.BDelLigne.TabIndex = 15
        Me.BDelLigne.Text = "X"
        '
        'BDelLigne2
        '
        Me.BDelLigne2.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.BDelLigne2.Location = New System.Drawing.Point(141, 191)
        Me.BDelLigne2.Name = "BDelLigne2"
        Me.BDelLigne2.Size = New System.Drawing.Size(23, 29)
        Me.BDelLigne2.TabIndex = 16
        Me.BDelLigne2.Text = "X"
        '
        'PBAddCode
        '
        Me.PBAddCode.Location = New System.Drawing.Point(172, 155)
        Me.PBAddCode.Name = "PBAddCode"
        Me.PBAddCode.Size = New System.Drawing.Size(65, 65)
        Me.PBAddCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'LMachine
        '
        Me.LMachine.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LMachine.Location = New System.Drawing.Point(5, 100)
        Me.LMachine.Name = "LMachine"
        Me.LMachine.Size = New System.Drawing.Size(77, 20)
        Me.LMachine.Text = "Machine:"
        '
        'CBMachine
        '
        Me.CBMachine.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.CBMachine.Location = New System.Drawing.Point(92, 95)
        Me.CBMachine.Name = "CBMachine"
        Me.CBMachine.Size = New System.Drawing.Size(100, 30)
        Me.CBMachine.TabIndex = 24
        '
        'PBAddMachine
        '
        Me.PBAddMachine.Location = New System.Drawing.Point(201, 93)
        Me.PBAddMachine.Name = "PBAddMachine"
        Me.PBAddMachine.Size = New System.Drawing.Size(35, 35)
        Me.PBAddMachine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmRebuts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.PBAddMachine)
        Me.Controls.Add(Me.PScan)
        Me.Controls.Add(Me.CBMachine)
        Me.Controls.Add(Me.LMachine)
        Me.Controls.Add(Me.PNumOF)
        Me.Controls.Add(Me.PBAddCode)
        Me.Controls.Add(Me.BDelLigne2)
        Me.Controls.Add(Me.BDelLigne)
        Me.Controls.Add(Me.TBEcartees2)
        Me.Controls.Add(Me.TBEcartees)
        Me.Controls.Add(Me.TBCode2)
        Me.Controls.Add(Me.BValider)
        Me.Controls.Add(Me.PBRecap)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.TBCode)
        Me.Controls.Add(Me.LPEcartees)
        Me.Controls.Add(Me.LCode)
        Me.Controls.Add(Me.LTitre)
        Me.Name = "frmRebuts"
        Me.Text = "Pièces écartées"
        Me.PNumOF.ResumeLayout(False)
        Me.PScan.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LTitre As System.Windows.Forms.Label
    Friend WithEvents LOF As System.Windows.Forms.Label
    Friend WithEvents PNumOF As System.Windows.Forms.Panel
    Friend WithEvents PBAddOF As System.Windows.Forms.PictureBox
    Friend WithEvents CBOF As System.Windows.Forms.ComboBox
    Friend WithEvents LCode As System.Windows.Forms.Label
    Friend WithEvents LPEcartees As System.Windows.Forms.Label
    Friend WithEvents TBCode As System.Windows.Forms.TextBox
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
    Friend WithEvents PBRecap As System.Windows.Forms.PictureBox
    Friend WithEvents BValider As System.Windows.Forms.Button
    Friend WithEvents TBCode2 As System.Windows.Forms.TextBox
    Friend WithEvents TBEcartees As System.Windows.Forms.TextBox
    Friend WithEvents TBEcartees2 As System.Windows.Forms.TextBox
    Friend WithEvents BDelLigne As System.Windows.Forms.Button
    Friend WithEvents BDelLigne2 As System.Windows.Forms.Button
    Friend WithEvents PBAddCode As System.Windows.Forms.PictureBox
    Friend WithEvents LMachine As System.Windows.Forms.Label
    Friend WithEvents CBMachine As System.Windows.Forms.ComboBox
    Friend WithEvents PScan As System.Windows.Forms.Panel
    Friend WithEvents BDelScan As System.Windows.Forms.Button
    Friend WithEvents TBNumEtiq As System.Windows.Forms.TextBox
    Friend WithEvents Lscan As System.Windows.Forms.Label
    Friend WithEvents PBAddMachine As System.Windows.Forms.PictureBox
End Class
