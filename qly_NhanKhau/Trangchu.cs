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
    public partial class Trangchu : Form
    {
        public Trangchu()
        {
            InitializeComponent();
        }
        private Form findForm(string name)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                    return f;
            }
            return null;
        }
        private void phườngToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            Form f = findForm("qlyPhuong");
            Form sv = new qlyPhuong();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();
        }

        private void tổDânPhốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("qlyToDanPho");
            Form sv = new qlyToDanPho();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();
        }

        private void khaiSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("qlyKhaiSinh");
            Form sv = new qlyKhaiSinh();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();
        }

        private void nhânKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("qlyNhanKhau");
            Form sv = new qlyNhanKhau();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();
        }

        private void ngườiPhụThuộcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("qlyNguoiPhuThuoc");
            Form sv = new qlyNguoiPhuThuoc();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();
        }

        private void khaiTửToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form f = findForm("qlyKhaiTu");
            Form sv = new qlyKhaiTu();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();
        }

        private void tạmTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
          
            Form f = findForm("qlyTamTru");
            Form sv = new qlyTamTru();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();

        }

        private void tạmVắngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("qlyTamVang");
            Form sv = new qlyTamVang();
            if (f == null)
            {
                sv.MdiParent = this;
                sv.Show();
            }
            else
                sv.Activate();

        }

        private void Trangchu_Load(object sender, EventArgs e)
        {
        }
    }
}
