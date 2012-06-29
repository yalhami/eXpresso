<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="forumThreadAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.forumThreadAdmin" %>
<%@ Register src="../UI/Forum/ForumThreadAdmin_UC.ascx" tagname="ForumThreadAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ForumThreadAdmin_UC ID="ForumThreadAdmin_UC1" runat="server" />
</asp:Content>
