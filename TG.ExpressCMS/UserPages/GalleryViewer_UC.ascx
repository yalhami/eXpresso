<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GalleryViewer_UC.ascx.cs"
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

<%--<link href="../../JS/stylesheet1.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript" src="../../JS/mootools-1.2.1-core.js"></script>
<script language="javascript" type="text/javascript" src="../../JS/mootools-1.2-more.js"></script>
<script language="javascript" type="text/javascript" src="../../JS/slideitmoo-1.1.js"></script>
<script language="javascript" type="text/javascript" src="../../JS/slimbox.js"></script>--%>
<%--<script language="javascript" type="text/javascript">
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
                itemWidth: 70,
                showControls: 1,
                onChange: function (index) {
                    //alert(index);
                }
            });
        }
    });
</script>--%>
<link rel="stylesheet" type="text/css" href="/slideshow/style.css" />
<asp:UpdatePanel runat="server">
    <contenttemplate>
        <div class="ContentTitle">
            <asp:Label ID="lblGalleryViewer" runat="server"></asp:Label>
        </div>
        <br />
        <div id="dvMessages" runat="server">
        </div>
        <br />
            <div id="gallery">
        <table cellpadding="0" cellspacing="0" border="0">
        <tr>
        <td>
    
  <div id="imagearea">
    <div id="image">
      <a href="javascript:slideShow.nav(-1)" class="imgnav " id="previmg"></a>
      <a href="javascript:slideShow.nav(1)" class="imgnav " id="nextimg"></a>
    
  </div>
  </div>
        </td>
        </tr>
        </tr>
            <tr>
                <td>
                 <div id="thumbwrapper">
    <div id="thumbarea">
      <ul id="thumbs">
                            <asp:DataList ID="dlPhotogallery" runat="server" CssClass="content" RepeatColumns="10"
                                    RepeatDirection="Horizontal" BorderStyle="None" RepeatLayout="Table" Width="100%">
                                    <ItemTemplate>
                  <li value="1">
                                            <a id="abigimage" runat="server" href='<%#GetFullPath(DataBinder.Eval(Container,"DataItem.Path").ToString(),"full") %>'
                                                rel="lightbox[galerie]" target="_blank">
                                                <img id="ibtnItem" runat="server" border="0" src='<%#GetFullPath(DataBinder.Eval(Container,"DataItem.Path").ToString(),DataBinder.Eval(Container,"DataItem.Type").ToString()) %>'
                                                    onmouseover="setCursorByID(this,'pointer');" onmouseout="setCursorByID(this,'default');"
                                                    alt='<%#DataBinder.Eval(Container,"DataItem.Name") %>' width="86" height="63" />
                                            </a>
                                        
                                        
                                        <asp:Label ID="lblGalleryName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:Label>
                                        </li>
                                    </ItemTemplate>
                                </asp:DataList>
                                  </ul>
    </div>
  </div>
                </td>
            </tr>
        </table>
        </div>
        <%--  <table cellpadding="0" cellspacing="0" border="0" class="pager">
            <tr>
                <td class="btn_next">
                    <asp:LinkButton ID="lbPrevious" runat="server" Text=" "></asp:LinkButton>
                </td>
                <td class="btn_pre">
                    <asp:LinkButton ID="lbtnNext" runat="server" Text=" "></asp:LinkButton>
                </td>
            </tr>
        </table>--%>
        <uc2:CustomPager_UC ID="CustomPager_UC1" runat="server" />
        
<script type="text/javascript">
    var imgid = 'image';
    var imgdir = '../upload/Files/gallery';
    var imgext = '.jpg';
    var thumbid = 'thumbs';
    var auto = true;
    var autodelay = 5;
</script>
<script type="text/javascript" src="../js/slide.js"></script>
    </contenttemplate>
</asp:UpdatePanel>
