Public Class frmAbout

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnOpenWebSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenWebSite.Click
        ' Shell("explorer.exe http://tocos-wireless.com/") ' opens with IE ;-(
        Process.Start("http://tocos-wireless.com/jp/tech/eHarvest.html") ' fine :-)
    End Sub
End Class