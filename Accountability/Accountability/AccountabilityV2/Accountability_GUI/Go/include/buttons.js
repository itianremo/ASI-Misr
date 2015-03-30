NS4 = (document.layers);
IE4 = (document.all);
DOM = (document.getElementById);
ver4 = (NS4 || IE4 || DOM) && !window.opera;
isMac = (navigator.appVersion.indexOf("Mac") != -1);

totalPages = 13;
arPages = new Array(totalPages);
for(i=1;i<=totalPages;i++){
arPages[i]=((i==1)?"index.html":i+".html");
}

impre = "../art/b_"

if (document.images) {
arImLoadB = new Array (
impre+"left_over",
impre+"left_down",
impre+"right_over",
impre+"right_down");
arImListB = new Array ();
for (xm=0;xm<arImLoadB.length;xm++) {
arImListB[xm] = new Image();
arImListB[xm].src = arImLoadB[xm] + ".gif";
}}

function movr(){this.img.src = this.img.overSrc}
function mout(){this.img.src = this.img.outSrc}
function mdown(){this.img.src = this.img.downSrc}
function makeButs(pos){
	var lr = "left";
	var lstr = ("<TABLE WIDTH=100%><TR VALIGN=TOP><TD ALIGN=LEFT><B><A HREF='/'>home</A> / <A HREF='/experts/'>experts</A> / <A HREF='/dhtml/'>dhtml</A> / ");
	if(curPage!=1){ lstr+="<A HREF='/dhtml/column67/'>column67</A> / " + curPage}else{ lstr+="column67</B>" };
	lstr+= "</TD><TD ALIGN=RIGHT>";
    document.write(lstr);
	for (i=1;i<arPages.length;i++){
		if (i==curPage) lr = "center";
		imstr = "<IMG SRC='"+ impre + lr + ".gif' WIDTH=18 HEIGHT=18 BORDER=0>";
		if (i==curPage) {document.write(imstr);lr="right";continue}
		document.write(imstr.link(arPages[i]));
		if(!ver4) continue;
		tLink =	document.links[document.links.length-1];
		tImg = tLink.img = document.images[document.images.length-1];
		tImg.outSrc = tImg.src;
		tImg.downSrc = impre + lr + "_down.gif";
		tImg.overSrc = impre + lr + "_over.gif";
		tLink.onmouseover = movr;
		tLink.onmouseout = tLink.onmouseup = mout;
		tLink.onmousedown = mdown;
	}
	var sPrevPage=((curPage==2)?"index":(curPage-1));
	var sPrev=(curPage==1)?"":"[ <A HREF='"+sPrevPage+".html'>Previous</A> ]";
    var sNextPage=(curPage+1);
	var sNext=(curPage==totalPages)?"":"[ <A HREF='"+sNextPage+".html'>Next</A> ]";
	document.write("<BR>"+sPrev+" "+sNext);
	document.write("</TD></TR></TABLE>");
}

