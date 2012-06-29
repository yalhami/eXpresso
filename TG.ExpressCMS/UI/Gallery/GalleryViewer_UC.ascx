﻿<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GalleryViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Gallery.GalleryViewer_UC" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc2" %>
<script type="text/javascript">

    function setCursorByID(id, cursorStyle) {

        if (document.getElementById) {
            if (document.getElementById(id.id).style) {
                document.getElementById(id.id).style.cursor = cursorStyle;
            }
        }
    }
</script>
<script type="text/javascript" src="../../JS/highslide/highslide-with-gallery.js"></script>
<link rel="stylesheet" type="text/css" href="../../JS/highslide/highslide.css" />
<script type="text/javascript">
    hs.graphicsDir = '../../JS/highslide/graphics/';
    hs.align = 'center';
    hs.transitions = ['expand', 'crossfade'];
    hs.outlineType = 'rounded-white';
    hs.wrapperClassName = 'controls-in-heading';
    hs.fadeInOut = true;
    hs.dimmingOpacity = 0.75;

    // Add the controlbar
    if (hs.addSlideshow) hs.addSlideshow({
        //slideshowGroup: 'group1',
        interval: 5000,
        repeat: false,
        useControls: true,
        fixedControls: false,
        overlayOptions: {
            opacity: 1,
            position: 'top right',
            hideOnMouseOut: false
        }
    });
</script>
<div class="ContentTitle">
    <asp:Label ID="lblGalleryViewer" runat="server"></asp:Label>
</div>
<br />
<div id="dvMessages" runat="server">
</div>
<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
            <asp:DataList ID="dlPhotogallery" runat="server" CssClass="content" RepeatColumns="3"
                RepeatDirection="Horizontal" BorderStyle="None" RepeatLayout="Table" Width="480px">
                <ItemTemplate>
                    <a id="abigimage" runat="server" href='<%#GetFullPath(DataBinder.Eval(Container,"DataItem.Path").ToString(),"full") %>'
                        class="highslide" onclick="return hs.expand(this)">
                        <img id="ibtnItem" runat="server" width="150" height="120" border="0" src='<%#GetFullPath(DataBinder.Eval(Container,"DataItem.Path").ToString(),DataBinder.Eval(Container,"DataItem.Type").ToString()) %>'
                            onmouseover="setCursorByID(this,'pointer');" onmouseout="setCursorByID(this,'default');"
                            alt='<%#DataBinder.Eval(Container,"DataItem.Name") %>' />
                    </a>
                    <br />
                    <asp:Label ID="lblGalleryName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                        Visible="false"></asp:Label>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
<br />
<br />
<uc2:CustomPager_UC ID="CustomPager_UC1" runat="server" />
