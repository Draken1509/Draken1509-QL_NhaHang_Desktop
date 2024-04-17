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
using CustomControlThongKe;
using System.Data.SqlClient;

namespace QuanLyNhaHang
{
    public partial class frmThanhToan : Form
    {
        VoucherDAL voucherdal = new VoucherDAL();
        HoaDonDAL hoadondal = new HoaDonDAL();
        MenuDAL menudal = new MenuDAL();
        int thanhtien;
        bool check_button = true;
        String ghichu;
        FlowLayoutPanel panelhoadon;
        public frmThanhToan(int thanhtien, FlowLayoutPanel panelhoadon, String ghichu)
        {
            InitializeComponent();
            this.panelhoadon = panelhoadon;
            this.thanhtien = thanhtien;
            this.ghichu = ghichu;
            txt_tamtinh.Text = thanhtien + ",000";
            txt_tongtien.Text = thanhtien + ",000";
            btn_tienmat.PerformClick();
            loadVoucher();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void btn_back_Paint(object sender, PaintEventArgs e)
        {

        }
        private void loadVoucher()
        {
            List<VOUCHER> list_voucher = voucherdal.loadAllVoucher(thanhtien);
            dgv_voucher.DataSource = list_voucher;

            dgv_voucher.Columns["id_voucher"].HeaderText = "Mã voucher";
            dgv_voucher.Columns["ngaybatdau"].HeaderText = "Ngày bắt đầu";
            dgv_voucher.Columns["ngayhethan"].HeaderText = "Ngày hết hạn";
            dgv_voucher.Columns["mucgiam"].HeaderText = "Mức giảm";
            dgv_voucher.Columns["yeucau"].HeaderText = "Yêu cầu";
            dgv_voucher.Columns["tenvoucher"].HeaderText = "Tên voucher";
        }

        private void dgv_voucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String tenvoucher = dgv_voucher.Rows[e.RowIndex].Cells[5].Value.ToString();

            txt_voucher.Text = tenvoucher;
        }

        private void btn_addvoucher_Click(object sender, EventArgs e)
        {
            if(txt_voucher.Text.Length == 0)
            {
                MessageBox.Show("Tên Voucher trống!!!. Vui lòng nhập Voucher");
            }
            else
            {
                txt_magiamgia.Text = txt_voucher.Text;

                int thanhtien_temp = thanhtien * 1000;
                VOUCHER voucher = voucherdal.loadInfoOfVoucher(txt_voucher.Text.Trim());
                if(voucher.mucgiam.Contains("%"))
                {
                    txt_giamphantram.Text = voucher.mucgiam.Substring(0, voucher.mucgiam.Length - 1);
                    txt_giamtien.Clear();

                    thanhtien_temp -= thanhtien_temp * int.Parse(voucher.mucgiam.Substring(0, voucher.mucgiam.Length - 1)) / 100;

                   
                }
                else
                {
                    int mucgiam = int.Parse(voucher.mucgiam);
                    txt_giamtien.Text = mucgiam.ToString("n0");
                    txt_giamphantram.Clear();

                    thanhtien_temp -= mucgiam;
                }
                txt_tongtien.Text = thanhtien_temp.ToString("n0");

                txt_voucher.Clear();
            }
        }

        private void btn_chuyenkhoan_Click(object sender, EventArgs e)
        {
            check_button = false;
            btn_chuyenkhoan.BaseColor = Color.FromArgb(151, 143, 255);
            btn_tienmat.BaseColor = Color.FromArgb(128, 255, 128);
        }

        private void btn_tienmat_Click(object sender, EventArgs e)
        {
            check_button = true;
            btn_tienmat.BaseColor = Color.FromArgb(151, 143, 255);
            btn_chuyenkhoan.BaseColor = Color.FromArgb(128, 255, 128);
        }

        

        private void btn_tratien_Click_1(object sender, EventArgs e)
        {
            bool check;
            int charLocation = txt_tongtien.Text.IndexOf(",", StringComparison.Ordinal);
            if (txt_magiamgia.Text.Length == 0)
            {
                check = hoadondal.thao_addInvoices(0, 1, int.Parse(txt_tongtien.Text.Substring(0, charLocation)), ghichu);
            }
            else
            {
                VOUCHER voucher = voucherdal.loadInfoOfVoucher(txt_magiamgia.Text.Trim());
                check = hoadondal.thao_addInvoices(voucher.id_voucher, 1, int.Parse(txt_tongtien.Text.Substring(0, charLocation)), ghichu);
            }
            if (check)
            {
                int id_hd = hoadondal.thao_getIdHD();
                foreach (Control c in panelhoadon.Controls)
                {
                    if (c is cardChiTietThucAn)
                    {
                        cardChiTietThucAn cardCheck = c as cardChiTietThucAn;

                        int id_mon = menudal.getIdMon(cardCheck.Tenmon);

                        bool check2 = hoadondal.thao_addDetailsOfInvoice(id_hd, id_mon, cardCheck.Soluong, cardCheck.Giaban);

                        if (!check2)
                        {
                            MessageBox.Show("Thêm thất bại");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
                return;
            }
            MessageBox.Show("Thêm thành công");

            panelhoadon.Controls.Clear();
        }

        private void btn_inhoadon_Click(object sender, EventArgs e)
        {
            int id_max = hoadondal.thao_getIdHD();

            HoaDon hd = new HoaDon();
            hd.Show();

            SqlConnection con = new SqlConnection("Data Source=103.183.121.70;Initial Catalog=QuanLyNhaHang;User ID=admin_nhahang;Password=123");
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from chitiethoadon, menu where chitiethoadon.id_mon = menu.id_mon and id_hd = @id_hd", con);
            cmd.Parameters.AddWithValue("id_hd", id_max);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            adap.Fill(ds);

            CrystalReport1 cr1 = new CrystalReport1();
            cr1.SetDatabaseLogon("admin_nhahang", "123");
            cr1.SetDataSource(ds);
            cr1.SetParameterValue(0, id_max);

            hd.crystalReportViewer1.ReportSource = cr1;
            hd.crystalReportViewer1.Refresh();

            con.Close();

            this.Dispose();
        }
    }
}
