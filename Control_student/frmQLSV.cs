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
    public partial class frmQLSV : Form
    {
        public frmQLSV()
        {
            InitializeComponent();
        }
        private void ketnoi()
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string sql = "select * from SINHVIEN ";
                SqlCommand comandsql = new SqlCommand(sql, conn);
                SqlDataAdapter com = new SqlDataAdapter(comandsql);
                DataTable table = new DataTable();
                com.Fill(table);
                dgrDSSV.DataSource = table;
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
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmQLSV_Load(object sender, EventArgs e)
        {
            ketnoi();
            // TODO: This line of code loads data into the 'qL_SVDataSet15.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter4.Fill(this.qL_SVDataSet15.LOP);
            // TODO: This line of code loads data into the 'qL_SVDataSet14.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter3.Fill(this.qL_SVDataSet14.LOP);
            // TODO: This line of code loads data into the 'qL_SVDataSet13.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter2.Fill(this.qL_SVDataSet13.LOP);
            // TODO: This line of code loads data into the 'qL_SVDataSet12.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter1.Fill(this.qL_SVDataSet12.LOP);
            // TODO: This line of code loads data into the 'qL_SVDataSet11.KHOAVIEN' table. You can move, or remove it, as needed.
            this.kHOAVIENTableAdapter.Fill(this.qL_SVDataSet11.KHOAVIEN);
            // TODO: This line of code loads data into the 'qL_SVDataSet10.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Fill(this.qL_SVDataSet10.LOP);
            // TODO: This line of code loads data into the 'qL_SVDataSet9.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Fill(this.qL_SVDataSet9.SINHVIEN);

        }

        private void cboGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conect = SystemInformation.UserDomainName.ToString();
            SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
            conn.Open();
            string select = "Select * from SINHVIEN where MaLop='" + cboLop.Text + "'";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataAdapter com = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            com.Fill(table);
            dgrDSSV.DataSource = table;
            cmd.Dispose();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLop.Items.Clear();
            string conect = SystemInformation.UserDomainName.ToString();
            SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
            conn.Open();
            string select = "Select MaLop from LOP where MaKhoa='" + cboKhoa.Text + "'";
            SqlCommand cmd = new SqlCommand(select, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            //Add vao cboLop
            while (reader.Read())
            {

                cboLop.Items.Add(reader.GetString(0));
            }
            reader.Dispose();
            cmd.Dispose();
        }

        private void dgrDSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = dgrDSSV.CurrentRow.Index;
            txtMaSV.Text = dgrDSSV.Rows[index].Cells[0].Value.ToString();
            txtHoTen.Text = dgrDSSV.Rows[index].Cells[1].Value.ToString();
            mskNgaySinh.Text = dgrDSSV.Rows[index].Cells[2].Value.ToString();
            cboGioiTinh.Text = dgrDSSV.Rows[index].Cells[3].Value.ToString();
            txtDiaChi.Text = dgrDSSV.Rows[index].Cells[4].Value.ToString();
            txtDanToc.Text = dgrDSSV.Rows[index].Cells[5].Value.ToString();
            cboMalop.Text = dgrDSSV.Rows[index].Cells[6].Value.ToString();

        }

        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string them = "Insert Into SINHVIEN(MSSV,HoTen,NgaySinh,GioiTinh,NoiSinh,DanToc,MaLop)" +
                "Values(N'" + txtMaSV.Text + "','" + txtHoTen.Text + "','" + mskNgaySinh.Text + "','" + cboGioiTinh.Text + "','" + txtDiaChi.Text + "','" + txtDanToc.Text + "','" + cboMalop.Text + "')";
                SqlCommand commandthem = new SqlCommand(them, conn);
                commandthem.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("Lỗi sinh viên chưa có kết lối, hoặc lỗi kết lối với dữ liệu !");
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
                string update = "Update SINHVIEN Set MSSV=N'" + txtMaSV.Text + "',HoTen='" + txtHoTen.Text + "',NgaySinh='" + mskNgaySinh.Text + "',GioiTinh='"+ cboGioiTinh.Text+ "',NoiSinh='" + txtDiaChi.Text + "',DanToc='" + txtDanToc.Text + "',MaLop='" + cboMalop.Text + "' where MSSV='" + txtMaSV.Text + "' ";
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string conect = SystemInformation.UserDomainName.ToString();
                SqlConnection conn = new SqlConnection(@"Data Source = " + conect + "\\SQLEXPRESS; Initial Catalog = QL_SV; Integrated Security = True");
                conn.Open();
                string delete = "delete from SINHVIEN where MSSV='" + txtMaSV.Text + "' ";
                SqlCommand cmd = new SqlCommand(delete, conn);
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
