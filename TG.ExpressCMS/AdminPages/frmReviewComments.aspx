<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmReviewComments.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmReviewComments" %>
<%@ Register src="../UI/Comment/CommentsAdmin_UC.ascx" tagname="CommentsAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:CommentsAdmin_UC ID="CommentsAdmin_UC1" runat="server" />
</asp:Content>
