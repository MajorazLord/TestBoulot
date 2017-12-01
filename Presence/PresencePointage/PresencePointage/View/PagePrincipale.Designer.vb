<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class PagePrincipale
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
        Me.components = New System.ComponentModel.Container
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.CbSect = New System.Windows.Forms.ComboBox
        Me.PagePrincipaleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.PagePrincipaleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(0, 1)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(240, 22)
        Me.DateTimePicker1.TabIndex = 0
        '
        'RadioButton1
        '
        Me.RadioButton1.Location = New System.Drawing.Point(1, 29)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(49, 20)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.Text = "MAT"
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(47, 29)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(47, 20)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "SOI"
        '
        'RadioButton3
        '
        Me.RadioButton3.Location = New System.Drawing.Point(94, 29)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(47, 20)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.Text = "NUI"
        '
        'RadioButton4
        '
        Me.RadioButton4.Location = New System.Drawing.Point(142, 29)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(54, 20)
        Me.RadioButton4.TabIndex = 4
        Me.RadioButton4.Text = "WE1"
        '
        'RadioButton5
        '
        Me.RadioButton5.Location = New System.Drawing.Point(189, 29)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(51, 20)
        Me.RadioButton5.TabIndex = 5
        Me.RadioButton5.Text = "WE2"
        '
        'CbSect
        '
        Me.CbSect.Location = New System.Drawing.Point(0, 54)
        Me.CbSect.Name = "CbSect"
        Me.CbSect.Size = New System.Drawing.Size(240, 22)
        Me.CbSect.TabIndex = 6
        '
        'PagePrincipaleBindingSource
        '
        Me.PagePrincipaleBindingSource.DataSource = GetType(PresencePointage.PagePrincipale)
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(0, 76)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(240, 218)
        Me.TreeView1.TabIndex = 8
        '
        'PagePrincipale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 294)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.CbSect)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.KeyPreview = True
        Me.Name = "PagePrincipale"
        Me.Text = "Form1"
        CType(Me.PagePrincipaleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents CbSect As System.Windows.Forms.ComboBox
    Friend WithEvents PagePrincipaleBindingSource As System.Windows.Forms.BindingSource

End Class
