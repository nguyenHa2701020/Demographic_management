using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Objects
{
    internal class objTamTru
    {

        string _soTT;
        string _maP;
        string _ten;
        string _CMNDan;
        string _Dt;
        DateTime _ngaytamtru;
       
        public string soTamTru { get { return _soTT; } set { _soTT = value; } }
        public string maPh { get { return _maP; } set { _maP = value; } }
        public string ten { get { return _ten; } set { _ten = value; } }
        public string CMND { get { return _CMNDan; } set { _CMNDan = value; } }
        public string Dthoai { get { return _Dt; } set { _Dt = value; } }
        public DateTime ngayTT { get { return _ngaytamtru; } set { _ngaytamtru = value; } }
      
    }
}

