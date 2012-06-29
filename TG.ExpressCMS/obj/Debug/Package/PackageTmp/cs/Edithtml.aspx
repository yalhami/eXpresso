<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Edit Static Html Example </title>
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
						<h1>Edit Static Html</h1>		
						This example demonstrates you can use Cute Editor to edit static html page. Below is an example page that displays a document held in an HTML file on the hard drive. When you submit the form, the document is saved back to the drive. <a href="document.htm"><b>Check the document.htm</b></a>
						<br><br>
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" EditCompleteDocument="true" AllowPasteHtml="false" ThemeType="Office2003_BlueTheme" runat="server" ></CE:Editor><BR>
						<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Submit"></asp:Button><br />			
						<asp:textbox id="textbox1" runat="server" TextMode="MultiLine" Height="250px" Width="730px" Font-Name="Arial"></asp:TextBox>							
					
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
			Editor1.SaveFile("document.htm");
			textbox1.Text = Editor1.Text; 
	    } 
		else 
		{ 
			Editor1.LoadHtml("document.htm");
		} 	
	}
	public void Submit(object sender, System.EventArgs e)
	{
			Editor1.SaveFile("document.htm");
			textbox1.Text = Editor1.Text;  
	}
</script>