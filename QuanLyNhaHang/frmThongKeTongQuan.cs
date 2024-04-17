using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DAL;
using DTO;
using CustomControlThongKe;
namespace QuanLyNhaHang
{

    public partial class frmThongKeTongQuan : Form
    {

        // huu trung nè

        frmThoiGianTuyChinh frmtgtc;
        HoaDonDAL hoadondal = new HoaDonDAL();
        VoucherDAL voucherdal = new VoucherDAL();
        bool all = false;
        bool homnay = false;
        bool homqua = false;
        bool bayngayqua = false;
        bool muoibonngayqua = false;
        bool bamuoingayqua = false;
        bool tuannay = false;
        bool thangnay = false;
        bool tuantruoc = false;
        bool thangtruoc = false;

        DateTime bd = DateTime.Now;
        DateTime kt = DateTime.Now;
        SanPhamDAL sanphamdal = new SanPhamDAL();

        public frmThongKeTongQuan()
        {
            InitializeComponent();


            this.Load += frmThongKeTongQuan_Load;
            cbo_thonngke.SelectedIndex = 2;
            loadAllThongKe();
            lbl_ngatbatdau.Visible = true;
            //


        }

        public void loadAllThongKe()
        {


            //  int sohd = hoadondal.soLuongHD();
            // lbl_sohd.Text = hoadondal.soLuongHD().ToString();
            //lbl_giamgia.Text = voucherdal.soLuongVoucher().ToString();
            //lbl_chieukhau.Text = hoadondal.getDoanhThu().ToString();
            //lbl_doanhthu.Text = hoadondal.getDoanhThu().ToString();         


        }
        public void frmThongKeTongQuan_Load(object sender, EventArgs e)
        {
            // Tạo một loạt dữ liệu cho biểu đồ
            //Series series = new Series("Dữ liệu biểu đồ");
            //series.Points.AddXY("Mục 1", 10);
            //series.Points.AddXY("Mục 2", 20);
            //series.Points.AddXY("Mục 3", 15);
            //series.Points.AddXY("Mục 4", 30);

            //// Đặt loại biểu đồ thành biểu đồ cột
            //series.ChartType = SeriesChartType.Column;

            //// Thêm loạt dữ liệu vào biểu đồ
            //chart1.Series.Add(series);

            //// Đặt tiêu đề cho biểu đồ và các trục
            //chart1.Titles.Add("Biểu đồ cột đơn giản");
            //chart1.ChartAreas[0].AxisX.Title = "X-Axis";
            //chart1.ChartAreas[0].AxisY.Title = "Y-Axis";
        }

        private void panel_chart_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void CalendarUserControl_DateSelected(string selectedDate)
        {
            // Xử lý ngày đã chọn từ UserControl (Bộ lịch)

            lbl_ngatbatdau.Text = selectedDate;
            string input = selectedDate;

            // Tách chuỗi theo dấu gạch ngang
            string[] parts = input.Split('-');

            if (parts.Length >= 2)
            {
                // Lấy phần bắt đầu và kết thúc
                string startDateString = parts[0].Trim();
                string endDateString = parts[1].Trim();

                DateTime ngayDaChuyen_batdau = DateTime.ParseExact(startDateString, "dd/MM/yyyy", null);
                DateTime ngayDaChuyen_kethuc = DateTime.ParseExact(endDateString, "dd/MM/yyyy", null);

                string ngayDaChuyen_batdau_format = ngayDaChuyen_batdau.ToString("yyyy/MM/dd");
                string ngayDaChuyen_kethuc_format = ngayDaChuyen_kethuc.ToString("yyyy/MM/dd");

                DateTime ngayDaChuyen_batdau_cpt = DateTime.ParseExact(ngayDaChuyen_batdau_format, "yyyy/MM/dd", null);
                DateTime ngayDaChuyen_kethuc_cpt = DateTime.ParseExact(ngayDaChuyen_kethuc_format, "yyyy/MM/dd", null);

                bd = ngayDaChuyen_batdau_cpt;
                kt = ngayDaChuyen_kethuc_cpt;
            }
            else
            {
                Console.WriteLine("Chuỗi không hợp lệ");
            }
        }




