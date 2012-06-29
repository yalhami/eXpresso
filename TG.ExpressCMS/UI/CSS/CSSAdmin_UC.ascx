﻿<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CSSAdmin_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.CSS.CSSAdmin_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<div class="header">
    <h3>
        <asp:Label ID="lblCSSAdmin" runat="server" Text="CSS Manager"></asp:Label>
    </h3>
</div>
<asp:UpdatePanel ID="upnlGird" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="dvProblems" runat="server">
        </div>
        <br />
        <div class="imgbtn">
            <asp:ImageButton ID="ibtnDelete" runat="server" ToolTip="Delete" ImageUrl="~/App_Themes/AdminSide2/Images/delete.png"
                Visible="true" OnClientClick="return ConfirmDelete();"></asp:ImageButton>
            <asp:ImageButton ID="ibtAdd" runat="server" ToolTip="Add" ImageUrl="~/App_Themes/AdminSide2/Images/add.png"
                Visible="true"></asp:ImageButton>
        </div>
        <div class="gridTitle">
            <asp:Label ID="lblGrdTitleCSS" runat="server" Text="CSS Files"></asp:Label>
        </div>
        <div style="background: white; overflow: auto; width: 100%; height: 255px;">
            <asp:TreeView ShowCheckBoxes="All" ID="trCSSFiles" runat="server" AutoGenerateDataBindings="false"
                ShowLines="true" ExpandImageUrl="~/App_Themes/AdminSide2/Images/expand.png" CollapseImageUrl="~/App_Themes/AdminSide2/Images/collapse.png">
            </asp:TreeView>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upnlControl" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:PlaceHolder ID="plccontrol" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                            ValidationGroup="AddEditCSS" Text="*" Display="Dynamic" ErrorMessage="Name"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDetails" runat="server" Text="Details"></asp:Label>
                    </td>
                    <td>
                        <HTMLEditor:Editor ActiveMode="Html" NoScript="false" NoUnicode="false" Width="650"
                            ID="txtDetails" runat="server" Height="450"></HTMLEditor:Editor>
                        <asp:RequiredFieldValidator ID="rfvDetails" runat="server" ControlToValidate="txtDetails"
                            ValidationGroup="AddEditCSS" Text="*" Display="Dynamic" ErrorMessage="Details"></asp:RequiredFieldValidator>
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
            <asp:ValidationSummary ID="valsummaryXsl" runat="server" ValidationGroup="AddEditCSS"
                HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
                ShowMessageBox="true" ShowSummary="false" />
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>