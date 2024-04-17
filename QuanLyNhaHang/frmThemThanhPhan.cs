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
    public partial class frmThemThanhPhan : Form
    {
        NguyenLieuDAL nguyenlieudal = new NguyenLieuDAL();
        List<int> lst_maNguyenLieu = new List<int>();
        int ID = 0;
        public frmThemThanhPhan(int idMon)
        {
            InitializeComponent();
            ID = idMon;
            //MessageBox.Show("mã món :" + ID);
            loadDataGirdView();
        }


        public void loadHeader()
        {
            dtgv_nguyenlieu.AutoGenerateColumns = false;

            // Thêm cột số thứ tự
            dtgv_nguyenlieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Mã nguyên liệu ",
                DataPropertyName = "IdNguyenLieuLamMon",
                Visible = false

            });
            dtgv_nguyenlieu.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tên nguyên liệu",
                DataPropertyName = "TenNguyenLieu",
                Visible = true

            });
            //dtgv_nguyenlieu.Columns.Add(new DataGridViewCheckBoxColumn
            //{
            //    HeaderText = "checkBox",
            //    DataPropertyName = "IsSelected"

            //});
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
            {
                HeaderText = "checkBox",
                DataPropertyName = "checkBox"
            };
            dtgv_nguyenlieu.Columns.Add(checkBoxColumn);


        }
        public void loadDataGirdView()
        {
            dtgv_nguyenlieu.DataSource = null;
            dtgv_nguyenlieu.Columns.Clear();
            dtgv_nguyenlieu.Rows.Clear();
            loadHeader();
            dtgv_nguyenlieu.DataSource = nguyenlieudal.getALLNguyenLieuLamMon();
        }

        //private void dtgv_nguyenlieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dtgv_nguyenlieu.Columns[e.ColumnIndex].DataPropertyName == "Icon" && e.RowIndex >= 0)
        //    {
        //        string iconResourceName = "icontrash";

        //        if (!string.IsNullOrEmpty(iconResourceName))
        //        {
        //            // Nếu tên tài nguyên hình ảnh có giá trị, thì hiển thị ảnh từ tài nguyên
        //            e.Value = Properties.Resources.ResourceManager.GetObject(iconResourceName);
        //        }
        //        else
        //        {
        //            // Nếu không có tên tài nguyên, có thể hiển thị một ảnh mặc định hoặc để cột trống
        //            e.Value = null;
        //        }
        //    }
        //}

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

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_nguyenlieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                  int  maNguyenLieu = int.Parse( dtgv_nguyenlieu.Rows[e.RowIndex].Cells[0].Value.ToString());
                //  MessageBox.Show("Checkbox is checked in row with Name: " + cellValue1);
            
                    // Lấy giá trị của ô checkbox từ đối tượng dữ liệu

                object cellValue = dtgv_nguyenlieu.Rows[e.RowIndex].Cells[2].Value;

                DataGridViewCheckBoxCell cell = dtgv_nguyenlieu.Rows[e.RowIndex].Cells[2] as DataGridViewCheckBoxCell;
                bool newValue = !Convert.ToBoolean(cell.Value);
                cell.Value = newValue;
                if (newValue == true)
                {

               //     MessageBox.Show("Checkbox is checked in row with Name: " + maNguyenLieu);
                    lst_maNguyenLieu.Add(maNguyenLieu);
                    // DataGridViewCellStyle style = new DataGridViewCellStyle();
                    //style.BackColor = Color.FromArgb(255, 128, 0);
                    dtgv_nguyenlieu.Rows[e.RowIndex].Cells[1].Style.ForeColor = Color.Red;

                       // DataGridViewCheckBoxCell cell1 = dtgv_nguyenlieu.Rows[e.RowIndex].Cells[1] as DataGridViewCheckBoxCell;
                       // e.cell1.ForeColor = Color.FromArgb(255, 128, 0);
                    Console.WriteLine(lst_maNguyenLieu);
                }
                else
                {
                    lst_maNguyenLieu.Remove(maNguyenLieu);
                  //  MessageBox.Show("Đã out: " + maNguyenLieu);
                }        
          }
            

            
        }

        private void dtgv_nguyenlieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            //{
            //    string cellValue1 = dtgv_nguyenlieu.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    //  MessageBox.Show("Checkbox is checked in row with Name: " + cellValue1);

            //    // Lấy giá trị của ô checkbox từ đối tượng dữ liệu

            //    object cellValue = dtgv_nguyenlieu.Rows[e.RowIndex].Cells[2].Value;

            //    DataGridViewCheckBoxCell cell = dtgv_nguyenlieu.Rows[e.RowIndex].Cells[1] as DataGridViewCheckBoxCell;
            //    bool newValue = !Convert.ToBoolean(cell.Value);
            //    cell.Value = newValue;

            //    if (newValue == true)
            //    {
            //        // Checkbox được chọn: thay đổi màu chữ
            //        e.CellStyle.ForeColor = Color.FromArgb(255, 128, 0);
            //    }
            //    else
            //    {
            //        // Checkbox không được chọn: trả về màu chữ mặc định
            //        e.CellStyle.ForeColor = dtgv_nguyenlieu.DefaultCellStyle.ForeColor;
            //    }



            //}


        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)  // button them
        {
            if (lst_maNguyenLieu != null)
            {
                foreach(int i in lst_maNguyenLieu)
                {
                    int kt_NguyenLieuTonTai = nguyenlieudal.ktNguyenLieu(ID, i);
                    if (kt_NguyenLieuTonTai == 0)
                    {
                        int kt = nguyenlieudal.themNguyenLieu(ID, i);
                        this.Close();
                    }
                    else
                    {
                        int x = nguyenlieudal.xoaNguyenLieu(ID, i);
                        int kt = nguyenlieudal.themNguyenLieu(ID, i);
                        this.Close();
                    }
                                    
                }
                
            }




        }

     

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
             textBoxSearch.Text = "";
        }


        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            dtgv_nguyenlieu.DataSource = null;
            dtgv_nguyenlieu.Columns.Clear();
            dtgv_nguyenlieu.Rows.Clear();
            loadHeader();

            dtgv_nguyenlieu.DataSource = nguyenlieudal.timNguyenLieuLamMon(textBoxSearch.Text.Trim());        
   
            
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            {
                loadDataGirdView();
            }
        }
    }




}
