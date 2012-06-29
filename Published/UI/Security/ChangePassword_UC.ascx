<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ChangePassword_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.ChangePassword_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblXslPage" runat="server" Text="Change Passwords"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlControls" runat="server">
    <ContentTemplate>
        <div id="dvMessages" runat="server">
        </div>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="230" ID="txtPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="ChangePassword" Text="*" Display="Dynamic" ErrorMessage="Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="230" ID="txtConfirmPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" Operator="Equal" ValidationGroup="ChangePassword"
                            ErrorMessage="Password doesn't match" Text="*" ValueToCompare="txtConfirmPassword"></asp:CompareValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="ChangePassword"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="ChangePassword"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
