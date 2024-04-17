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
using DTO;

namespace QuanLyNhaHang
{
    public partial class fromChiTietHangHoa : Form
    {
        DonNhapHangDAL dnhdal = new DonNhapHangDAL();
        int iddnh = 0;
        public fromChiTietHangHoa(int id_dnh, string tinhtrangnhanhang)
        {
            InitializeComponent();
            label1.Text = "CT" + id_dnh;
            loadDuLieu(id_dnh);
            iddnh = id_dnh;
            if (tinhtrangnhanhang.Equals("Đã giao hàng"))
            {
                btn_duyet.Visible = false;
            }
        }

        private void loadDuLieu(int id_dnh)
        {
            gunaDataGridView1.ReadOnly = true;
            gunaDataGridView1.RowTemplate.Height = 100;
            gunaDataGridView1.Columns.AddRange(
            new DataGridViewTextBoxColumn() { Name = "tennl", HeaderText = "Tên nguyên liệu" },
            new DataGridViewTextBoxColumn() { Name = "ngaynhap", HeaderText = "Ngày nhập" },
            new DataGridViewTextBoxColumn() { Name = "khoiluong", HeaderText = "Khối lượng nhập" },
            new DataGridViewTextBoxColumn() { Name = "gianhap", HeaderText = "Gía nhập" },
            new DataGridViewTextBoxColumn() { Name = "thanhtien", HeaderText = "Thành tiền" }
            );
            //
            HienThiDuLieu(dnhdal.loadChietnhaphang(id_dnh));
        }

        public void HienThiDuLieu(List<ChiTietDonNhapHang> ctdonnhaphang)
        {
            gunaDataGridView1.Rows.Clear();

            foreach (var ct in ctdonnhaphang)
            {
                gunaDataGridView1.Rows.Add(
                    ct.tennl,
                    ct.ngaynhap,
                    ct.khoiluong,
                    ct.gianhap + "000",
                    ct.thanhtien  + "000"
                );
            }
        }

        private void btn_duyet_Click_1(object sender, EventArgs e)
        {
            dnhdal.CapNhatTinhTrangNhanHang(iddnh, true);
            List<ChiTietDonNhapHang> lst_ctdnh = dnhdal.loadChietnhaphang(iddnh);
            foreach (ChiTietDonNhapHang ct in lst_ctdnh)
            {
                dnhdal.CapNhatSoLuongNguyenLieu(ct.id_nl, ct.khoiluong);
            }
            this.Close();

        }
    }
}
