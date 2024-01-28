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
    internal class dataqlyKhaiSinh
    {
       connect connect= new connect();
        public DataTable load_KS()
        {
            string sql = "load_KS";
            return connect.Load_Data(sql);
        }
        public DataTable loadMaPh()
        {
            string sql = "load_MPhuong";
            return connect.Load_Data(sql);
        }
        public int insert_KS(objKhaiSinh objKS)
        {
     
            int parameter = 10;
            string[] names= new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soKhaiSinh";
            names[1] = "@mphuong";
            names[2] = "@tenKS";
            names[3] = "@ngayS";
            names[4] = "@GTinh";
            names[5] = "@noisinh";
            names[6] = "@quoctich";
            names[7] = "@hoTenCha";
            names[8] = "@hoTenMe";
            names[9] = "@nguoiDiKhai";


            values[0] = objKS.SoKhaiSinh;
            values[1] = objKS.maPh;
            values[2] = objKS.Hoten;
            values[3] = objKS.ngaysinh;
            values[4] = objKS.gt;
            values[5] = objKS.noisinh;
            values[6] = objKS.quocTich;
            values[7] = objKS.HoTenCha;
            values[8] = objKS.HotenMe;
            values[9] = objKS.HotenNgKai;
            string sql = "insert_KS";
            return connect.Execute(sql, names, values, parameter);
        }
        public int update_KS(objKhaiSinh objKS)
        {

            int parameter = 10;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soKhaiSinh";
            names[1] = "@mphuong";
            names[2] = "@tenKS";
            names[3] = "@ngayS";
            names[4] = "@GTinh";
            names[5] = "@noisinh";
            names[6] = "@quoctich";
            names[7] = "@hoTenCha";
            names[8] = "@hoTenMe";
            names[9] = "@nguoiDiKhai";


            values[0] = objKS.SoKhaiSinh;
            values[1] = objKS.maPh;
            values[2] = objKS.Hoten;
            values[3] = objKS.ngaysinh;
            values[4] = objKS.gt;
            values[5] = objKS.noisinh;
            values[6] = objKS.quocTich;
            values[7] = objKS.HoTenCha;
            values[8] = objKS.HotenMe;
            values[9] = objKS.HotenNgKai;
            string sql = "update_KS";
            return connect.Execute(sql, names, values, parameter);
        }
        public int delete_KS(objKhaiSinh objKS)
        {

            int parameter = 1;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soKhaiSinh";

            values[0] = objKS.SoKhaiSinh;
          
            string sql = "delete_KS";
            return connect.Execute(sql, names, values, parameter);
        }

        public DataTable search_KS(string filter)
        {
            return connect.Load_DataNotProc(filter);
        }

    }
}
