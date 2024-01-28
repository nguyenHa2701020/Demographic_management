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
    internal class dataqlyNhanKhau
    {
        connect connect=new connect();
        public DataTable load_NK()
        {
            string sql = "load_NK";
            return connect.Load_Data(sql);
        }
        public DataTable load_MaTDP()
        {
            string sql = "load_MTDP";
            return connect.Load_Data(sql);
        }
        public int insertNK(objNhanKhau objNK)
        {
            int parameter = 6;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@sonhankhau";
            names[1] = "@maTDP";
            names[2] = "@TenCH";
            names[3] = "@CMNhanDan";
            names[4] = "@nghenghiep";
            names[5] = "@quequan";

            values[0] = objNK.SoNK;
            values[1] =objNK.maTDP;
            values[2] = objNK.TenCH;
            values[3] = objNK.CMNDan;
            values[4] = objNK.NgheNghiep;
            values[5] = objNK.queQuan;
            string sql = "insert_NK";
            return connect.Execute(sql, names, values, parameter);
        }
        public int updateNK(objNhanKhau objNK)
        {
            int parameter = 6;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@sonhankhau";
            names[1] = "@maTDP";
            names[2] = "@TenCH";
            names[3] = "@CMNhanDan";
            names[4] = "@nghenghiep";
            names[5] = "@quequan";

            values[0] = objNK.SoNK;
            values[1] = objNK.maTDP;
            values[2] = objNK.TenCH;
            values[3] = objNK.CMNDan;
            values[4] = objNK.NgheNghiep;
            values[5] = objNK.queQuan;
            string sql = "update_NK";
            return connect.Execute(sql, names, values, parameter);
        }

            public int deleteNK(objNhanKhau objNK)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@soNK";
            values[0] = objNK.SoNK;

            string sql = "delete_NK";
            return connect.Execute(sql, name, values, parameter);
        }


        public DataTable searchNK(string filter)
        {
            return connect.Load_DataNotProc(filter);
        }
    }
}
