<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ThreadViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Forum.ThreadViewer_UC" %>
<%@ Register Src="~/UI/Controls/DataPager_UC.ascx" TagName="DataPager_UC" TagPrefix="controls" %>
<%@ Register Src="~/UI/Controls/PagePath_UC.ascx" TagName="PagePath_UC" TagPrefix="uc1" %>
<asp:PlaceHolder ID="plcThread" runat="server">
    <uc1:PagePath_UC ID="ucPagePath" runat="server" />
    <table class="TableBorder" width="100%" border="0" cellspacing="0" cellpadding="0">
        <colgroup width="20%" />
        <colgroup width="80%" />
        <tr>
            <td class="ForumHeader" style="width: 80%">
                <asp:Label ID="lblThreadName" runat="server"></asp:Label>
            </td>
            <td class="ForumHeader" style="width: 20%">
                <asp:Label ID="lblHeaderThreadTotalPosts" runat="server" Text='<%$Resources:ForumResource,TotalPosts %>'></asp:Label>(
                <asp:Label ID="lblTotalPosts" runat="server"></asp:Label>)
            </td>
        </tr>
    </table>
    <table class="TableBorder" width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="ForumHeaderSub" style="width: 20%">
                <center>
                    <span class="lblfourm">
                        <asp:Label ID="lblAddedby" runat="server" Text='<%$Resources:ForumResource,lblAddedby %>'></asp:Label></span>
                    <table>
                        <tr>
                            <td>
                                <asp:Image ID="imgUser" runat="server" CssClass="imguser" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>
                                    <asp:HyperLink ID="hypForumUserProfile" runat="server"></asp:HyperLink>
                                </b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblcount" runat="server" Text='<%$Resources:ForumResource,lblParticipationcount %>'></asp:Label>(<asp:Label
                                    ID="lblThreadTotalPostsValue" runat="server"></asp:Label>)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="ratingg">
                                    <Ajax:Rating ID="ratingThreadUser" runat="server" MaxRating="5" StarCssClass="ratingStar"
                                        Enabled="true" ReadOnly="true" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar"
                                        EmptyStarCssClass="emptyRatingStar" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </center>
            </td>
            <td class="ForumHeaderSub" width="80%" valign="top">
                <div id="dvThreadDetails" runat="server">
                </div>
                <asp:HyperLink CssClass="addpost_link" ID="hypAddPost" runat="server" Text='<%$ Resources:ForumResource,AddPosts%>'></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="ForumRowOdd" style="display: none" colspan="2">
                <asp:Label ID="lblPosts" Text='<%$Resources:ForumResource,Posts%>' runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:DataList CssClass="PostList" DataKeyField="ID" RepeatColumns="1" RepeatDirection="Horizontal"
                    RepeatLayout="table" ID="dlPosts" runat="server" Width="100%" CellPadding="0"
                    CellSpacing="0">
                    <ItemTemplate>
                        <table class="TableBorder" width="100%" border="0" cellspacing="0" cellpadding="0">
                            <colgroup width="20%" valign="top" style="vertical-align: top; text-align: center" />
                            <colgroup width="80%" valign="top" />
                            <tr>
                                <td class="LFT-BRDR">
                                    <center>
                                        <asp:Image CssClass="imguser" ID="imgUser" ImageUrl='<%#GetForumUserImage(DataBinder.Eval(Container, "DataItem.UserSummary.Image").ToString()) %>'
                                            runat="server" Width="80px" Height="80px" />
                                        <b>
                                            <br />
                                            <asp:Label CssClass="usrnme" ID="lblUserName" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UserSummary.UserName")%>'></asp:Label></b>
                                        <br />
                                        <asp:Label ID="lblPostTime" CssClass="pstdte" runat="server" Text='<%#GetDateByFormat(DataBinder.Eval(Container, "DataItem.CreationDate"),"dd/MM/yy HH:mm")%>'></asp:Label>
                                        <br />
                                        <div class="ratingg">
                                            <Ajax:Rating ID="ratingPostUser" runat="server" CurrentRating='<%#DataBinder.Eval(Container, "DataItem.UserSummary.UserRateValue")%>'
                                                MaxRating="5" StarCssClass="ratingStar" ReadOnly="true" Enabled="false" WaitingStarCssClass="savedRatingStar"
                                                FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" />
                                        </div>
                                        <br />
                                        <span class="signeture">
                                            <asp:Label ID="lblSignature" runat="server" Text='<%$ Resources:ForumResource,lblSignature%>'></asp:Label></span>
                                        <div class="dvUserSignature">
                                            <%#DataBinder.Eval(Container, "DataItem.UserSummary.Signature")%>
                                        </div>
                                        <td class="ForumRowEven" valign="top">
                                            <b>
                                                <asp:Label CssClass="title-subj" ID="lblPostSubject" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Name")%>'></asp:Label></b>
                                            <span id="spanPostDetails">
                                                <%#DataBinder.Eval(Container, "DataItem.DetailsHtml")%>
                                            </span>
                                            <asp:HyperLink ID="hypAddPost" CssClass="addpost_link" runat="server" Text="<%$ Resources:ForumResource,AddPosts%>"
                                                NavigateUrl='<%#GetAddPostURL(Convert.ToInt32(DataBinder.Eval(Container, "DataItem.ForumThreadID")),Convert.ToInt32(DataBinder.Eval(Container, "DataItem.ID"))) %>'></asp:HyperLink>
                                    </center>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="pagerz">
                    <controls:DataPager_UC ID="ucDataPager" runat="server" />
                </div>
            </td>
        </tr>
    </table>
</asp:PlaceHolder>
