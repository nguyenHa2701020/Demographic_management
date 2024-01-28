using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Objects
{
    internal class objTamVang
    {

        string _soTV;
        string _masoNK;
        string _hoten;
        string _CMND;
        string _Dthoai;
        DateTime _ngaytamvang;
        string _lidoTV;


        public string soTamVang { get { return _soTV; } set { _soTV = value; } }
        public string masoNK { get { return _masoNK; } set { _masoNK = value; } }
        public string hoten { get { return _hoten; } set { _hoten = value; } }
        public string CMND { get { return _CMND; } set { _CMND = value; } }
        public string Dthoai { get { return _Dthoai; } set { _Dthoai = value; } }
        public DateTime ngayTV { get { return _ngaytamvang; } set { _ngaytamvang = value; } }
        public string lidoTV { get { return _lidoTV; } set { _lidoTV = value; } }
    }
}
