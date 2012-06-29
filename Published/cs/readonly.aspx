<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Read only example</title>
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
						<h1>Read only support</h1>
						This example show you you can set ReadOnly property to true if you would like to display read-only content in the Cute Editor in some situations. 
						<br><br>
						<CE:Editor id="Editor1" ReadOnly="true" EditorWysiwygModeCss="../example.css" runat="server" ></CE:Editor>
						<br />
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
</script>

