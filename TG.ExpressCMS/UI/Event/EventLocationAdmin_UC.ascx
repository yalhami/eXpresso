<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="EventLocationAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Event.EventLocationAdmin_UC" %>
<div class="header">
    <h3>
        <asp:Label ID="lblEventLocationPage" runat="server" Text='<%$Resources:EventResource, EventLocationManager %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:EventResource, Delete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnAdd" runat="server" ToolTip='<%$Resources:EventResource, Add %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton>
            </div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleEventLocation" runat="server" Text='<%$Resources:EventResource, EventLocations %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvEventLocation" runat="server" AllowPaging="true" PageSize="25"
                    AutoGenerateColumns="false" CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText='<%$Resources:EventResource, Name %>'>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblLocationName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditEventLocation"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:Label ID="lblNoEventLocations" runat="server" Text='<%$Resources:EventResource, NoEventLocations %>'></asp:Label>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlControls" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td style="width: 20%">
                        <asp:Label ID="lblName" runat="server" Text='<%$Resources:EventResource, Name %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditEventLocation" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:EventResource, Name %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:EventResource, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:EventResource, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSave" runat="server" Width="60px" ValidationGroup="AddEditEventLocation"
                    Text='<%$Resources:EventResource, btnSave %>' />
                <asp:Button CssClass="btn" ID="btnUpdate" runat="server" Width="60px" ValidationGroup="AddEditEventLocation"
                    Text='<%$Resources:EventResource, btnUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditEventLocation"
                HeaderText='<%$Resources:EventResource, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
