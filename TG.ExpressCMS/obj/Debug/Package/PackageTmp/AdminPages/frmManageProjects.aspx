<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmManageProjects.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmManageProjects" %>
<%@ Register src="../UI/Custums/Mushtaraka/Projects_UC.ascx" tagname="Projects_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Projects_UC ID="Projects_UC1" runat="server" />
</asp:Content>
