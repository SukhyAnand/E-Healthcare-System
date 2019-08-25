using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for Transaction
/// </summary>
namespace DMS
{
    public class Transaction
    {
        static String ConnectionString = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;

        public static bool SqlInUpDelTransaction(string ProcName, List<Transaction> Trans)
        {

            try
            {
                
                Int32 rowsAffected;
                using (SqlConnection sqlConnection1 = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {


                        cmd.CommandText = ProcName;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = sqlConnection1;
                        foreach (var item in Trans)
                            cmd.Parameters.AddWithValue(item.Key, item.value);
                        sqlConnection1.Open();

                        rowsAffected = cmd.ExecuteNonQuery();

                    }
                }
                if (rowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static DataSet SqlSelTransaction(string ProcName, List<Transaction> Trans)
        {
            DataSet ds = new DataSet();
            try
            {
               
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // 1.  create a command object identifying the stored procedure
                    SqlCommand cmd = new SqlCommand(ProcName, conn);

                    // 2. set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // 3. add parameter to command, which will be passed to the stored procedure
                    foreach (var item in Trans)
                        cmd.Parameters.Add(new SqlParameter(item.Key, item.value));

                    // execute the command
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(rdr);
                        ds.Tables.Add(dt);
                        // iterate through results, printing each to console
                        //while (rdr.Read())
                        //{
                        //    Console.WriteLine("Product: {0,-35} Total: {1,2}", rdr["ProductName"], rdr["Total"]);
                        //}
                    }
                }
                return ds;

            }
            catch (Exception ex)
            {
                return ds;
            }
        }

        public string Key { get; set; }
        public object value { get; set; }
        public object type { get; set; }

    }
}