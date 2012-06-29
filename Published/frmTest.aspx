<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTest.aspx.cs" Inherits="TG.ExpressCMS.frmTest" %>

<%@ Register Src="UI/Security/ManageUsers_UC.ascx" TagName="ManageUsers_UC" TagPrefix="uc1" %>
<%@ Register src="UI/Contact/ContactsGroups_UC.ascx" tagname="ContactsGroups_UC" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scManager" runat="server">
    </asp:ScriptManager>
    <div>
    
        <uc2:ContactsGroups_UC ID="ContactsGroups_UC1" runat="server" />
    
    </div>
    </form>
</body>
</html>
