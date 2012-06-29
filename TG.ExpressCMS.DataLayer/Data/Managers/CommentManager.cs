using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using TG.ExpressCMS.DataLayer.Entities;

namespace TG.ExpressCMS.DataLayer.Data
{
    public class CommentManager
    {
        public static int Add(Comment obj)
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            return objCaller.Add(obj);
        }
        public static void Update(Comment obj)
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            objCaller.Update(obj);
        }
        public static Comment GetByID(int ID)
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            return objCaller.GetByID(ID);
        }
        public static IList<Comment> GetAll()
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            return objCaller.GetAll();
        }
        public static IList<Comment> SearchNewsComment(int objectid, int catid)
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            return objCaller.SearchNewsComment(objectid, catid);
        }
        public static IList<Comment> GetPendingComments()
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            return objCaller.GetPendingComments();
        }
        public static IList<Comment> GetCommentByIDandType(int ObjectId, int ObjectType)
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            return objCaller.GetCommentsByTypeandID(ObjectId, ObjectType);
        }
        public static void Delete(int ID)
        {
            CommentDataMapper objCaller = new CommentDataMapper();

            objCaller.Delete(ID);
        }
    }
}