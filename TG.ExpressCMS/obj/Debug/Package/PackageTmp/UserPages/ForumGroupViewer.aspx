<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide2.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/Forum/ForumGroupViewer_UC.ascx" TagName="ForumGroupViewer_UC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc7:HtmlViewer_UC runat="server" HashName="ForumsHeader"></uc7:HtmlViewer_UC>
    <br />
   
    <uc1:ForumGroupViewer_UC ID="ForumGroupViewer_UC1" runat="server" />
</asp:Content>
