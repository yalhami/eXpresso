<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>
<%@ Register src="../UI/Custums/Sawtyyat/SawwtyyatViewer_UC.ascx" tagname="SawwtyyatViewer_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:SawwtyyatViewer_UC ID="SawwtyyatViewer_UC1" runat="server" />
</asp:Content>
