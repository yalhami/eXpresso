<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BecomeVolunteerAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.Volunteer.BecomeVolunteer_UC" %>
<div class="gridTitle">
    <asp:Label ID="lblGrdTitleCat" runat="server" Text="Volntary Requests"></asp:Label>
</div>
<div style="background: white; overflow: auto; width: 100%; height: 150px;">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="SqlDataSource1" CssClass="grd" Height="20px" Width="100%" AllowPaging="True"
        AllowSorting="True">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
            <asp:BoundField DataField="MESSAGE" HeaderText="MESSAGE" SortExpression="MESSAGE" />
            <asp:TemplateField>
                <HeaderTemplate>
                    CV
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink ID="lbCv" Text="Download" runat="server" NavigateUrl='<%#GetCV(DataBinder.Eval(Container,"DataItem.CV").ToString()) %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CMS_EXPRESSConnectionString %>"
    SelectCommand="SELECT * FROM [Volunteer]" 
    DeleteCommand="DELETE FROM [Volunteer] WHERE [ID] = @ID" 
    InsertCommand="INSERT INTO [Volunteer] ([NAME], [EMAIL], [MESSAGE], [CV]) VALUES (@NAME, @EMAIL, @MESSAGE, @CV)" 
    UpdateCommand="UPDATE [Volunteer] SET [NAME] = @NAME, [EMAIL] = @EMAIL, [MESSAGE] = @MESSAGE, [CV] = @CV WHERE [ID] = @ID">
    <DeleteParameters>
        <asp:Parameter Name="ID" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="NAME" Type="String" />
        <asp:Parameter Name="EMAIL" Type="String" />
        <asp:Parameter Name="MESSAGE" Type="String" />
        <asp:Parameter Name="CV" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="NAME" Type="String" />
        <asp:Parameter Name="EMAIL" Type="String" />
        <asp:Parameter Name="MESSAGE" Type="String" />
        <asp:Parameter Name="CV" Type="String" />
        <asp:Parameter Name="ID" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

