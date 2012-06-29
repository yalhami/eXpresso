<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageCategories.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageCategories" %>
<%@ Register src="../UI/Categories/CategoryAdmin_UC.ascx" tagname="CategoryAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CategoryAdmin_UC ID="CategoryAdmin_UC1" runat="server" />
</asp:Content>
