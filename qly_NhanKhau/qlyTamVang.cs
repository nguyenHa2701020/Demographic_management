using qly_NhanKhau.Datas;
using qly_NhanKhau.Objects;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace qly_NhanKhau
{
    public partial class qlyTamVang : Form
    {
        public qlyTamVang()
        {
            InitializeComponent();
        }
        string CMND, hoten;
    dataqlyTamVang dttv = new dataqlyTamVang();
    private void format_TV()
    {
        dataGridViewTV.ReadOnly = true;
        dataGridViewTV.Columns[0].HeaderText = "Số tạm vắng";
        dataGridViewTV.Columns[1].HeaderText = "số nhân khẩu";
        dataGridViewTV.Columns[2].HeaderText = "Họ tên";
        dataGridViewTV.Columns[3].HeaderText = "CMND";
        dataGridViewTV.Columns[4].HeaderText = "Điên thoại";
        dataGridViewTV.Columns[5].HeaderText = "Ngày tạm vắng";
        dataGridViewTV.Columns[6].HeaderText = "Lí do tạm vắng";

    }

    private void reset_TV()
    {
        txtsoTV.Text = "";
        textBoxCMND.Text = "";
        txtDT.Text = "";
        dateTimeNTV.Text = "";
        txtLiDo.Text = "";

    }
    private void showDataTV()
    {
        DataTable data = dttv.load_TV();
        dataGridViewTV.DataSource = data;
    }
    private void loadmsoNK()
    {
        DataTable dt = dttv.load_soNK();
        comboBoxsoNK.DataSource = dt;
        comboBoxsoNK.DisplayMember = "soNK";
        comboBoxsoNK.ValueMember = "soNK";

    }


    private void qlyTamVang_Load(object sender, EventArgs e)
        {
            
            
            showDataTV();
            format_TV();
            loadmsoNK();

        }

        private void dataGridViewTV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsoTV.Text = dataGridViewTV.CurrentRow.Cells[0].Value.ToString();
            comboBoxsoNK.Text = dataGridViewTV.CurrentRow.Cells[1].Value.ToString();
            comboBoxHTenNgPThuoc.Text = dataGridViewTV.CurrentRow.Cells[2].Value.ToString();
            textBoxCMND.Text = dataGridViewTV.CurrentRow.Cells[3].Value.ToString();
            txtDT.Text = dataGridViewTV.CurrentRow.Cells[4].Value.ToString();
            dateTimeNTV.Text = dataGridViewTV.CurrentRow.Cells[5].Value.ToString();
            txtLiDo.Text = dataGridViewTV.CurrentRow.Cells[6].Value.ToString();


        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            objTamVang tv = new objTamVang();
            tv.soTamVang = txtsoTV.Text;
            tv.masoNK = comboBoxsoNK.SelectedValue.ToString();
            
            if (hoten == comboBoxHTenNgPThuoc.Text)
            {
                tv.hoten = comboBoxHTenNgPThuoc.Text.ToString();
            }
            else
            {
                MessageBox.Show("Không Sửa Tên");
            }
            if (CMND == textBoxCMND.Text)
            {
                tv.CMND = textBoxCMND.Text;
            }
            else
            {
                MessageBox.Show("Không Sửa CMND");
            }
            tv.Dthoai = txtDT.Text;
            tv.ngayTV = DateTime.Parse(dateTimeNTV.Text);
            tv.lidoTV = txtLiDo.Text;
            int i = dttv.insertTV(tv);
            if (i > 0)
            {
                MessageBox.Show("Thêm tạm vắng thành công");
                showDataTV();
                reset_TV();
            }
            else
                MessageBox.Show("Thêm tạm vắng thất bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            objTamVang tv = new objTamVang();
            tv.soTamVang = txtsoTV.Text;
            tv.masoNK = comboBoxsoNK.SelectedValue.ToString();
            if (hoten == comboBoxHTenNgPThuoc.Text)
            {
                tv.hoten = comboBoxHTenNgPThuoc.Text.ToString();
            }
            else
            {
                MessageBox.Show("Không Sửa Tên");
            }
            if (CMND == textBoxCMND.Text)
            {
                tv.CMND = textBoxCMND.Text;
            }
            else
            {
                MessageBox.Show("Không Sửa CMND");
            }
            tv.Dthoai = txtDT.Text;
            tv.ngayTV = DateTime.Parse(dateTimeNTV.Text);
            tv.lidoTV = txtLiDo.Text;
            int i = dttv.updateTV(tv);
            if (i > 0)
            {
                MessageBox.Show("Sửa tạm vắng thành công");
                showDataTV();
                reset_TV();
            }
            else
                MessageBox.Show("Sửa tạm vắng thất bại");
        }

    
        private void btnXoa_Click(object sender, EventArgs e)
        {
            objTamVang tv = new objTamVang();
            tv.soTamVang = txtsoTV.Text;
       
            int i = dttv.deleteTV(tv);
            if (i > 0)
            {
                MessageBox.Show("Xoá tạm vắng thành công");
                showDataTV();
                reset_TV();
            }
            else
                MessageBox.Show("Xoá tạm vắng thất bại");
        }
    

        private void btnTK_Click(object sender, EventArgs e)
        {
            string filter = "select soTV, nhanKhau.soNK,hoten, CMNDan, dienthoai, ngaytamvang ,lidotamvang from  tamVang,nhanKhau where tamVang.soNK=nhanKhau.soNK ";
            if (!string.IsNullOrEmpty(txtsoTV.Text.Trim()))
            {
                filter += string.Format(" AND soTV like N'%{0}%'", txtsoTV.Text);
            }

            if (comboBoxHTenNgPThuoc.Text != "")
            {
                filter += "AND tamVang.hoten = N'" + comboBoxHTenNgPThuoc.Text + "'";
            }
           if (!string.IsNullOrEmpty(textBoxCMND.Text.Trim()))
           {
                filter += string.Format(" AND CMNDan like N'%{0}%'", textBoxCMND.Text);

            }

            if (!string.IsNullOrEmpty(txtDT.Text.Trim()))
            {
                filter += string.Format(" AND dienthoai like N'%{0}%'", txtDT.Text);

            }
            if (!string.IsNullOrEmpty(txtLiDo.Text.Trim()))
            {
                filter += string.Format(" AND lidotamvang like N'%{0}%'", txtLiDo.Text);

            }
            if (comboBoxsoNK.Text != "")
            {
                filter += " AND  tamVang.soNK  = '" + comboBoxsoNK.Text + "'";

            }
         
            DataTable dt = dttv.searchTV(filter);
            dataGridViewTV.DataSource = dt;
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

            string filter = " { tamVang.soNK } = { nhanKhau.soNK }";
            if (!string.IsNullOrEmpty(txtsoTV.Text.Trim()))
            {
         
                filter += "AND {tamVang.soTV} LIKE '*" + txtsoTV.Text.Trim() + "*'";
            }

            if (comboBoxHTenNgPThuoc.Text!="")
            {
               
                filter += "AND {tamVang.hoTen} = '" + comboBoxHTenNgPThuoc.Text + "'";
            }
            if (!string.IsNullOrEmpty(textBoxCMND.Text.Trim()))
            {
               filter += "AND {tamVang.CMNDan} LIKE '*" + textBoxCMND.Text.Trim() + "*'";

           }
            if (!string.IsNullOrEmpty(txtDT.Text.Trim()))
            {
                
                filter += "AND {tamVang.dienthoai} LIKE '*" + txtDT.Text.Trim() + "*'";


            }
            if (!string.IsNullOrEmpty(txtLiDo.Text.Trim()))
            {
                
                filter += "AND {tamVang.lidotamvang} LIKE '*" + txtLiDo.Text.Trim() + "*'";


            }
            if (comboBoxsoNK.Text != "")
            {
                filter += "AND {tamVang.soNK} ='" + comboBoxsoNK.SelectedValue + "'";
            }
           
            //hien thi report
            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("tamVang.rpt", filter, "DANH SÁCH TẠM VẮNG");
            reportViewerForm.Activate();
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            reset_TV();
            showDataTV();
            format_TV();
            loadmsoNK();
        }

        private void comboBoxsoNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            string MaNK;
            MaNK = comboBoxsoNK.SelectedValue.ToString();
            DataTable dt = dttv.load_NgPhuThuoc(MaNK);
            comboBoxHTenNgPThuoc.DataSource= dt;
            comboBoxHTenNgPThuoc.ValueMember = "soNPT";
            comboBoxHTenNgPThuoc.DisplayMember = "hoTen";
            hoten = comboBoxHTenNgPThuoc.Text;
        }

        private void comboBoxHTenNgPThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name=dttv.loadCMND_ngphuThuoc(comboBoxHTenNgPThuoc.SelectedValue.ToString());
            textBoxCMND.Text = name;
            CMND = name;
        }
    }
}
