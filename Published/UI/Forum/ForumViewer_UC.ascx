<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ForumViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Forum.ForumViewer_UC" %>
<%@ Register Src="~/UI/Controls/DataPager_UC.ascx" TagName="DataPager_UC" TagPrefix="controls" %>
<%@ Register Src="~/UI/Controls/PagePath_UC.ascx" TagName="PagePath_UC" TagPrefix="uc1" %>
<asp:PlaceHolder ID="plcForum" runat="server">
    <uc1:PagePath_UC ID="ucPagePath" runat="server" />
    <table class="TableBorder" width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td class="ForumHeader" width="80%">
                <asp:Label ID="lblForumName" runat="server"></asp:Label>
            </td>
            <td class="ForumHeader" width="20%">
                <asp:Label ID="lblForumTotalThreads" runat="server" Text='<%$Resources:ForumResource,TotalThreads %>'></asp:Label>
                &nbsp; (
                <asp:Label ID="lblForumTotalThreadsValue" runat="server"></asp:Label>
                )
            </td>
        </tr>
        <tr>
            <td colspan="3" class="ForumHeaderSub" style="display: none">
                <div id="dvForumDetails" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td class="ForumRowOdd" style="display: none">
                <asp:Label ID="lblThreadTitle" Text='<%$Resources:ForumResource,ThreadTitle %>' runat="server"></asp:Label>
            </td>
            <td class="ForumRowOdd" colspan="2">
                <asp:UpdatePanel ID="upnlAddThread" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:LinkButton ID="lbtnAddThread" runat="server"  Text='<%$ Resources:ForumResource, AddThread %>' />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upAddThread" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="pnlAddThread" runat="server" DefaultButton="btnAdd">
                            <div id="dvAddThreadMessages" runat="server">
                            </div>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <colgroup class="label" />
                                <colgroup />
                                <tr>
                                    <td class="ForumRowEven">
                                        <asp:Label ID="lblThreadName" Text='<%$Resources:ForumResource,Subject %>' runat="server"></asp:Label>
                                    </td>
                                    <td class="ForumRowEven">
                                        <asp:TextBox ID="txtThreadName" MaxLength="50" runat="server" CssClass="form SubscribeFieldStyle"
                                            Width="90%"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvThreadName" runat="server" ControlToValidate="txtThreadName"
                                            ValidationGroup="AddThread" Text="*" ErrorMessage='<%$Resources:ForumResource,Subject %>'></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="ForumRowEven">
                                        <asp:Label ID="lblThreadDetails" Text='<%$Resources:ForumResource,Details %>' runat="server"></asp:Label>
                                    </td>
                                    <td class="ForumRowEven">
                                        <asp:TextBox runat="server" ID="txtThreadDetails" TextMode="MultiLine" Width="90%"
                                            CssClass="SubscribeFieldStyle" Height="90px"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvThreadDetails" runat="server" ControlToValidate="txtThreadDetails"
                                            ValidationGroup="AddThread" Text="*" ErrorMessag='<%$Resources:ForumResource,Details %>'> </asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                            <div class="actions">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn1" ValidationGroup="AddThread"
                                    CausesValidation="true" Text='<%$Resources:ForumResource,btnSave %>' Width="80px" />
                            </div>
                            <asp:ValidationSummary ID="valsumAddThread" runat="server" DisplayMode="BulletList"
                                ShowMessageBox="True" ShowSummary="False" ValidationGroup="AddThread" HeaderText='<%$Resources:ForumResource, valSummHeader %>' />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="upnlThreads" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DataList CssClass="ForumThreadList" DataKeyField="ID" RepeatColumns="1" RepeatDirection="Horizontal"
                            RepeatLayout="table" ID="dlThreads" runat="server" Width="100%">
                            <ItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0" class="bgwhite-tbl">
                                    <tr>
                                        <td class="ForumRowOdd" width="35%">
                                            <asp:Label runat="server" ID="lbldlThreadName" CssClass="lblfourm" Text='<%$Resources:ForumResource,Thread %>'></asp:Label>
                                            <asp:HyperLink ID="hypThreadLink" runat="server" NavigateUrl='<%# GetThreadURL(Convert.ToInt32(DataBinder.Eval(Container, "DataItem.ID")))%>'
                                                Text='<%#DataBinder.Eval(Container, "DataItem.Name")%>'></asp:HyperLink>
                                        </td>
                                        <td width="25%">
                                            <table class="TableBorder" width="100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td class="ForumRowEven">
                                                         <asp:Image ID="imgUser" ImageUrl='<%#GetForumUserImage(DataBinder.Eval(Container, "DataItem.UserSummary.Image").ToString()) %>'
                                                            runat="server" CssClass="imguser" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ForumRowEven">
