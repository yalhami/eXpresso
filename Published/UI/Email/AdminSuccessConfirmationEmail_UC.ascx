<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AdminSuccessConfirmationEmail_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Email.AdminSuccessConfirmationEmail_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<script type="text/javascript">
    function HideDivMsg() {
        setTimeout("Hide();", 2000);
    }
    function Hide() {
        var dvmessages = document.getElementById('<%=dvmessages.ClientID %>');
        dvmessages.style.display = 'none';
    }
</script>
<div class="gridTitle">
    <asp:Label ID="lblAdminMessages" runat="server" Text="Newsletter messages administration"></asp:Label>
</div>
<asp:UpdatePanel ID="upnlall" runat="server">
    <ContentTemplate>
        <div id="dvmessages" runat="server">
        </div>
        <table>
            <tr>
                <td colspan="2" style="font-style: italic;">
                    Please use following parameter to define certain constants:
                    <br />
                    #Name# : Name of Contact.
                    <br />
                    #Email# : Email of Contact.
                    <br />
                    #Link# : Activation Link.
                </td>
            </tr>
        </table>
        <br />
        <hr />
        <table width="100%">
            <tr>
                <td style="vertical-align: top; width: 12%;">
                    <asp:Label ID="lblConfirmation" runat="server" Text="Confirnation E-Mail"></asp:Label>
                </td>
                <td>
                    <HTMLEditor:Editor runat="server" Height="300px" Width="65%" AutoFocus="true" ID="txtConfirmation" />
                    <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtConfirmation"
                        ValidationGroup="AddEditNewsletterMessages" Text="*" Display="Dynamic" ErrorMessage="txtConfirmation"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; width: 12%;">
                    <asp:Label ID="lblSuccess" runat="server" Text="Success E-Mail"></asp:Label>
                </td>
                <td>
                    <HTMLEditor:Editor runat="server" Height="300px" Width="65%" AutoFocus="true" ID="txtSuccess" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSuccess"
                        ValidationGroup="AddEditNewsletterMessages" Text="*" Display="Dynamic" ErrorMessage="txtSuccess"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditNewsletterMessages"
                Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
        </div>
        <asp:ValidationSummary ID="valsummaryHtml" runat="server" ValidationGroup="AddEditNewsletterMessages"
            HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
            ShowMessageBox="true" ShowSummary="false" />
    </ContentTemplate>
</asp:UpdatePanel>
