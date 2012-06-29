<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="forumGroupAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.forumGroupAdmin" %>
<%@ Register src="../UI/Forum/ForumGroupAdmin_UC.ascx" tagname="ForumGroupAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ForumGroupAdmin_UC ID="ForumGroupAdmin_UC1" runat="server" />
</asp:Content>
