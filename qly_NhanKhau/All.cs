using qly_NhanKhau.DATAobj;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using System.Xml.Linq;

namespace qly_NhanKhau
{
    internal class All
    {
        /*
         1, đổi mk
private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxp1 != textBoxp2)
            {
                MessageBox.Show("k dusng");
            }
            else
            {
                //1. goi connec
                //2. command=proc update
                //3. truyeefn parametter với uname  và pass1 
                //4. ktra execute >0==> Message Thành công
                
            }
        }
2, Đăng nhập quá 3 lần thì thông báo và khoá đăng nhập.
  string user;
        string pass;
        string role;

        int sousersai = 0;

        int solanSai;
        private DateTime dtUnLock = DateTime.MinValue;
        int saimax = 3;
        int delay = 1;
 
  private void btnDn_Click(object sender, EventArgs e)
        {
            user = txtUser.Text;
            pass = txtPass.Text;

            int check = check_User(user, pass);


            if (DateTime.Now < dtUnLock)
            {
                MessageBox.Show("Khoas");
                return;
            }
            else
            {
                if (check > 0)
                {
                    //solanSai = 0;
                    // eru.Remove(eru[i]);
                    dtUnLock = DateTime.MinValue;
                    MessageBox.Show("Đăng nhập thành công");
                    role = getRole(user, pass);

                    //hien us và tg dn
                    //filter={user.name}=user
                    string filter = "{user.name}=" + user;
                    //gọi  form báo cáo lên trèn filer report title

                    MDI mDI = new MDI();
                    mDI.getrole(role);
                    mDI.Show();
                    this.Hide();
                }
                else
                {
                    solanSai++;
                    MessageBox.Show("Thaast baimj");
                    if (solanSai >= saimax)
                    {
                        dtUnLock= DateTime.Now.AddMinutes(delay);
                        MessageBox.Show("Khoa 1 phut");
                    }
                }
            }
3. tìm theo tuôi nhập vào
3. đếm tgian Dang nhap
Stopwatch st = new Stopwatch();
 private void FormLogin_Load(object sender, EventArgs e)
        {
           
            st.Start();
        }

private void btnThoat_Click(object sender, EventArgs e)
        {
            //this. Close();
            st.Stop();
            TimeSpan tp = st.Elapsed;
            MessageBox.Show("Sau" + tp.ToString());
        }
4. validate năm sinh k qua htai nv k quá 18
private void dtNS_Validating(object sender, CancelEventArgs e)
        {
//ktra Ngay duoi htai
            DateTime dt = dtNS.Value;
            if (dt > DateTime.Now)
            {
                
                MessageBox.Show("Khong lon ngay HTai");
            }
//ktra tuoi <18
            TimeSpan tsp = DateTime.Now.Subtract(dt);

            if (tsp.TotalDays < 18 * 365)
            {
                MessageBox.Show("18!");
            }
        }
5. só hàng nhiều nhất report
6. trường phụ thuộc
private void dtNS_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dtNS.Value;
            TimeSpan tsp = DateTime.Now.Subtract(dt);
            int tuoi =(int) tsp.TotalDays / 365;
            labelTuoi.Text=tuoi.ToString();
        }
7. tìm KH mua nhiều t2
create proc tim2max
as
begin
declare c cursor SCROLL READ_ONLY for
select PK_iKhachhangID,sHoten, count(PK_iHoadonID) as'Tong Tien'
from tblKhachHang, tblHoadon
where tblKhachhang.PK_iKhachhangID=tblHoadon.FK_iKhachhangID
group by PK_iKhachhangID,sHoten
order by count(PK_iHoadonID) DESC
open c
fetch absolute 2 from c
close c
DEALLOCATE c
end

exec tim2max

private void button1_Click(object sender, EventArgs e)
        {

            // Tìm Lớn 2
            /*string cmd= "tim2max";


            DataTable dt = new DataTable();
            
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);

            gvBH.DataSource = dt;
    }
8. tìm tên người mua nhiếu nhất<select top1....order by desc|Nhiều nhất hoắc asc|ít nhất>
9. tìm sp giá<nhập vào và sắp xếp
10. ckeck mail
private void txtTCQ_Validating(object sender, CancelEventArgs e)
    {
        ErrorProvider er = new ErrorProvider();
        string email = txtTCQ.Text;
        if (!email.EndsWith("@gmail.com"))
        {
            er.SetError(txtTCQ, "khong phai mail");
        }
        else
        {
            er.SetError(txtTCQ, null);
        }
    }
11. check số lượng
private void txtDT_Validating(object sender, CancelEventArgs e)
    {
        int number;
        ErrorProvider er = new ErrorProvider();
        string t = txtDT.Text;
        bool ck = int.TryParse(t, out number);
        if (ck)
        {
            if (number < 0)
            {

                er.SetError(txtDT, "So phai >0");
                return;
            }
            else
            {
                er.Clear();
            }
        }
        else
        {
            //ErrorProvider er = new ErrorProvider();
            er.SetError(txtDT, "khong phai so");
            return;
        }

    }
12. in ds tổng k quá 15tr
13. tìm sp theo giá<giá nhập và sắp xếp
14. ch nhập text thì bton mờ
 private void Form1_Load(object sender, EventArgs e)
    {
        btnBaocao.Enabled = false;

    }
    private void txtHT_TextChanged(object sender, EventArgs e)
    {
        if (txtHT.Text == "")
        {
            btnBaocao.Enabled = false;
        }
        else
        {
            btnBaocao.Enabled = true;
        }
    }
15. hiện ds tuổi người trên 30

create proc tuoi30
as
begin
select*,datediff(year, tNgaysinh, getDate()) as 'Tuoit'from tblKhachhang
where datediff(year, tNgaysinh, getDate())>30
end
 //tìm kiếm
 string cmd = "tuoi30";


    DataTable dt = new DataTable();

    SqlCommand sc = new SqlCommand(cmd, con);
    sc.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(sc);
    sda.Fill(dt);

            gvBH.DataSource = dt;
//Báo cáo
string filter = " {tblKhachhang.PK_iKhachhangID} >0 and Year (CurrentDate)-Year ({tblKhachhang.tNgaysinh})>30"
16. 1nv k lập quá 3 HD
int demtk++;
 demtk++;
            if (demtk == 3)
            {
                MessageBox.Show("KTK");
                btnTK.Enabled = false;
            }
17.check trùng mã 
create proc maTrung
@name nvarchar(100)
as
begin
select COUNT(*) from Users
where userName = @name
end

 private int checkTrung(string user)
{
    //SqlConnection cnt = new SqlConnection(@"Data Source=ADMIN\\MAYCHU;Initial Catalog=db_Shop4Training;Integrated Security=True");
    string sql = "maTrung";
    SqlConnection cnt = new SqlConnection(connect);
    cnt.Open();
    SqlCommand con = new SqlCommand(sql, cnt);
    con.CommandType = CommandType.StoredProcedure;
    con.Parameters.AddWithValue("@name", user);

    int us = int.Parse(con.ExecuteScalar().ToString());
    return us;
}

private void button1_Click(object sender, EventArgs e)
{
    int ckt = checkTrung(txtUser.Text);
    if (ckt > 0)
    {
        MessageBox.Show("Có");
    }
    else
    {
        MessageBox.Show("khonngngngn");
    }
}
18.xoá du iệu c# sql còn
private void button2_Click(object sender, EventArgs e)
{
    if (gvBH.SelectedRows.Count > 0)
    {
        foreach (DataGridViewRow row in gvBH.SelectedRows)
        {
            gvBH.Rows.Remove(row);
        }
    }

    DateTime date = DateTime.Now;
    string formattedDate = date.ToString("dddd, MM/dd/yyyy");
    labelTuoi.Text = formattedDate;
}
19.hiển thị tuôi khi datetimepicker
private void dtNS_ValueChanged(object sender, EventArgs e)
{
    DateTime dt = dtNS.Value;
    TimeSpan tsp = DateTime.Now.Subtract(dt);
    int tuoi = (int)tsp.TotalDays / 365;
    labelTuoi.Text = tuoi.ToString();
}
20.check sdt
private void txtDC_Validating(object sender, CancelEventArgs e)
{
    ErrorProvider er = new ErrorProvider();
    string phoneNumber = txtDC.Text;

    if (phoneNumber.Length > 0 && phoneNumber.Length <= 11 && phoneNumber[0] == '0')
    {
        //er.Clear();
        foreach (char c in phoneNumber)
        {
            int number;
            if (!int.TryParse(c.ToString(), out number))
            {
                er.SetError(txtDC, "khong phai sdt");
                //return;
            }
            else { er.Clear(); }

        }
    }
    // string input = "123456";
    else
    {
        er.SetError(txtDC, "khong phai sdt");
    }
}
21.chuyển màu
format bject==>forn==>color==>iif({@tuoi}> 30,red, black)
22.tuổi report
Year(CurrentDate) - Year({ tblKhachhang.tNgaysinh})


         **/
    }
}
