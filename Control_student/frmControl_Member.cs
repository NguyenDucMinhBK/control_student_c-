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
    public partial class frmControl_Member : Form
    {
        public frmControl_Member()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string delete = "delete from LOGINMEMBER where MSSV='" + txtTaikhoan.Text + "' ";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("Lỗi kết lỗi  liên kết dữ liệu!)");
            }
            finally
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Close();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string update = "Update LOGINMEMBER Set MSSV=N'" + txtTaikhoan.Text + "',passwword='" + txtMK.Text + "' where MSSV='" + txtTaikhoan.Text + "' ";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("loi ket noi");
            }
            finally
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Close();
            }
        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            string them;
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                them = "Insert Into LOGINMEMBER(MSSV,passwword)" +
                "Values('" + txtTaikhoan.Text + "','" + txtMK.Text + "')";
                SqlCommand commandthem = new SqlCommand(them, conn);
                commandthem.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("loi ket noi");
            }
            finally
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Close();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmControl_Member_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_SVDataSet6.LOGINMEMBER' table. You can move, or remove it, as needed.
            this.lOGINMEMBERTableAdapter.Fill(this.qL_SVDataSet6.LOGINMEMBER);

        }
        private void ketnoi()
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string sql = "select * from LOGINMEMBER";
                SqlCommand comandsql = new SqlCommand(sql, conn);
                SqlDataAdapter com = new SqlDataAdapter(comandsql);
                DataTable table = new DataTable();
                com.Fill(table);
                dgrLogin.DataSource = table;
            }
            catch
            {
                MessageBox.Show("loi ket noi");
            }
            finally
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Close();
            }

        }
        private void dgrLogin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = dgrLogin.CurrentRow.Index;
            txtTaikhoan.Text = dgrLogin.Rows[index].Cells[0].Value.ToString();
            txtMK.Text = dgrLogin.Rows[index].Cells[1].Value.ToString();
        }
    }
}
