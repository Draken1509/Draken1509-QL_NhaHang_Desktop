using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControlThongKe;
using DAL;
using DTO;
using Guna.UI.WinForms;

namespace QuanLyNhaHang
{
    public partial class frmDonOnline : Form
    {
        DonHangOnlineDAL donhangonline = new DonHangOnlineDAL();
        MenuDAL menu = new MenuDAL();
        public frmDonOnline()
        {
            InitializeComponent();
        }


        private void frmDonOnline_Load(object sender, EventArgs e)
        {
            loadData(0);
            changeBackColorOfButton("Chờ duyệt");
        }
        private void loadData(int dieukien)
        {
            //
            if (panel_thongtindh.Controls.Count > 0)
            {
                panel_thongtindh.Controls.Clear();
            }
            //
            List<DONHANGONLINE> list = new List<DONHANGONLINE>();
            list = donhangonline.getDonHangOnline(dieukien);
            foreach (DONHANGONLINE i in list)
            {
                List<ChiTiet> list_details = new List<ChiTiet>();
                int id_dho = int.Parse(i.id_dho.ToString());
                DangXuLY card = new DangXuLY();
                if (id_dho < 9)
                {
                    card.Madonhangonline = "(HD00" + id_dho.ToString() + ")";
                }
                else
                {
                    card.Madonhangonline = "(HD0" + id_dho.ToString() + ")";
                }
                if(dieukien != -1)
                {
                    card.Tinhtranghoadon = dieukien;
                    card.ButtonName = dieukien;
                }
                else
                {
                    card.Tinhtranghoadon = i.tinhtranghoadon.Value;
                    card.ButtonName = i.tinhtranghoadon.Value;
                }
                
                int tong = i.tongtien.Value;
                if (tong < 1000)
                {
                    card.Tongtien = tong + ",000";
                }
                else
                {
                    card.Tongtien = tong.ToString("n0");
                }


                card.Khachhang = i.hoten.ToString() + " - " + i.sdt.ToString();

                List<CHITIETDONHANGONLINE> chitiet_list = donhangonline.getChiTietDonHangOnline(id_dho);

                List<MENU> list_food = new List<MENU>();
                list_food = menu.getMenu();

                foreach (CHITIETDONHANGONLINE t in chitiet_list)
                {
                    foreach (MENU j in list_food)
                    {
                        if (t.id_mon == j.id_mon)
                        {
                            ChiTiet chitiet = new ChiTiet();
                            chitiet.giaban = j.giaban.Value;
                            chitiet.id_mon = j.id_mon;
                            chitiet.sl = t.sl.Value;
                            chitiet.tenmon = j.tenmon;
                            chitiet.tongtien = i.tongtien.Value;

                            list_details.Add(chitiet);
                        }
                    }
                }
                card.chitiet = list_details;
                card.loadChitiet();

                panel_thongtindh.Controls.Add(card);
            }
        }

        private void btn_choduyet_Click(object sender, EventArgs e)
        {
            loadData(0);
            changeBackColorOfButton("Chờ duyệt");
        }

        private void btn_dangxuly_Click(object sender, EventArgs e)
        {
            loadData(1);
            changeBackColorOfButton("Đang xử lý");
        }

        private void btn_dangvanchuyen_Click(object sender, EventArgs e)
        {
            loadData(2);
            changeBackColorOfButton("Đang vận chuyển");
        }

        private void btn_hoanthanh_Click(object sender, EventArgs e)
        {
            loadData(3);
            changeBackColorOfButton("Hoàn thành");
        }

        private void btn_dahuy_Click(object sender, EventArgs e)
        {
            loadData(4);
            changeBackColorOfButton("Đã hủy");
        }
        private void changeBackColorOfButton(String nameOfButton)
        {
            foreach (Control c in this.panel6.Controls)
            {
                //MessageBox.Show(c.GetType().ToString());
                GunaButton btn = c as GunaButton;
                if (btn != null) // if c is another type, btn will be null
                {
                    //MessageBox.Show(btn.Text + " - " + nameOfButton);
                    if (btn.Text.Equals(nameOfButton))
                    {
                        btn.BaseColor = Color.Green;
                        btn.ForeColor = Color.White;
                    }
                    else
                    {
                        btn.BaseColor = Color.White;
                        btn.ForeColor = Color.Gray;
                    }
                }
            }
        }

        private void txt_timkiem_Click(object sender, EventArgs e)
        {
            txt_timkiem.Clear();
        }

        private void txt_timkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loadData(-1);

                List<DangXuLY> list_search = new List<DangXuLY>();

                //filter
                foreach(Control c in panel_thongtindh.Controls)
                {
                    if(c is DangXuLY)
                    {
                        DangXuLY card = c as DangXuLY;

                        if(card.Madonhangonline.Contains(txt_timkiem.Text))
                        {
                            list_search.Add(card);
                        }
                    }
                }

                //clear panel
                if (panel_thongtindh.Controls.Count > 0)
                {
                    panel_thongtindh.Controls.Clear();
                }

                //add card to panel
                foreach(DangXuLY dxl in list_search)
                {
                    panel_thongtindh.Controls.Add(dxl);
                }
            }
        }
    }
}
