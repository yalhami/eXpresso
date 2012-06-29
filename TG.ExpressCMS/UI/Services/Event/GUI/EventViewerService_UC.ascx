<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EventViewerService_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Services.EventViewerService_UC" %>
<div id="dvNoRecords" runat="server" visible="false" class="lbltd bld_lbl prblm_msg">
</div>
<table width="100%" border="0" cellpadding="1" cellpadding="1">
    <asp:DataList ID="dlsEvent" runat="server" CssClass="dlsEvent-css" RepeatDirection="Vertical"
        RepeatLayout="Flow" RepeatColumns="1" Width="100%">
        <HeaderTemplate>
            <%--'<%$Resources:EventResource,StartTime %>''<%$Resources:EventResource,EndTime %><%$Resources:EventResource,EventTitile %>'--%>
            <tr>
                <td>
                    <%--<asp:Label Visible="false" ID="lblHEventEndTime" CssClass="dlsEvent-HEndTime" runat="server" Text="وقت النهايه"></asp:Label>--%>
                    الموضوع
                </td>
                <td>
                    <asp:Label runat="server" CssClass="dlsEvent-HStratTime" ID="lblHEventStartTime"
                        Text="وقت البدايه"></asp:Label>
                </td>
                <td>
                  <%--  <asp:Label runat="server" CssClass="dlsEvent-HName" ID="lblHEventName" Text="تاريخ الحدث"></asp:Label>--%>
                  وقت النهايه
                </td>
            </tr>
            <br />
        </HeaderTemplate>
        <HeaderStyle CssClass="dlsEvent-Header" />
        <ItemTemplate>
            <tr>
                <td>
                    <asp:HyperLink ID="lblEventName" Text='<%#GetEventTitle(DataBinder.Eval(Container, "DataItem.Name").ToString())%>'
                        CssClass="dlsEvent-IDetails" ToolTip='<%#DataBinder.Eval(Container, "DataItem.Name")%>'
                        runat="server" NavigateUrl='<%#GetURLDetails(Convert.ToInt32(DataBinder.Eval(Container, "DataItem.ID")))%>'
                        Target="_self"></asp:HyperLink>
                </td>
                <td>
                    <asp:Label ID="lblEventStartDate" CssClass="dlsEvent-ISDate" runat="server" Text='<%#GetDate(Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.FromDate")))%>'></asp:Label>
                    <asp:Label ID="lblEventStartTime" CssClass="dlsEvent-ISTime" runat="server" Text='<%#GetTime(Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.FromDate")))%>'></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEventEndDate" CssClass="dlsEvent-IEDate" runat="server" Text='<%#GetDate(Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ToDate")))%>'></asp:Label>
                    <asp:Label ID="lblEventEndTime" CssClass="dlsEvent-IETime" runat="server" Text='<%#GetTime(Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ToDate")))%>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <ItemStyle CssClass="dlsEvent-Item" />
        <SeparatorTemplate>
        </SeparatorTemplate>
        <SeparatorStyle CssClass="dlsEvent-Separat" />
        <FooterTemplate>
        </FooterTemplate>
        <FooterStyle CssClass="dlsEvent-Footer" />
    </asp:DataList>
</table>