        public void layTTDAL()
        {


            DateTime ngaybd = bd;
            DateTime ngaykt = kt;

            int tt = 3;
            ThongTinThongKe a = new ThongTinThongKe();
            a = hoadondal.getThongKe(all, homnay, homqua, bayngayqua, muoibonngayqua, bamuoingayqua, tuannay, thangnay, tuantruoc, thangtruoc, ngaybd, ngaykt, tt);
            lbl_sohd.Text = a.SoLuongHd.ToString();
            lbl_soDonDaHoanThanh.Text = a.SoLuongHd.ToString();
            lbl_doanhso.Text = a.SoLuongHd.ToString();
            lbl_sokhachhangdahoanthanh.Text = a.SoLuongHd.ToString();

            lbl_doanhthu.Text = a.DoanhThu.ToString();
            if (lbl_doanhthu.Text != "0")
            {
                lbl_doanhthu.Text = lbl_doanhthu.Text + "000";
            }

            lbl_tongtienmat.Text = a.TongTienMat.ToString();
            if (lbl_tongtienmat.Text != "0")
            {
                lbl_tongtienmat.Text = lbl_tongtienmat.Text + "000";
            }

            lbl_tongchuyenkhoan.Text = a.TongChuyenKhoan.ToString();
            lbl_soluonghdtienmat.Text = a.SoTienMat.ToString();
            lbl_soluonghoadonchuyenkhoan.Text = a.SoChuyenKhoan.ToString();

            lbl_soDonDaHuy.Text = a.SoDonDaHuy.ToString();

            lbl_sodononline.Text = a.SoDonOnline.ToString();
            lbl_sodonoffline.Text = a.SoDonOffline.ToString();
            lbl_giamgia.Text = a.SoVoucher.ToString();


            lbl_tongtiendonoffline.Text = a.TongTienDonOffline.ToString();
            if (lbl_tongtiendonoffline.Text != "0")
            {
                lbl_tongtiendonoffline.Text = lbl_tongtiendonoffline.Text + "000";
            }
            lbl_tongtiendononline.Text = a.TongTienDonOnline.ToString();
            if (lbl_tongtiendononline.Text != "0")
            {
                lbl_tongtiendononline.Text = lbl_tongtiendononline.Text + "000";
            }

        }

