<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="AlramzUserRegistration_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.AlramzUserRegistration_UC" %>
<%@ Register Src="../../Html/HtmlViewer_UC.ascx" TagName="HtmlViewer_UC" TagPrefix="uc1" %>
<div runat="server" id="dvmessages">
</div>
<asp:UpdateProgress ID="UpdateProgressAnimation" runat="server" DisplayAfter="0">
    <ProgressTemplate>
        <%-- <div class="LoadingContainer">
            </div>--%>
        <div class="Loading">
            <img src="../App_Themes/AdminSide/images/ajax-loader(2).gif" /></div>
    </ProgressTemplate>
</asp:UpdateProgress>
<div class="ContentTitle" style="display: none;">
    <asp:Label ID="Label1" runat="server" Text='<%$Resources:ExpressCMS,lblRegistration %>'></asp:Label>
</div>
<asp:UpdatePanel runat="server" ID="upnlfirst">
    <ContentTemplate>
        <asp:Panel ID="pnlFirst" runat="server">
            <table>
                <tr>
                    <td colspan="2" class="ContentTitle">
                        <br />
                        <asp:Label ID="lblFirlst" runat="server" Text='<%$Resources:ExpressCMS,lblFirlst %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblPleaseFillbelow" runat="server" Text='<%$Resources:ExpressCMS,lblPleaseFillbelow %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblAccordingtoBelow" runat="server" Text='<%$Resources:ExpressCMS,lblAccording %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMrMrss" runat="server" Text='<%$Resources:ExpressCMS,lblMrMrs %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFullName" runat="server" Width="250" MaxLength="80"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvFullName" runat="server" ControlToValidate="txtFullName"
                            ValidationGroup="AccountType" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblMrMrs %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNumberinABDSE" runat="server" Text='<%$Resources:ExpressCMS,lblNumberinABDSE %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserNumberinABD" runat="server" Width="250" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvUserNumberinABD" runat="server"
                            ControlToValidate="txtUserNumberinABD" ValidationGroup="AccountType" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblNumberinABDSE %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNumberInDubai" runat="server" Text='<%$Resources:ExpressCMS,lblNumberInDubai %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumberInDubail" runat="server" Width="250" MaxLength="30"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvtxtNumberInDubai" runat="server"
                            ControlToValidate="txtNumberInDubail" ValidationGroup="AccountType" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblNumberInDubai %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAccountType" runat="server" Text='<%$Resources:ExpressCMS,lblAccountType %>'></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAccountType" runat="server" Width="254">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvAccountType" runat="server" ControlToValidate="ddlAccountType"
                            ValidationGroup="AccountType" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblAccountType %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
            </table>
            <div class="actions">
                <asp:Button ID="btnStart" runat="server" CausesValidation="true" ValidationGroup="AccountType"
                    CssClass="btn" Text='<%$Resources:ExpressCMS,btnStart %>' />
                <asp:ValidationSummary ID="valSummaryIndiv" runat="server" ValidationGroup="AccountType"
                    HeaderText='<%$Resources:ExpressCMS,valSummHeader %>' ShowMessageBox="true" ShowSummary="false"
                    DisplayMode="BulletList" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server" ID="upnlIndiv">
    <ContentTemplate>
        <asp:Panel ID="pnlIndividuals" runat="server">
            <table>
                <tr>
                    <td colspan="2" class="ContentTitle">
                        <asp:Label ID="lblIndividual" runat="server" Text='<%$Resources:ExpressCMS,lblIndividual %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNationality" runat="server" Text='<%$Resources:ExpressCMS,lblNationality %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtNationality" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvNationality" runat="server" ControlToValidate="txtNationality"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblNationality %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassportNumber" runat="server" Text='<%$Resources:ExpressCMS,lblPassportNumber %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPassportNumber" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvtxtPassportNumber" runat="server"
                            ControlToValidate="txtPassportNumber" ValidationGroup="valIndividuals" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblPassportNumber %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBirthdate" runat="server" Text='<%$Resources:ExpressCMS,lblbdate %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="dtbDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvbDate" runat="server" ControlToValidate="dtbDate"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblbdate %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPhone" runat="server" Text='<%$Resources:ExpressCMS,lblPhone %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPhone" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPhone %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMobile" runat="server" Text='<%$Resources:ExpressCMS,lblMobile %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtMobile" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvMobile" runat="server" ControlToValidate="txtMobile"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblMobile %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPOBox" runat="server" Text='<%$Resources:ExpressCMS,lblPOBox %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPOBox" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvBOPox" runat="server" ControlToValidate="txtPOBox"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPOBox %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text='<%$Resources:ExpressCMS,lblEmail %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtEmail" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                            ValidationGroup="Regiter" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblWork" runat="server" Text='<%$Resources:ExpressCMS,lblWork %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtWorkWith" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <%-- <asp:RequiredFieldValidator Display="Static" ID="rfvWork" runat="server" ControlToValidate="txtWorkWith"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblWork %>'></asp:RequiredFieldValidator>--%>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProfession" runat="server" Text='<%$Resources:ExpressCMS,lblProfession %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtProfession" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvProfession" runat="server" ControlToValidate="txtProfession"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblProfession %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblWorksAdd" runat="server" Text='<%$Resources:ExpressCMS,lblWorksAdd %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtWorksAdd" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator Display="Static" ID="rfvWorksAdd" runat="server" ControlToValidate="txtWorksAdd"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblWorksAdd
                        %>'></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmpolymentNumber" runat="server" Text='<%$Resources:ExpressCMS,lblEmpolymentNumber %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtEmploymentNumber" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <%--  <asp:RequiredFieldValidator Display="Static" ID="rfvEmploymentNumber" runat="server" ControlToValidate="txtEmploymentNumber"
                            ValidationGroup="valIndividuals" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblEmpolymentNumber %>'></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblResidencePlace" runat="server" Text='<%$Resources:ExpressCMS,lblResidencePlace %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtResidencePlace" runat="server" MaxLength="50" ValidationGroup="valIndividuals"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvResidencePlace" runat="server"
                            ControlToValidate="txtResidencePlace" ValidationGroup="valIndividuals" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblResidencePlace %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
            </table>
            <div class="actions">
                <div class="btnNext">
                    <asp:Button ID="btnIdividual" runat="server" CausesValidation="true" ValidationGroup="valIndividuals"
                        CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
                </div>
                <div class="btnBack">
                    <asp:Button ID="btnbacktoinital" runat="server" CausesValidation="false" CssClass="btn back"
                        Text='<%$Resources:ExpressCMS,btnback %>' />
                </div>
                <asp:ValidationSummary ID="valSummaryIdiv" runat="server" ValidationGroup="valIndividuals"
                    HeaderText='<%$Resources:ExpressCMS,valSummHeader %>' ShowMessageBox="true" DisplayMode="BulletList"
                    ShowSummary="false" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server" ID="upnlcompanies">
    <ContentTemplate>
        <asp:Panel ID="pnlCompanies" runat="server">
            <table>
                <tr>
                    <td colspan="2" class="ContentTitle">
                        <asp:Label ID="lblCompanies" runat="server" Text='<%$Resources:ExpressCMS,lblCompanies %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTradeName" runat="server" Text='<%$Resources:ExpressCMS,lblTradeName  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtcomTradeName" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvTradeName" runat="server" ControlToValidate="txtcomTradeName"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblTradeName %>'></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <div class="Reqiured">
                            *</div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLegalForm" runat="server" Text='<%$Resources:ExpressCMS,lblLegalForm %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtcomLegalForm" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvLegalForm" runat="server" ControlToValidate="txtcomLegalForm"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblLegalForm %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNationalityCompany" runat="server" Text='<%$Resources:ExpressCMS,lblNationalityCompany %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtNationalityCompany" runat="server" MaxLength="50"
                            ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtNationalityCompany" ValidationGroup="valCompanies" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblNationalityCompany %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTypeBranch" runat="server" Text='<%$Resources:ExpressCMS,lblTypeBranch %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtcomTypeBranch" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvTypeBranch" runat="server" ControlToValidate="txtcomTypeBranch"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblTypeBranch %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblADCCMemberNumber" runat="server" Text='<%$Resources:ExpressCMS,lblADCCMemberNumber %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtADCCMemberNumber" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvADCCMemberNumber" runat="server"
                            ControlToValidate="txtADCCMemberNumber" ValidationGroup="valCompanies" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblADCCMemberNumber %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIssueDate" runat="server" Text='<%$Resources:ExpressCMS,lblIssueDate %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rtDateOfIssue" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvDateofIssue" runat="server" ControlToValidate="rtDateOfIssue"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblIssueDate %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblDateofExpiry" runat="server" Text='<%$Resources:ExpressCMS,lblDateofExpiry %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdDateofExpiry" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvDateExpiry" runat="server" ControlToValidate="rdDateofExpiry"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblDateofExpiry %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTradeNumber" runat="server" Text='<%$Resources:ExpressCMS,lblTradeNumber %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtcomTradeNumber" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvTradeNumber" runat="server" ControlToValidate="txtcomTradeNumber"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblTradeNumber %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTradeIssueDate" runat="server" Text='<%$Resources:ExpressCMS,lblTradeIssueDate %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdDateIssueTrade" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvTradeIssuedate" runat="server"
                            ControlToValidate="rdDateIssueTrade" ValidationGroup="valCompanies" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblTradeIssueDate %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTradeExpiryDate" runat="server" Text='<%$Resources:ExpressCMS,lblTradeExpiryDate %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdTradeExpiryDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvTradeIssueExpiryDate" runat="server"
                            ControlToValidate="rdTradeExpiryDate" ValidationGroup="valCompanies" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblTradeExpiryDate %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCompanyPhone" runat="server" Text='<%$Resources:ExpressCMS,lblCompanyPhone %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtCompanyPhone" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvCompanyPhone" runat="server"
                            ControlToValidate="txtCompanyPhone" ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblCompanyPhone %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComFax" runat="server" Text='<%$Resources:ExpressCMS,lblComFax %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComFax" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComFax" runat="server" ControlToValidate="txtComFax"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblEmail %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComPOBox" runat="server" Text='<%$Resources:ExpressCMS,lblComPOBox %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComPOBox" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComPOBox" runat="server" ControlToValidate="txtComPOBox"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComPOBox %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComAddress" runat="server" Text='<%$Resources:ExpressCMS,lblComAddress %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComAddress" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComAddress" runat="server" ControlToValidate="txtComAddress"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComAddress %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComEmail" runat="server" Text='<%$Resources:ExpressCMS,lblComEmail %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComEmail" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtComEmail" ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComEmail %>'></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regComEmail" runat="server" ControlToValidate="txtComEmail"
                            ValidationGroup="valCompanies" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblSigauthorities" runat="server" Text='<%$Resources:ExpressCMS,lblSigauthorities %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComSignAuthorities" runat="server" MaxLength="50"
                            ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComSignAuthorites" runat="server"
                            ControlToValidate="txtComSignAuthorities" ValidationGroup="valCompanies" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblSigauthorities %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComNationality" runat="server" Text='<%$Resources:ExpressCMS,lblComNationality %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtCompanyNationality" runat="server" MaxLength="50"
                            ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComNationality" runat="server"
                            ControlToValidate="txtCompanyNationality" ValidationGroup="valCompanies" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblComNationality %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComPassport" runat="server" Text='<%$Resources:ExpressCMS,lblComPassport %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComPassport" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComPassport" runat="server" ControlToValidate="txtComPassport"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComPassport %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComBDate" runat="server" Text='<%$Resources:ExpressCMS,lblComBDate %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdComBDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComBDate" runat="server" ControlToValidate="rdDateIssueTrade"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComBDate %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComPhone1" runat="server" Text='<%$Resources:ExpressCMS,lblCompanyPhone %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComPhone1" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComPhone1" runat="server" ControlToValidate="txtComPhone1"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblCompanyPhone %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComFax1" runat="server" Text='<%$Resources:ExpressCMS,lblComFax %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComFax1" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComFax1" runat="server" ControlToValidate="txtComFax1"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComFax %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComPoBox1" runat="server" Text='<%$Resources:ExpressCMS,lblComPOBox %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComPOBox1" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvComPOBox1" runat="server" ControlToValidate="txtComPOBox1"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComPOBox %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComAddress1" runat="server" Text='<%$Resources:ExpressCMS,lblComAddress %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtComAddress1" runat="server" MaxLength="50" ValidationGroup="valCompanies"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="txtComAddress1" ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComAddress %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="actions">
                <div class="btnNext">
                    <asp:Button ID="btnNextCompany" runat="server" CausesValidation="true" ValidationGroup="valCompanies"
                        CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
                </div>
                <div class="btnBack">
                    <asp:Button ID="btnBack2" runat="server" CausesValidation="false" CssClass="btn back"
                        Text='<%$Resources:ExpressCMS,btnback %>' />
                </div>
                <asp:ValidationSummary ID="valCompanySummary" runat="server" ValidationGroup="valCompanies"
                    HeaderText='<%$Resources:ExpressCMS,valSummHeader %>' ShowMessageBox="true" DisplayMode="BulletList"
                    ShowSummary="false" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server" ID="upnlProxyTrustee">
    <ContentTemplate>
        <asp:Panel ID="pnlProxyTrustee" runat="server">
            <table>
                <tr>
                    <td colspan="2" class="ContentTitle">
                        <asp:Label ID="lblProxyTrustee" runat="server" Text='<%$Resources:ExpressCMS,lblProxyTrustee %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProxyName" runat="server" Text='<%$Resources:ExpressCMS,lblProxyName  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtProxyName" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvProxyName" runat="server" ControlToValidate="txtProxyName"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblProxyName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblpproxeeTrusteeNationality" runat="server" Text='<%$Resources:ExpressCMS,lblpproxeeTrusteeNationality  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtProxeeTrustee" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtProxeeTrustee" ValidationGroup="vaProxyTrustee" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblpproxeeTrusteeNationality %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrPassportNumber" runat="server" Text='<%$Resources:ExpressCMS,lblPrPassportNumber  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrPassportNumber" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPrPasspotNumber" runat="server"
                            ControlToValidate="txtPrPassportNumber" ValidationGroup="vaProxyTrustee" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblPrPassportNumber %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrDob" runat="server" Text='<%$Resources:ExpressCMS,lblPrDob %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="dtProd" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPrDate" runat="server" ControlToValidate="dtProd"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrDob %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrPhone" runat="server" Text='<%$Resources:ExpressCMS,lblPrPhone  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrPhone" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtPrPhone" ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrPhone %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrMobile" runat="server" Text='<%$Resources:ExpressCMS,lblPrMobile  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrMobile" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPrProxeeTrustee" runat="server"
                            ControlToValidate="txtPrMobile" ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrMobile %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrWorksAt" runat="server" Text='<%$Resources:ExpressCMS,lblPrWorksAt  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrWorksAt" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <%--   <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPrWorksAt"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrWorksAt %>'></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrProfession" runat="server" Text='<%$Resources:ExpressCMS,lblPrProfession %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrProfession" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator7" runat="server"
                            ControlToValidate="txtPrProfession" ValidationGroup="vaProxyTrustee" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblPrProfession %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrAddress" runat="server" Text='<%$Resources:ExpressCMS,lblPrAddress %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrAddress" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPrAddress" runat="server" ControlToValidate="txtPrAddress"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrAddress %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrEmploymentnumber" runat="server" Text='<%$Resources:ExpressCMS,lblPrEmploymentnumber %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrEmploymentNumber" runat="server" MaxLength="50"
                            ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <%-- <asp:RequiredFieldValidator Display="Static" ID="rfvPrEmploymentNumber" runat="server" ControlToValidate="txtPrEmploymentNumber"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrEmploymentnumber %>'></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblResidenceAddress" runat="server" Text='<%$Resources:ExpressCMS,lblResidenceAddress %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtResidenAddress" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPrWorkAddress" runat="server"
                            ControlToValidate="txtResidenAddress" ValidationGroup="vaProxyTrustee" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblResidenceAddress %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrPOBox" runat="server" Text='<%$Resources:ExpressCMS,lblPrPOBox %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrBoPox" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPrBoPox" runat="server" ControlToValidate="txtPrBoPox"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrPOBox %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrEmail" runat="server" Text='<%$Resources:ExpressCMS,lblPrEmail %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrEmail" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvPrEmail" runat="server" ControlToValidate="txtPrEmail"
                            ValidationGroup="valCompanies" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrEmail %>'></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtComEmail"
                            ValidationGroup="txtPrEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblProxyNumber" runat="server" Text='<%$Resources:ExpressCMS,lblProxyNumber %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtProxynumber" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvProxyNumber" runat="server" ControlToValidate="txtProxynumber"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblProxyNumber %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrissueDate" runat="server" Text='<%$Resources:ExpressCMS,lblPrissueDate %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdIssueDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvIssueDate" runat="server" ControlToValidate="dtProd"
                            ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrissueDate %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPrPlaceAddress" runat="server" Text='<%$Resources:ExpressCMS,lblPrPlaceAddress %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtPrPlaceAddress" runat="server" MaxLength="50" ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator8" runat="server"
                            ControlToValidate="txtPrAddress" ValidationGroup="vaProxyTrustee" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrPlaceAddress %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="actions">
                <div class="btnNext">
                    <asp:Button ID="btnNextProxee" runat="server" CausesValidation="true" ValidationGroup="vaProxyTrustee"
                        CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
                </div>
                <div class="btnBack">
                    <asp:Button ID="btnback3" runat="server" CausesValidation="false" CssClass="btn back"
                        Text='<%$Resources:ExpressCMS,btnback %>' />
                </div>
                <asp:ValidationSummary ID="valPrSummary" runat="server" ValidationGroup="vaProxyTrustee"
                    HeaderText='<%$Resources:ExpressCMS,valSummHeader %>' ShowMessageBox="true" DisplayMode="BulletList"
                    ShowSummary="false" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server" ID="upnljoint">
    <ContentTemplate>
        <asp:Panel ID="pnlJointAccount" runat="server">
            <table>
                <tr>
                    <td colspan="2" class="ContentTitle">
                        <asp:Label ID="lblJointAccount" runat="server" Text='<%$Resources:ExpressCMS,lblJointAccount %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointAccountHolder" runat="server" Text='<%$Resources:ExpressCMS,lblJointAccountHolder  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointAccountHolder" runat="server" MaxLength="50"
                            ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointAccountHolder" runat="server"
                            ControlToValidate="txtJointAccountHolder" ValidationGroup="vaJoint" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblJointAccountHolder %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointAuthorizedmanageccount" runat="server" Text='<%$Resources:ExpressCMS,lblJointAuthorizedmanageccount  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointAuthorizedmanageaccount" runat="server" MaxLength="50"
                            ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointauthorizedmanageaccount"
                            runat="server" ControlToValidate="txtJointAuthorizedmanageaccount" ValidationGroup="vaJoint"
                            Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointAuthorizedmanageccount %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointNationality" runat="server" Text='<%$Resources:ExpressCMS,lblJointNationality  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointNationality" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator11" runat="server"
                            ControlToValidate="txtJointNationality" ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointNationality %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointPassportNumber" runat="server" Text='<%$Resources:ExpressCMS,lblJointPassportNumber  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointPassportNumber" runat="server" MaxLength="50"
                            ValidationGroup="vaProxyTrustee"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator9" runat="server"
                            ControlToValidate="txtJointPassportNumber" ValidationGroup="vaJoint" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblJointPassportNumber %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointDate" runat="server" Text='<%$Resources:ExpressCMS,lblJointDate %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="rdJointDate" runat="server" Width="140px" AutoPostBack="false"
                            DateInput-EmptyMessage="Pick a Date" DateInput-DateFormat="dd/MM/yyyy" MinDate="01/01/1990"
                            MaxDate="01/01/3000">
                            <Calendar>
                                <SpecialDays>
                                    <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday" />
                                </SpecialDays>
                            </Calendar>
                        </telerik:RadDatePicker>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointDate" runat="server" ControlToValidate="rdJointDate"
                            ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointDate %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointPhone" runat="server" Text='<%$Resources:ExpressCMS,lblJointPhone  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointDate" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator13" runat="server"
                            ControlToValidate="txtJointDate" ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointPhone %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointMobile" runat="server" Text='<%$Resources:ExpressCMS,lblJointMobile  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointMobile" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointMobile" runat="server" ControlToValidate="txtJointMobile"
                            ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrMobile %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblRepresentedBy" runat="server" Text='<%$Resources:ExpressCMS,lblRepresentedBy  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointRepresentedby" runat="server" MaxLength="50"
                            ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointrepresentedBy" runat="server"
                            ControlToValidate="txtJointRepresentedby" ValidationGroup="vaJoint" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblRepresentedBy %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointworksAdd" runat="server" Text='<%$Resources:ExpressCMS,lblJointworksAdd %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointWorksAtt" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <%--  <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtJointWorksAtt"
                            ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointworksAdd %>'></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointProffession" runat="server" Text='<%$Resources:ExpressCMS,lblJointProffession %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointProffession" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointProffession" runat="server"
                            ControlToValidate="txtJointProffession" ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointProffession %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointAddress" runat="server" Text='<%$Resources:ExpressCMS,lblJointAddress %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointaddress" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointaddress" runat="server"
                            ControlToValidate="txtJointaddress" ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointAddress %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointEmploymentNumber" runat="server" Text='<%$Resources:ExpressCMS,lblJointEmploymentNumber %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointEmploymentNumber" runat="server" MaxLength="50"
                            ValidationGroup="vaJoint"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator Display="Static" ID="rfvJointEmploymentNumber" runat="server" ControlToValidate="txtJointEmploymentNumber"
                            ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointEmploymentNumber %>'></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointResidencePlace" runat="server" Text='<%$Resources:ExpressCMS,lblJointResidencePlace %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointResidencePlace" runat="server" MaxLength="50"
                            ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointResidenceAddress" runat="server"
                            ControlToValidate="txtJointResidencePlace" ValidationGroup="vaJoint" Text="*"
                            ErrorMessage='<%$Resources:ExpressCMS,lblJointResidencePlace %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointPOBox" runat="server" Text='<%$Resources:ExpressCMS,lblJointPOBox %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointPoBox" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator22" runat="server"
                            ControlToValidate="txtJointPoBox" ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblJointPOBox %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblJointEmail" runat="server" Text='<%$Resources:ExpressCMS,lblPrEmail %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtJointEmail" runat="server" MaxLength="50" ValidationGroup="vaJoint"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvJointemail" runat="server" ControlToValidate="txtJointEmail"
                            ValidationGroup="vaJoint" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblPrEmail %>'></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regJointEmail" runat="server" ControlToValidate="txtJointEmail"
                            ValidationGroup="txtPrEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ErrorMessage='<%$Resources:ExpressCMS,validEmail %>'>*</asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <div class="actions">
                <div class="btnNext">
                    <asp:Button ID="btnJointNext" runat="server" CausesValidation="true" ValidationGroup="vaJoint"
                        CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
                </div>
                <div class="btnBack">
                    <asp:Button ID="Button4" runat="server" CausesValidation="false" CssClass="btn" Text='<%$Resources:ExpressCMS,btnback %>' />
                </div>
                <asp:ValidationSummary ID="valJoint" runat="server" ValidationGroup="vaJoint" HeaderText='<%$Resources:ExpressCMS,valSummHeader %>'
                    ShowMessageBox="true" DisplayMode="BulletList" ShowSummary="false" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server" ID="upnlrelAccount">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlelAccount">
            <table>
                <tr>
                    <td colspan="2" class="ContentTitle">
                        <asp:Label ID="lblreAccount" runat="server" Text='<%$Resources:ExpressCMS,lblreAccount %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPleaseCheckBelow" runat="server" Text='<%$Resources:ExpressCMS,lblPleaseCheckBelow  %>'></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBoxList runat="server">
                            <asp:ListItem Text='<%$Resources:ExpressCMS,adsm %>' Value="1"></asp:ListItem>
                            <asp:ListItem Text='<%$Resources:ExpressCMS,dfm %>' Value="2"></asp:ListItem>
                            <asp:ListItem Text='<%$Resources:ExpressCMS,osc %>' Value="3"></asp:ListItem>
                            <asp:ListItem Text='<%$Resources:ExpressCMS,bc %>' Value="4"></asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAccountOwnerName" runat="server" Text='<%$Resources:ExpressCMS,lblAccountOwnerName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtAccountOwnerName" runat="server" MaxLength="50" ValidationGroup="vaRela"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="rfvAccountOwnerName" runat="server"
                            ControlToValidate="txtAccountOwnerName" ValidationGroup="vaRela" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblAccountOwnerName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblComapnyOwnerName" runat="server" Text='<%$Resources:ExpressCMS,lblComapnyOwnerName %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtCompanyOwenrName" runat="server" MaxLength="50" ValidationGroup="vaRela"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator10" runat="server"
                            ControlToValidate="txtCompanyOwenrName" ValidationGroup="vaRela" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblComapnyOwnerName %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCapacity" runat="server" Text='<%$Resources:ExpressCMS,lblCapacity %>'></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox Width="250" ID="txtRelCapacity" runat="server" MaxLength="50" ValidationGroup="vaRela"></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Static" ID="RequiredFieldValidator12" runat="server"
                            ControlToValidate="txtRelCapacity" ValidationGroup="vaRela" Text="*" ErrorMessage='<%$Resources:ExpressCMS,lblCapacity %>'></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div class="actions">
                <div class="btnNext">
                    <asp:Button ID="btnNextRelatives" runat="server" CausesValidation="true" ValidationGroup="vaRela"
                        CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
                </div>
                <div class="btnBack">
                    <asp:Button ID="btnback5" runat="server" CausesValidation="false" CssClass="btn"
                        Text='<%$Resources:ExpressCMS,btnback %>' />
                </div>
                <asp:ValidationSummary ID="valRelative" runat="server" ValidationGroup="vaJoint"
                    HeaderText='<%$Resources:ExpressCMS,valSummHeader %>' ShowMessageBox="true" DisplayMode="BulletList"
                    ShowSummary="false" />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server" ID="UpdatePanel1">
    <ContentTemplate>
        <asp:Panel ID="pnlStep6" runat="server">
            <div id="Div4" class="ContentTitle" runat="server">
                <asp:Label ID="lblUploadControl" runat="server" Text='<%$Resources:ExpressCMS,lblUploadControl %>'></asp:Label>
            </div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblAccountOpeningForm" runat="server" Text='<%$Resources:ExpressCMS,lblAccountOpeningForm %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload ControlObjectsVisibility="None" runat="server" MaxFileInputsCount="1"
                            InitialFileInputsCount="1" AllowedFileExtensions="{.doc,.docx,.pdf}" MaxFileSize="200000000"
                            TargetPhysicalFolder="~/Upload/Files/" ID="rtAccountOpeningForm">
                        </telerik:RadUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassport" runat="server" Text='<%$Resources:ExpressCMS,lblPassport %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload ID="rtUploadPassport" ControlObjectsVisibility="None" runat="server"
                            MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                            MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                        </telerik:RadUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblIdentity" runat="server" Text='<%$Resources:ExpressCMS,lblIdentity %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload ID="rtIdentity" ControlObjectsVisibility="None" runat="server"
                            MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                            MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                        </telerik:RadUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFamilyBook" runat="server" Text='<%$Resources:ExpressCMS,lblFamilyBook %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload ID="rtFamilyBook" ControlObjectsVisibility="None" runat="server"
                            MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                            MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                        </telerik:RadUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPowerofAttornary" runat="server" Text='<%$Resources:ExpressCMS,lblPowerofAttornary %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload ID="rtPowerofAttornary" ControlObjectsVisibility="None" runat="server"
                            MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                            MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                        </telerik:RadUpload>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAllPapers" runat="server" Text='<%$Resources:ExpressCMS,lblAllPapers %>'></asp:Label>
                    </td>
                    <td>
                        <telerik:RadUpload ID="rtAllPapers" ControlObjectsVisibility="None" runat="server"
                            MaxFileInputsCount="1" InitialFileInputsCount="1" AllowedFileExtensions="{.jpg,.jpeg,.pmp,.tiff,.bmp}"
                            MaxFileSize="200000000" TargetPhysicalFolder="~/Upload/Files/">
                        </telerik:RadUpload>
                    </td>
                </tr>
            </table>
            <br />
            <div class="actions">
                <div class="btnNext">
                    <asp:Button ID="btnNext6" runat="server" CausesValidation="true" ValidationGroup="Step5"
                        CssClass="btn" Text='<%$Resources:ExpressCMS,btnNext %>' />
                </div>
                <div class="btnBack">
                    <asp:Button ID="btnbacktolst" runat="server" CausesValidation="false" CssClass="btn back"
                        Text='<%$Resources:ExpressCMS,btnback %>' />
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel runat="server" ID="upnlFinal">
    <ContentTemplate>
        <asp:Panel runat="server" ID="pnlFinal">
            <uc1:HtmlViewer_UC ID="HtmlViewer_UC1" runat="server" HashName="Agreement" />
            <asp:CheckBox ID="checkIAgree" runat="server" AutoPostBack="true" Text='<%$Resources:ExpressCMS,IAgree %>' />
            <div class="actions">
                <asp:Button ID="btnFinish" runat="server" CausesValidation="true" CssClass="btn"
                    Text='<%$Resources:ExpressCMS,btnFinish %>' />
                <asp:Button ID="btnbackfromfinal" runat="server" CausesValidation="false" CssClass="btn back"
                    Text='<%$Resources:ExpressCMS,btnback %>' />
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
