<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmManagePolls.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManagePolls" %>
<%@ Register src="../UI/Polls/PollsAdmin_UC.ascx" tagname="PollsAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:PollsAdmin_UC ID="PollsAdmin_UC1" runat="server" />
</asp:Content>
