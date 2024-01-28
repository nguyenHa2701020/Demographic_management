using qly_NhanKhau.objqlyHK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.DATAobj
{
    internal class dataqlyPhuong
    {
        connect ketnoi = new connect();

        public DataTable load_Phuong()
        {
            string sql = "load_Phuong";
            return ketnoi.Load_Data(sql);
        }

        public DataTable search_Phuong(string filter)
        {
            return ketnoi.Load_DataNotProc(filter);
        }

        public int insert_Phuong(objPhuong ph)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maph";
            name[1] = "@tenph";
            name[2] = "@sdtph";
            values[0] = ph.Map;
            values[1] = ph.Tenp;
            values[2] = ph.Ssdtp;
            string sql = "insert_Phuong";
            return ketnoi.Execute(sql, name, values, parameter);
        }

        public int update_Phuong(objPhuong ph)
        {
            int parameter = 3;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maph";
            name[1] = "@tenph";
            name[2] = "@sdtph";
            values[0] = ph.Map;
            values[1] = ph.Tenp;
            values[2] = ph.Ssdtp;
            string sql = "update_Phuong";
            return ketnoi.Execute(sql, name, values, parameter);
        }

        public int delete_Phuong(objPhuong ph)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maph";
            
            values[0] = ph.Map;
            
            string sql = "delete_Phuong";
            return ketnoi.Execute(sql, name, values, parameter);
        }


    }
}
