<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Default Configuration </title>
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
						<h1>Enable All Toolbars</h1>
						This example show you <b>all the predefined buttons</b>. <br><br>
									
						<asp:radiobuttonlist id="ConfigureList" runat="server" autopostback="True" RepeatDirection="Horizontal" onselectedindexchanged="Configure_Changed">
							<asp:ListItem value="Full"  Selected="True">Full</asp:ListItem>
							<asp:ListItem value="Full_noform">Full_noform</asp:ListItem>
							<asp:ListItem value="Compact">Compact</asp:ListItem>
							<asp:ListItem value="Simple">Simple</asp:ListItem>
							<asp:ListItem value="Minimal">Minimal</asp:ListItem>
							<asp:ListItem value="None">None</asp:ListItem>
						</asp:radiobuttonlist>
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" runat="server" ></CE:Editor><br />
						<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Show HTML"></asp:Button>
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
			Editor1.Text = "Type Here";
		} 
	
	}
	public void Submit(object sender, System.EventArgs e)
	{
		Literal1.Text = "<h2>The HTML you typed is...</h2><br>"; 
		Literal1.Text += Server.HtmlEncode(Editor1.Text); 
	}
	
	private void Configure_Changed(Object sender, EventArgs e)
	{
		switch(ConfigureList.SelectedItem.Value)
		{
			case "Full":
				Editor1.AutoConfigure  = AutoConfigure.Full;
				Editor1.Width=Unit.Pixel(776);
				break;
				
			case "Compact":
				Editor1.AutoConfigure  = AutoConfigure.Compact;
				Editor1.Width=Unit.Pixel(770);
				break;
				
			case "Full_noform":
				Editor1.AutoConfigure  = AutoConfigure.Full_noform;
				Editor1.Width=Unit.Pixel(660);
				break;
				
			case "Simple":
				Editor1.AutoConfigure  = AutoConfigure.Simple;
				Editor1.Width=Unit.Pixel(720);
				break;
				
			case "Minimal":
				Editor1.AutoConfigure  = AutoConfigure.Minimal;
				Editor1.Width=Unit.Pixel(500);
				break;
				
			case "None":
				Editor1.AutoConfigure  = AutoConfigure.None;
				Editor1.Width=Unit.Pixel(500);
				break;
		}	
	}
</script>

