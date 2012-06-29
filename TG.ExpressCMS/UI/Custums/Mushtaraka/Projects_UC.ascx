<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="Projects_UC.ascx.cs"
    Inherits="TG.ExpressCMS.Projects_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<script type="text/javascript">

    function HideMessage(timeout) {

        setTimeout("HideDiv1();", timeout);
    }
    function HideDiv1(dvmsg1) {

        var dvmsg = document.getElementById("<%=dvProblems.ClientID%>");
        dvmsg.style.display = 'none';
    }

</script>
<div class="header">
    <h3>
        <asp:Label ID="lblCatPage" runat="server" Text="Projects Manager"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnDelete %>'
                    ImageUrl="~/App_Themes/AdminSide2/Images/delete.png" Visible="true" OnClientClick="return ConfirmDelete();">
                </asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip='<%$Resources:ExpressCMS,ibtnadd %>'
                    CausesValidation="False" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleCat" runat="server" Text="Projects"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvCat" runat="server" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
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
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditCat"></asp:LinkButton>
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
                        <asp:Label ID="lblDoctorName" runat="server" Text='<%$Resources:ExpressCMS,lblDoctorName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditCat" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDoctorName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%$Resources:ExpressCMS,lblDescription %>'></asp:Label>
                    </td>
                    <td>
                        <HTMLEditor:Editor runat="server" Height="300px" Width="65%" AutoFocus="true" ID="txtDesc" />
                        <asp:RequiredFieldValidator ID="rfvSpecilization" runat="server" ControlToValidate="txtDesc"
                            ValidationGroup="AddEditCat" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblDescription %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditCat"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' OnClientClick="HideMessage(2000);" />
            </div>
            <asp:ValidationSummary ID="valsummaryCat" runat="server" ValidationGroup="AddEditCat"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSaveUpdate" />
    </Triggers>
</asp:UpdatePanel>
