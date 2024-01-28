using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Objects
{
    internal class objNhanKhau
    {
        string _sonhankhau;
        string _MTDP;
        string _tenCh;
        string _CMND;
        string _ngheNghiep;
        string _quequan;
        public string SoNK {  get { return _sonhankhau; } set { _sonhankhau = value; } }
        public string maTDP { get { return _MTDP; } set { _MTDP = value; } }
        public string TenCH { get { return _tenCh; } set { _tenCh = value; } }
        public string CMNDan { get { return _CMND; } set { _CMND = value; } }
        public string NgheNghiep { get { return _ngheNghiep; } set { _ngheNghiep = value; } }

        public string queQuan { get { return _quequan; } set { _quequan = value; } }
    }
}

