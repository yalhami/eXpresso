using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TG.ExpressCMS.DataLayer.Data;
using System.Xml;
using System.IO;

namespace TG.ExpressCMS.UI.Menus
{
    public partial class MenuViewer_UC : System.Web.UI.UserControl
    {
        public Orientation Direction
        {
            set
            {
                ViewState["Direction"] = value;
            }
            get
            {
                if (ViewState["Direction"] == null)
                {
                    return Orientation.Horizontal;
                }
                else
                {
                    return (Orientation)Convert.ToInt32(ViewState["Direction"]);
                }
            }
        }
        public int CategoryID
        {
            set
            {
                ViewState["CategoryID"] = value;
            }
            get
            {
                if (ViewState["CategoryID"] == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(ViewState["CategoryID"].ToString());
                }
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Load += new EventHandler(MenuViewer_UC_Load);
        }

        void MenuViewer_UC_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GenerateXML();

        }
        private void GenerateXML()
        {
            string xml = GetXmlPublishMenuById(CategoryID, Server.MapPath("~/UserPages/GeneratedPages/MenuXML" + CategoryID + ".xml"));


            TreeSource.DataFile = "~/UserPages/GeneratedPages/MenuXML" + CategoryID + ".xml";
            TreeSource.DataBind();
            TreeSource.XPath = "Menus/Menu";

            mnuUserSide.Orientation = Direction;
            mnuUserSide.DataSource = TreeSource;
            mnuUserSide.DataBind();
        }


        #region Menu User Side

        public string GetXmlPublishMenuById(int MenuCategoryId, string FileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (File.Exists(FileName))
            {
                xmlDoc.Load(FileName);
                return xmlDoc.OuterXml;
            }
            IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> colParentMenus = MenuItemManager.GetAll().Where(t => t.CategoryId == MenuCategoryId).ToList();
            XmlElement eleMenu, eleParentMenu;
            XmlAttribute attMenu;

            eleMenu = xmlDoc.CreateElement("Menus");
            xmlDoc.AppendChild(eleMenu);

            IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> parentsMenu = (from pMenu in colParentMenus
                                                                            where pMenu.MenuID == 0
                                                                            select pMenu).ToList();
            foreach (TG.ExpressCMS.DataLayer.Entities.MenuItem parentMenu in parentsMenu)
            {
                eleParentMenu = xmlDoc.CreateElement("Menu");

                attMenu = xmlDoc.CreateAttribute("text");
                attMenu.Value = parentMenu.Name;
                eleParentMenu.Attributes.Append(attMenu);

                attMenu = xmlDoc.CreateAttribute("ID");
                attMenu.Value = parentMenu.ID.ToString();
                eleParentMenu.Attributes.Append(attMenu);


                attMenu = xmlDoc.CreateAttribute("url");
                attMenu.Value = parentMenu.Url;
                eleParentMenu.Attributes.Append(attMenu);

                GetSubMenu(xmlDoc, eleParentMenu, parentMenu.ID, colParentMenus);

                eleMenu.AppendChild(eleParentMenu);
            }

            XmlWriter xmlWriter = XmlWriter.Create(FileName);
            xmlDoc.WriteContentTo(xmlWriter);
            xmlWriter.Close();

            return xmlDoc.OuterXml;
        }

        private void GetSubMenu(XmlDocument xmlDoc, XmlElement eleParentMenu, int ParentMenuID, IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> Menus)
        {
            XmlElement eleSubMenu;
            XmlAttribute attMenu;

            IList<TG.ExpressCMS.DataLayer.Entities.MenuItem> subMenus = (from menu in Menus
                                                                         where menu.MenuID == ParentMenuID
                                                                         select menu).ToList();
            foreach (TG.ExpressCMS.DataLayer.Entities.MenuItem subMenu in subMenus)
            {
                eleSubMenu = xmlDoc.CreateElement("SubMenu");

                attMenu = xmlDoc.CreateAttribute("text");
                attMenu.Value = subMenu.Name;
                eleSubMenu.Attributes.Append(attMenu);

                attMenu = xmlDoc.CreateAttribute("ID");
                attMenu.Value = subMenu.ID.ToString();
                eleSubMenu.Attributes.Append(attMenu);



                attMenu = xmlDoc.CreateAttribute("url");
                attMenu.Value = subMenu.Url;
                eleSubMenu.Attributes.Append(attMenu);

                GetSubMenu(xmlDoc, eleSubMenu, subMenu.ID, Menus);
                eleParentMenu.AppendChild(eleSubMenu);
            }
        }
        #endregion

    }
}