<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Extract plain text example</title>
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
						<h1>Extract plain text example</h1>
						This sample demonstrates retrieving the CuteEditor HTML content in the plain text format. 
						<br><br>
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css"  runat="server" ></CE:Editor><br />
						<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Submit"></asp:Button><br/>
						<asp:textbox id="textbox1" runat="server" TextMode="MultiLine" Height="250px" Width="730px" Font-Name="Arial"></asp:TextBox><br />		
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
			textbox1.Text = Editor1.PlainText; 	  
	    } 
		else 
		{ 
			Editor1.Text = @"<table cellspacing=""4"" cellpadding=""4"" bgcolor=""#ffffff"" border=""0""> <tbody> <tr> <td> <p> <img src=""http://cutesoft.net/Uploads/j0262681.jpg"" width=""80"" /></p></td> <td> <p>When your algorithmic and programming skills have reached a level which you cannot improve any further, refining your team strategy will give you that extra edge you need to reach the top. We practiced programming contests with different team members and strategies for many years, and saw a lot of other teams do so too.  </p></td></tr> <tr> <td> <p> <img src=""http://cutesoft.net/Uploads/PH02366J.jpg"" width=""80"" /></p></td> <td> <p>From this we developed a theory about how an optimal team should behave during a contest. However, a refined strategy is not a must: The World Champions of 1995, Freiburg University, were a rookie team, and the winners of the 1994 Northwestern European Contest, Warsaw University, met only two weeks before that contest.  </p></td></tr></tbody></table> <br /> <br />"; 
		} 
	
	}
	public void Submit(object sender, System.EventArgs e)
	{
		textbox1.Text = Editor1.PlainText; 
	}
</script>