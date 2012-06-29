<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageContactsSubscribtionMessages.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageContactsSubscribtionMessages" %>
<%@ Register src="../UI/Email/AdminSuccessConfirmationEmail_UC.ascx" tagname="AdminSuccessConfirmationEmail_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:AdminSuccessConfirmationEmail_UC ID="AdminSuccessConfirmationEmail_UC1" 
        runat="server" />
</asp:Content>
