using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class frmMainThemMenu : Form
    {
        public frmMainThemMenu()
        {
            InitializeComponent();
        }

       

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMainThemMenu_Load(object sender, EventArgs e)
        {
            frmThemMenu frm = new frmThemMenu();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            painMain.Controls.Add(frm);
            frm.Show();
        
        }
       


    }
}
