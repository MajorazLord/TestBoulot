<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmRecapTempsProduction
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
        Me.DGTempsProd = New System.Windows.Forms.DataGrid
        Me.LTempsProd = New System.Windows.Forms.Label
        Me.PBRetour = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        '
        'DGTempsProd
        '
        Me.DGTempsProd.BackgroundColor = System.Drawing.Color.White
        Me.DGTempsProd.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.DGTempsProd.Location = New System.Drawing.Point(0, 49)
        Me.DGTempsProd.Name = "DGTempsProd"
        Me.DGTempsProd.PreferredRowHeight = 25
        Me.DGTempsProd.RowHeadersVisible = False
        Me.DGTempsProd.Size = New System.Drawing.Size(240, 170)
        Me.DGTempsProd.TabIndex = 0
        '
        'LTempsProd
        '
        Me.LTempsProd.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LTempsProd.ForeColor = System.Drawing.Color.Peru
        Me.LTempsProd.Location = New System.Drawing.Point(0, 0)
        Me.LTempsProd.Name = "LTempsProd"
        Me.LTempsProd.Size = New System.Drawing.Size(240, 46)
        Me.LTempsProd.Text = "Récap Temps de Production"
        Me.LTempsProd.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PBRetour
        '
        Me.PBRetour.Location = New System.Drawing.Point(3, 225)
        Me.PBRetour.Name = "PBRetour"
        Me.PBRetour.Size = New System.Drawing.Size(66, 66)
        Me.PBRetour.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'frmRecapTempsProduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.PBRetour)
        Me.Controls.Add(Me.LTempsProd)
        Me.Controls.Add(Me.DGTempsProd)
        Me.KeyPreview = True
        Me.Name = "frmRecapTempsProduction"
        Me.Text = "Récap Tps Prod"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGTempsProd As System.Windows.Forms.DataGrid
    Friend WithEvents LTempsProd As System.Windows.Forms.Label
    Friend WithEvents PBRetour As System.Windows.Forms.PictureBox
End Class
