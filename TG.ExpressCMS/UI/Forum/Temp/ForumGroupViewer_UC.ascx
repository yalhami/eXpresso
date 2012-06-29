<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ForumGroupViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Forum.ForumGroupViewer_UC" %>
<asp:DataList RepeatColumns="1" CssClass="ForumGroupList" DataKeyField="ID" RepeatDirection="Horizontal"
    RepeatLayout="Flow" ID="dlGroups" runat="server">
    <HeaderTemplate>
        <asp:Label ID="lblGroupTitle" Style="display: none;" runat="server" Text='<%$Resources:ForumResource,GroupTitle %>'></asp:Label></a>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="ForumHeader">
            <asp:Label ID="lblGroupName" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.Name")%>'></asp:Label></a>
        </div>
        <div id="divForum">
            <asp:DataList RepeatColumns="1" CssClass="ForumList" DataKeyField="ID" RepeatDirection="Horizontal"
                RepeatLayout="Table" ID="dlForums" runat="server" Width="100%" CellPadding="0"
                CellSpacing="0">
                <ItemTemplate>
                    <table class="TableBorder" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="ForumRowOdd_IMG " width="5%">
                                <img src="/Upload/Files/EditorImage/topic.gif" />
                            </td>
                            <td class="ForumRowOdd" width="40%">
                                <asp:Label ID="lblGroupTitle" CssClass="lblfourm" runat="server" Text='<%$Resources:ForumResource,Forum %>'></asp:Label>
                                <asp:HyperLink ID="hlForum" NavigateUrl='<%#GetForumURL(Convert.ToInt32(DataBinder.Eval(Container, "DataItem.ID"))) %>'
                                    Text='<%#DataBinder.Eval(Container, "DataItem.Name")%>' runat="server"></asp:HyperLink>
                            </td>
                            <td class="ForumRowOdd" width="10%" style="text-align: center">
                                <asp:Label runat="server" CssClass="lblfourm" ID="lblTotalThreads" Text='<%$Resources:ForumResource,TotalThreads %>'></asp:Label>
                                <asp:Label ID="lblForumTotalThreads" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.TotalThreads")%>'></asp:Label>
                            </td>
                            <td class="ForumRowOdd" width="25%">
                                <asp:Label runat="server" ID="lblLastThread" CssClass="lblfourm" Text='<%$Resources:ForumResource,LastThread %>'></asp:Label>
                                <input id="hdnForumLastThread" type="hidden" value='<%#DataBinder.Eval(Container, "DataItem.LastForumThreadID")%>'
                                    runat="server" />
                                <asp:HyperLink ID="hlForumLastThread" Text='<%#DataBinder.Eval(Container, "DataItem.LastThreadName") %>'
                                    runat="server"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </ItemTemplate>
</asp:DataList>