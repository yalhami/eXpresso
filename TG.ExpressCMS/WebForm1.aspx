<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmtest.aspx.cs" Inherits="TG.ExpressCMS.frmTest" %>

<%@ Register Src="UI/Custums/AlRamz/AlramzUserRegistration_UC.ascx" TagName="AlramzUserRegistration_UC"
    TagPrefix="uc1" %>
<%@ Register src="UI/Custums/Fattoush/FattoushContactUs_UC.ascx" tagname="FattoushContactUs_UC" tagprefix="uc2" %>
<%@ Register src="UI/Custums/Fattoush/BMICalculator_UC.ascx" tagname="BMICalculator_UC" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scmgr" runat="server">
    </asp:ScriptManager>
    <div>
        <%--<uc1:AlramzUserRegistration_UC ID="AlRamzRegistration2_UC1" runat="server" />--%>
        
        <uc3:BMICalculator_UC ID="BMICalculator_UC1" runat="server" />
        
    </div>
    </form>
</body>
</html>
