<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Careers/CareersApplication_UC.ascx" TagName="CareersApplication_UC"
    TagPrefix="uc1" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ContentTitle">
        Apply to Career
    </div>
    <br />
    <uc7:htmlviewer_uc runat="server" id="contactusheader" hashname="career" />
    <uc1:CareersApplication_UC ID="CareersApplication_UC1" runat="server" />
</asp:Content>
