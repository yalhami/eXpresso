<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide2.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/Forum/AddPost_UC.ascx" TagName="AddPost_UC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContentTitle">
        <uc7:HtmlViewer_UC ID="Htmlviewer_uc1" runat="server" HashName="addPost" />
    </div>
    <uc1:AddPost_UC ID="AddPost_UC1" runat="server" />
</asp:Content>
