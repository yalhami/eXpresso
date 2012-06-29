<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="MarqueeAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Marquee.MarqueeAdmin_UC" %>
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
        <asp:Label ID="lblMarqueePage" runat="server" Text="Marquee Manager"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblSearch" runat="server" Text="Keyword"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSearch" Width="250px" runat="server" ValidationGroup="SearchValG"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvsearch" runat="server" ControlToValidate="txtSearch"
                        ValidationGroup="valSearch" Text="*" Display="Dynamic" ErrorMessage="* "></asp:RequiredFieldValidator>
                    <asp:Button CssClass="btn" Height="21" ID="btnSearch" runat="server" Text="Search"
                        ValidationGroup="SearchValG" CausesValidation="true" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server" class="dvmessages">
        </div>
        <asp:PlaceHolder ID="plcGridView" runat="server">
            <div class="imgbtn">
                <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip="Delete" ImageUrl="~/App_Themes/AdminSide2/Images/delete.png"
                    Visible="true" OnClientClick="return ConfirmDelete();"></asp:ImageButton>
                <asp:ImageButton ID="ibtnadd" runat="server" ToolTip="Add" CausesValidation="False"
                    ImageUrl="~/App_Themes/AdminSide2/Images/add.png"></asp:ImageButton></div>
            <div class="gridTitle">
                <asp:Label ID="lblGrdTitleMarquee" runat="server" Text="Marquees"></asp:Label>
            </div>
            <div style="background: white; overflow: auto; width: 100%; height: 255px;">
                <asp:GridView ID="gvMarquee" runat="server" AllowPaging="true" PageSize="25" AutoGenerateColumns="false"
                    CssClass="grd" Height="20px" Width="100%">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkItem" runat="server" />
                                <input type="hidden" id="hdnID" runat="server" value='<%#DataBinder.Eval(Container,"DataItem.ID")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Label ID="lblH" runat="server" Text="Name"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lblgvMenuName" runat="server" Text='<%#DataBinder.Eval(Container,"DataItem.Name")%>'
                                    CommandArgument='<%#DataBinder.Eval(Container,"DataItem.ID")%>' CommandName="EditmarqueeItems"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
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
                        <asp:Label ID="lblMarqueeName" runat="server" Text="Name "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditMarquee" Text="*" Display="Dynamic" ErrorMessage="Name "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblText" runat="server" Text="Text"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtText" runat="server" TextMode="MultiLine" Height="60px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSpecilization" runat="server" ControlToValidate="txtText"
                            ValidationGroup="AddEditMarquee" Text="*" Display="Dynamic" ErrorMessage="Text "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCategory" runat="server" Text="Category "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategories" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategories"
                            ValidationGroup="AddEditMarquee" Text="*" Display="Dynamic" ErrorMessage="Category "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMarqueeType" runat="server" Text="Type "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMarqueeType" runat="server" Width="254" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMarqueeType" runat="server" ControlToValidate="ddlMarqueeType"
                            ValidationGroup="AddEditMarquee" Text="*" Display="Dynamic" ErrorMessage="Type "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trURL" visible="false">
                    <td>
                        <asp:Label ID="lblURL" runat="server" Text="URL "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" Height="70" TextMode="MultiLine" ID="txtURL" runat="server"
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvURL" runat="server" ControlToValidate="txtURL"
                            ValidationGroup="AddEditMarquee" Text="*" Display="Dynamic" ErrorMessage="URL "></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td>
                        <asp:Label ID="lblImage" runat="server" Text="Image "></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload ID="fUploader" runat="server" />
                    </td>
                </tr>
                <tr runat="server" id="trDetails">
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details "></asp:Label>
                    </td>
                    <td>
                        <CE:Editor ID="txtDetails" BreakElement="Br" runat="server" Width="97%" Height="500px"
                            EnableBrowserContextMenu="False" EditorWysiwygModeCss="example.css">
                           
                        </CE:Editor>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditMarquee" Text="*" Display="Dynamic" ErrorMessage="Details "></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" OnClientClick="HideMessage(2000);"
                    ValidationGroup="AddEditMarquee" Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
            <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="AddEditMarquee"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
