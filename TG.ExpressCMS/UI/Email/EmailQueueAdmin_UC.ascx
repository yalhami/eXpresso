<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EmailQueueAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Email.EmailQueueAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblHistoryQueue" runat="server" Text='<%$Resources:ExpressCMS,lblHistoryQueue %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server">
        </div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblEmails" runat="server" Text='<%$Resources:ExpressCMS,lblEmails %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmails" runat="server" Width="254px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblSendingStatus" runat="server" Text='<%$Resources:ExpressCMS,lblSendingStatus %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSendingstatus" runat="server" Width="254px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDeliveryStatussearch" runat="server" Text='<%$Resources:ExpressCMS,lblDeliveryStatussearch %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSeliveryStatus" runat="server" Width="254px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblReciverEmail" runat="server" Text='<%$Resources:ExpressCMS,lblReciverEmail %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="250"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationGroup="SearchQueue" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ErrorMessage="*">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDateSearch" runat="server" Text='<%$Resources:ExpressCMS,lblDateSearch %>'></asp:Label>
                </td>
                <td>
                    <asp:TextBox Width="135" ID="txtDateSearch" runat="server" MaxLength="50"></asp:TextBox>
                    <Ajax:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateSearch"
                        CssClass="cal_Theme1" Format="dd/MM/yyyy" PopupButtonID="ibtnFrom" />
                    <asp:ImageButton ID="ibtnFrom" Width="23" Height="23" runat="server" ImageUrl="~/App_Themes/Adminside2/Images/calendar.png" />
                </td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" ValidationGroup="SearchQueue"
                CausesValidation="true" />
        </div>
        <h3>
            <asp:Label ID="lblVTotalItemsOnQueue" runat="server" Text="Total Items on Queue :"></asp:Label>
            <asp:Label ID="lblTotalItemsOnQueue" runat="server" Text=""></asp:Label>
        </h3>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <%-- <asp:ImageButton ID="ibtnDelete" runat="server" Text='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/Adminside2/Images/delete.png" OnClientClick="return ConfirmDelete();"
                    Visible="true"></asp:ImageButton>--%>
                <asp:ImageButton ID="ibtntoExcel" runat="server" Width="17" Height="17" ImageUrl="~/App_Themes/AdminSide2/Images/xls.png"
                    ToolTip="Export to Excel" />
            </div>
            <div class="gridTitle">
                <asp:Label ID="lblEmailHistory" runat="server" Text='<%$Resources:ExpressCMS,lblEmailHistory %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvEmail" runat="server" AutoGenerateColumns="false" CssClass="grd"
                    Height="20px" Width="100%" AllowPaging="true" PageSize="65">
                    <EmptyDataTemplate>
                        <a>No data returned,please select search criterea </a>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField DataField="RecieverName" HeaderText="Receiver Name" />
                        <asp:BoundField DataField="ReciverAddress" HeaderText="Receiver Email" />
                        <asp:BoundField DataField="SentDate" HeaderText="Sent Date" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblSendingStatus" runat="server" Text="Sending Status"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSendingStatus" runat="server" Text='<%#GetSendingStatus(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.SendingStatus"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblDeliveryStatus" runat="server" Text="Delivery Status"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDeliverStatus" runat="server" Text='<%#GetDeliveryStatus(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.DeliveryStatus"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblSentBy" runat="server" Text="Sent By"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSentByH" runat="server" Text='<%#GetUser(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.SentBy"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ibtntoExcel" />
    </Triggers>
</asp:UpdatePanel>
