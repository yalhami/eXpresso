<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Use MaxHTMLLength or MaxTextLength to Protect Your Database</title>
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
						<h1>Use MaxHTMLLength or MaxTextLength to Protect Your Database</h1>
						We often use a database backend such as <a href="http://www.microsoft.com/sql/">SQL Server</a> to store data. In such databases, you have to specify the length of any textual field when a table is designed. If you tried to insert a record whose text length is greater than allowed by your table, an error will be reported. <br /><br />
						To prevent this type of error from occurring, developers can use <strong>MaxHTMLLength</strong> or <strong>MaxTextLength</strong> in the Cute Editor to limit the length of the user’s input.
						<br><br>
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" MaxHTMLLength=8 runat="server" Height="200" ThemeType="OfficeXP" AutoConfigure="Simple"></CE:Editor><br>
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
			Editor1.Text = "Type Here";
		} 	
	
	}
	public void Submit(object sender, System.EventArgs e)
	{
		Literal1.Text = "<h2>The HTML you typed is...</h2><br>"; 
		Literal1.Text += Server.HtmlEncode(Editor1.Text); 
	}
</script>