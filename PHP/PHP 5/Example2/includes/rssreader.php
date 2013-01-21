<?php

class RSSReader
{
    public $items = array();

    public function RSSReader($url)
    {
        $xmlDoc = new COM("Microsoft.XMLDOM");
        $xmlDoc->async = false;
        $xmlDoc->load($url);
        $this->title = $this->getElement($xmlDoc, 'title');
        $this->link = $this->getElement($xmlDoc, 'link');
        $this->description = $this->getElement($xmlDoc, 'description');

        $items = $xmlDoc->getElementsByTagName('item');

        for ($i = 0; $i < $items->length; $i++) 
        {
            $this->items[$i] = array('title' => $this->getElement($items[$i], 'title'),
				                        'description' => $this->getElement($items[$i], 'description'),
				                        'link' => $this->getElement($items[$i], 'link'));
        }
    }

    private function getElement($parent, $tagName)
    {
        $element = $parent->getElementsByTagName($tagName);
        return $element[0]->firstChild->nodeValue;
    }	
}

?>