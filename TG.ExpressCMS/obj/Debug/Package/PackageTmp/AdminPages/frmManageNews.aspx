<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"  EnableEventValidation ="false" AutoEventWireup="true" CodeBehind="frmManageNews.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageNews" %>
<%@ Register src="../UI/News/NewsAdmin_UC.ascx" tagname="NewsAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:NewsAdmin_UC ID="NewsAdmin_UC1" runat="server" />
</asp:Content>
