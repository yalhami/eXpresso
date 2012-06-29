<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="TG.ExpressCMS.WebForm2" %>

<%@ Register src="UI/Custums/Fattoush/BMICalculator_UC.ascx" tagname="BMICalculator_UC" tagprefix="uc1" %>

<%@ Register src="UI/Careers/CareersApplication_UC.ascx" tagname="CareersApplication_UC" tagprefix="uc2" %>

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
       <%-- <uc1:BMICalculator_UC ID="BMICalculator_UC1" runat="server" />--%>
        <uc2:CareersApplication_UC ID="CareersApplication_UC1" runat="server" />
    </div>
    </form>
</body>
</html>
