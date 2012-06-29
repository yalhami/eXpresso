<%@ Page Title="" Language="C#" MasterPageFile="~/UserPages/Default.Master" AutoEventWireup="false"
    CodeBehind="Default.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Default" %>

<%@ Register Src="../UI/Contact/ShortCutNewsletter_UC.ascx" TagName="ShortCutNewsletter_UC"
    TagPrefix="uc2" %>
<%@ Register Src="../UI/Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc17" %>
<%@ Register Src="../UI/Menus/MenuViewerXsl_UC.ascx" TagName="MenuViewerXsl_UC" TagPrefix="uc13" %>
<%@ Register Src="../UI/Search/Search_UC.ascx" TagName="Search_UC" TagPrefix="uc98" %>
<%@ Register Src="../UI/News/NewsViewer_UC.ascx" TagName="NewsViewer_UC" TagPrefix="uc16" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tpcls">
    </div>
    <div class="news">
        <%--   <uc17:htmlviewer_uc id="HtmlViewer_UC544" runat="server" hashname="TodayFattoush" />
        --%>
        <uc16:NewsViewer_UC ShowPager="false" CategoryID="23" XSLID="7" Count="5" runat="server"
            ID="newslide_UC1" />
    </div>
    <div class="ra2i">
        <uc16:NewsViewer_UC ShowPager="false" CategoryID="26" XSLID="2" Count="1" runat="server"
            ID="NewsViewer_UC1" />
    </div>
    <div class="ra2i_2">
        <uc17:HtmlViewer_UC ID="HtmlViewer_UC5" runat="server" HashName="Subscribe" />
        <uc2:ShortCutNewsletter_UC ID="ShortCutNewsletter_UC1" runat="server" />
    </div>
    <div class="slide-news">
        <div class="slid-dv">
            <uc17:HtmlViewer_UC ID="HtmlViewer_UC1" runat="server" HashName="foods" />
            <uc16:NewsViewer_UC ShowPager="false" CategoryID="36" XSLID="8" Count="1" runat="server"
                ID="sport1_UC1" ShowFeatured="1" />
            <uc16:NewsViewer_UC ShowPager="false" CategoryID="36" XSLID="9" Count="4" runat="server"
                ID="sport4_UC1" ShowFeatured="0" />
            <div style="direction: rtl; margin-right: 90%; color: Blue;">
                <a href="/Userpages/Healthyfood.aspx" style="color: Blue;">المزيد...</a>
            </div>
        </div>
    </div>
    <div>
    </div>
    <div class="advdv">
        <div class="insidebanner">
            <script type="text/javascript"><!--
                google_ad_client = "ca-pub-1981521975883198";
                /* Top Left */
                google_ad_slot = "0221966899";
                google_ad_width = 300;
                google_ad_height = 250;
//-->
            </script>
            <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
            </script>
        </div>
    </div>
    <div class="video">
        <uc17:HtmlViewer_UC ID="HtmlViewer_UC4" runat="server" HashName="video" />
    </div>
    <div class="slide-news">
        <div class="slid-dv">
            <uc17:HtmlViewer_UC ID="HtmlViewer_UC2" runat="server" HashName="Rashaqa" />
            <uc16:NewsViewer_UC ShowPager="false" CategoryID="24" XSLID="8" Count="1" runat="server"
                ID="r1_UC1" ShowFeatured="1" />
            <uc16:NewsViewer_UC ShowPager="false" CategoryID="24" XSLID="9" Count="4" runat="server"
                ID="r_UC1" ShowFeatured="0" />
            <div style="direction: rtl; margin-right: 90%; color: Blue;">
                <a href="/Userpages/MixTamareen.aspx" style="color: Blue;">المزيد...</a>
            </div>
        </div>
    </div>
    <div class="advdv">
        <div class="insidebanner1">
            <script type="text/javascript"><!--
                google_ad_client = "pub-1981521975883198";
                /* 300x250, created 8/15/11 */
                google_ad_slot = "2278628343";
                google_ad_width = 300;
                google_ad_height = 250;
//-->
            </script>
            <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
            </script>
        </div>
    </div>
    <div class="slide-news">
        <div class="slid-dv">
            <uc17:HtmlViewer_UC ID="HtmlViewer_UC3" runat="server" HashName="Se77ah" />
            <uc16:NewsViewer_UC ShowPager="false" CategoryID="25" XSLID="8" Count="1" runat="server"
                ID="ht1_UC1" ShowFeatured="1" />
            <uc16:NewsViewer_UC ShowPager="false" CategoryID="25" XSLID="9" Count="4" runat="server"
                ID="h4_UC1" ShowFeatured="0" />
            <div style="direction: rtl; margin-right: 90%; color: Blue;">
                <a href="/Userpages/fattoushInHome.aspx" style="color: Blue;">المزيد...</a>
            </div>
        </div>
    </div>
    <div class="advdv">
        <div class="insidebanner1">
            <script type="text/javascript"><!--
                google_ad_client = "ca-pub-1981521975883198";
                /* DownBannerLeft */
                google_ad_slot = "1775601987";
                google_ad_width = 300;
                google_ad_height = 250;
//-->
            </script>
            <script type="text/javascript" src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
            </script>
        </div>
    </div>
</asp:Content>
