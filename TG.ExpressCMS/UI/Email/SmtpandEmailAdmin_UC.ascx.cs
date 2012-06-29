using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Net;
using TG.ExpressCMS.Utilities;
using TG.ExpressCMS.Configuration;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.UI.Email
{
    public partial class SmtpandEmailAdmin_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(SmtpandEmailAdmin_UC_Load);
            this.btnSaveUpdate.Click += new EventHandler(btnSaveUpdate_Click);
            this.btnDNS.Click += new EventHandler(btnDNS_Click);
        }

        void btnDNS_Click(object sender, EventArgs e)
        {
            IPAddress[] Addresses = Dns.GetHostAddresses(txtHost.Text);
            if (null != Addresses && Addresses.Count() > 0)
            {
                txtHost.Text = Addresses[0].ToString();
                dvMessage.InnerText = "Resolved Successfully";
            }
        }

        void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            ClearFileData();
            SaveSmtpFile();
            if (chkUseCredential.Checked)
            {
                trCredential1.Style.Add(HtmlTextWriterStyle.Display, "block");
                trCredential2.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                trCredential1.Style.Add(HtmlTextWriterStyle.Display, "none");
                trCredential2.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        void SmtpandEmailAdmin_UC_Load(object sender, EventArgs e)
        {
            dvMessage.InnerText = "";
            if (!IsPostBack)
            {
                LoadSmtpSettingsFile();
                PerformSettings();
            }

        }

        private void LoadSmtpSettingsFile()
        {
            EmailSetting _emailSetting = EmailContext.LoadSmtpSettingsFile();
            if (_emailSetting == null)
                return;

            try
            {
                txtHost.Text = _emailSetting.Host;
                txtPort.Text = _emailSetting.Port.ToString();
                txtSenderEmail.Text = _emailSetting.SernderAddress;
                txtSenderName.Text = _emailSetting.SenderName;
                if (!_emailSetting.EnableSSL)
                {
                    chkEnableSSL.Checked = false;
                }
                else
                    chkEnableSSL.Checked = true;
                if (_emailSetting.UseCredential)
                {
                    trCredential1.Style.Add(HtmlTextWriterStyle.Display, "block");
                    trCredential2.Style.Add(HtmlTextWriterStyle.Display, "block");
                    chkUseCredential.Checked = true;
                    txtPassowrd.Text = _emailSetting.Password;
                    txtUserName.Text = _emailSetting.Username;
                }
                else
                {
                    trCredential1.Style.Add(HtmlTextWriterStyle.Display, "none");
                    trCredential2.Style.Add(HtmlTextWriterStyle.Display, "none");
                    chkUseCredential.Checked = false;
                    txtUserName.Text = "";
                    txtPassowrd.Text = "";
                }
            }
            catch (Exception ex)
            {
                dvMessage.InnerText = ex.ToString();
            }
        }
        private void SaveSmtpFile()
        {
            XmlDocument xDoc = new XmlDocument();
            try
            {
                XmlElement xRoot = xDoc.CreateElement("Settings");
                XmlElement xElement = xDoc.CreateElement("Setting");
                XmlAttribute xAttHost = xDoc.CreateAttribute("Host");
                XmlAttribute xAttPort = xDoc.CreateAttribute("Port");
                XmlAttribute xAttSenderName = xDoc.CreateAttribute("SenderName");
                XmlAttribute xAttSenderEmail = xDoc.CreateAttribute("SenderEmail");
                XmlAttribute xAttEnableSSL = xDoc.CreateAttribute("EnableSSL");
                XmlAttribute xAttUsername = xDoc.CreateAttribute("Username");
                XmlAttribute xAttPassword = xDoc.CreateAttribute("Password");
                XmlAttribute xAttUseCredential = xDoc.CreateAttribute("UseCredential");



                xAttHost.Value = txtHost.Text;
                xAttPort.Value = txtPort.Text;
                xAttSenderEmail.Value = txtSenderEmail.Text;
                xAttSenderName.Value = txtSenderName.Text;
                xAttEnableSSL.Value = chkEnableSSL.Checked.ToString();
                xAttUsername.Value = txtUserName.Text;
                
                if (txtPassowrd.Text != string.Empty)
                    xAttPassword.Value = EncryptionContext.Encrypt(txtPassowrd.Text);
                else
                    xAttPassword.Value = "";

                xAttUseCredential.Value = chkUseCredential.Checked.ToString();

                xElement.Attributes.Append(xAttHost);
                xElement.Attributes.Append(xAttPort);
                xElement.Attributes.Append(xAttSenderEmail);
                xElement.Attributes.Append(xAttSenderName);
                xElement.Attributes.Append(xAttEnableSSL);
                xElement.Attributes.Append(xAttUseCredential);
                xElement.Attributes.Append(xAttPassword);
                xElement.Attributes.Append(xAttUsername);

                xDoc.AppendChild(xRoot);
                xRoot.AppendChild(xElement);
                xDoc.Save(Server.MapPath("~/Settings/SmtpEmailSettings.xml"));
                Session["ccc"] = xDoc;
                EmailContext.ClearSmtpCache();
                dvMessage.InnerText = "Settings saved successfully";
            }
            catch (Exception ex)
            {
                dvMessage.InnerText = ex.ToString();
            }
            finally
            {
                //
            }

        }
        private void ClearFileData()
        {
            try
            {

                using (StreamReader _reader = new StreamReader(Server.MapPath("~/Settings/SmtpEmailSettings.xml")))
                {
                    string _data = _reader.ReadToEnd();
                    _reader.Close();
                    if (_data.Length > 0)
                    {
                        _data = "";
                        using (StreamWriter _writer = new StreamWriter(Server.MapPath("~/Settings/SmtpEmailSettings.xml")))
                        {
                            _writer.Write(_data);
                            _writer.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dvMessage.InnerText = ex.ToString();
            }
        }
        private void PerformSettings()
        {
            //   dvMessage.Style.Add(HtmlTextWriterStyle.Display, "none");
            btnDNS.Attributes.Add("onclick", "HideMessage(2000);return true;");
            btnSaveUpdate.Attributes.Add("onclick", "HideMessage(3000);return true;");
        }
    }
}