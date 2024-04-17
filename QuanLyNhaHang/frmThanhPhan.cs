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
    public partial class frmThanhPhan : Form
    {
        NguyenLieuDAL nguyenlieudal = new NguyenLieuDAL();
        int IDMON = 0;
        public frmThanhPhan(int  idMon)
        {
            InitializeComponent();
            IDMON = idMon;
            loadDataGirdView();
            
        }

        public  void loadHeader()
        {
        //    dtgv_nguyenlieu.AutoGenerateColumns = false;

            // Thêm cột số thứ tự
            dtgv_nguyenlieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã nguyên liệu",
                DataPropertyName = "IdNguyenLieuLamMon",
                Visible = false

            });
            dtgv_nguyenlieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên nguyên liệu",
                DataPropertyName = "TenNguyenLieu",
                Visible = true

            });
            dtgv_nguyenlieu.Columns.Add(new DataGridViewImageColumn
            {
                HeaderText = "",
                DataPropertyName = "Icon"

            });
            dtgv_nguyenlieu.Columns.Add(new DataGridViewCheckBoxColumn
            {
                HeaderText = "checkbox",
                DataPropertyName = "IsSelected",
                 Visible = false

            });
        }
        public void loadDataGirdView()
        {
            dtgv_nguyenlieu.DataSource = null;
            dtgv_nguyenlieu.Columns.Clear();
            dtgv_nguyenlieu.Rows.Clear();
            loadHeader();
            dtgv_nguyenlieu.DataSource = nguyenlieudal.getNguyenLieuLamMon(IDMON);
            if (dtgv_nguyenlieu.RowCount == 0)
            {
                lbl_msg.Text = "Món ăn này không có nguyên liệu";
            }
            else
            {
                lbl_msg.Visible = false;
            }
        }

        private void dtgv_nguyenlieu_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var index = (e.RowIndex + 1).ToString();
            Font font = new Font(dtgv_nguyenlieu.DefaultCellStyle.Font.FontFamily, 15, GraphicsUnit.Pixel);

            // Tạo một đối tượng Brush để vẽ số thứ tự
            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Tính toán vị trí để vẽ số thứ tự
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dtgv_nguyenlieu.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(index, font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dtgv_nguyenlieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dtgv_nguyenlieu.Columns[e.ColumnIndex].DataPropertyName == "Icon" && e.RowIndex >= 0)
            {
                string iconResourceName = "icontrash";

                if (!string.IsNullOrEmpty(iconResourceName))
                {
                    // Nếu tên tài nguyên hình ảnh có giá trị, thì hiển thị ảnh từ tài nguyên
                    e.Value = Properties.Resources.ResourceManager.GetObject(iconResourceName);
                }
                else
                {
                    // Nếu không có tên tài nguyên, có thể hiển thị một ảnh mặc định hoặc để cột trống
                    e.Value = null;
                }
            }
        }

        private void dtgv_nguyenlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0) // Cột thứ 7, vị trí bắt đầu từ 0
            {
                string cellValue =  dtgv_nguyenlieu.Rows[e.RowIndex].Cells[1].Value.ToString();
                int idNguyenlieu = int.Parse(dtgv_nguyenlieu.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());

               // int idMon = int.Parse(dtgv_nguyenlieu.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn nguyên liệu " + cellValue + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra kết quả từ hộp thoại xác nhận
                if (result == DialogResult.Yes)
                {
                    try
                    {
                       // int kt = monanDal.xoa(idMon);
                       // loadDataGirdView(0, idLoai);
                        int kt = nguyenlieudal.xoaNguyenLieu(IDMON, idNguyenlieu);
                        if (kt == 1)
                        {
                          //  MessageBox.Show("Xóa thành công: " + cellValue);
                            loadDataGirdView();
                        }                          
                        else
                            MessageBox.Show("Xóa thất bại: " + cellValue);
                    }
                    catch (Exception ex)
                    {
                       
                    }

                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            frmThemThanhPhan frm = new frmThemThanhPhan(IDMON);
            //frm.TopLevel = false;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;      
            frm.Show();



            //frmthemsp.FormBorderStyle = FormBorderStyle.None;
            //frmthemsp.WindowState = FormWindowState.Maximized;
            //frmthemsp.BringToFront();
            //frmthemsp.FormClosed += FormMoi_FormClosed;
        }
        private void CenterFormOnScreen()
        {
           
        }

        private void frmThanhPhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadDataGirdView();
        }



    }
}
