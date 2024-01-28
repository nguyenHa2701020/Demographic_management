using qly_NhanKhau.DATAobj;
using qly_NhanKhau.Datas;
using qly_NhanKhau.Objects;
using qly_NhanKhau.objqlyHK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace qly_NhanKhau
{
    public partial class qlyToDanPho : Form
    {
        public qlyToDanPho()
        {
            InitializeComponent();
        }
        string tenP;
        dataqlyToDanPho dttdp = new dataqlyToDanPho();
        private void dinhdangluoi()
        {
            dataGridViewTDp.ReadOnly = true;
            dataGridViewTDp.Columns[0].HeaderText = "Mã tổ dân phố";
            dataGridViewTDp.Columns[1].HeaderText = "Mã phường";
            dataGridViewTDp.Columns[2].HeaderText = "Tên phường";
;            dataGridViewTDp.Columns[3].HeaderText = "Tên tổ dân phố";
            dataGridViewTDp.Columns[4].HeaderText = "Cảnh sát khu vực";
            dataGridViewTDp.Columns[5].HeaderText = "Tổ trưởng";
            dataGridViewTDp.Columns[6].HeaderText = "SDT";
        }
        private void showdataTDP()
        {
            DataTable data = dttdp.load_TDP();
            dataGridViewTDp.DataSource = data;
        }
        private void qlyToDanPho_Load(object sender, EventArgs e)
        {
            showdataTDP();

            dinhdangluoi();
            LoadMaP();
        }

        private void LoadMaP()
        {
            DataTable daTable = dttdp.load_MP();
            comboBoxMP.DataSource = daTable;
            comboBoxMP.DisplayMember = "tenphuong";
            comboBoxMP.ValueMember = "maphuong";

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            objToDanPho tdp = new objToDanPho();
            tdp.MaToDanPho = txtMTDP.Text;
         
            if (tenP == comboBoxMP.Text)
            {
                tdp.maphuong = comboBoxMP.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không Sửa Tên");
            }
            tdp.TenToDanPho = txtTenTDP.Text;
            tdp.CanhSatKV = txtCSKV.Text;
            tdp.toTruongToDanPho = txtToTruong.Text;
            tdp.dienthoaiToDanPho= txtdtTDP.Text;
            int i = dttdp.insertTDP(tdp);
            if (i > 0)
            {
                MessageBox.Show("Thêm tổ dân phố thành công");
                showdataTDP();
                reset();
            }
            else
            MessageBox.Show("Thêm tổ dân phố thất bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            objToDanPho tdp = new objToDanPho();
            tdp.MaToDanPho = txtMTDP.Text;

            if (tenP == comboBoxMP.Text)
            {
                tdp.maphuong = comboBoxMP.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không Sửa Tên");
            }
            int ckt = checkTrung(txtTenTDP.Text);
            if (ckt > 0)
            {
                MessageBox.Show("Trùng tên tổ dân phố");
            }
            else
            {
                MessageBox.Show("Không trùng tên tổ dân phố");
            }
           // tdp.TenToDanPho = txtTenTDP.Text;
            tdp.CanhSatKV = txtCSKV.Text;
            tdp.toTruongToDanPho = txtToTruong.Text;
            tdp.dienthoaiToDanPho = txtdtTDP.Text;
            int i = dttdp.updateTDP(tdp);
            if (i > 0)
            {
                MessageBox.Show("Sửa tổ dân phố thành công");
                showdataTDP();
                reset();
            }
            else
            {
                MessageBox.Show("Sửa tổ dân phô thất bại");
            }
}
        private int checkTrung(string name)
        {
            string connect = @"Data Source=ADMIN\MAYCHU;Initial Catalog=SQL_QLNK;Integrated Security=True";

            string sql = "tenTDPTrung";
            SqlConnection cnt = new SqlConnection(connect);
            cnt.Open();
            SqlCommand con = new SqlCommand(sql, cnt);
            con.CommandType = CommandType.StoredProcedure;
            con.Parameters.AddWithValue("@tenDP", name);

            int us = int.Parse(con.ExecuteScalar().ToString());
            return us;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            objToDanPho tdp = new objToDanPho();
            tdp.MaToDanPho = txtMTDP.Text;
           
            int i = dttdp.deleteTDP(tdp);
            if (i > 0)
            {
                MessageBox.Show("Xoá tổ dân phố thành công");
                showdataTDP();
                reset();
            }


            else
            {
                MessageBox.Show("Xoá tổ dân phô thất bại");
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string filter = "select maTodanPho,tblPhuong.maPhuong,tblPhuong.tenphuong, tenToDP, CSKV, toTruong, sdtTDP from tbltoDanPho, tblPhuong where tbltoDanPho.maph= tblPhuong.maPhuong ";
            if (!string.IsNullOrEmpty(txtMTDP.Text.Trim()))
            {
                filter += string.Format("AND maToDanPho like N'%{0}%'", txtMTDP.Text);
            }

            if (!string.IsNullOrEmpty(txtTenTDP.Text.Trim()))
            {
                filter += string.Format("AND tenToDP like N'%{0}%'", txtTenTDP.Text);
            }
            if (!string.IsNullOrEmpty(txtCSKV.Text.Trim()))
            {
                filter += string.Format("AND CSKV like N'%{0}%'", txtCSKV.Text);

            }
            if (!string.IsNullOrEmpty(txtToTruong.Text.Trim()))
            {
                filter += string.Format("AND toTruong like N'%{0}%'", txtToTruong.Text);

            }
            if (!string.IsNullOrEmpty(txtdtTDP.Text.Trim()))
            {
                filter += string.Format("AND sdtTDP like N'%{0}%'", txtdtTDP.Text);

            }
            if (comboBoxMP.Text != "")
            {
                filter += " AND  tbltoDanPho.maPh  = '" + comboBoxMP.SelectedValue + "'";

            }
         
            DataTable dt = dttdp.searchTDP(filter);
            dataGridViewTDp.DataSource = dt;
         
        }
        private void reset()
        {
            txtMTDP.Text = "";
            txtTenTDP.Text = "";
            txtCSKV.Text = "";
            txtToTruong.Text = "";
            txtdtTDP.Text = "";
        }
     

        private void dataGridViewTDp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMTDP.Text = dataGridViewTDp.CurrentRow.Cells[0].Value.ToString();
            comboBoxMP.Text = dataGridViewTDp.CurrentRow.Cells[2].Value.ToString();

            txtTenTDP.Text = dataGridViewTDp.CurrentRow.Cells[3].Value.ToString();

            txtCSKV.Text = dataGridViewTDp.CurrentRow.Cells[4].Value.ToString();
            txtToTruong.Text = dataGridViewTDp.CurrentRow.Cells[5].Value.ToString();

            txtdtTDP.Text = dataGridViewTDp.CurrentRow.Cells[6].Value.ToString();



        }
        private Form findOpenedForm(string name)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return f;
            }
            return null;
        }
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            string filter = " {tbltoDanPho.maph}= {tblPhuong.maphuong} ";
            if (!string.IsNullOrEmpty(txtMTDP.Text.Trim()))
            {
                filter += "AND {tbltoDanPho.maToDanPho} LIKE '*"+ txtMTDP.Text.Trim() +"*'";
            }
            if (!string.IsNullOrEmpty(txtTenTDP.Text.Trim()))
            {
                filter += "AND {tbltoDanPho.tenToDP} LIKE '*" + txtTenTDP.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtCSKV.Text.Trim()))
            {
                filter += "AND {tbltoDanPho.CSKV} LIKE '*" + txtCSKV.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtToTruong.Text.Trim()))
            {
                filter += "AND {tbltoDanPho.toTruong} LIKE '*" + txtToTruong.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtdtTDP.Text.Trim()))
            {
                filter += "AND {tbltoDanPho.sdtTDP} LIKE '*" + txtdtTDP.Text.Trim() + "*'";
            }
            if (comboBoxMP.Text != "")
            {
                filter += "AND {tbltoDanPho.maPh} ='" + comboBoxMP.SelectedValue + "'";
            }
            //hien thi report
            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("ToDanPho.rpt", filter, "DANH SÁCH TỔ DÂN PHỐ");
            reportViewerForm.Activate();
        }

        private void btnRSS_Click(object sender, EventArgs e)
        {
            reset();
            showdataTDP();
            dinhdangluoi();
            LoadMaP();

        }

        private void comboBoxMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenP = comboBoxMP.Text;
        }
    }
}
