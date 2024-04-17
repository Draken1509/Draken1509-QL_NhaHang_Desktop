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
    public partial class frmNhapHang : Form
    {
        DonNhapHangDAL nhaphangdal = new DonNhapHangDAL();
        NhaCungCapDAL nccdal = new NhaCungCapDAL();
        public frmNhapHang()
        {
            InitializeComponent();
            loadData();
            loadComBoBox();
            cbo_ncc.SelectedIndexChanged += cbo_ncc_SelectedIndexChanged;
        }

        void chuhoanthanh_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void hoanthanh_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (checkBox.Checked)
            {
                List<ThongTinDonNhapHang> danhSachDonNhapHangTrue = nhaphangdal.LoadTheoTinhTrang(true);
                HienThiDuLieu(danhSachDonNhapHangTrue);
            }
            else
            {
                HienThiDuLieu(nhaphangdal.LayThongTinHaiBang());
            }
        }
        public void loadComBoBox()
        {
            cbo_ncc.DataSource = nccdal.getncc();
            cbo_ncc.DisplayMember = "tenncc";
            cbo_ncc.ValueMember = "id_ncc";
        }

        private void cbo_ncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_ncc = Convert.ToInt32(cbo_ncc.SelectedValue);

            List<ThongTinDonNhapHang> danhSachTheoNCC = nhaphangdal.LoadTheoNCC(id_ncc);

            HienThiDuLieu(danhSachTheoNCC);
        }

        public void loadData()
        {
            //
            gunaDataGridView1.ReadOnly = true;
            gunaDataGridView1.RowTemplate.Height = 100;
            gunaDataGridView1.Columns.AddRange(
            new DataGridViewTextBoxColumn() { Name = "id_dnh", HeaderText = "Mã đơn hàng" },
            new DataGridViewTextBoxColumn() { Name = "ngaynhap", HeaderText = "Ngày nhập" },
            new DataGridViewTextBoxColumn() { Name = "tinhtrangnhanhang", HeaderText = "Tình trạng nhận hàng" },
            new DataGridViewTextBoxColumn() { Name = "tongtien", HeaderText = "Tổng tiền" },
            new DataGridViewTextBoxColumn() { Name = "tenncc", HeaderText = "Tên nhà cung cấp" }
            );
            // Đặt kích thước của cột button
            gunaDataGridView1.Columns["tinhtrangnhanhang"].DefaultCellStyle.Padding = new Padding(35); // Thiết lập Padding cho cell chứa button
            HienThiDuLieu(nhaphangdal.LayThongTinHaiBang());
            // Sự kiện 
            gunaDataGridView1.CellClick += GunaDataGridView1_CellClick;
        }

        public void HienThiDuLieu(List<ThongTinDonNhapHang> danhSachDonNhapHang)
        {
            gunaDataGridView1.Rows.Clear();

            foreach (var donNhapHang in danhSachDonNhapHang)
            {
                gunaDataGridView1.Rows.Add(
                    donNhapHang.id_dnh,
                    donNhapHang.ngaynhap,
                    donNhapHang.tinhtrangnhanhang ? "Đã giao hàng" : "Chưa giao hàng",
                    donNhapHang.tongtien + "000 VNĐ",
                    donNhapHang.tenncc
                );
            }
        }

        private void GunaDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = gunaDataGridView1.Rows[e.RowIndex];
                string idDonHang = selectedRow.Cells["id_dnh"].Value.ToString();
                string ngayNhap = selectedRow.Cells["ngaynhap"].Value.ToString();
                string tinhTrangNhanHang = selectedRow.Cells["tinhtrangnhanhang"].Value.ToString();
                int id_dnh = Int32.Parse(idDonHang);
                fromChiTietHangHoa frmctnhaphang = new fromChiTietHangHoa(id_dnh, tinhTrangNhanHang);
                frmctnhaphang.Show();
            }
        }

        // làm lại
        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            frmChiTietNhapHang frm = new frmChiTietNhapHang();
            frm.MdiParent = this.MdiParent;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void btn_tim_Click_1(object sender, EventArgs e)
        {
            int id = Int32.Parse(txt_id.Text);
            HienThiDuLieu(nhaphangdal.TimTheoIDDNH(id));
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            HienThiDuLieu(nhaphangdal.LayThongTinHaiBang());
        }
    }
}
