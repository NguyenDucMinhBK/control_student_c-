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
    public partial class frmQLDIEM : Form
    {
        public frmQLDIEM()
        {
            InitializeComponent();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void qLSVDataSet17BindingSource_CurrentChanged(object sender, EventArgs e)
        {
            
        }

        private void dgrDiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmQLDIEM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qL_SVDataSet19.DIEMHP' table. You can move, or remove it, as needed.
            this.dIEMHPTableAdapter.Fill(this.qL_SVDataSet19.DIEMHP);
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string sql = "select DIEMHP.MaMon as 'Mã Môn', DIEMHP.MSSV, SINHVIEN.HoTen, MONHP.TenMon from DIEMHP inner join MONHP on DIEMHP.MaMon = MONHP.MaMon inner join SINHVIEN on DIEMHP.MSSV = SINHVIEN.MSSV ";
                SqlCommand comandsql = new SqlCommand(sql, conn);
                SqlDataAdapter com = new SqlDataAdapter(comandsql);
                DataTable table = new DataTable();
                com.Fill(table);
                dgrDiem.DataSource = table;

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double diemGK, diemCk, DiemTB;
            diemGK = double.Parse(this.txtDiemThi1.Text);
            diemCk = double.Parse(this.textBox2.Text);
            DiemTB = ((diemCk * 0.7) + (diemGK * 0.3));
            this.textBox1.Text = Convert.ToString(DiemTB);
            if (txtDiemThi1.Text == "")
            {
                this.txtDiemThi1.Text = "0";
                diemCk = double.Parse(this.textBox2.Text);

                //Tính điểm TK
                DiemTB = ((diemCk * 0.7) + (diemGK * 0));
                this.textBox1.Text = Convert.ToString(DiemTB);
            }
            else if(txtDiemThi1.)
        }
    }
}
