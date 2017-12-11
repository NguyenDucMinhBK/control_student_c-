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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
   
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                string conect = SystemInformation.UserDomainName.ToString();
                string taikhoan = SessionLogin.SessionUsername;
                SqlConnection con = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                SqlDataAdapter sda1 = new SqlDataAdapter("select count(*) from LoginAdmin where  username ='" + taikhoan + "' and passwword='" + txtMKcu.Text + "'", con);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "1")
                {
                    if (txtMKmoi.Text == txtConfimMk.Text)
                    {
                        con.Open();
                        string them = "Update LoginAdmin Set  username=N'" + taikhoan + "', passwword='" + txtMKmoi.Text + "' where username='" + taikhoan + "' ";
                        SqlCommand commandthem = new SqlCommand(them, con);
                        commandthem.ExecuteNonQuery();
                        MessageBox.Show("Đổi mật khẩu thành công ! ");
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu mới không giống mật khẩu cũ, mời nhập lại ! ");
                    }
                }
                else
                {
                    string taikhoan_member = SessionLogin.SessionUsername;
                    SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                    SqlDataAdapter sda = new SqlDataAdapter("select count(*) from LoginMember where  MSSV ='" + taikhoan_member + "' and passwword='" + txtMKcu.Text + "'", conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        if (txtMKmoi.Text == txtConfimMk.Text)
                        {
                            conn.Open();
                            string them = "Update LoginMember Set  MSSV=N'" + taikhoan_member + "', passwword='" + txtMKmoi.Text + "' where MSSV='" + taikhoan_member + "' ";
                            SqlCommand commandthem = new SqlCommand(them, conn);
                            commandthem.ExecuteNonQuery();
                            MessageBox.Show("Đổi mật khẩu thành công ! ");
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu mới không giống mật khẩu nhập lại, mời nhập lại ! ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu và tên đăng nhập không đúng mời nhập lai !", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
