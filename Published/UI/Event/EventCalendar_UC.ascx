<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EventCalendar_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Event.EventCalendar_UC" %>
<asp:UpdatePanel ID="upnlSearch" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Calendar ID="cldEvent" runat="server" Width="100%"></asp:Calendar>
    </ContentTemplate>
</asp:UpdatePanel>
<input type="hidden" id="hdColor" runat="server" value="#F2C461" />
<asp:LinkButton ID="lbtnEvent" runat="server" CausesValidation="false" Style="display: none"></asp:LinkButton>
<Ajax:ModalPopupExtender runat="server" ID="mpEvent" TargetControlID="lbtnEvent"
    CancelControlID="imgEventExit" DropShadow="FALSE" PopupControlID="pnlEvent" BackgroundCssClass="backModal">
</Ajax:ModalPopupExtender>
<asp:Panel ID="pnlEvent" CssClass="PollContainer" runat="server" Width="500px">
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr>
            <td class="PollTitle">
                <span>
                    <asp:Label ID="lblEvent" runat="server" Text='<%$Resources:EventResource , lblEvents %>'></asp:Label></span>
                <div style="float: left;">
                    <asp:ImageButton ID="imgEventExit" runat="server" ToolTip="<%$Resources:EventResource , btnClose %>"
                        ImageUrl="~/App_Themes/DrNouh1/images/PollClose.png" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div style="float: right; display: none">
                    <asp:Label ID="lblEventHeader" Visible="false" runat="server" Text='<%$Resources:EventResource,Events %>'></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <div runat="server" id="dvEventloading" style="display: none" class="loadingPanel">
                    <img alt="Loading..." src="../../App_Themes/adminside/images/ajax-loader(2).gif" />
                </div>
                <asp:Panel ID="pnlEventData" runat="server">
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>
