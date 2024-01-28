using qly_NhanKhau.DATAobj;
using qly_NhanKhau.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Datas
{
    internal class dataqlyTamVang
    {
        connect connect = new connect();
        public DataTable load_TV()
        {
            string sql = "load_TV";
            return connect.Load_Data(sql);
        }
        public DataTable load_soNK()
        {
            string sql = "load_soNhanKhau";
            return connect.Load_Data(sql);
        }

        public string loadCMND_ngphuThuoc(string soNPT)
        {
            string sql = "select ChungMinhNhanDan from NguoiPhuThuoc where soNpT='" + soNPT + "'";
            string name= connect.returnString(sql);
            return name;
        }
        public DataTable load_NgPhuThuoc(string MaNK)
        {
            string sql = "load_NgPT_TamV";
            int parameter = 1;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soNK";
            values[0] = MaNK;
            return connect.ExecuteDaTa(sql,names,values,parameter);
        }
        public DataTable load_CMND(string cmND)
        {
            string sql = "load_NgPT_TamV";
            int parameter = 1;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soNK";
            values[0] = cmND;
            return connect.ExecuteDaTa(sql, names, values, parameter);
        }


        public int insertTV(objTamVang objTV)
        {

            int parameter = 7;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soTV";
            names[1] = "@soNhanKhau";
            names[2] = "@hoten";
            names[3] = "@CMNDan";
            names[4] = "@DT";
            names[5] = "@ngayTV";
            names[6] = "@LDoTamVang";

            values[0] = objTV.soTamVang;
            values[1] = objTV.masoNK;
            values[2] = objTV.hoten;
            values[3] = objTV.CMND;
            values[4] = objTV.Dthoai;
            values[5] = objTV.ngayTV;
            values[6] = objTV.lidoTV;

            string sql = "insert_TV";
            return connect.Execute(sql, names, values, parameter);
        }
        public int updateTV(objTamVang objTV)
        {

            int parameter = 7;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soTV";
            names[1] = "@soNhanKhau";
            names[2] = "@hoten";
            names[3] = "@CMNDan";
            names[4] = "@DT";
            names[5] = "@ngayTV";
            names[6] = "@LDoTamVang";

            values[0] = objTV.soTamVang;
            values[1] = objTV.masoNK;
            values[2] = objTV.hoten;
            values[3] = objTV.CMND;
            values[4] = objTV.Dthoai;
            values[5] = objTV.ngayTV;
            values[6] = objTV.lidoTV;
            string sql = "update_TV";
            return connect.Execute(sql, names, values, parameter);
        }

        public int deleteTV(objTamVang objTV)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@soTV";
            values[0] = objTV.soTamVang;

            string sql = "delete_TV";
            return connect.Execute(sql, name, values, parameter);
        }


        public DataTable searchTV(string filter)
        {
            return connect.Load_DataNotProc(filter);
        }
    }
}
