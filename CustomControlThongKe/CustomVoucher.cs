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
    public partial class CustomVoucher : UserControl
    {
        public CustomVoucher()
        {
            InitializeComponent();
        }
        private String tenvoucher;

        public String Tenvoucher
        {
            get { return tenvoucher; }
            set { 
                tenvoucher = value;
                txt_tenvoucher.Text = value;
            }
        }
        private int mavoucher;

        public int Mavoucher
        {
            get { return mavoucher; }
            set { 
                mavoucher = value;
                txt_mavoucher.Text = value.ToString();
            }
        }
        private String ngaybatdau;

        public String Ngaybatdau
        {
            get { return ngaybatdau; }
            set { 
                ngaybatdau = value;
                txt_ngaybatdau.Text = value;
            }
        }
        private String ngayketthuc;

        public String Ngayketthuc
        {
            get { return ngayketthuc; }
            set { 
                ngayketthuc = value;
                txt_ngayhetthan.Text = value;
            }
        }
        private String mucgiam;

        public String Mucgiam
        {
            get { return mucgiam; }
            set { 
                mucgiam = value;
                txt_mucgiam.Text = value;
            }
        }
        private int yeucau;

        public int Yeucau
        {
            get { return yeucau; }
            set { 
                yeucau = value;
                txt_yeucau.Text = value + ",000";
            }
        }
    }
}
