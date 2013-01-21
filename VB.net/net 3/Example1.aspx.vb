Imports Example1

Partial Class _Example1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rssExamples As New RSSReader(ConfigurationManager.AppSettings("rssUri"))
        rssControl.Title = rssExamples.title
        rssControl.Description = rssExamples.description
        rssControl.Link = rssExamples.link
        rssControl.DataSource = rssExamples.items
    End Sub
End Class
