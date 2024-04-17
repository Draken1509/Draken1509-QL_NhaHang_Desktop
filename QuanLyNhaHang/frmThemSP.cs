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
namespace QuanLyNhaHang
{
    
    public partial class frmThemSP : Form
    {
        int ID = 0;
        public frmThemSP(int id)
        {
            InitializeComponent();
            line_thnahphan.Visible = false;
            ID = id;
        }

        private void frmThemSP_Load(object sender, EventArgs e)
        {
            lbl_idmon.Text = ID.ToString().Trim();
            frmThongTinSP frm = new frmThongTinSP(ID);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            painMain.Controls.Add(frm);
            frm.Show();

        }

      
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_thanhPhan_Click(object sender, EventArgs e)
        {
            painMain.Controls.Clear();
            line_thongtinsanpham.Visible = false;
            line_thnahphan.Visible = true;
            lbl_idmon.Text = ID.ToString().Trim();

            frmThanhPhan frm = new frmThanhPhan(ID);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
          
            frm.Dock = DockStyle.Fill;
            painMain.Controls.Add(frm);
            frm.FormClosed += frmThemSP_FormClosed;
            frm.Show();

        }


        private void btn_ThongtinSP_Click(object sender, EventArgs e)
        {
           
            painMain.Controls.Clear();
            line_thongtinsanpham.Visible = true;
            line_thnahphan.Visible = false;



            lbl_idmon.Text = ID.ToString().Trim();
            frmThongTinSP frm = new frmThongTinSP(ID);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            painMain.Controls.Add(frm);
            frm.Show();
        }

        private void frmThemSP_FormClosed(object sender, FormClosedEventArgs e)
        {

            painMain.Controls.Clear();
            line_thongtinsanpham.Visible = false;
            line_thnahphan.Visible = true;
            lbl_idmon.Text = ID.ToString().Trim();

            frmThanhPhan frm = new frmThanhPhan(ID);
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            painMain.Controls.Add(frm);
            frm.Show();

        }

     
       
    }
}
