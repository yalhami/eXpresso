<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="UsersRoles_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.UsersRoles_UC" %>
<div class="gridTitle">
  
        <asp:Label ID="lblUsersPage" runat="server" Text="Users Roles"></asp:Label>
 
</div>
<asp:UpdatePanel ID="upnlUsersRoles" runat="server">
    <ContentTemplate>
        <table width="width:100%">
            <tr>
                <td>
                    <asp:Label ID="lblUser" runat="server">Users</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlUsers" runat="server" Width="254" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblRoles" runat="server" Text="All Roles"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td align="center">
                                <asp:Label ID="lblOut" runat="server" Text="User Roles"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="lstRoles" SelectionMode="Multiple" runat="server" Width="220" Height="140"></asp:ListBox>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnIn" runat="server" Text=">" CssClass="btn" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnOut" runat="server" Text="<" CssClass="btn" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:ListBox ID="lstUserRoles" SelectionMode="Single" runat="server" Width="220" Height="140"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
