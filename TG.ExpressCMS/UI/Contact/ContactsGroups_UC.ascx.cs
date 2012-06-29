using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;

namespace TG.ExpressCMS.UI.Contact
{
    public partial class ContactsGroups_UC : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(ContactsGroups_UC_Load);
            this.btnIn.Click += new EventHandler(btnIn_Click);
            this.btnOut.Click += new EventHandler(btnOut_Click);
            this.ddlGroups.SelectedIndexChanged += new EventHandler(ddlGroups_SelectedIndexChanged);
        }

        void ddlGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGroups.SelectedValue == string.Empty)
            {
                lstGroupContact.Items.Clear();
                return;
            }
            lstGroupContact.DataSource = FillContactsforGroup();
            lstGroupContact.DataTextField = "FullName";
            lstGroupContact.DataValueField = "ID";
            lstGroupContact.DataBind();
        }

        void btnOut_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lstGroupContact.Items.Count; i++)
            {
                if (lstGroupContact.Items[i].Selected)
                {
                    //Remove the items.
                    ContactManager.DeleteContactsFromGroups(Convert.ToInt32(lstGroupContact.Items[i].Value));
                }
            }
            lstGroupContact.Items.Clear();
            lstGroupContact.DataSource = FillContactsforGroup();
            lstGroupContact.DataTextField = "FullName";
            lstGroupContact.DataValueField = "ID";
            lstGroupContact.DataBind();
        }

        void btnIn_Click(object sender, EventArgs e)
        {
            if (ddlGroups.SelectedValue == string.Empty)
            {
                lstGroupContact.Items.Clear();
                return;
            }
            for (int i = 0; i < lstallContacts.Items.Count; i++)
            {
                if (lstallContacts.Items[i].Selected == true)
                {
                    lstGroupContact.Items.Add(lstallContacts.Items[i]);
                }
            }
            ContactManager.DeleteAllGroupContacts(Convert.ToInt32(ddlGroups.SelectedValue)); ;
            for (int i = 0; i < lstGroupContact.Items.Count; i++)
            {
                ContactManager.AssignContacttoGroup(Convert.ToInt32(lstGroupContact.Items[i].Value), Convert.ToInt32(ddlGroups.SelectedValue));
            }

        }

        void ContactsGroups_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAllContacts();
                FillGroupDDL();
            }
        }
        private void FillAllContacts()
        {
            lstallContacts.DataSource = ContactManager.GetAll();
            lstallContacts.DataTextField = "FullName";
            lstallContacts.DataValueField = "ID";
            lstallContacts.DataBind();

        }
        private IList<TG.ExpressCMS.DataLayer.Entities.Contact> FillContactsforGroup()
        {
            IList<TG.ExpressCMS.DataLayer.Entities.Contact> colContacts = new List<TG.ExpressCMS.DataLayer.Entities.Contact>();
            int selectedgroup = 0;
            Int32.TryParse(ddlGroups.SelectedValue, out selectedgroup);

            if (selectedgroup == 0)
                return colContacts;

            colContacts = ContactManager.GetByGroupID(selectedgroup);
            return colContacts;
        }
        private void FillGroupDDL()
        {
            ddlGroups.DataSource = GroupManager.GetAll();
            ddlGroups.DataTextField = "Name";
            ddlGroups.DataValueField = "ID";
            ddlGroups.DataBind();

            ddlGroups.Items.Insert(0, new ListItem());
        }
    }
}