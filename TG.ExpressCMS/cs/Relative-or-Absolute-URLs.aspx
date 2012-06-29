<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Relative vs. Absolute URLs Example</title>
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
						<h1>Relative or Absolute URLs, which do you prefer?</h1>
						<hr>
						<p>With Cute Editor, you have the choice of using either a <font color=darkred><b>relative or absolute URL</b></font>.						
						</p>
						<br />
						<asp:radiobuttonlist id="UrlsList" runat="server" autopostback="True" RepeatDirection="Horizontal" onselectedindexchanged="Urls_Changed">
							<asp:ListItem value="Default"  Selected="True">Default</asp:ListItem>
							<asp:ListItem value="SiteRelative">SiteRelative Urls</asp:ListItem>
							<asp:ListItem value="Absolute">Absolute Urls</asp:ListItem>
						</asp:radiobuttonlist>
									
						<CE:Editor DisableAutoFormatting="true" EditorWysiwygModeCss="../example.css" id="Editor1" AutoConfigure="Compact" runat="server" ></CE:Editor><BR>
									
						<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Show HTML"></asp:Button>
						<br>
						<br />
						<asp:textbox id="textbox1" runat="server" TextMode="MultiLine" Height="250px" Width="730px" Font-Name="Arial"></asp:TextBox><br />				
					</td>
				<tr>
			</table>			
		</form>
	</body>
</html>

<script runat="server">
	void Page_Load(object sender, System.EventArgs e)
	 {
	    if (!IsPostBack) 
		{ 
			Editor1.Text = "<div><a href=\"some.htm\">This is a relative path</a><br><br><a href=\"/some.htm\">This is a Site Root Relative path</a> <br><br><a href=\"Http://somesite/some.htm\">This is a absolute path.</a><br><br><a href=\"#tips\">This is a link to anchor.</a><br><br></div>";
		} 
	
	}
	public void Submit(object sender, System.EventArgs e)
	{
		textbox1.Text = Editor1.XHTML; 
	}
	
	private void Urls_Changed(Object sender, EventArgs e)
	{
		switch(UrlsList.SelectedItem.Value)
		{
			case "Default":
				Editor1.URLType  = URLType.Default;
				break;
		    case "SiteRelative":
				Editor1.URLType  = URLType.SiteRelative;
				break;
		    case "Absolute":
				Editor1.URLType  = URLType.Absolute;
				break;
		}	
	}
</script>