<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginUserSide_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.LoginUserSide_UC" %>
<script language="javascript" type="text/javascript">
    function ClearBoxs(txt) {
        txt.value = "";
    }

    function FillBoxs(txt, strVal) {
        if (txt.value == "") {
            txt.value = strVal;
        }
    }

</script>
<div class="ContentTitle">
    <asp:Label ID="Label1" runat="server" Text='<%$Resources:ExpressCMS, lblLoginTitle %>'></asp:Label>
</div>
<asp:UpdatePanel ID="upnlControls" runat="server">
    <ContentTemplate>
        <asp:Panel ID="plcControls" runat="server" DefaultButton="btnSaveUpdate">
            <div id="dvMessages" runat="server">
            </div>
            <table width="500" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" runat="server" Text='<%$Resources:ExpressCMS, lblUserName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" Width="200" CssClass="SubscribeFieldStyle" runat="server"
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text='<%$Resources:ExpressCMS, lblPassword %>'></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txtPassword" Width="200" runat="server" MaxLength="50" CssClass="SubscribeFieldStyle"
                            TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:HyperLink runat="server" CssClass="mlink1" ID="hypForgetPassword" Text='<%$Resources:ExpressCMS, hyoForgetPassword %>'></asp:HyperLink>
                        <Ajax:ModalPopupExtender ID="mpeShowResult" runat="server" TargetControlID="hypForgetPassword"
                            PopupControlID="pnlResult" CancelControlID="ibtnClose" BackgroundCssClass="backModal">
                        </Ajax:ModalPopupExtender>
                        <asp:Panel ID="pnlResult" runat="server" CssClass="PollContainer">
                            <table width="100%">
                                <tr>
                                    <td class="PollTitle">
                                        <span>
                                            <asp:Label runat="server" ID="HyperLink1" Text='<%$Resources:ExpressCMS, hyoForgetPassword %>'></asp:Label></span>
                                        <div style="float: left;">
                                            <asp:ImageButton ID="ibtnClose" runat="server" ToolTip='<%$Resources:ExpressCMS, Close %>'
                                                ImageUrl="~/App_Themes/DrNouh1/images/PollClose.png" /></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblEmails" runat="server" Text='<%$Resources:ExpressCMS, lblEmail %>'></asp:Label>
                                        <asp:TextBox runat="server" ID="txtEmail" MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                                            ValidationGroup="Forget" ErrorMessage='<%$Resources:ExpressCMS, lblEmail %>'
                                            Text="*"></asp:RequiredFieldValidator>
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Forget"
                                            HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                                            ShowMessageBox="true" ShowSummary="false" />
                                    </td>
                                </tr>
                            </table>
                            <div class="actions" style="float: left;">
                                <asp:Button CssClass="btnLoginUsers" runat="server" ID="btnSend" Text='<%$Resources:ExpressCMS, btnSend %>' />
                            </div>
                        </asp:Panel>
                    </td>
                    <td>
                        <asp:HyperLink NavigateUrl="~/UserPages/ForumRegistration.aspx" runat="server" ID="hypRegister"
                            Text='<%$Resources:ExpressCMS, hypRegister %>'></asp:HyperLink>
                    </td>
                </tr>
            </table>
            <div class="actions1">
                <asp:Button ID="btnSaveUpdate" runat="server" ValidationGroup="Login" Text='<%$Resources:ExpressCMS, loginButton %>'
                    CssClass="btnLoginUsers" />
            </div>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ValidationGroup="Login" ErrorMessage='<%$Resources:ExpressCMS, lblPassword %>'
                Text="*" Style="display: none;"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                ValidationGroup="Login" Text="*" ErrorMessage='<%$Resources:ExpressCMS, lblUserName %>'
                Style="display: none;"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="Login"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
