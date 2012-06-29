<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GalleryViewer2_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Gallery.GalleryViewer2_UC" %>
<script language="javascript" type="text/javascript" src="http://www.bishop.edu.jo/js/mootools-1.2.1-core.js"></script>
<script language="javascript" type="text/javascript" src="http://www.bishop.edu.jo/mootools-1.2-more.js"></script>
<script language="javascript" type="text/javascript" src="http://www.bishop.edu.jo/js/slideitmoo-1.1.js"></script>
<script language="javascript" type="text/javascript" src="http://www.bishop.edu.jo/js/slimbox.js"></script>
<script language="javascript" type="text/javascript">

    window.addEvents({
        'domready': function () {
            /* thumbnails example , div containers */
            new SlideItMoo({
                overallContainer: 'SlideItMoo_outer',
                elementScrolled: 'SlideItMoo_inner',
                thumbsContainer: 'SlideItMoo_items',
                itemsVisible: 6,
                elemsSlide: 5,
                duration: 400,
                itemsSelector: '.SlideItMoo_element',
                itemWidth: 95,
                showControls: 1,
                onChange: function (index) {
                    //alert(index);
                }

            });
        }
    });
</script>
<div id="SlideItMoo_outer">
    <div id="SlideItMoo_inner">
        <div id="SlideItMoo_items">
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-1.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/1.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-2.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/2.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-3.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/3.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-4.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/4.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-5.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/5.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-6.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/6.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-7.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/7.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-8.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/8.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-9.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/9.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/thumb-1.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/1.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/a1.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/a.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/A2.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/b.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/a3.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/c.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/a4.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/d.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/a5.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/e.jpg" width="61"
                        height="61" /></a></div>
            <div class="SlideItMoo_element">
                <a href="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/a6.jpg" rel="lightbox[galerie]"
                    target="_blank">
                    <img alt="" src="http://www.bishop.edu.jo/Portal1/Upload/Block/Image/f.jpg" width="61"
                        height="61" /></a></div>
        </div>
    </div>
</div>
