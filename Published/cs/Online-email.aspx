<%@ Page Language="C#" ValidateRequest="false"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<%@ import Namespace="System.Web.Mail" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Online email example</title>
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
						<h1>Online email example</h1>
						You can use CuteEditor in all sorts of applications, and this demonstration shows how it can be used to send richly-formatted emails in HTML format. 
						<br><br>
						<table>
							<tr>
								<td width="80" nowrap>
										Subject:
									</td>
									<td>
										<asp:textbox id="SubjectTextBox" runat="server" value="Rich-text HTML email"></asp:textbox>
									</td>
								</tr>
								<tr>
									<td>
										From:
									</td>
									<td>
										<asp:textbox id="FromTextBox" runat="server"></asp:textbox>
										email address
										<asp:RegularExpressionValidator
											ControlToValidate="FromTextBox"
											Text="Invalid Email Address!"
											ValidationExpression="\S+@\S+\.\S{2,3}"
											Runat="Server" 
										/>		
										<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="'Email' must not be left blank." ControlToValidate="FromTextBox"></asp:RequiredFieldValidator>								
									</td>
								</tr>
								<tr>
									<td>
										To:
									</td>
									<td>
										<asp:textbox id="ToTextBox" runat="server"></asp:textbox>
										email address 
										<asp:RegularExpressionValidator
											ControlToValidate="ToTextBox"
											Text="Invalid Email Address!"
											ValidationExpression="\S+@\S+\.\S{2,3}"
											Runat="Server" 
										/>		
										<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="'Email' must not be left blank." ControlToValidate="ToTextBox"></asp:RequiredFieldValidator>								
														
									</td>
								</tr>
							</table>
				            
							<CE:Editor EditorWysiwygModeCss="../example.css" URLType="Absolute" id="Editor1" Height="250px" AutoConfigure="Simple" runat="server" ></CE:Editor><BR>
										
							<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Send email..."></asp:Button>
							<br><br>
							<asp:Label id="ResultLabel" runat="server"></asp:Label> 
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
	public void Submit(object sender, System.EventArgs e)
	{	
		if (Page.IsValid)
		{
			try
            {
                SmtpMail.SmtpServer = "localhost";
                MailMessage mail = new MailMessage();
                mail.From = FromTextBox.Text;
                mail.Subject = SubjectTextBox.Text;
                mail.Body = Editor1.Text;
                mail.To = ToTextBox.Text;
                mail.BodyFormat = MailFormat.Html;
                SmtpMail.Send(mail);
    
                ResultLabel.Text = "Message sent successfully.";
            }
            catch (Exception exc)
            {
                ResultLabel.Text = "<b>Message could not be sent: " + exc.Message + "</b><br>"
                    + "Please verify that the following settings are correct:<ul>"
                    + "<li>You have installed a locale SMTP service"
                    + "<li>Your local SMTP service is set to allow relaying for IP 127.0.0.1</li>"
                    + @"<li>The ASPNET account has read/write permissions in mailroot directory (usually 'C:\inetpub\mailroot')</li>"
                    + "</ul>";
            }
        }
	}
</script>