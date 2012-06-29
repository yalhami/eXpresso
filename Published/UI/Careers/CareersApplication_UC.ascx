<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CareersApplication_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Careers.CareersApplication_UC" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<div class="ContentTitle" style="display: none;">
    <asp:Label ID="Label1" runat="server" Text='<%$Resources:ExpressCMS,lblApplytoCareer %>'></asp:Label>
</div>
<div id="dvProblems" runat="server">
</div>
<asp:Panel ID="plcControls" runat="server">
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
                <telerik:RadUpload runat="server" ID="fUploader" InitialFileInputsCount="1" MaxFileInputsCount="1"
                    AllowedFileExtensions=".jpg,.jpeg,.png,.bmp,.tiff" MaxFileSize="90485760" ControlObjectsVisibility="None" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCV" runat="server" Text='<%$Resources:ExpressCMS,lblCV %>'></asp:Label>
            </td>
            <td>
                <telerik:RadUpload runat="server" ID="fUploaderCV" InitialFileInputsCount="1" MaxFileInputsCount="1"
                    AllowedFileExtensions=".doc,.docx,.pdf" MaxFileSize="90485760" ControlObjectsVisibility="None" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblExperiences" runat="server" Text='<%$Resources:ExpressCMS,lblExperiences %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtExperiences" runat="server" TextMode="MultiLine" Height="140"
                    Width="500"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtExperiences"
                    ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblExperiences %>'></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblEducation" runat="server" Text='<%$Resources:ExpressCMS,lblEducation %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEducation" runat="server" TextMode="MultiLine" Height="140" Width="500"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEducation"
                    ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblEducation %>'></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCVText" runat="server" Text='<%$Resources:ExpressCMS,lblCVText %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtTextCV" runat="server" TextMode="MultiLine" Height="140" Width="500"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTextCV"
                    ValidationGroup="CareerApp" Text="*" Display="Dynamic" ErrorMessage='<%$Resources:ExpressCMS,lblCVText %>'></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <div class="btns">
        <asp:Button CssClass="btn" ID="btnSaveUpdate" runat="server" Width="60px" ValidationGroup="CareerApp"
            Text='<%$Resources:ExpressCMS, btnSaveUpdate %>' />
    </div>
    <asp:ValidationSummary ID="valsummaryContact" runat="server" ValidationGroup="CareerApp"
        HeaderText='<%$Resources:ExpressCMS, valSummHeader %>' DisplayMode="BulletList"
        ShowMessageBox="true" ShowSummary="false" />
</asp:Panel>
