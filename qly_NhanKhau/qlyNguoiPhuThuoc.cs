using qly_NhanKhau.Datas;
using qly_NhanKhau.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace qly_NhanKhau
{
    public partial class qlyNguoiPhuThuoc : Form
    {
        public qlyNguoiPhuThuoc()
        {
            InitializeComponent();

        }
        string soNK;
        dataqlyNguoiPhuThuoc dtNPT= new dataqlyNguoiPhuThuoc();
        private void btnThem_Click(object sender, EventArgs e)
        {

            objNguoiPhuThuoc npt = new objNguoiPhuThuoc();
            npt.soNPT = txtSNPT.Text;
            //  npt.soNhanKhau = comboBoxSNK.SelectedValue.ToString();
            if (soNK == comboBoxSNK.Text)
            {
                npt.soNhanKhau = comboBoxSNK.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không sửa số nhân khẩu");
            }
            npt.TenNguoiPhuThuoc = txtTenNPT.Text;
            npt.ngaysinhNPT = DateTime.Parse(dateTimePickerNS.Text);

            if (radioNam.Checked == true)
            {
                npt.gtNPT = "Nam";
            }
            if (radioNu.Checked == true)
            {
                npt.gtNPT = "Nữ";
            }
            npt.queQuanNPT = txtqueQuan.Text;
            npt.CMND_NPT = txtCMND.Text;
            npt.ngheNghiepNPT = txtNgheNghiep.Text;
            npt.quanheVoiChuHo = txtQheCh.Text;
            int i = dtNPT.insert_NPT(npt);
            if (i > 0)
            {
                MessageBox.Show("Thêm người phụ thuộc thành công");
                showdataNPT();
                reset_NPT();
            }
            else
                MessageBox.Show("Thêm người phụ thuộc thất bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            objNguoiPhuThuoc npt = new objNguoiPhuThuoc();
            npt.soNPT = txtSNPT.Text;
            // npt.soNhanKhau = comboBoxSNK.SelectedValue.ToString();
            if (soNK == comboBoxSNK.Text)
            {
                npt.soNhanKhau = comboBoxSNK.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không sửa số nhân khẩu");
            }
            npt.TenNguoiPhuThuoc = txtTenNPT.Text;
            npt.ngaysinhNPT = DateTime.Parse(dateTimePickerNS.Text);

            if (radioNam.Checked == true)
            {
                npt.gtNPT = "Nam";
            }
            if (radioNu.Checked == true)
            {
                npt.gtNPT = "Nữ";
            }
            npt.queQuanNPT = txtqueQuan.Text;
            npt.CMND_NPT = txtCMND.Text;
            npt.ngheNghiepNPT = txtNgheNghiep.Text;
            npt.quanheVoiChuHo = txtQheCh.Text;
            int i = dtNPT.update_NPT(npt);
            if (i > 0)
            {
                MessageBox.Show("Sửa người phụ thuộc thành công");
                showdataNPT();
                reset_NPT();
            }
            else
                MessageBox.Show("Sửa người phụ thuộc thất bại");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            objNguoiPhuThuoc npt = new objNguoiPhuThuoc();
            npt.soNPT = txtSNPT.Text;
          
            int i = dtNPT.delete_NPT(npt);
            if (i > 0)
            {
                MessageBox.Show("Xoá người phụ thuộc thành công");
                showdataNPT();
                reset_NPT();
                txtSNPT.Focus();
            }
            else
                MessageBox.Show("Xoá người phụ thuộc thất bại");
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            string filter = "select soNPT, NguoiPhuThuoc.soNK, hoTen, ngaySinh, gioitinh ,queQuanNPT,  ChungMinhNhanDan, ngheNghiepNPT, quanHeVoiChuHo from  nhanKhau, NguoiPhuThuoc where nhanKhau.soNK=NguoiPhuThuoc.soNK  ";
            if (!string.IsNullOrEmpty(txtSNPT.Text.Trim()))
            {
                filter += string.Format(" AND soNPT like N'%{0}%'", txtSNPT.Text);
            }

            if (!string.IsNullOrEmpty(txtTenNPT.Text.Trim()))
            {
                filter += string.Format(" AND hoTen like N'%{0}%'", txtTenNPT.Text);
            }

            if (radioNam.Checked == true)
            {

                filter += "AND gioiTinh = '" + "Nam" + "'";
            }
            if (radioNu.Checked == true)

                filter += "AND gioiTinh = N'" + "Nữ" + "'";

            if (!string.IsNullOrEmpty(txtqueQuan.Text.Trim()))
            {
                filter += string.Format(" AND queQuanNPT like N'%{0}%'", txtqueQuan.Text);

            }
            if (!string.IsNullOrEmpty(txtCMND.Text.Trim()))
            {
                filter += string.Format(" AND ChungMinhNhanDan like N'%{0}%'", txtCMND.Text);

            }
            if (!string.IsNullOrEmpty(txtNgheNghiep.Text.Trim()))
            {
                filter += string.Format(" AND ngheNghiepNPT like N'%{0}%'", txtNgheNghiep.Text);

            }
            if (!string.IsNullOrEmpty(txtQheCh.Text.Trim()))
            {
                filter += string.Format(" AND quanHeVoiChuHo like N'%{0}%'", txtQheCh.Text);

            }

            if (comboBoxSNK.Text != "")
            {
                filter += " AND NguoiPhuThuoc.soNK = '" + comboBoxSNK.SelectedValue + "'";
            }
            DataTable dt = dtNPT.search_NPT(filter);
            dataGridViewNPT.DataSource = dt;

        }
        private void format_NPT()
        {
            dataGridViewNPT.ReadOnly = true;
            dataGridViewNPT.Columns[0].HeaderText = "Số người phụ thuộc";
            dataGridViewNPT.Columns[1].HeaderText = "Số nhân khẩu";
            dataGridViewNPT.Columns[2].HeaderText = "Tên người phụ thuộc";
            dataGridViewNPT.Columns[3].HeaderText = "Ngày sinh";
            dataGridViewNPT.Columns[4].HeaderText = "Giới tính";
            dataGridViewNPT.Columns[5].HeaderText = "Quê quán";
            dataGridViewNPT.Columns[6].HeaderText = "CMND";
            dataGridViewNPT.Columns[7].HeaderText = "Nghề nghiệp";
            dataGridViewNPT.Columns[8].HeaderText = "Quan hệ với chủ hộ";
         

        }
        private void showdataNPT()
        {
            DataTable data = dtNPT.load_NPT();
            dataGridViewNPT.DataSource = data;
        }
        private void Load_soNK()
        {
            DataTable daTable = dtNPT.loadSoNK();
            comboBoxSNK.DataSource = daTable;
            comboBoxSNK.DisplayMember = "soNK";
            comboBoxSNK.ValueMember = "soNK";
        }
        private void reset_NPT()
        {
            txtSNPT.Text = "";
            txtTenNPT.Text = "";
            txtCMND.Text = "";
            txtqueQuan.Text = "";
            txtNgheNghiep.Text = "";
            txtQheCh.Text = "";

        }
        private void dataGridViewNPT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSNPT.Text = dataGridViewNPT.CurrentRow.Cells[0].Value.ToString();
            comboBoxSNK.Text = dataGridViewNPT.CurrentRow.Cells[1].Value.ToString();
            txtTenNPT.Text = dataGridViewNPT.CurrentRow.Cells[2].Value.ToString();
            dateTimePickerNS.Text = dataGridViewNPT.CurrentRow.Cells[3].Value.ToString();
            string gt = dataGridViewNPT.CurrentRow.Cells[4].Value.ToString();
            if (gt == "Nam")
            {
                radioNam.Checked = true;
            }

            if (gt == "Nữ")
            {
                radioNu.Checked = true;
            }
            txtqueQuan.Text = dataGridViewNPT.CurrentRow.Cells[5].Value.ToString();
            txtCMND.Text = dataGridViewNPT.CurrentRow.Cells[6].Value.ToString();
            txtNgheNghiep.Text = dataGridViewNPT.CurrentRow.Cells[7].Value.ToString();
            txtQheCh.Text = dataGridViewNPT.CurrentRow.Cells[8].Value.ToString();
           
        }

        private void qlyNguoiPhuThuoc_Load(object sender, EventArgs e)
        {
            showdataNPT();
            format_NPT();
            Load_soNK();

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
        private void btnBC_Click(object sender, EventArgs e)
        {
            string filter = " { nhanKhau.soNK } ={ NguoiPhuThuoc.soNK }";
            if (!string.IsNullOrEmpty(txtSNPT.Text.Trim()))
            {
                
                filter += "AND {NguoiPhuThuoc.soNPT} LIKE '*" + txtSNPT.Text.Trim() + "*'";
            }

            if (!string.IsNullOrEmpty(txtTenNPT.Text.Trim()))
            {
                
                filter += "AND {NguoiPhuThuoc.hoTen} LIKE '*" + txtTenNPT.Text.Trim() + "*'";
            }

            if (radioNam.Checked == true)
            {

                filter += "AND {NguoiPhuThuoc.gioiTinh} = '" + "Nam" + "'";
            }
            if (radioNu.Checked == true)

                filter += "AND {NguoiPhuThuoc.gioiTinh} = '" + "Nữ" + "'";


            if (!string.IsNullOrEmpty(txtCMND.Text.Trim()))
            {
         
                filter += "AND {NguoiPhuThuoc.ChungMinhNhanDan} LIKE '*" + txtCMND.Text.Trim() + "*'";

            }
            if (!string.IsNullOrEmpty(txtNgheNghiep.Text.Trim()))
            {
               
                filter += "AND {NguoiPhuThuoc.ngheNghiepNPT} LIKE '*" + txtNgheNghiep.Text.Trim() + "*'";

            }
            if (!string.IsNullOrEmpty(txtQheCh.Text.Trim()))
            {
               
                filter += "AND {NguoiPhuThuoc.quanHeVoiChuHo} LIKE '*" + txtQheCh.Text.Trim() + "*'";

            }

        
            if (comboBoxSNK.Text != "")
            {
                filter += " AND {NguoiPhuThuoc.soNK} = '" + comboBoxSNK.SelectedValue + "'";
            }

            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("nguoiPhuThuoc.rpt", filter, "DANH SÁCH NGƯỜI PHỤ THUỘC");
            reportViewerForm.Activate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset_NPT();
            showdataNPT();
            format_NPT();
            Load_soNK();
        }

        private void comboBoxSNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            soNK = comboBoxSNK.Text;
        }
    }
}
