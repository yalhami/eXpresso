<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="forumUserAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.forumUserAdmin" %>
<%@ Register src="../UI/Forum/ForumUserAdmin_UC.ascx" tagname="ForumUserAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ForumUserAdmin_UC ID="ForumUserAdmin_UC1" runat="server" />
</asp:Content>
