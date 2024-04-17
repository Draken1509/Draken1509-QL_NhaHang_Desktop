using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControlThongKe;
using System.IO;

namespace CustomControlThongKe
{
    public partial class cardThucAn : UserControl
    {
        FlowLayoutPanel panelhoadon;
        public cardThucAn(FlowLayoutPanel panelhoadon)
        {
            InitializeComponent();
            //
            txt_tenmon.AutoSize = true;
            txt_tenmon.MaximumSize = new Size(131, 50);
            txt_tenmon.AutoEllipsis = true;
            txt_tenmon.TextAlign = ContentAlignment.MiddleCenter;

            pic_food.MouseDown += MyUserControl_MouseDown;
            pic_food.MouseUp += MyUserControl_MouseUp;
            pic_food.MouseEnter += MyUserControl_MouseEnter;
            pic_food.MouseLeave += MyUserControl_MouseLeave;
            pic_food.Click += CardThucAn_Click;

            this.panelhoadon = panelhoadon;
            this.MouseDown += MyUserControl_MouseDown;
            this.MouseUp += MyUserControl_MouseUp;
            this.MouseEnter += MyUserControl_MouseEnter;
            this.MouseLeave += MyUserControl_MouseLeave;
            this.Click += CardThucAn_Click;
        }

        private void CardThucAn_Click(object sender, EventArgs e)
        {
            frmChiTiet frmchitiet = new frmChiTiet(tenmon, panelhoadon, hinh);
            frmchitiet.Show();
        }

        private void MyUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            // Thay đổi màu sắc khi người dùng nhấn chuột
            this.BackColor = Color.Red;
        }

        private void MyUserControl_MouseUp(object sender, MouseEventArgs e)
        {
            // Đặt lại màu sắc khi người dùng thả nút chuột
            this.BackColor = Color.White;
        }
        private void MyUserControl_MouseEnter(object sender, EventArgs e)
        {
            // Thực hiện hành động khi con trỏ chuột rê tới
            this.BackColor = Color.Yellow;
        }
        private void MyUserControl_MouseLeave(object sender, EventArgs e)
        {
            // Thực hiện hành động khi con trỏ chuột rời khỏi vùng User Control
            this.BackColor = Color.White;
        }
        private String tenmon;

        public String Tenmon
        {
            get { return tenmon; }
            set { 
                tenmon = value;
                txt_tenmon.Text = value;
            }
        }
        private int giaban;

        public int Giaban
        {
            get { return giaban; }
            set { 
                giaban = value;
                txt_giaban.Text = value.ToString() + ",000";
            }
        }
        private String hinh;
        public String Hinh
        {
            get { return hinh; }
            set
            {
                hinh = value;
                //Object rm = Properties.Resources.ResourceManager.GetObject(value);
                //Bitmap myImage = (Bitmap)rm;
                //pic_food.Image = myImage;

                //load anh new
                string imagePath = @"../../../DAL/CommonImage/" + value;
                //--------------------------------------------------Load Anh
                if (File.Exists(imagePath))
                {
                    using (FileStream fileStream = File.Open(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        Image myImage = Image.FromStream(fileStream);

                        // Gán ảnh cho PictureBox hoặc nơi cần sử dụng
                        pic_food.BackgroundImageLayout = ImageLayout.Stretch;
                        pic_food.Image = myImage;
                    }

                }

                else
                {
                    //MessageBox.Show("Không tìm thấy tệp hình ảnh!");
                }

            }
        }
    }
}
