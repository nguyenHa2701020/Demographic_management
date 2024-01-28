using qly_NhanKhau.DATAobj;
using qly_NhanKhau.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Datas
{
    internal class dataqlyTamTru
    {
        connect connect = new connect();
        public DataTable load_TT()
        {
            string sql = "load_TT";
            return connect.Load_Data(sql);
        }
        public DataTable load_MaP()
        {
            string sql = "load_MaP";
            return connect.Load_Data(sql);
        }
        public int insertTT(objTamTru objTT)
        {
            int parameter = 6;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soTT";
            names[1] = "@maPh";
            names[2] = "@hoTen";
            names[3] = "@CMND";
            names[4] = "@DThoai";
            names[5] = "@ngayTT";

            values[0] = objTT.soTamTru;
            values[1] = objTT.maPh;
            values[2] = objTT.ten;
            values[3] = objTT.CMND;
            values[4] = objTT.Dthoai;
            values[5] = objTT.ngayTT;
            string sql = "insert_TT";
            return connect.Execute(sql, names, values, parameter);
        }
        public int updateTT(objTamTru objTT)
        {
            int parameter = 6;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soTT";
            names[1] = "@maPh";
            names[2] = "@hoTen";
            names[3] = "@CMND";
            names[4] = "@DThoai";
            names[5] = "@ngayTT";

            values[0] = objTT.soTamTru;
            values[1] = objTT.maPh;
            values[2] = objTT.ten;
            values[3] = objTT.CMND;
            values[4] = objTT.Dthoai;
            values[5] = objTT.ngayTT;
            string sql = "update_TT";
            return connect.Execute(sql, names, values, parameter);
        }

        public int deleteTT(objTamTru objTT)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@soTamTru";
            values[0] = objTT.soTamTru;

            string sql = "delete_TT";
            return connect.Execute(sql, name, values, parameter);
        }


        public DataTable searchTT(string filter)
        {
            return connect.Load_DataNotProc(filter);
        }
    }
}
