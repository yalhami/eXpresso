﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmBecomeVolunteerRequests.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.Customs.frmBecomeVolunteerRequests" %>
<%@ Register src="../UI/Custums/Volunteer/BecomeVolunteerAdmin_UC.ascx" tagname="BecomeVolunteerAdmin_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:BecomeVolunteerAdmin_UC ID="BecomeVolunteerAdmin_UC1" runat="server" />
</asp:Content>
