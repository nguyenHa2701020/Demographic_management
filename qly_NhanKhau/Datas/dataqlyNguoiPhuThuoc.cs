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
    internal class dataqlyNguoiPhuThuoc
    {
        connect connect = new connect();
        public DataTable load_NPT()
        {
            string sql = "load_NPT";
            return connect.Load_Data(sql);
        }
        public DataTable loadSoNK()
        {
            string sql = "load_SoNK";
            return connect.Load_Data(sql);
        }
        public int insert_NPT(objNguoiPhuThuoc objNPT)
        {

            int parameter = 9;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soNPT";
            names[1] = "@sonhankhau";
            names[2] = "@tenNPT";
            names[3] = "@ngaySinhNPT";
            names[4] = "@GT_NPT";
            names[5] = "@quequanNPT";
            names[6] = "@CMND_NPT";
            names[7] = "@NNghiep_NPT";
            names[8] = "@qheCh";



            values[0] = objNPT.soNPT;
            values[1] = objNPT.soNhanKhau;
            values[2] = objNPT.TenNguoiPhuThuoc;
            values[3] = objNPT.ngaysinhNPT;
            values[4] = objNPT.gtNPT;
            values[5] = objNPT.queQuanNPT;
            values[6] = objNPT.CMND_NPT;
            values[7] = objNPT.ngheNghiepNPT;
            values[8] = objNPT.quanheVoiChuHo;
            
            string sql = "insert_NPT";
            return connect.Execute(sql, names, values, parameter);
        }
        public int update_NPT(objNguoiPhuThuoc objNPT)
        {

            int parameter = 9;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soNPT";
            names[1] = "@sonhankhau";
            names[2] = "@tenNPT";
            names[3] = "@ngaySinhNPT";
            names[4] = "@GT_NPT";
            names[5] = "@quequanNPT";
            names[6] = "@CMND_NPT";
            names[7] = "@NNghiep_NPT";
            names[8] = "@qheCh";



            values[0] = objNPT.soNPT;
            values[1] = objNPT.soNhanKhau;
            values[2] = objNPT.TenNguoiPhuThuoc;
            values[3] = objNPT.ngaysinhNPT;
            values[4] = objNPT.gtNPT;
            values[5] = objNPT.queQuanNPT;
            values[6] = objNPT.CMND_NPT;
            values[7] = objNPT.ngheNghiepNPT;
            values[8] = objNPT.quanheVoiChuHo;

            string sql = "update_NPT";
            return connect.Execute(sql, names, values, parameter);
        }
        public int delete_NPT(objNguoiPhuThuoc objNPT)
        {

            int parameter = 1;
            string[] names = new string[parameter];
            object[] values = new object[parameter];
            names[0] = "@soNPT";

            values[0] = objNPT.soNPT;

            string sql = "delete_NPT";
            return connect.Execute(sql, names, values, parameter);
        }

        public DataTable search_NPT(string filter)
        {
            return connect.Load_DataNotProc(filter);
        }

    }
}
