<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>


<script runat="server">

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "Refreshed at " +
            DateTime.Now.ToString();
    }
</script>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Ajax Support</title>
		<link rel="stylesheet" href="../example.css" type="text/css" />
		<style type="text/css">
		#UpdatePanel1 { 
		width:760px;
		}
		</style>
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
					<td valign="top" width="760">
						<asp:ScriptManager ID="ScriptManager1" runat="server">
						</asp:ScriptManager>
						<h1>Ajax Support Sample</h1>
						<p style="width:760px;">To run this example, you need to install Microsoft ASP.NET AJAX on your server.</p>
						<br>
						<asp:UpdatePanel ID="UpdatePanel1" runat="server">
							<ContentTemplate>
								<fieldset>
								<legend>UpdatePanel</legend>
								<asp:Label ID="Label1" runat="server" Text="Panel created."></asp:Label><br />
								</fieldset>
							</ContentTemplate>
							<Triggers>
								<asp:AsyncPostBackTrigger ControlID="Button1" />
							</Triggers>
						</asp:UpdatePanel>
						<br>
						<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
						<asp:UpdatePanel ID="UpdatePanel2" runat="server">
							<ContentTemplate>
									<CE:Editor id="Editor1" AutoConfigure="Simple" EditorWysiwygModeCss="../example.css" runat="server" ></CE:Editor><br />
							</ContentTemplate>
						</asp:UpdatePanel>
						
					</td>
				<tr>
			</table>			
		</form>
	</body>
</html>