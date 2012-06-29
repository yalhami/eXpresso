<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="SawwtyyatAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.Sawtyyat.SawwtyyatAdmin_UC" %>
<script type="text/javascript">

    function HideDiv1(dvmsg1) {

        var dvmsg = document.getElementById("<%=dvProblems.ClientID%>");
        dvmsg.style.display = 'none';
    }
    function CheckAll(oCheckbox) {
        var GridView2 = document.getElementById("<%=gvSawtyyat.ClientID %>");
        for (i = 1; i < GridView2.rows.length; i++) {
            if (null != GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0])
                GridView2.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
        }
    }
</script>
<asp:UpdatePanel ID="upnlall" runat="server">
    <ContentTemplate>
        <div class="header">
            <h3>
                <asp:Label ID="lblSawtyyatHeader" runat="server" Text='<%$Resources:ExpressCMS,lblSawtyyatHeader %>'></asp:Label>
            </h3>
        </div>
        <telerik:RadProgressArea runat="server" ID="ProgressArea1">
        </telerik:RadProgressArea>
        <telerik:RadProgressManager ID="Radprogressmanager1" runat="server" />
        <tr>
            <td>
                <asp:Label ID="lblSearchType" runat="server" Text='<%$Resources:ExpressCMS,lblType %>'></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSearchtype" runat="server" Width="254">
                </asp:DropDownList>
            </td>
        </tr>
        <div class="actions">
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn" />
        </div>
        <br />
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:Panel ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblSawtyyaTitle" runat="server" Text='<%$Resources:ExpressCMS,lblSawtyyaTitle %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvSawtyyat" runat="server" PageSize="9" AllowPaging="True" AllowSorting="false"
                    AutoGenerateColumns="False" DataKeyNames="ID" Width="100%">
                    <EmptyDataTemplate>
                        <a>No data returned,please select search criterea </a>
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:TemplateField>
                            <HeaderStyle Width="5%" />
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkItemheader" onclick="CheckAll(this);" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItemUnique" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbName" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container,"DataItem.ID") %>'
                                    runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Details" HeaderText="Details" />
                    </Columns>
                </asp:GridView>
            </div>
        </asp:Panel>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblType" runat="server" Text='<%$Resources:ExpressCMS,lblType %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlType" runat="server" Width="254" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="ddlType"
                            ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblType %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategory"
                            ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic" ErrorMessage="Category"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text='<%$Resources:ExpressCMS,lblName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trFile">
                    <td>
                        <asp:Label ID="lblFile" runat="server" Text='<%$Resources:ExpressCMS,lblFile %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload ID="fUploader" ControlObjectsVisibility="All" runat="server" MaxFileInputsCount="12"
                            OverwriteExistingFiles="true" MaxFileSize="104857600" />
                    </td>
                </tr>
           
                <tr>
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text='<%$Resources:ExpressCMS,lblDetails %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="280" ID="txtDetails" runat="server" TextMode="MultiLine" Height="120"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDetails %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditFatawa"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryFatawa" runat="server" ValidationGroup="AddEditFatawa"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSaveUpdate" />
    </Triggers>
</asp:UpdatePanel>
