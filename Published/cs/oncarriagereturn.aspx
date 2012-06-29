<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Carriage Return Example</title>
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
						<h1>&lt;div&gt;,&lt;p&gt; or &lt;br&gt;, which do you prefer?</h1>
						<p>With Cute Editor, you can defines what happens when the "enter" key is pressed in the editor&nbsp;in the <U><STRONG>BreakElement</STRONG></U> enumeration.This enumeration has three values: Div, Br and P.
						</p>
						<br />
						<asp:radiobuttonlist id="CarriageList" runat="server" autopostback="True" RepeatDirection="Horizontal" onselectedindexchanged="Carriage_Changed">
							<asp:ListItem value="div"  Selected="True">Div</asp:ListItem>
							<asp:ListItem value="br">Br</asp:ListItem>
							<asp:ListItem value="paragraph">P</asp:ListItem>
						</asp:radiobuttonlist>
									
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" ThemeType="OfficeXP" Autoconfigure="Simple" runat="server"/> <br />
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
			Literal1.Text += Server.HtmlEncode(Editor1.XHTML); 
	    } 
		else 
		{ 
			Editor1.Text = "Type Here";
		} 
	
	}
	public void Submit(object sender, System.EventArgs e)
	{
		Literal1.Text = "<h2>The HTML you typed is...</h2><br>"; 
		Literal1.Text += Server.HtmlEncode(Editor1.XHTML); 
	}
	
	private void Carriage_Changed(Object sender, EventArgs e)
	{
		switch(CarriageList.SelectedItem.Value)
		{
			case "div":
				Editor1.BreakElement  = BreakElement.Div;
				Editor1.Text = "Editor1.BreakElement  = BreakElement.Div;";
				break;
		    case "br":
				Editor1.BreakElement  = BreakElement.Br;
				Editor1.Text = "Editor1.BreakElement  = BreakElement.Br;";
				break;
		    case "paragraph":
				Editor1.BreakElement  = BreakElement.P;
				Editor1.Text = "Editor1.BreakElement  = BreakElement.P;";
				break;
		}	
		Editor1.Visible = true;	
			
	}
</script>