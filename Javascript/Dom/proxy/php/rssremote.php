<?php 
	header ("content-type: text/xml"); 
	echo file_get_contents($_REQUEST['url']); 
?> 