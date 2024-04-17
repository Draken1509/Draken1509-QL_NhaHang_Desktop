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
using Guna.UI.WinForms;
namespace QuanLyNhaHang
{
    public partial class frmSanPham : Form
    {
        MonAnDAL monanDal = new MonAnDAL();
        private GunaButton lastClickedButton;
        int idLoai=0;
        public frmSanPham()
        {
            InitializeComponent();
            InitializeSearchTextBox();
            loadDataGirdView(0,0);
            btn_tatCa.BaseColor = Color.FromArgb(255, 159, 3);
            cbo_themnhom.Visible = false;
        }
         public void loadDataGirdView(int c, int loai) 
         {
             dtgv_sanpham.DataSource = null;             
             dtgv_sanpham.Columns.Clear();
             dtgv_sanpham.Rows.Clear();
             loadHeader();
             if(c==0 && loai==0)
             {
                 dtgv_sanpham.DataSource = monanDal.getThongTinMonAn();
             }
             else
             {
                 dtgv_sanpham.DataSource = monanDal.getThongTinMonAnTheoLoai(loai);
             }
            
           
         }


         public void loadHeader()
         {
             dtgv_sanpham.AutoGenerateColumns = false;

             // Thêm cột số thứ tự
             dtgv_sanpham.Columns.Add(new DataGridViewTextBoxColumn
             {
                 HeaderText = "No.",
                 DataPropertyName = "Stt",
                   Visible=false

             });
             dtgv_sanpham.Columns.Add(new DataGridViewTextBoxColumn
             {
                 HeaderText = "No.",
                 DataPropertyName = "Id_mon",
                 Visible=false

             });
             dtgv_sanpham.Columns.Add(new DataGridViewTextBoxColumn
             {
                 HeaderText = "Mã món",
                 DataPropertyName = "Id_loai",
                     Visible=false

             });      
             dtgv_sanpham.Columns.Add(new DataGridViewTextBoxColumn
             {
                 HeaderText = "Tên món",
                 DataPropertyName = "Tenmon"

             });
             dtgv_sanpham.Columns.Add(new DataGridViewTextBoxColumn
             {
                 HeaderText = "Giá bán",
                 DataPropertyName = "Giaban"

             });
             dtgv_sanpham.Columns.Add(new DataGridViewTextBoxColumn
             {
                 HeaderText = "Ghi chú",
                 DataPropertyName = "Ghichu",
                     Visible=false

             });
             dtgv_sanpham.Columns.Add(new DataGridViewTextBoxColumn
             {
                 HeaderText = "Hình",
                 DataPropertyName = "Hinh",
                     Visible=false

             });
             dtgv_sanpham.Columns.Add(new DataGridViewImageColumn
             {
                 HeaderText = "",
                 DataPropertyName = "Icon"

             });
            
         }

