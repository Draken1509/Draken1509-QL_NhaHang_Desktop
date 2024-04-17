using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;
using Guna.UI.WinForms;
using CustomControlThongKe;

namespace QuanLyNhaHang
{
    public partial class frmTaiQuay : Form
    {
        MenuDAL dal = new MenuDAL();
        LoaiDAL loai = new LoaiDAL();
        int tong = 0;
        public frmTaiQuay()
        {
            //Thiet lap mac dinh
            InitializeComponent();
        }

        private void frmTaiBan_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            loadMenu();
            loadLoai();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTaiBan_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        private void loadMenu()
        {
            List<MENU> list = new List<MENU>();
            list = dal.getMenu();

            foreach(MENU i in list)
            {
                cardThucAn card = new cardThucAn(flowLayoutPanel1);
                card.Tenmon = i.tenmon;
                card.Giaban = i.giaban.Value;
                card.Hinh = i.hinh;

                panNoiDung.Controls.Add(card);
            }
        }
        private void loadLoai()
        {
            List<LOAI> list = new List<LOAI>();
            list = loai.getLoai();

            Button_Loai button = new Button_Loai(flowLayoutPanel3, panNoiDung, flowLayoutPanel1);
            button.Text = "Tất cả";

            flowLayoutPanel3.Controls.Add(button);

            foreach(LOAI i in list)
            {
                Button_Loai button1 = new Button_Loai(flowLayoutPanel3, panNoiDung, flowLayoutPanel1);
                button1.Text = i.tenloai;

                flowLayoutPanel3.Controls.Add(button1);
            }
        }

        private void flowLayoutPanel1_ClientSizeChanged(object sender, EventArgs e)
        {
            
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            tong = 0;
            foreach(Control c in this.flowLayoutPanel1.Controls)
            {
                cardChiTietThucAn item = c as cardChiTietThucAn;
                tong += item.Giaban * item.Soluong;
                //tong += item.tongMonAnKem();
            }
            txt_tongcong.Text = tong + ",000";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            panNoiDung.Controls.Clear();

            String search = txt_search.Text;

            List<MENU> list = dal.findFood(search);

            foreach (MENU i in list)
            {
                cardThucAn card = new cardThucAn(flowLayoutPanel1);
                card.Tenmon = i.tenmon;
                card.Giaban = i.giaban.Value;
                card.Hinh = i.hinh;

                panNoiDung.Controls.Add(card);
            }
        }

        private void gunaTextBox2_Click(object sender, EventArgs e)
        {
            txt_ghichu.Text = "";
            txt_ghichu.Clear();
        }

        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            frmThanhToan frm = new frmThanhToan(tong, flowLayoutPanel1, txt_ghichu.Text);
            frm.Show();
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            int tong = 0;
            foreach (Control c in this.flowLayoutPanel1.Controls)
            {
                cardChiTietThucAn item = c as cardChiTietThucAn;
                tong += item.Giaban * item.Soluong;
                //tong += item.tongMonAnKem();
            }
            txt_tongcong.Text = tong + ",000";
        }
    }
}
