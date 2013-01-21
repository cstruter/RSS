Imports Example3

Partial Class _Example3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rssExamples As New RSSReader(ConfigurationManager.AppSettings("rssUri"))
        rssControl.title = rssExamples.title
        rssControl.description = rssExamples.description
        rssControl.link = rssExamples.link
        rssControl.DataSource = rssExamples.items
    End Sub

End Class
