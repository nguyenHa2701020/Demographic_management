using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qly_NhanKhau.Objects
{
    internal class objKhaiSinh
    {
		string _sokhaisinh;
		string _map;
		string _ten;
		DateTime _ngaysinh;
		string _gioitinh;
		string _nơisinh;
		string _quoctich;
		string _tencha;
		string _tenme;
		string _tenngdikhai;

		public string SoKhaiSinh { get { return _sokhaisinh;} set {  _sokhaisinh = value;} }
        public string maPh { get { return _map; } set { _map= value; } }

        public string Hoten { get { return _ten; } set { _ten = value; } }

        public DateTime ngaysinh { get { return _ngaysinh; } set { _ngaysinh = value; } }

        public string gt { get { return _gioitinh; } set { _gioitinh = value; } }

        public string noisinh { get { return _nơisinh; } set { _nơisinh = value; } }

        public string quocTich { get { return _quoctich; } set { _quoctich = value; } }

        public string HoTenCha { get { return _tencha; } set { _tencha = value; } }

        public string HotenMe { get { return _tenme; } set { _tenme = value; } }
        public string HotenNgKai { get { return _tenngdikhai; } set { _tenngdikhai = value; } }

    }
}

