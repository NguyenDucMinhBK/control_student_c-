using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Control_student
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void MnuDN_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }

        private void mnuDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.Show();
        }

        private void mnuQuanlinguoidung_Click(object sender, EventArgs e)
        {
            frmControl_Member frm = new frmControl_Member();
            frm.Show();
        }

        private void mnuDX_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
            //mnuDN.Enabled = true;
            //editMenu.Enabled = false;
            //mnuDoiMK.Enabled = false;
            //MnuItemDanhMuc.Enabled = false;
            //mnuItemQuanli.Enabled = false;
            //mnuWindows.Enabled = false;
            //mnuItemThongKe.Enabled = false;
        }

        private void mnuMon_Click(object sender, EventArgs e)
        {
            frmMonHoc frm = new frmMonHoc();
            frm.Show();
        }

        private void mnuKhoa_Click(object sender, EventArgs e)
        {
            frmKhoa frm = new frmKhoa();
            frm.Show();
        }

        private void mnuLop_Click(object sender, EventArgs e)
        {
            frmLop frm = new frmLop();
            frm.Show();
        }

        private void mnuSV_Click(object sender, EventArgs e)
        {
            frmQLSV frm = new frmQLSV();
            frm.Show();
        }

        private void mnuGV_Click(object sender, EventArgs e)
        {
            
            frmQLGV frm = new frmQLGV();
            frm.Show();
        }

        private void mnuHL_Click(object sender, EventArgs e)
        {
            frmHocLai frm = new frmHocLai();
            frm.Show();
        }

        private void mnuThongtinSV_Click(object sender, EventArgs e)
        {
            frmQLTTSV frm = new frmQLTTSV();
            frm.Show();
        }

        private void mnuDiem_Click(object sender, EventArgs e)
        {
            frmQLDIEM frm = new frmQLDIEM();
            frm.Show();
        }

        private void mnuDSSV_Click(object sender, EventArgs e)
        {
            frmDSSV frm = new frmDSSV();
            frm.Show();
        }

        private void mnuDiemTK_Click(object sender, EventArgs e)
        {
            frmDTK frm = new frmDTK();
            frm.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //SessionLogin.SessionUsername
            //MessageBox.Show(SessionLogin.SessionUsername);

        }

        private void mnuDN_Click_1(object sender, EventArgs e)
        {

        }
    }
}
