function RSS(url)
{	
    this.items = new Array();

    try
    {
        var xmlDoc = (document.all) ? new ActiveXObject("Microsoft.XMLDOM")
						            : document.implementation.createDocument("","",null);
        xmlDoc.async = false;
        xmlDoc.load('proxy/php/rssremote.php?url=' + escape(url));

        this.title = getElement(xmlDoc, 'title');
        this.link = getElement(xmlDoc, 'link');
        this.description = getElement(xmlDoc, 'description');

        var items = xmlDoc.getElementsByTagName('item');
        for (var i = 0; i < items.length; i++) 
        {
            this.items[i] = new function()
            {
                this.title = getElement(items[i], 'title');
                this.description = getElement(items[i], 'description');
                this.link = getElement(items[i], 'link');
            }
        }
    }	
    catch(e)
    {
        alert(e.message);
    }

    function getElement(parent, tagName)
    {
        return parent.getElementsByTagName(tagName)[0].firstChild.nodeValue;
    }
}

function RenderRSS(url, id)
{
	var rss = new RSS(url);
	var rssDiv = document.getElementById(id);
	var rssFeed = rssDiv.getElementsByTagName("div");
	
	for (var i = 0; i < rssFeed.length; i++)
	{
		switch (rssFeed.item(i).className)
		{
			case "FeedTitle": 	var output = Replace(unescape(rssFeed.item(i).innerHTML),"(::Title::)",rss.title);
								output = Replace(output,"(::Link::)",rss.link);
								output = Replace(output,"(::Description::)",rss.description);
								rssFeed.item(i).innerHTML = output;
							break;
			case "FeedItems": 	var buffer = "";
								for (var c = 0; c < rss.items.length; c++) 
								{
									var output = Replace(unescape(rssFeed.item(i).innerHTML),"(::Title::)", rss.items[c].title);
									output = Replace(output, "(::Link::)", rss.items[c].link);											
									output = Replace(output,"(::Description::)",rss.items[c].description);
									buffer+=output;
								}
								rssFeed.item(i).innerHTML = buffer;
							break;
		}
	}
}

function Replace(totalValue,oldValue,newValue)
{
	while(totalValue.indexOf(oldValue) > -1)
		totalValue=totalValue.replace(oldValue,newValue);
			return totalValue;
}