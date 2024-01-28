using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Objects
{
    internal class objToDanPho
    {
        string _maTDP;
        string _maPhuong;
        string _tenTDP;
        string _CanhSatKV;
        string _toTruongTDP;
        string _dtToDanPho;
        public string MaToDanPho { get { return _maTDP; } set {  _maTDP = value; } }
        public string maphuong { get { return _maPhuong; } set {  _maPhuong = value; } }
        public string TenToDanPho { get { return _tenTDP; } set { _tenTDP = value; } }
        public string CanhSatKV { get { return _CanhSatKV;  } set { _CanhSatKV = value; } }
        public string toTruongToDanPho { get { return _toTruongTDP; } set { _toTruongTDP = value; }}
        public string dienthoaiToDanPho { get { return _dtToDanPho; } set { _dtToDanPho = value; } }
    }
}
