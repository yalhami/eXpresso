<%@ Page Language="C#"%>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Register TagPrefix="cutesoft" TagName="banner" Src="banner.ascx" %>
<%@ Register TagPrefix="cutesoft" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>

<html>
    <head>
		<title>ASP and ASP.NET WYSIWYG Editor - Working with DataGrid</title>
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
						<h1>Working with DataGrid</h1>
						This example show you how easy it can be to integrate the CuteEditor with the DataGrid. 
						<br><br>
						<asp:Datagrid runat="server"
						Id="MyDataGrid"
						cellpadding="3"
						cellspacing="0"
						Headerstyle-BackColor="#eeeeee"
    					Headerstyle-Font-Bold="True"
						BackColor="#f5f5f5"
						BorderWidth="1"
						Width=650
						Font-Name="Arial"
						Font-Size="12px"
						BorderColor="#999999"
						AutogenerateColumns="False"
						OnEditcommand="MyDataGrid_EditCommand"
						OnCancelcommand="MyDataGrid_Cancel"
						OnUpdateCommand="MyDataGrid_UpdateCommand">
						<Columns>
							<asp:EditCommandColumn 
								ButtonType="LinkButton" 
								UpdateText="Update" 
								CancelText="Cancel" 
								EditText="Edit"
            					ItemStyle-HorizontalAlign="Center" 
		    					HeaderText="Edit">
							</asp:EditCommandColumn>
							<asp:BoundColumn 
								DataField="EmployeeID" 
								HeaderText="ID" 
								ReadOnly="True">
							</asp:BoundColumn>
							
							<asp:TemplateColumn HeaderText = "Title">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
								</ItemTemplate>
								<EditItemTemplate>
									<CE:Editor id = "FirstName_box" EditorWysiwygModeCss="../example.css" TemplateItemList="Bold,Italic,Underline" Height=150 Width=300 ShowBottomBar="false" Text = '<%#DataBinder.Eval(Container.DataItem, "FirstName") %>' runat = "Server" ></CE:Editor>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText = "Title">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "LastName") %>
								</ItemTemplate>
								<EditItemTemplate>
									<CE:Editor id = "LastName_box" EditorWysiwygModeCss="../example.css" TemplateItemList="Bold,Italic,Underline" Height=150 Width=200 ShowBottomBar="false" Text = '<%#DataBinder.Eval(Container.DataItem, "LastName") %>' runat = "Server" ></CE:Editor>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText = "Title">
								<ItemTemplate>
									<%# DataBinder.Eval(Container.DataItem, "Title") %>
								</ItemTemplate>
								<EditItemTemplate>
									<CE:Editor id = "Title_box" EditorWysiwygModeCss="../example.css" TemplateItemList="Bold,Italic,Underline" Height=150 Width=200 ShowBottomBar="false" Text = '<%#DataBinder.Eval(Container.DataItem, "Title") %>' runat = "Server" ></CE:Editor>
								</EditItemTemplate>
							</asp:TemplateColumn>
						</Columns>
					</asp:DataGrid>
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
		string sql = "Select EmployeeID, FirstName, LastName, Title from Employees";
					
		OleDbConnection myConnection = CreateConnection();
        OleDbCommand myCommand = new OleDbCommand(sql, myConnection);

		// Execute the command
		OleDbDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
			
		MyDataGrid.DataSource = result ;
		MyDataGrid.DataBind();
	}
	
	void MyDataGrid_EditCommand(Object sender, DataGridCommandEventArgs e)
	{
		MyDataGrid.EditItemIndex = e.Item.ItemIndex;
		BindData();
	}
	void MyDataGrid_Cancel(Object sender, DataGridCommandEventArgs e)
	{
		MyDataGrid.EditItemIndex = -1;
		BindData();
	}
	void MyDataGrid_UpdateCommand(Object sender, DataGridCommandEventArgs e)
	{
		OleDbConnection myConnection = CreateConnection();
		string sql = "Select EmployeeID, FirstName, LastName, Title from Employees";
		
		CuteEditor.Editor txtFirstName;
		CuteEditor.Editor txtLastName;
		CuteEditor.Editor txtTitle;
		
		txtFirstName = (CuteEditor.Editor)e.Item.FindControl("FirstName_Box");
		txtLastName = (CuteEditor.Editor)e.Item.FindControl("LastName_Box");
		txtTitle = (CuteEditor.Editor)e.Item.FindControl("Title_Box");
		
		string strUpdateStmt;
        strUpdateStmt =" UPDATE Employees SET FirstName =@Fname, LastName =@Lname, Title = @Title WHERE EmployeeID = @EmpID";
		OleDbCommand myCommand = new OleDbCommand(strUpdateStmt, myConnection);
        myCommand.Parameters.Add(new OleDbParameter("@Fname", txtFirstName.Text));
		myCommand.Parameters.Add(new OleDbParameter("@Lname", txtLastName.Text));
		myCommand.Parameters.Add(new OleDbParameter("@Title", txtTitle.Text));
		myCommand.Parameters.Add(new OleDbParameter("@EmpID", e.Item.Cells[1].Text ));
		myCommand.ExecuteNonQuery();
        MyDataGrid.EditItemIndex = -1;
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

