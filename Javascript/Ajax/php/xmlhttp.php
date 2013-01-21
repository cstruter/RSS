<table class="rssBlock">
<?php
	include "rssreader.php";

	$rss = new RSSReader($_REQUEST['url']);
	
	echo "<tr>
			<td class='rssParentTitle'>$rss->title</td>
		</tr>
		<tr>
			<td>$rss->description</td>
		</tr>";
	
	for($i = 0; $i < count($rss->items); $i++)
	{
		$title = $rss->items[$i]["title"];
		$description = $rss->items[$i]["description"];
		$link = $rss->items[$i]["link"];		
		
		echo "<tr>
				<td class='rssTitle'>$title</td>
			</tr>
			<tr>
				<td>$description</td>
			</tr>
			<tr>
				<td>
					<a href='$link'>Read More</a>
					<br />
					<br />
				</td>
			</tr>";
	}
?>