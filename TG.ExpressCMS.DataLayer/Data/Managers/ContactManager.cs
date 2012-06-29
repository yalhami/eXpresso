using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class ContactManager
    {
        public static int Add(Contact obj)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Contact obj)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            objCaller.Update(obj);
        }
        public static void AssignContacttoGroup(int contactID, int GroupID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            objCaller.AssignContacttoGroup(contactID, GroupID);
        }
        public static void DeleteContactsFromGroups(int contactID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            objCaller.DeleteContactfromGroups(contactID);
        }
        public static void DeleteAllGroupContacts(int groupID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            objCaller.DeleteContactfromGroup(groupID);
        }
        public static void DeleteContactsFromGroup(int contactID, int groupID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            objCaller.DeleteContactfromGroup(contactID, groupID);
        }
        public static Contact GetByID(int ID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<int> GetGroupsByContactId(int contactID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            return objCaller.GetContactsGroup(contactID);
        }
        public static Contact GetbyGuid(string guid)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            return objCaller.GetByGuid(guid);
        }
        public static Contact GetByEmail(string email)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            return objCaller.GetByEmail(email);
        }
        public static IList<Contact> GetAll()
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            return objCaller.GetAll();
        }
        public static IList<Contact> GetByGroupID(int groupID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            return objCaller.GetByGroupID(groupID);
        }
        public static void Delete(int ID)
        {
            ContactDataMapper objCaller = new ContactDataMapper();

            objCaller.Delete(ID);
        }
    }
}