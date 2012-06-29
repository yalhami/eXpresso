<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Using External Style Sheets </title>
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
						<h1>Using External Style Sheets </h1>
						With Cute Editor, you can specify the location of the style sheet that will be used by the editable area. Multiple Style Sheets are supported. 
						<br><br>
						<asp:radiobuttonlist id="themeList" runat="server" autopostback="True" RepeatDirection="Horizontal" onselectedindexchanged="theme_Changed">
							<asp:ListItem value="../example.css"  Selected="True">example.css</asp:ListItem>
							<asp:ListItem value="blackbackground.css">blackbackground.css</asp:ListItem>
							<asp:ListItem value="../example.css,blackbackground.css">example.css+blackbackground.css</asp:ListItem>
						</asp:radiobuttonlist>
						<CE:Editor ThemeType="Office2003_BlueTheme" id="Editor1" runat="server" Height="250" AutoConfigure="Simple"></CE:Editor>
						<br><br>
						<asp:Literal ID="Literal1" Runat="server" />	
					</td>
				<tr>
			</table>			
		</form>
	</body>
</html>

<script runat="server">
	private void theme_Changed(Object sender, EventArgs e)
	{
		Editor1.EditorWysiwygModeCss  = themeList.SelectedItem.Value;	
		
		Literal1.Text = "Cute Editor automatically parse the CSS classes from EditorWysiwygModeCss <font color=darkred><b>("+themeList.SelectedItem.Value+")</b> </font> and populate all items into CssClass dropdown";
	}
</script>