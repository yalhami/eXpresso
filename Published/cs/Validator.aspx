<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>Working with ASP.NET Validator Controls</title>
		<link rel="stylesheet" href="../example.css" type="text/css" />
	</head>
	<body>
        <form runat="server">
			<cutesoft:banner id="banner1" runat="server" />	
			<table>
				<tr>
					<td valign="top" nowrap id="leftcolumn" width="160">
						<cutesoft:leftmenu id="leftmenu1" runat="server" />				
					</td>
					<td width="20" nowrap></td>
					<td valign="top" width="750">
						<h1>Working with ASP.NET Validator Controls</h1>
						This sample demonstrates how to use the ASP.NET Validator control to check Cute Editor input and, if necessary, display messages to the user. 
						<br><br>
						<CE:Editor id="Editor1" runat="server" EditorWysiwygModeCss="../example.css" RenderRichDropDown="false" ThemeType="OfficeXP" DisableItemList="save" AutoConfigure="Simple" width=780></CE:Editor>
						<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="Editor1" Text="<h3>The body field is required!</h3>"></asp:RequiredFieldValidator>
						<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Submit"></asp:Button>
						<asp:Literal ID="Literal1" Runat="server" />
					</td>
				<tr>
			</table>			
		</form>
	</body>
</html>

<script runat="server">
	void Page_Load(object sender, System.EventArgs e)
	 {
	    if (IsPostBack) 
		{ 
			Literal1.Text = "<h2>The HTML you typed is...</h2><br>"; 
			Literal1.Text += Server.HtmlEncode(Editor1.Text); 
	    } 
	
	}
	public void Submit(object sender, System.EventArgs e)
	{
		Literal1.Text = "<h2>The HTML you typed is...</h2><br>"; 
		Literal1.Text += Server.HtmlEncode(Editor1.Text); 
	}
</script>