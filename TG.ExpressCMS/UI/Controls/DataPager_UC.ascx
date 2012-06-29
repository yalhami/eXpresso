<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="DataPager_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Controls.DataPager_UC" %>
<asp:UpdatePanel ID="upnlPager" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlPager" runat="server" DefaultButton="ibtnJumptoPage">
            <table>
                <tr>
                    <td>
                        <a id="hrefNext" runat="server">
                        <img id="Img2" runat="server" alt='<%$Resources:ControlResource,Next %>' src="~/App_Themes/UserSides/Images/previous.png" />   
                        </a>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Label ID="lblTitlePage" Text='<%$Resources:ControlResource,Page %>' runat="server"></asp:Label>
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
                        <img id="Img1" runat="server" alt='<%$Resources:ControlResource,Previous %>' src="~/App_Themes/UserSides/Images/next.png" />
                        
                        
                         
                            
                        </a>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
