using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DBManager
    {

        static string constring = @"Data Source =MYPC; initial catalog=VPProject; Integrated security=true;";
        public SqlConnection conn = new SqlConnection(constring);

        public void opencon()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();

            }
        }
        public void closecon()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
      
        public SqlDataReader sdr = null;
        public void IUD(string query)
        {

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
        public SqlDataReader select(String query)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            
            return cmd.ExecuteReader();
        }

    }
}
