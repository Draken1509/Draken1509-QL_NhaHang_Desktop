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
using DTO;
using System.IO;

namespace CustomControlThongKe
{
    public partial class frmChiTiet : Form
    {
        DoAnKemDAL dak = new DoAnKemDAL();
        MenuDAL dal = new MenuDAL();
        MENU menu = new MENU();
        FlowLayoutPanel panelhoadon;

        public frmChiTiet(String tenmon, FlowLayoutPanel panelhoadon, String hinh)
        {
            InitializeComponent();
            this.panelhoadon = panelhoadon;
            this.Tenmon = tenmon;
            this.Hinh = hinh;
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            int soluong = int.Parse(txt_soluong.Text);
            soluong++;
            txt_soluong.Text = soluong.ToString();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            int soluong = int.Parse(txt_soluong.Text);
            soluong--;
            if(soluong < 0)
            {
                txt_soluong.Text = "0";
            }
            else
            {
                txt_soluong.Text = soluong.ToString();
            }
        }

        private void frmChiTiet_Load(object sender, EventArgs e)
        {
            txt_tenmon.Text = tenmon;
            menu = dal.getDetailOfFood(tenmon);
            Ghichu = menu.ghichu;
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
        private String ghichu;

        public String Ghichu
        {
            get { return ghichu; }
            set { 
                ghichu = value;
                txt_ghichu.Text = value;
            }
        }
        private String hinh;

        public String Hinh
        {
            get { return hinh; }
            set { 
                hinh = value;
                //Object rm = Properties.Resources.ResourceManager.GetObject(value);
                //Bitmap myImage = (Bitmap)rm;
                //pic_food.Image = myImage;

                //load hinh new
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

        private void btn_addtocart_Click(object sender, EventArgs e)
        {
            menu = dal.getDetailOfFood(tenmon);

            Cart_Item item = new Cart_Item();
            item.soluong = int.Parse(txt_soluong.Text);
            item.tenmon = menu.tenmon;
            item.giaban = menu.giaban.Value;

            cardChiTietThucAn card = new cardChiTietThucAn(item, panelhoadon);

            //kiem tra trung mon
            foreach(Control c in panelhoadon.Controls)
            {
                if(c is cardChiTietThucAn)
                {
                    cardChiTietThucAn cardCheck = c as cardChiTietThucAn;
                    if(card.Tenmon.Equals(cardCheck.Tenmon))
                    {
                        card.Soluong += cardCheck.Soluong;

                        panelhoadon.Controls.Remove(cardCheck);
                    }
                }
            }

            panelhoadon.Controls.Add(card);
            this.Close();
        }
    }
}
