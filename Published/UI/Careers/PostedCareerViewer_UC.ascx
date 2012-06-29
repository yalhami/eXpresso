<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostedCareerViewer_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Careers.PostedCareerViewer_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<div class="header">
    <h3>
        <asp:Label ID="lblPostedCareerPage" runat="server" Text="Posted Careers Applications"></asp:Label>
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
                <asp:ImageButton ID="ibtntoExcel" runat="server" Width="17" Height="17" ImageUrl="~/App_Themes/AdminSide2/Images/xls.png"
                    ToolTip="Export to Excel" />
            </div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitlePostedCareer" runat="server" Text="Posted Job Applications"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvPostedCareer" runat="server" AllowPaging="true" PageSize="9"
                    AutoGenerateColumns="false" CssClass="grd" Height="20px" Width="100%">
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
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID") %>' CommandName="EditCareerPost"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Career
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblType" runat="server" Text='<%#GetCareer(Convert.ToInt32(DataBinder.Eval(Container,"DataItem.JobID"))) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <asp:Panel ID="Panel1" runat="server">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="lblFullName" runat="server" Text='<%$Resources:ExpressCMS,lblFullName %>'></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblFullName %>'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPhone" runat="server" Text='<%$Resources:ExpressCMS,lblPhone %>'></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox Width="250" ID="txtPhone" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                                ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblPhone %>'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblJobID" runat="server" Text='<%$Resources:ExpressCMS,JobID %>'></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlJobID" runat="server" Width="254px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvJobID" runat="server" ControlToValidate="txtName"
                                ValidationGroup="CareerApp" Text="*" Display="Dynamic" InitialValue="" ErrorMessage='<%$Resources:ExpressCMS,JobID %>'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblImage" runat="server" Text='<%$Resources:ExpressCMS,lblImage %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="img" runat="server" Width="80" Height="80" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCV" runat="server" Text='<%$Resources:ExpressCMS,lblCV %>'></asp:Label>
                        </td>
                        <td>
                            <asp:HyperLink ID="hypCV" runat="server"></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblExperiences" runat="server" Text='<%$Resources:ExpressCMS,lblExperiences %>'></asp:Label>
                        </td>
                        <td>
                            <HTMLEditor:Editor Width="650" ID="txtExperiences" runat="server" Height="120"></HTMLEditor:Editor>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtExperiences"
                                ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblExperiences %>'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblEducation" runat="server" Text='<%$Resources:ExpressCMS,lblEducation %>'></asp:Label>
                        </td>
                        <td>
                            <HTMLEditor:Editor Width="650" ID="txtEducation" runat="server" Height="120"></HTMLEditor:Editor>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEducation"
                                ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEducation %>'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCVText" runat="server" Text='<%$Resources:ExpressCMS,lblCVText %>'></asp:Label>
                        </td>
                        <td>
                            <HTMLEditor:Editor Width="650" ID="txtTextCV" runat="server" Height="120"></HTMLEditor:Editor>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTextCV"
                                ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCVText %>'></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryPostedCareer" runat="server" ValidationGroup="AddEditPostedCareer"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="ibtntoExcel" />
    </Triggers>
</asp:UpdatePanel>
