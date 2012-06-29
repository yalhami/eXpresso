<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="NewsViewer_UC.ascx.cs"
    EnableViewState="false" Inherits="TG.ExpressCMS.UI.News.NewsViewer_UC" %>
<%@ Register Src="../Comment/CommentsUserSide_UC.ascx" TagName="CommentsUserSide_UC"
    TagPrefix="uc1" %>
<%@ Register Src="../Controls/CustomPager_UC.ascx" TagName="CustomPager_UC" TagPrefix="uc2" %>
<script type="text/javascript" src="../../Upload/Files/EditorImage/flexcroll.js"></script>
<%--<script type="text/javascript">
    function SearchByYear(href) {

        var text = href.innerText;
        __doPostBack('Years', text);
    }
</script>--%>
<div id="dvyears" runat="server">
    <div id="dvyearsInternal" runat="server">
    </div>
</div>
<div id="dvProblems" runat="server">
</div>
<div id="dvData" runat="server">
</div>
<div runat="server" id="dvPager">
    <uc2:CustomPager_UC ID="CustomPager_UC1" runat="server" Visible="true" />
</div>
