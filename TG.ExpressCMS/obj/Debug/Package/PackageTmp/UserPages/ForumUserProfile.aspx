<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide2.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>
<%@ Register src="../UI/Forum/ForumUserProfile_UC.ascx" tagname="ForumUserProfile_UC" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ForumUserProfile_UC ID="ForumUserProfile_UC1" runat="server" />
</asp:Content>
