<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="SmtpandEmailAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Email.SmtpandEmailAdmin_UC" %>
<script language="javascript" type="text/javascript">
    function HideShowCredential() {

        var trcredential1 = document.getElementById('<%=trCredential1.ClientID %>');
        var trcredential2 = document.getElementById('<%=trCredential2.ClientID %>');

        if (trcredential2.style.display == 'none') {
            trcredential2.style.display = 'block';
            trcredential1.style.display = 'block';
        }
        else {
            trcredential2.style.display = 'none';
            trcredential1.style.display = 'none';
        }
    }

</script>
<script type="text/javascript">

    function HideMessage(timeout) {

        setTimeout("HideDiv1();", timeout);
    }
    function HideDiv1(dvmsg1) {

        var dvmsg = document.getElementById("<%=dvMessage.ClientID%>");
        dvmsg.style.display = 'none';
    }

</script>
<h4>
    <asp:Label ID="lblSmtp" runat="server" Text='<%$Resources:ExpressCMS,lblSmtpAdmin %>'></asp:Label>
</h4>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvMessage" runat="server" class="dvmessages">
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblHost" runat="server" Text='<%$Resources:ExpressCMS,lblHost %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="198" ID="txtHost" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:Button ID="btnDNS" Width="50" CssClass="btn" Height="21" runat="server" Text='<%$Resources:ExpressCMS,btnDNS %>'
                        ValidationGroup="AddEditEmail" />
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtHost"
                        ValidationGroup="AddEditEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblHost %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPort" runat="server" Text='<%$Resources:ExpressCMS,lblPort %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="100" ID="txtPort" runat="server" MaxLength="50"></asp:TextBox>
                    <Ajax:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtPort"
                        FilterType="Numbers" ValidChars="" />
                    <asp:RequiredFieldValidator ID="rfvPort" runat="server" ControlToValidate="txtPort"
                        ValidationGroup="AddEditEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPort %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="1">
                    <asp:Label ID="lbluserCredential" runat="server" Text='<%$Resources:ExpressCMS,lbluserCredential %>'></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkUseCredential" runat="server" onclick="HideShowCredential();" />
                </td>
            </tr>
            <tr runat="server" id="trCredential1" style="display: none;">
                <td>
                    <asp:Label ID="lblUsername" runat="server" Text='<%$Resources:ExpressCMS,lblUsername %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="100" ID="txtUserName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName"
                        ValidationGroup="AddEditEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblUsername %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr runat="server" id="trCredential2" style="display: none;">
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text='<%$Resources:ExpressCMS,lblPassword %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="80" ID="txtPassowrd" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassowrd"
                        ValidationGroup="AddEditEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPassword %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEnableSSL" runat="server" Text='<%$Resources:ExpressCMS,lblEnableSSL %>'></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkEnableSSL" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSenderName" runat="server" Text='<%$Resources:ExpressCMS,lblSenderName %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="250" ID="txtSenderName" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSenderName" runat="server" ControlToValidate="txtSenderName"
                        ValidationGroup="AddEditEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblSenderName %>'></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbltxtSenderEmail" runat="server" Text='<%$Resources:ExpressCMS,lbltxtSenderEmail %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="250" ID="txtSenderEmail" runat="server" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSenderemail" runat="server" ControlToValidate="txtSenderEmail"
                        ValidationGroup="AddEditEmail" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lbltxtSenderEmail %>'></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtSenderEmail"
                        ValidationGroup="AddEditEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage='<%$Resources:ExpressCMS,lbltxtSenderEmail %>'>*</asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditEmail"
                Text='<%$Resources:ExpressCMS, btnAddEditSMTP %>' />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="AddEditEmail"
    HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
    ShowMessageBox="true" ShowSummary="false" />
