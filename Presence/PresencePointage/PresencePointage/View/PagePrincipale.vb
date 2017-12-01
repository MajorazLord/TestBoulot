Public Class PagePrincipale
    Private lesSites As DeuxSite

    Private Sub initSect(ByVal site As DeuxSite)
        CbSect.DataSource = site.LesSecteurs
    End Sub

    Private Sub initList(ByVal sect As Secteur)
        TreeView1.Visible = False
        TreeView1.CheckBoxes = True
        TreeView1.Nodes.Clear()
        For Each pdcs As Poste In sect.LesPdcs
            TreeView1.Nodes.Add(pdcs.Code)
        Next
        TreeView1.Visible = True
    End Sub

    Dim checkBoxes As New List(Of CheckBox)

    Private Sub PagePrincipale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lesSites = initTotal()
        initSect(lesSites)
        CbSect.DisplayMember = "Code"
        CbSect.SelectedIndex = 0
        initList(CbSect.SelectedItem)

    End Sub

    Private Sub CbSect_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CbSect.SelectedValueChanged
        initList(CbSect.SelectedItem)
    End Sub
End Class
