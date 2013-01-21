Imports System.ServiceModel.Syndication
Imports System.Xml

Partial Class _Example4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RSSReader As XmlReader = XmlReader.Create(ConfigurationManager.AppSettings("rssUri"))
        Dim formatter As New Rss20FeedFormatter()
        formatter.ReadFrom(RSSReader)
        lblTitle.Text = formatter.Feed.Title.Text
        lblDescription.Text = formatter.Feed.Description.Text
        hlRss.NavigateUrl = formatter.Feed.Links(0).Uri.AbsoluteUri
        lvRSS.DataSource = formatter.Feed.Items
        lvRSS.DataBind()
    End Sub

End Class