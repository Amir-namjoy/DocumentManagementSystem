using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MaliArchive.settings;
using MaliArchive;

namespace MaliArchive
{

    public enum DatabaseType
    {
        Access = 1,
        SQLExpress = 2,
        SqlServer = 3
    }

    class DA
    {
        public static string ConnectionString="";

        public static void run_Query(string query)
        {
            using (SqlConnection myconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    mycommand.CommandText = query;
                    mycommand.ExecuteNonQuery();
                 }
                myconnection.Close();
            }
        }
        public static void run_Query(SqlCommand mycommand)
        {
            using (SqlConnection myconnection = new SqlConnection(ConnectionString))
            {

                    myconnection.Open();
                    mycommand.Connection = myconnection;
                   
                    mycommand.ExecuteNonQuery();
  
                    myconnection.Close();
            }
        }
        public static void run_Query(string query, SqlParameter[] myparametrs)
        {
            using (SqlConnection myconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    mycommand.CommandText = query;
                    mycommand.ExecuteNonQuery();
                }
                myconnection.Close();
            }
        }

        public static bool check_is_in_table(string CheckQuery)
        {
            bool CheckResult = false;
            using (SqlConnection myconnection = new SqlConnection(DA.ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    mycommand.CommandText = CheckQuery;
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    CheckResult = myreader.HasRows;
                 }
                myconnection.Close();
            }
            return CheckResult;
        }

        // ---------------  راكد كردن پرونده

        public static string raked_doc(string doc_id)
        {
            string q = "update parvandeh set raked=1, raked_date=GETDATE() where id=" + doc_id;
            DA.run_Query(q);
            return "0";
        }


        public static int ass_new_pnumber(string tarikTashkil)
        {
            int a;
            using (SqlConnection myconnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand mycommand = new SqlCommand())
                {
                    myconnection.Open();
                    mycommand.Connection = myconnection;
                    mycommand.Parameters.AddWithValue("@tarikTashkil", tarikTashkil);
                    string q = @"DECLARE @assid INT
                                insert into parvandeh(tarikTashkil, tedadbarg, raked, amanat, raked_date, amanatid) values(@tarikTashkil,0,0,0,0,-1)
                                set @assid = SCOPE_IDENTITY()
                                select @assid";
                    mycommand.CommandText = q;
                    SqlDataReader myreader = mycommand.ExecuteReader();
                    myreader.Read();
                    if (myreader[0] == DBNull.Value)
                        a = 0;
                    else
                        a = Convert.ToInt32(myreader[0]);

                }
                myconnection.Close();
            }
            return a;
        }

        public static class ConnectionSetting
        {
        
            public static string DatabaseName = "";
            public static string SQLServerName = "";
            public static string SQLServerPassword = "";
            public static string SQLServerUsername = "";
        }

       /* public static bool TestConnection()
        {
            frmProgress pgs = new frmProgress("اتصال به دیتابيس...");
            pgs.Show();
            try
            {
                SqlConnection Connection = new SqlConnection();
                Connection.ConnectionString = getConnectionString();
                Connection.Open();
                Connection.Close();
                pgs.Close();
                return true;
            }
            catch { }
            pgs.Close();
            
            return false;
        }*/



    }
}
