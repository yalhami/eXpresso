<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FatwaAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Fatwa.FatwaAdmin_UC" %>
<asp:UpdatePanel ID="upnall" runat="server">
    <ContentTemplate>
        <div class="header">
            <h3>
                <asp:Label ID="lblFatawaPage" runat="server" Text='<%$Resources:ExpressCMS,lblFatawaPage %>'></asp:Label>
            </h3>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        Keyword
                    </td>
                    <td>
                        <asp:TextBox CssClass="txt" ID="txtKeyword" runat="server" Width="165" ValidationGroup="SearchValG"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Category
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" Width="170">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatusSearch" runat="server" Width="170">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <div class="actions">
                <asp:Button ID="btnSearch" CssClass="btn" runat="server" ValidationGroup="SearchValG"
                    Width="70" Height="22" Text="Search" />
            </div>
        </div>
        <br />
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
                <asp:Label ID="lblGrdTitleFatawa" runat="server" Text='<%$Resources:ExpressCMS,lblGrdTitleFatawa %>'></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 100%;">
                <asp:GridView ID="gvFatwa" runat="server" PageSize="9" AllowPaging="True" AllowSorting="false"
                    AutoGenerateColumns="False" Width="100%" CssClass="grd" Height="20px">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <itemstyle width="5%" horizontalalign="left" />
                                <input type="hidden" runat="server" id="hdnID" value='<%#DataBinder.Eval(Container,"DataItem.ID") %>' />
                                <asp:CheckBox ID="chkItem" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <HeaderTemplate>
                                Name
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbName" CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container,"DataItem.ID") %>'
                                    runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="QUESTION" HeaderText="Question" SortExpression="QUESTION"
                            ControlStyle-Width="50%" ItemStyle-Width="60%" />
                        <asp:BoundField DataField="QUESTIONDATE" HeaderText="Question Date" SortExpression="QUESTIONDATE"
                            ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center" />
                    </Columns>
                    <EmptyDataTemplate>
                        <a>No data returned,please select search criterea </a>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </asp:Panel>
        <asp:PlaceHolder ID="plcControls" runat="server">
            <table width="100%">
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
                <tr>
                    <td>
                        <asp:Label ID="lblCategory" runat="server" Text='<%$Resources:ExpressCMS,lblCategory %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategories" runat="server" Width="254px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategories"
                            InitialValue="تصنيفات الفتاوى...." ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic"
                            ErrorMessage='<%$Resources:ExpressCMS,lblCategory %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Status
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="170">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvStatus" runat="server" ControlToValidate="ddlStatus"
                            InitialValue="" ValidationGroup="ddlStatus" Text="*" Display="Dynamic" ErrorMessage="Status"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmail %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSpecilization" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblQuestion" runat="server" Text='<%$Resources:ExpressCMS,lblQuestion %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="95%" ID="txtQuestion" runat="server" TextMode="MultiLine" Height="260px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQuestion"
                            ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblQuestion %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAnswer" runat="server" Text='<%$Resources:ExpressCMS,lblAnswer %>'></asp:Label>
                    </td>
                    <td>
                        <CE:Editor ID="txtAnswer" BreakElement="Br" runat="server" Width="97%" Height="500px"
                            EnableBrowserContextMenu="False" EditorWysiwygModeCss="example.css">
                            <FrameStyle Height="100%" BorderWidth="1px" BorderStyle="Solid" BorderColor="#DDDDDD"
                                Width="100%" CssClass="CuteEditorFrame" BackColor="White"></FrameStyle>
                        </CE:Editor>
                        <asp:RequiredFieldValidator ID="rfvAnswer" runat="server" ControlToValidate="txtAnswer"
                            ValidationGroup="AddEditFatawa" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblAnswer %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" CausesValidation="true"
                    Width="60px" ValidationGroup="AddEditFatawa" Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryFatawa" runat="server" ValidationGroup="AddEditFatawa"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
