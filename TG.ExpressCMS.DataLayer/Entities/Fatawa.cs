using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TG.ExpressCMS.DataLayer.Entities
{
    public class Fatawa
    {
        public int ID
        {
            set;
            get;
        }
        public string Name
        {
            set;
            get;
        }
        public string Email
        {
            set;
            get;
        }
        public string Mobile
        {
            set;
            get;
        }
        public string Address
        {
            set;
            get;
        }
        public string Question
        {
            set;
            get;
        }
        public string Answer
        {
            set;
            get;
        }
        public string AnsweredBy
        {
            set;
            get;
        }
        public string QuestionDate
        {
            set;
            get;
        }
        public string AnswerDate
        {
            set;
            get;
        }
        public int Status
        {
            set;
            get;
        }
        public bool IsDeleted
        {
            set;
            get;
        }
        public int CategoryID
        {
            set;
            get;
        }
        public string QuestionandAnswerAndEmail
        {
            get
            {
                return Question + ":" + ID;
            }
        }
    }
}