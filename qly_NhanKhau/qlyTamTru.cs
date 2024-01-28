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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace qly_NhanKhau
{
    public partial class qlyTamTru : Form
    {
        public qlyTamTru()
        {
            InitializeComponent();
        }
        string tenP;
        dataqlyTamTru dttt = new dataqlyTamTru();
        private void format_TT()
        {
            dataGridViewTT.ReadOnly = true;
            dataGridViewTT.Columns[0].HeaderText = "Số tạm trú";
            dataGridViewTT.Columns[1].HeaderText = "Mã phường";
            dataGridViewTT.Columns[2].HeaderText = "Tên phường";
            dataGridViewTT.Columns[3].HeaderText = "Họ tên";
            dataGridViewTT.Columns[4].HeaderText = "CMND";
            dataGridViewTT.Columns[5].HeaderText = "Điện thoại";
            dataGridViewTT.Columns[6].HeaderText = "Ngày tạm trú";

        }

        private void reset_TT()
        {
            txtSoTT.Text = "";
            txtTen.Text = "";
            txtCMND.Text = "";
            txtDt.Text = "";
            dateTimeNgayTT.Text = "";

        }
        private void showDataTT()
        {
            DataTable data = dttt.load_TT();
            dataGridViewTT.DataSource = data;
        }
        private void loadmaP()
        {
            DataTable dt = dttt.load_MaP();
            comboBoxMP.DataSource = dt;
            comboBoxMP.DisplayMember = "tenphuong";
            comboBoxMP.ValueMember = "maphuong";

        }

        private void qlyTamTru_Load(object sender, EventArgs e)
        {
            showDataTT();
            format_TT();
            loadmaP();
        }

        private void dataGridViewTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoTT.Text = dataGridViewTT.CurrentRow.Cells[0].Value.ToString();
            comboBoxMP.Text = dataGridViewTT.CurrentRow.Cells[2].Value.ToString();
            txtTen.Text = dataGridViewTT.CurrentRow.Cells[3].Value.ToString();
            txtCMND.Text = dataGridViewTT.CurrentRow.Cells[4].Value.ToString();
            txtDt.Text = dataGridViewTT.CurrentRow.Cells[5].Value.ToString();
            dateTimeNgayTT.Text = dataGridViewTT.CurrentRow.Cells[6].Value.ToString();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            objTamTru tt = new objTamTru();
            tt.soTamTru = txtSoTT.Text;
            // tt.maPh = comboBoxMP.SelectedValue.ToString();
            if (tenP == comboBoxMP.Text)
            {
                tt.maPh = comboBoxMP.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không sửa số nhân khẩu");
            }
            tt.ten = txtTen.Text;
            tt.CMND = txtCMND.Text;
            tt.Dthoai = txtDt.Text;
            tt.ngayTT = DateTime.Parse(dateTimeNgayTT.Text);
            int i = dttt.insertTT(tt);
            if (i > 0)
            {
                MessageBox.Show("Thêm tạm trú thành công");
                showDataTT();
                reset_TT();
            }
            else
                MessageBox.Show("Thêm tạm trú thất bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            objTamTru tt = new objTamTru();
            tt.soTamTru = txtSoTT.Text;
            //tt.maPh = comboBoxMP.SelectedValue.ToString();
            if (tenP == comboBoxMP.Text)
            {
                tt.maPh = comboBoxMP.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không Sửa Tên");
            }
            tt.ten = txtTen.Text;
            tt.CMND = txtCMND.Text;
            tt.Dthoai = txtDt.Text;
            tt.ngayTT = DateTime.Parse(dateTimeNgayTT.Text);
            int i = dttt.updateTT(tt);
            if (i > 0)
            {
                MessageBox.Show("Sửa tạm trú thành công");
                showDataTT();
                reset_TT();
            }
            else
                MessageBox.Show("Sửa tạm trú thất bại");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            objTamTru tt = new objTamTru();
            tt.soTamTru = txtSoTT.Text;
           
            int i = dttt.deleteTT(tt);
            if (i > 0)
            {
                MessageBox.Show("Xoá tạm trú thành công");
                showDataTT();
                reset_TT();
            }
            else
                MessageBox.Show("Xoá tạm trú thất bại");
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            string filter = "select soTT, tamTru.maP,tblPhuong.tenphuong, hovaten, CMND, DT, ngaytamtru from  tamTru, tblPhuong where tamTru.maP=tblPhuong.maphuong ";
            if (!string.IsNullOrEmpty(txtSoTT.Text.Trim()))
            {
                filter += string.Format(" AND soTT like N'%{0}%'", txtSoTT.Text);
            }

            if (!string.IsNullOrEmpty(txtTen.Text.Trim()))
            {
                filter += string.Format(" AND hovaten like N'%{0}%'", txtTen.Text);
            }
            if (!string.IsNullOrEmpty(txtCMND.Text.Trim()))
            {
                filter += string.Format(" AND CMND like N'%{0}%'", txtCMND.Text);

            }
            if (!string.IsNullOrEmpty(txtDt.Text.Trim()))
            {
                filter += string.Format(" AND DT like N'%{0}%'", txtDt.Text);

            }
            if (comboBoxMP.Text != "")
            {
                filter += " AND  tamTru.maP  = '" + comboBoxMP.SelectedValue + "'";

            }
           // filter += string.Format("AND tamTru.maP = N'{0}'", comboBoxMP.SelectedValue);
            DataTable dt = dttt.searchTT(filter);
            dataGridViewTT.DataSource = dt;

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
            string filter = " { tamTru.maP} = { tblPhuong.maphuong } ";
            if (!string.IsNullOrEmpty(txtSoTT.Text.Trim()))
            {
               
                filter += "AND {tamTru.soTT} LIKE '*" + txtSoTT.Text.Trim() + "*'";
            }

            if (!string.IsNullOrEmpty(txtTen.Text.Trim()))
            {
             
                filter += "AND {tamTru.hovaten} LIKE '*" + txtTen.Text.Trim() + "*'";

            }
            if (!string.IsNullOrEmpty(txtCMND.Text.Trim()))
            {

              
                filter += "AND {tamTru.CMND} LIKE '*" + txtCMND.Text.Trim() + "*'";

            }
            if (!string.IsNullOrEmpty(txtDt.Text.Trim()))
            {
                
                filter += "AND {tamTru.DT} LIKE '*" + txtDt.Text.Trim() + "*'";

            }

           
            if (comboBoxMP.Text != "")
            {
                filter += "AND {tamTru.maP} ='" + comboBoxMP.SelectedValue + "'";
            }
            //hien thi report
            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("tamTru.rpt", filter, "DANH SÁCH TẠM TRÚ");
            reportViewerForm.Activate();
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            reset_TT();
            showDataTT();
            format_TT();
            loadmaP();
        }

        private void comboBoxMP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenP = comboBoxMP.Text;
        }
    }
}
