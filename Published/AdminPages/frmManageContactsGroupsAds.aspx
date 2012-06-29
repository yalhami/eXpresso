<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"
    AutoEventWireup="true" CodeBehind="frmManageContactsGroupsAds.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageContactsGroupsAds" %>

<%@ Register Src="../UI/Contact/ContactsGroups_UC.ascx" TagName="ContactsGroups_UC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ContactsGroups_UC ID="ContactsGroups_UC1" runat="server" />
</asp:Content>
