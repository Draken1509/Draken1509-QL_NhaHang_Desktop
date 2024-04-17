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

namespace QuanLyNhaHang
{
    public partial class frmVoucher : Form
    {
        VoucherDAL voucherDAL = new VoucherDAL();
        public frmVoucher()
        {
            InitializeComponent();          
            dtgv_voucher.DataSource = voucherDAL.loadVoucher();

            dtgv_voucher.Columns["Id"].HeaderText = "Mã";
            dtgv_voucher.Columns["TenVoucher"].HeaderText = "Tên Voucher";
            dtgv_voucher.Columns["MucGiam"].HeaderText = "Mức Giảm";

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgv_voucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgv_voucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                VOUCHER voucher = voucherDAL.loadInfoOfVoucher(dtgv_voucher.Rows[e.RowIndex].Cells[2].Value.ToString());

                txt_mavoucher.Text = voucher.id_voucher.ToString();
                if (voucher.mucgiam.Contains("%"))
                {
                    txt_mucgiam.Text = voucher.mucgiam;
                }
                else
                {
                    int mucgiam = int.Parse(voucher.mucgiam);
                    txt_mucgiam.Text = mucgiam.ToString("n0");
                }
                String ngaybatdau = voucher.ngaybatdau.ToString();
                txt_ngaybatdau.Text = ngaybatdau;
                txt_ngayhethan.Text = voucher.ngayhethan.ToString();
                txt_tenvoucher.Text = voucher.tenvoucher;
                txt_yeucau.Text = voucher.yeucau + ",000";
            }
            catch (Exception ex)
            {

            }
        }

        private void gunaImageButton4_Click(object sender, EventArgs e)
        {

        }
    }
}
