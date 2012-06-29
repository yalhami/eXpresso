<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AddPost_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Forum.AddPost_UC" %>
<asp:PlaceHolder ID="plcAddPost" runat="server">
    <asp:UpdatePanel ID="upAddPosts" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="dvAddPostsProblems" visible="false" runat="server">
            </div>
            <div id="dvAddPostSuccessfully" visible="false" runat="server">
                <div>
                    <asp:Label ID="lblSavedSuccessfully" runat="server" Text='<%$Resources:ForumResource,SavedPostSuccessfully %>'></asp:Label>
                </div>
                <asp:HyperLink ID="hypReturn" Text='<%$Resources:ForumResource,Return %>' runat="server"></asp:HyperLink>
            </div>
            <asp:Panel ID="pnlAddPost" runat="server" DefaultButton="btnAdd">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <asp:Label ID="lblPostSubject" Text='<%$Resources:ForumResource,Subject %>' runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="SubscribeFieldStyle" ID="txtPostSubject" runat="server" MaxLength="50"
                                Width="250 px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPostName" runat="server" ControlToValidate="txtPostSubject"
                                ValidationGroup="AddPost" Text="*" ErrorMessage='<%$Resources:ForumResource,Subject %>'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPostDetails" Text='<%$Resources:ForumResource,Details %>' runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox CssClass="SubscribeFieldStyle" Width="250" Height="90" ID="txtPostDetails"
                                runat="server" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPostDetails" runat="server" ControlToValidate="txtPostDetails"
                                ValidationGroup="AddPost" Text="*" ErrorMessage="Details"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div class="actions marginAddppost">
                    <asp:Button ID="btnAdd" runat="server" ValidationGroup="AddPost" CausesValidation="true"
                        CssClass="btn" Text='<%$Resources:ForumResource,SavePost %>' />
                </div>
                <asp:ValidationSummary ID="valsumAddPost" runat="server" DisplayMode="BulletList"
                    ShowMessageBox="True" ShowSummary="False" ValidationGroup="AddPost" HeaderText='<%$Resources:ForumResource,valSummHeader %>' />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:PlaceHolder>
