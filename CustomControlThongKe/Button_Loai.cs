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
using DAL;
using CustomControlThongKe;

namespace CustomControlThongKe
{
    public partial class Button_Loai : GunaButton
    {
        MenuDAL dal = new MenuDAL();
        FlowLayoutPanel panel;
        FlowLayoutPanel panelMenu;
        FlowLayoutPanel panelhoadon;
        public Button_Loai(FlowLayoutPanel panel, FlowLayoutPanel panelMenu, FlowLayoutPanel panelhoadon)
        {
            InitializeComponent();
            this.panel = panel;
            this.panelMenu = panelMenu;
            this.panelhoadon = panelhoadon;
            this.Size = new Size(180, 52);
            this.OnPressedDepth = 30;
            this.OnPressedColor = Color.Maroon;
            this.OnHoverForeColor = Color.WhiteSmoke;
            this.OnHoverBorderColor = Color.FromArgb(255, 128, 0);
            this.OnHoverBaseColor = Color.FromArgb(255, 159, 3);
            this.BaseColor = Color.White;
            this.BorderColor = Color.FromArgb(255, 128, 0);
            this.BorderSize = 1;
            this.ForeColor = Color.Gray;
            this.TextAlign = HorizontalAlignment.Left;
            this.OnHoverImage = null;
            this.Image = null;
            this.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            this.Click += btn_Loai_onClick;
        }
        public void btn_Loai_onClick(object sender, EventArgs e)
        {
            foreach(Control c in panel.Controls)
            {
                if(c is GunaButton)
                {
                    GunaButton btn = c as GunaButton;
                    if(btn.Text.Equals(this.Text))
                    {
                        btn.BaseColor = Color.FromArgb(255, 159, 3);
                        btn.ForeColor = Color.White;
                        loadMenu(this.Text);
                    }
                    else
                    {
                        btn.BaseColor = Color.White;
                        btn.ForeColor = Color.Gray;
                    }
                }
            }
        }
        private void loadMenu(String tenloai)
        {
            panelMenu.Controls.Clear();
            List<MENU> list = new List<MENU>();
            if(tenloai.Equals("Tất cả"))
            {
                list = dal.getMenu();
            }
            else
            {
                list = dal.getMenuFollowFilterCategory(tenloai);
            }
            
            foreach (MENU i in list)
            {
                cardThucAn card = new cardThucAn(panelhoadon);
                card.Tenmon = i.tenmon;
                card.Giaban = i.giaban.Value;
                card.Hinh = i.hinh;

                panelMenu.Controls.Add(card);
            }
        }
    }
}
