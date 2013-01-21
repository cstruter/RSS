using System.Collections.Generic;
using System.Xml;

public struct RSSItem
{
    private string _title;
    public string title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }

    private string _link;
    public string link
    {
        get
        {
            return _link;
        }
        set
        {
            _link = value;
        }
    }

    private string _description;
    public string description
    {
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }
}


public class RSSReader
{
    public string title;
    public string link;
    public string description;
    public List<RSSItem> items = new List<RSSItem>();

    public RSSReader(string url)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(url);

        XmlElement channel = doc["rss"]["channel"];
        XmlNodeList items = channel.GetElementsByTagName("item");
        this.title = channel["title"].InnerText;
        this.link = channel["link"].InnerText;
        this.description = channel["description"].InnerText;

        foreach (XmlNode item in items)
        {
            RSSItem rssItem = new RSSItem();
            rssItem.title = item["title"].InnerText;
            rssItem.description = item["description"].InnerText;
            rssItem.link = item["link"].InnerText;
            this.items.Add(rssItem);
        }
    }
}
