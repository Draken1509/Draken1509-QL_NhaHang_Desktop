using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;

namespace CustomControlThongKe
{
    public partial class cardChiTietThucAn : UserControl
    {
        FlowLayoutPanel panelhoadon;
        public cardChiTietThucAn(Cart_Item item, FlowLayoutPanel panelhoadon)
        {
            InitializeComponent();
            Soluong = item.soluong;
            Giaban = item.giaban;
            Tenmon = item.tenmon;
            this.panelhoadon = panelhoadon;

            //loadScreen();
        }

        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { 
                soluong = value;
                txt_soluong.Text = "x" + value;
            }
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
                txt_giaban.Text = value + ",000";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món ăn này", "Thông báo", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                foreach (Control c in panelhoadon.Controls)
                {
                    if (c is cardChiTietThucAn)
                    {
                        cardChiTietThucAn cardCheck = c as cardChiTietThucAn;
                        if (cardCheck.tenmon.Equals(tenmon))
                        {
                            panelhoadon.Controls.Remove(cardCheck);
                        }
                    }
                }
            }
        }

        //private void loadScreen()
        //{
        //    if (list.ToArray().Length > 0) // Xử lý tăng kích thước tương ứng với số item món ăn kèm (cái này vd nên lấy đại sl của món ăn)
        //    {
        //        List<string> monAnKemList = new List<string>();
        //        foreach(Cart_Item item in list)
        //        {
        //            String food = "x" + item.soluong + " " + item.tenmon + " - " + item.giaban + ",000";
        //            monAnKemList.Add(food);
                   
        //        }
        //         this.Size = new Size(this.Size.Width, this.Size.Height + 14 * list.ToArray().Length);
        //        txt_monankem.Text = string.Join(Environment.NewLine, monAnKemList);
        //    }
        //    txt_monankem.AutoSize = true;
        //    txt_monankem.MaximumSize = new Size(250, 0);
        //    txt_monankem.AutoEllipsis = true;

        //    txt_tenmon.AutoSize = true;
        //    txt_tenmon.MaximumSize = new Size(235, 0);
        //    txt_tenmon.AutoEllipsis = true;
        //}

    }
}
