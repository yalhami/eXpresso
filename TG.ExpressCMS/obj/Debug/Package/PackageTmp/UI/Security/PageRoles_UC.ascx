<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PageRoles_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.PageRoles_UC" %>
<div class="gridTitle">
    <asp:Label ID="lblPagesPage" runat="server" Text="Pages Roles"></asp:Label>
</div>
<asp:UpdatePanel ID="upnlPagesRoles" runat="server">
    <ContentTemplate>
        <table width="width:100%">
            <tr>
                <td>
                    <asp:Label ID="lblPage" runat="server">Pages</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPages" runat="server" Width="254" AutoPostBack="true">
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
                                <asp:Label ID="lblOut" runat="server" Text="Page Roles"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="lstRoles" SelectionMode="Multiple" runat="server" Width="220" Height="140">
                                </asp:ListBox>
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
                                <asp:ListBox ID="lstPageRoles" SelectionMode="Single" runat="server" Width="220"
                                    Height="140"></asp:ListBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
