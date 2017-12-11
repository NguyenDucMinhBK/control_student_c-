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
    public partial class frmKhoa : Form
    {
        public frmKhoa()
        {
            InitializeComponent();
        }

        private void frmKhoa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_SVDataSet5.KHOAVIEN' table. You can move, or remove it, as needed.
            this.kHOAVIENTableAdapter.Fill(this.qL_SVDataSet5.KHOAVIEN);

        }
        private void ketnoi()
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string sql = "select * from KHOAVIEN";
                SqlCommand comandsql = new SqlCommand(sql, conn);
                SqlDataAdapter com = new SqlDataAdapter(comandsql);
                DataTable table = new DataTable();
                com.Fill(table);
                dgrMON.DataSource = table;
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
        int index;
        private void dgrMON_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgrMON.CurrentRow.Index;
            txtKhoa.Text = dgrMON.Rows[index].Cells[0].Value.ToString();
            txtTenKhoa.Text = dgrMON.Rows[index].Cells[1].Value.ToString();
        }
        string them;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                them = "Insert Into KHOAVIEN(MaKhoa,TenKhoa)" +
                "Values('" + txtKhoa.Text + "',N'" + txtTenKhoa.Text + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string update = "Update KHOAVIEN Set MaKhoa=N'" + txtKhoa.Text + "',TenKhoa='" + txtTenKhoa.Text + "' where MaKhoa='" + txtKhoa.Text + "' ";
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string delete = "delete from KHOAVIEN where MaKhoa='" + txtKhoa.Text + "' ";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("Lỗi kết lỗi (CÓ thể dó liên kết dữ liệu, hoặc do khoa viện này vẫn còn lớp nên không thể xóa!)");
            }
            finally
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Close();
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
