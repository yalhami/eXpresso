<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CustomPager_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Controls.CustomPager_UC" %>
<asp:Panel ID="pnlPager" runat="server" DefaultButton="ibtnJumptoPage">
    <table>
        <tr>
            <td>
                <a id="hrefNext" runat="server">
                    <asp:ImageButton ID="imgNext" runat="server" ToolTip='<%$Resources:ControlResource,Next %>'
                        ImageUrl="~/App_Themes/UserSides/Images/next.png" />
                </a>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblPageNo" Text='<%$Resources:ControlResource,Page %>' runat="server"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="SubscribeFieldStyle" ID="txtCurrentPage" runat="server" Width="30"
                    Height="20px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="lblTitleOfPage" Text='<%$Resources:ControlResource,Of %>' runat="server"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblTotalPages" runat="server"></asp:Label>
            </td>
            <td>
                <asp:ImageButton ID="ibtnJumptoPage" runat="server" ToolTip='<%$Resources:ControlResource,GoPage %>'
                    CssClass="pages" ImageUrl="~/App_Themes/UserSides/Images/go.png" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <a id="hrefPrevious" runat="server">
                    <asp:ImageButton ID="imgPrevious" runat="server" ToolTip='<%$Resources:ControlResource,Previous %>'
                        ImageUrl="~/App_Themes/UserSides/Images/previous.png" />
                </a>
            </td>
        </tr>
    </table>
</asp:Panel>
