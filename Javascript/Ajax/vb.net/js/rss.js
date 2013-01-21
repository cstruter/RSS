function RSS(url, elementID)
{
	var html = document.getElementById(elementID);
	var xmlhttp = (window.XMLHttpRequest) ? new XMLHttpRequest() : new ActiveXObject("Microsoft.XMLHTTP");
		
	if (xmlhttp)
	{
		html.innerHTML = '<img src="img/ajax-loader.gif" />';
		xmlhttp.onreadystatechange = function() 
		{	
			if (xmlhttp.readyState==4) 
			{
				var html = document.getElementById(elementID);
				try
				{
					html.innerHTML =(xmlhttp.status == 200) ? xmlhttp.responseText : "RSS failed to load, error " + xmlhttp.status;
				}
				catch(ex)
				{
					html.innerHTML = ex.description;
				}
			}
		}
		xmlhttp.open("GET", "xmlhttp.aspx?url="+escape(url),true);
		xmlhttp.send(null);
	}
}