<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ContactsGroups_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Contact.ContactsGroups_UC" %>
<asp:UpdatePanel ID="upnlAll" runat="server">
    <ContentTemplate>
        <div class="ContentTitle">
            <asp:Label ID="lblHeader" runat="server" Text="Contacts Groups Manager"></asp:Label>
        </div>
        <br />
        <table width="100%">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblGroupName" runat="server" Text="Group Name"></asp:Label>
                    <asp:DropDownList ID="ddlGroups" runat="server" Width="254px" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr align="center">
                <td>
                    All Contacts
                </td>
                <td>
                </td>
                <td>
                    Contacts Groups
                </td>
            </tr>
            <tr align="center">
                <td>
                    <asp:ListBox ID="lstallContacts" runat="server" Width="250" Height="250px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnIn" runat="server" Text=">" Width="60" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnOut" runat="server" Text="<" Width="60" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:ListBox ID="lstGroupContact" runat="server" Width="250" Height="250px" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
