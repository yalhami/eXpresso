<%@ Page Title="" EnableEventValidation="false"
 Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="forumAdmin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.forumAdmin" %>
<%@ Register src="../UI/Forum/ForumAdmin_UC.ascx" tagname="ForumAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ForumAdmin_UC ID="ForumAdmin_UC1" runat="server" />
</asp:Content>
