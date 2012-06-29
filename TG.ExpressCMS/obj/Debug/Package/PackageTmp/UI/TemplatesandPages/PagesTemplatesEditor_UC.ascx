<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PagesTemplatesEditor_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.TemplatesandPages.PagesTemplatesEditor_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<div class="header">
    <h3>
        <asp:Label ID="lblPagePage" runat="server" Text="Page and Template Editor"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlAll" runat="server">
    <ContentTemplate>
        <div runat="server" id="dvproblems">
        </div>
        <asp:PlaceHolder ID="plControls" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblEditTemplates" runat="server" Text="Templates"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="chkEditTemplates" runat="server" AutoPostBack="true" />
                    </td>
                </tr>
                <tr runat="server" id="trPages">
                    <td>
                        <asp:Label ID="lblPages" runat="server" Text="Pages"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPages" runat="server" Width="254" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="trTemplates">
                    <td>
                        <asp:Label ID="lblTemplate" runat="server" Text="Templates"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTemplates" runat="server" Width="254" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBlocks" runat="server" Text="Blocks"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBlocks" runat="server" Width="254" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="dvRegisterTag" runat="server" Width="280" TextMode="MultiLine" Height="50"></asp:TextBox>
                    </td>
                </tr>
                <tr runat="server" id="trCategories">
                    <td>
                        <asp:Label ID="lblCategories" runat="server" Text="Categories"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlCategories" runat="server" Width="254">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="trXSLs">
                    <td>
                        <asp:Label ID="lblXSL" runat="server" Text="XSLs"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlXSLs" runat="server" Width="254">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id="trHTMLs">
                    <td>
                        <asp:Label ID="lblHTML" runat="server" Text="HTML"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlHTML" runat="server" Width="254">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" Height="400" Width="880"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditXsl" Text="*" Display="Dynamic" ErrorMessage="Details"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="btns">
                <asp:Button CssClass="btn" ID="btnExit" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnExit %>' />
                <asp:Button CssClass="btn" ID="btnReset" runat="server" Width="60px" CausesValidation="false"
                    Text='<%$Resources:ExpressCMS, btnReset %>' />
                <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="AddEditXsl"
                    Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
            </div>
        </asp:PlaceHolder>
        <asp:ValidationSummary ID="valsummaryXsl" runat="server" ValidationGroup="AddEditXsl"
            HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
            ShowMessageBox="true" ShowSummary="false" />
    </ContentTemplate>
</asp:UpdatePanel>
