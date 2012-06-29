<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login_UC.ascx.cs" Inherits="TG.ExpressCMS.UI.Security.Login_UC" %>
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

<asp:UpdatePanel ID="upnlControls" runat="server">
    <ContentTemplate>
        <asp:PlaceHolder ID="plcControls" runat="server"><a style="font-weight: bolder; margin-left: 7px;">
        </a>
            <div id="dvMessages" runat="server">
            </div>
            <table width="500" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="10" height="20">
                        &nbsp;
                    </td>
                    <td width="55" height="20">
                        <span class="LoginLabel" style="width: 48px; padding-top: 5px">Username</span>
                    </td>
                    <td width="130" height="20">
                        <span class="LoginLabel" style="width: 132px">
                            <asp:TextBox Width="129" ID="txtUsername" runat="server" MaxLength="50"></asp:TextBox>
                        </span>
                    </td>
                    <td width="55" height="20">
                        <span class="LoginLabel" style="width: 48px; padding-top: 5px">Password</span>
                    </td>
                    <td width="130" height="20">
                        <span class="LoginLabel" style="width: 122px">
                            <asp:TextBox Width="129" ID="txtPassword" Style="margin-top: 5px;" runat="server"
                                MaxLength="50" TextMode="Password"></asp:TextBox>
                            <div class="LoginLabel" style="width: 48px; padding-top: 1px">
                        </span>
                    </td>
                    <td width="3" height="20">
                        <span class="LoginLabel" style="width: 48px; padding-top: 1px">
                            <asp:Button ID="btnSaveUpdate" runat="server" Text="Login" CssClass="LoginButton"
                                ValidationGroup="Login" />
                        </span>
                    </td>
                    <td width="10" height="20">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ValidationGroup="Login" ErrorMessage="Password" Text="*" Style="display: none;"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                ValidationGroup="Login" Text="*" ErrorMessage="E-Mail" Style="display: none;"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="Login"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
