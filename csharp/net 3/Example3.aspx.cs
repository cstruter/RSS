using System;
using System.Configuration;
using example3;

public partial class Example3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RSSReader rssExamples = new RSSReader(ConfigurationManager.AppSettings["rssUri"]);
        rssControl.Title = rssExamples.title;
        rssControl.Description = rssExamples.description;
        rssControl.Link = rssExamples.link;
        rssControl.DataSource = rssExamples.items;
    }
}
