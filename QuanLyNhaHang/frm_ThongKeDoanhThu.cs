using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using DTO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;
namespace QuanLyNhaHang
{
    public partial class frm_ThongKeDoanhThu : Form
    {
        DoanhThuDAL doanhthudal = new DoanhThuDAL();
        public frm_ThongKeDoanhThu()
        {
            InitializeComponent();
            loadCboNam();

            cbo_thangtatca.SelectedIndex = 0; 
            cbo_nam.SelectedIndex = cbo_nam.Items.Count-1;                                        
        }

        public void loadCboNam(){            
            List<int> lst = doanhthudal.getAllNam();
            cbo_nam.DataSource = lst;
        }
        public void createChartNam( int nam)
        {
           
            //if (!chart_dt.Series.Any(s => s.Name == "doanhthu"))
            //{
            //    chart_dt.Series.Add(new Series("doanhthu"));
            //    chart_dt.Series["doanhthu"].ChartType = SeriesChartType.Column;
            //}

            chart_dt.Series["doanhthu"].Points.Clear();
            List<DoanhThu> doanhthu = doanhthudal.getDoanhThuTheoNam(nam);
            foreach (var item in doanhthu)
            {
                chart_dt.Series["doanhthu"].Points.AddXY(item.Thang, item.Doanhthu);
            }

            chart_dt.Series["doanhthu"].IsValueShownAsLabel = true;
            chart_dt.ChartAreas[0].AxisX.Title = "Tháng";
            chart_dt.ChartAreas[0].AxisY.Title = "Doanh thu";
        }
        public void loadDataGirdView(int nam)
        {
            dtgv_doanhthu.DataSource = doanhthudal.getDoanhThuTheoNam(nam);
            dtgv_doanhthu.Columns["Thang"].HeaderText = "Tháng";
            dtgv_doanhthu.Columns["Doanhthu"].HeaderText = "Doanh thu";      
            dtgv_doanhthu.Refresh();
        }

        private void cbo_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbo_thangtatca.SelectedIndex == 0)
            {

                int nam = int.Parse(cbo_nam.SelectedItem.ToString().Trim());
                loadDataGirdView(nam);
                createChartNam(nam);
            }
            else
            {
                string thang = "";
                if (cbo_thangtatca.SelectedIndex != -1)
                {
                    thang = cbo_thangtatca.SelectedItem.ToString().Trim();
                    string[] parts = thang.Split(' ');
                    int t = int.Parse(parts[1].ToString().Trim());
                    Console.Write("tháng :" + t);
                    int nam = int.Parse(cbo_nam.SelectedItem.ToString().Trim());
                    loadDataGirdView_Thang(nam, t);
                    createChartNam_Thang(nam, t);
                }

                  
            }                     
        }

        private void cbo_thangtatca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_thangtatca.SelectedIndex == 0)
            {

                int nam = int.Parse(cbo_nam.SelectedItem.ToString().Trim());
                loadDataGirdView(nam);
                createChartNam(nam);
            }
            else 
            {
                string thang = "";
                if (cbo_thangtatca.SelectedIndex != -1)
                {
                    thang = cbo_thangtatca.SelectedItem.ToString().Trim();
                    string[] parts = thang.Split(' ');
                    int t = int.Parse(parts[1].ToString().Trim());
                    Console.Write("tháng :" + t);
                    int nam = int.Parse(cbo_nam.SelectedItem.ToString().Trim());
                    loadDataGirdView_Thang(nam, t);
                    createChartNam_Thang(nam, t);
                }
                
            }
        }



        public void createChartNam_Thang(int nam, int thang)
        {
            chart_dt.Series["doanhthu"].Points.Clear();
            List<DoanhThu> doanhthu = doanhthudal.getDoanhThuTheoThangNam(nam, thang);
            foreach (var item in doanhthu)
            {
                chart_dt.Series["doanhthu"].Points.AddXY(item.Thang, item.Doanhthu);
            }
            chart_dt.Series["doanhthu"].IsValueShownAsLabel = true;
            chart_dt.ChartAreas[0].AxisX.Title = "Ngày";
            chart_dt.ChartAreas[0].AxisY.Title = "Doanh thu";
        }
        public void loadDataGirdView_Thang(int nam, int thang)
        {
            dtgv_doanhthu.DataSource = doanhthudal.getDoanhThuTheoThangNam(nam,thang);
            dtgv_doanhthu.Columns["Thang"].HeaderText = "Ngày";
            dtgv_doanhthu.Columns["Doanhthu"].HeaderText = "Doanh thu";
            dtgv_doanhthu.Refresh();
        }

       

    }
}
