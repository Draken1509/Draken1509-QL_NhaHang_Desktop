using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControlThongKe
{
    public partial class cardThem : UserControl
    {
        public cardThem()
        {
            InitializeComponent();
        }
        private int id_dak;

        public int Id_dak
        {
            get { return id_dak; }
            set { id_dak = value; }
        }

        private String tendak;

        public String Tendak
        {
            get { return tendak; }
            set { 
                tendak = value;
                txt_tendak.Text = value;
            }
        }
        private int giaban;

        public int Giaban
        {
            get { return giaban; }
            set { 
                giaban = value;
                txt_giatien.Text = value + ",000";
            }
        }

        //private int soluong;

        public int Soluong
        {
            get { return int.Parse(txt_soluong.Text); }
        }

        public int Giaban2
        {
            get { return int.Parse(txt_giatien.Text); }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int count = int.Parse(txt_soluong.Text);
            count++;
            txt_soluong.Text = count.ToString();
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            int count = int.Parse(txt_soluong.Text);
            count--;
            if(count <0)
            {
                txt_soluong.Text = "0";
            }
            else
            {
                txt_soluong.Text = count.ToString();
            }
        }
    }
}
