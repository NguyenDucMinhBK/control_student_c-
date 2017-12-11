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

namespace Control_student
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = "+ conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from LoginAdmin where username ='" + txtTenDN.Text + "' and passwword='" + txtMatKhau.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    SessionLogin.SessionUsername = txtTenDN.Text;
                    SessionLogin.SessionPassword = txtMatKhau.Text;
                    this.Hide();
                    frmMain mm = new frmMain();
                    mm.Show();
                    mm.mnuDN.Enabled = false;
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                    SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from LoginMember where MSSV ='" + txtTenDN.Text + "' and passwword='" + txtMatKhau.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    if (dt1.Rows[0][0].ToString() == "1")
                    {
                        SessionLogin.SessionUsername = txtTenDN.Text;
                        SessionLogin.SessionPassword = txtMatKhau.Text;
                        this.Hide();
                        frmMain mm = new frmMain();
                        mm.Show();
                        mm.mnuDN.Enabled = false;
                        mm.mnuItemQuanli.Enabled = false;
                        mm.mnuQuanlinguoidung.Enabled = false;
                        mm.MnuItemDanhMuc.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu và tên đăng nhập không đúng mời nhập lai !", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }    
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_Enter(object sender, EventArgs e)
        {
        
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
