<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Départ
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
        Me.BTerm = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.BtnSuppr = New System.Windows.Forms.Button
        Me.DGDépart = New System.Windows.Forms.DataGrid
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'BTerm
        '
        Me.BTerm.BackColor = System.Drawing.Color.CornflowerBlue
        Me.BTerm.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BTerm.Location = New System.Drawing.Point(122, 230)
        Me.BTerm.Name = "BTerm"
        Me.BTerm.Size = New System.Drawing.Size(115, 61)
        Me.BTerm.TabIndex = 23
        Me.BTerm.Text = "Terminer"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.LimeGreen
        Me.Label2.Location = New System.Drawing.Point(78, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 30)
        Me.Label2.Text = "Départ"
        '
        'BtnSuppr
        '
        Me.BtnSuppr.BackColor = System.Drawing.Color.Red
        Me.BtnSuppr.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSuppr.Location = New System.Drawing.Point(3, 230)
        Me.BtnSuppr.Name = "BtnSuppr"
        Me.BtnSuppr.Size = New System.Drawing.Size(115, 61)
        Me.BtnSuppr.TabIndex = 27
        Me.BtnSuppr.Text = "Supprimer"
        '
        'DGDépart
        '
        Me.DGDépart.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DGDépart.Location = New System.Drawing.Point(3, 49)
        Me.DGDépart.Name = "DGDépart"
        Me.DGDépart.RowHeadersVisible = False
        Me.DGDépart.Size = New System.Drawing.Size(234, 175)
        Me.DGDépart.TabIndex = 28
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label1.Location = New System.Drawing.Point(8, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(185, 20)
        Me.Label1.Text = "Scanner les contenants..."
        '
        'Départ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.DGDépart)
        Me.Controls.Add(Me.BtnSuppr)
        Me.Controls.Add(Me.BTerm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Départ"
        Me.Text = "Départ"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTerm As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnSuppr As System.Windows.Forms.Button
    Friend WithEvents DGDépart As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
