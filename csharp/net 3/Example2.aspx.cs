using System;
using System.Configuration;
using example2;

public partial class Example2 : System.Web.UI.Page
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
