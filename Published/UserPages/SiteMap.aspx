<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/UserSide.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc7:HtmlViewer_UC HashName="sitemapheader" runat="server" ID="HtmlViewer_UC22" />
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1">
        <DataBindings>
            <asp:TreeNodeBinding ValueField="id" NavigateUrlField="url" TargetField="url" TextField="text" />
        </DataBindings>
    </asp:TreeView>
    <asp:XmlDataSource ID="XmlDataSource1" XPath="Menus/Menu" runat="server" DataFile="GeneratedPages/MenuXML13.xml">
    </asp:XmlDataSource>
</asp:Content>
