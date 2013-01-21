<html>
	<head>
		<title>PHP 4 Example</title>
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
		</table>
	</body>
</html>