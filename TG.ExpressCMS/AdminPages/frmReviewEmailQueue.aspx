<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master"   EnableEventValidation ="false"  AutoEventWireup="true" CodeBehind="frmReviewEmailQueue.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmReviewEmailQueue" %>
<%@ Register src="../UI/Email/EmailQueueAdmin_UC.ascx" tagname="EmailQueueAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:EmailQueueAdmin_UC ID="EmailQueueAdmin_UC1" runat="server" />
</asp:Content>
