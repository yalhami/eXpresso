<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="forumPostAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.forumPostAdmin" %>
<%@ Register src="../UI/Forum/ForumPostAdmin_UC.ascx" tagname="ForumPostAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ForumPostAdmin_UC ID="ForumPostAdmin_UC1" runat="server" />
</asp:Content>
