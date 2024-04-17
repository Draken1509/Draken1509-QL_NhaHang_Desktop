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
    public partial class btnMenu : Form
    {
        //Giao diện
        //frmTaiQuay1 frmtaiquay;
        frmTaiQuay frmtaiquay;
        frmBaoCao frmbaocao;
        frmVoucher frmvoucher;
        frmNhapHang frmnhaphang;
        frmKhachHang frmkhachhang;
        frmThongKeTongQuan frmthongKeTongQuan;
        frmThongKeHangHoa frmthongKeHangHoa;
        frmThem frmthem;
        frm_ThongKeDoanhThu frmthongkedoanhthu;
        frmDonOnline frmdononline;
        //Biến
        bool menuExpand = false;
        bool sidebarExpand = true;

        public btnMenu(NHANVIEN nv)
        {
            InitializeComponent();
            //if (nv.id_quyen == 1)
            //{
            //    btnBaoCao.Enabled = false;
            //    btnNhapHang.Enabled = false;
            //    btnKhachHang.Enabled = false;
            //    btnThem.Enabled = false;

            //    btnBaoCao.ForeColor = Color.White;
            //    btnKhachHang.ForeColor = Color.White;
            //    btnThem.ForeColor = Color.White;
            //    btnNhapHang.ForeColor = Color.White;
            //}
            MessageBox.Show("Đăng nhập thành công \n chào mừng " + nv.tennv + "Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            mdiProp();
        }

        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232,234,237);
        }
        //frm tai ban
        private void btnTaiBan_Click(object sender, EventArgs e)
        {
            if (frmdononline == null)
            {
                frmdononline = new frmDonOnline();
                frmdononline.FormClosed += Frmtaiban_FormClosed;
                frmdononline.MdiParent = this;
                frmdononline.Dock = DockStyle.Fill;
                frmdononline.Show();
            }
            else
            {
                frmtaiquay.Activate();
            }
        }
        //frm tai quay
        private void btnTaiQuay_Click(object sender, EventArgs e)
        {
            if (frmtaiquay == null)
            {
                frmtaiquay = new frmTaiQuay();
                frmtaiquay.FormClosed += Frmtaiban_FormClosed;
                frmtaiquay.MdiParent = this;
                frmtaiquay.Dock = DockStyle.Fill;
                frmtaiquay.Show();
            }
            else
            {
                frmtaiquay.Activate();
            }
        }
        private void Frmtaiban_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmtaiquay = null;
        }

        //frm bao cao
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            MenuTransiton.Start();
        }
        private void btn_tongQuan_Click(object sender, EventArgs e)
        {
            if (frmthongKeTongQuan == null)
            {
                frmthongKeTongQuan = new frmThongKeTongQuan();
                frmthongKeTongQuan.MdiParent = this;
                frmthongKeTongQuan.Dock = DockStyle.Fill;
                frmthongKeTongQuan.Show();
            }
            else
            {
                frmthongKeTongQuan.Activate();
            }
        }
        private void btn_sanPhamBanChay_Click(object sender, EventArgs e)
        {
            if (frmthongKeHangHoa == null)
            {
                frmthongKeHangHoa = new frmThongKeHangHoa();
                frmthongKeHangHoa.FormClosed += frmthongKeHangHoa_FormClosed;
                frmthongKeHangHoa.MdiParent = this;
                frmthongKeHangHoa.Dock = DockStyle.Fill;
                frmthongKeHangHoa.Show();
            }
            else
            {
                frmthongKeHangHoa.Activate();
            }
        }
        void frmthongKeHangHoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmthongKeHangHoa = null;
        }
        //frm voucher
        private void btnVoucher_Click(object sender, EventArgs e)
        {
            if (frmvoucher == null)
            {
                frmvoucher = new frmVoucher();
                frmvoucher.FormClosed += frmvoucher_FormClosed;
                frmvoucher.MdiParent = this;
                frmvoucher.Dock = DockStyle.Fill;
                frmvoucher.Show();
            }
            else
            {
                frmvoucher.Activate();
            }
        }
        void frmvoucher_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmvoucher = null;
        }
        //frm Nhap hang
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (frmnhaphang == null)
            {
                frmnhaphang = new frmNhapHang();
                frmnhaphang.FormClosed += Frmnhaphang_FormClosed;
                frmnhaphang.MdiParent = this;
                frmnhaphang.Dock = DockStyle.Fill;
                frmnhaphang.Show();
            }
            else
            {
                frmnhaphang.Activate();
            }
        }
        private void Frmnhaphang_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmnhaphang = null;
        }

        //
        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            if (frmkhachhang == null)
            {
                frmkhachhang = new frmKhachHang();
                frmkhachhang.FormClosed += frmkhachhang_FormClosed;
                frmkhachhang.MdiParent = this;
                frmkhachhang.Dock = DockStyle.Fill;
                frmkhachhang.Show();
            }
            else
            {
                frmkhachhang.Activate();
            }
        }

        void frmkhachhang_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmkhachhang = null;
        }

        //frm them
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (frmthem == null)
            {
                frmthem = new frmThem();
                frmthem.FormClosed += frmthem_FormClosed;
                frmthem.MdiParent = this;
                frmthem.Dock = DockStyle.Fill;
                frmthem.Show();
            }
            else
            {
                frmthem.Activate();
            }
        }
        void frmthem_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmthem = null;
        }

        // desgin giao dien
        private void btnMenu2_Click(object sender, EventArgs e)
        {
            change();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                // reduce flickering when switching mdi child forms (see also WndProc)
                //cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED (which is essentially double buffered)

                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED (which is essentially double buffered)

                return cp;
            }
        }
        private void MenuTransiton_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer.Height += 10;
                if (menuContainer.Height >= 232)
                {
                    MenuTransiton.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer.Height -= 10;
                if (menuContainer.Height <= 58)
                {
                    MenuTransiton.Stop();
                    menuExpand = false;
                }
            }
        }
        private void change()
        {
            while (true)
            {
                if (sidebarExpand)
                {
                    sidebar.Width -= 10;
                    if (sidebar.Width <= 60)
                    {
                        sidebar.Width = 60;
                        sidebarExpand = false;

                        btnTaiBan.Width = sidebar.Width;
                        btnTaiQuay.Width = sidebar.Width;
                        btnBaoCao.Width = sidebar.Width;
                        btnKhachHang.Width = sidebar.Width;
                        btnThem.Width = sidebar.Width;
                        btnNhapHang.Width = sidebar.Width;
                        break;
                    }
                }
                else
                {
                    sidebar.Width += 10;
                    if (sidebar.Width >= 275)
                    {
                        sidebar.Width = 275;
                        sidebarExpand = true;

                        btnTaiBan.Width = sidebar.Width;
                        btnTaiQuay.Width = sidebar.Width;
                        btnBaoCao.Width = sidebar.Width;
                        btnKhachHang.Width = sidebar.Width;
                        btnThem.Width = sidebar.Width;
                        btnNhapHang.Width = sidebar.Width;
                        break;
                    }
                }
            }

        }

        private void btn_doanhThu_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("da vao dc", "thong bao", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (frmthongkedoanhthu == null)
            {
                frmthongkedoanhthu = new frm_ThongKeDoanhThu();
                frmthongkedoanhthu.FormClosed += frmthongKeHangHoa_FormClosed;
                frmthongkedoanhthu.MdiParent = this;
                frmthongkedoanhthu.Dock = DockStyle.Fill;
                frmthongkedoanhthu.Show();
            }
            else
            {
                frmthongkedoanhthu.Activate();
            }
        }

        private void btnMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
