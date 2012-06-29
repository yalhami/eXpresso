using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Enums;
using TG.ExpressCMS.UI.Custums.AlRamz;

namespace TG.ExpressCMS.UI.Custums
{
    public partial class AlramzUserRegistration_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(AlramzUserRegistration_UC_Load);
            this.btnStart.Click += new EventHandler(btnStart_Click);
            this.btnNextRelatives.Click += new EventHandler(btnNextRelatives_Click);
            this.btnNextProxee.Click += new EventHandler(btnNextProxee_Click);
            this.btnNextCompany.Click += new EventHandler(btnNextCompany_Click);
            this.btnJointNext.Click += new EventHandler(btnJointNext_Click);
            this.btnIdividual.Click += new EventHandler(btnIdividual_Click);
            this.btnFinish.Click += new EventHandler(btnFinish_Click);
            this.btnNext6.Click += new EventHandler(btnNext6_Click);
            checkIAgree.CheckedChanged += new EventHandler(checkIAgree_CheckedChanged);
            btnbacktoinital.Click += new EventHandler(btnbacktoinital_Click);
            btnBack2.Click += new EventHandler(btnBack2_Click);
            btnback3.Click += new EventHandler(btnback3_Click);
            Button4.Click += new EventHandler(Button4_Click);
            btnback5.Click += new EventHandler(btnback5_Click);
            btnbacktolst.Click += new EventHandler(btnbacktolst_Click);
            btnbackfromfinal.Click += new EventHandler(btnbackfromfinal_Click);
        }

        void Button4_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;
        }

        void btnbacktolst_Click(object sender, EventArgs e)
        {
            HideAll();

            int value = 0;
            Int32.TryParse(ViewState["Temp"].ToString(), out value);
            HideAll();
            //ViewState["Temp"] = value;
            switch (value)
            {
                case (int)RootEnums.AccountType.Companies:
                    pnlCompanies.Visible = true;
                    break;
                case (int)RootEnums.AccountType.EmployeeHavingRelation:
                    pnlelAccount.Visible = true;
                    break;
                case (int)RootEnums.AccountType.Individuals:
                    pnlIndividuals.Visible = true;
                    break;
                case (int)RootEnums.AccountType.JointAccount:
                    pnlJointAccount.Visible = true;
                    break;
                case (int)RootEnums.AccountType.ProxyTrustee:
                    pnlProxyTrustee.Visible = true;
                    break;
                default:
                    break;
            }
        }

        void btnbackfromfinal_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;
        }

        void btnback5_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlFirst.Visible = true;
        }

        void btnback3_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlFirst.Visible = true;
        }

        void btnBack2_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlFirst.Visible = true;
        }

        void btnbacktoinital_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlFirst.Visible = true;
        }

        void checkIAgree_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIAgree.Checked)
            {
                btnFinish.Enabled = true;
            }
            else
                btnFinish.Enabled = false;
        }

        void btnNext6_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlFinal.Visible = true;
        }

        void btnFinish_Click(object sender, EventArgs e)
        {
            HideAll();

            eXMNouhEntities adapter = new eXMNouhEntities();

            AlramzRegistration _registrar = new AlramzRegistration();

            int type = 0;
            Int32.TryParse(ViewState["Temp"].ToString(), out type);
            switch (type)
            {
                case (int)RootEnums.AccountType.Companies:
                    _registrar.MrsMr_1 = txtFullName.Text;
                    _registrar.NumberOnAbudhabi_1 = txtUserNumberinABD.Text;
                    _registrar.NumberOnDubai_1 = txtNumberInDubail.Text;
                    _registrar.AccountType_1 = ddlAccountType.SelectedValue;
                    _registrar.Companies_TradeName = txtcomTradeName.Text;
                    _registrar.Companies_LegalForm = txtcomLegalForm.Text;
                    _registrar.Companies_Nationality = txtCompanyNationality.Text;
                    _registrar.Companies_Type = txtcomTypeBranch.Text;
                    _registrar.Companies_RoomNumber = txtADCCMemberNumber.Text;
                    _registrar.Companies_RoomNumber_IssueDate = rtDateOfIssue.SelectedDate.Value.ToShortDateString();
                    _registrar.Companies_RoomNumber_ExpiryDate = rdDateofExpiry.SelectedDate.Value.ToShortDateString();
                    _registrar.Companies_TradeLicenseNumber = txtcomTradeNumber.Text;
                    _registrar.Companies_TradeLicenseNumber_IssueDate = rdDateIssueTrade.SelectedDate.Value.ToShortDateString();
                    _registrar.Companies_TradeLicenseNumber_ExpiryDate = rdTradeExpiryDate.SelectedDate.Value.ToShortDateString();
                    _registrar.Companies_Phone = txtCompanyPhone.Text;
                    _registrar.Companies_Fax = txtComFax.Text;
                    _registrar.Companies_POBOX = txtComPOBox.Text;
                    _registrar.Companies_Address = txtComAddress.Text;
                    _registrar.Companies_Email = txtComEmail.Text;
                    _registrar.Companies_SignatureAuthority = txtComSignAuthorities.Text;
                    _registrar.Companies_SignatureAuthority_Nationality = txtCompanyNationality.Text;
                    _registrar.Companies_SignatureAuthority_passportNumber = txtComPassport.Text;

                    _registrar.Companies_SignatureAuthority_Birthdate = rdComBDate.SelectedDate.Value.ToShortDateString();
                    _registrar.Companies_SignatureAuthority_phone = txtComPhone1.Text;
                    _registrar.Companies_SignatureAuthority_fax = txtComFax1.Text;
                    _registrar.Companies_SignatureAuthority_PoBox = txtComPOBox1.Text;
                    _registrar.Companies_SignatureAuthority_Address = txtComAddress1.Text;

                    _registrar.Upload_AccountApp = UtilitiesManager.GetSavedFile(FileUpload5, true);
                    _registrar.Upload_passportnumber = UtilitiesManager.GetSavedFile(FileUpload4, true);
                    _registrar.Upload_Summary = UtilitiesManager.GetSavedFile(FileUpload2, true);
                    _registrar.Upload_wakaleh = UtilitiesManager.GetSavedFile(FileUpload1, true);
                    _registrar.Upload_all = UtilitiesManager.GetSavedFile(rtAllPapers, true);
                    _registrar.Upload_Identity = UtilitiesManager.GetSavedFile(FileUpload3, true);

                    break;
                case (int)RootEnums.AccountType.EmployeeHavingRelation:
                    _registrar.MrsMr_1 = txtFullName.Text;
                    _registrar.NumberOnAbudhabi_1 = txtUserNumberinABD.Text;
                    _registrar.NumberOnDubai_1 = txtNumberInDubail.Text;
                    _registrar.AccountType_1 = ddlAccountType.SelectedValue;

                    _registrar.RelatedEmp_CompanyOwner = txtCompanyOwenrName.Text;
                    _registrar.RelatedEmp_description = txtRelCapacity.Text;
                    _registrar.RelatedEmp_OwnerAccount = txtAccountOwnerName.Text;
                    int type2 = 0;
                    try
                    {
                        Int32.TryParse(chkHowUcome.SelectedValue, out type2);
                        _registrar.RelatedEmp_Type = type2;
                    }
                    catch 
                    {
                        
                    }
                    

                    _registrar.Upload_AccountApp = UtilitiesManager.GetSavedFile(FileUpload5, true);
                    _registrar.Upload_passportnumber = UtilitiesManager.GetSavedFile(FileUpload4, true);
                    _registrar.Upload_Summary = UtilitiesManager.GetSavedFile(FileUpload2, true);
                    _registrar.Upload_wakaleh = UtilitiesManager.GetSavedFile(FileUpload1, true);
                    _registrar.Upload_all = UtilitiesManager.GetSavedFile(rtAllPapers, true);
                    _registrar.Upload_Identity = UtilitiesManager.GetSavedFile(FileUpload3, true);
                    break;
                case (int)RootEnums.AccountType.Individuals:
                    _registrar.MrsMr_1 = txtFullName.Text;
                    _registrar.NumberOnAbudhabi_1 = txtUserNumberinABD.Text;
                    _registrar.NumberOnDubai_1 = txtNumberInDubail.Text;
                    _registrar.AccountType_1 = ddlAccountType.SelectedValue;

                    _registrar.Individual_Nationality = txtNationality.Text;
                    _registrar.Individual_Passportnumber = txtPassportNumber.Text;
                    _registrar.Individual_Birthdate = dtbDate.SelectedDate.Value.ToShortDateString();
                    _registrar.Individual_Phone = txtPhone.Text;
                    _registrar.Individual_Mobile = txtMobile.Text;
                    _registrar.Individual_POBox = txtPOBox.Text;
                    _registrar.Individual_Email = txtEmail.Text;
                    _registrar.Individual_WorkSite = txtWorkWith.Text;
                    _registrar.Individual_Proffession = txtProfession.Text;
                    _registrar.Individual_WorkAddress = txtWorksAdd.Text;
                    _registrar.Individual_employmentNumber = txtEmploymentNumber.Text;
                    _registrar.Individual_ResidencePlace = txtResidencePlace.Text;


                    _registrar.Upload_AccountApp = UtilitiesManager.GetSavedFile(FileUpload5, true);
                    _registrar.Upload_passportnumber = UtilitiesManager.GetSavedFile(FileUpload4, true);
                    _registrar.Upload_Summary = UtilitiesManager.GetSavedFile(FileUpload2, true);
                    _registrar.Upload_wakaleh = UtilitiesManager.GetSavedFile(FileUpload1, true);
                    _registrar.Upload_all = UtilitiesManager.GetSavedFile(rtAllPapers, true);
                    _registrar.Upload_Identity = UtilitiesManager.GetSavedFile(FileUpload3, true);

                    break;
                case (int)RootEnums.AccountType.JointAccount:
                    _registrar.MrsMr_1 = txtFullName.Text;
                    _registrar.NumberOnAbudhabi_1 = txtUserNumberinABD.Text;
                    _registrar.NumberOnDubai_1 = txtNumberInDubail.Text;
                    _registrar.AccountType_1 = ddlAccountType.SelectedValue;


                    _registrar.Mushtarakah_AccountOwner = txtAccountOwnerName.Text;
                    _registrar.Mushtarakah_AuthorityOwner = txtJointAuthorizedmanageaccount.Text;
                    _registrar.Mushtarakah_Nationality = txtJointNationality.Text;
                    _registrar.Mushtarakah_PassportNumber = txtJointPassportNumber.Text;
                    _registrar.Mushtarakah_BDate = rdJointDate.SelectedDate.Value.ToShortDateString();
                    _registrar.Mushtarakah_Phone = txtJointDate.Text;
                    _registrar.Mushtarakah_Mobile = txtJointMobile.Text;
                    _registrar.Mushtarakah_yomathleh = txtJointRepresentedby.Text;
                    _registrar.Mushtarakah_WorkAddress = txtJointWorksAtt.Text;
                    _registrar.Mushtarakah_Proffession = txtJointProffession.Text;
                    _registrar.Mushtarakah_Address = txtJointaddress.Text;
                    _registrar.Mushtarakah_EmploymentNumber = txtJointEmploymentNumber.Text;
                    _registrar.Mushtarakah_ResidencyPlace = txtJointResidencePlace.Text;
                    _registrar.Mushtarakah_POBox = txtJointPoBox.Text;
                    _registrar.Mushtarakah_Email = txtJointEmail.Text;





                    _registrar.Upload_AccountApp = UtilitiesManager.GetSavedFile(FileUpload5, true);
                    _registrar.Upload_passportnumber = UtilitiesManager.GetSavedFile(FileUpload4, true);
                    _registrar.Upload_Summary = UtilitiesManager.GetSavedFile(FileUpload2, true);
                    _registrar.Upload_wakaleh = UtilitiesManager.GetSavedFile(FileUpload1, true);
                    _registrar.Upload_all = UtilitiesManager.GetSavedFile(rtAllPapers, true);
                    _registrar.Upload_Identity = UtilitiesManager.GetSavedFile(FileUpload3, true);
                    break;
                case (int)RootEnums.AccountType.ProxyTrustee:
                    _registrar.MrsMr_1 = txtFullName.Text;
                    _registrar.NumberOnAbudhabi_1 = txtUserNumberinABD.Text;
                    _registrar.NumberOnDubai_1 = txtNumberInDubail.Text;
                    _registrar.AccountType_1 = ddlAccountType.SelectedValue;

                    _registrar.Wakaleh_Name = txtProxyName.Text;
                    _registrar.Wakaleh_Nationality = txtProxeeTrustee.Text;
                    _registrar.Wakaleh_Passport = txtPrPassportNumber.Text;
                    _registrar.Wakaleh_BDate = dtProd.SelectedDate.Value.ToShortDateString();
                    _registrar.Wakaleh_Phone = txtPrPhone.Text;
                    _registrar.Wakaleh_Mobile = txtPrMobile.Text;
                    _registrar.Wakaleh_WorkSite = txtPrWorksAt.Text;
                    _registrar.Wakaleh_Proffession = txtPrProfession.Text;
                    _registrar.Wakaleh_Address = txtPrAddress.Text;
                    _registrar.Wakaleh_IdentityNumber = txtPrEmploymentNumber.Text;
                    _registrar.Wakaleh_POBox = txtPrBoPox.Text;
                    _registrar.Wakaleh_Email = txtPrEmail.Text;
                    _registrar.Wakaleh_NO = txtProxynumber.Text;
                    _registrar.Wakaleh_IssueDate = rdIssueDate.SelectedDate.Value.ToShortDateString();
                    _registrar.Wakaleh_IssuePlace = txtPrPlaceAddress.Text;


                    _registrar.Upload_AccountApp = UtilitiesManager.GetSavedFile(FileUpload5, true);
                    _registrar.Upload_passportnumber = UtilitiesManager.GetSavedFile(FileUpload4, true);
                    _registrar.Upload_Summary = UtilitiesManager.GetSavedFile(FileUpload2, true);
                    _registrar.Upload_wakaleh = UtilitiesManager.GetSavedFile(FileUpload1, true);
                    _registrar.Upload_all = UtilitiesManager.GetSavedFile(rtAllPapers, true);
                    _registrar.Upload_Identity = UtilitiesManager.GetSavedFile(FileUpload3, true);
                    break;
                default:
                    break;
            }

            adapter.AddObject("AlramzRegistration", _registrar);
            adapter.SaveChanges();

            pnlFinal.Visible = false;
            dvmessages.InnerText = Resources.ExpressCMS.ThanksyourApplicationsRecivedandwill;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString().Substring(0, 6), "alert('" + Resources.ExpressCMS.ThanksyourApplicationsRecivedandwill + "');", true);
        }

        void btnIdividual_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;

        }

        void btnJointNext_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;
        }

        void btnNextCompany_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;
        }

        void btnNextProxee_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;
        }

        void btnNextRelatives_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;
        }

        void btnNext_Click(object sender, EventArgs e)
        {
            HideAll();
            pnlStep6.Visible = true;
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            int value = 0;
            Int32.TryParse(ddlAccountType.SelectedValue, out value);
            HideAll();
            ViewState["Temp"] = value;
            switch (value)
            {
                case (int)RootEnums.AccountType.Companies:
                    pnlCompanies.Visible = true;
                    break;
                case (int)RootEnums.AccountType.EmployeeHavingRelation:
                    pnlelAccount.Visible = true;
                    break;
                case (int)RootEnums.AccountType.Individuals:
                    pnlIndividuals.Visible = true;
                    break;
                case (int)RootEnums.AccountType.JointAccount:
                    pnlJointAccount.Visible = true;
                    break;
                case (int)RootEnums.AccountType.ProxyTrustee:
                    pnlProxyTrustee.Visible = true;
                    break;
                default:
                    break;
            }
        }


        void AlramzUserRegistration_UC_Load(object sender, EventArgs e)
        {
            dvmessages.InnerText = "";
            if (!IsPostBack)
            {
                btnFinish.Enabled = false;
                FillDDl();
                PerformSettings();
                HideAll();
                pnlFirst.Visible = true;
            }
        }
        private void FillDDl()
        {
            ddlAccountType.DataSource = UtilitiesManager.GetEnumDataSource(Resources.ExpressCMS.ResourceManager, typeof(RootEnums.AccountType));
            ddlAccountType.DataTextField = "Key";
            ddlAccountType.DataValueField = "Value";
            ddlAccountType.DataBind();

            ddlAccountType.Items.Insert(0, new ListItem());
        }
        private void PerformSettings()
        {
            //    wzard.Visible = false;
        }
        private void HideAll()
        {
            btnFinish.Enabled = false;
            pnlCompanies.Visible = false;
            pnlelAccount.Visible = false;
            pnlFirst.Visible = false;
            pnlIndividuals.Visible = false;
            pnlJointAccount.Visible = false;
            pnlProxyTrustee.Visible = false;
            pnlFinal.Visible = false;
            // pnlStep6.Visible = false;
            pnlStep6.Visible = false;
        }
    }
}