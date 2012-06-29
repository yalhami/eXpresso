<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmMyProfile.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmMyProfile" %>
<%@ Register src="../UI/Security/MyProfile_UC.ascx" tagname="MyProfile_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:MyProfile_UC ID="MyProfile_UC1" runat="server" />
</asp:Content>
