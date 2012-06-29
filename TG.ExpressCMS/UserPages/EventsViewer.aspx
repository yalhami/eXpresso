<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<%@ Register Src="../UI/Event/EventCalendar_UC.ascx" TagName="EventCalendar_UC" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc7:HtmlViewer_UC HashName="EventViewerage" runat="server" ID="htmlTopHeader" />
    <center>
        <uc1:EventCalendar_UC ID="EventCalendar_UC1" CategoryID="19" runat="server" />
    </center>
</asp:Content>
