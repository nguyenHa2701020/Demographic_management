using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.DATAobj
{
    public  class connect
    {
        SqlConnection cnt = new SqlConnection(@"Data Source=ADMIN\MAYCHU;Initial Catalog=SQL_QLNK;Integrated Security=True");
        public connect()
        {
            if (cnt.State == ConnectionState.Closed)
            {
                cnt.Open();
            }
        }
        public string returnString(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand(sql,cnt);
            sqlCommand.CommandType = CommandType.Text;
            string name = sqlCommand.ExecuteScalar().ToString();
            return name;
        }

        public DataTable Load_Data(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnt);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Load_DataNotProc(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, cnt);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }



        public DataTable ExecuteDaTa(string sql, string[] name, object[] values, int parameter)
        {
 
                SqlCommand cmd = new SqlCommand(sql, cnt);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
        }



        public int Execute(string sql, string[] name, object[] values, int parameter)
        {
          try
           {
                SqlCommand cmd = new SqlCommand(sql, cnt);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < parameter; i++)
                {
                    cmd.Parameters.AddWithValue(name[i], values[i]);
                }
                return cmd.ExecuteNonQuery();
           }
            catch
            {
                return 0;
            }
        }


    }
}
