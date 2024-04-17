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
    public partial class frmChiTietNhapHang : Form
    {
        DonNhapHangDAL handle = new DonNhapHangDAL();
        List<ChiTietDonNhapHang> lst_nhaphang = new List<ChiTietDonNhapHang>();

        public frmChiTietNhapHang()
        {
            InitializeComponent();
            loadDuLieu();
            loadNCC();
        }

        public void loadNCC()
        {
            // Loại bỏ sự kiện SelectedIndexChanged trước khi gán dữ liệu
            cbo_nhacungcap.SelectedIndexChanged -= cbo_nhacungcap_SelectedIndexChanged;

            cbo_nhacungcap.DataSource = handle.loadNCC();
            cbo_nhacungcap.DisplayMember = "tenncc";
            cbo_nhacungcap.ValueMember = "id_ncc";

            // Thêm lại sự kiện SelectedIndexChanged sau khi gán dữ liệu
            cbo_nhacungcap.SelectedIndexChanged += cbo_nhacungcap_SelectedIndexChanged;
        }

        private void cbo_nhacungcap_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cbo_nhacungcap.SelectedValue.ToString();
            int id_ncc = Int32.Parse(selectedValue);
            //MessageBox.Show("Kết quả là" + selectedValue);
            cbosp.DataSource = handle.loadNguyenLieu(id_ncc);
            cbosp.DisplayMember = "tennguyenlieu";
            cbosp.ValueMember = "id_nguyenlieu";
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            string idnl = cbosp.SelectedValue.ToString();
            int id_nl = Int32.Parse(idnl);
            string tennl = cbosp.Text;
            int sl = Int32.Parse(txtsoluong.Text.Trim());
            NGUYENLIEU nl = handle.LayNguyenLieuTheoID(id_nl);

            // Kiểm tra xem nguyên liệu đã tồn tại trong danh sách chưa
            ChiTietDonNhapHang existingItem = lst_nhaphang.FirstOrDefault(item => item.id_nl == id_nl);

            if (existingItem != null)
            {
                // Nếu nguyên liệu đã tồn tại, cập nhật số lượng
                existingItem.khoiluong += sl;
                existingItem.thanhtien += sl * nl.gianhap.GetValueOrDefault();
            }
            else
            {
                // Nếu nguyên liệu chưa tồn tại, thêm mới vào danh sách
                ChiTietDonNhapHang ctdnh = new ChiTietDonNhapHang();
                ctdnh.tennl = nl.tennguyenlieu;
                ctdnh.gianhap = nl.gianhap.GetValueOrDefault();
                ctdnh.ngaynhap = DateTime.Now;
                ctdnh.khoiluong = sl;
                ctdnh.id_nl = id_nl;
                ctdnh.thanhtien = sl * nl.gianhap.GetValueOrDefault();
                lst_nhaphang.Add(ctdnh);
            }

            HienThiDuLieu(lst_nhaphang);

            // Tính toán và hiển thị thông tin
            txtngaynhap.Text = DateTime.Now.ToString();
            int sum = 0;
            foreach (ChiTietDonNhapHang ct in lst_nhaphang)
            {
                sum += ct.thanhtien;
            }
            txttongsoluong.Text = lst_nhaphang.Count.ToString();
            txtthanhtien.Text = sum.ToString() + "000";
        }

        private void loadDuLieu()
        {
            gunaDataGridView1.ReadOnly = true;
            gunaDataGridView1.RowTemplate.Height = 100;
            gunaDataGridView1.Columns.AddRange(
            new DataGridViewTextBoxColumn() { Name = "tennl", HeaderText = "Tên nguyên liệu" },
            new DataGridViewTextBoxColumn() { Name = "khoiluong", HeaderText = "Khối lượng nhập" },
            new DataGridViewTextBoxColumn() { Name = "gianhap", HeaderText = "Gía nhập" },
            new DataGridViewTextBoxColumn() { Name = "thanhtien", HeaderText = "Thành tiền" }
            );
            //
        
        }

        public void HienThiDuLieu(List<ChiTietDonNhapHang> ctdonnhaphang)
        {
            gunaDataGridView1.Rows.Clear();

            foreach (var ct in ctdonnhaphang)
            {
                gunaDataGridView1.Rows.Add(
                    ct.tennl,
                    ct.khoiluong,
                    ct.gianhap + "000",
                    ct.thanhtien + "000"
                );
            }
        }

        private void themDonNhapHang(int id_ncc, int tongtien)
        {
            DONNHAPHANG dnh = new DONNHAPHANG();
            dnh.id_ncc = id_ncc;
            dnh.ngaynhap = DateTime.Now;
            dnh.tinhtrangnhanhang = false;
            dnh.tongtien = tongtien;
            handle.ThemDonNhapHang(dnh);
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            string selectedValue = cbo_nhacungcap.SelectedValue.ToString();
            int id_ncc = Int32.Parse(selectedValue);
            int tt = Int32.Parse(txtthanhtien.Text);
            themDonNhapHang(id_ncc, tt);
            int id_max = handle.loaddonnhaphang();

            foreach(ChiTietDonNhapHang ct in lst_nhaphang)
            {
                CHITIETDONNHAPHANG ctdnh = new CHITIETDONNHAPHANG();
                ctdnh.id_nguyenlieu = ct.id_nl;
                ctdnh.id_dnh = id_max;
                ctdnh.khoiluongnhap = ct.khoiluong;
                handle.ThemChiTietDonNhapHang(ctdnh);
            }
            MessageBox.Show("Thêm thành công", "Thông báo");
        }

    }
}