<asp:Label runat="server" ID="lbldlThreadCreatedBy" CssClass="lblfourm" Text='<%$Resources:ForumResource,CreatedBy %>'></asp:Label>
                                                                                                             
  <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UserSummary.UserName")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="ForumRowOdd" width="25%">
                                            <asp:Label runat="server" CssClass="lblfourm" ID="lbldlThreadCreationDate" Text='<%$Resources:ForumResource,CreationDate %>'></asp:Label>
                                            <asp:Label ID="lblThreadCreationDate" runat="server" Text='<%#GetDateByFormat(DataBinder.Eval(Container, "DataItem.CreationDate"),"dd/MM/yy HH:mm")%>'></asp:Label>
                                        </td>
                                        <td class="ForumRowOdd" width="15%">
                                            <asp:Label runat="server" CssClass="lblfourm" ID="lbldlThreadTotalPosts" Text='<%$Resources:ForumResource,TotalPosts %>'></asp:Label>(
                                            <asp:Label ID="lblThreadTotalPosts" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.TotalPosts")%>'></asp:Label>)
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                            <AlternatingItemTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0" class="bgwhite-tbl">
                                    <tr>
                                        <td class="ForumRowOdd" width="35%">
                                            <asp:Label runat="server" ID="lbldlThreadName" CssClass="lblfourm" Text='<%$Resources:ForumResource,Thread %>'></asp:Label>
                                            <asp:HyperLink ID="hypThreadLink" runat="server" NavigateUrl='<%# GetThreadURL(Convert.ToInt32(DataBinder.Eval(Container, "DataItem.ID")))%>'
                                                Text='<%#DataBinder.Eval(Container, "DataItem.Name")%>'></asp:HyperLink>
                                        </td>
                                        <td width="25%">
                                            <table class="TableBorder" width="100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td class="ForumRowEven">
                                                        <asp:Image ID="imgUser" CssClass="imguser" ImageUrl='<%#GetForumUserImage(DataBinder.Eval(Container, "DataItem.UserSummary.Image").ToString()) %>'
                                                            runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="ForumRowEven">
                                                        <asp:Label runat="server" ID="lbldlThreadCreatedBy" CssClass="lblfourm" Text='<%$Resources:ForumResource,CreatedBy %>'></asp:Label>
                                                        <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.UserSummary.UserName")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="ForumRowOdd" width="25%">
                                            <asp:Label runat="server" CssClass="lblfourm" ID="lbldlThreadCreationDate" Text='<%$Resources:ForumResource,CreationDate %>'></asp:Label>
                                            <asp:Label ID="lblThreadCreationDate" runat="server" Text='<%#GetDateByFormat(DataBinder.Eval(Container, "DataItem.CreationDate"),"dd/MM/yy HH:mm")%>'></asp:Label>
                                        </td>
                                        <td class="ForumRowOdd" width="15%">
                                            <asp:Label runat="server" CssClass="lblfourm" ID="lbldlThreadTotalPosts" Text='<%$Resources:ForumResource,TotalPosts %>'></asp:Label>
                                            <asp:Label ID="lblThreadTotalPosts" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.TotalPosts")%>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </AlternatingItemTemplate>
                        </asp:DataList>
                        <div>
                            <controls:DataPager_UC ID="ucDataPager" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:PlaceHolder>
