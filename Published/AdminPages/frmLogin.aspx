<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmLogin" %>

<%@ Register Src="../UI/Security/Login_UC.ascx" TagName="Login_UC" TagPrefix="uc1" %>
<%@ Register src="../UI/Security/LoggedInUserInfo_UC.ascx" tagname="LoggedInUserInfo_UC" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>
        <%=GetPortalName() %></title>
    <link href="../App_Themes/AdminSide/CMS-Style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scmgr" runat="server" EnablePageMethods="true" LoadScriptsBeforeUI="true"
        EnablePartialRendering="true" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        ScriptMode="Release">
        <CompositeScript>
            <Scripts>
                <asp:ScriptReference Path="~/JS/AjaxLoader.js" />
            </Scripts>
        </CompositeScript>
    </asp:ScriptManager>
    <asp:UpdateProgress ID="UpdateProgressAnimation" runat="server" DisplayAfter="0">
        <ProgressTemplate>
            <div class="loadingPanel">
                <img alt="Loading..." src="../App_Themes/AdminSide/images/ajax-loader(2).gif" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div class="Header">
        <div class="HeaderTopContainer">
            <div class="CBSLogo">
                <img src="../App_Themes/AdminSide/images/CBS-Logo.png" /></div>
            <div class="ClientLogo">
                <img src="../App_Themes/AdminSide/images/Client-Logo.png" /></div>
        </div>
        <div class="HeaderBottomContainer">
            <div class="CMSTitle">
                <img src="../App_Themes/AdminSide/images/CMSTitle.jpg" /></div>
        </div>
    </div>
    <div style="clear: both; height: 80px">
    </div>
    <div class="LoginContainer">
        <div class="NavTop">
            <div class="NavTopL">
            </div>
            <div class="NavTopR">
            </div>
        </div>
        <div class="NavBody">
            <uc1:Login_UC ID="Login_UC1" runat="server" />
        </div>
        <div class="NavBottom">
            <div class="NavBottomL">
            </div>
            <div class="NavBottomR">
            </div>
        </div>
    </div>
    <div class="Footer">
        <div class="Copyright">
            Copyright 2011 Mushtaraka. All rights reserved.</div>
    </div>
    <uc2:LoggedInUserInfo_UC ID="LoggedInUserInfo_UC1" runat="server" />
    </form>
</body>
</html>
