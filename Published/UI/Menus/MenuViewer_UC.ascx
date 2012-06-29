<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="MenuViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Menus.MenuViewer_UC" %>
<%--<asp:Menu ID="mnuUserSide" runat="server" SkipLinkText="" CssClass="m-menu" DynamicEnableDefaultPopOutImage="False"
    DynamicPopOutImageTextFormatString="" StaticEnableDefaultPopOutImage="False"
    StaticPopOutImageTextFormatString="">
    <StaticSelectedStyle CssClass="m-selected" />
    <StaticMenuItemStyle CssClass="NavItem" ItemSpacing="0" />
    <StaticHoverStyle CssClass="m-item-over" />
    <DynamicMenuStyle CssClass="NavItem" />
    <DynamicHoverStyle CssClass="m-item2-over" />
    <DynamicSelectedStyle CssClass="m-item2-selected" />
    <DynamicMenuItemStyle CssClass="NavItem" />
    <DataBindings>
        <asp:MenuItemBinding DataMember="Menu" TextField="text" ValueField="text" NavigateUrlField="url" />
        <asp:MenuItemBinding DataMember="SubMenu" NavigateUrlField="url" TextField="text"
            ValueField="text" />
    </DataBindings>
</asp:Menu>
<asp:XmlDataSource ID="TreeSource" runat="server" ></asp:XmlDataSource>--%>
<asp:Menu ID="mnuUserSide" runat="server" SkipLinkText="" CssClass="mnuViewer"  DynamicEnableDefaultPopOutImage="False"
    DynamicPopOutImageTextFormatString="" StaticEnableDefaultPopOutImage="False"
    StaticPopOutImageTextFormatString="">
    <StaticSelectedStyle />
    <StaticMenuItemStyle CssClass="NavItem" ItemSpacing="0" />
    <StaticHoverStyle />
    <DynamicMenuStyle />
    <DynamicHoverStyle />
    <DynamicSelectedStyle />
    <DynamicMenuItemStyle />
    <DataBindings>
        <asp:MenuItemBinding DataMember="Menu" TextField="text" ValueField="text" NavigateUrlField="url" />
        <asp:MenuItemBinding DataMember="SubMenu" NavigateUrlField="url" TextField="text"
            ValueField="text" />
    </DataBindings>
</asp:Menu>
<asp:XmlDataSource ID="TreeSource" runat="server"></asp:XmlDataSource>
