<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ProductsManager_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.ECommerce.ProductsManager_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<script type="text/javascript">

    function HideDiv1(dvmsg1) {

        var dvmsg = document.getElementById("<%=dvProblems.ClientID%>");
        dvmsg.style.display = 'none';
    }
    function CheckAll(oCheckbox) {
        var GridView2 = document.getElementById("<%=gvNews.ClientID %>");
        for (i = 1; i < GridView2.rows.length; i++) {
            if (null != GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0])
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
        }
    }
    
</script>
<div class="header">
    <h3>
        <asp:Label ID="lblProductPage" runat="server" Text='<%$Resources:ExpressCMS,lblProductPage %>'></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:DropDownList ID="ddlSearchProduct" runat="server" Width="200px" AutoPostBack="true">
        </asp:DropDownList>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleProduct" runat="server" Text='<%$Resources:ExpressCMS,lblGrdTitleProduct %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvProduct" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <EmptyDataTemplate>
                        <a>No data returned,please select search criterea </a>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID" HeaderText="ID" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvDoctorName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditProduct"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblProductName" runat="server" Text='<%$Resources:ExpressCMS,lblProductName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblProductName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSerial" runat="server" Text='<%$Resources:ExpressCMS,lblSerial %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtSerial" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSerial" Enabled="false" runat="server" ControlToValidate="txtSerial"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblSerial %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValue" runat="server" Text='<%$Resources:ExpressCMS,lblValue %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtValue" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvValue" Enabled="false" runat="server" ControlToValidate="txtValue"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblValue %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPublicPrice" runat="server" Text='<%$Resources:ExpressCMS,lblPublicPrice %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPublicprice" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvpublicprice" Enabled="false" runat="server" ControlToValidate="txtPublicprice"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPublicPrice %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrivatePrice" runat="server" Text='<%$Resources:ExpressCMS,lblPrivatePrice %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrivatePrice" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrivatePrice" Enabled="false" runat="server" ControlToValidate="txtPrivatePrice"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPrivatePrice %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                            ValidationGroup="AddEditProduct" Text="*" InitialValue="" Display="Dynamic" ErrorMessage="Category"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblImage" runat="server" Text="Image "></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fUploader" runat="server" />
                    </td>
                </tr>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblimage1" runat="server" Text="Image "></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fuploader1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Production Date
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="dtProductionDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="rfvProductiondate" runat="server" ControlToValidate="dtProductionDate"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Production Date"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Expiry Date
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rtExpiryDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator ID="rfvexpirydate" runat="server" ControlToValidate="rtExpiryDate"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage="Expiry Date"
                            InitialValue=""></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTax" runat="server" Text='<%$Resources:ExpressCMS,lblTax %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtTax" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtax" runat="server" ControlToValidate="txtTax"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblTax %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDiscount" runat="server" Text='<%$Resources:ExpressCMS,lblDiscount %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtDscount" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvdiscount" runat="server" ControlToValidate="lblDiscount"
                            ValidationGroup="AddEditProduct" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDiscount %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditProduct"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' OnClientClick="HideMessage(2000);" />
            </div>
            <asp:ValidationSummary ID="valsummaryProduct" runat="server" ValidationGroup="AddEditProduct"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSaveUpdate" />
    </Triggers>
</asp:UpdatePanel>
