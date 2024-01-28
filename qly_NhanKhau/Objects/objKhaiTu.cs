using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Objects
{
    internal class objKhaiTu
    {
        string _soKT;
        string _soKS;
        string _tenngkhai;
        string _quanheVsngmat;
        DateTime _ngayMat;
        string _lidomat;
        public string soKhaiTu { get { return _soKT; } set { _soKT = value; } }
        public string soKhaiSinh { get { return _soKS; } set { _soKS = value; } }
        public string nguoiKhai { get { return _tenngkhai; } set { _tenngkhai = value; } }
        public string quanheVsNgMat { get { return _quanheVsngmat; } set { _quanheVsngmat = value; } }
        public DateTime ngayMat { get { return _ngayMat; } set { _ngayMat = value; } }
        public string lidoMat { get { return _lidomat; } set { _lidomat = value; } }
    }
}
