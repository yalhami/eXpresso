<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/Categories/CategoryViewer_UC.ascx" TagName="CategoryViewer_UC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContentTitle">
        <uc7:HtmlViewer_UC HashName="GalleryCategories" runat="server" ID="HtmlViewer_UC22" />
    </div>
    
    <uc1:CategoryViewer_UC Count="9" XSLID="9" Type="4" ID="CategoryViewer_UC1" runat="server" />
</asp:Content>
