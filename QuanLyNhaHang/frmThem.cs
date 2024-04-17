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
namespace QuanLyNhaHang
{
    public partial class frmThem : Form
    {
        frmSanPham frmsanpham;
        frmThemSP frmthemsanpham;
        frmThem frmthem;
        public frmThem()
        {
            
            InitializeComponent();
          
                    
        }

        private void cardMoRong1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

      

        private void cardMoRong1_Load_2(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaCircleButton7_Click(object sender, EventArgs e)
        {
            frmSanPham frmthemsp = new frmSanPham();
            frmthemsp.FormBorderStyle = FormBorderStyle.None;
            frmthemsp.WindowState = FormWindowState.Maximized;
            frmthemsp.BringToFront();
            frmthemsp.ShowDialog();  
        }

        void frmsanpham_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            frmDonOnline frmdononline = new frmDonOnline();
            frmdononline.TopLevel = false;
            frmdononline.Dock = DockStyle.Fill;
            

            frmdononline.Show();
        }

       
       

    }
}
