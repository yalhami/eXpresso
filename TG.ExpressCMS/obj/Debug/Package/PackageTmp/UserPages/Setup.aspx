<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="TG.ExpressCMS.UserPages.Setup" %>

<%@ Register Src="../UI/Security/ManageUsers_UC.ascx" TagName="ManageUsers_UC" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <div>
        <br />
        <asp:TextBox runat="server" ID="txtDetails" TextMode="MultiLine" Height="290" Width="300">
        </asp:TextBox>
        <asp:Button runat="server" ID="btnRun" Text="Run" />
    </div>
    </form>
</body>
</html>
