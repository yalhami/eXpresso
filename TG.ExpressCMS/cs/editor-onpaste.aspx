<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET HTML Editor - Handle pasted text</title>
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
						<h1>Handle pasted text</h1>
						<p>With Cute Editor, you can specify if formatting is stripped when text is pasted into the editor.</p>
						<br />
						<asp:radiobuttonlist id="EditorOnPaste" runat="server" autopostback="True" RepeatDirection="Horizontal" onselectedindexchanged="PasteBehavior_Changed">
							<asp:ListItem value="Disabled"  Selected="True">Disabled</asp:ListItem>
							<asp:ListItem value="PastePureText">PastePureText </asp:ListItem>
							<asp:ListItem value="PasteText">PasteText</asp:ListItem>
							<asp:ListItem value="PasteCleanHTML">PasteCleanHTML</asp:ListItem>
							<asp:ListItem value="PasteWord">PasteWord</asp:ListItem>
							<asp:ListItem value="ConfirmWord">ConfirmWord</asp:ListItem>
						</asp:radiobuttonlist>
									
						<CE:Editor DisableAutoFormatting="true" EditorWysiwygModeCss="../example.css" ThemeType="Office2003_BlueTheme" EditorOnPaste="Disabled" id="Editor1" Height="250px" AutoConfigure="Simple" runat="server" ></CE:Editor><BR>
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
			Editor1.Text = "Type Here";
		} 
	
	}
	
	private void PasteBehavior_Changed(Object sender, EventArgs e)
	{
		switch(EditorOnPaste.SelectedItem.Value)
		{
			case "Disabled":
				Editor1.EditorOnPaste = PasteBehavior.Disabled;
				break;
		    case "PastePureText":
				Editor1.EditorOnPaste = PasteBehavior.PastePureText;
				break;
		    case "PasteText":
				Editor1.EditorOnPaste = PasteBehavior.PasteText;
				break;
		    case "PasteCleanHTML":
				Editor1.EditorOnPaste = PasteBehavior.PasteCleanHTML;
				break;
		    case "PasteWord":
				Editor1.EditorOnPaste = PasteBehavior.PasteWord;
				break;
		    case "ConfirmWord":
				Editor1.EditorOnPaste = PasteBehavior.ConfirmWord;
				break;
		}	
		Editor1.Visible = true;	
			
	}
</script>