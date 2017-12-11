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
    public partial class frmLop : Form
    {
        public frmLop()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_SVDataSet8.KHOAVIEN' table. You can move, or remove it, as needed.
            this.kHOAVIENTableAdapter.Fill(this.qL_SVDataSet8.KHOAVIEN);
            // TODO: This line of code loads data into the 'qL_SVDataSet7.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.qL_SVDataSet7.LOP);

        }
        private void ketnoi()
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string sql = "select * from LOP";
                SqlCommand comandsql = new SqlCommand(sql, conn);
                SqlDataAdapter com = new SqlDataAdapter(comandsql);
                DataTable table = new DataTable();
                com.Fill(table);
                dgrLop.DataSource = table;
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
        private void dgrLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dgrLop.CurrentRow.Index;
            txtMaLop.Text = dgrLop.Rows[index].Cells[0].Value.ToString();
            txtTenLop.Text = dgrLop.Rows[index].Cells[1].Value.ToString();
            cboKhoa.Text = dgrLop.Rows[index].Cells[2].Value.ToString();
        }

        private void txtTenlop_TextChanged(object sender, EventArgs e)
        {

        }
        string them;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                them = "Insert Into LOP(MaLop,TenLop,MaKhoa)" +
                "Values('" + txtMaLop.Text + "','" + txtTenLop.Text + "','"+ cboKhoa.Text + "')";
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
                string update = "Update LOP Set MaLop=N'" + txtMaLop.Text + "',TenLop='" + txtTenLop.Text + "', MaKhoa='"+ cboKhoa.Text+"' where MaLop='" + txtMaLop.Text+ "' ";
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
                string delete = "delete from LOP where MaLop='" + txtMaLop.Text + "' ";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("Lỗi kết lỗi (CÓ thể lỗi liên kết dữ liệu, hoặc do lớp vẫn còn sinh viên nên không thể xóa!)");
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
