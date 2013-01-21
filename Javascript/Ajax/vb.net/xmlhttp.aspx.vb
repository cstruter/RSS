

Partial Class Xmlhttp
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rssExamples As New RSSReader(Request.QueryString("url"))
        rssControl.title = rssExamples.title
        rssControl.description = rssExamples.description
        rssControl.link = rssExamples.link
        rssControl.DataSource = rssExamples.items
    End Sub
End Class
