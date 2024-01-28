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
    internal class dataqlyKhaiTu
    {
        connect connect = new connect();
        public DataTable load_KT()
        {
            string sql = "load_KT";
            return connect.Load_Data(sql);

        }
        public DataTable load_soKS()
        {
            string sql = "load_soKS";
            return connect.Load_Data(sql);

        }

        public int insertKT(objKhaiTu objKT)
        {
            int parameter = 6;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soKT";
            names[1] = "@soKhaiSinh";
            names[2] = "@tenNguoiKhai";
            names[3] = "@qheNgMat";
            names[4] = "@ngaymat";
            names[5] = "@lidoMat";

            values[0] = objKT.soKhaiTu;
            values[1] = objKT.soKhaiSinh ;
            values[2] = objKT.nguoiKhai;
            values[3] = objKT.quanheVsNgMat ;
            values[4] = objKT.ngayMat;
            values[5] = objKT.lidoMat;
            string sql = "insert_KT";
            return connect.Execute(sql, names, values, parameter);
        }
        public int updateKT(objKhaiTu objKT)
        {
            int parameter = 6;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soKT";
            names[1] = "@soKhaiSinh";
            names[2] = "@tenNguoiKhai";
            names[3] = "@qheNgMat";
            names[4] = "@ngaymat";
            names[5] = "@lidoMat";

            values[0] = objKT.soKhaiTu;
            values[1] = objKT.soKhaiSinh;
            values[2] = objKT.nguoiKhai;
            values[3] = objKT.quanheVsNgMat;
            values[4] = objKT.ngayMat;
            values[5] = objKT.lidoMat;
            string sql = "update_KT";
            return connect.Execute(sql, names, values, parameter);
        }

        public int deleteKT(objKhaiTu objKT)
        {
            int parameter = 1;
            string[] name = new string[parameter];
            object[] values = new object[parameter];
            name[0] = "@soKT";
            values[0] = objKT.soKhaiTu;

            string sql = "delete_KT";
            return connect.Execute(sql, name, values, parameter);
        }


        public DataTable searchKT(string filter)
        {
            return connect.Load_DataNotProc(filter);
        }
    }

}
