using CrystalDecisions.Shared;
using qly_NhanKhau.DATAobj;
using qly_NhanKhau.objqlyHK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace qly_NhanKhau
{
    public partial class qlyPhuong : Form
    {
        public qlyPhuong()
        {
            InitializeComponent();
        }


        dataqlyPhuong dtp = new dataqlyPhuong();


        private void dinhdangluoi()
        {
            dataGridViewPhuong.ReadOnly = true;
            dataGridViewPhuong.Columns[0].HeaderText = "Mã Phường";
            dataGridViewPhuong.Columns[1].HeaderText = "Tên Phường";
            dataGridViewPhuong.Columns[2].HeaderText = "Số Điện Thoại";
        }
        private void showdataP()
        {
            DataTable data = dtp.load_Phuong();
            dataGridViewPhuong.DataSource = data;
        }


        private void qlyPhuong_Load(object sender, EventArgs e)
        {

            showdataP();
            dinhdangluoi();


        }
        private void refmo()
        {
            textBoxMaP.Text = "";
            textBoxTenP.Text = "";
            textBoxSDTP.Text = "";
        }

        private void buttonThemP_Click(object sender, EventArgs e)
        {
            objPhuong ph = new objPhuong();
            ph.Map = textBoxMaP.Text;
            ph.Tenp = textBoxTenP.Text;
            ph.Ssdtp = textBoxSDTP.Text;
            if (textBoxTenP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên phường");
                return;
            }
            if (textBoxMaP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã phường");
                return;
            }

            int i = dtp.insert_Phuong(ph);
            if (i > 0)
            {
                MessageBox.Show("Thêm Phường thành công");
                showdataP();
                refmo();
            }
            else
            {
                MessageBox.Show("Thêm Phường thất bại");
            }

        }

        private void buttonSuaP_Click(object sender, EventArgs e)
        {
            objPhuong ph = new objPhuong();
            ph.Map = textBoxMaP.Text;
            ph.Tenp = textBoxTenP.Text;
            ph.Ssdtp = textBoxSDTP.Text;
            int i = dtp.update_Phuong(ph);
            if (i > 0)
            {
                MessageBox.Show("Sửa Phường thành công");
                showdataP();
                refmo();
            }
            else
            {
                MessageBox.Show("Sửa Phường thất bại");
            }
        }

        private void buttonXoaP_Click(object sender, EventArgs e)
        {
            objPhuong ph = new objPhuong();
            ph.Map = textBoxMaP.Text;

            int i = dtp.delete_Phuong(ph);
            if (i > 0)
            {
                MessageBox.Show("Xóa Phường thành công");
                showdataP();
                refmo();
            }
            else
            {
                MessageBox.Show("Xóa Phường thất bại");
            }
        }

        private void dataGridViewPhuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxMaP.Text = dataGridViewPhuong.CurrentRow.Cells[0].Value.ToString();
            textBoxTenP.Text = dataGridViewPhuong.CurrentRow.Cells[1].Value.ToString();
            textBoxSDTP.Text = dataGridViewPhuong.CurrentRow.Cells[2].Value.ToString();
        }

        private void buttonTimPh_Click(object sender, EventArgs e)
        {
            string filter = "select* from tblPhuong where maphuong in(select maphuong from tblPhuong)";
            if (!string.IsNullOrEmpty(textBoxMaP.Text.Trim()))
            {
                filter += string.Format("AND maphuong like N'%{0}%'", textBoxMaP.Text);
            }
            if (!string.IsNullOrEmpty(textBoxTenP.Text.Trim()))
            {
                filter += string.Format("AND tenphuong like N'%{0}%'", textBoxTenP.Text);
            }
            if (!string.IsNullOrEmpty(textBoxTenP.Text.Trim()))
            {
                filter += string.Format("AND sdtphuong like N'%{0}%'", textBoxSDTP.Text);
            }
            DataTable dt = dtp.search_Phuong(filter);
            dataGridViewPhuong.DataSource = dt;

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
            string filter = "{tblPhuong.maphuong} in {tblPhuong.maphuong} ";
            if (!string.IsNullOrEmpty(textBoxMaP.Text.Trim()))
                filter += "AND {tblPhuong.maphuong}  LIKE '*" + textBoxMaP.Text.Trim() + "*'";
            if (!string.IsNullOrEmpty(textBoxTenP.Text.Trim()))
                filter += "AND {tblPhuong.tenphuong}  LIKE '*" + textBoxTenP.Text.Trim() + "*'";
            if (!string.IsNullOrEmpty(textBoxSDTP.Text.Trim()))
                filter += "AND {tblPhuong.sdtphuong}  LIKE '*" + textBoxSDTP.Text.Trim() + "*'";

            //hien thi report
            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("Phuong.rpt", filter, "DANH SÁCH PHƯỜNG");
            reportViewerForm.Activate();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            refmo();
            showdataP();
            dinhdangluoi();
        }

        private void textBoxSDTP_Validating(object sender, CancelEventArgs e)
        {
            int number;
            string t = textBoxSDTP.Text;
            bool ck = int.TryParse(t, out number);
            if (ck)
            {
                if (number < 0)
                {
                    MessageBox.Show(textBoxSDTP, "So điện thoại phải >0");
                    return;
                }
            }
            else
            {
                MessageBox.Show(textBoxSDTP, "Không phải số");
                return;
            }
        }
    }
    }



