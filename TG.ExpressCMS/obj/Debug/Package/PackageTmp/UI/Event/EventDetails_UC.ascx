<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EventDetails_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Event.EventDetails_UC" %>
<asp:PlaceHolder ID="plcEvent" runat="server">
    <div id="dvimage" runat="server">
        <asp:Image ID="imgEvent" runat="server"></asp:Image>
    </div>
    <div id="dvEventName" runat="server" class="ContentTitle">
    </div>
    <div class="Event-StartDateTime">
        <asp:Label ID="lblStartTime" Text='<%$ Resources:EventResource, StartTime %>' runat="server"></asp:Label>
        <div id="dvStartDate" class="Event-StartDate" runat="server">
        </div>
        <div id="dvStartTime" class="Event-StartTime" runat="server">
        </div>
    </div>
    <br />
    <div class="Event-EndDateTime">
        <asp:Label ID="lblEndTime" Text='<%$ Resources:EventResource, EndTime %>' runat="server"></asp:Label>
        <div id="dvEndDate" class="Event-EndDate" runat="server">
        </div>
        <div id="dvEndTime" class="Event-EndTime" runat="server">
        </div>
    </div>
    <br />
    <div class="Event-EndDateTime">
        <asp:Label ID="lblLocation" runat="server" Text='<%$ Resources:EventResource, lbleventlocation %>'></asp:Label>
        <div id="dvLocation" runat="server" class="Event-Location">
        </div>
    </div>
    <br />
    <br />
    <div class="Event-EndDateTime">
        التفاصيل
        <br />
        <div id="dvEventDetails" runat="server">
        </div>
    </div>
</asp:PlaceHolder>
