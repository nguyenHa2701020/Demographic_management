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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace qly_NhanKhau
{
    public partial class qlyKhaiTu : Form
    {
        public qlyKhaiTu()
        {
            InitializeComponent();
        }
        string sKS;
        dataqlyKhaiTu dtkt= new dataqlyKhaiTu();
        private void format_KT()
        {
            dataGridViewKT.ReadOnly = true;
            dataGridViewKT.Columns[0].HeaderText = "Số khai tử";
            dataGridViewKT.Columns[1].HeaderText = "Số khai sinh";
            dataGridViewKT.Columns[2].HeaderText = "Tên người khai";
            dataGridViewKT.Columns[3].HeaderText = "Quan hệ với người mất";
            dataGridViewKT.Columns[4].HeaderText = "Ngày mất";
            dataGridViewKT.Columns[5].HeaderText = "Lí do mất";
       
        }

        private void reset_KT()
        {
            txtsoKT.Text = "";
            txtNgKhai.Text = "";
            txtqhe.Text = "";
            txtlidoMat.Text = "";
            dateTimengayMat.Text = "";
          
        }
        private void showDataKT()
        {
            DataTable data = dtkt.load_KT();
            dataGridViewKT.DataSource = data;
        }
        private void loadsoKSinh()
        {
            DataTable dt = dtkt.load_soKS();
            comboBoxKS.DataSource = dt;
            comboBoxKS.DisplayMember = "soKS";
            comboBoxKS.ValueMember = "soKS";

        }
        private void qlyKhaiTu_Load(object sender, EventArgs e)
        {
            showDataKT();
            format_KT();
            loadsoKSinh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            objKhaiTu kt = new objKhaiTu();
            kt.soKhaiTu = txtsoKT.Text;
           // kt.soKhaiSinh = comboBoxKS.SelectedValue.ToString();
            if(sKS == comboBoxKS.Text)
            {
                kt.soKhaiSinh = comboBoxKS.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không sửa só khai sinh");
            }
            kt.nguoiKhai= txtNgKhai.Text;
            kt.quanheVsNgMat = txtqhe.Text;
            kt.ngayMat = DateTime.Parse(dateTimengayMat.Text);
            kt.lidoMat= txtlidoMat.Text;
            int i = dtkt.insertKT(kt);
            if (i > 0)
            {
                MessageBox.Show("Thêm khai tử thành công");
                showDataKT();
                reset_KT();
                txtsoKT.Focus();
            }
            else
                MessageBox.Show("Thêm khai tử thất bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            objKhaiTu kt = new objKhaiTu();
            kt.soKhaiTu = txtsoKT.Text;
            //    kt.soKhaiSinh = comboBoxKS.SelectedValue.ToString();
            if (sKS == comboBoxKS.Text)
            {
                kt.soKhaiSinh = comboBoxKS.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không sửa só khai sinh");
            }
            kt.nguoiKhai = txtNgKhai.Text;
            kt.quanheVsNgMat = txtqhe.Text;
            kt.ngayMat = DateTime.Parse(dateTimengayMat.Text);
            kt.lidoMat = txtlidoMat.Text;
            int i = dtkt.updateKT(kt);
            if (i > 0)
            {
                MessageBox.Show("Sửa khai tử thành công");
                showDataKT();
                reset_KT();
                txtsoKT.Focus();
            }
            else
                MessageBox.Show("Sửa khai tử thất bại");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            objKhaiTu kt = new objKhaiTu();
            kt.soKhaiTu = txtsoKT.Text;
          
            int i = dtkt.deleteKT(kt);
            if (i > 0)
            {
                MessageBox.Show("Xoá khai tử thành công");
                showDataKT();
                reset_KT();
                txtsoKT.Focus();
            }
            else
                MessageBox.Show("Xoá khai tử thất bại");
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string filter = "select soKT, khaiSinh.soKS,hotenNgKhai, Qhngmat, ngayMat, lidoMat from  khaiSinh,khaiTu where khaiTu.soKS=khaiSinh.soKS  ";
            if (!string.IsNullOrEmpty(txtsoKT.Text.Trim()))
            {
                filter += string.Format(" AND soKT like N'%{0}%'", txtsoKT.Text);
            }
            if (!string.IsNullOrEmpty(txtNgKhai.Text.Trim()))
            {
                filter += string.Format(" AND hotenNgKhai like N'%{0}%'", txtNgKhai.Text);
            }
            if (!string.IsNullOrEmpty(txtqhe.Text.Trim()))
            {
                filter += string.Format(" AND Qhngmat like N'%{0}%'", txtqhe.Text);
            }
            if (!string.IsNullOrEmpty(txtlidoMat.Text.Trim()))
            {
                filter += string.Format(" AND lidoMat like N'%{0}%'", txtlidoMat.Text);
            }
            if (comboBoxKS.Text != "")
            {
                filter += " AND khaiTu.soKS = '" + comboBoxKS.SelectedValue + "'";
            }
           // filter += string.Format("AND khaiTu.soKS = N'{0}'", comboBoxKS.SelectedValue);
            DataTable dt = dtkt.searchKT(filter);
            dataGridViewKT.DataSource = dt;

        }

        private void dataGridViewKT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsoKT.Text = dataGridViewKT.CurrentRow.Cells[0].Value.ToString();
            comboBoxKS.Text = dataGridViewKT.CurrentRow.Cells[1].Value.ToString();
            txtNgKhai.Text = dataGridViewKT.CurrentRow.Cells[2].Value.ToString();
            txtqhe.Text = dataGridViewKT.CurrentRow.Cells[3].Value.ToString();
            dateTimengayMat.Text = dataGridViewKT.CurrentRow.Cells[4].Value.ToString();
            txtlidoMat.Text = dataGridViewKT.CurrentRow.Cells[5].Value.ToString();
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
            string filter = " { khaiTu.soKS } = { khaiSinh.soKS } ";
            if (!string.IsNullOrEmpty(txtsoKT.Text.Trim()))
            {
                
                filter += "AND {khaiTu.soKT} LIKE '*" + txtsoKT.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtNgKhai.Text.Trim()))
            {
               
                filter += "AND {khaiTu.hotenNgKhai} LIKE '*" + txtNgKhai.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtqhe.Text.Trim()))
            {
              
                filter += "AND {khaiTu.Qhngmat} LIKE '*" + txtqhe.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtlidoMat.Text.Trim()))
            {
              
                filter += "AND {khaiTu.lidoMat} LIKE '*" + txtlidoMat.Text.Trim() + "*'";

            }
       
            if (comboBoxKS.Text != "")
            {
                filter += "AND {khaiTu.soKS} ='" + comboBoxKS.SelectedValue + "'";
            }
            //hien thi report
            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("khaiTu.rpt", filter, "DANH SÁCH KHAI TỬ");
            reportViewerForm.Activate();
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            reset_KT();
            showDataKT();
            format_KT();
            loadsoKSinh();
        }

        private void comboBoxKS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
