using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qly_NhanKhau
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            
            if(txtUser.Text=="")
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống");
            }
            else
            {
                if(txtpass.Text=="")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống");
                }
                else
                {
                    if (txtUser.Text == "Admin")
                    {
                        if(txtpass.Text=="123456")
                        {
                            Trangchu tc= new Trangchu();
                            tc.Show();
                            tc.Activate();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sai mật khẩu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập");
                    }
                
                }
            }

        }
    }
}
