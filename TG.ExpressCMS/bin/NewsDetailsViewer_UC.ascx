<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="NewsDetailsViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.News.NewsDetailsViewer_UC" %>
<%@ Register src="../Comment/CommentsUserSide_UC.ascx" tagname="CommentsUserSide_UC" tagprefix="uc1" %>
<div id="dvData" runat="server" class="dvData">
</div>
<uc1:CommentsUserSide_UC ID="CommentsUserSide_UC1" runat="server" />

