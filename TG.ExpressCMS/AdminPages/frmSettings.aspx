<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmSettings.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmSettings" %>
<%@ Register src="~/UI/Settings/GeneralSettings_UC.ascx" tagname="GeneralSettins_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:GeneralSettins_UC ID="GeneralSettins_UC1" runat="server" />
</asp:Content>