        private void gunaImageButton2_Click(object sender, EventArgs e)
        {
            cbo_themnhom.DroppedDown = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }            
        private void InitializeSearchTextBox()
        {
            textBoxSearch.Text = "Tìm kiếm theo tên món, loại món, giá tiền";
            textBoxSearch.ForeColor = SystemColors.GrayText;
            textBoxSearch.Enter += textBoxSearch_MouseEnter;
            textBoxSearch.Leave += textBoxSearch_MouseLeave;
        }    
        private void textBoxSearch_MouseEnter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Tìm kiếm theo tên món, loại món, giá tiền")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = SystemColors.WindowText;
            }   
        }
        private void textBoxSearch_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = "Tìm kiếm theo tên món, loại món, giá tiền";
                textBoxSearch.ForeColor = SystemColors.GrayText;
            }
        }

        private void dtgv_sanpham_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgv_sanpham.Columns[e.ColumnIndex].DataPropertyName == "Icon" && e.RowIndex >= 0)
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
        private void ChangeButtonColor(GunaButton button)
        {
            // Đặt màu của nút mới được nhấn
            button.BaseColor = Color.FromArgb(255, 159, 3);

            // Nếu đã có một nút được nhấn trước đó, đặt lại màu của nó
            if (lastClickedButton != null && lastClickedButton != button)
            {
                lastClickedButton.BaseColor = SystemColors.Control; // Màu mặc định hoặc màu bạn muốn
            }

            // Lưu trạng thái của nút mới được nhấn
            lastClickedButton = button;

            // Thực hiện các hành động khác khi nút được nhấn
        }
        private void btn_tatCa_Click(object sender, EventArgs e)
        {
            idLoai = 0;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 0);
         
        }


        private void btn_Burger_Click(object sender, EventArgs e)
        {
            idLoai = 1;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 1);
        }

        private void btn_friedChicken_Click(object sender, EventArgs e)
        {
            idLoai = 2;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 2);
        }

        private void btn_wwing_Click(object sender, EventArgs e)
        {
            idLoai = 3;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 3);
        }

        private void btn_spy_Click(object sender, EventArgs e)
        {
            idLoai = 4;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 4);
        }

        private void btn_Bento_Click(object sender, EventArgs e)
        {
            idLoai = 5;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 5);
        }

        private void btn_snack_Click(object sender, EventArgs e)
        {
            idLoai = 6;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 6);
        }

        private void btn_drink_Click(object sender, EventArgs e)
        {
            idLoai = 7;
            ChangeButtonColor((GunaButton)sender);
            loadDataGirdView(0, 7);
        }

        private void dtgv_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0) // Cột thứ 7, vị trí bắt đầu từ 0
                {
                   string cellValue = dtgv_sanpham.Rows[e.RowIndex].Cells[3].Value.ToString();
                   
                   int idMon = int.Parse(dtgv_sanpham.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());
               
                   DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm "+ cellValue +" không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    // Kiểm tra kết quả từ hộp thoại xác nhận
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            int kt = monanDal.xoa(idMon);
                            loadDataGirdView(0, idLoai);
                        }
                        catch(Exception ex)
                        {

                        }
                                        
                    }
            }
            else
            {
                int idMon = int.Parse(dtgv_sanpham.Rows[e.RowIndex].Cells[1].Value.ToString().Trim());
                frmThemSP frmthemsp = new frmThemSP(idMon);           
                frmthemsp.FormBorderStyle = FormBorderStyle.None;
                frmthemsp.WindowState = FormWindowState.Maximized;
                frmthemsp.BringToFront();
                frmthemsp.FormClosed += FormMoi_FormClosed;
                frmthemsp.ShowDialog();                         
            }

        }
        private void FormMoi_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadDataGirdView(0, idLoai);
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            string str = textBoxSearch.Text.ToString().Trim();
            dtgv_sanpham.DataSource = monanDal.timKiem(str);
            if (dtgv_sanpham.RowCount == 0)
            {
                MessageBox.Show("Không tìm thấy thông tin món ăn");
            }
            else
            {               

            }

        }

        private void dtgv_sanpham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
          var index = (e.RowIndex + 1).ToString();
          Font font = new Font(dtgv_sanpham.DefaultCellStyle.Font.FontFamily, 15, GraphicsUnit.Pixel);

                // Tạo một đối tượng Brush để vẽ số thứ tự
                var centerFormat = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // Tính toán vị trí để vẽ số thứ tự
                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, dtgv_sanpham.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(index, font, SystemBrushes.ControlText, headerBounds, centerFormat);
            
        }

        private void btn_themSP_Click(object sender, EventArgs e)
        {

            frmMainThemMenu frmthemsp = new frmMainThemMenu();
            frmthemsp.FormBorderStyle = FormBorderStyle.None;
            frmthemsp.WindowState = FormWindowState.Maximized;
            frmthemsp.BringToFront();
            frmthemsp.FormClosed += FormMoi_FormClosed;
            frmthemsp.ShowDialog();     
        }

    

    }
}
