<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CategoryViewer_UC.ascx.cs" EnableViewState="false"
    Inherits="TG.ExpressCMS.UI.Categories.CategoryViewer_UC" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc1" %>
<div id="divMessages" runat="server">
</div>
<div id="dvCategories" runat="server">
</div>
<br />
<uc1:CustomPager_UC ID="CustomPager_UC1" runat="server" />
