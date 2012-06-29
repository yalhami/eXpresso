<%@ Page Language="C#" Debug="true"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Database Example</title>
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
						<h1>Database Example</h1>
						This example show you how easy it can be to save the CuteEditor's content in a database. 
						<br><br>
						<asp:Datagrid runat="server"
							Id="MyDataGrid"
							cellpadding="3"
							cellspacing="0"
							Headerstyle-BackColor="#eeeeee"
    						Headerstyle-Font-Bold="True"
							BackColor="#f5f5f5"
							BorderWidth="1"
							Width=720
							Font-Name="Arial"
							Font-Size="12px"
							BorderColor="#999999"
							AutogenerateColumns="False"
							OnItemCommand="UpdateItem"
							>
							<Columns>
									<asp:BoundColumn DataField="EventID" Visible="False" />
									<asp:BoundColumn  ItemStyle-Width="50px" DataField="EventID" HeaderText="ID" />
									<asp:BoundColumn  ItemStyle-Width="430px" DataField="Notes" HeaderText="Note" />
									<asp:BoundColumn  ItemStyle-Width="120px" DataField="EventDate" HeaderText="Date" />
									<asp:ButtonColumn ItemStyle-Width="50px" ButtonType="LinkButton"  CommandName="Edit" HeaderText="Edit" Text="Edit" />
									<asp:ButtonColumn ItemStyle-Width="50px" ButtonType="LinkButton"  CommandName="Delete" HeaderText="Delete" Text="Delete" />
							</Columns>
						</asp:datagrid>
						<br>
						<CE:Editor id="Editor1" EditorWysiwygModeCss="../example.css" Autoconfigure="Simple" Height="200" runat="server" ></CE:Editor><br />
						<asp:Button id="btnUpdate" onclick="Submit" Runat="server" Text="Add"></asp:Button>
						<asp:Literal ID="Literal1" Runat="server" />
						<br><br>
						<input type="hidden" name="eventid" runat="server" id="eventid">
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
			BindData();
	    } 		
	}
	
	void BindData() 
	{
		OleDbConnection myConnection = CreateConnection();
		string sql = "Select EventID, Notes, EventDate from Events";		
        OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

		// Execute the command
		OleDbDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
		
		MyDataGrid.DataSource = result ;
		MyDataGrid.DataBind();
	}
	
	
	void UpdateItem(Object sender, DataGridCommandEventArgs e )
	{
		OleDbConnection myConnection = CreateConnection();
		
		//Check if the CommandName ==Delete
		if (e.CommandName == "Delete")
		{
			OleDbCommand com = new OleDbCommand("DELETE FROM Events WHERE EventID = @id", myConnection);
			com.Parameters.Add("id", e.Item.Cells[0].Text);
			com.ExecuteNonQuery();
			myConnection.Close();
		} 
		else if (e.CommandName == "Edit")
		{
			OleDbCommand command = new OleDbCommand("SELECT Notes FROM Events WHERE EventID = @id", myConnection);
			command.Parameters.Add("id", e.Item.Cells[0].Text);
			OleDbDataReader result = command.ExecuteReader();
			if (result.Read())
			{
				//set the editor text 
				Editor1.Text = result.GetString(0);
				eventid.Value = e.Item.Cells[0].Text;
				btnUpdate.Text="Update";
			}
			else
			{
				Editor1.Text = "";
				eventid.Value = "";
				btnUpdate.Text="Add";
			}
			result.Close();
		}
		BindData();			
	}
	
	void Submit(object sender, System.EventArgs e)
	{
		if(!Page.IsValid)
			return;
				
		OleDbConnection myConnection = CreateConnection();
		OleDbCommand command = null;

		if (eventid.Value != "")
		{
			command = new OleDbCommand("UPDATE Events SET EventDate = Date(), Notes = @content WHERE EventID = @id", myConnection);
			command.Parameters.Add("content", Editor1.Text);
			command.Parameters.Add("id", Convert.ToInt32(eventid.Value));
		}
		else
		{
			command = new OleDbCommand("INSERT INTO Events (EventDate, Notes) VALUES (Date(), @content)", myConnection);
			command.Parameters.Add("content", Editor1.Text);
		}
		
		command.ExecuteNonQuery();		
		myConnection.Close();		
		BindData();	
	}
	
	OleDbConnection CreateConnection() 
	{
		OleDbConnection myConnection = new OleDbConnection();
		myConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Context.Server.MapPath("../uploads/Northwind.mdb") + ";";
		myConnection.Open();
		return myConnection;
	}
</script>

