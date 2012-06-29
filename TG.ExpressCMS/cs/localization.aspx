<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Localized (Spanish,German...) </title>
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
						<h1>Localized (Spanish,German...)</h1>
						<asp:radiobuttonlist  style="border:1px solid #666666" BgColor="#f0f0f0" id="RadioList" Width=750 runat="server" autopostback="True" RepeatLayout="Table" RepeatColumns="4" CellPadding="2" CellSpacing="0" RepeatDirection="Horizontal" onselectedindexchanged="culture_Changed">
							<asp:ListItem value="en"><span style="width:100">English</span><IMG src="http://cutesoft.net/images/flags/f0-us.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="fr-FR"><span style="width:100">French</span><IMG src="http://cutesoft.net/images/flags/f0-fr.gif"  align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="de-de"><span style="width:100">German</span><IMG src="http://cutesoft.net/images/flags/f0-de.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="nl-NL"><span style="width:100">Dutch</span><IMG src="http://cutesoft.net/images/flags/f0-nl.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="es-ES"><span style="width:100">Spanish</span><IMG src="http://cutesoft.net/images/flags/f0-es.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="it-IT"><span style="width:100">Italian</span><IMG src="http://cutesoft.net/images/flags/f0-it.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="nb-NO"><span style="width:100">Norwegian</span><IMG src="http://cutesoft.net/images/flags/f0-no.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="ru-RU"><span style="width:100">Russian</span><IMG src="http://cutesoft.net/images/flags/f0-ru.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="ja-JP"><span style="width:100">Japanese</span><IMG src="http://cutesoft.net/images/flags/f0-jp.gif" align=absMiddle border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="zh-cn"><span style="width:100">Chinese</span><IMG src="http://cutesoft.net/images/flags/f0-cn.gif" align=absMiddle  border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="sv-SE"><span style="width:100">Swedish</span><IMG src="http://cutesoft.net/images/flags/f0-se.gif" align=absMiddle  border="1" hspace="6"></asp:ListItem>
							<asp:ListItem value="pt-BR"><span style="width:100">Portuguese</span><IMG src="http://cutesoft.net/images/flags/f0-pt.gif" align=absMiddle  border="1" hspace="6"></asp:ListItem>
						</asp:radiobuttonlist><br/>
						<!--	<asp:ListItem value=""><span style="width:100">Auto Detect</span></asp:ListItem> -->
						
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" runat="server" ></CE:Editor><br /><br />
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
	private void culture_Changed(Object sender, EventArgs e)
	{
		Editor1.CustomCulture = RadioList.SelectedItem.Value;
	}
		
</script>

