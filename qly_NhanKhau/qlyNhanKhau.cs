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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace qly_NhanKhau
{
    public partial class qlyNhanKhau : Form
    {
        public qlyNhanKhau()
        {
            InitializeComponent();
        }
        dataqlyNhanKhau dtnk= new dataqlyNhanKhau();
        string tenTDP;
        private void formatNK()
        {
            dataGridViewNK.ReadOnly = true;
            dataGridViewNK.Columns[0].HeaderText = "Số nhân khẩu";
            dataGridViewNK.Columns[1].HeaderText = "Mã tổ dân phố";
            dataGridViewNK.Columns[2].HeaderText = "Tên tổ dân phố";
            dataGridViewNK.Columns[3].HeaderText = "Tên chủ hộ";
            dataGridViewNK.Columns[4].HeaderText = "Chứng minh nhân dân";
            dataGridViewNK.Columns[5].HeaderText = "Nghề nghiệp";
            dataGridViewNK.Columns[6].HeaderText = "Quê quán";
        }
        private void showdataNK()
        {
            DataTable data = dtnk.load_NK();
            dataGridViewNK.DataSource = data;
        }

        private void qlyNhanKhau_Load(object sender, EventArgs e)
        {
            showdataNK();

            formatNK();
            LoadMaTDP();
        }
        private void LoadMaTDP()
        {
            DataTable daTable = dtnk.load_MaTDP();
            comboBoxMaTDP.DataSource = daTable;
            comboBoxMaTDP.DisplayMember = "tenToDP";
            comboBoxMaTDP.ValueMember = "maToDanPho";
        }
        private void reset()
        {
            txtsoNK.Text = "";
            txtTenCh.Text = "";
           txtCMND.Text = "";
            txtNNghiep.Text = "";
            txtquequan.Text = "";
        }
        private void dataGridViewNK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsoNK.Text = dataGridViewNK.CurrentRow.Cells[0].Value.ToString();
            comboBoxMaTDP.Text = dataGridViewNK.CurrentRow.Cells[2].Value.ToString();

            txtTenCh.Text = dataGridViewNK.CurrentRow.Cells[3].Value.ToString();

            txtCMND.Text = dataGridViewNK.CurrentRow.Cells[4].Value.ToString();
            txtNNghiep.Text = dataGridViewNK.CurrentRow.Cells[5].Value.ToString();

            txtquequan.Text = dataGridViewNK.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnInsertNk_Click(object sender, EventArgs e)
        {
            objNhanKhau nk = new objNhanKhau();
            nk.SoNK = txtsoNK.Text;
           // nk.maTDP = comboBoxMaTDP.SelectedValue.ToString();
            if (tenTDP == comboBoxMaTDP.Text)
            {
                nk.maTDP = comboBoxMaTDP.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không sửa tên tổ dân phố");
            }
            nk.TenCH = txtTenCh.Text;
            nk.CMNDan = txtCMND.Text;
            nk.NgheNghiep = txtNNghiep.Text;
            nk.queQuan = txtquequan.Text;
            int i = dtnk.insertNK(nk);
            if (i > 0)
            {
                MessageBox.Show("Thêm nhân khẩu thành công");
                showdataNK();
                reset();
            }
            else
                MessageBox.Show("Thêm nhân khẩu thất bại");
        }

        private void btnUpdateNK_Click(object sender, EventArgs e)
        {
            objNhanKhau nk = new objNhanKhau();
            nk.SoNK = txtsoNK.Text;
            //  nk.maTDP = comboBoxMaTDP.SelectedValue.ToString();
            if (tenTDP == comboBoxMaTDP.Text)
            {
                nk.maTDP = comboBoxMaTDP.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không sửa tên tổ dân phố");
            }
            nk.TenCH = txtTenCh.Text;
            nk.CMNDan = txtCMND.Text;
            nk.NgheNghiep = txtNNghiep.Text;
            nk.queQuan = txtquequan.Text;
            int i = dtnk.updateNK(nk);
            if (i > 0)
            {
                MessageBox.Show("Sửa nhân khẩu thành công");
                showdataNK();
                reset();
            }
            else
                MessageBox.Show("Sửa nhân khẩu thất bại");
        }

        private void btnDeleteNk_Click(object sender, EventArgs e)
        {
            objNhanKhau nk = new objNhanKhau();
            nk.SoNK = txtsoNK.Text;
           
            int i = dtnk.deleteNK(nk);
            if (i > 0)
            {
                MessageBox.Show("Xoá nhân khẩu thành công");
                showdataNK();
                reset();
            }
            else
                MessageBox.Show("Xoá nhân khẩu thất bại");

        }

        private void btnSearchNk_Click(object sender, EventArgs e)
        {
            string filter = "select soNK, nhanKhau.matodanpho,tbltoDanPho.tenToDP, hoTenChuHo, CMND, ngheNghiep, queQuan from  tbltoDanPho,nhanKhau where nhanKhau.matodanpho=tbltoDanPho.maToDanPho ";
            if (!string.IsNullOrEmpty(txtsoNK.Text.Trim()))
            {
                filter += string.Format("AND soNK like N'%{0}%'", txtsoNK.Text);
            }

            if (!string.IsNullOrEmpty(txtTenCh.Text.Trim()))
            {
                filter += string.Format("AND hoTenChuHo like N'%{0}%'", txtTenCh.Text);
            }
            if (!string.IsNullOrEmpty(txtCMND.Text.Trim()))
            {
                filter += string.Format("AND CMND like N'%{0}%'", txtCMND.Text);

            }
            if (!string.IsNullOrEmpty(txtNNghiep.Text.Trim()))
            {
                filter += string.Format("AND ngheNghiep like N'%{0}%'", txtNNghiep.Text);

            }
            if (!string.IsNullOrEmpty(txtquequan.Text.Trim()))
            {
                filter += string.Format("AND queQuan like N'%{0}%'", txtquequan.Text);

            }
            if (comboBoxMaTDP.Text != "")
            {
                filter += " AND  nhanKhau.matodanpho  = '" + comboBoxMaTDP.SelectedValue + "'";

            }

           // filter += string.Format("AND nhanKhau.matodanpho = N'{0}'", comboBoxMaTDP.SelectedValue);
            DataTable dt = dtnk.searchNK(filter);
            dataGridViewNK.DataSource = dt;

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
            string filter = " { nhanKhau.matodanpho} = { tbltoDanPho.maToDanPho } ";
            if (!string.IsNullOrEmpty(txtsoNK.Text.Trim()))
            {
                
                filter += "AND {nhanKhau.soNK} LIKE '*" + txtsoNK.Text.Trim() + "*'";
            }

            if (!string.IsNullOrEmpty(txtTenCh.Text.Trim()))
            {
                
                filter += "AND {nhanKhau.hoTenChuHo} LIKE '*" + txtTenCh.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtCMND.Text.Trim()))
            {
                
                filter += "AND {nhanKhau.CMND} LIKE '*" + txtCMND.Text.Trim() + "*'";

            }
            if (!string.IsNullOrEmpty(txtNNghiep.Text.Trim()))
            {
                
                filter += "AND {nhanKhau.ngheNghiep} LIKE '*" + txtNNghiep.Text.Trim() + "*'";

            }
            if (!string.IsNullOrEmpty(txtquequan.Text.Trim()))
            {
                
                filter += "AND {nhanKhau.queQuan} LIKE '*" + txtquequan.Text.Trim() + "*'";

            }
            if (comboBoxMaTDP.Text != "")
            {
                filter += "AND {nhanKhau.matodanpho} ='" + comboBoxMaTDP.SelectedValue + "'";
            }
            //hien thi report
            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("nhanKhau.rpt", filter, "DANH SÁCH TỔ DÂN PHỐ");
            reportViewerForm.Activate();

        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            reset();
            showdataNK();
            formatNK();
            LoadMaTDP();
        }

        private void comboBoxMaTDP_SelectedIndexChanged(object sender, EventArgs e)
        {
            tenTDP = comboBoxMaTDP.Text;
        }
    }
}
