<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Multiple Editors in one page</title>
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
					<td valign="top">
						<h1>Multiple Editors in one page</h1>
						<CE:EDITOR id="Editor1" EditorWysiwygModeCss="../example.css" runat="server" Height="200" ThemeType="Office2003_BlueTheme" AutoConfigure="Simple"></CE:EDITOR><br>
						<CE:EDITOR id="Editor2" EditorWysiwygModeCss="../example.css" runat="server" Height="200" ThemeType="Office2003" AutoConfigure="Simple"></CE:EDITOR><br>
						<CE:EDITOR id="Editor3" EditorWysiwygModeCss="../example.css" runat="server" Height="200" ThemeType="OfficeXP" AutoConfigure="Simple"></CE:EDITOR><br>
						<CE:EDITOR id="Editor4" EditorWysiwygModeCss="../example.css" runat="server" Height="200" ThemeType="Office2000" AutoConfigure="Simple"></CE:EDITOR><br>
						<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Show HTML"></asp:Button>
					</td>
				<tr>
			</table>			
		</form>
	</body>
</html>


<script runat="server">
	void Page_Load(object sender, System.EventArgs e)
	{
		if(! this.IsPostBack )
		{
			Editor1.Text = @"<h3 style=""COLOR: red"">1. Easy for developers</h3>";
			Editor2.Text = @"<h3 style=""COLOR: #339966"">2. Seamless Integration with Web Forms</h3>";
			Editor3.Text = @"<h3 style=""COLOR: #ff00ff"">3. Easy customization and extension</h3>";
			Editor4.Text = @"<h3 style=""COLOR: #999999"">4. Easy for end-users</h3>";	
		}
	}

	public void Submit(object sender, EventArgs e)
	{
		
	}
</script>