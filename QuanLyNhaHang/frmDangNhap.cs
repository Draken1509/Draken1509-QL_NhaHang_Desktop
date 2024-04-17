using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace QuanLyNhaHang
{
    public partial class frmDangNhap : Form
    {
        NhanVienDAL nhanviendal = new NhanVienDAL();
        public frmDangNhap()
        {
            InitializeComponent();
            txt_matkhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txt_taikhoan.Text.Trim();
            string matkhau = txt_matkhau.Text.Trim();
            NHANVIEN nv = nhanviendal.getEmployee(taikhoan,matkhau);
            if (nv != null)
            {
                this.Hide();
                btnMenu frmTrangChu = new btnMenu(nv);
                frmTrangChu.Show();
            }
            else
            {
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
