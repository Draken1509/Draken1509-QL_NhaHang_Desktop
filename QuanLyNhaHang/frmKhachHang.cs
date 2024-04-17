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
    public partial class frmKhachHang : Form
    {
        NhanVienDAL nhanviendal = new NhanVienDAL();
        int position = -1;
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            loadNhanVien();
            loadPhanQuyen();
            loadTinhTrangLamViec();
            txt_password.Enabled = false;
        }
        private void loadNhanVien()
        {
            dgv_nhanvien.DataSource = nhanviendal.loadNhanVien();

            dgv_nhanvien.Columns["id_nv"].HeaderText = "Mã nhân viên";
            dgv_nhanvien.Columns["tennv"].HeaderText = "Tên nhân viên";
            dgv_nhanvien.Columns["tinhtranglamviec"].HeaderText = "Tình trạng làm việc";

            dgv_nhanvien.AutoResizeColumns();
            dgv_nhanvien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void loadPhanQuyen()
        {
            cbo_quyen.DataSource = nhanviendal.loadPhanQuyen();
            cbo_quyen.DisplayMember = "phanquyen";
            cbo_quyen.ValueMember = "id_quyen";
        }
        private void loadTinhTrangLamViec()
        {
            List<TinhTrangLamViec> list_thao = new List<TinhTrangLamViec>();

            TinhTrangLamViec a = new TinhTrangLamViec();
            a.tinhtranglamviec = 0;
            a.ten = "Đã nghỉ việc";

            TinhTrangLamViec b = new TinhTrangLamViec();
            b.tinhtranglamviec = 1;
            b.ten = "Đang làm việc";

            list_thao.Add(a);
            list_thao.Add(b);

            cbo_tinhtranglamviec.DataSource = list_thao;
            cbo_tinhtranglamviec.DisplayMember = "ten";
            cbo_tinhtranglamviec.ValueMember = "tinhtranglamviec";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textbox = c as TextBox;
                    textbox.Clear();
                }
            }
            lockUI(true);
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (txt_password.Enabled)
            {
                if (cbo_tinhtranglamviec.SelectedValue.ToString() == "1")
                {
                    check = nhanviendal.addNhanVien(int.Parse(cbo_quyen.SelectedValue.ToString()), txt_tennv.Text, true, txt_username.Text, txt_password.Text);
                }
                else
                {
                    check = nhanviendal.addNhanVien(int.Parse(cbo_quyen.SelectedValue.ToString()), txt_tennv.Text, false, txt_username.Text, txt_password.Text);
                }
            }
            else
            {
                if (cbo_tinhtranglamviec.SelectedValue.ToString() == "1")
                {
                    check = nhanviendal.editNhanVien(int.Parse(cbo_quyen.SelectedValue.ToString()), txt_tennv.Text, true, txt_username.Text, int.Parse(dgv_nhanvien.Rows[position].Cells[0].Value.ToString()));
                }
                else
                {
                    check = nhanviendal.editNhanVien(int.Parse(cbo_quyen.SelectedValue.ToString()), txt_tennv.Text, false, txt_username.Text, int.Parse(dgv_nhanvien.Rows[position].Cells[0].Value.ToString()));
                }
            }
            if (check)
            {
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            loadNhanVien();
        }
        private void lockUI(bool check)
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textbox = c as TextBox;
                    textbox.Enabled = check;
                }
                if (c is ComboBox)
                {
                    ComboBox combobox = c as ComboBox;
                    combobox.Enabled = check;
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            bool check = nhanviendal.deleteNhanVien(int.Parse(dgv_nhanvien.Rows[position].Cells[0].Value.ToString()));

            if (check)
            {
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            loadNhanVien();
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            txt_tennv.Enabled = true;
            cbo_quyen.Enabled = true;
            cbo_tinhtranglamviec.Enabled = true;
            txt_username.Enabled = true;
        }

        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            position = e.RowIndex;

            txt_tennv.Text = dgv_nhanvien.Rows[e.RowIndex].Cells[1].Value.ToString();

            NHANVIEN nhanvien = nhanviendal.getThongTinNhanVien(int.Parse(dgv_nhanvien.Rows[e.RowIndex].Cells[0].Value.ToString()));

            txt_username.Text = nhanvien.username;

            if (nhanvien.tinhtranglamviec.Value)
            {
                cbo_tinhtranglamviec.SelectedValue = 1;
            }
            else
            {
                cbo_tinhtranglamviec.SelectedValue = 0;
            }

            cbo_quyen.SelectedValue = nhanvien.id_quyen;

            lockUI(false);
        }
    }
}
