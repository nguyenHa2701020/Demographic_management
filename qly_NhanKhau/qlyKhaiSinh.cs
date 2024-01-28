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
    public partial class qlyKhaiSinh : Form
    {
        public qlyKhaiSinh()
        {
            InitializeComponent();
        }
        string tenP;
        dataqlyKhaiSinh dtks= new dataqlyKhaiSinh();

        private void dataGridViewKS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoKS.Text= dataGridViewKS.CurrentRow.Cells[0].Value.ToString();
            comboBoxmaphuong.Text = dataGridViewKS.CurrentRow.Cells[2].Value.ToString();
            txtHoTen.Text = dataGridViewKS.CurrentRow.Cells[3].Value.ToString();
            dateTimeNS.Text = dataGridViewKS.CurrentRow.Cells[4].Value.ToString();
            string gt = dataGridViewKS.CurrentRow.Cells[5].Value.ToString();
            if(gt=="Nam")
            {
                radioButton1.Checked = true;
            }

            if (gt == "Nữ")
            {
                radioButton2.Checked = true;
            }
            txtNoiSinh.Text = dataGridViewKS.CurrentRow.Cells[6].Value.ToString();
            txtquoctich.Text = dataGridViewKS.CurrentRow.Cells[7].Value.ToString();
            txtCha.Text = dataGridViewKS.CurrentRow.Cells[8].Value.ToString();
            txtMe.Text = dataGridViewKS.CurrentRow.Cells[9].Value.ToString();
            txtTenNgKhai.Text = dataGridViewKS.CurrentRow.Cells[10].Value.ToString();

        }
        private void format_KS()
        {
            dataGridViewKS.ReadOnly = true;
            dataGridViewKS.Columns[0].HeaderText = "Số khai sinh";
            dataGridViewKS.Columns[1].HeaderText = "Mã phường";
            dataGridViewKS.Columns[2].HeaderText = "Tên phường";
            dataGridViewKS.Columns[3].HeaderText = "Họ tên";
            dataGridViewKS.Columns[4].HeaderText = "Ngày sinh";
            dataGridViewKS.Columns[5].HeaderText = "Giới tính";
            dataGridViewKS.Columns[6].HeaderText = "Nơi sinh";
            dataGridViewKS.Columns[7].HeaderText = "Quốc tịch";
            dataGridViewKS.Columns[8].HeaderText = "Họ tên cha";
            dataGridViewKS.Columns[9].HeaderText = "Họ tên mẹ";
            dataGridViewKS.Columns[10].HeaderText = "Tên người khai";
        }
        private void reset_KS()
        {
            txtSoKS.Text = "";
            txtHoTen.Text = "";
            dateTimeNS.Text = "";
            
            txtNoiSinh.Text = "";
            txtquoctich.Text = "";
            txtCha.Text = "";
            txtMe.Text = "";
            txtTenNgKhai.Text = "";
           
        }
        private void showDataKS()
        {
            DataTable data=dtks.load_KS();
            dataGridViewKS.DataSource = data;
        }

        private void qlyKhaiSinh_Load(object sender, EventArgs e)
        {
            txtSoKS.Focus();
            showDataKS();
            format_KS();
            loadmaPh();
            

        }
        private void loadmaPh()
        {
            
            DataTable dt= dtks.loadMaPh();
            comboBoxmaphuong.DataSource= dt;
            comboBoxmaphuong.DisplayMember = "tenphuong";
            comboBoxmaphuong.ValueMember = "maphuong";
         
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            objKhaiSinh ks= new objKhaiSinh();
            ks.SoKhaiSinh = txtSoKS.Text;
        //    ks.maPh = comboBoxmaphuong.SelectedValue.ToString();
            if (tenP == comboBoxmaphuong.Text)
            {
                ks.maPh = comboBoxmaphuong.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không Sửa Tên");
            }
            ks.Hoten = txtHoTen.Text;
            ks.ngaysinh= DateTime.Parse(dateTimeNS.Text);
            
            if (radioButton1.Checked==true)
            {
                ks.gt = "Nam";
            }
            if (radioButton2.Checked == true)
            {
                ks.gt = "Nữ";
            }
            
            ks.noisinh= txtNoiSinh.Text;
            ks.quocTich = txtquoctich.Text;
            ks.HoTenCha = txtCha.Text;
            ks.HotenMe= txtMe.Text;
            ks.HotenNgKai= txtTenNgKhai.Text;
            int i = dtks.insert_KS(ks);
            if (i > 0)
            {
                MessageBox.Show("Thêm khai sinh thành công");
                showDataKS();
                reset_KS();
                txtSoKS.Focus();
            }
            else
                MessageBox.Show("Thêm khai sinh thất bại");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            objKhaiSinh ks = new objKhaiSinh();
            ks.SoKhaiSinh = txtSoKS.Text;
           // ks.maPh = comboBoxmaphuong.SelectedValue.ToString();
            if (tenP == comboBoxmaphuong.Text)
            {
                ks.maPh = comboBoxmaphuong.SelectedValue.ToString();
            }
            else
            {
                MessageBox.Show("Không Sửa Tên");
            }
            ks.Hoten = txtHoTen.Text;
            ks.ngaysinh = DateTime.Parse(dateTimeNS.Text);
         
            if (radioButton1.Checked)
            {
                ks.gt = "Nam";
            }
            else
                ks.gt = "Nữ";
            ks.noisinh = txtNoiSinh.Text;
            ks.quocTich = txtquoctich.Text;
            ks.HoTenCha = txtCha.Text;
            ks.HotenMe = txtMe.Text;
            ks.HotenNgKai = txtTenNgKhai.Text;
            int i = dtks.update_KS(ks);
            if (i > 0)
            {
                MessageBox.Show("Sửa khai sinh thành công");
                showDataKS();
                reset_KS();
                txtSoKS.Focus();
            }
            else
                MessageBox.Show("Sửa khai sinh thất bại");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            objKhaiSinh ks = new objKhaiSinh();
            ks.SoKhaiSinh = txtSoKS.Text;
          
            int i = dtks.delete_KS(ks);
            if (i > 0)
            {
                MessageBox.Show("Xoá khai sinh thành công");
                showDataKS();
                reset_KS();
                txtSoKS.Focus();
            }
            else
                MessageBox.Show("Xoá khai sinh thất bại");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = " select soKS, khaiSinh.maPhuong,tblPhuong.tenphuong, hoten, ngaySinh, gioiTinh, noiSinh,quocTich,  hoTenCha,hoTenMe, nguoiDiKhai from  khaiSinh, tblPhuong where khaiSinh.maPhuong=tblPhuong.maphuong ";
            if (!string.IsNullOrEmpty(txtSoKS.Text.Trim()))
            {
                filter += string.Format(" AND soKS like N'%{0}%'", txtSoKS.Text);
            }

            if (!string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
                filter += string.Format(" AND hoten like N'%{0}%'", txtHoTen.Text);
            }
         
            if (!string.IsNullOrEmpty(txtNoiSinh.Text.Trim()))
            {
                filter += string.Format(" AND noiSinh like N'%{0}%'", txtNoiSinh.Text);

            }
            if (!string.IsNullOrEmpty(txtquoctich.Text.Trim()))
            {
                filter += string.Format(" AND quocTich like N'%{0}%'", txtquoctich.Text);
            }
            if (!string.IsNullOrEmpty(txtCha.Text.Trim()))
            {
                filter += string.Format(" AND hoTenCha like N'%{0}%'", txtCha.Text);
            }
            if (!string.IsNullOrEmpty(txtMe.Text.Trim()))
            {
                filter += string.Format(" AND hoTenMe like N'%{0}%'", txtMe.Text);
            }
            if (!string.IsNullOrEmpty(txtTenNgKhai.Text.Trim()))
            {
                filter += string.Format(" AND nguoiDiKhai like N'%{0}%'", txtTenNgKhai.Text);
            }


            if (radioButton1.Checked == true)
            {

                filter += " AND gioiTinh = '" + "Nam" + "'";
            }


            if (radioButton2.Checked == true)
            {

                filter += " AND gioiTinh = N'" + "Nữ" + "'";

            }


                 if (comboBoxmaphuong.Text != "")
               {
                    filter += " AND  khaiSinh.maPhuong  = '" + comboBoxmaphuong.SelectedValue + "'";

                 }
            //filter += string.Format("AND khaiSinh.maPhuong = N'{0}'", comboBoxmaphuong.SelectedValue);


            DataTable dt = dtks.search_KS(filter);
            dataGridViewKS.DataSource = dt;

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
            string filter = " { khaiSinh.maPhuong } = { tblPhuong.maphuong } ";
            if (!string.IsNullOrEmpty(txtSoKS.Text.Trim()))
            {
                filter += "AND {khaiSinh.soKS} LIKE '*" + txtSoKS.Text.Trim() + "*'";
            }

            if (!string.IsNullOrEmpty(txtHoTen.Text.Trim()))
            {
     
                filter += "AND {khaiSinh.hoten} LIKE '*" + txtHoTen.Text.Trim() + "*'";
            }

            if (!string.IsNullOrEmpty(txtNoiSinh.Text.Trim()))
            {
                filter += "AND {khaiSinh.noiSinh} LIKE '*" + txtNoiSinh.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtquoctich.Text.Trim()))
            {
         
                filter += "AND {khaiSinh.quocTich} LIKE '*" + txtquoctich.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtCha.Text.Trim()))
            {
                
                filter += "AND {khaiSinh.hoTenCha} LIKE '*" + txtCha.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtMe.Text.Trim()))
            {
              
                filter += "AND {khaiSinh.hoTenMe} LIKE '*" + txtMe.Text.Trim() + "*'";
            }
            if (!string.IsNullOrEmpty(txtTenNgKhai.Text.Trim()))
            {
               
                filter += "AND {khaiSinh.nguoiDiKhai} LIKE '*" + txtTenNgKhai.Text.Trim() + "*'";
            }

            
                if (radioButton1.Checked == true)
                {

                    filter += "AND {khaiSinh.gioiTinh} = '" + "Nam" + "'";
                }
            
         
                if (radioButton2.Checked == true)
                {

                    filter += "AND {khaiSinh.gioiTinh} = '" + "Nữ" + "'";

                }
            

            if (comboBoxmaphuong.Text != "")
            {
                filter += " AND {khaiSinh.maPhuong} = '" + comboBoxmaphuong.SelectedValue + "'";

            }
            
            
            //hien thi report
            BaoCao reportViewerForm = findOpenedForm("BaoCao") as BaoCao;
            if (reportViewerForm == null)
                reportViewerForm = new BaoCao();
            reportViewerForm.MdiParent = this.ParentForm;
            reportViewerForm.Show();
            reportViewerForm.ShowReport("khaiSinh.rpt", filter, "DANH SÁCH KHAI SINH");
            reportViewerForm.Activate();
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            reset_KS();
            txtSoKS.Focus();
            showDataKS();
            format_KS();
            loadmaPh();
        }

        private void comboBoxmaphuong_SelectedValueChanged(object sender, EventArgs e)
        {
            tenP= comboBoxmaphuong.Text;
        }
    }
}
