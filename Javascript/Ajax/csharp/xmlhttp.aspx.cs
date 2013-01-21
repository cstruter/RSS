using System;

public partial class xmlhttp : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RSSReader rssExamples = new RSSReader(Request.QueryString["url"]);
        rssControl.Title = rssExamples.title;
        rssControl.Description = rssExamples.description;
        rssControl.Link = rssExamples.link;
        rssControl.DataSource = rssExamples.items;
    }
}
