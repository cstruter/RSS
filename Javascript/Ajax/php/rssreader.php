<?php

class RSSReader 
{
    var $inItem = false;
    var $inChannel = false;
    var $currentTag = "";
    var $items = array();
    var $count = 0;	
	
    function RSSReader($url) 
    {
        $this->parser = xml_parser_create();
        xml_set_object($this->parser, $this);
        xml_set_element_handler($this->parser, "openElement", "closeElement");
        xml_set_character_data_handler($this->parser, "cdata");
        $contents = file_get_contents($url);
        xml_parse($this->parser, $contents);
        xml_parser_free($this->parser);
    }

    function openElement($parser, $tag, $attributes) 
    {
        switch($tag)
        {
            case "ITEM":				
                $this->inItem = true;
                $this->inChannel = false;
                $this->items[$this->count] = array();
                break;
            case "CHANNEL":
                $this->inChannel = true;
        }		
        $this->currentTag = strtolower($tag);
    }	

    function cdata($parser, $cdata) 
    {
        if ($this->inItem) 
        {			
            if ($this->currentTag != "item")
            {
                $this->items[$this->count][$this->currentTag].= $cdata;
            }
        }
        		
        if ($this->inChannel)
        {
            if ($this->currentTag == "image")
            {
                $this->inChannel = false;
            }
            else
            {
                $this->{$this->currentTag}.= $cdata;
            }
        }
    }

    function closeElement($parser, $tag) 
    {
        if ($tag == "ITEM")
        {
            $this->count++;
            $this->inItem = false;
            $this->inChannel = false;
        }
    }
}

?>