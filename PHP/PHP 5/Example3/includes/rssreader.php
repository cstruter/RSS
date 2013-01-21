<?php                            

class RSSReader 
{
    public function RSSReader($url) 
    {
        $contents = file_get_contents($url); 
        $rss = new SimpleXmlElement($contents);
        $this->title = $rss->channel->title;
        $this->link = $rss->channel->link;
        $this->decription = $rss->channel->description;
        $this->date = $rss->channel->pubDate;
        $this->image = $rss->channel->image;
        $this->items = $rss->channel->item;
	}
}

?>