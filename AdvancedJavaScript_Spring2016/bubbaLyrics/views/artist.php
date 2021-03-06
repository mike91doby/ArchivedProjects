<script type="text/javascript" src="http://ict.neit.edu/001264912/public_html/se251/bubbaLyrics/scripts/artistScript.js"></script>
<script type="text/javascript" src="http://ict.neit.edu/001264912/public_html/se251/bubbaLyrics/scripts/canvas.js"></script>

<div class="row">
	<div class="container-fluid">
		<div class="col-md-12" style= "background-color:#262626;color:white;">
            <canvas id="canvas" width="1800" height="100"></canvas>
      <img id="musicNote" width="0" height="0" src="http://ict.neit.edu/001264912/public_html/se251/bubbaLyrics/images/musicNote.png" alt="Music Note">
			<h1 id="songName" style="text-align:center;"></h1>
		</div>
	</div>
    
</div>

<div class="row">
	<div class="container-fluid">
		
		<div class="col-md-6" style="margin-top:15px;">
            <p><em><strong>Click an album to view songs from specified album...</strong></em></p>
			<div class="panel panel-primary">
				<!-- Default panel contents -->
				<div class="panel-heading">Albums</div>
				<table id="tblAlbums" class="table table-hover"></table>
			</div>
			<ul class="pager">
				<li id="albumPrev"><a href="#">Previous</a></li>
				<li id="albumNxt"><a href="#">Next</a></li>
			</ul>
		</div>
	
		<div class="col-md-6" style="margin-top:15px;">
            <p><em><strong>Click a song to view the lyrics from specified song...</strong></em></p>
			<div class="panel panel-primary">
				<!-- Default panel contents -->
				<div id="albumName" class="panel-heading">Songs</div>
				<table id="tblSongs" class="table table-hover"></table>
			</div>
		</div>
        
		
	</div>
</div>
