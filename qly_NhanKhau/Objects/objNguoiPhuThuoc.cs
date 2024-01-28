using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Objects
{
    internal class objNguoiPhuThuoc
    {
        string _soNguoiPhuThuoc;
        string _soNhanKhau;
        string _tenNPT;
        DateTime _ngaysinhNPT;
        string _gioitinhNPT;
        string _quequanNPT;
        string _CMND;
        string _ngheNghiep;
        string _qheCH;
     
        public string soNPT { get { return _soNguoiPhuThuoc; } set { _soNguoiPhuThuoc = value; } }
        public string soNhanKhau { get { return _soNhanKhau; } set { _soNhanKhau = value; } }

        public string TenNguoiPhuThuoc { get { return _tenNPT; } set { _tenNPT = value; } }

        public DateTime ngaysinhNPT { get { return _ngaysinhNPT; } set { _ngaysinhNPT = value; } }

        public string gtNPT { get { return _gioitinhNPT; } set { _gioitinhNPT = value; } }

        public string queQuanNPT { get { return _quequanNPT; } set { _quequanNPT = value; } }

        public string CMND_NPT { get { return _CMND; } set { _CMND = value; } }

        public string ngheNghiepNPT { get { return _ngheNghiep; } set { _ngheNghiep = value; } }

        public string quanheVoiChuHo { get { return _qheCH; } set { _qheCH = value; } }
       
    }
}
