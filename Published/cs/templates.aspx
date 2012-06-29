<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Content management with templates</title>
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
						<h1>Content management with templates</h1>
						The basic idea behind a Content Management System (<b>CMS</b>) is to separate the management of content from design. Cute Editor allows the site designer to easily create and establish <b>templates</b> to give the site a uniform look. Templates may be modified when desired. 
						<br><br>
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" ThemeType="Office2003_BlueTheme" runat="server" ></CE:Editor><br />
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
		else 
		{ 
			Editor1.LoadHtml("../templates/template3.htm");
		} 	
	
	}
	public void Submit(object sender, System.EventArgs e)
	{
		Literal1.Text = "<h2>The HTML you typed is...</h2><br>"; 
		Literal1.Text += Server.HtmlEncode(Editor1.Text); 
	}
</script>