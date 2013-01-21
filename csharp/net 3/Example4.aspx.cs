using System;
using System.Configuration;
using System.ServiceModel.Syndication;
using System.Xml;

public partial class Example4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XmlReader RSSReader = XmlReader.Create(ConfigurationManager.AppSettings["rssUri"]);
        Rss20FeedFormatter formatter = new Rss20FeedFormatter();
        formatter.ReadFrom(RSSReader);
        lblTitle.Text = formatter.Feed.Title.Text;
        lblDescription.Text = formatter.Feed.Description.Text;
        hlRss.NavigateUrl = formatter.Feed.Links[0].Uri.AbsoluteUri;
        lvRSS.DataSource = formatter.Feed.Items;
        lvRSS.DataBind();

        
    }
}
