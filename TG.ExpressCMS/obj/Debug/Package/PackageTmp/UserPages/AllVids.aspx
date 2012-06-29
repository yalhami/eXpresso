<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Custums/Sawtyyat/VideosViewerXsl_UC.ascx" TagName="VideosViewerXsl_UC"
    TagPrefix="uc5" %>
    <%@ Register Src="../UI/News/NewsViewer_UC.ascx" TagName="NewsViewer_UC" TagPrefix="uc16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<uc5:videosviewerxsl_uc id="VideosViewerXsl_UC1" runat="server" xslid="20" categoryid="57" />--%>
       <uc16:NewsViewer_UC runat="server" XSLID="22" CategoryID="58" />
</asp:Content>
