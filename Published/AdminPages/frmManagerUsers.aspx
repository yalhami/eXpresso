﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManagerUsers.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManagerUsers" %>
<%@ Register src="../UI/Security/ManageUsers_UC.ascx" tagname="ManageUsers_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ManageUsers_UC ID="ManageUsers_UC1" runat="server" />
</asp:Content>
