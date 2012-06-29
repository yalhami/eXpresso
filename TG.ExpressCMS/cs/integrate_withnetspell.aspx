<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Integration with NetSpell 2.1.4</title>
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
						<h1>Integration with NetSpell 2.1.4</h1>
						<p>The NetSpell project is a <B>free</B> spell checking engine written entirely in managed C# .net code. Package includes a medium sized English dictionaries. Suggestions for misspelled words are generated using 
						phonetic (sounds like) matching and ranked by a typographical score (looks like). Also supports "ignore all" and "replace all" misspelled-word handling. Project includes a dictionary build tool (separate download) to build custom 
						dictionaries. <br /><br />For detail information, please check <A href="http://www.loresoft.com/Default.aspx?tabid=14">LoreSoft.com</A> Site. </p><br/>
						
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" ThemeType="Office2003_BlueTheme" runat="server" ></CE:Editor><br />
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
</script>