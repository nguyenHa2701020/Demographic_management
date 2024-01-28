using qly_NhanKhau.DATAobj;
using qly_NhanKhau.Objects;
using qly_NhanKhau.objqlyHK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Datas
{
    internal class dataqlyToDanPho
    {
        connect connect= new connect();
        public DataTable load_TDP()
        {
            string sql = "load_TDP";
           return  connect.Load_Data(sql);

        }
        public DataTable load_MP()
        {
            string sql = "load_MP";
            return connect.Load_Data(sql);

        }

        public int insertTDP(objToDanPho objTDP)
        {
            int parameter = 6;
            string[] names= new string[parameter];
            object[] values= new object[parameter];
            names[0] = "@maTDP";
            names[1] = "@maP";
            names[2] = "@tenTDP";
            names[3] = "@CSKhuVuc";
            names[4] = "@totruongTDP";
            names[5] = "@dtTDP";

            values[0] = objTDP.MaToDanPho;
            values[1] = objTDP.maphuong;
            values[2] = objTDP.TenToDanPho;
            values[3] = objTDP.CanhSatKV;
            values[4] = objTDP.toTruongToDanPho;
            values[5] = objTDP.dienthoaiToDanPho;
            string sql = "insert_TDP";
            return connect.Execute(sql, names, values, parameter);
         }
        public int updateTDP(objToDanPho objTDP)
        {
            int parameter = 6;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@maTDP";
            names[1] = "@maP";
            names[2] = "@tenTDP";
            names[3] = "@CSKhuVuc";
            names[4] = "@totruongTDP";
            names[5] = "@dtTDP";

            values[0] = objTDP.MaToDanPho;
            values[1] = objTDP.maphuong;
            values[2] = objTDP.TenToDanPho;
            values[3] = objTDP.CanhSatKV;
            values[4] = objTDP.toTruongToDanPho;
            values[5] = objTDP.dienthoaiToDanPho;
            string sql = "update_TDP";
            return connect.Execute(sql, names, values, parameter);
        }

        public int deleteTDP(objToDanPho objTDP)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@maToDanPho";
            values[0] = objTDP.MaToDanPho;

            string sql = "delete_TDP";
            return connect.Execute(sql, name, values, parameter);
        }


        public DataTable searchTDP(string filter)
        {
            return connect.Load_DataNotProc(filter);
        }

    }
}
