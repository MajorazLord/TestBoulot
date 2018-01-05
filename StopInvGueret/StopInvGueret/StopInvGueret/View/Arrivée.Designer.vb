<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Arrivée
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
        Me.TbScan = New System.Windows.Forms.TextBox
        Me.BtnDelDétach = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnDelQtité = New System.Windows.Forms.Button
        Me.TbQtité = New System.Windows.Forms.TextBox
        Me.BtnCont = New System.Windows.Forms.Button
        Me.BTerm = New System.Windows.Forms.Button
        Me.BtnRecap = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TbScan
        '
        Me.TbScan.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.TbScan.Location = New System.Drawing.Point(4, 74)
        Me.TbScan.Name = "TbScan"
        Me.TbScan.Size = New System.Drawing.Size(202, 26)
        Me.TbScan.TabIndex = 0
        '
        'BtnDelDétach
        '
        Me.BtnDelDétach.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BtnDelDétach.Location = New System.Drawing.Point(211, 74)
        Me.BtnDelDétach.Name = "BtnDelDétach"
        Me.BtnDelDétach.Size = New System.Drawing.Size(26, 26)
        Me.BtnDelDétach.TabIndex = 1
        Me.BtnDelDétach.Text = "X"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(4, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 20)
        Me.Label1.Text = "Scan partie détachable : "
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(77, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 37)
        Me.Label2.Text = "Arrivée"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(4, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 20)
        Me.Label3.Text = "Saisir la quantité :"
        '
        'BtnDelQtité
        '
        Me.BtnDelQtité.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BtnDelQtité.Location = New System.Drawing.Point(211, 139)
        Me.BtnDelQtité.Name = "BtnDelQtité"
        Me.BtnDelQtité.Size = New System.Drawing.Size(26, 26)
        Me.BtnDelQtité.TabIndex = 6
        Me.BtnDelQtité.Text = "X"
        '
        'TbQtité
        '
        Me.TbQtité.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.TbQtité.Location = New System.Drawing.Point(4, 139)
        Me.TbQtité.Name = "TbQtité"
        Me.TbQtité.Size = New System.Drawing.Size(202, 26)
        Me.TbQtité.TabIndex = 5
        '
        'BtnCont
        '
        Me.BtnCont.BackColor = System.Drawing.Color.Lime
        Me.BtnCont.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BtnCont.Location = New System.Drawing.Point(123, 227)
        Me.BtnCont.Name = "BtnCont"
        Me.BtnCont.Size = New System.Drawing.Size(115, 61)
        Me.BtnCont.TabIndex = 9
        Me.BtnCont.Text = "Continuer"
        '
        'BTerm
        '
        Me.BTerm.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BTerm.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BTerm.Location = New System.Drawing.Point(3, 227)
        Me.BTerm.Name = "BTerm"
        Me.BTerm.Size = New System.Drawing.Size(115, 61)
        Me.BTerm.TabIndex = 10
        Me.BTerm.Text = "Terminer"
        '
        'BtnRecap
        '
        Me.BtnRecap.BackColor = System.Drawing.Color.LightCoral
        Me.BtnRecap.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.BtnRecap.Location = New System.Drawing.Point(3, 190)
        Me.BtnRecap.Name = "BtnRecap"
        Me.BtnRecap.Size = New System.Drawing.Size(234, 25)
        Me.BtnRecap.TabIndex = 14
        Me.BtnRecap.Text = "Voir le récaptitulatif des saisies"
        '
        'Arrivée
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.BtnRecap)
        Me.Controls.Add(Me.BTerm)
        Me.Controls.Add(Me.BtnCont)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnDelQtité)
        Me.Controls.Add(Me.TbQtité)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnDelDétach)
        Me.Controls.Add(Me.TbScan)
        Me.Name = "Arrivée"
        Me.Text = "Arrivée"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TbScan As System.Windows.Forms.TextBox
    Friend WithEvents BtnDelDétach As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnDelQtité As System.Windows.Forms.Button
    Friend WithEvents TbQtité As System.Windows.Forms.TextBox
    Friend WithEvents BtnCont As System.Windows.Forms.Button
    Friend WithEvents BTerm As System.Windows.Forms.Button
    Friend WithEvents BtnRecap As System.Windows.Forms.Button
End Class
