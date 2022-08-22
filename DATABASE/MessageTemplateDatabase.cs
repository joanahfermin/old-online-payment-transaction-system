﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using Microsoft.Data.SqlClient;

namespace SampleRPT1
{
    internal class MessageTemplateDatabase
    {
        public static List<MessageTemplate> SelectLatest()
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                //Returns the list of records from the database. 
                return conn.Query<MessageTemplate>($"SELECT TOP 100 * FROM JO_Z3 where Deleted != 1 order by TemplateID DESC").ToList();
            }
        }

        public static MessageTemplate SelectByName(string Name)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.QuerySingleOrDefault<MessageTemplate>($"SELECT * FROM Jo_Z3 where Name = @Name and Deleted != 1", new { Name = Name });
            }
        }

        public static MessageTemplate Get(long TemplateID)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Get<MessageTemplate>(TemplateID);
            }
        }

        public static long Insert(MessageTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Insert<MessageTemplate>(modelInstance);
            }
        }

        public static bool Update(MessageTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                return conn.Update<MessageTemplate>(modelInstance);
            }
        }

        public static bool Delete(MessageTemplate modelInstance)
        {
            using (SqlConnection conn = DbUtils.getConnection())
            {
                modelInstance.Deleted = 1;
                return conn.Update<MessageTemplate>(modelInstance);
            }
        }
    }
}
