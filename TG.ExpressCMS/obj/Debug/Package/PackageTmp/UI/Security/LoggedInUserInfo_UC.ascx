<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="LoggedInUserInfo_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Security.LoggedInUserInfo_UC" %>
<div>
    <div class="TopLinks">
        <img width="14" height="14" src="../../App_Themes/AdminSide/images/exit.png" />
        <asp:LinkButton ID="lbtnlogout" runat="server" Text="Logout"></asp:LinkButton>
    </div>
    <div id="Div1" class="TopLinks">
        <img width="14" height="14" src="../../App_Themes/AdminSide/images/Service Manager.png" />
        <asp:LinkButton ID="lbSwitchtoLanguageVersion" runat="server"></asp:LinkButton>
    </div>
    <div class="TopLinks" runat="server" visible="false">
        <img width="14" height="14" src="../../App_Themes/AdminSide/images/Service Manager.png" />
        <asp:HyperLink NavigateUrl="~/AdminPages/frmSettings.aspx" ID="hypPortalSettings"
            runat="server">Portal Settings</asp:HyperLink>
    </div>
    <div class="TopLinks">
        <img width="14" height="14" src="../../App_Themes/AdminSide/images/Text preview.png" />
        <asp:HyperLink ID="hypPreview" runat="server" Target="_parent" NavigateUrl="~/UserPages/Default.aspx">Preview Website</asp:HyperLink>
    </div>
    <div class="TopLinks">
        <img width="14" height="14" src="../../App_Themes/AdminSide/images/Profile.png" />
        <asp:LinkButton ID="lbtUsername" runat="server"></asp:LinkButton>
    </div>
</div>
