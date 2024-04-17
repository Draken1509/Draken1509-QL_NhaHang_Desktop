using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;
using DTO;
using DAL;

namespace CustomControlThongKe
{
    public partial class DangXuLY : UserControl
    {
        DonHangOnlineDAL onlinedal = new DonHangOnlineDAL();
        public DangXuLY()
        {
            InitializeComponent();
            btn_xuly.Click += btn_xuly_Click;
        }

        private String thoigiandat;

        public String Thoigiandat
        {
            get { return thoigiandat; }
            set
            {
                thoigiandat = value;
                txt_thoigiandat.Text = value;
            }
        }
        private String madonhangonline;

        public String Madonhangonline
        {
            get { return madonhangonline; }
            set
            {
                madonhangonline = value;
                txt_id.Text = value;
            }
        }
        private String khachhang;

        public String Khachhang
        {
            get { return khachhang; }
            set
            {
                khachhang = value;
                txt_khachhang.Text = value;
            }
        }
        private String tongtien;

        public String Tongtien
        {
            get { return tongtien; }
            set
            {
                tongtien = value;
                txt_giatien.Text = value;
            }
        }
        private void btn_huy_Click(object sender, EventArgs e)
        {
            String mahd = txt_id.Text.Substring(txt_id.Text.Length - 3, 2);
            int id = int.Parse(mahd);
            bool check = onlinedal.editStatus(id, 4);
            if (!check)
            {
                MessageBox.Show("Fail");
                return;
            }
            this.Visible = false;
        }

        //private int tinhtranghoadon;

        //public int Tinhtranghoadon
        //{
        //    get { return tinhtranghoadon; }
        //    set
        //    {
        //        tinhtranghoadon = value;
        //        if (value == 0)
        //        {
        //            txt_trangthai.Text = "Chờ duyệt";
        //            //button
        //            GunaButton b = new GunaButton();
        //            b.Size = new Size(174, 52);
        //            b.Image = null;
        //            b.Text = "Hủy đơn";
        //            b.ForeColor = Color.White;
        //            b.Top = 48;
        //            b.TextAlign = HorizontalAlignment.Center;
        //            b.Font = new Font("Segoe UI", 12);
        //            b.Left = 150;
        //            b.Click += btn_huy_Click;
        //            panel4.Controls.Add(b);
        //            btn_xuly.Text = "Duyệt";
        //            btn_xuly.Left = 350;
        //        }
        //        else if (value == 0)
        //        {
        //            txt_trangthai.Text = "Chờ duyệt";
        //            //button
        //            btn_xuly.Text = "Duyệt";
        //        }
        //        else if (value == 1)
        //        {
        //            txt_trangthai.Text = "Đang xử lý";
        //            //button
        //            btn_xuly.Text = "Giao hàng";
        //        }
        //        else if (value == 2)
        //        {
        //            txt_trangthai.Text = "Đang vận chuyển";
        //            //button
        //            btn_xuly.Text = "Hoàn thành";
        //        }
        //        else if (value == 3)
        //        {
        //            txt_trangthai.Text = "Hoàn thành";
        //            //button
        //            txt_thanhtoan.Text = "Đã thanh toán";
        //            btn_xuly.Visible = false;
        //        }
        //        else
        //        {
        //            txt_trangthai.Text = "Đã hủy";
        //            btn_xuly.Visible = false;
        //        }
        //    }
        //}

        private int tinhtranghoadon;

        public int Tinhtranghoadon
        {
            get { return tinhtranghoadon; }
            set
            {
                tinhtranghoadon = value;
                if(value == 0)
                {
                    txt_trangthai.Text = "Chờ duyệt";
                }
                else if(value == 1)
                {
                    txt_trangthai.Text = "Đang xử lý";
                }
                else if(value == 2)
                {
                    txt_trangthai.Text = "Đang vận chuyển";
                }
                else if(value == 3)
                {
                    txt_trangthai.Text = "Hoàn thành";
                }
                else
                {
                    txt_trangthai.Text = "Đã huỷ";
                }
                //txt_thanhtoan.Text = value.ToString();
            }
        }

        public int ButtonName
        {
            get
            {
                return buttonName;
            }
            set
            {
                buttonName = value;
                //txt_trangthai.Text = value;
                if (value == 0)
                {
                    GunaButton b = new GunaButton();
                    b.Size = new Size(174, 40);
                    b.Image = null;
                    b.Text = "Hủy đơn";
                    b.ForeColor = Color.White;
                    b.Top = 40;
                    b.TextAlign = HorizontalAlignment.Center;
                    b.Font = new Font("Segoe UI", 12);
                    b.Left = 150;
                    b.Click += btn_huy_Click;
                    panel4.Controls.Add(b);
                    btn_xuly.Text = "Duyệt";
                    btn_xuly.Left = 350;
                }
                else if (value == 1)
                {
                    btn_xuly.Text = "Giao hàng";
                }
                else if (value == 2)
                {
                    btn_xuly.Text = "Hoàn thành";
                }
                else
                {
                    btn_xuly.Visible = false;
                }
                //if (txt_trangthai.Text.Equals("Chờ duyệt"))
                //{
                //    GunaButton b = new GunaButton();
                //    b.Size = new Size(260, 74);
                //    b.Text = "Hủy đơn";
                //    b.Top = 44;
                //    b.ForeColor = Color.Black;
                //    b.Left = 80;
                //    b.Click += btn_huy_Click;
                //    panel4.Controls.Add(b);
                //    btn_xuly.Text = "Duyệt";
                //    btn_xuly.Left = 350;
                //}
                //else if (txt_trangthai.Text.Equals("Đang xử lý"))
                //{
                //    btn_xuly.Text = "Giao hàng";
                //}
                //else if (txt_trangthai.Text.Equals("Đang vận chuyển"))
                //{
                //    btn_xuly.Text = "Hoàn thành";
                //}
                //else
                //{
                //    btn_xuly.Visible = false;
                //}
            }
        }

        private int buttonName;

        private void btn_xuly_Click(object sender, EventArgs e)
        {
            String mahd = txt_id.Text.Substring(txt_id.Text.Length - 3, 2);
            int id = int.Parse(mahd);
            bool check;
            if (btn_xuly.Text.Equals("Duyệt"))
            {
                check = onlinedal.editStatus(id, 1);
            }
            else if (btn_xuly.Text.Equals("Giao hàng"))
            {
                check = onlinedal.editStatus(id, 2);
            }
            else
            {
                check = onlinedal.editStatus(id, 3);
            }
            if (!check)
            {
                MessageBox.Show("Fail");
            }
            else
            {
                this.Visible = false;
            }
        }
        public List<ChiTiet> chitiet { get; set; }

        public void loadChitiet()
        {
            int top = 20;
            foreach (ChiTiet i in chitiet)
            {
                Label l = new Label();
                l.Top = top;
                l.Left = 20;
                l.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                l.Text = i.sl + " x " + i.tenmon;
                l.AutoSize = true;
                panel2.Controls.Add(l);
                top += 40;
            }

        }
    }
}
