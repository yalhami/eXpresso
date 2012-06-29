using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;
using TG.ExpressCMS.DataLayer.Data;
using TG.ExpressCMS.DataLayer.Enums;
using System.Xml;
namespace TG.ExpressCMS.DataLayer.Data
{
    public class DataMapperBase
    {
        #region Global
        public const string PN_PAGE_NUMBER = "@P_PAGE_NUMBER";
        public const string PN_PAGE_SIZE = "@P_PAGE_SIZE";
        #endregion

        public void PopulateCategory(SqlDataReader _dtr, Category obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_DESCRIPTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Description = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.CategoryType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_ATTRIBUTES);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Attributes = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_XSL_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.XslID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_image);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Image = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_LANGUAGE_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LanguageID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(CategoryDataMapper.CN_HASH);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Hash = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateVolunteer(SqlDataReader _dtr, Volunteer obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(VolunteerDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(VolunteerDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(VolunteerDataMapper.CN_EMAIL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Email = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(VolunteerDataMapper.CN_CV);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CV = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(VolunteerDataMapper.CN_MESSAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Message = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateNewsItem(SqlDataReader _dtr, NewsItem obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_DESCRIPTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Description = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.URlType = (TG.ExpressCMS.DataLayer.Enums.RootEnums.NewsItemURLType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_CATEGORYID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_URL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Url = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_IMAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Image = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_CREATIONDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreationDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_CREATEDBY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = Convert.ToInt32(_dtr.GetString((columnIndex)));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_CREATIONTIME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreationTime = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_PUBLISHFROM);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PublishFrom = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_PUBLISHTO);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PublishTo = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_ShowComments);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ShowComments = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_LANG_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LangID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_DATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Date = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_OrderNumber);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.OrderNumber = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.PN_REF_LANG_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.RefLangID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_VIEW_COUNT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ViewCount = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_IS_FEATURED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsFeatured = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_KEYWORDS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Keywords = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(NewsItemDataMapper.CN_GUID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Guid = _dtr.GetString((columnIndex));
            }

        }

        public void PopulateMenuItem(SqlDataReader _dtr, MenuItem obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_DESCRIPTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Description = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.MenuItemURLtype)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_CATEGORYID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryId = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_URL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Url = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_ORDERNUMBER);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.OrderNumber = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_MENUID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.MenuID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_IMAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Image = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_CREATIONDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreationDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_CREATEDBY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = Convert.ToInt32(_dtr.GetString((columnIndex)));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_CREATIONTIME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreationTime = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_PUBLISHFROM);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PublishFrom = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_PUBLISHTO);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PublishTo = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.CN_LANG_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LangID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.PN_REF_LANG);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.RefLangID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(MenuItemDataMapper.PN_IS_PUBLISHED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsPublished = _dtr.GetBoolean((columnIndex));
            }
        }

        public void PopulateXslTemplate(SqlDataReader _dtr, XslTemplate obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(XslTemplateDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(XslTemplateDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(XslTemplateDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(XslTemplateDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(XslTemplateDataMapper.CN_HASH);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Hash = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(XslTemplateDataMapper.CN_CATEGORYID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateHtmlItem(SqlDataReader _dtr, HtmlItem obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_HASH);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Hash = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_DATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Date = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = (RootEnums.HtmlBlockStatus)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (RootEnums.HtmlBlockType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(HtmlItemDataMapper.CN_LANGUAGE_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LanguageID = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateMarqueeItems(SqlDataReader _dtr, MarqueeItems obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_CATEGORYID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_URL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Url = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_URLTYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UrlType = (TG.ExpressCMS.DataLayer.Enums.RootEnums.MarqueeItemURLType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_TEXT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Text = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(MarqueeItemsDataMapper.CN_IMAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Image = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateUsers(SqlDataReader _dtr, Users obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(UsersDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(UsersDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(UsersDataMapper.CN_EMAIL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Email = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(UsersDataMapper.CN_PASSWORD);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Password = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(UsersDataMapper.CN_ISACTIVE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsActive = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(UsersDataMapper.CN_Type);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.UserType)_dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateInQuiry(SqlDataReader _dtr, InQuiry obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_DESCRIPTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Description = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_EMAIL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Email = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_PHONE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Phone = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_COUNTRY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Country = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = (TG.ExpressCMS.DataLayer.Enums.RootEnums.InQuiryStatus)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(InQuiryDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
        }

        public void PopulateGroup(SqlDataReader _dtr, Group obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(GroupDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GroupDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GroupDataMapper.CN_DESCRIPTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Description = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateContact(SqlDataReader _dtr, Contact obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_FIRSTNAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.FirstName = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_SURNAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.SurName = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_EMAIL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Email = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_MOBILE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Mobile = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_PHONE2);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Phone2 = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_ZIPCODE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ZipCode = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_GUID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Guid = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = (TG.ExpressCMS.DataLayer.Enums.RootEnums.ContactStatus)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_COUNTRY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Country = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_COMPANY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Company = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ContactDataMapper.CN_NOTES);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Notes = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateEmail(SqlDataReader _dtr, Email obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(EmailDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailDataMapper.CN_DATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Date = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.EmailType)_dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateEmailQueue(SqlDataReader _dtr, EmailQueue obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_RECIVERADDRESS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ReciverAddress = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_RECIEVERNAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.RecieverName = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_SENDERADDRESS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.SenderAddress = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_SENDERNAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.SenderName = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_CONTACTID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ContactID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_SCHEDULEDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ScheduleDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_SCHEDULETIME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ScheduleTime = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_SENDINGSTATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.SendingStatus = (TG.ExpressCMS.DataLayer.Enums.RootEnums.SendingStatus)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_SENTDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.SentDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_DELIVERYSTATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DeliveryStatus = (TG.ExpressCMS.DataLayer.Enums.RootEnums.DeliveryStatus)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_MAILID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.MailID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EmailQueueDataMapper.CN_SENT_BY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.SentBy = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateComment(SqlDataReader _dtr, Comment obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_SUBJECT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Subject = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_COMPANY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Company = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_EMAIL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Email = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_COUNTRY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Country = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_OBJECTID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ObjectID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_OBJECTTYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ObjectType = (RootEnums.ObjectType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (RootEnums.CommentType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = (TG.ExpressCMS.DataLayer.Enums.RootEnums.CommentStatus)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_INTIALVALUE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IntialValue = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_MODIFIEDVALUE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ModifiedValue = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CommentDataMapper.CN_IPADDRESS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IPAddress = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateRoles(SqlDataReader _dtr, Roles obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(RolesDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(RolesDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateCMSPage(SqlDataReader _dtr, CMSPage obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.CN_DESCRIPTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Description = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.CN_KEYWORD);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Keyword = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.CN_METTAGS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.MetTags = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.CN_TEMPLATENAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.TemplateName = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (TG.ExpressCMS.DataLayer.Enums.RootEnums.PageType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CMSPageDataMapper.PN_PAGE_CONTENT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PageContent = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateCareerPosts(SqlDataReader _dtr, CareerPosts obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_JOBID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.JobID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_DATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Date = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_EXPERIENCES);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Experiences = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_CVDOCUMENT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CVDocument = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_CVTEXT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CVText = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_IMAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Image = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_PHONE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Phone = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(CareerPostsDataMapper.CN_TITLE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Title = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateGallery(SqlDataReader _dtr, Gallery obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_DESCRIPTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Description = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_TAGS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Tags = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_DATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Date = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_URL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Url = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (RootEnums.GalleryType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_PATH);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Path = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_CREATEDBY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_ISARCHIEVED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsArchieved = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(GalleryDataMapper.CN_CATEGORYID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateBlocks(SqlDataReader _dtr, Blocks obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(BlocksDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BlocksDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BlocksDataMapper.CN_USECATEGORY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UseCategory = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BlocksDataMapper.CN_USEXSL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UseXSL = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BlocksDataMapper.CN_REGISTERTAG);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.RegisterTag = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BlocksDataMapper.CN_USEHTML);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UseHtml = _dtr.GetBoolean((columnIndex));
            }
        }

        public void PopulateSettings(SqlDataReader _dtr, Settings obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(SettingsDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SettingsDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SettingsDataMapper.CN_DEFAULTURL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DefaultUrl = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SettingsDataMapper.CN_DEFAULTLANGUAGECODE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DefaultLanguageCode = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SettingsDataMapper.CN_ISDEFAULT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDefault = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SettingsDataMapper.CN_PHYSICALPATH);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PhysicalPath = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SettingsDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
        }

        public void PopulatePoll(SqlDataReader _dtr, Poll obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(PollDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(PollDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(PollDataMapper.CN_DATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Date = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(PollDataMapper.CN_CREATEDBY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(PollDataMapper.CN_ISCLOSED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsClosed = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(PollDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
        }

        public void PopulatePollDetails(SqlDataReader _dtr, PollDetails obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(PollDetailsDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(PollDetailsDataMapper.CN_POLLID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PollID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(PollDetailsDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(PollDetailsDataMapper.CN_COUNT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Count = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateForumGroup(SqlDataReader _dtr, ForumGroup obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_CREATED_BY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetInt32((columnIndex));
            }

            #region GetDateTime
            int TotalDays = 0, TotalSeconds = 0;

            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_CREATION_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_CREATION_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.CreationDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);
            #endregion

            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_IS_DELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_ORDER_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.OrderID = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateForum(SqlDataReader _dtr, Forum obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_CREATED_BY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetInt32((columnIndex));
            }

            #region GetDateTime
            int TotalDays = 0, TotalSeconds = 0;

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_CREATION_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_CREATION_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.CreationDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);
            #endregion

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_DETAILS_HTML);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DetailsHtml = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_DETAILS_TEXT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DetailsText = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_GROUP_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ForumGroupID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_IS_ACTIVE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsActive = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_IS_DELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_LAST_POST_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LastForumPostID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_LAST_THREAD_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LastForumThreadID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_MOST_ACCESS_THREAD_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.MostAccessForumThreadID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_NUMBER_VIEWS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.NumberForumViews = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_TOTAL_POSTS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.TotalPosts = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumDataMapper.CN_FORUM_TOTAL_THREADS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.TotalThreads = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LastThreadName = _dtr.GetString(columnIndex);
            }

            columnIndex = _dtr.GetOrdinal(ForumGroupDataMapper.CN_FORUM_GROUP_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ForumGroupName = _dtr.GetString(columnIndex);
            }
        }

        public void PopulateForumThread(SqlDataReader _dtr, ForumThread obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_CREATED_BY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetInt32((columnIndex));
            }

            #region GetDateTime
            int TotalDays = 0, TotalSeconds = 0;

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_CREATION_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_CREATION_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.CreationDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);
            #endregion

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_DETAILS_HTML);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DetailsHtml = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_DETAILS_TEXT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DetailsText = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_FORUM_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ForumID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = (RootEnums.ForumThreadStatus)_dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_IS_DELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_LAST_POST_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LastPostID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_NUMBER_VIEWS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.NumberThreadViews = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumThreadDataMapper.CN_FORUM_THREAD_TOTAL_POSTS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.TotalPosts = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateForumPost(SqlDataReader _dtr, ForumPost obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_CREATED_BY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetInt32((columnIndex));
            }

            #region GetDateTime
            int TotalDays = 0, TotalSeconds = 0;

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_CREATION_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_CREATION_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.CreationDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);
            #endregion

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_DETAILS_HTML);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DetailsHtml = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_DETAILS_TEXT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DetailsText = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_FORUM_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ForumID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = (RootEnums.ForumPostStatus)_dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_IS_DELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_PARENT_POST_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ParentPostID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumPostDataMapper.CN_FORUM_POST_THREAD_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ForumThreadID = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateForumUser(SqlDataReader _dtr, ForumUser obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            int TotalDays = 0, TotalSeconds = 0;
            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_BANNED_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_BANNED_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.BannedDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_BIRTH_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_BIRTH_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.BirthDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_FORUM_USER_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ForumUserType = (RootEnums.ForumUserType)(_dtr.GetInt32((columnIndex)));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_IMAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Image = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_IS_BANNED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsBanned = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_IS_TRUSTED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsTrusted = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_JOIN_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_JOIN_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.JoinDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_POSTS_PER_PAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PostsPerPage = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_ROLE_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.RoleID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_SIGNATURE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Signature = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_THREADS_PER_PAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ThreadsPerPage = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_USER_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UserID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_USER_RATE_VALUE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UserRateValue = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UserName = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_IS_DELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
        }

        public void PopulateForumUserSummary(SqlDataReader _dtr, ForumUserSummary obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_IMAGE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Image = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_SIGNATURE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Signature = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_USER_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UserID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UserName = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(ForumUserDataMapper.CN_FORUM_USER_USER_RATE_VALUE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UserRateValue = _dtr.GetInt32((columnIndex));
            }
        }


        public void PopulateEvent(SqlDataReader _dtr, Event obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_CATEGORY_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }

            int TotalDays = 0, TotalSeconds = 0;
            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_CREATED_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_CREATED_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.CreationDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_CREATED_BY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DetailsHtml = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_DURATION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Duration = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_EVENT_LOCATION_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.LocationID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_EVERY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Every = _dtr.GetInt32((columnIndex));
            }

            TotalDays = 0;
            TotalSeconds = 0;
            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_FROM_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_FROM_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.FromDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_IMAGE_URL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ImageURL = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_IS_DELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_NOTIFY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Notify = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_PERIOD);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Period = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_REMINDER);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Reminder = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_REPEAT_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.RepeatType = (RootEnums.EventRepeatType)_dtr.GetInt32((columnIndex));
            }

            TotalDays = 0;
            TotalSeconds = 0;
            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_TO_TOT_DAY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalDays = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventDataMapper.CN_EVENT_TO_TOT_SECOND);
            if (!_dtr.IsDBNull(columnIndex))
            {
                TotalSeconds = _dtr.GetInt32((columnIndex));
            }
            obj.ToDate = Helper.HelperMethods.ConvertToDateTime(TotalDays, TotalSeconds);
        }

        public void PopulateEventLocation(SqlDataReader _dtr, EventLocation obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(EventLocationDataMapper.CN_EVENT_LOCATION_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventLocationDataMapper.CN_EVENT_LOCATION_IS_DELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(EventLocationDataMapper.CN_EVENT_LOCATION_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
        }

        public void PopulateSawtyyat(SqlDataReader _dtr, Sawtyyat obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(SawtyyatDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SawtyyatDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SawtyyatDataMapper.CN_PATH);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Path = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SawtyyatDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (RootEnums.AudioVideoType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SawtyyatDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(SawtyyatDataMapper.CN_DATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Date = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(SawtyyatDataMapper.CN_CATEGORY_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateFatawa(SqlDataReader _dtr, Fatawa obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_EMAIL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Email = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_MOBILE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Mobile = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_ADDRESS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Address = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_QUESTION);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Question = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_ANSWER);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Answer = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_ANSWEREDBY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.AnsweredBy = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_QUESTIONDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.QuestionDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_ANSWERDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.AnswerDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(FatawaDataMapper.CN_CATEGORY_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
        }

        public void PopulateBanner(SqlDataReader _dtr, Banner obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_HASH);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Hash = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_DETAILS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Details = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_CRERATIONDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CrerationDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_CREATEDBY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CreatedBy = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_PUBLISHFROM);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PublishFrom = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_PUBLISHTO);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PublishTo = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_CATEGORYID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_STATUS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Status = (RootEnums.BannerStatus)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_URL_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UrlType = (RootEnums.UrlType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_URL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Url = _dtr.GetString((columnIndex));
            }

            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_TOTALCOUNT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.TotalCount = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_TOTALVIEWS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.TotalPassed = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_TYPE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Type = (RootEnums.BannerType)_dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(BannerDataMapper.CN_USER_SIDE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.UserSide = _dtr.GetString((columnIndex));
            }

        }
        public void PopulateMaiciousRequest(SqlDataReader _dtr, MaiciousRequest obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(MaiciousRequestDataMapper.CN_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MaiciousRequestDataMapper.CN_IPADDRESS);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IPAddress = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MaiciousRequestDataMapper.CN_URL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Url = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(MaiciousRequestDataMapper.CN_DATETIME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.DateTime = _dtr.GetString((columnIndex));
            }

            ////#PutNextFunctionhere#////
        }

        public void PopulateProduct(SqlDataReader _dtr, Product obj)
        {
            int columnIndex = 0;
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_ID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_NAME);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Name = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_SERIAL);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Serial = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_PUBLICPRICE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PublicPrice = _dtr.GetDouble((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_PRIVATEPRICE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.PrivatePrice = _dtr.GetDouble((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_CATEGORYID);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.CategoryID = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_PRODUCINGDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ProducingDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_EXPIRYDATE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.ExpiryDate = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_VALUE);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Value = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_TAX);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Tax = _dtr.GetDouble((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_PICTURE1);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Picture1 = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_PICTURE2);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Picture2 = _dtr.GetString((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_WEIGHT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Weight = _dtr.GetDouble((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_HEIGHT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Height = _dtr.GetDouble((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_TAX);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Tax = _dtr.GetDouble((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_DISCOUNT);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Discount = _dtr.GetDouble((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_ISDELETED);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.IsDeleted = _dtr.GetBoolean((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_QUANTITY);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Quantity = _dtr.GetInt32((columnIndex));
            }
            columnIndex = _dtr.GetOrdinal(ProductDataMapper.CN_PRODUCT_PROVIDER);
            if (!_dtr.IsDBNull(columnIndex))
            {
                obj.Provider = _dtr.GetInt32((columnIndex));
            }
        }
    }
}