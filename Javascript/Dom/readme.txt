.net users please note that in js/rss.js you need to change the following
line:

xmlDoc.load('proxy/php/rssremote.php?url=' + escape(url));

to

xmlDoc.load('proxy/csharp/rssremote.aspx?url=' + escape(url));

or

xmlDoc.load('proxy/vb.net/rssremote.aspx?url=' + escape(url));