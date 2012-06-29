<%@ Page Language="C#"%>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>Add custom buttons</title>
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
						<h1>Add custom buttons</h1>
						This example shows you how easy it can be to <b>add your own functions</b> to the CuteEditor with the help of CuteEditor extended functionalities.  
						<br><br>
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" Height="200" runat="server" TemplateItemList="Bold,Italic,Underline,JustifyLeft,JustifyCenter,JustifyRight,InsertUnorderedList,Separator,Indent, Outdent, insertcustombutonhere"></CE:Editor><BR>							
						<asp:textbox id="TextBox1" Runat="server">OKOK</asp:textbox>
					</td>
				<tr>
			</table>			
		</form>
	</body>
</html>

<script runat="server">
	void Page_Load(object sender, System.EventArgs e)
	{
		CuteEditor.ToolControl tc = Editor1.ToolControls["insertcustombutonhere"];
		if(tc!=null)
		{				
			System.Web.UI.WebControls.Image Image1 = new System.Web.UI.WebControls.Image ();
			Image1.ToolTip				= "Insert today's date";
			Image1.ImageUrl				= "tools.gif";
			Image1.CssClass				= "CuteEditorButton";
			SetMouseEvents(Image1);
			Image1.Attributes["onclick"]="var d = new Date(); CuteEditor_GetEditor(this).ExecCommand('PasteHTML',false,d.toLocaleDateString())";
			tc.Control.Controls.Add(Image1);
			
			Button postbutton=new Button();
			postbutton.Click+=new EventHandler(postbutton_Click);
			postbutton.Text="PostBack";
			postbutton.Style["vertical-align"]="middle";
			tc.Control.Controls.Add(postbutton);
			
			System.Web.UI.WebControls.Image Image2 = new System.Web.UI.WebControls.Image();
			Image2.ToolTip				= "Using oncommand";
			Image2.ImageUrl				= "tools.gif";
			Image2.CssClass				= "CuteEditorButton";
			SetMouseEvents(Image2);
			Image2.Attributes["Command"]="MyCmd";
			tc.Control.Controls.Add(Image2);
			
			//Editor1.AddToolControl("CustomPostBack",postbutton);
		}
	}
	
	void SetMouseEvents(WebControl control)
	{
		control.Attributes["onmouseover"]="CuteEditor_ButtonCommandOver(this)";
		control.Attributes["onmouseout"]="CuteEditor_ButtonCommandOut(this)";
		control.Attributes["onmousedown"]="CuteEditor_ButtonCommandDown(this)";
		control.Attributes["onmouseup"]="CuteEditor_ButtonCommandUp(this)";
		control.Attributes["ondragstart"]="CuteEditor_CancelEvent()";
	}
	private void postbutton_Click(object sender, EventArgs e)
	{
		TextBox1.Text="PostButton Clicked";
	}

</script>

<script language="JavaScript" type="text/javascript" >
		var editor1=document.getElementById("<%=Editor1.ClientID%>");
		
		function CuteEditor_OnCommand(editor,command,ui,value)
		{
			//handle the command by yourself
			if(command=="MyCmd")
			{
				editor.ExecCommand("InsertTable");
				return true;
			}
		}
</script>