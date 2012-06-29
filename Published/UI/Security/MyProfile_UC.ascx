<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyProfile_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.MyProfile_UC" %>
<div class="gridTitle">
    <asp:Label ID="lblXslPage" runat="server" Text="My Profile"></asp:Label>
</div>
<asp:UpdatePanel ID="upnlControls" runat="server">
    <ContentTemplate>
        <div id="dvMessages" runat="server">
        </div>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblUsersName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="UserProfile" Text="*" Display="Dynamic" ErrorMessage="Name "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmail %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="UserProfile" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="UserProfile" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="230" ID="txtPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                            ValidationGroup="UserProfile" Text="*" Display="Dynamic" ErrorMessage="Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="230" ID="txtConfirmPassword" runat="server" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" Operator="Equal" ValidationGroup="UserProfile"
                            ErrorMessage="Password doesn't match" Text="*" ValueToCompare="txtConfirmPassword"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMyRoles" runat="server" Text="My Roles"></asp:Label>
                    </td>
                    <td>
                        <asp:ListBox ID="lstmyRoles" runat="server" Width="250"></asp:ListBox>
                        <div id="dvSuperadmin" runat="server">
                        </div>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="UserProfile"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="UserProfile"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