        private void cbo_thonngke_SelectedIndexChanged(object sender, EventArgs e)
        {

            DateTime ngaybd = DateTime.Now;
            DateTime ngaykt = DateTime.Now;
            int tt = 3;
            if (cbo_thonngke.SelectedIndex == 0)
            {
                
             

                MyCustomCalendar calendarUserControl = new MyCustomCalendar();
                calendarUserControl.DateSelected += CalendarUserControl_DateSelected;
                // Hiển thị UserControl trong một Form mới
                using (var calendarForm = new Form())
                {
                    calendarForm.Controls.Add(calendarUserControl);
                    calendarForm.StartPosition = FormStartPosition.Manual;
                    calendarForm.Location = new Point(
                        this.Location.X + (this.Width - calendarForm.Width) / 2,
                        this.Location.Y + (this.Height - calendarForm.Height) / 2
                    );

                    // Thiết lập kích thước (ví dụ: 300x200)
                    calendarForm.Size = new Size(700, 460);


                    calendarForm.ShowDialog();  // Chờ đến khi Form con đóng
                }

                lbl_ngatbatdau.Visible = true;
                layTTDAL();

            }
            else if (cbo_thonngke.SelectedIndex == 1)
            {

                all = true;
                layTTDAL();
                all = false;
                lbl_ngatbatdau.Text = "Tất cả";
                lbl_ngatbatdau.Visible = true;
            }
            else if (cbo_thonngke.SelectedIndex == 2)  //hom nay
            {
                lbl_ngatbatdau.Text = sanphamdal.layNgayHomNay().ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                homnay = true;
                layTTDAL();
                homnay = false;
               

            }
            else if (cbo_thonngke.SelectedIndex == 3)
            {
                lbl_ngatbatdau.Text = sanphamdal.layNgayHomQua().ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;
                homqua = true;
                layTTDAL();
                homqua = false;
            }
            else if (cbo_thonngke.SelectedIndex == 4)
            {
                DateTime ngayhomnay = DateTime.Now;
                lbl_ngatbatdau.Text = sanphamdal.layNNgayQua(7).ToString("dd/MM/yyyy")
                    + " - " + ngayhomnay.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                bayngayqua = true;
                layTTDAL();
                bayngayqua = false;
             
            }
            else if (cbo_thonngke.SelectedIndex == 5)
            {
                DateTime ngayhomnay = DateTime.Now;
                lbl_ngatbatdau.Text = sanphamdal.layNNgayQua(14).ToString("dd/MM/yyyy")
                    + " - " + ngayhomnay.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                muoibonngayqua = true;
                layTTDAL();
                muoibonngayqua = false;
               
            }
            else if (cbo_thonngke.SelectedIndex == 6)
            {
                DateTime ngayhomnay = DateTime.Now;
                lbl_ngatbatdau.Text = sanphamdal.layNNgayQua(30).ToString("dd/MM/yyyy")
                    + " - " + ngayhomnay.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                bamuoingayqua = true;
                layTTDAL();
                bamuoingayqua = false;
               
            }
            else if (cbo_thonngke.SelectedIndex == 7)
            {
                KhoangThoiGian tg = sanphamdal.layTuanNay();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yyyy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                tuannay = true;
                layTTDAL();
                tuannay = false;
              
            }
            else if (cbo_thonngke.SelectedIndex == 8)
            {
                KhoangThoiGian tg = sanphamdal.layThangNay();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yyyy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                thangnay = true;
                layTTDAL();
                thangnay = false;
            
            }
            else if (cbo_thonngke.SelectedIndex == 9)
            {

                KhoangThoiGian tg = sanphamdal.layTuanTruoc();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yyyy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                tuantruoc = true;
                layTTDAL();
                tuantruoc = false;
              
            }
            else if (cbo_thonngke.SelectedIndex == 10)
            {
                KhoangThoiGian tg = sanphamdal.layThangTruoc();
                lbl_ngatbatdau.Text = tg.NgayBatDau.ToString("dd/MM/yyyy") +
                    " - " + tg.NgayKetThuc.ToString("dd/MM/yyyy");
                lbl_ngatbatdau.Visible = true;

                thangtruoc = true;
                layTTDAL();
                thangtruoc = false;
             
            }

        }

        private void btn_word_Click(object sender, EventArgs e)
        {
            WordExport wordExport = new WordExport();

            string ngay = DateTime.Now.Day.ToString();
            string thang = DateTime.Now.Month.ToString();
            string nam = DateTime.Now.Year.ToString();
            string thoigian= lbl_ngatbatdau.Text.ToString();
            string doanhthu=lbl_doanhthu.Text.ToString();
            string hoadonoffline=lbl_sodonoffline.Text;
            string hoadononline=lbl_sodononline.Text;
            string tongienhoadonoffline = lbl_tongtiendonoffline.Text;
            string tongienhoadononline= lbl_tongtiendononline.Text;
            string hoadonhuy = lbl_soDonDaHuy.Text;
            wordExport.thongkedoanhthu(ngay,
                thang, nam, thoigian, doanhthu, hoadonoffline,
                hoadononline, tongienhoadonoffline
                ,tongienhoadononline,hoadonhuy);
            
            string[] fields = new string[] { "ngay", "thang",
                
                "nam", "thoigian", "doanhthu","hoadonoffline", 

                 "hoadononline","tongienhoadonoffline", "tongienhoadononline","hoadonhuy" };
        }



    }
}
