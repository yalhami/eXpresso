﻿<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="GalleryViewer2_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Gallery.GalleryViewer2_UC" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc2" %>
<script type="text/javascript">
    function SetBigImage(thumbnail) {
        var bigImage = document.getElementById('<%=imgbig.ClientID %>');
        bigImage.src = thumbnail.src.toString().replace('Thumb-', '');
        return false;
    }

    function setCursorByID(id, cursorStyle) {

        if (document.getElementById) {
            if (document.getElementById(id.id).style) {
                document.getElementById(id.id).style.cursor = cursorStyle;
            }
        }
    }
</script>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <div class="ContentTitle">
            <asp:Label ID="lblGalleryViewer" runat="server"></asp:Label>
        </div>
        <br />
        <div id="dvMessages" runat="server">
        </div>
        <br />
        <table>
            <tr>
                <td>
                    <div id="dvDetails" runat="server">
                    </div>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="imgbig" runat="server" Width="300" Height="215" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DataList ID="dlPhotogallery" runat="server" CssClass="content" RepeatColumns="3"
                                    RepeatDirection="Horizontal" BorderStyle="None" RepeatLayout="Table" Width="100%">
                                    <ItemTemplate>
                                        <img id="ibtnItem" runat="server" border="0" src='<%#GetFullPath(DataBinder.Eval(Container,"DataItem.Path").ToString(),DataBinder.Eval(Container,"DataItem.Type").ToString()) %>'
                                            onmouseover="setCursorByID(this,'pointer');" onmouseout="setCursorByID(this,'default');"
                                            onclick="SetBigImage(this);" alt='<%#DataBinder.Eval(Container,"DataItem.Name") %>' />
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <uc2:CustomPager_UC ID="CustomPager_UC1" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
