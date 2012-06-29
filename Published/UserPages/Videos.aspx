<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Custums/Sawtyyat/VideosViewerXsl_UC.ascx" TagName="VideosViewerXsl_UC"
    TagPrefix="uc16" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc17:htmlviewer_uc runat="server" hashname="FattoushVideos" />
    <uc16:videosviewerxsl_uc xslid="14" runat="server" categoryid="38"></uc16:videosviewerxsl_uc>
</asp:Content>
