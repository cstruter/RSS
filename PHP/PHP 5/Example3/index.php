<html>
	<head>
		<title>PHP 5 SimpleXML Example</title>
		<link rel="stylesheet" type="text/css" href="styles/styles.css" />
	</head>

	<body>
		<table class="rssBlock">
		<?php
			include "includes/rssreader.php";

			$rss = new RSSReader('http://rss.cnn.com/rss/cnn_topstories.rss');
					
			echo "<tr>
					<td class='rssParentTitle'>$rss->title</td>
				</tr>
				<tr>
					<td>$rss->description</td>
				</tr>";
			
			foreach($rss->items as $item)
			{	
				echo "<tr>
						<td class='rssTitle'>$item->title</td>
					</tr>
					<tr>
						<td>$item->description</td>
					</tr>
					<tr>
						<td>
							<a href='$item->link'>Read More</a>
							<br />
							<br />
						</td>
					</tr>";
			}
		?>
		</table>
	</body>
</html>